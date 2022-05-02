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
    public partial class frmReceberDocumento : EMCLibrary.EMCForm
    {

        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmReceberDocumento";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        List<ReceberBaseRateio> lstRateio = new List<ReceberBaseRateio>();
        DataTable dtParcelas = new DataTable();
        Boolean travaDataEntrada = false;
        DateTime dataContabilidade = DateTime.Now;
        Boolean travaContabil = false;
        int idMoedaCorrente = 0;
        Boolean utilizaIndexador = false;
        double txaJuros = 0;
        double txaMulta = 0;


        #region [Metodos para configuração do formulário]
        public frmReceberDocumento(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmReceberDocumento()
        {
            InitializeComponent();
        }

        private void frmReceberDocumento_Load(object sender, EventArgs e)
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

            //Periodicidade
            cboPeriodicidade.Items.Add("Parcela Unica");
            cboPeriodicidade.Items.Add("Quinzenal");
            cboPeriodicidade.Items.Add("Mensal");
            cboPeriodicidade.Items.Add("Bimestral");
            cboPeriodicidade.Items.Add("Semestral");
            cboPeriodicidade.Items.Add("Anual");

            cboPeriodicidade.SelectedIndex = 0;

            
            btnRateio.Enabled = false;

            CancelaOperacao();

            this.ActiveControl = txtCNPJCPF;

        }

#endregion

        #region [Tratamento de Texts, combos ]
        private void txtValorDocumento_Validating(object sender, CancelEventArgs e)
        {
            atualizaSomaGrid();
        }

        //Cliente
        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCNPJCPF.Text))
                {
                    txtIdCliente.ReadOnly = false;
                    txtIdCliente.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCNPJCPF.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCNPJCPF.Text.Trim().Length == 11)
                    {
                        txtCNPJCPF.Mask = "000.000.000-00";
                        lblCNPJ.Text = "CPF";
                        txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCNPJCPF.Text.Trim().Length == 14)
                    {
                        txtCNPJCPF.Mask = "00.000.000/0000-00";
                        lblCNPJ.Text = "CNPJ";
                        txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCNPJ.Text = "CNPJ/CPF";
                    }

                    if (txtCNPJCPF.Text.Trim().Length > 0)
                    {
                        ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                        Cliente oCliente = new Cliente();

                        oCliente = oClienteRN.ObterPor(empMaster, txtCNPJCPF.Text.Trim());

                        if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdCliente.ReadOnly = false;
                            txtIdCliente.Focus();
                        }
                        else
                        {
                            txtIdCliente.Text = oCliente.idPessoa.ToString();
                            txtRazaoSocial.Text = oCliente.pessoa.nome;
                            exibeInfoCarteira();
                            txtIdCliente.ReadOnly = true;
                            txtNroDocumento.Focus();
                        }


                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message, "Erro", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
            }
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text))
            {
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                Cliente oCliente = new Cliente();

                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);

                if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtIdCliente.Text = oCliente.idPessoa.ToString();
                    txtCNPJCPF.Text = oCliente.pessoa.cnpjCpf;
                    txtRazaoSocial.Text = oCliente.pessoa.nome;

                    if (txtCNPJCPF.Text.Trim().Length == 11)
                    {
                        txtCNPJCPF.Mask = "000.000.000-00";
                        lblCNPJ.Text = "CPF";
                    }
                    else if (txtCNPJCPF.Text.Trim().Length == 14)
                    {
                        txtCNPJCPF.Mask = "00.000.000/0000-00";
                        lblCNPJ.Text = "CNPJ";
                    }
                    exibeInfoCarteira();
                    txtNroDocumento.Focus();
                }

            }
            else
            {
                txtCNPJCPF.Focus();
            }
        }

        private void txtNroDocumento_Validating(object sender, CancelEventArgs e)
        {
            pesquisaDocumento();
            txtDataEmissao.Focus();
        }

        private void exibeInfoCarteira()
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text.Trim()) && txtIdCliente.Text != "System.Data.DataRowView")
            {

                Fornecedor oFornecedor = new Fornecedor();
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = EmcResources.cInt(txtIdCliente.Text);

                Cliente oCliente = new Cliente();
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);

                //Receber
                ReceberParcelaRN oRcParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                txtSaldoDevedor.Text = oRcParcelaRN.calculaSaldoDevedor(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtSdoAtraso.Text = oRcParcelaRN.calculaSaldoAtraso(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtSdo30Dias.Text = oRcParcelaRN.calculaVencimento30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtSdoVencimentoUP30dias.Text = oRcParcelaRN.calculaSdoVencimentoUp30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();

                //Pagar
                PagarParcelaRN oPgParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                txtFornSdoDevedor.Text = oPgParcelaRN.calculaSaldoDevedor(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtFornSdoAtraso.Text = oPgParcelaRN.calculaSaldoAtraso(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtFornSdo30D.Text = oPgParcelaRN.calculaVencimento30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtFornSdoUp30D.Text = oPgParcelaRN.calculaSdoVencimentoUp30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();

                //dados adiantamentos - Fornecedor
                PagarBaixaRN oPgBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                txtFornSdoAdto.Text = oPgBaixaRN.calculaSdoAdiantamento(oFornecedor).ToString();

                //dados adiantamentos - Cliente
                ReceberBaixaRN oRcBaixaRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                txtClienteSdoAdto.Text = oRcBaixaRN.calculaSdoAdiantamento(oCliente).ToString();
            }
        }

        private void exibeSdoDocumento()
        {
            if (!String.IsNullOrEmpty(txtIdReceberDocumento.Text.Trim()) && txtIdCliente.Text != "System.Data.DataRowView")
            {
                ReceberParcelaRN oRcParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                txtInfVlrDocumento.Text = oRcParcelaRN.calculaDocParcela(EmcResources.cInt(txtIdReceberDocumento.Text)).ToString();
                txtInfVlrDescontos.Text = oRcParcelaRN.calculaDocDesconto(EmcResources.cInt(txtIdReceberDocumento.Text)).ToString();
                txtInfVlrJuros.Text = oRcParcelaRN.calculaDocJuros(EmcResources.cInt(txtIdReceberDocumento.Text)).ToString();
                txtInfVlrPago.Text = oRcParcelaRN.calculaDocSdoPago(EmcResources.cInt(txtIdReceberDocumento.Text)).ToString();
                txtInfVlrPagar.Text = oRcParcelaRN.calculaDocSdoPagar(EmcResources.cInt(txtIdReceberDocumento.Text)).ToString();
            }
        }

        #endregion

        #region [metodos para tratamento das informacoes]
        private void constroiCombos()
        {
            try
            {
                /* Busca a taxa de juros e multa padrão da empresa */
                ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                txaJuros = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "TAXA_JUROS"));
                txaMulta = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "TAXA_MULTA"));

                txtTaxaJuros.Text = txaJuros.ToString();
                txtTaxaMulta.Text = txaMulta.ToString();

                /* Identifica o codigo do indexador da moeda corrente no pais */
                idMoedaCorrente = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "MOEDA_CORRENTE"));

                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "UTILIZA_INDEXADOR") == "S")
                    utilizaIndexador = true;
                else
                    utilizaIndexador = false;

                //Carregamento de Combobox do formulário
                TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                cboTipoCobranca.DataSource = oCobrRN.ListaTipoCobranca();
                cboTipoCobranca.DisplayMember = "descricao";
                cboTipoCobranca.ValueMember = "idtipocobranca";

                IndexadorRN oIndexRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
                cboIdIndexador.DataSource = oIndexRN.ListaIndexador();
                cboIdIndexador.DisplayMember = "descricao";
                cboIdIndexador.ValueMember = "idindexador";
                cboIdIndexador.SelectedValue = idMoedaCorrente;

                if (!utilizaIndexador)
                {
                    cboIdIndexador.Enabled = false;
                }

                TipoDocumentoRN oTipoDocRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                cboIdTipoDocumento.DataSource = oTipoDocRN.ListaTipoDocumento();
                cboIdTipoDocumento.DisplayMember = "descricao";
                cboIdTipoDocumento.ValueMember = "idtipodocumento";

                cboPeriodicidade.SelectedIndex = 0;


                //verifica se o financeiro permite lancamento retroativo
                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "LANCTO_RETROATIVO") == "N")
                {
                    travaDataEntrada = true;
                }

                if (travaDataEntrada)
                {
                    txtDataEntrada.Text = DateTime.Now.ToString();
                    txtDataEntrada.Enabled = false;
                }


                //carrega valores da TRAVACONTABIL e PROCESSO_CONTABIL
                if (oParametroRN.retParametro(codempresa, "EMCCONTABIL", "VALIDACAO", "TRAVADIGITACAO") == "S")
                {
                    travaContabil = true;
                }
                else
                    travaContabil = false;

                dataContabilidade = Convert.ToDateTime(oParametroRN.retParametro(codempresa, "EMCCONTABIL", "VALIDACAO", "PROCESSO_CONTABIL"));


            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message, "Erro", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        private Boolean verificaReceberDocumento(ReceberDocumento oRcdoc)
        {
            ReceberDocumentoRN oReceberRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                if (travaContabil)
                {
                    if (Convert.ToDateTime(txtDataEntrada.Text) <= dataContabilidade)
                    {
                        MessageBox.Show("Data Entrada do Lançamento anterior ao fechamento contábil!");
                        return false;
                    }
                }
                oReceberRN.VerificaDados(oRcdoc);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }

        private ReceberDocumento montaReceberDocumento()
        {
            ReceberDocumento oReceberDocumento = new ReceberDocumento();

            oReceberDocumento.codEmpresa = codempresa;
            oReceberDocumento.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());



            // se for alteracao executa
            flagInclusao = false;
            if (!flagInclusao)
            {
                oReceberDocumento.cadastro_idusuario = Convert.ToInt32(usuario);
                oReceberDocumento.cadastro_datahora = DateTime.Now;

                oReceberDocumento.dataEmissao = EmcResources.cDate(txtDataEmissao.Text.ToString());
                oReceberDocumento.dataEntrada = EmcResources.cDate(txtDataEntrada.Text.ToString());
                oReceberDocumento.valorDocumento = Convert.ToDecimal(txtValorDocumento.Value.ToString());
                oReceberDocumento.nroParcelas = EmcResources.cInt(txtNroParcelas.Text);
                oReceberDocumento.situacao = "A";
                oReceberDocumento.taxaJuros = EmcResources.cDouble(txtTaxaJuros.Value.ToString());
                oReceberDocumento.taxaMulta = EmcResources.cDouble(txtTaxaMulta.Value.ToString());

                if (cboPeriodicidade.Text == "Quinzenal")
                    oReceberDocumento.periodicidade = "Q";
                else if (cboPeriodicidade.Text == "Mensal")
                    oReceberDocumento.periodicidade = "M";
                else if (cboPeriodicidade.Text == "Bimestral")
                    oReceberDocumento.periodicidade = "B";
                else if (cboPeriodicidade.Text == "Semestral")
                    oReceberDocumento.periodicidade = "S";
                else if (cboPeriodicidade.Text == "Anual")
                    oReceberDocumento.periodicidade = "A";
                else if (cboPeriodicidade.Text == "Parcela Unica")
                    oReceberDocumento.periodicidade = "P";
                else
                    oReceberDocumento.periodicidade = "M";

                oReceberDocumento.diaFixo = EmcResources.cStr(txtDiaFixo.Text);
                oReceberDocumento.origemDocumento = lblOrigemDocumento.Text.Trim();
                oReceberDocumento.descricao = EmcResources.cStr(txtDescricao.Text);

                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao,objOcorrencia,empMaster);
                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);
                oReceberDocumento.cliente = oCliente;

                TipoDocumento oTipo = new TipoDocumento();
                TipoDocumentoRN oTipoRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                oTipo.idTipoDocumento = Convert.ToInt32(cboIdTipoDocumento.SelectedValue);
                oTipo = oTipoRN.ObterPor(oTipo);
                oReceberDocumento.tipoDocumento = oTipo;

                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
                oIndexador.idIndexador = Convert.ToInt32(cboIdIndexador.SelectedValue);
                oIndexador = oIndexadorRN.ObterPor(oIndexador);
                oReceberDocumento.indexador = oIndexador;

                //atribui rateios ao documento a pagar
                oReceberDocumento.baseRateio = lstRateio;

                List<ReceberParcela> lstParcelas = new List<ReceberParcela>();
                ReceberParcela oParcela;
                ReceberDocumento oDoc = new ReceberDocumento();

                oDoc.idReceberDocumento = EmcResources.cInt(txtIdReceberDocumento.Text);

                

                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdReceberParcelas.Rows)
                {

                    oParcela = new ReceberParcela();


                    oParcela.cadastro_idusuario = Convert.ToInt32(usuario);
                    oParcela.cadastro_datahora = DateTime.Now;
                    oParcela.codEmpresa = codempresa;
                    oParcela.dataVencimento = EmcResources.cDate(dataGridViewRow.Cells["datavencimento"].Value.ToString());
                    oParcela.idReceberParcela = EmcResources.cInt(dataGridViewRow.Cells["idreceberparcelas"].Value.ToString());
                    oParcela.boleto_NossoNumero = dataGridViewRow.Cells["nossonumero"].Value.ToString();
                    oParcela.nroParcela = EmcResources.cInt(dataGridViewRow.Cells["nroparcela"].Value.ToString());
                    oParcela.receberDocumento = oDoc;
                    oParcela.saldoPagar = Convert.ToDecimal(dataGridViewRow.Cells["saldopagar"].Value.ToString());
                    oParcela.saldoPago = Convert.ToDecimal(dataGridViewRow.Cells["saldopago"].Value.ToString());
                    oParcela.situacao = dataGridViewRow.Cells["situacao"].Value.ToString();
                    oParcela.valorDesconto = Convert.ToDecimal(dataGridViewRow.Cells["valordesconto"].Value.ToString());
                    oParcela.valorJuros = Convert.ToDecimal(dataGridViewRow.Cells["valorjuros"].Value.ToString());
                    oParcela.valorParcela = Convert.ToDecimal(dataGridViewRow.Cells["valorparcela"].Value.ToString());
                    oParcela.status = dataGridViewRow.Cells["status"].Value.ToString();
                    oParcela.jurosPrevisto = EmcResources.cCur(dataGridViewRow.Cells["jurosprevisto"].Value.ToString());
                    oParcela.multaPrevisto = EmcResources.cCur(dataGridViewRow.Cells["multaprevista"].Value.ToString());
                    oParcela.dtaUltCalculoJuros = DateTime.Now;

                    TipoCobranca oCobr = new TipoCobranca();
                    TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                    oCobr.idTipoCobranca = EmcResources.cInt(dataGridViewRow.Cells["idtipocobranca"].Value.ToString());
                    oCobr = oCobrRN.ObterPor(oCobr);
                    oParcela.tipoCobranca = oCobr;

                    Formulario oForm = new Formulario();
                    if (EmcResources.cInt(dataGridViewRow.Cells["idformulario"].Value.ToString()) > 0)
                    {
                        FormularioRN oFormRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
                        oForm.idFormulario = EmcResources.cInt(dataGridViewRow.Cells["idformulario"].Value.ToString());
                        oForm = oFormRN.ObterPor(oForm);
                    }
                    else
                        oForm.idFormulario = 0;

                    oParcela.formulario = oForm;
                    oParcela.receberDocumento = oReceberDocumento;

                    List<ReceberBaixa> lstBaixa = new List<ReceberBaixa>();

                    if (oParcela.idReceberParcela > 0)
                    {
                        ReceberBaixaRN oBxRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                        lstBaixa = oBxRN.listaBaixasParcela(oParcela.idReceberParcela);
                    }

                    oParcela.baixas = lstBaixa;

                    lstParcelas.Add(oParcela);
                }


                oReceberDocumento.parcelas = lstParcelas;
            }

            return oReceberDocumento;
        }

        private void montaTela(ReceberDocumento oReceberDocumento)
        {
            txtSituacao.Text = oReceberDocumento.situacao;
            if (oReceberDocumento.situacao == "P")
            {
                lblSituacao.Text = "Documento Quitado";
                travaBotao("btnExcluir");
                travaBotao("btnAtualizar");
            }
            else
            {
                lblSituacao.Text = "";
                liberaBotao("btnExcluir");
                liberaBotao("btnAtualizar");
            }

            lblOrigemDocumento.Text = oReceberDocumento.origemDocumento;
            txtIdReceberDocumento.Text = oReceberDocumento.idReceberDocumento.ToString();
            txtNroDocumento.Text = oReceberDocumento.nroDocumento;
            txtDataEmissao.Text = oReceberDocumento.dataEmissao.ToString();
            txtDataEntrada.Text = oReceberDocumento.dataEntrada.ToString();
            cboIdTipoDocumento.SelectedValue = oReceberDocumento.tipoDocumento.idTipoDocumento.ToString();

            txtIdCliente.Text = oReceberDocumento.cliente.idPessoa.ToString();
            txtIdCliente_Validating(null, null);

            cboIdIndexador.SelectedValue = oReceberDocumento.indexador.idIndexador.ToString();


            txtDescricao.Text = oReceberDocumento.descricao.ToString();
            if (oReceberDocumento.periodicidade == "Q")
                cboPeriodicidade.Text = "Quinzenal";
            else if (oReceberDocumento.periodicidade == "M")
                cboPeriodicidade.Text = "Mensal";
            else if (oReceberDocumento.periodicidade == "B")
                cboPeriodicidade.Text = "Bimestral";
            else if (oReceberDocumento.periodicidade == "S")
                cboPeriodicidade.Text = "Semestral";
            else if (oReceberDocumento.periodicidade == "A")
                cboPeriodicidade.Text = "Anual";
            else if (oReceberDocumento.periodicidade == "P")
                cboPeriodicidade.Text = "Parcela Unica";


            txtDiaFixo.Text = oReceberDocumento.diaFixo.ToString();
            txtValorDocumento.Text = oReceberDocumento.valorDocumento.ToString();
            txtNroParcelas.Text = oReceberDocumento.nroParcelas.ToString();

            //carrega rateios
            lstRateio = oReceberDocumento.baseRateio;

            AtualizaGrid(oReceberDocumento);
            exibeInfoCarteira();

            exibeSdoDocumento();

            atualizaSomaGrid();
            btnExcluiParcela.Enabled = true;
            btnIncluiParcela.Enabled = true;
            btnRateio.Enabled = true;
            objOcorrencia.chaveidentificacao = oReceberDocumento.idReceberDocumento.ToString();

           
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
            btnGeraParcelas.Enabled = false;
            if (txtSituacao.Text == "P")
            {
                travaBotao("btnExcluir");
                travaBotao("btnAtualizar");
            }
            else
            {
                liberaBotao("btnExcluir");
                liberaBotao("btnAtualizar");
            }
            btnRateio.Enabled = true;
            txtNroDocumento.Enabled = false;
            txtCNPJCPF.Enabled = false;
            txtIdCliente.Enabled = false;

        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            btnGeraParcelas.Enabled = true;
            btnRateio.Enabled = true;

            txtNroDocumento.Enabled = true;
            txtCNPJCPF.Enabled = true;
            txtIdCliente.Enabled = true;
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            
            lstRateio = null;
            objOcorrencia.chaveidentificacao = "";
            btnRateio.Enabled = false;
            constroiCombos();

            txtNroDocumento.Enabled = true;
            txtCNPJCPF.Enabled = true;
            txtIdCliente.Enabled = true;


            txtCNPJCPF.Focus();
        }

        public override void BuscaObjeto()
        {
            psqContasReceber oPsq = new psqContasReceber(usuario,
                                                         login,
                                                         codempresa.ToString(),
                                                         empMaster.ToString(),
                                                         Conexao,
                                                         objOcorrencia);
            oPsq.ShowDialog();

            oPsq.Dispose();

            txtNroDocumento.Text = retPesquisa.chavebusca;
            if (EmcResources.cInt(retPesquisa.chaveinterna.ToString()) > 0)
                txtIdReceberDocumento.Text = retPesquisa.chaveinterna.ToString();

            if (!String.IsNullOrEmpty(txtNroDocumento.Text) || !String.IsNullOrEmpty(txtIdReceberDocumento.Text))
            {
                pesquisaDocumento();
            }

        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            lblOrigemDocumento.Text = "CTARECEBER";
            txtIdCliente.Text = "";
            txtCNPJCPF.Text = "";
            txtNroDocumento.Text = "";
            flagInclusao = true;
            grdReceberParcelas.Rows.Clear();
            grdReceberBaixa.Rows.Clear();
            txtValorDocumento.Text = "0";
            txtSomaParcelas.Text = "0";
            txtInfVlrDescontos.Text = "0";
            txtInfVlrDocumento.Text = "0";
            txtInfVlrJuros.Text = "0";
            txtInfVlrPagar.Text = "0";
            txtInfVlrPago.Text = "0";
            txtSaldoDevedor.Text = "0";
            txtSdo30Dias.Text = "0";
            txtSdoAtraso.Text = "0";
            txtSdoVencimentoUP30dias.Text = "0";
            txtSomaParcelas.Text = "0";
            lstRateio = null;
            objOcorrencia.chaveidentificacao = "";
            constroiCombos();

            cboPeriodicidade.SelectedIndex = 0;
            txtCNPJCPF.Focus();
        }

        public override void SalvaObjeto()
        {

            try
            {
                if (EmcResources.cCur(txtValorDocumento.Value.ToString()) != EmcResources.cCur(txtSomaParcelas.Text))
                {
                    MessageBox.Show("Valor do documento não fecha com as parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (verificaSequenciaParcelas())
                {
                    MessageBox.Show("Verifique a sequencia das parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ReceberDocumento oReceberDocumento = new ReceberDocumento();
                    ReceberDocumentoRN oReceberDocumentoRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);

                    oReceberDocumento = montaReceberDocumento();


                    if (verificaReceberDocumento(oReceberDocumento))
                    {
                        oReceberDocumentoRN.Salvar(oReceberDocumento);
                        LimpaCampos();
                    }
                    
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " - " + erro.StackTrace);
            }

        }

        public override void AtualizaObjeto()
        {
            try
            {
                if (EmcResources.cCur(txtValorDocumento.Value.ToString()) != EmcResources.cCur(txtSomaParcelas.Text))
                {
                    MessageBox.Show("Valor do documento não fecha com as parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSituacao.Text == "P")
                {
                    MessageBox.Show("Documento já está quitado, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (verificaSequenciaParcelas())
                {
                    MessageBox.Show("Verifique a sequencia das parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    ReceberDocumento oReceberDocumento = new ReceberDocumento();
                    ReceberDocumentoRN oReceberDocumentoRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);

                    oReceberDocumento = montaReceberDocumento();
                    oReceberDocumento.idReceberDocumento = Convert.ToInt32(txtIdReceberDocumento.Text);

                    if (verificaReceberDocumento(oReceberDocumento))
                    {
                        oReceberDocumentoRN.Atualizar(oReceberDocumento);
                        
                        txtNroDocumento_Validating(null, null);
                        
                        //LimpaCampos();

                        MessageBox.Show("Documento atualizado com sucesso");
                    }
                    else MessageBox.Show("Atualização cancelada");
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
                ReceberDocumento oReceberDocumento = new ReceberDocumento();
                ReceberDocumentoRN oReceberDocumentoRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);
                oReceberDocumento = montaReceberDocumento();
                oReceberDocumento.idReceberDocumento = Convert.ToInt32(txtIdReceberDocumento.Text);

                if (verificaReceberDocumento(oReceberDocumento))
                {
                    oReceberDocumentoRN.Excluir(oReceberDocumento);

                    MessageBox.Show("Documento excluido!", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);

                    CancelaOperacao();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            
        }

        public void pesquisaDocumento()
        {
            try
            {
                ReceberDocumento oReceberDocumento = new ReceberDocumento();

                if (!String.IsNullOrEmpty(txtNroDocumento.Text) && !String.IsNullOrEmpty(txtIdCliente.Text))
                {
                    Cliente oCli = new Cliente();
                    oCli.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                    oCli.codEmpresa = empMaster;

                    oReceberDocumento.codEmpresa = codempresa;
                    oReceberDocumento.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());
                    oReceberDocumento.cliente = oCli;
                }
                else if (!String.IsNullOrEmpty(txtIdReceberDocumento.Text))
                {
                    oReceberDocumento.idReceberDocumento = EmcResources.cInt(txtIdReceberDocumento.Text);
                    oReceberDocumento.codEmpresa = codempresa;
                }

                if ((!String.IsNullOrEmpty(txtNroDocumento.Text) && !String.IsNullOrEmpty(txtIdCliente.Text)) || (!String.IsNullOrEmpty(txtIdReceberDocumento.Text)))
                {
                    ReceberDocumentoRN oReceberDocumentoRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);
                    oReceberDocumento = oReceberDocumentoRN.ObterPor(oReceberDocumento);

                    if (!String.IsNullOrEmpty(oReceberDocumento.descricao))
                    {
                        montaTela(oReceberDocumento);
                        AtualizaGrid(oReceberDocumento);
                        AtivaEdicao();
                        flagInclusao = false;
                    }
                    else
                    {
                        AtivaInsercao();
                        flagInclusao = true;
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region [metodos para controle da grid]

        public void AtualizaGrid(ReceberDocumento oReceberDocumento)
        {

            //foreach (DataRow row in dtPAgamento)

            //adquiri lista de parcelas do objeto documento
            List<ReceberParcela> lstPagarParcela = oReceberDocumento.parcelas;

            grdReceberParcelas.Rows.Clear();
            Decimal somaParcelas = 0;
            Decimal somaJurosCalc = 0;
            Decimal somaMultaCalc = 0;
            DateTime? dataUltCalc = DateTime.Now;

            foreach (ReceberParcela oParcela in lstPagarParcela)
            {
                grdReceberParcelas.Rows.Add("", oParcela.nroParcela, oParcela.dataVencimento, oParcela.dataQuitacao, oParcela.valorParcela,
                                          oParcela.saldoPago, oParcela.valorDesconto, oParcela.valorJuros, oParcela.saldoPagar,
                                          oParcela.situacao, oParcela.jurosPrevisto, oParcela.multaPrevisto,
                                          oParcela.boleto_NossoNumero, oParcela.idReceberParcela,
                                          oParcela.tipoCobranca.descricao, oParcela.tipoCobranca.idTipoCobranca, oParcela.formulario.descricaoFormulario, oParcela.formulario.idFormulario);
                somaParcelas = somaParcelas + oParcela.valorParcela;
                somaJurosCalc = somaJurosCalc + oParcela.jurosPrevisto;
                somaMultaCalc = somaMultaCalc + oParcela.multaPrevisto;

                if (oParcela.dtaUltCalculoJuros is DateTime)
                    dataUltCalc = Convert.ToDateTime(oParcela.dtaUltCalculoJuros.ToString());
                else
                    dataUltCalc = null;
                
            }

            txtSomaParcelas.Text = somaParcelas.ToString();
            txtJurosDocumento.Text = somaJurosCalc.ToString();
            txtMultaDocumento.Text = somaMultaCalc.ToString();
            txtDataUltimoCalculo.Text = dataUltCalc.ToString();

            grdReceberParcelas.ScrollBars = ScrollBars.Both;

        }
        public void atualizaSomaGrid()
        {
            Decimal somaParcelas = 0;
            foreach (DataGridViewRow row in grdReceberParcelas.Rows)
            {
                if (row.Cells["status"].Value.ToString() != "E")
                {
                    somaParcelas = somaParcelas + Convert.ToDecimal(row.Cells["valorparcela"].Value.ToString());
                }
            }
            txtSomaParcelas.Text = somaParcelas.ToString();

            if (somaParcelas != EmcResources.cCur(txtValorDocumento.Value.ToString()))
            {
                txtSomaParcelas.BackColor = Color.Red;
            }
            else
                txtSomaParcelas.BackColor = Color.Yellow;
        }
        private void grdReceberParcelas_Click(object sender, EventArgs e)
        {
            try
            {
                ReceberBaixaRN oReceberBaixaRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                List<ReceberBaixa> lstReceberParcela = new List<ReceberBaixa>();

                lstReceberParcela = oReceberBaixaRN.listaBaixasParcela(Convert.ToInt32(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["idreceberparcelas"].Value.ToString()));

                grdReceberBaixa.Rows.Clear();

                foreach (ReceberBaixa oReceberBaixa in lstReceberParcela)
                {
                    grdReceberBaixa.Rows.Add(oReceberBaixa.documentoBaixa, oReceberBaixa.situacaoBaixa, oReceberBaixa.valorBaixa, oReceberBaixa.valorJuros, oReceberBaixa.valorDesconto, oReceberBaixa.contaCorrente.Banco.descricao, oReceberBaixa.contaCorrente.descricao, oReceberBaixa.nominal, oReceberBaixa.formaPagamento.descricao, oReceberBaixa.historico, oReceberBaixa.idReceberBaixa);
                }
                grdReceberBaixa.ScrollBars = ScrollBars.Both;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region [Calculos do parcelamento]

        private void btnGeraParcelas_Click(object sender, EventArgs e)
        {

            //verifica as informações necessárias
            if (EmcResources.cCur(txtValorDocumento.Value.ToString()) == 0)
                MessageBox.Show("Valor do documento deve ser informado!");
            else if (Convert.ToInt32(txtNroParcelas.Text) == 0)
                MessageBox.Show("Número de Parcelas deve ser informado!");
            else
            {

                calculaParcelamento();
            }


        }
        private void calculaParcelamento()
        {
            //Limpa a grid
            grdReceberParcelas.Rows.Clear();

            //Atribui valores
            Decimal valorDocumento = EmcResources.cCur(txtValorDocumento.Value.ToString());
            int nroParcelas = Convert.ToInt32(txtNroParcelas.Text);

            //Calcula parcela e diferencas
            Decimal vlrParcela = Decimal.Round((valorDocumento / nroParcelas), 2);
            Decimal vlrDiferenca = valorDocumento - (vlrParcela * nroParcelas);

            //Geração de Parcelas
            int xParc = 1;
            DateTime xDataVenc = Convert.ToDateTime(txtDataEmissao.Text);

            while (xParc <= nroParcelas)
            {
                //ser for a ultima parcela joga a diferença
                if (xParc == nroParcelas)
                    vlrParcela = (vlrParcela + vlrDiferenca);

                //atribui o numero de dias de acordo com a periodicidade escolhida
                if (cboPeriodicidade.Text == "Mensal")
                    xDataVenc = xDataVenc.AddDays(30);
                else if (cboPeriodicidade.Text == "Quinzenal")
                    xDataVenc = xDataVenc.AddDays(15);
                else if (cboPeriodicidade.Text == "Bimestral")
                    xDataVenc = xDataVenc.AddDays(60);
                else if (cboPeriodicidade.Text == "Semestral")
                    xDataVenc = xDataVenc.AddDays(180);
                else if (cboPeriodicidade.Text == "Anual")
                    xDataVenc = xDataVenc.AddDays(360);
                else if (cboPeriodicidade.Text == "Parcela Unica")
                    xDataVenc = Convert.ToDateTime(txtVencimento.DateValue.ToString());

                //Verifica dia fixo
                DateTime dataGravar = xDataVenc;
                if (!String.IsNullOrEmpty(txtDiaFixo.Text))
                {
                    String dtDiafixo = "";
                    String diaFixo = txtDiaFixo.Text;

                    if (txtDiaFixo.Text == "30" || txtDiaFixo.Text == "31")
                    {
                        //verifica dia fixo se é o ultimo dia do mes
                        if (dataGravar.Month == 2)
                            diaFixo = "28";
                        else if (dataGravar.Month == 1 || dataGravar.Month == 3 || dataGravar.Month == 5
                              || dataGravar.Month == 7 || dataGravar.Month == 8 || dataGravar.Month == 10
                              || dataGravar.Month == 12)
                            diaFixo = "31";
                        else diaFixo = "30";
                    }

                    dtDiafixo = diaFixo + "/" + xDataVenc.Month.ToString() + "/" + xDataVenc.Year.ToString();

                    dataGravar = Convert.ToDateTime(dtDiafixo);
                }

                ParametroRN oParametroRN = new ParametroRN(Conexao,objOcorrencia,codempresa);
                //verifica o parametro considera data valida para vencimento de parcelas.
                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "VENCIMENTO_DIA_UTIL") == "S")
                {
                    // colocar if de acordo com parametro
                    FeriadoRN oFeriadoRN = new FeriadoRN(Conexao, objOcorrencia, codempresa);
                    dataGravar = oFeriadoRN.diaUtil(dataGravar);
                }

                TipoCobrancaRN oTpCobRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                TipoCobranca otpCob = new TipoCobranca();
                otpCob.idTipoCobranca = EmcResources.cInt(cboTipoCobranca.SelectedValue.ToString());
                otpCob = oTpCobRN.ObterPor(otpCob);

                grdReceberParcelas.Rows.Add("", xParc, dataGravar, "", vlrParcela, 0, 0, 0, vlrParcela, "A",0,0, "", "", otpCob.descricao, otpCob.idTipoCobranca.ToString(),"",0);

                xParc++;
            }

            atualizaSomaGrid();
        }

        #endregion 

        #region [metodos para gerir alteracoes no parcelamento]
        private void btnExcluiParcela_Click(object sender, EventArgs e)
        {
            if (grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["status"].Value.ToString() == "E")
                    grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["status"].Value = "";
                else
                    grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["status"].Value = "E";

                atualizaSomaGrid();
            }
        }
        private void btnIncluiParcela_Click(object sender, EventArgs e)
        {
            limpaGlobalParcela();
            frmReceberEditaParcelas ofrm = new frmReceberEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
            if (gPagarParcela.nroParcela > 0)
                gravaAltParcela();
        }
        private void grdReceberParcelas_DoubleClick(object sender, EventArgs e)
        {
            if (grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                montaGlobalParcela();
                frmReceberEditaParcelas ofrm = new frmReceberEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();
                gravaAltParcela();
            }
        }
        private void montaGlobalParcela()
        {
            gPagarParcela.nroLinha = grdReceberParcelas.CurrentRow.Index;
            gPagarParcela.idPagarParcela = EmcResources.cInt(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["idreceberparcelas"].Value.ToString());
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = EmcResources.cInt(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["nroparcela"].Value.ToString());
            PagarDocumento oPagardoc = new PagarDocumento();
            oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdReceberDocumento.Text);
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = EmcResources.cDate(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["datavencimento"].Value.ToString());
            //if (String.IsNullOrEmpty(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gPagarParcela.dataQuitacao = EmcResources.cDate(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

            gPagarParcela.valorParcela = Convert.ToDecimal(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["valorparcela"].Value.ToString());
            gPagarParcela.valorDesconto = Convert.ToDecimal(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["valordesconto"].Value.ToString());
            gPagarParcela.valorJuros = Convert.ToDecimal(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["valorjuros"].Value.ToString());
            gPagarParcela.saldoPagar = Convert.ToDecimal(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["saldopagar"].Value.ToString());
            gPagarParcela.saldoPago = Convert.ToDecimal(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["saldopago"].Value.ToString());
            gPagarParcela.situacao = grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString();
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = EmcResources.cInt(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["idtipocobranca"].Value.ToString());
            gPagarParcela.tipoCobranca = oCobr;
            gPagarParcela.nossoNumero = grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["nossonumero"].Value.ToString();
            Formulario oForm = new Formulario();
            oForm.idFormulario = EmcResources.cInt(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["idformulario"].Value.ToString());
            gPagarParcela.formulario = oForm;
            gPagarParcela.status = "";

        }
        private void limpaGlobalParcela()
        {
            gPagarParcela.nroLinha = -1;
            gPagarParcela.idPagarParcela = 0;
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = 0;
            PagarDocumento oPagardoc = new PagarDocumento();
            oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdReceberDocumento.Text);
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = DateTime.Now;
            //if (String.IsNullOrEmpty(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gPagarParcela.dataQuitacao = EmcResources.cDate(grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

            gPagarParcela.valorParcela = 0;
            gPagarParcela.valorDesconto = 0;
            gPagarParcela.valorJuros = 0;
            gPagarParcela.saldoPagar = 0;
            gPagarParcela.saldoPago = 0;
            gPagarParcela.situacao = "A";
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = 1;
            gPagarParcela.tipoCobranca = oCobr;
            gPagarParcela.codigoBarras = "";
            gPagarParcela.nossoNumero = "";
            Formulario oForm = new Formulario();
            gPagarParcela.formulario = oForm;

        }
        private bool verificaSequenciaParcelas()
        {
            bool bErro = false;
            try
            {

                int contaParcela = 1;
                List<Int32> lstParcela = new List<Int32>();
                foreach (DataGridViewRow row in grdReceberParcelas.Rows)
                {
                    lstParcela.Add(EmcResources.cInt(row.Cells["NroParcela"].Value.ToString()));
                }

                lstParcela.Sort();

                foreach (Int32 nroParcela in lstParcela)
                {
                    if (nroParcela != contaParcela)
                    {
                        bErro = true;
                    }
                    contaParcela++;

                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC");
            }
            return bErro;
        }
        public void gravaAltParcela()
        {
            if (gPagarParcela.nroLinha > -1)
            {
                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["nossonumero"].Value = gPagarParcela.nossoNumero;

                TipoCobranca oCobr = new TipoCobranca();
                TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                oCobr = oCobrRN.ObterPor(gPagarParcela.tipoCobranca);
                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["idtipocobranca"].Value = oCobr.idTipoCobranca.ToString();
                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["tipocobranca"].Value = oCobr.descricao;

                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["valorparcela"].Value = Convert.ToDecimal(gPagarParcela.valorParcela.ToString());
                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["saldopagar"].Value = Convert.ToDecimal(gPagarParcela.valorParcela.ToString()) - Convert.ToDecimal(gPagarParcela.saldoPago.ToString());
                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["datavencimento"].Value = EmcResources.cDate(gPagarParcela.dataVencimento.ToString());
                grdReceberParcelas.Rows[gPagarParcela.nroLinha].Cells["status"].Value = EmcResources.cStr(gPagarParcela.status.ToString());
            }
            else
            {
                bool bErro = false;
                foreach (DataGridViewRow row in grdReceberParcelas.Rows)
                {
                    if (EmcResources.cInt(row.Cells["NroParcela"].Value.ToString()) == gPagarParcela.nroParcela)
                    {
                        bErro = true;
                    }
                }

                if (bErro)
                {
                    MessageBox.Show("Nova parcela nro " + gPagarParcela.nroParcela + " cancelada, Parcela já existe", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    grdReceberParcelas.Rows.Add("I", gPagarParcela.nroParcela.ToString(), Convert.ToDateTime(gPagarParcela.dataVencimento.ToString()),
                                              "", Convert.ToDecimal(gPagarParcela.valorParcela.ToString()), 0, 0, 0, Convert.ToDecimal(gPagarParcela.saldoPagar.ToString()),
                                              "A", gPagarParcela.nossoNumero, gPagarParcela.codigoBarras,
                                              gPagarParcela.tipoCobranca.descricao, gPagarParcela.tipoCobranca.idTipoCobranca.ToString(),
                                              "", 0);
                }
                
            }
            atualizaSomaGrid();
        }

        #endregion 

        private void btnRateio_Click(object sender, EventArgs e)
        {
            try
            {

                /* se o documento estiver quitado permite a alteração da classificação se as baixas forem posteriores ao fechamento contabil */
                ReceberBaixaRN oPgReceberRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                /*se retornar true existem baixa anteriores ao fechamento contabil */
                Boolean contabil = oPgReceberRN.verificaBaixaDtaContabil(EmcResources.cInt(txtIdReceberDocumento.Text));

                if (true)
                {


                    rateioReceber.lstReceberBaseRateio = lstRateio;

                    frmReceberBaseRateio ofrm = new frmReceberBaseRateio(usuario,
                                                             login,
                                                             codempresa.ToString(),
                                                             empMaster.ToString(),
                                                             Conexao,
                                                             objOcorrencia,
                                                             EmcResources.cInt(txtIdReceberDocumento.Text),
                                                             EmcResources.cCur(txtValorDocumento.Value.ToString()));
                    ofrm.ShowDialog();

                    lstRateio = rateioReceber.lstReceberBaseRateio;

                    if (lstRateio == null)
                    {
                        Exception oLstNull = new Exception("Não foi informada a base de rateio do documento.");
                        throw oLstNull;
                    }
                    /* verifica se houve alteracao na base de rateio */
                    Boolean alteracao = false;
                    foreach(ReceberBaseRateio oRat in lstRateio)
                    {
                        if (oRat.status =="E" || oRat.status=="A" || oRat.status=="I")
                        {
                            alteracao = true;
                        }
                    }

                    /* Verifica se existem pagamentos anteriores ao processamento contabil */
                    if (txtSituacao.Text == "P" && !contabil && alteracao)
                    {
                        if (MessageBox.Show("Atualiza Base de Rateio ?", "Atualização", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ReceberDocumento oReceberDocumento = new ReceberDocumento();
                            ReceberDocumentoRN oReceberDocumentoRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);

                            oReceberDocumento = montaReceberDocumento();
                            oReceberDocumento.idReceberDocumento = EmcResources.cInt(txtIdReceberDocumento.Text);

                            oReceberDocumentoRN.atualizarBaseRateio(oReceberDocumento);

                            MessageBox.Show("Base Rateio Atualizada", "Aviso");
                            
                        }
                        else
                            MessageBox.Show("Atualização cancelada!", "Aviso");

                        txtNroDocumento_Validating(null, null);

                    }
                }
                else
                {
                    MessageBox.Show("Não é permitida a alteração da classificação de custos, pois existem baixas anteriores ao fechamento contabil.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboPeriodicidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodicidade.Text == "Parcela Unica")
            {
                txtNroParcelas.Text = "1";
                txtDiaFixo.Text = "";
                txtNroParcelas.Enabled = false;
                txtDiaFixo.Enabled = false;
                txtVencimento.Enabled = true;
            }
            else
            {
                txtNroParcelas.Enabled = true;
                txtDiaFixo.Enabled = true;
                txtVencimento.Enabled = false;
            }
        }

        private void txtCNPJCPF_Enter(object sender, EventArgs e)
        {
            txtCNPJCPF.Mask = "";
            lblCNPJ.Text = "CNPJ/CPF";
            txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdCliente.Text = "";
                else
                    txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdCliente_Validating(null, null);
                txtNroDocumento.Focus();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txtSdoVencimentoUP30dias_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
