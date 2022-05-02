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
    public class AplicacaoDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;


        public AplicacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Aplicacao objAplicacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de Aplicacao
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'aplicacao'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objAplicacao.idAplicacao= Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objAplicacao, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into Aplicacao ( descricao ) values (@descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objAplicacao.descricao);
             
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

        public void Atualizar(Aplicacao objAplicacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Aplicacao
            try
            {
                geraOcorrencia(objAplicacao, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Aplicacao set descricao = @descricao where idAplicacao = @idAplicacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idAplicacao", objAplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objAplicacao.descricao);
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

        public void Excluir(Aplicacao objAplicacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //apaga registro de Aplicacao
            try
            {
                geraOcorrencia(objAplicacao, "E");
               
                //Monta comando para a gravação do registro
                String strSQL = "delete from Aplicacao where idAplicacao = @idAplicacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idAplicacao", objAplicacao.idAplicacao);

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

        public DataTable pesquisaAplicacaco(int empMaster, int idAplicacao, string nome)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select b.* from aplicacao b ";

                if (idAplicacao > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " b.idaplicacao = @idaplicacao ";
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
                Sqlcon.Parameters.AddWithValue("@idaplicacao", idAplicacao);
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

        public DataTable ListaAplicacao()
        {

            try
            {
               
                //Monta comando para a gravação do registro
                String strSQL = "select * from Aplicacao order by descricao";
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

       public Aplicacao ObterPor(Aplicacao oAplicacao)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Aplicacao Where idAplicacao=@idAplicacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idAplicacao", oAplicacao.idAplicacao);

                drCon = Sqlcon.ExecuteReader();
                Aplicacao objAplicacao = new Aplicacao();

                while (drCon.Read())
                {

                    objAplicacao.idAplicacao = Convert.ToInt32(drCon["idAplicacao"].ToString());
                    objAplicacao.descricao = drCon["descricao"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                return objAplicacao;

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

        private void geraOcorrencia(Aplicacao oAplicacao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario=oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oAplicacao.idAplicacao.ToString();

                if (flag == "A")
                {
            
                    Aplicacao oApl = new Aplicacao();
                    oApl = ObterPor(oAplicacao);

                    if (!oApl.Equals(oAplicacao))
                    {
                        descricao = "Aplicacao " + oAplicacao.idAplicacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oApl.descricao.Equals(oAplicacao.descricao))
                        {
                            descricao += " Descricao de " + oApl.descricao + " para " + oAplicacao.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Aplicacao " + oAplicacao.idAplicacao + " - " + oAplicacao.descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Aplicacao " + oAplicacao.idAplicacao + " - " + oAplicacao.descricao + " foi exluido por " + oOcorrencia.usuario.nome;
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
