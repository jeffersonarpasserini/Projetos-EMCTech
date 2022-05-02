using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCImobDAO
{
    public class TipoLanctoCaptacaoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public TipoLanctoCaptacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'tipolanctocaptacao'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objTipoLanctoCaptacao, "I"); 

                //Monta comando para a gravação do registro
                String strSQL = "insert into TipoLanctoCaptacao (Descricao, TipoLancamento) values (@Descricao, @TipoLancamento)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@Descricao", objTipoLanctoCaptacao.Descricao);
                Sqlcon.Parameters.AddWithValue("@TipoLancamento", objTipoLanctoCaptacao.TipoLancamento);

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

        public void Atualizar(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objTipoLanctoCaptacao, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update TipoLanctoCaptacao set Descricao = @Descricao, TipoLancamento = @TipoLancamento where idTipoLanctoCaptacao = @idTipoLanctoCaptacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoLanctoCaptacao", objTipoLanctoCaptacao.idTipoLanctoCaptacao);
                Sqlcon.Parameters.AddWithValue("@Descricao", objTipoLanctoCaptacao.Descricao);
                Sqlcon.Parameters.AddWithValue("@TipoLancamento", objTipoLanctoCaptacao.TipoLancamento);

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

        public void Excluir(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objTipoLanctoCaptacao, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from TipoLanctoCaptacao where idTipoLanctoCaptacao = @idTipoLanctoCaptacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoLanctoCaptacao", objTipoLanctoCaptacao.idTipoLanctoCaptacao);

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

        public DataTable pesquisaTipoLanctoCaptacao(int empMaster, int idTipoLanctoCaptacao, string nome)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select b.* from tipolanctocaptacao b ";

                if (idTipoLanctoCaptacao > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " b.idtipolanctocaptacao = @idtipolanctocaptacao ";
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

                    strSQL += " b.descricao like @nome ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipolanctocaptacao", idTipoLanctoCaptacao);
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

        public DataTable ListaTipoLanctoCaptacao()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from TipoLanctoCaptacao order by Descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                daCon.Dispose();
                daCon = null;
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

        public TipoLanctoCaptacao ObterPor(TipoLanctoCaptacao oTipoLanctoCaptacao)
        {
            MySqlDataReader drCon;
            TipoLanctoCaptacao oRetorno = new TipoLanctoCaptacao();

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oTipoLanctoCaptacao.idTipoLanctoCaptacao > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from TipoLanctoCaptacao Where idTipoLanctoCaptacao = " + oTipoLanctoCaptacao.idTipoLanctoCaptacao + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                  //  Conexao.Open();   
                    //drCon = Sqlcon.ExecuteReader(CommandBehavior.CloseConnection);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        oRetorno.idTipoLanctoCaptacao = EmcResources.cInt(drCon["idTipoLanctoCaptacao"].ToString());
                        oRetorno.Descricao = drCon["Descricao"].ToString();
                        oRetorno.TipoLancamento = drCon["TipoLancamento"].ToString();
                        
                    }

                    drCon.Close();
                    drCon.Dispose();
                }                

                return oRetorno;

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

        private void geraOcorrencia( TipoLanctoCaptacao oTipoLanctoCaptacao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oTipoLanctoCaptacao.idTipoLanctoCaptacao.ToString();

                if (flag == "A")
                {

                    TipoLanctoCaptacao oTpLanctoCap = new TipoLanctoCaptacao();
                    oTpLanctoCap = ObterPor(oTipoLanctoCaptacao);

                    if (!oTpLanctoCap.Equals(oTipoLanctoCaptacao))
                    {
                        descricao = "Tipo Lancto Captacao id: " + oTipoLanctoCaptacao.idTipoLanctoCaptacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oTpLanctoCap.Descricao.Equals(oTipoLanctoCaptacao.Descricao))
                        {
                            descricao += " Descrição " + oTpLanctoCap.Descricao + " para " + oTipoLanctoCaptacao.Descricao;
                        }
                        if (!oTpLanctoCap.TipoLancamento.Equals(oTipoLanctoCaptacao.TipoLancamento))
                        {
                            descricao += " Tipo de Lançamento " + oTpLanctoCap.TipoLancamento + " para " + oTipoLanctoCaptacao.TipoLancamento;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Tipo Lancto Captacao : " + oTipoLanctoCaptacao.idTipoLanctoCaptacao + " - " + oTipoLanctoCaptacao.Descricao + " - " + oTipoLanctoCaptacao.TipoLancamento + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Tipo Lancto Captacao : " + oTipoLanctoCaptacao.idTipoLanctoCaptacao + " - " + oTipoLanctoCaptacao.Descricao + " - " + oTipoLanctoCaptacao.TipoLancamento + " foi exluido por " + oOcorrencia.usuario.nome;
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
