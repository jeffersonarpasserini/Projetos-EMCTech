using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCImobModel;
using EMCImobDAO;
using EMCSecurityModel;

namespace EMCImobRN
{
    public class ContasCaptacaoRN
    {

        ContasCaptacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ContasCaptacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaContasCaptacao(ContasCaptacao oContasCaptacao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContasCaptacaoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaContasCaptacao(oContasCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(ContasCaptacao objContasCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContasCaptacao);

                objBLL = new ContasCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objContasCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(ContasCaptacao objContasCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContasCaptacao);

                objBLL = new ContasCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objContasCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(ContasCaptacao objContasCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContasCaptacao);

                objBLL = new ContasCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objContasCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ContasCaptacao ObterPor(ContasCaptacao objContasCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ContasCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objContasCaptacao = objBLL.ObterPor(objContasCaptacao);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objContasCaptacao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(ContasCaptacao obj)
        {

            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nulo");
                throw objErro;
            }

            if (obj.situacao == "P" )
            {
                objErro = new Exception("Movimentos PAGOS não podem ser alterados por essa aplicação");
                throw objErro;
            }


        }

        #endregion
    }
}
