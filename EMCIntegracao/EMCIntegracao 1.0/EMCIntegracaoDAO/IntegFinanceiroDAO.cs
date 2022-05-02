using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCFinanceiroModel;
using EMCFinanceiroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCIntegracaoModel;
using EMCImobModel;
using EMCImobDAO;

namespace EMCIntegracaoDAO
{
    public class IntegFinanceiroDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IntegFinanceiroDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
            }
            codEmpresa = idEmpresa;

        }

        public void Salvar(IntegFinanceiro oInteg, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                if (oInteg.statusOperacao == "I")
                {
                    /*
                     * Operação de inclusão de um documento pelo sistema origem
                     */
                                       
                    //Monta comando para a gravação do registro
                    String strSQL = "insert into IntegFinanceiro (idintegfinanceiro, imob_idlocacaopagar, imob_idlocacaoreceber, "+
                                                                 "imob_idbaixacaptacao, imob_iddespesaimovel, " +
                                                                 "imob_idiptu, idreceberparcela, idpagarparcelas, tipointegracao, " + 
                                                                 "sistemaorigem, statusgeracao, statusbaixa, nivelintegracao, " +
                                                                 "idusuarioorigem, dataorigem, idusuariofinanceiro, datafinanceiro, " + 
                                                                 "idpagardocumento, idreceberdocumento, idempresa )" +
                                                        "values (@idintegfinanceiro, @imob_idlocacaopagar, @imob_idlocacaoreceber, " +
                                                                "@imob_idbaixacaptacao, @imob_iddespesaimovel, " +
                                                                "@imob_idiptu, @idreceberparcela, @idpagarparcela, @tipointegracao, " +
                                                                "@sistemaorigem, @statusgeracao, @statusbaixa, @nivelintegracao, " +
                                                                "@idusuarioorigem, @dataorigem, @idusuariofinanceiro, @datafinanceiro, " +
                                                                "@idpagardocumento, @idreceberdocumento, @idempresa) ";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idreceberparcela", null );
                    SqlconPar.Parameters.AddWithValue("@idpagarparcela", null );
                    SqlconPar.Parameters.AddWithValue("@tipointegracao", oInteg.tipoIntegracao);
                    SqlconPar.Parameters.AddWithValue("@sistemaorigem", oInteg.sistemaOrigem);
                    SqlconPar.Parameters.AddWithValue("@statusgeracao", "G");
                    SqlconPar.Parameters.AddWithValue("@statusbaixa", oInteg.statusBaixa);
                    SqlconPar.Parameters.AddWithValue("@nivelintegracao", oInteg.nivelIntegracao );
                    SqlconPar.Parameters.AddWithValue("@idusuarioorigem", oInteg.idUsuarioOrigem);
                    SqlconPar.Parameters.AddWithValue("@dataorigem", oInteg.dataOrigem);
                    SqlconPar.Parameters.AddWithValue("@idusuariofinanceiro", null);
                    SqlconPar.Parameters.AddWithValue("@datafinanceiro", null);
                    SqlconPar.Parameters.AddWithValue("@idpagardocumento", null);
                    SqlconPar.Parameters.AddWithValue("@idreceberdocumento", null );
                    SqlconPar.Parameters.AddWithValue("@idempresa", oInteg.idEmpresa);

                    if (oInteg.sistemaOrigem.ToUpper() == "EMCIMOB")
                    {
                        if (oInteg.imob_LocacaoPagar != null)
                            SqlconPar.Parameters.AddWithValue("@imob_idlocacaopagar", oInteg.imob_LocacaoPagar.idLocacaoPagar);
                        else
                            SqlconPar.Parameters.AddWithValue("@imob_idlocacaopagar", null);

                        if (oInteg.imob_LocacaoReceber != null)
                            SqlconPar.Parameters.AddWithValue("@imob_idlocacaoreceber", oInteg.imob_LocacaoReceber.idLocacaoReceber);
                        else
                            SqlconPar.Parameters.AddWithValue("@imob_idlocacaoreceber", null);

                        if (oInteg.imob_BaixaCaptacao != null)
                            SqlconPar.Parameters.AddWithValue("@imob_idbaixacaptacao", oInteg.imob_BaixaCaptacao.idBaixaCaptacao);
                        else
                            SqlconPar.Parameters.AddWithValue("@imob_idbaixacaptacao", null);

                        if (oInteg.imob_DespesaImovel != null)
                            SqlconPar.Parameters.AddWithValue("@imob_iddespesaimovel", oInteg.imob_DespesaImovel.idDespesaImovel );
                        else
                            SqlconPar.Parameters.AddWithValue("@imob_iddespesaimovel", null);

                        if (oInteg.imob_Iptu != null)
                            SqlconPar.Parameters.AddWithValue("@imob_idiptu", oInteg.imob_Iptu.idIptu );
                        else
                            SqlconPar.Parameters.AddWithValue("@imob_idiptu", null);
                    }
                    else
                    {
                        SqlconPar.Parameters.AddWithValue("@imob_idlocacaopagar", null);
                        SqlconPar.Parameters.AddWithValue("@imob_idlocacaoreceber", null);
                        SqlconPar.Parameters.AddWithValue("@imob_idbaixacaptacao", null );
                        SqlconPar.Parameters.AddWithValue("@imob_iddespesaimovel", null );
                        SqlconPar.Parameters.AddWithValue("@imob_idiptu", null );
                    }


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (oInteg.statusOperacao == "P")
                {
                    /*
                     * Operação de processamento do documento pelo financeiro
                     */

                    //Monta comando para a gravação do registro
                    String strSQL = "update IntegFinanceiro set statusgeracao=@statusgeracao, idusuariofinanceiro=@idusuariofinanceiro, " +
                                                              " datafinanceiro=@datafinanceiro,  " +
                                                              " idpagardocumento=@idpagardocumento, idreceberdocumento=@idreceberdocumento, " +
                                                              " idreceberparcela=@idreceberparcela, idpagarparcelas=@idpagarparcela " +
                                            " Where idintegfinanceiro = @idintegfinanceiro";
                                            
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@statusgeracao", "P");
                    SqlconPar.Parameters.AddWithValue("@idusuariofinanceiro", oInteg.idUsuarioFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@datafinanceiro", oInteg.dataFinanceiro);

                    if (oInteg.tipoIntegracao == "P")
                    {
                        SqlconPar.Parameters.AddWithValue("@idpagardocumento", oInteg.idPagarDocumento.idPagarDocumento);
                        SqlconPar.Parameters.AddWithValue("@idreceberdocumento", null);

                        if (oInteg.nivelIntegracao == "P")
                        {
                            SqlconPar.Parameters.AddWithValue("@idreceberparcela", null);
                            SqlconPar.Parameters.AddWithValue("@idpagarparcela", oInteg.idPagarParcela.idPagarParcela);
                        } 
                    }
                    else
                    {
                        SqlconPar.Parameters.AddWithValue("@idpagardocumento", null);
                        SqlconPar.Parameters.AddWithValue("@idreceberdocumento", oInteg.idReceberDocumento.idReceberDocumento);

                        if (oInteg.nivelIntegracao == "P")
                        {
                            SqlconPar.Parameters.AddWithValue("@idreceberparcela", oInteg.idReceberParcela.idReceberParcela);
                            SqlconPar.Parameters.AddWithValue("@idpagarparcela", null);
                        }
                    }
                    
                    if (oInteg.nivelIntegracao == "D")
                    {
                        SqlconPar.Parameters.AddWithValue("@idreceberparcela", null);
                        SqlconPar.Parameters.AddWithValue("@idpagarparcela", null);
                    }
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    if (oInteg.nivelIntegracao == "D")
                    {

                    }
                    else
                    {
                        if (oInteg.sistemaOrigem == "EMCIMOB")
                        {
                            /* retorna atualização da situacao para o documento de origem */
                            if (oInteg.imob_LocacaoReceber.idLocacaoReceber > 0)
                            {
                                LocacaoReceberDAO oLocReceber = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                                oLocReceber.Integracao(oInteg.imob_LocacaoReceber, Conexao, transacao, "P", DateTime.Now);
                            }
                            else if (oInteg.imob_LocacaoPagar.idLocacaoPagar > 0)
                            {
                                LocacaoPagarDAO oLocPagar = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                                oLocPagar.Integracao(oInteg.imob_LocacaoPagar, Conexao, transacao, "P", DateTime.Now);
                            }
                            else if (oInteg.imob_BaixaCaptacao != null)
                            {

                            }
                            else if (oInteg.imob_DespesaImovel != null)
                            {

                            }
                            else if (oInteg.imob_Iptu != null)
                            {

                            }
                        }

                    }
                }
                else if (oInteg.statusOperacao == "E")
                {
                    /*
                     * Estorno do processamento do documento no sistema financeiro
                     */

                    //Monta comando para a gravação do registro
                    String strSQL = "update IntegFinanceiro set statusgeracao='G', idusuariofinanceiro=null, datafinanceiro=null, " +
                                                              " idreceberparcela=null, idpagarparcelas=null, idpagardocumento=null, " +
                                                              " idreceberdocumento=null " +
                                            " Where idintegfinanceiro = @idintegfinanceiro";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    
                    SqlconPar.ExecuteNonQuery();

                    if (oInteg.nivelIntegracao == "D")
                    {

                    }
                    else
                    {
                        if (oInteg.sistemaOrigem == "EMCIMOB")
                        {
                            /* retorna atualização da situacao para o documento de origem */
                            if (oInteg.imob_LocacaoReceber.idLocacaoReceber > 0)
                            {
                                LocacaoReceberDAO oLocReceber = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                                oLocReceber.Integracao(oInteg.imob_LocacaoReceber, Conexao, transacao, "E", DateTime.Now);
                            }
                            else if (oInteg.imob_LocacaoPagar.idLocacaoPagar > 0)
                            {
                                LocacaoPagarDAO oLocPagar = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                                oLocPagar.Integracao(oInteg.imob_LocacaoPagar, Conexao, transacao, "E", DateTime.Now);
                            }
                            else if (oInteg.imob_BaixaCaptacao != null)
                            {

                            }
                            else if (oInteg.imob_DespesaImovel != null)
                            {

                            }
                            else if (oInteg.imob_Iptu != null)
                            {

                            }
                        }

                    }

                }
                else if (oInteg.statusOperacao == "C")
                {
                    /*
                     * Cancelamento da integração pelo sistema de origem
                     */

                    //Monta comando para a gravação do registro
                    if (oInteg.sistemaOrigem.ToUpper() == "EMCIMOB")
                    {
                        if (oInteg.imob_LocacaoPagar != null)
                        {
                            String strSQL = "delete from IntegFinanceiro Where imob_idlocacaopagar=@idlocacaopagar";

                            MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                            SqlconPar.Parameters.AddWithValue("@idlocacaopagar", oInteg.imob_LocacaoPagar.idLocacaoPagar);

                            SqlconPar.ExecuteNonQuery();
                        }

                        if (oInteg.imob_LocacaoReceber != null)
                        {
                            String strSQL = "delete from IntegFinanceiro Where imob_idlocacaoreceber=@idlocacaoreceber";

                            MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                            SqlconPar.Parameters.AddWithValue("@idlocacaoreceber", oInteg.imob_LocacaoReceber.idLocacaoReceber);

                            SqlconPar.ExecuteNonQuery();
                        }

                        if (oInteg.imob_BaixaCaptacao != null)
                        {

                        }

                        if (oInteg.imob_DespesaImovel != null)
                        {

                        }
                        if (oInteg.imob_Iptu != null)
                        {

                        }
                     
                    }


                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public IntegFinanceiro ObterPor(int idIntegracao)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where idintegfinanceiro = @idintegfinanceiro";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idintegfinanceiro", idIntegracao);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                    oInteg.tipoIntegracao = drCon["tipointegracao"].ToString();
                    oInteg.sistemaOrigem = drCon["sistemaorigem"].ToString();
                    oInteg.statusGeracao = drCon["statusgeracao"].ToString();
                    oInteg.statusBaixa = drCon["statusbaixa"].ToString();
                    oInteg.statusOperacao = "";
                    oInteg.nivelIntegracao = drCon["nivelintegracao"].ToString();
                    oInteg.idUsuarioOrigem = EmcResources.cInt(drCon["idusuarioorigem"].ToString());
                    oInteg.idUsuarioFinanceiro = EmcResources.cInt(drCon["idusuariofinanceiro"].ToString());
                    oInteg.dataOrigem = Convert.ToDateTime(drCon["dataorigem"].ToString());
                    oInteg.dataFinanceiro = EmcResources.cDate(drCon["datafinanceiro"].ToString());
                    oInteg.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                    
                    //atributos financeiro
                    PagarDocumento oPgDoc = new PagarDocumento();
                    oPgDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    oInteg.idPagarDocumento = oPgDoc;

                    ReceberDocumento oRcDoc = new ReceberDocumento();
                    oRcDoc.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
                    oInteg.idReceberDocumento = oRcDoc;

                    PagarParcela oPgParc = new PagarParcela();
                    oPgParc.idPagarParcela = EmcResources.cInt(drCon["idpagarparcelas"].ToString());
                    oInteg.idPagarParcela = oPgParc;

                    ReceberParcela oRcParc = new ReceberParcela();
                    oRcParc.idReceberParcela = EmcResources.cInt(drCon["idreceberparcela"].ToString());
                    oInteg.idReceberParcela = oRcParc;

                    //atributos EMCImob
                    LocacaoPagar oLocPagar = new LocacaoPagar();
                    oLocPagar.idLocacaoPagar = EmcResources.cInt(drCon["imob_idlocacaopagar"].ToString());
                    oInteg.imob_LocacaoPagar = oLocPagar;

                    LocacaoReceber oLocReceber = new LocacaoReceber();
                    oLocReceber.idLocacaoReceber = EmcResources.cInt(drCon["imob_idlocacaoreceber"].ToString());
                    oInteg.imob_LocacaoReceber = oLocReceber;

                    BaixaCaptacao oBxCaptacao = new BaixaCaptacao();
                    oBxCaptacao.idBaixaCaptacao = EmcResources.cInt(drCon["imob_idbaixacaptacao"].ToString());
                    oInteg.imob_BaixaCaptacao = oBxCaptacao;

                    DespesaImovel oDespImovel = new DespesaImovel();
                    oDespImovel.idDespesaImovel = EmcResources.cInt(drCon["imob_iddespesaimovel"].ToString());
                    oInteg.imob_DespesaImovel = oDespImovel;

                    Iptu oIptu = new Iptu();
                    oIptu.idIptu = EmcResources.cInt(drCon["imob_idiptu"].ToString());
                    oInteg.imob_Iptu = oIptu;

                    
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {

                    if (oInteg.idPagarDocumento.idPagarDocumento > 0)
                    {
                        PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.idPagarDocumento = oPgDocDAO.ObterPor(oInteg.idPagarDocumento);
                    }

                    if (oInteg.idReceberDocumento.idReceberDocumento > 0)
                    {
                        ReceberDocumentoDAO oRcDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.idReceberDocumento = oRcDocDAO.ObterPor(oInteg.idReceberDocumento);
                    }

                    if (oInteg.idPagarParcela.idPagarParcela > 0)
                    {
                        PagarParcelaDAO oPgParcDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.idPagarParcela = oPgParcDAO.ObterPor(oInteg.idPagarParcela);
                    }

                    if (oInteg.idReceberParcela.idReceberParcela > 0)
                    {
                        ReceberParcelaDAO oRcParcDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.idReceberParcela = oRcParcDAO.ObterPor(oInteg.idReceberParcela);
                    }

                    if (oInteg.imob_LocacaoPagar.idLocacaoPagar > 0)
                    {
                        LocacaoPagarDAO oLocPagarDAO = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.imob_LocacaoPagar = oLocPagarDAO.ObterPor(oInteg.imob_LocacaoPagar);
                    }

                    if (oInteg.imob_LocacaoReceber.idLocacaoReceber > 0)
                    {
                        LocacaoReceberDAO oLocReceberDAO = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.imob_LocacaoReceber = oLocReceberDAO.ObterPor(oInteg.imob_LocacaoReceber);
                    }

                    if (oInteg.imob_BaixaCaptacao.idBaixaCaptacao > 0)
                    {
                        BaixaCaptacaoDAO oCapDAO = new BaixaCaptacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.imob_BaixaCaptacao = oCapDAO.ObterPor(oInteg.imob_BaixaCaptacao);
                    }

                    if (oInteg.imob_DespesaImovel.idDespesaImovel > 0)
                    {
                        DespesaImovelDAO oDspDAO = new DespesaImovelDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.imob_DespesaImovel = oDspDAO.ObterPor(oInteg.imob_DespesaImovel);
                    }

                    if (oInteg.imob_Iptu.idIptu > 0)
                    {
                        IptuDAO oIptuDAO = new IptuDAO(parConexao, oOcorrencia, codEmpresa);
                        oInteg.imob_Iptu = oIptuDAO.ObterPor(oInteg.imob_Iptu);
                    }


                    IntegBaixaPagarDAO oIntegPagar = new IntegBaixaPagarDAO(parConexao, oOcorrencia, codEmpresa);
                    oInteg.lstBaixaPagar = oIntegPagar.lstIntegBaixaPagar(oInteg.idIntegFinanceiro);

                    IntegBaixaReceberDAO oIntegReceber = new IntegBaixaReceberDAO(parConexao, oOcorrencia, codEmpresa);
                    oInteg.lstBaixaReceber = oIntegReceber.lstIntegBaixaReceber(oInteg.idIntegFinanceiro);
                    
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public IntegFinanceiro ObterPorLocacaoReceber(int oReceber)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where imob_idlocacaoreceber = @id";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oReceber);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    oInteg = ObterPor(oInteg.idIntegFinanceiro);
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public IntegFinanceiro ObterPorLocacaoPagar(int oPagar)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where imob_idlocacaopagar = @id";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oPagar);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    oInteg = ObterPor(oInteg.idIntegFinanceiro);
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public IntegFinanceiro ObterPorReceberParcela(int oReceber)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where idreceberparcela = @id";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oReceber);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    oInteg = ObterPor(oInteg.idIntegFinanceiro);
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public IntegFinanceiro ObterPorReceberDocumento(int oReceber)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where idreceberdocumento = @id";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oReceber);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    oInteg = ObterPor(oInteg.idIntegFinanceiro);
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public IntegFinanceiro ObterPorPagarParcela(int oPagar)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where idpagarparcelas = @id";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oPagar);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    oInteg = ObterPor(oInteg.idIntegFinanceiro);
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public IntegFinanceiro ObterPorPagarDocumento(int oPagar)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IntegFinanceiro " +
                                " Where idpagardocumento = @id";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oPagar);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegFinanceiro oInteg = new IntegFinanceiro();

                while (drCon.Read())
                {
                    consulta = true;
                    //atributos gerais
                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    oInteg = ObterPor(oInteg.idIntegFinanceiro);
                }
                return oInteg;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public List<IntegFinanceiro> lstGeracaoIntegracao(String origem = "TODOS")
        {
            List<IntegFinanceiro> lstIntegracao = new List<IntegFinanceiro>();
            List<IntegFinanceiro> lstRetorno = new List<IntegFinanceiro>();
            Boolean consulta = false;
            try
            {
                //Monta comando para a gravação do registro

                String strSQL = "select * from integfinanceiro i where i.idempresa=@codempresa and i.statusgeracao='G' "; 

                if (origem != "TODOS")
                {
                    strSQL = strSQL + " and i.sistemaorigem=@origem ";
                }
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@origem", origem);
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    consulta = true;
                    IntegFinanceiro oInteg = new IntegFinanceiro();

                    oInteg.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());

                    lstIntegracao.Add(oInteg);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (IntegFinanceiro oIntegra in lstIntegracao)
                    {
                        lstRetorno.Add(ObterPor(oIntegra.idIntegFinanceiro));
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }
    }
}
