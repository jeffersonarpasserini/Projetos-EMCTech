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
    public class Estq_Produto_UnidadeRN
    {

        Estq_Produto_UnidadeDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_UnidadeRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Produto_Unidade()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Produto_Unidade();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Unidade);

                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_Produto_Unidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Unidade);

                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_Produto_Unidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Unidade);

                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Produto_Unidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Produto_Unidade ObterPor(Estq_Produto_Unidade objEstq_Produto_Unidade)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Produto_Unidade = objBLL.ObterPor(objEstq_Produto_Unidade);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Produto_Unidade;

        }

        public DataTable pesquisaProdutoUnidade(int empMaster, int idEstqProdutoUnidade, string descricao, string abreviatura)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaProdutoUnidade(empMaster, idEstqProdutoUnidade, descricao, abreviatura);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_UnidadeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string DataReport1()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select u.* from estq_produto_unidade u");
            strSQL.Append(" order by u.descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select u.* from estq_produto_unidade u");
            strSQL.Append(" order by u.idestq_produto_unidade");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Produto_Unidade obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.unidade_descricao))
            {
                objErro = new Exception("A Descrição da Unidade deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.unidade_abreviatura))
            {
                objErro = new Exception("A Abreviatura da Unidade deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
