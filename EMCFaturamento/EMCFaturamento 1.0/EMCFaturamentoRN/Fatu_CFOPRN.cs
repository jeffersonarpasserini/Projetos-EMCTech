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
    public class Fatu_CFOPRN
    {

        Fatu_CFOPDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_CFOPRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_CFOP()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_CFOPDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaFatu_CFOP();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_CFOP objFatu_CFOP)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_CFOP, "A");

                objBLL = new Fatu_CFOPDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_CFOP);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_CFOP objFatu_CFOP)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_CFOP, "I");

                objBLL = new Fatu_CFOPDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_CFOP);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_CFOP objFatu_CFOP)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_CFOP, "E");

                objBLL = new Fatu_CFOPDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_CFOP);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_CFOP ObterPor(Fatu_CFOP objFatu_CFOP)
        {
            try
            {
                objBLL = new Fatu_CFOPDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_CFOP = objBLL.ObterPor(objFatu_CFOP);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_CFOP;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_CFOP obj, string sOperacao)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.nrocfop))
            {
                objErro = new Exception("CFOP (Código Fiscal da Operação) deve ser informado");
                throw objErro;
            }

            //verificando se o Número CFOP informado já existe, na inclusão
            if (sOperacao == "I")
            {
                objBLL = new Fatu_CFOPDAO(Conexao, oOcorrencia, codEmpresa);
                obj = objBLL.ObterPor(obj);
                if (!String.IsNullOrEmpty(obj.nrocfop))
                {
                    objErro = new Exception("CFOP " + obj.nrocfop + " já cadastrado com o código " + obj.idfatu_cfop);
                    throw objErro;
                }
            }
        }

        #endregion
    }
}
