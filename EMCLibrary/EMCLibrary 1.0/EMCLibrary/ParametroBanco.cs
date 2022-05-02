using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EMCLibrary
{
    public class ParametroBanco
    {
        public string strSelecionaBanco()
        {
            //busca qual é o opção de banco de dados a ser utilizado
            string conn = ConfigurationManager.AppSettings["BancoUtilizado"].ToString();
            return conn;
        }
        public String StrConnection()
        {
            string bcoUtilizado = strSelecionaBanco();
            string conn = StrConnection(bcoUtilizado);
            return conn;
        }
        public String StrConnection(string bancoDados)
        {
            string conn = "";

            if (bancoDados == "MYSQL")
            {
                conn = ConfigurationManager.ConnectionStrings["AcessoMySQL"].ToString(); 
            }
            else if (bancoDados == "SQLSERVER")
            {
                conn = ConfigurationManager.ConnectionStrings["AcessoSQLSERVER"].ToString();
            }
            else if (bancoDados == "FIREBIRD")
            {
                conn = ConfigurationManager.ConnectionStrings["AcessoFIREBIRD"].ToString();
            }
            return conn;
        }
    }
}
