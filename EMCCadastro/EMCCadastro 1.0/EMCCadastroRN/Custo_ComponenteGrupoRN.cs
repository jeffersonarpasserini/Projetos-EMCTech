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
    public class Custo_ComponenteGrupoRN
    {

        Custo_ComponenteGrupoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Custo_ComponenteGrupoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaCusto_ComponenteGrupo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Custo_ComponenteGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaCusto_ComponenteGrupo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCusto_ComponenteGrupo);

                objBLL = new Custo_ComponenteGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objCusto_ComponenteGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCusto_ComponenteGrupo);

                objBLL = new Custo_ComponenteGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objCusto_ComponenteGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objCusto_ComponenteGrupo);

                objBLL = new Custo_ComponenteGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objCusto_ComponenteGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Custo_ComponenteGrupo ObterPor(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Custo_ComponenteGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objCusto_ComponenteGrupo = objBLL.ObterPor(objCusto_ComponenteGrupo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objCusto_ComponenteGrupo;

        }

        public DataTable pesquisaComponenteGrupo(int empMaster, int idComponenteGrupo, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Custo_ComponenteGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaComponenteGrupo(empMaster, idComponenteGrupo, descricao);
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
        private void VerificaDados(Custo_ComponenteGrupo obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Grupo do Componente de Custo deve ser informada");
                throw objErro;
            }
        }

        #endregion
    }
}
