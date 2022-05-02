using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCFinanceiroDAO
{
    public class PagarBaseRateioDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarBaseRateioDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
            
        public Boolean Salvar(List<PagarBaseRateio> lstPgBaseRateio)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            Boolean verificaAlteracao = false;
            //Grava um novo registro de PagarDocumento
            try
            {
                
                verificaAlteracao =  Salvar(Conexao, transacao, lstPgBaseRateio);

                transacao.Commit();

                return verificaAlteracao;

            }
            catch (MySqlException erro)
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
        public Boolean Salvar(MySqlConnection Conecta, MySqlTransaction transacao, List<PagarBaseRateio> lstPgBaseRateio)
        {

            //Grava um novo registro de PagarDocumento
            try
            {

                Boolean verificaAlteracao = false;

                foreach(PagarBaseRateio oPgRateio in lstPgBaseRateio)
                {

                    if (oPgRateio.status == "I")
                    {
                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(oPgRateio.codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                         "where a.table_name = 'pagarbaserateio'"+
                                         "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        int idPagar = 0;
                        while (drCon.Read())
                        {
                            idPagar = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                            oPgRateio.idPagarBaseRateio = idPagar;
                        }

                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oPgRateio, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into PagarBaseRateio (idpagardocumento, idaplicacao, idcontacusto, percentualrateio, valorrateio ) " +
                                                                    "values (@idpagardocumento, @idaplicacao, @idcontacusto, @percentualrateio, @valorrateio) ";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                        Sqlcon.Parameters.AddWithValue("@idpagardocumento", oPgRateio.idPagarDocumento);
                        Sqlcon.Parameters.AddWithValue("@idaplicacao", oPgRateio.aplicacao.idAplicacao );
                        Sqlcon.Parameters.AddWithValue("@idcontacusto", oPgRateio.contaCusto.idContaCusto);
                        Sqlcon.Parameters.AddWithValue("@percentualrateio", oPgRateio.percentualRateio);
                        Sqlcon.Parameters.AddWithValue("@valorrateio", oPgRateio.valorRateio);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oPgRateio.status == "A")
                    {
                        geraOcorrencia(oPgRateio, "A");

                        //Monta comando para a gravação do registro
                        String strSQL = "update PagarBaseRateio set idaplicacao=@idaplicacao, idcontacusto=@idcontacusto, percentualrateio=@percentualrateio, " +
                                                                 " valorrateio=@valorrateio " +
                                                                 " where idpagarbaserateio = @idpagarbaserateio";

                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idpagarbaserateio", oPgRateio.idPagarBaseRateio);
                        Sqlcon.Parameters.AddWithValue("@idaplicacao", oPgRateio.aplicacao.idAplicacao);
                        Sqlcon.Parameters.AddWithValue("@idcontacusto", oPgRateio.contaCusto.idContaCusto);
                        Sqlcon.Parameters.AddWithValue("@percentualrateio", oPgRateio.percentualRateio);
                        Sqlcon.Parameters.AddWithValue("@valorrateio", oPgRateio.valorRateio);

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oPgRateio.status == "E")
                    {
                        geraOcorrencia(oPgRateio, "E");
                        //Monta comando para a gravação do registro
                        String strSQL = "delete from PagarBaseRateio where idpagarbaserateio = @idpagarbaserateio";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idpagarbaserateio", oPgRateio.idPagarBaseRateio);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }

                }

                return verificaAlteracao;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }


        public void Atualizar(List<PagarBaseRateio> lstPgBaseRateio)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                
                Atualizar(Conexao, transacao, lstPgBaseRateio);

                transacao.Commit();


            }
            catch (MySqlException erro)
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
        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, List<PagarBaseRateio> lstPgBaseRateio)
        {
            //atualiza um registro de PagarDocumento
            try
            {
                
                foreach(PagarBaseRateio oPgRateio in lstPgBaseRateio)
                {                
                    if (oPgRateio.status == "A")
                    {
                        geraOcorrencia(oPgRateio, "A");

                        //Monta comando para a gravação do registro
                        String strSQL = "update PagarBaseRateio set idaplicacao=@idaplicacao, idcontacusto=@idcontacusto, percentualrateio=@percentualrateio, " + 
                                                                 " valorrateio=@valorrateio " + 
                                                                 " where idpagarbaserateio = @idpagarbaserateio";
                
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idpagarbaserateio", oPgRateio.idPagarBaseRateio);
                        Sqlcon.Parameters.AddWithValue("@idaplicacao", oPgRateio.aplicacao.idAplicacao );
                        Sqlcon.Parameters.AddWithValue("@idcontacusto", oPgRateio.contaCusto.idContaCusto);
                        Sqlcon.Parameters.AddWithValue("@percentualrateio", oPgRateio.percentualRateio);
                        Sqlcon.Parameters.AddWithValue("@valorrateio", oPgRateio.valorRateio);

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);
                    }
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Excluir(List<PagarBaseRateio> lstPgBaseRateio)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                
                Excluir(Conexao, transacao, lstPgBaseRateio);

                transacao.Commit();


            }
            catch (MySqlException erro)
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
        public void Excluir(MySqlConnection Conecta, MySqlTransaction transacao, List<PagarBaseRateio> lstPgBaseRateio)
        {
            
            try
            {
                foreach (PagarBaseRateio oPgRateio in lstPgBaseRateio)
                {
                    geraOcorrencia(oPgRateio, "E");
                    //Monta comando para a gravação do registro
                    String strSQL = "delete from PagarBaseRateio where idpagarbaserateio = @idpagarbaserateio";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                    Sqlcon.Parameters.AddWithValue("@idpagarbaserateio", oPgRateio.idPagarBaseRateio);

                    //abre conexao e executa o comando
               
                    Sqlcon.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
          
        }
 
        public DataTable ListaPagarBaseRateio(int idPagarDocumento)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaseRateio r, aplicacao a, contacusto c where idpagardocumento = @idpagardocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);

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

        public List<PagarBaseRateio> listaRateioDocumento(int idPagarDocumento)
        {
            try
            {
                List<PagarBaseRateio> lstRateio = new List<PagarBaseRateio>();
                List<PagarBaseRateio> lstRetorno = new List<PagarBaseRateio>();

                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarBaseRateio r where idpagardocumento = @idpagardocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idPagarDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                
                Boolean Consulta = false;

                while (drCon.Read())
                {
                    Consulta = true;
                    PagarBaseRateio oRateio = new PagarBaseRateio();
                    oRateio.idPagarBaseRateio = EmcResources.cInt(drCon["idpagarbaserateio"].ToString());
                    oRateio.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    oRateio.percentualRateio = EmcResources.cDouble(drCon["percentualrateio"].ToString());
                    oRateio.valorRateio = EmcResources.cCur(drCon["valorrateio"].ToString());

                    Aplicacao oApl = new Aplicacao();
                    oApl.idAplicacao = EmcResources.cInt(drCon["idaplicacao"].ToString());

                    oRateio.aplicacao = oApl;


                    ContaCusto oCusto = new ContaCusto();
                    oCusto.idContaCusto = EmcResources.cInt(drCon["idcontacusto"].ToString());

                    oRateio.contaCusto = oCusto;
                    oRateio.status = "";

                    lstRateio.Add(oRateio);
                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    foreach (PagarBaseRateio oRat in lstRateio)
                    {

                        AplicacaoDAO oAplicacaoDAO = new AplicacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        oRat.aplicacao = oAplicacaoDAO.ObterPor(oRat.aplicacao);


                        ContaCustoDAO oContaCustoDAO = new ContaCustoDAO(parConexao, oOcorrencia, oRat.codEmpresa);
                        oRat.contaCusto = oContaCustoDAO.ObterPor(oRat.contaCusto);

                        lstRetorno.Add(oRat);
                    }

                }
                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public PagarBaseRateio ObterPor(PagarBaseRateio oPgRateio)
        {
            bool Consulta = false;

            try
            {
                string strSQL = "";
                MySqlCommand Sqlcon = null;
                //Monta comando para a gravação do registro
                
                
                strSQL = "select * from PagarBaseRateio Where idpagarbaserateio = @idpagarbaserateio ";
                Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idpagarbaserateio", oPgRateio.idPagarBaseRateio);
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                PagarBaseRateio oRateio = new PagarBaseRateio();

                while (drCon.Read())
                {
                    Consulta = true;        
                    oRateio.idPagarBaseRateio = EmcResources.cInt(drCon["idpagarbaserateio"].ToString());
                    oRateio.idPagarDocumento  = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    oRateio.percentualRateio = EmcResources.cDouble(drCon["percentualrateio"].ToString());
                    oRateio.valorRateio = EmcResources.cCur(drCon["valorrateio"].ToString());

                    Aplicacao oApl = new Aplicacao();
                    oApl.idAplicacao = EmcResources.cInt(drCon["idaplicacao"].ToString());

                    oRateio.aplicacao = oApl;


                    ContaCusto oCusto = new ContaCusto();
                    oCusto.idContaCusto = EmcResources.cInt(drCon["idcontacusto"].ToString());

                    oRateio.contaCusto = oCusto;

                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {

                    AplicacaoDAO oAplicacaoDAO = new AplicacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.aplicacao = oAplicacaoDAO.ObterPor(oRateio.aplicacao);


                    ContaCustoDAO oContaCustoDAO = new ContaCustoDAO(parConexao, oOcorrencia, oRateio.codEmpresa);
                    oRateio.contaCusto = oContaCustoDAO.ObterPor(oRateio.contaCusto);

                }
                return oRateio;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(PagarBaseRateio oPgRateio, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oPgRateio.idPagarDocumento.ToString();

                if (flag == "A")
                {

                    PagarBaseRateio oRat = new PagarBaseRateio();
                    oRat = ObterPor(oPgRateio);

                    if (!oRat.Equals(oPgRateio))
                    {
                        descricao = " Pagar Documenti id : " + oPgRateio.idPagarDocumento + "Base Rateio ID: " + oPgRateio.idPagarDocumento + " Aplicacao id :" + oPgRateio.aplicacao.idAplicacao  + 
                                    " - " + oPgRateio.aplicacao.descricao + " Conta Custo id : " +  oPgRateio.contaCusto.idContaCusto + " - " + oPgRateio.contaCusto.codigoConta + 
                                    " - " + oPgRateio.contaCusto.descricao +" foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oRat.percentualRateio.Equals(oPgRateio.percentualRateio))
                        {
                            descricao += " Percentual de Rateio de  " + oRat.percentualRateio + " para " + oPgRateio.percentualRateio;
                        }
                        if (!oRat.valorRateio.Equals(oPgRateio.valorRateio))
                        {
                            descricao += " Valor Rateio de " + oRat.valorRateio + " para " + oPgRateio.valorRateio;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "Documento Pagar id : " + oPgRateio.idPagarDocumento.ToString() +
                                " - Id Rateio - " + oPgRateio.idPagarBaseRateio.ToString() +
                                " - Aplicacao - " + oPgRateio.aplicacao.idAplicacao.ToString() + " - " + oPgRateio.aplicacao.descricao +
                                " - Conta Custo  - " + oPgRateio.contaCusto.idContaCusto.ToString() + " - " + oPgRateio.contaCusto.codigoConta + "-" + oPgRateio.contaCusto.descricao +
                                " - Percentual - " + oPgRateio.percentualRateio.ToString() + " - Valor : " + oPgRateio.valorRateio + 
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Documento Pagar id : " + oPgRateio.idPagarDocumento.ToString() +
                                " - Id Rateio - " + oPgRateio.idPagarBaseRateio.ToString() +
                                " - Aplicacao - " + oPgRateio.aplicacao.idAplicacao.ToString() + " - " + oPgRateio.aplicacao.descricao +
                                " - Conta Custo  - " + oPgRateio.contaCusto.idContaCusto.ToString() + " - " + oPgRateio.contaCusto.codigoConta + "-" + oPgRateio.contaCusto.descricao +
                                " - Percentual - " + oPgRateio.percentualRateio.ToString() + " - Valor : " + oPgRateio.valorRateio + 
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                oOcorrencia.data_hora = DateTime.Now;
                descricao += " em " + oOcorrencia.data_hora.ToString();

                oOcorrencia.descricao = descricao;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }


    }

}
