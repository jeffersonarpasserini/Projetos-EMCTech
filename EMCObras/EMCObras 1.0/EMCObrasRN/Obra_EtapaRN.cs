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
    public class Obra_EtapaRN
    {

        Obra_EtapaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_EtapaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public List<Obra_Etapa> LstObra_Etapa()
        {
            List<Obra_Etapa> lstEtapa = new List<Obra_Etapa>();

            try
            {
                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
                lstEtapa = objBLL.LstObra_Etapa();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstEtapa;
        }

        public DataTable ListaObra_Etapa()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaObra_Etapa();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Obra_Etapa objObra_Etapa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Etapa);

                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objObra_Etapa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Obra_Etapa objObra_Etapa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Etapa);

                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objObra_Etapa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Obra_Etapa objObra_Etapa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_Etapa);

                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objObra_Etapa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_Etapa ObterPor(Obra_Etapa objObra_Etapa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
                objObra_Etapa = objBLL.ObterPor(objObra_Etapa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra_Etapa;

        }

        public DataTable pesquisaObraEtapa(int empMaster, int idObraEtapa, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaObraEtapa(empMaster, idObraEtapa, descricao);
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
                objBLL = new Obra_EtapaDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("Select * from obra_etapa");
            strSQL.Append(" order by descricao");

            return strSQL.ToString();

        }

        public string DataReport()
        {

            StringBuilder strSQL = new StringBuilder();
            strSQL.Clear();
            strSQL.Append("Select * from obra_etapa");
            strSQL.Append(" order by idobra_etapa");
                                       
            return strSQL.ToString();

        }


        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra_Etapa obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição da Etapa deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
