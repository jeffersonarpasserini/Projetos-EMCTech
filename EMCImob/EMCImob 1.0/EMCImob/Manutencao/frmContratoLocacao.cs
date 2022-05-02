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
using EMCCadastro;
using EMCCadastroRN;
using EMCCadastroModel;
using System.Collections;
using EMCSecurityRN;


namespace EMCImob
{
    public partial class frmContratoLocacao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmContratoLocacao";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();


        public int alug_Locador = 0;
        public int alug_locatario = 0;
        public int cond_locatario = 0;
        public int idTaxa_adm = 0;
        public int desc_Conc_Locador = 0;
        public int desc_Conc_Locatario = 0;
        public int base_Dimob = 0;
        public int juros_Recebidos = 0;
        public int juros_Pagos = 0;
        public int juros_Retidos = 0;
        public int base_IR = 0;
        public int imposto_Renda = 0;

        public double taxa_Multa = 0;
        public double taxa_Juros = 0;
        public double perc_Taxa_Adm = 0;

        public string stOperacao = "C";

        #region "metodos do form"
        public frmContratoLocacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmContratoLocacao()
        {
            InitializeComponent();
        }

        private void frmContratoLocacao_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "locacaocontrato";

            
            this.ActiveControl = txtIdentificacaoContrato;
            AtivaInsercao();
        }

        #endregion

        #region "metodos para tratamento das informacoes"

        private Boolean verificaLocacaoContrato(LocacaoContrato oContrato)
        {
            LocacaoContratoRN oContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oContratoRN.VerificaDados(oContrato);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro LocacaoContrato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private LocacaoContrato montaContrato()
        {
            LocacaoContrato oContrato = new LocacaoContrato();
            try
            {
                //prepara objeto contrato para a gravação

                oContrato.idLocacaoContrato = 0;
                oContrato.identificacaoContrato = txtIdentificacaoContrato.Text;
                oContrato.contratoGarantido = cboContratoGarantido.SelectedValue.ToString();
                oContrato.data1Parcela = Convert.ToDateTime(txtData1Parcela.DateValue.ToString());
                oContrato.data1ParcelaCarencia = Convert.ToDateTime(txtData1ParcelaCarencia.DateValue.ToString());
                oContrato.dataContrato = Convert.ToDateTime(txtDataContrato.DateValue.ToString());
                oContrato.dataDesocupacao = null;
                oContrato.dataInicial = Convert.ToDateTime(txtDataInicial.DateValue.ToString());
                oContrato.dataFinal = Convert.ToDateTime(txtDataFinal.DateValue.ToString());
                oContrato.dataEntradaFinal = EmcResources.cDate(txtDtaEntradaFinal.DateValue.ToString());
                oContrato.dataEntradaInicio = EmcResources.cDate(txtDtaEntradaInicio.DateValue.ToString());
                oContrato.dataFinalDesconto = EmcResources.cDate(txtDataFinalDesconto.DateValue.ToString());
                oContrato.dataInicioDesconto = EmcResources.cDate(txtDataInicioDesconto.DateValue.ToString());
                oContrato.diaFixoLocatario = EmcResources.cInt(txtDiaFixoLocatario.Text);
                oContrato.diaFixoPagamento = txtDiaFixoPagamento.Text;
                oContrato.diasCarencia = EmcResources.cInt(txtDiasCarencia.Text);
                oContrato.diasProporcionais = EmcResources.cInt(txtDiasProporcionais.Text);
                oContrato.idEmpresa = codempresa;
                oContrato.integraCondominio = cboIntegraCondominio.SelectedValue.ToString();

                oContrato.locatarioRepresentanteParticipacao = EmcResources.cDouble(txtLocatarioParticipacao.Value.ToString());

                Imovel oImovel = new Imovel();
                ImovelRN oImovelRN = new ImovelRN(Conexao,objOcorrencia,codempresa);

                oImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
                oImovel = oImovelRN.ObterPor(oImovel);

                oContrato.imovel = oImovel;

                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorRN = new IndexadorRN(Conexao,objOcorrencia,codempresa);

                oIndexador.idIndexador = EmcResources.cInt(cboIdIndexador.SelectedValue.ToString());
                oIndexador = oIndexadorRN.ObterPor(oIndexador);

                oContrato.indexador = oIndexador;

                oContrato.locadorFormaPagamento = cboLocadorFormaPagamento.SelectedValue.ToString();
                oContrato.locadorRateio = cboLocadorRateio.SelectedValue.ToString();

                Fornecedor oForn = new Fornecedor();
                FornecedorRN oFornRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);

                oForn.codEmpresa = empMaster;
                oForn.idPessoa = EmcResources.cInt(cboIdLocadorRepresentante.SelectedValue.ToString());

                oForn = oFornRN.ObterPor(oForn);

                oContrato.locadorRepresentante = oForn;
                oContrato.locatarioFormaPagamento = cboLocadorFormaPagamento.SelectedValue.ToString();
                oContrato.locatarioRateio = cboLocatarioRateio.SelectedValue.ToString();

                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);

                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = EmcResources.cInt(txtIdLocatarioRepresentante.Text);

                oCliente = oClienteRN.ObterPor(oCliente);
                oContrato.locatarioRepresentante = oCliente;

                oContrato.nroDiasPagamento = txtNroDiasPagamento.Text;
                oContrato.nroMeses = EmcResources.cInt(txtNroMeses.Text);
                oContrato.nroParcelas = EmcResources.cInt(txtNroParcelas.Text);
                oContrato.pagamentoIptu = cboPagamentoIPTU.SelectedValue.ToString();
                oContrato.saldoContratoParcela = EmcResources.cCur(txtSaldoContratoParcela.Value.ToString());
                oContrato.taxaAdministracao = EmcResources.cDouble(txtTaxaAdministracao.Value.ToString());
                oContrato.taxaJuros = EmcResources.cDouble(txtTaxaJuros.Value.ToString());
                oContrato.taxaMulta = EmcResources.cDouble(txtTaxaMulta.Value.ToString());
                oContrato.temCarencia = cboTemCarencia.SelectedValue.ToString();
                oContrato.valorAluguel = EmcResources.cCur(txtValorAluguel.Value.ToString());
                oContrato.valorDescontoConcedido = EmcResources.cCur(txtValorDescontoConcedido.Value.ToString());
                oContrato.valorEntrada = EmcResources.cCur(txtValorEntrada.Value.ToString());
                oContrato.valorMensal = EmcResources.cCur(txtValorMensal.Value.ToString());
                oContrato.valorProporcional = EmcResources.cCur(txtValorProporcional.Value.ToString());
                oContrato.valorTotalContrato = EmcResources.cCur(txtValorTotalContrato.Value.ToString());
                oContrato.situacaoEncerramento = "";
                oContrato.situacaoContrato = "A";

                oContrato.statusOperacao = "I";
          
                //monta a lista de locatários
                List<LocacaoCliente> lstLocatarios = new List<LocacaoCliente>();
                foreach(DataGridViewRow oLocatarioRow in grdLocatario.Rows)
                {
                    LocacaoCliente oLocaCliente = new LocacaoCliente();
                    oLocaCliente.idLocacaoCliente = EmcResources.cInt(oLocatarioRow.Cells["idlocacaocliente"].Value.ToString());
                    oLocaCliente.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);

                    Cliente oLocatario = new Cliente();
                    ClienteRN oLocatarioRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                    oLocatario.codEmpresa = empMaster;
                    oLocatario.idPessoa = EmcResources.cInt(oLocatarioRow.Cells["idlocatario"].Value.ToString());
                    oLocatario = oLocatarioRN.ObterPor(oLocatario);
                    oLocaCliente.locatario = oLocatario;

                    oLocaCliente.percParticipacao = EmcResources.cDouble(oLocatarioRow.Cells["participacao"].Value.ToString());
                    oLocaCliente.situacao = oLocatarioRow.Cells["sitlocatario"].Value.ToString();
                    oLocaCliente.statusOperacao = oLocatarioRow.Cells["status"].Value.ToString();
                    oLocaCliente.valorAluguel = EmcResources.cCur(oLocatarioRow.Cells["vlraluguelreceber"].Value.ToString());
                    oLocaCliente.representante = oLocatarioRow.Cells["representante"].Value.ToString();

                    lstLocatarios.Add(oLocaCliente);
                }
                oContrato.listaLocatarios = lstLocatarios;


                //monta a lista de locadores
                List<LocacaoFornecedor> lstLocador = new List<LocacaoFornecedor>();
                foreach (DataGridViewRow oLocadorRow in grdLocador.Rows)
                {
                    LocacaoFornecedor oLocaFornecedor = new LocacaoFornecedor();
                    oLocaFornecedor.idLocacaoFornecedor = EmcResources.cInt(oLocadorRow.Cells["idlocacaofornecedor"].Value.ToString());
                    oLocaFornecedor.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);

                    Fornecedor oLocador = new Fornecedor();
                    FornecedorRN oLocadorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
                    oLocador.codEmpresa = empMaster;
                    oLocador.idPessoa = EmcResources.cInt(oLocadorRow.Cells["idlocador"].Value.ToString());
                    oLocador = oLocadorRN.ObterPor(oLocador);
                    oLocaFornecedor.locador = oLocador;

                    oLocaFornecedor.percParticipacao = EmcResources.cDouble(oLocadorRow.Cells["percparticipacao"].Value.ToString());
                    oLocaFornecedor.situacao = oLocadorRow.Cells["situacaolocador"].Value.ToString();
                    oLocaFornecedor.statusOperacao = oLocadorRow.Cells["situacao"].Value.ToString();
                    oLocaFornecedor.valorAluguel = EmcResources.cCur(oLocadorRow.Cells["valoraluguel"].Value.ToString());
     
                    lstLocador.Add(oLocaFornecedor);
                }
                oContrato.listaLocadores = lstLocador;


                //monta a lista de fiadores
                List<LocacaoFiador> lstFiador = new List<LocacaoFiador>();
                foreach (DataGridViewRow oFiadorRow in grdFiador.Rows)
                {
                    LocacaoFiador oLocaFiador = new LocacaoFiador();
                    oLocaFiador.idLocacaoFiador = EmcResources.cInt(oFiadorRow.Cells["idlocacaofiador"].Value.ToString());
                    oLocaFiador.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);

                    Fiador oFiador = new Fiador();
                    FiadorRN oFiadorRN = new FiadorRN(Conexao, objOcorrencia, codempresa);
                    oFiador.codEmpresa = empMaster;
                    oFiador.idPessoa = EmcResources.cInt(oFiadorRow.Cells["idfiador"].Value.ToString());
                    oFiador = oFiadorRN.ObterPor(oFiador);
                    oLocaFiador.fiador = oFiador;

                    oLocaFiador.situacao = oFiadorRow.Cells["situacaofiador"].Value.ToString();
                    oLocaFiador.statusOperacao = oFiadorRow.Cells["stoperacaofiador"].Value.ToString();
                    

                    lstFiador.Add(oLocaFiador);
                }
                oContrato.listaFiadores = lstFiador;

                //Parcelamento a Receber
                List<LocacaoReceber> lstReceber = new List<LocacaoReceber>();
                foreach(DataGridViewRow oRecRow in grdLocacaoReceber.Rows)
                {
                    LocacaoReceber oReceber = new LocacaoReceber();
                    oReceber.dataCarencia = Convert.ToDateTime(oRecRow.Cells["dtacarencia"].Value.ToString());
                    oReceber.dataIntegracao = EmcResources.cDate(oRecRow.Cells["dataintegracao"].Value.ToString());
                    oReceber.dataVencimento = Convert.ToDateTime(oRecRow.Cells["dtavenccliente"].Value.ToString());
                    oReceber.diasCarencia = EmcResources.cInt(oRecRow.Cells["diascarencia"].Value.ToString());
                    oReceber.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);
                    oReceber.idLocacaoReceber = EmcResources.cInt(oRecRow.Cells["idlocacaoreceber"].Value.ToString());

                    Cliente oLocatario = new Cliente();
                    ClienteRN oLocatarioRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                    oLocatario.codEmpresa = empMaster;
                    oLocatario.idPessoa = EmcResources.cInt(oRecRow.Cells["idcliente"].Value.ToString());
                    oLocatario = oLocatarioRN.ObterPor(oLocatario);
                    oReceber.locatario = oLocatario;

                    oReceber.nroParcela = EmcResources.cInt(oRecRow.Cells["nroparcelacliente"].Value.ToString());
                    oReceber.percParticipacao = EmcResources.cDouble(oRecRow.Cells["percpartreceber"].Value.ToString());
                    oReceber.periodoFim = Convert.ToDateTime(oRecRow.Cells["periodofinal"].Value.ToString());
                    oReceber.periodoInicio =Convert.ToDateTime(oRecRow.Cells["periodoinicio"].Value.ToString());
                    oReceber.situacao = oRecRow.Cells["situacaocliente"].Value.ToString();
                    oReceber.statusOperacao = oRecRow.Cells["st"].Value.ToString();
                    oReceber.valorDesconto = EmcResources.cCur(oRecRow.Cells["vlrdescontocliente"].Value.ToString());
                    oReceber.valorJuros = EmcResources.cCur(oRecRow.Cells["vlrjuroscliente"].Value.ToString());
                    oReceber.valorJurosCalculado = EmcResources.cCur(oRecRow.Cells["vlrjuroscalculado"].Value.ToString());
                    oReceber.valorPago = EmcResources.cCur(oRecRow.Cells["vlrpagocliente"].Value.ToString());
                    oReceber.valorParcela = EmcResources.cCur(oRecRow.Cells["valorparcelacliente"].Value.ToString());
                    
                    List<LocacaoCCReceber> lstCtaReceber = new List<LocacaoCCReceber>();
                    foreach(DataGridViewRow oCtRecRow in grdCCReceber.Rows)
                    {
                        //se o provento for da parcela atual insere na lista.
                        if (oReceber.idLocacaoReceber == EmcResources.cInt(oCtRecRow.Cells["idlocacaoreceberccrc"].Value.ToString()) &&
                            oReceber.locatario.idPessoa == EmcResources.cInt(oCtRecRow.Cells["idlocatariocta"].Value.ToString()) &&
                            oReceber.nroParcela == EmcResources.cInt(oCtRecRow.Cells["nroparcela"].Value.ToString()))
                        {
                            LocacaoCCReceber oCCReceber = new LocacaoCCReceber();
                            oCCReceber.dataEmissao = Convert.ToDateTime(oCtRecRow.Cells["dataemissao"].Value.ToString());
                            oCCReceber.dataLancamento = Convert.ToDateTime(oCtRecRow.Cells["datalancamento"].Value.ToString());
                            oCCReceber.descricao = oCtRecRow.Cells["descricao"].Value.ToString();
                            oCCReceber.idLocacaoCCReceber = EmcResources.cInt(oCtRecRow.Cells["idlocacaoccreceber"].Value.ToString());
                            oCCReceber.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);
                            oCCReceber.idLocacaoReceber = EmcResources.cInt(oCtRecRow.Cells["idlocacaoreceberccrc"].Value.ToString());
                            oCCReceber.locatario = oLocatario;
                            oCCReceber.nroParcela = EmcResources.cInt(oCtRecRow.Cells["nroparcela"].Value.ToString());

                            LocacaoProventos oProvento = new LocacaoProventos();
                            LocacaoProventosRN oProventoRN = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
                            oProvento.idLocacaoProventos = EmcResources.cInt(oCtRecRow.Cells["idprovento"].Value.ToString());
                            oProvento = oProventoRN.ObterPor(oProvento);
                            oCCReceber.provento = oProvento;

                            oCCReceber.situacao = oCtRecRow.Cells["sitccreceber"].Value.ToString();
                            oCCReceber.statusOperacao = oCtRecRow.Cells["stccreceber"].Value.ToString();
                            oCCReceber.tipoProvento = oCtRecRow.Cells["tipoprovento"].Value.ToString();
                            oCCReceber.valorLancamento = EmcResources.cCur(oCtRecRow.Cells["valorlancamento"].Value.ToString());

                            lstCtaReceber.Add(oCCReceber);
                        }
                    }

                    oReceber.lstCtaCorrente = lstCtaReceber;

                    lstReceber.Add(oReceber);

                }
                oContrato.lstLocacaoReceber = lstReceber;
                
                //Parcelas a Pagar
                List<LocacaoPagar> lstPagar = new List<LocacaoPagar>();
                foreach (DataGridViewRow oPgRow in grdLocacaoPagar.Rows)
                {
                    LocacaoPagar oPagar = new LocacaoPagar();
                    oPagar.dataIntegracao = EmcResources.cDate(oPgRow.Cells["dtaintegracaopagar"].Value.ToString());
                    oPagar.dataVencimento = Convert.ToDateTime(oPgRow.Cells["dtavencimentopagar"].Value.ToString());
                    oPagar.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);
                    oPagar.idLocacaoPagar = EmcResources.cInt(oPgRow.Cells["idlocacaopagar"].Value.ToString());

                    Fornecedor oLocador = new Fornecedor();
                    FornecedorRN oLocadorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
                    oLocador.codEmpresa = empMaster;
                    oLocador.idPessoa = EmcResources.cInt(oPgRow.Cells["idlocadorpagar"].Value.ToString());
                    oLocador = oLocadorRN.ObterPor(oLocador);
                    oPagar.locador = oLocador;

                    oPagar.nroParcela = EmcResources.cInt(oPgRow.Cells["nroparcelapagar"].Value.ToString());
                    oPagar.percParticipacao = EmcResources.cDouble(oPgRow.Cells["percparticipacaopagar"].Value.ToString());
                    oPagar.periodoFim = Convert.ToDateTime(oPgRow.Cells["peraquisitivofinal"].Value.ToString());
                    oPagar.periodoInicio = Convert.ToDateTime(oPgRow.Cells["peraquisitivoinicio"].Value.ToString());
                    oPagar.situacao = oPgRow.Cells["situacaopagar"].Value.ToString();
                    oPagar.statusOperacao = oPgRow.Cells["stoperacao"].Value.ToString();
                    oPagar.valorDesconto = EmcResources.cCur(oPgRow.Cells["valordescontopagar"].Value.ToString());
                    oPagar.valorJuros = EmcResources.cCur(oPgRow.Cells["valorjurospagar"].Value.ToString());
                    oPagar.valorJurosCalculado = EmcResources.cCur(oPgRow.Cells["valorjuroscalculadopagar"].Value.ToString());
                    oPagar.valorPago = EmcResources.cCur(oPgRow.Cells["valorpagopagar"].Value.ToString());
                    oPagar.valorParcela = EmcResources.cCur(oPgRow.Cells["valorparcelapagar"].Value.ToString());

                    List<LocacaoCCPagar> lstCtaPagar = new List<LocacaoCCPagar>();
                    foreach (DataGridViewRow oCtPagRow in grdCCPagar.Rows)
                    {
                        //se o provento for da parcela atual insere na lista.
                        if (oPagar.idLocacaoPagar == EmcResources.cInt(oCtPagRow.Cells["idparcelaccpagar"].Value.ToString()) &&
                            oPagar.locador.idPessoa == EmcResources.cInt(oCtPagRow.Cells["idlocadorccpagar"].Value.ToString()) &&
                            oPagar.nroParcela == EmcResources.cInt(oCtPagRow.Cells["nroparcelaccpagar"].Value.ToString()))
                        {
                            LocacaoCCPagar oCCPagar = new LocacaoCCPagar();
                            oCCPagar.dataEmissao = Convert.ToDateTime(oCtPagRow.Cells["dataemissaoccpagar"].Value.ToString());
                            oCCPagar.dataLancamento = Convert.ToDateTime(oCtPagRow.Cells["datalanctoccpagar"].Value.ToString());
                            oCCPagar.descricao = oCtPagRow.Cells["descricaoccpagar"].Value.ToString();
                            oCCPagar.idLocacaoCCPagar = EmcResources.cInt(oCtPagRow.Cells["idlocacaoccpagar"].Value.ToString());
                            oCCPagar.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);
                            oCCPagar.idLocacaoPagar = EmcResources.cInt(oCtPagRow.Cells["idparcelaccpagar"].Value.ToString());
                            oCCPagar.locador = oLocador;
                            oCCPagar.nroParcela = EmcResources.cInt(oCtPagRow.Cells["nroparcelaccpagar"].Value.ToString());

                            LocacaoProventos oProvento = new LocacaoProventos();
                            LocacaoProventosRN oProventoRN = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
                            oProvento.idLocacaoProventos = EmcResources.cInt(oCtPagRow.Cells["idproventoccpagar"].Value.ToString());
                            oProvento = oProventoRN.ObterPor(oProvento);
                            oCCPagar.provento = oProvento;

                            oCCPagar.situacao = oCtPagRow.Cells["situacaoccpagar"].Value.ToString();
                            oCCPagar.statusOperacao = oCtPagRow.Cells["stoperacaoccpagar"].Value.ToString();
                            oCCPagar.tipoProvento = oCtPagRow.Cells["tipoproventoccpagar"].Value.ToString();
                            oCCPagar.valorLancamento = EmcResources.cCur(oCtPagRow.Cells["valorccpagar"].Value.ToString());

                            lstCtaPagar.Add(oCCPagar);
                        }
                    }

                    oPagar.lstCtaCorrente = lstCtaPagar;

                    lstPagar.Add(oPagar);

                }
                oContrato.lstLocacaoPagar = lstPagar;
                
                //Anotações
                List<LocacaoAnotacao> lstAnotacao = new List<LocacaoAnotacao>();
                oContrato.lstAnotacao = lstAnotacao;

                //Lancamentos Contabeis
                List<LocacaoContabil> lstContabil = new List<LocacaoContabil>();
                oContrato.lstLocacaoContabil = lstContabil;
            
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            return oContrato;
        }

        private void montaTela(LocacaoContrato oContrato)
        {
            AtivaEdicao();

            /* Contrato Geral */
            txtIdentificacaoContrato.Text = oContrato.identificacaoContrato;
            txtIdLocacaoContrato.Text = oContrato.idLocacaoContrato.ToString();
            txtDataContrato.Text = oContrato.dataContrato.ToString();
            txtDataInicial.Text = oContrato.dataInicial.ToString();
            txtDataFinal.Text = oContrato.dataFinal.ToString();
            txtCodigoImovel.Text = oContrato.imovel.codigoImovel.ToString();
            txtIdImovel.Text = oContrato.imovel.idImovel.ToString();
            txtEndereco.Text = oContrato.imovel.rua;
            txtCidade.Text = oContrato.imovel.cidade;
            txtEstado.Text = oContrato.imovel.estado;
            txtNumero.Text = oContrato.imovel.numero;
            txtNroMeses.Text = oContrato.nroMeses.ToString();
            txtValorTotalContrato.Text = oContrato.valorTotalContrato.ToString();
            txtValorAluguel.Text = oContrato.valorAluguel.ToString();
            cboIntegraCondominio.SelectedValue = oContrato.integraCondominio.ToString();
            cboIdIndexador.SelectedValue = EmcResources.cInt(oContrato.indexador.idIndexador.ToString());
            cboPagamentoIPTU.SelectedValue = oContrato.pagamentoIptu.ToString();
           
            /*Aba locatarios*/
            txtCPFCNPJLocatario.Text = oContrato.locatarioRepresentante.pessoa.cnpjCpf.ToString();
            txtIdLocatarioRepresentante.Text = oContrato.locatarioRepresentante.pessoa.idPessoa.ToString();
            txtNomeLocatario.Text = oContrato.locatarioRepresentante.pessoa.nome;
            txtData1Parcela.Text = oContrato.data1Parcela.ToString();
            txtDiaFixoLocatario.Text = oContrato.diaFixoLocatario.ToString();
            txtDiasProporcionais.Text =oContrato.diasProporcionais.ToString();
            txtDataProporcional.Text = "";
            txtValorProporcional.Text = oContrato.valorProporcional.ToString();
            txtDtaEntradaInicio.Text = oContrato.dataEntradaInicio.ToString();
            txtDtaEntradaFinal.Text = oContrato.dataEntradaFinal.ToString();
            txtValorEntrada.Text = oContrato.valorEntrada.ToString();
            txtDataInicioDesconto.Text = oContrato.dataInicioDesconto.ToString();
            txtDataFinalDesconto.Text = oContrato.dataFinalDesconto.ToString();
            txtValorDescontoConcedido.Text = oContrato.valorDescontoConcedido.ToString();
            txtSaldoContratoParcela.Text = oContrato.saldoContratoParcela.ToString();
            txtNroParcelas.Text = oContrato.nroParcelas.ToString();
            txtValorMensal.Text = oContrato.valorMensal.ToString();
            txtDiasCarencia.Text = oContrato.diasCarencia.ToString();
            txtData1ParcelaCarencia.Text = oContrato.data1ParcelaCarencia.ToString();
            txtTaxaMulta.Text = oContrato.taxaMulta.ToString();
            txtTaxaJuros.Text = oContrato.taxaJuros.ToString();
            cboLocatarioRateio.SelectedValue = oContrato.locatarioRateio.ToString();
            cboLocatarioFormaPagto.SelectedValue = oContrato.locatarioFormaPagamento.ToString();
            cboTemCarencia.SelectedValue = oContrato.temCarencia.ToString();
            txtLocatarioParticipacao.Text = oContrato.locatarioRepresentanteParticipacao.ToString();
            montaGridLocatario(oContrato.listaLocatarios);

            /*Aba locadores */
            txtNroDiasPagamento.Text = oContrato.nroDiasPagamento.ToString();
            txtDiaFixoPagamento.Text = oContrato.diaFixoPagamento.ToString();
            txtTaxaAdministracao.Text = oContrato.taxaAdministracao.ToString();
            cboLocadorRateio.SelectedValue = oContrato.locadorRateio.ToString();
            cboIdLocadorRepresentante.SelectedValue = oContrato.locadorRepresentante.pessoa.idPessoa.ToString();
            cboLocadorFormaPagamento.SelectedValue = oContrato.locadorFormaPagamento.ToString();
            cboContratoGarantido.SelectedValue = oContrato.contratoGarantido.ToString();
            montaGridLocador(oContrato.listaLocadores);

            /*aba Fiador */
            montaGridFiador(oContrato.listaFiadores);

            /*aba receber*/
            montaGridReceber(oContrato.lstLocacaoReceber);

            /*aba proventos receber*/
            

            /*aba pagar */
            montaGridPagar(oContrato.lstLocacaoPagar);

            /*aba proventos pagar */

            travaDados();

            txtDataContrato.Focus();
            objOcorrencia.chaveidentificacao = oContrato.idLocacaoContrato.ToString();
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
            stOperacao = "E";

            mostraAbas();

        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();

            stOperacao = "I";
            objOcorrencia.chaveidentificacao = "";

            txtTaxaAdministracao.Text = perc_Taxa_Adm.ToString();
            txtTaxaJuros.Text = taxa_Juros.ToString();
            txtTaxaMulta.Text = taxa_Multa.ToString();
            ocultaAbas();
            travaDados();

            carregaConfiguracoes();

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

        public void carregaConfiguracoes()
        {

            /* monta combos */

            ArrayList arrLocadorRateio = new ArrayList();
            arrLocadorRateio.Add(new popCombo("Contrato Individual", "I"));
            arrLocadorRateio.Add(new popCombo("Contrato Vários Locadores", "C"));
            cboLocadorRateio.DataSource = arrLocadorRateio;
            cboLocadorRateio.DisplayMember = "nome";
            cboLocadorRateio.ValueMember = "valor";

            cboLocadorRateio.SelectedIndex = -1;

            IndexadorRN oIndexadorRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
            cboIdIndexador.DataSource = oIndexadorRN.ListaIndexador();
            cboIdIndexador.DisplayMember = "descricao";
            cboIdIndexador.ValueMember = "idindexador";

            ArrayList arrLocatarioRateio = new ArrayList();
            arrLocatarioRateio.Add(new popCombo("Contrato Individual", "I"));
            arrLocatarioRateio.Add(new popCombo("Contrato Vários Locatários", "C"));
            cboLocatarioRateio.DataSource = arrLocatarioRateio;
            cboLocatarioRateio.DisplayMember = "nome";
            cboLocatarioRateio.ValueMember = "valor";

            ArrayList arrRecebe = new ArrayList();
            arrRecebe.Add(new popCombo("Antecipado", "A"));
            arrRecebe.Add(new popCombo("Não antecipado", "N"));
            cboLocatarioFormaPagto.DataSource = arrRecebe;
            cboLocatarioFormaPagto.DisplayMember = "nome";
            cboLocatarioFormaPagto.ValueMember = "valor";

            ArrayList arrPagto = new ArrayList();
            arrPagto.Add(new popCombo("N dias Uteis", "N"));
            arrPagto.Add(new popCombo("Dia Fixo", "D"));
            cboLocadorFormaPagamento.DataSource = arrPagto;
            cboLocadorFormaPagamento.DisplayMember = "nome";
            cboLocadorFormaPagamento.ValueMember = "valor";

            cboLocadorFormaPagamento.SelectedIndex = -1;

            ArrayList arrCarencia = new ArrayList();
            arrCarencia.Add(new popCombo("Sim", "S"));
            arrCarencia.Add(new popCombo("Não", "N"));
            cboTemCarencia.DataSource = arrCarencia;
            cboTemCarencia.DisplayMember = "nome";
            cboTemCarencia.ValueMember = "valor";

            ArrayList arrIptu = new ArrayList();
            arrIptu.Add(new popCombo("Locatário", "C"));
            arrIptu.Add(new popCombo("Locador", "F"));
            cboPagamentoIPTU.DataSource = arrIptu;
            cboPagamentoIPTU.DisplayMember = "nome";
            cboPagamentoIPTU.ValueMember = "valor";

            ArrayList arrGarantia = new ArrayList();
            arrGarantia.Add(new popCombo("Não", "N"));
            arrGarantia.Add(new popCombo("Sim", "S"));
            cboContratoGarantido.DataSource = arrGarantia;
            cboContratoGarantido.DisplayMember = "nome";
            cboContratoGarantido.ValueMember = "valor";

            ArrayList arrCondominio = new ArrayList();
            arrCondominio.Add(new popCombo("Não", "N"));
            arrCondominio.Add(new popCombo("Sim", "S"));
            cboIntegraCondominio.DataSource = arrCondominio;
            cboIntegraCondominio.DisplayMember = "nome";
            cboIntegraCondominio.ValueMember = "valor";


            /* Configura parametros */
            ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);

            //Código provento aluguel locador
            alug_Locador = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "ALUG_LOCADOR"));

            //Código provento aluguel locatario
            alug_locatario = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "ALUG_LOCATARIO"));

            //Código provento condominio locatario
            cond_locatario = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "COND_LOCATARIO"));

            //Código provento TAXA ADMINISTRACAO
            idTaxa_adm = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "TAXA_ADM"));

            //Código provento DESCONTO CONCEDIDO LOCADOR
            desc_Conc_Locador = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "DESC_CONC_LOCADOR"));

            //Código provento DESCONTO CONCEDIDO LOCATARIO
            desc_Conc_Locatario = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "DESC_CONC_LOCATARIO"));

            //Código provento BASE DIMOB
            base_Dimob = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "BASE_DIMOB"));

            //Código provento JUROS RECEBIDOS LOCATARIO
            juros_Recebidos = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "JUROS_RECEBIDOS"));

            //Código provento juros pagos
            juros_Pagos = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "JUROS_PAGOS"));

            //Código provento DESCONTO CONCEDIDO LOCADOR
            juros_Retidos = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "JUROS_RETIDOS"));

            //Código provento BASE IR
            base_IR = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "BASE_IR"));

            //Código provento IMPOSTO DE RENDA
            imposto_Renda = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCIMOB", "PROVENTO", "IMPOSTO_RENDA"));

            //Código provento TAXA DE MULTA PADRÃO
            taxa_Multa = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCIMOB", "TAXA", "TAXA_MULTA"));

            //Código provento TAXA DE MULTA PADRÃO
            taxa_Juros = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCIMOB", "TAXA", "TAXA_JUROS"));

            //Código provento TAXA ADMINISTRACAO PADRÃO
            perc_Taxa_Adm = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCIMOB", "TAXA", "PERC_TAXA_ADM"));

        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();

            stOperacao = "C";

            carregaConfiguracoes();

            limpaGrids();

            txtIdentificacaoContrato.Focus();

            objOcorrencia.chaveidentificacao = "";
            travaDados();
        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                //psqLocacaoContrato ofrm = new psqLocacaoContrato(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                //ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaContrato()
        {
            if (!String.IsNullOrEmpty(txtIdentificacaoContrato.Text))
            {

                LocacaoContrato oContrato = new LocacaoContrato();
                try
                {
                    LocacaoContratoRN ContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);

                    oContrato = montaContrato();
                    oContrato.idLocacaoContrato = EmcResources.cInt(txtIdLocacaoContrato.Text);
                    oContrato.identificacaoContrato = txtIdentificacaoContrato.Text;

                    oContrato = ContratoRN.ObterPor(oContrato);

                    if (String.IsNullOrEmpty(oContrato.identificacaoContrato))
                    {
                        DialogResult result = MessageBox.Show("Contrato não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oContrato);
                        AtivaEdicao();
                        txtDataContrato.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro LocacaoContrato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            limpaContratoGeral();
            limpaAbaLocatarios();
            limpaAbaLocadores();
            limpaAbaFiadores();

            limpaGrids();


            objOcorrencia.chaveidentificacao = "";
            txtIdentificacaoContrato.Focus();

            txtTaxaAdministracao.Text = perc_Taxa_Adm.ToString();
            txtTaxaJuros.Text = taxa_Juros.ToString();
            txtTaxaMulta.Text = taxa_Multa.ToString();
            ocultaAbas();


        }

        public void limpaContratoGeral()
        {
            txtIdLocacaoContrato.Text = "";
            txtIdentificacaoContrato.Text = "";
            txtDataContrato.Text = "";
            txtDataInicial.Text = "";
            txtDataFinal.Text = "";
            txtCodigoImovel.Text = "";
            txtIdImovel.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtNumero.Text = "";
            txtNroMeses.Text = "";
            txtValorTotalContrato.Text = "";
            txtValorAluguel.Text = "";
        }

        public void limpaAbaLocatarios()
        {
            txtCPFCNPJLocatario.Text = "";
            txtIdLocatarioRepresentante.Text = "";
            txtNomeLocatario.Text = "";
            txtLocatarioParticipacao.Text = "";
            txtData1Parcela.Text = "";
            txtDiaFixoLocatario.Text = "";
            txtDiasProporcionais.Text = "";
            txtDataProporcional.Text = "";
            txtValorProporcional.Text = "";
            txtDtaEntradaInicio.Text = "";
            txtDtaEntradaFinal.Text = "";
            txtValorEntrada.Text = "";
            txtDataInicioDesconto.Text = "";
            txtDataFinalDesconto.Text = "";
            txtValorDescontoConcedido.Text = "";
            txtSaldoContratoParcela.Text = "";
            txtNroParcelas.Text = "";
            txtValorMensal.Text = "";
            txtDiasCarencia.Text = "";
            txtData1ParcelaCarencia.Text = "";
            txtTaxaMulta.Text = "";
            txtTaxaJuros.Text = "";
        }

        public void limpaAbaLocadores()
        {
            txtNroDiasPagamento.Text = "";
            txtDiaFixoPagamento.Text = "";
            txtTaxaAdministracao.Text = "";
        }

        public void limpaAbaFiadores()
        {
            txtCPFCNPJFiador.Text = "";
            txtIdFiador.Text = "";
            txtNomeFiador.Text = "";
        }

        public void limpaAbaReceber()
        {


        }

        public void limpaAbaCCReceber()
        {

        }

        public void limpaAbaPagar()
        {

        }

        public void limpaAbaCCPagar()
        {

        }

        public override void SalvaObjeto()
        {
            try
            {
                LocacaoContrato oContrato = new LocacaoContrato();
                LocacaoContratoRN oContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                oContrato = montaContrato();
                oContrato.statusOperacao = "I";

                oContratoRN.Salvar(oContrato);

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
                LocacaoContrato oLocacaoContrato = new LocacaoContrato();
                LocacaoContratoRN oLocacaoContratoBLL = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                oLocacaoContrato = montaContrato();
                oLocacaoContrato.statusOperacao = "A";
                oLocacaoContrato.idLocacaoContrato = Convert.ToInt32(txtIdLocacaoContrato.Text);

                oLocacaoContratoBLL.Salvar(oLocacaoContrato);

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
                LocacaoContrato oLocacaoContrato = new LocacaoContrato();
                LocacaoContratoRN oLocacaoContratoBLL = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                oLocacaoContrato = montaContrato();
                oLocacaoContrato.statusOperacao = "E";
                oLocacaoContrato.idLocacaoContrato = Convert.ToInt32(txtIdLocacaoContrato.Text);

                oLocacaoContratoBLL.Salvar(oLocacaoContrato);

                CancelaOperacao();
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
                Relatorios.relContratoLocacao ofrm = new Relatorios.relContratoLocacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ocultaAbas() 
        {
            tabContrato.Controls.Remove(tabFiador);
            tabContrato.Controls.Remove(tabLocatario);
            tabContrato.Controls.Remove(tabCtaLocatario);
            tabContrato.Controls.Remove(tabLocador);
            tabContrato.Controls.Remove(tabCtaLocador);
            tabContrato.Controls.Remove(tabContabil);
            tabContrato.Controls.Remove(tabAnotacao);
            
        }

        public void mostraAbas() 
        {
            if (tabContrato.TabCount <= 2)
            {
                tabContrato.Controls.Add(tabFiador);
                tabContrato.Controls.Add(tabLocatario);
                tabContrato.Controls.Add(tabCtaLocatario);
                tabContrato.Controls.Add(tabLocador);
                tabContrato.Controls.Add(tabCtaLocador);
                tabContrato.Controls.Add(tabContabil);
                tabContrato.Controls.Add(tabAnotacao);
            }
        
        }

        public void travaDados()
        {
            Boolean flagEdicao = false;

            if (stOperacao == "I")
                flagEdicao = true;

            /* Contrato Geral */
            txtIdLocacaoContrato.Enabled = false;
            txtIdentificacaoContrato.Enabled = true;
            txtDataContrato.Enabled = flagEdicao;
            txtDataInicial.Enabled = flagEdicao;
            txtDataFinal.Enabled = flagEdicao;
            txtCodigoImovel.Enabled = flagEdicao;
            txtIdImovel.Enabled = flagEdicao;
            txtEndereco.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;
            txtNumero.Enabled = false;
            txtNroMeses.Enabled = false;
            txtValorTotalContrato.Enabled = false;
            txtValorAluguel.Enabled = false;
            cboIdIndexador.Enabled = flagEdicao;
            cboIntegraCondominio.Enabled = flagEdicao;
            cboPagamentoIPTU.Enabled = flagEdicao;

            /*aba locatarios */
            cboLocatarioRateio.Enabled = flagEdicao;
            cboLocatarioFormaPagto.Enabled = flagEdicao;
            txtCPFCNPJLocatario.Enabled = flagEdicao;
            txtIdLocatarioRepresentante.Enabled = flagEdicao;
            btnBuscaImovel.Enabled = flagEdicao;
            btnLocatario.Enabled = flagEdicao;
            txtNomeLocatario.Enabled = flagEdicao;
            txtLocatarioParticipacao.Enabled = flagEdicao;
            txtData1Parcela.Enabled = flagEdicao;
            txtDiaFixoLocatario.Enabled = flagEdicao;
            txtDiasProporcionais.Enabled = flagEdicao;
            txtDataProporcional.Enabled = flagEdicao;
            txtValorProporcional.Enabled = flagEdicao;
            txtDtaEntradaInicio.Enabled = flagEdicao;
            txtDtaEntradaFinal.Enabled = flagEdicao;
            txtValorEntrada.Enabled = flagEdicao;
            txtDataInicioDesconto.Enabled = flagEdicao;
            txtDataFinalDesconto.Enabled = flagEdicao;
            txtValorDescontoConcedido.Enabled = flagEdicao;
            txtSaldoContratoParcela.Enabled = flagEdicao;
            txtNroParcelas.Enabled = flagEdicao;
            txtValorMensal.Enabled = flagEdicao;
            txtDiasCarencia.Enabled = flagEdicao;
            txtData1ParcelaCarencia.Enabled = flagEdicao;
            txtTaxaMulta.Enabled = flagEdicao;
            txtTaxaJuros.Enabled = flagEdicao;
            cboTemCarencia.Enabled = flagEdicao;

            /* aba locadores */
            txtNroDiasPagamento.Enabled = flagEdicao;
            txtDiaFixoPagamento.Enabled = flagEdicao;
            txtTaxaAdministracao.Enabled = flagEdicao;
            cboLocadorRateio.Enabled = flagEdicao;
            cboLocadorFormaPagamento.Enabled = flagEdicao;
            cboContratoGarantido.Enabled = flagEdicao;
            cboIdLocadorRepresentante.Enabled = flagEdicao;

        }

        #endregion

        #region "metodos da dbgrid"

      


        #endregion

        #region "Tratamento de Campos - Tela Geral do Contrato"

        private void btnBuscaImovel_Click(object sender, EventArgs e)
        {
            psqImovel ofrm = new psqImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (retPesquisa.chaveinterna == 0)
            {
                txtIdImovel.Text = "";
                txtCodigoImovel.Text = "";
            }
            else
            {
                txtIdImovel.Text = retPesquisa.chaveinterna.ToString();
                txtCodigoImovel.Text = retPesquisa.chavebusca.ToString();
            }

            txtCodigoImovel_Validating(null, null);
        }

        private void cboPagamentoIPTU_Validating(object sender, CancelEventArgs e)
        {
            if(cboPagamentoIPTU.SelectedIndex >-1)
            {
                cboLocatarioRateio.Focus();
            }
        }

        private void txtCodigoImovel_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Imovel oImovel = new Imovel();
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;

                oImovel.codigoImovel = txtCodigoImovel.Text;
                oImovel.empresa = oEmpresa;

                ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                oImovel = oImovelRN.ObterPor(oImovel);

                if (oImovel.idImovel > 0)
                {
                    txtIdImovel.Text = oImovel.idImovel.ToString();
                    txtCidade.Text = oImovel.cidade;
                    txtEstado.Text = oImovel.estado;
                    txtEndereco.Text = oImovel.rua;
                    txtNumero.Text = oImovel.numero;

                    txtValorAluguel.Text = oImovel.valorAluguel.ToString();
                    
                    txtValorTotalContrato.Text = (EmcResources.cCur(txtValorAluguel.Value.ToString()) * EmcResources.cCur(txtNroMeses.Text)).ToString();
                    txtSaldoContratoParcela.Text = (EmcResources.cCur(txtValorAluguel.Value.ToString()) * EmcResources.cCur(txtNroMeses.Text)).ToString();

                    txtValorMensal.Text = (EmcResources.cCur(txtSaldoContratoParcela.Value.ToString()) / EmcResources.cCur(txtNroParcelas.Text)).ToString();

                    cboIntegraCondominio.Focus();

                }
                else
                {
                    MessageBox.Show("Imovel não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDataInicial_Validating(object sender, CancelEventArgs e)
        {
            if(txtDataInicial.DateValue >= txtDataFinal.DateValue)
            {
                MessageBox.Show("Período do contrato, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataInicial.Focus();
            }
            else if (txtDataInicial.DateValue is DateTime && txtDataFinal.DateValue is DateTime)
            {
                /****** Calcula a diferença entre as data em meses *****/

                DateTime dataInicio = Convert.ToDateTime(txtDataInicial.DateValue);
                DateTime dataFinal = Convert.ToDateTime(txtDataFinal.DateValue);

                TimeSpan datadif = dataFinal.Subtract(dataInicio);

                txtNroMeses.Text = (datadif.Days / 30).ToString();
                txtNroParcelas.Text = txtNroMeses.Text;
            }
        }

        private void txtDataFinal_Validating(object sender, CancelEventArgs e)
        {
            if (txtDataInicial.DateValue >= txtDataFinal.DateValue)
            {
                MessageBox.Show("Período do contrato, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataInicial.Focus();
            }
            else if (txtDataInicial.DateValue is DateTime && txtDataFinal.DateValue is DateTime)
            {
                /****** Calcula a diferença entre as data em meses *****/

                DateTime dataInicio = Convert.ToDateTime(txtDataInicial.DateValue);
                DateTime dataFinal = Convert.ToDateTime(txtDataFinal.DateValue);

                TimeSpan datadif = dataFinal.Subtract(dataInicio);

                txtNroMeses.Text = (datadif.Days / 30).ToString();
                txtNroParcelas.Text = txtNroMeses.Text;

            }

        }

        private void txtIdentificacaoContrato_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(txtIdentificacaoContrato.Text))
                {
                    LocacaoContratoRN oContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                    LocacaoContrato oContrato = new LocacaoContrato();
                    oContrato.idEmpresa = codempresa;
                    oContrato.identificacaoContrato = txtIdentificacaoContrato.Text;

                    oContrato = oContratoRN.ObterPor(oContrato);

                    if (oContrato.valorTotalContrato > 0)
                    {
                        montaTela(oContrato);
                    }
                    else
                    {
                        AtivaInsercao();
                    }
                }

            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void cboIntegraCondominio_Validating(object sender, CancelEventArgs e)
        {
            if (cboIntegraCondominio.SelectedIndex > -1)
            {
                cboIdIndexador.Focus();
            }
        }

        #endregion

        #region "Tratamento de Campos - Tab - Aba de Locatários"

        private void btnLocatario_Click(object sender, EventArgs e)
        {
            psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdLocatarioRepresentante.Text = "";
            else
                txtIdLocatarioRepresentante.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdLocatarioRepresentante_Validating(null, null);
            
        }

        private void txtCPFCNPJLocatario_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJLocatario.Text))
                {
                    txtIdLocatarioRepresentante.ReadOnly = false;
                    txtIdLocatarioRepresentante.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJLocatario.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJLocatario.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJLocatario.Mask = "000.000.000-00";
                        lblCNPJLocatario.Text = "CPF";
                        txtCPFCNPJLocatario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJLocatario.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJLocatario.Mask = "00.000.000/0000-00";
                        lblCNPJLocatario.Text = "CNPJ";
                        txtCPFCNPJLocatario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCNPJLocatario.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJLocatario.Text.Trim().Length > 0)
                    {
                        ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                        Cliente oCliente = new Cliente();

                        oCliente = oClienteRN.ObterPor(empMaster, txtCPFCNPJLocatario.Text.Trim());

                        if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocatarioRepresentante.ReadOnly = false;
                            txtIdLocatarioRepresentante.Focus();
                        }
                        else
                        {
                            txtIdLocatarioRepresentante.Text = oCliente.idPessoa.ToString();
                            txtNomeLocatario.Text = oCliente.pessoa.nome;
                            txtIdLocatarioRepresentante.ReadOnly = true;

                            if (cboLocatarioRateio.SelectedValue == "I")
                            {
                                insereRepresentanteGrid();
                                cboLocatarioFormaPagto.Focus();
                            }
                            else
                                txtLocatarioParticipacao.Focus();
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

        private void txtIdLocatarioRepresentante_Validating(object sender, CancelEventArgs e)
        {
            try
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
                        txtIdLocatarioRepresentante.Text = oCliente.idPessoa.ToString();
                        txtCPFCNPJLocatario.Text = oCliente.pessoa.cnpjCpf;
                        txtNomeLocatario.Text = oCliente.pessoa.nome;

                        if (txtCPFCNPJLocatario.Text.Trim().Length == 11)
                        {
                            txtCNPJCPF.Mask = "000.000.000-00";
                            lblCNPJ.Text = "CPF";
                        }
                        else if (txtCPFCNPJLocatario.Text.Trim().Length == 14)
                        {
                            txtCNPJCPF.Mask = "00.000.000/0000-00";
                            lblCNPJ.Text = "CNPJ";
                        }

                        if (cboLocatarioRateio.SelectedValue == "I")
                        {
                            insereRepresentanteGrid();
                            cboLocatarioFormaPagto.Focus();
                        }
                        else
                            txtLocatarioParticipacao.Focus();
                    }

                }
                else
                {
                    txtCPFCNPJLocatario.Focus();
                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtCPFCNPJLocatario_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJLocatario.Mask = "";
            lblCNPJLocatario.Text = "CNPJ/CPF";
            txtCPFCNPJLocatario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void insereRepresentanteGrid()
        {
            try
            {
                Boolean achou = false;
                string cnpjAnterior = "";
                double valorAluguel = Math.Round( (txtValorAluguel.Value*txtLocatarioParticipacao.Value)/100, 2);

                foreach (DataGridViewRow row in grdLocatario.Rows)
                {
                    if (row.Cells["cnpjlocatario"].Value.ToString() == txtCPFCNPJLocatario.Text)
                    {
                        row.Cells["participacao"].Value = txtLocatarioParticipacao.Value;
                        row.Cells["vlraluguelreceber"].Value = valorAluguel;
                        achou = true;
                    }
                }


                if (!achou)
                {
                    //se continuar como contrato Individual elimina os representantes anteriores da grid
                    if (cboLocatarioRateio.SelectedValue.ToString() == "I")
                        grdLocatario.Rows.Clear();


                    //Insere novo locatario representante na grid
                    grdLocatario.Rows.Add(txtCPFCNPJLocatario.Text, txtIdLocatarioRepresentante.Text, txtNomeLocatario.Text, valorAluguel.ToString(), txtLocatarioParticipacao.Value, "S", "A", "I", 0);

                    //altera status do representante anterior para não
                    foreach (DataGridViewRow row in grdLocatario.Rows)
                    {
                        if (row.Cells["cnpjlocatario"].Value.ToString() != txtCPFCNPJLocatario.Text && 
                            row.Cells["representante"].Value.ToString()=="S")
                        {
                            cnpjAnterior = row.Cells["cnpjlocatario"].Value.ToString();
                            row.Cells["representante"].Value = "N";
                        }
                    }

                    //recalcula o percentual do representante anterior
                    //calcula as participações
                    double soma = 0;
                    double novoPercentual = 0;
                    double somaAluguel = 0;
                    double novoAluguel = 0;
                    foreach (DataGridViewRow row in grdLocatario.Rows)
                    {
                        if (row.Cells["cnpjlocatario"].Value.ToString() != cnpjAnterior)
                        {
                            soma += EmcResources.cDouble(row.Cells["participacao"].Value.ToString());
                            somaAluguel += EmcResources.cDouble(row.Cells["vlraluguelreceber"].Value.ToString());
                        }
                    }

                    novoPercentual = Math.Round((100 - soma), 4);
                    novoAluguel = Math.Round(txtValorAluguel.Value - somaAluguel, 2); 

                    //atualiza representante anterior
                    foreach (DataGridViewRow row in grdLocatario.Rows)
                    {
                        if (row.Cells["cnpjlocatario"].Value.ToString() == cnpjAnterior)
                        {
                            row.Cells["participacao"].Value = novoPercentual;
                            row.Cells["vlraluguelreceber"].Value = novoAluguel;
                        }
                    }

                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void cboLocatarioRateio_Validating(object sender, CancelEventArgs e)
        {
            if (cboLocatarioRateio.SelectedIndex > -1)
            {
                if (cboLocatarioRateio.SelectedValue =="I")
                {
                    txtLocatarioParticipacao.Text = "100";
                    txtLocatarioParticipacao.Enabled = false;
                    panLocatario.Enabled = false;
                }
                else
                {
                    txtLocatarioParticipacao.Text = "0";
                    txtLocatarioParticipacao.Enabled = true;
                    panLocatario.Enabled = true;
                }

            }
        }

        private void txtLocatarioParticipacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                insereRepresentanteGrid();
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void cboLocatarioFormaPagto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(cboLocatarioFormaPagto.SelectedIndex >-1)
                {
                    if (txtDataInicial.DateValue is DateTime)
                    {

                        //inicializa variavel para calculo do vencimento da 1a.parcela
                        DateTime dataVenc1Parcela = DateTime.Now;

                        if (cboLocatarioFormaPagto.SelectedValue.ToString() == "A")
                        {
                            /* Antecipado */
                            dataVenc1Parcela = Convert.ToDateTime(txtDataInicial.Text);
                        }
                        else
                        {
                            /* Não Antecipado */

                            //adiciona 30 dias ao vencimento da primeira parcela.
                            dataVenc1Parcela = Convert.ToDateTime(txtDataInicial.Text);
                            dataVenc1Parcela = dataVenc1Parcela.AddDays(30);
                        }

                        //Se cair no ultimo dia do mês


                        //Verifica Feriado
                        FeriadoRN oFeriadoRN = new FeriadoRN(Conexao, objOcorrencia, codempresa);
                        dataVenc1Parcela = oFeriadoRN.diaUtil(dataVenc1Parcela);

                        //Exibe a data Calculada
                        txtData1Parcela.Text = dataVenc1Parcela.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Preencher o período aquisitivo do contrato", "Aviso", MessageBoxButtons.OK);
                    }
                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDiaFixoLocatario_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //verifica se o dia digitado é um valor valido
                if (EmcResources.cInt(txtDiaFixoLocatario.Text)>=1 && 
                    EmcResources.cInt(txtDiaFixoLocatario.Text)<=31)
                {

                    //Verifica se o dia Fixo está no mês seguinte a data da 1a parcela calculada
                    DateTime data1Parcela = Convert.ToDateTime(txtData1Parcela.Text);
                    DateTime dataProprocional = data1Parcela;
                    string dia = "";
                    string mes = "";
                    string ano = "";
                    TimeSpan diasProporcionais;

                    if (!String.IsNullOrEmpty(txtDiaFixoLocatario.Text))
                    {
                        //verifica se o dia fixo é anterior ao dia do vencimento calculado
                        if (data1Parcela.Day > EmcResources.cInt(txtDiaFixoLocatario.Text))
                        {
                            dia = txtDiaFixoLocatario.Text;
                            mes = (dataProprocional.Month+1).ToString();
                            ano ="";
                            if (dataProprocional.Month == 12)
                            {
                                ano = (dataProprocional.Year+1).ToString();
                            }
                            else
                                ano = dataProprocional.Year.ToString();

                            //se o dia proporcional for 30 ou 31 verifica o ultimo dia do mês
                            if (dia == "30" || dia == "31")
                            {
                                if (EmcResources.cInt(mes) == 2)
                                {
                                    dia = "28";
                                }
                                else if (EmcResources.cInt(mes) == 1 ||
                                         EmcResources.cInt(mes) == 3 ||
                                         EmcResources.cInt(mes) == 5 ||
                                         EmcResources.cInt(mes) == 7 ||
                                         EmcResources.cInt(mes) == 8 ||
                                         EmcResources.cInt(mes) == 10 ||
                                         EmcResources.cInt(mes) == 12)
                                {
                                    dia = "31";
                                }
                                else if (EmcResources.cInt(mes) == 4 ||
                                         EmcResources.cInt(mes) == 6 ||
                                         EmcResources.cInt(mes) == 9 ||
                                         EmcResources.cInt(mes) == 11)
                                {
                                    dia = "30";
                                }
                            }

                            //fica para o proximo mês
                            dataProprocional = Convert.ToDateTime(dia+"/"+mes+"/" +ano);
                        }
                        else
                        {
                            //dentro do mês
                            dia = txtDiaFixoLocatario.Text;
                            mes = dataProprocional.Month.ToString();
                            ano = dataProprocional.Year.ToString(); 
                                
                            //fica para o proximo mês
                            dataProprocional = Convert.ToDateTime(dia + "/" + mes + "/" + ano);
                        }

                        diasProporcionais = dataProprocional.Subtract(data1Parcela);

                        txtDataProporcional.Text = dataProprocional.ToString();

                        txtDiasProporcionais.Text = diasProporcionais.Days.ToString();

                        txtValorProporcional.Text =((EmcResources.cCur(txtValorAluguel.Value.ToString()) / 30) * diasProporcionais.Days).ToString();

                    }


                }
                else
                {
                    if (!String.IsNullOrEmpty(txtDiaFixoLocatario.Text))
                    {
                        MessageBox.Show("Dia invalido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDiasProporcionais_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                txtValorProporcional.Text = ((EmcResources.cCur(txtValorAluguel.Value.ToString()) / 30) * EmcResources.cCur(txtDiasProporcionais.Text)).ToString();

            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDtaEntradaInicio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDtaEntradaInicio.DateValue >= txtDtaEntradaFinal.DateValue)
                {
                    MessageBox.Show("Período da Entrada do contrato, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDtaEntradaInicio.Focus();
                }
                else if (txtDtaEntradaInicio.DateValue is DateTime && txtDtaEntradaFinal.DateValue is DateTime)
                {
                    /****** Calcula a diferença entre as data em meses *****/

                    DateTime dataInicio = Convert.ToDateTime(txtDtaEntradaInicio.DateValue);
                    DateTime dataFinal = Convert.ToDateTime(txtDtaEntradaFinal.DateValue);

                    TimeSpan datadif = dataFinal.Subtract(dataInicio);

                    int nroDias = datadif.Days+1;

                    //ajusta nro de dias ao mes comercial
                    if (nroDias >= 30)
                    {
                        nroDias = Math.Abs(nroDias / 30) * 30;

                        if (dataFinal.Month == 2)
                        {
                            nroDias += 30;
                        }
                    }

                    //CALCULA VALOR DA ENTRADA
                    txtValorEntrada.Text = ((txtValorAluguel.Value/30) * Math.Abs(nroDias)).ToString();

                    //RECALCULADA NRO DE PARCELAS
                    txtSaldoContratoParcela.Text = (txtValorTotalContrato.Value - txtValorEntrada.Value).ToString();
                    txtNroParcelas.Text = (EmcResources.cInt(txtNroParcelas.Text) - Math.Abs((nroDias / 30))).ToString();
                    txtValorMensal.Text = (txtSaldoContratoParcela.Value / EmcResources.cDouble(txtNroParcelas.Text)).ToString();
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDtaEntradaFinal_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDtaEntradaInicio.DateValue >= txtDtaEntradaFinal.DateValue)
                {
                    MessageBox.Show("Período da Entrada do contrato, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDtaEntradaInicio.Focus();
                }
                else if (txtDtaEntradaInicio.DateValue is DateTime && txtDtaEntradaFinal.DateValue is DateTime)
                {
                    /****** Calcula a diferença entre as data em meses *****/

                    DateTime dataInicio = Convert.ToDateTime(txtDtaEntradaInicio.DateValue);
                    DateTime dataFinal = Convert.ToDateTime(txtDtaEntradaFinal.DateValue);

                    TimeSpan datadif = dataFinal.Subtract(dataInicio);

                    int nroDias = datadif.Days+1;

                    //ajusta nro de dias ao mes comercial
                    if (nroDias >= 30)
                    {
                        nroDias = Math.Abs(nroDias / 30) * 30;

                        if (dataFinal.Month == 2)
                        {
                            nroDias += 30;
                        }
                    }
                    

                    //CALCULA VALOR DA ENTRADA
                    txtValorEntrada.Text = ((txtValorAluguel.Value/30) * Math.Abs(nroDias)).ToString();

                    //RECALCULADA NRO DE PARCELAS
                    txtSaldoContratoParcela.Text = (txtValorTotalContrato.Value - txtValorEntrada.Value).ToString();
                    txtNroParcelas.Text = (EmcResources.cInt(txtNroParcelas.Text)-Math.Abs((nroDias/30))).ToString();
                    txtValorMensal.Text = (txtSaldoContratoParcela.Value / EmcResources.cDouble(txtNroParcelas.Text)).ToString();

                }


            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtValorEntrada_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtValorEntrada.Value > 0)
                {
                    txtSaldoContratoParcela.Text = (txtValorTotalContrato.Value - txtValorEntrada.Value).ToString();
                    txtValorMensal.Text = (txtSaldoContratoParcela.Value / EmcResources.cDouble(txtNroParcelas.Text)).ToString();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDataInicioDesconto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDataInicioDesconto.DateValue >= txtDataFinalDesconto.DateValue)
                {
                    MessageBox.Show("Período de desconto, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataInicioDesconto.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDataFinalDesconto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDataInicioDesconto.DateValue >= txtDataFinalDesconto.DateValue)
                {
                    MessageBox.Show("Período de desconto, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataInicioDesconto.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void cboTemCarencia_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(cboTemCarencia.SelectedIndex >-1)
                {
                    DateTime data1Parcela = Convert.ToDateTime(txtData1Parcela.Text);

                    if (cboTemCarencia.SelectedValue.ToString() == "S")
                    {
                        txtDiasCarencia.Enabled = true;
                        txtDiasCarencia.Text = "0";
                    }
                    else
                    {
                        txtDiasCarencia.Enabled = false;
                        txtDiasCarencia.Text = "0";
                    }
                    txtData1ParcelaCarencia.Text = data1Parcela.AddDays(EmcResources.cInt(txtDiasCarencia.Text)).ToString();
                    txtDiasCarencia.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtDiasCarencia_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime data1Parcela = Convert.ToDateTime(txtData1Parcela.Text);

                txtData1ParcelaCarencia.Text = data1Parcela.AddDays(EmcResources.cInt(txtDiasCarencia.Text)).ToString();
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtTaxaJuros_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                tabContrato.SelectedTab = tabDadosLocador;
                cboLocadorRateio.Focus();
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtNroParcelas_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                txtValorMensal.Text = (EmcResources.cCur(txtSaldoContratoParcela.Value.ToString()) / EmcResources.cCur(txtNroParcelas.Text)).ToString();
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }
        #endregion

        #region "Tratamento de Campos - Tab - Aba de Locadores"

        private void btnCalculoContrato_Click(object sender, EventArgs e)
        {
            //realiza calculo simulado do contrato.
            try
            {
                limpaGridsRecalculo();
                mostraAbas();
                calculaContrato();
            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
            
        }

        private void carregaLocadoresImovel()
        {
            try
            {
                // Faz a busca na tabela imovel_prorietario para carregar na grid as participação societária do imóvel
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void cboLocadorRateio_Enter(object sender, EventArgs e)
        {

        }

        private void cboLocadorRateio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLocadorRateio.SelectedIndex > -1 && EmcResources.cInt(txtIdImovel.Text) > 0)
                {
                    if (grdLocador.Rows.Count > 0)
                         grdLocador.Rows.Clear();

                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);

                    oImovel = oImovelRN.ObterPor(oImovel);
                    
                    ArrayList arrProprietario = new ArrayList();
                    foreach (ImovelProprietario oProprietario in oImovel.lstProprietario)
                    {
                        /*
                        * Contrato Individual - Carrega a combo de locador apenas com o representante do imovel e a
                        * grid também apenas com o proprietário representante e com part. na parcela 100% e não permite
                        * alterações na participação
                        */
                      
                        /*
                         * Contrato Vário Locadores - Carrega a grid com todos os proprietários do imóvel e a combo
                         * com o proprietário representante. E não permite alterações na participação
                         */

                     
                        
                        //define quais elementos entram na combo de locador representante.
                        if (cboLocadorRateio.SelectedValue.ToString() == "C" || 
                            (cboLocadorRateio.SelectedValue.ToString()=="I" && oProprietario.representante=="S"))
                        {
                            double percRateio;

                            //adiciona a combo de representante
                            arrProprietario.Add(new popCombo(oProprietario.idProprietario.pessoa.nome, oProprietario.idProprietario.idPessoa.ToString()));

                            //se o contrato for por representante o perc. rateio é 100%
                            if (cboLocadorRateio.SelectedValue.ToString() == "C")
                                percRateio = oProprietario.participacao;
                            else
                                percRateio = 100;

                            if (stOperacao == "I")
                            {
                                //adiciona a grid de participantes
                                grdLocador.Rows.Add(oProprietario.idProprietario.pessoa.cnpjCpf,
                                                   oProprietario.idProprietario.pessoa.idPessoa,
                                                   oProprietario.idProprietario.pessoa.nome,
                                                   percRateio,
                                                   0,
                                                   "A",
                                                   "I",
                                                   oProprietario.idProprietario.pessoa.codEmpresa,
                                                   0,
                                                   0);
                            }
                        }


                    }

                    cboIdLocadorRepresentante.DataSource = arrProprietario;
                    cboIdLocadorRepresentante.DisplayMember = "nome";
                    cboIdLocadorRepresentante.ValueMember = "valor";

                    calculaAluguelLocador();

                    cboIdLocadorRepresentante.Focus();

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }
        
        public void calculaAluguelLocador()
        {
            try
            {
                //pega valor do aluguel
                double valorAluguelTotal = EmcResources.cDouble(txtValorAluguel.Value.ToString());
                int nroParticipantes = grdLocador.Rows.Count;

                double valorAluguel = 0;
                double somaAluguel = 0;
                foreach(DataGridViewRow orow in grdLocador.Rows)
                {
                    if (nroParticipantes == 1)
                    {
                        valorAluguel = valorAluguelTotal - somaAluguel;
                    }
                    else
                    {
                        valorAluguel = Math.Round(((valorAluguelTotal*EmcResources.cDouble(orow.Cells["percparticipacao"].Value.ToString()))/100),2);
                        somaAluguel += valorAluguel;
                    }

                    orow.Cells["valoraluguel"].Value = valorAluguel;

                    valorAluguel = 0;

                    nroParticipantes--;
                }


            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void cboIdLocadorRepresentante_Validating(object sender, CancelEventArgs e)
        {
            cboLocadorFormaPagamento.Focus();
        }

        private void cboLocadorFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboLocadorFormaPagamento.SelectedIndex > -1)
                {

                    if (cboLocadorFormaPagamento.SelectedValue.ToString() == "N")
                    {
                        txtNroDiasPagamento.Enabled = true;
                        txtDiaFixoPagamento.Enabled = false;

                        txtNroDiasPagamento.Focus();
                    }
                    else
                    {
                        txtNroDiasPagamento.Enabled = false;
                        txtDiaFixoPagamento.Enabled = true;

                        txtDiaFixoPagamento.Focus();
                    }
                }      
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtTaxaAdministracao_Validating(object sender, CancelEventArgs e)
        {
            btnCalculoContrato.Focus();
        }

        #endregion

        #region Carregamento de Informações nas grids
        private void limpaGrids()
        {
            grdCCReceber.Rows.Clear();
            grdLocacaoReceber.Rows.Clear();
            grdLocatario.Rows.Clear();
            grdLocador.Rows.Clear();
            grdFiador.Rows.Clear();
            grdCCPagar.Rows.Clear();
            grdLocacaoPagar.Rows.Clear();
        }

        private void limpaGridsRecalculo()
        {
            grdCCReceber.Rows.Clear();
            grdLocacaoReceber.Rows.Clear();
            grdCCPagar.Rows.Clear();
            grdLocacaoPagar.Rows.Clear();
        }

        private void montaGridLocatario(List<LocacaoCliente> lstCliente)
        {
            try
            {
                foreach (LocacaoCliente oCliente in lstCliente)
                {

                    grdLocatario.Rows.Add(oCliente.locatario.pessoa.cnpjCpf, 
                                          oCliente.locatario.pessoa.idPessoa, 
                                          oCliente.locatario.pessoa.nome, 
                                          oCliente.valorAluguel,
                                          oCliente.percParticipacao, 
                                          oCliente.representante,
                                          oCliente.situacao, 
                                          "", 
                                          oCliente.idLocacaoCliente);

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void montaGridLocador(List<LocacaoFornecedor> lstFornecedor)
        {
            try
            {
                foreach (LocacaoFornecedor oProprietario in lstFornecedor)
                {

                    grdLocador.Rows.Add(oProprietario.locador.pessoa.cnpjCpf,
                                        oProprietario.locador.pessoa.idPessoa,
                                        oProprietario.locador.pessoa.nome,
                                        oProprietario.percParticipacao,
                                        oProprietario.valorAluguel,
                                        oProprietario.situacao,
                                        "",
                                        oProprietario.locador.pessoa.codEmpresa,
                                        oProprietario.idLocacaoContrato,
                                        oProprietario.idLocacaoFornecedor);

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void montaGridFiador(List<LocacaoFiador> lstFiador)
        {
            try
            {
                foreach (LocacaoFiador oFiador in lstFiador)
                {

                    grdFiador.Rows.Add(oFiador.fiador.pessoa.cnpjCpf,
                                        oFiador.fiador.pessoa.idPessoa,
                                        oFiador.fiador.pessoa.nome,
                                        oFiador.situacao,
                                        "",
                                        oFiador.idLocacaoFiador);

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void montaGridReceber(List<LocacaoReceber> lstReceber)
        {
            try
            {
                foreach(LocacaoReceber oParcela in lstReceber)
                {
                    
                    grdLocacaoReceber.Rows.Add(oParcela.locatario.pessoa.nome,
                                               oParcela.locatario.pessoa.idPessoa,
                                               oParcela.nroParcela,
                                               oParcela.dataVencimento,
                                               oParcela.dataCarencia,
                                               oParcela.periodoInicio,
                                               oParcela.periodoFim,
                                               oParcela.valorParcela,
                                               oParcela.valorPago,
                                               oParcela.valorJuros,
                                               oParcela.valorDesconto,
                                               oParcela.situacao,
                                               oParcela.dataIntegracao.ToString(),
                                               oParcela.statusOperacao,
                                               oParcela.diasCarencia,
                                               oParcela.idLocacaoContrato,
                                               oParcela.idLocacaoReceber,
                                               oParcela.percParticipacao,
                                               oParcela.valorJurosCalculado);

                    montagridCCReceber(oParcela.lstCtaCorrente);
                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void montagridCCReceber(List<LocacaoCCReceber> lstCCReceber)
        {
            try
            {
                foreach (LocacaoCCReceber oCta in lstCCReceber)
                {
                    grdCCReceber.Rows.Add(oCta.locatario.pessoa.nome,
                                               oCta.locatario.pessoa.idPessoa,
                                               oCta.nroParcela,
                                               oCta.provento.Descricao,
                                               oCta.provento.idLocacaoProventos,
                                               oCta.tipoProvento,
                                               oCta.dataLancamento,
                                               oCta.valorLancamento,
                                               oCta.situacao,
                                               oCta.statusOperacao,
                                               oCta.locatario.pessoa.codEmpresa,
                                               oCta.dataEmissao,
                                               oCta.idLocacaoContrato,
                                               oCta.descricao,
                                               oCta.idLocacaoReceber,
                                               oCta.idLocacaoCCReceber);
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void montaGridPagar(List<LocacaoPagar> lstPagar)
        {
            try
            {
                foreach (LocacaoPagar oParcela in lstPagar)
                {
                    grdLocacaoPagar.Rows.Add(oParcela.locador.pessoa.nome,
                                               oParcela.locador.pessoa.idPessoa,
                                               oParcela.nroParcela,
                                               oParcela.dataVencimento,
                                               oParcela.periodoInicio,
                                               oParcela.periodoFim,
                                               oParcela.valorParcela,
                                               oParcela.valorPago,
                                               oParcela.valorDesconto,
                                               oParcela.valorJuros,
                                               oParcela.situacao,
                                               oParcela.dataIntegracao.ToString(),
                                               oParcela.statusOperacao,
                                               oParcela.idLocacaoContrato,
                                               oParcela.idLocacaoPagar,
                                               oParcela.percParticipacao,
                                               oParcela.valorJurosCalculado);

                    montagridCCPagar(oParcela.lstCtaCorrente);
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void montagridCCPagar(List<LocacaoCCPagar> lstCCPagar)
        {
            try
            {
                foreach (LocacaoCCPagar oCta in lstCCPagar)
                {
                    grdCCPagar.Rows.Add(oCta.locador.pessoa.nome,
                                               oCta.locador.pessoa.idPessoa,
                                               oCta.nroParcela,
                                               oCta.provento.Descricao,
                                               oCta.provento.idLocacaoProventos,
                                               oCta.tipoProvento,
                                               oCta.dataLancamento,
                                               oCta.valorLancamento,
                                               oCta.situacao,
                                               oCta.statusOperacao,
                                               oCta.locador.pessoa.codEmpresa,
                                               oCta.dataEmissao,
                                               oCta.idLocacaoCCPagar,
                                               oCta.descricao,
                                               oCta.idLocacaoPagar,
                                               oCta.idLocacaoContrato);
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        #endregion

        #region "Calculo do Contrato"

        private void calculaContrato()
        {
            bool temEntrada = false;
            bool temProporcional = false;
            int totalParcelas = 0;
            int nroParcela = 0;

            try
            {
                totalParcelas = EmcResources.cInt(txtNroParcelas.Text);
                if (txtValorEntrada.Value > 0)
                {
                    temEntrada = true;
                    totalParcelas++;
                }

                if (txtValorProporcional.Value > 0)
                {
                    temProporcional = true;
                    totalParcelas++;
                }

                // Localiza imovel
                Imovel oImovel = new Imovel();
                oImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);

                ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                oImovel = oImovelRN.ObterPor(oImovel);

                /* 
                 * Gera Parcelas para o locatário com seus respectivos proventos
                 */

                //Cria uma lista de parcelas locatário
                List<LocacaoReceber> lstReceber = new List<LocacaoReceber>();
                List<LocacaoCCReceber> lstCCReceber;

                //percorre a grid de locatarios que participam do contrato para gerar o parcelamento para cada contrato
                int contaParcelas = 0;
                double vlrAluguel = 0;
                double percPart = 0;
                double valorParcela = 0;

                double valorCondominio = EmcResources.cDouble(oImovel.valorCondominio.ToString());
                double valorCondominioLocatario = valorCondominio;
                double totCondominio = 0;

                double valorDesconto = txtValorDescontoConcedido.Value;
                double valorDescontoLocatario = valorDesconto;
                double totDesconto = 0;

                double valorEntrada = txtValorEntrada.Value;
                double valorEntradaLocatario = valorEntrada;
                double totEntrada = 0;

                double valorProporc = txtValorProporcional.Value;
                double valorProporcionalLocatario = valorProporc;
                double totProporcional = 0;

                int diasProporcionais = EmcResources.cInt(txtDiasProporcionais.Text);
                double valorProporcional = EmcResources.cDouble(txtValorProporcional.Value.ToString());
                DateTime periodoInicio = Convert.ToDateTime(txtDataInicial.Text);
                DateTime periodoFinal = Convert.ToDateTime(txtDataInicial.Text);
                DateTime dtaVencimentobk = Convert.ToDateTime(txtData1Parcela.Text);

                if (EmcResources.cInt(txtDiaFixoLocatario.Text) > 0)
                {
                    dtaVencimentobk = Convert.ToDateTime(txtDataProporcional.Text);
                }

                LocacaoReceber oReceber;

                LocacaoProventos oProvento;
                LocacaoProventosRN oProventoRN = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);

                Cliente oLocatario;
                ClienteRN oLocatarioRN = new ClienteRN(Conexao, objOcorrencia, codempresa);

                FeriadoRN oFeriadoRN = new FeriadoRN(Conexao, objOcorrencia, codempresa);

                int contalocatario = 0;
                bool controleProporc_PerAquisitivo = false;
                bool controleEntrada_PerAquisitivo = false;

                foreach (DataGridViewRow oRow in grdLocatario.Rows)
                {
                    //reinicia a contagem de parcelas para um novo locatário.
                    contaParcelas = 0;
                    contalocatario++;

                    vlrAluguel = EmcResources.cDouble(oRow.Cells["vlraluguelreceber"].Value.ToString());
                    percPart = EmcResources.cDouble(oRow.Cells["participacao"].Value.ToString());

                    if (contalocatario == grdLocatario.Rows.Count)
                    {
                        valorCondominioLocatario = valorCondominio - totCondominio;
                        valorEntradaLocatario = valorEntrada - totEntrada;
                        valorDescontoLocatario = valorDesconto - totDesconto;
                        valorProporcionalLocatario = valorProporc - totProporcional;
                    }
                    else
                    {
                        valorCondominioLocatario = Math.Round((valorCondominio * percPart) / 100, 2);
                        totCondominio = totCondominio + valorCondominioLocatario;

                        valorDescontoLocatario = Math.Round((valorDesconto * percPart) / 100, 2);
                        totDesconto = totDesconto + valorDescontoLocatario;

                        valorEntradaLocatario = Math.Round((valorEntrada * percPart) / 100, 2);
                        totEntrada = totEntrada + valorEntradaLocatario;

                        valorProporcionalLocatario = Math.Round((valorProporc * percPart) / 100, 2);
                        totProporcional = totProporcional + valorProporcionalLocatario;

                    }

                    //localiza o locatario cliente
                    oLocatario = new Cliente();
                    oLocatario.codEmpresa = empMaster;
                    oLocatario.idPessoa = EmcResources.cInt(oRow.Cells["idlocatario"].Value.ToString());
                    oLocatario = oLocatarioRN.ObterPor(oLocatario);

                    periodoInicio = Convert.ToDateTime(txtDataInicial.DateValue.ToString());
                    periodoFinal = Convert.ToDateTime(txtDataInicial.DateValue.ToString());

                    if (temEntrada)
                    {
                        //Calculo do Periodo Aquisitivo
                        periodoInicio = Convert.ToDateTime(txtDtaEntradaInicio.Text);
                        periodoFinal = Convert.ToDateTime(txtDtaEntradaFinal.Text);

                        /* Gerar a Parcela de Entrada do Contrato na data de assinatura do contrato */
                        contaParcelas++;

                        valorParcela = valorEntradaLocatario;

                        lstCCReceber = new List<LocacaoCCReceber>();
                        //geração de proventos para o locatario ref. entrada

                        // Lancto Aluguel Locatario
                        LocacaoCCReceber oEntAluguel = new LocacaoCCReceber();
                        oEntAluguel.dataEmissao = Convert.ToDateTime(txtDataInicial.Text);
                        oEntAluguel.dataLancamento = Convert.ToDateTime(txtDataInicial.Text);
                        oEntAluguel.descricao = "Valor Entrada Aluguel locatario";
                        oEntAluguel.idLocacaoCCReceber = 0;
                        oEntAluguel.idLocacaoContrato = 0;
                        oEntAluguel.idLocacaoReceber = 0;
                        oEntAluguel.locatario = oLocatario;

                        oProvento = new LocacaoProventos();
                        oProvento.idLocacaoProventos = alug_locatario;
                        oEntAluguel.provento = oProventoRN.ObterPor(oProvento);

                        oEntAluguel.situacao = "A";
                        oEntAluguel.statusOperacao = "I";
                        oEntAluguel.tipoProvento = oEntAluguel.provento.TipoProvento;
                        oEntAluguel.valorLancamento = EmcResources.cCur(valorParcela.ToString());
                        oEntAluguel.nroParcela = contaParcelas;

                        lstCCReceber.Add(oEntAluguel);


                        //Montagem da parcela locatario - entrada
                        oReceber = new LocacaoReceber();
                        oReceber.idLocacaoReceber = 0;
                        oReceber.idLocacaoContrato = 0;
                        oReceber.locatario = oLocatario;
                        oReceber.nroParcela = 1;
                        oReceber.dataVencimento = Convert.ToDateTime(txtDataInicial.Text);
                        oReceber.dataIntegracao = null;
                        oReceber.diasCarencia = 0;
                        oReceber.dataCarencia = oReceber.dataVencimento;
                        oReceber.percParticipacao = percPart;
                        oReceber.valorParcela = EmcResources.cCur(valorParcela.ToString());
                        oReceber.situacao = "A";
                        oReceber.statusOperacao = "I";
                        oReceber.periodoInicio = periodoInicio;
                        oReceber.periodoFim = periodoFinal;
                        oReceber.lstCtaCorrente = lstCCReceber;
                        oReceber.valorPago = 0;
                        oReceber.valorJurosCalculado = 0;
                        oReceber.valorJuros = 0;
                        oReceber.valorDesconto = 0;

                        lstReceber.Add(oReceber);

                        //Recalcula Periodo para a 1a parcela normal do contrato.
                        if (EmcResources.cInt(txtNroParcelas.Text) == EmcResources.cInt(txtNroMeses.Text))
                        {
                            periodoInicio = Convert.ToDateTime(txtDataInicial.DateValue.ToString());
                            periodoFinal = Convert.ToDateTime(txtDataInicial.DateValue.ToString());
                        }
                        else
                        {
                            periodoInicio = periodoFinal.AddDays(1);
                            periodoFinal = periodoFinal.AddMonths(1);
                            //set o flag para a geração do 1o periodo aquisitivo do parcelamento normal.
                            controleEntrada_PerAquisitivo = true;
                        }
                       
                    }

                    if (temProporcional)
                    {
                        /* Gerar a Parcela de Entrada do Contrato na data de assinatura do contrato */
                        contaParcelas++;

                        valorParcela = valorProporcionalLocatario;

                        lstCCReceber = new List<LocacaoCCReceber>();
                        //geração de proventos para o locatario ref. parcela proporcional
                        // Lancto Aluguel Locatario
                        LocacaoCCReceber oProporcional = new LocacaoCCReceber();
                        oProporcional.dataEmissao = Convert.ToDateTime(txtDataInicial.Text);
                        oProporcional.dataLancamento = Convert.ToDateTime(txtDataInicial.Text);
                        oProporcional.descricao = "Valor Proporcional Aluguel locatario";
                        oProporcional.idLocacaoCCReceber = 0;
                        oProporcional.idLocacaoContrato = 0;
                        oProporcional.idLocacaoReceber = 0;
                        oProporcional.locatario = oLocatario;

                        oProvento = new LocacaoProventos();
                        oProvento.idLocacaoProventos = alug_locatario;
                        oProporcional.provento = oProventoRN.ObterPor(oProvento);

                        oProporcional.situacao = "A";
                        oProporcional.statusOperacao = "I";
                        oProporcional.tipoProvento = oProporcional.provento.TipoProvento;
                        oProporcional.valorLancamento = EmcResources.cCur(valorParcela.ToString());
                        oProporcional.nroParcela = contaParcelas;

                        lstCCReceber.Add(oProporcional);

                        //Calculo da Data Final do Período Aquisitivo para proporcionalidade
                        periodoFinal = periodoFinal.AddDays(diasProporcionais - 1);


                        //Montagem da parcela locatario - entrada
                        oReceber = new LocacaoReceber();
                        oReceber.idLocacaoReceber = 0;
                        oReceber.idLocacaoContrato = 0;
                        oReceber.locatario = oLocatario;
                        oReceber.nroParcela = 1;
                        oReceber.dataVencimento = Convert.ToDateTime(txtDataInicial.Text);
                        oReceber.dataIntegracao = null;
                        oReceber.diasCarencia = 0;
                        oReceber.dataCarencia = oReceber.dataVencimento;
                        oReceber.percParticipacao = percPart;
                        oReceber.valorParcela = EmcResources.cCur(valorParcela.ToString());
                        oReceber.situacao = "A";
                        oReceber.statusOperacao = "I";
                        oReceber.periodoInicio = periodoInicio;
                        oReceber.periodoFim = periodoFinal;
                        oReceber.lstCtaCorrente = lstCCReceber;
                        oReceber.valorPago = 0;
                        oReceber.valorJurosCalculado = 0;
                        oReceber.valorJuros = 0;
                        oReceber.valorDesconto = 0;

                        lstReceber.Add(oReceber);

                        //recalcula periodo aquisito para proximas parcelas
                        periodoInicio = periodoFinal.AddDays(1);
                        periodoFinal = periodoFinal.AddMonths(1);
                        //set o flag para a geração do 1o periodo aquisitivo do parcelamento normal.
                        controleProporc_PerAquisitivo = true;


                    }

                    //Geração demais parcelas do contrato
                    int conta = 1;
                    string dia = txtDiaFixoLocatario.Text;
                    DateTime dtaVencimento = dtaVencimentobk;


                    while (contaParcelas < totalParcelas)
                    {
                        valorParcela = 0;

                        //Calcula data Vencimento
                        if (conta > 1)
                        {
                            //adiciona 30 dias a data anterior
                            dtaVencimento = dtaVencimento.AddDays(30);
                        }

                        //se for dia fixo 
                        if (EmcResources.cInt(txtDiaFixoLocatario.Text) > 0 &&
                            !dtaVencimento.Day.Equals(EmcResources.cInt(txtDiaFixoLocatario.Text)))
                        {

                            if (txtDiaFixoLocatario.Text == "30" ||
                                txtDiaFixoLocatario.Text == "31")
                            {
                                dtaVencimento = Convert.ToDateTime(DateTime.DaysInMonth(dtaVencimento.Year, dtaVencimento.Month) + "/" +
                                                                   dtaVencimento.Month + "/" + dtaVencimento.Year);
                            }
                            else
                            {
                                dtaVencimento = Convert.ToDateTime(txtDiaFixoLocatario.Text.Trim() + "/" +
                                                                   dtaVencimento.Month + "/" + dtaVencimento.Year);
                            }
                        }

                        //verifica se da vencimento é dia util é dia util
                        dtaVencimento = oFeriadoRN.diaUtil(dtaVencimento);



                        //Calculo do Período Aquisitivo
                        if (periodoFinal.Equals(periodoInicio))
                        {
                            periodoFinal = periodoInicio.AddDays(30);
                        }
                        else if (controleProporc_PerAquisitivo || controleEntrada_PerAquisitivo)
                        {
                            //se tiver proporcionalidade na primeira vez que passar não recalcula o periodo aquisitivo.

                            //seta o flag para não entrar novamente.
                            controleProporc_PerAquisitivo = false;

                            //seta o flag para não entrar novamente.
                            controleEntrada_PerAquisitivo = false;
                        }
                        else
                        {
                            periodoInicio = periodoInicio.AddMonths(1);
                            periodoFinal = periodoFinal.AddMonths(1);

                            if (periodoFinal > Convert.ToDateTime(txtDataFinal.Text))
                            {
                                periodoFinal = Convert.ToDateTime(txtDataFinal.Text);
                            }
                        }
                        //se o dia do inicio do periodo for dia 1 obrigatoriamente o fim do periodo tem que ser o ultimo dia do mês
                        if (periodoInicio.Day == 1)
                        {
                            periodoFinal = Convert.ToDateTime(DateTime.DaysInMonth(periodoInicio.Year, periodoInicio.Month) + "/" +
                                                              periodoInicio.Month + "/" + periodoInicio.Year);
                        }


                        /* Gerar a Parcela do Contrato  */
                        contaParcelas++;
                        valorParcela = vlrAluguel;

                        //ajusta a ultima parcela com o desconto da proporcionalidade que já gerou uma parcela de ajuste.
                        if (temProporcional && contaParcelas == totalParcelas)
                        {
                            valorParcela = vlrAluguel - valorProporcionalLocatario;
                        }

                        lstCCReceber = new List<LocacaoCCReceber>();
                        //geração de proventos para o locatario ref. aluguel mensal
                        // Lancto Aluguel Locatario
                        LocacaoCCReceber oAlugLocatario = new LocacaoCCReceber();
                        oAlugLocatario.dataEmissao = periodoInicio;
                        oAlugLocatario.dataLancamento = periodoInicio;
                        oAlugLocatario.descricao = "Valor Aluguel locatario";
                        oAlugLocatario.idLocacaoCCReceber = 0;
                        oAlugLocatario.idLocacaoContrato = 0;
                        oAlugLocatario.idLocacaoReceber = 0;
                        oAlugLocatario.locatario = oLocatario;
                        oAlugLocatario.nroParcela = contaParcelas;

                        oProvento = new LocacaoProventos();
                        oProvento.idLocacaoProventos = alug_locatario;
                        oAlugLocatario.provento = oProventoRN.ObterPor(oProvento);

                        oAlugLocatario.situacao = "A";
                        oAlugLocatario.statusOperacao = "I";
                        oAlugLocatario.tipoProvento = oAlugLocatario.provento.TipoProvento;
                        oAlugLocatario.valorLancamento = EmcResources.cCur(valorParcela.ToString());


                        lstCCReceber.Add(oAlugLocatario);

                        //geração de proventos para o locatario ref. condominio
                        // Lancto Condominio
                        if (cboIntegraCondominio.SelectedValue.ToString() == "S" && oImovel.valorCondominio > 0)
                        {

                            LocacaoCCReceber oCondLocatario = new LocacaoCCReceber();
                            oCondLocatario.dataEmissao = periodoInicio;
                            oCondLocatario.dataLancamento = periodoInicio;
                            oCondLocatario.descricao = "Valor Condominio locatario";
                            oCondLocatario.idLocacaoCCReceber = 0;
                            oCondLocatario.idLocacaoContrato = 0;
                            oCondLocatario.idLocacaoReceber = 0;
                            oCondLocatario.locatario = oLocatario;
                            oCondLocatario.nroParcela = contaParcelas;

                            oProvento = new LocacaoProventos();
                            oProvento.idLocacaoProventos = cond_locatario;
                            oCondLocatario.provento = oProventoRN.ObterPor(oProvento);

                            oCondLocatario.situacao = "A";
                            oCondLocatario.statusOperacao = "I";
                            oCondLocatario.tipoProvento = oCondLocatario.provento.TipoProvento;
                            oCondLocatario.valorLancamento = EmcResources.cCur(valorCondominioLocatario.ToString());

                            valorParcela = valorParcela + valorCondominioLocatario;

                            lstCCReceber.Add(oCondLocatario);
                        }

                        //geração de proventos para o locatario ref. condominio
                        // Lancto Desconto Concedido
                        if ((txtDataInicioDesconto.DateValue is DateTime && txtDataFinalDesconto.DateValue is DateTime) &&
                             (dtaVencimento >= txtDataInicioDesconto.DateValue && dtaVencimento <= txtDataFinalDesconto.DateValue))
                        {
                            LocacaoCCReceber odescLocatario = new LocacaoCCReceber();
                            odescLocatario.dataEmissao = periodoInicio;
                            odescLocatario.dataLancamento = periodoInicio;
                            odescLocatario.descricao = "Valor Condominio locatario";
                            odescLocatario.idLocacaoCCReceber = 0;
                            odescLocatario.idLocacaoContrato = 0;
                            odescLocatario.idLocacaoReceber = 0;
                            odescLocatario.locatario = oLocatario;
                            odescLocatario.nroParcela = contaParcelas;

                            oProvento = new LocacaoProventos();
                            oProvento.idLocacaoProventos = desc_Conc_Locatario;
                            odescLocatario.provento = oProventoRN.ObterPor(oProvento);

                            odescLocatario.situacao = "A";
                            odescLocatario.statusOperacao = "I";
                            odescLocatario.tipoProvento = odescLocatario.provento.TipoProvento;
                            odescLocatario.valorLancamento = EmcResources.cCur(valorDescontoLocatario.ToString());

                            valorParcela = valorParcela - valorDescontoLocatario;

                            lstCCReceber.Add(odescLocatario);
                        }

                        //Montagem da parcela locatario
                        oReceber = new LocacaoReceber();
                        oReceber.idLocacaoReceber = 0;
                        oReceber.idLocacaoContrato = 0;
                        oReceber.locatario = oLocatario;
                        oReceber.nroParcela = contaParcelas;
                        oReceber.dataVencimento = dtaVencimento;
                        oReceber.dataIntegracao = null;
                        oReceber.diasCarencia = EmcResources.cInt(txtDiasCarencia.Text);
                        oReceber.dataCarencia = dtaVencimento.AddDays(oReceber.diasCarencia);
                        oReceber.percParticipacao = percPart;
                        oReceber.valorParcela = EmcResources.cCur(valorParcela.ToString());
                        oReceber.situacao = "A";
                        oReceber.statusOperacao = "I";
                        oReceber.periodoInicio = periodoInicio;
                        oReceber.periodoFim = periodoFinal;
                        oReceber.lstCtaCorrente = lstCCReceber;
                        oReceber.valorPago = 0;
                        oReceber.valorJurosCalculado = 0;
                        oReceber.valorJuros = 0;
                        oReceber.valorDesconto = 0;

                        lstReceber.Add(oReceber);

                        conta++;

                    }

                    montaGridReceber(lstReceber);


                }

                /*
                 * Geração de Parcelamento para o Locador
                 * 
                 */

                //Cria uma lista de parcelas locatário
                List<LocacaoPagar> lstPagar = new List<LocacaoPagar>();
                List<LocacaoCCPagar> lstCCPagar;

                LocacaoPagar oPagar;

                //Pega a taxa de adm atualizada
                double txaADM = EmcResources.cDouble(txtTaxaAdministracao.Value.ToString());
                double valorDescontoLocador = 0;
                int contaLocador = 0;
                DateTime dataVencPagar;

                totDesconto = 0;

                Fornecedor oLocador = new Fornecedor();
                FornecedorRN oLocadorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);

                foreach (DataGridViewRow oRow2 in grdLocador.Rows)
                {
                    //reinicia a contagem de parcelas para um novo locatário.
                    contaParcelas = 0;
                    

                    //localiza o locatario cliente
                    oLocador = new Fornecedor();
                    oLocador.codEmpresa = empMaster;
                    oLocador.idPessoa = EmcResources.cInt(oRow2.Cells["idlocador"].Value.ToString());
                    oLocador = oLocadorRN.ObterPor(oLocador);

                    vlrAluguel = EmcResources.cDouble(oRow2.Cells["valoraluguel"].Value.ToString());
                    percPart = EmcResources.cDouble(oRow2.Cells["percparticipacao"].Value.ToString());

                    if (contaLocador == grdLocatario.Rows.Count)
                    {
                        valorDescontoLocatario = valorDesconto - totDesconto;
                    }
                    else
                    {
                        valorDescontoLocador = Math.Round((valorDesconto * percPart) / 100, 2);
                        totDesconto = totDesconto + valorDescontoLocador;
                    }
                    contaLocador++;

                    int idlocatario = 0;
                    DateTime dtaVencPagar;
                    int nroParcelaPagar = 0;

                    foreach(LocacaoReceber oReceita in lstReceber)
                    {
                        periodoInicio = oReceita.periodoInicio;
                        periodoFinal = oReceita.periodoFim;
                        dtaVencPagar = oReceita.dataVencimento;
                        nroParcelaPagar = oReceita.nroParcela;
                        
                        
                        //ser for a primeira passagem pega o locatario
                        if (idlocatario==0)
                        {
                            idlocatario = oReceita.locatario.pessoa.idPessoa;
                        }

                        //se mudar o locatario encerra o loop
                        if (idlocatario == oReceita.locatario.pessoa.idPessoa)
                        {

                            /* Geração do provento com o valor do aluguel */
                            valorParcela = 0;

                            valorParcela = vlrAluguel;
                            lstCCPagar = new List<LocacaoCCPagar>();
                            // Lancto Aluguel Locador
                            LocacaoCCPagar oAlugLocador = new LocacaoCCPagar();
                            oAlugLocador.dataEmissao = periodoInicio;
                            oAlugLocador.dataLancamento = periodoInicio;
                            oAlugLocador.descricao = "Valor Aluguel locador";
                            oAlugLocador.idLocacaoCCPagar = 0;
                            oAlugLocador.idLocacaoContrato = 0;
                            oAlugLocador.idLocacaoPagar = 0;
                            oAlugLocador.locador = oLocador;
                            oAlugLocador.nroParcela = nroParcelaPagar;

                            oProvento = new LocacaoProventos();
                            oProvento.idLocacaoProventos = alug_Locador;
                            oAlugLocador.provento = oProventoRN.ObterPor(oProvento);

                            oAlugLocador.situacao = "A";
                            oAlugLocador.statusOperacao = "I";
                            oAlugLocador.tipoProvento = oAlugLocador.provento.TipoProvento;
                            oAlugLocador.valorLancamento = EmcResources.cCur(valorParcela.ToString());

                            lstCCPagar.Add(oAlugLocador);

                            /* Geração do provento de desconto concedido */

                            //verifica se a parcela a receber tem desconto concedido.
                            bool verificaDesconto = false;
                            foreach(LocacaoCCReceber oCCRec in oReceita.lstCtaCorrente)
                            {
                                if (oCCRec.provento.idLocacaoProventos == desc_Conc_Locatario)
                                {
                                    verificaDesconto = true;
                                }
                            }

                            //se tiver gera desconto concedido para o locador.
                            if (verificaDesconto)
                            {
                                LocacaoCCPagar odescLocador = new LocacaoCCPagar();
                                odescLocador.dataEmissao = periodoInicio;
                                odescLocador.dataLancamento = periodoInicio;
                                odescLocador.descricao = "Valor Desconto Concedido locador";
                                odescLocador.idLocacaoCCPagar = 0;
                                odescLocador.idLocacaoContrato = 0;
                                odescLocador.idLocacaoPagar = 0;
                                odescLocador.locador = oLocador;
                                odescLocador.nroParcela = nroParcelaPagar;

                                oProvento = new LocacaoProventos();
                                oProvento.idLocacaoProventos = desc_Conc_Locador;
                                odescLocador.provento = oProventoRN.ObterPor(oProvento);

                                odescLocador.situacao = "A";
                                odescLocador.statusOperacao = "I";
                                odescLocador.tipoProvento = odescLocador.provento.TipoProvento;
                                odescLocador.valorLancamento = EmcResources.cCur(valorDescontoLocador.ToString());

                                valorParcela = valorParcela - valorDescontoLocador;

                                lstCCPagar.Add(odescLocador);
                            }

                            /* Gera a Taxa de Administração */

                            double valorTaxaAdmPagar = 0;

                            if (txaADM>0)
                            {
                                //calcula o valor da taxa de administracao 
                                valorTaxaAdmPagar = Math.Round((valorParcela * txaADM) / 100, 2);

                                LocacaoCCPagar oAdmLocador = new LocacaoCCPagar();
                                oAdmLocador.dataEmissao = periodoInicio;
                                oAdmLocador.dataLancamento = periodoInicio;
                                oAdmLocador.descricao = "Valor Taxa Adm locador";
                                oAdmLocador.idLocacaoCCPagar = 0;
                                oAdmLocador.idLocacaoContrato = 0;
                                oAdmLocador.idLocacaoPagar = 0;
                                oAdmLocador.locador = oLocador;
                                oAdmLocador.nroParcela = nroParcelaPagar;

                                oProvento = new LocacaoProventos();
                                oProvento.idLocacaoProventos = idTaxa_adm;
                                oAdmLocador.provento = oProventoRN.ObterPor(oProvento);

                                oAdmLocador.situacao = "A";
                                oAdmLocador.statusOperacao = "I";
                                oAdmLocador.tipoProvento = oAdmLocador.provento.TipoProvento;
                                oAdmLocador.valorLancamento = EmcResources.cCur(valorTaxaAdmPagar.ToString());

                                valorParcela = valorParcela - valorTaxaAdmPagar;

                                lstCCPagar.Add(oAdmLocador);
                            }

                            /*
                             * Calcula da Data Vencimento a Pagar
                             */
                            if (cboLocadorFormaPagamento.SelectedValue.ToString() == "N")
                            {
                                dataVencPagar = oReceita.dataVencimento.AddDays(EmcResources.cInt(txtNroDiasPagamento.Text));
                            }
                            else
                            {
                                dataVencPagar = Convert.ToDateTime(txtDiaFixoPagamento.Text.Trim() + "/" +
                                                                    oReceita.dataVencimento.Month + "/" +
                                                                    oReceita.dataVencimento.Year);
                            }

                            //verifica se da vencimento é dia util é dia util
                            dataVencPagar = oFeriadoRN.diaUtil(dataVencPagar);


                            //Montagem da parcela locador
                            oPagar = new LocacaoPagar();
                            oPagar.idLocacaoPagar = 0;
                            oPagar.idLocacaoContrato = 0;
                            oPagar.locador = oLocador;
                            oPagar.nroParcela = nroParcelaPagar;
                            oPagar.dataVencimento = dataVencPagar;
                            oPagar.dataIntegracao = null;
                            oPagar.percParticipacao = percPart;
                            oPagar.valorParcela = EmcResources.cCur(valorParcela.ToString());
                            oPagar.situacao = "A";
                            oPagar.statusOperacao = "I";
                            oPagar.periodoInicio = periodoInicio;
                            oPagar.periodoFim = periodoFinal;
                            oPagar.lstCtaCorrente = lstCCPagar;
                            oPagar.valorJuros = 0;
                            oPagar.valorDesconto = 0;
                            oPagar.valorJurosCalculado = 0;
                            oPagar.valorPago = 0;

                            lstPagar.Add(oPagar);

                        }
                    }

                    montaGridPagar(lstPagar);
                }


            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        #endregion 

        #region "Tratamento de Campos - Tab - Aba de fiadores"
        private void btnFiador_Click(object sender, EventArgs e)
        {
            psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdFiador.Text = "";
            else
                txtIdFiador.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdFiador_Validating(null, null);
        }

        private void txtCPFCNPJFiador_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJFiador.Mask = "";
            lblCNPJFiador.Text = "CNPJ/CPF";
            txtCPFCNPJFiador.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void txtCPFCNPJFiador_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJFiador.Text))
                {
                    txtIdFiador.ReadOnly = false;
                    txtIdFiador.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJFiador.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJFiador.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJFiador.Mask = "000.000.000-00";
                        lblCNPJFiador.Text = "CPF";
                        txtCPFCNPJFiador.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJFiador.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJFiador.Mask = "00.000.000/0000-00";
                        lblCNPJFiador.Text = "CNPJ";
                        txtCPFCNPJFiador.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCNPJFiador.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJFiador.Text.Trim().Length > 0)
                    {
                        FiadorRN oFiadorRN = new FiadorRN(Conexao, objOcorrencia, empMaster);
                        Fiador oFiador = new Fiador();

                        oFiador = oFiadorRN.ObterPor(empMaster, txtCPFCNPJFiador.Text.Trim());

                        if (EmcResources.cInt(oFiador.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdFiador.ReadOnly = false;
                            txtIdFiador.Focus();
                        }
                        else
                        {
                            txtIdFiador.Text = oFiador.idPessoa.ToString();
                            txtNomeFiador.Text = oFiador.pessoa.nome;
                            txtIdFiador.ReadOnly = true;

                            bool encontrou = false;

                            foreach (DataGridViewRow oRow in grdFiador.Rows)
                            {
                                if (EmcResources.cInt(oRow.Cells["idfiador"].Value.ToString()) == EmcResources.cInt(txtIdFiador.Text))
                                {
                                    encontrou = true;
                                }
                            }

                            if (encontrou)
                            {
                                btnInsereFiador.Enabled = false;
                                btnLimpaFiador.Enabled = true;
                                btnExcluiFiador.Enabled = true;
                            }
                            else
                            {
                                btnInsereFiador.Enabled = true;
                                btnLimpaFiador.Enabled = true;
                                btnExcluiFiador.Enabled = false;
                            }
                            
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

        private void txtIdFiador_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdFiador.Text))
                {
                    FiadorRN oFiadorRN = new FiadorRN(Conexao, objOcorrencia, empMaster);
                    Fiador oFiador = new Fiador();

                    oFiador.idPessoa = EmcResources.cInt(txtIdFiador.Text);
                    oFiador.codEmpresa = empMaster;

                    oFiador = oFiadorRN.ObterPor(oFiador);

                    if (EmcResources.cInt(oFiador.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Fiador não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdFiador.Text = oFiador.idPessoa.ToString();
                        txtCPFCNPJFiador.Text = oFiador.pessoa.cnpjCpf;
                        txtNomeFiador.Text = oFiador.pessoa.nome;

                        if (txtCPFCNPJFiador.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJFiador.Mask = "000.000.000-00";
                            lblCNPJFiador.Text = "CPF";
                        }
                        else if (txtCPFCNPJFiador.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJFiador.Mask = "00.000.000/0000-00";
                            lblCNPJFiador.Text = "CNPJ";
                        }

                        bool encontrou = false;

                        foreach (DataGridViewRow oRow in grdFiador.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idfiador"].Value.ToString()) == EmcResources.cInt(txtIdFiador.Text))
                            {
                                encontrou = true;
                            }
                        }

                        if (encontrou)
                        {
                            btnInsereFiador.Enabled = false;
                            btnLimpaFiador.Enabled = true;
                            btnExcluiFiador.Enabled = true;
                        }
                        else
                        {
                            btnInsereFiador.Enabled = true;
                            btnLimpaFiador.Enabled = true;
                            btnExcluiFiador.Enabled = false;
                        }

                    }

                }
                else
                {
                    txtCPFCNPJLocatario.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            } 
        }

        private void btnInsereFiador_Click(object sender, EventArgs e)
        {
            try
            {
                bool encontrou = false;

                foreach(DataGridViewRow oRow in grdFiador.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idfiador"].Value.ToString()) == EmcResources.cInt(txtIdFiador.Text) )
                    {
                        encontrou = true;
                    }
                }

                if (!encontrou)
                {
                    grdFiador.Rows.Add(txtCPFCNPJFiador.Text, txtIdFiador.Text, txtNomeFiador.Text, "A", "I", 0);
                }
                else
                    MessageBox.Show("O fiador foi encontrado no contrato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message);
            }
        }

        private void btnExcluiFiador_Click(object sender, EventArgs e)
        {
            try
            {
                
                foreach (DataGridViewRow oRow in grdFiador.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idfiador"].Value.ToString()) == EmcResources.cInt(txtIdFiador.Text))
                    {
                        if (oRow.Cells["situacaofiador"].Value.ToString() == "A" &&
                            oRow.Cells["stoperacaofiador"].Value.ToString() == "")
                        {
                            oRow.Cells["stoperacaofiador"].Value = "C";
                        }
                        else if (oRow.Cells["situacaofiador"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacaofiador"].Value.ToString() == "C")
                        {
                            oRow.Cells["stoperacaofiador"].Value = "";
                        }
                        else if (oRow.Cells["situacaofiador"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacaofiador"].Value.ToString() == "")
                        {
                            oRow.Cells["stoperacaofiador"].Value = "R";
                        }
                        else if (oRow.Cells["situacaofiador"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacaofiador"].Value.ToString() == "R")
                        {
                            oRow.Cells["stoperacaofiador"].Value = "";
                        }

                    }

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message);
            }
        }

        private void btnLimpaFiador_Click(object sender, EventArgs e)
        {
            try
            {
                txtCPFCNPJFiador.Text = "";
                txtIdFiador.Text="";
                txtNomeFiador.Text = "";
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro :" + erro.Message);
            }
        }

        private void grdFiador_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIdFiador.Text = grdFiador.Rows[grdFiador.CurrentRow.Index].Cells["idfiador"].Value.ToString();
                txtIdFiador_Validating(null, null);
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message);
            }
        }
        #endregion

        #region "Tratamento de Campos - Tab - Aba de Parcela a Receber"
        private void grdLocacaoReceber_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //if (grdLocacaoReceber.Rows[grdLocacaoReceber.CurrentRow.Index].Cells["situacaocliente"].Value.ToString() != "G")
                //{

                    txtIdLocatarioReceber.Text = grdLocacaoReceber.Rows[grdLocacaoReceber.CurrentRow.Index].Cells["idcliente"].Value.ToString();
                    txtIdLocatarioReceber_Validating(null, null);
                    
                    txtNroParcelaReceber.Text = grdLocacaoReceber.Rows[grdLocacaoReceber.CurrentRow.Index].Cells["nroparcelacliente"].Value.ToString();
                    
                    txtNroParcelaReceber_Validating(null, null);
                //}
                //else
               // {
                 //   MessageBox.Show("Parcela gerada para o financeiro, não pode sofrer manutenção.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message);
            }
        }

        private void txtIdLocatarioReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocatarioReceber.Text))
                {
                    ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                    Cliente oCliente = new Cliente();

                    oCliente.idPessoa = EmcResources.cInt(txtIdLocatarioReceber.Text);
                    oCliente.codEmpresa = empMaster;

                    oCliente = oClienteRN.ObterPor(oCliente);

                    if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdLocatarioReceber.Text = oCliente.idPessoa.ToString();
                        txtCPFCNPJReceber.Text = oCliente.pessoa.cnpjCpf;
                        txtNomeLocatarioReceber.Text = oCliente.pessoa.nome;

                        if (txtCPFCNPJReceber.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJReceber.Mask = "000.000.000-00";
                            lblCnpjReceber.Text = "CPF";
                        }
                        else if (txtCPFCNPJReceber.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJReceber.Mask = "00.000.000/0000-00";
                            lblCnpjReceber.Text = "CNPJ";
                        }

                        bool encontrou = false;

                        foreach (DataGridViewRow oRow in grdLocatario.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idlocatario"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text))
                            {
                                encontrou = true;
                            }
                        }


                        if (!encontrou)
                        {
                            MessageBox.Show("Locatário não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpaReceber_Click(null, null);
                        }
                        else
                        {
                            txtNroParcelaReceber.Focus();
                        }



                    }

                }
                else
                {
                    txtCPFCNPJReceber.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtCPFCNPJReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJReceber.Text))
                {
                    txtIdLocatarioReceber.ReadOnly = false;
                    txtIdLocatarioReceber.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJReceber.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJReceber.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJReceber.Mask = "000.000.000-00";
                        lblCnpjReceber.Text = "CPF";
                        txtCPFCNPJReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJReceber.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJReceber.Mask = "00.000.000/0000-00";
                        lblCnpjReceber.Text = "CNPJ";
                        txtCPFCNPJReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCnpjReceber.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJReceber.Text.Trim().Length > 0)
                    {
                        ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                        Cliente oCliente = new Cliente();

                        oCliente = oClienteRN.ObterPor(empMaster, txtCPFCNPJReceber.Text.Trim());

                        if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocatarioReceber.ReadOnly = false;
                            txtIdLocatarioReceber.Focus();
                        }
                        else
                        {
                            txtIdLocatarioReceber.Text = oCliente.idPessoa.ToString();
                            txtNomeLocatarioReceber.Text = oCliente.pessoa.nome;
                            txtIdLocatarioReceber.ReadOnly = true;

                            bool encontrou = false;

                            foreach (DataGridViewRow oRow in grdLocatario.Rows)
                            {
                                if (EmcResources.cInt(oRow.Cells["idlocatario"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text))
                                {
                                    encontrou = true;
                                }
                            }


                            if (!encontrou)
                            {
                                MessageBox.Show("Locatário não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLimpaReceber_Click(null, null);
                            }
                            else
                            {
                                txtNroParcelaReceber.Focus();
                            }
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

        private void txtCPFCNPJReceber_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJReceber.Mask = "";
            lblCnpjReceber.Text = "CNPJ/CPF";
            txtCPFCNPJReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            
        }

        private void btnLimpaReceber_Click(object sender, EventArgs e)
        {
            txtCPFCNPJReceber.Text = "";
            txtIdLocatarioReceber.Text = "";
            txtNomeLocatarioReceber.Text = "";
            txtCarenciaParcela.Text = "";
            txtNroParcelaReceber.Text = "";
            txtVencimentoParcela.Text = "";
            txtDiasCarenciaParcela.Text = "";
            txtDtaInicioParcela.Text = "";
            txtDtaFinalParcela.Text = "";

            txtNroParcelaReceber.Enabled = true;

            txtCPFCNPJReceber.Focus();

            btnIntegReceber.Enabled = false;


        }

        private void btnIncluiReceber_Click(object sender, EventArgs e)
        {
            try
            {
                double percParticipacao = 0;

                foreach (DataGridViewRow oRow in grdLocatario.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idlocatario"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text))
                    {
                        percParticipacao = EmcResources.cDouble(oRow.Cells["participacao"].Value.ToString());
                    }
                }

                grdLocacaoReceber.Rows.Add( txtNomeLocatarioReceber.Text,
                                            txtIdLocatarioReceber.Text,
                                            txtNroParcelaReceber.Text,
                                            txtVencimentoParcela.Text,
                                            txtCarenciaParcela.Text,
                                            txtDtaInicioParcela.Text,
                                            txtDtaFinalParcela.Text,
                                            "0,00",
                                            "0,00",
                                            "0,00",
                                            "0,00",
                                            "A",
                                            "",
                                            "I",
                                            txtDiasCarenciaParcela.Text,
                                            txtIdLocacaoContrato.Text,
                                            0,
                                            percParticipacao,
                                            0);

                btnLimpaReceber_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnAlteraReceber_Click(object sender, EventArgs e)
        {
            try
            {
                string stoper = "";
                foreach (DataGridViewRow oRow in grdLocacaoReceber.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idcliente"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelacliente"].Value.ToString()) == EmcResources.cInt(txtNroParcelaReceber.Text))
                    {
                        if (oRow.Cells["st"].Value.ToString() == "A" || oRow.Cells["st"].Value.ToString() == "")
                        {
                            stoper = "A";
                        }
                        else if (oRow.Cells["st"].Value.ToString() == "I")
                        {
                            oRow.Cells["st"].Value = "I";
                        }

                        oRow.Cells["dtavenccliente"].Value = txtVencimentoParcela.Text;
                        oRow.Cells["diascarencia"].Value = txtDiasCarenciaParcela.Text;
                        oRow.Cells["dtacarencia"].Value = txtCarenciaParcela.Text;
                        oRow.Cells["periodoinicio"].Value = txtDtaInicioParcela.Text;
                        oRow.Cells["periodofinal"].Value = txtDtaFinalParcela.Text;
                        oRow.Cells["st"].Value = stoper;

                    }
                }

                btnLimpaReceber_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnExcluiReceber_Click(object sender, EventArgs e)
        {
            bool alteraProventos = true;

            try
            {
                //marca a parcela para cancelamento na aba de locacao receber
                foreach (DataGridViewRow oRow in grdLocacaoReceber.Rows)
                {
                    
                    if (EmcResources.cInt(oRow.Cells["idcliente"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelacliente"].Value.ToString()) == EmcResources.cInt(txtNroParcelaReceber.Text))
                    {

                        if (oRow.Cells["situacaocliente"].Value.ToString() == "A" &&
                            oRow.Cells["st"].Value.ToString() == "")
                        {
                            oRow.Cells["st"].Value = "C";
                        }
                        else if (oRow.Cells["situacaocliente"].Value.ToString() == "A" &&
                                 oRow.Cells["st"].Value.ToString() == "C")
                        {
                            oRow.Cells["st"].Value = "";
                        }
                        else if (oRow.Cells["situacaocliente"].Value.ToString() == "C" &&
                                 oRow.Cells["st"].Value.ToString() == "")
                        {
                            oRow.Cells["st"].Value = "R";
                        }
                        else if (oRow.Cells["situacaocliente"].Value.ToString() == "C" &&
                                 oRow.Cells["st"].Value.ToString() == "R")
                        {
                            oRow.Cells["st"].Value = "";
                        }
                        else if (oRow.Cells["situacaocliente"].Value.ToString() == "A" &&
                                 oRow.Cells["st"].Value.ToString() == "I")
                        {
                            grdLocacaoReceber.Rows.Remove(oRow);
                        }
                        else if (oRow.Cells["situacaocliente"].Value.ToString() == "A" &&
                                 oRow.Cells["st"].Value.ToString() == "A")
                        {
                            MessageBox.Show("Parcela está em alteração, não pode ser excluida", "Aviso");
                            alteraProventos = false;
                        }


                    }

                }

                if (alteraProventos)
                {

                    // marca para cancelamento os proventos referentes a a parcela cancelada
                    foreach (DataGridViewRow oRow in grdCCReceber.Rows)
                    {

                        if (EmcResources.cInt(oRow.Cells["idlocatariocta"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text) &&
                            EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString()) == EmcResources.cInt(txtNroParcelaReceber.Text))
                        {

                            if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                oRow.Cells["stccreceber"].Value.ToString() == "")
                            {
                                oRow.Cells["stccreceber"].Value = "C";
                            }
                            else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                     oRow.Cells["stccreceber"].Value.ToString() == "C")
                            {
                                oRow.Cells["stccreceber"].Value = "";
                            }
                            else if (oRow.Cells["sitccreceber"].Value.ToString() == "C" &&
                                     oRow.Cells["stccreceber"].Value.ToString() == "")
                            {
                                oRow.Cells["stccreceber"].Value = "R";
                            }
                            else if (oRow.Cells["sitccreceber"].Value.ToString() == "C" &&
                                     oRow.Cells["stccreceber"].Value.ToString() == "R")
                            {
                                oRow.Cells["stccreceber"].Value = "";
                            }
                            else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                     oRow.Cells["stccreceber"].Value.ToString() == "I")
                            {
                                grdCCReceber.Rows.Remove(oRow);
                            }


                        }

                    }
                }
                btnLimpaReceber_Click(null, null);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtNroParcelaReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtNroParcelaReceber.Text)> 0 && EmcResources.cInt(txtIdLocatarioReceber.Text) > 0)
                {
                    bool encontrou = false;

                    foreach (DataGridViewRow oRow in grdLocacaoReceber.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["idcliente"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text) &&
                            EmcResources.cInt(oRow.Cells["nroparcelacliente"].Value.ToString()) == EmcResources.cInt(txtNroParcelaReceber.Text))
                        {
                            encontrou = true;

                            txtDtaInicioParcela.Text = oRow.Cells["periodoinicio"].Value.ToString();
                            txtDtaFinalParcela.Text = oRow.Cells["periodofinal"].Value.ToString();
                            txtCarenciaParcela.Text = oRow.Cells["dtacarencia"].Value.ToString();
                            txtDiasCarenciaParcela.Text = oRow.Cells["diascarencia"].Value.ToString();
                            txtVencimentoParcela.Text = oRow.Cells["dtavenccliente"].Value.ToString();
                            txtSitReceber.Text = oRow.Cells["situacaocliente"].Value.ToString();
                            txtStReceber.Text = oRow.Cells["st"].Value.ToString();

                        }
                    }


                    if (!encontrou)
                    {
                        MessageBox.Show("Parcela não encontrada para este locatário", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLimpaReceber.Enabled = true;
                        btnIncluiReceber.Enabled = true;
                        btnAlteraReceber.Enabled = false;
                        btnExcluiReceber.Enabled = false;
                        btnIntegReceber.Enabled = false;
                    }
                    else
                    {
                        //verifica se habilida campos para controle de carencia de acordo com as regras do contrato.
                        if (cboTemCarencia.SelectedValue.ToString() == "S")
                        {
                            txtDiasCarenciaParcela.Enabled = true;
                            txtCarenciaParcela.Enabled = true;
                        }
                        else
                        {
                            txtDiasCarenciaParcela.Enabled = false;
                            txtCarenciaParcela.Enabled = false;
                        }


                        //configura botões de acordo com o status da parcela
                        if (txtStReceber.Text == "A" || String.IsNullOrEmpty(txtStReceber.Text) || txtStReceber.Text == "I")
                        {
                            btnLimpaReceber.Enabled = true;
                            btnIncluiReceber.Enabled = false;
                            btnAlteraReceber.Enabled = true;
                            btnExcluiReceber.Enabled = true;

                            if (txtSitReceber.Text == "G")
                                btnIntegReceber.Enabled = true;
                            else
                                btnIntegReceber.Enabled = false;

                        }
                        else if (txtStReceber.Text == "C" || txtStReceber.Text == "R")
                        {
                            btnLimpaReceber.Enabled = true;
                            btnIncluiReceber.Enabled = false;
                            btnAlteraReceber.Enabled = false;
                            btnExcluiReceber.Enabled = true;
                            btnIntegReceber.Enabled = false;
                        }

                        //configura botões de acordo com a situação da parcela
                        if (txtSitReceber.Text == "G" || txtSitReceber.Text == "P")
                        {
                            btnLimpaReceber.Enabled = true;
                            btnIncluiReceber.Enabled = false;
                            btnAlteraReceber.Enabled = false;
                            btnExcluiReceber.Enabled = false;
                        }
                        else if (txtSitReceber.Text == "C")
                        {
                            btnLimpaReceber.Enabled = true;
                            btnIncluiReceber.Enabled = false;
                            btnAlteraReceber.Enabled = false;
                            btnExcluiReceber.Enabled = true;
                        }

                    }

                    txtVencimentoParcela.Focus();
                }
                
            }
            catch(Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtVencimentoParcela_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboTemCarencia.SelectedValue.ToString() == "N")
                {
                    txtDiasCarenciaParcela.Enabled = false;
                    txtCarenciaParcela.Enabled = false;
                    txtDiasCarenciaParcela.Text = "0";
                    txtCarenciaParcela.Text = txtVencimentoParcela.Text;
                }
                else
                {
                    txtDiasCarenciaParcela.Enabled = true;
                    txtCarenciaParcela.Enabled = true;
                    txtDiasCarenciaParcela.Text = txtDiasCarencia.Text;
                    txtCarenciaParcela.Text = txtVencimentoParcela.DateValue.Value.AddDays(EmcResources.cInt(txtDiasCarenciaParcela.Text)).ToShortDateString();
                }

                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtDiasCarenciaParcela_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                txtCarenciaParcela.Text = txtVencimentoParcela.DateValue.Value.AddDays(EmcResources.cInt(txtDiasCarenciaParcela.Text)).ToShortDateString();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtCarenciaParcela_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TimeSpan difData = txtCarenciaParcela.DateValue.Value.Subtract(txtVencimentoParcela.DateValue.Value);
                txtCarenciaParcela.Text = difData.Days.ToString();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }

        }

        private void txtDtaFinalParcela_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (btnIncluiReceber.Enabled)
                {
                    btnIncluiReceber.Focus();
                }
                else
                {
                    btnAlteraReceber.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }

        }

        private void btnLocatarioReceber_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocatarioReceber.Text = "";
                else
                    txtIdLocatarioReceber.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocatarioReceber_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnIntegReceber_Click(object sender, EventArgs e)
        {
            try
            {
                string stoper = "";
                foreach (DataGridViewRow oRow in grdLocacaoReceber.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idcliente"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelacliente"].Value.ToString()) == EmcResources.cInt(txtNroParcelaReceber.Text))
                    {
                        if (oRow.Cells["st"].Value.ToString() == "" && oRow.Cells["situacaocliente"].Value.ToString() == "G")
                        {
                            stoper = "G";
                        }
                        oRow.Cells["st"].Value = stoper;

                    }
                }

                btnLimpaReceber_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        

        #endregion

        #region "Tratamento de Campos - Tab - Proventos de Parcelas a Receber"

        private void txtCPFCNPJCCReceber_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJCCReceber.Mask = "";
            lblCnpjCCReceber.Text = "CNPJ/CPF";
            txtCPFCNPJCCReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void txtCPFCNPJCCReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJCCReceber.Text))
                {
                    txtIdLocatarioCCReceber.ReadOnly = false;
                    txtIdLocatarioCCReceber.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJCCReceber.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJCCReceber.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJCCReceber.Mask = "000.000.000-00";
                        lblCnpjCCReceber.Text = "CPF";
                        txtCPFCNPJCCReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJCCReceber.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJCCReceber.Mask = "00.000.000/0000-00";
                        lblCnpjCCReceber.Text = "CNPJ";
                        txtCPFCNPJCCReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCnpjCCReceber.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJCCReceber.Text.Trim().Length > 0)
                    {
                        ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                        Cliente oCliente = new Cliente();

                        oCliente = oClienteRN.ObterPor(empMaster, txtCPFCNPJCCReceber.Text.Trim());

                        if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocatarioCCReceber.ReadOnly = false;
                            txtIdLocatarioCCReceber.Focus();
                        }
                        else
                        {
                            txtIdLocatarioCCReceber.Text = oCliente.idPessoa.ToString();
                            txtNomeLocatarioCCReceber.Text = oCliente.pessoa.nome;
                            txtIdLocatarioCCReceber.ReadOnly = true;

                            bool encontrou = false;

                            foreach (DataGridViewRow oRow in grdLocatario.Rows)
                            {
                                if (EmcResources.cInt(oRow.Cells["idlocatario"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                                {
                                    encontrou = true;
                                }
                            }


                            if (!encontrou)
                            {
                                MessageBox.Show("Locatário não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLimpaReceber_Click(null, null);
                            }
                            else
                            {
                                txtNroParcelaCCReceber.Focus();
                            }
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

        private void txtIdLocatarioCCReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocatarioCCReceber.Text))
                {
                    ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                    Cliente oCliente = new Cliente();

                    oCliente.idPessoa = EmcResources.cInt(txtIdLocatarioCCReceber.Text);
                    oCliente.codEmpresa = empMaster;

                    oCliente = oClienteRN.ObterPor(oCliente);

                    if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdLocatarioCCReceber.Text = oCliente.idPessoa.ToString();
                        txtCPFCNPJCCReceber.Text = oCliente.pessoa.cnpjCpf;
                        txtNomeLocatarioCCReceber.Text = oCliente.pessoa.nome;

                        if (txtCPFCNPJCCReceber.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJCCReceber.Mask = "000.000.000-00";
                            lblCnpjCCReceber.Text = "CPF";
                        }
                        else if (txtCPFCNPJCCReceber.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJCCReceber.Mask = "00.000.000/0000-00";
                            lblCnpjCCReceber.Text = "CNPJ";
                        }

                        bool encontrou = false;

                        foreach (DataGridViewRow oRow in grdLocatario.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idlocatario"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                            {
                                encontrou = true;
                            }
                        }


                        if (!encontrou)
                        {
                            MessageBox.Show("Locatário não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpaCCReceber_Click(null, null);
                        }
                        else
                        {
                            txtNroParcelaCCReceber.Focus();
                        }



                    }

                }
                else
                {
                    txtCPFCNPJCCReceber.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnLocatarioCCReceber_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocatarioCCReceber.Text = "";
                else
                    txtIdLocatarioCCReceber.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocatarioCCReceber_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtNroParcelaCCReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtNroParcelaCCReceber.Text) > 0 && EmcResources.cInt(txtIdLocatarioCCReceber.Text) > 0)
                {
                    bool encontrou = false;
                    string sitParcelaReceber = "";
                    int idParcela = 0;

                    //verifica se a parcela existe para o locatário.
                    foreach (DataGridViewRow oRow in grdLocacaoReceber.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["idcliente"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text) &&
                            EmcResources.cInt(oRow.Cells["nroparcelacliente"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCReceber.Text))
                        {
                            encontrou = true;
                            sitParcelaReceber = oRow.Cells["situacaocliente"].Value.ToString();
                            idParcela = EmcResources.cInt(oRow.Cells["idlocacaoreceber"].Value.ToString());
                        }
                    }

                    txtidparcelaccreceber.Text = idParcela.ToString();

                    if (!encontrou)
                    {
                        MessageBox.Show("Parcela não encontrada para este locatário", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNroParcelaCCReceber.Focus();

                        btnLimpaCCReceber.Enabled = true;
                        btnIncluiCCReceber.Enabled = false;
                        btnAlteraCCReceber.Enabled = false;
                        btnExcluiCCReceber.Enabled = false;
                    }
                    else
                        txtIdProventoCCReceber.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }

        }

        private void txtIdProventoCCReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdProventoCCReceber.Text))
                {
                    LocacaoProventosRN oProventoRN = new LocacaoProventosRN(Conexao, objOcorrencia, empMaster);
                    LocacaoProventos oProvento = new LocacaoProventos();

                    oProvento.idLocacaoProventos = EmcResources.cInt(txtIdProventoCCReceber.Text);
                    oProvento = oProventoRN.ObterPor(oProvento);

                    if (EmcResources.cInt(oProvento.idLocacaoProventos.ToString()) == 0)
                    {
                        MessageBox.Show("Provento não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //carrega informações de proventos
                        txtIdProventoCCReceber.Text = oProvento.idLocacaoProventos.ToString();
                        txtProventoCCReceber.Text = oProvento.Descricao;
                        txtTipoProventoCCReceber.Text = oProvento.TipoProvento;

                        bool encontrou = false;

                        //verifica se já existe o provento para a parcela e locador
                        foreach (DataGridViewRow oRow in grdCCReceber.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idprovento"].Value.ToString()) == EmcResources.cInt(txtIdProventoCCReceber.Text) &&
                                EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCReceber.Text) &&
                                EmcResources.cInt(oRow.Cells["idlocatariocta"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                            {
                                encontrou = true;

                                txtDtaEmissaoCCReceber.Text = oRow.Cells["dataemissao"].Value.ToString();
                                txtDtaLanctoCCReceber.Text = oRow.Cells["datalancamento"].Value.ToString();
                                txtValorCCReceber.Text = oRow.Cells["valorlancamento"].Value.ToString();
                                txtDescricaoCCReceber.Text = oRow.Cells["descricao"].Value.ToString();
                                txtSitCCReceber.Text = oRow.Cells["sitccreceber"].Value.ToString();
                                txtStCCReceber.Text = oRow.Cells["stccreceber"].Value.ToString();
                            }
                        }


                        if (encontrou)
                        {
                            //MessageBox.Show("Provento já cadastrado nesta parcela para o locatário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpaCCReceber.Enabled = true;
                            btnIncluiCCReceber.Enabled = false;
                            btnAlteraCCReceber.Enabled = true;
                            btnExcluiCCReceber.Enabled = true;

                            //configura botões de acordo com o status do provento
                            if (txtStCCReceber.Text == "A" || String.IsNullOrEmpty(txtStCCReceber.Text) || txtStCCReceber.Text == "I")
                            {
                                btnLimpaCCReceber.Enabled = true;
                                btnIncluiCCReceber.Enabled = false;
                                btnAlteraCCReceber.Enabled = true;
                                btnExcluiCCReceber.Enabled = true;
                            }
                            else if (txtStCCReceber.Text == "C" || txtStCCReceber.Text == "R")
                            {
                                btnLimpaCCReceber.Enabled = true;
                                btnIncluiCCReceber.Enabled = false;
                                btnAlteraCCReceber.Enabled = false;
                                btnExcluiCCReceber.Enabled = true;
                            }

                            //configura botões de acordo com a situação do provento
                            if (txtSitCCReceber.Text == "G")
                            {
                                btnLimpaCCReceber.Enabled = true;
                                btnIncluiCCReceber.Enabled = false;
                                btnAlteraCCReceber.Enabled = false;
                                btnExcluiCCReceber.Enabled = false;
                            }
                            else if (txtSitCCReceber.Text == "C")
                            {
                                btnLimpaCCReceber.Enabled = true;
                                btnIncluiCCReceber.Enabled = false;
                                btnAlteraCCReceber.Enabled = false;
                                btnExcluiCCReceber.Enabled = true;
                            }

                        }
                        else
                        {
                            btnLimpaCCReceber.Enabled = true;
                            btnIncluiCCReceber.Enabled = true;
                            btnAlteraCCReceber.Enabled = false;
                            btnExcluiCCReceber.Enabled = false;

                            txtSitCCReceber.Text = "A";
                            txtStCCReceber.Text = "I";
                            
                        }

                        txtDtaEmissaoCCReceber.Focus();

                    }

                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnProventoReceber_Click(object sender, EventArgs e)
        {
            try
            {
                psqLocacaoProventos ofrm = new psqLocacaoProventos(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                    txtIdProventoCCReceber.Text = "";
                else
                    txtIdProventoCCReceber.Text = retPesquisa.chaveinterna.ToString();

                //txtIdProventoCCReceber_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtDescricaoCCReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (btnIncluiCCReceber.Enabled)
                {
                    btnIncluiCCReceber.Focus();
                }
                else
                {
                    btnAlteraCCReceber.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnLimpaCCReceber_Click(object sender, EventArgs e)
        {
            txtNroParcelaCCReceber.Enabled = true;

            txtCPFCNPJCCReceber.Text = "";
            txtIdLocatarioCCReceber.Text = "";
            txtNomeLocatarioCCReceber.Text = "";
            txtNroParcelaCCReceber.Text = "";
            txtIdProventoCCReceber.Text = "";
            txtProventoCCReceber.Text = "";
            txtTipoProventoCCReceber.Text = "";
            txtDtaEmissaoCCReceber.Text = "";
            txtDtaLanctoCCReceber.Text = "";
            txtValorCCReceber.Text = "0,00";
            txtDescricaoCCReceber.Text = "";

            txtCPFCNPJCCReceber.Focus();
        }

        private void btnAlteraCCReceber_Click(object sender, EventArgs e)
        {
            try
            {
                string stoper = "";
                foreach (DataGridViewRow oRow in grdCCReceber.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idprovento"].Value.ToString()) == EmcResources.cInt(txtIdProventoCCReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["idlocatariocta"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                    {
                        if (oRow.Cells["stccreceber"].Value.ToString() == "A" || oRow.Cells["stccreceber"].Value.ToString() == "")
                        {
                            stoper = "A";
                        }
                        else if (oRow.Cells["stccreceber"].Value.ToString() == "I")
                        {
                            stoper = "I";
                        }

                        oRow.Cells["dataemissao"].Value = txtDtaEmissaoCCReceber.Text;
                        oRow.Cells["datalancamento"].Value = txtDtaLanctoCCReceber.Text;
                        oRow.Cells["valorlancamento"].Value = txtValorCCReceber.Value;
                        oRow.Cells["descricao"].Value = txtDescricaoCCReceber.Text;
                        oRow.Cells["stccreceber"].Value = stoper;

                    }
                }

                recalculaReceber(EmcResources.cInt(txtIdLocatarioCCReceber.Text), EmcResources.cInt(txtNroParcelaCCReceber.Text));

                btnLimpaCCReceber_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnIncluiCCReceber_Click(object sender, EventArgs e)
        {
            try
            {
                grdCCReceber.Rows.Add(txtNomeLocatarioCCReceber.Text,
                                               txtIdLocatarioCCReceber.Text,
                                               txtNroParcelaCCReceber.Text,
                                               txtProventoCCReceber.Text,
                                               txtIdProventoCCReceber.Text,
                                               txtTipoProventoCCReceber.Text,
                                               txtDtaLanctoCCReceber.Text,
                                               txtValorCCReceber.Value,
                                               txtSitCCReceber.Text,
                                               "I",
                                               empMaster,
                                               txtDtaEmissaoCCReceber.Text,
                                               txtIdLocacaoContrato.Text,
                                               txtDescricaoCCReceber.Text,
                                               txtidparcelaccreceber.Text,
                                               0);

                recalculaReceber(EmcResources.cInt(txtIdLocatarioCCReceber.Text), EmcResources.cInt(txtNroParcelaCCReceber.Text));

                btnLimpaCCReceber_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnExcluiCCReceber_Click(object sender, EventArgs e)
        {
            try
            {
                //marca o provento da parcela para cancelamento na aba de locacao CC receber
                foreach (DataGridViewRow oRow in grdCCReceber.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idprovento"].Value.ToString()) == EmcResources.cInt(txtIdProventoCCReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["idlocatariocta"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                    {

                        if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                            oRow.Cells["stccreceber"].Value.ToString() == "")
                        {
                            oRow.Cells["stccreceber"].Value = "C";
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "C")
                        {
                            oRow.Cells["stccreceber"].Value = "";
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "C" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "")
                        {
                            oRow.Cells["stccreceber"].Value = "R";
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "C" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "R")
                        {
                            oRow.Cells["stccreceber"].Value = "";
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "I")
                        {
                            grdCCReceber.Rows.Remove(oRow);
                        }


                    }

                }

                recalculaReceber(EmcResources.cInt(txtIdLocatarioCCReceber.Text), EmcResources.cInt(txtNroParcelaCCReceber.Text));

                btnLimpaCCReceber_Click(null, null);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void recalculaReceber(int idLocatario, int nroParcela)
        {
            Decimal valorParcela = 0;

            try
            {
                //marca o provento da parcela para cancelamento na aba de locacao CC receber
                foreach (DataGridViewRow oRow in grdCCReceber.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCReceber.Text) &&
                        EmcResources.cInt(oRow.Cells["idlocatariocta"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                    {

                        if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                            oRow.Cells["stccreceber"].Value.ToString() == "")
                        {
                            if (oRow.Cells["tipoprovento"].Value.ToString() == "D")
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                            else
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                            oRow.Cells["stccreceber"].Value.ToString() == "A")
                        {
                            if (oRow.Cells["tipoprovento"].Value.ToString() == "D")
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                            else
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "C")
                        {
                            //Não faz nada pois o lancamento vai ser cancelado
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "C" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "")
                        {
                            //não faz nada pois o lancamento está cancelado
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "C" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "R")
                        {
                            //refaz o calculo porque o lancamento vai ser restaurado.
                            if (oRow.Cells["tipoprovento"].Value.ToString() == "D")
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                            else
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                        }
                        else if (oRow.Cells["sitccreceber"].Value.ToString() == "A" &&
                                 oRow.Cells["stccreceber"].Value.ToString() == "I")
                        {
                            //considera lancamentos que estão sendo incluidos.
                            if (oRow.Cells["tipoprovento"].Value.ToString() == "D")
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                            else
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorlancamento"].Value.ToString());
                        }

                    }

                }

                //atualiza o valor da Parcela apartir dos lancamentos.
                foreach (DataGridViewRow oRow2 in grdLocacaoReceber.Rows)
                {

                    if (EmcResources.cInt(oRow2.Cells["nroparcelacliente"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCReceber.Text) &&
                        EmcResources.cInt(oRow2.Cells["idcliente"].Value.ToString()) == EmcResources.cInt(txtIdLocatarioCCReceber.Text))
                    {
                        oRow2.Cells["valorparcelacliente"].Value = EmcResources.cCur(valorParcela.ToString());
                   

                        if (oRow2.Cells["st"].Value.ToString() == "I")
                        {
                            oRow2.Cells["st"].Value = "I";
                        }
                        else
                            oRow2.Cells["st"].Value = "A";
                    }
                }
                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
            
        }

        private void grdCCReceber_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdCCReceber.Rows[grdCCReceber.CurrentRow.Index].Cells["sitccreceber"].Value.ToString() != "G")
                {
                    txtIdLocatarioCCReceber.Text = grdCCReceber.Rows[grdCCReceber.CurrentRow.Index].Cells["idlocatariocta"].Value.ToString();
                    txtIdLocatarioCCReceber_Validating(null, null);

                    txtNroParcelaCCReceber.Text = grdCCReceber.Rows[grdCCReceber.CurrentRow.Index].Cells["nroparcela"].Value.ToString();
                    txtNroParcelaCCReceber.Enabled = false;

                    txtIdProventoCCReceber.Text = grdCCReceber.Rows[grdCCReceber.CurrentRow.Index].Cells["idprovento"].Value.ToString();
                    txtIdProventoCCReceber_Validating(null, null);
                }
                else
                {
                    MessageBox.Show("Parcela gerada para o financeiro, não pode sofrer manutenção.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }
        #endregion

        #region "Tratamento de Campos - Tab - Aba de Parcela a Pagar"

        private void txtCPFCNPJPagar_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJPagar.Mask = "";
            lblCnpjPagar.Text = "CNPJ/CPF";
            txtCPFCNPJPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void txtCPFCNPJPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJPagar.Text))
                {
                    txtIdLocadorPagar.ReadOnly = false;
                    txtIdLocadorPagar.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJPagar.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJPagar.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJPagar.Mask = "000.000.000-00";
                        lblCnpjPagar.Text = "CPF";
                        txtCPFCNPJPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJPagar.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJPagar.Mask = "00.000.000/0000-00";
                        lblCnpjPagar.Text = "CNPJ";
                        txtCPFCNPJPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCnpjPagar.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJPagar.Text.Trim().Length > 0)
                    {
                        FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                        Fornecedor oFornecedor = new Fornecedor();

                        oFornecedor = oFornecedorRN.ObterPor(empMaster, txtCPFCNPJPagar.Text.Trim());

                        if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocadorPagar.ReadOnly = false;
                            txtIdLocadorPagar.Focus();
                        }
                        else
                        {
                            txtIdLocadorPagar.Text = oFornecedor.idPessoa.ToString();
                            txtNomeLocadorPagar.Text = oFornecedor.pessoa.nome;
                            txtIdLocadorPagar.ReadOnly = true;

                            bool encontrou = false;

                            foreach (DataGridViewRow oRow in grdLocador.Rows)
                            {
                                if (EmcResources.cInt(oRow.Cells["idlocador"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text))
                                {
                                    encontrou = true;
                                }
                            }


                            if (!encontrou)
                            {
                                MessageBox.Show("Locador não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLimpaPagar_Click(null, null);
                            }
                            else
                            {
                                txtNroParcelaPagar.Focus();
                            }
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

        private void txtIdLocadorPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocadorPagar.Text))
                {
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                    Fornecedor oFornecedor = new Fornecedor();

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdLocadorPagar.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdLocadorPagar.Text = oFornecedor.idPessoa.ToString();
                        txtCPFCNPJPagar.Text = oFornecedor.pessoa.cnpjCpf;
                        txtNomeLocadorPagar.Text = oFornecedor.pessoa.nome;

                        if (txtCPFCNPJPagar.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJPagar.Mask = "000.000.000-00";
                            lblCnpjPagar.Text = "CPF";
                        }
                        else if (txtCPFCNPJPagar.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJPagar.Mask = "00.000.000/0000-00";
                            lblCnpjPagar.Text = "CNPJ";
                        }

                        bool encontrou = false;

                        foreach (DataGridViewRow oRow in grdLocador.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idlocador"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text))
                            {
                                encontrou = true;
                            }
                        }


                        if (!encontrou)
                        {
                            MessageBox.Show("Locador não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpaPagar_Click(null, null);
                        }
                        else
                        {
                            txtNroParcelaPagar.Focus();
                        }



                    }

                }
                else
                {
                    txtCPFCNPJPagar.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnLocadorPagar_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocadorPagar.Text = "";
                else
                    txtIdLocadorPagar.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocadorPagar_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtNroParcelaPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtNroParcelaPagar.Text) > 0 && EmcResources.cInt(txtIdLocadorPagar.Text) > 0)
                {
                    bool encontrou = false;

                    foreach (DataGridViewRow oRow in grdLocacaoPagar.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["idlocadorpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text) &&
                            EmcResources.cInt(oRow.Cells["nroparcelapagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaPagar.Text))
                        {
                            encontrou = true;

                            txtDtaInicioParcelaPagar.Text = oRow.Cells["peraquisitivoinicio"].Value.ToString();
                            txtDtaFinalParcelaPagar.Text = oRow.Cells["peraquisitivofinal"].Value.ToString();
                            txtVencimentoParcelaPagar.Text = oRow.Cells["dtavencimentopagar"].Value.ToString();
                            txtSitPagar.Text = oRow.Cells["situacaopagar"].Value.ToString();
                            txtStPagar.Text = oRow.Cells["stoperacao"].Value.ToString();

                        }
                    }


                    if (!encontrou)
                    {
                        MessageBox.Show("Parcela não encontrada para este locador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLimpaPagar.Enabled = true;
                        btnIncluiPagar.Enabled = true;
                        btnAlteraPagar.Enabled = false;
                        btnExcluiPagar.Enabled = false;
                        btnIntegPagar.Enabled = false;
                    }
                    else
                    {

                        //configura botões de acordo com o status da parcela
                        if (txtStPagar.Text == "A" || String.IsNullOrEmpty(txtStPagar.Text) || txtStPagar.Text == "I")
                        {
                            btnLimpaPagar.Enabled = true;
                            btnIncluiPagar.Enabled = false;
                            btnAlteraPagar.Enabled = true;
                            btnExcluiPagar.Enabled = true;

                            if (txtSitPagar.Text == "G")
                                btnIntegPagar.Enabled = true;
                            else
                                btnIntegPagar.Enabled = false;
                        }
                        else if (txtStPagar.Text == "C" || txtStPagar.Text == "R")
                        {
                            btnLimpaPagar.Enabled = true;
                            btnIncluiPagar.Enabled = false;
                            btnAlteraPagar.Enabled = false;
                            btnExcluiPagar.Enabled = true;
                        }

                        //configura botões de acordo com a situação da parcela
                        if (txtSitPagar.Text == "G" || txtSitPagar.Text == "P")
                        {
                            btnLimpaPagar.Enabled = true;
                            btnIncluiPagar.Enabled = false;
                            btnAlteraPagar.Enabled = false;
                            btnExcluiPagar.Enabled = false;
                        }
                        else if (txtSitReceber.Text == "C")
                        {
                            btnLimpaPagar.Enabled = true;
                            btnIncluiPagar.Enabled = false;
                            btnAlteraPagar.Enabled = false;
                            btnExcluiPagar.Enabled = true;
                        }

                    }

                    txtVencimentoParcelaPagar.Focus();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void grdLocacaoPagar_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                //if (grdLocacaoPagar.Rows[grdLocacaoPagar.CurrentRow.Index].Cells["situacaopagar"].Value.ToString() != "G")
                //{

                    txtIdLocadorPagar.Text = grdLocacaoPagar.Rows[grdLocacaoPagar.CurrentRow.Index].Cells["idlocadorpagar"].Value.ToString();
                    txtIdLocadorPagar_Validating(null, null);

                    txtNroParcelaPagar.Text = grdLocacaoPagar.Rows[grdLocacaoPagar.CurrentRow.Index].Cells["nroparcelapagar"].Value.ToString();

                    txtNroParcelaPagar_Validating(null, null);
                //}
                //else
                //{
                 //   MessageBox.Show("Parcela gerada para o financeiro, não pode sofrer manutenção.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message);
            }
        }

        private void btnLimpaPagar_Click(object sender, EventArgs e)
        {
            txtCPFCNPJPagar.Text = "";
            txtIdLocadorPagar.Text = "";
            txtNomeLocadorPagar.Text = "";
            txtNroParcelaPagar.Text = "";
            txtVencimentoParcelaPagar.Text = "";
            txtDtaInicioParcelaPagar.Text = "";
            txtDtaFinalParcelaPagar.Text = "";

            txtNroParcelaPagar.Enabled = true;

            txtCPFCNPJReceber.Focus();
        }

        private void btnIncluiPagar_Click(object sender, EventArgs e)
        {
            try
            {
                double percParticipacao = 0;

                foreach (DataGridViewRow oRow in grdLocador.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idlocador"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text))
                    {
                        percParticipacao = EmcResources.cDouble(oRow.Cells["percparticipacao"].Value.ToString());
                    }
                }

                grdLocacaoPagar.Rows.Add(txtNomeLocadorPagar.Text,
                                               txtIdLocadorPagar.Text,
                                               txtNroParcelaPagar.Text,
                                               txtVencimentoParcelaPagar.Text,
                                               txtDtaInicioParcelaPagar.Text,
                                               txtDtaFinalParcelaPagar.Text,
                                               "0,00",
                                               "0,00",
                                               "0,00",
                                               "0,00",
                                               "A",
                                               "",
                                               "I",
                                               txtIdLocacaoContrato.Text,
                                               0,
                                               percParticipacao,
                                               0);

                btnLimpaPagar_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnAlteraPagar_Click(object sender, EventArgs e)
        {
            try
            {
                string stoper = "";
                foreach (DataGridViewRow oRow in grdLocacaoPagar.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idlocadorpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelapagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaPagar.Text))
                    {
                        if (oRow.Cells["stoperacao"].Value.ToString() == "A" || oRow.Cells["stoperacao"].Value.ToString() == "")
                        {
                            stoper = "A";
                        }
                        else if (oRow.Cells["stoperacao"].Value.ToString() == "I")
                        {
                            oRow.Cells["st"].Value = "I";
                        }

                        oRow.Cells["dtavencimentopagar"].Value = txtVencimentoParcelaPagar.Text;
                        oRow.Cells["peraquisitivoinicio"].Value = txtDtaInicioParcelaPagar.Text;
                        oRow.Cells["peraquisitivofinal"].Value = txtDtaFinalParcelaPagar.Text;
                        oRow.Cells["stoperacao"].Value = stoper;

                    }
                }

                btnLimpaPagar_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnExcluiPagar_Click(object sender, EventArgs e)
        {
            try
            {
                bool alteraProventos = true;

                //marca a parcela para cancelamento na aba de locacao receber
                foreach (DataGridViewRow oRow in grdLocacaoPagar.Rows)
                {
                    
                    if (EmcResources.cInt(oRow.Cells["idlocadorpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelapagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaPagar.Text))
                    {

                        if (oRow.Cells["situacaopagar"].Value.ToString() == "A" &&
                            oRow.Cells["stoperacao"].Value.ToString() == "")
                        {
                            oRow.Cells["stoperacao"].Value = "C";
                        }
                        else if (oRow.Cells["situacaopagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacao"].Value.ToString() == "C")
                        {
                            oRow.Cells["stoperacao"].Value = "";
                        }
                        else if (oRow.Cells["situacaopagar"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacao"].Value.ToString() == "")
                        {
                            oRow.Cells["stoperacao"].Value = "R";
                        }
                        else if (oRow.Cells["situacaopagar"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacao"].Value.ToString() == "R")
                        {
                            oRow.Cells["stoperacao"].Value = "";
                        }
                        else if (oRow.Cells["situacaopagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacao"].Value.ToString() == "I")
                        {
                            grdLocacaoPagar.Rows.Remove(oRow);
                        }
                        else if (oRow.Cells["situacaopagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacao"].Value.ToString() == "A")
                        {
                            MessageBox.Show("Parcela está em alteração, não pode ser excluida", "Aviso");
                            alteraProventos = false;
                        }


                    }

                }

                if (alteraProventos)
                {

                    // marca para cancelamento os proventos referentes a a parcela cancelada
                    foreach (DataGridViewRow oRow in grdCCPagar.Rows)
                    {

                        if (EmcResources.cInt(oRow.Cells["idlocadorccpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text) &&
                            EmcResources.cInt(oRow.Cells["nroparcelaccpagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaPagar.Text))
                        {

                            if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                            {
                                oRow.Cells["stoperacaoccpagar"].Value = "C";
                            }
                            else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                     oRow.Cells["stoperacaoccpagar"].Value.ToString() == "C")
                            {
                                oRow.Cells["stoperacaoccpagar"].Value = "";
                            }
                            else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "C" &&
                                     oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                            {
                                oRow.Cells["stoperacaoccpagar"].Value = "R";
                            }
                            else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "C" &&
                                     oRow.Cells["stoperacaoccpagar"].Value.ToString() == "R")
                            {
                                oRow.Cells["stoperacaoccpagar"].Value = "";
                            }
                            else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                     oRow.Cells["stoperacaoccpagar"].Value.ToString() == "I")
                            {
                                grdCCPagar.Rows.Remove(oRow);
                            }
                        }

                    }
                }

                btnLimpaPagar_Click(null, null);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtDtaFinalParcelaPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (btnIncluiPagar.Enabled)
                {
                    btnIncluiPagar.Focus();
                }
                else
                {
                    btnAlteraPagar.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnIntegPagar_Click(object sender, EventArgs e)
        {
            try
            {
                string stoper = "";
                foreach (DataGridViewRow oRow in grdLocacaoPagar.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idlocadorpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelapagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaPagar.Text))
                    {
                        if (oRow.Cells["stoperacao"].Value.ToString() == "" && oRow.Cells["situacaopagar"].Value.ToString() == "G")
                        {
                            stoper = "G";
                        }
                        oRow.Cells["stoperacao"].Value = stoper;

                    }
                }

                btnLimpaPagar_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        #endregion

        #region "Tratamento de Campos - Tab - Proventos de Parcela a Pagar"

        private void txtCPFCNPJCCPagar_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJCCPagar.Mask = "";
            lblCnpjCCPagar.Text = "CNPJ/CPF";
            txtCPFCNPJCCPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void txtCPFCNPJCCPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJCCPagar.Text))
                {
                    txtIdLocadorCCPagar.ReadOnly = false;
                    txtIdLocadorCCPagar.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJCCPagar.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJCCPagar.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJCCPagar.Mask = "000.000.000-00";
                        lblCnpjCCPagar.Text = "CPF";
                        txtCPFCNPJCCPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJCCPagar.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJCCPagar.Mask = "00.000.000/0000-00";
                        lblCnpjCCPagar.Text = "CNPJ";
                        txtCPFCNPJCCPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCnpjCCPagar.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJCCPagar.Text.Trim().Length > 0)
                    {
                        FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                        Fornecedor oFornecedor = new Fornecedor();

                        oFornecedor = oFornecedorRN.ObterPor(empMaster, txtCPFCNPJPagar.Text.Trim());

                        if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocadorCCPagar.ReadOnly = false;
                            txtIdLocadorCCPagar.Focus();
                        }
                        else
                        {
                            txtIdLocadorCCPagar.Text = oFornecedor.idPessoa.ToString();
                            txtNomeLocadorCCPagar.Text = oFornecedor.pessoa.nome;
                            txtIdLocadorCCPagar.ReadOnly = true;

                            bool encontrou = false;

                            foreach (DataGridViewRow oRow in grdLocador.Rows)
                            {
                                if (EmcResources.cInt(oRow.Cells["idlocador"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                                {
                                    encontrou = true;
                                }
                            }


                            if (!encontrou)
                            {
                                MessageBox.Show("Locador não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnLimpaCCPagar_Click(null, null);
                            }
                            else
                            {
                                txtNroParcelaCCPagar.Focus();
                            }
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

        private void txtIdLocadorCCPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocadorCCPagar.Text))
                {
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                    Fornecedor oFornecedor = new Fornecedor();

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdLocadorCCPagar.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCPFCNPJCCPagar.Focus();
                    }
                    else
                    {
                        txtIdLocadorCCPagar.Text = oFornecedor.idPessoa.ToString();
                        txtCPFCNPJCCPagar.Text = oFornecedor.pessoa.cnpjCpf;
                        txtNomeLocadorCCPagar.Text = oFornecedor.pessoa.nome;

                        if (txtCPFCNPJCCPagar.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJCCPagar.Mask = "000.000.000-00";
                            lblCnpjCCPagar.Text = "CPF";
                        }
                        else if (txtCPFCNPJCCPagar.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJCCPagar.Mask = "00.000.000/0000-00";
                            lblCnpjCCPagar.Text = "CNPJ";
                        }

                        bool encontrou = false;

                        foreach (DataGridViewRow oRow in grdLocador.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idlocador"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                            {
                                encontrou = true;
                            }
                        }


                        if (!encontrou)
                        {
                            MessageBox.Show("Locador não faz parte do contrato", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpaCCPagar_Click(null, null);
                        }
                        else
                        {
                            txtNroParcelaCCPagar.Enabled = true;
                            txtNroParcelaCCPagar.Focus();
                        }



                    }

                }
                else
                {
                    txtCPFCNPJCCPagar.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnLocadorCCPagar_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocadorCCPagar.Text = "";
                else
                    txtIdLocadorCCPagar.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocadorCCPagar_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtNroParcelaCCPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtNroParcelaCCPagar.Text) > 0 && EmcResources.cInt(txtIdLocadorCCPagar.Text) > 0)
                {
                    bool encontrou = false;
                    string sitParcelaPagar = "";
                    int idParcela = 0;
                    //verifica se a parcela existe para o locatário.
                    foreach (DataGridViewRow oRow in grdLocacaoPagar.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["idlocadorpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text) &&
                            EmcResources.cInt(oRow.Cells["nroparcelapagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCPagar.Text))
                        {
                            encontrou = true;
                            sitParcelaPagar = oRow.Cells["situacaopagar"].Value.ToString();
                            idParcela = EmcResources.cInt(oRow.Cells["idlocacaopagar"].Value.ToString());
                        }
                    }

                    txtidparcelaccpagar.Text = idParcela.ToString();


                    if (!encontrou)
                    {
                        MessageBox.Show("Parcela não encontrada para este locador", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNroParcelaCCPagar.Focus();

                        btnLimpaCCPagar.Enabled = true;
                        btnIncluiCCPagar.Enabled = false;
                        btnAlteraCCPagar.Enabled = false;
                        btnExcluiCCPagar.Enabled = false;
                    }
                    else
                        txtIdProventoCCPagar.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtIdProventoCCPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdProventoCCPagar.Text))
                {
                    LocacaoProventosRN oProventoRN = new LocacaoProventosRN(Conexao, objOcorrencia, empMaster);
                    LocacaoProventos oProvento = new LocacaoProventos();

                    oProvento.idLocacaoProventos = EmcResources.cInt(txtIdProventoCCPagar.Text);
                    oProvento = oProventoRN.ObterPor(oProvento);

                    if (EmcResources.cInt(oProvento.idLocacaoProventos.ToString()) == 0)
                    {
                        MessageBox.Show("Provento não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //carrega informações de proventos
                        txtIdProventoCCPagar.Text = oProvento.idLocacaoProventos.ToString();
                        txtProventoCCPagar.Text = oProvento.Descricao;
                        txtTipoProventoCCPagar.Text = oProvento.TipoProvento;

                        bool encontrou = false;

                        //verifica se já existe o provento para a parcela e locador
                        foreach (DataGridViewRow oRow in grdCCPagar.Rows)
                        {
                            if (EmcResources.cInt(oRow.Cells["idproventoccpagar"].Value.ToString()) == EmcResources.cInt(txtIdProventoCCPagar.Text) &&
                                EmcResources.cInt(oRow.Cells["nroparcelaccpagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCPagar.Text) &&
                                EmcResources.cInt(oRow.Cells["idlocadorccpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                            {
                                encontrou = true;

                                txtDtaEmissaoCCPagar.Text = oRow.Cells["dataemissaoccpagar"].Value.ToString();
                                txtDtaLanctoCCPagar.Text = oRow.Cells["datalanctoccpagar"].Value.ToString();
                                txtValorCCPagar.Text = oRow.Cells["valorccpagar"].Value.ToString();
                                txtDescricaoCCPagar.Text = oRow.Cells["descricaoccpagar"].Value.ToString();
                                txtSitCCPagar.Text = oRow.Cells["situacaoccpagar"].Value.ToString();
                                txtStCCPagar.Text = oRow.Cells["stoperacaoccpagar"].Value.ToString();
                            }
                        }


                        if (encontrou)
                        {
                            //MessageBox.Show("Provento já cadastrado nesta parcela para o locatário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLimpaCCPagar.Enabled = true;
                            btnIncluiCCPagar.Enabled = false;
                            btnAlteraCCPagar.Enabled = true;
                            btnExcluiCCPagar.Enabled = true;

                            //configura botões de acordo com o status do provento
                            if (txtStCCPagar.Text == "A" || String.IsNullOrEmpty(txtStCCPagar.Text) || txtStCCPagar.Text == "I")
                            {
                                btnLimpaCCPagar.Enabled = true;
                                btnIncluiCCPagar.Enabled = false;
                                btnAlteraCCPagar.Enabled = true;
                                btnExcluiCCPagar.Enabled = true;
                            }
                            else if (txtStCCPagar.Text == "C" || txtStCCPagar.Text == "R")
                            {
                                btnLimpaCCPagar.Enabled = true;
                                btnIncluiCCPagar.Enabled = false;
                                btnAlteraCCPagar.Enabled = false;
                                btnExcluiCCPagar.Enabled = true;
                            }

                            //configura botões de acordo com a situação do provento
                            if (txtSitCCPagar.Text == "G")
                            {
                                btnLimpaCCPagar.Enabled = true;
                                btnIncluiCCPagar.Enabled = false;
                                btnAlteraCCPagar.Enabled = false;
                                btnExcluiCCPagar.Enabled = false;
                            }
                            else if (txtSitCCPagar.Text == "C")
                            {
                                btnLimpaCCPagar.Enabled = true;
                                btnIncluiCCPagar.Enabled = false;
                                btnAlteraCCPagar.Enabled = false;
                                btnExcluiCCPagar.Enabled = true;
                            }

                        }
                        else
                        {
                            btnLimpaCCPagar.Enabled = true;
                            btnIncluiCCPagar.Enabled = true;
                            btnAlteraCCPagar.Enabled = false;
                            btnExcluiCCPagar.Enabled = false;

                            txtSitCCPagar.Text = "A";
                            txtStCCPagar.Text = "I";

                        }

                        txtDtaEmissaoCCPagar.Focus();

                    }

                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnProventoPagar_Click(object sender, EventArgs e)
        {
            try
            {
                psqLocacaoProventos ofrm = new psqLocacaoProventos(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                    txtIdProventoCCPagar.Text = "";
                else
                    txtIdProventoCCPagar.Text = retPesquisa.chaveinterna.ToString();

                //txtIdProventoCCReceber_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void grdCCPagar_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdCCPagar.Rows[grdCCPagar.CurrentRow.Index].Cells["situacaoccpagar"].Value.ToString() != "G")
                {
                    txtIdLocadorCCPagar.Text = grdCCPagar.Rows[grdCCPagar.CurrentRow.Index].Cells["idlocadorccpagar"].Value.ToString();
                    txtIdLocadorCCPagar_Validating(null, null);

                    txtNroParcelaCCPagar.Text = grdCCPagar.Rows[grdCCPagar.CurrentRow.Index].Cells["nroparcelaccpagar"].Value.ToString();
                    txtNroParcelaCCPagar.Enabled = false;

                    txtIdProventoCCPagar.Text = grdCCPagar.Rows[grdCCPagar.CurrentRow.Index].Cells["idproventoccpagar"].Value.ToString();
                    txtIdProventoCCPagar_Validating(null, null);
                }
                else
                {
                    MessageBox.Show("Parcela gerada para o financeiro, não pode sofrer manutenção.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void txtDescricaoCCPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (btnIncluiCCPagar.Enabled)
                {
                    btnIncluiCCPagar.Focus();
                }
                else
                {
                    btnAlteraCCPagar.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnLimpaCCPagar_Click(object sender, EventArgs e)
        {
            txtCPFCNPJCCPagar.Text = "";
            txtIdLocadorCCPagar.Text = "";
            txtNomeLocadorCCPagar.Text = "";
            txtNroParcelaCCPagar.Text = "";
            txtIdProventoCCPagar.Text = "";
            txtProventoCCPagar.Text = "";
            txtTipoProventoCCPagar.Text = "";
            txtDtaEmissaoCCPagar.Text = "";
            txtDtaLanctoCCPagar.Text = "";
            txtValorCCPagar.Text = "0,00";
            txtDescricaoCCPagar.Text = "";
        }

        private void btnAlteraCCPagar_Click(object sender, EventArgs e)
        {
            try
            {
                string stoper = "";
                foreach (DataGridViewRow oRow in grdCCPagar.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idproventoccpagar"].Value.ToString()) == EmcResources.cInt(txtIdProventoCCPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelaccpagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["idlocadorccpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                    {
                        if (oRow.Cells["stoperacaoccpagar"].Value.ToString() == "A" || oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                        {
                            stoper = "A";
                        }
                        else if (oRow.Cells["stoperacaoccpagar"].Value.ToString() == "I")
                        {
                            stoper = "I";
                        }

                        oRow.Cells["dataemissaoccpagar"].Value = txtDtaEmissaoCCPagar.Text;
                        oRow.Cells["datalanctoccpagar"].Value = txtDtaLanctoCCPagar.Text;
                        oRow.Cells["valorccpagar"].Value = txtValorCCPagar.Value;
                        oRow.Cells["descricaoccpagar"].Value = txtDescricaoCCPagar.Text;
                        oRow.Cells["stoperacaoccpagar"].Value = stoper;

                    }
                }

                recalculaPagar(EmcResources.cInt(txtIdLocadorCCPagar.Text), EmcResources.cInt(txtNroParcelaCCPagar.Text));

                btnLimpaCCPagar_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnExcluiCCPagar_Click(object sender, EventArgs e)
        {
            try
            {
                //marca o provento da parcela para cancelamento na aba de locacao CC receber
                foreach (DataGridViewRow oRow in grdCCPagar.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idproventoccpagar"].Value.ToString()) == EmcResources.cInt(txtIdProventoCCPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["nroparcelaccpagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["idlocadorccpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                    {

                        if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                            oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                        {
                            oRow.Cells["stoperacaoccpagar"].Value = "C";
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "C")
                        {
                            oRow.Cells["stoperacaoccpagar"].Value = "";
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                        {
                            oRow.Cells["stoperacaoccpagar"].Value = "R";
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "R")
                        {
                            oRow.Cells["stoperacaoccpagar"].Value = "";
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "I")
                        {
                            grdCCPagar.Rows.Remove(oRow);
                        }


                    }

                }

                recalculaPagar(EmcResources.cInt(txtIdLocadorCCPagar.Text), EmcResources.cInt(txtNroParcelaCCPagar.Text));

                btnLimpaCCPagar_Click(null, null);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnIncluiCCPagar_Click(object sender, EventArgs e)
        {
            try
            {

                grdCCPagar.Rows.Add(txtNomeLocadorCCPagar.Text,
                                               txtIdLocadorCCPagar.Text,
                                               txtNroParcelaCCPagar.Text,
                                               txtProventoCCPagar.Text,
                                               txtIdProventoCCPagar.Text,
                                               txtTipoProventoCCPagar.Text,
                                               txtDtaLanctoCCPagar.Text,
                                               txtValorCCPagar.Value,
                                               txtSitCCPagar.Text,
                                               "I",
                                               empMaster,
                                               txtDtaEmissaoCCPagar.Text,
                                               0,
                                               "",
                                               txtidparcelaccpagar.Text,
                                               txtIdLocacaoContrato.Text);

                recalculaPagar(EmcResources.cInt(txtIdLocadorCCPagar.Text), EmcResources.cInt(txtNroParcelaCCPagar.Text));

                btnLimpaCCPagar_Click(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void recalculaPagar(int idLocador, int nroParcela)
        {
            Decimal valorParcela = 0;

            try
            {
                //marca o provento da parcela para cancelamento na aba de locacao CC receber
                foreach (DataGridViewRow oRow in grdCCPagar.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["nroparcelaccpagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCPagar.Text) &&
                        EmcResources.cInt(oRow.Cells["idlocadorccpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                    {

                        if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                            oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                        {
                            if (oRow.Cells["tipoproventoccpagar"].Value.ToString() == "D")
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                            else
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                            oRow.Cells["stoperacaoccpagar"].Value.ToString() == "A")
                        {
                            if (oRow.Cells["tipoproventoccpagar"].Value.ToString() == "D")
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                            else
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "C")
                        {
                            //Não faz nada pois o lancamento vai ser cancelado
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "")
                        {
                            //não faz nada pois o lancamento está cancelado
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "C" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "R")
                        {
                            //refaz o calculo porque o lancamento vai ser restaurado.
                            if (oRow.Cells["tipoproventoccpagar"].Value.ToString() == "D")
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                            else
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                        }
                        else if (oRow.Cells["situacaoccpagar"].Value.ToString() == "A" &&
                                 oRow.Cells["stoperacaoccpagar"].Value.ToString() == "I")
                        {
                            //considera lancamentos que estão sendo incluidos.
                            if (oRow.Cells["tipoproventoccpagar"].Value.ToString() == "D")
                                valorParcela = valorParcela - EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                            else
                                valorParcela = valorParcela + EmcResources.cCur(oRow.Cells["valorccpagar"].Value.ToString());
                        }

                    }

                }

                //atualiza o valor da Parcela apartir dos lancamentos.
                foreach (DataGridViewRow oRow2 in grdLocacaoPagar.Rows)
                {

                    if (EmcResources.cInt(oRow2.Cells["nroparcelapagar"].Value.ToString()) == EmcResources.cInt(txtNroParcelaCCPagar.Text) &&
                        EmcResources.cInt(oRow2.Cells["idlocadorpagar"].Value.ToString()) == EmcResources.cInt(txtIdLocadorCCPagar.Text))
                    {
                        oRow2.Cells["valorparcelapagar"].Value = EmcResources.cCur(valorParcela.ToString());

                        if (oRow2.Cells["stoperacao"].Value.ToString() == "I")
                        {
                            oRow2.Cells["stoperacao"].Value = "I";
                        }
                        else
                            oRow2.Cells["stoperacao"].Value = "A";
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }

        }


        #endregion

        




    }
}
