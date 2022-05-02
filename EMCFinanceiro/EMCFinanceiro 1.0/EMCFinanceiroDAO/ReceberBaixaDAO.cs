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
    public class ReceberBaixaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberBaixaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
        /// Calcula Saldo adiantamento para um Cliente
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSdoAdiantamento(Cliente oCliente)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(sdoamortizacao) as saldopagar from v_receberbaixa pc " +
                                " where pc.sdoamortizacao > 0 " +
                                  " and pc.cliente_codempresa = @codempresa and pc.idcliente = @idcliente";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", oCliente.idPessoa);


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

        public void Salvar(List<ReceberBaixa> lstReceberBaixa, String TipoPagamento)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            //Grava um novo registro de PagarBaixa
            try
            {
                Salvar(lstReceberBaixa, TipoPagamento, Conexao, Transacao);
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
        public void Salvar(List<ReceberBaixa> lstReceberBaixa, String TipoPagamento, MySqlConnection xConexao, MySqlTransaction Transacao)
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

            
            //Grava um novo registro de ReceberBaixa
            try
            {
                int contar = 0;
                int idMovBanco = 0;
                int idCheque = 0;
                int? idDivida = 0;
                int controleCaixa = 0;

        
                foreach (ReceberBaixa oBaixa in lstReceberBaixa)
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
                            oMovBanco.tipoMovimento = "C";
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

                            MovimentoBancarioDAO oMovBcoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia,codEmpresa);
                            idMovBanco = oMovBcoDAO.Salvar(oMovBanco, xConexao, Transacao);
                            contar++;
                        }


                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(oBaixa.codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                            "where a.table_name = 'ReceberBaixa'"+
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idReceberBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        oBaixa.idMovimentoBancario = idMovBanco;

                        geraOcorrencia(oBaixa, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into ReceberBaixa ( codempresa, idreceberParcela, datapagamento, valorbaixa, " +
                                                              " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                              " cadastro_idusuario, cadastro_datahora, nominal, situacao, sdoamortizacao, idhistorico, iddivida ) " +
                                                       " values (@codempresa, @idreceberParcela, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                               " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, @valordesconto, @idmovimentobancario, @cadastro_idusuario, " +
                                                               " @cadastro_datahora, @nominal, @situacao, @sdoamortizacao, @idhistorico, @iddivida )";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idreceberParcela", oBaixa.receberParcela.idReceberParcela);
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
                        Sqlcon.Parameters.AddWithValue("@situacao", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                        Sqlcon.Parameters.AddWithValue("@iddivida", null);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        ReceberParcelaDAO oReceberParcela = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oReceberParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                    }
                    else if (oBaixa.formaPagamento.idFormaPagamento == 2 || oBaixa.formaPagamento.idFormaPagamento == 3)
                    {
                        //Baixa por Cheque  - 2
                        //Baixa por Cheque Pre - 3 - Gera um novo documento de cobrança ref ao cheque predatado

                        idMovBanco = 0;
                        MovimentoBancario oMovBanco = new MovimentoBancario();

                        MovimentoBancarioDAO oMovBcoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia, codEmpresa);
                            
                        Empresa oEmp = new Empresa();
                        

                        if (oBaixa.formaPagamento.idFormaPagamento == 2)
                        {
                            //gera movimento bancario para o lancamento    
                            oMovBanco.codEmpresa = oBaixa.codEmpresa;
                            oMovBanco.documento = oBaixa.documentoBaixa; ;
                            oMovBanco.documentoorigem = oBaixa.documentoBaixa;
                            oMovBanco.dataMovimento = oBaixa.dataPagamento;
                            oMovBanco.contaBancaria = oBaixa.contaCorrente;
                            oMovBanco.tipoMovimento = "C";
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

                        List<ChequeRecebido> lstChRecebidoGravar = new List<ChequeRecebido>();

                        //Pagamento em cheque ou cheque pré datado
                        if (oBaixa.formaPagamento.idFormaPagamento == 3)
                        {
                            //se for cheque pré datado tem que gerar um novo documento de divida para o Cliente
                            
                            foreach(ChequeRecebido oCheque in oBaixa.lstCheque)
                            {
                                idDivida=0;
                                
                                ReceberDocumento oPgDoc = new ReceberDocumento();
                                oPgDoc.cadastro_datahora = oBaixa.cadastro_datahora;
                                oPgDoc.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                oPgDoc.codEmpresa = oBaixa.codEmpresa;
                                oPgDoc.dataEmissao = DateTime.Now;
                                oPgDoc.dataEntrada = DateTime.Now;
                                oPgDoc.descricao = "Doc.Cobr.Gerado em contra partida do CH Pré nro " +
                                                    oCheque.nroCheque + " da Conta " + oCheque.nroAgencia + "-" + oCheque.nroConta +
                                                    " Titular :" + oCheque.nominal;
                                oPgDoc.diaFixo = "";
                                oPgDoc.cliente = oBaixa.receberParcela.receberDocumento.cliente;
                                oPgDoc.indexador = oBaixa.receberParcela.receberDocumento.indexador;
                                oPgDoc.nroDocumento = "C" + String.Format("{0:00000}", oBaixa.receberParcela.receberDocumento.cliente.idPessoa) + "CH" + String.Format("{0:0000000}", oCheque.nroCheque);
                                oPgDoc.nroParcelas = 1;
                                oPgDoc.origemDocumento = "CTARECEBER";
                                oPgDoc.periodicidade = "M";
                                oPgDoc.situacao = "A";
                                TipoDocumento oTipoDoc = new TipoDocumento();
                                //tipo documento ch pre datado
                                oTipoDoc.idTipoDocumento = 5;
                                oPgDoc.tipoDocumento = oTipoDoc;
                                oPgDoc.valorDocumento = oBaixa.valorTotal;

                                List<ReceberBaseRateio> lstBaseRateio = new List<ReceberBaseRateio>();
                                oPgDoc.baseRateio = lstBaseRateio;

                                foreach (ReceberBaseRateio oRat in oBaixa.receberParcela.receberDocumento.baseRateio)
                                {
                                    decimal valor = 0;
                                    valor = EmcResources.cCur( ((EmcResources.cDouble(oPgDoc.valorDocumento.ToString()) * oRat.percentualRateio) / 100).ToString());
                                    oRat.valorRateio = valor;
                                    oRat.idReceberDocumento = EmcResources.cInt(oPgDoc.idReceberDocumento.ToString());
                                    oRat.idReceberBaseRateio = 0;
                                    oRat.status = "I";

                                    lstBaseRateio.Add(oRat);
                                }
                                oPgDoc.baseRateio = lstBaseRateio;


                                ReceberParcela oParcela = new ReceberParcela();
                                ReceberDocumento oDoc = new ReceberDocumento();
                                List<ReceberBaixa> lstBaixa = new List<ReceberBaixa>();
                                oParcela.baixas = lstBaixa;
                                oParcela.receberDocumento = oDoc;
                                oParcela.cadastro_datahora = oBaixa.cadastro_datahora;
                                oParcela.cadastro_idusuario = oBaixa.cadastro_idusuario;
                                oParcela.codEmpresa = oBaixa.codEmpresa;
                                oParcela.dataVencimento = oCheque.dataPreDatado;
                                oParcela.nroParcela = 1;
                                oParcela.saldoPagar = oBaixa.valorTotal;
                                oParcela.saldoPago = 0;
                                oParcela.situacao = "A";
                                oParcela.status = "I";
                                TipoCobranca oTpCobr = new TipoCobranca();
                                oTpCobr.idTipoCobranca = 1;
                                oParcela.tipoCobranca = oTpCobr;
                                oParcela.valorParcela = oBaixa.valorTotal;

                                Formulario oFormulario = new Formulario();
                                oParcela.formulario = oFormulario;

                                List<ReceberParcela> lstParcela = new List<ReceberParcela>();
                                lstParcela.Add(oParcela);

                                oPgDoc.parcelas = lstParcela;

                                Ocorrencia oOco = new Ocorrencia();
                                Aplicativo oAplicativo = new Aplicativo();
                                oAplicativo.nome = "EMCFinanceiro";
                                oOco.aplicativo = oAplicativo;
                                oOco.chaveidentificacao = "";
                                oOco.data_hora = DateTime.Now;
                                oOco.descricao = "";
                                oOco.formulario = "frmReceberDocumento";
                                oOco.seqLogin = oOcorrencia.seqLogin;
                                oOco.tabela = "receberdocumento";
                                oOco.usuario = oOcorrencia.usuario;

                                ReceberDocumentoDAO oPgDocDAO = new ReceberDocumentoDAO(parConexao, oOco, codEmpresa);
                                oPgDocDAO.Salvar(Conexao, Transacao, oPgDoc);

                                ReceberParcelaDAO oPgParcDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                                ReceberParcela oParc = oPgParcDAO.ObterPor(oPgDoc.nroDocumento, 1, oPgDoc.codEmpresa);

                                idDivida = oParc.idReceberParcela;

                                //atribui o id da parcela gera ao cheque recebido para mapeamento da nova conta a receber
                                oCheque.idReceberParcela = EmcResources.cInt(idDivida.ToString());

                                lstChRecebidoGravar.Add(oCheque);

                            }


                        }


                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(oBaixa.codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                            "where a.table_name = 'ReceberBaixa'" +
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);
                        
                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idReceberBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        oBaixa.idMovimentoBancario = idMovBanco;
                        geraOcorrencia(oBaixa, "I");


                        //Monta comando para a gravação do registro
                        String strSQL = "insert into ReceberBaixa ( codempresa, idreceberParcela, datapagamento, valorbaixa, " +
                                                                " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                                " cadastro_idusuario, cadastro_datahora, nominal, situacao, iddivida, sdoamortizacao, idhistorico )  " +
                                                        " values (@codempresa, @idreceberParcela, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                                " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, @valordesconto, @idmovimentobancario, @cadastro_idusuario, " +
                                                                " @cadastro_datahora, @nominal, @situacao, @iddivida, @sdoamortizacao, @idhistorico )";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idreceberParcela", oBaixa.receberParcela.idReceberParcela);
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
                        Sqlcon.Parameters.AddWithValue("@situacao", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@iddivida", null);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        ReceberParcelaDAO oreceberParcela = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oreceberParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                        ChequeRecebidoDAO oChequeDAO = new ChequeRecebidoDAO(parConexao, oOcorrencia, codEmpresa);
                        foreach (ChequeRecebido oChGravar in oBaixa.lstCheque)
                        {
                            oChGravar.idMovimentoBancario = idMovBanco;
                            oChGravar.compensacao = "A";
                           
                            if (oBaixa.formaPagamento.idFormaPagamento == 3)
                                oChGravar.predatado = "S";

                            oChGravar.receberBaixa = oBaixa;
                            oChequeDAO.Salva(oChGravar, xConexao, Transacao);
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
                        string schemaBD = oParamDAO.retParametro(oBaixa.codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                            "where a.table_name = 'ReceberBaixa'" +
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idReceberBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oBaixa, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into ReceberBaixa ( codempresa, idreceberParcela, datapagamento, valorbaixa, " +
                                                              " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                              " cadastro_idusuario, cadastro_datahora, nominal, situacao, idamortizacao , sdoamortizacao, idhistorico) " +
                                                       " values (@codempresa, @idreceberParcela, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                               " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, " +
                                                               " @valordesconto, @idmovimentobancario, @cadastro_idusuario, @cadastro_datahora, " +
                                                               " @nominal, @situacao, @idamortizacao, @sdoamortizacao, @idhistorico )";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idreceberParcela", oBaixa.receberParcela.idReceberParcela);
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
                        Sqlcon.Parameters.AddWithValue("@situacao", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@idamortizacao", oBaixa.idAmortizacao.idReceberBaixa);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        ReceberParcelaDAO oreceberParcela = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oreceberParcela.atualizaSaldos(oBaixa, xConexao, Transacao);


                        //atualiza valor a amortizar no adiantamento
                        decimal sdoAmortizacao = oBaixa.idAmortizacao.sdoAmortizacao;
                        sdoAmortizacao = sdoAmortizacao - oBaixa.valorBaixa;

                        string strSQL3 = "update ReceberBaixa set sdoamortizacao=@saldo where idReceberBaixa=@idReceberBaixa";
                        MySqlCommand Sqlcon3 = new MySqlCommand(@strSQL3, xConexao, Transacao);
                        Sqlcon3.Parameters.AddWithValue("@idReceberBaixa", oBaixa.idAmortizacao.idReceberBaixa);
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
                                            "where a.table_name = 'receberbaixa'" +
                                            "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        while (drCon.Read())
                        {
                            oBaixa.idReceberBaixa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        }
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oBaixa, "I");
                        String strSQL = "insert into ReceberBaixa ( codempresa, idreceberParcela, datapagamento, valorbaixa, " +
                                                              " idformapagamento, historico, ctabancaria_idempresa, idcontacorrente, documentobaixa, valorjuros, valordesconto, idmovimentobancario, " +
                                                              " cadastro_idusuario, cadastro_datahora, nominal, situacao, idamortizacao , sdoamortizacao, idhistorico ) " +
                                                       " values (@codempresa, @idreceberParcela, @datapagamento, @valorbaixa, @idformapagamento, " +
                                                               " @historico, @ctabancaria_idempresa, @idcontacorrente, @documentobaixa, @valorjuros, " +
                                                               " @valordesconto, @idmovimentobancario, @cadastro_idusuario, @cadastro_datahora, " +
                                                               " @nominal, @situacao, @idamortizacao, @sdoamortizacao, @idhistorico )";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                        Sqlcon.Parameters.AddWithValue("@codempresa", oBaixa.codEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idreceberParcela", oBaixa.receberParcela.idReceberParcela);
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
                        Sqlcon.Parameters.AddWithValue("@situacao", oBaixa.situacaoBaixa);
                        Sqlcon.Parameters.AddWithValue("@idamortizacao", null);
                        Sqlcon.Parameters.AddWithValue("@sdoamortizacao", oBaixa.sdoAmortizacao);
                        Sqlcon.Parameters.AddWithValue("@idhistorico", oBaixa.idHistorico.idHistorico);
                        

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, Transacao);

                        //atualizar saldos no pagar parcela
                        ReceberParcelaDAO oReceberParcela = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oReceberParcela.atualizaSaldos(oBaixa, xConexao, Transacao);

                        //atualiza nro fatura no pagarparcela
                        oReceberParcela.atualizaFatura(oBaixa, xConexao, Transacao);

                    }

                    //Gerar ReceberRateio - rateio da baixa reliazada nos centros de custos e aplicação
                    List<ReceberBaseRateio> lstRateio = new List<ReceberBaseRateio>();
                    lstRateio = oBaixa.receberParcela.receberDocumento.baseRateio;

                    ReceberRateioDAO oRateioDAO = new ReceberRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateioDAO.rateioBaixa(oBaixa, lstRateio, xConexao, Transacao);

                    if (oBaixa.receberParcela.idAcordo > 0)
                    {
                        /* Estornar validade acordo */
                        //ReceberParcelaDAO oParcelaAcordoDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        //oParcelaAcordoDAO.estornaValidadeAcordo(oBaixa.receberParcela, xConexao, Transacao);
                    }

                }
               
            }
            catch (MySqlException erro)
            {
               throw erro;
            }
           
        }

        public DataTable pesquisaBaixaCompensar(int codEmpresa, int empMaster, int idCliente)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select b.idReceberBaixa, d.nrodocumento, p.nroparcela, f.nome as nomefornecedor, b.datapagamento, b.valorbaixa, b.sdoamortizacao  " +
                                " from ReceberBaixa b, receberParcela p, receberDocumento d, v_cliente f " +
                                " where p.idreceberParcela = b.idreceberParcela and d.idreceberdocumento = p.idreceberdocumento " +
                                  " and f.codempresa=d.cliente_codempresa and f.idpessoa=d.idcliente " +
                                  " and d.cliente_codempresa = @empmaster and d.idcliente=@idcliente " +
                                  " and b.codempresa=@codempresa " +
                                  " and b.sdoamortizacao > 0 ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@empmaster", empMaster);
                Sqlcon.Parameters.AddWithValue("@idcliente", idCliente);

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

        public DataTable ListaReceberBaixa(ReceberBaixa objReceberBaixa)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaixa where idreceberParcela=@idreceberParcela order by datapagamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberParcela", objReceberBaixa.receberParcela.idReceberParcela);

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

        public ReceberBaixa ObterPor(ReceberBaixa oReceberBaixa)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaixa Where idReceberBaixa = @idReceberBaixa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberBaixa", oReceberBaixa.idReceberBaixa);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                ReceberBaixa objReceberBaixa = new ReceberBaixa();

                while (drCon.Read())
                {
                    consulta = true;
                    objReceberBaixa.idReceberBaixa = Convert.ToInt32(drCon["idReceberBaixa"].ToString());
                    objReceberBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    ReceberParcela oPagarDoc = new ReceberParcela();
                    oPagarDoc.idReceberParcela = Convert.ToInt32(drCon["idreceberParcela"].ToString());

                    objReceberBaixa.receberParcela = oPagarDoc;

                    objReceberBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objReceberBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objReceberBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objReceberBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objReceberBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objReceberBaixa.idHistorico = oHistorico;

                    objReceberBaixa.historico = drCon["historico"].ToString();
                    objReceberBaixa.nominal = drCon["nominal"].ToString();
                    objReceberBaixa.situacaoBaixa = drCon["situacao"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objReceberBaixa.contaCorrente = oConta;

                    objReceberBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objReceberBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objReceberBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objReceberBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    ReceberParcela oDivida = new ReceberParcela();
                    oDivida.idReceberParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objReceberBaixa.idDivida = oDivida;

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ReceberParcelaDAO oPagarDocDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.receberParcela = oPagarDocDAO.ObterPor(objReceberBaixa.receberParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (objReceberBaixa.idDivida.idReceberParcela > 0)
                    {
                        ReceberParcelaDAO oReceberDivDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        objReceberBaixa.idDivida = oReceberDivDAO.ObterPor(objReceberBaixa.idDivida);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.formaPagamento = oFormaDAO.ObterPor(objReceberBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.contaCorrente = oContaDAO.ObterPor(objReceberBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.idHistorico = oHistDAO.ObterPor(objReceberBaixa.idHistorico);

                    ChequeRecebidoDAO oChRecebido = new ChequeRecebidoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.lstCheque = oChRecebido.listCheque(EmcResources.cInt(objReceberBaixa.idReceberBaixa.ToString()));

                }

                return objReceberBaixa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public ReceberBaixa ObterPor(int idDivida)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaixa Where iddivida = @iddivida ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@iddivida", idDivida);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                ReceberBaixa objReceberBaixa = new ReceberBaixa();

                while (drCon.Read())
                {
                    consulta = true;
                    objReceberBaixa.idReceberBaixa = Convert.ToInt32(drCon["idReceberBaixa"].ToString());
                    objReceberBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    ReceberParcela oPagarDoc = new ReceberParcela();
                    oPagarDoc.idReceberParcela = Convert.ToInt32(drCon["idreceberParcela"].ToString());

                    objReceberBaixa.receberParcela = oPagarDoc;

                    objReceberBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objReceberBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objReceberBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objReceberBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objReceberBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objReceberBaixa.idHistorico = oHistorico;

                    objReceberBaixa.historico = drCon["historico"].ToString();
                    objReceberBaixa.nominal = drCon["nominal"].ToString();
                    objReceberBaixa.situacaoBaixa = drCon["situacao"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objReceberBaixa.contaCorrente = oConta;

                    objReceberBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objReceberBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objReceberBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objReceberBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    ReceberParcela oDivida = new ReceberParcela();
                    oDivida.idReceberParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objReceberBaixa.idDivida = oDivida;

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ReceberParcelaDAO oPagarDocDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.receberParcela = oPagarDocDAO.ObterPor(objReceberBaixa.receberParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (objReceberBaixa.idDivida.idReceberParcela > 0)
                    {
                        ReceberParcelaDAO oReceberDivDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        objReceberBaixa.idDivida = oReceberDivDAO.ObterPor(objReceberBaixa.idDivida);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.formaPagamento = oFormaDAO.ObterPor(objReceberBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.contaCorrente = oContaDAO.ObterPor(objReceberBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.idHistorico = oHistDAO.ObterPor(objReceberBaixa.idHistorico);

                    ChequeRecebidoDAO oChRecebido = new ChequeRecebidoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberBaixa.lstCheque = oChRecebido.listCheque(EmcResources.cInt(objReceberBaixa.idReceberBaixa.ToString()));

                }

                return objReceberBaixa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<ReceberBaixa> ObterPor(MovimentoBancario oMovBanco)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaixa Where idmovimentobancario=@idmovbancario ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idmovbancario", oMovBanco.idMovimentoBancario);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                List<ReceberBaixa> lstReceberBaixa = new List<ReceberBaixa>();
                

                while (drCon.Read())
                {
                    ReceberBaixa objReceberBaixa = new ReceberBaixa();
                    consulta = true;
                    objReceberBaixa.idReceberBaixa = Convert.ToInt32(drCon["idReceberBaixa"].ToString());
                    objReceberBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    ReceberParcela oPagarDoc = new ReceberParcela();
                    oPagarDoc.idReceberParcela = Convert.ToInt32(drCon["idreceberParcela"].ToString());

                    objReceberBaixa.receberParcela = oPagarDoc;

                    objReceberBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objReceberBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objReceberBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objReceberBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objReceberBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objReceberBaixa.idHistorico = oHistorico;

                    objReceberBaixa.historico = drCon["historico"].ToString();
                    objReceberBaixa.nominal = drCon["nominal"].ToString();
                    objReceberBaixa.situacaoBaixa = drCon["situacao"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oConta.idCtaBancaria = Convert.ToInt32(drCon["idcontacorrente"].ToString());
                    objReceberBaixa.contaCorrente = oConta;

                    objReceberBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objReceberBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objReceberBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    objReceberBaixa.sdoAmortizacao = EmcResources.cCur(drCon["sdoamortizacao"].ToString());

                    ReceberParcela oDivida = new ReceberParcela();
                    oDivida.idReceberParcela = EmcResources.cInt(drCon["iddivida"].ToString());
                    objReceberBaixa.idDivida = oDivida;

                    
                    lstReceberBaixa.Add(objReceberBaixa);

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                List<ReceberBaixa> lstRetorno = new List<ReceberBaixa>();

                foreach (ReceberBaixa oPgBaixa in lstReceberBaixa)
                {
                    ReceberParcelaDAO oPagarDocDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.receberParcela = oPagarDocDAO.ObterPor(oPgBaixa.receberParcela);

                    //se for cheque pre busca a parcela em aberto gerada pelo cheque pre
                    if (oPgBaixa.idDivida.idReceberParcela > 0)
                    {
                        ReceberParcelaDAO oReceberDivDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.idDivida = oReceberDivDAO.ObterPor(oPgBaixa.idDivida);
                    }

                    FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.formaPagamento = oFormaDAO.ObterPor(oPgBaixa.formaPagamento);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.contaCorrente = oContaDAO.ObterPor(oPgBaixa.contaCorrente);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.idHistorico = oHistDAO.ObterPor(oPgBaixa.idHistorico);

                    ChequeRecebidoDAO oChRecebido = new ChequeRecebidoDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgBaixa.lstCheque = oChRecebido.listCheque(EmcResources.cInt(oPgBaixa.idReceberBaixa.ToString()));

                    lstRetorno.Add(oPgBaixa);
                }

                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<ReceberBaixa> listaBaixasParcela(int? idreceberParcela)
        {
            bool consulta = false;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaixa p " +
                                " where p.idreceberParcela=@idreceberParcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberParcela", idreceberParcela);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ReceberBaixa> lstParcela = new List<ReceberBaixa>();
                List<ReceberBaixa> lstRetorno = new List<ReceberBaixa>();


                while (drCon.Read())
                {
                    consulta = true;
                    ReceberBaixa objReceberBaixa = new ReceberBaixa();
                    objReceberBaixa.idReceberBaixa = Convert.ToInt32(drCon["idReceberBaixa"].ToString());
                    objReceberBaixa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());

                    //não faz a busca da receberParcela para não entrar em loop
                    ReceberParcela oPagarDoc = new ReceberParcela();
                    oPagarDoc.idReceberParcela = Convert.ToInt32(drCon["idreceberParcela"].ToString());
                    objReceberBaixa.receberParcela = oPagarDoc;

                    objReceberBaixa.dataPagamento = Convert.ToDateTime(drCon["datapagamento"].ToString());
                    objReceberBaixa.valorBaixa = Convert.ToDecimal(drCon["valorbaixa"].ToString());
                    objReceberBaixa.valorJuros = Convert.ToDecimal(drCon["valorjuros"].ToString());
                    objReceberBaixa.valorDesconto = Convert.ToDecimal(drCon["valordesconto"].ToString());

                    FormaPagamento oForma = new FormaPagamento();
                    oForma.idFormaPagamento = Convert.ToInt32(drCon["idformapagamento"].ToString());
                    objReceberBaixa.formaPagamento = oForma;

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objReceberBaixa.idHistorico = oHistorico;

                    objReceberBaixa.historico = drCon["historico"].ToString();
                    objReceberBaixa.nominal = drCon["nominal"].ToString();

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
                    objReceberBaixa.contaCorrente = oConta;

                    objReceberBaixa.documentoBaixa = drCon["documentobaixa"].ToString();
                    objReceberBaixa.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objReceberBaixa.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objReceberBaixa.situacaoBaixa = drCon["situacao"].ToString();

                    lstParcela.Add(objReceberBaixa);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (ReceberBaixa oPgBaixa in lstParcela)
                    {
                        FormaPagamentoDAO oFormaDAO = new FormaPagamentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.formaPagamento = oFormaDAO.ObterPor(oPgBaixa.formaPagamento); ;


                        HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgBaixa.idHistorico = oHistDAO.ObterPor(oPgBaixa.idHistorico);

                        if (oPgBaixa.contaCorrente.idCtaBancaria == 0)
                        {
                            Banco oBanco = new Banco();
                            oBanco.descricao = "";
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
                String strSQL = "select b.idreceberbaixa as idbaixa, b.idmovimentobancario, b.nrodocumento, b.nroparcela, b.documentobaixa, " +
                                " b.nome as nomeforncli, b.datapagamento, b.valorparcela, b.jurosbaixa, " +
                                " b.descontobaixa, b.valorbaixa " +
                                " from v_receberbaixa b " +
                                " where b.idmovimentobancario in (" + idMovimentoBancario + ")";
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

        public Boolean verificaBaixaDtaContabil(int idReceberDocumento)
        {
            Boolean baixa = false;
            try
            {
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao, oOcorrencia, codEmpresa);
                DateTime dataContabil = Convert.ToDateTime(oParametroDAO.retParametro(codEmpresa, "EMCCONTABIL", "VALIDACAO", "PROCESSO_CONTABIL"));


                //Monta comando para a gravação do registro
                String strSQL = "select * from v_receberbaixa Where codempresa=@codempresa and idreceberdocumento=@id and datapagamento<=@data ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@id", idReceberDocumento);
                Sqlcon.Parameters.AddWithValue("@data", dataContabil);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    baixa = true;
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

        private void geraOcorrencia(ReceberBaixa oReceberBaixa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oReceberBaixa.receberParcela.receberDocumento.idReceberDocumento.ToString();

                if (flag == "A")
                {

                    ReceberBaixa oPgBaixa = new ReceberBaixa();
                    oPgBaixa = ObterPor(oReceberBaixa);

                    if (!oPgBaixa.Equals(oReceberBaixa))
                    {

                        // alteração de pagamento não implementada
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Receber Baixa id : " + oReceberBaixa.idReceberBaixa +
                                " - CodEmpresa - " + oReceberBaixa.codEmpresa +
                                " - Id Documento - " + oReceberBaixa.receberParcela.receberDocumento.idReceberDocumento +
                                " - Id Parcela - " + oReceberBaixa.receberParcela.idReceberParcela +
                                " - Fornecedor - " + oReceberBaixa.receberParcela.receberDocumento.cliente.pessoa.idPessoa + " - " +
                                                    oReceberBaixa.receberParcela.receberDocumento.cliente.pessoa.nome +
                                " - Documento - " + oReceberBaixa.receberParcela.receberDocumento.nroDocumento +
                                " - Nro Parcela - " + oReceberBaixa.receberParcela.nroParcela +
                                " - Data Pagamento - " + oReceberBaixa.dataPagamento +
                                " - Valor Baixa - " + oReceberBaixa.valorBaixa +
                                " - Valor Juros - " + oReceberBaixa.valorJuros +
                                " - Valor Desconto - " + oReceberBaixa.valorDesconto +
                                " - Valor Total - " + oReceberBaixa.valorTotal +
                                " - Forma Pagamento - " + oReceberBaixa.formaPagamento.idFormaPagamento + " - " + oReceberBaixa.formaPagamento.descricao +
                                " - idHistorico - " + oReceberBaixa.idHistorico.idHistorico + " - " + oReceberBaixa.idHistorico.descricao +
                                " - Historico - " + oReceberBaixa.historico +
                                " - Documento Baixa - " + oReceberBaixa.documentoBaixa +
                                " - Nominal - " + oReceberBaixa.nominal +
                                " - Id Mov Bancario - " + oReceberBaixa.idMovimentoBancario +
                                " - Conta Corrente - Empresa : - " + oReceberBaixa.contaCorrente.codEmpresa + " - Conta : " + oReceberBaixa.contaCorrente.idCtaBancaria + " - " + oReceberBaixa.contaCorrente.descricao +
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
