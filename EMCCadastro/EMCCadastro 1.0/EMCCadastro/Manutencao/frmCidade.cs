using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmCidade : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCidade";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        private string sitOperacao = "";

#region "metodos do form"
        public frmCidade(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmCidade()
        {
            InitializeComponent();
        }

        private void frmCidade_Activated(object sender, EventArgs e)
        {


        }
    
        private void frmCidade_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "cidade";

            AtualizaGrid();
            this.ActiveControl = txtCepCidade;
            CancelaOperacao();
            sitOperacao = "C";
        }
#endregion

#region "metodos para tratamento das informacoes"
        
        private Cidade montaCidade()
        {
            Cidade oCidade = new Cidade();
            oCidade.cepCidade = txtCepCidade.Text;
            
            IbgeCidade oIbge = new IbgeCidade();
            oIbge.codigoIbge = txtCodigoIbge.Text;
            IbgeCidadeRN oIbgeRN = new IbgeCidadeRN(Conexao, objOcorrencia, codempresa);
            oIbge = oIbgeRN.ObterPor(oIbge);
            oCidade.ibgeCidade = oIbge;

            oCidade.nomeCidade = oIbge.nomeCidade;

            return oCidade;
        }
        
        private void montaTela(Cidade oCidade)
        {
            txtCepCidade.Text = oCidade.cepCidade;
            txtNomeCidade.Text = oCidade.ibgeCidade.nomeCidade + " - " + oCidade.ibgeCidade.estado.abreviatura;
            txtCodigoIbge.Text = oCidade.ibgeCidade.codigoIbge;
            
            objOcorrencia.chaveidentificacao = oCidade.cepCidade.ToString();
            txtCepCidade.ReadOnly = true;
            
            txtCodigoIbge.Focus();
            
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
        
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtCepCidade.Enabled = false;
            sitOperacao = "A";
            
        }
        
        public override void AtivaInsercao()
        {
            
            base.AtivaInsercao();

            if (sitOperacao != "I")
            {
                txtCepCidade.Enabled = true;
                txtCepCidade.ReadOnly = false;
                txtCepCidade.Focus();
                sitOperacao = "I";
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
            txtCepCidade.Enabled = true;
            txtCepCidade.ReadOnly = false;
            txtCepCidade.Focus();
            sitOperacao = "C";

        }

        public override void BuscaObjeto()
        {
           try
            {
                //psqCidade ofrm = new psqCidade (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                //ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdCidade.Value.ToString() = "";
                    
                }
                else
                {
                    txtCodigoIbge.Enabled = true;
                    txtCepCidade.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtCepCidade.Focus();
                    SendKeys.Send("{TAB}");
                 }
            }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Cidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   
        public void BuscaCidade()
        {

            if (!String.IsNullOrEmpty(txtCodigoIbge.Value.ToString()))
            {

                Cidade oCidade = new Cidade();
                oCidade.cepCidade = txtCepCidade.Text;
                try
                {
                    if (EmcResources.cInt(txtCepCidade.Text)>0)
                    {
                        CidadeRN CidadeBLL = new CidadeRN(Conexao, objOcorrencia, codempresa);
                        oCidade = CidadeBLL.ObterPor(oCidade);

                        if (oCidade.cepCidade.Equals(null) || EmcResources.cInt(oCidade.cepCidade) == 0)
                        {
                            DialogResult result = MessageBox.Show("Cidade não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                sitOperacao = "I";
                                AtivaInsercao();
                            }
                            else
                            {
                                CancelaOperacao();
                            }
                        }
                        else
                        {
                            montaTela(oCidade);
                            AtivaEdicao();
                        }

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Documento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtCepCidade.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Cidade oCidade = new Cidade();
                CidadeRN oUFBLL = new CidadeRN(Conexao, objOcorrencia, codempresa);
                oCidade = montaCidade();

                oUFBLL.Salvar(oCidade);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Cidade oCidade = new Cidade();
                CidadeRN oCidadeBLL = new CidadeRN(Conexao,objOcorrencia,codempresa);
                oCidade = montaCidade();
                oCidade.cepCidade = txtCepCidade.Text;

                oCidadeBLL.Atualizar(oCidade);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Cidade oCidade = new Cidade();
                CidadeRN oCidadeBLL = new CidadeRN(Conexao,objOcorrencia,codempresa);
                oCidade = montaCidade();
                oCidade.cepCidade = txtCepCidade.Text;

                oCidadeBLL.Excluir(oCidade);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relCidade ofrm = new Relatorios.relCidade(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Cidade: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    #endregion

#region "metodos da dbgrid"

        private void grdCidade_DoubleClick(object sender, EventArgs e)
        {
            txtCepCidade.Enabled = true;
            txtCepCidade.Text = grdCidade.Rows[grdCidade.CurrentRow.Index].Cells["cepcidade"].Value.ToString();
            txtCepCidade.Focus();
            SendKeys.Send("{TAB}");
            
        }

        private void AtualizaGrid()
        {
            try
            {
                //carrega a grid com os Cidades cadastrados
                CidadeRN objCidade = new CidadeRN(Conexao, objOcorrencia, codempresa);
                grdCidade.DataSource = objCidade.ListaCidade();
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

      
        private void txtCodigoIbge_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtCodigoIbge.Text) > 0)
                {

                    IbgeCidade oIbge = new IbgeCidade();
                    IbgeCidadeRN oIbgeRN = new IbgeCidadeRN(Conexao, objOcorrencia, codempresa);

                    oIbge.codigoIbge = txtCodigoIbge.Text;
                    oIbge = oIbgeRN.ObterPor(oIbge);

                    if (oIbge.idIbgeCidade == 0)
                    {
                        MessageBox.Show("Código do IBGE não Cadastrado", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdIbgeCidade.Text = oIbge.idIbgeCidade.ToString();
                        txtNomeCidade.Text = oIbge.nomeCidade + "-" + oIbge.estado.abreviatura;
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCepCidade_Validating(object sender, CancelEventArgs e)
        {
            BuscaCidade();
        }

        private void btnBuscaCep_Click(object sender, EventArgs e)
        {
            try
            {
                psqIbgeCidade ofrm = new psqIbgeCidade(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtCodigoIbge.Text = "";
                else
                    txtCodigoIbge.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtCodigoIbge.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
