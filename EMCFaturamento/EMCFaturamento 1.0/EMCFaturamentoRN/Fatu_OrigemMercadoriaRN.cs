using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCFaturamentoModel;
using EMCFaturamentoDAO;
using EMCSecurityModel;

namespace EMCFaturamentoRN
{
    public class Fatu_OrigemMercadoriaRN
    {

        Fatu_OrigemMercadoriaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_OrigemMercadoriaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = codempresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaFatu_OrigemMercadoria()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Fatu_OrigemMercadoriaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFatu_OrigemMercadoria();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_OrigemMercadoria);

                objBLL = new Fatu_OrigemMercadoriaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objFatu_OrigemMercadoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_OrigemMercadoria);

                objBLL = new Fatu_OrigemMercadoriaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objFatu_OrigemMercadoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFatu_OrigemMercadoria);

                objBLL = new Fatu_OrigemMercadoriaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objFatu_OrigemMercadoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Fatu_OrigemMercadoria ObterPor(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            try
            {
                objBLL = new Fatu_OrigemMercadoriaDAO(Conexao, oOcorrencia, codEmpresa);
                objFatu_OrigemMercadoria = objBLL.ObterPor(objFatu_OrigemMercadoria);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFatu_OrigemMercadoria;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Fatu_OrigemMercadoria obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição deve ser informada");
                throw objErro;
            }

            if (EmcResources.cInt(obj.codigoOrigem) < 0 || EmcResources.cInt(obj.codigoOrigem) > 9)
            {
                objErro = new Exception("Código de Origem Invalido");
                throw objErro;
            }
        }

        #endregion
    }
}
