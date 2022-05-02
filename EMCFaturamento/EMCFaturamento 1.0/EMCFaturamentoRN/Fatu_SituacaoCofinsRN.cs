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
    public class Fatu_SituacaoCofinsRN
    {

        Fatu_SituacaoCofinsDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_SituacaoCofinsRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_SituacaoCofins()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_SituacaoCofinsDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_SituacaoCofins();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoCofins);

                objBLL = new Fatu_SituacaoCofinsDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_SituacaoCofins);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoCofins);

                objBLL = new Fatu_SituacaoCofinsDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_SituacaoCofins);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_SituacaoCofins);

                objBLL = new Fatu_SituacaoCofinsDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_SituacaoCofins);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_SituacaoCofins ObterPor(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            try
            {
                objBLL = new Fatu_SituacaoCofinsDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_SituacaoCofins = objBLL.ObterPor(objFatu_SituacaoCofins);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_SituacaoCofins;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_SituacaoCofins obj)
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
