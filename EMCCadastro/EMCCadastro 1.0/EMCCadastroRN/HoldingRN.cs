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
    public class HoldingRN
    {

        HoldingDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public HoldingRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaHolding(Holding oHolding)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new HoldingDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaHolding(oHolding);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Holding oHolding)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oHolding);

                objBLL = new HoldingDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(oHolding);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Holding oHolding)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oHolding);

                objBLL = new HoldingDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(oHolding);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Holding oHolding)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oHolding);

                objBLL = new HoldingDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(oHolding);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Holding ObterPor(Holding oHolding)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new HoldingDAO(Conexao,oOcorrencia,codEmpresa);
                oHolding = objBLL.ObterPor(oHolding);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return oHolding;

        }

        public DataTable pesquisaHolding(int empMaster, int idHolding, string nomeHolding)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new HoldingDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaHolding(empMaster, idHolding, nomeHolding);

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
        public void VerificaDados(Holding obj)
        {

            Exception objErro;

            if (obj.nomeHolding.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            if (obj.idHolding < 0)
            {
                objErro = new Exception("Código da Holding não pode ser nulo");
                throw objErro;
            }

        }

        #endregion
    }
}
