using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCCadastroModel;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCFinanceiroDAO
{
    public class ChequeRecebidoDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ChequeRecebidoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public int Salva(ChequeRecebido oCheque, MySqlConnection Conecta, MySqlTransaction Transacao)
        {

            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'chequerecebido'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    oCheque.idChequeRecebido = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oCheque, "I");  


                //Monta comando para a gravação do registro
                String strSQL = "insert into chequerecebido (idempresa, datacheque, datapredatado, " +
                                                      " valorcheque, nominal, nrocheque, idbanco, idreceberbaixa, nroagencia, " + 
                                                      " nroconta, idreceberparcela, idmovimentobancario, predatado ) " +
                                               " values (@idempresa, @datacheque, @datapredatado, @valorcheque, @nominal, " +
                                                       " @nrocheque, @idbanco, @idreceberbaixa, @nroagencia, " + 
                                                       " @nroconta, @idreceberparcela, @idmovimentobancario, @predatado )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                
                Sqlcon.Parameters.AddWithValue("@idempresa", oCheque.empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@datacheque", oCheque.dataCheque);
                Sqlcon.Parameters.AddWithValue("@datapredatado", oCheque.dataPreDatado);
                Sqlcon.Parameters.AddWithValue("@valorcheque", oCheque.valorCheque);
                Sqlcon.Parameters.AddWithValue("@nominal", oCheque.nominal);
                Sqlcon.Parameters.AddWithValue("@nrocheque", oCheque.nroCheque);
                Sqlcon.Parameters.AddWithValue("@idbanco", oCheque.banco.idBanco);
                Sqlcon.Parameters.AddWithValue("@idreceberbaixa", oCheque.receberBaixa.idReceberBaixa);
                Sqlcon.Parameters.AddWithValue("@nroagencia", oCheque.nroAgencia);
                Sqlcon.Parameters.AddWithValue("@nroconta", oCheque.nroConta);
                if (oCheque.idReceberParcela > 0)
                    Sqlcon.Parameters.AddWithValue("@idreceberparcela", oCheque.idReceberParcela);
                else
                    Sqlcon.Parameters.AddWithValue("@idreceberparcela", null);

                if (oCheque.idMovimentoBancario > 0)
                    Sqlcon.Parameters.AddWithValue("@idmovimentobancario", oCheque.idMovimentoBancario);
                else
                    Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                Sqlcon.Parameters.AddWithValue("@predatado", oCheque.predatado);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

                return oCheque.idChequeRecebido;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void baixaCheque(string Tipo, ChequeRecebido oCheque, MySqlConnection Conecta, MySqlTransaction Transacao)
        {

            try
            {
                if (Tipo == "PRE")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update chequerecebido set compensado=@compensado, idmovimentobancario=@movbanco " + 
                                    " where idchequerecebido=@idchequerecebido ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);

                    Sqlcon.Parameters.AddWithValue("@compensado", oCheque.compensacao);
                    Sqlcon.Parameters.AddWithValue("@movbanco", oCheque.idMovimentoBancario);
                    Sqlcon.Parameters.AddWithValue("@idchequerecebido", oCheque.idChequeRecebido);

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update chequerecebido set compensado=@compensado where idmovimentobancario=@movbanco ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);

                    Sqlcon.Parameters.AddWithValue("@compensado", oCheque.compensacao);
                    Sqlcon.Parameters.AddWithValue("@movbanco", oCheque.idMovimentoBancario);

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(ChequeRecebido oCheque, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCheque.idChequeRecebido.ToString();

                if (flag == "A")
                {

                    //Aplicacao oApl = new Aplicacao();
                    //oApl = ObterPor(oAplicacao);

                    //if (!oApl.Equals(oAplicacao))
                    //{
                    //    descricao = "Aplicacao " + oAplicacao.idAplicacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                    //    if (!oApl.descricao.Equals(oAplicacao.descricao))
                    //    {
                    //        descricao += " Descricao de " + oApl.descricao + " para " + oAplicacao.descricao;
                    //    }
                    //}
                }
                else if (flag == "I")
                {
                    descricao = "Cheque Recebido incluído : " + oCheque.idChequeRecebido + " - CH : " + oCheque.nroCheque + " - Data : " + oCheque.dataCheque + " -  Pre : " + 
                                                                oCheque.dataPreDatado + " - Nominal : " +  oCheque.nominal + " - Valor : " + 
                                                                oCheque.valorCheque.ToString() + " - Banco :" + oCheque.banco.idBanco + " - Agencia : " + oCheque.nroAgencia +
                                                                " - Conta : " + oCheque.nroConta + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    //descricao = "Aplicacao " + oAplicacao.idAplicacao + " - " + oAplicacao.descricao + " foi exluido por " + oOcorrencia.usuario.nome;
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

        public List<ChequeRecebido> listCheque(ReceberBaixa idReceberBaixa)
        {
            try
            {
                List<ChequeRecebido> lstChRecebido = new List<ChequeRecebido>();
                Boolean bConsulta = false;


                //Monta comando para a gravação do registro
                String strSQL = "select * from chequerecebido Where idReceberBaixa = @idReceberBaixa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberBaixa", idReceberBaixa.idReceberBaixa);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    bConsulta = true;
                    ChequeRecebido oChRecebido = new ChequeRecebido();

                    Banco oBanco = new Banco();
                    oBanco.idBanco = EmcResources.cInt(drCon["idbanco"].ToString());
                    oChRecebido.banco = oBanco;

                    oChRecebido.compensacao = drCon["compensado"].ToString();

                    oChRecebido.dataCheque = Convert.ToDateTime(drCon["datacheque"].ToString());

                    oChRecebido.dataPreDatado = Convert.ToDateTime(drCon["datapredatado"].ToString());

                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                    oChRecebido.empresa = oEmpresa;

                    oChRecebido.idChequeRecebido = EmcResources.cInt(drCon["idchequerecebido"].ToString());

                    oChRecebido.idMovimentoBancario = EmcResources.cInt(drCon["idmovimentobancario"].ToString());

                    oChRecebido.idReceberParcela = EmcResources.cInt(drCon["idreceberparcela"].ToString());

                    oChRecebido.nominal = drCon["nominal"].ToString();

                    oChRecebido.nroAgencia = drCon["nroagencia"].ToString();

                    oChRecebido.nroCheque = drCon["nrocheque"].ToString();

                    oChRecebido.nroConta = drCon["nroconta"].ToString();

                    ReceberBaixa oBaixa = new ReceberBaixa();
                    oBaixa.idReceberBaixa = EmcResources.cInt(drCon["idreceberbaixa"].ToString());
                    oChRecebido.receberBaixa = oBaixa;

                    oChRecebido.valorCheque = EmcResources.cCur(drCon["valorcheque"].ToString());

                    oChRecebido.predatado = drCon["predatado"].ToString();

                    lstChRecebido.Add(oChRecebido);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return lstChRecebido;
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }
            
        }

        public List<ChequeRecebido> listCheque(int idDivida)
        {
            try
            {
                List<ChequeRecebido> lstChRecebido = new List<ChequeRecebido>();
                Boolean bConsulta = false;


                //Monta comando para a gravação do registro
                String strSQL = "select * from chequerecebido Where idReceberparcela = @idReceberBaixa ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberBaixa", idDivida);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    bConsulta = true;
                    ChequeRecebido oChRecebido = new ChequeRecebido();

                    Banco oBanco = new Banco();
                    oBanco.idBanco = EmcResources.cInt(drCon["idbanco"].ToString());
                    oChRecebido.banco = oBanco;

                    oChRecebido.compensacao = drCon["compensado"].ToString();

                    oChRecebido.dataCheque = Convert.ToDateTime(drCon["datacheque"].ToString());

                    oChRecebido.dataPreDatado = Convert.ToDateTime(drCon["datapredatado"].ToString());

                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                    oChRecebido.empresa = oEmpresa;

                    oChRecebido.idChequeRecebido = EmcResources.cInt(drCon["idchequerecebido"].ToString());

                    oChRecebido.idMovimentoBancario = EmcResources.cInt(drCon["idmovimentobancario"].ToString());

                    oChRecebido.idReceberParcela = EmcResources.cInt(drCon["idreceberparcela"].ToString());

                    oChRecebido.nominal = drCon["nominal"].ToString();

                    oChRecebido.nroAgencia = drCon["nroagencia"].ToString();

                    oChRecebido.nroCheque = drCon["nrocheque"].ToString();

                    oChRecebido.nroConta = drCon["nroconta"].ToString();

                    ReceberBaixa oBaixa = new ReceberBaixa();
                    oBaixa.idReceberBaixa = EmcResources.cInt(drCon["idreceberbaixa"].ToString());
                    oChRecebido.receberBaixa = oBaixa;

                    oChRecebido.valorCheque = EmcResources.cCur(drCon["valorcheque"].ToString());

                    oChRecebido.predatado = drCon["predatado"].ToString();

                    lstChRecebido.Add(oChRecebido);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return lstChRecebido;
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }

        }


    }
}
