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
    public partial class frmTipoDocumento : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmTipoDocumento";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmTipoDocumento(String idUsuario, String seqLogin, String idEmpresa, String empmaster,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        public frmTipoDocumento()
        {
            InitializeComponent();
        }

        private void frmTipoDocumento_Activated(object sender, EventArgs e)
        {


        }
    
        private void frmTipoDocumento_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "tipodocumento";

            AtualizaGrid();
            this.ActiveControl = txtIdTipoDocumento;
            CancelaOperacao();
        }
#endregion


#region "metodos para tratamento das informacoes"
        
        private TipoDocumento montaTipoDocumento()
        {
            TipoDocumento oTipoDocumento = new TipoDocumento();
            oTipoDocumento.idTipoDocumento = EmcResources.cInt(txtIdTipoDocumento.Text);
            oTipoDocumento.descricao = txtDescricao.Text;
            oTipoDocumento.abreviatura = txtAbreviatura.Text;

            return oTipoDocumento;
        }
        
        private void montaTela(TipoDocumento oTipoDocumento)
        {
            txtDescricao.Text = oTipoDocumento.descricao;
            txtIdTipoDocumento.Text = oTipoDocumento.idTipoDocumento.ToString();
            txtAbreviatura.Text = oTipoDocumento.abreviatura;

            objOcorrencia.chaveidentificacao = oTipoDocumento.idTipoDocumento.ToString();
            txtIdTipoDocumento.ReadOnly = true;
            
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
            txtIdTipoDocumento.Enabled = false;
            
        }
        
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdTipoDocumento.ReadOnly = true;
            txtDescricao.Focus();
        }
        
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtIdTipoDocumento.Enabled = true;
            txtIdTipoDocumento.ReadOnly = false;
            txtIdTipoDocumento.Focus();

        }

        public override void BuscaObjeto()
        {
           try
            {
                psqTipoDocumento ofrm = new psqTipoDocumento (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdTipoDocumento.Text = "";
                    
                }
                else
                {
                    txtIdTipoDocumento.Enabled = true;
                    txtIdTipoDocumento.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdTipoDocumento.Focus();
                    SendKeys.Send("{TAB}");
                 }
            }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   
        public void BuscaTipoDocumento()
        {

            if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text))
            {

                TipoDocumento oTipoDocumento = new TipoDocumento();
                oTipoDocumento.idTipoDocumento = EmcResources.cInt(txtIdTipoDocumento.Text);
                try
                {
                    TipoDocumentoRN TipoDocumentoBLL = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                    oTipoDocumento = TipoDocumentoBLL.ObterPor(oTipoDocumento);

                    if (oTipoDocumento.idTipoDocumento == 0)
                    {
                        DialogResult result = MessageBox.Show("Tipo Documento não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        montaTela(oTipoDocumento);
                        AtivaEdicao();
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
            txtIdTipoDocumento.ReadOnly = true;
            txtDescricao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                TipoDocumento oTipoDocumento = new TipoDocumento();
                TipoDocumentoRN oTipoDocumentoBLL = new TipoDocumentoRN(Conexao,objOcorrencia,codempresa);
                oTipoDocumento = montaTipoDocumento();

                oTipoDocumentoBLL.Salvar(oTipoDocumento);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Documento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                TipoDocumento oTipoDocumento = new TipoDocumento();
                TipoDocumentoRN oTipoDocumentoBLL = new TipoDocumentoRN(Conexao,objOcorrencia,codempresa);
                oTipoDocumento = montaTipoDocumento();
                oTipoDocumento.idTipoDocumento = Convert.ToInt32(txtIdTipoDocumento.Text);

                oTipoDocumentoBLL.Atualizar(oTipoDocumento);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Documento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                TipoDocumento oTipoDocumento = new TipoDocumento();
                TipoDocumentoRN oTipoDocumentoBLL = new TipoDocumentoRN(Conexao,objOcorrencia,codempresa);
                oTipoDocumento = montaTipoDocumento();
                oTipoDocumento.idTipoDocumento = Convert.ToInt32(txtIdTipoDocumento.Text);

                oTipoDocumentoBLL.Excluir(oTipoDocumento);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Documento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relTipoDocumento ofrm = new Relatorios.relTipoDocumento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Tipo Documento: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    #endregion

#region "metodos da dbgrid"

        private void grdTipoDocumento_DoubleClick(object sender, EventArgs e)
        {
            txtIdTipoDocumento.Enabled = true;
            txtIdTipoDocumento.Text = grdTipoDocumento.Rows[grdTipoDocumento.CurrentRow.Index].Cells["idTipoDocumento"].Value.ToString();
            txtIdTipoDocumento.Focus();
            SendKeys.Send("{TAB}");
            
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os TipoDocumentos cadastrados
            TipoDocumentoRN objTipoDocumento = new TipoDocumentoRN(Conexao,objOcorrencia,codempresa);
            grdTipoDocumento.DataSource = objTipoDocumento.ListaTipoDocumento();
        }

        #endregion

      
        private void txtIdTipoDocumento_Validating(object sender, CancelEventArgs e)
        {
            BuscaTipoDocumento();
        }



    }
}
