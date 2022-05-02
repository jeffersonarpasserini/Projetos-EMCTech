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
using EMCCadastroModel;
using EMCCadastroDAO;



namespace EMCEstoqueDAO
{
    public class Estq_Produto_FornecedorDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_FornecedorDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Estq_Produto_Fornecedor'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Produto_Fornecedor.idestq_produto_fornecedor = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Produto_Fornecedor, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Estq_Produto_Fornecedor (estq_Produto_idEstq_Produto, fornecedor_CodEmpresa, fornecedor_idPessoa, idproduto_fornecedor) values (@estq_Produto_idEstq_Produto, @fornecedor_CodEmpresa, @fornecedor_idPessoa, @idproduto_fornecedor)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@estq_Produto_idEstq_Produto", objEstq_Produto_Fornecedor.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@fornecedor_CodEmpresa", objEstq_Produto_Fornecedor.Fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idPessoa", objEstq_Produto_Fornecedor.Fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idproduto_fornecedor", objEstq_Produto_Fornecedor.idproduto_fornecedor);
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

        public void Atualizar(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Produto_Fornecedor, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Estq_Produto_Fornecedor set idproduto_fornecedor = @idproduto_fornecedor where idestq_produto_fornecedor = @idestq_produto_fornecedor";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_Produto_fornecedor", objEstq_Produto_Fornecedor.idestq_produto_fornecedor);
                Sqlcon.Parameters.AddWithValue("@idproduto_fornecedor", objEstq_Produto_Fornecedor.idproduto_fornecedor);
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

        public void Excluir(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Produto_Fornecedor, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Estq_Produto_Fornecedor where idEstq_Produto_Fornecedor = @idEstq_Produto_Fornecedor";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto_Fornecedor", objEstq_Produto_Fornecedor.idestq_produto_fornecedor);

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

        public DataTable ListaEstq_Produto_Fornecedor(Estq_Produto oProduto)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select PF.*, PR.Descricao as Produto_Descricao, P.Nome as Fornecedor " + 
                                "from Estq_Produto_Fornecedor PF, Estq_Produto PR, Pessoa P " + 
                                " where PR.idEstq_Produto = PF.Estq_Produto_idEstq_Produto " + 
                                "   and P.CodEmpresa = PF.fornecedor_CodEmpresa " + 
                                "   and P.IdPessoa = PF.fornecedor_IdPessoa " + 
                                "   and PR.idestq_produto=@idproduto " +
                                " order by PF.idEstq_Produto_Fornecedor";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idproduto", oProduto.idestq_produto);

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

        public Estq_Produto_Fornecedor ObterPor(Estq_Produto_Fornecedor oEstq_Produto_Fornecedor)
        {
            MySqlDataReader drCon;
            try
            {

            if (oEstq_Produto_Fornecedor.idestq_produto_fornecedor > 0)
            {
                //se informado a chave da tabela
                String strSQL = "select * from Estq_Produto_Fornecedor Where idEstq_Produto_Fornecedor = @idEstq_Produto_Fornecedor";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto_Fornecedor", oEstq_Produto_Fornecedor.idestq_produto_fornecedor);
                drCon = Sqlcon.ExecuteReader();
            }
            else
            {
                //se não informado a chave da tabela, faz a busca pelo Produto e Fornecedor
                String strSQL = "select * from Estq_Produto_Fornecedor Where Estq_Produto_idEstq_Produto = @Estq_Produto_idEstq_Produto and fornecedor_CodEmpresa = @fornecedor_CodEmpresa and fornecedor_idPessoa = @fornecedor_idPessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@Estq_Produto_idEstq_Produto", oEstq_Produto_Fornecedor.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@fornecedor_CodEmpresa", oEstq_Produto_Fornecedor.Fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idPessoa", oEstq_Produto_Fornecedor.Fornecedor.idPessoa);
                drCon = Sqlcon.ExecuteReader();
            }

                Estq_Produto_Fornecedor objEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();

                while (drCon.Read())
                {

                    objEstq_Produto_Fornecedor.idestq_produto_fornecedor = Convert.ToInt32(drCon["idEstq_Produto_Fornecedor"].ToString());
                    objEstq_Produto_Fornecedor.idproduto_fornecedor = drCon["idproduto_fornecedor"].ToString();

                    //Carregando o produto
                    Estq_Produto oEstq_Produto = new Estq_Produto();
                    oEstq_Produto.idestq_produto = Convert.ToInt32(drCon["estq_Produto_idEstq_Produto"].ToString());
                    //Carregando o fornecedor
                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = Convert.ToInt32(drCon["fornecedor_CodEmpresa"].ToString());
                    oFornecedor.idPessoa = Convert.ToInt32(drCon["fornecedor_idPessoa"].ToString());
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();
                    //lendo dados do Produto
                    Estq_ProdutoDAO oEstq_ProdutoDAO = new Estq_ProdutoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto_Fornecedor.Estq_Produto = oEstq_ProdutoDAO.ObterPor(oEstq_Produto);
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();
                    //lendo os dados do Fornecedor
                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto_Fornecedor.Fornecedor = oFornecedorDAO.ObterPor(oFornecedor);
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();

                    return objEstq_Produto_Fornecedor;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Produto_Fornecedor objEstq_Produto_Fornecedor1 = new Estq_Produto_Fornecedor();
                return objEstq_Produto_Fornecedor1;

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

        private void geraOcorrencia(Estq_Produto_Fornecedor oEstq_Produto_Fornecedor, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Produto_Fornecedor.idestq_produto_fornecedor.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Produto_Fornecedor oCobr = new Estq_Produto_Fornecedor();
                    oCobr = ObterPor(oEstq_Produto_Fornecedor);

                    if (!oCobr.Equals(oEstq_Produto_Fornecedor))
                    {
                        descricao = "Produto Fornecedor id: " + oEstq_Produto_Fornecedor.idestq_produto_fornecedor + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.idproduto_fornecedor.Equals(oEstq_Produto_Fornecedor.idproduto_fornecedor))
                        {
                            descricao += " Código Interno do Fornecedor " + oCobr.idproduto_fornecedor + " para " + oEstq_Produto_Fornecedor.idproduto_fornecedor;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Produto Fornecedor : " + oEstq_Produto_Fornecedor.idestq_produto_fornecedor + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Produto Fornecedor : " + oEstq_Produto_Fornecedor.idestq_produto_fornecedor + " foi excluído por " + oOcorrencia.usuario.nome;
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
