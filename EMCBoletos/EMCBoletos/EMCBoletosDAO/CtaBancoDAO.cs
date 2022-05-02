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
    public class CtaBancoDAO
    {
        FbConnection Conexao;

        ParametroBanco strConn = new ParametroBanco();
      
        public void geraSequencia(CtaBanco oCta)
        {
            Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
            Conexao.Open();

            FbTransaction transacao = Conexao.BeginTransaction();
            try 
            {
                String strSQL3 = "update ctabanco set seqarqremessa=@seqarqremessa where codempresa=@codempresa and bancodi=@bancodi";
                FbCommand Sqlcon3 = new FbCommand(@strSQL3, Conexao, transacao);
                Sqlcon3.Parameters.AddWithValue("@codempresa", oCta.codEmpresa);
                Sqlcon3.Parameters.AddWithValue("@bancodi", oCta.idCtaBancaria);
                Sqlcon3.Parameters.AddWithValue("@seqarqremessa", oCta.seqArqRemessa);
                

                Sqlcon3.ExecuteNonQuery();

                transacao.Commit();

                Sqlcon3.Dispose();

            }
            catch (FbException erro)
            {
                transacao.Rollback();
                throw erro;
            }
            finally
            {
                transacao.Dispose();
                transacao = null;
            }
        }

        public CtaBanco ObterPor(CtaBanco oCtaBanco)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select b.*, bco.bconume, e.razaosocial, e.cnpj " + 
                                " from ctabanco b, empresa e, banco bco " + 
                                " where e.codempresa = b.codempresa and " + 
                                " bco.codempresa = b.empmaster and bco.bcoenti = b.banbanc " + 
                                " and b.codempresa=@codempresa and b.bancodi=@bancodi";

                Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
                FbCommand Sqlcon = new FbCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oCtaBanco.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@bancodi", oCtaBanco.idCtaBancaria);
                
                Conexao.Open();

                FbDataReader drCon;

                drCon = Sqlcon.ExecuteReader(CommandBehavior.CloseConnection);


                CtaBanco objConta = new CtaBanco();

                while (drCon.Read())
                {

                    objConta.idCtaBancaria = Convert.ToInt32(drCon["bancodi"].ToString());
                    objConta.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objConta.descricao = drCon["bandesc"].ToString();
                    objConta.digAgencia = drCon["banagencia_digito"].ToString();
                    objConta.digCedente = drCon["bancedente_digito"].ToString();
                    objConta.digConta = drCon["banconta_digito"].ToString();
                    objConta.empMaster = EmcResources.cInt(drCon["empmaster"].ToString());
                    objConta.nossoNumero = drCon["jlmnossonro"].ToString();
                    objConta.nroAgencia = drCon["banagen"].ToString();
                    objConta.nroCedente = drCon["bancedente"].ToString();
                    objConta.nroConta = drCon["bancont"].ToString();
                    objConta.empCNPJ = drCon["cnpj"].ToString();
                    objConta.empRazaoSocial = drCon["razaosocial"].ToString();
                    objConta.nroBanco = drCon["bconume"].ToString();
                    objConta.seqArqRemessa = EmcResources.cInt(drCon["seqarqremessa"].ToString());
                    objConta.cedenteRazao = drCon["cedenterazaosocial"].ToString();
                    objConta.cedenteCnpj = drCon["cedentecnpj"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                return objConta;

            }
            catch (FbException erro)
            {
                throw erro;
            }
        }

        public DataTable ListaConta(int pCodEmpresa)
        {
            try
            {
                Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
                Conexao.Open();

                //Monta comando para a gravação do registro
                String strSQL = "select * from ctabanco where codempresa=@codempresa order by bandesc";
                FbCommand Sqlcon = new FbCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", pCodEmpresa);

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


    }
}
