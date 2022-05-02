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
    public class ChequeEmitirDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ChequeEmitirDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public DataTable ListaChequeEmitir(CtaBancaria oConta)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select ch.*, cb.descricao from chequeemitir ch, ctabancaria cb " +
                                " where cb.idctabancaria = ch.idctabancaria " +
                                "   and cb.idempresa = ch.ctabancaria_idempresa " +
                                "   and ch.idctabancaria=@idctabancaria " +
                                "   and ch.ctabancaria_idempresa=@codempresa "+
                                "   and ch.nrocheque = ''";

                strSQL += " order by ch.datacheque ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oConta.idCtaBancaria);
                


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

        public DataTable PesquisaChequeEmitir(DateTime dataInicial, DateTime dataFinal)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select  ch.*, valorextenso(ch.valorcheque) as extenso, ct.idBanco, ct.descricao as descricaoconta, b.descricao as descricaobanco," +
                                " ct.agencia, ct.conta" +
                                " from chequeemitir ch, pagarbaixa pb, ctabancaria ct, banco b" +
                                " where ch.idchequeemitir = pb.idchequeemitir" +
                                " and ch.idctabancaria = ct.idctabancaria" +
                                " and ct.idbanco = b.idbanco" +
                                " and ch.idEmpresa = @codempresa" +
                                " and ch.datacheque between @datainicial and @datafinal" +
                                " order by ch.datacheque";
                                              
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);

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

        public int Salva(ChequeEmitir oCheque, MySqlConnection Conecta, MySqlTransaction Transacao)
        {

            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'chequeemitir'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    oCheque.idChequeEmitir = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oCheque, "I");  


                //Monta comando para a gravação do registro
                String strSQL = "insert into chequeemitir (idmovimentobancario, idempresa, datacheque, " +
                                                      " valorcheque, nominal, nrocheque, idctabancaria, ctabancaria_idempresa, predatado, datapredatado, compensado, formulario_idformulario ) " +
                                               " values (@idmovimentobancario, @idempresa, @datacheque, @valorcheque, @nominal, " +
                                                       " @nrocheque, @idctabancaria, @ctabancaria_idempresa, @predatado, @datapredatado, @compensado, @formulario_idformulario )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                
                Sqlcon.Parameters.AddWithValue("@idempresa", oCheque.empresa.idEmpresa);
                if (oCheque.idMovimentoBancario>0)
                    Sqlcon.Parameters.AddWithValue("@idmovimentobancario", oCheque.idMovimentoBancario);
                else
                    Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                Sqlcon.Parameters.AddWithValue("@datacheque", oCheque.dataCheque);
                Sqlcon.Parameters.AddWithValue("@valorcheque", oCheque.valorCheque);
                Sqlcon.Parameters.AddWithValue("@nominal", oCheque.nominal);
                Sqlcon.Parameters.AddWithValue("@nrocheque", "");
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oCheque.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oCheque.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@predatado", oCheque.preDatado);
                Sqlcon.Parameters.AddWithValue("@datapredatado", oCheque.dataPreDatado);
                Sqlcon.Parameters.AddWithValue("@compensado", oCheque.compensacao);
                Sqlcon.Parameters.AddWithValue("@formulario_idformulario", null);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

                return oCheque.idChequeEmitir;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void salvaChequeCancelado(ChequeEmitir oCheque)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();

            try
            {
                /* Etapa 1 - grava o cheque que foi cancelado */
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'chequeemitir'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    oCheque.idChequeEmitir = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oCheque, "I");

                //grava cheque cancelado.

                //Monta comando para a gravação do registro
                String strSQL = "insert into chequeemitir (idmovimentobancario, idempresa, datacheque, " +
                                                      " valorcheque, nominal, nrocheque, idctabancaria, ctabancaria_idempresa, " + 
                                                      " predatado, datapredatado, compensado, formulario_idformulario, historico ) " +
                                               " values (@idmovimentobancario, @idempresa, @datacheque, @valorcheque, @nominal, " +
                                                       " @nrocheque, @idctabancaria, @ctabancaria_idempresa, "+
                                                       " @predatado, @datapredatado, @compensado, @formulario_idformulario, @historico )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);

                Sqlcon.Parameters.AddWithValue("@idempresa", oCheque.empresa.idEmpresa);
                if (oCheque.idMovimentoBancario > 0)
                    Sqlcon.Parameters.AddWithValue("@idmovimentobancario", oCheque.idMovimentoBancario);
                else
                    Sqlcon.Parameters.AddWithValue("@idmovimentobancario", null);
                Sqlcon.Parameters.AddWithValue("@datacheque", oCheque.dataCheque);
                Sqlcon.Parameters.AddWithValue("@valorcheque", oCheque.valorCheque);
                Sqlcon.Parameters.AddWithValue("@nominal", oCheque.nominal);
                Sqlcon.Parameters.AddWithValue("@nrocheque", "");
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oCheque.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oCheque.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@predatado", oCheque.preDatado);
                Sqlcon.Parameters.AddWithValue("@datapredatado", oCheque.dataPreDatado);
                Sqlcon.Parameters.AddWithValue("@compensado", oCheque.compensacao);
                Sqlcon.Parameters.AddWithValue("@formulario_idformulario", oCheque.formulario.idFormulario);
                Sqlcon.Parameters.AddWithValue("@historico", oCheque.historico);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

                /* Etapa 2 - Atualizando o número do cheque no controle de formulários */
                FormularioDAO oFormularioDAO = new FormularioDAO(parConexao, oOcorrencia, codEmpresa);
                oFormularioDAO.AtualizaControle(oCheque.formulario, Conexao, Transacao);

                /* Etapa 3 - Atualizando a Situação da Baixa de B para H se for Pre datado ou de B para P se for normal */


                /* Etapa 4 - Se for cheque pré datado atualiza o historico no DocumentoPagar c/ o nro do cheque 
                 * para o novo documento de cobrança referente ao cheque pre
                 */

                Transacao.Commit();

            }
            catch (MySqlException oErro)
            {
                Transacao.Rollback();
                throw oErro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }


        }

        public void emiteCheque(ChequeEmitir oCheque)
        {
            MySqlTransaction Transacao  = Conexao.BeginTransaction();

            try
            {
                
                /* Etapa 1 - Completando as informações de cheque a emitir */

                geraOcorrencia(oCheque, "EM");

                //Monta comando para a gravação do registro
                String strSQL = "update chequeemitir set nrocheque=@nrocheque, formulario_idformulario=@formulario_idformulario " +
                                               " where idchequeemitir=@idchequeemitir ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);

                Sqlcon.Parameters.AddWithValue("@idchequeemitir", oCheque.idChequeEmitir);
                Sqlcon.Parameters.AddWithValue("@nrocheque", oCheque.nroCheque);
                Sqlcon.Parameters.AddWithValue("@formulario_idformulario", oCheque.formulario.idFormulario);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

                /* Etapa 2 - Atualizando o número do cheque no controle de formulários */
                FormularioDAO oFormularioDAO = new FormularioDAO(parConexao, oOcorrencia, codEmpresa);
                oFormularioDAO.AtualizaControle(oCheque.formulario, Conexao, Transacao);

                /* Etapa 3 - Atualizando a Situação da Baixa de B para H se for Pre datado ou de B para P se for normal */
                foreach (PagarBaixa oBaixa in oCheque.pagarBaixa)
                {
                    if (oCheque.preDatado == "S")
                        oBaixa.situacaoBaixa = "H";
                    else
                        oBaixa.situacaoBaixa = "P";

                    oBaixa.documentoBaixa = oCheque.nroCheque;

                    PagarBaixaDAO oBxDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    oBxDAO.AlterarSituacaoBaixa(oBaixa, Conexao, Transacao);
                    oBxDAO.AlterarDocumentoBaixa(oBaixa, Conexao, Transacao);


                }
                                
                /* Etapa 4 - Se for cheque pré datado atualiza o historico no DocumentoPagar c/ o nro do cheque 
                 * para o novo documento de cobrança referente ao cheque pre
                 */
                if (oCheque.preDatado == "S")
                {
                    foreach (PagarBaixa oBaixa in oCheque.pagarBaixa)
                    {
                        PagarParcela oParcela = new PagarParcela();
                        PagarParcelaDAO oParcelaDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);

                        oParcela = oParcelaDAO.ObterPor(oBaixa.idDivida);

                        PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oPgDocDAO.alteraHistoricoChequePre(Conexao, Transacao, oParcela.pagarDocumento, oCheque.nroCheque);
                    }
                }

                Transacao.Commit();

            }
            catch (MySqlException oErro)
            {
                Transacao.Rollback();
                throw oErro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }
            
        }

        public void baixaCheque(string Tipo, ChequeEmitir oCheque, MySqlConnection Conecta, MySqlTransaction Transacao)
        {

            try
            {
                if (Tipo == "PRE")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update chequeemitir set compensado=@compensado, idmovimentobancario=@movbanco " + 
                                    " where idchequeemitir=@idchequeemitir ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);

                    Sqlcon.Parameters.AddWithValue("@compensado", oCheque.compensacao);
                    Sqlcon.Parameters.AddWithValue("@movbanco", oCheque.idMovimentoBancario);
                    Sqlcon.Parameters.AddWithValue("@idchequeemitir", oCheque.idChequeEmitir);

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update chequeemitir set compensado=@compensado where idmovimentobancario=@movbanco ";

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

        public ChequeEmitir ObterPor(ChequeEmitir oCheque)
        {
            MySqlDataReader drCon;

            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from chequeemitir Where idchequeemitir = @idChequeEmitir ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idChequeEmitir", oCheque.idChequeEmitir);

                drCon = Sqlcon.ExecuteReader();


                ChequeEmitir oChequeEmitir = new ChequeEmitir();

                while (drCon.Read())
                {
                    consulta = true;
                    oChequeEmitir.compensacao = drCon["compensado"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.idCtaBancaria = EmcResources.cInt(drCon["idctabancaria"].ToString());
                    oConta.codEmpresa = EmcResources.cInt(drCon["ctabancaria_idempresa"].ToString());
                    oChequeEmitir.contaBancaria = oConta;

                    oChequeEmitir.dataCheque = Convert.ToDateTime(drCon["datacheque"].ToString());

                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                    oChequeEmitir.empresa = oEmpresa;

                    oChequeEmitir.idChequeEmitir = EmcResources.cInt(drCon["idchequeemitir"].ToString());

                    oChequeEmitir.idMovimentoBancario = EmcResources.cInt(drCon["idmovimentobancario"].ToString());

                    oChequeEmitir.nominal = drCon["nominal"].ToString();

                    oChequeEmitir.nroCheque = drCon["nrocheque"].ToString();

                    oChequeEmitir.valorCheque = EmcResources.cCur(drCon["valorcheque"].ToString());

                    oChequeEmitir.preDatado = drCon["predatado"].ToString();

                    oChequeEmitir.dataPreDatado = Convert.ToDateTime(drCon["datapredatado"].ToString());

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    EmpresaDAO oEmpresaDAO = new EmpresaDAO(parConexao, oOcorrencia);
                    oChequeEmitir.empresa = oEmpresaDAO.ObterPor(oChequeEmitir.empresa);

                    CtaBancariaDAO oContaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                    oChequeEmitir.contaBancaria = oContaDAO.ObterPor(oChequeEmitir.contaBancaria);

                    PagarBaixaDAO oPgBaixaDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    oChequeEmitir.pagarBaixa = oPgBaixaDAO.listaBaixasporCheque(oCheque.idChequeEmitir);
                }

                return oChequeEmitir;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                
            }
        }

        private void geraOcorrencia(ChequeEmitir oCheque, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCheque.idChequeEmitir.ToString();

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
                    descricao = "Cheque a Emitir incluído : " + oCheque.idChequeEmitir + " - " + 
                                                                oCheque.nominal + " - " + 
                                                                oCheque.valorCheque.ToString() + " - Mov. Bancario :" +
                                                                oCheque.idMovimentoBancario.ToString() + " foi incluida por " + oOcorrencia.usuario.nome;
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

        public DataTable dstRelatorio(String sSQL)
        {

            try
            {
                string strSQL = sSQL.ToString();
                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
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

    }
}
