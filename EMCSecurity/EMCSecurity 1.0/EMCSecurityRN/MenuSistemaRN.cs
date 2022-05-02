using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCLibrary;

namespace EMCSecurityRN
{
    public class MenuSistemaRN
    {
        MenuSistemaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public MenuSistemaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa; 
        }

        public MenuSistemaRN(ConectaBancoMySql pConexao)
        {
            Conexao = pConexao;
            //oOcorrencia = parOcorrencia;
            //codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        
        public DataTable ListaMenuSistema()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MenuSistemaDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaMenuSistema();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }      

        public  List<MenuSistema> LstMenuSistema()
        {
            try
            {
                List<MenuSistema> listMenuSis = new List<MenuSistema>();

                MenuSistemaDAO oMenuSistemaDAO = new MenuSistemaDAO(Conexao, oOcorrencia, codEmpresa);
                listMenuSis = oMenuSistemaDAO.LstMenuSistema();

                return listMenuSis;
            }
            catch(Exception oErro)
            {
                throw oErro;
            }
        }        

        public void Atualizar(MenuSistema objMenuSis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMenuSis);

                objBLL = new MenuSistemaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objMenuSis);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Salvar(MenuSistema objMenuSis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMenuSis);

                objBLL = new MenuSistemaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objMenuSis);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(MenuSistema objMenuSis)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMenuSis);

                objBLL = new MenuSistemaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objMenuSis);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public MenuSistema ObterPor(MenuSistema objMenuSis)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new MenuSistemaDAO(Conexao,oOcorrencia,codEmpresa);
                objMenuSis = objBLL.ObterPor(objMenuSis);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objMenuSis;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(MenuSistema obj)
        {

            Exception objErro;

            if (obj.modulo.Trim().Length == 0)
            {
                objErro = new Exception("Módulo não pode ser nulo");
                throw objErro;
            }
            if (obj.idMenuSistema == 0)
            {
                objErro = new Exception("Id não pode ser nulo");
                throw objErro;
            }
            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nulo");
                throw objErro;
            }  /*
            if (obj.nNamespace.Trim().Length == 0)
            {
                objErro = new Exception("Namespace não pode ser nulo");
                throw objErro;
            }
            if (obj.endereco.Trim().Length == 0)
            {
                objErro = new Exception("Endereço não pode ser nulo");
                throw objErro;
            } */
            if (obj.ordem < 0)
            {
                objErro = new Exception("Ordem não pode ser nulo");
                throw objErro;
            }
            if (obj.menuPai < 0)
            {
                objErro = new Exception("Menu Pai não pode ser nulo");
                throw objErro;
            }
            if (obj.nivel < 0)
            {
                objErro = new Exception("Nível não pode ser nulo");
                throw objErro;
            }

        }

        #endregion
    }
}
