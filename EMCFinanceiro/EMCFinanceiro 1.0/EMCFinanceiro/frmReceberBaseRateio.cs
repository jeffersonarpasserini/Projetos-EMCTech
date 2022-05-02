using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFinanceiro.Pesquisa;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCCadastro;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;

namespace EMCFinanceiro
{
    public partial class frmReceberBaseRateio : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmReceberBaseRateio";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        List<ReceberBaseRateio> lstRateioGeral = new List<ReceberBaseRateio>();

        //controle da grid
        private int idPgrDocumento = 0;
        private decimal valordocumento = 0;
        private int gIdAplicacao = 0;
        private string gCodigoConta = "";
        private decimal gValorRateio = 0;
        private decimal gPercentualRateio = 0;

        #region [Metodos para configuração do formulário]
        public frmReceberBaseRateio(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia oOcorrencia, int idPagarDocumento, decimal pValor)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            objOcorrencia = oOcorrencia;
            idPgrDocumento = idPagarDocumento;
            valordocumento = pValor;

            InitializeComponent();
        }
        public frmReceberBaseRateio()
        {
            InitializeComponent();
        }
        private void frmReceberBaseRateio_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "receberdocumento";


            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;

            //string vMascara = oContaCustoRN.montaMascara();
            //txtIdContaCusto.Mask = @vMascara;

            lstRateioGeral = rateioReceber.lstReceberBaseRateio;

            CancelaOperacao();

            AtualizaGrid();
        }

        #endregion

        #region [Tratamento de Texts, combos ]

        #endregion

        #region [metodos para tratamento das informacoes]
        private Boolean verificaReceberBaseRateio(List<ReceberBaseRateio> lstRateio)
        {
            ReceberBaseRateioRN oReceberRN = new ReceberBaseRateioRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oReceberRN.VerificaDados(lstRateio, valordocumento);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        private List<ReceberBaseRateio> montaReceberBaseRateio()
        {
            List<ReceberBaseRateio> lstRateio = new List<ReceberBaseRateio>();

            try
            {
                Decimal somaValor = 0;
                double somaPerc = 0;

                int contaRows = 0;
                double difPercentual = 0;

                //monta uma lista de parcelas
                foreach (DataGridViewRow oRow in grdBaseRateio.Rows)
                {
                    DataGridViewCell idAplicacao = oRow.Cells["idaplicacao"];
                    DataGridViewCell idCodigoConta = oRow.Cells["codigoconta"];

                    if (idAplicacao.Value != null && idCodigoConta.Value != null)
                    {
                        ReceberBaseRateio oRateio = new ReceberBaseRateio();

                        oRateio.codEmpresa = codempresa;

                        oRateio.status = oRow.Cells["status"].Value.ToString();

                        if (oRateio.status == "I")
                            oRateio.idReceberBaseRateio = 0;
                        else
                            oRateio.idReceberBaseRateio = EmcResources.cInt(oRow.Cells["idreceberbaserateio"].Value.ToString());

                        oRateio.idReceberDocumento = EmcResources.cInt(oRow.Cells["idreceberdocumento"].Value.ToString());
                        oRateio.valorRateio = EmcResources.cCur(oRow.Cells["valorrateio"].Value.ToString());
                        oRateio.percentualRateio = EmcResources.cDouble(oRow.Cells["percentualrateio"].Value.ToString());

                        if (oRateio.status != "E")
                        {
                            
                            somaValor = somaValor + oRateio.valorRateio;

                            if ( (contaRows == grdBaseRateio.Rows.Count - 1) && (somaValor == EmcResources.cCur(txtTotalRateio.Text)))
                            {
                                difPercentual = Math.Round((100 - somaPerc), 4);
                                oRateio.percentualRateio = difPercentual;
                            }
                            
                            somaPerc = Math.Round(somaPerc + oRateio.percentualRateio,4);

                            
                        }


                        Aplicacao oAplicacao = new Aplicacao();
                        AplicacaoRN oAplicacaoRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);
                        oAplicacao.idAplicacao = EmcResources.cInt(oRow.Cells["idaplicacao"].Value.ToString());
                        oAplicacao = oAplicacaoRN.ObterPor(oAplicacao);
                        oRateio.aplicacao = oAplicacao;

                        ContaCusto oCusto = new ContaCusto();
                        ContaCustoRN oCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
                        oCusto.idContaCusto = EmcResources.cInt(oRow.Cells["idcontacusto"].Value.ToString());
                        oCusto = oCustoRN.ObterPor(oCusto);
                        oRateio.contaCusto = oCusto;

                        lstRateio.Add(oRateio);
                        contaRows++;
                    }

                }

                lstRateioGeral = null;
                lstRateioGeral = lstRateio;

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

            return lstRateio;

        }
        private void montaTela(PagarDocumento oPagarDocumento)
        {

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
            travaBotao("btnExcluir");
            travaBotao("btnBusca");
            travaBotao("btnAtualizar");
            travaBotao("btnOcorrencia");
            travaBotao("btnRelatorio");
            travaBotao("btnOcorrencia");

        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            travaBotao("btnExcluir");
            travaBotao("btnBusca");
            travaBotao("btnAtualizar");
            travaBotao("btnOcorrencia");
            travaBotao("btnRelatorio");
            travaBotao("btnOcorrencia");

        }
        public override void AtualizaTela()
        {

        }
        public override void CancelaOperacao()
        {
            //base.CancelaOperacao();
            travaBotao("btnExcluir");
            travaBotao("btnBusca");
            travaBotao("btnAtualizar");
            travaBotao("btnOcorrencia");
            travaBotao("btnRelatorio");
            travaBotao("btnOcorrencia");

            grdBaseRateio.Rows.Clear();

            txtCodigoConta.Focus();

            txtValorDocumento.Text = valordocumento.ToString();
            btnAlteraRateio.Enabled = false;
            btnExcluiParcela.Enabled = false;
            btnNovoRateio.Enabled = true;

        }
        public override void BuscaObjeto()
        {

        }
        public override void LimpaCampos()
        {
            txtIdContaCusto.Text = "";
            txtContaCusto.Text = "";
            txtIdAplicacao.Text = "";
            txtAplicacao.Text = "";
            txtCodigoConta.Text = "";
            txtVlrUnitario.Text = "";
            txtVlrPercentual.Text = "";

            txtCodigoConta.Focus();

            txtValorDocumento.Text = valordocumento.ToString();
            btnAlteraRateio.Enabled = false;
            btnExcluiParcela.Enabled = false;
            btnNovoRateio.Enabled = true;

        }
        public override void SalvaObjeto()
        {

            try
            {

                lstRateioGeral = montaReceberBaseRateio();
                ReceberBaseRateioRN oBaseRN = new ReceberBaseRateioRN(Conexao, objOcorrencia, codempresa);

                oBaseRN.VerificaDados(lstRateioGeral, valordocumento);

                rateioReceber.lstReceberBaseRateio = lstRateioGeral;
                LimpaCampos();

                this.Close();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public override void AtualizaObjeto()
        {
            try
            {
                try
                {


                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message + " - " + erro.StackTrace);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.AtualizaObjeto();
        }
        public override void ExcluiObjeto()
        {
            try
            {
                try
                {


                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message + " - " + erro.StackTrace);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        #endregion

        #region [metodos para controle da grid]
       
        public void AtualizaGrid()
        {
            try
            {
                if (lstRateioGeral != null)
                {
                    decimal valorRateio = 0;
                    foreach (ReceberBaseRateio oRateio in lstRateioGeral)
                    {

                        grdBaseRateio.Rows.Add(oRateio.idReceberDocumento, oRateio.idReceberBaseRateio, oRateio.aplicacao.idAplicacao, oRateio.aplicacao.descricao,
                                               oRateio.contaCusto.idContaCusto, oRateio.contaCusto.codigoConta, oRateio.contaCusto.descricao,
                                               oRateio.valorRateio, oRateio.percentualRateio, oRateio.status);
                        valorRateio += oRateio.valorRateio;
                    }
                    txtTotalRateio.Text = valorRateio.ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message);
            }
        }
        private void grdBaseRateio_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtGridIndex.Text = grdBaseRateio.CurrentRow.Index.ToString();
                txtIdAplicacao.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["idaplicacao"].Value.ToString();
                txtIdContaCusto.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["idcontacusto"].Value.ToString();
                txtCodigoConta.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["codigoconta"].Value.ToString();
                txtVlrPercentual.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["percentualrateio"].Value.ToString();
                txtVlrUnitario.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["valorrateio"].Value.ToString();
                txtValorAnterior.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["valorrateio"].Value.ToString();
                txtStatus.Text = grdBaseRateio.Rows[grdBaseRateio.CurrentRow.Index].Cells["status"].Value.ToString();

                txtIdAplicacao_Validating(null, null);
                txtCodigoConta_Validating(null, null);

                txtCodigoConta.Focus();

                btnAlteraRateio.Enabled = true;
                btnExcluiParcela.Enabled = true;
                btnNovoRateio.Enabled = false;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grdBaseRateio_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdBaseRateio.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void grdBaseRateio_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Ultimo evento depois que termina a  edição de uma célula
            try
            {
                //verifica o status da linha - se for inclusão ou exclusão não verifica alteração
                if (!grdBaseRateio.CurrentRow.Cells["status"].Value.ToString().Equals("I") && !grdBaseRateio.CurrentRow.Cells["status"].Value.ToString().Equals("E"))
                {
                    //se houve alguma alteração seta status como A
                    if (!EmcResources.cCur(grdBaseRateio.CurrentRow.Cells["valorrateio"].Value.ToString()).Equals(gValorRateio) ||
                        !EmcResources.cCur(grdBaseRateio.CurrentRow.Cells["percentualrateio"].Value.ToString()).Equals(gPercentualRateio) ||
                        !EmcResources.cInt(grdBaseRateio.CurrentRow.Cells["idaplicacao"].Value.ToString()).Equals(gIdAplicacao) ||
                        !(grdBaseRateio.CurrentRow.Cells["codigoconta"].Value.ToString()).Equals(gCodigoConta))
                    {
                        grdBaseRateio.CurrentRow.Cells["status"].Value = "A";
                    }
                }
                if (e.ColumnIndex == grdBaseRateio.Columns["valorrateio"].Index)
                {
                    DataGridViewCell cellValorRateio = grdBaseRateio.CurrentCell;
                    DataGridViewCell cellPercentualRateio = grdBaseRateio.CurrentRow.Cells["percentualrateio"];
                    //se id da base de rateio for null vai ser uma inclusão de uma nova base 
                    // seta parametros para isto
                    if ((cellValorRateio.Value != null) && (cellPercentualRateio.Value != null))
                    {
                        grdBaseRateio.CurrentCell.Value = String.Format("{0:c2}", grdBaseRateio.CurrentCell.Value.ToString());
                        grdBaseRateio.CurrentRow.Cells["percentualrateio"].Value = String.Format("{0:0,0000%}", cellPercentualRateio.Value.ToString());
                    }

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private void grdBaseRateio_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdBaseRateio_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == grdBaseRateio.Columns["idaplicacao"].Index)
                {

                    DataGridViewCell cellIdAplicacao = grdBaseRateio.CurrentCell;

                    //se id da base de rateio for null vai ser uma inclusão de uma nova base 
                    // seta parametros para isto
                    if (cellIdAplicacao.Value == null || cellIdAplicacao.Value.ToString() == "0" || cellIdAplicacao.Value.ToString() == "")
                    {
                        MessageBox.Show("Código da Aplicação é obrigatório, preencher!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        if (grdBaseRateio.CurrentCell.Value.ToString() == "?")
                        {
                            psqAplicacao ofrm = new psqAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                            ofrm.ShowDialog();

                            grdBaseRateio.CurrentCell.Value = EMCCadastro.retPesquisa.chaveinterna.ToString();

                        }
                        Aplicacao oAplicacao = new Aplicacao();
                        oAplicacao.idAplicacao = Convert.ToInt32(grdBaseRateio.CurrentCell.Value);
                        AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);
                        oAplicacao = oAplRN.ObterPor(oAplicacao);

                        if (oAplicacao.idAplicacao == 0)
                        {
                            Exception oDataMov = new Exception("Aplicação não cadastrada");
                            throw oDataMov;
                        }
                        //Preenche a proxima celula com a descrição
                        grdBaseRateio.CurrentRow.Cells["aplicacao"].Value = oAplicacao.descricao;

                    }


                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["codigoconta"].Index)
                {

                    DataGridViewCell cellCodigoConta = grdBaseRateio.CurrentCell;

                    //se id da base de rateio for null vai ser uma inclusão de uma nova base 
                    // seta parametros para isto
                    if (cellCodigoConta.Value == null || cellCodigoConta.Value.ToString() == "0" || cellCodigoConta.Value.ToString() == "")
                    {
                        MessageBox.Show("Código da Conta Custo é obrigatório, preencher!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        if (grdBaseRateio.CurrentCell.Value.ToString() == "?")
                        {
                            psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia, false);
                            ofrm.ShowDialog();

                            grdBaseRateio.CurrentCell.Value = EMCCadastro.retPesquisa.chavebusca.ToString();
                        }

                        ContaCusto oCtaCusto = new ContaCusto();
                        oCtaCusto.codigoConta = grdBaseRateio.CurrentCell.Value.ToString().ToUpper();
                        ContaCustoRN oCtaRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
                        oCtaCusto = oCtaRN.ObterPor(oCtaCusto);

                        if (oCtaCusto.idContaCusto == 0)
                        {
                            Exception oDataMov = new Exception("Conta Custo não cadastrada");
                            throw oDataMov;
                        }
                        //Preenche a proxima celula com a descrição
                        grdBaseRateio.CurrentRow.Cells["descricaocontacusto"].Value = oCtaCusto.descricao;
                        grdBaseRateio.CurrentRow.Cells["idcontacusto"].Value = oCtaCusto.idContaCusto.ToString();

                    }

                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["valorrateio"].Index)
                {
                    DataGridViewCell cellValorRateio = grdBaseRateio.CurrentCell;
                    DataGridViewCell cellPercentualRateio = grdBaseRateio.CurrentRow.Cells["percentualrateio"];

                    //se id da base de rateio for null vai ser uma inclusão de uma nova base 
                    // seta parametros para isto
                    if ((cellValorRateio.Value == null || EmcResources.cCur(cellValorRateio.Value.ToString()) == 0 || cellValorRateio.Value.ToString() == "") &&
                         (cellPercentualRateio.Value == null || EmcResources.cCur(cellPercentualRateio.Value.ToString()) == 0 || cellPercentualRateio.Value.ToString() == ""))
                    {
                        MessageBox.Show("Valor ou Percentual de rateio é obrigatório, preencher!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        grdBaseRateio.CurrentRow.Cells["percentualrateio"].Value = (EmcResources.cCur(grdBaseRateio.CurrentCell.Value.ToString()) / valordocumento) * 100;
                        txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(grdBaseRateio.CurrentCell.Value.ToString())).ToString();

                        if (EmcResources.cCur(txtTotalRateio.Text) > valordocumento)
                        {
                            Exception oDataMov = new Exception("Valor rateio ultrapassa o valor do rateio");
                            throw oDataMov;
                        }


                    }
                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["percentualrateio"].Index)
                {
                    DataGridViewCell cellValorRateio = grdBaseRateio.CurrentRow.Cells["valorrateio"];
                    DataGridViewCell cellPercentualRateio = grdBaseRateio.CurrentCell;

                    //se id da base de rateio for null vai ser uma inclusão de uma nova base 
                    // seta parametros para isto
                    if ((cellValorRateio.Value == null || EmcResources.cCur(cellValorRateio.Value.ToString()) == 0 || cellValorRateio.Value.ToString() == "") &&
                         (cellPercentualRateio.Value == null || EmcResources.cCur(cellPercentualRateio.Value.ToString()) == 0 || cellPercentualRateio.Value.ToString() == ""))
                    {
                        MessageBox.Show("Valor ou Percentual de rateio é obrigatório, preencher!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cellValorRateio.Value == null || EmcResources.cCur(cellValorRateio.Value.ToString()) == 0 || cellValorRateio.Value.ToString() == "")
                    {
                        grdBaseRateio.CurrentRow.Cells["valorrateio"].Value = (valordocumento * EmcResources.cCur(cellPercentualRateio.Value.ToString())) / 100;
                        txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(grdBaseRateio.CurrentCell.Value.ToString())).ToString();

                        if (EmcResources.cCur(txtTotalRateio.Text) > valordocumento)
                        {
                            Exception oDataMov = new Exception("Valor rateio ultrapassa o valor do rateio");
                            throw oDataMov;
                        }
                        grdBaseRateio.CurrentCell.Value = EmcResources.FormatText(cellPercentualRateio.Value.ToString(), "###,###,##0.00", 17, EmcResources.eAlign.Direita);
                        grdBaseRateio.CurrentRow.Cells["valorrateio"].Value = EmcResources.FormatText(cellValorRateio.Value.ToString(), "##0.00", 20, EmcResources.eAlign.Direita);


                    }
                    else
                    {
                        // SendKeys.Send("{TAB}");
                    }

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private void grdBaseRateio_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //evento quando a celula ganha o foco
            try
            {
                if (grdBaseRateio.Rows.Count > 0)
                {
                    AtivaInsercao();
                }
                DataGridViewCell idDocumento = grdBaseRateio.CurrentRow.Cells["idreceberdocumento"];
                DataGridViewCell idBaseRateio = grdBaseRateio.CurrentRow.Cells["idreceberbaserateio"];

                //se id da base de rateio for null vai ser uma inclusão de uma nova base 
                // seta parametros para isto
                if (idBaseRateio.Value == null || idBaseRateio.Value.ToString() == "0")
                {

                    grdBaseRateio.CurrentRow.Cells["status"].Value = "I";
                    grdBaseRateio.CurrentRow.Cells["idreceberdocumento"].Value = idPgrDocumento;
                    grdBaseRateio.CurrentRow.Cells["idreceberbaserateio"].Value = "0";
                }
                else
                {
                    gValorRateio = EmcResources.cCur(grdBaseRateio.CurrentRow.Cells["valorrateio"].Value.ToString());
                    gPercentualRateio = EmcResources.cCur(grdBaseRateio.CurrentRow.Cells["percentualrateio"].Value.ToString());
                    gIdAplicacao = EmcResources.cInt(grdBaseRateio.CurrentRow.Cells["idaplicacao"].Value.ToString());
                    gCodigoConta = grdBaseRateio.CurrentRow.Cells["codigoconta"].Value.ToString();

                }
                if (e.ColumnIndex == grdBaseRateio.Columns["idaplicacao"].Index)
                {

                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["aplicacao"].Index)
                {
                    SendKeys.Send("{TAB}");
                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["descricaocontacusto"].Index)
                {
                    SendKeys.Send("{TAB}");
                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["valorrateio"].Index)
                {
                    if (grdBaseRateio.CurrentCell.Value != null)
                    {
                        txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) - EmcResources.cCur(grdBaseRateio.CurrentCell.Value.ToString())).ToString();
                    }
                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["status"].Index)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private void grdBaseRateio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //formatando a informação digita pelo usuário
            try
            {

                if (e.ColumnIndex == grdBaseRateio.Columns["valorrateio"].Index)
                {


                }
                else if (e.ColumnIndex == grdBaseRateio.Columns["percentualrateio"].Index)
                {

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        #endregion

        private void btnContaCusto_Click(object sender, EventArgs e)
        {
            psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia, false);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtCodigoConta.Text = "";
                //txtIdContaCusto.Text = "";
            }
            else
                txtCodigoConta.Text = EMCCadastro.retPesquisa.chavebusca.ToString();
            txtIdContaCusto.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtCodigoConta.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtCodigoConta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigoConta.Text))
            {
                try
                {
                    ContaCusto oContaCusto = new ContaCusto();
                    ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                    oContaCusto.codigoConta = txtCodigoConta.Text;
                    //oContaCusto.codEmpresa = empMaster;

                    oContaCusto = oContaCustoRN.ObterPor(oContaCusto);

                    txtContaCusto.Text = oContaCusto.descricao;
                    txtIdContaCusto.Text = oContaCusto.idContaCusto.ToString();

                    if (oContaCusto.idContaCusto == 0)
                    {
                        btnContaCusto.Focus();
                    }
                    else
                        txtIdAplicacao.Focus();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void txtIdAplicacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Aplicacao oAplicacao = new Aplicacao();
                AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);

                oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Value.ToString());
                oAplicacao = oAplRN.ObterPor(oAplicacao);

                if (!String.IsNullOrEmpty(oAplicacao.descricao))
                {
                    txtAplicacao.Text = oAplicacao.descricao;
                    txtVlrPercentual.Focus();
                }
                else
                {
                    //MessageBox.Show("Aplicação não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAplicacao.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void btnAplicacao_Click(object sender, EventArgs e)
        {
            psqAplicacao ofrm = new psqAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdAplicacao.Text = "0";
            }
            else
            {
                txtIdAplicacao.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                txtIdAplicacao.Focus();
                SendKeys.Send("{TAB}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalRateio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNovoRateio_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAplicacao.Text) &&
                    !String.IsNullOrEmpty(txtCodigoConta.Text) &&
                     txtVlrUnitario.Value > 0 && txtVlrPercentual.Value > 0)
                {

                    if (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(txtVlrUnitario.Value.ToString()) > valordocumento)
                    {
                        Exception oDataMov = new Exception("Valor rateio ultrapassa o valor do documento");
                        throw oDataMov;
                    }
                    else
                    {
                        grdBaseRateio.Rows.Add(idPgrDocumento, 0, txtIdAplicacao.Text, txtAplicacao.Text, txtIdContaCusto.Text, txtCodigoConta.Text, txtContaCusto.Text, txtVlrUnitario.Value.ToString(), txtVlrPercentual.Value.ToString(), "I");
                        txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(txtVlrUnitario.Value.ToString())).ToString();
                        LimpaCampos();
                    }

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtVlrUnitario_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double calculaPerc = Math.Round(((EmcResources.cDouble(txtVlrUnitario.Value.ToString()) / EmcResources.cDouble(valordocumento.ToString())) * 100), 4);
                txtVlrPercentual.Text = calculaPerc.ToString();

                if (btnAlteraRateio.Enabled == true)
                    btnAlteraRateio.Focus();
                else
                    btnNovoRateio.Focus();
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void txtVlrPercentual_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Double calculaValor = Math.Round((EmcResources.cDouble(valordocumento.ToString()) * (EmcResources.cDouble(txtVlrPercentual.Value.ToString()) / 100)), 2);
                txtVlrUnitario.Text = EmcResources.cCur(calculaValor.ToString()).ToString();
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnAlteraRateio_Click(object sender, EventArgs e)
        {
            string varStatus = txtStatus.Text;
            try
            {
                if (!String.IsNullOrEmpty(txtIdAplicacao.Text) &&
                    !String.IsNullOrEmpty(txtCodigoConta.Text) &&
                     txtVlrUnitario.Value > 0 && txtVlrPercentual.Value > 0)
                {

                    /* define qual status gravar na grid */
                    /*Se for vazio coloca alteração pois veio carregado do banco */

                    if (String.IsNullOrEmpty(varStatus))
                        varStatus = "A";
                    else if (varStatus == "A")
                        varStatus = "A";
                    else if (varStatus == "I")
                        varStatus = "I";
                    else if (varStatus == "E")
                    {
                        Exception oDataMov = new Exception("Rateio não pode ser alterado pois está com status de exclusão");
                        throw oDataMov;
                    }

                    /* realiza a alteração do valor acumulado no documento */
                    if (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(txtVlrUnitario.Value.ToString()) - EmcResources.cCur(txtValorAnterior.Value.ToString()) > valordocumento)
                    {
                        Exception oDataMov = new Exception("Valor rateio ultrapassa o valor do documento");
                        throw oDataMov;
                    }
                    else
                    {
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["status"].Value = varStatus;
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["valorrateio"].Value = txtVlrUnitario.Value.ToString();
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["percentualrateio"].Value = txtVlrPercentual.Value.ToString();
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["descricaocontacusto"].Value = txtContaCusto.Text;
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["codigoconta"].Value = txtCodigoConta.Text;
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["idcontacusto"].Value = txtIdContaCusto.Text;
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["aplicacao"].Value = txtAplicacao.Text;
                        grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Value.ToString())].Cells["idaplicacao"].Value = txtIdAplicacao.Text;

                        txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(txtVlrUnitario.Value.ToString()) - EmcResources.cCur(txtValorAnterior.Value.ToString())).ToString();

                        LimpaCampos();
                    }

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void btnExcluiParcela_Click(object sender, EventArgs e)
        {
            string varStatus = grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Text)].Cells["status"].Value.ToString();

            if (varStatus == "E")
            {
                if (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(txtVlrUnitario.Value.ToString()) > valordocumento)
                {
                    Exception oDataMov = new Exception("Valor rateio ultrapassa o valor do documento");
                    throw oDataMov;
                }

                if (grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Text)].Cells["idpagarbaserateio"].Value.ToString() == "0")
                {
                    grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Text)].Cells["status"].Value = "I";
                }
                else
                {
                    grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Text)].Cells["status"].Value = "A";
                }
                txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) + EmcResources.cCur(txtVlrUnitario.Value.ToString())).ToString();
            }
            else
            {
                grdBaseRateio.Rows[EmcResources.cInt(txtGridIndex.Text)].Cells["status"].Value = "E";
                txtTotalRateio.Text = (EmcResources.cCur(txtTotalRateio.Text) - EmcResources.cCur(txtVlrUnitario.Value.ToString())).ToString();
            }
            LimpaCampos();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtVlrUnitario_TextChanged(object sender, EventArgs e)
        {

        }
      


    }
}
