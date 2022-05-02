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
    public class Fatu_SituacaoFiscalIPIRN
    {

        Fatu_SituacaoFiscalIPIDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_SituacaoFiscalIPIRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_SituacaoFiscalIPI(string Situacao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_SituacaoFiscalIPIDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_SituacaoFiscalIPI(Situacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoFiscalIPI);

                objBLL = new Fatu_SituacaoFiscalIPIDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_SituacaoFiscalIPI);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoFiscalIPI);

                objBLL = new Fatu_SituacaoFiscalIPIDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_SituacaoFiscalIPI);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoFiscalIPI);

                objBLL = new Fatu_SituacaoFiscalIPIDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_SituacaoFiscalIPI);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_SituacaoFiscalIPI ObterPor(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            try
            {
                objBLL = new Fatu_SituacaoFiscalIPIDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_SituacaoFiscalIPI = objBLL.ObterPor(objFatu_SituacaoFiscalIPI);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_SituacaoFiscalIPI;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_SituacaoFiscalIPI obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.codigosituacaoipi))
            {
                objErro = new Exception("O Código Situação IPI deve ser informado");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.entradasaida))
            {
                objErro = new Exception("Tipo Entrada|Saída deve ser informado");
                throw objErro;
            }
        }

        #endregion
    }
}
