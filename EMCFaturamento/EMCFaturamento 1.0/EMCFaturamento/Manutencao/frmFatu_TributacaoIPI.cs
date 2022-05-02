using System;
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
    public partial class frmFatu_TributacaoIPI : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_TributacaoIPI";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();



        public frmFatu_TributacaoIPI(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmFatu_TributacaoIPI()
        {
            InitializeComponent();
        }


        private void frmFatu_TributacaoIPI_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_TributacaoIPIIPI";


            /* Situacao Fiscal IPI */
            Fatu_SituacaoFiscalIPIRN oIPi = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia, codempresa);
            /* Situacao Fiscal IPI - Entrada */
            cboFatu_SitFiscalIPIEntrada.DataSource = oIPi.ListaFatu_SituacaoFiscalIPI("E");
            cboFatu_SitFiscalIPIEntrada.ValueMember = "idfatu_situacaofiscalipi";
            cboFatu_SitFiscalIPIEntrada.DisplayMember = "descricao";
            /* Situacao Fiscal IPI - Saida */
            cboFatu_SitFiscalIPISaida.DataSource = oIPi.ListaFatu_SituacaoFiscalIPI("S");
            cboFatu_SitFiscalIPISaida.ValueMember = "idfatu_situacaofiscalipi";
            cboFatu_SitFiscalIPISaida.DisplayMember = "descricao";

            CancelaOperacao();
            AtualizaGrid();

            this.ActiveControl = txtIdFatu_TributacaoIPI;
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_TributacaoIPI montaFatu_TributacaoIPIIPI()
        {
            Fatu_TributacaoIPI oFatu_TributacaoIPI = new Fatu_TributacaoIPI();
            oFatu_TributacaoIPI.descricao = txtDescricao.Text;
            oFatu_TributacaoIPI.percTributado = EmcResources.cDouble(txtIpi_Perc_Tributado.Value.ToString());
            oFatu_TributacaoIPI.percIsento = EmcResources.cDouble(txtIpi_Perc_Isentos.Value.ToString());
            oFatu_TributacaoIPI.percOutros = EmcResources.cDouble(txtIpi_Perc_Outros.Value.ToString());
            oFatu_TributacaoIPI.aliquotaIPI = EmcResources.cDouble(txtIpi_Perc_Ipi.Value.ToString());

            Fatu_SituacaoFiscalIPI oIPIEntrada = new Fatu_SituacaoFiscalIPI();
            Fatu_SituacaoFiscalIPIRN oIPIEntradaRN = new Fatu_SituacaoFiscalIPIRN(Conexao,objOcorrencia,codempresa);

            oIPIEntrada.idfatu_situacaofiscalipi = EmcResources.cInt(cboFatu_SitFiscalIPIEntrada.SelectedValue.ToString());

            oFatu_TributacaoIPI.situacaoIPIEntrada = oIPIEntradaRN.ObterPor(oIPIEntrada);

            Fatu_SituacaoFiscalIPI oIPISaida = new Fatu_SituacaoFiscalIPI();
            Fatu_SituacaoFiscalIPIRN oIPISaidaRN = new Fatu_SituacaoFiscalIPIRN(Conexao,objOcorrencia,codempresa);

            oIPISaida.idfatu_situacaofiscalipi = EmcResources.cInt(cboFatu_SitFiscalIPISaida.SelectedValue.ToString());

            oFatu_TributacaoIPI.situacaoIPISaida = oIPISaidaRN.ObterPor(oIPISaida);

            return oFatu_TributacaoIPI;
        }
        private void montaTela(Fatu_TributacaoIPI oFatu_TributacaoIPI)
        {
            txtIdFatu_TributacaoIPI.Text = oFatu_TributacaoIPI.idFatu_TributacaoIPI.ToString();
            txtDescricao.Text = oFatu_TributacaoIPI.descricao;
            txtIpi_Perc_Tributado.Text = oFatu_TributacaoIPI.percTributado.ToString();
            txtIpi_Perc_Isentos.Text = oFatu_TributacaoIPI.percIsento.ToString();
            txtIpi_Perc_Outros.Text = oFatu_TributacaoIPI.percOutros.ToString();
            txtIpi_Perc_Ipi.Text = oFatu_TributacaoIPI.aliquotaIPI.ToString();
            cboFatu_SitFiscalIPIEntrada.SelectedValue = oFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi.ToString();
            cboFatu_SitFiscalIPISaida.SelectedValue = oFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi.ToString();


            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_TributacaoIPI.idFatu_TributacaoIPI.ToString();
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
            txtIdFatu_TributacaoIPI.Enabled = false;
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdFatu_TributacaoIPI.Enabled = false;

        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtIdFatu_TributacaoIPI.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtIdFatu_TributacaoIPI.Text))
            {

                Fatu_TributacaoIPI oFatu_TributacaoIPI = new Fatu_TributacaoIPI();
                try
                {
                    
                    Fatu_TributacaoIPIRN Fatu_TributacaoIPIBLL = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia,codempresa);

                    oFatu_TributacaoIPI = montaFatu_TributacaoIPIIPI();
                    oFatu_TributacaoIPI.idFatu_TributacaoIPI =EmcResources.cInt(txtIdFatu_TributacaoIPI.Text);

                    oFatu_TributacaoIPI = Fatu_TributacaoIPIBLL.ObterPor(oFatu_TributacaoIPI);

                    if (String.IsNullOrEmpty(oFatu_TributacaoIPI.descricao))
                    {
                        MessageBox.Show("Tributação IPI não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_TributacaoIPI);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_TributacaoIPI: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                Fatu_TributacaoIPI oFatu_TributacaoIPI = new Fatu_TributacaoIPI();
                Fatu_TributacaoIPIRN oFatu_TributacaoIPIBLL = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia,codempresa);
                oFatu_TributacaoIPI = montaFatu_TributacaoIPIIPI();

                oFatu_TributacaoIPIBLL.Salvar(oFatu_TributacaoIPI);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void AtualizaObjeto()
        {
            try
            {
                Fatu_TributacaoIPI oFatu_TributacaoIPI = new Fatu_TributacaoIPI();
                Fatu_TributacaoIPIRN oFatu_TributacaoIPIBLL = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia,codempresa);
                oFatu_TributacaoIPI = montaFatu_TributacaoIPIIPI();
                oFatu_TributacaoIPI.idFatu_TributacaoIPI = EmcResources.cInt(txtIdFatu_TributacaoIPI.Text);

                oFatu_TributacaoIPIBLL.Atualizar(oFatu_TributacaoIPI);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void ExcluiObjeto()
        {
            try
            {
                Fatu_TributacaoIPI oFatu_TributacaoIPI = new Fatu_TributacaoIPI();
                Fatu_TributacaoIPIRN oFatu_TributacaoIPIBLL = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia, codempresa);
                oFatu_TributacaoIPI = montaFatu_TributacaoIPIIPI();
                oFatu_TributacaoIPI.idFatu_TributacaoIPI = EmcResources.cInt(txtIdFatu_TributacaoIPI.Text);

                oFatu_TributacaoIPIBLL.Excluir(oFatu_TributacaoIPI);

                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }


        #endregion

        #region "metodos da dbgrid"

        private void grdTributacaoIPI_DoubleClick(object sender, EventArgs e)
        {

            //carregando os dados da grid nos campos da tela
            txtIdFatu_TributacaoIPI.Text = grdTributacaoIPI.Rows[grdTributacaoIPI.CurrentRow.Index].Cells["idfatu_tributacaoipi"].Value.ToString();
            txtIdFatu_TributacaoIPI_Validating(null, null);
        }

        private void AtualizaGrid()
        {
            try
            {
                //carrega a grid
                Fatu_TributacaoIPIRN objFatu_TributacaoIPI = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia, codempresa);
                grdTributacaoIPI.DataSource = objFatu_TributacaoIPI.ListaFatu_TributacaoIPI();

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro: " + oErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


        private void txtIdFatu_TributacaoIPI_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
            //SendKeys.Send("{TAB}");
        }

    }
}
