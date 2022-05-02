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
    public class PagarBaseRateioRN
    {

        PagarBaseRateioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarBaseRateioRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaPagarBaseRateio(int idPagarBaseRateio)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaPagarBaseRateio(idPagarBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(List<PagarBaseRateio> lstPagarBaseRateio)
        {
            try
            {

                objBLL = new PagarBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(lstPagarBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(List<PagarBaseRateio> lstPagarBaseRateio)
        {

            try
            {

                objBLL = new PagarBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(lstPagarBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(List<PagarBaseRateio> lstPagarBaseRateio)
        {
            try
            {


                objBLL = new PagarBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(lstPagarBaseRateio);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public PagarBaseRateio ObterPor(PagarBaseRateio oPagarBaseRateio)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objPagarBaseRateio);

                objBLL = new PagarBaseRateioDAO(Conexao, oOcorrencia, codEmpresa);
                oPagarBaseRateio = objBLL.ObterPor(oPagarBaseRateio);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oPagarBaseRateio;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(List<PagarBaseRateio> obj, decimal vlrDocumento)
        {

            Exception objErro;
            decimal somaValor = 0;
            decimal somaPercentual = 0;
            foreach (PagarBaseRateio oRateio in obj)
            {
                if (oRateio.status != "E")
                {
                    somaValor = somaValor + EmcResources.cCur(oRateio.valorRateio.ToString());
                    somaPercentual = somaPercentual + EmcResources.cCur(oRateio.percentualRateio.ToString());
                }
                if (String.IsNullOrEmpty(oRateio.aplicacao.idAplicacao.ToString()))
                {
                    objErro = new Exception("A aplicação do PagarBaseRateio não pode estar vazia");
                    throw objErro;
                }
                if (String.IsNullOrEmpty(oRateio.contaCusto.codigoConta.ToString()))
                {
                    objErro = new Exception("Conta Custo do PagarBaseRateio não pode estar vazia");
                    throw objErro;
                }
                
            }
            if (!somaPercentual.Equals(100))
            {
                objErro = new Exception("A PagarBaseRateio deve ser de 100% do valor do documento ");
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
