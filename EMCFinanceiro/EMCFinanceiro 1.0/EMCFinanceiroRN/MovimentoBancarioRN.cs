using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCFinanceiroModel;
using EMCFinanceiroDAO;
using EMCSecurityModel;

namespace EMCFinanceiroRN
{
    public class MovimentoBancarioRN
    {

        MovimentoBancarioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public MovimentoBancarioRN(ConectaBancoMySql pConexao,Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable extratoPeriodo(CtaBancaria oCta, DateTime dataInicio, DateTime dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.extratoPeriodo(oCta, dataInicio, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public Decimal calculaCredito(int codEmpresa, DateTime dataInicio, DateTime dataFinal, CtaBancaria oConta, bool conciliado)
        {
            Decimal valorCredito = 0;
            try
            {
                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                valorCredito = objBLL.calculaCredito(codEmpresa, dataInicio, dataFinal, oConta, conciliado);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return valorCredito;
        }

        public Decimal calculaDebito(int codEmpresa, DateTime dataInicio, DateTime dataFinal, CtaBancaria oConta, bool conciliado)
        {
            Decimal valorDebito = 0;
            try
            {
                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                valorDebito = objBLL.calculaDebito(codEmpresa, dataInicio, dataFinal, oConta, conciliado);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return valorDebito;
        }

        public DataTable ListaExtratoBancario(int codempresa, int empmaster, int idConta, DateTime dtaInicio, DateTime dtaFinal, bool conciliado)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaExtratoBancario(codempresa,empmaster,idConta, dtaInicio, dtaFinal,conciliado);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaMovimentoBancario()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaMovimentoBancario();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable listaControleCaixa(int idControleCaixa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaControleCaixa(idControleCaixa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public decimal calculaSdoCtrCaixa(int idControleCaixa)
        {
            decimal saldoAtual;
            try
            {

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                saldoAtual = objBLL.calculaSdoCtrCaixa(idControleCaixa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldoAtual;
        }


        public void conciliaMovimento(List<MovimentoBancario> lstMovBanco)
        {
            try
            {

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.conciliaMovimento(lstMovBanco);

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Atualizar(MovimentoBancario objMovimentoBancario)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMovimentoBancario);

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objMovimentoBancario);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(MovimentoBancario objMovimentoBancario)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMovimentoBancario);

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objMovimentoBancario);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(MovimentoBancario objMovimentoBancario)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMovimentoBancario);

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objMovimentoBancario);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public MovimentoBancario ObterPor(MovimentoBancario objMovimentoBancario)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objMovimentoBancario);

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                objMovimentoBancario = objBLL.ObterPor(objMovimentoBancario);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objMovimentoBancario;

        }
        public List<MovimentoBancario> lstMovimentoCaixa(int idControleCaixa)
        {
            List<MovimentoBancario> lstMovBanco = new List<MovimentoBancario>();
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objMovimentoBancario);

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                lstMovBanco = objBLL.lstMovimentoCaixa(idControleCaixa);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstMovBanco;

        }
        public List<MovimentoBancario> lstEmissaoRecibo(string tipoMovimento, DateTime dtaInicio, DateTime dtaFinal)
        {
            List<MovimentoBancario> lstMovBanco = new List<MovimentoBancario>();
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objMovimentoBancario);

                objBLL = new MovimentoBancarioDAO(Conexao, oOcorrencia, codEmpresa);
                lstMovBanco = objBLL.lstEmissaoRecibo(tipoMovimento, dtaInicio, dtaFinal);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstMovBanco;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(MovimentoBancario obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.historico))
            {
                objErro = new Exception("A descrição do MovimentoBancario não pode estar vazia");
                throw objErro;
            }
        }

        #endregion

    }
}
