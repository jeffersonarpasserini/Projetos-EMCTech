using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCFaturamentoModel;

namespace EMCFaturamentoDAO
{
    public class Fatu_TributacaoUfDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_TributacaoUfDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
                codEmpresa = codempresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = codempresa;
            }

        }

        public void Salvar(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();




            //Grava um novo registro
            try
            {

                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_tributacaouf'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_TributacaoUf.idFatu_TributacaoUf = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;
                
                geraOcorrencia(objFatu_TributacaoUf, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_TributacaoUf (idfatu_tributacao, idfatu_naturezaoperacao, tipotabela" + 
                                                               "uforigem, ufdestino, entradasaida, contribuinteicms,  tipocontribuinte, " + 
                                                               "icmstributado, icmsisento, icmsoutros, deduzreducao, icmsaliquota, " + 
                                                               "subicmstributado, subicmsacrescimo, subicmsaliquota, " + 
                                                               "ipisomabase, ipisomabasesubicms, situacaoicms, " + 
                                                               "impruraltributado, impruralaliquota, fundepectributado, fundepecaliquota, " + 
                                                               "livrecomerciodesconto, idfatu_motivoicms, codigoajusteicms, codigoajusteicentivo, " + 
                                                               "ajusteincentivo, mensagem) " + 
                                                      "values ( @idfatu_tributacao, @idfatu_naturezaoperacao, @tipotabela," + 
                                                               "@uforigem, @ufdestino, @entradasaida, @contribuinteicms,  @tipocontribuinte, " + 
                                                               "@icmstributado, @icmsisento, @icmsoutros, @deduzreducao, @icmsaliquota, " + 
                                                               "@subicmstributado, @subicmsacrescimo, @subicmsaliquota, " + 
                                                               "@ipisomabase, @ipisomabasesubicms, @situacaoicms, " + 
                                                               "@impruraltributado, @impruralaliquota, @fundepectributado, @fundepecaliquota, " + 
                                                               "@livrecomerciodesconto, @idfatu_motivoicms, @codigoajusteicms, @codigoajusteicentivo, " + 
                                                               "@ajusteincentivo, @mensagem )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_tributacao", objFatu_TributacaoUf.tributacao.idfatu_tributacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_naturezaoperacao", objFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao);
                Sqlcon.Parameters.AddWithValue("@tipotabela", objFatu_TributacaoUf.tipoTabela);
                Sqlcon.Parameters.AddWithValue("@uforigem", objFatu_TributacaoUf.ufOrigem);
                Sqlcon.Parameters.AddWithValue("@ufdestino", objFatu_TributacaoUf.ufDestino);
                Sqlcon.Parameters.AddWithValue("@entradasaida", objFatu_TributacaoUf.entradaSaida);
                Sqlcon.Parameters.AddWithValue("@contribuinteicms", objFatu_TributacaoUf.contribuinteICMS);
                Sqlcon.Parameters.AddWithValue("@tipocontribuinte", objFatu_TributacaoUf.tipoContribuinte);
                Sqlcon.Parameters.AddWithValue("@icmstributado", objFatu_TributacaoUf.icmsTributado);
                Sqlcon.Parameters.AddWithValue("@icmsisento", objFatu_TributacaoUf.icmsIsento);
                Sqlcon.Parameters.AddWithValue("@icmsoutros", objFatu_TributacaoUf.icmsOutros);
                Sqlcon.Parameters.AddWithValue("@deduzreducao", objFatu_TributacaoUf.deduzReducao);
                Sqlcon.Parameters.AddWithValue("@icmsaliquota", objFatu_TributacaoUf.icmsAliquota);
                Sqlcon.Parameters.AddWithValue("@subicmstributado", objFatu_TributacaoUf.subIcmsTributado);
                Sqlcon.Parameters.AddWithValue("@subicmsacrescimo", objFatu_TributacaoUf.subIcmsAcrescimo);
                Sqlcon.Parameters.AddWithValue("@subicmsaliquota", objFatu_TributacaoUf.subIcmsAliquota);
                Sqlcon.Parameters.AddWithValue("@ipisomabase", objFatu_TributacaoUf.ipiSomaBase);
                Sqlcon.Parameters.AddWithValue("@ipisomabasesubicms", objFatu_TributacaoUf.ipiSomaBaseSubIcms);
                Sqlcon.Parameters.AddWithValue("@situacaoicms", objFatu_TributacaoUf.situacaoIcms);
                Sqlcon.Parameters.AddWithValue("@impruraltributado", objFatu_TributacaoUf.impRuralTributado);
                Sqlcon.Parameters.AddWithValue("@impruralaliquota", objFatu_TributacaoUf.impRuralAliquota);
                Sqlcon.Parameters.AddWithValue("@fundepectributado", objFatu_TributacaoUf.fundepectributado);
                Sqlcon.Parameters.AddWithValue("@livrecomerciodesconto", objFatu_TributacaoUf.livrecomerciodesconto);
                Sqlcon.Parameters.AddWithValue("@idfatu_motivoicms", objFatu_TributacaoUf.motivoDesnoneracaoIcms.idFatu_MotivoIcms);
                Sqlcon.Parameters.AddWithValue("@codigoajusteicms", objFatu_TributacaoUf.codigoAjusteIcms);
                Sqlcon.Parameters.AddWithValue("@codigoajusteicentivo", objFatu_TributacaoUf.codigoAjusteIncentivo);
                Sqlcon.Parameters.AddWithValue("@ajusteincentivo", objFatu_TributacaoUf.ajusteIncentivo);
                Sqlcon.Parameters.AddWithValue("@mensagem", objFatu_TributacaoUf.mensagem);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);


                transacao.Commit();

            }
            catch (MySqlException erro)
            {
                transacao.Rollback();
                throw erro;
            }
            finally
            {
                transacao.Dispose();
                transacao = null;
            }
        }

        public void Atualizar(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_TributacaoUf, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_TributacaoUf set idfatu_tributacao=@idfatu_tributacao, idfatu_naturezaoperacao=@idfatu_naturezaoperacao, tipotabela=@tipotabela, " +
                                                               "uforigem=@uforigem, ufdestino=@ufdestino, entradasaida=@entradasaida, contribuinteicms=@contribuinteicms, " +
                                                               "tipocontribuinte=@tipocontribuinte, icmstributado=@icmstributado, icmsisento=@icmsisento, icmsoutros=@icmsoutros, " +
                                                               "deduzreducao=@deduzreducao, icmsaliquota@icmsaliquota, subicmstributado=@subicmstributado, " +
                                                               "subicmsacrescimo=@subicmsacrescimo, subicmsaliquota@subicmsaliquota, ipisomabase=@ipisomabase, " +
                                                               "ipisomabasesubicms=@ipisomabasesubicms, situacaoicms=@situacaoicms, " +
                                                               "impruraltributado=@impruraltributado, impruralaliquota=@impruralaliquota, fundepectributado=@fundepectributado, " +
                                                               "fundepecaliquota=@fundepecaliquota, livrecomerciodesconto=@livrecomerciodesconto, idfatu_motivoicms=@idfatu_motivoicms, " +
                                                               "codigoajusteicms=@codigoajusteicms, codigoajusteicentivo=@codigoajusteicentivo, " +
                                                               "ajusteincentivo=@ajusteincentivo, mensagem=@mensagem " +
                                                      "where idfatu_tributacaouf=@idfatu_tributacaouf ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_tributacaouf", objFatu_TributacaoUf.idFatu_TributacaoUf);
                Sqlcon.Parameters.AddWithValue("@idfatu_tributacao", objFatu_TributacaoUf.tributacao.idfatu_tributacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_naturezaoperacao", objFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao);
                Sqlcon.Parameters.AddWithValue("@tipotabela", objFatu_TributacaoUf.tipoTabela);
                Sqlcon.Parameters.AddWithValue("@uforigem", objFatu_TributacaoUf.ufOrigem);
                Sqlcon.Parameters.AddWithValue("@ufdestino", objFatu_TributacaoUf.ufDestino);
                Sqlcon.Parameters.AddWithValue("@entradasaida", objFatu_TributacaoUf.entradaSaida);
                Sqlcon.Parameters.AddWithValue("@contribuinteicms", objFatu_TributacaoUf.contribuinteICMS);
                Sqlcon.Parameters.AddWithValue("@tipocontribuinte", objFatu_TributacaoUf.tipoContribuinte);
                Sqlcon.Parameters.AddWithValue("@icmstributado", objFatu_TributacaoUf.icmsTributado);
                Sqlcon.Parameters.AddWithValue("@icmsisento", objFatu_TributacaoUf.icmsIsento);
                Sqlcon.Parameters.AddWithValue("@icmsoutros", objFatu_TributacaoUf.icmsOutros);
                Sqlcon.Parameters.AddWithValue("@deduzreducao", objFatu_TributacaoUf.deduzReducao);
                Sqlcon.Parameters.AddWithValue("@icmsaliquota", objFatu_TributacaoUf.icmsAliquota);
                Sqlcon.Parameters.AddWithValue("@subicmstributado", objFatu_TributacaoUf.subIcmsTributado);
                Sqlcon.Parameters.AddWithValue("@subicmsacrescimo", objFatu_TributacaoUf.subIcmsAcrescimo);
                Sqlcon.Parameters.AddWithValue("@subicmsaliquota", objFatu_TributacaoUf.subIcmsAliquota);
                Sqlcon.Parameters.AddWithValue("@ipisomabase", objFatu_TributacaoUf.ipiSomaBase);
                Sqlcon.Parameters.AddWithValue("@ipisomabasesubicms", objFatu_TributacaoUf.ipiSomaBaseSubIcms);
                Sqlcon.Parameters.AddWithValue("@situacaoicms", objFatu_TributacaoUf.situacaoIcms);
                Sqlcon.Parameters.AddWithValue("@impruraltributado", objFatu_TributacaoUf.impRuralTributado);
                Sqlcon.Parameters.AddWithValue("@impruralaliquota", objFatu_TributacaoUf.impRuralAliquota);
                Sqlcon.Parameters.AddWithValue("@fundepectributado", objFatu_TributacaoUf.fundepectributado);
                Sqlcon.Parameters.AddWithValue("@livrecomerciodesconto", objFatu_TributacaoUf.livrecomerciodesconto);
                Sqlcon.Parameters.AddWithValue("@idfatu_motivoicms", objFatu_TributacaoUf.motivoDesnoneracaoIcms.idFatu_MotivoIcms);
                Sqlcon.Parameters.AddWithValue("@codigoajusteicms", objFatu_TributacaoUf.codigoAjusteIcms);
                Sqlcon.Parameters.AddWithValue("@codigoajusteicentivo", objFatu_TributacaoUf.codigoAjusteIncentivo);
                Sqlcon.Parameters.AddWithValue("@ajusteincentivo", objFatu_TributacaoUf.ajusteIncentivo);
                Sqlcon.Parameters.AddWithValue("@mensagem", objFatu_TributacaoUf.mensagem);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                transacao.Commit();
            }
            catch (MySqlException erro)
            {
                transacao.Rollback();
                throw erro;
            }
            finally
            {
                transacao.Dispose();
                transacao = null;
            }

        }

        public void Excluir(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_TributacaoUf, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_TributacaoUf where idFatu_TributacaoUf = @idFatu_TributacaoUf";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_TributacaoUf", objFatu_TributacaoUf.idFatu_TributacaoUf);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                transacao.Commit();

            }
            catch (MySqlException erro)
            {
                transacao.Rollback();
                throw erro;
            }
            finally
            {
                transacao.Dispose();
                transacao = null;
            }

        }

        public DataTable ListaFatu_TributacaoUf()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_TributacaoUf order by ufdestino";
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

        public Fatu_TributacaoUf ObterPor(Fatu_TributacaoUf oFatu_TributacaoUf)
        {
            MySqlDataReader drCon;
            try
            {


                if (oFatu_TributacaoUf.idFatu_TributacaoUf > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_TributacaoUf Where idFatu_TributacaoUf=@idFatu_TributacaoUf";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_TributacaoUf", oFatu_TributacaoUf.idFatu_TributacaoUf);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_TributacaoUf Where idFatu_Tributacao=@idFatu_Tributacao " +
                                                                     " and idFatu_NaturezaOperacao=@idFatu_NaturezaOperacao " +
                                                                     " and uforigem=@uforigem " +
                                                                     " and ufdestino=@ufdestino " +
                                                                     " and tipotabela=@tipotabela";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_Tributacao", oFatu_TributacaoUf.tributacao.idfatu_tributacao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_NaturezaOperacao", oFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao);
                    Sqlcon.Parameters.AddWithValue("@uforigem", oFatu_TributacaoUf.ufOrigem);
                    Sqlcon.Parameters.AddWithValue("@ufdestino", oFatu_TributacaoUf.ufDestino);
                    Sqlcon.Parameters.AddWithValue("@tipotabela", oFatu_TributacaoUf.tipoTabela);
                    drCon = Sqlcon.ExecuteReader();
                }

                while (drCon.Read())
                {
                    Fatu_TributacaoUf oTribUf = new Fatu_TributacaoUf();
                    oTribUf.idFatu_TributacaoUf = EmcResources.cInt(drCon["idfatu_tributacaouf"].ToString());

                    Fatu_Tributacao oTributacao = new Fatu_Tributacao();
                    oTributacao.idfatu_tributacao = EmcResources.cInt(drCon["idfatu_tributacao"].ToString());
                    oTribUf.tributacao = oTributacao;

                    Fatu_NaturezaOperacao oNatOperacao = new Fatu_NaturezaOperacao();
                    oNatOperacao.idFatu_NaturezaOperacao = EmcResources.cInt(drCon["idfatu_naturezaoperacao"].ToString());
                    oTribUf.naturezaOperacao = oNatOperacao;

                    oTribUf.ufOrigem = drCon["uforigem"].ToString();
                    oTribUf.ufDestino = drCon["ufdestino"].ToString();
                    oTribUf.tipoTabela = drCon["tipotabela"].ToString();
                    oTribUf.entradaSaida = drCon["entradasaida"].ToString();
                    oTribUf.contribuinteICMS = drCon["contribuinteicms"].ToString();
                    oTribUf.icmsTributado = EmcResources.cDouble(drCon["icmstributado"].ToString());
                    oTribUf.icmsIsento = EmcResources.cDouble(drCon["icmsisento"].ToString());
                    oTribUf.icmsOutros = EmcResources.cDouble(drCon["icmsoutros"].ToString());
                    oTribUf.deduzReducao = drCon["deduzreducao"].ToString();
                    oTribUf.icmsAliquota = EmcResources.cDouble(drCon["icmsaliquota"].ToString());
                    oTribUf.subIcmsTributado = EmcResources.cDouble(drCon["subicmstributado"].ToString());
                    oTribUf.subIcmsAcrescimo = EmcResources.cDouble(drCon["subicmsacrescimo"].ToString());
                    oTribUf.subIcmsAliquota = EmcResources.cDouble(drCon["subicmsaliquota"].ToString());
                    oTribUf.ipiSomaBase = drCon["ipisomabase"].ToString();
                    oTribUf.ipiSomaBaseSubIcms = drCon["ipisomabasesubicms"].ToString();
                    oTribUf.situacaoIcms = drCon["situacaoicms"].ToString();
                    oTribUf.impRuralTributado = drCon["impruraltributado"].ToString();
                    oTribUf.impRuralAliquota = EmcResources.cDouble(drCon["impruralaliquota"].ToString());
                    oTribUf.fundepectributado = drCon["fundepectributado"].ToString();
                    oTribUf.fundepecaliquota = EmcResources.cDouble(drCon["fundepecaliquota"].ToString());
                    oTribUf.livrecomerciodesconto = EmcResources.cDouble(drCon["livrecomerciodesconto"].ToString());

                    Fatu_MotivoIcms oMotivo = new Fatu_MotivoIcms();
                    oMotivo.idFatu_MotivoIcms = drCon["idfatu_motivoicms"].ToString();
                    oTribUf.motivoDesnoneracaoIcms = oMotivo;

                    oTribUf.codigoAjusteIcms = drCon["codigoajusteicms"].ToString();
                    oTribUf.codigoAjusteIncentivo = drCon["codigoajusteicentivo"].ToString();
                    oTribUf.ajusteIncentivo = drCon["ajusteincentivo"].ToString();
                    oTribUf.mensagem = drCon["mensagem"].ToString();        
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_TributacaoUf objFatu_TributacaoUf1 = new Fatu_TributacaoUf();
                return objFatu_TributacaoUf1;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }

        }

        private void geraOcorrencia(Fatu_TributacaoUf oFatu_TributacaoUf, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_TributacaoUf.idFatu_TributacaoUf.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_TributacaoUf oCobr = new Fatu_TributacaoUf();
                    oCobr = ObterPor(oFatu_TributacaoUf);

                    if (!oCobr.Equals(oFatu_TributacaoUf))
                    {
                        descricao = "Sit. Fiscal Cofins id: " + oFatu_TributacaoUf.idFatu_TributacaoUf + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.tributacao.idfatu_tributacao.Equals(oFatu_TributacaoUf.tributacao.idfatu_tributacao))
                        {
                            descricao += " Tributação de " + oCobr.tributacao.idfatu_tributacao + " - " + oCobr.tributacao.descricao
                                                + " para " + oFatu_TributacaoUf.tributacao.idfatu_tributacao+ " - " + oFatu_TributacaoUf.tributacao.descricao ;
                        }
                        if (!oCobr.naturezaOperacao.idFatu_NaturezaOperacao.Equals(oFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao))
                        {
                            descricao += " Natureza de Operacao de " + oCobr.naturezaOperacao.idFatu_NaturezaOperacao + " - " + oCobr.naturezaOperacao.descricao
                                                + " para " + oFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao + " - " + oFatu_TributacaoUf.naturezaOperacao.descricao;
                        }
                        if (!oCobr.ufOrigem.Equals(oFatu_TributacaoUf.ufOrigem))
                        {
                            descricao += " Uf Origem de " + oCobr.ufOrigem + " para " + oFatu_TributacaoUf.ufOrigem;
                        }
                        if (!oCobr.ufDestino.Equals(oFatu_TributacaoUf.ufDestino))
                        {
                            descricao += " Uf Destino de " + oCobr.ufDestino + " para " + oFatu_TributacaoUf.ufDestino;
                        }
                        if (!oCobr.tipoTabela.Equals(oFatu_TributacaoUf.tipoTabela))
                        {
                            descricao += " Tipo Tabela de " + oCobr.tipoTabela + " para " + oFatu_TributacaoUf.tipoTabela;
                        }
                        if (!oCobr.entradaSaida.Equals(oFatu_TributacaoUf.entradaSaida))
                        {
                            descricao += " Entrada/Saida de " + oCobr.entradaSaida + " para " + oFatu_TributacaoUf.entradaSaida;
                        }
                        if (!oCobr.contribuinteICMS.Equals(oFatu_TributacaoUf.contribuinteICMS))
                        {
                            descricao += " Contribuinte ICMS de " + oCobr.contribuinteICMS + " para " + oFatu_TributacaoUf.contribuinteICMS;
                        }
                        if (!oCobr.tipoContribuinte.Equals(oFatu_TributacaoUf.tipoContribuinte))
                        {
                            descricao += " Tipo Contribuinte de " + oCobr.tipoContribuinte + " para " + oFatu_TributacaoUf.tipoContribuinte;
                        }
                        if (!oCobr.icmsTributado.Equals(oFatu_TributacaoUf.icmsTributado))
                        {
                            descricao += " ICMS Tributado de " + oCobr.icmsTributado.ToString() + " para " + oFatu_TributacaoUf.icmsTributado.ToString();
                        }
                        if (!oCobr.icmsIsento.Equals(oFatu_TributacaoUf.icmsIsento))
                        {
                            descricao += " ICMS Isento de " + oCobr.icmsIsento.ToString() + " para " + oFatu_TributacaoUf.icmsIsento.ToString();
                        }
                        if (!oCobr.icmsOutros.Equals(oFatu_TributacaoUf.icmsOutros))
                        {
                            descricao += " ICMS Outros de " + oCobr.icmsOutros.ToString() + " para " + oFatu_TributacaoUf.icmsOutros.ToString();
                        }
                        if (!oCobr.deduzReducao.Equals(oFatu_TributacaoUf.deduzReducao))
                        {
                            descricao += " Deduz Redução de " + oCobr.deduzReducao + " para " + oFatu_TributacaoUf.deduzReducao;
                        }
                        if (!oCobr.icmsAliquota.Equals(oFatu_TributacaoUf.icmsAliquota))
                        {
                            descricao += " ICMS Aliquota de " + oCobr.icmsAliquota.ToString() + " para " + oFatu_TributacaoUf.icmsAliquota.ToString();
                        }
                        if (!oCobr.subIcmsTributado.Equals(oFatu_TributacaoUf.subIcmsTributado))
                        {
                            descricao += " ICMS Subst. Tributado " + oCobr.subIcmsTributado.ToString() + " para " + oFatu_TributacaoUf.subIcmsTributado.ToString();
                        }
                        if (!oCobr.subIcmsAcrescimo.Equals(oFatu_TributacaoUf.subIcmsAcrescimo))
                        {
                            descricao += " ICMS Subst Acrescimo de " + oCobr.subIcmsAcrescimo.ToString() + " para " + oFatu_TributacaoUf.subIcmsAcrescimo.ToString();
                        }
                        if (!oCobr.subIcmsAliquota.Equals(oFatu_TributacaoUf.subIcmsAliquota))
                        {
                            descricao += " ICMS Subst. Aliquota de " + oCobr.subIcmsAliquota.ToString() + " para " + oFatu_TributacaoUf.subIcmsAliquota.ToString();
                        }
                        if (!oCobr.ipiSomaBase.Equals(oFatu_TributacaoUf.ipiSomaBase))
                        {
                            descricao += " Soma IPI na Base ICMS de " + oCobr.ipiSomaBase.ToString() + " para " + oFatu_TributacaoUf.ipiSomaBase.ToString();
                        }
                        if (!oCobr.ipiSomaBaseSubIcms.Equals(oFatu_TributacaoUf.ipiSomaBaseSubIcms))
                        {
                            descricao += " Soma IPI na Base ICMS Subst. de " + oCobr.ipiSomaBaseSubIcms.ToString() + " para " + oFatu_TributacaoUf.ipiSomaBaseSubIcms.ToString();
                        }
                        if (!oCobr.situacaoIcms.Equals(oFatu_TributacaoUf.situacaoIcms))
                        {
                            descricao += " Situacao ICMS de " + oCobr.situacaoIcms.ToString() + " para " + oFatu_TributacaoUf.situacaoIcms.ToString();
                        }
                        if (!oCobr.impRuralTributado.Equals(oFatu_TributacaoUf.impRuralTributado))
                        {
                            descricao += " Tributa Imp.Rural de " + oCobr.impRuralTributado.ToString() + " para " + oFatu_TributacaoUf.impRuralTributado.ToString();
                        }
                        if (!oCobr.impRuralAliquota.Equals(oFatu_TributacaoUf.impRuralAliquota))
                        {
                            descricao += " Imp. Rural Aliquota de " + oCobr.impRuralAliquota.ToString() + " para " + oFatu_TributacaoUf.impRuralAliquota.ToString();
                        }
                        if (!oCobr.fundepectributado.Equals(oFatu_TributacaoUf.fundepectributado))
                        {
                            descricao += " Fundepec Tributado de " + oCobr.fundepectributado.ToString() + " para " + oFatu_TributacaoUf.fundepectributado.ToString();
                        }
                        if (!oCobr.fundepecaliquota.Equals(oFatu_TributacaoUf.fundepecaliquota))
                        {
                            descricao += " Fundepec Aliquota de " + oCobr.fundepecaliquota.ToString() + " para " + oFatu_TributacaoUf.fundepecaliquota.ToString();
                        }
                        if (!oCobr.livrecomerciodesconto.Equals(oFatu_TributacaoUf.livrecomerciodesconto))
                        {
                            descricao += " Desconto Livre Comercio de " + oCobr.livrecomerciodesconto.ToString() + " para " + oFatu_TributacaoUf.livrecomerciodesconto.ToString();
                        }
                        if (!oCobr.motivoDesnoneracaoIcms.idFatu_MotivoIcms.Equals(oFatu_TributacaoUf.motivoDesnoneracaoIcms.idFatu_MotivoIcms))
                        {
                            descricao += " Motivo Desoneração ICMS de " + oCobr.motivoDesnoneracaoIcms.idFatu_MotivoIcms.ToString() + " - " + oCobr.motivoDesnoneracaoIcms.descricao + 
                                                     " para " + oFatu_TributacaoUf.motivoDesnoneracaoIcms.idFatu_MotivoIcms.ToString() + " - " + oFatu_TributacaoUf.motivoDesnoneracaoIcms.descricao;
                        }
                        if (!oCobr.codigoAjusteIcms.Equals(oFatu_TributacaoUf.codigoAjusteIcms))
                        {
                            descricao += " Cod. Ajuste ICMS de " + oCobr.codigoAjusteIcms.ToString() + " para " + oFatu_TributacaoUf.codigoAjusteIcms.ToString();
                        }
                        if (!oCobr.codigoAjusteIncentivo.Equals(oFatu_TributacaoUf.codigoAjusteIncentivo))
                        {
                            descricao += " Cod. Ajuste Incentivo de " + oCobr.codigoAjusteIncentivo.ToString() + " para " + oFatu_TributacaoUf.codigoAjusteIncentivo.ToString();
                        }
                        if (!oCobr.ajusteIncentivo.Equals(oFatu_TributacaoUf.ajusteIncentivo))
                        {
                            descricao += " Ajuste Incentivo de " + oCobr.ajusteIncentivo.ToString() + " para " + oFatu_TributacaoUf.ajusteIncentivo.ToString();
                        }
                        if (!oCobr.mensagem.Equals(oFatu_TributacaoUf.mensagem))
                        {
                            descricao += " Mensagem de " + oCobr.mensagem.ToString() + " para " + oFatu_TributacaoUf.mensagem.ToString();
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Sit. Fiscal Cofins id: " + oFatu_TributacaoUf.idFatu_TributacaoUf;
                    descricao += " Tributação : " + oFatu_TributacaoUf.tributacao.idfatu_tributacao + " - " + oFatu_TributacaoUf.tributacao.descricao;
                    descricao += " Natureza de Operacao : " + oFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao + " - " + oFatu_TributacaoUf.naturezaOperacao.descricao;
                    descricao += " Uf Origem : " + oFatu_TributacaoUf.ufOrigem;
                    descricao += " Uf Destino : " + oFatu_TributacaoUf.ufDestino;
                    descricao += " Tipo Tabela : " + oFatu_TributacaoUf.tipoTabela;
                    descricao += " Entrada/Saida : "  + oFatu_TributacaoUf.entradaSaida;
                    descricao += " Contribuinte ICMS : "+ oFatu_TributacaoUf.contribuinteICMS;
                    descricao += " Tipo Contribuinte : "  + oFatu_TributacaoUf.tipoContribuinte;
                    descricao += " ICMS Tributado : "  + oFatu_TributacaoUf.icmsTributado.ToString();
                    descricao += " ICMS Isento : " + oFatu_TributacaoUf.icmsIsento.ToString();
                    descricao += " ICMS Outros : " + oFatu_TributacaoUf.icmsOutros.ToString();
                    descricao += " Deduz Redução : "  + oFatu_TributacaoUf.deduzReducao;
                    descricao += " ICMS Aliquota : " + oFatu_TributacaoUf.icmsAliquota.ToString();
                    descricao += " ICMS Subst. Tributado : "  + oFatu_TributacaoUf.subIcmsTributado.ToString();
                    descricao += " ICMS Subst Acrescimo : "  + oFatu_TributacaoUf.subIcmsAcrescimo.ToString();
                    descricao += " ICMS Subst. Aliquota : "  + oFatu_TributacaoUf.subIcmsAliquota.ToString();
                    descricao += " Soma IPI na Base ICMS : " + oFatu_TributacaoUf.ipiSomaBase.ToString();
                    descricao += " Soma IPI na Base ICMS Subst. : " + oFatu_TributacaoUf.ipiSomaBaseSubIcms.ToString();
                    descricao += " Situacao ICMS : " + oFatu_TributacaoUf.situacaoIcms.ToString();
                    descricao += " Tributa Imp.Rural : " + oFatu_TributacaoUf.impRuralTributado.ToString();
                    descricao += " Imp. Rural Aliquota : " + oFatu_TributacaoUf.impRuralAliquota.ToString();
                    descricao += " Fundepec Tributado : " + oFatu_TributacaoUf.fundepectributado.ToString();
                    descricao += " Fundepec Aliquota : " + oFatu_TributacaoUf.fundepecaliquota.ToString();
                    descricao += " Desconto Livre Comercio : " + oFatu_TributacaoUf.livrecomerciodesconto.ToString();
                    descricao += " Motivo Desoneração ICMS : " + oFatu_TributacaoUf.motivoDesnoneracaoIcms.idFatu_MotivoIcms.ToString() + " - " + oFatu_TributacaoUf.motivoDesnoneracaoIcms.descricao;
                    descricao += " Cod. Ajuste ICMS : "  + oFatu_TributacaoUf.codigoAjusteIcms.ToString();
                    descricao += " Cod. Ajuste Incentivo : " + oFatu_TributacaoUf.codigoAjusteIncentivo.ToString();
                    descricao += " Ajuste Incentivo : " + oFatu_TributacaoUf.ajusteIncentivo.ToString();
                    descricao += " Mensagem : "  + oFatu_TributacaoUf.mensagem.ToString();
                    descricao += " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Sit. Fiscal Cofins id: " + oFatu_TributacaoUf.idFatu_TributacaoUf;
                    descricao += " Tributação : " + oFatu_TributacaoUf.tributacao.idfatu_tributacao + " - " + oFatu_TributacaoUf.tributacao.descricao;
                    descricao += " Natureza de Operacao : " + oFatu_TributacaoUf.naturezaOperacao.idFatu_NaturezaOperacao + " - " + oFatu_TributacaoUf.naturezaOperacao.descricao;
                    descricao += " Uf Origem : " + oFatu_TributacaoUf.ufOrigem;
                    descricao += " Uf Destino : " + oFatu_TributacaoUf.ufDestino;
                    descricao += " Tipo Tabela : " + oFatu_TributacaoUf.tipoTabela;
                    descricao += " Entrada/Saida : " + oFatu_TributacaoUf.entradaSaida;
                    descricao += " Contribuinte ICMS : " + oFatu_TributacaoUf.contribuinteICMS;
                    descricao += " Tipo Contribuinte : " + oFatu_TributacaoUf.tipoContribuinte;
                    descricao += " ICMS Tributado : " + oFatu_TributacaoUf.icmsTributado.ToString();
                    descricao += " ICMS Isento : " + oFatu_TributacaoUf.icmsIsento.ToString();
                    descricao += " ICMS Outros : " + oFatu_TributacaoUf.icmsOutros.ToString();
                    descricao += " Deduz Redução : " + oFatu_TributacaoUf.deduzReducao;
                    descricao += " ICMS Aliquota : " + oFatu_TributacaoUf.icmsAliquota.ToString();
                    descricao += " ICMS Subst. Tributado : " + oFatu_TributacaoUf.subIcmsTributado.ToString();
                    descricao += " ICMS Subst Acrescimo : " + oFatu_TributacaoUf.subIcmsAcrescimo.ToString();
                    descricao += " ICMS Subst. Aliquota : " + oFatu_TributacaoUf.subIcmsAliquota.ToString();
                    descricao += " Soma IPI na Base ICMS : " + oFatu_TributacaoUf.ipiSomaBase.ToString();
                    descricao += " Soma IPI na Base ICMS Subst. : " + oFatu_TributacaoUf.ipiSomaBaseSubIcms.ToString();
                    descricao += " Situacao ICMS : " + oFatu_TributacaoUf.situacaoIcms.ToString();
                    descricao += " Tributa Imp.Rural : " + oFatu_TributacaoUf.impRuralTributado.ToString();
                    descricao += " Imp. Rural Aliquota : " + oFatu_TributacaoUf.impRuralAliquota.ToString();
                    descricao += " Fundepec Tributado : " + oFatu_TributacaoUf.fundepectributado.ToString();
                    descricao += " Fundepec Aliquota : " + oFatu_TributacaoUf.fundepecaliquota.ToString();
                    descricao += " Desconto Livre Comercio : " + oFatu_TributacaoUf.livrecomerciodesconto.ToString();
                    descricao += " Motivo Desoneração ICMS : " + oFatu_TributacaoUf.motivoDesnoneracaoIcms.idFatu_MotivoIcms.ToString() + " - " + oFatu_TributacaoUf.motivoDesnoneracaoIcms.descricao;
                    descricao += " Cod. Ajuste ICMS : " + oFatu_TributacaoUf.codigoAjusteIcms.ToString();
                    descricao += " Cod. Ajuste Incentivo : " + oFatu_TributacaoUf.codigoAjusteIncentivo.ToString();
                    descricao += " Ajuste Incentivo : " + oFatu_TributacaoUf.ajusteIncentivo.ToString();
                    descricao += " Mensagem : " + oFatu_TributacaoUf.mensagem.ToString();
                    descricao += " foi excluída por " + oOcorrencia.usuario.nome;

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
