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
    public class VendedorRN
    {
        VendedorDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public VendedorRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaVendedor(Vendedor oVendedor)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new VendedorDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaVendedor();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Vendedor objVendedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objVendedor);

                objBLL = new VendedorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objVendedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Vendedor objVendedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objVendedor);

                objBLL = new VendedorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objVendedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Vendedor objVendedor)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objVendedor);

                objBLL = new VendedorDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objVendedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Vendedor ObterPor(Vendedor objVendedor)
        {
            try
            {

                objBLL = new VendedorDAO(Conexao,oOcorrencia,codEmpresa);
                objVendedor = objBLL.ObterPor(objVendedor);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objVendedor;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Vendedor obj)
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
