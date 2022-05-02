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
    public class AutorizadosClienteDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AutorizadosClienteDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(AutorizadosCliente objAutorizadosCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de AutorizadosCliente
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'autorizados'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objAutorizadosCliente.idAutorizado = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objAutorizadosCliente, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Autorizados(codempresa, idpessoa, nome, parentesco ) " +
                                " values (@codempresa, @idpessoa, @nome, @parentesco)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objAutorizadosCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objAutorizadosCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@nome", objAutorizadosCliente.nome);
                Sqlcon.Parameters.AddWithValue("@parentesco", objAutorizadosCliente.parentesco);

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

        public void Atualizar(AutorizadosCliente objAutorizadosCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de AutorizadosCliente
            try
            {
                geraOcorrencia(objAutorizadosCliente, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Autorizados set nome=@nome, parentesco=@parentesco " +
                                " where codempresa = @codempresa and idpessoa = @idpessoa and idautorizado = @codigo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objAutorizadosCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objAutorizadosCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigo", objAutorizadosCliente.idAutorizado);
                Sqlcon.Parameters.AddWithValue("@nome", objAutorizadosCliente.nome);
                Sqlcon.Parameters.AddWithValue("@parentesco", objAutorizadosCliente.parentesco);
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

        public void Excluir(AutorizadosCliente objAutorizadosCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de AutorizadosCliente
            try
            {
                geraOcorrencia(objAutorizadosCliente, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from Autorizados where codempresa = @codempresa and idpessoa = @idpessoa and idautorizado = @codigo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objAutorizadosCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objAutorizadosCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigo", objAutorizadosCliente.idAutorizado);
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

        public DataTable ListaAutorizadosCliente(AutorizadosCliente objAutorizadosCliente)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idautorizado, nome, parentesco " +
                                 " from Autorizados where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objAutorizadosCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objAutorizadosCliente.idPessoa);

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

        public AutorizadosCliente ObterPor(AutorizadosCliente oAutorizadosCliente)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Autorizados Where idautorizado=@idautorizado ";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idautorizado", oAutorizadosCliente.idAutorizado);

                

                AutorizadosCliente objAutorizadosCliente = objAutorizadosCliente = new AutorizadosCliente();

                drCon = Sqlcon.ExecuteReader();
                
                while (drCon.Read())
                {
                    
                    objAutorizadosCliente.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objAutorizadosCliente.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objAutorizadosCliente.idAutorizado = Convert.ToInt32(drCon["idautorizado"].ToString());
                    objAutorizadosCliente.nome = drCon["nome"].ToString();
                    objAutorizadosCliente.parentesco = drCon["parentesco"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                return objAutorizadosCliente;

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

        private void geraOcorrencia(AutorizadosCliente oAutorizado, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oAutorizado.idPessoa.ToString();

                if (flag == "A")
                {

                    AutorizadosCliente oAuto = new AutorizadosCliente();
                    oAuto = ObterPor(oAutorizado);

                    if (!oAuto.Equals(oAutorizado))
                    {
                        descricao = "Autorizado Cliente : " + oAutorizado.idAutorizado + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oAuto.nome.Equals(oAutorizado.nome))
                        {
                            descricao += " Nome de " + oAuto.nome + " para " + oAutorizado.nome;
                        }
                        if (!oAuto.parentesco.Equals(oAutorizado.parentesco))
                        {
                            descricao += " Parentesco de " + oAuto.parentesco + " para " + oAutorizado.parentesco;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Autorizado " + oAutorizado.idAutorizado + " - " + oAutorizado.nome + " - Parentesco : " + oAutorizado.parentesco + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Autorizado " + oAutorizado.idAutorizado + " - " + oAutorizado.nome + " - Parentesco : " + oAutorizado.parentesco + " foi excluído por " + oOcorrencia.usuario.nome;
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
