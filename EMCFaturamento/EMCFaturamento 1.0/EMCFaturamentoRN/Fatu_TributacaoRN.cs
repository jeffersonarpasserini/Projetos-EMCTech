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
    public class Fatu_TributacaoRN
    {

        Fatu_TributacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_TributacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_Tributacao()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_TributacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_Tributacao();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_Tributacao objFatu_Tributacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_Tributacao);

                objBLL = new Fatu_TributacaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objFatu_Tributacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_Tributacao objFatu_Tributacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_Tributacao);

                objBLL = new Fatu_TributacaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objFatu_Tributacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_Tributacao objFatu_Tributacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_Tributacao);

                objBLL = new Fatu_TributacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_Tributacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_Tributacao ObterPor(Fatu_Tributacao objFatu_Tributacao)
        {
            try
            {
                objBLL = new Fatu_TributacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_Tributacao = objBLL.ObterPor(objFatu_Tributacao);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_Tributacao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_Tributacao obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.advertencia))
            {
                objErro = new Exception("Advertência deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.situacao))
            {
                objErro = new Exception("Situação deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.sistematributacao))
            {
                objErro = new Exception("Sistema de Tributação deve ser informado");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.codigotributacao))
            {
                objErro = new Exception("Código de Tributação deve ser informado");
                throw objErro;
            }
        }

        #endregion
    }
}
