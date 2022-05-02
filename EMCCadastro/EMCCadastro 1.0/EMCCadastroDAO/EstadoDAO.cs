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
    public class EstadoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public EstadoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Estado objEstado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de Estado
            try
            {
                geraOcorrencia(objEstado, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into estado (idestado, nome, abreviatura ) values (@idestado, @descricao, @abreviatura)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idestado", objEstado.idEstado);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstado.nome);
                Sqlcon.Parameters.AddWithValue("@abreviatura", objEstado.abreviatura);
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

        public void Atualizar(Estado objEstado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Estado
            try
            {
                geraOcorrencia(objEstado, "A");               
                //Monta comando para a gravação do registro
                String strSQL = "update estado set nome = @descricao, abreviatura=@abreviatura where idestado = @idestado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestado", objEstado.idEstado);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstado.nome);
                Sqlcon.Parameters.AddWithValue("@abreviatura", objEstado.abreviatura);
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

        public void Excluir(Estado objEstado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Estado
            try
            {
                geraOcorrencia(objEstado, "E");               
                //Monta comando para a gravação do registro
                String strSQL = "delete from estado where idEstado = @idEstado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstado", objEstado.idEstado);

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

        public DataTable ListaEstado()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from estado order by nome";
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

        public Estado ObterPor(Estado oEstado)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from estado Where idEstado=@idEstado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idEstado", oEstado.idEstado);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Estado objEstado = new Estado();
                    objEstado.idEstado = drCon["idEstado"].ToString();
                    objEstado.nome = drCon["nome"].ToString();
                    objEstado.abreviatura = drCon["abreviatura"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;
                    return objEstado;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                Estado objEstado1 = new Estado();
                objEstado1.idEstado = "0";
                return objEstado1;

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
      
        private void geraOcorrencia(Estado oEstado, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstado.idEstado.ToString();

                if (flag == "A")
                {

                    Estado oCobr = new Estado();
                    oCobr = ObterPor(oEstado);

                    if (!oCobr.Equals(oEstado))
                    {
                        descricao = "Estado id: " + oEstado.idEstado + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.nome.Equals(oEstado.nome))
                        {
                            descricao += " Nome de " + oCobr.nome + " para " + oEstado.nome;
                        }
                        if (!oCobr.abreviatura.Equals(oEstado.abreviatura))
                        {
                            descricao += " Sigla de " + oCobr.abreviatura + " para " + oEstado.abreviatura;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Estado : " + oEstado.idEstado + " - " + oEstado.nome + " - " + oEstado.abreviatura + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Estado : " + oEstado.idEstado + " - " + oEstado.nome + " - " + oEstado.abreviatura + " foi exluido por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaEstado(int empMaster, int idEstado, string nome, string abrevitura)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select tc.* from estado tc ";


                if (idEstado > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " tc.idestado = @idestado ";
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

                    strSQL += " tc.nome like @nome ";
                }

                if (!String.IsNullOrEmpty(abrevitura.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " tc.abreviatura like @abreviatura ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestado", idEstado);
                Sqlcon.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@abreviatura", "%" + abrevitura.Trim() + "%");

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
