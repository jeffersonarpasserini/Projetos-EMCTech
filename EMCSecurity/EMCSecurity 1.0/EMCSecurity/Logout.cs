using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityRN;

namespace EMCSecurity
{
    public class Logout
    {
        public static bool getLogout(int idAcesso, ConectaBancoMySql pConexao) 
        {
            

            if (pConexao == null)
            {
                ConectaBancoMySql myConexao = new ConectaBancoMySql();
                pConexao = myConexao;
            }

            
            ControleLoginRN oCtrLoginRN = new ControleLoginRN(pConexao);
            Login oLogin = new Login();

            oLogin.seqLogin = idAcesso;
            oLogin.macAddress = "";

            if (oCtrLoginRN.baixaLogin(oLogin))
            {
                return true;
                
            }

            return false;
           
        }

    }
}
