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
    public class TipoImovelDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoImovelDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(TipoImovel objTipoImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'tipoimovel'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objTipoImovel.idTipoImovel = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objTipoImovel, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into tipoimovel (descricao) values (@descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@descricao", objTipoImovel.descricao);

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

        public void Atualizar(TipoImovel objTipoImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objTipoImovel, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update tipoimovel set descricao = @descricao where idTipoImovel = @idTipoImovel";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoImovel", objTipoImovel.idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@descricao", objTipoImovel.descricao);

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

        public void Excluir(TipoImovel objTipoImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objTipoImovel, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from tipoimovel where idTipoImovel = @idTipoImovel";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoImovel", objTipoImovel.idTipoImovel);

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

        public DataTable pesquisaTipoImovel(int empMaster, int idTipoImovel, string nome)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select b.* from tipoimovel b ";

                if (idTipoImovel > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " b.idtipoimovel = @idtipoimovel ";
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
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
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

        public DataTable ListaTipoImovel()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from tipoimovel order by descricao";
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

        public TipoImovel ObterPor(TipoImovel oTipoImovel)
        {
            MySqlDataReader drCon;
            TipoImovel objRetorno = new TipoImovel();

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oTipoImovel.idTipoImovel > 0)
                {


                    //Monta comando para a gravação do registro
                    strSQL = "select * from tipoimovel Where idtipoimovel = " + oTipoImovel.idTipoImovel + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();


                    while (drCon.Read())
                    {

                        objRetorno.idTipoImovel = EmcResources.cInt(drCon["idtipoimovel"].ToString());
                        objRetorno.descricao = drCon["descricao"].ToString();

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

        private void geraOcorrencia(TipoImovel oTipoImovel, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oTipoImovel.idTipoImovel.ToString();

                if (flag == "A")
                {

                    TipoImovel oTipoIm = new TipoImovel();
                    oTipoIm = ObterPor(oTipoImovel);

                    if (!oTipoIm.Equals(oTipoImovel))
                    {
                        descricao = "Tipo Imóvel id: " + oTipoImovel.idTipoImovel + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oTipoIm.descricao.Equals(oTipoImovel.descricao))
                        {
                            descricao += " Nome de " + oTipoIm.descricao + " para " + oTipoImovel.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Tipo Imóvel : " + oTipoImovel.idTipoImovel + " - " + oTipoImovel.descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Tipo Imóvel : " + oTipoImovel.idTipoImovel + " - " + oTipoImovel.descricao + " foi exluido por " + oOcorrencia.usuario.nome;
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
