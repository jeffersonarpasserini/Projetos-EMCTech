using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCEstoqueModel;
using EMCEstoqueDAO;
using EMCSecurityModel;

namespace EMCEstoqueRN
{
    public class Estq_Produto_LoteRN
    {

        Estq_Produto_LoteDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_LoteRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Produto_Lote(Estq_Produto oProduto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_LoteDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Produto_Lote(oProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Lote);

                objBLL = new Estq_Produto_LoteDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objEstq_Produto_Lote);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Lote);

                objBLL = new Estq_Produto_LoteDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objEstq_Produto_Lote);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Lote);

                objBLL = new Estq_Produto_LoteDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objEstq_Produto_Lote);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Produto_Lote ObterPor(Estq_Produto_Lote objEstq_Produto_Lote)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_Produto_LoteDAO(Conexao, oOcorrencia, codEmpresa);
                objEstq_Produto_Lote = objBLL.ObterPor(objEstq_Produto_Lote);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Produto_Lote;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Produto_Lote obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.loteproduto))
            {
                objErro = new Exception("O Lote deve ser informado");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.datavalidade.ToString()))
            {
                objErro = new Exception("A Data de Validade do Lote deve ser informada");
                throw objErro;
            }

        }

        #endregion
    }
}
