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
    public class Obra_TarefaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_TarefaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql xConexao = new ConectaBancoMySql();
                xConexao.conectar();

                Conexao = xConexao.getConexao();
                parConexao = xConexao;
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

        public void Salvar(Obra_Tarefa objObra_Tarefa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'obra_tarefas'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objObra_Tarefa.idobra_tarefas = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objObra_Tarefa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into obra_tarefas (idobra_etapa, idobra_modulo, descricao) values (@idobra_etapa, @idobra_modulo, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", objObra_Tarefa.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", objObra_Tarefa.obra_modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_Tarefa.descricao);
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

        public void Atualizar(Obra_Tarefa objObra_Tarefa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra_Tarefa, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update obra_tarefas set idobra_etapa = @idobra_etapa, idobra_modulo = @idobra_modulo, descricao = @descricao where idobra_tarefas = @idobra_tarefas";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefas", objObra_Tarefa.idobra_tarefas);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", objObra_Tarefa.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", objObra_Tarefa.obra_modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_Tarefa.descricao);            
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

        public void Excluir(Obra_Tarefa objObra_Tarefa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objObra_Tarefa, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from obra_tarefas where idobra_tarefas = @idobra_tarefas";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefas", objObra_Tarefa.idobra_tarefas);

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
        public List<Obra_Tarefa> LstObra_Tarefa(Obra_Modulo oModulo)
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_tarefas where idobra_modulo=@idobra_modulo order by idobra_tarefas";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", oModulo.idobra_modulo);
                drCon = Sqlcon.ExecuteReader();

                List<Obra_Tarefa> lstTarefa = new List<Obra_Tarefa>();

                while (drCon.Read())
                {
                    Obra_Tarefa objObra_Tarefa = new Obra_Tarefa();

                    objObra_Tarefa.idobra_tarefas = EmcResources.cInt(drCon["idobra_tarefas"].ToString());
                    objObra_Tarefa.obra_modulo = oModulo;
                    objObra_Tarefa.descricao = drCon["descricao"].ToString();

                    lstTarefa.Add(objObra_Tarefa);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return lstTarefa;
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
        public DataTable ListaObra_Tarefa()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select OT.*, OE.descricao as obra_etapa_descricao, OM.descricao as obra_modulo_descricao from obra_tarefas OT, obra_etapa OE, obra_modulo OM where OE.idobra_etapa = OT.idobra_etapa and OM.idobra_modulo = OT.idobra_modulo order by OT.Descricao";
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
        
        public Obra_Tarefa ObterPor(Obra_Tarefa oObra_Tarefa)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select OT.*, OE.descricao as obra_etapa_descricao, OM.descricao as obra_modulo_descricao " + 
                                " from obra_tarefas OT, obra_etapa OE, obra_modulo OM " + 
                                " where OE.idobra_etapa = OT.idobra_etapa " + 
                                  " and OM.idobra_modulo = OT.idobra_modulo " + 
                                  " and OT.idobra_tarefas = @idobra_tarefa " + 
                                  " order by OT.Descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefa", oObra_Tarefa.idobra_tarefas);


                drCon = Sqlcon.ExecuteReader();
                Obra_Tarefa objObra_Tarefa = new Obra_Tarefa();

                while (drCon.Read())
                {

                    objObra_Tarefa.idobra_tarefas = Convert.ToInt32(drCon["idobra_tarefas"].ToString());
                    objObra_Tarefa.descricao = drCon["descricao"].ToString();

                    Obra_Etapa oObra_Etapa = new Obra_Etapa();
                    oObra_Etapa.idobra_etapa = Convert.ToInt32(drCon["idobra_etapa"].ToString());

                    Obra_Modulo oObra_Modulo = new Obra_Modulo();
                    oObra_Modulo.idobra_modulo = Convert.ToInt32(drCon["idobra_modulo"].ToString());


                    drCon.Close();
                    drCon.Dispose();


                    Obra_EtapaDAO oObra_EtapaDAO = new Obra_EtapaDAO(parConexao, oOcorrencia,codEmpresa);
                    objObra_Tarefa.obra_etapa = oObra_EtapaDAO.ObterPor(oObra_Etapa);

                    Obra_ModuloDAO oObra_ModuloDAO = new Obra_ModuloDAO(parConexao, oOcorrencia,codEmpresa);
                    objObra_Tarefa.obra_modulo = oObra_ModuloDAO.ObterPor(oObra_Modulo);

                    return objObra_Tarefa;
                }


                drCon.Close();
                drCon.Dispose();

                Obra_Tarefa objObra_Tarefa1 = new Obra_Tarefa();
                return objObra_Tarefa1;

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

        private void geraOcorrencia(Obra_Tarefa oObra_Tarefa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oObra_Tarefa.idobra_tarefas.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra_Tarefa oCobr = new Obra_Tarefa();
                    oCobr = ObterPor(oObra_Tarefa);

                    if (!oCobr.Equals(oObra_Tarefa))
                    {
                        descricao = "Tarefa da Obra id: " + oObra_Tarefa.idobra_tarefas + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oObra_Tarefa.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oObra_Tarefa.descricao;
                        }
                        if (!oCobr.obra_etapa.idobra_etapa.Equals(oObra_Tarefa.obra_etapa.idobra_etapa))
                        {
                            descricao += " Etapa da Obra de " + oCobr.obra_etapa.idobra_etapa + "-" + oCobr.obra_etapa.descricao + " para " + oObra_Tarefa.obra_etapa.idobra_etapa + "-" + oObra_Tarefa.obra_etapa.descricao;
                        }
                        if (!oCobr.obra_modulo.idobra_modulo.Equals(oObra_Tarefa.obra_modulo.idobra_modulo))
                        {
                            descricao += " Módulo da Obra de " + oCobr.obra_modulo.idobra_modulo + "-" + oCobr.obra_modulo.descricao + " para " + oObra_Tarefa.obra_modulo.idobra_modulo + "-" + oObra_Tarefa.obra_modulo.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Tarefa da Obra : " + oObra_Tarefa.idobra_tarefas + " - " + oObra_Tarefa.descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Tarefa da Obra : " + oObra_Tarefa.idobra_tarefas + " - " + oObra_Tarefa.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaObraTarefa(int empMaster, int idObraTarefa, string descricaoTarefa, int idObraModulo, string descricaoModulo)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select t.*, m.Descricao as Obra_Modulo_Descricao, e.descricao as Obra_Etapa_Descricao" +
                                " from obra_modulo m, obra_etapa e, obra_tarefas t " +
                                " where m.idobra_modulo = t.idobra_modulo" +
                                " and e.idobra_etapa = t.idobra_etapa";

                if (idObraTarefa > 0)
                {

                    strSQL += " and t.idobra_tarefas = @idobratarefa ";

                }
                if (idObraModulo > 0)
                {

                    strSQL += " and t.idobra_modulo = @idobramodulo ";

                }

                if (!String.IsNullOrEmpty(descricaoTarefa.Trim()))
                {

                    strSQL += " and t.descricao like @descricaotarefa ";
                }

                if (!String.IsNullOrEmpty(descricaoModulo.Trim()))
                {

                    strSQL += " and m.descricao like @descricaomodulo ";
                }

                strSQL += " order by t.descricao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobratarefa", idObraTarefa);
                Sqlcon.Parameters.AddWithValue("@idobramodulo", idObraModulo);
                Sqlcon.Parameters.AddWithValue("@descricaotarefa", "%" + descricaoTarefa.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@descricaomodulo", "%" + descricaoModulo.Trim() + "%");

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
