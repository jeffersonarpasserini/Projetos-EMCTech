using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCCadastroModel;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCCadastroDAO
{
    public class BancoDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public BancoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
                codEmpresa = idEmpresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = idEmpresa;
            }

        }
        
        public void Salvar(Banco objBanco)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de Empresa
            try
            {

                geraOcorrencia(objBanco, "I");

        
                //Monta comando para a gravação do registro
                String strSQL = "insert into banco (idBanco,Descricao) Values (@id, @descricao)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@id", objBanco.idBanco);
                Sqlcon.Parameters.AddWithValue("@descricao", objBanco.descricao);
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

        public void Atualizar(Banco objBanco)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {

                geraOcorrencia(objBanco, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update banco set descricao = @descricao " +
                                                    " Where idBanco = @id ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@id", objBanco.idBanco);
                Sqlcon.Parameters.AddWithValue("@descricao", objBanco.descricao);
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

        public void Excluir(Banco objBanco)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {

                geraOcorrencia(objBanco, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from banco where idBanco = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@id", objBanco.idBanco);

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

        public DataSet Imprimir()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from banco order by idbanco";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);


                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataSet dtCon = new DataSet();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
   
            }// End Try
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        
        public DataTable pesquisaBanco(int empMaster, int idBanco, string nome)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select b.* from banco b ";

                if (idBanco > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " b.idbanco = @idbanco ";
                }

                if (!String.IsNullOrEmpty(nome.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL +=  " and ";

                    strSQL += " b.descricao like @nome ";
                }

               
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idbanco", idBanco);
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

        public DataTable ListaBanco(Banco oBanco)
        {

            try
            {   
        
                StringBuilder strSQL = new StringBuilder();
                strSQL.Clear();
                
                //Monta comando para a gravação do registro
                strSQL.Append("select * from banco order by");

                if (Convert.ToInt16(oBanco.ordem) == 1)
                {
                    strSQL.Append(" idBanco");
                }
                else
                {
                    strSQL.Append(" Descricao");
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(strSQL.ToString(), Conexao);
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

        public Banco ObterPor(Banco oBanco)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "";
                Banco objRetorno = new Banco();
                //verifica se o atributo está vazio
                if (oBanco.idBanco > 0)
                {


                    //Monta comando para a gravação do registro
                    strSQL = "select * from banco Where idbanco = " + oBanco.idBanco + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();
                    

                    while (drCon.Read())
                    {

                        objRetorno.idBanco = Convert.ToInt32(drCon["idbanco"]);
                        objRetorno.descricao = drCon["descricao"].ToString();

                    }
                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                }
                

                return objRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public bool ExisteCodigo(Banco oBanco)
        {
            MySqlDataReader drCon;
            try
            {

                String strSQL = "";
                //verifica se o atributo está vazio
                if (oBanco.idBanco > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from banco Where idbanco = " +
                             oBanco.idBanco;
                }
                else
                {
                    Exception oErro = new Exception("Informe o código do banco");
                    throw oErro;
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    if (!drCon.IsDBNull(0))
                    {
                        drCon.Close();
                        drCon.Dispose();
                        return true;
                    }
                }
                return false;

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

        private void geraOcorrencia(Banco oBanco, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oBanco.idBanco.ToString();

                if (flag == "A")
                {

                    Banco oBco = new Banco();
                    oBco = ObterPor(oBanco);

                    if (!oBco.Equals(oBanco))
                    {
                        descricao = "Banco " + oBanco.idBanco + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oBco.descricao.Equals(oBanco.descricao))
                        {
                            descricao += " Descricao de " + oBco.descricao + " para " + oBanco.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Banco " + oBanco.idBanco + " - " + oBanco.descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Banco " + oBanco.idBanco + " - " + oBanco.descricao + " foi exluido por " + oOcorrencia.usuario.nome;
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
