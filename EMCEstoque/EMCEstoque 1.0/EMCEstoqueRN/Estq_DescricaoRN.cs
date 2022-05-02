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
    public class Estq_DescricaoRN
    {

        Estq_DescricaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_DescricaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Descricao()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_DescricaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Descricao();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Descricao objEstq_Descricao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Descricao);

                objBLL = new Estq_DescricaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_Descricao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Descricao objEstq_Descricao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Descricao);

                objBLL = new Estq_DescricaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_Descricao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Descricao objEstq_Descricao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Descricao);

                objBLL = new Estq_DescricaoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Descricao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Descricao ObterPor(Estq_Descricao objEstq_Descricao)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_DescricaoDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Descricao = objBLL.ObterPor(objEstq_Descricao);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Descricao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Descricao obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição Personalizada do Produto deve ser informado");
                throw objErro;
            }

            if (obj.Cliente.idPessoa == 0)
            {
                objErro = new Exception("O Cliente deve ser informado");
                throw objErro;
            }

        }

        #endregion
    }
}
