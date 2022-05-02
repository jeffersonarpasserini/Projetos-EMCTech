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
    public class EstadoRN
    {
        EstadoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public EstadoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstado()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EstadoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaEstado();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estado objEstado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstado);

                objBLL = new EstadoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estado objEstado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstado);

                objBLL = new EstadoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estado objEstado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstado);

                objBLL = new EstadoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estado ObterPor(Estado objEstado)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objEstado);

                objBLL = new EstadoDAO(Conexao,oOcorrencia,codEmpresa);
                objEstado = objBLL.ObterPor(objEstado);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstado;

        }

        public DataTable pesquisaEstado(int empMaster, int idEstado, String nome, String abreviatura)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new EstadoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaEstado(empMaster, idEstado,nome, abreviatura);
               
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estado obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.nome))
            {
                objErro = new Exception("O Nome do estado deve ser preenchido.");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.abreviatura))
            {
                objErro = new Exception("A abreviatura do Estado não pode estar vazia");
                throw objErro;
            }
        }

        #endregion


    }
}
