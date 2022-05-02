using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCImobModel;
using EMCImobDAO;
using EMCSecurityModel;

namespace EMCImobRN
{
    public class TipoImovelRN
    {

        TipoImovelDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TipoImovelRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaTipoImovel()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoImovelDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaTipoImovel();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }        

        public DataTable ListaTipoImovel(String SSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(SSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaTipoImovel(int empMaster, int idTipoImovel, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new TipoImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaTipoImovel(empMaster, idTipoImovel, nome);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(TipoImovel objTipoImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoImovel);

                objBLL = new TipoImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objTipoImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(TipoImovel objTipoImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoImovel);

                objBLL = new TipoImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objTipoImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(TipoImovel objTipoImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objTipoImovel);

                objBLL = new TipoImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objTipoImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public TipoImovel ObterPor(TipoImovel objTipoImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new TipoImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objTipoImovel = objBLL.ObterPor(objTipoImovel);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objTipoImovel;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(TipoImovel obj)
        {
            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Tipo de Imóvel não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
    }
}
