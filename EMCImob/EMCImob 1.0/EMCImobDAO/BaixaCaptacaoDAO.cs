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
using EMCCadastroModel;

namespace EMCImobDAO
{
    public class BaixaCaptacaoDAO
    {
       MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public BaixaCaptacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(BaixaCaptacao objBaixaCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'baixacaptacao'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objBaixaCaptacao.idBaixaCaptacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objBaixaCaptacao, "I"); 

                //Monta comando para a gravação do registro
                String strSQL = "insert into BaixaCaptacao (Descricao, DataBaixa, ValorBaixa) values (@Descricao, @DataBaixa, @ValorBaixa)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@Descricao", objBaixaCaptacao.descricao);
                Sqlcon.Parameters.AddWithValue("@DataBaixa", objBaixaCaptacao.dataBaixa);
                Sqlcon.Parameters.AddWithValue("@ValorBaixa", objBaixaCaptacao.valorBaixa);

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

        public void Atualizar(BaixaCaptacao objBaixaCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {
                geraOcorrencia(objBaixaCaptacao, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update BaixaCaptacao set Descricao = @Descricao, DataBaixa = @DataBaixa, ValorBaixa = @ValorBaixa where idBaixaCaptacao = @idBaixaCaptacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idBaixaCaptacao", objBaixaCaptacao.idBaixaCaptacao);
                Sqlcon.Parameters.AddWithValue("@Descricao", objBaixaCaptacao.descricao);
                Sqlcon.Parameters.AddWithValue("@DataBaixa", objBaixaCaptacao.dataBaixa);
                Sqlcon.Parameters.AddWithValue("@ValorBaixa", objBaixaCaptacao.valorBaixa);

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

        public void Excluir(BaixaCaptacao objBaixaCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

           
            try
            {
                geraOcorrencia(objBaixaCaptacao, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from BaixaCaptacao where idBaixaCaptacao = @idBaixaCaptacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idBaixaCaptacao", objBaixaCaptacao.idBaixaCaptacao);

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

        public DataTable ListaBaixaCaptacao(Vendedor objVendedor)
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
               
                //Monta comando para a gravação do registro
                String strSQL = "select * from BaixaCaptacao where Vendedor_CodEmpresa = @Vendedor_CodEmpresa and Vendedor_IdPessoa = @Vendedor_IdPessoa order by DataBaixa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@Vendedor_CodEmpresa", objVendedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@Vendedor_IdPessoa", objVendedor.idPessoa);

                
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

        public BaixaCaptacao ObterPor(BaixaCaptacao oBaixaCaptacao)
        {
            MySqlDataReader drCon;
            BaixaCaptacao objRetorno = new BaixaCaptacao();
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oBaixaCaptacao.idBaixaCaptacao > 0)
                {


                    //Monta comando para a gravação do registro
                    strSQL = "select * from BaixaCaptacao Where idBaixaCaptacao = @idBaixaCaptacao";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idBaixaCaptacao", oBaixaCaptacao.idBaixaCaptacao);

                    drCon = Sqlcon.ExecuteReader();


                    while (drCon.Read())
                    {

                        //Atribuindo valores para o objeto Baixa Captacao com os dados da baixa selecionada
                        objRetorno.idBaixaCaptacao = Convert.ToInt32(drCon["idBaixaCaptacao"].ToString());
                        objRetorno.descricao = drCon["Descricao"].ToString();
                        objRetorno.dataBaixa = Convert.ToDateTime(drCon["DataBaixa"].ToString());
                        objRetorno.valorBaixa = Convert.ToDecimal(drCon["ValorBaixa"].ToString());

                    }

                    drCon.Dispose();
                    drCon.Close();

                    if (objRetorno.idBaixaCaptacao > 0)
                    {
                        //carrega as contascaptacao baixados por este documento
                        ContasCaptacaoDAO oCtaCaptacaoDAO = new ContasCaptacaoDAO(parConexao,oOcorrencia,codEmpresa);
                        objRetorno.contasCaptacao = oCtaCaptacaoDAO.ListaContasCaptacao(objRetorno);
                    }

                }
                
                return objRetorno;
               
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
           

        }

        private void geraOcorrencia(BaixaCaptacao objBaixaCaptacao, string p)
        {
            throw new NotImplementedException();
        }

    }
}
