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
    public class ReceberBaixaRN
    {

        ReceberBaixaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberBaixaRN(ConectaBancoMySql pConexao,Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        /// <summary>
        /// Calcula Saldo Adiantamento para um Cliente
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSdoAdiantamento(Cliente Cliente)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSdoAdiantamento(Cliente);


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
                objBLL = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaBaixaRecibo(idMovimentoBancario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public List<ReceberBaixa> listaBaixasParcela(int? idReceberParcela)
        {
            List<ReceberBaixa> lstBaixa = new List<ReceberBaixa>();
            try
            {
                ReceberBaixaDAO oBaixaDAO = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                lstBaixa = oBaixaDAO.listaBaixasParcela(idReceberParcela);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstBaixa;
        }

        public DataTable pesquisaBaixaCompensar(int codEmpresa, int empMaster, int idCliente)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaBaixaCompensar(codEmpresa, empMaster, idCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaReceberBaixa(ReceberParcela oParcela)
        {
            DataTable dtCon = new DataTable();

            try
            {
                ReceberBaixa oBaixa = new ReceberBaixa();
                oBaixa.receberParcela = oParcela;

                objBLL = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaReceberBaixa(oBaixa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Salvar(List<ReceberBaixa> lstReceberBaixa, String TipoPagamento)
        {
            try
            {
                ReceberBaixaDAO oBaixaDAO = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                oBaixaDAO.Salvar(lstReceberBaixa, TipoPagamento);

            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ReceberBaixa ObterPor(ReceberBaixa objReceberBaixa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objReceberBaixa);

                objBLL = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                objReceberBaixa = objBLL.ObterPor(objReceberBaixa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objReceberBaixa;

        }

        public Boolean verificaBaixaDtaContabil(int idReceberDocumento)
        {
            Boolean valida = false;
            try
            {

                objBLL = new ReceberBaixaDAO(Conexao, oOcorrencia, codEmpresa);
                valida = objBLL.verificaBaixaDtaContabil(idReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return valida;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(ReceberBaixa obj)
        {

           //Exception objErro;
        }

        #endregion





    }
}
