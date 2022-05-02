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
    public class TipoCobrancaDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoCobrancaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(TipoCobranca objTipoCobranca)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de TipoCobranca
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'tipocobranca'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objTipoCobranca.idTipoCobranca = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objTipoCobranca, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into tipocobranca ( descricao, abreviatura ) values (@descricao, @abreviatura)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objTipoCobranca.descricao);
                Sqlcon.Parameters.AddWithValue("@abreviatura", objTipoCobranca.abreviatura);
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

        public void Atualizar(TipoCobranca objTipoCobranca)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de TipoCobranca
            try
            {
                geraOcorrencia(objTipoCobranca, "A");               
                //Monta comando para a gravação do registro
                String strSQL = "update tipocobranca set descricao = @descricao, abreviatura=@abreviatura where idTipoCobranca = @idTipoCobranca";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idTipoCobranca", objTipoCobranca.idTipoCobranca);
                Sqlcon.Parameters.AddWithValue("@descricao", objTipoCobranca.descricao);
                Sqlcon.Parameters.AddWithValue("@abreviatura", objTipoCobranca.abreviatura);
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

        public void Excluir(TipoCobranca objTipoCobranca)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de TipoCobranca
            try
            {
                geraOcorrencia(objTipoCobranca, "E");               
                //Monta comando para a gravação do registro
                String strSQL = "delete from tipocobranca where idTipoCobranca = @idTipoCobranca";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idTipoCobranca", objTipoCobranca.idTipoCobranca);

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

        public DataTable ListaTipoCobranca()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from tipocobranca order by descricao";
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

        public TipoCobranca ObterPor(TipoCobranca oTipoCobranca)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from tipocobranca Where idTipoCobranca=@idTipoCobranca";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoCobranca", oTipoCobranca.idTipoCobranca);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    TipoCobranca objTipoCobranca = new TipoCobranca();
                    objTipoCobranca.idTipoCobranca = Convert.ToInt32(drCon["idTipoCobranca"].ToString());
                    objTipoCobranca.descricao = drCon["descricao"].ToString();
                    objTipoCobranca.abreviatura = drCon["abreviatura"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objTipoCobranca;
                }

                drCon.Close();
                drCon.Dispose();
                TipoCobranca objTipoCobranca1 = new TipoCobranca();
                return objTipoCobranca1;

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
      
        private void geraOcorrencia(TipoCobranca oTipoCobranca, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oTipoCobranca.idTipoCobranca.ToString();

                if (flag == "A")
                {

                    TipoCobranca oCobr = new TipoCobranca();
                    oCobr = ObterPor(oTipoCobranca);

                    if (!oCobr.Equals(oTipoCobranca))
                    {
                        descricao = "Tipo Cobranca id: " + oTipoCobranca.idTipoCobranca + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oTipoCobranca.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oTipoCobranca.descricao;
                        }
                        if (!oCobr.abreviatura.Equals(oTipoCobranca.abreviatura))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oTipoCobranca.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Tipo Cobrança : " + oTipoCobranca.idTipoCobranca + " - " + oTipoCobranca.descricao + oTipoCobranca.abreviatura +" foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Tipo Cobrança : " + oTipoCobranca.idTipoCobranca + " - " + oTipoCobranca.descricao + oTipoCobranca.abreviatura + " foi exluido por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaTipoCobranca(int empMaster, int idTipoCobranca, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select tc.* from tipocobranca tc ";


                if (idTipoCobranca > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " tc.idtipocobranca = @idtipocobranca ";
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

                    strSQL += " tc.descricao like @descricao ";
                }

             

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipocobranca", idTipoCobranca);
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
    }
}
