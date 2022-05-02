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
    public partial class frmTipoCobranca : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmTipoCobranca";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmTipoCobranca(String idUsuario, String seqLogin, String idEmpresa, String empmaster,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        public frmTipoCobranca()
        {
            InitializeComponent();
        }

        private void frmTipoCobranca_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "tipocobranca";
    

            AtualizaGrid();
            this.ActiveControl = txtIdTipoCobranca;
            CancelaOperacao();
        }
#endregion


#region "metodos para tratamento das informacoes"
        
        private TipoCobranca montaTipoCobranca()
        {
            TipoCobranca oTipoCobranca = new TipoCobranca();
            oTipoCobranca.idTipoCobranca = EmcResources.cInt(txtIdTipoCobranca.Text);
            oTipoCobranca.descricao = txtDescricao.Text;
            oTipoCobranca.abreviatura = txtAbreviatura.Text;

            return oTipoCobranca;
        }
        
        private void montaTela(TipoCobranca oTipoCobranca)
        {
            txtDescricao.Text = oTipoCobranca.descricao;
            txtIdTipoCobranca.Text = oTipoCobranca.idTipoCobranca.ToString();
            txtAbreviatura.Text = oTipoCobranca.abreviatura;

            objOcorrencia.chaveidentificacao = oTipoCobranca.idTipoCobranca.ToString();
            txtIdTipoCobranca.ReadOnly = true;
            txtDescricao.Focus();
            
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
            txtIdTipoCobranca.Enabled = false;
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
            objOcorrencia.chaveidentificacao = "";
            txtIdTipoCobranca.Enabled = true;
            txtIdTipoCobranca.ReadOnly = false;
            txtIdTipoCobranca.Focus();
        }

        public override void BuscaObjeto()
        {
            
            try
            {
                psqTipoCobranca ofrm = new psqTipoCobranca (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdTipoCobranca.Text = "";
                    
                }
                else
                {
                    txtIdTipoCobranca.Enabled = true;
                    txtIdTipoCobranca.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdTipoCobranca.Focus();
                    SendKeys.Send("{TAB}");
                 }
            }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdTipoCobranca.Enabled = false;
            txtIdTipoCobranca.ReadOnly = true;
            txtDescricao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                TipoCobranca oTipoCobranca = new TipoCobranca();
                TipoCobrancaRN oTipoCobrancaBLL = new TipoCobrancaRN(Conexao,objOcorrencia,codempresa);
                oTipoCobranca = montaTipoCobranca();

                oTipoCobrancaBLL.Salvar(oTipoCobranca);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Cobrança: "+ erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                TipoCobranca oTipoCobranca = new TipoCobranca();
                TipoCobrancaRN oTipoCobrancaBLL = new TipoCobrancaRN(Conexao,objOcorrencia,codempresa);
                oTipoCobranca = montaTipoCobranca();
                oTipoCobranca.idTipoCobranca = Convert.ToInt32(txtIdTipoCobranca.Text);

                oTipoCobrancaBLL.Atualizar(oTipoCobranca);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                TipoCobranca oTipoCobranca = new TipoCobranca();
                TipoCobrancaRN oTipoCobrancaBLL = new TipoCobrancaRN(Conexao,objOcorrencia,codempresa);
                oTipoCobranca = montaTipoCobranca();
                oTipoCobranca.idTipoCobranca = Convert.ToInt32(txtIdTipoCobranca.Text);

                oTipoCobrancaBLL.Excluir(oTipoCobranca);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public void BuscaTipoCobranca()
        {

            if (!String.IsNullOrEmpty(txtIdTipoCobranca.Text))
            {

                TipoCobranca oTipoCobranca = new TipoCobranca();
                oTipoCobranca.idTipoCobranca = EmcResources.cInt(txtIdTipoCobranca.Text);
                try
                {
                    TipoCobrancaRN TipoCobrancaBLL = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                    oTipoCobranca = TipoCobrancaBLL.ObterPor(oTipoCobranca);

                    if (oTipoCobranca.idTipoCobranca == 0)
                    {
                        DialogResult result = MessageBox.Show("Tipo Cobrança não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        montaTela(oTipoCobranca);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relTipoCobranca ofrm = new Relatorios.relTipoCobranca(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        #endregion

        #region "metodos da dbgrid"

        private void grdTipoCobranca_DoubleClick(object sender, EventArgs e)
        {
            txtIdTipoCobranca.Enabled = true;
            txtIdTipoCobranca.Text = grdTipoCobranca.Rows[grdTipoCobranca.CurrentRow.Index].Cells["idTipoCobranca"].Value.ToString();
            txtIdTipoCobranca.Focus();
            SendKeys.Send("{TAB}");
           
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os TipoCobrancas cadastrados
            TipoCobrancaRN objTipoCobranca = new TipoCobrancaRN(Conexao,objOcorrencia,codempresa);
            grdTipoCobranca.DataSource = objTipoCobranca.ListaTipoCobranca();
        }
        
        #endregion
      
        private void txtIdTipoCobranca_Validating(object sender, CancelEventArgs e)
        {
            BuscaTipoCobranca();
        }
    }
}
