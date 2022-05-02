using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCImobModel;


namespace EMCImobDAO
{
    public class AtivoGrupoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public AtivoGrupoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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


        public void Salvar(AtivoGrupo objAtivoGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'ativogrupo'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objAtivoGrupo.CodAtivoGrupo = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objAtivoGrupo, "I"); 


                //Monta comando para a gravação do registro
                String strSQL = "insert into AtivoGrupo (descricao) values (@descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objAtivoGrupo.Descricao);
                
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public void Atualizar(AtivoGrupo objAtivoGrupo)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objAtivoGrupo, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update AtivoGrupo set descricao = @descricao where CodAtivoGrupo = @CodAtivoGrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@CodAtivoGrupo", objAtivoGrupo.CodAtivoGrupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objAtivoGrupo.Descricao);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public void Excluir(AtivoGrupo objAtivoGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objAtivoGrupo, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from AtivoGrupo where CodAtivoGrupo = @CodAtivoGrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@CodAtivoGrupo", objAtivoGrupo.CodAtivoGrupo);

                Sqlcon.ExecuteNonQuery();
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public DataTable ListaAtivoGrupo()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                
                //Monta comando para a gravação do registro
                String strSQL = "select * from AtivoGrupo order by descricao";
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

        public AtivoGrupo ObterPor(AtivoGrupo oAtivoGrupo)
        {
            MySqlDataReader drCon;
            AtivoGrupo objRetorno = new AtivoGrupo();
            try
            {
               //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oAtivoGrupo.CodAtivoGrupo > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from AtivoGrupo Where CodAtivoGrupo =@codAtivoGrupo";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codAtivoGrupo", oAtivoGrupo.CodAtivoGrupo);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        objRetorno.CodAtivoGrupo = Convert.ToInt32(drCon["CodAtivoGrupo"].ToString());
                        objRetorno.Descricao = drCon["descricao"].ToString();
                         
                    }
                    drCon.Close();
                    drCon.Dispose();
                }

                return objRetorno;

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

        private void geraOcorrencia(AtivoGrupo oAtivoGrupo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oAtivoGrupo.CodAtivoGrupo.ToString();

                if (flag == "A")
                {

                    AtivoGrupo oAtivo = new AtivoGrupo();
                    oAtivo = ObterPor(oAtivoGrupo);

                    if (!oAtivo.Equals(oAtivoGrupo))
                    {
                        descricao = "Grupo de Ativos : " + oAtivoGrupo.CodAtivoGrupo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oAtivo.Descricao.Equals(oAtivoGrupo.Descricao))
                        {
                            descricao += " Descricao de " + oAtivo.Descricao + " para " + oAtivoGrupo.Descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Grupo de Ativos : " + oAtivoGrupo.CodAtivoGrupo + " - " + oAtivoGrupo.Descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Grupo de Ativos :" + oAtivoGrupo.CodAtivoGrupo + " - " + oAtivoGrupo.Descricao + " foi exluido por " + oOcorrencia.usuario.nome;
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
