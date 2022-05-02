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
    public class AplicacaoRN
    {

        AplicacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AplicacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe
       
        public DataTable pesquisaAplicacao(int empMaster, int idAplicacao, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new AplicacaoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.pesquisaAplicacaco(empMaster, idAplicacao, nome);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
    
        public DataTable ListaAplicacao()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new AplicacaoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaAplicacao();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
       
        //Retorna DataTable com o conteúdo da consulta passada como parâmetro
        public DataTable ListaAplicacao(String SSQL)
           {
           DataTable dtCon = new DataTable();

           try
              {
              objBLL = new AplicacaoDAO(Conexao, oOcorrencia,codEmpresa);
              dtCon = objBLL.dstRelatorio(SSQL);
              }
           catch (Exception erro)
              {
              throw erro;
              }
           return dtCon;
           }

       public void Atualizar(Aplicacao objAplicacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAplicacao);

                objBLL = new AplicacaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objAplicacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Aplicacao objAplicacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAplicacao);

                objBLL = new AplicacaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objAplicacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Aplicacao objAplicacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAplicacao);

                objBLL = new AplicacaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objAplicacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Aplicacao ObterPor(Aplicacao objAplicacao)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objAplicacao);

                objBLL = new AplicacaoDAO(Conexao,oOcorrencia,codEmpresa);
                objAplicacao = objBLL.ObterPor(objAplicacao);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objAplicacao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Aplicacao obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição da Aplicação não pode estar vazia");
                throw objErro;
            }
        }

        #endregion

    }
}
