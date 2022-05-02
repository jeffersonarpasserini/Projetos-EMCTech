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
    public class TipoLanctoCaptacaoRN
    {

        TipoLanctoCaptacaoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoLanctoCaptacaoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaTipoLanctoCaptacao()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaTipoLanctoCaptacao();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaTipoLanctoCaptacao(String SSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(SSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaTipoLanctoCaptacao(int empMaster, int idTipoLanctoCaptacao, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaTipoLanctoCaptacao(empMaster, idTipoLanctoCaptacao, nome);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoLanctoCaptacao);

                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objTipoLanctoCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoLanctoCaptacao);

                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objTipoLanctoCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoLanctoCaptacao);

                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objTipoLanctoCaptacao);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public TipoLanctoCaptacao ObterPor(TipoLanctoCaptacao objTipoLanctoCaptacao)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new TipoLanctoCaptacaoDAO(Conexao, oOcorrencia, codEmpresa);
                objTipoLanctoCaptacao = objBLL.ObterPor(objTipoLanctoCaptacao);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objTipoLanctoCaptacao;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(TipoLanctoCaptacao obj)
        {

            Exception objErro;

            if (obj.Descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
        }

        #endregion
    }
}
