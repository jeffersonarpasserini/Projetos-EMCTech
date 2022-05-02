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
    public class LocacaoProventosRN
    {
        LocacaoProventosDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoProventosRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaLocacaoProventos()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaLocacaoProventos();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaLocacaoProventos(String SSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(SSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaLocacaoProventos(int empMaster, int idLocacaoProventos, string nome)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaLocacaoProventos(empMaster, idLocacaoProventos, nome);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(LocacaoProventos objLocacaoProventos)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLocacaoProventos);

                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objLocacaoProventos);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(LocacaoProventos objLocacaoProventos)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLocacaoProventos);

                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objLocacaoProventos);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(LocacaoProventos objLocacaoProventos)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLocacaoProventos);

                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objLocacaoProventos);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public LocacaoProventos ObterPor(LocacaoProventos objLocacaoProventos)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new LocacaoProventosDAO(Conexao, oOcorrencia, codEmpresa);
                objLocacaoProventos = objBLL.ObterPor(objLocacaoProventos);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objLocacaoProventos;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(LocacaoProventos obj)
        {

            Exception objErro;

            if (obj.Descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            

        }

        #endregion
    }
}
