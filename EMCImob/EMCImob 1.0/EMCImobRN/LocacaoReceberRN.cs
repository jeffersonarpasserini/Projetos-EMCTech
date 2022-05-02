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
    public class LocacaoReceberRN
    {
        LocacaoReceberDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoReceberRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public List<LocacaoReceber> lstLocacaoReceber(DateTime? dataInicial, DateTime? dataFinal, string idContrato, int nroParcela, int idImovel, int empmaster,  int idLocatario)
        {
            List<LocacaoReceber> dtCon = new List<LocacaoReceber>();

            try
            {
                objBLL = new LocacaoReceberDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.lstLocacaoReceber(dataInicial, dataFinal, idContrato, nroParcela, idImovel, empmaster, idLocatario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public LocacaoReceber ObterPor(LocacaoReceber oReceber)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new LocacaoReceberDAO(Conexao, oOcorrencia, codEmpresa);
                oReceber = objBLL.ObterPor(oReceber);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oReceber;

        }

        public DataTable PesquisaLocacaoReceber(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoReceberDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.PesquisaLocacaoReceber(dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro; 
            }
            return dtCon;
        }
     
        public List<LocacaoReceber> listaLocReceber(int idUsuario, int codempresa, int idLocatario, DateTime? dataInicial)
        {
            List<LocacaoReceber> lstParcVencida = new List<LocacaoReceber>();

            try
            {               
                objBLL = new LocacaoReceberDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcVencida = objBLL.listaParcelaVencida(idUsuario, codempresa, idLocatario, dataInicial);
            }
            catch (Exception erro)
            {
                throw erro;
            } 
            return lstParcVencida;

        }        

        public DataTable ListaLocatario(DateTime? dataInicial)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoReceberDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstListaLocatario(dataInicial);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaCCReceber( DateTime? dataInicial, string identificacaoContrato)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoReceberDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstListaCCReceber(dataInicial, identificacaoContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

    }
}
