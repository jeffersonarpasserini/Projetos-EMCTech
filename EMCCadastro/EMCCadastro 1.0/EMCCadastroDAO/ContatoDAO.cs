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
    public class ContatoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ContatoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Contato objContato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Contato
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'telefone'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objContato.codigo = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objContato, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into telefone (codempresa, idpessoa, numero, tipotelefone, recado, email) " + 
                                " values (@codempresa, @idpessoa, @telefone, @tipotelefone, @recado, @email)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objContato.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objContato.idPessoa);
                Sqlcon.Parameters.AddWithValue("@telefone", objContato.numero);
                Sqlcon.Parameters.AddWithValue("@tipotelefone", objContato.tipoTelefone);
                Sqlcon.Parameters.AddWithValue("@recado", objContato.recado);
                Sqlcon.Parameters.AddWithValue("@email", objContato.eMail);
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

        public void Atualizar(Contato objContato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Contato
            try
            {
                geraOcorrencia(objContato, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update telefone set numero=@telefone, tipotelefone=@tipotelefone,"+ 
                                                   "recado=@recado, email=@email " +
                                " where codempresa = @codempresa and idpessoa = @idpessoa and idtelefone = @codigo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objContato.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objContato.idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigo", objContato.codigo);
                Sqlcon.Parameters.AddWithValue("@telefone", objContato.numero);
                Sqlcon.Parameters.AddWithValue("@tipotelefone", objContato.tipoTelefone);
                Sqlcon.Parameters.AddWithValue("@recado", objContato.recado);
                Sqlcon.Parameters.AddWithValue("@email", objContato.eMail);
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

        public void Excluir(Contato objContato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Contato
            try
            {
                geraOcorrencia(objContato, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from telefone where codempresa = @codempresa and idpessoa = @idpessoa and idtelefone = @codigo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objContato.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objContato.idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigo", objContato.codigo);
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

        public DataTable ListaContato(Contato objContato)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idtelefone,numero,tipotelefone,recado,email " + 
                                 " from telefone where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objContato.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objContato.idPessoa);

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

        public Contato ObterPor(Contato oContato)
        {

            MySqlDataReader drCon;

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from telefone Where ";

                //verifica se o atributo está vazio
                if (oContato.codigo > 0 && oContato.codEmpresa > 0 && oContato.idPessoa > 0)
                {
                    strSQL += " codempresa = @codempresa and idpessoa = @idpessoa and idtelefone = @codigo";
                }
               
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oContato.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oContato.idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigo", oContato.codigo);
                Sqlcon.Parameters.AddWithValue("@telefone", oContato.numero);
                Sqlcon.Parameters.AddWithValue("@email", oContato.eMail);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    Contato objContato  = new Contato();
                    objContato.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objContato.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objContato.codigo = Convert.ToInt32(drCon["idtelefone"].ToString());
                    objContato.numero = drCon["numero"].ToString();
                    objContato.tipoTelefone = drCon["tipotelefone"].ToString();
                    objContato.recado = drCon["recado"].ToString(); ;
                    objContato.eMail = drCon["email"].ToString();
                    drCon.Close();
                    drCon.Dispose();
                    return objContato;
                }


                Contato objContato1 = new Contato();
                drCon.Close();
                drCon.Dispose();
                return objContato1;

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

        private void geraOcorrencia(Contato oContato, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oContato.idPessoa.ToString();

                if (flag == "A")
                {

                    Contato oCon = new Contato();
                    oCon = ObterPor(oContato);

                    if (!oCon.Equals(oContato))
                    {
                        descricao = "Contato : " + oContato.codigo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCon.eMail.Equals(oContato.eMail))
                        {
                            descricao += " Email de " + oCon.eMail + " para " + oContato.eMail;
                        }
                        if (!oCon.numero.Equals(oContato.numero))
                        {
                            descricao += " Telefone de " + oCon.numero + " para " + oContato.numero;
                        }
                        if (!oCon.recado.Equals(oContato.recado))
                        {
                            descricao += " Recado de " + oCon.recado + " para " + oContato.recado;
                        }
                        if (!oCon.tipoTelefone.Equals(oContato.tipoTelefone))
                        {
                            descricao += " Tipo de " + oCon.tipoTelefone + " para " + oContato.tipoTelefone;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Contato " + oContato.codigo + " Pessoa : " + oContato.idPessoa + " - Numero : " + oContato.numero + " - Tipo : " + oContato.tipoTelefone + " - Recado : " + oContato.recado + " - Email : " + oContato.eMail + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contato " + oContato.codigo + " Pessoa : " + oContato.idPessoa + " - Numero : " + oContato.numero + " - Tipo : " + oContato.tipoTelefone + " - Recado : " + oContato.recado + " - Email : " + oContato.eMail + " foi excluída por " + oOcorrencia.usuario.nome;
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
