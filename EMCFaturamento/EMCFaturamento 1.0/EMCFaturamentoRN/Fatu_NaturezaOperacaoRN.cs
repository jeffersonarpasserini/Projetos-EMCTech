using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCFaturamentoModel;
using EMCFaturamentoDAO;
using EMCSecurityModel;

namespace EMCFaturamentoRN
{
    public class Fatu_NaturezaOperacaoRN
    {
        Fatu_NaturezaOperacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_NaturezaOperacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_NaturezaOperacao()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_NaturezaOperacaoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaFatu_NaturezaOperacao();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_NaturezaOperacao, "A");

                objBLL = new Fatu_NaturezaOperacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_NaturezaOperacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_NaturezaOperacao, "I");

                objBLL = new Fatu_NaturezaOperacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_NaturezaOperacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_NaturezaOperacao, "E");

                objBLL = new Fatu_NaturezaOperacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_NaturezaOperacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_NaturezaOperacao ObterPor(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            try
            {
                objBLL = new Fatu_NaturezaOperacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_NaturezaOperacao = objBLL.ObterPor(objFatu_NaturezaOperacao);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_NaturezaOperacao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_NaturezaOperacao obj, string sOperacao)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }
           

        }

        #endregion

    }
}
