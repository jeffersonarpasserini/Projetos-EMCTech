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
    public class Fatu_NCMRN
    {

        Fatu_NCMDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_NCMRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_NCM()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_NCMDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_NCM();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_NCM objFatu_NCM)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_NCM, "A");

                objBLL = new Fatu_NCMDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_NCM);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_NCM objFatu_NCM)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_NCM, "I");

                objBLL = new Fatu_NCMDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_NCM);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_NCM objFatu_NCM)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_NCM, "E");

                objBLL = new Fatu_NCMDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_NCM);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_NCM ObterPor(Fatu_NCM objFatu_NCM)
        {
            try
            {
                objBLL = new Fatu_NCMDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_NCM = objBLL.ObterPor(objFatu_NCM);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_NCM;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_NCM obj, string sOperacao)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.situacao))
            {
                objErro = new Exception("Situação deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.nroncm))
            {
                objErro = new Exception("Código NCM deve ser informado");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.classificacaofiscal))
            {
                objErro = new Exception("Classificação Fiscal deve ser informada");
                throw objErro;
            }

            //verificando se o Número NCM informado já existe na inclusão
            if (sOperacao == "I")
            {
                objBLL = new Fatu_NCMDAO(Conexao, oOcorrencia, codEmpresa);
                obj = objBLL.ObterPor(obj);
                if (!String.IsNullOrEmpty(obj.nroncm))
                {
                    objErro = new Exception("NCM " + obj.nroncm + " já cadastrado com o código " + obj.idfatu_ncm);
                    throw objErro;
                }
            }
        }

        #endregion
    }
}
