using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCEstoqueModel;
using EMCEstoqueDAO;
using EMCSecurityModel;

namespace EMCEstoqueRN
{
    public class Estq_Produto_VolumeRN
    {

        Estq_Produto_VolumeDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_Produto_VolumeRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Produto_Volume(int idProduto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_Produto_VolumeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaEstq_Produto_Volume(idProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Volume);

                objBLL = new Estq_Produto_VolumeDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objEstq_Produto_Volume);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Volume);

                objBLL = new Estq_Produto_VolumeDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objEstq_Produto_Volume);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto_Volume);

                objBLL = new Estq_Produto_VolumeDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Produto_Volume);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Produto_Volume ObterPor(Estq_Produto_Volume objEstq_Produto_Volume)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_Produto_VolumeDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Produto_Volume = objBLL.ObterPor(objEstq_Produto_Volume);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Produto_Volume;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_Produto_Volume obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.fatorconversao))
            {
                objErro = new Exception("O Fator de Conversão deve ser informada");
                throw objErro;
            }

            if (obj.Estq_Produto_Unidade.idestq_produto_unidade == 0)
            {
                objErro = new Exception("A Unidade deve ser informada");
                throw objErro;
            }

        }

        #endregion
    }
}
