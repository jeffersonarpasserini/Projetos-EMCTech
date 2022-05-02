using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCEstoqueModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCEstoqueDAO
{
    public class Estq_GrupoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_GrupoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Grupo objEstq_Grupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_grupo'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Grupo.idestq_grupo = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Grupo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into estq_grupo ( descricao, faturamentoentrada, faturamentosaida ) values ( @descricao, @faturamentoentrada, @faturamentosaida )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Grupo.descricao);
                Sqlcon.Parameters.AddWithValue("@faturamentoentrada", objEstq_Grupo.faturamentoentrada);
                Sqlcon.Parameters.AddWithValue("@faturamentosaida", objEstq_Grupo.faturamentosaida);
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

        public void Atualizar(Estq_Grupo objEstq_Grupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Grupo, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update estq_grupo set descricao = @descricao, faturamentoentrada = @faturamentoentrada, faturamentosaida = @faturamentosaida where idestq_grupo = @idestq_grupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_grupo", objEstq_Grupo.idestq_grupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Grupo.descricao);
                Sqlcon.Parameters.AddWithValue("@faturamentoentrada", objEstq_Grupo.faturamentoentrada);
                Sqlcon.Parameters.AddWithValue("@faturamentosaida", objEstq_Grupo.faturamentosaida);
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

        public void Excluir(Estq_Grupo objEstq_Grupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Grupo, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from estq_grupo where idestq_grupo = @idestq_grupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_grupo", objEstq_Grupo.idestq_grupo);

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

        public DataTable ListaEstq_Grupo()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select g.*, if(g.faturamentoentrada = 'S', 'SIM', 'NÃO')as fatuentrada,"+
                                " if(g.faturamentosaida = 'S', 'SIM', 'NÃO') as fatusaida from estq_grupo g order by g.descricao";
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

        public Estq_Grupo ObterPor(Estq_Grupo oEstq_Grupo)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_grupo Where idestq_grupo=@idestq_grupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestq_grupo", oEstq_Grupo.idestq_grupo);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Estq_Grupo objEstq_Grupo = new Estq_Grupo();
                    objEstq_Grupo.idestq_grupo = Convert.ToInt32(drCon["idestq_grupo"].ToString());
                    objEstq_Grupo.descricao = drCon["descricao"].ToString();
                    objEstq_Grupo.faturamentoentrada = drCon["faturamentoentrada"].ToString();
                    objEstq_Grupo.faturamentosaida = drCon["faturamentosaida"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objEstq_Grupo;
                }

                drCon.Close();
                drCon.Dispose();
                Estq_Grupo objEstq_Grupo1 = new Estq_Grupo();
                return objEstq_Grupo1;

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

        private void geraOcorrencia(Estq_Grupo oEstq_Grupo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Grupo.idestq_grupo.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Grupo oCobr = new Estq_Grupo();
                    oCobr = ObterPor(oEstq_Grupo);

                    if (!oCobr.Equals(oEstq_Grupo))
                    {
                        descricao = "Grupo de Estoque id: " + oEstq_Grupo.idestq_grupo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oEstq_Grupo.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oEstq_Grupo.descricao;
                        }
                        if (!oCobr.faturamentoentrada.Equals(oEstq_Grupo.faturamentoentrada))
                        {
                            descricao += " Faturamentona na Entrada de " + oCobr.faturamentoentrada + " para " + oEstq_Grupo.faturamentoentrada;
                        }
                        if (!oCobr.faturamentosaida.Equals(oEstq_Grupo.faturamentosaida))
                        {
                            descricao += " Faturamento na Saída de " + oCobr.faturamentosaida + " para " + oEstq_Grupo.faturamentosaida;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Grupo de Estoque : " + oEstq_Grupo.idestq_grupo + " - " + oEstq_Grupo.descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Grupo de Estoque : " + oEstq_Grupo.idestq_grupo + " - " + oEstq_Grupo.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaGrupo(int empMaster, int idEstqGrupo, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select g.*, if(g.faturamentoentrada = 'S', 'SIM', 'NÃO')as fatuentrada,if(g.faturamentosaida = 'S', 'SIM', 'NÃO') as fatusaida from estq_grupo g ";

                if (idEstqGrupo > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " g.idEstq_grupo = @idestqgrupo ";
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

                    strSQL += " g.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestqgrupo", idEstqGrupo);
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
