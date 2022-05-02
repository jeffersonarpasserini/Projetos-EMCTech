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
    public class TipoDocumentoRN
    {

        TipoDocumentoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoDocumentoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaTipoDocumento()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoDocumentoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaTipoDocumento();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(TipoDocumento objTipoDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoDocumento);

                objBLL = new TipoDocumentoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objTipoDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(TipoDocumento objTipoDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoDocumento);

                objBLL = new TipoDocumentoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objTipoDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(TipoDocumento objTipoDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoDocumento);

                objBLL = new TipoDocumentoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objTipoDocumento);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public TipoDocumento ObterPor(TipoDocumento objTipoDocumento)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objTipoDocumento);

                objBLL = new TipoDocumentoDAO(Conexao,oOcorrencia,codEmpresa);
                objTipoDocumento = objBLL.ObterPor(objTipoDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objTipoDocumento;

        }

        public DataTable pesquisaTipoDocumento(int empMaster, int idTipoDocumento, String descricao, String abreviatura)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new TipoDocumentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaTipoDocumento(empMaster, idTipoDocumento, descricao, abreviatura);

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
        private void VerificaDados(TipoDocumento obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição do Tipo Documento não pode estar vazia");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.abreviatura))
            {
                objErro = new Exception("A abreviatura do TipoDocumento não pode estar vazia");
                throw objErro;
            }
        }

        #endregion

    }
}
