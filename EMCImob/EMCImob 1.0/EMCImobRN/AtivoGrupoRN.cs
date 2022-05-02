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
    public class AtivoGrupoRN
    {

        AtivoGrupoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AtivoGrupoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaAtivoGrupo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new AtivoGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaAtivoGrupo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(AtivoGrupo objAtivoGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAtivoGrupo);

                objBLL = new AtivoGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objAtivoGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(AtivoGrupo objAtivoGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAtivoGrupo);

                objBLL = new AtivoGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objAtivoGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(AtivoGrupo objAtivoGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objAtivoGrupo);

                objBLL = new AtivoGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objAtivoGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public AtivoGrupo ObterPor(AtivoGrupo objAtivoGrupo)
        {
            try
            {
                //Valida informações a serem gravadas


                objBLL = new AtivoGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                objAtivoGrupo = objBLL.ObterPor(objAtivoGrupo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objAtivoGrupo;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(AtivoGrupo obj)
        {

            Exception objErro;

            if (obj.Descricao.Trim().Length == 0)
            {
                objErro = new Exception("O Grupo não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
    }
}
