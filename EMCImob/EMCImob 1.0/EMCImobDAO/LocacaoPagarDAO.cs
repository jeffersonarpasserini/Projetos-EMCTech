using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCCadastroDAO;
using EMCCadastroModel;
using EMCIntegracaoModel;
using EMCIntegracaoDAO;

namespace EMCImobDAO
{
    public class LocacaoPagarDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoPagarDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoPagar> lstLocacaoPagar(DateTime? dataInicial, DateTime? dataFinal, string idContrato, int nroParcela, int idImovel, int empMaster, int idLocador)
        {
            bool consulta = false;

            try
            {

                //Monta comando para a gravação do registro

                String strSQL = "select r.idLocacaopagar, r.idLocacaoContrato, c.IdentificacaoContrato, " +
                                       "r.datavencimento, r.PeriodoInicio, r.PeriodoFim, " +
                                       "r.idlocador, r.CodEmpresa, r.valorparcela, r.situacao, c.idimovel, i.codigoImovel " +
                               "from locacaopagar r left join locacaocontrato c on c.idLocacaoContrato = r.idLocacaoContrato, " +
                                    "locacaocontrato c1 left join imovel i on i.idimovel = c1.idimovel " +
                               "Where c.idempresa=@codempresa and r.situacao = 'A' ";

                if (dataInicial is DateTime && dataFinal is DateTime)
                {
                    strSQL = strSQL + " and r.datavencimento between @datainicial and @datafinal ";
                }

                if (!String.IsNullOrEmpty(idContrato))
                {
                    strSQL = strSQL + " and c.identificacaocontrato = @idcontrato ";
                }

                if (nroParcela > 0)
                {
                    strSQL = strSQL + " and r.nroparcela = @nroparcela ";
                }

                if (idImovel > 0)
                {
                    strSQL = strSQL + " and c.idimovel=@idimovel ";
                }

                if (idLocador > 0)
                {
                    strSQL = strSQL + " and r.fornecedor_codempresa=@empmaster and r.idfornecedor = @idlocador";
                }
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);
                Sqlcon.Parameters.AddWithValue("@nroparcela", nroParcela);
                Sqlcon.Parameters.AddWithValue("@idimovel", idImovel);
                Sqlcon.Parameters.AddWithValue("@empmaster", empMaster);
                Sqlcon.Parameters.AddWithValue("@idlocador", idLocador);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoPagar> lstLocacaoPagar = new List<LocacaoPagar>();
                List<LocacaoPagar> lstRetorno = new List<LocacaoPagar>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoPagar oPagar = new LocacaoPagar();

                    oPagar.idLocacaoPagar = EmcResources.cInt(drCon["idlocacaopagar"].ToString());

                    lstLocacaoPagar.Add(oPagar);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoPagar oCC in lstLocacaoPagar)
                    {
                        LocacaoPagar oCCP = new LocacaoPagar();
                        oCCP = ObterPor(oCC);

                        lstRetorno.Add(oCCP);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public List<LocacaoPagar> lstLocacaoPagar(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                
                String strSQL = "select * from LocacaoPagar Where idlocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoPagar> lstLocacaoPagar = new List<LocacaoPagar>();
                List<LocacaoPagar> lstRetorno = new List<LocacaoPagar>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoPagar oPagar = new LocacaoPagar();

                    oPagar.idLocacaoPagar = EmcResources.cInt(drCon["idLocacaoPagar"].ToString());

                    lstLocacaoPagar.Add(oPagar);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoPagar oCC in lstLocacaoPagar)
                    {
                        LocacaoPagar oRec = new LocacaoPagar();
                        oRec = ObterPor(oCC);

                        lstRetorno.Add(oRec);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public List<LocacaoPagar> listaParcelaVencida(int idUsuario, int codempresa, int idLocador, DateTime? dataInicial)
        {

            try
            {
                //Monta comando para a gravação do registro
                int colocaWhere = 0;
                String strSQL = "select lp.*, f.nome as pessoa " +
                                " from locacaopagar lp  " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lp.idlocacaocontrato " +
                                " left join v_fornecedor f on f.codempresa = lp.codempresa and f.idpessoa = lp.idlocador";


                
                if (idLocador > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " idlocador = @idlocador ";
                }

               
                if (dataInicial != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datavencimento < @datainicial ";
                }

                strSQL += " and situacao = 'A'";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idlocador", idLocador);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoPagar> lstParcela = new List<LocacaoPagar>();
                List<LocacaoPagar> lstRetorno = new List<LocacaoPagar>();

                while (drCon.Read())
                {

                    LocacaoPagar objLocacaoPagar = new LocacaoPagar();

                    objLocacaoPagar.idLocacaoPagar = EmcResources.cInt(drCon["idlocacaopagar"].ToString());
                    //objLocacaoPagar.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    lstParcela.Add(objLocacaoPagar);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                foreach (LocacaoPagar oLPag in lstParcela)
                {
                    lstRetorno.Add(ObterPor(oLPag));
                }


                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable dstListaLocador(DateTime? dataInicial)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "select lp.*, f.nome as nome_locador, lc.identificacaocontrato as identificacaocontrato " +
                                " from locacaopagar lp  " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lp.idlocacaocontrato " +
                                " left join v_fornecedor f on f.codempresa = lp.codempresa and f.idpessoa = lp.idlocador ";
                     
                if (dataInicial != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " datavencimento < @datainicio ";
                }

                strSQL += " and situacao = 'A' ";

                strSQL += " order by lp.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                //Sqlcon.Parameters.AddWithValue("@idlocacaopagar", idLocacaoPagar);
                //Sqlcon.Parameters.AddWithValue("@idlocador", idLocador);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
                //Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);

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
         
        public DataTable dstListaCCPagar(DateTime? dataInicial, string identificacaoContrato)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = " select lcc.*, f.nome as nome_locador, lc.identificacaocontrato as identificacaocontrato, p.descricao as descricao_prov, lp.datavencimento as datavencimento " +
                                " from locacaoccpagar lcc " +
                                " left join locacaopagar lp on lp.idlocacaopagar = lcc.idlocacaopagar " +
                                " left join locacaoproventos p on p.idlocacaoproventos = lcc.idlocacaoproventos " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lcc.idlocacaocontrato " +
                                " left join v_fornecedor f on f.codempresa = lp.codempresa and f.idpessoa = lp.idlocador ";

                if (dataInicial != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " lp.datavencimento < @datainicio ";
                }

                if (!String.IsNullOrEmpty(identificacaoContrato))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " lc.identificacaocontrato = @identificacaocontrato ";
                }


                strSQL += " and lcc.situacao = 'A' ";

                strSQL += " order by nroparcela ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
                Sqlcon.Parameters.AddWithValue("@identificacaocontrato", identificacaoContrato);


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
         
        public void Salvar(LocacaoPagar oPagar, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oPagar.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoPagar'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oPagar.idLocacaoPagar = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oPagar, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoPagar (idlocacaocontrato, nroparcela, codempresa, idlocador, " +  
                                                                "periodoinicio, periodofim, datavencimento, " + 
                                                                "valorjuros, valorjuroscalculado, valordesconto, valorparcela, " +
                                                                "percparticipacao, situacao, valorpago )" +
                                    "values (@idlocacaocontrato, @nroparcela, @codempresa, @idlocador, " +
                                            "@periodoinicio, @periodofim, @datavencimento, " + 
                                            "@valorjuros, @valorjuroscalculado, @valordesconto, @valorparcela, " + 
                                            "@percparticipacao, @situacao, @valorpago )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oPagar.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", oPagar.nroParcela);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oPagar.locador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oPagar.locador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@periodoinicio", oPagar.periodoInicio);
                    SqlconPar.Parameters.AddWithValue("@periodofim", oPagar.periodoFim);
                    SqlconPar.Parameters.AddWithValue("@datavencimento", oPagar.dataVencimento);
                    SqlconPar.Parameters.AddWithValue("@valorjuros", oPagar.valorJuros);
                    SqlconPar.Parameters.AddWithValue("@valorjuroscalculado", oPagar.valorJurosCalculado);
                    SqlconPar.Parameters.AddWithValue("@valordesconto", oPagar.valorDesconto);
                    SqlconPar.Parameters.AddWithValue("@valorparcela", oPagar.valorParcela);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oPagar.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oPagar.situacao);
                    SqlconPar.Parameters.AddWithValue("@valorpago", 0);
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    /* Realiza a gravação dos proventos da parcela */
                    foreach(LocacaoCCPagar oCCPagar in oPagar.lstCtaCorrente)
                    {
                        LocacaoCCPagarDAO oCCPagarDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        //atribui o id gerado na inclusão ao provento a ser gravado.
                        oCCPagar.idLocacaoPagar = oPagar.idLocacaoPagar;
                        oCCPagar.idLocacaoContrato = oPagar.idLocacaoContrato;
                        oCCPagarDAO.Salvar(oCCPagar,Conexao,transacao);
                    }

                }
                else if (oPagar.statusOperacao == "A")
                {
                    geraOcorrencia(oPagar, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoPagar set idlocacaocontrato=@idlocacaocontrato, nroparcela=@nroparcela, " +
                                                             " codempresa=@codempresa, idlocador=@idlocador, " +
                                                             " periodoinicio=@periodoinicio, periodofim=@periodofim, " +
                                                             " datavencimento=@datavencimento, " +
                                                             " valorjuros=@valorjuros, " +
                                                             " valorjuroscalculado=@valorjuroscalculado, valordesconto=@valordesconto, " +
                                                             " valorparcela=@valorparcela, percparticipacao=@percparticipacao, situacao=@situacao, " +
                                                             " valorpago=@valorpago " +
                                            " Where idLocacaoPagar = @idLocacaoPagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oPagar.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", oPagar.nroParcela);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oPagar.locador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oPagar.locador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@periodoinicio", oPagar.periodoInicio);
                    SqlconPar.Parameters.AddWithValue("@periodofim", oPagar.periodoFim);
                    SqlconPar.Parameters.AddWithValue("@datavencimento", oPagar.dataVencimento);
                    SqlconPar.Parameters.AddWithValue("@valorjuros", oPagar.valorJuros);
                    SqlconPar.Parameters.AddWithValue("@valorjuroscalculado", oPagar.valorJurosCalculado);
                    SqlconPar.Parameters.AddWithValue("@valordesconto", oPagar.valorDesconto);
                    SqlconPar.Parameters.AddWithValue("@valorparcela", oPagar.valorParcela);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oPagar.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oPagar.situacao);
                    SqlconPar.Parameters.AddWithValue("@valorpago", oPagar.valorPago);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCPagar oCCPagar in oPagar.lstCtaCorrente)
                    {
                        LocacaoCCPagarDAO oCCPagarDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCPagarDAO.Salvar(oCCPagar, Conexao, transacao);
                    }
                }
                else if (oPagar.statusOperacao == "C")
                {
                    geraOcorrencia(oPagar, "E");

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCPagar oCCReceber in oPagar.lstCtaCorrente)
                    {
                        LocacaoCCPagarDAO oCCreceberDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from LocacaoPagar where idLocacaoPagar = @idLocacaoPagar";

                    String strSQL = "update LocacaoPagar set situacao='C' where idLocacaoPagar = @idLocacaoPagar";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oPagar.statusOperacao == "R")
                {
                    geraOcorrencia(oPagar, "R");

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCPagar oCCReceber in oPagar.lstCtaCorrente)
                    {
                        LocacaoCCPagarDAO oCCreceberDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from LocacaoPagar where idLocacaoPagar = @idLocacaoPagar";

                    String strSQL = "update LocacaoPagar set situacao='A' where idLocacaoPagar = @idLocacaoPagar";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oPagar.statusOperacao == "G")
                {

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCPagar oCCPagar in oPagar.lstCtaCorrente)
                    {
                        oCCPagar.statusOperacao = "G";
                        LocacaoCCPagarDAO oCCpagarDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCpagarDAO.Salvar(oCCPagar, Conexao, transacao);
                    }

                    /* estorna a integração com o financeiro */

                    String strSQL = "update Locacaopagar set situacao='A', dataintegracao = null where idLocacaopagar = @idLocacaoPagar";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);

                    Sqlcon.ExecuteNonQuery();


                    /* deleta a integração com o financeiro */
                    IntegFinanceiro oInteg = new IntegFinanceiro();
                    IntegFinanceiroDAO oIntegDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);

                    //oInteg = oIntegDAO.ObterPorLocacaoReceber(oReceber.idLocacaoReceber);
                    oInteg.imob_LocacaoPagar = oPagar;
                    oInteg.statusOperacao = "C";
                    oInteg.sistemaOrigem = "EMCIMOB";

                    oIntegDAO.Salvar(oInteg, Conexao, transacao);

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Integracao(LocacaoPagar oPagar, MySqlConnection Conexao, MySqlTransaction transacao, string Operacao, DateTime integracao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (Operacao == "I")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update Locacaopagar set situacao=@situacao, dataintegracao=@data " +
                                            " Where idLocacaopagar = @idLocacaoPagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@situacao", "G");
                    SqlconPar.Parameters.AddWithValue("@data", integracao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (Operacao == "P")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update Locacaopagar set situacao=@situacao, dataintegracao=@data " +
                                            " Where idLocacaopagar = @idLocacaoPagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@situacao", "P");
                    SqlconPar.Parameters.AddWithValue("@data", integracao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (Operacao == "E")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update Locacaopagar set situacao=@situacao " +
                                            " Where idLocacaopagar = @idLocacaoPagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoPagar", oPagar.idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@situacao", "G");

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LocacaoPagar ObterPor(LocacaoPagar oCC)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoPagar Where idLocacaoPagar = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oCC.idLocacaoPagar);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoPagar oCCPagar = new LocacaoPagar();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oCCPagar.idLocacaoPagar = EmcResources.cInt(drCon["idLocacaoPagar"].ToString());
                    oCCPagar.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    LocacaoContrato oContrato = new LocacaoContrato();
                    oContrato.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());
                    oCCPagar.contrato = oContrato;

                    Fornecedor oLocador = new Fornecedor();
                    oLocador.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    oLocador.idPessoa = EmcResources.cInt(drCon["idlocador"].ToString());
                    oCCPagar.locador = oLocador;

                    oCCPagar.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    oCCPagar.periodoInicio = Convert.ToDateTime(drCon["periodoinicio"].ToString());
                    oCCPagar.periodoFim = Convert.ToDateTime(drCon["periodofim"].ToString());
                    oCCPagar.dataVencimento = Convert.ToDateTime(drCon["datavencimento"].ToString());

                    if (drCon["dataintegracao"] is DBNull)
                    {
                        oCCPagar.dataIntegracao = null;
                    }
                    else
                        oCCPagar.dataIntegracao = Convert.ToDateTime(drCon["dataintegracao"].ToString());

                    oCCPagar.percParticipacao = EmcResources.cDouble(drCon["percparticipacao"].ToString());
                    oCCPagar.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    oCCPagar.valorJurosCalculado = EmcResources.cCur(drCon["valorjuroscalculado"].ToString());
                    oCCPagar.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    oCCPagar.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    oCCPagar.valorPago = EmcResources.cCur(drCon["valorpago"].ToString());
                    oCCPagar.situacao = drCon["situacao"].ToString();
                    oCCPagar.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCPagar.locador = oFornecedorDAO.ObterPor(oCCPagar.locador);

                    LocacaoCCPagarDAO oCCDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCPagar.lstCtaCorrente = oCCDAO.lstLocacaoCCPagar(oCCPagar.idLocacaoContrato, oCCPagar.idLocacaoPagar);

                    LocacaoContratoDAO oContratoDAO = new LocacaoContratoDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCPagar.contrato = oContratoDAO.ObterPor(oCCPagar.contrato, "N");

                }
                return oCCPagar;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void recalculaParcela(int idContrato, int idParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            try
            {
                decimal valorParcela = 0;
                List<LocacaoCCPagar> lstCCPagar = new List<LocacaoCCPagar>();

                LocacaoCCPagarDAO oCCPagarDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                lstCCPagar = oCCPagarDAO.lstLocacaoCCPagar(idContrato, idParcela);


                foreach(LocacaoCCPagar oCCPagar in lstCCPagar)
                {
                    if (oCCPagar.situacao != "C")
                    {
                        if (oCCPagar.tipoProvento == "D")
                        {
                            valorParcela = valorParcela + oCCPagar.valorLancamento;
                        }
                        else
                        {
                            valorParcela = valorParcela + oCCPagar.valorLancamento;
                        }
                    }
                }
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }
        }

        private void geraOcorrencia(LocacaoPagar oCCReceber, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oCCReceber.idLocacaoContrato.ToString();

                if (flag == "A")
                {

                    LocacaoPagar oCCP = new LocacaoPagar();
                    oCCP = ObterPor(oCCReceber);

                    if (!oCCP.Equals(oCCReceber))
                    {
                        descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato + 
                                    " Locacao Receber id : " + oCCReceber.idLocacaoPagar + 
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.locador.Equals(oCCReceber.locador))
                        {
                            descricao += " Locador de " + oCCP.locador.pessoa.nome + " para " + oCCReceber.locador.pessoa.nome;
                        }
                        if (!oCCP.nroParcela.Equals(oCCReceber.nroParcela))
                        {
                            descricao += " Nro Parcela de " + oCCP.nroParcela + " para " + oCCReceber.nroParcela;
                        }
                        if (!oCCP.periodoInicio.Equals(oCCReceber.periodoInicio))
                        {
                            descricao += " Periodo Inicio de " + oCCP.periodoInicio + " para " + oCCReceber.periodoInicio;
                        }
                        if (!oCCP.periodoFim.Equals(oCCReceber.periodoFim))
                        {
                            descricao += " Periodo Fim de " + oCCP.periodoFim + " para " + oCCReceber.periodoFim;
                        }
                        if (!oCCP.dataVencimento.Equals(oCCReceber.dataVencimento))
                        {
                            descricao += " Data Vencimento de " + oCCP.dataVencimento + " para " + oCCReceber.dataVencimento;
                        }
                        if (!oCCP.percParticipacao.Equals(oCCReceber.percParticipacao))
                        {
                            descricao += " Percentual Participação de " + oCCP.percParticipacao + " para " + oCCReceber.percParticipacao;
                        }
                        if (!oCCP.valorJuros.Equals(oCCReceber.valorJuros))
                        {
                            descricao += " Valor Juros de " + oCCP.valorJuros + " para " + oCCReceber.valorJuros;
                        }
                        if (!oCCP.valorJurosCalculado.Equals(oCCReceber.valorJurosCalculado))
                        {
                            descricao += " Valor Juros Calculado de " + oCCP.valorJurosCalculado + " para " + oCCReceber.valorJurosCalculado;
                        }
                        if (!oCCP.valorDesconto.Equals(oCCReceber.valorDesconto))
                        {
                            descricao += " Valor Desconto de " + oCCP.valorDesconto + " para " + oCCReceber.valorDesconto;
                        }
                        if (!oCCP.valorParcela.Equals(oCCReceber.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oCCP.valorParcela + " para " + oCCReceber.valorParcela;
                        }
                        if (!oCCP.valorParcela.Equals(oCCReceber.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oCCP.valorParcela + " para " + oCCReceber.valorParcela;
                        }
                        if (!oCCP.valorPago.Equals(oCCReceber.valorPago))
                        {
                            descricao += " Valor Pago de " + oCCP.valorPago + " para " + oCCReceber.valorPago;
                        }
                        if (!oCCP.situacao.Equals(oCCReceber.situacao))
                        {
                            descricao += " Situação de " + oCCP.situacao + " para " + oCCReceber.situacao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato + 
                                " Locacao Receber id : " + oCCReceber.idLocacaoPagar + 
                                " Locador : " + oCCReceber.locador.pessoa.nome + " - " + oCCReceber.locador.pessoa.idPessoa +
                                " Nro Parcela : " + oCCReceber.nroParcela +
                                " Periodo Inicio : " + oCCReceber.periodoInicio +
                                " Periodo Fim : " + oCCReceber.periodoFim +
                                " Data Vencimento : " + oCCReceber.dataVencimento.ToShortDateString() +
                                " Percentual Partipação : " + oCCReceber.percParticipacao.ToString() +
                                " Desconto : " + oCCReceber.valorDesconto.ToString() +
                                " Juros : " + oCCReceber.valorJuros.ToString() +
                                " Juros Calculado : " + oCCReceber.valorJurosCalculado.ToString() +
                                " Valor Pago : " + oCCReceber.valorPago.ToString() +
                                " Valor Parcela : " + oCCReceber.valorParcela.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoPagar +
                                " Locador : " + oCCReceber.locador.pessoa.nome + " - " + oCCReceber.locador.pessoa.idPessoa +
                                " Nro Parcela : " + oCCReceber.nroParcela +
                                " Periodo Inicio : " + oCCReceber.periodoInicio +
                                " Periodo Fim : " + oCCReceber.periodoFim +
                                " Data Vencimento : " + oCCReceber.dataVencimento.ToShortDateString() +
                                " Percentual Partipação : " + oCCReceber.percParticipacao.ToString() +
                                " Desconto : " + oCCReceber.valorDesconto.ToString() +
                                " Juros : " + oCCReceber.valorJuros.ToString() +
                                " Juros Calculado : " + oCCReceber.valorJurosCalculado.ToString() +
                                " Valor Pago : " + oCCReceber.valorPago.ToString() +
                                " Valor Parcela : " + oCCReceber.valorParcela.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "R")
                {
                    descricao = "Recuperado : Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoPagar +
                                " Locador : " + oCCReceber.locador.pessoa.nome + " - " + oCCReceber.locador.pessoa.idPessoa +
                                " Nro Parcela : " + oCCReceber.nroParcela +
                                " Periodo Inicio : " + oCCReceber.periodoInicio +
                                " Periodo Fim : " + oCCReceber.periodoFim +
                                " Data Vencimento : " + oCCReceber.dataVencimento.ToShortDateString() +
                                " Percentual Partipação : " + oCCReceber.percParticipacao.ToString() +
                                " Desconto : " + oCCReceber.valorDesconto.ToString() +
                                " Juros : " + oCCReceber.valorJuros.ToString() +
                                " Juros Calculado : " + oCCReceber.valorJurosCalculado.ToString() +
                                " Valor Pago : " + oCCReceber.valorPago.ToString() +
                                " Valor Parcela : " + oCCReceber.valorParcela.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi recuperado por " + oOcorrencia.usuario.nome;
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
