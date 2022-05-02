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
    public class TipoCobrancaRN
    {
        TipoCobrancaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoCobrancaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaTipoCobranca()
        {
            DataTable dtCon = new DataTable();
            
            try
            {
                TipoCobrancaDAO oTpCobranca = new TipoCobrancaDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = oTpCobranca.ListaTipoCobranca();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        //Retorna DataSet com o conteúdo da consulta passada como parâmetro
        public DataTable ListaTipoCobranca(String SSQL)
           {
           DataTable dtCon = new DataTable();

           try
              {
              objBLL = new TipoCobrancaDAO(Conexao, oOcorrencia,codEmpresa);
              dtCon = objBLL.dstRelatorio(SSQL);
              }
           catch (Exception erro)
              {
              throw erro;
              }
           return dtCon;
           }


       public void Atualizar(TipoCobranca objTipoCobranca)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoCobranca);

                objBLL = new TipoCobrancaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objTipoCobranca);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(TipoCobranca objTipoCobranca)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoCobranca);

                objBLL = new TipoCobrancaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objTipoCobranca);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(TipoCobranca objTipoCobranca)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoCobranca);

                objBLL = new TipoCobrancaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objTipoCobranca);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public TipoCobranca ObterPor(TipoCobranca objTipoCobranca)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objTipoCobranca);

                objBLL = new TipoCobrancaDAO(Conexao,oOcorrencia,codEmpresa);
                objTipoCobranca = objBLL.ObterPor(objTipoCobranca);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objTipoCobranca;

        }

        public DataTable pesquisaTipoCobranca(int empMaster, int idTipoCobranca, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new TipoCobrancaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaTipoCobranca(empMaster, idTipoCobranca, descricao);

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
        private void VerificaDados(TipoCobranca obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição do Tipo Cobrança não pode estar vazia");
                throw objErro;
            }
        }

        #endregion

    }
}
