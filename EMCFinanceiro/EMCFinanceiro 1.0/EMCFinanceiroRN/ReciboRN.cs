using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;
using EMCSecurityModel;
using EMCLibrary;

namespace EMCFinanceiroRN
{
    public class ReciboRN
    {
        ReciboDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReciboRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public int Salvar(Recibo oRecibo)
        {
            try
            {
                objBLL = new ReciboDAO(Conexao, oOcorrencia, codEmpresa);
                int idRecibo = objBLL.Salvar(oRecibo);

                return idRecibo;
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public DataTable dstReciboSimples(String idRecibo)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReciboDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstReciboSimples(idRecibo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;

        }


    }
}
