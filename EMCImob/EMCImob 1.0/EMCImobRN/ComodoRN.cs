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
    public class ComodoRN
    {

        ComodoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ComodoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaComodo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaComodo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaComodo(String SSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(SSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaComodo(int empMaster, int idComodos, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaComodo(empMaster, idComodos, nome);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Comodo objComodo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objComodo);

                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objComodo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Comodo objComodo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objComodo);

                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objComodo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Comodo objComodo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objComodo);

                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objComodo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Comodo ObterPor(Comodo objComodo)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ComodoDAO(Conexao, oOcorrencia, codEmpresa);
                objComodo = objBLL.ObterPor(objComodo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objComodo;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Comodo obj)
        {
            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Nome do Comodo não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
    }
}
