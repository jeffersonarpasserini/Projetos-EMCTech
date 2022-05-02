using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCImobDAO
{
    public class CarteiraImoveisDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CarteiraImoveisDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(CarteiraImoveis objCarteiraImoveis)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'carteiraimoveis'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objCarteiraImoveis.idCarteiraImoveis = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objCarteiraImoveis, "I"); 
                
                //Monta comando para a gravação do registro
                String strSQL = "insert into CarteiraImoveis (descricao) values (@descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objCarteiraImoveis.Descricao);

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

        public void Atualizar(CarteiraImoveis objCarteiraImoveis)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objCarteiraImoveis, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update CarteiraImoveis set descricao = @descricao where idCarteiraImoveis = @idCarteiraImoveis";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idCarteiraImoveis", objCarteiraImoveis.idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@descricao", objCarteiraImoveis.Descricao);

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

        public void Excluir(CarteiraImoveis objCarteiraImoveis)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objCarteiraImoveis, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from CarteiraImoveis where idCarteiraImoveis = @idCarteiraImoveis";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idCarteiraImoveis", objCarteiraImoveis.idCarteiraImoveis);

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

        public DataTable pesquisaCarteiraImoveis(int empMaster, int idCarteiraImoveis, string nome)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select b.* from carteiraimoveis b ";

                if (idCarteiraImoveis > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " b.idcarteiraimoveis = @idcarteiraimoveis ";
                }

                if (!String.IsNullOrEmpty(nome.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " b.descricao like @nome ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");



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

        public DataTable ListaCarteiraImoveis()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {               
                //Monta comando para a gravação do registro
                String strSQL = "select * from CarteiraImoveis order by descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
               
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                daCon.Dispose();
                daCon = null;
            }
        }

        public DataTable dstRelatorio(string sSQL)
        {
            try
            {
                //Monta comando para a gravação do registro
                //String strSQL = "select * from pessoa order by idpessoa";
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

        public CarteiraImoveis ObterPor(CarteiraImoveis oCarteiraImoveis)
        {
            MySqlDataReader drCon;
            CarteiraImoveis objRetorno = new CarteiraImoveis();

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oCarteiraImoveis.idCarteiraImoveis > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from CarteiraImoveis Where idCarteiraImoveis = " + oCarteiraImoveis.idCarteiraImoveis + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);                    

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        objRetorno.idCarteiraImoveis = EmcResources.cInt(drCon["idcarteiraimoveis"].ToString());
                        objRetorno.Descricao = drCon["descricao"].ToString();
                    }
                    drCon.Close();
                    drCon.Dispose();
                }

                return objRetorno;
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

        private void geraOcorrencia(CarteiraImoveis objCarteiraImoveis, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = objCarteiraImoveis.idCarteiraImoveis.ToString();

                if (flag == "A")
                {

                    CarteiraImoveis oCarteiraIm = new CarteiraImoveis();
                    oCarteiraIm = ObterPor(objCarteiraImoveis);

                    if (!oCarteiraIm.Equals(objCarteiraImoveis))
                    {
                        descricao = "Carteira de Imóveis id: " + objCarteiraImoveis.idCarteiraImoveis + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCarteiraIm.Descricao.Equals(objCarteiraImoveis.Descricao))
                        {
                            descricao += " Nome de " + oCarteiraIm.Descricao + " para " + objCarteiraImoveis.Descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Carteira de Imóveis : " + objCarteiraImoveis.idCarteiraImoveis + " - " + objCarteiraImoveis.Descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Carteira de Imóveis : " + objCarteiraImoveis.idCarteiraImoveis + " - " + objCarteiraImoveis.Descricao + " foi exluido por " + oOcorrencia.usuario.nome;
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
