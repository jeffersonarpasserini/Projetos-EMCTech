using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCCadastroDAO;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;
using System.Data;


namespace EMCFinanceiroDAO
{
    public class LayoutChequeDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LayoutChequeDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = pOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = pOcorrencia;
            }
            codEmpresa = idEmpresa;

        }

        public DataTable ListaLayoutCheque(CtaBancaria oConta)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from layoutcheque ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LayoutCheque ObterPor(LayoutCheque oCheque)
        {
            MySqlDataReader drCon;

            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from layoutcheque Where idlayoutcheque = @idlayoutcheque ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idLayoutCheque", oCheque.idLayoutCheque);

                drCon = Sqlcon.ExecuteReader();


                LayoutCheque oLayoutCheque = new LayoutCheque();

                while (drCon.Read())
                {
                    consulta = true;
                    oLayoutCheque.idLayoutCheque = EmcResources.cInt(drCon["idlayoutcheque"].ToString());
                    oLayoutCheque.chequeCompacta = drCon["compactacheque"].ToString();
                    oLayoutCheque.valorCompacta = drCon["compactavalor"].ToString();
                    oLayoutCheque.descricao = drCon["descricao"].ToString();

                    Banco oBanco = new Banco();
                    oBanco.idBanco = oLayoutCheque.tamanhoLinha = EmcResources.cInt(drCon["idbanco"].ToString());
                    oLayoutCheque.idBanco = oBanco;

                    oLayoutCheque.espacoAno = EmcResources.cInt(drCon["espacoano"].ToString());
                    oLayoutCheque.espacoCidade = EmcResources.cInt(drCon["espacocidade"].ToString());
                    oLayoutCheque.espacoDia = EmcResources.cInt(drCon["espacodia"].ToString());
                    oLayoutCheque.espacoMes = EmcResources.cInt(drCon["espacomes"].ToString());
                    oLayoutCheque.espacoExtenso1 = EmcResources.cInt(drCon["espacoextenso"].ToString());
                    oLayoutCheque.espacoExtenso2 = EmcResources.cInt(drCon["espacoextenso2"].ToString());
                    oLayoutCheque.espacoNominal = EmcResources.cInt(drCon["espaconominal"].ToString());
                    oLayoutCheque.espacoObservação = EmcResources.cInt(drCon["espacoobservacao"].ToString());
                    oLayoutCheque.espacoPredatado = EmcResources.cInt(drCon["espacopredatado"].ToString());
                    oLayoutCheque.espacoValor = EmcResources.cInt(drCon["espacovalor"].ToString());
                    oLayoutCheque.tamanhoLinha = EmcResources.cInt(drCon["tamanholinha"].ToString());
                    
                    oLayoutCheque.margemCidade = EmcResources.cInt(drCon["margemcidade"].ToString());
                    oLayoutCheque.margemExtenso1 = EmcResources.cInt(drCon["margemextenso1"].ToString());
                    oLayoutCheque.margemExtenso2 = EmcResources.cInt(drCon["margemextenso2"].ToString());
                    oLayoutCheque.margemNominal = EmcResources.cInt(drCon["margemnominal"].ToString());
                    oLayoutCheque.margemObservacao = EmcResources.cInt(drCon["margemobservacao"].ToString());
                    oLayoutCheque.margemPreDatado = EmcResources.cInt(drCon["margempredatado"].ToString());
                    oLayoutCheque.margemValor = EmcResources.cInt(drCon["margemvalor"].ToString());
                    
                    oLayoutCheque.saltoCidade = EmcResources.cInt(drCon["saltocidade"].ToString());
                    oLayoutCheque.saltoExtenso1 = EmcResources.cInt(drCon["saltoextenso1"].ToString());
                    oLayoutCheque.saltoExtenso2 = EmcResources.cInt(drCon["saltoextenso2"].ToString());
                    oLayoutCheque.saltoNominal =  EmcResources.cInt(drCon["saltonominal"].ToString());
                    oLayoutCheque.saltoPreDatado = EmcResources.cInt(drCon["saltopredatado"].ToString());
                    oLayoutCheque.saltoProximaFolha = EmcResources.cInt(drCon["saltoproximafolha"].ToString());
                    oLayoutCheque.saltoValor = EmcResources.cInt(drCon["saltovalor"].ToString());


                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    BancoDAO oBancoDAO = new BancoDAO(parConexao, oOcorrencia, codEmpresa);
                    oLayoutCheque.idBanco = oBancoDAO.ObterPor(oLayoutCheque.idBanco);
                }

                return oLayoutCheque;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {

            }
        }

    }
}
