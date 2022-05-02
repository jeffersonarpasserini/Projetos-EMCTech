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

namespace EMCFinanceiroRN
{
    public class LayoutChequeRN
    {

        LayoutChequeDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LayoutChequeRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }


        public DataTable ListaLayoutCheque(CtaBancaria oConta)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LayoutChequeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaLayoutCheque(oConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }


        public LayoutCheque ObterPor(LayoutCheque objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new LayoutChequeDAO(Conexao, oOcorrencia, codEmpresa);
                objConta = objBLL.ObterPor(objConta);


            }
            catch (Exception erro)
            {
                throw erro;
            }

            return objConta;

        }
    }

}
