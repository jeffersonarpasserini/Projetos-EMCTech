using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCObrasModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCObrasDAO
{
    public class Obra_EtapaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_EtapaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Obra_Etapa objObra_Etapa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'obra_etapa'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objObra_Etapa.idobra_etapa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objObra_Etapa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into obra_etapa ( descricao ) values (@descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_Etapa.descricao);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public void Atualizar(Obra_Etapa objObra_Etapa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra_Etapa, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update obra_etapa set descricao = @descricao where idobra_etapa = @idobra_etapa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", objObra_Etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_Etapa.descricao);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public void Excluir(Obra_Etapa objObra_Etapa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objObra_Etapa, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from obra_etapa where idobra_etapa = @idobra_etapa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", objObra_Etapa.idobra_etapa);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public List<Obra_Etapa> LstObra_Etapa()
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_etapa order by idobra_etapa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                
                drCon = Sqlcon.ExecuteReader();

                List<Obra_Etapa> lstEtapa = new List<Obra_Etapa>();

                while (drCon.Read())
                {
                    Obra_Etapa objObra_Etapa = new Obra_Etapa();
                    objObra_Etapa.idobra_etapa = Convert.ToInt32(drCon["idobra_etapa"].ToString());
                    objObra_Etapa.descricao = drCon["descricao"].ToString();

                    lstEtapa.Add(objObra_Etapa);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return lstEtapa;
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

        public DataTable ListaObra_Etapa()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_etapa order by descricao";
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

        public Obra_Etapa ObterPor(Obra_Etapa oObra_Etapa)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_etapa Where idobra_etapa=@idobra_etapa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", oObra_Etapa.idobra_etapa);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Obra_Etapa objObra_Etapa = new Obra_Etapa();
                    objObra_Etapa.idobra_etapa = Convert.ToInt32(drCon["idobra_etapa"].ToString());
                    objObra_Etapa.descricao = drCon["descricao"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objObra_Etapa;
                }

                drCon.Close();
                drCon.Dispose();
                Obra_Etapa objObra_Etapa1 = new Obra_Etapa();
                return objObra_Etapa1;

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

        private void geraOcorrencia(Obra_Etapa oObra_Etapa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oObra_Etapa.idobra_etapa.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra_Etapa oCobr = new Obra_Etapa();
                    oCobr = ObterPor(oObra_Etapa);

                    if (!oCobr.Equals(oObra_Etapa))
                    {
                        descricao = "Etapa da Obra id: " + oObra_Etapa.idobra_etapa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oObra_Etapa.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oObra_Etapa.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Etapa da Obra : " + oObra_Etapa.idobra_etapa + " - " + oObra_Etapa.descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Etapa da Obra : " + oObra_Etapa.idobra_etapa + " - " + oObra_Etapa.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaObraEtapa(int empMaster, int idObraEtapa, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select oe.* from obra_etapa oe ";

                if (idObraEtapa > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " oe.idobra_etapa = @idobraetapa ";
                }

                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " oe.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobraetapa", idObraEtapa);
                Sqlcon.Parameters.AddWithValue("@descricao", "%" + descricao.Trim() + "%");

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
