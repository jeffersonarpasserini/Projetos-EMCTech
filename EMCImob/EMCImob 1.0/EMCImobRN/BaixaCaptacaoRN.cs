using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCImobModel;
using EMCCadastroModel;
using EMCImobDAO;
using EMCSecurityModel;


namespace EMCImobRN
{
    public class BaixaCaptacaoRN
    {

        BaixaCaptacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public BaixaCaptacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaBaixaCaptacao(Vendedor objVendedor)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new BaixaCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaBaixaCaptacao(objVendedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(BaixaCaptacao objBaixaCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objBaixaCaptacao);

                objBLL = new BaixaCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objBaixaCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(BaixaCaptacao objBaixaCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objBaixaCaptacao);

                objBLL = new BaixaCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objBaixaCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(BaixaCaptacao objBaixaCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objBaixaCaptacao);

                objBLL = new BaixaCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objBaixaCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public BaixaCaptacao ObterPor(BaixaCaptacao objBaixaCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new BaixaCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBaixaCaptacao = objBLL.ObterPor(objBaixaCaptacao);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objBaixaCaptacao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(BaixaCaptacao obj)
        {

            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Dados da Baixa não pode ser nulos");
                throw objErro;
            }
        }

        #endregion
    }
}
