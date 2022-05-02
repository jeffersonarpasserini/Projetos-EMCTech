using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCObrasModel;
using EMCObrasDAO;
using EMCSecurityModel;
using EMCCadastroDAO;
using EMCCadastroModel;


namespace EMCObrasRN
{
    public class ObraRN
    {
        ObraDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ObraRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable listaObra()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ObraDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.listaObra();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void atualizar(Obra objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new ObraDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.atualizar(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void alteraSituacaoObra(Obra objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new ObraDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.alteraSituacaoObra(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void salvar(Obra objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new ObraDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.salvar(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void excluir(Obra objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new ObraDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.excluir(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra obterPor(Obra objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ObraDAO(Conexao, oOcorrencia, codEmpresa);
                objObra = objBLL.ObterPor(objObra);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição da Obra deve ser informada");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição da Obra deve ser informada");
                throw objErro;
            }

            if (obj.dtaFinal <= obj.dtaInicio)
            {
                objErro = new Exception("Data Final deve ser maior que a inicial");
                throw objErro;
            }
            if (obj.contaCusto.idContaCusto == 0)
            {
                objErro = new Exception("Conta custo deve ser informada");
                throw objErro;
            }
        }

        #endregion





    }
}
