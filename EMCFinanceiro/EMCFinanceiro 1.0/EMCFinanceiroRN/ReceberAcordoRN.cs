using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;

namespace EMCFinanceiroRN
{
    public class ReceberAcordoRN
    {
        ReceberAcordoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberAcordoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public void Atualizar(ReceberAcordo objAcordo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAcordo);

                objBLL = new ReceberAcordoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objAcordo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public int Salvar(ReceberAcordo objAcordo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAcordo);

                objBLL = new ReceberAcordoDAO(Conexao, oOcorrencia, codEmpresa);
                int idAcordo = objBLL.Salvar(objAcordo);

                return idAcordo;
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(ReceberAcordo objAcordo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAcordo);

                objBLL = new ReceberAcordoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objAcordo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void aprovaAcordo(ReceberAcordo objAcordo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAcordo);

                objBLL = new ReceberAcordoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.aprovaAcordo(objAcordo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void estornaAprovacao(ReceberAcordo objAcordo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAcordo);

                objBLL = new ReceberAcordoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.estornaAprovacao(objAcordo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ReceberAcordo ObterPor(ReceberAcordo objAcordo)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ReceberAcordoDAO(Conexao, oOcorrencia, codEmpresa);
                objAcordo = objBLL.ObterPor(objAcordo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return objAcordo;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(ReceberAcordo obj)
        {

            Exception objErro;


        }

        #endregion

    }
}
