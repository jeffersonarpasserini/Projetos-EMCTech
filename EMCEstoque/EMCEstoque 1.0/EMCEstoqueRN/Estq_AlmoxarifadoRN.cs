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
    public class Estq_AlmoxarifadoRN
    {

        Estq_AlmoxarifadoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_AlmoxarifadoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Almoxarifado(String pEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaEstq_Almoxarifado(pEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Almoxarifado);

                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_Almoxarifado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Almoxarifado);

                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_Almoxarifado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Almoxarifado);

                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Almoxarifado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Almoxarifado ObterPor(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Almoxarifado = objBLL.ObterPor(objEstq_Almoxarifado);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Almoxarifado;

        }

        public DataTable pesquisaAlmoxarifado(int empMaster, int idEstqAlmoxarifado, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaAlmoxarifado(empMaster, idEstqAlmoxarifado, descricao);
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
                objBLL = new Estq_AlmoxarifadoDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("select a.* from estq_almoxarifado a");
            strSQL.Append(" order by a.descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select a.* from estq_almoxarifado a ");
            strSQL.Append(" order by a.idestq_almoxarifado");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }
            
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Almoxarifado obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Almoxarifado deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
