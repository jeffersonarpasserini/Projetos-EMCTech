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
    public class Estq_EmbalagemRN
    {
         Estq_EmbalagemDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_EmbalagemRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Embalagem()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Embalagem();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Embalagem objEstq_Embalagem)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Embalagem);

                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objEstq_Embalagem);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Embalagem objEstq_Embalagem)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Embalagem);

                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objEstq_Embalagem);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Embalagem objEstq_Embalagem)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Embalagem);

                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Embalagem);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Embalagem ObterPor(Estq_Embalagem objEstq_Embalagem)
        {
            try
            {
                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Embalagem = objBLL.ObterPor(objEstq_Embalagem);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Embalagem;

        }

        public DataTable pesquisaEmbalagem(int empMaster, int idEmbalagem, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaEmbalagem(empMaster, idEmbalagem, descricao);
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
                objBLL = new Estq_EmbalagemDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("select e.*, u.unidade_abreviatura as unidade from estq_embalagem e, estq_produto_unidade u");
            strSQL.Append(" where u.idestq_produto_unidade = e.idunidade");
            strSQL.Append(" order by e.descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select e.*, u.unidade_abreviatura as unidade from estq_embalagem e, estq_produto_unidade u");
            strSQL.Append(" where u.idestq_produto_unidade = e.idunidade");
            strSQL.Append(" order by e.idestq_embalagem");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }


        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Embalagem obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }

            if (obj.quantidade == 0)
            {
                objErro = new Exception("A quantidade da embalagem deve ser informada");
                throw objErro;
            }
        }

        #endregion

    }
}
