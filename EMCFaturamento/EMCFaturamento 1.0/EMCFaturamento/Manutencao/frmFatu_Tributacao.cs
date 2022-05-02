using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFaturamentoModel;
using EMCFaturamentoRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;


namespace EMCFaturamento
{
    public partial class frmFatu_Tributacao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_Tributacao";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        //controla a posição da linha da grid selecionada
        private int iLinhaSelecionada = 0;

        public frmFatu_Tributacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmFatu_Tributacao()
        {
            InitializeComponent();
        }


        private void frmFatu_Tributacao_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_Tributacao";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_Tributacao montaFatu_Tributacao()
        {
            Fatu_Tributacao oFatu_Tributacao = new Fatu_Tributacao();
            oFatu_Tributacao.descricao = txtDescricao.Text;
            oFatu_Tributacao.advertencia = txtAdvertencia.Text;
            oFatu_Tributacao.situacao = cboSituacao.SelectedValue.ToString();
            oFatu_Tributacao.sistematributacao = cboSistemaTributacao.SelectedValue.ToString();
            oFatu_Tributacao.codigotributacao = txtCodigoTributacao.Text;

            return oFatu_Tributacao;
        }
        private void montaTela(Fatu_Tributacao oFatu_Tributacao)
        {
            txtidFatu_Tributacao.Text = oFatu_Tributacao.idfatu_tributacao.ToString();
            txtDescricao.Text = oFatu_Tributacao.descricao;
            txtAdvertencia.Text = oFatu_Tributacao.advertencia;
            cboSituacao.SelectedValue = oFatu_Tributacao.situacao.ToString();
            cboSistemaTributacao.SelectedValue = oFatu_Tributacao.sistematributacao.ToString();
            txtCodigoTributacao.Text = oFatu_Tributacao.codigotributacao;

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_Tributacao.idfatu_tributacao.ToString();
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
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidFatu_Tributacao.Text))
            {

                Fatu_Tributacao oFatu_Tributacao = new Fatu_Tributacao();
                try
                {
                    Fatu_TributacaoRN Fatu_TributacaoBLL = new Fatu_TributacaoRN(Conexao, objOcorrencia,codempresa);

                    oFatu_Tributacao = montaFatu_Tributacao();
                    oFatu_Tributacao.idfatu_tributacao = Convert.ToInt32(txtidFatu_Tributacao.Text);

                    oFatu_Tributacao = Fatu_TributacaoBLL.ObterPor(oFatu_Tributacao);

                    if (String.IsNullOrEmpty(oFatu_Tributacao.descricao))
                    {
                        MessageBox.Show("Tributação não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_Tributacao);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_Tributacao: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";

            //montando combo's
            ArrayList arrSituacao = new ArrayList();
            arrSituacao.Add(new popCombo("Ativo", "A"));
            arrSituacao.Add(new popCombo("Inativo", "I"));
            cboSituacao.DataSource = arrSituacao;
            cboSituacao.DisplayMember = "nome";
            cboSituacao.ValueMember = "valor";

            ArrayList arrSistemaTributacao = new ArrayList();
            arrSistemaTributacao.Add(new popCombo("Tributação Normal", "N"));
            arrSistemaTributacao.Add(new popCombo("Simples Nacional", "S"));
            cboSistemaTributacao.DataSource = arrSistemaTributacao;
            cboSistemaTributacao.DisplayMember = "nome";
            cboSistemaTributacao.ValueMember = "valor";

        }

        public override void SalvaObjeto()
        {
            try
            {

                Fatu_Tributacao oFatu_Tributacao = new Fatu_Tributacao();
                Fatu_TributacaoRN oFatu_TributacaoBLL = new Fatu_TributacaoRN(Conexao, objOcorrencia,codempresa);
                oFatu_Tributacao = montaFatu_Tributacao();

                oFatu_TributacaoBLL.Salvar(oFatu_Tributacao);
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
                Fatu_Tributacao oFatu_Tributacao = new Fatu_Tributacao();
                Fatu_TributacaoRN oFatu_TributacaoBLL = new Fatu_TributacaoRN(Conexao, objOcorrencia,codempresa);
                oFatu_Tributacao = montaFatu_Tributacao();
                oFatu_Tributacao.idfatu_tributacao = Convert.ToInt32(txtidFatu_Tributacao.Text);

                oFatu_TributacaoBLL.Atualizar(oFatu_Tributacao);
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
                Fatu_Tributacao oFatu_Tributacao = new Fatu_Tributacao();
                Fatu_TributacaoRN oFatu_TributacaoBLL = new Fatu_TributacaoRN(Conexao, objOcorrencia,codempresa);
                oFatu_Tributacao = montaFatu_Tributacao();
                oFatu_Tributacao.idfatu_tributacao = Convert.ToInt32(txtidFatu_Tributacao.Text);

                oFatu_TributacaoBLL.Excluir(oFatu_Tributacao);
                iLinhaSelecionada = 0;
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdFatu_Tributacao_DoubleClick(object sender, EventArgs e)
        {
            //armazenando a posição a linha selecionada
            iLinhaSelecionada = 0;

            if (grdFatu_Tributacao.CurrentRow != null)
            {
                iLinhaSelecionada = grdFatu_Tributacao.CurrentRow.Index;
            }


            //carregando os dados da grid nos campos da tela
            txtidFatu_Tributacao.Text = grdFatu_Tributacao.Rows[grdFatu_Tributacao.CurrentRow.Index].Cells["idFatu_Tributacao"].Value.ToString();
            txtidFatu_Tributacao.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_TributacaoRN objFatu_Tributacao = new Fatu_TributacaoRN(Conexao, objOcorrencia,codempresa);
            grdFatu_Tributacao.DataSource = objFatu_Tributacao.ListaFatu_Tributacao();

            //setando a linha selecionada
            if (grdFatu_Tributacao.RowCount > 0) grdFatu_Tributacao.Rows[iLinhaSelecionada].Selected = true;

        }

        #endregion


        private void txtidFatu_Tributacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFatu_Tributacao_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
