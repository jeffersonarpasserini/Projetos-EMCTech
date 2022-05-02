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
    public class CidadeRN
    {
        CidadeDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CidadeRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaCidade()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new CidadeDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaCidade();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Cidade objCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCidade);

                objBLL = new CidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objCidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Cidade objCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCidade);

                objBLL = new CidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objCidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Cidade objCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCidade);

                objBLL = new CidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objCidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Cidade ObterPor(Cidade objCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCidade);

                objBLL = new CidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objCidade = objBLL.ObterPor(objCidade);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCidade;

        }

        public DataTable pesquisaCidade(int empMaster, int idCidade, String descricao, String abreviatura)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new CidadeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaCidade(empMaster, idCidade, descricao);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }


        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Cidade obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.nomeCidade))
            {
                objErro = new Exception("O nome da cidade deve ser preenchido");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.cepCidade))
            {
                objErro = new Exception("O Cep da cidade deve ser preenchido");
                throw objErro;
            }
            if (obj.ibgeCidade.idIbgeCidade==0)
            {
                objErro = new Exception("O codigo do municipio no IBGE deve ser preenchido");
                throw objErro;
            }

        }

        #endregion


    }
}
