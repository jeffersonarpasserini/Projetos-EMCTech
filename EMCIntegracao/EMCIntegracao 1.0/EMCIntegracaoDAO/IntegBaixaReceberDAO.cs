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
    public class IntegBaixaReceberDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IntegBaixaReceberDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<IntegBaixaReceber> lstIntegBaixaReceber(int idIntegFinanceiro)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                
                String strSQL = "select * from integbaixaReceber Where idintegfinanceiro = @idintegfinanceiro";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idintegfinanceiro", idIntegFinanceiro);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<IntegBaixaReceber> lstMontagem = new List<IntegBaixaReceber>();
                List<IntegBaixaReceber> lstRetorno = new List<IntegBaixaReceber>();


                while (drCon.Read())
                {
                    consulta = true;
                    IntegBaixaReceber oBaixa = new IntegBaixaReceber();

                    oBaixa.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());

                    ReceberBaixa oFinBaixa = new ReceberBaixa();
                    oFinBaixa.idReceberBaixa = EmcResources.cInt(drCon["idReceberbaixa"].ToString());
                    oBaixa.idBaixaReceber = oFinBaixa;

                    lstMontagem.Add(oBaixa);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ReceberBaixaDAO oFinBaixaDAO = new ReceberBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    foreach (IntegBaixaReceber oBx in lstMontagem)
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

        public void Salvar(IntegBaixaReceber oInteg, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oInteg.statusOperacao == "I")
                {
                    /*
                     * Operação de inclusão de uma baixa na integração pelo financeiro
                     */
                                       
                    //Monta comando para a gravação do registro
                    String strSQL = "insert into integbaixaReceber (idintegfinanceiro, idReceberbaixa, statusbaixa, idusuarioorigem, dataprocessamento )" +
                                    "values (@idintegfinanceiro, @idReceberbaixa, @statusbaixa, @idusuarioorigem, @dataprocessamento) ";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idReceberbaixa", oInteg.idBaixaReceber.idReceberBaixa);
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
                    String strSQL = "update integbaixaReceber set statusbaixa=@statusbaixa, idusuarioorigem=@idusuarioorigem, dataprocessamento=@dataprocessamento " +
                                            " Where idintegfinanceiro = @idintegfinanceiro" +
                                            "   and idReceberbaixa = @idReceberbaixa";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idReceberbaixa", oInteg.idBaixaReceber.idReceberBaixa);
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
                    String strSQL = "update integbaixaReceber set statusbaixa='G', idusuarioorigem=null, dataprocessamento=null" +
                                            " Where idintegfinanceiro = @idintegfinanceiro" +
                                            "   and idReceberbaixa = @idReceberbaixa";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idReceberbaixa", oInteg.idBaixaReceber.idReceberBaixa);

                    SqlconPar.ExecuteNonQuery();
                    

                }
                else if (oInteg.statusOperacao == "C")
                {
                    /*
                     * Cancelamento da integração da baixa pelo o financeiro
                     */

                    //Monta comando para a gravação do registro
                    String strSQL = "delete from integbaixaReceber Where idintegfinanceiro = @idintegfinanceiro" +
                                            "   and idReceberbaixa = @idReceberbaixa";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                    SqlconPar.Parameters.AddWithValue("@idReceberbaixa", oInteg.idBaixaReceber.idReceberBaixa);

                    SqlconPar.ExecuteNonQuery();

                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public IntegBaixaReceber ObterPor(IntegBaixaReceber oInteg)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from integbaixaReceber " +
                                " Where idintegfinanceiro = @idintegfinanceiro" +
                                "   and idReceberbaixa = @idReceberbaixa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idintegfinanceiro", oInteg.idIntegFinanceiro);
                Sqlcon.Parameters.AddWithValue("@idReceberbaixa", oInteg.idBaixaReceber.idReceberBaixa);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IntegBaixaReceber oIntegBaixa = new IntegBaixaReceber();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oIntegBaixa.idIntegFinanceiro = EmcResources.cInt(drCon["idintegfinanceiro"].ToString());

                    ReceberBaixa oFinBaixa = new ReceberBaixa();
                    oFinBaixa.idReceberBaixa = EmcResources.cInt(drCon["idReceberbaixa"].ToString());
                    oIntegBaixa.idBaixaReceber = oFinBaixa;

                    oIntegBaixa.dataProcessamento = Convert.ToDateTime(drCon["dataprocessamento"].ToString());
                    oIntegBaixa.idUsuarioOrigem = EmcResources.cInt(drCon["idusuarioorigem"].ToString());
                    oIntegBaixa.statusBaixa = drCon["statusgeracao"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ReceberBaixaDAO oFinBaixaDAO = new ReceberBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    oIntegBaixa.idBaixaReceber = oFinBaixaDAO.ObterPor(oIntegBaixa.idBaixaReceber);
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
