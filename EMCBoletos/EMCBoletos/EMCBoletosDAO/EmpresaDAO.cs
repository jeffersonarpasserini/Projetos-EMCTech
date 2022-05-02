using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FirebirdSql.Data.FirebirdClient;
using EMCLibrary;
using EMCBoletosModel;

namespace EMCBoletosDAO
{
    public class EmpresaDAO
    {
        FbConnection Conexao;

        ParametroBanco strConn = new ParametroBanco();

        public DataTable ListaEmpresa()
        {
            try
            {
                Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
                Conexao.Open();

                //Monta comando para a gravação do registro
                String strSQL = "select * from empresa order by codempresa";
                FbCommand Sqlcon = new FbCommand(@strSQL, Conexao);

                FbDataAdapter daCon = new FbDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
            }
            catch (FbException erro)
            {
                throw erro;
            }
        }

        public Empresa ObterPor(Empresa oEmpresa)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * " +
                                " from empresa e " +
                                " where e.codempresa = @codempresa ";

                Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
                FbCommand Sqlcon = new FbCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oEmpresa.codEmpresa);

                Conexao.Open();

                FbDataReader drCon;

                drCon = Sqlcon.ExecuteReader(CommandBehavior.CloseConnection);


                Empresa objEmpresa = new Empresa();

                while (drCon.Read())
                {
                    objEmpresa.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objEmpresa.empMaster = Convert.ToInt32(drCon["empmaster"].ToString());
                    objEmpresa.razaoSocial = drCon["razaosocial"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                return objEmpresa;

            }
            catch (FbException erro)
            {
                throw erro;
            }
        }
    }
}
