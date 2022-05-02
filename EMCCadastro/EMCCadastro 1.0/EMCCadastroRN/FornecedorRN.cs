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
    public class FornecedorRN
    {
        FornecedorDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
        public FornecedorRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable pesquisaFornecedor(int empMaster, int idFornecedor, string nome, string cnpj)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FornecedorDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.pesquisaFornecedor(empMaster,idFornecedor,nome,cnpj);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaFornecedor(Fornecedor oFornecedor)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FornecedorDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaFornecedor(oFornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fornecedor objFornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFornecedor);

                objBLL = new FornecedorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objFornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fornecedor objFornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFornecedor);

                objBLL = new FornecedorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objFornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fornecedor objFornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFornecedor);

                objBLL = new FornecedorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objFornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fornecedor ObterPor(int empresaMaster, string cnpjcpf)
        {
            Fornecedor objFornecedor = new Fornecedor();
            try
            {
                objBLL = new FornecedorDAO(Conexao,oOcorrencia,codEmpresa);
                objFornecedor = objBLL.ObterPor(empresaMaster,cnpjcpf);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFornecedor;

        }
        public Fornecedor ObterPor(Fornecedor objFornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new FornecedorDAO(Conexao,oOcorrencia,codEmpresa);
                objFornecedor = objBLL.ObterPor(objFornecedor);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFornecedor;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Fornecedor obj)
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
