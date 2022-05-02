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
    public class TarifaBancariaRN
    {

        TarifaBancariaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TarifaBancariaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaTarifaBancaria()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TarifaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaTarifaBancaria();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaTarifaBancariaBaixa(int idCtaBancaria)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TarifaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaTarifaBancariaBaixa(idCtaBancaria);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(TarifaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new TarifaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(TarifaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new TarifaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(TarifaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new TarifaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public TarifaBancaria ObterPor(TarifaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new TarifaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
                objConta = objBLL.ObterPor(objConta);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return objConta;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(TarifaBancaria obj)
        {

            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descricao não pode ser nula");
                throw objErro;
            }
            if (obj.nroDocumento.Trim().Length == 0)
            {
                objErro = new Exception("Número do Documento não pode ser nulo");
                throw objErro;
            }
            if (obj.contaCusto.idContaCusto <= 0)
            {
                objErro = new Exception("Conta Custo não pode ser nula");
                throw objErro;
            }
            if (obj.aplicacao.idAplicacao <= 0)
            {
                objErro = new Exception("Aplicacção não pode ser nula");
                throw objErro;
            }
            if (obj.contaBancaria.idCtaBancaria <= 0)
            {
                objErro = new Exception("Conta Bancaria não pode ser nula");
                throw objErro;
            }
            if (obj.fornecedor.idPessoa <= 0)
            {
                objErro = new Exception("Fornecedor não pode ser nula");
                throw objErro;
            }
        }

        #endregion


    }
}
