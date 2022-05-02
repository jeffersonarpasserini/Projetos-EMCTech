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


namespace EMCEstoqueDAO
{
    public class Estq_Produto_Lote_EstoqueDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_Lote_EstoqueDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Produto_Lote_Estoque oLoteEstoque)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {

                Salvar(oLoteEstoque, Conexao, transacao);
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
        public void Salvar(Estq_Produto_Lote_Estoque oLoteEstoque, MySqlConnection xConexao, MySqlTransaction transacao)
        {
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_produto_lote_estoque'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    oLoteEstoque.idProduto_Lote_Estoque = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oLoteEstoque, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into estq_produto_lote_estoque (almoxarifado_idalmoxarifado, almoxarifado_empresa_idempresa, " + 
                                                                      " produto_lote_idproduto_lote, produto_lote_produto_idproduto, " + 
                                                                      " quantidadeatual, quantidadeanterior, ultimoprecopago, customedio, " + 
                                                                      " vlrestoque_customedio, vlrestoque_ultimoprecopago) " +
                                                               " values (@almoxarifado_idalmoxarifado, @almoxarifado_empresa_idempresa, " +
                                                                      " @produto_lote_idproduto_lote, @produto_lote_produto_idproduto, " +
                                                                      " @quantidadeatual, @quantidadeanterior, @ultimoprecopago, @customedio, " +
                                                                      " @vlrestoque_customedio, @vlrestoque_ultimoprecopago) ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, transacao);
                Sqlcon.Parameters.AddWithValue("@almoxarifado_idalmoxarifado", oLoteEstoque.almoxarifado.idestq_almoxarifado);
                Sqlcon.Parameters.AddWithValue("@almoxarifado_empresa_idempresa", oLoteEstoque.almoxarifado.Empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@produto_lote_idproduto_lote", oLoteEstoque.produtoLote.idEstq_Produto_lote);
                Sqlcon.Parameters.AddWithValue("@produto_lote_produto_idproduto", oLoteEstoque.produtoLote.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@quantidadeatual", oLoteEstoque.quantidadeAtual);
                Sqlcon.Parameters.AddWithValue("@quantidadeanterior", oLoteEstoque.quantidadeAnterior);
                Sqlcon.Parameters.AddWithValue("@ultimoprecopago", oLoteEstoque.ultimoPrecoPago);
                Sqlcon.Parameters.AddWithValue("@customedio", oLoteEstoque.custoMedio);
                Sqlcon.Parameters.AddWithValue("@vlrestoque_customedio", oLoteEstoque.vlrEstoque_CustoMedio);
                Sqlcon.Parameters.AddWithValue("@vlrestoque_ultimoprecopago", oLoteEstoque.vlrEstoque_UltimoPrecoPago);
                Sqlcon.ExecuteNonQuery();

                //OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                //oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Atualizar(Estq_Produto_Lote_Estoque oLoteEstoque)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                Atualizar(oLoteEstoque,Conexao,transacao);
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
        public void Atualizar(Estq_Produto_Lote_Estoque oLoteEstoque, MySqlConnection xConexao, MySqlTransaction transacao)
        {
            //atualiza um registro
            try
            {
                geraOcorrencia(oLoteEstoque, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update estq_produto_lote_estoque set almoxarifado_idalmoxarifado=@almoxarifado_idalmoxarifado, " +
                                                                    " almoxarifado_empresa_idempresa=@almoxarifado_empresa_idempresa, " +
                                                                    " produto_lote_idproduto_lote=@produto_lote_idproduto_lote, " +
                                                                    " produto_lote_produto_idproduto=@produto_lote_produto_idproduto, " +
                                                                    " quantidadeatual=@quantidadeatual, quantidadeanterior=@quantidadeanterior, " +
                                                                    " ultimoprecopago=@ultimoprecopago, customedio=@customedio, " +
                                                                    " vlrestoque_customedio=@vlrestoque_customedio, " +
                                                                    " vlrestoque_ultimoprecopago=@vlrestoque_ultimoprecopago " + 
                                                            " where idestq_produto_lote_estoque=@id ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, transacao);
                Sqlcon.Parameters.AddWithValue("@id", oLoteEstoque.idProduto_Lote_Estoque);
                Sqlcon.Parameters.AddWithValue("@almoxarifado_idalmoxarifado", oLoteEstoque.almoxarifado.idestq_almoxarifado);
                Sqlcon.Parameters.AddWithValue("@almoxarifado_empresa_idempresa", oLoteEstoque.almoxarifado.Empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@produto_lote_idproduto_lote", oLoteEstoque.produtoLote.idEstq_Produto_lote);
                Sqlcon.Parameters.AddWithValue("@produto_lote_produto_idproduto", oLoteEstoque.produtoLote.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@quantidadeatual", oLoteEstoque.quantidadeAtual);
                Sqlcon.Parameters.AddWithValue("@quantidadeanterior", oLoteEstoque.quantidadeAnterior);
                Sqlcon.Parameters.AddWithValue("@ultimoprecopago", oLoteEstoque.ultimoPrecoPago);
                Sqlcon.Parameters.AddWithValue("@customedio", oLoteEstoque.custoMedio);
                Sqlcon.Parameters.AddWithValue("@vlrestoque_customedio", oLoteEstoque.vlrEstoque_CustoMedio);
                Sqlcon.Parameters.AddWithValue("@vlrestoque_ultimoprecopago", oLoteEstoque.vlrEstoque_UltimoPrecoPago);
                Sqlcon.ExecuteNonQuery();

                //OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                //oOcoDAO.Salvar(oOcorrencia, transacao);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto_Lote_Estoque oLoteEstoque)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                Excluir(oLoteEstoque, Conexao, transacao);
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
        public void Excluir(Estq_Produto_Lote_Estoque oLoteEstoque, MySqlConnection xConexao, MySqlTransaction transacao)
        {
            //apaga registro
            try
            {
                geraOcorrencia(oLoteEstoque, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from estq_produto_lote_estoque " +
                                " where idestq_produto_lote_estoque=@id ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, transacao);
                Sqlcon.Parameters.AddWithValue("@id", oLoteEstoque.idProduto_Lote_Estoque);
                Sqlcon.ExecuteNonQuery();

                //OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                //oOcoDAO.Salvar(oOcorrencia, transacao);


            }
            catch (MySqlException erro)
            {
                throw erro;
            }
           

        }

        public List<Estq_Produto_Lote_Estoque> lstEstq_ProdutoLoteEstoque(Estq_Produto_Lote oLote)
        {
            List<Estq_Produto_Lote_Estoque> lstLoteEstoques = new List<Estq_Produto_Lote_Estoque>();
            MySqlDataReader drCon;
            try
            {
                //se informado a chave da tabela
                String strSQL = "select * from estq_produto_lote_estoque Where produto_lote_idproduto_lote=@lote " + 
                                                                         " and produto_lote_produto_idproduto=@produto " + 
                                                                         " and almoxarifado_empresa_idempresa=@empresa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@produto", oLote.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@lote", oLote.idEstq_Produto_lote);
                Sqlcon.Parameters.AddWithValue("@empresa", codEmpresa);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    Estq_Produto_Lote_Estoque objEstq_Produto_Lote_Estoque = new Estq_Produto_Lote_Estoque();
                    objEstq_Produto_Lote_Estoque.idProduto_Lote_Estoque = EmcResources.cInt(drCon["idproduto_lote_estoque"].ToString());
                    objEstq_Produto_Lote_Estoque = ObterPor(objEstq_Produto_Lote_Estoque);
                    lstLoteEstoques.Add(objEstq_Produto_Lote_Estoque);
                }
                drCon.Close();
                drCon.Dispose();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }

            return lstLoteEstoques;
        }

        public DataTable ListaEstq_Produto_Lote_Estoque(Estq_Produto_Lote oLote)
        {

            try
            {
                //se informado a chave da tabela
                String strSQL = "select * from estq_produto_lote_estoque Where produto_lote_idproduto_lote=@lote " +
                                                                         " and produto_lote_produto_idproduto=@produto " +
                                                                         " and almoxarifado_empresa_idempresa=@empresa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@produto", oLote.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@lote", oLote.idEstq_Produto_lote);
                Sqlcon.Parameters.AddWithValue("@empresa", codEmpresa);

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

        public Estq_Produto_Lote_Estoque ObterPor(Estq_Produto_Lote_Estoque oEstoque)
        {
            MySqlDataReader drCon;
            Boolean bControle = false;
            Estq_Produto_Lote_Estoque oLoteEstoque = new Estq_Produto_Lote_Estoque();
            try
            {

                if (oEstoque.idProduto_Lote_Estoque > 0)
                {
                    //se informado a chave da tabela
                    String strSQL = "select * from estq_produto_lote_estoque Where idproduto_lote_estoque = @estoque";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@estoque", oEstoque.idProduto_Lote_Estoque);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //se não informado a chave da tabela, faz a busca por almoxarifado e lote
                    String strSQL = "select * from Estq_Produto_Lote_estoque  Where produto_lote_idproduto_lote=@lote " + 
                                                                         " and produto_lote_produto_idproduto=@produto " + 
                                                                         " and almoxarifado_empresa_idempresa=@empresa " +
                                                                         " and almoxarifado_idalmoxarifado=@almoxarifado ";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@lote", oEstoque.produtoLote.idEstq_Produto_lote);
                    Sqlcon.Parameters.AddWithValue("@produto", oEstoque.produtoLote.Estq_Produto.idestq_produto);
                    Sqlcon.Parameters.AddWithValue("@empresa", oEstoque.almoxarifado.Empresa.idEmpresa);
                    Sqlcon.Parameters.AddWithValue("@almoxarifado", oEstoque.almoxarifado.idestq_almoxarifado);
                    drCon = Sqlcon.ExecuteReader();
                }

                
                while (drCon.Read())
                {
                    bControle = true;
                    /* carrega almoxarifado */
                    Estq_Almoxarifado oAlmoxarifado = new Estq_Almoxarifado();
                    oAlmoxarifado.idestq_almoxarifado = EmcResources.cInt(drCon["almoxarifado_idalmoxarifado"].ToString());
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = EmcResources.cInt(drCon["almoxarifado_empresa_idempresa"].ToString());
                    oAlmoxarifado.Empresa = oEmpresa;
                    oLoteEstoque.almoxarifado = oAlmoxarifado;

                    oLoteEstoque.codEmpresa = EmcResources.cInt(drCon["almoxarifado_empresa_idempresa"].ToString());
                    oLoteEstoque.custoMedio = EmcResources.cCur(drCon["customedio"].ToString());
                    oLoteEstoque.idProduto_Lote_Estoque = EmcResources.cInt(drCon["idproduto_lote_estoque"].ToString());

                    Estq_Produto_Lote oLote = new Estq_Produto_Lote();
                    oLote.idEstq_Produto_lote = EmcResources.cInt(drCon["produto_lote_idproduto_lote"].ToString());
                    Estq_Produto oProduto = new Estq_Produto();
                    oProduto.idestq_produto = EmcResources.cInt(drCon["produto_lote_produto_idproduto"].ToString());
                    oLote.Estq_Produto = oProduto;
                    oLoteEstoque.produtoLote = oLote;

                    oLoteEstoque.quantidadeAnterior = EmcResources.cDouble(drCon["quantidadeanterior"].ToString());
                    oLoteEstoque.quantidadeAtual = EmcResources.cDouble(drCon["quantidadeatual"].ToString());

                    oLoteEstoque.ultimoPrecoPago = EmcResources.cCur(drCon["ultimoprecopago"].ToString());
                    oLoteEstoque.vlrEstoque_CustoMedio = EmcResources.cCur(drCon["vlrestoque_customedio"].ToString());
                    oLoteEstoque.vlrEstoque_UltimoPrecoPago = EmcResources.cCur(drCon["vlrestoque_ultimoprecopago"].ToString());

                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bControle)
                {
                    Estq_AlmoxarifadoDAO oAlmoxarifadoDAO = new Estq_AlmoxarifadoDAO(parConexao,oOcorrencia,codEmpresa);
                    oLoteEstoque.almoxarifado = oAlmoxarifadoDAO.ObterPor(oLoteEstoque.almoxarifado);

                    Estq_Produto_LoteDAO oLoteDAO = new Estq_Produto_LoteDAO(parConexao,oOcorrencia,codEmpresa);
                    oLoteEstoque.produtoLote = oLoteDAO.ObterPor(oLoteEstoque.produtoLote);

                }

                return oLoteEstoque;
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

        private void geraOcorrencia(Estq_Produto_Lote_Estoque oEstoque, string flag)
        {
            try
            {
    

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }


    }
}
