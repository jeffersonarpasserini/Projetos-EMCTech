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
    public class Obra_TipoContratoRN
    {

        Obra_TipoContratoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_TipoContratoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public List<Obra_TipoContrato> LstObra_TipoContrato()
        {
            List<Obra_TipoContrato> lstEtapa = new List<Obra_TipoContrato>();

            try
            {
                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                lstEtapa = objBLL.LstObra_TipoContrato();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstEtapa;
        }

        public DataTable ListaObra_TipoContrato()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaObra_TipoContrato();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Obra_TipoContrato objObra_TipoContrato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_TipoContrato);

                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objObra_TipoContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Obra_TipoContrato objObra_TipoContrato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_TipoContrato);

                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objObra_TipoContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Obra_TipoContrato objObra_TipoContrato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra_TipoContrato);

                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objObra_TipoContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_TipoContrato ObterPor(Obra_TipoContrato objObra_TipoContrato)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                objObra_TipoContrato = objBLL.ObterPor(objObra_TipoContrato);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra_TipoContrato;

        }

        public DataTable pesquisaObraTipoContrato(int empMaster, int idObraTipoContrato, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaObraTipoContrato(empMaster, idObraTipoContrato, descricao);
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
                objBLL = new Obra_TipoContratoDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("Select * from obra_tipocontrato");
            strSQL.Append(" order by descricao");

            return strSQL.ToString();

        }

        public string DataReport()
        {

            StringBuilder strSQL = new StringBuilder();
            strSQL.Clear();
            strSQL.Append("Select * from obra_tipocontrato");
            strSQL.Append(" order by idobra_tipocontrato");
                                       
            return strSQL.ToString();

        }


        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra_TipoContrato obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Contrato deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
