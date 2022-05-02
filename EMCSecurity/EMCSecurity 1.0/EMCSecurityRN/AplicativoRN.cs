using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCSecurityRN
{
    public class AplicativoRN
    {

        AplicativoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AplicativoRN(ConectaBancoMySql pConexao,Ocorrencia parOcorrencia,int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public List<Aplicativo> lstAplicativo()
        {
            List<Aplicativo> lstAplicativo = new List<Aplicativo>();

            try
            {
                objBLL = new AplicativoDAO(Conexao, oOcorrencia, codEmpresa);
                lstAplicativo = objBLL.lstAplicativo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstAplicativo;
        }
        public DataTable ListaAplicativo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new AplicativoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaAplicativo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Aplicativo objAplicativo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAplicativo);

                objBLL = new AplicativoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objAplicativo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Aplicativo objAplicativo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAplicativo);

                objBLL = new AplicativoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objAplicativo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Aplicativo objAplicativo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAplicativo);

                objBLL = new AplicativoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objAplicativo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Aplicativo ObterPor(Aplicativo objAplicativo)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objAplicativo);

                objBLL = new AplicativoDAO(Conexao, oOcorrencia, codEmpresa);
                objAplicativo = objBLL.ObterPor(objAplicativo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objAplicativo;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Aplicativo obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição do Aplicativo deve ser informada.");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.nome))
            {
                objErro = new Exception("O Nome do Aplicativo deve ser informado.");
                throw objErro;
            }

        }

        #endregion

    }
}
