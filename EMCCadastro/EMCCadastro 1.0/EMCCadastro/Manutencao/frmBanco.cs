using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmBanco : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmBanco";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public frmBanco(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        #region "Configurações do Form"
     
        private void frmBanco_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "banco";
         

            AtualizaGrid();
            this.ActiveControl = txtidBanco;
            CancelaOperacao();
        }

        #endregion

        #region "metodos para tratamento das informacoes******************************************************************"
        
        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relCadastroBanco ofrm = new Relatorios.relCadastroBanco(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Banco : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            txtidBanco.Enabled = false;
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtidBanco.Enabled = true;
            txtidBanco.ReadOnly = false;
            txtidBanco.Focus();
        }

        public override void AtualizaTela()
        {
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqBanco ofrm = new psqBanco(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidBanco.Enabled = true;
                    txtidBanco.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtidBanco.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            //txtidEmpresa.Enabled = false;
            txtidBanco.Enabled = true;
            txtidBanco.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                Banco oBanco = new Banco(Int32.Parse(txtidBanco.Text), txtDescricao.Text);
                BancoRN oBancoBLL = new BancoRN(Conexao,objOcorrencia,codempresa);
                oBancoBLL.Salvar(oBanco);
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
            AtualizaGrid();

        }

        public override void AtualizaObjeto()
        {
            try
            {

                BancoRN oBancoBLL = new BancoRN(Conexao,objOcorrencia,codempresa);

                Banco oBanco = new Banco(Convert.ToInt32(txtidBanco.Text), txtDescricao.Text);
                oBancoBLL.Atualizar(oBanco);

                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.AtualizaObjeto();
            AtualizaGrid();

        }

        public override void ExcluiObjeto()
        {
            try
            {
                Banco oBanco = new Banco();
                oBanco.idBanco = Convert.ToInt32(txtidBanco.Text);
                BancoRN oBLL = new BancoRN(Conexao,objOcorrencia,codempresa);
                oBLL.Excluir(oBanco);


                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
            AtualizaGrid();
        }
       
        public void pesquisaBanco()
        {
            if (txtidBanco.Text.Trim().Length > 0)
            {
                Banco oBanco = new Banco();
                try
                {

                    BancoRN bancoBLL = new BancoRN(Conexao, objOcorrencia,codempresa);
                    oBanco.idBanco = Convert.ToInt32(txtidBanco.Text);
                    oBanco = bancoBLL.ObterPor(oBanco);
                                                        

                        if (oBanco.idBanco == 0)
                        {
                            DialogResult result = MessageBox.Show("Banco não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                AtivaInsercao();
                            }

                            else
                            {
                                CancelaOperacao();
                            }

                        }
                        else
                        {

                            txtDescricao.Text = oBanco.descricao;
                            objOcorrencia.chaveidentificacao = oBanco.idBanco.ToString();
                            AtivaEdicao();
                        }
                   

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Banco: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtidBanco.Enabled = true;
                txtidBanco.Focus();

            }
           

        }

#endregion

#region "Text´s e Button´s*****************************************************************************************"

        private void txtidBanco_Validating(object sender, CancelEventArgs e)
        {
            pesquisaBanco();
        }

#endregion

#region "metodos da dbgrid*****************************************************************************************"

        private void grdBanco_DoubleClick(object sender, EventArgs e)
        {
            txtidBanco.Enabled = true;
            txtidBanco.Text = grdBanco.Rows[grdBanco.CurrentRow.Index].Cells["idBanco"].Value.ToString();
            txtidBanco.Focus();
            SendKeys.Send("{TAB}");
     
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os bancos 
            BancoRN oBLL = new BancoRN(Conexao,objOcorrencia,codempresa);
            Banco oBanco = new Banco();
            grdBanco.DataSource = oBLL.ListaBanco(oBanco);

        }


#endregion

  

    }
}
