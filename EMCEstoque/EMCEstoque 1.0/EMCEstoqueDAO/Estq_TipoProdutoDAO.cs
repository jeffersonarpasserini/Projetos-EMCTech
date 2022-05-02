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
    public class Estq_TipoProdutoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_TipoProdutoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_TipoProduto objEstq_TipoProduto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_tipoproduto'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_TipoProduto, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into estq_tipoproduto (descricao, controlaestoqueminimo, prestacaoservico, familiaobrigatoria) values (@descricao, @controlaestoqueminimo, @prestacaoservico, @familiaobrigatoria)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_TipoProduto.descricao);
                Sqlcon.Parameters.AddWithValue("@controlaestoqueminimo", objEstq_TipoProduto.controlaestoqueminimo);
                Sqlcon.Parameters.AddWithValue("@prestacaoservico", objEstq_TipoProduto.prestacaoservico);
                Sqlcon.Parameters.AddWithValue("@familiaobrigatoria", objEstq_TipoProduto.familiaobrigatoria);
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

        public void Atualizar(Estq_TipoProduto objEstq_TipoProduto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_TipoProduto, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update estq_tipoproduto set descricao = @descricao, controlaestoqueminimo = @controlaestoqueminimo, prestacaoservico = @prestacaoservico, familiaobrigatoria = @familiaobrigatoria where idestq_tipoproduto = @idestq_tipoproduto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_tipoproduto", objEstq_TipoProduto.idestq_tipoproduto);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_TipoProduto.descricao);
                Sqlcon.Parameters.AddWithValue("@controlaestoqueminimo", objEstq_TipoProduto.controlaestoqueminimo);
                Sqlcon.Parameters.AddWithValue("@prestacaoservico", objEstq_TipoProduto.prestacaoservico);
                Sqlcon.Parameters.AddWithValue("@familiaobrigatoria", objEstq_TipoProduto.familiaobrigatoria);
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

        public void Excluir(Estq_TipoProduto objEstq_TipoProduto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_TipoProduto, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from estq_tipoproduto where idestq_tipoproduto = @idestq_tipoproduto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_tipoproduto", objEstq_TipoProduto.idestq_tipoproduto);

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

        public DataTable ListaEstq_TipoProduto()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_tipoproduto order by descricao";
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

        public Estq_TipoProduto ObterPor(Estq_TipoProduto oEstq_TipoProduto)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_tipoproduto Where idestq_tipoproduto=@idestq_tipoproduto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestq_tipoproduto", oEstq_TipoProduto.idestq_tipoproduto);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Estq_TipoProduto objEstq_TipoProduto = new Estq_TipoProduto();
                    objEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(drCon["idestq_tipoproduto"].ToString());
                    objEstq_TipoProduto.descricao = drCon["descricao"].ToString();
                    objEstq_TipoProduto.controlaestoqueminimo = drCon["controlaestoqueminimo"].ToString();
                    objEstq_TipoProduto.prestacaoservico = drCon["prestacaoservico"].ToString();
                    objEstq_TipoProduto.familiaobrigatoria = drCon["familiaobrigatoria"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objEstq_TipoProduto;
                }

                drCon.Close();
                drCon.Dispose();
                Estq_TipoProduto objEstq_TipoProduto1 = new Estq_TipoProduto();
                return objEstq_TipoProduto1;

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

        private void geraOcorrencia(Estq_TipoProduto oEstq_TipoProduto, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_TipoProduto.idestq_tipoproduto.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_TipoProduto oCobr = new Estq_TipoProduto();
                    oCobr = ObterPor(oEstq_TipoProduto);

                    if (!oCobr.Equals(oEstq_TipoProduto))
                    {
                        descricao = "Tipo de Produto id: " + oEstq_TipoProduto.idestq_tipoproduto + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oEstq_TipoProduto.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oEstq_TipoProduto.descricao;
                        }
                        if (!oCobr.controlaestoqueminimo.Equals(oEstq_TipoProduto.controlaestoqueminimo))
                        {
                            descricao += " Controla Estoque Mímino de " + oCobr.controlaestoqueminimo + " para " + oEstq_TipoProduto.controlaestoqueminimo;
                        }
                        if (!oCobr.prestacaoservico.Equals(oEstq_TipoProduto.prestacaoservico))
                        {
                            descricao += " Prestação de Serviço de " + oCobr.prestacaoservico + " para " + oEstq_TipoProduto.prestacaoservico;
                        }
                        if (!oCobr.familiaobrigatoria.Equals(oEstq_TipoProduto.familiaobrigatoria))
                        {
                            descricao += " Família Obrigatória de " + oCobr.familiaobrigatoria + " para " + oEstq_TipoProduto.familiaobrigatoria;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Tipo de Produto : " + oEstq_TipoProduto.idestq_tipoproduto + " - " + oEstq_TipoProduto.descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Tipo de Produto : " + oEstq_TipoProduto.idestq_tipoproduto + " - " + oEstq_TipoProduto.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaTipoProduto(int empMaster, int idEstqTipoProduto, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select tp.* from estq_tipoproduto tp ";

                if (idEstqTipoProduto > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " tp.idestq_tipoproduto = @idestqtipoproduto ";
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

                    strSQL += " tp.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestqtipoproduto", idEstqTipoProduto);
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
