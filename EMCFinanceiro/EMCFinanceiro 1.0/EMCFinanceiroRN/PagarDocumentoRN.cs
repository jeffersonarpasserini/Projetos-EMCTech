using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCFinanceiroRN
{
    public class PagarDocumentoRN
    {


        PagarDocumentoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarDocumentoRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaPagarDocumento(int codEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaPagarDocumento(codEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaPagarDocumento(int codEmpresa, int empMaster, int idFornecedor, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaPagarDocumento(codEmpresa,empMaster,idFornecedor,dataInicio,dataFinal,chkTodasContas,valorInicio,valorFinal,valorDocumento,docAberto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(PagarDocumento objPagarDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPagarDocumento);

                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objPagarDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void atualizarBaseRateio(PagarDocumento objPagarDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPagarDocumento);

                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.atualizarBaseRateio(objPagarDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(PagarDocumento objPagarDocumento)
        {
           
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPagarDocumento);

                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objPagarDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(PagarDocumento objPagarDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPagarDocumento);

                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objPagarDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public PagarDocumento ObterPor(PagarDocumento objPagarDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objPagarDocumento);

                objBLL = new PagarDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objPagarDocumento = objBLL.ObterPor(objPagarDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objPagarDocumento;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(PagarDocumento obj)
        {

            Exception objErro;
            ParametroDAO oParametroDAO = new ParametroDAO(Conexao, oOcorrencia, codEmpresa);
            //carrega valores da TRAVACONTABIL e PROCESSO_CONTABIL
            if (oParametroDAO.retParametro(codEmpresa, "EMCCONTABIL", "VALIDACAO", "TRAVADIGITACAO") == "S")
            {
                DateTime dataContabilidade = Convert.ToDateTime(oParametroDAO.retParametro(codEmpresa, "EMCCONTABIL", "VALIDACAO", "PROCESSO_CONTABIL"));

                if (obj.dataEntrada <= dataContabilidade)
                {
                    objErro = new Exception("Lançamento anterior a data de fechamento da contabilidade : " + dataContabilidade.ToShortDateString());
                    throw objErro;
                }


            }

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição do PagarDocumento não pode estar vazia :" + obj.descricao + " * ");
                throw objErro;
            }

            if (obj.dataEmissao > obj.dataEntrada)
            {
                objErro = new Exception("A data de emissão não deve ser maior que a data de entrada ");
                throw objErro;

            }

            if (obj.fornecedor.idPessoa <= 0)
            {
                objErro = new Exception("Informar um fornecedor para o documento");
                throw objErro;
            }

            if (obj.indexador.idIndexador <= 0)
            {
                objErro = new Exception("Informar um indexador para o documento");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.nroDocumento))
            {
                objErro = new Exception("Informar um número para o documento");
                throw objErro;
            }

            if (obj.nroParcelas <= 0)
            {
                objErro = new Exception("Informar o numero de parcelas para o documento");
                throw objErro;
            }

            if (obj.parcelas.Count != obj.nroParcelas)
            {
                objErro = new Exception("Verificar se o número de parcelas está correto");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.periodicidade))
            {
                objErro = new Exception("Informar a periodicidade das parcelas");
                throw objErro;
            }
            if (obj.tipoDocumento.idTipoDocumento <= 0)
            {
                objErro = new Exception("Informar o tipo do documento");
                throw objErro;
            }
            if (obj.valorDocumento <= 0)
            {
                objErro = new Exception("Informar o valor do documento");
                throw objErro;
            }
            if (obj.baseRateio == null || obj.baseRateio.Count <= 0)
            {
                objErro = new Exception("Informar a Base de Rateio para o documento");
                throw objErro;
            }
            Boolean testaBaseRateio = false;
            foreach (PagarBaseRateio oRat in obj.baseRateio)
            {
                if (oRat.status == "I" || oRat.status == "A" || oRat.status == "")
                {
                    testaBaseRateio = true;
                }
            }

            if (!testaBaseRateio)
            {
                objErro = new Exception("Não é permitida a exclusão de todas as bases de rateio do documento");
                throw objErro;
            }

        }

        #endregion


    }
}
