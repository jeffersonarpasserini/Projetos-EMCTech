using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCLibrary;
using EMCIntegracaoDAO;
using EMCIntegracaoModel;



namespace EMCIntegracaoRN
{
    public class IntegFinanceiroRN
    {
        IntegFinanceiroDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IntegFinanceiroRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public List<IntegFinanceiro> lstGeracaoIntegracao(String origem = "TODOS")
        {
            List<IntegFinanceiro> lstIntegracao = new List<IntegFinanceiro>();
            try
            {
                objBLL = new IntegFinanceiroDAO(Conexao, oOcorrencia, codEmpresa);
                lstIntegracao = objBLL.lstGeracaoIntegracao(origem);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstIntegracao;
        }

        public IntegFinanceiro ObterPor(int idIntegracao)
        {
            IntegFinanceiro oInteg = new IntegFinanceiro();
            try
            {
                objBLL = new IntegFinanceiroDAO(Conexao, oOcorrencia, codEmpresa);
                oInteg = objBLL.ObterPor(idIntegracao);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oInteg;

        }

        #endregion

      
    }
}
