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
    public class ContatoRN
    {
        ContatoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ContatoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaContato(Contato oContato)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContatoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaContato(oContato);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Contato objContato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContato);

                objBLL = new ContatoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objContato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Contato objContato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContato);

                objBLL = new ContatoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objContato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Contato objContato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContato);

                objBLL = new ContatoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objContato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Contato ObterPor(Contato objContato)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ContatoDAO(Conexao,oOcorrencia,codEmpresa);
                objContato = objBLL.ObterPor(objContato);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objContato;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Contato obj)
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
            if (obj.numero.Trim().Length == 0 && obj.eMail.Trim().Length == 0)
            {
                objErro = new Exception("Número de Telefone ou Campo de email devem ser preenchidos");
                throw objErro;
            }
            if (!EmcResources.ValidarEmail(obj.eMail))
            {
                objErro = new Exception("Email Inválido");
                throw objErro;
            }
        }

        #endregion
    }
}
