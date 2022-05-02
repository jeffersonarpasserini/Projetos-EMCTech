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
    public class Custo_ComponenteRN
    {

        Custo_ComponenteDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Custo_ComponenteRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaCusto_Componente(int idGrupoComponente)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Custo_ComponenteDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaCusto_Componente(idGrupoComponente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Custo_Componente objCusto_Componente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCusto_Componente);

                objBLL = new Custo_ComponenteDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objCusto_Componente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Custo_Componente objCusto_Componente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCusto_Componente);

                objBLL = new Custo_ComponenteDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objCusto_Componente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Custo_Componente objCusto_Componente)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCusto_Componente);

                objBLL = new Custo_ComponenteDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objCusto_Componente);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Custo_Componente ObterPor(Custo_Componente objCusto_Componente)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Custo_ComponenteDAO(Conexao, oOcorrencia,codEmpresa);
                objCusto_Componente = objBLL.ObterPor(objCusto_Componente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCusto_Componente;

        }

        public DataTable pesquisaComponente(int empMaster, int idComponente, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Custo_ComponenteDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaComponente(empMaster, idComponente, descricao);
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
        private void VerificaDados(Custo_Componente obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Componente de Custo deve ser informada");
                throw objErro;
            }

            if (obj.Custo_ComponenteGrupo.idcusto_componentegrupo == 0)
            {
                objErro = new Exception("O Grupo do Componente de Custo deve ser informado");
                throw objErro;
            }
        }

        #endregion
    }
}
