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
    public class Fatu_SituacaoPisRN
    {
        Fatu_SituacaoPisDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_SituacaoPisRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_SituacaoPis()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_SituacaoPisDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_SituacaoPis();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoPis);

                objBLL = new Fatu_SituacaoPisDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_SituacaoPis);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoPis);

                objBLL = new Fatu_SituacaoPisDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_SituacaoPis);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoPis);

                objBLL = new Fatu_SituacaoPisDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_SituacaoPis);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_SituacaoPis ObterPor(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            try
            {
                objBLL = new Fatu_SituacaoPisDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_SituacaoPis = objBLL.ObterPor(objFatu_SituacaoPis);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_SituacaoPis;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_SituacaoPis obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }

            if (EmcResources.cInt(obj.codigoFiscal) < 0 || EmcResources.cInt(obj.codigoFiscal) > 99)
            {
                objErro = new Exception("Código de Fiscal Invalido");
                throw objErro;
            }
        }

        #endregion


    }
}
