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
    public class Estq_EmbalagemDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_EmbalagemDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Embalagem objEstq_Embalagem)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'estq_embalagem'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Embalagem.idEstq_Embalagem = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Embalagem, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into estq_embalagem (descricao, quantidade, idunidade) values (@descricao,@quantidade,@idunidade)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Embalagem.descricao);
                Sqlcon.Parameters.AddWithValue("@quantidade", objEstq_Embalagem.quantidade);
                Sqlcon.Parameters.AddWithValue("@idunidade", objEstq_Embalagem.unidade.idestq_produto_unidade);
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

        public void Atualizar(Estq_Embalagem objEstq_Embalagem)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Embalagem, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update estq_embalagem set descricao = @descricao, quantidade=@quantidade, idunidade=@idunidade " + 
                                " where idestq_embalagem = @idestq_embalagem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_embalagem", objEstq_Embalagem.idEstq_Embalagem);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Embalagem.descricao);
                Sqlcon.Parameters.AddWithValue("@quantidade", objEstq_Embalagem.quantidade);
                Sqlcon.Parameters.AddWithValue("@idunidade", objEstq_Embalagem.unidade.idestq_produto_unidade);
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

        public void Excluir(Estq_Embalagem objEstq_Embalagem)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Embalagem, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from estq_embalagem where idestq_embalagem = @idestq_embalagem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_embalagem", objEstq_Embalagem.idEstq_Embalagem);

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

        public DataTable ListaEstq_Embalagem()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idestq_embalagem,descricao,u.unidade_abreviatura as abreviacao,quantidade " + 
                                " from estq_embalagem e, estq_produto_unidade u " + 
                                " where u.idestq_produto_unidade = e.idunidade " + 
                                " order by descricao";
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

        public Estq_Embalagem ObterPor(Estq_Embalagem oEstq_Embalagem)
        {
            MySqlDataReader drCon;
            Boolean Controle = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from estq_embalagem Where idestq_embalagem=@idestq_embalagem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestq_embalagem", oEstq_Embalagem.idEstq_Embalagem);


                drCon = Sqlcon.ExecuteReader();

                Estq_Embalagem objEstq_Embalagem = new Estq_Embalagem();
                while (drCon.Read())
                {
                    Controle = true;
                    objEstq_Embalagem.idEstq_Embalagem = Convert.ToInt32(drCon["idestq_embalagem"].ToString());
                    objEstq_Embalagem.descricao = drCon["descricao"].ToString();
                    objEstq_Embalagem.quantidade = EmcResources.cDouble(drCon["quantidade"].ToString());
                    Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
                    oUnidade.idestq_produto_unidade = EmcResources.cInt(drCon["idunidade"].ToString());
                    objEstq_Embalagem.unidade = oUnidade;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Controle)
                {
                    Estq_Produto_UnidadeDAO oUnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Embalagem.unidade = oUnidadeDAO.ObterPor(objEstq_Embalagem.unidade);
                }

                
                return objEstq_Embalagem;

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

        private void geraOcorrencia(Estq_Embalagem oEstq_Embalagem, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Embalagem.idEstq_Embalagem.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Embalagem oCobr = new Estq_Embalagem();
                    oCobr = ObterPor(oEstq_Embalagem);

                    if (!oCobr.Equals(oEstq_Embalagem))
                    {
                        descricao = "Embalagem id: " + oEstq_Embalagem.idEstq_Embalagem + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oEstq_Embalagem.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oEstq_Embalagem.descricao;
                        }
                        if (!oCobr.quantidade.Equals(oEstq_Embalagem.quantidade))
                        {
                            descricao += " Quantidade de " + oCobr.quantidade + " para " + oEstq_Embalagem.quantidade;
                        }

                        if (!oCobr.unidade.idestq_produto_unidade.Equals(oEstq_Embalagem.unidade.idestq_produto_unidade))
                        {
                            descricao += " Unidade de " + oCobr.unidade.unidade_abreviatura + " para " + oEstq_Embalagem.unidade.unidade_abreviatura;
                        }

                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Embalagem id : " + oEstq_Embalagem.idEstq_Embalagem + " - " + oEstq_Embalagem.descricao + 
                                " Quantidade : " + oEstq_Embalagem.quantidade + " Unidade : " + oEstq_Embalagem.unidade.unidade_abreviatura +        
                                " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Embalagem id : " + oEstq_Embalagem.idEstq_Embalagem + " - " + oEstq_Embalagem.descricao +
                                " Quantidade : " + oEstq_Embalagem.quantidade + " Unidade : " + oEstq_Embalagem.unidade.unidade_abreviatura +        
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

        public DataTable pesquisaEmbalagem(int empMaster, int idEmbalagem, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select e.* from estq_embalagem e ";

                if (idEmbalagem > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " e.idestq_embalagem = @idembalagem ";
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

                    strSQL += " e.descricao like @descricao ";
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idembalagem", idEmbalagem);
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
