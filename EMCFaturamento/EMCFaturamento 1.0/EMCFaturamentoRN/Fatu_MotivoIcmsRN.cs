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
    public class Fatu_MotivoIcmsRN
    {
        Fatu_MotivoIcmsDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_MotivoIcmsRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_MotivoIcms()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_MotivoIcmsDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_MotivoIcms();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_MotivoIcms);

                objBLL = new Fatu_MotivoIcmsDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_MotivoIcms);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_MotivoIcms);

                objBLL = new Fatu_MotivoIcmsDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_MotivoIcms);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_MotivoIcms);

                objBLL = new Fatu_MotivoIcmsDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_MotivoIcms);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_MotivoIcms ObterPor(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            try
            {
                objBLL = new Fatu_MotivoIcmsDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_MotivoIcms = objBLL.ObterPor(objFatu_MotivoIcms);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_MotivoIcms;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_MotivoIcms obj)
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
        }

        #endregion


    }
}
