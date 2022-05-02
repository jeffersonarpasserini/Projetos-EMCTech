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
    public class Estq_TipoProdutoRN
    {

        Estq_TipoProdutoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_TipoProdutoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_TipoProduto()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaEstq_TipoProduto();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_TipoProduto objEstq_TipoProduto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_TipoProduto);

                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_TipoProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_TipoProduto objEstq_TipoProduto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_TipoProduto);

                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_TipoProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_TipoProduto objEstq_TipoProduto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_TipoProduto);

                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_TipoProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_TipoProduto ObterPor(Estq_TipoProduto objEstq_TipoProduto)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_TipoProduto = objBLL.ObterPor(objEstq_TipoProduto);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_TipoProduto;

        }

        public DataTable pesquisaTipoProduto(int empMaster, int idEstqTipoProduto, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaTipoProduto(empMaster, idEstqTipoProduto, descricao);
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
                objBLL = new Estq_TipoProdutoDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("SELECT tp.*, if(tp.controlaestoqueminimo = 'S', 'SIM', 'NÃO')");
            strSQL.Append("as controlaestqminimo, if(tp.prestacaoservico = 'S', 'SIM', 'NÃO')");
            strSQL.Append("as prestservico, if(tp.familiaobrigatoria = 'S', 'SIM', 'NÃO')");
            strSQL.Append("as famiobrigatoria  FROM estq_tipoproduto tp");
            strSQL.Append(" order by tp.descricao");


            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("SELECT tp.*, if(tp.controlaestoqueminimo = 'S', 'SIM', 'NÃO')");
            strSQL.Append("as controlaestqminimo, if(tp.prestacaoservico = 'S', 'SIM', 'NÃO')");
            strSQL.Append("as prestservico, if(tp.familiaobrigatoria = 'S', 'SIM', 'NÃO')");
            strSQL.Append("as famiobrigatoria  FROM estq_tipoproduto tp");
            strSQL.Append(" order by tp.idestq_tipoproduto");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_TipoProduto obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Tipo de Produto deve ser informado");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.controlaestoqueminimo))
            {
                objErro = new Exception("Selecione uma opção para o Controle de Estoque Mínimo");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.prestacaoservico))
            {
                objErro = new Exception("Selecione uma opção para a Prestação de Serviço");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.familiaobrigatoria))
            {
                objErro = new Exception("Selecione uma opção para a Família Obrigatória");
                throw objErro;
            }
        }

        #endregion
    }
}
