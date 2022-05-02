using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCLibrary;


namespace EMCSecurityRN
{
    public class UsuarioEmpresaRN
    {
        UsuarioEmpresaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public UsuarioEmpresaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa; 
        }

        public UsuarioEmpresaRN(ConectaBancoMySql pConexao)
        {
            Conexao = pConexao; 
        }

        public DataTable ListaUsuarioEmpresa(int idUsuario) /*---- Verificar ----*/
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new UsuarioEmpresaDAO(Conexao);
                dtCon = objBLL.ListaEmpresaUsuario(idUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaEmpresaUsuario(int idUsuario)
        {
            DataTable dtCon = new DataTable();
            
            try
            {
                objBLL = new UsuarioEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaUsuarioEmpresa(idUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(UsuarioEmpresa objUserEmp)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objUserEmp);

                objBLL = new UsuarioEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objUserEmp);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(UsuarioEmpresa objUserEmp)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objUserEmp);

                objBLL = new UsuarioEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objUserEmp);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(UsuarioEmpresa objUserEmp)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objUserEmp);

                objBLL = new UsuarioEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objUserEmp);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public UsuarioEmpresa ObterPor(UsuarioEmpresa objUserSis)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new UsuarioEmpresaDAO(Conexao, oOcorrencia, codEmpresa);
                objUserSis = objBLL.ObterPor(objUserSis);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objUserSis;

        }

        public void VerificaDados(UsuarioEmpresa obj)
        {

            Exception objErro;

            if (obj.idUsuario == 0)
            {
                objErro = new Exception("Nome Usuario não pode ser nulo");
                throw objErro;
            }
        }

    }
}
