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
    public class HoldingDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public HoldingDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Holding oHolding)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'holding'"+
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oHolding.idHolding = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oHolding, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into holding (idholding, nomeholding ) " + 
                                " values (@idholding, @nomeholding)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idholding", oHolding.idHolding);
                Sqlcon.Parameters.AddWithValue("@nomeholding", oHolding.nomeHolding );
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

        public void Atualizar(Holding oHolding)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oHolding, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update holding set nomeholding = @nomeholding " +
                                                      "where idholding = @idholding";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idholding", oHolding.idHolding);
                Sqlcon.Parameters.AddWithValue("@nomeholding", oHolding.nomeHolding);
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

        public void Excluir(Holding oHolding)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oHolding, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from holding where idholding = @idholding";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idholding", oHolding.idHolding);
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

        public DataTable ListaHolding(Holding oHolding)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idholding, nomeholding from holding "; 
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

        public Holding ObterPor(Holding oHolding)
        {
            MySqlDataReader drConta;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from holding Where idHolding = " + oHolding.idHolding;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                while (drConta.Read())
                {

                    Holding oHold = new Holding();

                    oHold.idHolding = EmcResources.cInt(drConta["idHolding"].ToString());
                    oHold.nomeHolding = drConta["nomeholding"].ToString();

                    drConta.Close();
                    drConta.Dispose();

                    return oHold;
                }

                drConta.Close();
                drConta.Dispose();
                Holding objCta1 = new Holding();
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

        private void geraOcorrencia(Holding oHolding, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oHolding.idHolding.ToString();

                if (flag == "A" || flag=="AS")
                {

                    Holding oHold = new Holding();
                    oHold = ObterPor(oHolding);

                    if (flag == "AS")
                    {
                        descricao = " Atualização de Numero : de " + " foi excluída por " + oOcorrencia.usuario.nome;
                    }

                    if (!oHold.Equals(oHolding) && flag=="A")
                    {
                        descricao = "Holding :" + oHolding.idHolding + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oHold.nomeHolding.Equals(oHolding.nomeHolding))
                        {
                            descricao += " Nome Holding : " + oHold.nomeHolding + " para " + oHolding.nomeHolding;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Holding : " + oHolding.idHolding + " - Nome : " + oHolding.nomeHolding +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Holding : " + oHolding.idHolding + " - Nome : " + oHolding.nomeHolding +
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

        public DataTable pesquisaHolding(int empMaster, int idHolding, string nomeHolding)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select h.* from holding h ";


                if (idHolding > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " h.idholding = @idholding ";
                }

                if (!String.IsNullOrEmpty(nomeHolding.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " h.nomeholding like @nomeholding ";
                }



                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idholding", idHolding);
                Sqlcon.Parameters.AddWithValue("@nomeholding", "%" + nomeHolding.Trim() + "%");

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
