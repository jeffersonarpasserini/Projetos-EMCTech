using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCFinanceiroModel;
using EMCFinanceiroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCIntegracaoModel;

namespace EMCIntegracaoDAO
{
    public class IntegBaixaPagarDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IntegBaixaPagarDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<IntegBaixaPagar> lstIntegBaixaPagar(int idIntegFinanceiro)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                
                String strSQL = "select * from integbaixapagar Where idintegfinanceiro = @idintegfinanceiro";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idintegfinanceiro", idIntegFinanceiro);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<IntegBaixaPagar> lstMontagem = new List<IntegBaixaPagar>();
                List<IntegBaixaPagar> lstRetorno = new List<IntegBaixaPagar>();


                while (drCon.Read())
                {
                    consulta = true;
                    IntegBaixaPagar oBaixa = new IntegBaixaPagar();

                    oBaixa.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());

                    PagarBaixa oFinBaixa = new PagarBaixa();
                    oFinBaixa.idPagarBaixa = EmcResources.cInt(drCon["idpagarbaixa"].ToString());
                    oBaixa.idBaixaPagar = oFinBaixa;

                    lstMontagem.Add(oBaixa);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarBaixaDAO oFinBaixaDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    foreach (IntegBaixaPagar oBx in lstMontagem)
                    {
                        lstRetorno.Add(ObterPor(oBx));
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(IntegBaixaPagar oInteg, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                if (oInteg.statusOperacao == "I")
                {
                    /*
                     * Operação de inclusão de uma baixa na integração pelo financeiro
                     */
                                       
                    //Monta comando para a gravação do registro
                    String strSQL = "insert into integbaixapagar (idintegfinanceiro, idpagarbaixa, statusbaixa, idusuarioorigem, dataprocessamento )" +
                                    "values (@idintegfinanceiro, @idpagarbaixa, @statusbaixa, @idusuarioorigem, @dataprocessamento) ";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idpagarbaixa", oInteg.idBaixaPagar.idPagarBaixa);
                    SqlconPar.Parameters.AddWithValue("@statusbaixa", oInteg.statusBaixa);
                    SqlconPar.Parameters.AddWithValue("@idusuarioorigem", oInteg.idUsuarioOrigem);
                    SqlconPar.Parameters.AddWithValue("@dataprocessamento", oInteg.dataProcessamento);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (oInteg.statusOperacao == "P")
                {
                    /*
                     * Operação de processamento da baixa no sistema de origem do documento
                     */

                    //Monta comando para a gravação do registro
                    String strSQL = "update integbaixapagar set statusbaixa=@statusbaixa, idusuarioorigem=@idusuarioorigem, dataprocessamento=@dataprocessamento " +
                                            " Where idintegfinanceiro = @idintegfinanceiro" +
                                            "   and idpagarbaixa = @idpagarbaixa";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idpagarbaixa", oInteg.idBaixaPagar.idPagarBaixa);
                    SqlconPar.Parameters.AddWithValue("@statusbaixa", oInteg.statusBaixa);
                    SqlconPar.Parameters.AddWithValue("@idusuarioorigem", oInteg.idUsuarioOrigem);
                    SqlconPar.Parameters.AddWithValue("@dataprocessamento", oInteg.dataProcessamento);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (oInteg.statusOperacao == "E")
                {
                    /*
                     * Estorno do processamento da baixa no sistema de origem
                     */

                    //Monta comando para a gravação do registro
                    String strSQL = "update integbaixapagar set statusbaixa='G', idusuarioorigem=null, dataprocessamento=null" +
                                            " Where idintegfinanceiro = @idintegfinanceiro" +
                                            "   and idpagarbaixa = @idpagarbaixa";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idpagarbaixa", oInteg.idBaixaPagar.idPagarBaixa);

                    SqlconPar.ExecuteNonQuery();
                    

                }
                else if (oInteg.statusOperacao == "C")
                {
                    /*
                     * Cancelamento da integração da baixa pelo o financeiro
                     */

                    //Monta comando para a gravação do registro
                    String strSQL = "delete from integbaixapagar Where idintegfinanceiro = @idintegfinanceiro" +
                                            "   and idpagarbaixa = @idpagarbaixa";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idpagarbaixa", oInteg.idBaixaPagar.idPagarBaixa);

                    SqlconPar.ExecuteNonQuery();

                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public IntegBaixaPagar ObterPor(IntegBaixaPagar oInteg)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from integbaixapagar " +
                                " Where idintegfinanceiro = @idintegfinanceiro" +
                                "   and idpagarbaixa = @idpagarbaixa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                Sqlcon.Parameters.AddWithValue("@idpagarbaixa", oInteg.idBaixaPagar.idPagarBaixa);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegBaixaPagar oIntegBaixa = new IntegBaixaPagar();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oIntegBaixa.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());

                    PagarBaixa oFinBaixa = new PagarBaixa();
                    oFinBaixa.idPagarBaixa = EmcResources.cInt(drCon["idpagarbaixa"].ToString());
                    oIntegBaixa.idBaixaPagar = oFinBaixa;

                    oIntegBaixa.dataProcessamento = Convert.ToDateTime(drCon["dataprocessamento"].ToString());
                    oIntegBaixa.idUsuarioOrigem = EmcResources.cInt(drCon["idusuarioorigem"].ToString());
                    oIntegBaixa.statusBaixa = drCon["statusgeracao"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarBaixaDAO oFinBaixaDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    oIntegBaixa.idBaixaPagar = oFinBaixaDAO.ObterPor(oIntegBaixa.idBaixaPagar);
                }
                return oIntegBaixa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        
    }
}
