using EMCEventosDAO;
using EMCEventosModel;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EMCEventosRN
{
    public class AgendaRN
    {
        AgendaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AgendaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public List<Agenda> ListaCalendario(DateTime? dataAgenda)
        {
            List<Agenda> listaAgenda = new List<Agenda>();

            try
            {
                objBLL = new AgendaDAO(Conexao, oOcorrencia, codEmpresa);
                listaAgenda = objBLL.ListaCalendario(dataAgenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return listaAgenda;
        }
      
        public DataTable ListaAgendaEvento(int idImovel, string codigoImovel, int idEvento, string descEvento, bool chkImovel, bool chkEvento, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new AgendaDAO(Conexao, oOcorrencia, codEmpresa);                
                dtCon = objBLL.dstRelatorioEvento(idImovel, codigoImovel, idEvento, descEvento, chkImovel, chkEvento, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
           
        public List<Agenda> LstAgendaGrid(int idEvento, int idImovel, string codigoImovel, DateTime? dataInicio, DateTime? dataFinal)
        {
            List<Agenda> listaAgenda = new List<Agenda>();

            try
            {
                objBLL = new AgendaDAO(Conexao, oOcorrencia, codEmpresa);
                listaAgenda = objBLL.listAgendaGrid(idEvento, idImovel, codigoImovel, dataInicio, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return listaAgenda;
        }          

        public Agenda ObterPor(int idImovel, DateTime dataEvento)
        {
            Agenda objAgenda = new Agenda();
            try
            {                
                //Valida informações a serem gravadas

                objBLL = new AgendaDAO(Conexao, oOcorrencia, codEmpresa);
                objAgenda = objBLL.ObterPor(idImovel, dataEvento);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objAgenda;
        }

    }
}
