using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using EMCSecurityModel;
using EMCLibrary;


namespace EMCSecurityDAO
{
    public class UsuarioDAO 
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public UsuarioDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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
        public UsuarioDAO(ConectaBancoMySql pConexao)
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

        public Usuario ValidaSenha(Usuario objUsuario)
        {            
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from usuario Where nome = @nome and senha = @senha";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@nome", objUsuario.nome);
                Sqlcon.Parameters.AddWithValue("@senha", objUsuario.senha);

                Usuario objUser = new Usuario();

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    objUser = new Usuario(Convert.ToInt32(drCon["idusuario"]),
                                                      Convert.ToString(drCon["nome"]),
                                                      Convert.ToString(drCon["nomecompleto"]),
                                                      Convert.ToString(drCon["senha"]),
                                                      Convert.ToString(drCon["nivelacesso"]), true);
                }

                drCon.Close();
                drCon.Dispose();    
                return objUser;
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

        public void Salvar(Usuario objUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {

                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'usuario'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    objUsuario.idUsuario = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objUsuario, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into usuario (idUsuario, nome, nomecompleto, senha, nivelusuario, nivelacesso) " + 
                               " values (@idusuario, @nome, @nomecompleto, @senha, @nivelusuario, @nivelacesso)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@nome", objUsuario.nome);
                Sqlcon.Parameters.AddWithValue("@nomecompleto", objUsuario.nomeCompleto);
                Sqlcon.Parameters.AddWithValue("@senha", objUsuario.senha);
                Sqlcon.Parameters.AddWithValue("@nivelusuario", objUsuario.nivelUsuario);
                Sqlcon.Parameters.AddWithValue("@nivelacesso", objUsuario.nivelacesso);
             
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                MenuUsuarioDAO oMenuUsuarioDAO = new MenuUsuarioDAO(parConexao, oOcorrencia,codEmpresa);
                oMenuUsuarioDAO.SalvarNovoUsuario(objUsuario.idUsuario, Conexao, transacao);
                
                

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

        public void Atualizar(Usuario objUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {

                geraOcorrencia(objUsuario, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update usuario set nome = @nome, nomecompleto = @nomecompleto, " + 
                                                  " senha = @senha, nivelusuario=@nivelusuario " + 
                                           " where idusuario = @idusuario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@nome", objUsuario.nome);
                Sqlcon.Parameters.AddWithValue("@nomecompleto", objUsuario.nomeCompleto);
                Sqlcon.Parameters.AddWithValue("@senha", objUsuario.senha);
                Sqlcon.Parameters.AddWithValue("@nivelusuario", objUsuario.nivelUsuario);
                //abre conexao e executa o comando
            
                Sqlcon.ExecuteNonQuery();

                //falta implementar a gravação de empresas
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

        public void Excluir(Usuario objUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objUsuario, "E");

                MenuUsuarioDAO oMenuUsuarioDAO = new MenuUsuarioDAO(parConexao, oOcorrencia,codEmpresa);
                oMenuUsuarioDAO.ExcluirUsuario(objUsuario.idUsuario, Conexao, transacao);

                //Monta comando para a gravação do registro
                String strSQL = "delete from usuario where idusuario = @idusuario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objUsuario.idUsuario);

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

        public DataTable ListaUsuario()
        {
            try
            {               
                //Monta comando para a gravação do registro
                String strSQL = "select * from usuario order by nome";
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

        /// <summary>
        /// Lista de usuário
        /// Desenvolvido por : Kathia em 25/02/2014
        /// </summary>
        /// <param></param>
        /// <returns>
        /// List<Usuario>
        /// </returns>
        public List<Usuario> LstUsuario()
        {
            List<Usuario> lstUsuario = new List<Usuario>();
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from usuario ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.idUsuario = Convert.ToInt32(drCon["idusuario"]);
                    objUsuario.nome = Convert.ToString(drCon["nome"]);
                    objUsuario.nomeCompleto = Convert.ToString(drCon["nomecompleto"]);
                    objUsuario.senha = Convert.ToString(drCon["senha"]);
                    objUsuario.nivelUsuario = Convert.ToInt32(drCon["nivelusuario"]);
                    

                    lstUsuario.Add(objUsuario);
                }

                drCon.Close();
                drCon.Dispose();
                return lstUsuario;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public Usuario ObterPor(Usuario objUser)
        {
            MySqlDataReader drCon;
            try
            {
                //Abre Conexão com o banco
                //List<Empresa> lstEmpresas = new List<Empresa>();
               
                if (!string.IsNullOrEmpty(objUser.nome))
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from usuario Where nome = @nome";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@nome", objUser.nome);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from usuario Where idusuario=@id";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@id", objUser.idUsuario);
                    drCon = Sqlcon.ExecuteReader();
                }
                              

                Usuario objUsuario = new Usuario();

                while (drCon.Read())
                {
                    objUsuario.idUsuario = Convert.ToInt32(drCon["idusuario"]);
                    objUsuario.nome = Convert.ToString(drCon["nome"]);
                    objUsuario.nomeCompleto = Convert.ToString(drCon["nomecompleto"]);
                    objUsuario.senha = Convert.ToString(drCon["senha"]);
                    objUsuario.nivelacesso = Convert.ToString(drCon["nivelacesso"]);
                    objUsuario.nivelUsuario = Convert.ToInt32(drCon["nivelusuario"]);
                    objUsuario.validado = true;
                }

                drCon.Close();
                drCon.Dispose();
                return objUsuario;

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

        private void geraOcorrencia(Usuario oUsuario, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao,oOcorrencia,codEmpresa);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oUsuario.idUsuario.ToString();

                if (flag == "A")
                {

                    Usuario oUsr = new Usuario();
                    oUsr = ObterPor(oUsuario);

                    if (!oUsr.Equals(oUsuario) && flag == "A")
                    {
                        descricao = "Usuário :" + oUsuario.idUsuario + " - " + oUsuario.nome + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oUsr.nomeCompleto.Equals(oUsuario.nomeCompleto))
                        {
                            descricao += " Nome Completo : " + oUsr.nomeCompleto + " para " + oUsuario.nomeCompleto;
                        }
                        if (!oUsr.nivelUsuario.Equals(oUsuario.nivelUsuario))
                        {
                            descricao += " Nivel Usuário de : " + oUsr.nivelUsuario + " para " + oUsuario.nivelUsuario;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Usuario : " + oUsuario.idUsuario
                              + " - Nome : " + oUsuario.nome 
                              + " - Nome completo : " + oUsuario.nomeCompleto 
                              + " Nível Usuário : " + oUsuario.nivelUsuario +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Usuario : " + oUsuario.idUsuario
                              + " - Nome : " + oUsuario.nome
                              + " - Nome completo : " + oUsuario.nomeCompleto
                              + " Nível Usuário : " + oUsuario.nivelUsuario +
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
