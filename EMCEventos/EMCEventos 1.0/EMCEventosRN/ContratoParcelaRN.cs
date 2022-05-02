using EMCEventosDAO;
using EMCEventosModel;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEventosRN
{
    public class ContratoParcelaRN
    {
        ContratoParcelaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ContratoParcelaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public List<ContratoParcela> ListaContratoParcela(int idContrato)
        {
            List<ContratoParcela> listaParcelas = new List<ContratoParcela>();

            try
            {
                objBLL = new ContratoParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                listaParcelas = objBLL.lstContratoParcela(idContrato);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return listaParcelas;
        }
      
        //public DataTable ListaAgendaEvento(int idImovel, string codigoImovel, int idEvento, string descEvento, bool chkImovel, bool chkEvento, DateTime? dataInicial, DateTime? dataFinal)
        //{
        //    DataTable dtCon = new DataTable();

        //    try
        //    {
        //        objBLL = new AgendaDAO(Conexao, oOcorrencia, codEmpresa);                
        //        dtCon = objBLL.dstRelatorioEvento(idImovel, codigoImovel, idEvento, descEvento, chkImovel, chkEvento, dataInicial, dataFinal);
        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //    return dtCon;
        //}
           
        //public List<ContratoParcela> LstContParcelaGrid(int idContratoParcela, int idContrato)
        //{
            //List<ContratoParcela> listaContratoParcela = new List<ContratoParcela>();

            //try
            //{
            //    objBLL = new ContratoParcelaDAO(Conexao, oOcorrencia, codEmpresa);
            //    listaContratoParcela = objBLL.listContParcelaGrid(idContratoParcela, idContrato);
            //}
            //catch (Exception erro)
            //{
            //    throw erro;
            //}
            //return listaContratoParcela;
        //}          

        //public Agenda ObterPor(int idImovel, DateTime dataEvento)
        //{
        //    Agenda objAgenda = new Agenda();
        //    try
        //    {                
        //        //Valida informações a serem gravadas

        //        objBLL = new AgendaDAO(Conexao, oOcorrencia, codEmpresa);
        //        objAgenda = objBLL.ObterPor(idImovel, dataEvento);

        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //    return objAgenda;
        //}
    }
}
