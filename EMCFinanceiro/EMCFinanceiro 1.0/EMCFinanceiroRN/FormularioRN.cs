using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;

namespace EMCFinanceiroRN
{
    public class FormularioRN
    {
        FormularioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FormularioRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFormulario(Formulario oFormulario)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FormularioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFormulario(oFormulario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        

        public void Atualizar(Formulario objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new FormularioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Formulario objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new FormularioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Formulario objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objConta);

                objBLL = new FormularioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Formulario ObterPor(Formulario objConta)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new FormularioDAO(Conexao, oOcorrencia, codEmpresa);
                objConta = objBLL.ObterPor(objConta);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return objConta;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Formulario obj)
        {

            Exception objErro;

            if (obj.descricaoFormulario.Trim().Length == 0)
            {
                objErro = new Exception("Descricao não pode ser nula");
                throw objErro;
            }
            if (obj.idFormulario < 0)
            {
                objErro = new Exception("Codigo da Conta não pode ser nulo");
                throw objErro;
            }

        }

        #endregion



    }
}
