using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCObrasModel;
using EMCObrasRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;


namespace EMCObras
{
    public partial class frmObra_TipoContrato : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmObra_TipoContrato";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

      

        #region "metodos do form"

        public frmObra_TipoContrato(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmObra_TipoContrato()
        {
            InitializeComponent();
        }


        private void frmObra_TipoContrato_Activated(object sender, EventArgs e)
        {


        }

        private void frmObra_TipoContrato_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_etapa";

            this.ActiveControl = txtidObra_TipoContrato;

            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
 
        private Obra_TipoContrato montaObra_TipoContrato()
        {
            Obra_TipoContrato oObra_TipoContrato = new Obra_TipoContrato();
            oObra_TipoContrato.descricao = txtDescricao.Text;

            return oObra_TipoContrato;
        }

        private void montaTela(Obra_TipoContrato oObra_TipoContrato)
        {
            txtDescricao.Text = oObra_TipoContrato.descricao;
            txtidObra_TipoContrato.Text = oObra_TipoContrato.idObra_TipoContrato.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oObra_TipoContrato.idObra_TipoContrato.ToString();
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
           
        }
     
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtidObra_TipoContrato.Enabled = false;
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
            txtidObra_TipoContrato.Enabled = true;
            txtidObra_TipoContrato.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqObraEtapa ofrm = new psqObraEtapa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCObras.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_TipoContrato.Enabled = true;
                    txtidObra_TipoContrato.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_TipoContrato.Focus();
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
        }

        public override void SalvaObjeto()
        {
            try
            {

                Obra_TipoContrato oObra_TipoContrato = new Obra_TipoContrato();
                Obra_TipoContratoRN oObra_TipoContratoBLL = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);
                oObra_TipoContrato = montaObra_TipoContrato();

                oObra_TipoContratoBLL.Salvar(oObra_TipoContrato);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Obra_TipoContrato oObra_TipoContrato = new Obra_TipoContrato();
                Obra_TipoContratoRN oObra_TipoContratoBLL = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);
                oObra_TipoContrato = montaObra_TipoContrato();
                oObra_TipoContrato.idObra_TipoContrato = Convert.ToInt32(txtidObra_TipoContrato.Text);

                oObra_TipoContratoBLL.Atualizar(oObra_TipoContrato);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Obra_TipoContrato oObra_TipoContrato = new Obra_TipoContrato();
                Obra_TipoContratoRN oObra_TipoContratoBLL = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);
                oObra_TipoContrato = montaObra_TipoContrato();
                oObra_TipoContrato.idObra_TipoContrato = Convert.ToInt32(txtidObra_TipoContrato.Text);

                oObra_TipoContratoBLL.Excluir(oObra_TipoContrato);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaObraTipoContrato()
        {
            if (!String.IsNullOrEmpty(txtidObra_TipoContrato.Text))
            {

                Obra_TipoContrato oObra_TipoContrato = new Obra_TipoContrato();
                try
                {
                    Obra_TipoContratoRN Obra_TipoContratoBLL = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);

                    oObra_TipoContrato = montaObra_TipoContrato();
                    oObra_TipoContrato.idObra_TipoContrato = Convert.ToInt32(txtidObra_TipoContrato.Text);

                    oObra_TipoContrato = Obra_TipoContratoBLL.ObterPor(oObra_TipoContrato);

                    if (String.IsNullOrEmpty(oObra_TipoContrato.descricao))
                    {
                        DialogResult result = MessageBox.Show("Etapa não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oObra_TipoContrato);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Obra_TipoContrato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdTipoContrato_DoubleClick(object sender, EventArgs e)
        {
            txtidObra_TipoContrato.Text = grdTipoContrato.Rows[grdTipoContrato.CurrentRow.Index].Cells["idobra_tipocontrato"].Value.ToString();
            txtidObra_TipoContrato.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Obra_TipoContratoRN objObra_TipoContrato = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);
            grdTipoContrato.DataSource = objObra_TipoContrato.ListaObra_TipoContrato();
        }


        #endregion


        private void txtidObra_TipoContrato_Validating(object sender, CancelEventArgs e)
        {
            BuscaObraTipoContrato();
        }


    }
}
