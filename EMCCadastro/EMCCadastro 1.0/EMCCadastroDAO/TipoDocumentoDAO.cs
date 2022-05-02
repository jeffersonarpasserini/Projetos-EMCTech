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
    public class TipoDocumentoDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoDocumentoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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


        public void Salvar(TipoDocumento objTipoDocumento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de TipoDocumento
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'tipodocumento'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objTipoDocumento.idTipoDocumento = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objTipoDocumento, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into TipoDocumento ( descricao, abreviatura ) values (@descricao, @abreviatura)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objTipoDocumento.descricao);
                Sqlcon.Parameters.AddWithValue("@abreviatura", objTipoDocumento.abreviatura);
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

        public void Atualizar(TipoDocumento objTipoDocumento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de TipoDocumento
            try
            {
                geraOcorrencia(objTipoDocumento, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update TipoDocumento set descricao = @descricao, abreviatura=@abreviatura where idTipoDocumento = @idTipoDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idTipoDocumento", objTipoDocumento.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", objTipoDocumento.descricao);
                Sqlcon.Parameters.AddWithValue("@abreviatura", objTipoDocumento.abreviatura);
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

        public void Excluir(TipoDocumento objTipoDocumento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de TipoDocumento
            try
            {
                geraOcorrencia(objTipoDocumento, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from TipoDocumento where idTipoDocumento = @idTipoDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idTipoDocumento", objTipoDocumento.idTipoDocumento);

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

        public DataTable ListaTipoDocumento()
        {

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from TipoDocumento order by descricao";
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

        public TipoDocumento ObterPor(TipoDocumento oTipoDocumento)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from TipoDocumento Where idTipoDocumento=@idTipoDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoDocumento", oTipoDocumento.idTipoDocumento);

                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    TipoDocumento objTipoDocumento = new TipoDocumento();
                    objTipoDocumento.idTipoDocumento = Convert.ToInt32(drCon["idTipoDocumento"].ToString());
                    objTipoDocumento.descricao = drCon["descricao"].ToString();
                    objTipoDocumento.abreviatura = drCon["abreviatura"].ToString();
                    drCon.Close();
                    drCon.Dispose();
                    return objTipoDocumento;
                }

                drCon.Close();
                drCon.Dispose();
                TipoDocumento objTipoDocumento1 = new TipoDocumento();
                return objTipoDocumento1;

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

        private void geraOcorrencia(TipoDocumento oTipoDocumento, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oTipoDocumento.idTipoDocumento.ToString();

                if (flag == "A")
                {

                    TipoDocumento oDoc = new TipoDocumento();
                    oDoc = ObterPor(oTipoDocumento);

                    if (!oDoc.Equals(oTipoDocumento))
                    {
                        descricao = "Tipo Documento " + oTipoDocumento.idTipoDocumento + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oDoc.descricao.Equals(oTipoDocumento.descricao))
                        {
                            descricao += " Descricao de " + oDoc.descricao + " para " + oTipoDocumento.descricao;
                        }
                        if (!oDoc.abreviatura.Equals(oTipoDocumento.abreviatura))
                        {
                            descricao += " Abreviatura de " + oDoc.abreviatura + " para " + oTipoDocumento.abreviatura;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "Tipo Documento : " + oTipoDocumento.idTipoDocumento + " - " + oTipoDocumento.descricao + " - " + oTipoDocumento.abreviatura + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Tipo Documento : " + oTipoDocumento.idTipoDocumento + " - " + oTipoDocumento.descricao + " - " + oTipoDocumento.abreviatura + " foi exluido por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaTipoDocumento(int empMaster, int idTipoDocumento, String descricao, String abreviatura)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select td.* from tipodocumento td ";


                if (idTipoDocumento > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " td.idtipodocumento = @idtipodocumento ";
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

                    strSQL += " td.descricao like @descricao ";
                }

                if (!String.IsNullOrEmpty(abreviatura.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " td.abreviatura like @abreviatura ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", "%" + descricao.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@abreviatura", "%" + abreviatura.Trim() + "%");

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
