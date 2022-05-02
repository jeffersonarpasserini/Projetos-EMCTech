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
    public class GrupoEmpresaDAO
    {

         MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public GrupoEmpresaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(GrupoEmpresa oGrupoEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'GrupoEmpresa'"+
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oGrupoEmpresa.idGrupoEmpresa = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oGrupoEmpresa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into GrupoEmpresa (idGrupoEmpresa, nomeGrupoEmpresa, holding_idholding ) " + 
                                " values (@idGrupoEmpresa, @nomeGrupoEmpresa, @holding)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idGrupoEmpresa", oGrupoEmpresa.idGrupoEmpresa);
                Sqlcon.Parameters.AddWithValue("@nomeGrupoEmpresa", oGrupoEmpresa.nomeGrupoEmpresa );
                Sqlcon.Parameters.AddWithValue("@holding", oGrupoEmpresa.holding.idHolding);
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

        public void Atualizar(GrupoEmpresa oGrupoEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oGrupoEmpresa, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update grupoempresa set nomegrupoempresa=@nomeGrupoEmpresa, holding_idholding=@idholding " +
                                                      " where idgrupoempresa=@idGrupoEmpresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idGrupoEmpresa", oGrupoEmpresa.idGrupoEmpresa);
                Sqlcon.Parameters.AddWithValue("@nomeGrupoEmpresa", oGrupoEmpresa.nomeGrupoEmpresa);
                Sqlcon.Parameters.AddWithValue("@idholding", oGrupoEmpresa.holding.idHolding);
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

        public void Excluir(GrupoEmpresa oGrupoEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oGrupoEmpresa, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from GrupoEmpresa where idGrupoEmpresa = @idGrupoEmpresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idGrupoEmpresa", oGrupoEmpresa.idGrupoEmpresa);
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

        public DataTable ListaGrupoEmpresa(GrupoEmpresa oGrupoEmpresa)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select g.idGrupoEmpresa, g.nomeGrupoEmpresa, h.nomeholding from GrupoEmpresa g, holding h " + 
                                " where h.idholding = g.holding_idholding "; 
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

        public DataTable dstRelatorio(String sSQL)
           {

           try
              {
              //Monta comando para a gravação do registro
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

       public GrupoEmpresa ObterPor(GrupoEmpresa oGrupoEmpresa)
        {
            MySqlDataReader drConta;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from GrupoEmpresa Where idGrupoEmpresa = " + oGrupoEmpresa.idGrupoEmpresa;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                while (drConta.Read())
                {

                    GrupoEmpresa oGrupo = new GrupoEmpresa();

                    oGrupo.idGrupoEmpresa = EmcResources.cInt(drConta["idGrupoEmpresa"].ToString());
                    oGrupo.nomeGrupoEmpresa = drConta["nomeGrupoEmpresa"].ToString();

                    Holding oHolding = new Holding();
                    oHolding.idHolding = EmcResources.cInt(drConta["holding_idholding"].ToString());

                    drConta.Close();
                    drConta.Dispose();


                    HoldingDAO oHoldingDAO = new HoldingDAO(parConexao, oOcorrencia,codEmpresa);
                    oGrupo.holding = oHoldingDAO.ObterPor(oHolding);

                    return oGrupo;
                }

                drConta.Close();
                drConta.Dispose();
                GrupoEmpresa objCta1 = new GrupoEmpresa();
                return objCta1;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drConta = null;
            }

        }

       private void geraOcorrencia(GrupoEmpresa oGrupoEmpresa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oGrupoEmpresa.idGrupoEmpresa.ToString();

                if (flag == "A" || flag=="AS")
                {

                    GrupoEmpresa oHold = new GrupoEmpresa();
                    oHold = ObterPor(oGrupoEmpresa);

                    if (flag == "AS")
                    {
                        descricao = " Atualização de Numero : de " + " foi excluída por " + oOcorrencia.usuario.nome;
                    }

                    if (!oHold.Equals(oGrupoEmpresa) && flag=="A")
                    {
                        descricao = "GrupoEmpresa :" + oGrupoEmpresa.idGrupoEmpresa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oHold.nomeGrupoEmpresa.Equals(oGrupoEmpresa.nomeGrupoEmpresa))
                        {
                            descricao += " Nome GrupoEmpresa : " + oHold.nomeGrupoEmpresa + " para " + oGrupoEmpresa.nomeGrupoEmpresa;
                        }
                        if (!oHold.holding.idHolding.Equals(oGrupoEmpresa.holding.idHolding))
                        {
                            descricao += " Holding : " + oHold.holding.idHolding + " - " + oHold.holding.nomeHolding + " para " + 
                                                 oGrupoEmpresa.holding.idHolding + " - " + oGrupoEmpresa.holding.nomeHolding;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " GrupoEmpresa : " + oGrupoEmpresa.idGrupoEmpresa + " - Nome : " + oGrupoEmpresa.nomeGrupoEmpresa +
                                " holding : " + oGrupoEmpresa.holding.idHolding + " - " + oGrupoEmpresa.holding.nomeHolding +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " GrupoEmpresa : " + oGrupoEmpresa.idGrupoEmpresa + " - Nome : " + oGrupoEmpresa.nomeGrupoEmpresa +
                                " holding : " + oGrupoEmpresa.holding.idHolding + " - " + oGrupoEmpresa.holding.nomeHolding +
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

       public DataTable pesquisaGrupoEmpresa(int empMaster, int idGrupoEmpresa, int idHolding, String nomeGrupoEmpresa)// bool ckHolding)
       {
           try
           {
               
               String strSQL = "select g.* , h.nomeholding from grupoempresa g, holding h "
                                + "where g.holding_idholding = h.idholding";

               if (idGrupoEmpresa > 0)
               {
                
                   strSQL += " and g.idgrupoempresa =@idgrupoempresa";
               }
               if (idHolding > 0)
               {
                   strSQL += " and g.holding_idholding =@idholding";
               }
               if (!String.IsNullOrEmpty(nomeGrupoEmpresa.Trim()))
               {
                   strSQL += " and g.nomegrupoempresa like @nomegrupoempresa";
               }
            
               
               strSQL += " order by g.nomegrupoempresa";

               MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
               Sqlcon.Parameters.AddWithValue("@idgrupoempresa",idGrupoEmpresa);
               Sqlcon.Parameters.AddWithValue("@idholding", idHolding);
               Sqlcon.Parameters.AddWithValue("@nomegrupoempresa", "%" + nomeGrupoEmpresa.Trim() + "%");
             
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
