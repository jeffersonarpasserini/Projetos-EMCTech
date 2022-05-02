using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCCadastroDAO
{
    public class IndexadorDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IndexadorDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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



        public void Salvar(Indexador objIndexador)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Indexador
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'indexador'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objIndexador.idIndexador = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objIndexador, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into Indexador (descricao, tipoindexador, simbolo ) values (@descricao,@tipo,@simbolo)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objIndexador.descricao);
                Sqlcon.Parameters.AddWithValue("@tipo", objIndexador.tipoIndexador);
                Sqlcon.Parameters.AddWithValue("@simbolo", objIndexador.simbolo);
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

        public void Atualizar(Indexador objIndexador)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Indexador
            try
            {

                geraOcorrencia(objIndexador, "A");               
                //Monta comando para a gravação do registro
                String strSQL = "update Indexador set descricao=@descricao,tipoindexador=@tipo,simbolo=@simbolo where idIndexador = @idIndexador";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idIndexador", objIndexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@descricao", objIndexador.descricao);
                Sqlcon.Parameters.AddWithValue("@tipo", objIndexador.tipoIndexador);
                Sqlcon.Parameters.AddWithValue("@simbolo", objIndexador.simbolo);
               
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

        public void Excluir(Indexador objIndexador)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Indexador
            try
            {
                geraOcorrencia(objIndexador, "E");               
                //Monta comando para a gravação do registro
                String strSQL = "delete from Indexador where idIndexador = @idIndexador";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idIndexador", objIndexador.idIndexador);

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

        public DataTable pesquisaIndexador(int empMaster, int idIndexador, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select i.* from indexador i ";

                if (idIndexador > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " i.idindexador = @idindexador ";
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

                    strSQL += " i.descricao like @descricao ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idindexador", idIndexador);
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

        public DataTable ListaIndexador()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from Indexador order by descricao";
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

        public Indexador ObterPor(Indexador oIndexador)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from indexador Where idindexador = "+ oIndexador.idIndexador;
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                //Sqlcon.Parameters.AddWithValue("@idIndexador", oIndexador.idIndexador);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    Indexador objIndexador = objIndexador = new Indexador();
                    objIndexador.idIndexador = Convert.ToInt32(drCon["idIndexador"].ToString());
                    objIndexador.descricao = drCon["descricao"].ToString();
                    objIndexador.tipoIndexador = drCon["tipoindexador"].ToString();
                    objIndexador.simbolo = drCon["simbolo"].ToString();
                    drCon.Close();
                    drCon.Dispose();
                    return objIndexador;
                }

                drCon.Close();
                drCon.Dispose();
                Indexador objIndexador1 = new Indexador();
                return objIndexador1;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon=null;
            }

        }

        private void geraOcorrencia(Indexador oIndexador, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oIndexador.idIndexador.ToString();

                if (flag == "A")
                {

                    Indexador oInd = new Indexador();
                    oInd = ObterPor(oIndexador);

                    if (!oInd.Equals(oIndexador))
                    {
                        descricao = "Indexador : " + oIndexador.idIndexador + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oInd.descricao.Equals(oIndexador.descricao))
                        {
                            descricao += " Descricao de " + oInd.descricao + " para " + oIndexador.descricao;
                        }
                        if (!oInd.tipoIndexador.Equals(oIndexador.tipoIndexador))
                        {
                            descricao += " Tipo de " + oInd.tipoIndexador + " para " + oIndexador.tipoIndexador;
                        }
                        if (!oInd.simbolo.Equals(oIndexador.simbolo))
                        {
                            descricao += " Abreviatura de " + oInd.simbolo + " para " + oIndexador.simbolo;
                        }
                        
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Indexador : " + oIndexador.idIndexador + " - " + oIndexador.descricao + oIndexador.tipoIndexador + oIndexador.simbolo + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Indexador : " + oIndexador.idIndexador + " - " + oIndexador.descricao + oIndexador.tipoIndexador + oIndexador.simbolo + " foi excluida por " + oOcorrencia.usuario.nome;
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
