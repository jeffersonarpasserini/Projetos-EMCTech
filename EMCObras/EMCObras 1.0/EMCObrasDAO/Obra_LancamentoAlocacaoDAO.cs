using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCObrasModel;

namespace EMCObrasDAO
{
    public class Obra_LancamentoAlocacaoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_LancamentoAlocacaoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
            
        public Boolean Salvar(List<Obra_LancamentoAlocacao> lstAlocacao, int idItem )
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            Boolean verificaAlteracao = false;
            //Grava um novo registro de PagarDocumento
            try
            {
                
                verificaAlteracao =  Salvar(Conexao, transacao, lstAlocacao, idItem);

                transacao.Commit();

                return verificaAlteracao;

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
        public Boolean Salvar(MySqlConnection Conecta, MySqlTransaction transacao, List<Obra_LancamentoAlocacao> lstAlocacao, int idItem)
        {

            //Grava um novo registro de PagarDocumento
            try
            {

                Boolean verificaAlteracao = false;

                foreach(Obra_LancamentoAlocacao oAlocacao in lstAlocacao)
                {

                    if (oAlocacao.status == "I")
                    {
                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                         "where a.table_name = 'obra_lancamento_alocacao'"+
                                         "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        int idAlocacao = 0;
                        while (drCon.Read())
                        {
                            idAlocacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                            oAlocacao.idAlocacao = idAlocacao;
                        }

                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oAlocacao, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into obra_lancamento_alocacao (idobra_lancamento, idobra_lancamentoitem, idempresa, idobra_cronograma, "+
                                                                              "idobra_previsaodespesa, idobra_tarefas, idobra_modulo, " + 
                                                                              "idobra_etapa, percentual, valor ) " +
                                                                    "values (@idobra_lancamento, @idobra_lancamentoitem, @idempresa, @idobra_cronograma, " +
                                                                              "@idobra_previsaodespesa, @idobra_tarefas, @idobra_modulo, " +
                                                                              "@idobra_etapa, @percentual, @valor ) ";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                        Sqlcon.Parameters.AddWithValue("@idobra_lancamento", oAlocacao.idObra_Lancamento);
                        Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", idItem);
                        Sqlcon.Parameters.AddWithValue("@idempresa", oAlocacao.idEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oAlocacao.idObra.idObra_Cronograma);
                        Sqlcon.Parameters.AddWithValue("@idobra_previsaodespesa", oAlocacao.previsaoDespesa.idObra_PrevisaoDespesa);
                        Sqlcon.Parameters.AddWithValue("@idobra_tarefas", oAlocacao.obraTarefa.idobra_tarefas);
                        Sqlcon.Parameters.AddWithValue("@idobra_modulo", oAlocacao.obraTarefa.obra_modulo.idobra_modulo);
                        Sqlcon.Parameters.AddWithValue("@idobra_etapa", oAlocacao.obraTarefa.obra_etapa.idobra_etapa);
                        Sqlcon.Parameters.AddWithValue("@percentual", oAlocacao.percentual);
                        Sqlcon.Parameters.AddWithValue("@valor", oAlocacao.valor);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oAlocacao.status == "A")
                    {
                        geraOcorrencia(oAlocacao, "A");

                        //Monta comando para a gravação do registro
                        String strSQL = "update obra_lancamento_alocacao set idobra_lancamentoitem=@idobra_lancamentoitem, " +
                                                                            "idempresa=@idempresa, idobra_cronograma=@idobra_cronograma, " +
                                                                            "idobra_previsaodespesa=@idobra_previsaodespesa, " + 
                                                                            "idobra_tarefas=@idobra_tarefas, idobra_modulo=@idobra_modulo, " +
                                                                            "idobra_etapa=@idobra_etapa, percentual=@percentual, valor=@valor" +
                                                                 " where idalocacao=@idalocacao";

                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idalocacao", oAlocacao.idAlocacao);
                        Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", oAlocacao.idObra_LancamentoItem);
                        Sqlcon.Parameters.AddWithValue("@idempresa", oAlocacao.idEmpresa);
                        Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oAlocacao.idObra.idObra_Cronograma);
                        Sqlcon.Parameters.AddWithValue("@idobra_previsaodespesa", oAlocacao.previsaoDespesa.idObra_PrevisaoDespesa);
                        Sqlcon.Parameters.AddWithValue("@idobra_tarefas", oAlocacao.obraTarefa.idobra_tarefas);
                        Sqlcon.Parameters.AddWithValue("@idobra_modulo", oAlocacao.obraTarefa.obra_modulo.idobra_modulo);
                        Sqlcon.Parameters.AddWithValue("@idobra_etapa", oAlocacao.obraTarefa.obra_etapa.idobra_etapa);
                        Sqlcon.Parameters.AddWithValue("@percentual", oAlocacao.percentual);
                        Sqlcon.Parameters.AddWithValue("@valor", oAlocacao.valor);

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oAlocacao.status == "E")
                    {
                        geraOcorrencia(oAlocacao, "E");
                        //Monta comando para a gravação do registro
                        String strSQL = "delete from obra_lancamento_alocacao where idalocacao = @idalocacao";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idalocacao", oAlocacao.idAlocacao);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }

                }

                return verificaAlteracao;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable ListaObraLancamentoAlocacao(int idObra_LancamentoItem)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamento_alocacao a where a.idobra_lancamentoitem = @idobra_lancamentoitem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", idObra_LancamentoItem);

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

        public List<Obra_LancamentoAlocacao> listaObraLancamentoAlocacao(int idObra_LancamentoItem)
        {
            try
            {
                List<Obra_LancamentoAlocacao> lstRateio = new List<Obra_LancamentoAlocacao>();
                List<Obra_LancamentoAlocacao> lstRetorno = new List<Obra_LancamentoAlocacao>();

                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamento_alocacao a where a.idobra_lancamentoitem = @idobra_lancamentoitem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", idObra_LancamentoItem);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                
                Boolean Consulta = false;

                while (drCon.Read())
                {
                    Consulta = true;
                    Obra_LancamentoAlocacao oRateio = new Obra_LancamentoAlocacao();
                    oRateio.idAlocacao = EmcResources.cInt(drCon["idalocacao"].ToString());
                    oRateio.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());

                    Obra oObra = new Obra();
                    oObra.idObra_Cronograma = EmcResources.cInt(drCon["idobra_cronograma"].ToString());
                    oRateio.idObra = oObra;


                    oRateio.idObra_LancamentoItem = EmcResources.cInt(drCon["idobra_lancamentoitem"].ToString());
                    oRateio.idObra_Lancamento = EmcResources.cInt(drCon["idobra_lancamento"].ToString());


                    Obra_Tarefa oTarefa = new Obra_Tarefa();
                    oTarefa.idobra_tarefas = EmcResources.cInt(drCon["idobra_tarefas"].ToString());
                    oRateio.obraTarefa = oTarefa;

                    Obra_PrevisaoDespesa oObraDespesa = new Obra_PrevisaoDespesa();
                    oObraDespesa.idObra_PrevisaoDespesa = EmcResources.cInt(drCon["idobra_previsaodespesa"].ToString());
                    oRateio.previsaoDespesa = oObraDespesa;

                    oRateio.percentual = EmcResources.cDouble(drCon["percentual"].ToString());
                    oRateio.valor = EmcResources.cCur(drCon["valor"].ToString());
                    oRateio.status = "";

                    lstRateio.Add(oRateio);
                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    foreach (Obra_LancamentoAlocacao oRat in lstRateio)
                    {

                        ObraDAO oObraDAO = new ObraDAO(parConexao, oOcorrencia, codEmpresa);
                        oRat.idObra = oObraDAO.ObterPor(oRat.idObra);


                        Obra_TarefaDAO oTarefaDAO = new Obra_TarefaDAO(parConexao, oOcorrencia, codEmpresa);
                        oRat.obraTarefa = oTarefaDAO.ObterPor(oRat.obraTarefa);

                        Obra_PrevisaoDespesaDAO oDespesaDAO = new Obra_PrevisaoDespesaDAO(parConexao, oOcorrencia, codEmpresa);
                        oRat.previsaoDespesa = oDespesaDAO.ObterPor(oRat.previsaoDespesa);

                        lstRetorno.Add(oRat);
                    }

                }
                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Obra_LancamentoAlocacao ObterPor(Obra_LancamentoAlocacao oAlocacao)
        {
            bool Consulta = false;

            try
            {
               
               
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamento_alocacao a where a.idalocacao = @idalocacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idalocacao", oAlocacao.idAlocacao);
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Obra_LancamentoAlocacao oRateio = new Obra_LancamentoAlocacao();

                while (drCon.Read())
                {
                    Consulta = true;
                    oRateio.idAlocacao = EmcResources.cInt(drCon["idalocacao"].ToString());
                    oRateio.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());

                    Obra oObra = new Obra();
                    oObra.idObra_Cronograma = EmcResources.cInt(drCon["idobra_cronograma"].ToString());
                    oRateio.idObra = oObra;


                    oRateio.idObra_LancamentoItem = EmcResources.cInt(drCon["idobra_lancamentoitem"].ToString());
                    oRateio.idObra_Lancamento = EmcResources.cInt(drCon["idobra_lancamento"].ToString());

                    Obra_Tarefa oTarefa = new Obra_Tarefa();
                    oTarefa.idobra_tarefas = EmcResources.cInt(drCon["idobra_tarefas"].ToString());
                    oRateio.obraTarefa = oTarefa;

                    Obra_PrevisaoDespesa oObraDespesa = new Obra_PrevisaoDespesa();
                    oObraDespesa.idObra_PrevisaoDespesa = EmcResources.cInt(drCon["idobra_previsaodespesa"].ToString());
                    oRateio.previsaoDespesa = oObraDespesa;

                    oRateio.percentual = EmcResources.cDouble(drCon["percentual"].ToString());
                    oRateio.valor = EmcResources.cCur(drCon["valor"].ToString());
                    oRateio.status = "";

                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {

                    ObraDAO oObraDAO = new ObraDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.idObra = oObraDAO.ObterPor(oRateio.idObra);


                    Obra_TarefaDAO oTarefaDAO = new Obra_TarefaDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.obraTarefa = oTarefaDAO.ObterPor(oRateio.obraTarefa);

                    Obra_PrevisaoDespesaDAO oDespesaDAO = new Obra_PrevisaoDespesaDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.previsaoDespesa = oDespesaDAO.ObterPor(oRateio.previsaoDespesa);
                   
                }
                return oRateio;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(Obra_LancamentoAlocacao oAlocacao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oAlocacao.idObra_Lancamento.ToString();

                if (flag == "A")
                {

                    Obra_LancamentoAlocacao oRat = new Obra_LancamentoAlocacao();
                    oRat = ObterPor(oAlocacao);

                    if (!oRat.Equals(oAlocacao))
                    {
                        descricao = " Lancamento id : " + oAlocacao.idObra_Lancamento + "Item ID: " + oAlocacao.idObra_LancamentoItem + " Alocação id :" + oAlocacao.idObra_LancamentoItem +
                                    " -  foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oRat.percentual.Equals(oAlocacao.percentual))
                        {
                            descricao += " Percentual de Rateio de  " + oRat.percentual + " para " + oAlocacao.percentual;
                        }
                        if (!oRat.valor.Equals(oAlocacao.valor))
                        {
                            descricao += " Valor Rateio de " + oRat.valor + " para " + oAlocacao.valor;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = " Lancamento id : " + oAlocacao.idObra_Lancamento + "Item ID: " + oAlocacao.idObra_LancamentoItem + " Alocação id :" + oAlocacao.idObra_LancamentoItem +
                                " - Id Obra - " + oAlocacao.idObra.idObra_Cronograma +
                                " - Etapa - " + oAlocacao.obraTarefa.obra_etapa.idobra_etapa.ToString() + " - " + oAlocacao.obraTarefa.obra_etapa.descricao +
                                " - Modulo  - " + oAlocacao.obraTarefa.obra_modulo.idobra_modulo.ToString() + " - " + oAlocacao.obraTarefa.obra_modulo.descricao +
                                " - Tarefa  - " + oAlocacao.obraTarefa.idobra_tarefas.ToString() + " - " + oAlocacao.obraTarefa.descricao +
                                " - Percentual - " + oAlocacao.percentual.ToString() + " - Valor : " + oAlocacao.valor + 
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Lancamento id : " + oAlocacao.idObra_Lancamento + "Item ID: " + oAlocacao.idObra_LancamentoItem + " Alocação id :" + oAlocacao.idObra_LancamentoItem +
                                " - Id Obra - " + oAlocacao.idObra.idObra_Cronograma +
                                " - Etapa - " + oAlocacao.obraTarefa.obra_etapa.idobra_etapa.ToString() + " - " + oAlocacao.obraTarefa.obra_etapa.descricao +
                                " - Modulo  - " + oAlocacao.obraTarefa.obra_modulo.idobra_modulo.ToString() + " - " + oAlocacao.obraTarefa.obra_modulo.descricao +
                                " - Tarefa  - " + oAlocacao.obraTarefa.idobra_tarefas.ToString() + " - " + oAlocacao.obraTarefa.descricao +
                                " - Percentual - " + oAlocacao.percentual.ToString() + " - Valor : " + oAlocacao.valor +
                                " foi excluida por " + oOcorrencia.usuario.nome;
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
