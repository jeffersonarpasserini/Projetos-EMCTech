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
    public class IbgeCidadeRN
    {
        IbgeCidadeDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IbgeCidadeRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaIbgeCidade()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new IbgeCidadeDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaIbgeCidade();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(IbgeCidade objIbgeCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIbgeCidade);

                objBLL = new IbgeCidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objIbgeCidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(IbgeCidade objIbgeCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIbgeCidade);

                objBLL = new IbgeCidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objIbgeCidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(IbgeCidade objIbgeCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objIbgeCidade);

                objBLL = new IbgeCidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objIbgeCidade);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public IbgeCidade ObterPor(IbgeCidade objIbgeCidade)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objIbgeCidade);

                objBLL = new IbgeCidadeDAO(Conexao,oOcorrencia,codEmpresa);
                objIbgeCidade = objBLL.ObterPor(objIbgeCidade);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objIbgeCidade;

        }

        public DataTable pesquisaIbgeCidade(int empMaster, int idIbgeCidade, String nomeCidade, String estado)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new IbgeCidadeDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaIbgeCidade(empMaster, idIbgeCidade, nomeCidade, estado);
                

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
        private void VerificaDados(IbgeCidade obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.codigoIbge))
            {
                objErro = new Exception("O código do municipio deve estar preenchido");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.estado.idEstado))
            {
                objErro = new Exception("O Estado deve estar preenchido");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.nomeCidade))
            {
                objErro = new Exception("O nome da cidade deve estar preenchido");
                throw objErro;
            }

        }

        #endregion
    }
}
