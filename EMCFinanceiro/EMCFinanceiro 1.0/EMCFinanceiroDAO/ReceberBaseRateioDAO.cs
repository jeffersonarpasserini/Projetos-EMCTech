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
    public class ReceberBaseRateioDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberBaseRateioDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
            
        public Boolean Salvar(List<ReceberBaseRateio> lstRcBaseRateio)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            Boolean verificaAlteracao = false;
            //Grava um novo registro ReceberDocumento
            try
            {
                
                verificaAlteracao =  Salvar(Conexao, transacao, lstRcBaseRateio);

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
        public Boolean Salvar(MySqlConnection Conecta, MySqlTransaction transacao, List<ReceberBaseRateio> lstRcBaseRateio)
        {

            //Grava um novo registro de ReceberDocumento
            try
            {

                Boolean verificaAlteracao = false;

                foreach(ReceberBaseRateio oRcRateio in lstRcBaseRateio)
                {

                    if (oRcRateio.status == "I")
                    {
                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(oRcRateio.codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                         "where a.table_name = 'receberbaserateio'"+
                                         "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        int idReceber = 0;
                        while (drCon.Read())
                        {
                            idReceber = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                            oRcRateio.idReceberBaseRateio = idReceber;
                        }

                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oRcRateio, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into ReceberBaseRateio (idreceberdocumento, idaplicacao, idcontacusto, percentualrateio, valorrateio ) " +
                                                                    "values (@idreceberdocumento, @idaplicacao, @idcontacusto, @percentualrateio, @valorrateio) ";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                        Sqlcon.Parameters.AddWithValue("@idreceberdocumento", oRcRateio.idReceberDocumento);
                        Sqlcon.Parameters.AddWithValue("@idaplicacao", oRcRateio.aplicacao.idAplicacao );
                        Sqlcon.Parameters.AddWithValue("@idcontacusto", oRcRateio.contaCusto.idContaCusto);
                        Sqlcon.Parameters.AddWithValue("@percentualrateio", oRcRateio.percentualRateio);
                        Sqlcon.Parameters.AddWithValue("@valorrateio", oRcRateio.valorRateio);

                        //abre conexao e executa o comando

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oRcRateio.status == "A")
                    {
                        geraOcorrencia(oRcRateio, "A");

                        //Monta comando para a gravação do registro
                        String strSQL = "update ReceberBaseRateio set idaplicacao=@idaplicacao, idcontacusto=@idcontacusto, percentualrateio=@percentualrateio, " +
                                                                 " valorrateio=@valorrateio " +
                                                                 " where idreceberbaserateio = @idreceberbaserateio";

                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idreceberbaserateio", oRcRateio.idReceberBaseRateio);
                        Sqlcon.Parameters.AddWithValue("@idaplicacao", oRcRateio.aplicacao.idAplicacao);
                        Sqlcon.Parameters.AddWithValue("@idcontacusto", oRcRateio.contaCusto.idContaCusto);
                        Sqlcon.Parameters.AddWithValue("@percentualrateio", oRcRateio.percentualRateio);
                        Sqlcon.Parameters.AddWithValue("@valorrateio", oRcRateio.valorRateio);

                        Sqlcon.ExecuteNonQuery();

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oRcRateio.status == "E")
                    {
                        geraOcorrencia(oRcRateio, "E");
                        //Monta comando para a gravação do registro
                        String strSQL = "delete from ReceberBaseRateio where idreceberbaserateio = @idreceberbaserateio";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idreceberbaserateio", oRcRateio.idReceberBaseRateio);

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


        public void Atualizar(List<ReceberBaseRateio> lstRcBaseRateio)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de ReceberDocumento
            try
            {
                
                Atualizar(Conexao, transacao, lstRcBaseRateio);

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
        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, List<ReceberBaseRateio> lstRcBaseRateio)
        {
            //atualiza um registro de ReceberDocumento
            try
            {
                
                foreach(ReceberBaseRateio oRcRateio in lstRcBaseRateio)
                {                
                    if (oRcRateio.status == "A")
                    {
                        geraOcorrencia(oRcRateio, "A");

                        //Monta comando para a gravação do registro
                        String strSQL = "update ReceberBaseRateio set idaplicacao=@idaplicacao, idcontacusto=@idcontacusto, percentualrateio=@percentualrateio, " + 
                                                                 " valorrateio=@valorrateio " + 
                                                                 " where idreceberbaserateio = @idreceberbaserateio";
                
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idreceberbaserateio", oRcRateio.idReceberBaseRateio);
                        Sqlcon.Parameters.AddWithValue("@idaplicacao", oRcRateio.aplicacao.idAplicacao );
                        Sqlcon.Parameters.AddWithValue("@idcontacusto", oRcRateio.contaCusto.idContaCusto);
                        Sqlcon.Parameters.AddWithValue("@percentualrateio", oRcRateio.percentualRateio);
                        Sqlcon.Parameters.AddWithValue("@valorrateio", oRcRateio.valorRateio);

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

        public void Excluir(List<ReceberBaseRateio> lstRcBaseRateio)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de ReceberDocumento
            try
            {
                
                Excluir(Conexao, transacao, lstRcBaseRateio);

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
        public void Excluir(MySqlConnection Conecta, MySqlTransaction transacao, List<ReceberBaseRateio> lstRcBaseRateio)
        {
            
            try
            {
                foreach (ReceberBaseRateio oRcRateio in lstRcBaseRateio)
                {
                    geraOcorrencia(oRcRateio, "E");
                    //Monta comando para a gravação do registro
                    String strSQL = "delete from ReceberBaseRateio where idreceberbaserateio = @idreceberbaserateio";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                    Sqlcon.Parameters.AddWithValue("@idreceberbaserateio", oRcRateio.idReceberBaseRateio);

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
 
        public DataTable ListaReceberBaseRateio(int idReceberDocumento)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaseRateio r, aplicacao a, contacusto c where idreceberdocumento = @idreceberdocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idReceberDocumento);

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

        public List<ReceberBaseRateio> listaRateioDocumento(int idReceberDocumento)
        {
            try
            {
                List<ReceberBaseRateio> lstRateio = new List<ReceberBaseRateio>();
                List<ReceberBaseRateio> lstRetorno = new List<ReceberBaseRateio>();

                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberBaseRateio r where idreceberdocumento = @idreceberdocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idReceberDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                
                Boolean Consulta = false;

                while (drCon.Read())
                {
                    Consulta = true;
                    ReceberBaseRateio oRateio = new ReceberBaseRateio();
                    oRateio.idReceberBaseRateio = EmcResources.cInt(drCon["idreceberbaserateio"].ToString());
                    oRateio.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
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
                    foreach (ReceberBaseRateio oRat in lstRateio)
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

        public ReceberBaseRateio ObterPor(ReceberBaseRateio oPgRateio)
        {
            bool Consulta = false;

            try
            {
                string strSQL = "";
                MySqlCommand Sqlcon = null;
                //Monta comando para a gravação do registro
                
                
                strSQL = "select * from ReceberBaseRateio Where idreceberbaserateio = @idreceberbaserateio ";
                Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberbaserateio", oPgRateio.idReceberBaseRateio);
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                ReceberBaseRateio oRateio = new ReceberBaseRateio();

                while (drCon.Read())
                {
                    Consulta = true;        
                    oRateio.idReceberBaseRateio = EmcResources.cInt(drCon["idreceberbaserateio"].ToString());
                    oRateio.idReceberDocumento  = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
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

        private void geraOcorrencia(ReceberBaseRateio oPgRateio, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoreceber pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oPgRateio.idReceberDocumento.ToString();

                if (flag == "A")
                {

                    ReceberBaseRateio oRat = new ReceberBaseRateio();
                    oRat = ObterPor(oPgRateio);

                    if (!oRat.Equals(oPgRateio))
                    {
                        descricao = " Receber Documento id : " + oPgRateio.idReceberDocumento + "Base Rateio ID: " + oPgRateio.idReceberDocumento + " Aplicacao id :" + oPgRateio.aplicacao.idAplicacao  + 
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
                    descricao = "Documento Receber id : " + oPgRateio.idReceberDocumento.ToString() +
                                " - Id Rateio - " + oPgRateio.idReceberBaseRateio.ToString() +
                                " - Aplicacao - " + oPgRateio.aplicacao.idAplicacao.ToString() + " - " + oPgRateio.aplicacao.descricao +
                                " - Conta Custo  - " + oPgRateio.contaCusto.idContaCusto.ToString() + " - " + oPgRateio.contaCusto.codigoConta + "-" + oPgRateio.contaCusto.descricao +
                                " - Percentual - " + oPgRateio.percentualRateio.ToString() + " - Valor : " + oPgRateio.valorRateio + 
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Documento Receber id : " + oPgRateio.idReceberDocumento.ToString() +
                                " - Id Rateio - " + oPgRateio.idReceberBaseRateio.ToString() +
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
