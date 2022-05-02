using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCObrasModel;
using EMCObrasDAO;
using EMCSecurityModel;

namespace EMCObrasRN
{
    public class Obra_TarefaRN
    {

        Obra_TarefaDAO objBLL;
        ConectaBancoMySql oConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_TarefaRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            oConexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public List<Obra_Tarefa> LstObra_Tarefa(Obra_Modulo oModulo)
        {
            List<Obra_Tarefa> lstTarefa = new List<Obra_Tarefa>();

            try
            {
                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                lstTarefa = objBLL.LstObra_Tarefa(oModulo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstTarefa;
        }
        public DataTable ListaObra_Tarefa()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaObra_Tarefa();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        
        public void Atualizar(Obra_Tarefa objObra_Tarefa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Tarefa);

                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objObra_Tarefa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Obra_Tarefa objObra_Tarefa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Tarefa);

                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objObra_Tarefa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Obra_Tarefa objObra_Tarefa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Tarefa);

                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objObra_Tarefa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_Tarefa ObterPor(Obra_Tarefa objObra_Tarefa)
        {
            try
            {
                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                objObra_Tarefa = objBLL.ObterPor(objObra_Tarefa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra_Tarefa;

        }

        public DataTable pesquisaObraTarefa(int empMaster, int idObraTarefa, string descricaoTarefa, int idObraModulo, string descricaoModulo)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaObraTarefa(empMaster, idObraTarefa, descricaoTarefa, idObraModulo, descricaoModulo);
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
                objBLL = new Obra_TarefaDAO(oConexao, oOcorrencia, codEmpresa);
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
            strSQL.Clear();
            strSQL.Append("Select t.*, m.descricao as modulo, e.descricao as etapa");
            strSQL.Append(" from obra_tarefas t, obra_modulo m, obra_etapa e");
            strSQL.Append(" where m.idobra_modulo = t.idobra_modulo");
            strSQL.Append(" and e.idobra_etapa = t.idobra_etapa");
            strSQL.Append(" order by descricao");

            return strSQL.ToString();
        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();
            strSQL.Clear();
            strSQL.Append("Select t.*, m.descricao as modulo, e.descricao as etapa");
            strSQL.Append(" from obra_tarefas t, obra_modulo m, obra_etapa e");
            strSQL.Append(" where m.idobra_modulo = t.idobra_modulo");
            strSQL.Append(" and e.idobra_etapa = t.idobra_etapa");
            strSQL.Append(" order by idobra_tarefas");

            return strSQL.ToString();
        }

      
        #endregion

        #region Metodos Privados da Classe
        
        //Verifica erros no objeto
        private void VerificaDados(Obra_Tarefa obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição da Tarefa deve ser informada");
                throw objErro;
            }

            if (obj.obra_etapa.idobra_etapa == 0)
            {
                objErro = new Exception("A Etapa da Obra deve ser informada");
                throw objErro;
            }

            if (obj.obra_modulo.idobra_modulo == 0)
            {
                objErro = new Exception("O Módulo da Obra deve ser informada");
                throw objErro;
            }

        }

        #endregion
    }
}
