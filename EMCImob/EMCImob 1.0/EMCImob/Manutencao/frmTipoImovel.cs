using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCImob
{
    public partial class frmTipoImovel : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmTipoImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmTipoImovel(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmTipoImovel()
        {
            InitializeComponent();
        }

        private void frmTipoImovel_Activated(object sender, EventArgs e)
        {


        }
        private void frmTipoImovel_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "tipoimovel";

            AtualizaGrid();
            this.ActiveControl = txtIdTipoImovel;
            CancelaOperacao();
        }
        #endregion
        #region "metodos para tratamento das informacoes"

        private Boolean verificaTipoImovel(TipoImovel oTipoImovel)
        {
            TipoImovelRN oTipoImovelRN = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oTipoImovelRN.VerificaDados(oTipoImovel);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo de Imóvel: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private TipoImovel montaTipoImovel()
        {
            TipoImovel oTipoImovel = new TipoImovel();
            oTipoImovel.descricao = txtDescricao.Text;

            return oTipoImovel;
        }

        private void montaTela(TipoImovel oTipoImovel)
        {
            txtDescricao.Text = oTipoImovel.descricao;
            txtIdTipoImovel.Text = oTipoImovel.idTipoImovel.ToString();
            txtDescricao.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oTipoImovel.idTipoImovel.ToString();

        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtIdTipoImovel.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdTipoImovel.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
         //   txtIdTipoImovel.Focus();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
         //   base.BuscaObjeto();
            try
            {
                psqTipoImovel ofrm = new psqTipoImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdTipoImovel.Enabled = true;
                    txtIdTipoImovel.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtIdTipoImovel.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaTipoImovel()
        {
            if (!String.IsNullOrEmpty(txtIdTipoImovel.Text))
            {

                TipoImovel oTipoImovel = new TipoImovel();
                try
                {
                    TipoImovelRN TipoImovelBLL = new TipoImovelRN(Conexao, objOcorrencia, codempresa);

                    oTipoImovel = montaTipoImovel();
                    oTipoImovel.idTipoImovel = Convert.ToInt32(txtIdTipoImovel.Text);

                    oTipoImovel = TipoImovelBLL.ObterPor(oTipoImovel);

                    if (String.IsNullOrEmpty(oTipoImovel.descricao))
                    {
                        DialogResult result = MessageBox.Show("Tipo de Imóvel não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        //txtidComodo.Text = oComodo.idComodo;
                        montaTela(oTipoImovel);
                        AtivaEdicao();
                        txtDescricao.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Imóvel: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtDescricao.Focus();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            try
            {
                TipoImovel oTipoImovel = new TipoImovel();
                TipoImovelRN oTipoImovelBLL = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
                oTipoImovel = montaTipoImovel();

                oTipoImovelBLL.Salvar(oTipoImovel);
                AtualizaGrid();
                CancelaOperacao();
                //LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }

        }

        public override void AtualizaObjeto()
        {
            try
            {
                TipoImovel oTipoImovel = new TipoImovel();
                TipoImovelRN oTipoImovelBLL = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
                oTipoImovel = montaTipoImovel();
                oTipoImovel.idTipoImovel = Convert.ToInt32(txtIdTipoImovel.Text);

                oTipoImovelBLL.Atualizar(oTipoImovel);
                AtualizaGrid();
                CancelaOperacao();
                //LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void ExcluiObjeto()
        {
            try
            {
                TipoImovel oTipoImovel = new TipoImovel();
                TipoImovelRN oTipoImovelBLL = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
                oTipoImovel = montaTipoImovel();
                oTipoImovel.idTipoImovel = Convert.ToInt32(txtIdTipoImovel.Text);

                oTipoImovelBLL.Excluir(oTipoImovel);
                AtualizaGrid();
                CancelaOperacao();
                //LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }

        }

        public override void ImprimeObjeto()
        {
            try
            {
                Relatorios.relTipoImovel ofrm = new Relatorios.relTipoImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region "metodos da dbgrid"

        private void grdTipoImovel_DoubleClick(object sender, EventArgs e)
        {
            txtIdTipoImovel.Text = grdTipoImovel.Rows[grdTipoImovel.CurrentRow.Index].Cells["idtipoimovel"].Value.ToString();

            BuscaTipoImovel();
           // txtDescricao.Focus();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Comodos cadastrados
            TipoImovelRN objTipoImovel = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
            grdTipoImovel.DataSource = objTipoImovel.ListaTipoImovel();
            txtDescricao.Focus();
        }


        #endregion


        private void txtidTipoImovel_Validating(object sender, CancelEventArgs e)
        {
            BuscaTipoImovel();
        }

    }
}
