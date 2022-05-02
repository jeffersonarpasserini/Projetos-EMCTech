using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCEstoqueModel;
using EMCEstoqueDAO;
using EMCSecurityModel;
using EMCCadastroModel;

namespace EMCEstoqueRN
{
    public class Estq_Produto_Lote_EstoqueRN
    {
        Estq_Produto_Lote_EstoqueDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_Lote_EstoqueRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public List<Estq_Produto_Lote_Estoque> lstEstq_ProdutoLoteEstoque(Estq_Produto_Lote oLote)
        {
            List<Estq_Produto_Lote_Estoque> lstEstoque = new List<Estq_Produto_Lote_Estoque>();
            try
            {
                //Valida informações a serem gravadas
                
                objBLL = new Estq_Produto_Lote_EstoqueDAO(Conexao, oOcorrencia, codEmpresa);
                lstEstoque = objBLL.lstEstq_ProdutoLoteEstoque(oLote);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstEstoque;
        }

        public DataTable ListaEstq_Produto_Lote_Estoque(Estq_Produto_Lote oLote)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_Lote_EstoqueDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Produto_Lote_Estoque(oLote);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Produto_Lote_Estoque oEstoque)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oEstoque);

                objBLL = new Estq_Produto_Lote_EstoqueDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(oEstoque);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Produto_Lote_Estoque oEstoque)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oEstoque);

                objBLL = new Estq_Produto_Lote_EstoqueDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(oEstoque);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto_Lote_Estoque oEstoque)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oEstoque);

                objBLL = new Estq_Produto_Lote_EstoqueDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(oEstoque);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Produto_Lote_Estoque ObterPor(Estq_Produto_Lote_Estoque oEstoque)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_Produto_Lote_EstoqueDAO(Conexao, oOcorrencia, codEmpresa);
                oEstoque = objBLL.ObterPor(oEstoque);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oEstoque;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Produto_Lote_Estoque obj)
        {

            Exception objErro;

            if (obj.produtoLote.idEstq_Produto_lote == 0)
            {
                objErro = new Exception("O Lote deve ser informado");
                throw objErro;
            }

            if (obj.almoxarifado.idestq_almoxarifado==0)
            {
                objErro = new Exception("O Almoxarifado deve ser informado");
                throw objErro;
            }

        }

        #endregion

    }
}
