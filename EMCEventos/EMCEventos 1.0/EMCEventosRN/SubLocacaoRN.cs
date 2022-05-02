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
    public class SubLocacaoRN
    {
        SubLocacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public SubLocacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaSubLocacao()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaSubLocacao();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
                
        public DataTable ListaSubLocacao(string codigoImovel, int idEvento, bool chkImovel, bool chkEvento, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);               
                dtCon = objBLL.dstRelatorioSubLoc(codigoImovel, idEvento, chkImovel, chkEvento, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaSubLocImovel(string codigoImovel, int idEvento, bool chkImovel, bool chkEvento)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioSubLocImovel(codigoImovel, idEvento, chkImovel, chkEvento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaSubLocacao(int empMaster, int idEvento, string descEvento, string idBox)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaSubLocacao(empMaster, idEvento, descEvento, idBox);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(SubLocacao objSubLocacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objSubLocacao);

                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objSubLocacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(SubLocacao objSubLocacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objSubLocacao);


                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objSubLocacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(SubLocacao objSubLocacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objSubLocacao);

                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objSubLocacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public SubLocacao ObterPor(SubLocacao objSubLocacao)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new SubLocacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objSubLocacao = objBLL.ObterPor(objSubLocacao);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objSubLocacao;
        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(SubLocacao obj)
        {

            Exception objErro;
            if (obj.evento.idEvento == 0)
            {
                objErro = new Exception("Evento não pode ser nulo");
                throw objErro;
            }

            if (obj.idBox.Trim().Length == 0)
            {
                objErro = new Exception("Box não pode ser nulo");
                throw objErro;
            }

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nulo");
                throw objErro;
            }


        }

        #endregion
    }
}
