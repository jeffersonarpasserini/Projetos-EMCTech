using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;
using EMCIntegracaoModel;

namespace EMCFinanceiroRN
{
    public class IntegracaoRN
    {
        IntegracaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IntegracaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public void Salvar(ReceberDocumento oReceber, IntegFinanceiro oInteg)
        {
            try
            {
                objBLL = new IntegracaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(oReceber,oInteg);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(PagarDocumento oPagar, IntegFinanceiro oInteg)
        {
            try
            {
                objBLL = new IntegracaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(oPagar, oInteg);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }


    }
}
