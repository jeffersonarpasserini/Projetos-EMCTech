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
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCEstoqueModel;
using EMCEstoqueDAO;

namespace EMCObrasDAO
{
    public class Obra_CronogramaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_CronogramaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void salvar(Obra_Cronograma objObra_Cronograma)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Obra_cronogramaitem'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objObra_Cronograma.idObra_CronogramaItem = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objObra_Cronograma, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Obra_cronogramaitem (idobra_cronograma, dtainicio, dtafinal, idobra_tarefas, idobra_modulo, " +
                                                                " idobra_etapa, nrodiasprevisto, dtainicioprevisto, dtafinalprevisto, " + 
                                                                " custoprevisto, qtdeprevisto, custorealizado, qtderealizado, " +
                                                                " nrodiasrealizado, custounitarioprevisto, custounitariorealizado, " + 
                                                                " atividadecritica, situacao, idunidade ) " +
                                                       " values (@idobra_cronograma,@dtainicio, @dtafinal, @idobra_tarefas, @idobra_modulo, " + 
                                                               " @idobra_etapa, @nrodiasprevisto, @dtainicioprevisto, @dtafinalprevisto, " +
                                                               " @custoprevisto, @qtdeprevisto, @custorealizado, @qtderealizado, " +
                                                               " @nrodiasrealizado, @custounitarioprevisto, @custounitariorealizado, " +
                                                               " @atividadecritica, @situacao, @idunidade ) ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", objObra_Cronograma.idObra_Cronograma.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@dtainicio", objObra_Cronograma.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", objObra_Cronograma.dtaFinal);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefas", objObra_Cronograma.obra_tarefa.idobra_tarefas);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", objObra_Cronograma.obra_tarefa.obra_modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", objObra_Cronograma.obra_tarefa.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@nrodiasprevisto", objObra_Cronograma.nroDiasPrevisto);
                Sqlcon.Parameters.AddWithValue("@dtainicioprevisto", objObra_Cronograma.dtaInicioPrevisto);
                Sqlcon.Parameters.AddWithValue("@dtafinalprevisto", objObra_Cronograma.dtaFinalPreveisto);
                Sqlcon.Parameters.AddWithValue("@custoprevisto", objObra_Cronograma.custoPrevisto);
                Sqlcon.Parameters.AddWithValue("@qtdeprevisto", objObra_Cronograma.qtdePrevisto);
                Sqlcon.Parameters.AddWithValue("@custorealizado", objObra_Cronograma.custoRealizado);
                Sqlcon.Parameters.AddWithValue("@qtderealizado", objObra_Cronograma.qtdeRealizado);
                Sqlcon.Parameters.AddWithValue("@nrodiasrealizado", objObra_Cronograma.nroDiasRealizado);
                Sqlcon.Parameters.AddWithValue("@custounitarioprevisto", objObra_Cronograma.custoUnitarioPrevisto);
                Sqlcon.Parameters.AddWithValue("@custounitariorealizado", objObra_Cronograma.custoUnitarioRealizado);
                Sqlcon.Parameters.AddWithValue("@atividadecritica", objObra_Cronograma.atividadeCritica);
                Sqlcon.Parameters.AddWithValue("@situacao", objObra_Cronograma.situacao);
                Sqlcon.Parameters.AddWithValue("@idunidade", objObra_Cronograma.idUnidadeMedida.idestq_produto_unidade);
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

        public void atualizar(Obra_Cronograma objObra_Cronograma)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra_Cronograma, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Obra_cronogramaitem set idobra_cronograma=@idobra_cronograma, dtainicio=@dtainicio, dtafinal=@dtafinal, " +
                                                              " idobra_tarefas=@idobra_tarefas, idobra_modulo=@idobra_modulo, " +
                                                              " idobra_etapa=@idobra_etapa, nrodiasprevisto=@nrodiasprevisto, " +
                                                              " dtainicioprevisto=@dtainicioprevisto, dtafinalprevisto=@dtafinalprevisto, " +
                                                              " custoprevisto=@custoprevisto, qtdeprevisto=@qtdeprevisto, custorealizado=@custorealizado, " +
                                                              " qtderealizado=@qtderealizado, nrodiasrealizado=@nrodiasrealizado, " +
                                                              " custounitarioprevisto=@custounitarioprevisto, custounitariorealizado=@custounitariorealizado, " +
                                                              " atividadecritica=@atividadecritica, situacao=@situacao, idunidade=@idunidade " +
                                                       " where idobra_cronogramaitem=@item ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@item", objObra_Cronograma.idObra_CronogramaItem);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", objObra_Cronograma.idObra_Cronograma.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@dtainicio", objObra_Cronograma.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", objObra_Cronograma.dtaFinal);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefas", objObra_Cronograma.obra_tarefa.idobra_tarefas);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", objObra_Cronograma.obra_tarefa.obra_modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", objObra_Cronograma.obra_tarefa.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@nrodiasprevisto", objObra_Cronograma.nroDiasPrevisto);
                Sqlcon.Parameters.AddWithValue("@dtainicioprevisto", objObra_Cronograma.dtaInicioPrevisto);
                Sqlcon.Parameters.AddWithValue("@dtafinalprevisto", objObra_Cronograma.dtaFinalPreveisto);
                Sqlcon.Parameters.AddWithValue("@custoprevisto", objObra_Cronograma.custoPrevisto);
                Sqlcon.Parameters.AddWithValue("@qtdeprevisto", objObra_Cronograma.qtdePrevisto);
                Sqlcon.Parameters.AddWithValue("@custorealizado", objObra_Cronograma.custoRealizado);
                Sqlcon.Parameters.AddWithValue("@qtderealizado", objObra_Cronograma.qtdeRealizado);
                Sqlcon.Parameters.AddWithValue("@nrodiasrealizado", objObra_Cronograma.nroDiasRealizado);
                Sqlcon.Parameters.AddWithValue("@custounitarioprevisto", objObra_Cronograma.custoUnitarioPrevisto);
                Sqlcon.Parameters.AddWithValue("@custounitariorealizado", objObra_Cronograma.custoUnitarioRealizado);
                Sqlcon.Parameters.AddWithValue("@atividadecritica", objObra_Cronograma.atividadeCritica);
                Sqlcon.Parameters.AddWithValue("@situacao", objObra_Cronograma.situacao);
                Sqlcon.Parameters.AddWithValue("@idunidade", objObra_Cronograma.idUnidadeMedida.idestq_produto_unidade);
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

        public void excluir(Obra_Cronograma objObra_Cronograma)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objObra_Cronograma, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Obra_Cronogramaitem where idObra_Cronogramaitem = @item";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@item", objObra_Cronograma.idObra_CronogramaItem);

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

        public void atualizarSituacao(Obra_Cronograma objObra_Cronograma)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra_Cronograma, "SIT");
                //Monta comando para a gravação do registro
                String strSQL = "update Obra_cronogramaitem set situacao=@situacao, dtainicio=@dtainicio, dtafinal=@dtafinal " +
                                                       " where idobra_cronogramaitem=@item ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@item", objObra_Cronograma.idObra_CronogramaItem);
                Sqlcon.Parameters.AddWithValue("@situacao", objObra_Cronograma.situacao);
                Sqlcon.Parameters.AddWithValue("@dtainicio", objObra_Cronograma.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", objObra_Cronograma.dtaFinal);
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
        public DataTable listaObra_Cronograma()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select from Obra_Cronograma_cronograma" +
                                " where empresa_idempresa=" + codEmpresa.ToString();
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

        public Obra_Cronograma ObterPor(Obra_Cronograma oObra_Cronograma)
        {
            MySqlDataReader drCon;
            Boolean bControle = false;
            try
            {
                string strSQL = "";
                if (oObra_Cronograma.idObra_CronogramaItem > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Obra_Cronogramaitem Where idObra_Cronogramaitem=@item "+
                             " and idobra_cronograma=@obra";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@item", oObra_Cronograma.idObra_CronogramaItem);
                    Sqlcon.Parameters.AddWithValue("@obra", oObra_Cronograma.idObra_Cronograma.idObra_Cronograma);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Obra_Cronogramaitem Where idobra_cronograma=@obra and idobra_tarefas=@tarefa"; 
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@obra", oObra_Cronograma.idObra_Cronograma.idObra_Cronograma);
                    Sqlcon.Parameters.AddWithValue("@tarefa", oObra_Cronograma.obra_tarefa.idobra_tarefas);

                    drCon = Sqlcon.ExecuteReader();
                }

               

                Obra_Cronograma oCronograma = new Obra_Cronograma();
                while (drCon.Read())
                {
                    bControle = true;

                    oCronograma.atividadeCritica = drCon["atividadecritica"].ToString();
                    oCronograma.custoPrevisto = EmcResources.cCur(drCon["custoprevisto"].ToString());
                    oCronograma.custoRealizado = EmcResources.cCur(drCon["custorealizado"].ToString());
                    oCronograma.custoUnitarioPrevisto = EmcResources.cCur(drCon["custounitarioprevisto"].ToString());
                    oCronograma.custoUnitarioRealizado = EmcResources.cCur(drCon["custounitariorealizado"].ToString());
                    if (drCon["dtafinal"] is DBNull)
                        oCronograma.dtaFinal = DateTime.Today;
                    else
                        oCronograma.dtaFinal = Convert.ToDateTime(drCon["dtafinal"].ToString());
                    oCronograma.dtaFinalPreveisto = Convert.ToDateTime(drCon["dtafinalprevisto"].ToString());

                    if (drCon["dtainicio"] is DBNull)
                        oCronograma.dtaInicio = DateTime.Today;
                    else
                        oCronograma.dtaInicio = Convert.ToDateTime(drCon["dtainicio"].ToString());
                    oCronograma.dtaInicioPrevisto = Convert.ToDateTime(drCon["dtainicioprevisto"].ToString());

                    Obra oObra = new Obra();                    
                    oObra.idObra_Cronograma = EmcResources.cInt(drCon["idobra_cronograma"].ToString());
                    oCronograma.idObra_Cronograma = oObra;

                    oCronograma.idObra_CronogramaItem = EmcResources.cInt(drCon["idobra_cronogramaitem"].ToString());

                    Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
                    oUnidade.idestq_produto_unidade = EmcResources.cInt(drCon["idunidade"].ToString());
                    oCronograma.idUnidadeMedida = oUnidade;

                    oCronograma.nroDiasPrevisto = EmcResources.cInt(drCon["nrodiasprevisto"].ToString());
                    oCronograma.nroDiasRealizado = EmcResources.cInt(drCon["nrodiasrealizado"].ToString());

                    Obra_Tarefa oTarefa = new Obra_Tarefa();
                    oTarefa.idobra_tarefas = EmcResources.cInt(drCon["idobra_tarefas"].ToString());
                    oCronograma.obra_tarefa = oTarefa;

                    oCronograma.qtdePrevisto = EmcResources.cCur(drCon["qtdeprevisto"].ToString());
                    oCronograma.qtdeRealizado = EmcResources.cCur(drCon["qtderealizado"].ToString());
                    oCronograma.situacao = drCon["situacao"].ToString();
                    
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bControle)
                {

                    ObraDAO oObraDAO = new ObraDAO(parConexao, oOcorrencia, codEmpresa);
                    oCronograma.idObra_Cronograma = oObraDAO.ObterPor(oCronograma.idObra_Cronograma);

                    Obra_TarefaDAO oTarefaDAO = new Obra_TarefaDAO(parConexao, oOcorrencia, codEmpresa);
                    oCronograma.obra_tarefa = oTarefaDAO.ObterPor(oCronograma.obra_tarefa);

                    Estq_Produto_UnidadeDAO oUnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    oCronograma.idUnidadeMedida = oUnidadeDAO.ObterPor(oCronograma.idUnidadeMedida);
                }

                return oCronograma;
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

        private void geraOcorrencia(Obra_Cronograma oObra_Cronograma, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oObra_Cronograma.idObra_CronogramaItem.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra_Cronograma oObra_Cronogramabk = new Obra_Cronograma();
                    oObra_Cronogramabk = ObterPor(oObra_Cronograma);

                    if (!oObra_Cronogramabk.Equals(oObra_Cronograma))
                    {
                        descricao = "Etapa da Obra_Cronograma id: " + oObra_Cronograma.idObra_CronogramaItem +
                                   " Obra : " + oObra_Cronograma.idObra_Cronograma.descricao +
                                   " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oObra_Cronogramabk.atividadeCritica.Equals(oObra_Cronograma.atividadeCritica))
                        {
                            descricao += " Atividade Critica de " + oObra_Cronogramabk.atividadeCritica + " para " + oObra_Cronograma.atividadeCritica;
                        }
                        if (!oObra_Cronogramabk.custoPrevisto.Equals(oObra_Cronograma.custoPrevisto))
                        {
                            descricao += " Custo Previsto de " + oObra_Cronogramabk.custoPrevisto + " para " + oObra_Cronograma.custoPrevisto;
                        }
                        if (!oObra_Cronogramabk.custoRealizado.Equals(oObra_Cronograma.custoRealizado))
                        {
                            descricao += " Custo Realizado de " + oObra_Cronogramabk.custoRealizado + " para " + oObra_Cronograma.custoRealizado;
                        }
                        if (!oObra_Cronogramabk.custoUnitarioPrevisto.Equals(oObra_Cronograma.custoUnitarioPrevisto))
                        {
                            descricao += " Custo Unitario Previsto de " + oObra_Cronogramabk.custoUnitarioPrevisto + " para " + oObra_Cronograma.custoUnitarioPrevisto;
                        }
                        if (!oObra_Cronogramabk.custoUnitarioRealizado.Equals(oObra_Cronograma.custoUnitarioRealizado))
                        {
                            descricao += " Custo Unitario Realizado de " + oObra_Cronogramabk.custoUnitarioRealizado + " para " + oObra_Cronograma.custoUnitarioRealizado;
                        }
                        if (!oObra_Cronogramabk.dtaFinal.Equals(oObra_Cronograma.dtaFinal))
                        {
                            descricao += " Data Final de " + oObra_Cronogramabk.dtaFinal + " para " + oObra_Cronograma.dtaFinal;
                        }
                        if (!oObra_Cronogramabk.dtaFinalPreveisto.Equals(oObra_Cronograma.dtaFinalPreveisto))
                        {
                            descricao += " Data Final Previsto de " + oObra_Cronogramabk.dtaFinalPreveisto + " para " + oObra_Cronograma.dtaFinalPreveisto;
                        }
                        if (!oObra_Cronogramabk.dtaInicio.Equals(oObra_Cronograma.dtaInicio))
                        {
                            descricao += " Data Inicio de " + oObra_Cronogramabk.dtaInicio + " para " + oObra_Cronograma.dtaInicio;
                        }
                        if (!oObra_Cronogramabk.dtaInicioPrevisto.Equals(oObra_Cronograma.dtaInicioPrevisto))
                        {
                            descricao += " Data Inicio Prevista de " + oObra_Cronogramabk.dtaInicioPrevisto + " para " + oObra_Cronograma.dtaInicioPrevisto;
                        }
                        if (!oObra_Cronogramabk.idObra_Cronograma.idObra_Cronograma.Equals(oObra_Cronograma.idObra_Cronograma.idObra_Cronograma))
                        {
                            descricao += " Obra de " + oObra_Cronogramabk.idObra_Cronograma.descricao + " para " + oObra_Cronograma.idObra_Cronograma.descricao;
                        }
                        if (!oObra_Cronogramabk.idUnidadeMedida.Equals(oObra_Cronograma.idUnidadeMedida))
                        {
                            descricao += " Unidade de Medida de " + oObra_Cronogramabk.idUnidadeMedida + " para " + oObra_Cronograma.idUnidadeMedida;
                        }
                        if (!oObra_Cronogramabk.nroDiasPrevisto.Equals(oObra_Cronograma.nroDiasPrevisto))
                        {
                            descricao += " Numero de dias previsto de " + oObra_Cronogramabk.nroDiasPrevisto + " para " + oObra_Cronograma.nroDiasPrevisto;
                        }
                        if (!oObra_Cronogramabk.nroDiasRealizado.Equals(oObra_Cronograma.nroDiasRealizado))
                        {
                            descricao += " Numero de dias Realizado de " + oObra_Cronogramabk.nroDiasRealizado + " para " + oObra_Cronograma.nroDiasRealizado;
                        }
                        if (!oObra_Cronogramabk.qtdePrevisto.Equals(oObra_Cronograma.qtdePrevisto))
                        {
                            descricao += " Quantidade Previsto de " + oObra_Cronogramabk.qtdePrevisto + " para " + oObra_Cronograma.qtdePrevisto;
                        }
                        if (!oObra_Cronogramabk.qtdeRealizado.Equals(oObra_Cronograma.qtdeRealizado))
                        {
                            descricao += " Quantidade Realizado de " + oObra_Cronogramabk.qtdeRealizado + " para " + oObra_Cronograma.qtdeRealizado;
                        }
                        if (!oObra_Cronogramabk.situacao.Equals(oObra_Cronograma.situacao))
                        {
                            descricao += " Situacao de " + oObra_Cronogramabk.situacao + " para " + oObra_Cronograma.situacao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Etapa da Obra_Cronograma Item : " + oObra_Cronograma.idObra_CronogramaItem + " - " +
                        " Obra : " + oObra_Cronograma.idObra_Cronograma.abreviacao + " - " + oObra_Cronograma.idObra_Cronograma.descricao +
                        " Etapa : " + oObra_Cronograma.obra_tarefa.obra_etapa.idobra_etapa + " - " + oObra_Cronograma.obra_tarefa.obra_etapa.descricao +
                        " Modulo : " + oObra_Cronograma.obra_tarefa.obra_modulo.idobra_modulo + " - " + oObra_Cronograma.obra_tarefa.obra_modulo.descricao +
                        " Tarefa : " + oObra_Cronograma.obra_tarefa.idobra_tarefas + " - " + oObra_Cronograma.obra_tarefa.descricao +
                        " Data Inicio Previsto : " + oObra_Cronograma.dtaInicioPrevisto.ToShortDateString() +
                        " Data Final Final : " + oObra_Cronograma.dtaFinalPreveisto.ToShortDateString() +
                        " Quantidade Prevista : " + oObra_Cronograma.qtdePrevisto.ToString() +
                        " Custo Previsto : " + oObra_Cronograma.custoPrevisto.ToString() +
                        " Unidade Medida : " + oObra_Cronograma.idUnidadeMedida +
                        " Custo Unitario Previsto : " + oObra_Cronograma.custoUnitarioPrevisto.ToString() +
                        " Atividade Critica : " + oObra_Cronograma.atividadeCritica +
                        " Numero Dias Previsto : " + oObra_Cronograma.nroDiasPrevisto +
                        " Situacao : " + oObra_Cronograma.situacao +
                        " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Etapa da Obra_Cronograma Item : " + oObra_Cronograma.idObra_CronogramaItem + " - " +
                        " Obra : " + oObra_Cronograma.idObra_Cronograma.abreviacao + " - " + oObra_Cronograma.idObra_Cronograma.descricao +
                        " Etapa : " + oObra_Cronograma.obra_tarefa.obra_etapa.idobra_etapa + " - " + oObra_Cronograma.obra_tarefa.obra_etapa.descricao +
                        " Modulo : " + oObra_Cronograma.obra_tarefa.obra_modulo.idobra_modulo + " - " + oObra_Cronograma.obra_tarefa.obra_modulo.descricao +
                        " Tarefa : " + oObra_Cronograma.obra_tarefa.idobra_tarefas + " - " + oObra_Cronograma.obra_tarefa.descricao +
                        " Data Inicio Previsto : " + oObra_Cronograma.dtaInicioPrevisto.ToShortDateString() +
                        " Data Final Final : " + oObra_Cronograma.dtaFinalPreveisto.ToShortDateString() +
                        " Quantidade Prevista : " + oObra_Cronograma.qtdePrevisto.ToString() +
                        " Custo Previsto : " + oObra_Cronograma.custoPrevisto.ToString() +
                        " Unidade Medida : " + oObra_Cronograma.idUnidadeMedida +
                        " Custo Unitario Previsto : " + oObra_Cronograma.custoUnitarioPrevisto.ToString() +
                        " Atividade Critica : " + oObra_Cronograma.atividadeCritica +
                        " Numero Dias Previsto : " + oObra_Cronograma.nroDiasPrevisto +
                        " Situacao : " + oObra_Cronograma.situacao +
                    " foi excluído por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "SIT")
                {
                    descricao = "Etapa da Obra_Cronograma Item : " + oObra_Cronograma.idObra_CronogramaItem + " - " +
                        " Obra : " + oObra_Cronograma.idObra_Cronograma.abreviacao + " - " + oObra_Cronograma.idObra_Cronograma.descricao +
                        " Etapa : " + oObra_Cronograma.obra_tarefa.obra_etapa.idobra_etapa + " - " + oObra_Cronograma.obra_tarefa.obra_etapa.descricao +
                        " Modulo : " + oObra_Cronograma.obra_tarefa.obra_modulo.idobra_modulo + " - " + oObra_Cronograma.obra_tarefa.obra_modulo.descricao +
                        " Tarefa : " + oObra_Cronograma.obra_tarefa.idobra_tarefas + " - " + oObra_Cronograma.obra_tarefa.descricao;

                    if (oObra_Cronograma.situacao == "E")
                    {
                        descricao += "Data Inicio Tarefa : " + oObra_Cronograma.dtaInicio.ToString();
                    }
                    else if (oObra_Cronograma.situacao == "F")
                        descricao += "Data Final Tarefa : " + oObra_Cronograma.dtaInicio.ToString();

                    
                    descricao += " Situacao : " + oObra_Cronograma.situacao +
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

        public DataTable pesquisaObra(int empMaster, string abreviacao, string descricaoObra)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select o.* from obra_cronograma o where empresa_idempresa=@codempresa ";
                                
                if (!String.IsNullOrEmpty(abreviacao.Trim()))
                {
                    
                    strSQL += " and ";

                    strSQL += " o.abreviacao like @abreviacao ";
                }
                if (!String.IsNullOrEmpty(descricaoObra.Trim()))
                {
                    strSQL += " and ";

                    strSQL += " o.descricao like @descricao ";
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@abreviacao", "%" + abreviacao.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@descricao", "%" + descricaoObra.Trim() + "%");

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
