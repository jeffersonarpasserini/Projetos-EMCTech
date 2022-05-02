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
    public class IptuRN
    {
         IptuDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IptuRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        
        public DataTable ListaIptu()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaIptu();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
                
        public List<Iptu> LstIptu(int idIptu, int idImovel, string codigoImovel, string anoBase)
        {
            List<Iptu> listaIptu = new List<Iptu>();

            try
            {
                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                listaIptu = objBLL.lstIptu(idIptu, idImovel, codigoImovel, anoBase);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return listaIptu;
        }

        public DataTable ListaIptu(int idIptu, int idImovel, string codigoImovel, bool chkImovel, string anoBase, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioIptu(idIptu, idImovel, codigoImovel, chkImovel, anoBase, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaIptuImovel(int idIptu, int idImovel, string codigoImovel, bool chkImovel, string anoBase, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioImovel(idIptu, idImovel, codigoImovel, chkImovel, anoBase, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        
        public DataTable pesquisaIptu(int empMaster, string codigoImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaIptu(empMaster, codigoImovel, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Salvar(List<Iptu> lstIptu)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(lstIptu);

                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(lstIptu);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Iptu ObterPor(Iptu objIptu)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new IptuDAO(Conexao, oOcorrencia, codEmpresa);
                objIptu = objBLL.ObterPor(objIptu);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objIptu;
        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Iptu obj)
        {

            Exception objErro;

            if (obj.imovel.codigoImovel.Trim().Length == 0)
            {
                objErro = new Exception("Imóvel não pode ser nula");
                throw objErro;
            }
            //if (obj.nroParcela == 0)
            //{
            //    objErro = new Exception("Número Parcelas não pode ser nulo");
            //    throw objErro;
            //}
                       
            //if (obj.valorParcela == 0)
            //{
            //    objErro = new Exception("Valor da Parcela não pode ser nulo");
            //    throw objErro;
            //}
            
            if (obj.observacao.Trim().Length == 0)
            {
                objErro = new Exception("Observação não pode ser nulo");
                throw objErro;
            }
            if (obj.tipoAcerto.Trim().Length == 0)
            {
                objErro = new Exception("Tipo de Acerto não pode ser nulo");
                throw objErro;
            }
            if (obj.anoBase.Trim().Length == 0)
            {
                objErro = new Exception("Ano Base não pode ser nulo");
                throw objErro;
            } 
        }

        #endregion
    }
}
