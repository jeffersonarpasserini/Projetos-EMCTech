using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCSecurityRN
{
    public class MenuUsuarioRN
    {

        MenuUsuarioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public MenuUsuarioRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        //-------------------------------------------        

        public DataTable ListaMenuUsuario()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaMenuUsuario();
            }
            catch (Exception erro)
            {
                throw erro;
            }            
            return dtCon;
        }
        public DataTable ListaMenuUsuario(int idUsuario)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaMenuUsuario(idUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(MenuUsuario objMenuUser)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMenuUser);

                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objMenuUser);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Salvar(MenuUsuario objMenuUser)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMenuUser);

                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objMenuUser);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        
        public void Excluir(MenuUsuario objMenuUser)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objMenuUser);

                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objMenuUser);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void VerificaDados(MenuUsuario obj)
        {
            Exception objErro;

            if(obj.idUsuario == 0)
            {
                objErro = new Exception("Usuário não pode ser nulo");
                throw objErro;
            }
        }

        public MenuUsuario ObterPor(MenuUsuario objMenuUser)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                objMenuUser = objBLL.ObterPor(objMenuUser);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objMenuUser;

        }

        //--------------------------------------------

        public MenuUsuario ObterPor(string Formulario, int idUsuario, string Aplicativo)
        {
            MenuUsuario oMenu = new MenuUsuario();
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objAplicativo);

                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                oMenu = objBLL.ObterPor(Formulario, idUsuario, Aplicativo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oMenu;

        }
        public MenuUsuario ObterPor(int idMenuUsuario, int idUsuario, string Aplicativo)
        {
            MenuUsuario oMenu = new MenuUsuario();
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objAplicativo);

                objBLL = new MenuUsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                oMenu = objBLL.ObterPor(idMenuUsuario, idUsuario, Aplicativo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oMenu;

        }
    }
}
