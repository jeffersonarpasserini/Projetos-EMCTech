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
    public class AutorizadosClienteRN
    {
        AutorizadosClienteDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AutorizadosClienteRN(ConectaBancoMySql pConexao,Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaAutorizadosCliente(AutorizadosCliente oAutorizadosCliente)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new AutorizadosClienteDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaAutorizadosCliente(oAutorizadosCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(AutorizadosCliente objAutorizadosCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAutorizadosCliente);

                objBLL = new AutorizadosClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objAutorizadosCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(AutorizadosCliente objAutorizadosCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAutorizadosCliente);

                objBLL = new AutorizadosClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objAutorizadosCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(AutorizadosCliente objAutorizadosCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAutorizadosCliente);

                objBLL = new AutorizadosClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objAutorizadosCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public AutorizadosCliente ObterPor(AutorizadosCliente objAutorizadosCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new AutorizadosClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objAutorizadosCliente = objBLL.ObterPor(objAutorizadosCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objAutorizadosCliente;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(AutorizadosCliente obj)
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
            if (obj.nome == "")
            {
                objErro = new Exception("Nome da Pessoa não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
    }
}
