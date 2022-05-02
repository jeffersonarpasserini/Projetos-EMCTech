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
    public class Estq_Produto_LoteDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_LoteDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {

                Salvar(objEstq_Produto_Lote, Conexao, transacao);
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
        public void Salvar(Estq_Produto_Lote objEstq_Produto_Lote, MySqlConnection XConexao, MySqlTransaction Transacao)
        {
            
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_produto_lote'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, XConexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Produto_Lote.idEstq_Produto_lote = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Produto_Lote, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into estq_produto_lote (Estq_Produto_IdProduto, LoteProduto, DataValidade, idestq_embalagem, descricao ) " + 
                                "values (@Estq_Produto_IdProduto, @LoteProduto, @DataValidade,@embalagem, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, XConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@Estq_Produto_IdProduto", objEstq_Produto_Lote.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@LoteProduto", objEstq_Produto_Lote.loteproduto);
                Sqlcon.Parameters.AddWithValue("@DataValidade", objEstq_Produto_Lote.datavalidade);
                Sqlcon.Parameters.AddWithValue("@embalagem", objEstq_Produto_Lote.embalagem.idEstq_Embalagem);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Produto_Lote.descricao);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Atualizar(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Produto_Lote, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update estq_produto_lote set Estq_Produto_IdProduto = @Estq_Produto_IdProduto, " + 
                                                            " LoteProduto = @LoteProduto, DataValidade = @DataValidade, " + 
                                                            " idestq_embalagem=@embalagem, descricao=@descricao " +
                                                            " where idEstq_Produto_Lote = @idEstq_Produto_Lote";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto_Lote", objEstq_Produto_Lote.idEstq_Produto_lote);
                Sqlcon.Parameters.AddWithValue("@Estq_Produto_IdProduto", objEstq_Produto_Lote.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@LoteProduto", objEstq_Produto_Lote.loteproduto);
                Sqlcon.Parameters.AddWithValue("@DataValidade", objEstq_Produto_Lote.datavalidade);
                Sqlcon.Parameters.AddWithValue("@embalagem", objEstq_Produto_Lote.embalagem.idEstq_Embalagem);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Produto_Lote.descricao);
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

        public void Excluir(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Produto_Lote, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from estq_produto_lote where idestq_produto_lote = @idestq_produto_lote";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_produto_lote", objEstq_Produto_Lote.idEstq_Produto_lote);

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

        public List<Estq_Produto_Lote> lstEstq_ProdutoLote(Estq_Produto oProduto)
        {
            List<Estq_Produto_Lote> lstLotes = new List<Estq_Produto_Lote>();
            List<Estq_Produto_Lote> lstLotes_retorno = new List<Estq_Produto_Lote>();
            MySqlDataReader drCon;
            Boolean bControle = false;
            try
            {

               //se informado a chave da tabela
               String strSQL = "select * from estq_produto_lote Where estq_produto_idproduto=@idproduto";
               MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
               Sqlcon.Parameters.AddWithValue("@idproduto", oProduto.idestq_produto);
               drCon = Sqlcon.ExecuteReader();

               while (drCon.Read())
               {
                   bControle = true;
                   Estq_Produto_Lote objEstq_Produto_Lote = new Estq_Produto_Lote();
                   objEstq_Produto_Lote.idEstq_Produto_lote = EmcResources.cInt(drCon["idestq_produto_lote"].ToString());
                   lstLotes.Add(objEstq_Produto_Lote);
               }
               drCon.Close();
               drCon.Dispose();
               drCon = null;

               
               foreach(Estq_Produto_Lote oLote in lstLotes)
               {
                   Estq_Produto_Lote oLote_Retorno = new Estq_Produto_Lote();
                   oLote_Retorno = ObterPor(oLote);
                   lstLotes_retorno.Add(oLote);
               }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }

            return lstLotes_retorno;
        }

        public DataTable ListaEstq_Produto_Lote(Estq_Produto oProduto)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_produto_lote " +
                                " where estq_produto_idproduto=@idproduto " +
                                " order by DataValidade desc, LoteProduto";
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

        public Estq_Produto_Lote ObterPor(Estq_Produto_Lote oEstq_Produto_Lote)
        {
            MySqlDataReader drCon;
            try
            {

                if (oEstq_Produto_Lote.idEstq_Produto_lote > 0)
                {
                    //se informado a chave da tabela
                    String strSQL = "select * from estq_produto_lote Where idEstq_Produto_Lote = @idEstq_Produto_Lote";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idEstq_Produto_Lote", oEstq_Produto_Lote.idEstq_Produto_lote);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //se não informado a chave da tabela, faz a busca Lote do Produto
                    String strSQL = "select * from Estq_Produto_Lote Where LoteProduto = @LoteProduto";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@LoteProduto", oEstq_Produto_Lote.loteproduto);
                    drCon = Sqlcon.ExecuteReader();
                }

                Estq_Produto_Lote objEstq_Produto_Lote = new Estq_Produto_Lote();

                while (drCon.Read())
                {

                    objEstq_Produto_Lote.idEstq_Produto_lote = Convert.ToInt32(drCon["idEstq_Produto_lote"].ToString());
                    objEstq_Produto_Lote.loteproduto = drCon["LoteProduto"].ToString();
                    objEstq_Produto_Lote.datavalidade = Convert.ToDateTime(drCon["datavalidade"].ToString());
                    objEstq_Produto_Lote.descricao = drCon["descricao"].ToString();

                    Estq_Embalagem oEmbalagem = new Estq_Embalagem();
                    oEmbalagem.idEstq_Embalagem = EmcResources.cInt(drCon["idestq_embalagem"].ToString());

                    //Carregando o produto
                    Estq_Produto oEstq_Produto = new Estq_Produto();
                    oEstq_Produto.idestq_produto = Convert.ToInt32(drCon["Estq_Produto_idProduto"].ToString());
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();

                    //lendo dados do Produto
                    Estq_ProdutoDAO oEstq_ProdutoDAO = new Estq_ProdutoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto_Lote.Estq_Produto = oEstq_ProdutoDAO.ObterProduto(oEstq_Produto);

                    Estq_EmbalagemDAO oEmbalagemDAO = new Estq_EmbalagemDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto_Lote.embalagem = oEmbalagemDAO.ObterPor(oEmbalagem);
                    

                    return objEstq_Produto_Lote;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Produto_Lote objEstq_Produto_Lote1 = new Estq_Produto_Lote();
                return objEstq_Produto_Lote1;

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

        private void geraOcorrencia(Estq_Produto_Lote oEstq_Produto_Lote, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Produto_Lote.idEstq_Produto_lote.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Produto_Lote oCobr = new Estq_Produto_Lote();
                    oCobr = ObterPor(oEstq_Produto_Lote);

                    if (!oCobr.Equals(oEstq_Produto_Lote))
                    {
                        descricao = "Lote de Produto id: " + oEstq_Produto_Lote.idEstq_Produto_lote + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.loteproduto.Equals(oEstq_Produto_Lote.loteproduto))
                        {
                            descricao += " Lote de " + oCobr.loteproduto + " para " + oEstq_Produto_Lote.loteproduto;
                        }
                        if (!oCobr.datavalidade.Equals(oEstq_Produto_Lote.datavalidade))
                        {
                            descricao += " Data da Validade de " + oCobr.datavalidade + " para " + oEstq_Produto_Lote.datavalidade;
                        }
                        if (!oCobr.descricao.Equals(oEstq_Produto_Lote.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oEstq_Produto_Lote.descricao;
                        }
                        if (!oCobr.embalagem.idEstq_Embalagem.Equals(oEstq_Produto_Lote.embalagem.idEstq_Embalagem))
                        {
                            descricao += " Embalagem de " + oCobr.embalagem.idEstq_Embalagem + " - " + oCobr.embalagem.descricao + 
                                         " para " + oEstq_Produto_Lote.embalagem.idEstq_Embalagem + " - " + oEstq_Produto_Lote.embalagem.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Lote de Produto : " + oEstq_Produto_Lote.idEstq_Produto_lote + " - " + oEstq_Produto_Lote.loteproduto + 
                                " Descricao : " + oEstq_Produto_Lote.descricao +
                                " Embalagem : " + oEstq_Produto_Lote.embalagem.idEstq_Embalagem + " - " +oEstq_Produto_Lote.embalagem.descricao +
                                " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Lote de Produto : " + oEstq_Produto_Lote.idEstq_Produto_lote + " - " + oEstq_Produto_Lote.loteproduto +
                                " Descricao : " + oEstq_Produto_Lote.descricao +
                                " Embalagem : " + oEstq_Produto_Lote.embalagem.idEstq_Embalagem + " - " + oEstq_Produto_Lote.embalagem.descricao +
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
    }
}
