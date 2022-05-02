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
    public class CepRN
    {

        CepDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CepRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable pesquisaCep(int empMaster, int idCep, string cidade, string estado, bool checkEstado)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new CepDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaCep(empMaster, idCep, cidade, estado, checkEstado);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }


        public DataTable ListaCep()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new CepDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaCep();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        //Retorna DataSet com o conteúdo da consulta passada como parâmetro
        public DataTable ListaCep(String SSQL)
           {
           DataTable dtCon = new DataTable();

           try
              {
              objBLL = new CepDAO(Conexao, oOcorrencia,codEmpresa);
              dtCon = objBLL.dstRelatorio(SSQL);
              }
           catch (Exception erro)
              {
              throw erro;
              }
           return dtCon;
           }

        public void Atualizar(Cep objCep)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCep);

                objBLL = new CepDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objCep);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Cep objCep)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCep);

                objBLL = new CepDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objCep);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Cep objCep)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCep);

                objBLL = new CepDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objCep);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Cep ObterPor(Cep objCep)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new CepDAO(Conexao,oOcorrencia,codEmpresa);
                objCep = objBLL.ObterPor(objCep);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCep;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Cep obj)
        {

            Exception objErro;

            if (obj.idCep.Trim().Length == 0)
            {
                objErro = new Exception("Número do CEP não pode ser nulo");
                throw objErro;
            }
            if (obj.idCep.Trim().Length < 8)
            {
                objErro = new Exception("Formato do CEP inválido");
                throw objErro;
            }
            if (obj.cidade.Trim().Length == 0)
            {
                objErro = new Exception("Cidade não pode ser nula");
                throw objErro;
            }
            if (obj.estado.Trim().Length == 0)
            {
                objErro = new Exception("Estado não pode ser nulo");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.bairro))
            {
                objErro = new Exception("O Bairro não pode ser nulo");
                throw objErro;
            }
        }

        #endregion

    }
}
