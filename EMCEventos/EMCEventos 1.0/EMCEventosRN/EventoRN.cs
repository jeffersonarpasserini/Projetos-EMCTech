using EMCEventosDAO;
using EMCEventosModel;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMCEventosRN
{
    public class EventoRN
    {
        EventoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public EventoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        
        public DataTable ListaEvento()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEvento();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
                
        public List<Evento> LstEvento(int idEvento, int idImovel, string codigoImovel)
        {
            List<Evento> listaEvento = new List<Evento>();

            try
            {
                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                listaEvento = objBLL.lstEvento(idEvento, idImovel, codigoImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return listaEvento;
        }       
        
        public DataTable ListaEvento(int idEvento, int idImovel, string codigoImovel, bool chkImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioEvento(idEvento, idImovel, codigoImovel, chkImovel, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaEventoImovel(int idEvento, int idImovel, string codigoImovel, bool chkImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioImovel(idEvento, idImovel, codigoImovel, chkImovel, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        
        public DataTable pesquisaEvento(int empMaster, string codigoImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaEvento(empMaster, codigoImovel, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Evento objEvento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEvento);

                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objEvento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Evento objEvento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEvento);


                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objEvento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(Evento objEvento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEvento);

                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objEvento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public Evento ObterPor(Evento objEvento)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new EventoDAO(Conexao, oOcorrencia, codEmpresa);
                objEvento = objBLL.ObterPor(objEvento);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEvento;
        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Evento obj)
        {

            Exception objErro;
           
            //if (obj.imovel.codigoImovel.Trim().Length == 0)
            //{
            //    objErro = new Exception("Imóvel não pode ser nula");
            //    throw objErro;
            //}            
            
            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nulo");
                throw objErro;
            }

            
        }

        #endregion
    }
}
