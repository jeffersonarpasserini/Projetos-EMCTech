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
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCIntegracaoModel;
using EMCIntegracaoDAO;

namespace EMCFinanceiroDAO
{
    public class PagarParcelaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarParcelaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
        /// Realiza busca ao banco de dados das parcelas em aberto para aprovação de pagamento de acordo com o parametros informados
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <param name="DataInicio"></param>
        /// <param name="Datafinal"></param>
        /// <param name="todosValores"></param>
        /// <returns></returns>
        public List<PagarParcela> listaPagarLiberacao(int idUsuario, int codempresa, int idFornecedor, DateTime? dataInicio, DateTime? dataFinal, bool todos, string docPagar, decimal valorInicio, decimal valorFinal, bool todosValores)
        {
            bool consulta = false;
            
            try
            {
                //verifica o numero de liberações necessarias para aprovação do titulos para pagamento
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                string nroLiberacoes = oParametroDAO.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "NUMERO_LIBERACAO");

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas p, pagardocumento d " +
                                " where d.idpagardocumento = p.idpagardocumento and p.situacao='A' " + 
                                "   and p.autorizado = 'N' " + 
                                "   and p.codempresa = @codempresa ";

                if (!String.IsNullOrEmpty(docPagar))
                {
                    strSQL = strSQL + "and d.nrodocumento=@nrodocumento ";
                }
                if (!todos)
                {
                    strSQL = strSQL + "and p.datavencimento >= @datainicio and p.datavencimento <= @datafinal ";
                }
                if (!todosValores)
                {
                    strSQL = strSQL + "and p.saldopagar >= @valorinicio and p.saldopagar <= @valorfinal ";
                }
                if (idFornecedor > 0)
                {
                    strSQL = strSQL + "and d.idfornecedor = @idfornecedor ";
                }

                //strSQL = strSQL + " order by p.idpagardocumento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);
                Sqlcon.Parameters.AddWithValue("@codempresa", codempresa);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", docPagar);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@valorinicio", valorInicio);
                Sqlcon.Parameters.AddWithValue("@valorfinal", valorFinal);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", idFornecedor);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<PagarParcela> lstRetorno = new List<PagarParcela>();
                List<PagarParcela> lstParcela = new List<PagarParcela>();

                //lstParcela = null;

                
                PagarParcela objPagarParcela;
                
                while (drCon.Read())
                {
                    consulta = true;

                    objPagarParcela = new PagarParcela();

                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    objPagarParcela.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());

                    //PagarDocumento
                    PagarDocumento oPagarDoc = new PagarDocumento();
                    oPagarDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                   
                    objPagarParcela.pagarDocumento = oPagarDoc;

                    objPagarParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objPagarParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objPagarParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objPagarParcela.valorCMPago = EmcResources.cCur(drCon["valorcmpago"].ToString());
                    objPagarParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objPagarParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objPagarParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objPagarParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objPagarParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objPagarParcela.situacao = drCon["situacao"].ToString();
                    objPagarParcela.nossoNumero = drCon["nossonumero"].ToString();
                    objPagarParcela.codigoBarras = drCon["codigobarras"].ToString();
                    objPagarParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarParcela.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarParcela.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarParcela.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());


                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objPagarParcela.tipoCobranca = oTpCobr;

                    lstParcela.Add(objPagarParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (PagarParcela oPgParcDoc in lstParcela)
                    {

                        PagarDocumentoDAO oPagarDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgParcDoc.pagarDocumento = oPagarDocDAO.ObterDocParcela(oPgParcDoc.pagarDocumento);

                        TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgParcDoc.tipoCobranca = oTpCobrDAO.ObterPor(oPgParcDoc.tipoCobranca);

                        lstRetorno.Add(oPgParcDoc);
                    }
                }
                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas para montagem de uma fatura
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <param name="DataInicio"></param>
        /// <param name="Datafinal"></param>
        /// <param name="todosValores"></param>
        /// <returns></returns>
        public List<PagarParcela> listaPagarFatura(int idUsuario, int codempresa, int idFornecedor, DateTime? dataInicio, DateTime? dataFinal, bool todos)
        {
        
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas p, pagardocumento d " +
                                " where d.idpagardocumento = p.idpagardocumento and p.situacao='A' " +
                                "   and p.autorizado = 'N' ";

                if (!todos)
                {
                    strSQL = strSQL + "and p.datavencimento >= @datainicio and p.datavencimento <= @datafinal ";
                }
                if (idFornecedor > 0)
                {
                    strSQL = strSQL + "and d.idfornecedor = @idfornecedor ";
                }

                strSQL = strSQL + " order by p.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", idFornecedor);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<PagarParcela> lstParcela = new List<PagarParcela>();
                List<PagarParcela> lstRetorno = new List<PagarParcela>();

                while (drCon.Read())
                {
                  
                    PagarParcela objPagarParcela = new PagarParcela();

                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    
                    lstParcela.Add(objPagarParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                foreach (PagarParcela oParc in lstParcela)
                {
                    lstRetorno.Add(ObterPor(oParc));
                }

                
                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas pertencentes a uma fatura
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <param name="DataInicio"></param>
        /// <param name="Datafinal"></param>
        /// <param name="todosValores"></param>
        /// <returns></returns>
        public List<PagarParcela> listaParcelasFatura(int idPagarFatura)
        {
          
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas p where p.pagarfatura_idpagarfatura=@idfatura ";
                strSQL = strSQL + " order by p.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idfatura", idPagarFatura);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<PagarParcela> lstParcela = new List<PagarParcela>();
                List<PagarParcela> lstRetorno = new List<PagarParcela>();
                //lstParcela = null

                while (drCon.Read())
                {

                    PagarParcela objPagarParcela = new PagarParcela();

                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idpagarparcelas"].ToString());

                    lstParcela.Add(objPagarParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                foreach (PagarParcela oParc in lstParcela)
                {
                    lstRetorno.Add(ObterPor(oParc));
                }

                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas em aberto para pagamento de acordo com o parametros informados
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <returns></returns>
        public List<PagarParcela> listaParcelaBaixa(int empmaster, int idFornecedor, DateTime? dataInicio, DateTime? dataFinal, bool todos, string docPagar)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas p, pagardocumento d " + 
                                " where d.idpagardocumento = p.idpagardocumento and p.situacao='A' " +
                                "   and d.codempresa = @codempresa ";

                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                //verifica o parametro se obriga a ter liberação previa para pagamento
                if (oParametroDAO.retParametro(codEmpresa, "EMCFINANCEIRO", "CTAPAGAR", "OBRIGA_LIBERACAO") == "S")
                {
                    strSQL = strSQL + "and p.autorizado='S' ";
                }
                if (!String.IsNullOrEmpty(docPagar))
                {
                    strSQL = strSQL + "and d.nrodocumento=@nrodocumento " ;
                }
                if (!todos)
                {
                    strSQL = strSQL + "and p.datavencimento >= @datainicio and p.datavencimento <= @datafinal " ;
                }                
                if (idFornecedor > 0)
                {
                    strSQL = strSQL + "and d.fornecedor_codempresa=@empmaster and d.idfornecedor = @idfornecedor " ;
                }
                
                strSQL = strSQL + " order by p.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", docPagar);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@empmaster", empmaster);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", idFornecedor);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<PagarParcela> lstRetorno = new List<PagarParcela>();
                List<PagarParcela> lstParcela = new List<PagarParcela>();

                //lstParcela = null;

                
                PagarParcela objPagarParcela;

                while (drCon.Read())
                {
                    consulta = true;
                    objPagarParcela = new PagarParcela();

                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    objPagarParcela.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());

                    //PagarDocumento
                    PagarDocumento oPagarDoc = new PagarDocumento();
                    oPagarDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    objPagarParcela.pagarDocumento = oPagarDoc;

                    objPagarParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objPagarParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objPagarParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarParcela.valorCMPago = EmcResources.cCur(drCon["valorcmpago"].ToString());
                    objPagarParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objPagarParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objPagarParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objPagarParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objPagarParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objPagarParcela.situacao = drCon["situacao"].ToString();
                    objPagarParcela.nossoNumero = drCon["nossonumero"].ToString();
                    objPagarParcela.codigoBarras = drCon["codigobarras"].ToString();
                    objPagarParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarParcela.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarParcela.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarParcela.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());

                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objPagarParcela.tipoCobranca = oTpCobr;
                    
                    lstParcela.Add(objPagarParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (PagarParcela oPgParcDoc in lstParcela)
                    {
                        PagarDocumentoDAO oPagarDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgParcDoc.pagarDocumento = oPagarDocDAO.ObterDocParcela(oPgParcDoc.pagarDocumento);

                        TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgParcDoc.tipoCobranca = oTpCobrDAO.ObterPor(oPgParcDoc.tipoCobranca);

                        lstRetorno.Add(oPgParcDoc);
                    }
                }
                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Realiza a liberação do documento para pagamento - gerando sua propria transacao
        /// </summary>
        /// <param name="List<PagarParcela> lstParcelas"></param>
        /// <returns></returns>
        public void liberacaoPagamento(List<PagarParcela> lstParcelas, int codEmpresa)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            try
            {
                liberacaoPagamento(lstParcelas, Conexao, Transacao, codEmpresa);

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
        /// <summary>
        /// Realiza a liberação do documento para pagamento - utilizando a transação de outro processo
        /// </summary>
        /// <param name="List<PagarParcela> lstParcelas"></param>
        /// <returns></returns>
        public void liberacaoPagamento(List<PagarParcela> lstParcelas, MySqlConnection Conexao, MySqlTransaction transacao,int codEmpresa)
        {
            try
            {
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                string nroAprovadores = oParametroDAO.retParametro(codEmpresa, "EMCFINANCEIRO", "CTAPAGAR", "NUMERO_LIBERACAO");
                string strSQL = "";

                foreach (PagarParcela oParcela in lstParcelas)
                {
                    //verifica o parametro considera data valida para vencimento de parcelas.
                    if (EmcResources.cInt(nroAprovadores.Trim()) == 1 && oParcela.autorizador_idUsuario > 0)
                    {
                        oParcela.autorizado = "S";
                    }
                    else if (EmcResources.cInt(nroAprovadores.Trim()) == 1 && oParcela.autorizador_idUsuario > 0 && oParcela.autorizador2_idUsuario > 0)
                    {
                        oParcela.autorizado = "S";
                    }
                    else
                        oParcela.autorizado = "N";


                    geraOcorrencia(oParcela, "LIB");

                    strSQL = "update pagarparcelas set autorizador_idusuario=@autorizador_idusuario, " +
                                                   "  autorizador2_idusuario=@autorizador2_idusuario, " +
                                                   "  autorizado=@autorizado where idpagarparcelas=@idpagarparcela ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                    Sqlcon.Parameters.AddWithValue("@idPagarParcela", oParcela.idPagarParcela);
                    Sqlcon.Parameters.AddWithValue("@autorizador_idusuario", oParcela.autorizador_idUsuario);
                    if (oParcela.autorizador2_idUsuario > 0)
                        Sqlcon.Parameters.AddWithValue("@autorizador2_idusuario", oParcela.autorizador2_idUsuario);
                    else
                        Sqlcon.Parameters.AddWithValue("@autorizador2_idusuario", null);
                    Sqlcon.Parameters.AddWithValue("@autorizado", oParcela.autorizado);

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Salva as parcelas do contas a pagar recebendo também a conexão com o Banco de dados e a transação
        /// </summary>
        /// <param name="objPagarParcela"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public void Salvar(PagarParcela objPagarParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'pagarparcelas'"+
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idPagar = 0;
                while (drCon.Read())
                {
                    idPagar = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    objPagarParcela.idPagarParcela = idPagar;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objPagarParcela, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into PagarParcelas (codempresa, idpagardocumento, datavencimento, dataquitacao, " +
                                                            "valorparcela, saldopagar, saldopago, situacao, nossonumero,  " +
                                                            "codigobarras, valorjuros, valordesconto, nroparcela,idtipocobranca,cadastro_idusuario,cadastro_datahora, autorizado, " + 
                                                            "valorindexado, dataultimacorrecao, valorindice, valorcorrecaomonetaria, valorcmpago )" +
                                                            "values (@codempresa, @idpagardocumento, @datavencimento, " +
                                                            "@dataquitacao, @valorparcela, @saldopagar, @saldopago, @situacao, " +
                                                            "@nossonumero, @codigobarras, @valorjuros, @valordesconto, @nroparcela, @idtipocobranca, @cadastro_idusuario, @cadastro_datahora, @autorizado, " + 
                                                            "@valorindexado, @dataultimacorrecao, @valorindice, @valorcorrecaomonetaria, @valorcmpago )";
                MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                SqlconPar.Parameters.AddWithValue("@codempresa", objPagarParcela.codEmpresa);
                SqlconPar.Parameters.AddWithValue("@idpagardocumento", objPagarParcela.pagarDocumento.idPagarDocumento);
                SqlconPar.Parameters.AddWithValue("@datavencimento", objPagarParcela.dataVencimento);
                SqlconPar.Parameters.AddWithValue("@dataquitacao", objPagarParcela.dataQuitacao);
                SqlconPar.Parameters.AddWithValue("@valorparcela", objPagarParcela.valorParcela);
                SqlconPar.Parameters.AddWithValue("@saldopago", objPagarParcela.saldoPago);
                SqlconPar.Parameters.AddWithValue("@saldopagar", objPagarParcela.saldoPagar);
                SqlconPar.Parameters.AddWithValue("@situacao", objPagarParcela.situacao);
                SqlconPar.Parameters.AddWithValue("@nossonumero", objPagarParcela.nossoNumero);
                SqlconPar.Parameters.AddWithValue("@codigobarras", objPagarParcela.codigoBarras);
                SqlconPar.Parameters.AddWithValue("@valorjuros", objPagarParcela.valorJuros);
                SqlconPar.Parameters.AddWithValue("@valordesconto", objPagarParcela.valorDesconto);
                SqlconPar.Parameters.AddWithValue("@nroparcela", objPagarParcela.nroParcela);
                SqlconPar.Parameters.AddWithValue("@valorindice", objPagarParcela.valorIndice);
                SqlconPar.Parameters.AddWithValue("@valorcorrecaomonetaria", objPagarParcela.valorCorrecaoMonetaria);
                SqlconPar.Parameters.AddWithValue("@idtipocobranca", objPagarParcela.tipoCobranca.idTipoCobranca);
                SqlconPar.Parameters.AddWithValue("@cadastro_idusuario", objPagarParcela.cadastro_idusuario);
                SqlconPar.Parameters.AddWithValue("@cadastro_datahora", objPagarParcela.cadastro_datahora);
                SqlconPar.Parameters.AddWithValue("@valorindexado", objPagarParcela.valorIndexado);
                SqlconPar.Parameters.AddWithValue("@dataultimacorrecao", objPagarParcela.dataUltimaCorrecao);
                SqlconPar.Parameters.AddWithValue("@autorizado", "N");
                SqlconPar.Parameters.AddWithValue("@valorcmpago", objPagarParcela.valorCMPago);
                //abre conexao e executa o comando
                SqlconPar.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        /// <summary>
        /// Atualiza as parcelas do contas a pagar recebendo também a conexão com o Banco de dados e a transação
        /// </summary>
        /// <param name="objPagarParcela"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public void Atualizar(PagarParcela objPagarParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //atualiza um registro de PagarParcela
            try
            {
                geraOcorrencia(objPagarParcela, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update PagarParcelas set datavencimento=@datavencimento, " +
                                                         " valorparcela=@valorparcela, " +
                                                         " situacao=@situacao, nossonumero=@nossonumero, codigobarras=@codigobarras, " +
                                                         " nroparcela=@nroparcela, idtipocobranca=@idtipocobranca, " +
                                                         " cadastro_idusuario=@cadastro_usuario, cadastro_datahora=@cadastro_datahora, " +
                                                         " saldopagar=@saldopagar, valorindexado=@valorindexado,  " +
                                                         " valorindice=@valorindice, " +
                                                         " dataultimacorrecao=@dataultimacorrecao " +
                                                         " where idPagarParcelas = @idPagarParcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarParcela", objPagarParcela.idPagarParcela);
                Sqlcon.Parameters.AddWithValue("@codempresa", objPagarParcela.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", objPagarParcela.pagarDocumento.idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@datavencimento", objPagarParcela.dataVencimento);
                //Sqlcon.Parameters.AddWithValue("@dataquitacao", objPagarParcela.dataQuitacao);
                Sqlcon.Parameters.AddWithValue("@valorparcela", objPagarParcela.valorParcela);
                //Sqlcon.Parameters.AddWithValue("@saldopago", objPagarParcela.saldoPago);
                Sqlcon.Parameters.AddWithValue("@saldopagar", objPagarParcela.saldoPagar);
                Sqlcon.Parameters.AddWithValue("@situacao", objPagarParcela.situacao);
                Sqlcon.Parameters.AddWithValue("@nossonumero", objPagarParcela.nossoNumero);
                Sqlcon.Parameters.AddWithValue("@codigobarras", objPagarParcela.codigoBarras);
                //Sqlcon.Parameters.AddWithValue("@valorjuros", objPagarParcela.valorJuros);
                //Sqlcon.Parameters.AddWithValue("@valordesconto", objPagarParcela.valorDesconto);
                Sqlcon.Parameters.AddWithValue("@nroparcela", objPagarParcela.nroParcela);
                Sqlcon.Parameters.AddWithValue("@idtipocobranca", objPagarParcela.tipoCobranca.idTipoCobranca);
                Sqlcon.Parameters.AddWithValue("@cadastro_usuario", objPagarParcela.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objPagarParcela.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@valorindexado", objPagarParcela.valorIndexado);
                Sqlcon.Parameters.AddWithValue("@dataultimacorrecao", objPagarParcela.dataUltimaCorrecao);
                Sqlcon.Parameters.AddWithValue("@valorindice", objPagarParcela.valorIndice);
                
                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            
        }
        /// <summary>
        /// Atualiza os saldos da parcela de acordo com a baixa realizada
        /// </summary>
        /// <param name="oBaixa"></param>
        public void atualizaSaldos(PagarBaixa oBaixa, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            //atualiza um registro de PagarParcela
            try
            {
                String situacaoParcela = "A";
                DateTime? dataQuitacao = null;
                if ((oBaixa.pagarParcela.saldoPagar - oBaixa.valorBaixa) == 0)
                {
                    situacaoParcela = "P";
                    dataQuitacao = oBaixa.dataPagamento;
                    oBaixa.pagarParcela.dataQuitacao = dataQuitacao;
                    oBaixa.pagarParcela.situacao = situacaoParcela;
                }

                oBaixa.pagarParcela.dataQuitacao = dataQuitacao;
                oBaixa.pagarParcela.situacao = situacaoParcela;
                oBaixa.pagarParcela.saldoPago = (oBaixa.pagarParcela.saldoPago + oBaixa.valorBaixa);
                oBaixa.pagarParcela.saldoPagar = (oBaixa.pagarParcela.saldoPagar-oBaixa.valorBaixa);
                oBaixa.pagarParcela.valorJuros = (oBaixa.pagarParcela.valorJuros+oBaixa.valorJuros);
                oBaixa.pagarParcela.valorDesconto = (oBaixa.pagarParcela.valorDesconto+oBaixa.valorDesconto);
                oBaixa.pagarParcela.valorCMPago = (oBaixa.pagarParcela.valorCMPago + oBaixa.valorCorrecaoMonetaria);

               
                

                geraOcorrencia(oBaixa.pagarParcela, "SDO");
                
                //Monta comando para a gravação do registro
                String strSQL = "update PagarParcelas set dataquitacao=@dataquitacao, situacao=@situacao, " +
                                                         " saldopagar=@saldopagar, saldopago=@saldopago, " +
                                                         " valorjuros=@valorjuros, valordesconto=@valordesconto, " +
                                                         " valorcmpago=@valorcmpago " +
                                                         " where idPagarParcelas = @idPagarParcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@saldopago", oBaixa.pagarParcela.saldoPago );
                Sqlcon.Parameters.AddWithValue("@saldopagar", oBaixa.pagarParcela.saldoPagar);
                Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.pagarParcela.valorJuros);
                Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.pagarParcela.valorDesconto);
                Sqlcon.Parameters.AddWithValue("@dataquitacao", dataQuitacao);
                Sqlcon.Parameters.AddWithValue("@situacao", situacaoParcela);
                Sqlcon.Parameters.AddWithValue("@valorcmpago", oBaixa.pagarParcela.valorCMPago);
                Sqlcon.Parameters.AddWithValue("@idPagarParcela", oBaixa.pagarParcela.idPagarParcela);

                
         
                Sqlcon.ExecuteNonQuery();

                if (verificaSituacaoDocumento( oBaixa, Conecta, Transacao))
                {
                    PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    oPgDocDAO.alteraSitucao(Conecta, Transacao, oBaixa.pagarParcela.pagarDocumento, "P");
                }

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Atualiza numero da Fatura da parcela de acordo com a baixa realizada
        /// </summary>
        /// <param name="oBaixa"></param>
        public void atualizaFatura(PagarBaixa oBaixa, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            //atualiza um registro de PagarParcela
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "update PagarParcelas set pagarfatura_idpagarfatura=@idfatura " +
                                                         " where idPagarParcelas = @idPagarParcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@idfatura", oBaixa.pagarParcela.idpagarfatura);
                Sqlcon.Parameters.AddWithValue("@idPagarParcela", oBaixa.pagarParcela.idPagarParcela);

                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Verifica se todas as parcelas estão quitadas para alterar a situação do documento
        /// </summary>
        /// <param name="objBaixa"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public bool verificaSituacaoDocumento(PagarBaixa oBaixa, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            bool quitado = true;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas Where idpagardocumento = @idpagardocumento and situacao = 'A' ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", oBaixa.pagarParcela.pagarDocumento.idPagarDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    quitado = false;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return quitado;
        }
        /// <summary>
        /// Exclui as parcelas do contas a pagar recebendo também a conexão com o Banco de dados e a transação
        /// </summary>
        /// <param name="objPagarParcela"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public void Excluir(PagarParcela objPagarParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //apaga registro de PagarParcela
            try
            {

                geraOcorrencia(objPagarParcela, "E");

                // antes de excluir a parcela verifica se existe integração nivel parcela
                if (objPagarParcela.pagarDocumento.origemDocumento != "CTAPAGAR")
                {
                    IntegFinanceiro oIntegFinanceiro = new IntegFinanceiro();
                    IntegFinanceiroDAO oIntegFinanceiroDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);

                    if (objPagarParcela.pagarDocumento.origemDocumento == "EMCIMOB")
                    {
                        var idPagarParcela = EmcResources.cInt(objPagarParcela.idPagarParcela.ToString());

                        oIntegFinanceiro = oIntegFinanceiroDAO.ObterPorPagarParcela(idPagarParcela);
                        oIntegFinanceiro.statusOperacao = "E";

                        oIntegFinanceiroDAO.Salvar(oIntegFinanceiro, Conexao, transacao);
                    }

                }

                //Monta comando para a gravação do registro
                String strSQL = "delete from PagarParcelas where idPagarParcelas = @idPagarParcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarParcela", objPagarParcela.idPagarParcela);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        /// <summary>
        /// Lista as parcelas do contas a pagar retornando um datatable
        /// </summary>
        /// <param name="objPagarParcela"></param>
        /// <returns></returns>
        public DataTable ListaPagarParcela(PagarParcela objPagarParcela)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas where idpagardocumento=@idpagardocumento order by nroparcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", objPagarParcela.pagarDocumento.idPagarDocumento);

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
        /// <summary>
        /// Retorna uma lista "List" das parcelas a pagar
        /// </summary>
        /// <param name="oPagarParcela"></param>
        /// <returns></returns>
        public List<PagarParcela> ParcelaDocumento(PagarParcela oPagarParcela)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas Where idPagarDocumento = @idPagarDocumento order by nroparcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idPagarDocumento", oPagarParcela.pagarDocumento.idPagarDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();
                
                List<PagarParcela> lstParcela = new List<PagarParcela>();
                List<PagarParcela> lstRetorno = new List<PagarParcela>();

                //lstParcela = null;

                PagarDocumento oPagarDoc = new PagarDocumento();
                PagarParcela objPagarParcela;
                
                while (drCon.Read())
                {
                    consulta = true;
                    objPagarParcela = new PagarParcela();

                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    objPagarParcela.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    
                    oPagarDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    objPagarParcela.pagarDocumento = oPagarDoc;

                    objPagarParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objPagarParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objPagarParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objPagarParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objPagarParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objPagarParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objPagarParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objPagarParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objPagarParcela.situacao = drCon["situacao"].ToString();
                    objPagarParcela.nossoNumero = drCon["nossonumero"].ToString();
                    objPagarParcela.codigoBarras = drCon["codigobarras"].ToString();
                    objPagarParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarParcela.autorizador_idUsuario = EmcResources.cInt(drCon["autorizador_idusuario"].ToString());
                    objPagarParcela.autorizador2_idUsuario = EmcResources.cInt(drCon["autorizador2_idusuario"].ToString());
                    objPagarParcela.autorizado = drCon["autorizado"].ToString();
                    objPagarParcela.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarParcela.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarParcela.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarParcela.valorCMPago = EmcResources.cCur(drCon["valorcmpago"].ToString());


                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objPagarParcela.tipoCobranca = oTpCobr;

                    lstParcela.Add(objPagarParcela);

                   
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (PagarParcela oPgParcDoc in lstParcela)
                    {
                        PagarDocumentoDAO oPagarDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgParcDoc.pagarDocumento = oPagarDocDAO.ObterDocParcela(oPgParcDoc.pagarDocumento);

                        TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgParcDoc.tipoCobranca = oTpCobrDAO.ObterPor(oPgParcDoc.tipoCobranca);

                        lstRetorno.Add(oPgParcDoc);
                    }
                }

                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Busca uma parcela especifica retornando um objeto tipo PagarParcela
        /// </summary>
        /// <param name="oPagarParcela"></param>
        /// <returns></returns>
        public PagarParcela ObterPor(string nroDocumento, int nroParcela, int codEmpresa, Fornecedor oFornecedor)
        {
            bool consulta = false;
            try
            {

                PagarDocumento oPgDoc = new PagarDocumento();
                oPgDoc.nroDocumento=nroDocumento;
                oPgDoc.codEmpresa = codEmpresa;
                oPgDoc.fornecedor = oFornecedor;

                PagarDocumentoDAO oPgDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                oPgDoc=oPgDAO.ObterPor(oPgDoc);

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas Where idpagardocumento = @idpagardocumento and nroparcela=@nroparcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", oPgDoc.idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@nroparcela", nroParcela);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                PagarDocumento oPagarDoc = new PagarDocumento();

                PagarParcela objPagarParcela = new PagarParcela();

                while (drCon.Read())
                {
                    consulta = true;
                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    objPagarParcela.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());


                    oPagarDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    objPagarParcela.pagarDocumento = oPagarDoc;

                    objPagarParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objPagarParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objPagarParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objPagarParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objPagarParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objPagarParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objPagarParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objPagarParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objPagarParcela.situacao = drCon["situacao"].ToString();
                    objPagarParcela.nossoNumero = drCon["nossonumero"].ToString();
                    objPagarParcela.codigoBarras = drCon["codigobarras"].ToString();
                    objPagarParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarParcela.autorizador_idUsuario = EmcResources.cInt(drCon["autorizador_idusuario"].ToString());
                    objPagarParcela.autorizador2_idUsuario = EmcResources.cInt(drCon["autorizador2_idusuario"].ToString());
                    objPagarParcela.autorizado = drCon["autorizado"].ToString();
                    objPagarParcela.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarParcela.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarParcela.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarParcela.valorCMPago = EmcResources.cCur(drCon["valorcmpago"].ToString());

                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objPagarParcela.tipoCobranca = oTpCobr;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarDocumentoDAO oPagarDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.pagarDocumento = oPagarDocDAO.ObterDocParcela(objPagarParcela.pagarDocumento);

                    TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.tipoCobranca = oTpCobrDAO.ObterPor(objPagarParcela.tipoCobranca);

                    //busca as baixas da parcela
                    PagarBaixaDAO oBaixaDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.baixas = oBaixaDAO.listaBaixasParcela(objPagarParcela.idPagarParcela);
                }
                return objPagarParcela;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        /// <summary>
        /// Busca uma parcela especifica retornando um objeto tipo PagarParcela
        /// </summary>
        /// <param name="oPagarParcela"></param>
        /// <returns></returns>
        public PagarParcela ObterPor(PagarParcela oPagarParcela)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas Where idPagarParcelas = @idPagarParcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idPagarParcela", oPagarParcela.idPagarParcela);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                PagarDocumento oPagarDoc = new PagarDocumento();
                
                PagarParcela objPagarParcela = new PagarParcela();

                while (drCon.Read())
                {
                    consulta = true;
                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    objPagarParcela.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());


                    oPagarDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    objPagarParcela.pagarDocumento = oPagarDoc;

                    objPagarParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objPagarParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objPagarParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objPagarParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objPagarParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objPagarParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objPagarParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objPagarParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objPagarParcela.situacao = drCon["situacao"].ToString();
                    objPagarParcela.nossoNumero = drCon["nossonumero"].ToString();
                    objPagarParcela.codigoBarras = drCon["codigobarras"].ToString();
                    objPagarParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarParcela.autorizador_idUsuario = EmcResources.cInt(drCon["autorizador_idusuario"].ToString());
                    objPagarParcela.autorizador2_idUsuario = EmcResources.cInt(drCon["autorizador2_idusuario"].ToString());
                    objPagarParcela.autorizado = drCon["autorizado"].ToString();
                    objPagarParcela.idpagarfatura = EmcResources.cInt(drCon["pagarfatura_idpagarfatura"].ToString());
                    objPagarParcela.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarParcela.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarParcela.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarParcela.valorCMPago = EmcResources.cCur(drCon["valorcmpago"].ToString());

                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objPagarParcela.tipoCobranca = oTpCobr;
    
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarDocumentoDAO oPagarDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.pagarDocumento = oPagarDocDAO.ObterDocParcela(objPagarParcela.pagarDocumento);

                    TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.tipoCobranca = oTpCobrDAO.ObterPor(objPagarParcela.tipoCobranca);

                    //busca as baixas da parcela
                    PagarBaixaDAO oBaixaDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.baixas = oBaixaDAO.listaBaixasParcela(objPagarParcela.idPagarParcela);
                }
                return objPagarParcela;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
          
        }
        /// <summary>
        /// Busca uma parcela especifica retornando um objeto tipo PagarParcela
        /// </summary>
        /// <param name="oPagarParcela"></param>
        /// <returns></returns>
        public PagarParcela ObterPor(int idDivida)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarParcelas Where iddivida = @iddivida ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@iddivida", idDivida);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                PagarDocumento oPagarDoc = new PagarDocumento();

                PagarParcela objPagarParcela = new PagarParcela();

                while (drCon.Read())
                {
                    consulta = true;
                    objPagarParcela.idPagarParcela = EmcResources.cInt(drCon["idPagarParcelas"].ToString());
                    objPagarParcela.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());


                    oPagarDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    objPagarParcela.pagarDocumento = oPagarDoc;

                    objPagarParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objPagarParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objPagarParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objPagarParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objPagarParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objPagarParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objPagarParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objPagarParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objPagarParcela.situacao = drCon["situacao"].ToString();
                    objPagarParcela.nossoNumero = drCon["nossonumero"].ToString();
                    objPagarParcela.codigoBarras = drCon["codigobarras"].ToString();
                    objPagarParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarParcela.autorizador_idUsuario = EmcResources.cInt(drCon["autorizador_idusuario"].ToString());
                    objPagarParcela.autorizador2_idUsuario = EmcResources.cInt(drCon["autorizador2_idusuario"].ToString());
                    objPagarParcela.autorizado = drCon["autorizado"].ToString();
                    objPagarParcela.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarParcela.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarParcela.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    objPagarParcela.valorCorrecaoMonetaria = EmcResources.cCur(drCon["valorcorrecaomonetaria"].ToString());
                    objPagarParcela.valorCMPago = EmcResources.cCur(drCon["valorcmpago"].ToString());

                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objPagarParcela.tipoCobranca = oTpCobr;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarDocumentoDAO oPagarDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.pagarDocumento = oPagarDocDAO.ObterDocParcela(objPagarParcela.pagarDocumento);

                    TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.tipoCobranca = oTpCobrDAO.ObterPor(objPagarParcela.tipoCobranca);

                    //busca as baixas da parcela
                    PagarBaixaDAO oBaixaDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarParcela.baixas = oBaixaDAO.listaBaixasParcela(objPagarParcela.idPagarParcela);
                }
                return objPagarParcela;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        /// <summary>
        /// Gera uma ocorrencia de alteração, inclusão ou atualização para PagarParcela
        /// </summary>
        /// <param name="oPagarParcela"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private void geraOcorrencia(PagarParcela oPagarParcela, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oPagarParcela.pagarDocumento.idPagarDocumento.ToString();

                if (flag == "A")
                {

                    PagarParcela oPgParcela = new PagarParcela();
                    oPgParcela = ObterPor(oPagarParcela);

                    if (!oPgParcela.Equals(oPagarParcela))
                    {
                        descricao = "Parcela id: " + oPagarParcela.idPagarParcela + " Nro documento :" + oPagarParcela.pagarDocumento.idPagarDocumento + " Nro Parcela : " + oPagarParcela.nroParcela + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oPgParcela.dataVencimento.Equals(oPagarParcela.dataVencimento))
                        {
                            descricao += " Data Vencimento de " + oPgParcela.dataVencimento + " para " + oPagarParcela.dataVencimento;
                        }
                        if (!oPgParcela.dataQuitacao.Equals(oPagarParcela.dataQuitacao))
                        {
                            descricao += " Data Quitação de " + oPgParcela.dataQuitacao + " para " + oPagarParcela.dataQuitacao;
                        }
                        if (!oPgParcela.valorParcela.Equals(oPagarParcela.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oPgParcela.valorParcela + " para " + oPagarParcela.valorParcela;
                        }
                        if (!oPgParcela.saldoPagar.Equals(oPagarParcela.saldoPagar))
                        {
                            descricao += " Saldo Pagar de " + oPgParcela.saldoPagar + " para " + oPagarParcela.saldoPagar;
                        }
                        if (!oPgParcela.saldoPago.Equals(oPagarParcela.saldoPago))
                        {
                            descricao += " Saldo Pago de " + oPgParcela.saldoPago + " para " + oPagarParcela.saldoPago;
                        }
                        if (!oPgParcela.situacao.Equals(oPagarParcela.situacao))
                        {
                            descricao += " Situação de " + oPgParcela.situacao + " para " + oPagarParcela.situacao;
                        }
                        if (!oPgParcela.nossoNumero.Equals(oPagarParcela.nossoNumero))
                        {
                            descricao += " Nosso Numero de " + oPgParcela.nossoNumero + " para " + oPagarParcela.nossoNumero;
                        }
                        if (!oPgParcela.codigoBarras.Equals(oPagarParcela.codigoBarras))
                        {
                            descricao += " Codigo de Barras de " + oPgParcela.codigoBarras + " para " + oPagarParcela.codigoBarras;
                        }
                        if (!oPgParcela.valorJuros.Equals(oPagarParcela.valorJuros))
                        {
                            descricao += " Juros de " + oPgParcela.valorJuros + " para " + oPagarParcela.valorJuros;
                        }
                        if (!oPgParcela.valorDesconto.Equals(oPagarParcela.valorDesconto))
                        {
                            descricao += " Valor Desconto de " + oPgParcela.valorDesconto + " para " + oPagarParcela.valorDesconto;
                        }
                        if (!oPgParcela.tipoCobranca.Equals(oPagarParcela.tipoCobranca))
                        {
                            descricao += " Tipo de Cobrança  de " + oPgParcela.tipoCobranca.idTipoCobranca + "-" + oPgParcela.tipoCobranca.descricao + 
                                         " para " + oPagarParcela.tipoCobranca.idTipoCobranca+"-"+oPagarParcela.tipoCobranca.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Parcela Pagar id : " + oPagarParcela.idPagarParcela +
                                " - CodEmpresa - " + oPagarParcela.codEmpresa +
                                " - Documento - " + oPagarParcela.pagarDocumento.idPagarDocumento +
                                " - Nro Parcela - " + oPagarParcela.nroParcela +
                                " - Data Vencimento - " + oPagarParcela.dataVencimento +
                                " - Data Quitação - " + oPagarParcela.dataQuitacao +
                                " - Valor Parcela - " + oPagarParcela.valorParcela +
                                " - Valor Desconto - " + oPagarParcela.valorDesconto +
                                " - Valor Juros - " + oPagarParcela.valorJuros +
                                " - Saldo Pagar - " + oPagarParcela.saldoPagar +
                                " - Saldo Pago - " + oPagarParcela.saldoPago +
                                " - Situação - " + oPagarParcela.situacao +
                                " - Nosso Numero - " + oPagarParcela.nossoNumero +
                                " - Codigo de Barras - " + oPagarParcela.codigoBarras +
                                " - Tipo cobrança  - " + oPagarParcela.tipoCobranca.idTipoCobranca + "-" + oPagarParcela.tipoCobranca.descricao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Parcela Pagar id : " + oPagarParcela.idPagarParcela +
                                " - CodEmpresa - " + oPagarParcela.codEmpresa +
                                " - Documento - " + oPagarParcela.pagarDocumento.idPagarDocumento +
                                " - Nro Parcela - " + oPagarParcela.nroParcela +
                                " - Data Vencimento - " + oPagarParcela.dataVencimento +
                                " - Data Quitação - " + oPagarParcela.dataQuitacao +
                                " - Valor Parcela - " + oPagarParcela.valorParcela +
                                " - Valor Desconto - " + oPagarParcela.valorDesconto +
                                " - Valor Juros - " + oPagarParcela.valorJuros +
                                " - Saldo Pagar - " + oPagarParcela.saldoPagar +
                                " - Saldo Pago - " + oPagarParcela.saldoPago +
                                " - Situação - " + oPagarParcela.situacao +
                                " - Nosso Numero - " + oPagarParcela.nossoNumero +
                                " - Codigo de Barras - " + oPagarParcela.codigoBarras +
                                " - Tipo cobrança  - " + oPagarParcela.tipoCobranca.idTipoCobranca + "-" + oPagarParcela.tipoCobranca.descricao +
                                " - Usuario Inclusão - " + oPagarParcela.cadastro_idusuario + " - " + oPagarParcela.cadastro_datahora +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "LIB")
                {
                    descricao = " Autorização de Pagamento - Parcela Pagar id : " + oPagarParcela.idPagarParcela +
                                " - CodEmpresa - " + oPagarParcela.codEmpresa +
                                " - Documento - " + oPagarParcela.pagarDocumento.idPagarDocumento +
                                " - Nro Parcela - " + oPagarParcela.nroParcela +
                                " - Autorizador 1 - " + oPagarParcela.autorizador_idUsuario +
                                " - Autorizador 2 - " + oPagarParcela.autorizador2_idUsuario +
                                " - Autorizado - " + oPagarParcela.autorizado;
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
        /// <summary>
        /// Calcula Saldo Devedor para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSaldoDevedor(int codFornecedor)
        {
            decimal saldo=0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from pagarparcelas pc, pagardocumento d " + 
                                " where pc.codempresa=@codempresa " + 
                                "   and d.idpagardocumento = pc.idpagardocumento and d.idfornecedor = @idfornecedor";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", codFornecedor);

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
        /// <summary>
        /// Calcula Saldo Devedor em atraso para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSaldoAtraso(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where pc.codempresa=@codempresa "+
                                "   and d.idpagardocumento = pc.idpagardocumento and d.idfornecedor = @idfornecedor" + 
                                "   and pc.datavencimento < @datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", codFornecedor);
                Sqlcon.Parameters.AddWithValue("@datavencimento", DateTime.Now);

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
        /// <summary>
        /// Calcula Saldo Vencendo em 30 dias para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaVencimento30Dias(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where pc.codempresa=@codempresa " + 
                                "   and d.idpagardocumento = pc.idpagardocumento and d.idfornecedor = @idfornecedor" +
                                "   and pc.datavencimento >= @inicioperiodo and pc.datavencimento <= @finalperiodo ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", codFornecedor);
                Sqlcon.Parameters.AddWithValue("@inicioperiodo", DateTime.Now);
                Sqlcon.Parameters.AddWithValue("@finalperiodo", DateTime.Now.AddDays(30));

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
        /// <summary>
        /// Calcula Saldo Devedor em atraso para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSdoVencimentoUp30Dias(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where pc.codempresa=@codempresa " + 
                                "   and d.idpagardocumento = pc.idpagardocumento and d.idfornecedor = @idfornecedor" +
                                "   and pc.datavencimento > @datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", codFornecedor);
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
        
        /// <summary>
        /// Calcula Saldo Documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocParcela(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valorparcela) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where d.idpagardocumento = pc.idpagardocumento and pc.idpagardocumento = @idpagardocumento"; 
                                

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);
                

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
        /// <summary>
        /// Calcula Descontos Documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocDesconto(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valordesconto) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where d.idpagardocumento = pc.idpagardocumento and pc.idpagardocumento = @idpagardocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);


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
        /// <summary>
        /// Calcula Juros Documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocJuros(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valorjuros) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where d.idpagardocumento = pc.idpagardocumento and pc.idpagardocumento = @idpagardocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);


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
        /// <summary>
        /// Calcula CM Documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocCM(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valorcmpago) as saldocm from pagarparcelas pc, pagardocumento d " +
                                " where d.idpagardocumento = pc.idpagardocumento and pc.idpagardocumento = @idpagardocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldocm"].ToString());
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
        /// <summary>
        /// Calcula Saldo Pago Documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocSdoPago(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopago) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where d.idpagardocumento = pc.idpagardocumento and pc.idpagardocumento = @idpagardocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);


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
        /// <summary>
        /// Calcula Descontos Documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocSdoPagar(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from pagarparcelas pc, pagardocumento d " +
                                " where d.idpagardocumento = pc.idpagardocumento and pc.idpagardocumento = @idpagardocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);


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

        public DataTable dstRelatorio(String sSQL)
        {

            try
            {               
                string strSQL = sSQL.ToString();
                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
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
    }
}
