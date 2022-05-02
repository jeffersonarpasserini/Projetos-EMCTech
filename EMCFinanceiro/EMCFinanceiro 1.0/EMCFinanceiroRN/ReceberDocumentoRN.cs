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
    public class ReceberDocumentoRN
    {
        
        ReceberDocumentoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberDocumentoRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaReceberDocumento(int codEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaReceberDocumento(codEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaReceberDocumento(int codEmpresa, int empMaster, int idCliente, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaReceberDocumento(codEmpresa,empMaster,idCliente,dataInicio,dataFinal,chkTodasContas,valorInicio,valorFinal,valorDocumento,docAberto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(ReceberDocumento objReceberDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objReceberDocumento);

                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objReceberDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void atualizarBaseRateio(ReceberDocumento objReceberDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objReceberDocumento);

                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.atualizarBaseRateio(objReceberDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public int Salvar(ReceberDocumento objReceberDocumento)
        {
            int idReceberDocumento = 0;
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objReceberDocumento);

                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                idReceberDocumento =  objBLL.Salvar(objReceberDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return idReceberDocumento;

        }

        public void Excluir(ReceberDocumento objReceberDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objReceberDocumento);

                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objReceberDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ReceberDocumento ObterPor(ReceberDocumento objReceberDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objReceberDocumento);

                objBLL = new ReceberDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                objReceberDocumento = objBLL.ObterPor(objReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objReceberDocumento;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(ReceberDocumento obj)
        {

            Exception objErro;

            ParametroDAO oParametroDAO = new ParametroDAO(Conexao, oOcorrencia, codEmpresa);
            //carrega valores da TRAVACONTABIL e PROCESSO_CONTABIL
            if (oParametroDAO.retParametro(codEmpresa, "EMCCONTABIL", "VALIDACAO", "TRAVADIGITACAO") == "S")
            {
                DateTime dataContabilidade = Convert.ToDateTime(oParametroDAO.retParametro(codEmpresa, "EMCCONTABIL", "VALIDACAO", "PROCESSO_CONTABIL"));

                if (obj.dataEntrada <= dataContabilidade)
                {
                    objErro = new Exception("Lançamento anterior a data de fechamento da contabilidade : " + dataContabilidade.ToShortDateString() );
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
            if (obj.cliente.idPessoa <= 0)
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
            foreach(ReceberBaseRateio oRat in obj.baseRateio)
            {
                if (oRat.status =="I" || oRat.status=="A" || oRat.status=="")
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
