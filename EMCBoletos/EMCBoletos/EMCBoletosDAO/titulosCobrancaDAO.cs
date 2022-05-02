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
    public class titulosCobrancaDAO
    {
        FbConnection Conexao;

        ParametroBanco strConn = new ParametroBanco();        

        public titulosCobrancaDAO()
        {
        }

        public void gravaRemessa(List<TituloCobranca> lstTitulo, string nomeArquivo)
        {

            Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
            Conexao.Open();

            FbTransaction transacao = Conexao.BeginTransaction();
            
            //atualiza um registro de Aplicacao
            try
            {
                FbCommand Sqlcon = null;

                string strSQL = "update parreceber set arquivoremessa=@arquivoremessa where codempresa=@codempresa " +
                                                  " and efpclie=@efpclie and efpnume=@efpnume and efpparc=@efpparc";

                foreach (TituloCobranca oTitulo in lstTitulo)
                {

                    //Monta comando para a gravação do registro

                    Sqlcon = new FbCommand(@strSQL, Conexao, transacao);
                    Sqlcon.Parameters.AddWithValue("@codempresa", oTitulo.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@efpclie", oTitulo.idCliente);
                    Sqlcon.Parameters.AddWithValue("@efpnume", oTitulo.idContrato);
                    Sqlcon.Parameters.AddWithValue("@efpparc", oTitulo.nroParcela);
                    Sqlcon.Parameters.AddWithValue("@arquivoremessa", oTitulo.nomeArquivo);
                    

                    Sqlcon.ExecuteNonQuery();
                }
   
                transacao.Commit();

                Sqlcon.Dispose();

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
        public void gravaTitulos(List<TituloCobranca> lstTitulo,Empresa oEmpresa, int idConta, string nossoNumero)
        {
            Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));
            Conexao.Open();

            FbTransaction transacao = Conexao.BeginTransaction();
            
            //atualiza um registro de Aplicacao
            try
            {

                String strSQL = "update IMB_LOCPARCELAS set lpadocu=@nossonumero, nrocontatitulo=@nrocontatitulo where codempresa=@codempresa and lpaloca=@lpaloca and lpanume=@lpanume";
                String strSQL2 = "update parreceber set efpdocu=@efpdocu, nrocontatitulo=@nrocontatitulo, arquivoremessa=@arquivoremessa " + 
                                                  " where codempresa=@codempresa " +
                                                  " and efpclie=@efpclie and efpnume=@efpnume and efpparc=@efpparc";

                foreach (TituloCobranca oTitulo in lstTitulo)
                {
                
                    //Monta comando para a gravação do registro

                    FbCommand Sqlcon = new FbCommand(@strSQL, Conexao, transacao);
                    Sqlcon.Parameters.AddWithValue("@codempresa", oTitulo.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@lpaloca", oTitulo.idContrato);
                    Sqlcon.Parameters.AddWithValue("@lpanume", oTitulo.nroParcela);
                    Sqlcon.Parameters.AddWithValue("@nossonumero", oTitulo.nossoNUmero);
                    Sqlcon.Parameters.AddWithValue("@nrocontatitulo", oTitulo.nroContaTitulo);

                    Sqlcon.ExecuteNonQuery();

                    FbCommand Sqlcon2 = new FbCommand(@strSQL2, Conexao, transacao);
                    Sqlcon2.Parameters.AddWithValue("@codempresa", oTitulo.codEmpresa);
                    Sqlcon2.Parameters.AddWithValue("@efpclie", oTitulo.idCliente);
                    Sqlcon2.Parameters.AddWithValue("@efpnume", oTitulo.idContrato);
                    Sqlcon2.Parameters.AddWithValue("@efpparc", oTitulo.nroParcela);
                    Sqlcon2.Parameters.AddWithValue("@efpdocu", oTitulo.nossoNUmero);
                    Sqlcon2.Parameters.AddWithValue("@nrocontatitulo", oTitulo.nroContaTitulo);
                    Sqlcon2.Parameters.AddWithValue("@arquivoremessa", "");

                    Sqlcon2.ExecuteNonQuery();

                }

                String strSQL3 = "update ctabanco set jlmnossonro=@nossonumero where codempresa=@codempresa and bancodi=@bancodi";
                FbCommand Sqlcon3 = new FbCommand(@strSQL3, Conexao, transacao);
                Sqlcon3.Parameters.AddWithValue("@codempresa", oEmpresa.codEmpresa);
                Sqlcon3.Parameters.AddWithValue("@bancodi", idConta);
                Sqlcon3.Parameters.AddWithValue("@nossonumero", nossoNumero);

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

        public List<TituloCobranca> pesquisaTitulos(Empresa pCodEmpresa, int nroContrato, int nroContratoFinal, Boolean chkTodas, int idCliente, DateTime dataInicio, DateTime dataFinal, string tipoEmissao, int nroContaTitulo)
        {
            List<TituloCobranca> lstTitulos = new List<TituloCobranca>();
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select distinct p.*, l.lpainic, l.lpafina, l.lpavalo, l.lpaabon, l.lpaiptu, " +
                                      " l.lpacond,l.lpalcde,l.lpaoutr,l.lpaoutd,l.lpatota,c.entcodi, c.entraza, c.entcnpj, " +
                                      " c.entnrua, c.entnume, c.entbair, c.entcida, c.entesta, c.entncep, i.imocodi, i.imonrua, " +
                                      " i.imonume, i.imobair, lo.locmult, lo.loctjur " +
                                      " from parreceber p, imb_locparcelas l, view_cliente c, imb_locacao lo, imb_imovel i " +
                                " where p.codempresa = @codempresa " +
                                "   and p.efpsitu = 'A' " +
                                "   and l.codempresa = p.codempresa and l.lpaloca = p.efpnume and l.lpanume=p.efpparc " +
                                "   and c.codempresa = p.empmaster and c.entcodi = p.efpclie " + 
                                "   and lo.codempresa = p.codempresa and lo.loccont=p.efpnume " +
                                "   and i.codempresa = lo.codempresa and i.imocodi = lo.locimov";

                if (tipoEmissao == "G")
                {
                    strSQL = strSQL + " and (p.arquivoremessa = '' or p.arquivoremessa=null)";
                }
                if (tipoEmissao == "E")
                {
                    strSQL = strSQL + " and (p.efpdocu = '' or p.efpdocu=null)";
                }
                else
                    strSQL = strSQL + " and p.efpdocu <> ''";

                if (nroContaTitulo>0)
                    strSQL = strSQL + " and p.nrocontatitulo=@nrocontatitulo";

                if (nroContrato > 0)
                {
                    strSQL = strSQL + " and p.efpnume >= @efpnume and p.efpnume <= @ctrfinal ";
                }
                if (!chkTodas)
                {
                    strSQL = strSQL + " and p.efpvenc >= @datainicio and p.efpvenc <= @datafinal ";
                }

                if (idCliente > 0)
                {
                    strSQL = strSQL + " and p.empmaster = @empmaster and p.efpclie = @efpclie ";
                }

                strSQL = strSQL + "   order by p.efpnume, p.efpparc";



                Conexao = new FbConnection(@strConn.StrConnection("FIREBIRD"));

                FbCommand Sqlcon = new FbCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", pCodEmpresa.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@empmaster", pCodEmpresa.empMaster);
                Sqlcon.Parameters.AddWithValue("@efpclie", idCliente);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@efpnume", nroContrato);
                Sqlcon.Parameters.AddWithValue("@ctrfinal", nroContratoFinal);
                Sqlcon.Parameters.AddWithValue("@nrocontatitulo", nroContaTitulo);
                Conexao.Open();

                FbDataReader drCon;

                drCon = Sqlcon.ExecuteReader(CommandBehavior.CloseConnection);

                
                TituloCobranca oTitulo;

                while (drCon.Read())
                {
                    oTitulo = new TituloCobranca();
                    oTitulo.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    oTitulo.empMaster = Convert.ToInt32(drCon["empmaster"].ToString());
                    oTitulo.idCliente = Convert.ToInt32(drCon["efpclie"].ToString());
                    oTitulo.idContrato = Convert.ToInt32(drCon["efpnume"].ToString());
                    oTitulo.nroParcela = Convert.ToInt32(drCon["efpparc"].ToString());
                    oTitulo.dtaVencimento = Convert.ToDateTime(drCon["efpvenc"].ToString());
                    oTitulo.vlrBoleto = Convert.ToDecimal(drCon["efpvalo"].ToString());
                    oTitulo.vlrAluguel = Convert.ToDecimal(drCon["lpavalo"].ToString());
                    oTitulo.vlrAbono = Convert.ToDecimal(drCon["lpaabon"].ToString());
                    oTitulo.vlrIptu = Convert.ToDecimal(drCon["lpaiptu"].ToString());
                    oTitulo.vlrCondominio = Convert.ToDecimal(drCon["lpacond"].ToString());
                    oTitulo.vlrDescontoConcedido = Convert.ToDecimal(drCon["lpalcde"].ToString());
                    oTitulo.vlrOutros = EmcResources.cCur(drCon["lpaoutr"].ToString());
                    oTitulo.vlrOutrosDimob = EmcResources.cCur(drCon["lpaoutd"].ToString());
                    oTitulo.vlrTotalReceber = Convert.ToDecimal(drCon["lpatota"].ToString());
                    oTitulo.dtaInicioPeriodo = Convert.ToDateTime(drCon["lpainic"].ToString());
                    oTitulo.dtaFinalPeriodo = Convert.ToDateTime(drCon["lpafina"].ToString());
                    oTitulo.nossoNUmero = drCon["efpdocu"].ToString();
                    oTitulo.nroContaTitulo = EmcResources.cInt(drCon["nrocontatitulo"].ToString());
                    oTitulo.sacadoRazaoSocial = drCon["entraza"].ToString();
                    oTitulo.sacadoCNPJ = drCon["entcnpj"].ToString();
                    oTitulo.sacadoEndereco = drCon["entnrua"].ToString();
                    oTitulo.sacadoNumero = drCon["entnume"].ToString();
                    oTitulo.sacadoBairro = drCon["entbair"].ToString();
                    oTitulo.sacadoCidade = drCon["entcida"].ToString();
                    oTitulo.sacadoEstado = drCon["entesta"].ToString();
                    oTitulo.sacadoCEP = drCon["entncep"].ToString();
                    oTitulo.idImovel = EmcResources.cInt(drCon["imocodi"].ToString());
                    oTitulo.imovelEndereco = drCon["imonrua"].ToString();
                    oTitulo.imovelNumero = drCon["imonume"].ToString();
                    oTitulo.imovelBairro = drCon["imobair"].ToString();
                    oTitulo.taxaJuros = EmcResources.cCur(drCon["loctjur"].ToString());
                    oTitulo.taxaMulta = EmcResources.cCur(drCon["locmult"].ToString());
                    oTitulo.boletoJurosDia = ((oTitulo.vlrBoleto*oTitulo.taxaJuros)/100)/30;
                    oTitulo.boletoMulta = ((oTitulo.vlrBoleto * oTitulo.taxaMulta) / 100);

                    lstTitulos.Add(oTitulo);
                }
            }
            catch (FbException erro)
            {
                throw erro;
            }
            finally
            {
                Conexao.Close();
                Conexao.Dispose();
                Conexao = null;
            }
            return lstTitulos;
        }

    }
}
