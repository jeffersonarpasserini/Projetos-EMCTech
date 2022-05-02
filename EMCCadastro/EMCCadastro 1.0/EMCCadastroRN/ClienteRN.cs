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
    public class ClienteRN
    {

        ClienteDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ClienteRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public DataTable pesquisaCliente(int empMaster, int idCliente, string nome, string cnpj)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ClienteDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.pesquisaCliente(empMaster, idCliente, nome, cnpj);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaCliente(Cliente oCliente)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ClienteDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaCliente(oCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Cliente objCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCliente);

                objBLL = new ClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Cliente objCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCliente);

                objBLL = new ClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Cliente objCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCliente);

                objBLL = new ClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Cliente ObterPor(int empresaMaster, string cnpjcpf)
        {
            Cliente objCliente = new Cliente();
            try
            {

                objBLL = new ClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objCliente = objBLL.ObterPor(empresaMaster, cnpjcpf);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCliente;

        }
        public Cliente ObterPor(Cliente objCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objCliente = objBLL.ObterPor(objCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCliente;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Cliente obj)
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
