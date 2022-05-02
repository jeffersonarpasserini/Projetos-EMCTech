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
    public class FormaPagamentoRN
    {

        FormaPagamentoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FormaPagamentoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFormaPagamento()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FormaPagamentoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaFormaPagamento();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        //Retorna DataSet com o conteúdo da consulta passada como parâmetro
        public DataTable ListaFormaPagamento(String SSQL)
           {
           DataTable dtCon = new DataTable();

           try
              {
              objBLL = new FormaPagamentoDAO(Conexao, oOcorrencia,codEmpresa);
              dtCon = objBLL.dstRelatorio(SSQL);
              }
           catch (Exception erro)
              {
              throw erro;
              }
           return dtCon;
           }

        public void Atualizar(FormaPagamento objFormaPagamento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFormaPagamento);

                objBLL = new FormaPagamentoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objFormaPagamento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(FormaPagamento objFormaPagamento)
        {
            try
            {
                VerificaDados(objFormaPagamento);                  
                objBLL = new FormaPagamentoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objFormaPagamento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(FormaPagamento objFormaPagamento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFormaPagamento);

                objBLL = new FormaPagamentoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objFormaPagamento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public FormaPagamento ObterPor(FormaPagamento objFormaPagamento)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objFormaPagamento);

                objBLL = new FormaPagamentoDAO(Conexao,oOcorrencia,codEmpresa);
                objFormaPagamento = objBLL.ObterPor(objFormaPagamento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFormaPagamento;

        }

        public DataTable pesquisaFormaPagamento(int empMaster, int idFormaPagamento, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new FormaPagamentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaFormaPagamento(empMaster, idFormaPagamento, descricao);

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
        
        private void VerificaDados(FormaPagamento obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição da Forma Pagamento não pode estar vazia");
                throw objErro;
            }

            if (obj.historicoPadrao.idHistorico <= 0)
            {
                objErro = new Exception("O Histórico Padrão não pode estar vazio");
                throw objErro;
            }

        }

        #endregion

    }
}
