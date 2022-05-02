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
    public class Fatu_TributacaoUfRN
    {

        Fatu_TributacaoUfDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_TributacaoUfRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_TributacaoUf()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_TributacaoUfDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_TributacaoUf();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_TributacaoUf);

                objBLL = new Fatu_TributacaoUfDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_TributacaoUf);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_TributacaoUf);

                objBLL = new Fatu_TributacaoUfDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_TributacaoUf);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_TributacaoUf);

                objBLL = new Fatu_TributacaoUfDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_TributacaoUf);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_TributacaoUf ObterPor(Fatu_TributacaoUf objFatu_TributacaoUf)
        {
            try
            {
                objBLL = new Fatu_TributacaoUfDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_TributacaoUf = objBLL.ObterPor(objFatu_TributacaoUf);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_TributacaoUf;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_TributacaoUf obj)
        {

            Exception objErro;

            //if (String.IsNullOrEmpty(obj.descricao))
            //{
            //    objErro = new Exception("A Descrição deve ser informada");
            //    throw objErro;
            //}

            //if (String.IsNullOrEmpty(obj.situacao))
            //{
            //    objErro = new Exception("Situação deve ser informada");
            //    throw objErro;
            //}
        }

        #endregion


    }
}
