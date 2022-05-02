using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCLibrary;


namespace EMCSecurityRN
{
    public class ControleLoginRN
    {
        ControleLoginDAO objBLL;
        ConectaBancoMySql Conexao;

        public ControleLoginRN(ConectaBancoMySql pConexao)
        {
            Conexao = pConexao; 
        }

        public Login gravaLogin(Login login)
        {
            Login oLogin = new Login();
            try
            {
                objBLL = new ControleLoginDAO(Conexao);
                return objBLL.gravaLogin(login);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }


        public bool baixaLogin(Login login)
        {
            try
            {
                objBLL = new ControleLoginDAO(Conexao);
                return objBLL.baixaLogin(login);
            }
            catch (Exception erro)
            {
                throw erro;
                
            }
        }

    }
}
