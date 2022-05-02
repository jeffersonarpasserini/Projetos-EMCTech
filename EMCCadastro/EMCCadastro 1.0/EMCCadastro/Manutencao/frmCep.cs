using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmCep : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCEP";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        private string sitOperacao = "C";
        public frmCep(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmCep()
        {
            InitializeComponent();
        }
            
   
        private void frmCep_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "cep";

            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.Estados)))
            cboEstado.Items.Add(s);

            this.ActiveControl = txtidCep;
            CancelaOperacao();
            AtualizaGrid();
        }

        private void montaTela(Cep oCep)
        {            
            txtidCep.Text = oCep.idCep.ToString();
            //txtIdAplicacao.Enabled = false;
            txtidCep.ReadOnly = true;
            //objOcorrencia.chaveidentificacao = oAplicacao.idAplicacao.ToString();
            txtidCep.Focus();
        }
     
        private Cep montaCep()
        {
            Cidade oCidade = new Cidade();
            oCidade.cepCidade = txtidCep.Text.ToString().Substring(0,5);

            CidadeRN oCidadeRN = new CidadeRN(Conexao, objOcorrencia, codempresa);
            oCidade = oCidadeRN.ObterPor(oCidade);

            Cep oCep = new Cep();
            //oCep.idCep = txtidCep.Value.ToString();
            oCep.idCep = txtidCep.Text.ToString();
            oCep.logradouro = txtLogradouro.Text;
            oCep.bairro = txtBairro.Text;
            oCep.cidade = txtCidade.Text;
            oCep.estado = cboEstado.Text;
            oCep.cepCidade = oCidade;

            return oCep;
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtidCep.ReadOnly = true;
            txtidCep.Enabled = false;
            sitOperacao = "A";
         
        }
       
        public override void AtivaInsercao()
        {
            if (sitOperacao != "I")
            {
                sitOperacao = "I";
                base.AtivaInsercao();
                txtidCep.ReadOnly = false;
                txtidCep.Enabled = true;
                txtidCep.Focus();
            }
        }
       
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidCep.Enabled = true;
            txtidCep.Focus();
            sitOperacao = "C";
        }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }
       
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqCep ofrm = new psqCep(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdCep.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidCep.Enabled = true;
                    txtidCep.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtidCep.Focus();
                    SendKeys.Send("{TAB}");
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            
        }

        public override void SalvaObjeto()
        {
            try
            {
                Cep oCep = new Cep();
                oCep = montaCep();
                CepRN oCepBLL = new CepRN(Conexao,objOcorrencia,codempresa);
                oCepBLL.Salvar(oCep);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cep: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {

                Cep oCep = new Cep();
                oCep = montaCep();
                CepRN oCepBLL = new CepRN(Conexao,objOcorrencia,codempresa);
                oCepBLL.Atualizar(oCep);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cep: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {

                Cep oCep = new Cep();
                oCep = montaCep();
                CepRN oCepBLL = new CepRN(Conexao,objOcorrencia,codempresa);
                oCepBLL.Excluir(oCep);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cep: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            
            //base.ImprimeObjeto();
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relCEP ofrm = new Relatorios.relCEP(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Cep: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void buscaCep()
        {
              base.BuscaObjeto();

            if (txtidCep.Text.Trim().Length == 8)
            {
                Cep oCep = new Cep(txtidCep.Text.ToString(), "", "", "");
                try
                {

                    Cidade oCidade = new Cidade();
                    CidadeRN oCidadeRN = new CidadeRN(Conexao, objOcorrencia, codempresa);
                    //oCidade.cepCidade = txtidCep.Value.ToString().Substring(0, 5);
                    oCidade.cepCidade = txtidCep.Text.Substring(0, 5);

                    oCidade = oCidadeRN.ObterPor(oCidade);

                    if (String.IsNullOrEmpty(oCidade.cepCidade))
                    {
                        MessageBox.Show("CEP Principal da Cidade não Cadastrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtidCep.Focus();
                    }
                    else
                    {

                        CepRN cepBLL = new CepRN(Conexao, objOcorrencia, codempresa);
                        oCep = cepBLL.ObterPor(oCep);
                        if (oCep.idCep == null)
                        {
                            DialogResult result = MessageBox.Show("Cep não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                
                                AtivaInsercao();
                                txtLogradouro.Focus();
                                txtCidade.Text = oCidade.ibgeCidade.nomeCidade;
                                cboEstado.Text = oCidade.ibgeCidade.estado.abreviatura;

                            }
                            else
                            {
                                CancelaOperacao();
                            }

                        }
                        else
                        {
                            //txtidCep.Text = oCep.idCep;
                            txtBairro.Text = oCep.bairro;
                            txtCidade.Text = oCep.cidade;
                            cboEstado.Text = oCep.estado;
                            txtLogradouro.Text = oCep.logradouro;
                            objOcorrencia.chaveidentificacao = txtidCep.Text;
                            AtivaEdicao();
                        }
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Cep: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        

        #endregion

        #region "metodos da dbgrid"

        private void grdCep_DoubleClick(object sender, EventArgs e)
        {
            txtidCep.Enabled = true;
            txtidCep.Text = grdCep.Rows[grdCep.CurrentRow.Index].Cells["idCep"].Value.ToString();
            txtidCep.Focus();
            SendKeys.Send("{TAB}");
     
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            CepRN objCep = new CepRN(Conexao,objOcorrencia,codempresa);
            grdCep.DataSource = objCep.ListaCep();
        }


        #endregion

        private void txtidCep_TextChanged(object sender, EventArgs e)
        {
            //BuscaObjeto();
        }

        private void txtidCep_Validating(object sender, CancelEventArgs e)
        {
            buscaCep();
        }

        private void txtidCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

    }
}
