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
    public partial class frmAplicacao : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario="frmAplicacao";
        private const string nomeAplicativo = "EMCCadastro";
        
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        
        

        public frmAplicacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;

            InitializeComponent();
        }

#region "metodos do form"

        public frmAplicacao()
        {
            InitializeComponent();
        }

            
        private void frmAplicacao_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome =nomeAplicativo;
            objOcorrencia.aplicativo=oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "aplicacao";

            this.ActiveControl = txtIdAplicacao;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion
        
        #region "metodos para tratamento das informacoes"
       
        private Aplicacao montaAplicacao()
        {
            Aplicacao oAplicacao = new Aplicacao();
            oAplicacao.descricao = txtDescricao.Text;
            oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Text);

            return oAplicacao;
        }
       
        private void montaTela(Aplicacao oAplicacao)
        {
            txtDescricao.Text = oAplicacao.descricao;
            txtIdAplicacao.Text = oAplicacao.idAplicacao.ToString();
            txtIdAplicacao.ReadOnly = true;
            objOcorrencia.chaveidentificacao = oAplicacao.idAplicacao.ToString();
            txtDescricao.Focus();
        }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao,Convert.ToInt32(usuario),nomeAplicativo,nomeFormulario,btnFlag))
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
            txtIdAplicacao.Enabled = false;
        }
       
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
        }
        
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtIdAplicacao.ReadOnly = false;
            txtIdAplicacao.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtIdAplicacao.Focus();
        }
       
        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relAplicacao ofrm = new Relatorios.relAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Aplicação: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        
        public override void BuscaObjeto()
        {
           //base.BuscaObjeto();
            try
            {
                psqAplicacao ofrm = new psqAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0){
                   // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
            }
                else
            {
                txtIdAplicacao.Enabled = true;
                txtIdAplicacao.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                txtIdAplicacao.Focus();
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
            txtIdAplicacao.ReadOnly = true;
            txtDescricao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Aplicacao oAplicacao = new Aplicacao();
                AplicacaoRN oAplicacaoBLL = new AplicacaoRN(Conexao,objOcorrencia,codempresa);
                oAplicacao = montaAplicacao();

                oAplicacaoBLL.Salvar(oAplicacao);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Aplicação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Aplicacao oAplicacao = new Aplicacao();
                AplicacaoRN oAplicacaoBLL = new AplicacaoRN(Conexao,objOcorrencia,codempresa);
                oAplicacao = montaAplicacao();
                oAplicacao.idAplicacao = Convert.ToInt32(txtIdAplicacao.Text);

                oAplicacaoBLL.Atualizar(oAplicacao);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Aplicação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Aplicacao oAplicacao = new Aplicacao();
                AplicacaoRN oAplicacaoBLL = new AplicacaoRN(Conexao,objOcorrencia,codempresa);
                oAplicacao = montaAplicacao();
                oAplicacao.idAplicacao = Convert.ToInt32(txtIdAplicacao.Text);

                oAplicacaoBLL.Excluir(oAplicacao);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Aplicação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.ExcluiObjeto();
        }

        public void BuscaAplicacao()
        {

            if (!String.IsNullOrEmpty(txtIdAplicacao.Text))
            {

                Aplicacao oAplicacao = new Aplicacao();
                oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Text);

                try
                {
                    AplicacaoRN AplicacaoBLL = new AplicacaoRN(Conexao, objOcorrencia, codempresa);

                    oAplicacao = montaAplicacao();

                    oAplicacao = AplicacaoBLL.ObterPor(oAplicacao);

                    if (oAplicacao.idAplicacao == 0)
                    {
                        DialogResult result = MessageBox.Show("Aplicação não cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            LimpaCampos();
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                    }
                    else
                    {
                        montaTela(oAplicacao);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Aplicação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }
     
        #endregion

        #region "metodos da dbgrid"

        private void grdAplicacao_DoubleClick(object sender, EventArgs e)
        {
            txtIdAplicacao.Enabled = true;
            txtIdAplicacao.Text = grdAplicacao.Rows[grdAplicacao.CurrentRow.Index].Cells["idAplicacao"].Value.ToString();
            txtIdAplicacao.Focus();
            SendKeys.Send("{TAB}");
                      
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Aplicacaos cadastrados
            AplicacaoRN objAplicacao = new AplicacaoRN(Conexao,objOcorrencia,codempresa);
            grdAplicacao.DataSource = objAplicacao.ListaAplicacao();
        }

        #endregion
      
        private void txtIdAplicacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaAplicacao();
        }

    }
}
