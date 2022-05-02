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
    public class Obra_ModuloRN
    {

        Obra_ModuloDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_ModuloRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public List<Obra_Modulo> LstObra_Modulo(Obra_Etapa oEtapa)
        {
            List<Obra_Modulo> lstModulo = new List<Obra_Modulo>();

            try
            {
                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                lstModulo = objBLL.LstObra_Modulo(oEtapa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstModulo;
        }
        public DataTable ListaObra_Modulo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaObra_Modulo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Obra_Modulo objObra_Modulo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Modulo);

                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objObra_Modulo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Obra_Modulo objObra_Modulo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Modulo);

                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objObra_Modulo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Obra_Modulo objObra_Modulo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Modulo);

                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objObra_Modulo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_Modulo ObterPor(Obra_Modulo objObra_Modulo)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                objObra_Modulo = objBLL.ObterPor(objObra_Modulo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra_Modulo;

        }

        public DataTable pesquisaObraModulo(int empMaster, int idObraModulo, string descricaoModulo, int idObraEtapa, string descricaoEtapa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaObraModulo(empMaster, idObraModulo, descricaoModulo, idObraEtapa, descricaoEtapa);
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
                objBLL = new Obra_ModuloDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("Select m.*, e.descricao as etapa");
            strSQL.Append(" from obra_modulo m, obra_etapa e");
            strSQL.Append(" where e.idobra_etapa = m.obra_etapa_idobra_etapa");
            strSQL.Append(" order by descricao");

            return strSQL.ToString();
        }

        public string DataReport()
        {

            StringBuilder strSQL = new StringBuilder();
            strSQL.Clear();
            strSQL.Append("Select m.*, e.descricao as etapa");
            strSQL.Append(" from obra_modulo m, obra_etapa e");
            strSQL.Append(" where e.idobra_etapa = m.obra_etapa_idobra_etapa");
            strSQL.Append(" order by idobra_modulo");

            return strSQL.ToString();
        }


        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra_Modulo obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Módulo deve ser informada");
                throw objErro;
            }

            if (obj.obra_etapa.idobra_etapa == 0)
            {
                objErro = new Exception("A Etapa da Obra deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
