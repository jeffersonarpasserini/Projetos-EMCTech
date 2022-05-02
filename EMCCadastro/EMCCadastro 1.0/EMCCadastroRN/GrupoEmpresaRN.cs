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
    public class GrupoEmpresaRN
    {
        GrupoEmpresaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public GrupoEmpresaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaGrupoEmpresa(GrupoEmpresa oGrupoEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new GrupoEmpresaDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaGrupoEmpresa(oGrupoEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        //Retorna DataSet com o conteúdo da consulta passada como parâmetro
        public DataTable ListaGrupoEmpresa(String sSQL)
           {
           DataTable dtCon = new DataTable();

           try
              {
              objBLL = new GrupoEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
              dtCon = objBLL.dstRelatorio(sSQL);

              }
           catch (Exception erro)
              {
              throw erro;
              }
           return dtCon;
           }


        public void Atualizar(GrupoEmpresa oGrupoEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oGrupoEmpresa);

                objBLL = new GrupoEmpresaDAO(Conexao,oOcorrencia, codEmpresa);
                objBLL.Atualizar(oGrupoEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(GrupoEmpresa oGrupoEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oGrupoEmpresa);

                objBLL = new GrupoEmpresaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(oGrupoEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(GrupoEmpresa oGrupoEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oGrupoEmpresa);

                objBLL = new GrupoEmpresaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(oGrupoEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public GrupoEmpresa ObterPor(GrupoEmpresa oGrupoEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new GrupoEmpresaDAO(Conexao,oOcorrencia,codEmpresa);
                oGrupoEmpresa = objBLL.ObterPor(oGrupoEmpresa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return oGrupoEmpresa;

        }

        public DataTable pesquisaGrupoEmpresa(int empMaster, int idGrupoEmpresa, int idHolding, String nomeGrupoEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new GrupoEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaGrupoEmpresa(empMaster, idGrupoEmpresa, idHolding, nomeGrupoEmpresa);
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
        public void VerificaDados(GrupoEmpresa obj)
        {

            Exception objErro;

            if (obj.nomeGrupoEmpresa.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            if (obj.idGrupoEmpresa < 0)
            {
                objErro = new Exception("Código da GrupoEmpresa não pode ser nulo");
                throw objErro;
            }

        }

        #endregion

    }
}
