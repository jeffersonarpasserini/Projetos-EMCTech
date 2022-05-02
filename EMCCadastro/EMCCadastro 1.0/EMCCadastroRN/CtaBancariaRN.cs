using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;

namespace EMCCadastroRN
{
    public class CtaBancariaRN
    {
        CtaBancariaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CtaBancariaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

       public DataTable ListaCtaBancaria(CtaBancaria oConta)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new CtaBancariaDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaCtaBancaria(oConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

       public DataTable ListaCtaCaixa(CtaBancaria oConta)
       {
           DataTable dtCon = new DataTable();

           try
           {
               objBLL = new CtaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
               dtCon = objBLL.ListaCtaCaixa(oConta);
           }
           catch (Exception erro)
           {
               throw erro;
           }
           return dtCon;
       }
        
       //Retorna DataSet com o conteúdo da consulta passada como parâmetro
       public DataTable ListaCtaBancaria(String sSQL)
          {
          DataTable dtCon = new DataTable();
          
          try
            {
               objBLL = new CtaBancariaDAO(Conexao, oOcorrencia,codEmpresa);
               dtCon = objBLL.dstRelatorio(sSQL);
            }
          catch (Exception erro)
            {
             throw erro;
            }
          return dtCon;
          }

       public void Atualizar(CtaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new CtaBancariaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

       public void Salvar(CtaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new CtaBancariaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

       public void Excluir(CtaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new CtaBancariaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

       public CtaBancaria ObterPor(CtaBancaria objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new CtaBancariaDAO(Conexao,oOcorrencia,codEmpresa);
                objConta = objBLL.ObterPor(objConta);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return objConta;

        }

       public DataTable pesquisaCtaBancaria(int empMaster, int idctabancaria, int conta, int agencia, int idBanco)
       {
           DataTable dtCon = new DataTable();

           try
           {

               objBLL = new CtaBancariaDAO(Conexao, oOcorrencia, codEmpresa);
               dtCon = objBLL.pesquisaCtaBancaria(empMaster, idctabancaria, conta, agencia,  idBanco);

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
       
        public void VerificaDados(CtaBancaria obj)
        {

            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            if (obj.idCtaBancaria < 0)
            {
                objErro = new Exception("Código da Conta não pode ser nulo");
                throw objErro;
            }

        }

        #endregion

    }
}
