using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCLibrary;
using EMCImobModel;
using EMCImobDAO;
using EMCSecurityModel;


namespace EMCImobRN
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

        public void integraLocacaoReceber(List<LocacaoReceber> lstReceber, int idUsuario)
        {
            try
            {
                objBLL = new IntegracaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.integraLocacaoReceber(lstReceber, idUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void integraLocacaoPagar(List<LocacaoPagar> lstPagar, int idUsuario)
        {
            try
            {
                objBLL = new IntegracaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.integraLocacaoPagar(lstPagar, idUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        

    }
}
