using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCSecurityModel;

namespace EMCSecurityDAO
{
    public class ControleLoginDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        //Ocorrencia oOcorrencia;
     
        public ControleLoginDAO(ConectaBancoMySql pConexao)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
            }

        }

        public Login gravaLogin(Login login)
        {
            MySqlTransaction Transacao;
            Transacao = Conexao.BeginTransaction();

            MySqlDataReader drCon;

            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                String schemaBD = oParamDAO.retParametro(login.idEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'loglogin'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                drCon = Sqlcon2.ExecuteReader();

                int idLogLogin = 0;
                while (drCon.Read())
                {
                    idLogLogin = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                //Monta comando para a gravação do registro
                String strSQL = "insert into loglogin (idusuario, nome, nivelacesso, dtalogin, macaddress, idempresa ) " +
                                " values (@idusuario, @nome, @nivelacesso, @dtalogin, @macaddress, @idempresa )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);

                Sqlcon.Parameters.AddWithValue("@idusuario", login.idUsuario);
                Sqlcon.Parameters.AddWithValue("@nome", login.nome);
                Sqlcon.Parameters.AddWithValue("@nivelacesso", login.nivelAcesso);
                Sqlcon.Parameters.AddWithValue("@dtalogin", login.dtaLogin);
                Sqlcon.Parameters.AddWithValue("@macaddress", login.macAddress);
                Sqlcon.Parameters.AddWithValue("@idempresa", login.idEmpresa);
                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                Transacao.Commit();

                login.seqLogin = idLogLogin;

                return login;

            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
                drCon = null;
            }

        }

        public Boolean baixaLogin(Login login)
        {
            try
            {
                          
               //Monta comando para a gravação do registro
               String strSQL = "update loglogin set dtalogout = @dtalogout " +
                                    " where seqlogin = @seqlogin";
               MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
               Sqlcon.Parameters.AddWithValue("@dtalogout", DateTime.Now);
               Sqlcon.Parameters.AddWithValue("@seqlogin", login.seqLogin);
               //abre conexao e executa o comando
               Sqlcon.ExecuteNonQuery();
               return true;

            }
            catch (MySqlException erro)
            {
                throw erro;
                
            }
        }

    }
}
