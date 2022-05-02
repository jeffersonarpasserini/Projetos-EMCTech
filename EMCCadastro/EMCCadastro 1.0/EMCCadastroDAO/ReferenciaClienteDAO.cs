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
    public class ReferenciaClienteDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReferenciaClienteDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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



        public void Salvar(ReferenciaCliente objReferenciaCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de ReferenciaCliente
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'referencias'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objReferenciaCliente.idReferencia = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objReferenciaCliente, "I"); 

                //Monta comando para a gravação do registro
                String strSQL = "insert into Referencias (codempresa, idpessoa, idreferencia, tiporeferencia, "+ 
                                                               "nome, contato, telefone01, telefone02, email ) " +
                                " values (@codempresa, @idpessoa, @idreferencia, @tiporeferencia, @nome, @contato, " +
                                        " @telefone01, @telefone02, @email)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objReferenciaCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objReferenciaCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idreferencia", objReferenciaCliente.idReferencia);
                Sqlcon.Parameters.AddWithValue("@tiporeferencia", objReferenciaCliente.tipoReferencia);
                Sqlcon.Parameters.AddWithValue("@nome", objReferenciaCliente.nome);
                Sqlcon.Parameters.AddWithValue("@contato", objReferenciaCliente.contato);
                Sqlcon.Parameters.AddWithValue("@telefone01", objReferenciaCliente.telefone1);
                Sqlcon.Parameters.AddWithValue("@telefone02", objReferenciaCliente.telefone2);
                Sqlcon.Parameters.AddWithValue("@email", objReferenciaCliente.eMail);

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

        public void Atualizar(ReferenciaCliente objReferenciaCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de ReferenciaCliente
            try
            {

                geraOcorrencia(objReferenciaCliente, "A"); 

                //Monta comando para a gravação do registro
                String strSQL = "update Referencias set nome=@nome, contato=@contato, telefone01=@telefone01," +
                                                   "telefone02=@telefone02,email=@email, tiporeferencia=@tiporeferencia " +
                                " where codempresa = @codempresa and idpessoa = @idpessoa and idreferencia = @idreferencia";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objReferenciaCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objReferenciaCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idreferencia", objReferenciaCliente.idReferencia);
                Sqlcon.Parameters.AddWithValue("@tiporeferencia", objReferenciaCliente.tipoReferencia);
                Sqlcon.Parameters.AddWithValue("@nome", objReferenciaCliente.nome);
                Sqlcon.Parameters.AddWithValue("@contato", objReferenciaCliente.contato);
                Sqlcon.Parameters.AddWithValue("@telefone01", objReferenciaCliente.telefone1);
                Sqlcon.Parameters.AddWithValue("@telefone02", objReferenciaCliente.telefone2);
                Sqlcon.Parameters.AddWithValue("@email", objReferenciaCliente.eMail);
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

        public void Excluir(ReferenciaCliente objReferenciaCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de ReferenciaCliente
            try
            {
                geraOcorrencia(objReferenciaCliente, "E");
 
                //Monta comando para a gravação do registro
                String strSQL = "delete from referencias where codempresa = @codempresa and idpessoa = @idpessoa and idreferencia = @codigo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objReferenciaCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objReferenciaCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigo", objReferenciaCliente.idReferencia);
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

        public DataTable ListaReferenciaCliente(ReferenciaCliente objReferenciaCliente)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idreferencia, tiporeferencia, nome, contato, telefone01, telefone02, email " +
                                 " from Referencias where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objReferenciaCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objReferenciaCliente.idPessoa);

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

        public ReferenciaCliente ObterPor(ReferenciaCliente oReferenciaCliente)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Referencias Where codempresa = @codempresa and idpessoa = @idpessoa and idreferencia = @idreferencia";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oReferenciaCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oReferenciaCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idreferencia", oReferenciaCliente.idReferencia);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    ReferenciaCliente objReferenciaCliente = objReferenciaCliente = new ReferenciaCliente();
                    objReferenciaCliente.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objReferenciaCliente.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objReferenciaCliente.idReferencia = Convert.ToInt32(drCon["idreferencia"].ToString());
                    objReferenciaCliente.tipoReferencia = drCon["tiporeferencia"].ToString();
                    objReferenciaCliente.nome = drCon["nome"].ToString();
                    objReferenciaCliente.contato = drCon["contato"].ToString();
                    objReferenciaCliente.telefone1 = drCon["telefone01"].ToString();
                    objReferenciaCliente.telefone2 = drCon["telefone02"].ToString();
                    objReferenciaCliente.eMail = drCon["email"].ToString();
                    drCon.Close();
                    drCon.Dispose();
                    return objReferenciaCliente;
                }

                drCon.Close();
                drCon.Dispose();
                ReferenciaCliente objReferenciaCliente1 = new ReferenciaCliente();
                return objReferenciaCliente1;

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

        private void geraOcorrencia(ReferenciaCliente oReferencia, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oReferencia.idPessoa.ToString();

                if (flag == "A")
                {

                    ReferenciaCliente oRef = new ReferenciaCliente();
                    oRef = ObterPor(oReferencia);

                    if (!oRef.Equals(oReferencia))
                    {
                        descricao = "Referencia : id :" + oReferencia.idReferencia + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oRef.contato.Equals(oReferencia.contato))
                        {
                            descricao += " Contato de " + oRef.contato + " para " + oReferencia.contato;
                        }
                        if (!oRef.eMail.Equals(oReferencia.eMail))
                        {
                            descricao += " Email de " + oRef.eMail + " para " + oReferencia.eMail;
                        }
                        if (!oRef.nome.Equals(oReferencia.nome))
                        {
                            descricao += " Nome de " + oRef.nome + " para " + oReferencia.nome;
                        }
                        if (!oRef.telefone1.Equals(oReferencia.telefone1))
                        {
                            descricao += " Telefone1 de " + oRef.telefone1 + " para " + oReferencia.telefone1;
                        }
                        if (!oRef.telefone2.Equals(oReferencia.telefone2))
                        {
                            descricao += " Telefone 2 de " + oRef.telefone2 + " para " + oReferencia.telefone2;
                        }
                        if (!oRef.tipoReferencia.Equals(oReferencia.tipoReferencia))
                        {
                            descricao += " Tipo Referencia de " + oRef.tipoReferencia + " para " + oReferencia.tipoReferencia;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Referencia id : " + oReferencia.idReferencia + " - Id Pessoa " + oReferencia.idPessoa +
                                " - Nome : " + oReferencia.nome + " - Contato : " + oReferencia.contato +
                                " - Email : " + oReferencia.eMail + " - Tipo Referencia : " + oReferencia.tipoReferencia +
                                " - Telefone 1 : " + oReferencia.telefone1 + " - Telefone 2 : " + oReferencia.telefone2 +              
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Referencia id : " + oReferencia.idReferencia + " - Id Pessoa " + oReferencia.idPessoa +
                                " - Nome : " + oReferencia.nome + " - Contato : " + oReferencia.contato +
                                " - Email : " + oReferencia.eMail + " - Tipo Referencia : " + oReferencia.tipoReferencia +
                                " - Telefone 1 : " + oReferencia.telefone1 + " - Telefone 2 : " + oReferencia.telefone2 +
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
