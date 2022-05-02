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
    public class UsuarioBLL
    {
        UsuarioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public UsuarioBLL(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa; 
        }

        public UsuarioBLL(ConectaBancoMySql pConexao)
        {
            Conexao = pConexao;
            //oOcorrencia = parOcorrencia;
            //codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        
        public Usuario ValidaSenha(Usuario objUsuario)
        {
            Usuario objUser = new Usuario();

            try
            {
                objBLL = new UsuarioDAO(Conexao);
                objUser = objBLL.ValidaSenha(objUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objUser;
        }

        public DataTable ListaUsuario()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new UsuarioDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaUsuario();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public List<Usuario> LstMenuSistema()
        {
            try
            {
                List<Usuario> listUser = new List<Usuario>();

                UsuarioDAO oUsuarioDAO = new UsuarioDAO(Conexao, oOcorrencia, codEmpresa);
                listUser = oUsuarioDAO.LstUsuario();

                return listUser;
            }
            catch (Exception oErro)
            {
                throw oErro;
            }
        }        

        public void Atualizar(Usuario objUser)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objUser);

                objBLL = new UsuarioDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objUser);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Usuario objUser)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objUser);

                objBLL = new UsuarioDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objUser);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Usuario objUser)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objUser);

                objBLL = new UsuarioDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objUser);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Usuario ObterPor(Usuario objUser)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new UsuarioDAO(Conexao,oOcorrencia,codEmpresa);
                objUser = objBLL.ObterPor(objUser);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objUser;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Usuario obj)
        {

            Exception objErro;

            if (obj.nome.Trim().Length == 0)
            {
                objErro = new Exception("Nome Usuario não pode ser nulo");
                throw objErro;
            }
            if (obj.senha.Trim().Length == 0)
            {
                objErro = new Exception("Senha não pode ser nulo");
                throw objErro;
            }
        }

        #endregion


    }
}
