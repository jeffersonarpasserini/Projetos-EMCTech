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
    public class Estq_Produto_UnidadeDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_UnidadeDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_produto_unidade'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Produto_Unidade, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into estq_produto_unidade ( unidade_descricao, unidade_abreviatura ) values (@unidade_descricao, @unidade_abreviatura)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@unidade_descricao", objEstq_Produto_Unidade.unidade_descricao);
                Sqlcon.Parameters.AddWithValue("@unidade_abreviatura", objEstq_Produto_Unidade.unidade_abreviatura);
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

        public void Atualizar(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Produto_Unidade, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update estq_produto_unidade set unidade_descricao = @unidade_descricao, unidade_abreviatura = @unidade_abreviatura where idestq_produto_unidade = @idestq_produto_unidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_produto_unidade", objEstq_Produto_Unidade.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidade_descricao", objEstq_Produto_Unidade.unidade_descricao);
                Sqlcon.Parameters.AddWithValue("@unidade_abreviatura", objEstq_Produto_Unidade.unidade_abreviatura);
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

        public void Excluir(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Produto_Unidade, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from estq_produto_unidade where idestq_produto_unidade = @idestq_produto_unidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_produto_unidade", objEstq_Produto_Unidade.idestq_produto_unidade);

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

        public DataTable ListaEstq_Produto_Unidade()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_produto_unidade order by unidade_descricao";
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

        public Estq_Produto_Unidade ObterPor(Estq_Produto_Unidade oEstq_Produto_Unidade)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_produto_unidade Where idestq_produto_unidade = @idestq_produto_unidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestq_produto_unidade", oEstq_Produto_Unidade.idestq_produto_unidade);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Estq_Produto_Unidade objEstq_Produto_Unidade = new Estq_Produto_Unidade();
                    objEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(drCon["idestq_produto_unidade"].ToString());
                    objEstq_Produto_Unidade.unidade_descricao = drCon["unidade_descricao"].ToString();
                    objEstq_Produto_Unidade.unidade_abreviatura = drCon["unidade_abreviatura"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objEstq_Produto_Unidade;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                Estq_Produto_Unidade objEstq_Produto_Unidade1 = new Estq_Produto_Unidade();
                return objEstq_Produto_Unidade1;

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

        private void geraOcorrencia(Estq_Produto_Unidade oEstq_Produto_Unidade, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Produto_Unidade.idestq_produto_unidade.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Produto_Unidade oCobr = new Estq_Produto_Unidade();
                    oCobr = ObterPor(oEstq_Produto_Unidade);

                    if (!oCobr.Equals(oEstq_Produto_Unidade))
                    {
                        descricao = "Unidade de Produto id: " + oEstq_Produto_Unidade.idestq_produto_unidade + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.unidade_descricao.Equals(oEstq_Produto_Unidade.unidade_descricao))
                        {
                            descricao += " Descricao de " + oCobr.unidade_descricao + " para " + oEstq_Produto_Unidade.unidade_descricao;
                        }
                        if (!oCobr.unidade_abreviatura.Equals(oEstq_Produto_Unidade.unidade_abreviatura))
                        {
                            descricao += " Descricao Abreviada de " + oCobr.unidade_abreviatura + " para " + oEstq_Produto_Unidade.unidade_abreviatura;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Unidade de Produto : " + oEstq_Produto_Unidade.idestq_produto_unidade + " - " + oEstq_Produto_Unidade.unidade_descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Unidade de Produto : " + oEstq_Produto_Unidade.idestq_produto_unidade + " - " + oEstq_Produto_Unidade.unidade_descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaProdutoUnidade(int empMaster, int idEstqProdutoUnidade, string descricao, string abreviatura)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select u.* from estq_produto_unidade u ";

                if (idEstqProdutoUnidade > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " u.idestq_produto_unidade = @idestqprodutounidade ";
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

                    strSQL += " u.unidade_descricao like @descricao ";
                }
                else
                if (!String.IsNullOrEmpty(abreviatura.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " u.unidade_abreviatura like @abreviatura ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestqprodutounidade",idEstqProdutoUnidade);
                Sqlcon.Parameters.AddWithValue("@descricao", "%" + descricao.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@abreviatura", "%" + abreviatura.Trim() + "%");

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
