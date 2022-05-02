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
using EMCSecurityModel;
using EMCSecurity;
using System.Collections;

namespace EMCImob
{
    public partial class frmTipoLanctoCaptacao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmTipoLanctoCaptacao";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmTipoLanctoCaptacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmTipoLanctoCaptacao()
        {
            InitializeComponent();
        }

        private void frmTipoLanctoCaptacao_Activated(object sender, EventArgs e)
        {

        }
        private void frmTipoLanctoCaptacao_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "tipolanctocaptacao";

            AtualizaGrid();
            this.ActiveControl = txtidTipoLanctoCaptacao;
            CancelaOperacao();
        }
        #endregion
        #region "metodos para tratamento das informacoes"

        private Boolean verificaTipoLanctoCaptacao(TipoLanctoCaptacao oTipoLanctoCaptacao)
        {
            TipoLanctoCaptacaoRN oTipoLanctoCaptacaoRN = new TipoLanctoCaptacaoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oTipoLanctoCaptacaoRN.VerificaDados(oTipoLanctoCaptacao);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Tipo Lancto Captação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private TipoLanctoCaptacao montaTipoLanctoCaptacao()
        {
            TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
            oTipoLanctoCaptacao.Descricao = txtDescricao.Text;
            oTipoLanctoCaptacao.TipoLancamento = cboTipoLancamento.SelectedValue.ToString();

            return oTipoLanctoCaptacao;
        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }

        private void montaTela(TipoLanctoCaptacao oTipoLanctoCaptacao)
        {
            txtDescricao.Text = oTipoLanctoCaptacao.Descricao;
            txtidTipoLanctoCaptacao.Text = oTipoLanctoCaptacao.idTipoLanctoCaptacao.ToString();
            cboTipoLancamento.SelectedValue = oTipoLanctoCaptacao.TipoLancamento;
            txtDescricao.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oTipoLanctoCaptacao.idTipoLanctoCaptacao.ToString();

        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtidTipoLanctoCaptacao.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtidTipoLanctoCaptacao.Enabled = false;
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
            objOcorrencia.chaveidentificacao = "";

            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Sim", "S"));
            arr.Add(new popCombo("Não", "N"));
            cboTipoLancamento.DataSource = arr;
            cboTipoLancamento.DisplayMember = "nome";
            cboTipoLancamento.ValueMember = "valor";
        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqTipoLanctoCaptacao ofrm = new psqTipoLanctoCaptacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidTipoLanctoCaptacao.Enabled = true;
                    txtidTipoLanctoCaptacao.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtidTipoLanctoCaptacao.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaTipoLanctoCaptacao()
        {
            if (!String.IsNullOrEmpty(txtidTipoLanctoCaptacao.Text))
            {

                TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
                try
                {
                    TipoLanctoCaptacaoRN TipoLanctoCaptacaoBLL = new TipoLanctoCaptacaoRN(Conexao, objOcorrencia, codempresa);

                    oTipoLanctoCaptacao = montaTipoLanctoCaptacao();
                    oTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(txtidTipoLanctoCaptacao.Text);

                    oTipoLanctoCaptacao = TipoLanctoCaptacaoBLL.ObterPor(oTipoLanctoCaptacao);

                    if (String.IsNullOrEmpty(oTipoLanctoCaptacao.Descricao))
                    {
                        DialogResult result = MessageBox.Show("Tipo de Lançamento não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else                        
                            CancelaOperacao();   
                    }
                    else
                    {
                        //txtidTipoLanctoCaptacao.Text = oTipoLanctoCaptacao.idTipoLanctoCaptacao;
                        montaTela(oTipoLanctoCaptacao);
                        AtivaEdicao();
                        txtDescricao.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro TipoLanctoCaptacao: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
                TipoLanctoCaptacaoRN oTipoLanctoCaptacaoBLL = new TipoLanctoCaptacaoRN(Conexao, objOcorrencia, codempresa);
                oTipoLanctoCaptacao = montaTipoLanctoCaptacao();

                oTipoLanctoCaptacaoBLL.Salvar(oTipoLanctoCaptacao);
                AtualizaGrid();
                CancelaOperacao();
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
                TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
                TipoLanctoCaptacaoRN oTipoLanctoCaptacaoBLL = new TipoLanctoCaptacaoRN(Conexao, objOcorrencia, codempresa);
                oTipoLanctoCaptacao = montaTipoLanctoCaptacao();
                oTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(txtidTipoLanctoCaptacao.Text);

                oTipoLanctoCaptacaoBLL.Atualizar(oTipoLanctoCaptacao);
                AtualizaGrid();
                CancelaOperacao();
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
                TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
                TipoLanctoCaptacaoRN oTipoLanctoCaptacaoBLL = new TipoLanctoCaptacaoRN(Conexao, objOcorrencia, codempresa);
                oTipoLanctoCaptacao = montaTipoLanctoCaptacao();
                oTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(txtidTipoLanctoCaptacao.Text);

                oTipoLanctoCaptacaoBLL.Excluir(oTipoLanctoCaptacao);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
          //  base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                Relatorios.relTipoLanctoCaptacao ofrm = new Relatorios.relTipoLanctoCaptacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region "metodos da dbgrid"

        private void grdTipoLanctoCaptacao_DoubleClick(object sender, EventArgs e)
        {
            txtidTipoLanctoCaptacao.Text = grdTipoLanctoCaptacao.Rows[grdTipoLanctoCaptacao.CurrentRow.Index].Cells["idtipolanctocaptacao"].Value.ToString();
            BuscaTipoLanctoCaptacao();
            //BuscaObjeto();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os TipoLanctoCaptacaos cadastrados
            TipoLanctoCaptacaoRN objTipoLanctoCaptacao = new TipoLanctoCaptacaoRN(Conexao, objOcorrencia, codempresa);
            grdTipoLanctoCaptacao.DataSource = objTipoLanctoCaptacao.ListaTipoLanctoCaptacao();
            txtDescricao.Focus();
        }
        #endregion

        private void txtidTipoLanctoCaptacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaTipoLanctoCaptacao();
            //BuscaObjeto();
        }

    }
}
