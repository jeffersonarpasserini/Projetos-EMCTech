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
    public class CidadeDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CidadeDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Cidade objCidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de Cidade
            try
            {
                geraOcorrencia(objCidade, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into cidade (cepcidade, nomecidade, ibgecidade_idibgecidade ) " + 
                                "values (@cepcidade, @nomecidade, @ibge)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@cepcidade", objCidade.cepCidade);
                Sqlcon.Parameters.AddWithValue("@nomecidade", objCidade.ibgeCidade.nomeCidade);
                Sqlcon.Parameters.AddWithValue("@ibge", objCidade.ibgeCidade.idIbgeCidade);
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

        public void Atualizar(Cidade objCidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Cidade
            try
            {
                geraOcorrencia(objCidade, "A");               
                //Monta comando para a gravação do registro
                String strSQL = "update cidade set nomecidade = @nomecidade, ibgecidade_idibgecidade=@ibge " + 
                                " where cepcidade = @cepcidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@cepcidade", objCidade.cepCidade);
                Sqlcon.Parameters.AddWithValue("@nomecidade", objCidade.ibgeCidade.nomeCidade);
                Sqlcon.Parameters.AddWithValue("@ibge", objCidade.ibgeCidade.idIbgeCidade);
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

        public void Excluir(Cidade objCidade)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Cidade
            try
            {
                geraOcorrencia(objCidade, "E");               
                //Monta comando para a gravação do registro
                String strSQL = "delete from cidade where cepcidade = @cepcidade ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@cepcidade", objCidade.cepCidade);

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

        public DataTable ListaCidade()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select c.cepcidade, c.nomecidade, i.codigoibge from cidade c, ibgecidade i " + 
                                " where i.idibgecidade = c.ibgecidade_idibgecidade " +            
                                " order by nomecidade";
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

        public Cidade ObterPor(Cidade oCidade)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from cidade Where cepcidade=@cepcidade";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@cepcidade", oCidade.cepCidade);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    Cidade objCidade = new Cidade();
                    objCidade.cepCidade = drCon["cepcidade"].ToString();
                    objCidade.nomeCidade = drCon["nomecidade"].ToString();

                    IbgeCidade oIbge = new IbgeCidade();
                    oIbge.idIbgeCidade = EmcResources.cInt(drCon["ibgecidade_idibgecidade"].ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    IbgeCidadeDAO oIbgeDAO = new IbgeCidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objCidade.ibgeCidade = oIbgeDAO.ObterPor(oIbge);

                    return objCidade;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                Cidade objCidade1 = new Cidade();
                objCidade1.cepCidade = "";
                return objCidade1;

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
      
        private void geraOcorrencia(Cidade oCidade, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCidade.cepCidade.ToString();

                if (flag == "A")
                {

                    Cidade oCobr = new Cidade();
                    oCobr = ObterPor(oCidade);

                    if (!oCobr.Equals(oCidade))
                    {
                        descricao = "Cidade id: " + oCidade.cepCidade + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.nomeCidade.Equals(oCidade.nomeCidade))
                        {
                            descricao += " Nome de " + oCobr.nomeCidade + " para " + oCidade.nomeCidade;
                        }
                        if (!oCobr.ibgeCidade.codigoIbge.Equals(oCidade.ibgeCidade.codigoIbge))
                        {
                            descricao += " Código Ibge de " + oCobr.ibgeCidade.codigoIbge + " para " + oCidade.ibgeCidade.codigoIbge;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Cidade : " + oCidade.cepCidade + " - " + oCidade.nomeCidade + " - " + oCidade.ibgeCidade.codigoIbge +" foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Cidade : " + oCidade.cepCidade + " - " + oCidade.nomeCidade + " - " + oCidade.ibgeCidade.codigoIbge + " foi exluido por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaCidade(int empMaster, int idCidade, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select tc.* from cidade tc ";


                if (idCidade > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " tc.cepcidade = @cepcidade ";
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

                    strSQL += " tc.nomecidade like @nomecidade ";
                }

             

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@cepcidade", idCidade);
                Sqlcon.Parameters.AddWithValue("@nomecidade", "%" + descricao.Trim() + "%");

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
