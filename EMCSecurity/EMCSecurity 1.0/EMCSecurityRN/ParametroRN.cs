using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCLibrary;

namespace EMCSecurityRN
{
    public class ParametroRN
    {
        ParametroDAO objBLL;
        ConectaBancoMySql Conexao;
         Ocorrencia oOcorrencia;
        int codEmpresa;

        public ParametroRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa; 
        }
        public ParametroRN(ConectaBancoMySql pConexao)
        {
            Conexao = pConexao; 
        }

        #region Metodos Publicos da Classe

        /// <summary>
        /// Lista os Parametros Cadastrados em um Banco de Dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns name="datatable">Retorna um datatable com os parametros do banco de dados</returns>
        public DataTable ListaParametro(Parametro objParametro)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ParametroDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaParametro(objParametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        /// <summary>
        /// Realiza a alteracao de um parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns></returns>
        public void Atualizar(Parametro objParametro)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objParametro);

                objBLL = new ParametroDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objParametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        /// <summary>
        /// Realiza a gravação de um novo parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns></returns>
        public void Salvar(Parametro objParametro)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objParametro);

                objBLL = new ParametroDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objParametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        /// <summary>
        /// Realiza a exclusao de um parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns></returns>
        public void Excluir(Parametro objParametro)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objParametro);

                objBLL = new ParametroDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objParametro);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }


        /// <summary>
        /// retorna o valor de um parametro do sistema 
        /// </summary>
        /// <param name="codempresa">codigo da empresa ou empresa master</param>
        /// <param name="Aplicacao">codigo da aplicacao</param>
        /// <param name="Sessao">codigo da sessao</param>
        /// <param name="Chave">codigo da chave</param>
        /// <returns name="Valor (string)">Retorna uma string com o valor assumido pelo parametro solicitado</returns>
        public string retParametro(int codEmpresa, string Aplicacao, string Sessao, string Chave)
        {
            string retorno = "";
            try
            {
             
                objBLL = new ParametroDAO(Conexao,oOcorrencia,codEmpresa);
                retorno = objBLL.retParametro(codEmpresa, Aplicacao, Sessao, Chave);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return retorno;
        }

        /// <summary>
        /// Busca informações de um objeto parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns name="datatable">Retorna um datatable com os parametros do banco de dados</returns>
        public Parametro ObterPor(Parametro objParametro)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ParametroDAO(Conexao,oOcorrencia,codEmpresa);
                objParametro = objBLL.ObterPor(objParametro);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objParametro;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Parametro obj)
        {

            Exception objErro;

            if (obj.aplicacao.Trim().Length == 0)
            {
                objErro = new Exception("Aplicacao não pode ser nulo");
                throw objErro;
            }

            if (obj.sessao.Trim().Length == 0)
            {
                objErro = new Exception("Sessao não pode ser nulo");
                throw objErro;
            }

            if (obj.chave.Trim().Length == 0)
            {
                objErro = new Exception("Chave não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
        ///
    }
}

