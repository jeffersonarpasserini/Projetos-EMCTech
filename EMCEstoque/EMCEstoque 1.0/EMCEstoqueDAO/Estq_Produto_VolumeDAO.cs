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
    public class Estq_Produto_VolumeDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_VolumeDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia,int idEmpresa)
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

        public void Salvar(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_produto_volume'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Produto_Volume.idestq_produto_volume = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Produto_Volume, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Estq_Produto_Volume (estq_Produto_idEstq_Produto, idestq_produto_unidade, fatorconversao) values (@estq_Produto_idEstq_Produto, @idestq_produto_unidade, @fatorconversao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@estq_Produto_idEstq_Produto", objEstq_Produto_Volume.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@idestq_produto_unidade", objEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@fatorconversao", EmcResources.nDec(objEstq_Produto_Volume.fatorconversao));
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

        public void Atualizar(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Produto_Volume, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Estq_Produto_Volume set estq_produto_idEstq_Produto = @estq_produto_idEstq_Produto, idestq_produto_unidade = @idestq_produto_unidade, fatorconversao = @fatorconversao where idestq_produto_volume = @idestq_produto_volume";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@estq_produto_idEstq_Produto", objEstq_Produto_Volume.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@idestq_produto_unidade", objEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@fatorconversao", EmcResources.nDec(objEstq_Produto_Volume.fatorconversao));
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

        public void Excluir(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Produto_Volume, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Estq_Produto_Volume where idEstq_Produto_Volume = @idEstq_Produto_Volume";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto_Volume", objEstq_Produto_Volume.idestq_produto_volume);

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

        public DataTable ListaEstq_Produto_Volume(int idProduto)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select PV.*, P.Descricao as Produto_Descricao, PU.Unidade_Descricao " +
                                " from Estq_Produto_Volume PV, Estq_Produto P, Estq_Produto_Unidade PU " +
                                " where P.idEstq_Produto = PV.Estq_Produto_idEstq_Produto " +
                                  " and PU.IdEstq_Produto_Unidade = PV.idEstq_Produto_Unidade "+
                                  " and PV.estq_produto_idestq_produto=@produto"+
                                  " order by PV.idEstq_Produto_Volume";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@produto", idProduto);


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

        public Estq_Produto_Volume ObterPor(Estq_Produto_Volume oEstq_Produto_Volume)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                if (oEstq_Produto_Volume.idestq_produto_volume > 0)
                {
                    String strSQL = "select * from Estq_Produto_Volume Where idEstq_Produto_Volume=@idEstq_Produto_Volume";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idEstq_Produto_Volume", oEstq_Produto_Volume.idestq_produto_volume);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    String strSQL = "select * from Estq_Produto_Volume Where estq_produto_idestq_produto=@produto "+
                                                                       " and idestq_produto_unidade=@unidade";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@produto", oEstq_Produto_Volume.Estq_Produto.idestq_produto);
                    Sqlcon.Parameters.AddWithValue("@unidade", oEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade);
                    drCon = Sqlcon.ExecuteReader();
                }

                
                Estq_Produto_Volume objEstq_Produto_Volume = new Estq_Produto_Volume();

                while (drCon.Read())
                {

                    objEstq_Produto_Volume.idestq_produto_volume = Convert.ToInt32(drCon["idEstq_Produto_Volume"].ToString());
                    objEstq_Produto_Volume.fatorconversao = drCon["fatorconversao"].ToString();

                    //Carregando o produto
                    Estq_Produto oEstq_Produto = new Estq_Produto();
                    oEstq_Produto.idestq_produto = Convert.ToInt32(drCon["estq_Produto_idEstq_Produto"].ToString());
                    //Carregando a Unidade
                    Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                    oEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(drCon["idestq_produto_unidade"].ToString());
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();
                    //lendo dados do Produto
                    Estq_ProdutoDAO oEstq_ProdutoDAO = new Estq_ProdutoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto_Volume.Estq_Produto = oEstq_ProdutoDAO.ObterPor(oEstq_Produto);
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();
                    //lendo os dados da Menor Unidade de Controle
                    Estq_Produto_UnidadeDAO oEstq_Produto_UnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto_Volume.Estq_Produto_Unidade = oEstq_Produto_UnidadeDAO.ObterPor(oEstq_Produto_Unidade);
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();

                    return objEstq_Produto_Volume;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Produto_Volume objEstq_Produto_Volume1 = new Estq_Produto_Volume();
                return objEstq_Produto_Volume1;

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

        private void geraOcorrencia(Estq_Produto_Volume oEstq_Produto_Volume, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Produto_Volume.idestq_produto_volume.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Produto_Volume oCobr = new Estq_Produto_Volume();
                    oCobr = ObterPor(oEstq_Produto_Volume);

                    if (!oCobr.Equals(oEstq_Produto_Volume))
                    {
                        descricao = "Volume de Produto id: " + oEstq_Produto_Volume.idestq_produto_volume + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.fatorconversao.Equals(oEstq_Produto_Volume.fatorconversao))
                        {
                            descricao += " Fator de Conversão de " + oCobr.fatorconversao + " para " + oEstq_Produto_Volume.fatorconversao;
                        }
                        if (!oCobr.Estq_Produto_Unidade.idestq_produto_unidade.Equals(oEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade))
                        {
                            descricao += " Unidade de Produto de " + oCobr.Estq_Produto_Unidade.idestq_produto_unidade + "-" + oCobr.Estq_Produto_Unidade.unidade_descricao + " para " + oEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade + "-" + oEstq_Produto_Volume.Estq_Produto_Unidade.unidade_descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Volume de Produto : " + oEstq_Produto_Volume.idestq_produto_volume + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Volume de Produto : " + oEstq_Produto_Volume.idestq_produto_volume  + " foi excluído por " + oOcorrencia.usuario.nome;
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
