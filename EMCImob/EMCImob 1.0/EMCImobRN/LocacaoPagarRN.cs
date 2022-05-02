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
    public class LocacaoPagarRN
    {
        LocacaoPagarDAO objBLL; 
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoPagarRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public List<LocacaoPagar> lstLocacaoPagar(DateTime? dataInicial, DateTime? dataFinal, string idContrato, int nroParcela, int idImovel, int empmaster,  int idLocador)
        {
            List<LocacaoPagar> dtCon = new List<LocacaoPagar>();

            try
            {
                objBLL = new LocacaoPagarDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.lstLocacaoPagar(dataInicial, dataFinal, idContrato, nroParcela, idImovel, empmaster, idLocador);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public LocacaoPagar ObterPor(LocacaoPagar oPagar)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new LocacaoPagarDAO(Conexao, oOcorrencia, codEmpresa);
                oPagar = objBLL.ObterPor(oPagar);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oPagar;

        }

        public List<LocacaoPagar> listaLocPagar(int idUsuario, int codempresa, int idLocador, DateTime? dataInicial)
        {
            List<LocacaoPagar> lstParcVencida = new List<LocacaoPagar>();

            try
            {
                //if (dataInicial > dataFinal)
                //{
                //    Exception err = new Exception("Data Inicial é maior que data final");
                //    throw err;
                //}
                objBLL = new LocacaoPagarDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcVencida = objBLL.listaParcelaVencida(idUsuario, codempresa, idLocador, dataInicial);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstParcVencida;

        }

        public DataTable ListaLocador(DateTime? dataInicial)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoPagarDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstListaLocador(dataInicial);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaCCPagar(DateTime? dataInicial, string identificacaoContrato)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoPagarDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstListaCCPagar(dataInicial, identificacaoContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
              
    }
}
