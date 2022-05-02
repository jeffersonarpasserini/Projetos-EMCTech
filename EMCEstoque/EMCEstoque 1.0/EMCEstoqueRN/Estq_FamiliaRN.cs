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
    public class Estq_FamiliaRN
    {

        Estq_FamiliaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_FamiliaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Familia()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Familia();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Familia objEstq_Familia)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Familia);

                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objEstq_Familia);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Familia objEstq_Familia)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Familia);

                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objEstq_Familia);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Familia objEstq_Familia)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Familia);

                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Familia);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Familia ObterPor(Estq_Familia objEstq_Familia)
        {
            try
            {
                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Familia = objBLL.ObterPor(objEstq_Familia);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Familia;

        }

        public DataTable pesquisaFamilia(int empMaster, int idEstqFamilia, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaFamilia(empMaster, idEstqFamilia, descricao);
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
                objBLL = new Estq_FamiliaDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("select f.* from estq_familia f");
            strSQL.Append(" order by f.descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select f.* from estq_familia f");
            strSQL.Append(" order by f.idestq_familia");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Familia obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Família do Produto deve ser informada");
                throw objErro;
            }
        }
        
        #endregion
    }
}
