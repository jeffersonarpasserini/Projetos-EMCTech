using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCEstoqueModel;
using EMCEstoqueDAO;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;

namespace EMCEstoqueRN
{
    public class Estq_Produto_FornecedorRN
    {

        Estq_Produto_FornecedorDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_FornecedorRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Produto_Fornecedor(Estq_Produto oProduto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_FornecedorDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Produto_Fornecedor(oProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Fornecedor);

                objBLL = new Estq_Produto_FornecedorDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objEstq_Produto_Fornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Fornecedor);

                objBLL = new Estq_Produto_FornecedorDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objEstq_Produto_Fornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Fornecedor);

                objBLL = new Estq_Produto_FornecedorDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objEstq_Produto_Fornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Produto_Fornecedor ObterPor(Estq_Produto_Fornecedor objEstq_Produto_Fornecedor)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_Produto_FornecedorDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Produto_Fornecedor = objBLL.ObterPor(objEstq_Produto_Fornecedor);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Produto_Fornecedor;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Produto_Fornecedor obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.idproduto_fornecedor))
            {
                objErro = new Exception("O Código Interno do Fornecedor deve ser informado");
                throw objErro;
            }

            if ( obj.Fornecedor.idPessoa == 0)
            {
                objErro = new Exception("O Fornecedor deve ser informado");
                throw objErro;
            }

        }

        #endregion
    }
}
