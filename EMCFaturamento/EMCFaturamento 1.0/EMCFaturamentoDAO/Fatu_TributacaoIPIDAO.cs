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
    public class Fatu_TributacaoIPIDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_TributacaoIPIDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_TributacaoIPI'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_TributacaoIPI.idFatu_TributacaoIPI = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_TributacaoIPI, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_TributacaoIPI (descricao, perctributado, percisento, percoutros, aliquotaipi, " + 
                                                                   "idsitfiscal_ipientrada, idsitfiscal_ipisaida ) " + 
                                                          " values (@descricao, @perctributado, @percisento, @percoutros, @aliquotaipi, " + 
                                                                   "@idsitfiscal_ipientrada, @idsitfiscal_ipisaida )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_TributacaoIPI.descricao);
                Sqlcon.Parameters.AddWithValue("@perctributado", objFatu_TributacaoIPI.percTributado);
                Sqlcon.Parameters.AddWithValue("@percisento", objFatu_TributacaoIPI.percIsento);
                Sqlcon.Parameters.AddWithValue("@percoutros", objFatu_TributacaoIPI.percOutros);
                Sqlcon.Parameters.AddWithValue("@aliquotaipi", objFatu_TributacaoIPI.aliquotaIPI);
                Sqlcon.Parameters.AddWithValue("@idsitfiscal_ipientrada", objFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi);
                Sqlcon.Parameters.AddWithValue("@idsitfiscal_ipisaida", objFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi);
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

        public void Atualizar(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_TributacaoIPI, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_TributacaoIPI set descricao=@descricao, perctributado=@perctributado, percisento=@percisento, " + 
                                                                 "percoutros=@percoutros, aliquotaipi=@aliquotaipi, " + 
                                                                 "idsitfiscal_ipientrada=@idsitfiscal_ipientrada, " + 
                                                                 "idsitfiscal_ipisaida=@idsitfiscal_ipisaida " + 
                                                          " where idfatu_tributacaoipi=@idipi ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idipi", objFatu_TributacaoIPI.idFatu_TributacaoIPI);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_TributacaoIPI.descricao);
                Sqlcon.Parameters.AddWithValue("@perctributado", objFatu_TributacaoIPI.percTributado);
                Sqlcon.Parameters.AddWithValue("@percisento", objFatu_TributacaoIPI.percIsento);
                Sqlcon.Parameters.AddWithValue("@percoutros", objFatu_TributacaoIPI.percOutros);
                Sqlcon.Parameters.AddWithValue("@aliquotaipi", objFatu_TributacaoIPI.aliquotaIPI);
                Sqlcon.Parameters.AddWithValue("@idsitfiscal_ipientrada", objFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi);
                Sqlcon.Parameters.AddWithValue("@idsitfiscal_ipisaida", objFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi);
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

        public void Excluir(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_TributacaoIPI, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_TributacaoIPI where idfatu_tributacaoipi=@idipi ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idipi", objFatu_TributacaoIPI.idFatu_TributacaoIPI);

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

        public DataTable ListaFatu_TributacaoIPI()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_tributacaoipi, descricao from Fatu_TributacaoIPI order by descricao";
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

        public Fatu_TributacaoIPI ObterPor(Fatu_TributacaoIPI oFatu_TributacaoIPI)
        {
            MySqlDataReader drCon;
            Boolean Controle = false;

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_TributacaoIPI Where idFatu_TributacaoIPI=@idFatu_TributacaoIPI";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idFatu_TributacaoIPI", oFatu_TributacaoIPI.idFatu_TributacaoIPI);


                drCon = Sqlcon.ExecuteReader();

                Fatu_TributacaoIPI objFatu_TributacaoIPI = new Fatu_TributacaoIPI();

                while (drCon.Read())
                {
                    Controle = true;

                    
                    objFatu_TributacaoIPI.idFatu_TributacaoIPI = Convert.ToInt32(drCon["idfatu_tributacaoipi"].ToString());
                    objFatu_TributacaoIPI.descricao = drCon["descricao"].ToString();
                    objFatu_TributacaoIPI.percTributado = EmcResources.cDouble(drCon["perctributado"].ToString());
                    objFatu_TributacaoIPI.percIsento = EmcResources.cDouble(drCon["percisento"].ToString());
                    objFatu_TributacaoIPI.percOutros =EmcResources.cDouble(drCon["percoutros"].ToString());
                    objFatu_TributacaoIPI.aliquotaIPI = EmcResources.cDouble(drCon["aliquotaipi"].ToString());

                    Fatu_SituacaoFiscalIPI oSitIPIEntrada = new Fatu_SituacaoFiscalIPI();
                    oSitIPIEntrada.idfatu_situacaofiscalipi = EmcResources.cInt(drCon["idsitfiscal_ipientrada"].ToString());

                    objFatu_TributacaoIPI.situacaoIPIEntrada = oSitIPIEntrada;

                    Fatu_SituacaoFiscalIPI oSitIPISaida = new Fatu_SituacaoFiscalIPI();
                    oSitIPISaida.idfatu_situacaofiscalipi = EmcResources.cInt(drCon["idsitfiscal_ipisaida"].ToString());

                    objFatu_TributacaoIPI.situacaoIPISaida = oSitIPISaida;
                                       
                }

                drCon.Close();
                drCon.Dispose();

                if (Controle)
                {
                    Fatu_SituacaoFiscalIPIDAO oIPIEntradaDAO = new Fatu_SituacaoFiscalIPIDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatu_TributacaoIPI.situacaoIPIEntrada = oIPIEntradaDAO.ObterPor(objFatu_TributacaoIPI.situacaoIPIEntrada);

                    Fatu_SituacaoFiscalIPIDAO oIPISaidaDAO = new Fatu_SituacaoFiscalIPIDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatu_TributacaoIPI.situacaoIPISaida = oIPISaidaDAO.ObterPor(objFatu_TributacaoIPI.situacaoIPISaida);

                }
                return objFatu_TributacaoIPI;
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

        private void geraOcorrencia(Fatu_TributacaoIPI oFatu_TributacaoIPI, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_TributacaoIPI.idFatu_TributacaoIPI.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_TributacaoIPI oCobr = new Fatu_TributacaoIPI();
                    oCobr = ObterPor(oFatu_TributacaoIPI);

                    if (!oCobr.Equals(oFatu_TributacaoIPI))
                    {
                        descricao = "Tributação IPI id: " + oFatu_TributacaoIPI.idFatu_TributacaoIPI + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_TributacaoIPI.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_TributacaoIPI.descricao;
                        }
                        if (!oCobr.percTributado.Equals(oFatu_TributacaoIPI.percTributado))
                        {
                            descricao += " %Tributado de " + oCobr.percTributado + " para " + oFatu_TributacaoIPI.percTributado;
                        }
                        if (!oCobr.percIsento.Equals(oFatu_TributacaoIPI.percIsento))
                        {
                            descricao += " %Isento de " + oCobr.percIsento + " para " + oFatu_TributacaoIPI.percIsento;
                        }
                        if (!oCobr.percOutros.Equals(oFatu_TributacaoIPI.percOutros))
                        {
                            descricao += " %Outros de " + oCobr.percOutros + " para " + oFatu_TributacaoIPI.percOutros;
                        }
                        if (!oCobr.aliquotaIPI.Equals(oFatu_TributacaoIPI.aliquotaIPI))
                        {
                            descricao += " % Aliquota IPI de " + oCobr.aliquotaIPI + " para " + oFatu_TributacaoIPI.aliquotaIPI;
                        }
                        if (!oCobr.situacaoIPIEntrada.idfatu_situacaofiscalipi.Equals(oFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi))
                        {
                            descricao += " Sit Fiscal IPI Entrada de " + oCobr.situacaoIPIEntrada.idfatu_situacaofiscalipi+"-"+oCobr.situacaoIPIEntrada.descricao
                                       + " para " + oFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi+"-"+oFatu_TributacaoIPI.situacaoIPIEntrada.descricao;
                        }
                        if (!oCobr.situacaoIPISaida.idfatu_situacaofiscalipi.Equals(oFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi))
                        {
                            descricao += " Sit Fiscal IPI Saida de " + oCobr.situacaoIPISaida.idfatu_situacaofiscalipi + "-" + oCobr.situacaoIPISaida.descricao
                                       + " para " + oFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi + "-" + oFatu_TributacaoIPI.situacaoIPISaida.descricao;
                        }

                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Id Tributação IPI : " + oFatu_TributacaoIPI.idFatu_TributacaoIPI + " - " + oFatu_TributacaoIPI.descricao +
                                " % Tributado : " + oFatu_TributacaoIPI.percTributado + " % Isento : " +oFatu_TributacaoIPI.percIsento +
                                " % Outros : " + oFatu_TributacaoIPI.percOutros + " % Aliquota " + oFatu_TributacaoIPI.aliquotaIPI +
                                " Sit IPI Entrada : " + oFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi + "-"+oFatu_TributacaoIPI.situacaoIPIEntrada.descricao+
                                " Sit IPI Saida : " + oFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi + "-" + oFatu_TributacaoIPI.situacaoIPISaida.descricao +
                                " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {

                    descricao = "Id Tributação IPI : " + oFatu_TributacaoIPI.idFatu_TributacaoIPI + " - " + oFatu_TributacaoIPI.descricao +
                                " % Tributado : " + oFatu_TributacaoIPI.percTributado + " % Isento : " + oFatu_TributacaoIPI.percIsento +
                                " % Outros : " + oFatu_TributacaoIPI.percOutros + " % Aliquota " + oFatu_TributacaoIPI.aliquotaIPI +
                                " Sit IPI Entrada : " + oFatu_TributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi + "-" + oFatu_TributacaoIPI.situacaoIPIEntrada.descricao +
                                " Sit IPI Saida : " + oFatu_TributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi + "-" + oFatu_TributacaoIPI.situacaoIPISaida.descricao +
                                " foi excluído por " + oOcorrencia.usuario.nome;
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
