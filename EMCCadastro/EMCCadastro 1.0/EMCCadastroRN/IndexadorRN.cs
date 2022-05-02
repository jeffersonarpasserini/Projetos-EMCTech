using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;

namespace EMCCadastroRN
{
    public class IndexadorRN
    {


        IndexadorDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IndexadorRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable pesquisaIndexador(int empMaster, int idIndexador, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new IndexadorDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaIndexador(empMaster, idIndexador, descricao);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaIndexador()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IndexadorDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaIndexador();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Indexador objIndexador)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIndexador);

                objBLL = new IndexadorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objIndexador);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Indexador objIndexador)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIndexador);

                objBLL = new IndexadorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objIndexador);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Indexador objIndexador)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIndexador);

                objBLL = new IndexadorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objIndexador);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Indexador ObterPor(Indexador objIndexador)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objIndexador);

                objBLL = new IndexadorDAO(Conexao,oOcorrencia,codEmpresa);
                objIndexador = objBLL.ObterPor(objIndexador);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objIndexador;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Indexador obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição do Indexador não pode estar vazia");
                throw objErro;
            }
        }

        #endregion

    }
}
