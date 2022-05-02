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
    public class Fatu_TributacaoIPIRN
    {

        Fatu_TributacaoIPIDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_TributacaoIPIRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_TributacaoIPI()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_TributacaoIPIDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_TributacaoIPI();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_TributacaoIPI);

                objBLL = new Fatu_TributacaoIPIDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objFatu_TributacaoIPI);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_TributacaoIPI);

                objBLL = new Fatu_TributacaoIPIDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objFatu_TributacaoIPI);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_TributacaoIPI);

                objBLL = new Fatu_TributacaoIPIDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_TributacaoIPI);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_TributacaoIPI ObterPor(Fatu_TributacaoIPI objFatu_TributacaoIPI)
        {
            try
            {
                objBLL = new Fatu_TributacaoIPIDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_TributacaoIPI = objBLL.ObterPor(objFatu_TributacaoIPI);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_TributacaoIPI;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_TributacaoIPI obj)
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
