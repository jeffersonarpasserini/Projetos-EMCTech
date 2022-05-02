using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;

namespace EMCCadastroRN
{
    public class IndicesRN
    {

        IndicesDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IndicesRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        public DataTable ListaIndices(Indexador oIndice)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IndicesDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaIndices(oIndice);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Indices objIndices)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIndices);

                objBLL = new IndicesDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objIndices);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Indices objIndices)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIndices);

                objBLL = new IndicesDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objIndices);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Indices objIndices)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIndices);

                objBLL = new IndicesDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objIndices);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public DataTable pesquisaIndice(int empMaster, int idindexador, DateTime dataindice, Decimal valor, bool ckData)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new IndicesDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaIndice(empMaster, idindexador, dataindice, valor, ckData);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public Indices ObterPor(int idIndexador, DateTime dataIndice, Boolean obterUltimoIndice)
        {
            Indices objIndices = new Indices();
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objIndices);

                objBLL = new IndicesDAO(Conexao, oOcorrencia, codEmpresa);
                objIndices = objBLL.ObterPor(idIndexador, dataIndice,obterUltimoIndice);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objIndices;

        }
        public Indices ObterPor(Indices objIndices)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objIndices);

                objBLL = new IndicesDAO(Conexao,oOcorrencia,codEmpresa);
                objIndices = objBLL.ObterPor(objIndices);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objIndices;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Indices obj)
        {

            Exception objErro;

            if (obj.dataIndice == null)
            {
                objErro = new Exception("A data do indice não pode ser vazia");
                throw objErro;
            }
            if (obj.valor == 0)
            {
                objErro = new Exception("O Valor do indice não poder ser igual a zero");
                throw objErro;
            }
        }

        #endregion


    }
}
