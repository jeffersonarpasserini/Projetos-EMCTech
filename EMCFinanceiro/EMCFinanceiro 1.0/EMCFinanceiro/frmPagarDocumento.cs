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
using EMCCadastro;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;

namespace EMCFinanceiro
{
    public partial class frmPagarDocumento : EMCLibrary.EMCForm
    {

        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmPagarDocumento";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        List<PagarBaseRateio> lstRateio = new List<PagarBaseRateio>();
        DataTable dtParcelas = new DataTable();
        Boolean travaDataEntrada = false;
        DateTime dataContabilidade = DateTime.Now;
        Boolean travaContabil = false;
        int idMoedaCorrente = 0;
        Boolean utilizaIndexador = false;

        
#region [Metodos para configuração do formulário]
        public frmPagarDocumento(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmPagarDocumento()
        {
            InitializeComponent();
        }

        private void frmPagarDocumento_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "pagardocumento";

            lblSituacao.Text = "";

            btnRateio.Enabled = false;

            //Periodicidade
            cboPeriodicidade.Items.Add("Parcela Unica");
            cboPeriodicidade.Items.Add("Quinzenal");
            cboPeriodicidade.Items.Add("Mensal");
            cboPeriodicidade.Items.Add("Bimestral");
            cboPeriodicidade.Items.Add("Semestral");
            cboPeriodicidade.Items.Add("Anual");

            cboPeriodicidade.SelectedIndex = 0;

            CancelaOperacao();

            this.ActiveControl = txtCNPJCPF;

        }

#endregion

#region [Tratamento de Texts, combos ]
        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCNPJCPF.Text))
                {
                    txtIdFornecedor.ReadOnly = false;
                    txtIdFornecedor.Focus();
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
                        FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                        Fornecedor oFornecedor = new Fornecedor();

                        oFornecedor = oFornecedorRN.ObterPor(empMaster, txtCNPJCPF.Text.Trim());

                        if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdFornecedor.ReadOnly = false;
                            txtIdFornecedor.Focus();
                        }
                        else
                        {
                            txtIdFornecedor.Text = oFornecedor.idPessoa.ToString();
                            txtRazaoSocial.Text = oFornecedor.pessoa.nome;
                            exibeInfoCarteira();
                            txtIdFornecedor.ReadOnly = true;
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

        private void constroiCombos()
        {
            try
            {
                /* Identifica o codigo do indexador da moeda corrente no pais */
                ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
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
                    txtValorIndexado.Enabled = false;
                    txtValorIndice.Enabled = false;
                    txtDataUltimaCorrecao.Enabled = false;
                }

                TipoDocumentoRN oTipoDocRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                cboIdTipoDocumento.DataSource = oTipoDocRN.ListaTipoDocumento();
                cboIdTipoDocumento.DisplayMember = "descricao";
                cboIdTipoDocumento.ValueMember = "idtipodocumento";

                

                //verifica se o financeiro permite lancamento retroativo
                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "LANCTO_RETROATIVO") == "N")
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

        private void txtValorDocumento_Enter(object sender, EventArgs e)
        {
            if(utilizaIndexador)
            {
                txtValorDocumento.Text = EmcResources.cCur((EmcResources.cDouble(txtValorIndexado.Text) * EmcResources.cDouble(txtValorIndice.Text)).ToString()).ToString();
            }
            else
            {
                txtValorIndexado.Text = txtValorDocumento.Text;
            }
        }
        private void txtValorDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (utilizaIndexador)
            {
                txtValorIndexado.Text = Math.Round((EmcResources.cDouble(txtValorDocumento.Text) / EmcResources.cDouble(txtValorIndice.Text)), 4).ToString();
            }
            else
            {
                txtValorIndexado.Text = txtValorDocumento.Text;
            }
            atualizaSomaGrid();
        }

        //Indexador

        //fornecedor
        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdFornecedor.Text))
            {
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                Fornecedor oFornecedor = new Fornecedor();

                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtIdFornecedor.Text = oFornecedor.idPessoa.ToString();
                    txtCNPJCPF.Text = oFornecedor.pessoa.cnpjCpf;
                    txtRazaoSocial.Text = oFornecedor.pessoa.nome;
                    
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
            if (!String.IsNullOrEmpty(txtIdFornecedor.Text.Trim()) && txtIdFornecedor.Text != "System.Data.DataRowView")
            {
                Fornecedor oFornecedor = new Fornecedor();
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);

                Cliente oCliente = new Cliente();
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);

                //Dados Contas a receber
                ReceberParcelaRN oRcParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                txtClienteSdoDevedor.Text = oRcParcelaRN.calculaSaldoDevedor(EmcResources.cInt(txtIdFornecedor.Text)).ToString();
                txtClienteSdoAtraso.Text = oRcParcelaRN.calculaSaldoAtraso(EmcResources.cInt(txtIdFornecedor.Text)).ToString();
                txtClienteSdo30D.Text = oRcParcelaRN.calculaVencimento30Dias(EmcResources.cInt(txtIdFornecedor.Text)).ToString();
                txtClienteSdoUp30D.Text = oRcParcelaRN.calculaSdoVencimentoUp30Dias(EmcResources.cInt(txtIdFornecedor.Text)).ToString();

                //Dados Contas a pagar
                PagarParcelaRN oPgParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                txtSaldoDevedor.Text = oPgParcelaRN.calculaSaldoDevedor(EmcResources.cInt(txtIdFornecedor.Text)).ToString();
                txtSdoAtraso.Text = oPgParcelaRN.calculaSaldoAtraso(EmcResources.cInt(txtIdFornecedor.Text)).ToString();
                txtSdo30Dias.Text = oPgParcelaRN.calculaVencimento30Dias(EmcResources.cInt(txtIdFornecedor.Text)).ToString();
                txtSdoVencimentoUP30dias.Text = oPgParcelaRN.calculaSdoVencimentoUp30Dias(EmcResources.cInt(txtIdFornecedor.Text)).ToString();

                //dados adiantamentos - Fornecedor
                PagarBaixaRN oPgBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                txtFornecedorSdoAdto.Text = oPgBaixaRN.calculaSdoAdiantamento(oFornecedor).ToString();

                //dados adiantamentos - Cliente
                ReceberBaixaRN oRcBaixaRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                txtClienteSdoAdto.Text = oRcBaixaRN.calculaSdoAdiantamento(oCliente).ToString();

                
            }
        }

        private void exibeSdoDocumento()
        {
            if (!String.IsNullOrEmpty(txtIdPagarDocumento.Text.Trim()) && txtIdFornecedor.Text != "System.Data.DataRowView")
            {
                PagarParcelaRN oPgParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                txtInfVlrDocumento.Text = oPgParcelaRN.calculaDocParcela(EmcResources.cInt(txtIdPagarDocumento.Text)).ToString();
                txtInfVlrDescontos.Text = oPgParcelaRN.calculaDocDesconto(EmcResources.cInt(txtIdPagarDocumento.Text)).ToString();
                txtInfVlrJuros.Text = oPgParcelaRN.calculaDocJuros(EmcResources.cInt(txtIdPagarDocumento.Text)).ToString();
                txtInfVlrPago.Text = oPgParcelaRN.calculaDocSdoPago(EmcResources.cInt(txtIdPagarDocumento.Text)).ToString();
                txtInfVlrPagar.Text = oPgParcelaRN.calculaDocSdoPagar(EmcResources.cInt(txtIdPagarDocumento.Text)).ToString();
            }
        }

#endregion

#region [metodos para tratamento das informacoes]
        private Boolean verificaPagarDocumento(PagarDocumento oPgdoc)
        {
            PagarDocumentoRN oPagarRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);
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

                oPagarRN.VerificaDados(oPgdoc);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }

        private PagarDocumento montaPagarDocumento()
        {
            PagarDocumento oPagarDocumento = new PagarDocumento();

            oPagarDocumento.codEmpresa = codempresa;
            oPagarDocumento.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());

           
            // se for alteracao executa
            flagInclusao = false;
            if (!flagInclusao)
            {
                oPagarDocumento.cadastro_idusuario = Convert.ToInt32(usuario);
                oPagarDocumento.cadastro_datahora = DateTime.Now;

                oPagarDocumento.dataEmissao = EmcResources.cDate(txtDataEmissao.Text.ToString());
                oPagarDocumento.dataEntrada = EmcResources.cDate(txtDataEntrada.Text.ToString());
                oPagarDocumento.valorDocumento = Convert.ToDecimal(txtValorDocumento.Text);

                /* Controle de gravação dos valores indexados 
                 * Enquanto não estiver calculando vai ser igual ao valor do documento 
                 */
                oPagarDocumento.valorIndexado = EmcResources.cDouble(txtValorIndexado.Text);
                oPagarDocumento.dataUltimaCorrecao = Convert.ToDateTime(txtDataUltimaCorrecao.Text);
                oPagarDocumento.valorIndice = EmcResources.cDouble(txtValorIndice.Text);

                oPagarDocumento.nroParcelas = EmcResources.cInt(txtNroParcelas.Text);
                oPagarDocumento.situacao = "A";

                if (cboPeriodicidade.Text == "Quinzenal")
                    oPagarDocumento.periodicidade = "Q";
                else if (cboPeriodicidade.Text == "Mensal")
                    oPagarDocumento.periodicidade = "M";
                else if (cboPeriodicidade.Text == "Bimestral")
                    oPagarDocumento.periodicidade = "B";
                else if (cboPeriodicidade.Text == "Semestral")
                    oPagarDocumento.periodicidade = "S";
                else if (cboPeriodicidade.Text == "Anual")
                    oPagarDocumento.periodicidade = "A";
                else if (cboPeriodicidade.Text == "Parcela Unica")
                    oPagarDocumento.periodicidade = "P";
                else
                    oPagarDocumento.periodicidade = "M";


                oPagarDocumento.diaFixo = EmcResources.cStr(txtDiaFixo.Text);
                oPagarDocumento.origemDocumento = lblOrigemDocumento.Text.Trim();
                oPagarDocumento.descricao = EmcResources.cStr(txtDescricao.Text);

                TipoDocumento oTipo = new TipoDocumento();
                TipoDocumentoRN oTipoRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                oTipo.idTipoDocumento = Convert.ToInt32(cboIdTipoDocumento.SelectedValue);
                oTipo = oTipoRN.ObterPor(oTipo);
                oPagarDocumento.tipoDocumento = oTipo;

                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
                oIndexador.idIndexador = Convert.ToInt32(cboIdIndexador.SelectedValue);
                oIndexador = oIndexadorRN.ObterPor(oIndexador);
                oPagarDocumento.indexador = oIndexador;


                Fornecedor oFornecedor = new Fornecedor();
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);

                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                oPagarDocumento.fornecedor = oFornecedor;

                //atribui rateios ao documento a pagar
                oPagarDocumento.baseRateio = lstRateio;

                List<PagarParcela> lstParcelas = new List<PagarParcela>();
                PagarParcela oParcela;
                PagarDocumento oDoc = new PagarDocumento();

                oDoc.idPagarDocumento = EmcResources.cInt(txtIdPagarDocumento.Text);


                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdPagarParcelas.Rows)
                {

                    oParcela = new PagarParcela();


                    oParcela.cadastro_idusuario = Convert.ToInt32(usuario);
                    oParcela.cadastro_datahora = DateTime.Now;
                    oParcela.codEmpresa = codempresa;
                    oParcela.codigoBarras = dataGridViewRow.Cells["codigobarras"].Value.ToString();
                    oParcela.dataVencimento = EmcResources.cDate(dataGridViewRow.Cells["datavencimento"].Value.ToString());
                    oParcela.idPagarParcela = EmcResources.cInt(dataGridViewRow.Cells["idpagarparcelas"].Value.ToString());
                    oParcela.nossoNumero = dataGridViewRow.Cells["nossonumero"].Value.ToString();
                    oParcela.nroParcela = EmcResources.cInt(dataGridViewRow.Cells["nroparcela"].Value.ToString());
                    oParcela.pagarDocumento = oDoc;
                    oParcela.saldoPagar = Convert.ToDecimal(dataGridViewRow.Cells["saldopagar"].Value.ToString());
                    oParcela.saldoPago = Convert.ToDecimal(dataGridViewRow.Cells["saldopago"].Value.ToString());
                    oParcela.situacao = dataGridViewRow.Cells["situacao"].Value.ToString();
                    oParcela.valorDesconto = Convert.ToDecimal(dataGridViewRow.Cells["valordesconto"].Value.ToString());
                    oParcela.valorCMPago = EmcResources.cCur(dataGridViewRow.Cells["valorcmpago"].Value.ToString());
                    oParcela.valorCorrecaoMonetaria = EmcResources.cCur(dataGridViewRow.Cells["valorcorrecaomonetaria"].Value.ToString());
                    oParcela.valorJuros = Convert.ToDecimal(dataGridViewRow.Cells["valorjuros"].Value.ToString());
                    oParcela.valorParcela = Convert.ToDecimal(dataGridViewRow.Cells["valorparcela"].Value.ToString());
                    oParcela.status = dataGridViewRow.Cells["status"].Value.ToString();
                    oParcela.valorIndexado = EmcResources.cDouble(dataGridViewRow.Cells["valorindexado"].Value.ToString());
                    oParcela.dataUltimaCorrecao = Convert.ToDateTime(dataGridViewRow.Cells["dataultimacorrecao"].Value.ToString());

                    TipoCobranca oCobr = new TipoCobranca();
                    TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                    oCobr.idTipoCobranca = EmcResources.cInt(dataGridViewRow.Cells["idtipocobranca"].Value.ToString());
                    oCobr = oCobrRN.ObterPor(oCobr);
                    oParcela.tipoCobranca = oCobr;

                    List<PagarBaixa> lstBaixa = new List<PagarBaixa>();

                    if (oParcela.idPagarParcela > 0)
                    {
                        PagarBaixaRN oBxRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                        lstBaixa = oBxRN.listaBaixasParcela(oParcela.idPagarParcela);
                    }

                    oParcela.baixas = lstBaixa;

                    oParcela.pagarDocumento = oPagarDocumento;

                    lstParcelas.Add(oParcela);
                }


                oPagarDocumento.parcelas = lstParcelas;
            }

            return oPagarDocumento;
        }

        private void montaTela(PagarDocumento oPagarDocumento)
        {
            lblOrigemDocumento.Text = oPagarDocumento.origemDocumento;

            txtIdPagarDocumento.Text = oPagarDocumento.idPagarDocumento.ToString();
            txtNroDocumento.Text = oPagarDocumento.nroDocumento;
            txtDataEmissao.Text = oPagarDocumento.dataEmissao.ToString();
            txtDataEntrada.Text = oPagarDocumento.dataEntrada.ToString();
            cboIdTipoDocumento.SelectedValue = oPagarDocumento.tipoDocumento.idTipoDocumento.ToString();

            txtIdFornecedor.Text = oPagarDocumento.fornecedor.idPessoa.ToString();
            txtIdFornecedor_Validating(null, null);
           
            cboIdIndexador.SelectedValue = oPagarDocumento.indexador.idIndexador.ToString();

            //carrega rateios
            lstRateio = oPagarDocumento.baseRateio;

            
            txtDescricao.Text = oPagarDocumento.descricao.ToString();
            if (oPagarDocumento.periodicidade == "Q")
                cboPeriodicidade.Text = "Quinzenal";
            else if (oPagarDocumento.periodicidade == "M")
                cboPeriodicidade.Text = "Mensal";
            else if (oPagarDocumento.periodicidade == "B")
                cboPeriodicidade.Text = "Bimestral";
            else if (oPagarDocumento.periodicidade == "S")
                cboPeriodicidade.Text = "Semestral";
            else if (oPagarDocumento.periodicidade == "A")
                cboPeriodicidade.Text = "Anual";
            else if (oPagarDocumento.periodicidade == "P")
                cboPeriodicidade.Text = "Parcela Unica";

            txtDiaFixo.Text = oPagarDocumento.diaFixo.ToString();
            txtValorDocumento.Text = oPagarDocumento.valorDocumento.ToString();

             
            txtValorIndexado.Text = oPagarDocumento.valorIndexado.ToString();
            txtDataUltimaCorrecao.Text = oPagarDocumento.dataUltimaCorrecao.ToString();
            txtValorIndice.Text = oPagarDocumento.valorIndice.ToString();
            
              
            txtNroParcelas.Text = oPagarDocumento.nroParcelas.ToString();

            
            AtualizaGrid(oPagarDocumento);
            exibeInfoCarteira();

            exibeSdoDocumento();

            atualizaSomaGrid();
            btnExcluiParcela.Enabled = true;
            btnIncluiParcela.Enabled = true;

            txtSituacao.Text = oPagarDocumento.situacao;

            if (oPagarDocumento.situacao == "P")
            {
                lblSituacao.Text = "Documento Quitado";
            }
            else
            {
                lblSituacao.Text = "";
            }

            objOcorrencia.chaveidentificacao = oPagarDocumento.idPagarDocumento.ToString();
            btnRateio.Enabled = true;
            


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
            txtIdFornecedor.Enabled = false;
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            btnGeraParcelas.Enabled = true;
            btnRateio.Enabled = true;
            txtNroDocumento.Enabled = true;
            txtCNPJCPF.Enabled = true;
            txtIdFornecedor.Enabled = true;
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            lblSituacao.Text = "";
            lstRateio = null;
            objOcorrencia.chaveidentificacao = "";
            btnRateio.Enabled = false;
            constroiCombos();

            txtNroDocumento.Enabled = true;
            txtCNPJCPF.Enabled = true;
            txtIdFornecedor.Enabled = true;

            txtCNPJCPF.Focus();
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            txtIdPagarDocumento.Text = "";
            psqContasPagar oPsq = new psqContasPagar(usuario, 
                                                         login, 
                                                         codempresa.ToString(), 
                                                         empMaster.ToString(), 
                                                         Conexao, 
                                                         objOcorrencia);
            oPsq.ShowDialog();

            oPsq.Dispose();

            txtNroDocumento.Text = retPesquisa.chavebusca;
            if (EmcResources.cInt(retPesquisa.chaveinterna.ToString()) >0)
                txtIdPagarDocumento.Text = retPesquisa.chaveinterna.ToString();

            if (!String.IsNullOrEmpty(txtNroDocumento.Text) || !String.IsNullOrEmpty(txtIdPagarDocumento.Text))
            {
                pesquisaDocumento();
            }
            
            
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            lblOrigemDocumento.Text = "CTAPAGAR";
            txtCNPJCPF.Focus();
            flagInclusao = true;
            txtCNPJCPF.Text = "";
            txtRazaoSocial.Text = "";
            txtNroDocumento.Text = "";
            txtIdFornecedor.Text = "";
            grdPagarParcelas.Rows.Clear();
            grdPagarBaixa.Rows.Clear();
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
            txtValorIndice.Text = "0";
            txtValorIndexado.Text="0";
            objOcorrencia.chaveidentificacao = "";

            constroiCombos();

            cboPeriodicidade.SelectedIndex = 0;

        }

        public override void SalvaObjeto()
        {
            
            try
            {
                if (EmcResources.cCur(txtValorDocumento.Text) != EmcResources.cCur(txtSomaParcelas.Text))
                {
                    MessageBox.Show("Valor do documento não fecha com as parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSituacao.Text == "P")
                {

                }
                else if (verificaSequenciaParcelas())
                {
                    MessageBox.Show("Verifique a sequencia das parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PagarDocumento oPagarDocumento = new PagarDocumento();
                    PagarDocumentoRN oPagarDocumentoRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);

                    oPagarDocumento = montaPagarDocumento();


                    if (verificaPagarDocumento(oPagarDocumento))
                    {
                        oPagarDocumentoRN.Salvar(oPagarDocumento);
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
                if (EmcResources.cCur(txtValorDocumento.Text) != EmcResources.cCur(txtSomaParcelas.Text))
                {
                    MessageBox.Show("Valor do documento não fecha com as parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSituacao.Text == "P")
                {
                    MessageBox.Show("Documento está quitado, alteração não permitida", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (verificaSequenciaParcelas())
                {
                    MessageBox.Show("Verifique a sequencia das parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    PagarDocumento oPagarDocumento = new PagarDocumento();
                    PagarDocumentoRN oPagarDocumentoRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);

                    oPagarDocumento = montaPagarDocumento();
                    oPagarDocumento.idPagarDocumento = Convert.ToInt32(txtIdPagarDocumento.Text);

                    if (verificaPagarDocumento(oPagarDocumento))
                    {
                        oPagarDocumentoRN.Atualizar(oPagarDocumento);

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
                PagarDocumento oPagarDocumento = new PagarDocumento();
                PagarDocumentoRN oPagarDocumentoRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);
                oPagarDocumento = montaPagarDocumento();
                oPagarDocumento.idPagarDocumento = Convert.ToInt32(txtIdPagarDocumento.Text);

                if (txtSituacao.Text == "P")
                {
                    MessageBox.Show("Documento está quitado, alteração não permitida", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (verificaPagarDocumento(oPagarDocumento))
                {
                    oPagarDocumentoRN.Excluir(oPagarDocumento);

                    CancelaOperacao();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void pesquisaDocumento()
        {
            
            try
            {
                PagarDocumento oPagarDocumento = new PagarDocumento();

                if (!String.IsNullOrEmpty(txtNroDocumento.Text) && !String.IsNullOrEmpty(txtIdFornecedor.Text))
                {
                    Fornecedor oForn = new Fornecedor();
                    oForn.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                    oForn.codEmpresa = empMaster;

                    oPagarDocumento.codEmpresa = codempresa;
                    oPagarDocumento.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());
                    oPagarDocumento.fornecedor = oForn;
                }
                else if (!String.IsNullOrEmpty(txtIdPagarDocumento.Text))
                {
                    oPagarDocumento.idPagarDocumento = EmcResources.cInt(txtIdPagarDocumento.Text);
                    oPagarDocumento.codEmpresa = codempresa;
                }

                if ((!String.IsNullOrEmpty(txtNroDocumento.Text) && !String.IsNullOrEmpty(txtIdFornecedor.Text)) || (!String.IsNullOrEmpty(txtIdPagarDocumento.Text)))
                {
                    PagarDocumentoRN oPagarDocumentoRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);
                    oPagarDocumento = oPagarDocumentoRN.ObterPor(oPagarDocumento);

                    if (!String.IsNullOrEmpty(oPagarDocumento.descricao))
                    {
                        montaTela(oPagarDocumento);
                        AtualizaGrid(oPagarDocumento);
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
        
        public void AtualizaGrid(PagarDocumento oPagarDocumento)
        {
            
            //foreach (DataRow row in dtPAgamento)

            //adquiri lista de parcelas do objeto documento
            List<PagarParcela> lstPagarParcela = oPagarDocumento.parcelas;

            grdPagarParcelas.Rows.Clear();
            Decimal somaParcelas = 0;

            foreach (PagarParcela oParcela in lstPagarParcela)
            {
                grdPagarParcelas.Rows.Add("", oParcela.nroParcela,oParcela.dataVencimento, oParcela.dataQuitacao, oParcela.valorParcela, 
                                          oParcela.saldoPago, oParcela.valorDesconto, oParcela.valorJuros, oParcela.saldoPagar, 
                                          oParcela.situacao, oParcela.nossoNumero, oParcela.codigoBarras, oParcela.idPagarParcela, 
                                          oParcela.tipoCobranca.descricao, oParcela.tipoCobranca.idTipoCobranca,oParcela.valorIndexado,
                                          oParcela.valorCMPago, oParcela.valorCorrecaoMonetaria, oParcela.dataUltimaCorrecao);
                somaParcelas = somaParcelas + oParcela.valorParcela;
            }
            
            txtSomaParcelas.Text = somaParcelas.ToString();

            grdPagarParcelas.ScrollBars = ScrollBars.Both;

        }
        public void atualizaSomaGrid()
        {
              Decimal somaParcelas = 0;
              Double somaValorIndexado = 0;
              foreach (DataGridViewRow row in grdPagarParcelas.Rows)
              {
                  if (row.Cells["status"].Value.ToString() != "E")
                  {
                      somaParcelas = somaParcelas + Convert.ToDecimal(row.Cells["valorparcela"].Value.ToString());
                      somaValorIndexado = somaValorIndexado + EmcResources.cDouble(row.Cells["valorindexado"].Value.ToString());
                  }
              }
              txtSomaParcelas.Text = somaParcelas.ToString();

              if (somaParcelas != Convert.ToDecimal(txtValorDocumento.Text))
              {
                  txtSomaParcelas.BackColor = Color.Red;
              }
              else
                  txtSomaParcelas.BackColor = Color.Yellow;
        }
        private void grdPagarParcelas_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmcResources.cInt(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["idpagarparcelas"].Value.ToString()) > 0)
                {
                    PagarBaixaRN oPagarBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                    List<PagarBaixa> lstPagarParcela = new List<PagarBaixa>();

                    lstPagarParcela = oPagarBaixaRN.listaBaixasParcela(EmcResources.cInt(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["idpagarparcelas"].Value.ToString()));

                    grdPagarBaixa.Rows.Clear();

                    foreach (PagarBaixa oPagarBaixa in lstPagarParcela)
                    {
                        grdPagarBaixa.Rows.Add(oPagarBaixa.documentoBaixa, oPagarBaixa.situacaoBaixa, oPagarBaixa.valorBaixa, oPagarBaixa.valorJuros, oPagarBaixa.valorDesconto, oPagarBaixa.contaCorrente.Banco.descricao, oPagarBaixa.contaCorrente.descricao, oPagarBaixa.nominal, oPagarBaixa.formaPagamento.descricao, oPagarBaixa.historico, oPagarBaixa.idPagarBaixa);
                    }
                    grdPagarBaixa.ScrollBars = ScrollBars.Both;
                }
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
            if (Convert.ToDecimal(txtValorDocumento.Text) == 0 || EmcResources.cDouble(txtValorIndexado.Text) == 0)
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
            grdPagarParcelas.Rows.Clear();
            Double valorIndice = EmcResources.cDouble(txtValorIndice.Text);

            //Atribui valores
            Decimal valorDocumento = EmcResources.cCur(txtValorDocumento.Text);
            Double valorIndexado = EmcResources.cDouble(txtValorIndexado.Text);
            int nroParcelas = Convert.ToInt32(txtNroParcelas.Text);
          
            //Calcula parcela e diferencas
            //Utilizado o valor indexado para o calculo das parcelas
            Double vlrParcelaIndexada = Math.Round((valorIndexado / nroParcelas),4);
            Double vlrDiferencaIndexada = Math.Round(valorIndexado - (vlrParcelaIndexada * nroParcelas),4);

            //Decimal vlrParcela = Decimal.Round((valorDocumento/nroParcelas),2)
            //Decimal vlrDiferenca = valorDocumento-(vlrParcela*nroParcelas);
            Decimal vlrParcela =  EmcResources.cCur(Math.Round((vlrParcelaIndexada * valorIndice),2).ToString());
            Decimal vlrDiferenca = Math.Round(valorDocumento - (vlrParcela * nroParcelas),2);
            
            //Geração de Parcelas
            int xParc = 1;
            DateTime xDataVenc = Convert.ToDateTime(txtDataEmissao.Text);

            while (xParc <= nroParcelas)
            {
                //ser for a ultima parcela joga a diferença
                if (xParc == nroParcelas)
                {
                    vlrParcela = (vlrParcela + vlrDiferenca);
                    vlrParcelaIndexada = (vlrParcelaIndexada + vlrDiferencaIndexada);
                }
                    

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
                    xDataVenc = Convert.ToDateTime(txtVencimento.Text);

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
                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "VENCIMENTO_DIA_UTIL") == "S")
                {
                    // colocar if de acordo com parametro
                    FeriadoRN oFeriadoRN = new FeriadoRN(Conexao, objOcorrencia, codempresa);
                    dataGravar = oFeriadoRN.diaUtil(dataGravar);
                }

                TipoCobrancaRN oTpCobRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                TipoCobranca otpCob = new TipoCobranca();
                otpCob.idTipoCobranca = EmcResources.cInt(cboTipoCobranca.SelectedValue.ToString());
                otpCob = oTpCobRN.ObterPor(otpCob);

                grdPagarParcelas.Rows.Add("", xParc, dataGravar, "", vlrParcela, 0, 0, 0, vlrParcela,"A", "", "", "", otpCob.descricao, otpCob.idTipoCobranca.ToString(),vlrParcelaIndexada.ToString(),0,0,txtDataUltimaCorrecao.Text);

                xParc++;
            }

            atualizaSomaGrid();
        }

#endregion 

#region [metodos para gerir alteracoes no parcelamento]
        private void btnExcluiParcela_Click(object sender, EventArgs e)
        {
            if (grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["status"].Value.ToString() == "E")
                    grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["status"].Value = "";
                else
                    grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["status"].Value = "E";

                atualizaSomaGrid();
            }
        }
        private void btnIncluiParcela_Click(object sender, EventArgs e)
        {
            limpaGlobalParcela();
            frmEditaParcelas ofrm = new frmEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(),Conexao,objOcorrencia);
            ofrm.ShowDialog();
            if (gPagarParcela.nroParcela > 0)
                gravaAltParcela();
        }
        private void btnAlteraParcelas_Click(object sender, EventArgs e)
        {
            if (grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                montaGlobalParcela();
                frmEditaParcelas ofrm = new frmEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();
                gravaAltParcela();
            }

        }
        private void grdPagarParcelas_DoubleClick(object sender, EventArgs e)
        {
            if (grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                montaGlobalParcela();
                frmEditaParcelas ofrm = new frmEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(),Conexao,objOcorrencia);
                ofrm.ShowDialog();
                gravaAltParcela();
            }
        }
        private void montaGlobalParcela()
        {
            gPagarParcela.nroLinha = grdPagarParcelas.CurrentRow.Index;
            gPagarParcela.idPagarParcela = EmcResources.cInt(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["idpagarparcelas"].Value.ToString());
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = EmcResources.cInt(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["nroparcela"].Value.ToString());
            PagarDocumento oPagardoc = new PagarDocumento();
            oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdPagarDocumento.Text);
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = EmcResources.cDate(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["datavencimento"].Value.ToString());
            //if (String.IsNullOrEmpty(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gPagarParcela.dataQuitacao = EmcResources.cDate(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());
            
            gPagarParcela.valorParcela = Convert.ToDecimal(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["valorparcela"].Value.ToString());
            gPagarParcela.valorDesconto = Convert.ToDecimal(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["valordesconto"].Value.ToString());
            gPagarParcela.valorJuros = Convert.ToDecimal(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["valorjuros"].Value.ToString());
            gPagarParcela.saldoPagar = Convert.ToDecimal(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["saldopagar"].Value.ToString());
            gPagarParcela.saldoPago = Convert.ToDecimal(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["saldopago"].Value.ToString());
            gPagarParcela.situacao = grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["situacao"].Value.ToString();
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = EmcResources.cInt(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["idtipocobranca"].Value.ToString());
            gPagarParcela.tipoCobranca = oCobr;
            gPagarParcela.codigoBarras = grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["codigobarras"].Value.ToString();
            gPagarParcela.nossoNumero = grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["nossonumero"].Value.ToString();
            gPagarParcela.status = "";

        }
        private void limpaGlobalParcela()
        {
            gPagarParcela.nroLinha = -1;
            gPagarParcela.idPagarParcela = 0;
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = 0;
            PagarDocumento oPagardoc = new PagarDocumento();
            oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdPagarDocumento.Text);
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = DateTime.Now;
            //if (String.IsNullOrEmpty(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gPagarParcela.dataQuitacao = EmcResources.cDate(grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

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

        }

        private bool verificaSequenciaParcelas()
        {
            bool bErro = false;
            try
            {
               
                int contaParcela = 1;
                List<Int32> lstParcela = new List<Int32>();
                foreach (DataGridViewRow row in grdPagarParcelas.Rows)
                {
                    lstParcela.Add(EmcResources.cInt(row.Cells["NroParcela"].Value.ToString()));
                }

                lstParcela.Sort();

                foreach(Int32 nroParcela in lstParcela)
                {
                    if(nroParcela != contaParcela)
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
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["codigobarras"].Value = gPagarParcela.codigoBarras;
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["nossonumero"].Value = gPagarParcela.nossoNumero;

                TipoCobranca oCobr = new TipoCobranca();
                TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                oCobr = oCobrRN.ObterPor(gPagarParcela.tipoCobranca);
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["idtipocobranca"].Value = oCobr.idTipoCobranca.ToString();
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["tipocobranca"].Value = oCobr.descricao;

                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["valorparcela"].Value = Convert.ToDecimal(gPagarParcela.valorParcela.ToString());
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["saldopagar"].Value = Convert.ToDecimal(gPagarParcela.valorParcela.ToString()) - Convert.ToDecimal(gPagarParcela.saldoPago.ToString());
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["datavencimento"].Value = EmcResources.cDate(gPagarParcela.dataVencimento.ToString());
                grdPagarParcelas.Rows[gPagarParcela.nroLinha].Cells["status"].Value =  EmcResources.cStr(gPagarParcela.status.ToString());
            }
            else
            {

                bool bErro = false;
                foreach (DataGridViewRow row in grdPagarParcelas.Rows)
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

                    grdPagarParcelas.Rows.Add("I", gPagarParcela.nroParcela.ToString(), Convert.ToDateTime(gPagarParcela.dataVencimento.ToString()),
                                              "", Convert.ToDecimal(gPagarParcela.valorParcela.ToString()), 0, 0, 0, Convert.ToDecimal(gPagarParcela.saldoPagar.ToString()),
                                              "A", gPagarParcela.nossoNumero, gPagarParcela.codigoBarras, "",
                                              gPagarParcela.tipoCobranca.descricao, gPagarParcela.tipoCobranca.idTipoCobranca.ToString());
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
                PagarBaixaRN oPgBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                /*se retornar true existem baixa anteriores ao fechamento contabil */
                Boolean contabil = oPgBaixaRN.verificaBaixaDtaContabil(EmcResources.cInt(txtIdPagarDocumento.Text));

                if (true)
                {

                    rateioPagar.lstPagarBaseRateio = lstRateio;

                    frmPagarBaseRateio ofrm = new frmPagarBaseRateio(usuario,
                                                                login,
                                                                codempresa.ToString(),
                                                                empMaster.ToString(),
                                                                Conexao,
                                                                objOcorrencia,
                                                                EmcResources.cInt(txtIdPagarDocumento.Text),
                                                                EmcResources.cCur(txtValorDocumento.Text));
                    ofrm.ShowDialog();

                    lstRateio = rateioPagar.lstPagarBaseRateio;

                    if (lstRateio == null)
                    {
                        Exception oLstNull = new Exception("Não foi informada a base de rateio do documento.");
                        throw oLstNull;
                    }

                    /* verifica se houve alteracao na base de rateio */
                    Boolean alteracao = false;
                    foreach (PagarBaseRateio oRat in lstRateio)
                    {
                        if (oRat.status == "E" || oRat.status == "A" || oRat.status == "I")
                        {
                            alteracao = true;
                        }
                    }

                    /* Verifica se existem pagamentos anteriores ao processamento contabil */
                    if (txtSituacao.Text == "P" && !contabil && alteracao)
                    {
                        if (MessageBox.Show("Atualiza Base de Rateio ?", "Atualização", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            PagarDocumento oPagarDocumento = new PagarDocumento();
                            PagarDocumentoRN oPagarDocumentoRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);

                            oPagarDocumento = montaPagarDocumento();
                            oPagarDocumento.idPagarDocumento = Convert.ToInt32(txtIdPagarDocumento.Text);

                            oPagarDocumentoRN.atualizarBaseRateio(oPagarDocumento);

                            MessageBox.Show("Base Rateio Atualizada", "Aviso");
                        }
                        else
                            MessageBox.Show("Atualização cancelada!", "Aviso");

                        txtNroDocumento_Validating(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Não é permitida a alteração da classificação de custos, pois existem baixas anteriores ao fechamento contabil.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdFornecedor.Text = "";
                else
                    txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdFornecedor.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCNPJCPF_Enter(object sender, EventArgs e)
        {
            txtCNPJCPF.Mask = "";
            lblCNPJ.Text = "CNPJ/CPF";
            txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboIdIndexador_Validating(object sender, CancelEventArgs e)
        {
            if (utilizaIndexador)
            {
                if (EmcResources.cInt(cboIdIndexador.SelectedValue.ToString()) != idMoedaCorrente)
                {
                    //buscar o valor do indice escolhido

                    IndicesRN oIndRN = new IndicesRN(Conexao, objOcorrencia, codempresa);
                    Indices oIndice = new Indices();

                    oIndice = oIndRN.ObterPor(EmcResources.cInt(cboIdIndexador.SelectedValue.ToString()), Convert.ToDateTime(txtDataEntrada.Text), false);

                    if (oIndice.idIndice <= 0)
                    {
                        oIndice = oIndRN.ObterPor(EmcResources.cInt(cboIdIndexador.SelectedValue.ToString()), Convert.ToDateTime(txtDataEntrada.Text), true);
                        if (oIndice.idIndice > 0 && !Convert.ToDateTime(txtDataEntrada.Text).Equals(Convert.ToDateTime(oIndice.dataIndice.ToString())))
                        {
                            MessageBox.Show("Não foi encontrado um indice para a data do lancamento, verifique!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtValorIndice.Text = oIndice.valor.ToString();
                            txtDataUltimaCorrecao.Text = oIndice.dataIndice.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Não foram encontrados indices para este indexaor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtValorIndice.Text = "1";
                            txtDataUltimaCorrecao.Text = DateTime.Now.ToString();
                        }

                    }
                    else
                    {
                        txtValorIndice.Text = oIndice.valor.ToString();
                        txtDataUltimaCorrecao.Text = oIndice.dataIndice.ToString();
                    }

                }
                else
                {
                    txtValorIndice.Text = "1";
                    txtDataUltimaCorrecao.Text = DateTime.Now.ToString();
                }
                    
                txtValorIndexado.Focus();
            }
            else
            {
                txtValorIndice.Text = "1";
                txtValorDocumento.Focus();
            }
           
        }

        private void txtDataEntrada_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (travaContabil)
                {
                    if (Convert.ToDateTime(txtDataEntrada.Text) <= dataContabilidade)
                    {
                        MessageBox.Show("Data Entrada do Lançamento anterior ao fechamento contábil!");
                    }
                }
                
            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtSaldoDevedor_TextChanged(object sender, EventArgs e)
        {

        }

        

        

       
        
     
    }
}
