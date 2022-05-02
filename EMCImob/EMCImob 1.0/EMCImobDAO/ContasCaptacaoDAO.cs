using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCImobModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;



namespace EMCImobDAO
{
    public class ContasCaptacaoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public ContasCaptacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

 
        public void Salvar(ContasCaptacao oContasCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'contascaptacao'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    oContasCaptacao.idContasCaptacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oContasCaptacao, "I"); 

                //Monta comando para a gravação do registro
                String strSQL = "insert into ContasCaptacao (idTipoLanctoCaptacao, CodEmpresa, Vendedor_CodEmpresa, Vendedor_idPessoa, DataLacamento, ValorLancamento, Descricao, Situacao ) " +
                                " values (@idTipoLanctoCaptacao, @CodEmpresa, @Vendedor_CodEmpresa, @Vendedor_idPessoa, @DataLancamento, @ValorLancamento, @Descricao, @Situacao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idTipoLanctoCaptacao", oContasCaptacao.tipoLanctoCaptacao.idTipoLanctoCaptacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oContasCaptacao.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@DataLancamento", oContasCaptacao.dataLancamento);
                Sqlcon.Parameters.AddWithValue("@ValorLancamento", oContasCaptacao.valorLancamento);
                Sqlcon.Parameters.AddWithValue("@Descricao", oContasCaptacao.descricao);
                Sqlcon.Parameters.AddWithValue("@Situacao", oContasCaptacao.situacao);
                Sqlcon.Parameters.AddWithValue("@Vendedor_CodEmpresa", oContasCaptacao.vendedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@Vendedor_idPessoa", oContasCaptacao.vendedor.idPessoa);

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

        public void Atualizar(ContasCaptacao oContasCaptacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oContasCaptacao, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update ContasCaptacao set idtipolanctocaptacao = @idtipolanctocaptaao, datalancamento = @datalancamento  " +
                                                       "valorLancamento = @valorLancamento, descricao = @descricao, " +
                                                       "situacao = @situacao, vendedor_codempresa = @vendedor_codempresa, vendedor_idpessoa = @vendedor_idpessoa " +
                                "where idcontascaptacao = @idcontascaptacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idContasCaptacao", oContasCaptacao.idContasCaptacao);
                Sqlcon.Parameters.AddWithValue("@idTipoLanctoCaptacao", oContasCaptacao.tipoLanctoCaptacao.idTipoLanctoCaptacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oContasCaptacao.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@DataLancamento", oContasCaptacao.dataLancamento);
                Sqlcon.Parameters.AddWithValue("@ValorLancamento", oContasCaptacao.valorLancamento);
                Sqlcon.Parameters.AddWithValue("@Descricao", oContasCaptacao.descricao);
                Sqlcon.Parameters.AddWithValue("@Situacao", oContasCaptacao.situacao);
                Sqlcon.Parameters.AddWithValue("@Vendedor_CodEmpresa", oContasCaptacao.vendedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@Vendedor_idPessoa", oContasCaptacao.vendedor.idPessoa);

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

        public void Excluir(ContasCaptacao oConta)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(oConta, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from ContasCaptacao where idContasCaptacao = @idContasCaptacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idContasCaptacao", oConta.idContasCaptacao);

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

        public DataTable ListaContasCaptacao(ContasCaptacao oConta)
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from ContasCaptacao where idempresa = " + oConta.codEmpresa + " order by idContasCaptacao ";
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

        public List<ContasCaptacao> ListaContasCaptacao(BaixaCaptacao oBaixa)
        {
            MySqlDataReader drConta;
            bool Consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from ContasCaptacao where baixacaptacao_idbaixacaptacao = @baixacaptacao_idbaixacaptacao order by idContasCaptacao ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@baixacaptacao_idbaixacaptacao", oBaixa.idBaixaCaptacao);

                drConta = Sqlcon.ExecuteReader();

                List<ContasCaptacao> lstContasCaptacao = new List<ContasCaptacao>();
                
                while (drConta.Read())
                {
                    Consulta = true;

                    ContasCaptacao objCta = new ContasCaptacao();

                    //localiza o tipo de lançamento de captação
                    TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
                    oTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(drConta["idtipolanctocaptacao"]);
                    
                    //localiza o Vendedor
                    Vendedor oVendedor = new Vendedor();
                    oVendedor.codEmpresa = Convert.ToInt32(drConta["vendedor_codempresa"]);
                    oVendedor.idPessoa = Convert.ToInt32(drConta["vendedor_idpessoa"]);

                    
                    objCta.codEmpresa = Convert.ToInt32(drConta["idempresa"]);
                    objCta.idContasCaptacao = Convert.ToInt32(drConta["idContasCaptacao"]);
                    objCta.tipoLanctoCaptacao = oTipoLanctoCaptacao;
                    objCta.vendedor = oVendedor;
                    objCta.descricao = Convert.ToString(drConta["descricao"]);
                    objCta.dataLancamento = Convert.ToDateTime(drConta["datalancamento"]);
                    objCta.valorLancamento = Convert.ToDecimal(drConta["valorlancamento"]);
                    objCta.situacao = Convert.ToString(drConta["situacao"]);

                    lstContasCaptacao.Add(objCta);
                }

                drConta.Close();
                drConta.Dispose();
                drConta = null;

                List<ContasCaptacao> lstRetorno = new List<ContasCaptacao>();

                if (Consulta)
                {
                    foreach (ContasCaptacao oCaptacao in lstContasCaptacao)
                    {
                        ContasCaptacao oRetorno = new ContasCaptacao();

                        oRetorno.codEmpresa = oCaptacao.codEmpresa;
                        oRetorno.idContasCaptacao = oCaptacao.idContasCaptacao;
                        TipoLanctoCaptacaoDAO oTipoLanctoCaptacaoDAO = new TipoLanctoCaptacaoDAO(parConexao,oOcorrencia,codEmpresa);
                        oRetorno.tipoLanctoCaptacao = oTipoLanctoCaptacaoDAO.ObterPor(oCaptacao.tipoLanctoCaptacao);
                        VendedorDAO oVendedorDAO = new VendedorDAO(parConexao, oOcorrencia, codEmpresa);
                        oRetorno.vendedor = oVendedorDAO.ObterPor(oCaptacao.vendedor);
                        oRetorno.descricao = oCaptacao.descricao;
                        oRetorno.dataLancamento = oCaptacao.dataLancamento;
                        oRetorno.valorLancamento = oCaptacao.valorLancamento;
                        oRetorno.situacao = oCaptacao.situacao;

                        lstRetorno.Add(oRetorno);
                    }
                }

                return lstRetorno;

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

        public ContasCaptacao ObterPor(ContasCaptacao oConta)
        {
            MySqlDataReader drConta;
            bool Consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from ContasCaptacao Where idContasCaptacao = " + oConta.idContasCaptacao;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();
                ContasCaptacao oCaptacao = new ContasCaptacao();

                while (drConta.Read())
                {
                    Consulta = true;

                    //localiza o tipo de lançamento de captação
                    TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
                    oTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(drConta["idtipolanctocaptacao"]);

                    //localiza o Vendedor
                    Vendedor oVendedor = new Vendedor();
                    oVendedor.codEmpresa = Convert.ToInt32(drConta["vendedor_codempresa"]);
                    oVendedor.idPessoa = Convert.ToInt32(drConta["vendedor_idpessoa"]);
                    
                    oCaptacao.codEmpresa = EmcResources.cInt(drConta["idempresa"].ToString());
                    oCaptacao.idContasCaptacao = EmcResources.cInt(drConta["idContasCaptacao"].ToString());
                    oCaptacao.tipoLanctoCaptacao = oTipoLanctoCaptacao;
                    oCaptacao.vendedor = oVendedor;
                    oCaptacao.descricao = Convert.ToString(drConta["descricao"]);
                    oCaptacao.dataLancamento = Convert.ToDateTime(drConta["datalancamento"]);
                    oCaptacao.valorLancamento = Convert.ToDecimal(drConta["valorlancamento"]);
                    oCaptacao.situacao = Convert.ToString(drConta["situacao"]);

                }

                drConta.Close();
                drConta.Dispose();
                drConta = null;

                ContasCaptacao oRetorno = new ContasCaptacao();
                if (Consulta)
                {
                    oRetorno.codEmpresa = oCaptacao.codEmpresa;
                    oRetorno.idContasCaptacao = oCaptacao.idContasCaptacao;
                    TipoLanctoCaptacaoDAO oTipoLanctoCaptacaoDAO = new TipoLanctoCaptacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    oRetorno.tipoLanctoCaptacao = oTipoLanctoCaptacaoDAO.ObterPor(oCaptacao.tipoLanctoCaptacao);
                    VendedorDAO oVendedorDAO = new VendedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oRetorno.vendedor = oVendedorDAO.ObterPor(oCaptacao.vendedor);
                    oRetorno.descricao = oCaptacao.descricao;
                    oRetorno.dataLancamento = oCaptacao.dataLancamento;
                    oRetorno.valorLancamento = oCaptacao.valorLancamento;
                    oRetorno.situacao = oCaptacao.situacao;
                }

                return oRetorno;

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

        private void geraOcorrencia(ContasCaptacao oContasCaptacao, string flag)
        {
            throw new NotImplementedException();
        }

    }
}
