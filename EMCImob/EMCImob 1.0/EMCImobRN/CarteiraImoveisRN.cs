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
    public class CarteiraImoveisRN
    {

        CarteiraImoveisDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CarteiraImoveisRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaCarteiraImoveis()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new CarteiraImoveisDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaCarteiraImoveis();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaCarteiraImoveis(String SSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new CarteiraImoveisDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(SSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaCarteiraImoveis(int empMaster, int idCarteiraImoveis, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new CarteiraImoveisDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaCarteiraImoveis(empMaster, idCarteiraImoveis, nome);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(CarteiraImoveis objCarteiraImoveis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCarteiraImoveis);

                objBLL = new CarteiraImoveisDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objCarteiraImoveis);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(CarteiraImoveis objCarteiraImoveis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCarteiraImoveis);

                objBLL = new CarteiraImoveisDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objCarteiraImoveis);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(CarteiraImoveis objCarteiraImoveis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCarteiraImoveis);

                objBLL = new CarteiraImoveisDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objCarteiraImoveis);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public CarteiraImoveis ObterPor(CarteiraImoveis objCarteiraImoveis)
        {
            try
            {
                //Valida informações a serem gravadas


                objBLL = new CarteiraImoveisDAO(Conexao, oOcorrencia, codEmpresa);
                objCarteiraImoveis = objBLL.ObterPor(objCarteiraImoveis);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCarteiraImoveis;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(CarteiraImoveis obj)
        {

            Exception objErro;

            if (obj.Descricao.Trim().Length == 0)
            {
                objErro = new Exception("Carteira não pode ser nula");
                throw objErro;
            }
        }

        #endregion
    }
}
