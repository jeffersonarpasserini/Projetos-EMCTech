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
    public class Estq_GrupoRN
    {

        Estq_GrupoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_GrupoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Grupo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Grupo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Grupo objEstq_Grupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Grupo);

                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_Grupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Grupo objEstq_Grupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Grupo);

                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_Grupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Grupo objEstq_Grupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Grupo);

                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Grupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Grupo ObterPor(Estq_Grupo objEstq_Grupo)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Grupo = objBLL.ObterPor(objEstq_Grupo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Grupo;

        }

        public DataTable pesquisaGrupo(int empMaster, int idEstqGrupo, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaGrupo(empMaster, idEstqGrupo, descricao);
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
                objBLL = new Estq_GrupoDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("select g.*, if(g.faturamentoentrada = 'S', 'SIM', 'NÃO') as fatuentrada,");
            strSQL.Append(" if(g.faturamentosaida = 'S', 'SIM', 'NÃO') as fatusaida");
            strSQL.Append(" from estq_grupo g");
            strSQL.Append(" order by g.descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select g.*, if(g.faturamentoentrada = 'S', 'SIM', 'NÃO') as fatuentrada,"); 
            strSQL.Append(" if(g.faturamentosaida = 'S', 'SIM', 'NÃO') as fatusaida"); 
            strSQL.Append(" from estq_grupo g");
            strSQL.Append(" order by g.idestq_grupo");
            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Grupo obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Grupo de Estoque deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
