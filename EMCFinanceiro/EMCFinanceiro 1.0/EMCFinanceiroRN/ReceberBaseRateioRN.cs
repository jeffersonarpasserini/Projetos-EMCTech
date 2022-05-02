using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;
using EMCSecurityModel;

namespace EMCFinanceiroRN
{
    public class ReceberBaseRateioRN
    {
        ReceberBaseRateioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberBaseRateioRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaReceberBaseRateio(int idReceberBaseRateio)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReceberBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaReceberBaseRateio(idReceberBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(List<ReceberBaseRateio> lstReceberBaseRateio)
        {
            try
            {

                objBLL = new ReceberBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(lstReceberBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(List<ReceberBaseRateio> lstReceberBaseRateio)
        {

            try
            {

                objBLL = new ReceberBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(lstReceberBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(List<ReceberBaseRateio> lstReceberBaseRateio)
        {
            try
            {


                objBLL = new ReceberBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(lstReceberBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ReceberBaseRateio ObterPor(ReceberBaseRateio oReceberBaseRateio)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objReceberBaseRateio);

                objBLL = new ReceberBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                oReceberBaseRateio = objBLL.ObterPor(oReceberBaseRateio);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oReceberBaseRateio;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(List<ReceberBaseRateio> obj, decimal vlrDocumento)
        {

            Exception objErro;
            decimal somaValor = 0;
            decimal somaPercentual = 0;
            foreach (ReceberBaseRateio oRateio in obj)
            {
                if (oRateio.status != "E")
                {
                    somaValor = somaValor + EmcResources.cCur(oRateio.valorRateio.ToString());
                    somaPercentual = somaPercentual + EmcResources.cCur(oRateio.percentualRateio.ToString());
                }
                if (String.IsNullOrEmpty(oRateio.aplicacao.idAplicacao.ToString()))
                {
                    objErro = new Exception("A aplicação do ReceberBaseRateio não pode estar vazia");
                    throw objErro;
                }
                if (String.IsNullOrEmpty(oRateio.contaCusto.codigoConta.ToString()))
                {
                    objErro = new Exception("Conta Custo do ReceberBaseRateio não pode estar vazia");
                    throw objErro;
                }
                
            }
            if (!somaPercentual.Equals(100))
            {
                objErro = new Exception("A ReceberBaseRateio deve ser de 100% do valor do documento ");
                throw objErro;
            }

            if (!somaValor.Equals(vlrDocumento))
            {
                objErro = new Exception("A Soma do Rateio deve conferir com o valor do documento ");
                throw objErro;
            }
        }

        #endregion






    }
}
