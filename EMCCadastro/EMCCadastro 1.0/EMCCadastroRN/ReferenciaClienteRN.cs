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
    public class ReferenciaClienteRN
    {
        ReferenciaClienteDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReferenciaClienteRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

#region Metodos Publicos da Classe

        public DataTable ListaReferenciaCliente(ReferenciaCliente oReferenciaCliente)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReferenciaClienteDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaReferenciaCliente(oReferenciaCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(ReferenciaCliente objReferenciaCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objReferenciaCliente);

                objBLL = new ReferenciaClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objReferenciaCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(ReferenciaCliente objReferenciaCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objReferenciaCliente);

                objBLL = new ReferenciaClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objReferenciaCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(ReferenciaCliente objReferenciaCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objReferenciaCliente);

                objBLL = new ReferenciaClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objReferenciaCliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ReferenciaCliente ObterPor(ReferenciaCliente objReferenciaCliente)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ReferenciaClienteDAO(Conexao,oOcorrencia,codEmpresa);
                objReferenciaCliente = objBLL.ObterPor(objReferenciaCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objReferenciaCliente;

        }
#endregion

#region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(ReferenciaCliente obj)
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
            if (!EmcResources.ValidarEmail(obj.eMail))
            {
                objErro = new Exception("Email Inválido");
                throw objErro;
            }

            if (!obj.eMail.Contains("@") || (!obj.eMail.Contains(".")))
            {
                objErro = new Exception("Email Inválido, verifique novamente");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.telefone1))
            {
                objErro = new Exception("Telefone não pode ser nulo");
                throw objErro;
            }
        }

#endregion
    
    }
}
