using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
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
    public class Obra_PrevisaoDespesaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_PrevisaoDespesaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void salvar(Obra_PrevisaoDespesa oDespesa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Obra_previsaodespesa'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    oDespesa.idObra_PrevisaoDespesa = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oDespesa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Obra_previsaodespesa (idobra_cronograma, idobra_cronogramaitem, idobra_tarefas, idobra_modulo, idobra_etapa, " +
                                                                "  idestq_produto, quantidade, vlrunitario, vlrdespesa, idcusto_componente, " +
                                                                "  idgrupo_componente, idunidade ) " +
                                                       " values ( @idobra_cronograma, @idobra_cronogramaitem, @idobra_tarefas, @idobra_modulo, @idobra_etapa, " +
                                                               "  @idestq_produto, @quantidade, @vlrunitario, @vlrdespesa, @idcusto_componente, " +
                                                                " @idgrupo_componente, @idunidade ) ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oDespesa.idObra_Cronograma.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@idobra_cronogramaitem", oDespesa.idObra_CronogramaItem.idObra_CronogramaItem);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefas", oDespesa.idObra_Tarefa.idobra_tarefas);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", oDespesa.idObra_Tarefa.obra_modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", oDespesa.idObra_Tarefa.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@idestq_produto", oDespesa.idEstq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@quantidade", oDespesa.quantidade);
                Sqlcon.Parameters.AddWithValue("@vlrunitario", oDespesa.vlrUnitario);
                Sqlcon.Parameters.AddWithValue("@vlrdespesa", oDespesa.vlrDespesa);
                Sqlcon.Parameters.AddWithValue("@idcusto_componente", oDespesa.idCusto_Componente.idcusto_componente);
                Sqlcon.Parameters.AddWithValue("@idgrupo_componente", oDespesa.idCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@idunidade", oDespesa.idUnidade.idestq_produto_unidade);
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

        public void atualizar(Obra_PrevisaoDespesa oDespesa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(oDespesa, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Obra_previsaodespesa set idobra_cronograma=@idobra_cronograma, idobra_cronogramaitem=@idobra_cronogramaitem, idobra_tarefas=@idobra_tarefas, " +
                                                                " idobra_modulo=@idobra_modulo, idobra_etapa=@idobra_etapa, " +
                                                                "  idestq_produto=@idestq_produto, quantidade=@quantidade, vlrunitario=@vlrunitario, " +
                                                                " vlrdespesa=@vlrdespesa, idcusto_componente=@idcusto_componente, " +
                                                                "  idgrupo_componente=@idgrupo_componente, idunidade=@idunidade " +
                                                       " where idobra_previsaodespesa=@item ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@item", oDespesa.idObra_PrevisaoDespesa);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oDespesa.idObra_Cronograma.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@idobra_cronogramaitem", oDespesa.idObra_CronogramaItem.idObra_CronogramaItem);
                Sqlcon.Parameters.AddWithValue("@idobra_tarefas", oDespesa.idObra_Tarefa.idobra_tarefas);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", oDespesa.idObra_Tarefa.obra_modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@idobra_etapa", oDespesa.idObra_Tarefa.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@idestq_produto", oDespesa.idEstq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@quantidade", oDespesa.quantidade);
                Sqlcon.Parameters.AddWithValue("@vlrunitario", oDespesa.vlrUnitario);
                Sqlcon.Parameters.AddWithValue("@vlrdespesa", oDespesa.vlrDespesa);
                Sqlcon.Parameters.AddWithValue("@idcusto_componente", oDespesa.idCusto_Componente.idcusto_componente);
                Sqlcon.Parameters.AddWithValue("@idgrupo_componente", oDespesa.idCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@idunidade", oDespesa.idUnidade.idestq_produto_unidade);
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

        public void excluir(Obra_PrevisaoDespesa oDespesa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(oDespesa, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Obra_previsaodespesa where idObra_previsaodespesa = @item";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@item", oDespesa.idObra_PrevisaoDespesa);

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

        public DataTable listaObra_PrevisaoDespesa(string Tipo, int id)
        {

            try
            {
                
                String strSQL = "select d.idobra_previsaodespesa, d.idobra_tarefas, d.idestq_produto, " +
                                      " t.descricao as descricaotarefa, " +                  
                                      " p.codigoproduto as codigoproduto, u.unidade_abreviatura as descricaounidade, " +
                                      " d.quantidade, d.vlrdespesa, p.descricao as descricaoproduto " + 
                                "from Obra_previsaodespesa d, Obra_Cronograma c, " +
                                    " Obra_CronogramaItem i, Obra_tarefas t, " +
                                    " Estq_Produto p, Estq_Produto_Unidade u " +
                                "Where c.idobra_cronograma = d.idobra_cronograma " +
                                "  and i.idobra_cronogramaitem = d.idobra_cronogramaitem " +
                                "  and t.idobra_tarefas = d.idobra_tarefas " +
                                "  and p.idestq_produto = d.idestq_produto" + 
                                "  and u.idestq_produto_unidade = d.idunidade ";

                if (Tipo == "O")
                {
                    //Monta comando para a gravação do registro
                    strSQL += " and d.idobra_cronograma=@obra";
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL += " and d.idobra_cronogramaitem=@cronogramaitem";
                }
                strSQL += " order by t.descricao, p.codigoproduto ";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@obra", id);
                Sqlcon.Parameters.AddWithValue("@cronogramaitem", id);
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

        public Decimal listaTotalDespesaTarefa(int idObra_CronogramaItem)
        {
            Decimal valorTotalDespesaTarefa = 0;
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idobra_cronogramaitem, sum(vlrdespesa) as valordespesa " + 
                                " from Obra_previsaodespesa where idobra_cronogramaitem=@idcronograma";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcronograma", idObra_CronogramaItem);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    valorTotalDespesaTarefa = EmcResources.cCur(drCon["valordespesa"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                
                return valorTotalDespesaTarefa;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Decimal listaTotalDespesaObra(int idObra)
        {
            Decimal valorTotalDespesaTarefa = 0;
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idobra_cronograma, sum(vlrdespesa) as valordespesa from Obra_previsaodespesa where idobra_cronograma=@idcronograma";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcronograma", idObra);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    valorTotalDespesaTarefa = EmcResources.cCur(drCon["valordespesa"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return valorTotalDespesaTarefa;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Obra_PrevisaoDespesa ObterPor(Obra_PrevisaoDespesa oPrevDespesa)
        {
            MySqlDataReader drCon;
            Boolean bControle = false;
            try
            {
                string strSQL = "";
                

                if (oPrevDespesa.idObra_PrevisaoDespesa > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Obra_previsaodespesa Where idObra_previsaodespesa=@item";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@item", oPrevDespesa.idObra_PrevisaoDespesa);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    strSQL = "select * from Obra_previsaodespesa Where idobra_cronogramaitem=@cronograma and idestq_produto=@produto";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@cronograma", oPrevDespesa.idObra_CronogramaItem.idObra_CronogramaItem);
                    Sqlcon.Parameters.AddWithValue("@produto", oPrevDespesa.idEstq_Produto.idestq_produto);
                    drCon = Sqlcon.ExecuteReader();
                }


                Obra_PrevisaoDespesa oDespesa = new Obra_PrevisaoDespesa();
                while (drCon.Read())
                {
                    bControle = true;
                    Custo_Componente oCustoComponente = new Custo_Componente();
                    Custo_ComponenteGrupo oGrupoCusto = new Custo_ComponenteGrupo();
                    oGrupoCusto.idcusto_componentegrupo = EmcResources.cInt(drCon["idgrupo_componente"].ToString());
                    oCustoComponente.idcusto_componente = EmcResources.cInt(drCon["idcusto_componente"].ToString());
                    oCustoComponente.Custo_ComponenteGrupo = oGrupoCusto;
                    oDespesa.idCusto_Componente = oCustoComponente;

                    Estq_Produto oProduto = new Estq_Produto();
                    oProduto.idestq_produto = EmcResources.cInt(drCon["idestq_produto"].ToString());
                    oDespesa.idEstq_Produto = oProduto;

                    Obra oObra = new Obra();
                    oObra.idObra_Cronograma = EmcResources.cInt(drCon["idobra_cronograma"].ToString());
                    oDespesa.idObra_Cronograma = oObra;

                    Obra_Cronograma oCronograma = new Obra_Cronograma();
                    oCronograma.idObra_CronogramaItem = EmcResources.cInt(drCon["idobra_cronogramaitem"].ToString());
                    oCronograma.idObra_Cronograma = oObra;
                    oDespesa.idObra_CronogramaItem = oCronograma;

                    oDespesa.idObra_PrevisaoDespesa = EmcResources.cInt(drCon["idobra_previsaodespesa"].ToString());

                    Obra_Tarefa oTarefa = new Obra_Tarefa();
                    oTarefa.idobra_tarefas = EmcResources.cInt(drCon["idobra_tarefas"].ToString());
                    oDespesa.idObra_Tarefa = oTarefa;

                    Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
                    oUnidade.idestq_produto_unidade = EmcResources.cInt(drCon["idunidade"].ToString());
                    oDespesa.idUnidade = oUnidade;

                    oDespesa.quantidade =  Convert.ToDouble(drCon["quantidade"].ToString());
                    oDespesa.vlrUnitario = EmcResources.cCur(drCon["vlrunitario"].ToString());
                    oDespesa.vlrDespesa = EmcResources.cCur(drCon["vlrdespesa"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bControle)
                {

                    Custo_ComponenteDAO oCusto = new Custo_ComponenteDAO(parConexao, oOcorrencia, codEmpresa);
                    oDespesa.idCusto_Componente = oCusto.ObterPor(oDespesa.idCusto_Componente);
                    
                    Obra_TarefaDAO oTarefaDAO = new Obra_TarefaDAO(parConexao, oOcorrencia, codEmpresa);
                    oDespesa.idObra_Tarefa = oTarefaDAO.ObterPor(oDespesa.idObra_Tarefa);

                    Estq_ProdutoDAO oProdutoDAO = new Estq_ProdutoDAO(parConexao, oOcorrencia, codEmpresa);
                    oDespesa.idEstq_Produto = oProdutoDAO.ObterPor(oDespesa.idEstq_Produto);

                    Estq_Produto_UnidadeDAO oUnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    oDespesa.idUnidade = oUnidadeDAO.ObterPor(oDespesa.idUnidade);

                    Obra_CronogramaDAO oCronogramaDAO = new Obra_CronogramaDAO(parConexao, oOcorrencia, codEmpresa);
                    oDespesa.idObra_CronogramaItem = oCronogramaDAO.ObterPor(oDespesa.idObra_CronogramaItem);

                    ObraDAO oObraDAO = new ObraDAO(parConexao, oOcorrencia, codEmpresa);
                    oDespesa.idObra_Cronograma = oObraDAO.ObterPor(oDespesa.idObra_Cronograma);
                }

                return oDespesa;
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

        private void geraOcorrencia(Obra_PrevisaoDespesa oDespesa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oDespesa.idObra_CronogramaItem.idObra_CronogramaItem.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra_PrevisaoDespesa oDespesabk = new Obra_PrevisaoDespesa();
                    oDespesabk = ObterPor(oDespesa);

                    if (!oDespesabk.Equals(oDespesa))
                    {
                        descricao = "Despesa id: " + oDespesa.idObra_PrevisaoDespesa +
                                   " Obra : " + oDespesa.idObra_CronogramaItem.idObra_Cronograma.descricao +
                                   " Cronograma Item : " + oDespesa.idObra_CronogramaItem.idObra_CronogramaItem +
                                   " Tarefa : " + oDespesa.idObra_CronogramaItem.obra_tarefa.descricao +
                                   " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oDespesabk.idEstq_Produto.idestq_produto.Equals(oDespesa.idEstq_Produto.idestq_produto))
                        {
                            descricao += " Produto de " + oDespesabk.idEstq_Produto.idestq_produto + " - " + oDespesabk.idEstq_Produto.descricao + 
                                          " para " + oDespesa.idEstq_Produto.idestq_produto + " - " + oDespesabk.idEstq_Produto.descricao;
                        }
                        if (!oDespesabk.quantidade.Equals(oDespesa.quantidade))
                        {
                            descricao += " Quantidade de " + oDespesabk.quantidade.ToString() + " para " + oDespesa.quantidade.ToString();
                        }
                        if (!oDespesabk.vlrDespesa.Equals(oDespesa.vlrDespesa))
                        {
                            descricao += " Valor Despesa de " + oDespesabk.vlrDespesa.ToString() + " para " + oDespesa.vlrDespesa.ToString();
                        }
                        if (!oDespesabk.vlrUnitario.Equals(oDespesa.vlrUnitario))
                        {
                            descricao += " Valor Unitario de " + oDespesabk.vlrUnitario.ToString() + " para " + oDespesa.vlrUnitario.ToString();
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Obra Despesa Item : " + oDespesa.idObra_PrevisaoDespesa + " - " +
                        " Obra : " + oDespesa.idObra_CronogramaItem.idObra_Cronograma.abreviacao + " - " + oDespesa.idObra_CronogramaItem.idObra_Cronograma.descricao +
                        " Etapa : " + oDespesa.idObra_Tarefa.obra_etapa.idobra_etapa + " - " + oDespesa.idObra_Tarefa.obra_etapa.descricao +
                        " Modulo : " + oDespesa.idObra_Tarefa.obra_modulo.idobra_modulo + " - " + oDespesa.idObra_Tarefa.obra_modulo.descricao +
                        " Tarefa : " + oDespesa.idObra_Tarefa.idobra_tarefas + " - " + oDespesa.idObra_Tarefa.descricao +
                        " Produto : " + oDespesa.idEstq_Produto.idestq_produto + " - " + oDespesa.idEstq_Produto.descricao +
                        " Compoenente Custo : " + oDespesa.idCusto_Componente.idcusto_componente + " - " + oDespesa.idCusto_Componente.descricao +
                        " Quantidade Prevista : " + oDespesa.quantidade.ToString() +
                        " Valor Unitario : " + oDespesa.vlrUnitario.ToString() +
                        " Valor Despesa : " + oDespesa.vlrDespesa.ToString() +
                        " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Obra Despesa Item : " + oDespesa.idObra_PrevisaoDespesa + " - " +
                        " Obra : " + oDespesa.idObra_CronogramaItem.idObra_Cronograma.abreviacao + " - " + oDespesa.idObra_CronogramaItem.idObra_Cronograma.descricao +
                        " Etapa : " + oDespesa.idObra_Tarefa.obra_etapa.idobra_etapa + " - " + oDespesa.idObra_Tarefa.obra_etapa.descricao +
                        " Modulo : " + oDespesa.idObra_Tarefa.obra_modulo.idobra_modulo + " - " + oDespesa.idObra_Tarefa.obra_modulo.descricao +
                        " Tarefa : " + oDespesa.idObra_Tarefa.idobra_tarefas + " - " + oDespesa.idObra_Tarefa.descricao +
                        " Produto : " + oDespesa.idEstq_Produto.idestq_produto + " - " + oDespesa.idEstq_Produto.descricao +
                        " Compoenente Custo : " + oDespesa.idCusto_Componente.idcusto_componente + " - " + oDespesa.idCusto_Componente.descricao +
                        " Quantidade Prevista : " + oDespesa.quantidade.ToString() +
                        " Valor Unitario : " + oDespesa.vlrUnitario.ToString() +
                        " Valor Despesa : " + oDespesa.vlrDespesa.ToString() +
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

        public DataTable listaResumoOrcamento(int idObraCronograma)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT * FROM secol.v_obra_etapa_modulo_tarefa"
                              +  " where idObra_cronograma = @idobracronograma "
                              +  " order by idobra_cronograma, idobra_etapa, idobra_modulo, idobra_tarefas";
                    
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobracronograma", idObraCronograma);
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

        public DataTable listaDespesasItens(int idObraCronogramaItem)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "Select pr.codigoproduto as codigoproduto, pr.descricao as produto,"
                              + " u.unidade_abreviatura as unidade,"
                              + " c.descricao as custocomponente, cg.descricao as grupocomponente,"
                              + " p.quantidade, p.vlrunitario, p.vlrdespesa"
                              + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr,"
                              + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                              + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                                + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                                + " and i.idobra_cronograma = p.idobra_cronograma"
                                + " and p.idobra_cronogramaitem = @idobracronogramaitem"
                                + " and m.idobra_modulo = p.idobra_modulo"
                                + " and e.idobra_etapa = p.idobra_etapa"
                                + " and t.idobra_tarefas = p.idobra_tarefas"
                                + " and pr.idestq_produto = p.idestq_produto"
                                + " and c.idcusto_componente = p.idcusto_componente"
                                + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                                + " and u.idestq_produto_unidade = p.idunidade";
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobracronogramaitem", idObraCronogramaItem);
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

        public DataTable listaModuloEtapaObra(int idObraModulo, int idObraEtapa, int idObraCronograma)
        {

            try
            {
                String strSQL = "";      
           
                if (idObraModulo > 0)
                {
                 strSQL = " Select pr.codigoproduto as codigoproduto, pr.descricao as produto,"
                           +" u.unidade_abreviatura as unidade,"
                           +" c.descricao as custocomponente, cg.descricao as grupocomponente, "
                           +" p.quantidade, p.vlrunitario, p.vlrdespesa"
                           +" from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr,"
                           +" custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                           +" obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                           +" where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                           +" and i.idobra_cronograma = p.idobra_cronograma"
                           +" and p.idobra_cronograma = @idobracronograma"
                           +" and p.idobra_etapa = @idobraetapa"
                           +" and p.idobra_modulo = @idobramodulo"
                           +" and m.idobra_modulo = p.idobra_modulo"
                           +" and e.idobra_etapa = p.idobra_etapa"
                           +" and t.idobra_tarefas = p.idobra_tarefas"
                           +" and pr.idestq_produto = p.idestq_produto"
                           +" and c.idcusto_componente = p.idcusto_componente"
                           +" and cg.idcusto_componentegrupo = p.idgrupo_componente"
                           +" and u.idestq_produto_unidade = p.idunidade ";
                }
                else
                if (idObraEtapa > 0)
                {
                    strSQL = " Select pr.codigoproduto as codigoproduto, pr.descricao as produto,"
                              + " u.unidade_abreviatura as unidade,"
                              + " c.descricao as custocomponente, cg.descricao as grupocomponente, "
                              + " p.quantidade, p.vlrunitario, p.vlrdespesa"
                              + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr, "
                              + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                              + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                              + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                              + " and i.idobra_cronograma = p.idobra_cronograma"
                              + " and p.idobra_cronograma = @idobracronograma"
                              + " and p.idobra_etapa = @idobraetapa"
                              + " and m.idobra_modulo = p.idobra_modulo"
                              + " and e.idobra_etapa = p.idobra_etapa"
                              + " and t.idobra_tarefas = p.idobra_tarefas"
                              + " and pr.idestq_produto = p.idestq_produto"
                              + " and c.idcusto_componente = p.idcusto_componente"
                              + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                              + " and u.idestq_produto_unidade = p.idunidade ";
                }
                else
                    if (idObraCronograma > 0)
                    {
                        strSQL = " Select pr.codigoproduto as codigoproduto, pr.descricao as produto,"
                                  + " u.unidade_abreviatura as unidade,"
                                  + " c.descricao as custocomponente, cg.descricao as grupocomponente, "
                                  + " p.quantidade, p.vlrunitario, p.vlrdespesa"
                                  + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr, "
                                  + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                                  + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                                  + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                                  + " and i.idobra_cronograma = p.idobra_cronograma"
                                  + " and p.idobra_cronograma = @idobracronograma"
                                  + " and m.idobra_modulo = p.idobra_modulo"
                                  + " and e.idobra_etapa = p.idobra_etapa"
                                  + " and t.idobra_tarefas = p.idobra_tarefas"
                                  + " and pr.idestq_produto = p.idestq_produto"
                                  + " and c.idcusto_componente = p.idcusto_componente"
                                  + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                                  + " and u.idestq_produto_unidade = p.idunidade ";
                    }

          
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobracronograma", idObraCronograma);
                Sqlcon.Parameters.AddWithValue("@idobraetapa", idObraEtapa);
                Sqlcon.Parameters.AddWithValue("@idobramodulo", idObraModulo);
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
