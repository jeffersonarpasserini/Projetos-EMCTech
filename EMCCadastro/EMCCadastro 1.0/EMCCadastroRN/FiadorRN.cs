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
    public class FiadorRN
    {

        FiadorDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FiadorRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public DataTable pesquisaFiador(int empMaster, int idFiador, string nome, string cnpj)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FiadorDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.pesquisaFiador(empMaster, idFiador, nome, cnpj);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaFiador(Fiador oFiador)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FiadorDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaFiador(oFiador);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fiador objFiador)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFiador);

                objBLL = new FiadorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objFiador);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fiador objFiador)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFiador);

                objBLL = new FiadorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objFiador);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fiador objFiador)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFiador);

                objBLL = new FiadorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objFiador);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fiador ObterPor(int empresaMaster, string cnpjcpf)
        {
            Fiador objFiador = new Fiador();
            try
            {

                objBLL = new FiadorDAO(Conexao,oOcorrencia,codEmpresa);
                objFiador = objBLL.ObterPor(empresaMaster, cnpjcpf);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFiador;

        }
        public Fiador ObterPor(Fiador objFiador)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new FiadorDAO(Conexao,oOcorrencia,codEmpresa);
                objFiador = objBLL.ObterPor(objFiador);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFiador;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Fiador obj)
        {

            Exception objErro;

            if (obj.codEmpresa == 0)
            {
                objErro = new Exception("Código da Empresa não pode ser nulo");
                throw objErro;
            }
            if (obj.idPessoa == 0)
            {
                objErro = new Exception("Código da Pessoa não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
    }
}
