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
using EMCIntegracaoModel;
using EMCIntegracaoRN;
using EMCImobModel;
using System.Collections;


namespace EMCFinanceiro
{
    public partial class frmIntegracao : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmIntegracao";
        private const string nomeAplicativo = "EMCFinanceiro";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        private double txaJurosReceber = 0;
        private double txaMultaReceber = 0;

        private double txaJurosPagar = 0;
        private double txaMultaPagar = 0;

        private int idMoedaCorrente = 0;
        private Boolean utilizaIndexador = false; 

        /* Id Tipos de Documento */
        int tipoLocacaoReceber = 0;
        int tipoLocacaoPagar = 0;
        int tipoDepesaImovel = 0;
        int tipoIptu = 0;
        int tipoCapitacao = 0;
        int apliLocacaoReceber = 0;
        int apliLocacaoPagar = 0;

        public frmIntegracao()
        {
            InitializeComponent();
        }

        public frmIntegracao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmIntegracao_Load(object sender, EventArgs e)
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
            
            CancelaOperacao();

            this.ActiveControl = cboSistema;

        }


        #region [metodos para tratamento das informacoes]

        private void constroiCombos()
        {
            try
            {
                travaBotao("btnAltera");
                travaBotao("btnExclui");

                /* Busca a taxa de juros e multa padrão da empresa */
                ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                txaJurosReceber = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "TAXA_JUROS"));
                txaMultaReceber = EmcResources.cDouble(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "TAXA_MULTA"));

                /* Parametros id tipos de documentos */
                tipoLocacaoReceber = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "LOCACAORECEBER", "TIPODOCUMENTO"));
                tipoLocacaoPagar = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "LOCACAOPAGAR", "TIPODOCUMENTO"));
                tipoIptu = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "IPTU", "TIPODOCUMENTO"));
                tipoDepesaImovel = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "DESPESAIMOVEL", "TIPODOCUMENTO"));
                tipoCapitacao = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "CAPITACAO", "TIPODOCUMENTO"));

                apliLocacaoReceber = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "LOCACAORECEBER", "APLICACAO"));
                apliLocacaoPagar = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCINTEGRACAO", "LOCACAOPAGAR", "APLICACAO"));

                /* Identifica o codigo do indexador da moeda corrente no pais */
                idMoedaCorrente = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "MOEDA_CORRENTE"));

                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "UTILIZA_INDEXADOR") == "S")
                    utilizaIndexador = true;
                else
                    utilizaIndexador = false;

                //Carregamento de Combobox do Sistema
                List<Aplicativo> lstAplicativo = new List<Aplicativo>();
                AplicativoRN oAplicativoRN = new AplicativoRN(Conexao, objOcorrencia, codempresa);
                lstAplicativo = oAplicativoRN.lstAplicativo();
                
                ArrayList arrAplicativo = new ArrayList();
                arrAplicativo.Add(new popCombo("TODOS SISTEMAS", "TODOS"));
                foreach(Aplicativo oApl in lstAplicativo)
                {
                    if (oApl.nome != "EMCLIBRARY" && oApl.nome != "EMCSECURITY")
                        arrAplicativo.Add(new popCombo(oApl.descricao, oApl.nome));
                }
                cboSistema.DataSource = arrAplicativo;
                cboSistema.DisplayMember = "nome";
                cboSistema.ValueMember = "valor";

                cboSistema.SelectedIndex = 0;

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message, "Erro", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        private Boolean verificaDocumento(ReceberDocumento oRcdoc)
        {
            ReceberDocumentoRN oReceberRN = new ReceberDocumentoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }

        private ReceberDocumento montaReceberDocumento(int idIntegracao)
        {
                        
            IntegFinanceiroRN oIntegRN = new IntegFinanceiroRN(Conexao, objOcorrencia, codempresa);
            var oIntegra = oIntegRN.ObterPor(idIntegracao);

            ReceberDocumento oReceber = new ReceberDocumento();

            oReceber.idReceberDocumento = 0;
            oReceber.cadastro_datahora = DateTime.Now;
            oReceber.cadastro_idusuario = EmcResources.cInt(usuario);
            oReceber.codEmpresa = codempresa;
            oReceber.dataEntrada = DateTime.Now;
            oReceber.diaFixo = "";
            oReceber.idFatura = 0;

            Indexador oIndexador = new Indexador();
            oIndexador.idIndexador = idMoedaCorrente;
            oReceber.indexador = oIndexador;

            oReceber.jurosCalculado = 0;
            oReceber.multaCalculado = 0;
            
            oReceber.periodicidade = "M";
            oReceber.situacao = "A";
            
            if (oIntegra.imob_LocacaoReceber.idLocacaoReceber > 0)
            {
                oReceber.nroDocumento = "IMOB: " + oIntegra.imob_LocacaoReceber.contrato.identificacaoContrato + " P" + oIntegra.imob_LocacaoReceber.nroParcela.ToString();
                oReceber.nroParcelas = 1;
                oReceber.origemDocumento = oIntegra.sistemaOrigem;
                oReceber.cliente = oIntegra.imob_LocacaoReceber.locatario;
                oReceber.dataEmissao = oIntegra.imob_LocacaoReceber.contrato.dataContrato;
                oReceber.descricao = "Contrato : " + oIntegra.imob_LocacaoReceber.contrato.identificacaoContrato +
                                     " Parcela : " + oIntegra.imob_LocacaoReceber.nroParcela;
                oReceber.taxaJuros = oIntegra.imob_LocacaoReceber.contrato.taxaJuros;
                oReceber.taxaMulta = oIntegra.imob_LocacaoReceber.contrato.taxaMulta;

                TipoDocumento oTpDoc = new TipoDocumento();
                TipoDocumentoRN oTpDocRN = new TipoDocumentoRN(Conexao,objOcorrencia,codempresa);
                oTpDoc.idTipoDocumento = tipoLocacaoReceber;
                oTpDoc = oTpDocRN.ObterPor(oTpDoc);
                oReceber.tipoDocumento = oTpDoc;

                oReceber.valorDocumento = oIntegra.imob_LocacaoReceber.valorParcela;


                /* Gera parcelamento do documento */
                ReceberParcela oParcela = new ReceberParcela();
                oParcela.idReceberParcela = 0;
                oParcela.receberDocumento = oReceber;
                oParcela.boleto_NossoNumero ="";
                oParcela.cadastro_datahora = DateTime.Now;
                oParcela.cadastro_idusuario = EmcResources.cInt(usuario);
                oParcela.codEmpresa = codempresa;
                oParcela.dataLimiteAcordo = null;
                oParcela.dataQuitacao = null;
                oParcela.dataVencimento = oIntegra.imob_LocacaoReceber.dataVencimento;
                oParcela.descontoAcordo = 0;
                oParcela.descontoOriginal = 0;
                oParcela.dtaUltCalculoJuros = null;
                oParcela.jurosAcordo = 0;
                oParcela.jurosOriginal = 0;
                oParcela.jurosPrevisto =0;
                oParcela.multaAcordo =0;
                oParcela.multaOriginal = 0;
                oParcela.multaPrevisto = 0;
                oParcela.nroParcela = 1;
                oParcela.saldoPagar = oIntegra.imob_LocacaoReceber.valorParcela;
                oParcela.saldoPago = 0;
                oParcela.situacao = "A";
                oParcela.situacaoAcordo = "";
                oParcela.status = "I";

                Formulario oFormulario = new Formulario();
                oParcela.formulario = oFormulario;

                
                List<ReceberBaixa> lstBaixas = new List<ReceberBaixa>();
                oParcela.baixas = lstBaixas;

                TipoCobranca oTpCobr = new TipoCobranca();
                oTpCobr.idTipoCobranca = 1;
                oParcela.tipoCobranca = oTpCobr;

                oParcela.valorDesconto =0;
                oParcela.valorJuros = 0;
                oParcela.valorParcela = oIntegra.imob_LocacaoReceber.valorParcela;
                
                List<ReceberParcela> lstParcelas = new List<ReceberParcela>();
                lstParcelas.Add(oParcela);

                oReceber.parcelas = lstParcelas;

                /* Gera base rateio do documento */
                ReceberBaseRateio oRateio = new ReceberBaseRateio();
                oRateio.codEmpresa = codempresa;
                oRateio.idReceberDocumento = 0;
                oRateio.percentualRateio = 100;
                oRateio.valorRateio = oIntegra.imob_LocacaoReceber.valorParcela;
                oRateio.status = "I";
                oRateio.idReceberBaseRateio = 0;
                oRateio.contaCusto = oIntegra.imob_LocacaoReceber.contrato.imovel.contaCusto;
                Aplicacao oApl = new Aplicacao();
                oApl.idAplicacao = apliLocacaoReceber;
                oRateio.aplicacao = oApl;

                List<ReceberBaseRateio> lstRateio = new List<ReceberBaseRateio>();
                lstRateio.Add(oRateio);

                oReceber.baseRateio = lstRateio;
            }

            return oReceber;
        }

        private PagarDocumento montaPagarDocumento(int idIntegracao)
        {
            PagarDocumento oPagar = new PagarDocumento();

            IntegFinanceiroRN oIntegRN = new IntegFinanceiroRN(Conexao, objOcorrencia, codempresa);
            var oIntegra = oIntegRN.ObterPor(idIntegracao);

            oPagar.idPagarDocumento = 0;
            oPagar.cadastro_datahora = DateTime.Now;
            oPagar.cadastro_idusuario = EmcResources.cInt(usuario);
            oPagar.codEmpresa = codempresa;
            oPagar.dataEntrada = DateTime.Now;
            oPagar.diaFixo = "";
            oPagar.idFatura = 0;

            Indexador oIndexador = new Indexador();
            oIndexador.idIndexador = idMoedaCorrente;
            oPagar.indexador = oIndexador;

             
            
            oPagar.periodicidade = "M";
            oPagar.situacao = "A";

            if (oIntegra.imob_LocacaoPagar.idLocacaoPagar > 0)
            {
                oPagar.nroDocumento = "IMOB: " + oIntegra.imob_LocacaoPagar.contrato.identificacaoContrato + " P" + oIntegra.imob_LocacaoPagar.nroParcela.ToString();
                oPagar.nroParcelas = 1;
                oPagar.origemDocumento = oIntegra.sistemaOrigem;
                oPagar.fornecedor = oIntegra.imob_LocacaoPagar.locador;
                oPagar.dataEmissao = oIntegra.imob_LocacaoPagar.contrato.dataContrato;
                oPagar.descricao = "Contrato : " + oIntegra.imob_LocacaoPagar.contrato.identificacaoContrato +
                                     " Parcela : " + oIntegra.imob_LocacaoPagar.nroParcela;
                oPagar.taxaJuros = 0;
                oPagar.taxaMulta = 0;

                TipoDocumento oTpDoc = new TipoDocumento();
                TipoDocumentoRN oTpDocRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                oTpDoc.idTipoDocumento = tipoLocacaoPagar;
                oTpDoc = oTpDocRN.ObterPor(oTpDoc);
                oPagar.tipoDocumento = oTpDoc;

                oPagar.valorDocumento = oIntegra.imob_LocacaoPagar.valorParcela;

                oPagar.valorIndexado = EmcResources.cDouble(oIntegra.imob_LocacaoPagar.valorParcela.ToString());
                oPagar.dataUltimaCorrecao = DateTime.Now;
                oPagar.valorIndice = 1;


                /* Gera parcelamento do documento */
                PagarParcela oParcela = new PagarParcela();
                oParcela.idPagarParcela = 0;
                oParcela.pagarDocumento = oPagar;
                oParcela.cadastro_datahora = DateTime.Now;
                oParcela.cadastro_idusuario = EmcResources.cInt(usuario);
                oParcela.codEmpresa = codempresa;
                oParcela.dataQuitacao = null;
                oParcela.dataVencimento = oIntegra.imob_LocacaoPagar.dataVencimento;
                oParcela.jurosPrevisto = 0;
                oParcela.multaPrevisto = 0;
                oParcela.nroParcela = 1;
                oParcela.saldoPagar = oIntegra.imob_LocacaoPagar.valorParcela;
                oParcela.saldoPago = 0;
                oParcela.situacao = "A";
                oParcela.status = "I";

                List<PagarBaixa> lstBaixas = new List<PagarBaixa>();
                oParcela.baixas = lstBaixas;

                TipoCobranca oTpCobr = new TipoCobranca();
                oTpCobr.idTipoCobranca = 1;
                oParcela.tipoCobranca = oTpCobr;

                oParcela.valorDesconto = 0;
                oParcela.valorJuros = 0;
                oParcela.valorParcela = oIntegra.imob_LocacaoPagar.valorParcela;
                oParcela.dataUltimaCorrecao = DateTime.Now;
                oParcela.valorCorrecaoMonetaria = 0;
                oParcela.valorIndexado = EmcResources.cDouble(oIntegra.imob_LocacaoPagar.valorParcela.ToString());
                oParcela.valorIndice = 1;

                List<PagarParcela> lstParcelas = new List<PagarParcela>();
                lstParcelas.Add(oParcela);

                oPagar.parcelas = lstParcelas;

                /* Gera base rateio do documento */
                PagarBaseRateio oRateio = new PagarBaseRateio();
                oRateio.codEmpresa = codempresa;
                oRateio.idPagarDocumento = 0;
                oRateio.percentualRateio = 100;
                oRateio.valorRateio = oIntegra.imob_LocacaoPagar.valorParcela;
                oRateio.status = "I";
                oRateio.idPagarBaseRateio = 0;
                oRateio.contaCusto = oIntegra.imob_LocacaoPagar.contrato.imovel.contaCusto;
                Aplicacao oApl = new Aplicacao();
                oApl.idAplicacao = apliLocacaoPagar;
                oRateio.aplicacao = oApl;

                List<PagarBaseRateio> lstRateio = new List<PagarBaseRateio>();
                lstRateio.Add(oRateio);

                oPagar.baseRateio = lstRateio;
            }
            return oPagar;
        }

        private void montaTela(ReceberDocumento oReceberDocumento)
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
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            constroiCombos();
        }

        public override void BuscaObjeto()
        {
            try
            {
                montaGrid();
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

          
            objOcorrencia.chaveidentificacao = "";
            constroiCombos();

        }

        public override void SalvaObjeto()
        {
            try
            {
               int idIntegracao = 0;
               foreach(DataGridViewRow oRow in grdIntegracao.Rows)
               {
                   idIntegracao = EmcResources.cInt(oRow.Cells["idintegracao"].Value.ToString());
                   DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                   ch1 = (DataGridViewCheckBoxCell) oRow.Cells[0];

                   IntegFinanceiroRN oIntFinanceiroRN = new IntegFinanceiroRN(Conexao, objOcorrencia, codempresa);

                   if (ch1.Value == ch1.TrueValue)
                   {
                       IntegracaoRN oIntegraRN = new IntegracaoRN(Conexao, objOcorrencia, codempresa);

                       var oIntegra = oIntFinanceiroRN.ObterPor(idIntegracao);
                       oIntegra.dataFinanceiro = DateTime.Now;
                       oIntegra.idUsuarioFinanceiro = EmcResources.cInt(usuario);
                       oIntegra.statusOperacao = "P";

                       if (oRow.Cells["tipointegracao"].Value.ToString() == "R")
                       {
                           ReceberDocumento oReceber = new ReceberDocumento();
                           
                           
                           oReceber = montaReceberDocumento(idIntegracao);

                           oIntegraRN.Salvar(oReceber,oIntegra);

                       }
                       else
                       {
                           PagarDocumento oPagar = new PagarDocumento();
                           
                           oPagar = montaPagarDocumento(idIntegracao);

                           oIntegraRN.Salvar(oPagar, oIntegra);

                       }
                   }
               }
               montaGrid();
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
               

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region [metodos para tratamento da datagridview]

        private void montaGrid()
        {
            try
            {
                grdIntegracao.Rows.Clear();

                List<IntegFinanceiro> lstIntegracao = new List<IntegFinanceiro>();
                IntegFinanceiroRN oIntegRN = new IntegFinanceiroRN(Conexao, objOcorrencia, codempresa);
                lstIntegracao = oIntegRN.lstGeracaoIntegracao(cboSistema.SelectedValue.ToString());

                string modulo ="";
                string nrodocumento ="";
                DateTime vencimento = DateTime.Now.Date;
                decimal valordocumento = 0;
                string nomepessoa ="";
                int? idpessoa = 0;
                string tipodocumento = "";
                foreach(IntegFinanceiro oIntegra in lstIntegracao)
                {
                    tipodocumento = "";
                    /* monta grid de acordo com o tipo de documento recebido */
                    if (oIntegra.imob_BaixaCaptacao.idBaixaCaptacao > 0 && chkPagar.Checked)
                    {
                        modulo = "Captação";
                        nrodocumento = "Captação : " + oIntegra.imob_BaixaCaptacao.idBaixaCaptacao.ToString();
                        vencimento = oIntegra.imob_BaixaCaptacao.dataBaixa;
                        valordocumento = oIntegra.imob_BaixaCaptacao.valorBaixa;
                        tipodocumento = oIntegra.tipoIntegracao;
                        nomepessoa = "";
                        idpessoa = 0;
                    }
                    else if (oIntegra.imob_DespesaImovel.idDespesaImovel > 0 && chkPagar.Checked)
                    {
                        modulo = "Despesa Imovel";
                        nrodocumento = "Desp.Imovel: " + oIntegra.imob_DespesaImovel.idDespesaImovel.ToString();
                        vencimento = oIntegra.imob_DespesaImovel.dataLancamento;
                        valordocumento = oIntegra.imob_DespesaImovel.valorDespesa;
                        tipodocumento = oIntegra.tipoIntegracao;
                        nomepessoa = oIntegra.imob_DespesaImovel.fornecedor.pessoa.nome;
                        idpessoa = oIntegra.imob_DespesaImovel.fornecedor.idPessoa;
                    }
                    else if (oIntegra.imob_Iptu.idIptu > 0 && chkPagar.Checked)
                    {
                        modulo = "IPTU";
                        nrodocumento = oIntegra.imob_Iptu.imovel.codigoImovel + " - IPTU: " + oIntegra.imob_Iptu.anoBase + " Parc: " + oIntegra.imob_Iptu.nroParcela.ToString(); 
                        vencimento = oIntegra.imob_Iptu.dataVencimento;
                        valordocumento = oIntegra.imob_Iptu.valorParcela;
                        tipodocumento = oIntegra.tipoIntegracao;
                        nomepessoa = "";
                        idpessoa = 0;

                    }
                    else if (oIntegra.imob_LocacaoPagar.idLocacaoPagar > 0 && chkPagar.Checked)
                    {
                        modulo = "Locação Pagar";
                        nrodocumento = "IMOB: " + oIntegra.imob_LocacaoPagar.contrato.identificacaoContrato + " P" + oIntegra.imob_LocacaoPagar.nroParcela.ToString(); 
                        vencimento = oIntegra.imob_LocacaoPagar.dataVencimento;
                        valordocumento = oIntegra.imob_LocacaoPagar.valorParcela;
                        tipodocumento = oIntegra.tipoIntegracao;
                        nomepessoa = oIntegra.imob_LocacaoPagar.locador.pessoa.nome;
                        idpessoa = oIntegra.imob_LocacaoPagar.locador.idPessoa;
                    }
                    else if (oIntegra.imob_LocacaoReceber.idLocacaoReceber > 0 && chkReceber.Checked)
                    {
                        modulo = "Locação Receber";
                        nrodocumento = "IMOB: " + oIntegra.imob_LocacaoReceber.contrato.identificacaoContrato + " P" + oIntegra.imob_LocacaoReceber.nroParcela.ToString();
                        vencimento = oIntegra.imob_LocacaoReceber.dataVencimento;
                        valordocumento = oIntegra.imob_LocacaoReceber.valorParcela;
                        tipodocumento = oIntegra.tipoIntegracao;
                        nomepessoa = oIntegra.imob_LocacaoReceber.locatario.pessoa.nome;
                        idpessoa = oIntegra.imob_LocacaoReceber.locatario.idPessoa;
                    }

                    if (!String.IsNullOrEmpty(tipodocumento))
                    {
                        grdIntegracao.Rows.Add(
                                false,
                                oIntegra.sistemaOrigem,
                                modulo,
                                tipodocumento,
                                nrodocumento,
                                vencimento,
                                valordocumento,
                                nomepessoa,
                                idpessoa,
                                oIntegra.idIntegFinanceiro
                            );
                    }
                }

                if (grdIntegracao.Rows.Count>0)
                {
                    AtivaInsercao();
                }

            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion
    }
}
