using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCImobModel;
using EMCImobDAO;
using EMCSecurityModel;

namespace EMCImobRN
{
    public class LocacaoContratoRN
    {
        
        LocacaoContratoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoContratoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaLocacaoContrato()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                //dtCon = objBLL.ListaLocacaoContrato();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public List<LocacaoContrato> LstLocacaoContrato()
        {
            List<LocacaoContrato> dtCon = new List<LocacaoContrato>();

            try
            {
                objBLL = new LocacaoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.lstLocacaoContrato();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Salvar(LocacaoContrato objLocacaoContrato)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLocacaoContrato);

                objBLL = new LocacaoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objLocacaoContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        } 

        public LocacaoContrato ObterPor(LocacaoContrato objLocacaoContrato)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new LocacaoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                objLocacaoContrato = objBLL.ObterPor(objLocacaoContrato);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objLocacaoContrato;

        }

        public DataTable ListaExtratoContrato(string identificacaoContrato, DateTime? dataInicial, DateTime? dataFinal, int idLocatario, string codigoImovel)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoContratoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstListaExtrato(identificacaoContrato, dataInicial, dataFinal, idLocatario, codigoImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(LocacaoContrato obj)
        {
            Exception objErro;

            //if (obj.descricao.Trim().Length == 0)
            //{
            //    objErro = new Exception("Nome do LocacaoContrato não pode ser nulo");
            //    throw objErro;
            //}
        }

        #endregion

    }
}
