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
    public class BancoRN
    {
        BancoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public BancoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia,int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable pesquisaBanco(int empMaster, int idCliente, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new BancoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.pesquisaBanco(empMaster, idCliente, nome);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
       
        public DataTable ListaBanco(Banco oBanco)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new BancoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaBanco(oBanco);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Banco objBanco)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objBanco);

                objBLL = new BancoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objBanco);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Banco objBanco)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objBanco);

                objBLL = new BancoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objBanco);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Banco objBanco)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objBanco);

                objBLL = new BancoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objBanco);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Banco ObterPor(Banco objBanco)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new BancoDAO(Conexao,oOcorrencia,codEmpresa);
                objBanco = objBLL.ObterPor(objBanco);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objBanco;

        }

        #endregion

        #region Metodos Privados da Classe
       
        //Verifica erros no objeto
        private void VerificaDados(Banco obj)
        {

            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Nome do Banco não pode ser nulo");
                throw objErro;
            }
        }

        #endregion


    }
}
