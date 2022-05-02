using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCLibrary;

namespace EMCSecurityDAO
{
    public class UsuarioEmpresaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public UsuarioEmpresaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public UsuarioEmpresaDAO(ConectaBancoMySql pConexao)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql myConexao = new ConectaBancoMySql();
                Conexao = myConexao.getConexao();
            }
            else
            {
                Conexao = pConexao.getConexao();
            }
        }

        public DataTable ListaEmpresaUsuario(int idUsuario)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select u.idempresa, e.razaosocial from usuarioempresa u, empresa e " + 
                                " where e.idempresa = u.idempresa and idusuario = @idusuario order by idempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);
                
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

        public DataTable ListaUsuarioEmpresa(int idUsuario)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select u.idempresa, e.razaosocial, u.idusuario, p.nome as nomeusuario from usuarioempresa u, empresa e, usuario p " +
                                " where p.idusuario = u.idusuario and e.idempresa = u.idempresa and u.idusuario = @idusuario order by idempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);

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

        public void Salvar(UsuarioEmpresa objUsuarioEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
               
                geraOcorrencia(objUsuarioEmpresa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into usuarioempresa (idUsuario, idempresa) " +
                               " values (@idusuario, @idempresa)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objUsuarioEmpresa.idUsuario);
                Sqlcon.Parameters.AddWithValue("@idempresa", objUsuarioEmpresa.idEmpresa);

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

        public void Atualizar(UsuarioEmpresa objUsuarioEmpresa)
        {
          

        }

        public void Excluir(UsuarioEmpresa objUsuarioEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objUsuarioEmpresa, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from usuarioempresa where idusuario=@idusuario and idempresa=@idempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objUsuarioEmpresa.idUsuario);
                Sqlcon.Parameters.AddWithValue("@idempresa", objUsuarioEmpresa.idEmpresa);

                //abre conexao e executa o comando
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

        public UsuarioEmpresa ObterPor(UsuarioEmpresa objUserEmp)
        {
            MySqlDataReader drCon;
            try
            {

                //Abre Conexão com o banco
                //List<Empresa> lstEmpresas = new List<Empresa>();

                if (!string.IsNullOrEmpty(objUserEmp.idUsuario.ToString()))
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from usuarioempresa Where idusuario=@idusuario and idempresa=@idempresa";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idusuario", objUserEmp.idUsuario);
                    Sqlcon.Parameters.AddWithValue("@idempresa", objUserEmp.idEmpresa);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from usuarioempresa Where idusuario=@id";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@id", objUserEmp.idUsuario);
                    drCon = Sqlcon.ExecuteReader();
                }



                UsuarioEmpresa objUsuarioEmpresa = new UsuarioEmpresa();

                while (drCon.Read())
                {
                    objUsuarioEmpresa.idUsuario = Convert.ToInt32(drCon["idusuario"]);
                    objUsuarioEmpresa.idEmpresa = Convert.ToInt32(drCon["idempresa"]);
                    //objUsuarioEmpresa.validado = true;
                }

                drCon.Close();
                drCon.Dispose();
                return objUsuarioEmpresa;

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

        private void geraOcorrencia(UsuarioEmpresa oUsuarioEmp, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oUsuarioEmp.idUsuario.ToString();

                if (flag == "A")
                {

                    UsuarioEmpresa oUsrEmp = new UsuarioEmpresa();
                    oUsrEmp = ObterPor(oUsuarioEmp);

                    if (!oUsrEmp.Equals(oUsuarioEmp) && flag == "A")
                    {
                        descricao = "Usuário :" + oUsuarioEmp.idUsuario + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        
                        if (!oUsrEmp.idEmpresa.Equals(oUsuarioEmp.idEmpresa))
                        {
                            descricao += " Empresa de : " + oUsrEmp.idEmpresa + " para " + oUsuarioEmp.idEmpresa;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Usuario : " + oUsuarioEmp.idUsuario
                              + " Empresa : " + oUsuarioEmp.idEmpresa +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Usuario : " + oUsuarioEmp.idUsuario
                              + " Empresa : " + oUsuarioEmp.idEmpresa +
                                " foi excluida por " + oOcorrencia.usuario.nome;
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
