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
    public class PagarBaixaRN
    {

        PagarBaixaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarBaixaRN(ConectaBancoMySql pConexao,Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe
        /// <summary>
        /// Calcula Saldo Adiantamento para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSdoAdiantamento(Fornecedor codFornecedor)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSdoAdiantamento(codFornecedor);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }

        public DataTable listaBaixaRecibo(string idMovimentoBancario)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaBaixaRecibo(idMovimentoBancario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public List<PagarBaixa> listaBaixasParcela(int? idPagarParcela)
        {
            List<PagarBaixa> lstBaixa = new List<PagarBaixa>();
            try
            {
                PagarBaixaDAO oBaixaDAO = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                lstBaixa = oBaixaDAO.listaBaixasParcela(idPagarParcela);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstBaixa;
        }

        public DataTable pesquisaBaixaCompensar(int codEmpresa, int empMaster, int idFornecedor)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaBaixaCompensar(codEmpresa, empMaster, idFornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaPagarBaixa(PagarParcela oParcela)
        {
            DataTable dtCon = new DataTable();

            try
            {
                PagarBaixa oBaixa = new PagarBaixa();
                oBaixa.pagarParcela = oParcela;

                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaPagarBaixa(oBaixa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Salvar(List<PagarBaixa> lstPagarBaixa, String TipoPagamento)
        {
            try
            {
                PagarBaixaDAO oBaixaDAO = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                oBaixaDAO.Salvar(lstPagarBaixa, TipoPagamento);

            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public PagarBaixa ObterPor(PagarBaixa objPagarBaixa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objPagarBaixa);

                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                objPagarBaixa = objBLL.ObterPor(objPagarBaixa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objPagarBaixa;

        }

        public Boolean verificaBaixaDtaContabil(int idPagarDocumento)
        {
            Boolean valida = false;
            try
            {
                
                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                valida = objBLL.verificaBaixaDtaContabil(idPagarDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return valida;

        }

        public DataTable relatorioBaixas(DateTime dataInicio, DateTime dataFinal, int empMaster, int idfornecedor, Boolean chkFornecedor, int idctabancaria, Boolean chkconta, int idformaPagto, Boolean chkpagto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.relatorioBaixas(dataInicio, dataFinal, empMaster, idfornecedor, chkFornecedor, idctabancaria, chkconta, idformaPagto, chkpagto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(PagarBaixa obj)
        {

           // Exception objErro;
        }

        #endregion





    }
}
