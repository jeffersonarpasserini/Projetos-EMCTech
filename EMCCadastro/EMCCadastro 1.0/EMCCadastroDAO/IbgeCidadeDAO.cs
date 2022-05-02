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
    public class IbgeCidadeDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IbgeCidadeDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(IbgeCidade objIbgeCidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de IbgeCidade
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'ibgecidade'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objIbgeCidade.idIbgeCidade = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objIbgeCidade, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into ibgecidade (codigoibge, nomecidade, estado, idestado ) values (@codigoibge, @nomecidade, @estado, @idestado)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idestado", objIbgeCidade.estado.idEstado);
                Sqlcon.Parameters.AddWithValue("@codigoibge", objIbgeCidade.codigoIbge);
                Sqlcon.Parameters.AddWithValue("@nomecidade", objIbgeCidade.nomeCidade);
                Sqlcon.Parameters.AddWithValue("@estado", objIbgeCidade.estado.abreviatura);

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

        public void Atualizar(IbgeCidade objIbgeCidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de IbgeCidade
            try
            {
                geraOcorrencia(objIbgeCidade, "A");               
                //Monta comando para a gravação do registro
                String strSQL = "update ibgecidade set codigoibge=@codigoibge, nomecidade = @nomecidade, " + 
                                                 " estado=@estado, idestado=@idestado where idibgecidade = @idibgecidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idibgecidade", objIbgeCidade.idIbgeCidade);
                Sqlcon.Parameters.AddWithValue("@idestado", objIbgeCidade.estado.idEstado);
                Sqlcon.Parameters.AddWithValue("@codigoibge", objIbgeCidade.codigoIbge);
                Sqlcon.Parameters.AddWithValue("@nomecidade", objIbgeCidade.nomeCidade);
                Sqlcon.Parameters.AddWithValue("@estado", objIbgeCidade.estado.abreviatura);
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

        public void Excluir(IbgeCidade objIbgeCidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de IbgeCidade
            try
            {
                geraOcorrencia(objIbgeCidade, "E");               
                //Monta comando para a gravação do registro
                String strSQL = "delete from ibgecidade where idIbgeCidade = @idIbgeCidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idIbgeCidade", objIbgeCidade.idIbgeCidade);

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

        public DataTable ListaIbgeCidade()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ibgecidade order by nomecidade";
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

        public IbgeCidade ObterPor(IbgeCidade oIbgeCidade)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                if (oIbgeCidade.idIbgeCidade > 0)
                {
                    String strSQL = "select * from ibgecidade Where idIbgeCidade=@idIbgeCidade";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idIbgeCidade", oIbgeCidade.idIbgeCidade);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    String strSQL = "select * from ibgecidade Where codigoibge=@codigoibge";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigoibge", oIbgeCidade.codigoIbge);
                    drCon = Sqlcon.ExecuteReader();
                }

                while (drCon.Read())
                {
                    IbgeCidade objIbgeCidade = new IbgeCidade();
                    objIbgeCidade.idIbgeCidade = EmcResources.cInt(drCon["idibgecidade"].ToString());
                    objIbgeCidade.nomeCidade = drCon["nomecidade"].ToString();
                    objIbgeCidade.codigoIbge = drCon["codigoibge"].ToString();

                    Estado oEstado = new Estado();
                    oEstado.idEstado = drCon["idestado"].ToString();

                    objIbgeCidade.estado = oEstado;

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    EstadoDAO oEstadoDAO = new EstadoDAO(parConexao, oOcorrencia, codEmpresa);
                    objIbgeCidade.estado = oEstadoDAO.ObterPor(oEstado);

                    return objIbgeCidade;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                IbgeCidade objIbgeCidade1 = new IbgeCidade();
                return objIbgeCidade1;

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
      
        private void geraOcorrencia(IbgeCidade oIbgeCidade, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oIbgeCidade.idIbgeCidade.ToString();

                if (flag == "A")
                {

                    IbgeCidade oCobr = new IbgeCidade();
                    oCobr = ObterPor(oIbgeCidade);

                    if (!oCobr.Equals(oIbgeCidade))
                    {
                        descricao = "IbgeCidade id: " + oIbgeCidade.idIbgeCidade + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.codigoIbge.Equals(oIbgeCidade.codigoIbge))
                        {
                            descricao += " Codigo IBGE de " + oCobr.codigoIbge + " para " + oIbgeCidade.codigoIbge;
                        }
                        if (!oCobr.nomeCidade.Equals(oIbgeCidade.nomeCidade))
                        {
                            descricao += " Cidade de " + oCobr.nomeCidade + " para " + oIbgeCidade.nomeCidade;
                        }
                        if (!oCobr.estado.idEstado.Equals(oIbgeCidade.estado.idEstado))
                        {
                            descricao += " Estado de " + oCobr.estado.idEstado + " - " + oCobr.estado.abreviatura +
                                         " para " + oIbgeCidade.estado.idEstado + " - " + oIbgeCidade.estado.abreviatura;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "IbgeCidade : " + oIbgeCidade.idIbgeCidade + " - " + oIbgeCidade.nomeCidade + " - " + oIbgeCidade.estado.abreviatura + " - " + oIbgeCidade.estado.idEstado + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "IbgeCidade : " + oIbgeCidade.idIbgeCidade + " - " + oIbgeCidade.nomeCidade + " - " + oIbgeCidade.estado.abreviatura + " - " + oIbgeCidade.estado.idEstado + " foi exluido por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaIbgeCidade(int empMaster, int codigoIbge, string nomeCidade, string estado)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select ib.* from ibgecidade ib ";


                if (codigoIbge > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " tb.codigoibge = @codigoibge ";
                }

                if (!String.IsNullOrEmpty(nomeCidade.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " ib.nomecidade like @nomeCidade ";
                }
                if (!String.IsNullOrEmpty(estado.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " ib.estado like @estado ";
                }

             

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoibge", codigoIbge);
                Sqlcon.Parameters.AddWithValue("@nomeCidade", "%" + nomeCidade.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@estado", "%" + estado.Trim() + "%");

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
