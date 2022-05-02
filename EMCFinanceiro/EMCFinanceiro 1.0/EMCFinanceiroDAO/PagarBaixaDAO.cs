using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCFinanceiroDAO
{
    public class PagarBaixaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
        


        public PagarBaixaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia,int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = pOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = pOcorrencia;
            }
            codEmpresa = idEmpresa;
        

        }

        /// <summary>
        /// Calcula Saldo adiantamento para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSdoAdiantamento(Fornecedor codFornecedor)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(sdoamortizacao) as saldopagar from v_pagarbaixa pc " +
                                " where pc.sdoamortizacao > 0 " +
                                  " and pc.fornecedor_codempresa = @codempresa and pc.idfornecedor = @idfornecedor";
                               

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codFornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", codFornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@datavencimento", DateTime.Now.AddDays(30));

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }


        public void Salvar(List<PagarBaixa> lstPagarBaixa, String TipoPagamento)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            //Grava um novo registro de PagarBaixa
            try
            {
                Salvar(lstPagarBaixa, TipoPagamento, Conexao, Transacao);
                Transacao.Commit();
            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }
        }
        public void Salvar(List<PagarBaixa> lstPagarBaixa, String TipoPagamento, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            //FORMAS DE PAGAMENTO
            /*
             * 1 -DINHEIRO - p
             * 2 -CHEQUE - B -> P
             * 3- CHEQUE PRE DATADO B -> H
             * 4- REMESSA ELETRONICA R -> P
             * 5 -AMORTIZACAO ADIANTAMENTO - A
             * 6 - DEB/CRED CONTA - P
             * 7 - BONIFICACAO - G
             * 8 - CARTAO CREDITO - T
             * 9 - FATURA TRF - F
             */
             
            //SITUACOES DE BAIXA
            /*
             * P - PAGO - EFETIVAMENTE REALIZOU PAGAMENTO E SAIU DINHEIRO DA CONTA
             * C - CANCELADO - PARACELA CANCELADA OU COBRANCA INDEVIDA
             * B - PAGO SEM CONFIRMAÇÃO DA EMISSAO DO CH - AGUARDANDO EMISSAO DO CH - SE FOR PRE DATADO VAI PARA SITUACAO H / SE FOR CH NORMAL VAI PARA P
             * H - BAIXA COM CH PRE DATADO - BAIXA A PARCELA E GERA UM NOVO DOCUMENTO DE COBRANCA REALTIVO AO CH PRE
             * A - BAIXA POR AMORTIZAÇÃO DE ADIANTAMENTO - BAIXA PARCELA ATUAL AMORTIZANDO UM PAGAMENTO ANTERIOR DO TIPO ADIANTAMENTO
             * G - BAIXA POR BONIFICAÇÃO 
             * R - BAIXA POR REMESSA SEM CONFIRMAÇÃO DO RETORNO, DEPOIS DE CONFIRMADO VAI PARA A SITUAÇÃO P
             * T - BAIXA POR CARTAO DE CREDITO - BAIXA A PARCELA E TEM QUE GERAR UM NOVO DOCUMENTO DE COBRANCA PARA A OPERADORA DO CARTÃO
             * F - BAIXA POR FATURA - BAIXA AS PARCELAS SELECIONADAS E GERA UM NOVO DOCUMENTO DO TIPO FATURA.
             */

            //Grava um novo registro de PagarBaixa
            try
            {
                int contar = 0;
                int idMovBanco = 0;
                int idCheque = 0;
                int? idDivida = 0;
                int controleCaixa = 0;

                /* Identifica o codigo do indexador da moeda corrente no pais */
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao, oOcorrencia, codEmpresa);
                int idMoedaCorrente = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCFINANCEIRO", "GERAL", "MOEDA_CORRENTE"));

                foreach (PagarBaixa oBaixa in lstPagarBaixa)
                {
                    //busca id do controle do caixa
                    controleCaixa = 0;
                    if (oBaixa.contaCorrente.contaCaixa == "S")
                    {
                        //busca o numero do controle do caixa.
                        ControleCaixa oCtrCaixa = new ControleCaixa();
                        ControleCaixaDAO oCtrCaixaDAO = new ControleCaixaDAO(parConexao, oOcorrencia, codEmpresa);
                        oCtrCaixa.dtHoraAbertura = oBaixa.dataPagamento;
                        oCtrCaixa.contaBancaria = oBaixa.contaCorrente;
                        oCtrCaixa = oCtrCaixaDAO.ObterPor(oCtrCaixa);

                        if (oCtrCaixa.idControleCaixa > 0)
                        {
                            controleCaixa = oCtrCaixa.idControleCaixa;
                        }
                        else
                        {
                            Exception oErro = new Exception("Conta caixa não está aberta");
                            throw oErro;
                        }
                    }

                    if (oBaixa.formaPagamento.idFormaPagamento == 1 || oBaixa.formaPagamento.idFormaPagamento == 6)
                    {
                        //1- Pagamento em dinheiro
                        //6 - Debito ou Credito em conta corrente

                        if (contar == 0)
                        {
                            //monta movimento bancario geral a partir do primeiro lancamento da list
                            MovimentoBancario oMovBanco = new MovimentoBancario();
                            oMovBanco.codEmpresa = oBaixa.codEmpresa;
                            oMovBanco.documento = oBaixa.documentoBaixa;
                            oMovBanco.documentoorigem = oBaixa.documentoBaixa;
                            oMovBanco.dataMovimento = oBaixa.dataPagamento;
                            oMovBanco.contaBancaria = oBaixa.contaCorrente;
                            oMovBanco.tipoMovimento = "D";
                            oMovBanco.valorDocumento = oBaixa.totalDocumento;
                            oMovBanco.valorJuros = oBaixa.totalJuros;
                            oMovBanco.valorDesconto = oBaixa.totalDesconto;
                            oMovBanco.valorMovimento = oBaixa.totalPagamento;
                            oMovBanco.idHistorico = oBaixa.idHistorico;
                            oMovBanco.historico = oBaixa.historico;
                            oMovBanco.situacao = "A";
                            oMovBanco.pessoa = oBaixa.pessoa;
                            oMovBanco.nominal = oBaixa.nominal;
                            oMovBanco.dataPreDatado = oBaixa.dataPreDatado;
                            oMovBanco.cadastro_datahora = oBaixa.cadastro_datahora;
                            oMovBanco.cadastro_idusuario = oBaixa.cadastro_idusuario;
                            oMovBanco.idControleCaixa = controleCaixa;

                            if (oBaixa.tarifaConciliada)
                            {
                                oMovBanco.dataConciliacao = oBaixa.dataPagamento;
                                oMovBanco.situacao = "C";
                            }

                            MovimentoBancarioDAO oMovBcoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia,codEmpresa);
                            idMovBanco = oMovBcoDAO.Salvar(oMovBanco, xConexao, Transacao);
                            contar++;
                        }

                        //se o lancamento não tiver que agrupar o movimento bancario zera o contador novamente.
                        //esta opção foi feita por causa da baixa de tarifas bancarias
                        if (!oBaixa.agrupadoMovBancario)
                            contar = 0;

                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                            "where a.table_name = 'pagarbaixa'"+
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idPagarBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        oBaixa.idMovimentoBancario = idMovBanco;

                        geraOcorrencia(oBaixa, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into pagarbaixa ( codempresa, idpagarparcelas, datapagamento, valorbaixa, " +
                                                              " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                              " cadastro_idusuario, cadastro_datahora, nominal, situacaobaixa, sdoamortizacao, idhistorico, " +
                                                              " valorbaixaindexado, valorindiceajuste, valorcorrecaomonetaria) " +
                                                       " values (@codempresa, @idpagarparcelas, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                               " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, @valordesconto, @idmovimentobancario, @cadastro_idusuario, " + 
                                                               " @cadastro_datahora, @nominal, @situacaobaixa, @sdoamortizacao, @idhistorico, " +
                                                               " @valorbaixaindexado, @valorindiceajuste, @valorcorrecaomonetaria)";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idpagarparcelas", oBaixa.pagarParcela.idPagarParcela);
                        Sqlcon.Parameters.AddWithValue("@datapagamento", oBaixa.dataPagamento);
                        Sqlcon.Parameters.AddWithValue("@valorbaixa", oBaixa.valorBaixa);
                        Sqlcon.Parameters.AddWithValue("@idformapagamento", oBaixa.formaPagamento.idFormaPagamento);
                        Sqlcon.Parameters.AddWithValue("@historico", oBaixa.historico);
                        Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oBaixa.contaCorrente.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idcontacorrente", oBaixa.contaCorrente.idCtaBancaria);
                        Sqlcon.Parameters.AddWithValue("@documentobaixa", oBaixa.documentoBaixa);
                        Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.valorJuros);
                        Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.valorDesconto);
                        Sqlcon.Parameters.AddWithValue("@idmovimentobancario", idMovBanco);
                        Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", oBaixa.cadastro_idusuario);
                        Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oBaixa.cadastro_datahora);
                        Sqlcon.Parameters.AddWithValue("@nominal", oBaixa.nominal);
                        Sqlcon.Parameters.AddWithValue("@situacaobaixa", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                        Sqlcon.Parameters.AddWithValue("@valorbaixaindexado", oBaixa.valorBaixaIndexado);
                        Sqlcon.Parameters.AddWithValue("@valorindiceajuste", oBaixa.valorIndiceAjuste);
                        Sqlcon.Parameters.AddWithValue("@valorcorrecaomonetaria", oBaixa.valorCorrecaoMonetaria);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        PagarParcelaDAO oPagarParcela = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPagarParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 2 || oBaixa.formaPagamento.idFormaPagamento == 3)
                    {
                        
                        if (TipoPagamento == "1")
                        {
                            //Emite cheque individual pra cada pagamento

                            idMovBanco = 0;
                            MovimentoBancario oMovBanco = new MovimentoBancario();
                            ChequeEmitir oCheque = new ChequeEmitir();
                            MovimentoBancarioDAO oMovBcoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia,codEmpresa);
                            //ChequeEmitir oCheque = new ChequeEmitir();
                            Empresa oEmp = new Empresa();
                            ChequeEmitirDAO oChDAO = new ChequeEmitirDAO(parConexao, oOcorrencia,codEmpresa);

                            if (oBaixa.formaPagamento.idFormaPagamento == 2)
                            {
                                //gera movimento bancario para o lancamento    
                                oMovBanco.codEmpresa = oBaixa.codEmpresa;
                                oMovBanco.documento = oBaixa.documentoBaixa; ;
                                oMovBanco.documentoorigem = oBaixa.documentoBaixa;
                                oMovBanco.dataMovimento = oBaixa.dataPagamento;
                                oMovBanco.contaBancaria = oBaixa.contaCorrente;
                                oMovBanco.tipoMovimento = "D";
                                oMovBanco.valorDocumento = oBaixa.valorBaixa;
                                oMovBanco.valorJuros = oBaixa.valorJuros;
                                oMovBanco.valorDesconto = oBaixa.valorDesconto;
                                oMovBanco.valorMovimento = oBaixa.valorTotal;
                                oMovBanco.idHistorico = oBaixa.idHistorico;
                                oMovBanco.historico = oBaixa.historico;
                                oMovBanco.situacao = "A";
                                oMovBanco.pessoa = oBaixa.pessoa;
                                oMovBanco.nominal = oBaixa.nominal;
                                oMovBanco.dataPreDatado = oBaixa.dataPreDatado;
                                oMovBanco.cadastro_datahora = oBaixa.cadastro_datahora;
                                oMovBanco.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                oMovBanco.idControleCaixa = controleCaixa;


                                idMovBanco = oMovBcoDAO.Salvar(oMovBanco, xConexao, Transacao);
                                oMovBanco.idMovimentoBancario = idMovBanco;
                            }

                            //gera cheque a emitir para a parcela
                            oEmp.idEmpresa = oBaixa.codEmpresa;
                            oCheque.contaBancaria = oBaixa.contaCorrente;
                            oCheque.empresa = oEmp;
                            oCheque.dataCheque = oBaixa.dataPagamento;
                            oCheque.valorCheque = oBaixa.valorTotal;
                            oCheque.nominal = oBaixa.nominal;
                            oCheque.nroCheque = "";
                            oCheque.idMovimentoBancario = idMovBanco;
                            oCheque.compensacao = "A";
                            if (oBaixa.formaPagamento.idFormaPagamento == 3)
                            {
                                oCheque.preDatado = "S";
                                oCheque.dataPreDatado = Convert.ToDateTime(oBaixa.dataPreDatado.ToString());
                            }
                            else
                            {
                                oCheque.preDatado = "N";
                                oCheque.dataPreDatado = Convert.ToDateTime(oMovBanco.dataMovimento.ToString());
                            }

                            idCheque = oChDAO.Salva(oCheque, xConexao, Transacao);

                            //Pagamento em cheque ou cheque pré datado
                            if (oBaixa.formaPagamento.idFormaPagamento == 3)
                            {
                                //se for cheque pré datado tem que gerar um novo documento de divida contra o 
                                //Fornecedor

                                PagarDocumento oPgDoc = new PagarDocumento();
                                ParametroDAO oParamDAO1 = new ParametroDAO(parConexao);
                                string schemaBD1 = oParamDAO1.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                                String strSQL0 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                                    "where a.table_name = 'pagardocumento'" +
                                                    "  and a.table_schema ='" + schemaBD1.Trim() + "'";

                                MySqlCommand Sqlcon0 = new MySqlCommand(@strSQL0, xConexao, Transacao);

                                MySqlDataReader drCon0;
                                drCon0 = Sqlcon0.ExecuteReader();

                                while (drCon0.Read())
                                {
                                    oPgDoc.idPagarDocumento = Convert.ToInt32(drCon0["AUTO_INCREMENT"].ToString());
                                }
                                drCon0.Close();
                                drCon0.Dispose();
                                drCon0 = null;

                                //oPgDoc.aplicacao = oBaixa.pagarParcela.pagarDocumento.aplicacao;
                                //oPgDoc.contaCusto = oBaixa.pagarParcela.pagarDocumento.contaCusto;

                                oPgDoc.cadastro_datahora = oBaixa.cadastro_datahora;
                                oPgDoc.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                oPgDoc.codEmpresa = oBaixa.codEmpresa;
                                
                                oPgDoc.dataEmissao = DateTime.Now;
                                oPgDoc.dataEntrada = DateTime.Now;
                                oPgDoc.descricao = "Doc.Cobr.Gerado em contra partida do CH Pré " + 
                                                   " da Conta " + oCheque.contaBancaria.agencia + "-" + oCheque.contaBancaria.conta +
                                                   " Nominal a " + oCheque.nominal + 
                                                   " Cheque Nro : ";
                                oPgDoc.diaFixo = "";
                                oPgDoc.fornecedor = oBaixa.pagarParcela.pagarDocumento.fornecedor;
                                Indexador oIndexador = new Indexador();
                                oIndexador.idIndexador = idMoedaCorrente;

                                oPgDoc.indexador = oIndexador;
                                oPgDoc.nroDocumento = "F" + String.Format("{0:00000}", oBaixa.pagarParcela.pagarDocumento.fornecedor.idPessoa) + "CH" + String.Format("{0:0000000}", idCheque);
                                oPgDoc.nroParcelas = 1;
                                oPgDoc.origemDocumento = "CTAPAGAR";
                                oPgDoc.periodicidade = "M";
                                oPgDoc.situacao = "A";
                                oPgDoc.valorIndice = 1;
                                oPgDoc.valorIndexado = EmcResources.cDouble(oBaixa.valorTotal.ToString());
                                oPgDoc.dataUltimaCorrecao = oBaixa.dataPagamento;

                                TipoDocumento oTipoDoc = new TipoDocumento();
                                //tipo documento ch pre datado
                                oTipoDoc.idTipoDocumento=5;
                                oPgDoc.tipoDocumento = oTipoDoc;
                                oPgDoc.valorDocumento = oBaixa.valorTotal;

                                PagarParcela oParcela = new PagarParcela();
                                PagarDocumento oDoc = new PagarDocumento();
                                List<PagarBaixa> lstBaixa = new List<PagarBaixa>();
                                oParcela.baixas = lstBaixa;
                                oParcela.pagarDocumento = oDoc;
                                oParcela.autorizado = oBaixa.pagarParcela.autorizado;
                                oParcela.autorizador_idUsuario = oBaixa.pagarParcela.autorizador_idUsuario;
                                oParcela.autorizador2_idUsuario = oBaixa.pagarParcela.autorizador2_idUsuario;
                                oParcela.cadastro_datahora = oBaixa.cadastro_datahora;
                                oParcela.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                oParcela.codEmpresa = oBaixa.codEmpresa;
                                oParcela.dataVencimento = oBaixa.dataPreDatado;
                                oParcela.nroParcela = 1;
                                oParcela.saldoPagar = oBaixa.valorTotal;
                                oParcela.saldoPago = 0;
                                oParcela.situacao ="A";
                                oParcela.status ="I";
                                TipoCobranca oTpCobr = new TipoCobranca();
                                oTpCobr.idTipoCobranca = 1;
                                oParcela.tipoCobranca = oTpCobr;
                                oParcela.valorParcela = oBaixa.valorTotal;
                                oParcela.valorIndexado = EmcResources.cDouble(oBaixa.valorTotal.ToString());
                                oParcela.dataUltimaCorrecao = oBaixa.dataPagamento;
                                oParcela.valorIndice = 1;
                                oParcela.valorCorrecaoMonetaria = 0;
                                oParcela.valorCMPago = 0;

                                List<PagarBaseRateio> lstBaseRateio = new List<PagarBaseRateio>();
                                oPgDoc.baseRateio = lstBaseRateio;

                                foreach (PagarBaseRateio oRat in oBaixa.pagarParcela.pagarDocumento.baseRateio)
                                {
                                    decimal valor = 0;
                                    valor = EmcResources.cCur( ((EmcResources.cDouble(oPgDoc.valorDocumento.ToString()) * oRat.percentualRateio) / 100).ToString() );
                                    oRat.valorRateio = valor;
                                    oRat.idPagarDocumento = EmcResources.cInt(oPgDoc.idPagarDocumento.ToString());
                                    oRat.idPagarBaseRateio = 0;
                                    oRat.status = "I";

                                    lstBaseRateio.Add(oRat);
                                }
                                oPgDoc.baseRateio = lstBaseRateio;

                                List<PagarParcela> lstParcela = new List<PagarParcela>();
                                lstParcela.Add(oParcela);

                                oPgDoc.parcelas = lstParcela;

                                Ocorrencia oOco = new Ocorrencia();
                                Aplicativo oAplicativo = new Aplicativo();
                                oAplicativo.nome = "EMCFinanceiro";
                                oOco.aplicativo = oAplicativo;
                                oOco.chaveidentificacao = "";
                                oOco.data_hora = DateTime.Now;
                                oOco.descricao = "";
                                oOco.formulario = "frmPagarDocumento";
                                oOco.seqLogin = oOcorrencia.seqLogin;
                                oOco.tabela = "pagardocumento";
                                oOco.usuario = oOcorrencia.usuario;

                                PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, oOco, codEmpresa);
                                oPgDocDAO.Salvar(xConexao, Transacao, oPgDoc);

                                PagarParcelaDAO oPgParcDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                                PagarParcela oParc = oPgParcDAO.ObterPor(oPgDoc.nroDocumento, 1, oPgDoc.codEmpresa, oPgDoc.fornecedor);

                                idDivida = oParc.idPagarParcela;

                            }


                            ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                            string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                            //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                            String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                                "where a.table_name = 'pagarbaixa'" +
                                                "  and a.table_schema ='" + schemaBD.Trim() + "'";

                            MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                            MySqlDataReader drCon;
                            drCon = Sqlcon2.ExecuteReader();

                            while (drCon.Read())
                            {
                                oBaixa.idPagarBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                            }
                            drCon.Close();
                            drCon.Dispose();
                            drCon = null;

                            oBaixa.idMovimentoBancario = idMovBanco;
                            geraOcorrencia(oBaixa, "I");


                            //Monta comando para a gravação do registro
                            String strSQL = "insert into pagarbaixa ( codempresa, idpagarparcelas, datapagamento, valorbaixa, " +
                                                                  " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                                  " cadastro_idusuario, cadastro_datahora, nominal, situacaobaixa, idchequeemitir, iddivida, sdoamortizacao, idhistorico, " + 
                                                                  " valorindiceajuste, valorbaixaindexado, valorcorrecaomonetaria )  " +
                                                           " values (@codempresa, @idpagarparcelas, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                                   " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, @valordesconto, @idmovimentobancario, @cadastro_idusuario, " + 
                                                                   " @cadastro_datahora, @nominal, @situacaobaixa, @idcheque, @iddivida, @sdoamortizacao, @idhistorico, " +
                                                                   " @valorindiceajuste, @valorbaixaindexado, @valorcorrecaomonetaria )";
                            MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                            Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                            Sqlcon.Parameters.AddWithValue("@idpagarparcelas", oBaixa.pagarParcela.idPagarParcela);
                            Sqlcon.Parameters.AddWithValue("@datapagamento", oBaixa.dataPagamento);
                            Sqlcon.Parameters.AddWithValue("@valorbaixa", oBaixa.valorBaixa);
                            Sqlcon.Parameters.AddWithValue("@idformapagamento", oBaixa.formaPagamento.idFormaPagamento);
                            Sqlcon.Parameters.AddWithValue("@historico", oBaixa.historico);
                            Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oBaixa.contaCorrente.codEmpresa);
                            Sqlcon.Parameters.AddWithValue("@idcontacorrente", oBaixa.contaCorrente.idCtaBancaria);
                            Sqlcon.Parameters.AddWithValue("@documentobaixa", oBaixa.documentoBaixa);
                            Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.valorJuros);
                            Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.valorDesconto);
                            if (oBaixa.formaPagamento.idFormaPagamento == 3)
                                Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                            else
                                Sqlcon.Parameters.AddWithValue("@idmovimentobancario", idMovBanco);
                            Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", oBaixa.cadastro_idusuario);
                            Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oBaixa.cadastro_datahora);
                            Sqlcon.Parameters.AddWithValue("@nominal", oBaixa.nominal);
                            Sqlcon.Parameters.AddWithValue("@situacaobaixa", oBaixa.situacaoBaixa);
                            Sqlcon.Parameters.AddWithValue("@idcheque", idCheque);
                            if (idDivida > 0)
                                Sqlcon.Parameters.AddWithValue("@iddivida", idDivida);
                            else
                                Sqlcon.Parameters.AddWithValue("@iddivida", null);
                            Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                            Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                            Sqlcon.Parameters.AddWithValue("@valorbaixaindexado", oBaixa.valorBaixaIndexado);
                            Sqlcon.Parameters.AddWithValue("@valorindiceajuste", oBaixa.valorIndiceAjuste);
                            Sqlcon.Parameters.AddWithValue("@valorcorrecaomonetaria", oBaixa.valorCorrecaoMonetaria);

                            //abre conexao e executa o comando

                            Sqlcon.ExecuteNonQuery();

                            OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                            oOcoDAO.Salvar(oOcorrencia, Transacao);

                            //atualizar saldos no pagar parcela
                            PagarParcelaDAO oPagarParcela = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                            oPagarParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                        }
                        else if (TipoPagamento == "2")
                        {
                            //Emite cheque unico para todos os pagamentos
                            //gera um unico movimento bancario e gera um unico lancamento de cheque a emitir.
                            MovimentoBancarioDAO oMovBcoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia,codEmpresa);
                            ChequeEmitirDAO oChDAO = new ChequeEmitirDAO(parConexao, oOcorrencia,codEmpresa);
                            
                            //emite apenas um cheque para todos os pagamentos
                            if (contar == 0)
                            {
                                //gera movimento bancario para o lancamento
                                if (oBaixa.formaPagamento.idFormaPagamento == 2)
                                {
                                    MovimentoBancario oMovBanco = new MovimentoBancario();
                                    oMovBanco.codEmpresa = oBaixa.codEmpresa;
                                    oMovBanco.documento = oBaixa.documentoBaixa;
                                    oMovBanco.documentoorigem = oBaixa.documentoBaixa;
                                    oMovBanco.dataMovimento = oBaixa.dataPagamento;
                                    oMovBanco.contaBancaria = oBaixa.contaCorrente;
                                    oMovBanco.tipoMovimento = "D";
                                    oMovBanco.valorDocumento = oBaixa.totalDocumento;
                                    oMovBanco.valorJuros = oBaixa.totalJuros;
                                    oMovBanco.valorDesconto = oBaixa.totalDesconto;
                                    oMovBanco.valorMovimento = oBaixa.totalPagamento;
                                    oMovBanco.idHistorico = oBaixa.idHistorico;
                                    oMovBanco.historico = oBaixa.historico;
                                    oMovBanco.situacao = "A";
                                    oMovBanco.pessoa = oBaixa.pessoa;
                                    oMovBanco.nominal = oBaixa.nominal;
                                    oMovBanco.dataPreDatado = oBaixa.dataPreDatado;
                                    oMovBanco.cadastro_datahora = oBaixa.cadastro_datahora;
                                    oMovBanco.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                    oMovBanco.idControleCaixa = controleCaixa;

                                    idMovBanco = oMovBcoDAO.Salvar(oMovBanco, xConexao, Transacao);
                                    oMovBanco.idMovimentoBancario = idMovBanco;
                                }

                                ChequeEmitir oCheque = new ChequeEmitir();
                                Empresa oEmp = new Empresa();
                                //gera cheque a emitir para a parcela
                                oEmp.idEmpresa = oBaixa.codEmpresa;
                                oCheque.contaBancaria = oBaixa.contaCorrente;
                                oCheque.empresa = oEmp;
                                oCheque.dataCheque = oBaixa.dataPagamento;
                                oCheque.valorCheque = oBaixa.totalPagamento;
                                oCheque.nominal = oBaixa.nominal;
                                oCheque.nroCheque = "";
                                oCheque.idMovimentoBancario = idMovBanco;
                                oCheque.compensacao = "A";

                                if (oBaixa.formaPagamento.idFormaPagamento == 3)
                                {
                                    oCheque.preDatado = "S";
                                    oCheque.dataPreDatado = Convert.ToDateTime(oBaixa.dataPreDatado.ToString());
                                }
                                else
                                {
                                    oCheque.preDatado = "N";
                                    oCheque.dataPreDatado = Convert.ToDateTime(oBaixa.dataPagamento.ToString());
                                }


                                idCheque = oChDAO.Salva(oCheque, xConexao, Transacao);


                                //Pagamento em cheque ou cheque pré datado
                                if (oBaixa.formaPagamento.idFormaPagamento == 3)
                                {
                                    //se for cheque pré datado tem que gerar um novo documento de divida contra o 
                                    //Fornecedor
                                    PagarDocumento oPgDoc = new PagarDocumento();

                                    ParametroDAO oParamDAO1 = new ParametroDAO(parConexao);
                                    string schemaBD1 = oParamDAO1.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                                    String strSQL0 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                                        "where a.table_name = 'pagardocumento'" +
                                                        "  and a.table_schema ='" + schemaBD1.Trim() + "'";

                                    MySqlCommand Sqlcon0 = new MySqlCommand(@strSQL0, xConexao, Transacao);

                                    MySqlDataReader drCon0;
                                    drCon0 = Sqlcon0.ExecuteReader();

                                    while (drCon0.Read())
                                    {
                                        oPgDoc.idPagarDocumento = Convert.ToInt32(drCon0["AUTO_INCREMENT"].ToString());
                                    }
                                    drCon0.Close();
                                    drCon0.Dispose();
                                    drCon0 = null;

                                    
                                    //oPgDoc.aplicacao = oBaixa.pagarParcela.pagarDocumento.aplicacao;
                                    //oPgDoc.contaCusto = oBaixa.pagarParcela.pagarDocumento.contaCusto;

                                    oPgDoc.cadastro_datahora = oBaixa.cadastro_datahora;
                                    oPgDoc.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                    oPgDoc.codEmpresa = oBaixa.codEmpresa;
                                    
                                    oPgDoc.dataEmissao = DateTime.Now;
                                    oPgDoc.dataEntrada = DateTime.Now;
                                    oPgDoc.descricao = "Doc.Cobr.Gerado em contra partida do CH Pré " +
                                                   " da Conta " + oCheque.contaBancaria.agencia + "-" + oCheque.contaBancaria.conta +
                                                   " Nominal a " + oCheque.nominal +
                                                   " Cheque Nro : ";
                                    oPgDoc.diaFixo = "";
                                    oPgDoc.fornecedor = oBaixa.pagarParcela.pagarDocumento.fornecedor;
                                    oPgDoc.indexador = oBaixa.pagarParcela.pagarDocumento.indexador;
                                    oPgDoc.nroDocumento = "F" + String.Format("{0:00000}", oBaixa.pagarParcela.pagarDocumento.fornecedor.idPessoa) + "CH" + String.Format("{0:0000000}", idCheque);
                                    oPgDoc.nroParcelas = 1;
                                    oPgDoc.origemDocumento = "CTAPAGAR";
                                    oPgDoc.periodicidade = "M";
                                    oPgDoc.situacao = "A";
                                    oPgDoc.valorIndice = 1;
                                    oPgDoc.valorIndexado = EmcResources.cDouble(oBaixa.valorTotal.ToString());
                                    oPgDoc.dataUltimaCorrecao = oBaixa.dataPagamento;

                                    TipoDocumento oTipoDoc = new TipoDocumento();
                                    oTipoDoc.idTipoDocumento = 5;
                                    oPgDoc.tipoDocumento = oTipoDoc;
                                    oPgDoc.valorDocumento = oBaixa.valorTotal;

                                    List<PagarBaseRateio> lstBaseRateio = new List<PagarBaseRateio>();
                                    oPgDoc.baseRateio = lstBaseRateio;

                                    foreach (PagarBaseRateio oRat in oBaixa.pagarParcela.pagarDocumento.baseRateio)
                                    {
                                        decimal valor = 0;
                                        valor = EmcResources.cCur(((EmcResources.cDouble(oPgDoc.valorDocumento.ToString()) * oRat.percentualRateio) / 100).ToString());
                                        oRat.valorRateio = valor;
                                        oRat.idPagarDocumento = EmcResources.cInt(oPgDoc.idPagarDocumento.ToString());
                                        oRat.idPagarBaseRateio = 0;
                                        oRat.status = "I";

                                        lstBaseRateio.Add(oRat);
                                    }
                                    oPgDoc.baseRateio = lstBaseRateio;


                                    PagarParcela oParcela = new PagarParcela();
                                    PagarDocumento oDoc = new PagarDocumento();
                                    List<PagarBaixa> lstBaixa = new List<PagarBaixa>();
                                    oParcela.baixas = lstBaixa;
                                    oParcela.pagarDocumento = oDoc;
                                    oParcela.autorizado = oBaixa.pagarParcela.autorizado;
                                    oParcela.autorizador_idUsuario = oBaixa.pagarParcela.autorizador_idUsuario;
                                    oParcela.autorizador2_idUsuario = oBaixa.pagarParcela.autorizador2_idUsuario;
                                    oParcela.cadastro_datahora = oBaixa.cadastro_datahora;
                                    oParcela.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                    oParcela.codEmpresa = oBaixa.codEmpresa;
                                    oParcela.dataVencimento = oBaixa.dataPreDatado;
                                    oParcela.nroParcela = 1;
                                    oParcela.saldoPagar = oBaixa.valorTotal;
                                    oParcela.saldoPago = 0;
                                    oParcela.situacao = "A";
                                    oParcela.status = "I";
                                    TipoCobranca oTpCobr = new TipoCobranca();
                                    oTpCobr.idTipoCobranca = 1;
                                    oParcela.tipoCobranca = oTpCobr;
                                    oParcela.valorParcela = oBaixa.valorTotal;
                                    oParcela.valorIndexado = EmcResources.cDouble(oBaixa.valorTotal.ToString());
                                    oParcela.dataUltimaCorrecao = oBaixa.dataPagamento;
                                    oParcela.valorIndice = 1;
                                    oParcela.valorCorrecaoMonetaria = 0;
                                    oParcela.valorCMPago = 0;

                                    List<PagarParcela> lstParcela = new List<PagarParcela>();
                                    lstParcela.Add(oParcela);

                                    oPgDoc.parcelas = lstParcela;

                                    Ocorrencia oOco = new Ocorrencia();
                                    Aplicativo oAplicativo = new Aplicativo();
                                    oAplicativo.nome = "EMCFinanceiro";
                                    oOco.aplicativo = oAplicativo;
                                    oOco.chaveidentificacao = "";
                                    oOco.data_hora = DateTime.Now;
                                    oOco.descricao = "";
                                    oOco.formulario = "frmPagarDocumento";
                                    oOco.seqLogin = oOcorrencia.seqLogin;
                                    oOco.tabela = "pagardocumento";
                                    oOco.usuario = oOcorrencia.usuario;

                                    PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, oOco, codEmpresa);
                                    oPgDocDAO.Salvar(xConexao, Transacao, oPgDoc);

                                    PagarParcelaDAO oPgParcDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                                    PagarParcela oParc = oPgParcDAO.ObterPor(oPgDoc.nroDocumento, 1, oPgDoc.codEmpresa, oPgDoc.fornecedor);

                                    idDivida = oParc.idPagarParcela;

                                }

                                contar++;

                            }

                            ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                            string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                            //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                            String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                                "where a.table_name = 'pagarbaixa'" +
                                                "  and a.table_schema ='" + schemaBD.Trim() + "'";

                            MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                            MySqlDataReader drCon;
                            drCon = Sqlcon2.ExecuteReader();

                            while (drCon.Read())
                            {
                                oBaixa.idPagarBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                            }
                            drCon.Close();
                            drCon.Dispose();
                            drCon = null;

                            oBaixa.idMovimentoBancario = idMovBanco;
                            geraOcorrencia(oBaixa, "I");

                            //Monta comando para a gravação do registro
                            String strSQL = "insert into pagarbaixa ( codempresa, idpagarparcelas, datapagamento, valorbaixa, " +
                                                                  " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                                  " cadastro_idusuario, cadastro_datahora, nominal, situacaobaixa, idchequeemitir, iddivida, sdoamortizacao, idhistorico, " + 
                                                                  " valorbaixaindexado, valorindiceajuste, valorcorrecaomonetaria )  " +
                                                           " values (@codempresa, @idpagarparcelas, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                                   " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, @valordesconto, @idmovimentobancario, " + 
                                                                   " @cadastro_idusuario, @cadastro_datahora, @nominal, @situacaobaixa, @idcheque, @iddivida, @sdoamortizacao, @idhistorico, " +
                                                                   " @valorbaixaindexado, @valorindiceajuste, @valorcorrecaomonetaria )";
                            MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                            Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                            Sqlcon.Parameters.AddWithValue("@idpagarparcelas", oBaixa.pagarParcela.idPagarParcela);
                            Sqlcon.Parameters.AddWithValue("@datapagamento", oBaixa.dataPagamento);
                            Sqlcon.Parameters.AddWithValue("@valorbaixa", oBaixa.valorBaixa);
                            Sqlcon.Parameters.AddWithValue("@idformapagamento", oBaixa.formaPagamento.idFormaPagamento);
                            Sqlcon.Parameters.AddWithValue("@historico", oBaixa.historico);
                            Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oBaixa.contaCorrente.codEmpresa);
                            Sqlcon.Parameters.AddWithValue("@idcontacorrente", oBaixa.contaCorrente.idCtaBancaria);
                            Sqlcon.Parameters.AddWithValue("@documentobaixa", oBaixa.documentoBaixa);
                            Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.valorJuros);
                            Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.valorDesconto);
                            if (oBaixa.formaPagamento.idFormaPagamento == 3)
                                Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                            else
                                Sqlcon.Parameters.AddWithValue("@idmovimentobancario", idMovBanco);
                            Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", oBaixa.cadastro_idusuario);
                            Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oBaixa.cadastro_datahora);
                            Sqlcon.Parameters.AddWithValue("@nominal", oBaixa.nominal);
                            Sqlcon.Parameters.AddWithValue("@situacaobaixa", oBaixa.situacaoBaixa);
                            Sqlcon.Parameters.AddWithValue("@idcheque", idCheque);
                            if (idDivida>0)
                                Sqlcon.Parameters.AddWithValue("@iddivida", idDivida);
                            else
                                Sqlcon.Parameters.AddWithValue("@iddivida", null);
                            Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                            Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                            Sqlcon.Parameters.AddWithValue("@valorbaixaindexado", oBaixa.valorBaixaIndexado);
                            Sqlcon.Parameters.AddWithValue("@valorindiceajuste", oBaixa.valorIndiceAjuste);
                            Sqlcon.Parameters.AddWithValue("@valorcorrecaomonetaria", oBaixa.valorCorrecaoMonetaria);

                            //abre conexao e executa o comando

                            Sqlcon.ExecuteNonQuery();

                            OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                            oOcoDAO.Salvar(oOcorrencia, Transacao);

                            //atualizar saldos no pagar parcela
                            PagarParcelaDAO oPagarParcela = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                            oPagarParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                        }


                            
                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 4)
                    {
                        // Pagamento em remessa eletronica


                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 5)
                    {
                        //Pagamento Amortização de Adiantamento


                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                            "where a.table_name = 'pagarbaixa'" +
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idPagarBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oBaixa, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into pagarbaixa ( codempresa, idpagarparcelas, datapagamento, valorbaixa, " +
                                                              " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                              " cadastro_idusuario, cadastro_datahora, nominal, situacaobaixa, idamortizacao , sdoamortizacao, idhistorico, " + 
                                                              " valorbaixaindexado, valorindiceajuste, valorcorrecaomonetaria ) " +
                                                       " values (@codempresa, @idpagarparcelas, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                               " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, " + 
                                                               " @valordesconto, @idmovimentobancario, @cadastro_idusuario, @cadastro_datahora, " + 
                                                               " @nominal, @situacaobaixa, @idamortizacao, @sdoamortizacao, @idhistorico, " + 
                                                               " @valorbaixaindexado, @valorindiceajuste, @valorcorrecaomonetaria )";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idpagarparcelas", oBaixa.pagarParcela.idPagarParcela);
                        Sqlcon.Parameters.AddWithValue("@datapagamento", oBaixa.dataPagamento);
                        Sqlcon.Parameters.AddWithValue("@valorbaixa", oBaixa.valorBaixa);
                        Sqlcon.Parameters.AddWithValue("@idformapagamento", oBaixa.formaPagamento.idFormaPagamento);
                        Sqlcon.Parameters.AddWithValue("@historico", oBaixa.historico);
                        if (oBaixa.contaCorrente.idCtaBancaria > 0)
                        {
                            Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oBaixa.contaCorrente.codEmpresa);
                            Sqlcon.Parameters.AddWithValue("@idcontacorrente", oBaixa.contaCorrente.idCtaBancaria);
                        }
                        else
                        {
                            Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", null);
                            Sqlcon.Parameters.AddWithValue("@idcontacorrente", null);
                        }
                        Sqlcon.Parameters.AddWithValue("@documentobaixa", oBaixa.documentoBaixa);
                        Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.valorJuros);
                        Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.valorDesconto);
                        Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                        Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", oBaixa.cadastro_idusuario);
                        Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oBaixa.cadastro_datahora);
                        Sqlcon.Parameters.AddWithValue("@nominal", oBaixa.nominal);
                        Sqlcon.Parameters.AddWithValue("@situacaobaixa", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@idamortizacao", oBaixa.idAmortizacao.idPagarBaixa);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                        Sqlcon.Parameters.AddWithValue("@valorbaixaindexado", oBaixa.valorBaixaIndexado);
                        Sqlcon.Parameters.AddWithValue("@valorindiceajuste", oBaixa.valorIndiceAjuste);
                        Sqlcon.Parameters.AddWithValue("@valorcorrecaomonetaria", oBaixa.valorCorrecaoMonetaria);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        PagarParcelaDAO oPagarParcela = new PagarParcelaDAO(parConexao, oOcorrencia,codEmpresa);
                        oPagarParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                        
                        //atualiza valor a amortizar no adiantamento
                        decimal sdoAmortizacao = oBaixa.idAmortizacao.sdoAmortizacao;
                        sdoAmortizacao = sdoAmortizacao-oBaixa.valorBaixa;

                        string strSQL3 = "update pagarbaixa set sdoamortizacao=@saldo where idpagarbaixa=@idpagarbaixa";
                        MySqlCommand Sqlcon3 = new MySqlCommand(@strSQL3, xConexao, Transacao);
                        Sqlcon3.Parameters.AddWithValue("@idpagarbaixa", oBaixa.idAmortizacao.idPagarBaixa);
                        Sqlcon3.Parameters.AddWithValue("@saldo", sdoAmortizacao);

                        //abre conexao e executa o comando
                        Sqlcon3.ExecuteNonQuery();

                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 7)
                    {
                        //Bonificação
                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 8)
                    {
                        //Cartão de Credito
                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 9)
                    {
                        //Fatura

                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                            "where a.table_name = 'pagarbaixa'" +
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idPagarBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oBaixa, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into pagarbaixa ( codempresa, idpagarparcelas, datapagamento, valorbaixa, " +
                                                              " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                              " cadastro_idusuario, cadastro_datahora, nominal, situacaobaixa, idamortizacao , sdoamortizacao, idhistorico, " + 
                                                              " valorbaixaindexado, valorindiceajuste, valorcorrecaomonetaria ) " +
                                                       " values (@codempresa, @idpagarparcelas, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                               " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, " +
                                                               " @valordesconto, @idmovimentobancario, @cadastro_idusuario, @cadastro_datahora, " +
                                                               " @nominal, @situacaobaixa, @idamortizacao, @sdoamortizacao, @idhistorico, " +
                                                               " @valorbaixaindexado, @valorindiceajuste, valorcorrecaomonetaria )";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idpagarparcelas", oBaixa.pagarParcela.idPagarParcela);
                        Sqlcon.Parameters.AddWithValue("@datapagamento", oBaixa.dataPagamento);
                        Sqlcon.Parameters.AddWithValue("@valorbaixa", oBaixa.valorBaixa);
                        Sqlcon.Parameters.AddWithValue("@idformapagamento", oBaixa.formaPagamento.idFormaPagamento);
                        Sqlcon.Parameters.AddWithValue("@historico", oBaixa.historico);
                        if (oBaixa.contaCorrente.idCtaBancaria > 0)
                        {
                            Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oBaixa.contaCorrente.codEmpresa);
                            Sqlcon.Parameters.AddWithValue("@idcontacorrente", oBaixa.contaCorrente.idCtaBancaria);
                        }
                        else
                        {
                            Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", null);
                            Sqlcon.Parameters.AddWithValue("@idcontacorrente", null);
                        }
                        Sqlcon.Parameters.AddWithValue("@documentobaixa", oBaixa.documentoBaixa);
                        Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.valorJuros);
                        Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.valorDesconto);
                        Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                        Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", oBaixa.cadastro_idusuario);
                        Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oBaixa.cadastro_datahora);
                        Sqlcon.Parameters.AddWithValue("@nominal", oBaixa.nominal);
                        Sqlcon.Parameters.AddWithValue("@situacaobaixa", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@idamortizacao", null);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                        Sqlcon.Parameters.AddWithValue("@valorbaixaindexado", oBaixa.valorBaixaIndexado);
                        Sqlcon.Parameters.AddWithValue("@valorindiceajuste", oBaixa.valorIndiceAjuste);
                        Sqlcon.Parameters.AddWithValue("@valorcorrecaomonetaria", oBaixa.valorCorrecaoMonetaria);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        PagarParcelaDAO oPagarParcela = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPagarParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                        //atualiza nro fatura no pagarparcela
                        oPagarParcela.atualizaFatura(oBaixa, xConexao, Transacao);

                    }

                    //Gerar PagarRateio - rateio da baixa reliazada nos centros de custos e aplicação
                    List<PagarBaseRateio> lstRateio = new List<PagarBaseRateio>();
                    lstRateio = oBaixa.pagarParcela.pagarDocumento.baseRateio;

                    PagarRateioDAO oRateioDAO = new PagarRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateioDAO.rateioBaixa(oBaixa,lstRateio,xConexao,Transacao);

                }
                
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void AlterarSituacaoBaixa(PagarBaixa oBaixa, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            //FORMAS DE PAGAMENTO
            /*
             * 1 -DINHEIRO - p
             * 2 -CHEQUE - B -> P
             * 3- CHEQUE PRE DATADO B -> H
             * 4- REMESSA ELETRONICA R -> P
             * 5 -AMORTIZACAO ADIANTAMENTO - A
             * 6 - DEB/CRED CONTA - P
             * 7 - BONIFICACAO - G
             * 8 - CARTAO CREDITO - T
             * 9 - FATURA TRF - F
             */

            //SITUACOES DE BAIXA
            /*
             * P - PAGO - EFETIVAMENTE REALIZOU PAGAMENTO E SAIU DINHEIRO DA CONTA
             * C - CANCELADO - PARACELA CANCELADA OU COBRANCA INDEVIDA
             * B - PAGO SEM CONFIRMAÇÃO DA EMISSAO DO CH - AGUARDANDO EMISSAO DO CH - SE FOR PRE DATADO VAI PARA SITUACAO H / SE FOR CH NORMAL VAI PARA P
             * H - BAIXA COM CH PRE DATADO - BAIXA A PARCELA E GERA UM NOVO DOCUMENTO DE COBRANCA REALTIVO AO CH PRE
             * A - BAIXA POR AMORTIZAÇÃO DE ADIANTAMENTO - BAIXA PARCELA ATUAL AMORTIZANDO UM PAGAMENTO ANTERIOR DO TIPO ADIANTAMENTO
             * G - BAIXA POR BONIFICAÇÃO 
             * R - BAIXA POR REMESSA SEM CONFIRMAÇÃO DO RETORNO, DEPOIS DE CONFIRMADO VAI PARA A SITUAÇÃO P
             * T - BAIXA POR CARTAO DE CREDITO - BAIXA A PARCELA E TEM QUE GERAR UM NOVO DOCUMENTO DE COBRANCA PARA A OPERADORA DO CARTÃO
             * F - BAIXA POR FATURA - BAIXA AS PARCELAS SELECIONADAS E GERA UM NOVO DOCUMENTO DO TIPO FATURA.
             */

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update PagarBaixa set situacaobaixa=@situacaobaixa where idPagarBaixa = @idPagarBaixa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarBaixa", oBaixa.idPagarBaixa);
                Sqlcon.Parameters.AddWithValue("@situacaobaixa", oBaixa.situacaoBaixa);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }

        }

        public void AlterarDocumentoBaixa(PagarBaixa oBaixa, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update PagarBaixa set documentobaixa=@documentobaixa where idPagarBaixa = @idPagarBaixa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarBaixa", oBaixa.idPagarBaixa);
                Sqlcon.Parameters.AddWithValue("@documentobaixa", oBaixa.documentoBaixa);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }

        }
        public DataTable pesquisaBaixaCompensar(int codEmpresa, int empMaster, int idFornecedor)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select b.idpagarbaixa, d.nrodocumento, p.nroparcela, f.nome as nomefornecedor, b.datapagamento, b.valorbaixa, b.sdoamortizacao  " + 
                                " from PagarBaixa b, PagarParcelas p, PagarDocumento d, v_fornecedor f " + 
                                " where p.idpagarparcelas = b.idpagarparcelas and d.idpagardocumento = p.idpagardocumento " +
                                  " and f.codempresa=d.fornecedor_codempresa and f.idpessoa=d.idfornecedor " +
                                  " and d.fornecedor_codempresa = @empmaster and d.idfornecedor=@idfornecedor " +
                                  " and b.codempresa=@codempresa " + 
                                  " and b.sdoamortizacao > 0 ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@empmaster", empMaster);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", idFornecedor);

                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<PagarBaixa> listaBaixasporCheque(int idChequeEmitir)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaixa Where idchequeemitir=@idchequeemitir ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idchequeemitir", idChequeEmitir);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                List<PagarBaixa> lstPagarBaixa = new List<PagarBaixa>();
                

                while (drCon.Read())
                {
                    consulta = true;
                    PagarBaixa objPagarBaixa = new PagarBaixa();
                    objPagarBaixa.idPagarBaixa = Convert.ToInt32(drCon["idPagarBaixa"].ToString());
                    objPagarBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    PagarParcela oPagarDoc = new PagarParcela();
                    oPagarDoc.idPagarParcela = Convert.ToInt32(drCon["idpagarparcelas"].ToString());

                    objPagarBaixa.pagarParcela = oPagarDoc;

                    objPagarBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objPagarBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objPagarBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objPagarBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());
                    objPagarBaixa.valorIndiceAjuste = EmcResources.cDouble(drCon["valorindiceajuste"].ToString());
                    objPagarBaixa.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarBaixa.valorBaixaIndexado = EmcResources.cDouble(drCon["valorbaixaindexado"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objPagarBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objPagarBaixa.idHistorico = oHistorico;

                    objPagarBaixa.historico = drCon["historico"].ToString();
                    objPagarBaixa.nominal = drCon["nominal"].ToString();
                    objPagarBaixa.situacaoBaixa = drCon["situacaobaixa"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objPagarBaixa.contaCorrente = oConta;

                    objPagarBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objPagarBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objPagarBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    PagarParcela oDivida = new PagarParcela();
                    oDivida.idPagarParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objPagarBaixa.idDivida = oDivida;

                    ChequeEmitir oCh = new ChequeEmitir();
                    oCh.idChequeEmitir = EmcResources.cInt(drCon["idchequeemitir"].ToString());
                    objPagarBaixa.cheque = oCh;

                    lstPagarBaixa.Add(objPagarBaixa);

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                List<PagarBaixa> lstRetorno = new List<PagarBaixa>();

                foreach( PagarBaixa oPgBaixa in lstPagarBaixa)
                {
                    PagarParcelaDAO oPagarDocDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.pagarParcela = oPagarDocDAO.ObterPor(oPgBaixa.pagarParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (oPgBaixa.idDivida.idPagarParcela > 0)
                    {
                        PagarParcelaDAO oPagarDivDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.idDivida = oPagarDivDAO.ObterPor(oPgBaixa.idDivida);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia,codEmpresa);
                    oPgBaixa.formaPagamento = oFormaDAO.ObterPor(oPgBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.contaCorrente = oContaDAO.ObterPor(oPgBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.idHistorico = oHistDAO.ObterPor(oPgBaixa.idHistorico);

                    lstRetorno.Add(oPgBaixa);
                }

                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable ListaPagarBaixa(PagarBaixa objPagarBaixa)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaixa where idpagarparcela=@idpagarparcela order by datapagamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagarparcela", objPagarBaixa.pagarParcela.idPagarParcela);

                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public PagarBaixa ObterPor(PagarBaixa oPagarBaixa)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaixa Where idPagarBaixa = @idPagarBaixa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idPagarBaixa", oPagarBaixa.idPagarBaixa);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                PagarBaixa objPagarBaixa = new PagarBaixa();

                while (drCon.Read())
                {
                    consulta = true;
                    objPagarBaixa.idPagarBaixa = Convert.ToInt32(drCon["idPagarBaixa"].ToString());
                    objPagarBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    PagarParcela oPagarDoc = new PagarParcela();
                    oPagarDoc.idPagarParcela = Convert.ToInt32(drCon["idpagarparcelas"].ToString());

                    objPagarBaixa.pagarParcela = oPagarDoc;

                    objPagarBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objPagarBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objPagarBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objPagarBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());
                    objPagarBaixa.valorIndiceAjuste = EmcResources.cDouble(drCon["valorindiceajuste"].ToString());
                    objPagarBaixa.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarBaixa.valorBaixaIndexado = EmcResources.cDouble(drCon["valorbaixaindexado"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objPagarBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objPagarBaixa.idHistorico = oHistorico;

                    objPagarBaixa.historico = drCon["historico"].ToString();
                    objPagarBaixa.nominal = drCon["nominal"].ToString();
                    objPagarBaixa.situacaoBaixa = drCon["situacaobaixa"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objPagarBaixa.contaCorrente = oConta;

                    objPagarBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objPagarBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objPagarBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    PagarParcela oDivida = new PagarParcela();
                    oDivida.idPagarParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objPagarBaixa.idDivida = oDivida;

                    ChequeEmitir oCh = new ChequeEmitir();
                    oCh.idChequeEmitir = EmcResources.cInt(drCon["idchequeemitir"].ToString());
                    objPagarBaixa.cheque = oCh;

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarParcelaDAO oPagarDocDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarBaixa.pagarParcela = oPagarDocDAO.ObterPor(objPagarBaixa.pagarParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (objPagarBaixa.idDivida.idPagarParcela > 0)
                    {
                        PagarParcelaDAO oPagarDivDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        objPagarBaixa.idDivida = oPagarDivDAO.ObterPor(objPagarBaixa.idDivida);
                    }

                    if (objPagarBaixa.cheque.idChequeEmitir > 0)
                    {
                        ChequeEmitirDAO oChDAO = new ChequeEmitirDAO(parConexao, oOcorrencia,codEmpresa);
                        objPagarBaixa.cheque = oChDAO.ObterPor(objPagarBaixa.cheque);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia,codEmpresa);
                    objPagarBaixa.formaPagamento = oFormaDAO.ObterPor(objPagarBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                    objPagarBaixa.contaCorrente = oContaDAO.ObterPor(objPagarBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia,codEmpresa);
                    objPagarBaixa.idHistorico = oHistDAO.ObterPor(objPagarBaixa.idHistorico);
                }

                return objPagarBaixa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public PagarBaixa ObterPor(int idDivida)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaixa Where iddivida=@iddivida ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@iddivida", idDivida);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                PagarBaixa objPagarBaixa = new PagarBaixa();

                while (drCon.Read())
                {
                    consulta = true;
                    objPagarBaixa.idPagarBaixa = Convert.ToInt32(drCon["idPagarBaixa"].ToString());
                    objPagarBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    PagarParcela oPagarDoc = new PagarParcela();
                    oPagarDoc.idPagarParcela = Convert.ToInt32(drCon["idpagarparcelas"].ToString());

                    objPagarBaixa.pagarParcela = oPagarDoc;

                    objPagarBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objPagarBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objPagarBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objPagarBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());
                    objPagarBaixa.valorIndiceAjuste = EmcResources.cDouble(drCon["valorindiceajuste"].ToString());
                    objPagarBaixa.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarBaixa.valorBaixaIndexado = EmcResources.cDouble(drCon["valorbaixaindexado"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objPagarBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objPagarBaixa.idHistorico = oHistorico;

                    objPagarBaixa.historico = drCon["historico"].ToString();
                    objPagarBaixa.nominal = drCon["nominal"].ToString();
                    objPagarBaixa.situacaoBaixa = drCon["situacaobaixa"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objPagarBaixa.contaCorrente = oConta;

                    objPagarBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objPagarBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objPagarBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    PagarParcela oDivida = new PagarParcela();
                    oDivida.idPagarParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objPagarBaixa.idDivida = oDivida;

                    ChequeEmitir oCh = new ChequeEmitir();
                    oCh.idChequeEmitir = EmcResources.cInt(drCon["idchequeemitir"].ToString());
                    objPagarBaixa.cheque = oCh;


                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarParcelaDAO oPagarDocDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarBaixa.pagarParcela = oPagarDocDAO.ObterPor(objPagarBaixa.pagarParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (objPagarBaixa.idDivida.idPagarParcela > 0)
                    {
                        PagarParcelaDAO oPagarDivDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        objPagarBaixa.idDivida = oPagarDivDAO.ObterPor(objPagarBaixa.idDivida);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia,codEmpresa);
                    objPagarBaixa.formaPagamento = oFormaDAO.ObterPor(objPagarBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                    objPagarBaixa.contaCorrente = oContaDAO.ObterPor(objPagarBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia,codEmpresa);
                    objPagarBaixa.idHistorico = oHistDAO.ObterPor(objPagarBaixa.idHistorico);
                }

                return objPagarBaixa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<PagarBaixa> ObterPor(MovimentoBancario idMovimentoBancario)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaixa Where idmovimentobancario = @idPagarBaixa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idPagarBaixa", idMovimentoBancario.idMovimentoBancario);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                List<PagarBaixa> lstPagarBaixa = new List<PagarBaixa>();
                

                while (drCon.Read())
                {
                    consulta = true;
                    PagarBaixa objPagarBaixa = new PagarBaixa();
                    objPagarBaixa.idPagarBaixa = Convert.ToInt32(drCon["idPagarBaixa"].ToString());
                    objPagarBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    PagarParcela oPagarDoc = new PagarParcela();
                    oPagarDoc.idPagarParcela = Convert.ToInt32(drCon["idpagarparcelas"].ToString());

                    objPagarBaixa.pagarParcela = oPagarDoc;

                    objPagarBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objPagarBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objPagarBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objPagarBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());
                    objPagarBaixa.valorIndiceAjuste = EmcResources.cDouble(drCon["valorindiceajuste"].ToString());
                    objPagarBaixa.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarBaixa.valorBaixaIndexado = EmcResources.cDouble(drCon["valorbaixaindexado"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objPagarBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objPagarBaixa.idHistorico = oHistorico;

                    objPagarBaixa.historico = drCon["historico"].ToString();
                    objPagarBaixa.nominal = drCon["nominal"].ToString();
                    objPagarBaixa.situacaoBaixa = drCon["situacaobaixa"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objPagarBaixa.contaCorrente = oConta;

                    objPagarBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objPagarBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objPagarBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    PagarParcela oDivida = new PagarParcela();
                    oDivida.idPagarParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objPagarBaixa.idDivida = oDivida;

                    ChequeEmitir oCh = new ChequeEmitir();
                    oCh.idChequeEmitir = EmcResources.cInt(drCon["idchequeemitir"].ToString());
                    objPagarBaixa.cheque = oCh;

                    lstPagarBaixa.Add(objPagarBaixa);

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                List<PagarBaixa> lstRetorno = new List<PagarBaixa>();

                foreach( PagarBaixa oPgBaixa in lstPagarBaixa)
                {
                    PagarParcelaDAO oPagarDocDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.pagarParcela = oPagarDocDAO.ObterPor(oPgBaixa.pagarParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (oPgBaixa.idDivida.idPagarParcela > 0)
                    {
                        PagarParcelaDAO oPagarDivDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.idDivida = oPagarDivDAO.ObterPor(oPgBaixa.idDivida);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia,codEmpresa);
                    oPgBaixa.formaPagamento = oFormaDAO.ObterPor(oPgBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.contaCorrente = oContaDAO.ObterPor(oPgBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.idHistorico = oHistDAO.ObterPor(oPgBaixa.idHistorico);

                    lstRetorno.Add(oPgBaixa);
                }

                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<PagarBaixa> listaBaixasParcela(int? idPagarParcela)
        {
            bool consulta = false;
            try
            {
              

                //Monta comando para a gravação do registro
                String strSQL = "select * from pagarbaixa p " +
                                " where p.idpagarparcelas=@idpagarparcelas ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagarparcelas", idPagarParcela);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<PagarBaixa> lstParcela = new List<PagarBaixa>();
                List<PagarBaixa> lstRetorno = new List<PagarBaixa>();


                while (drCon.Read())
                {
                    consulta = true;
                    PagarBaixa objPagarBaixa = new PagarBaixa();
                    objPagarBaixa.idPagarBaixa = Convert.ToInt32(drCon["idPagarBaixa"].ToString());
                    objPagarBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    //não faz a busca da pagarparcela para não entrar em loop
                    PagarParcela oPagarDoc = new PagarParcela();
                    oPagarDoc.idPagarParcela = Convert.ToInt32(drCon["idpagarparcelas"].ToString());
                    objPagarBaixa.pagarParcela = oPagarDoc;

                    objPagarBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objPagarBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objPagarBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objPagarBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());
                    objPagarBaixa.valorIndiceAjuste = EmcResources.cDouble(drCon["valorindiceajuste"].ToString());
                    objPagarBaixa.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarBaixa.valorBaixaIndexado = EmcResources.cDouble(drCon["valorbaixaindexado"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objPagarBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objPagarBaixa.idHistorico = oHistorico;

                    objPagarBaixa.historico = drCon["historico"].ToString();
                    objPagarBaixa.nominal = drCon["nominal"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    if (drCon["idcontacorrente"] is DBNull)
                    {
                        oConta.codEmpresa = 0;
                        oConta.idCtaBancaria = 0;
                    }
                    else
                    {
                        oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                        oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    }
                    objPagarBaixa.contaCorrente = oConta;

                    objPagarBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objPagarBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarBaixa.situacaoBaixa = drCon["situacaobaixa"].ToString();

                    lstParcela.Add(objPagarBaixa);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (PagarBaixa oPgBaixa in lstParcela)
                    {
                        FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.formaPagamento = oFormaDAO.ObterPor(oPgBaixa.formaPagamento); ;


                        HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.idHistorico = oHistDAO.ObterPor(oPgBaixa.idHistorico);

                        if (oPgBaixa.contaCorrente.idCtaBancaria == 0)
                        {
                            Banco oBanco = new Banco();
                            oBanco.descricao="";
                            oPgBaixa.contaCorrente.Banco = oBanco;
                            oPgBaixa.contaCorrente.descricao = "";
                        }
                        else
                        {
                            CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia, codEmpresa);
                            oPgBaixa.contaCorrente = oContaDAO.ObterPor(oPgBaixa.contaCorrente);

                        }

                        lstRetorno.Add(oPgBaixa);
                    }
                }
                
                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable listaBaixaRecibo(string idMovimentoBancario)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select b.idpagarbaixa as idbaixa, b.idmovimentobancario, b.nrodocumento, b.nroparcela, b.documentobaixa, " +
                                " b.nome as nomeforncli, b.datapagamento, b.valorparcela, b.jurosbaixa, " + 
                                " b.descontobaixa, b.valorbaixa " +
                                " from v_pagarbaixa b " +
                                " where b.idmovimentobancario in (" +idMovimentoBancario + ")";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);


                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Boolean verificaBaixaDtaContabil(int idPagarDocumento)
        {
            Boolean baixa = false;
            try
            {
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao,oOcorrencia,codEmpresa);
                DateTime dataContabil = Convert.ToDateTime(oParametroDAO.retParametro(codEmpresa,"EMCCONTABIL","VALIDACAO","PROCESSO_CONTABIL"));


                //Monta comando para a gravação do registro
                String strSQL = "select * from v_pagarbaixa Where codempresa=@codempresa and idpagardocumento=@id and datapagamento<=@data ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@id", idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@data", dataContabil);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    baixa=true;
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return baixa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable relatorioBaixas(DateTime dataInicio, DateTime dataFinal, int empMaster, int idfornecedor, Boolean chkFornecedor, int idctabancaria, Boolean chkconta, int idformaPagto, Boolean chkpagto)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = " select pg.*, concat(cta.descricao,'- Ag:',cta.agencia, ' - Conta: ', cta.conta) as descricaoconta, f.descricao as formapagamento, ch.valorcheque, ch.datacheque, " +
                                        "lpad(ch.nrocheque,7,0) as nrocheque, ch.nominal, " +
                                        " (pg.valorbaixa+pg.cmbaixa+pg.jurosbaixa-pg.descontobaixa) as valorpagamento " +
                                " from v_pagarbaixa pg " +
                                " left join chequeemitir ch on ch.idchequeemitir=pg.idchequeemitir " +
                                " left join formapagamento f on f.idformapagamento = pg.idformapagamento " +
                                " left join ctabancaria cta on cta.idempresa = pg.ctabancaria_idempresa and cta.idctabancaria = pg.idcontacorrente " +
                                " where pg.codempresa = " + codEmpresa.ToString() +
                                  " and pg.datapagamento between '" + dataInicio.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd")+"' ";

                if (!chkFornecedor)
                {
                    strSQL = strSQL + " and pg.fornecedor_codempresa = " + empMaster + " and pg.idfornecedor = " + idfornecedor;
                }
                if (!chkconta)
                {
                    strSQL = strSQL + " and pg.ctabancaria_idempresa = " + codEmpresa + " and pg.idcontacorrente = " + idctabancaria;
                }
                if (!chkpagto)
                {
                    strSQL = strSQL + " and pg.idformapagamento = " + idformaPagto;
                } 

                strSQL = strSQL+" order by pg.datapagamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                

                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }


        private void geraOcorrencia(PagarBaixa oPagarBaixa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oPagarBaixa.pagarParcela.pagarDocumento.idPagarDocumento.ToString();

                if (flag == "A")
                {

                    PagarBaixa oPgBaixa = new PagarBaixa();
                    oPgBaixa = ObterPor(oPagarBaixa);

                    if (!oPgBaixa.Equals(oPagarBaixa))
                    {
                        
                       // alteração de pagamento não implementada
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Pagar Baixa id : " + oPagarBaixa.idPagarBaixa +
                                " - CodEmpresa - " + oPagarBaixa.codEmpresa +
                                " - Id Documento - " + oPagarBaixa.pagarParcela.pagarDocumento.idPagarDocumento +
                                " - Id Parcela - " + oPagarBaixa.pagarParcela.idPagarParcela +
                                " - Fornecedor - " + oPagarBaixa.pagarParcela.pagarDocumento.fornecedor.pessoa.idPessoa + " - " +
                                                    oPagarBaixa.pagarParcela.pagarDocumento.fornecedor.pessoa.nome +
                                " - Documento - " + oPagarBaixa.pagarParcela.pagarDocumento.nroDocumento +
                                " - Nro Parcela - " + oPagarBaixa.pagarParcela.nroParcela +
                                " - Data Pagamento - " + oPagarBaixa.dataPagamento +
                                " - Valor Baixa - " + oPagarBaixa.valorBaixa +
                                " - Valor Juros - " + oPagarBaixa.valorJuros +
                                " - Valor Desconto - " + oPagarBaixa.valorDesconto +
                                " - Valor Total - " + oPagarBaixa.valorTotal +
                                " - Forma Pagamento - " + oPagarBaixa.formaPagamento.idFormaPagamento + " - "  + oPagarBaixa.formaPagamento.descricao +
                                " - idHistorico - " + oPagarBaixa.idHistorico.idHistorico + " - " + oPagarBaixa.idHistorico.descricao +
                                " - Historico - " + oPagarBaixa.historico +
                                " - Documento Baixa - " + oPagarBaixa.documentoBaixa +
                                " - Nominal - " + oPagarBaixa.nominal + 
                                " - Id Mov Bancario - " + oPagarBaixa.idMovimentoBancario +
                                " - Conta Corrente - Empresa : - " + oPagarBaixa.contaCorrente.codEmpresa + " - Conta : " + oPagarBaixa.contaCorrente.idCtaBancaria + " - " + oPagarBaixa.contaCorrente.descricao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    // implementar cancelamento de pagamento
                }
                oOcorrencia.data_hora = DateTime.Now;
                descricao += " em " + oOcorrencia.data_hora.ToString();

                oOcorrencia.descricao = descricao;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }


    }
}
