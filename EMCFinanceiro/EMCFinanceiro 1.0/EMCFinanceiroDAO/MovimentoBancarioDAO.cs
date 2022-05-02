using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCFinanceiroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCFinanceiroDAO
{
    public class MovimentoBancarioDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public MovimentoBancarioDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public void conciliaMovimento(List<MovimentoBancario> lstMovBanco)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            try
            {
                conciliaMovimento(lstMovBanco, Conexao, Transacao);
                Transacao.Commit();
            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }
        }
        public void conciliaMovimento(List<MovimentoBancario> lstMovBanco, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            //atualiza um registro de MovimentoBancario
            try
            {

                foreach (MovimentoBancario oMovBancario in lstMovBanco)
                {
                    geraOcorrencia(oMovBancario, "C");

                    //Monta comando para a gravação do registro
                    String strSQL = "update movimentobancario set dataconciliacao=@dataconciliacao, situacao=@situacao " +
                                                                " where idMovimentoBancario = @idMovimentoBancario";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                    Sqlcon.Parameters.AddWithValue("@idMovimentoBancario", oMovBancario.idMovimentoBancario);
                    Sqlcon.Parameters.AddWithValue("@dataconciliacao", oMovBancario.dataConciliacao);
                    Sqlcon.Parameters.AddWithValue("@situacao", oMovBancario.situacao);

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, Transacao);

                    //Com a conciliação do movimento bancario, o sistema controla a situação dos cheques emitido ou recebido e
                    //se o movimento for do tipo cheque pre datado tem que conciliar o cheque emitido pelo movimento gerador.
                    if (oMovBancario.tipoMovimento == "D")
                    {
                        //Busca todas baixas realizada por este movimento bancario - lista de baixas
                        List<PagarBaixa> lstBaixa = new List<PagarBaixa>();
                        PagarBaixaDAO oPgDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                        lstBaixa = oPgDAO.ObterPor(oMovBancario);

                        //percorre a lista de baixas e verifica se é cheque pre
                        foreach (PagarBaixa oBaixa in lstBaixa)
                        {
                            //Verifica se o Lancamento é do Tipo Cheque pre
                            if (EmcResources.cInt(oBaixa.pagarParcela.pagarDocumento.tipoDocumento.idTipoDocumento.ToString()) == 5)
                            {
                                //realiza uma busca em pagarparcela pelo campo iddivida para localizar o documento originador desta baixa
                                PagarBaixa oPgBx = new PagarBaixa();
                                PagarBaixaDAO oPgBxDAO = new PagarBaixaDAO(parConexao, oOcorrencia, codEmpresa);

                                int idDivida = 0;
                                idDivida = EmcResources.cInt(oBaixa.pagarParcela.idPagarParcela.ToString());
                                oPgBx = oPgBxDAO.ObterPor(idDivida);

                                //Pega o numero do Cheque a Emitir e realiza a sua compensação
                                ChequeEmitirDAO oChOriginalDAO = new ChequeEmitirDAO(parConexao, oOcorrencia,codEmpresa);
                                ChequeEmitir oChOriginal = new ChequeEmitir();
                                oChOriginal = oPgBx.cheque;
                                oChOriginal.idMovimentoBancario = oMovBancario.idMovimentoBancario;
                                oChOriginal.compensacao = "C";
                                oChOriginalDAO.baixaCheque("PRE", oChOriginal, Conexao, Transacao);
                            }
                        }

                        ChequeEmitirDAO oChEmitido = new ChequeEmitirDAO(parConexao, oOcorrencia,codEmpresa);
                        ChequeEmitir oCheque = new ChequeEmitir();
                        oCheque.idMovimentoBancario = oMovBancario.idMovimentoBancario;
                        oCheque.compensacao = "C";

                        oChEmitido.baixaCheque("N", oCheque, Conexao, Transacao);

                    }
                    else if (oMovBancario.tipoMovimento == "C")
                    {

                        //Busca todas baixas realizada por este movimento bancario - lista de baixas
                        List<ReceberBaixa> lstBaixa = new List<ReceberBaixa>();
                        ReceberBaixaDAO oPgDAO = new ReceberBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                        lstBaixa = oPgDAO.ObterPor(oMovBancario);

                        //percorre a lista de baixas e verifica se é cheque pre
                        foreach (ReceberBaixa oBaixa in lstBaixa)
                        {
                            //Verifica se o Lancamento é do Tipo Cheque pre
                            if (EmcResources.cInt(oBaixa.receberParcela.receberDocumento.tipoDocumento.idTipoDocumento.ToString()) == 5)
                            {
                                //realiza uma busca em receberparcela pelo campo iddivida para localizar o documento originador desta baixa
                                ReceberBaixa oPgBx = new ReceberBaixa();
                                ReceberBaixaDAO oPgBxDAO = new ReceberBaixaDAO(parConexao, oOcorrencia, codEmpresa);

                                int idDivida = 0;
                                idDivida = EmcResources.cInt(oBaixa.receberParcela.idReceberParcela.ToString());
                                //oPgBx = oPgBxDAO.ObterPor(idDivida);
                                List<ChequeRecebido> lstChRecebido = new List<ChequeRecebido>();

                                ChequeRecebidoDAO oChOriginalDAO = new ChequeRecebidoDAO(parConexao, oOcorrencia,codEmpresa);
                                lstChRecebido = oChOriginalDAO.listCheque(idDivida);

                                foreach (ChequeRecebido oChOriginal in lstChRecebido)
                                {
                                    //Pega o numero do Cheque a Emitir e realiza a sua compensação
                                    oChOriginal.idMovimentoBancario = oMovBancario.idMovimentoBancario;
                                    oChOriginal.compensacao = "C";
                                    oChOriginalDAO.baixaCheque("PRE", oChOriginal, Conexao, Transacao);
                                }
                            }
                        }

                        ChequeRecebidoDAO oChRecebido = new ChequeRecebidoDAO(parConexao, oOcorrencia,codEmpresa);
                        ChequeRecebido oCheque = new ChequeRecebido();
                        oCheque.idMovimentoBancario = oMovBancario.idMovimentoBancario;
                        oCheque.compensacao = "C";

                        oChRecebido.baixaCheque("N",oCheque, Conexao, Transacao);
                    }

                    

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        public void conciliaMovimentoCaixa(List<MovimentoBancario> lstMovBanco, DateTime dataHora, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            try
            {

                foreach (MovimentoBancario oMovBancario in lstMovBanco)
                {
                    geraOcorrencia(oMovBancario, "C");

                    //Monta comando para a gravação do registro
                    String strSQL = "update movimentobancario set dataconciliacao=@dataconciliacao, situacao=@situacao " +
                                                                " where idMovimentoBancario = @idMovimentoBancario";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                    Sqlcon.Parameters.AddWithValue("@idMovimentoBancario", oMovBancario.idMovimentoBancario);
                    Sqlcon.Parameters.AddWithValue("@dataconciliacao", dataHora);
                    Sqlcon.Parameters.AddWithValue("@situacao", "C");

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, Transacao);
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            
        }


        public void Salvar(MovimentoBancario objMovimentoBancario)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            try
            {
                int idMovimentoBancario = Salvar(objMovimentoBancario, Conexao, Transacao);
                
                Transacao.Commit();
            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }
            
        }
        public Int32 Salvar(MovimentoBancario objMovimentoBancario, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'movimentobancario'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idMovimentoBancario = 0;
                while (drCon.Read())
                {
                    idMovimentoBancario = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    objMovimentoBancario.idMovimentoBancario = idMovimentoBancario;
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objMovimentoBancario, "I");
            
                //Monta comando para a gravação do registro
                String strSQL = "insert into MovimentoBancario ( codempresa, documento, documentoorigem, datamovimento, dataconciliacao, " + 
                                                                " ctabancaria_idempresa, ctabancaria_idctabancaria, tipomovimento, valormovimento, historico, nominal, situacao, idpessoa, codempresa_pessoa, " + 
                                                                " valordocumento, valorjuros, valordescontos, nrocheque, datapredatado, cadastro_idusuario, cadastro_datahora, idhistorico, idcaixacontrole )  " + 
                                                                " values (@codempresa, @documento, @documentoorigem, @datamovimento, @dataconciliacao, " +
                                                                        " @ctabancaria_idempresa, @ctabancaria_idctabancaria, @tipomovimento, @valormovimento, @historico, @nominal, @situacao, @idpessoa, @codempresa_pessoa, " + 
                                                                        " @valordocumento, @valorjuros, @valordescontos, @nrocheque, @datapredatado, " +
                                                                        " @cadastro_idusuario, @cadastro_datahora, @idhistorico, @idcontrolecaixa)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objMovimentoBancario.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@documento", objMovimentoBancario.documento);
                Sqlcon.Parameters.AddWithValue("@documentoorigem", objMovimentoBancario.documentoorigem);
                Sqlcon.Parameters.AddWithValue("@datamovimento", objMovimentoBancario.dataMovimento);
                Sqlcon.Parameters.AddWithValue("@dataconciliacao", objMovimentoBancario.dataConciliacao);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", objMovimentoBancario.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idctabancaria", objMovimentoBancario.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@tipomovimento", objMovimentoBancario.tipoMovimento);
                Sqlcon.Parameters.AddWithValue("@valordocumento", objMovimentoBancario.valorDocumento);
                Sqlcon.Parameters.AddWithValue("@valorjuros", objMovimentoBancario.valorJuros);
                Sqlcon.Parameters.AddWithValue("@valordescontos", objMovimentoBancario.valorDesconto);
                Sqlcon.Parameters.AddWithValue("@valormovimento", objMovimentoBancario.valorMovimento);
                Sqlcon.Parameters.AddWithValue("@historico", objMovimentoBancario.historico);
                Sqlcon.Parameters.AddWithValue("@nominal", objMovimentoBancario.nominal);
                Sqlcon.Parameters.AddWithValue("@situacao", objMovimentoBancario.situacao);
                Sqlcon.Parameters.AddWithValue("@codempresa_pessoa", objMovimentoBancario.pessoa.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objMovimentoBancario.pessoa.idPessoa);
                Sqlcon.Parameters.AddWithValue("@nrocheque", objMovimentoBancario.nroCheque);
                Sqlcon.Parameters.AddWithValue("@datapredatado", objMovimentoBancario.dataPreDatado);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", objMovimentoBancario.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objMovimentoBancario.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@idhistorico", objMovimentoBancario.idHistorico.idHistorico);
                if (objMovimentoBancario.idControleCaixa > 0)
                    Sqlcon.Parameters.AddWithValue("@idcontrolecaixa", objMovimentoBancario.idControleCaixa);
                else
                    Sqlcon.Parameters.AddWithValue("@idcontrolecaixa", null);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                CtaBancariaDAO oCtaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                oCtaDAO.atualizarSaldos(Conexao, Transacao, "I", objMovimentoBancario.tipoMovimento, objMovimentoBancario.valorMovimento, objMovimentoBancario.valorMovimentoAnterior, objMovimentoBancario.contaBancaria);


                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

                return idMovimentoBancario;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
                
        }

        public void Atualizar(MovimentoBancario objMovimentoBancario)
        {

            MySqlTransaction Transacao = Conexao.BeginTransaction();
            try
            {
                Atualizar(objMovimentoBancario, Conexao, Transacao);
                Transacao.Commit();
            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }
        }
        public void Atualizar(MovimentoBancario objMovimentoBancario, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            //atualiza um registro de MovimentoBancario
            try
            {
                geraOcorrencia(objMovimentoBancario, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update MovimentoBancario set documento=@documento, documentoorigem=@documentoorigem, " +
                                                            " datamovimento=@datamovimento, dataconciliacao=@dataconciliacao, " +
                                                            " ctabancaria_idempresa=@ctabancaria_idempresa, " +
                                                            " ctabancaria_idctabancaria=@ctabancaria_idctabancaria, tipomovimento=@tipomovimento, " +
                                                            " valormovimento=@valormovimento, historico=@historico, nominal=@nominal, situacao=@situacao, " +
                                                            " cadastro_idusuario=@cadastro_idusuario, cadastro_datahora=@cadastro_datahora, " +
                                                            " idhistorico=@idhistorico " +
                                                            " where idMovimentoBancario = @idMovimentoBancario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idMovimentoBancario", objMovimentoBancario.idMovimentoBancario);
                Sqlcon.Parameters.AddWithValue("@documento", objMovimentoBancario.documento);
                Sqlcon.Parameters.AddWithValue("@documentoorigem", objMovimentoBancario.documentoorigem);
                Sqlcon.Parameters.AddWithValue("@datamovimento", objMovimentoBancario.dataMovimento);
                Sqlcon.Parameters.AddWithValue("@dataconciliacao", objMovimentoBancario.dataConciliacao);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", objMovimentoBancario.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idctabancaria", objMovimentoBancario.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@tipomovimento", objMovimentoBancario.tipoMovimento);
                Sqlcon.Parameters.AddWithValue("@valormovimento", objMovimentoBancario.valorMovimento);
                Sqlcon.Parameters.AddWithValue("@historico", objMovimentoBancario.historico);
                Sqlcon.Parameters.AddWithValue("@nominal", objMovimentoBancario.nominal);
                Sqlcon.Parameters.AddWithValue("@situacao", objMovimentoBancario.situacao);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", objMovimentoBancario.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objMovimentoBancario.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@idhistorico", objMovimentoBancario.idHistorico.idHistorico);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                CtaBancariaDAO oCtaDAO = new CtaBancariaDAO(parConexao,oOcorrencia,codEmpresa);
                oCtaDAO.atualizarSaldos(Conexao, Transacao, "A", objMovimentoBancario.tipoMovimento, objMovimentoBancario.valorMovimento, objMovimentoBancario.valorMovimentoAnterior, objMovimentoBancario.contaBancaria);

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        public void AtualizarNroRecibo(int idMovimentoBancario, int idRecibo, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            //atualiza um registro de MovimentoBancario
            try
            {
               
                //Monta comando para a gravação do registro
                String strSQL = "update MovimentoBancario set idrecibo=@idrecibo " +
                                                            " where idMovimentoBancario = @idMovimentoBancario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idMovimentoBancario", idMovimentoBancario);
                Sqlcon.Parameters.AddWithValue("@idrecibo", idRecibo);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Excluir(MovimentoBancario objMovimentoBancario)
        {
            //apaga registro de MovimentoBancario
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            try
            {
                Excluir(objMovimentoBancario, Conexao, Transacao);

                Transacao.Commit();
            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }

        }
        public void Excluir(MovimentoBancario objMovimentoBancario, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            //apaga registro de MovimentoBancario
            try
            {
                geraOcorrencia(objMovimentoBancario, "E");
        
                //Monta comando para a gravação do registro
                String strSQL = "delete from MovimentoBancario where idMovimentoBancario = @idMovimentoBancario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL,Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idMovimentoBancario", objMovimentoBancario.idMovimentoBancario);

                Sqlcon.ExecuteNonQuery();

                CtaBancariaDAO oCtaDAO = new CtaBancariaDAO(parConexao,oOcorrencia,codEmpresa);
                oCtaDAO.atualizarSaldos(Conexao, Transacao, "E", objMovimentoBancario.tipoMovimento, objMovimentoBancario.valorMovimento, objMovimentoBancario.valorMovimentoAnterior, objMovimentoBancario.contaBancaria);

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            
        }


        public DataTable ListaExtratoBancario(int codempresa, int empmaster, int idConta, DateTime dtaInicio, DateTime dtaFinal, bool conciliado)
        {
            try
            {
                //Monta comando para a gravação do registro
                /* String strSQL = "select * from v_extrato_movimentobancario " + 
                                " where ctabancaria_idempresa = @codempresa and ctabancaria_idctabancaria = @idconta " +
                                "   and codempresa=@codempresa " +
                                "   and datamovimento>=@datainicio and datamovimento<=@datafinal ";
                */
                String strSQL = "select m.*, lpad(c.nrocheque,7,0) as chequeemitido, p.nome as nomepessoa " + 
                                "from v_extrato_movimentobancario m " +
                         " left join chequeemitir c on m.idmovimentobancario = c.idmovimentobancario " +
                         " left join pessoa p on m.codempresa_pessoa = p.CodEmpresa and m.idpessoa = p.idpessoa " +
                         " where m.ctabancaria_idempresa = @codempresa and m.ctabancaria_idctabancaria = @idconta " +
                         "   and m.codempresa=@codempresa " +
                         "  and m.datamovimento>=@datainicio and m.datamovimento<=@datafinal";

                if (conciliado)
                {
                    strSQL += " and m.situacao = 'C' order by m.dataconciliacao";
                }
                else
                    strSQL += " order by m.datamovimento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codempresa);
                Sqlcon.Parameters.AddWithValue("@empmaster", empmaster);
                Sqlcon.Parameters.AddWithValue("@idconta", idConta);
                Sqlcon.Parameters.AddWithValue("@datainicio", dtaInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dtaFinal);
                

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
        public DataTable ListaMovimentoBancario()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from MovimentoBancario order by datamovimento";
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
        public List<MovimentoBancario> lstEmissaoRecibo(string tipoMovimento, DateTime dtaInicio, DateTime dtaFinal)
        {
            List<MovimentoBancario> lstMovimentoBancario = new List<MovimentoBancario>();
            try
            {
                MySqlDataReader drCon;
                //Monta comando para a gravação do registro
                String strSQL = "select * from MovimentoBancario Where codempresa=@codempresa and (datamovimento >= @dtainicio and datamovimento <= @dtafinal) and tipomovimento = @tipo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@tipo", tipoMovimento);
                Sqlcon.Parameters.AddWithValue("@dtainicio", dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", dtaFinal);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);

                drCon = Sqlcon.ExecuteReader();

                List<MovimentoBancario> lstMovimento = new List<MovimentoBancario>();
                while (drCon.Read())
                {
                    MovimentoBancario objMovimentoBancario = new MovimentoBancario();
                    objMovimentoBancario.idMovimentoBancario = EmcResources.cInt(drCon["idmovimentobancario"].ToString());
                    lstMovimento.Add(objMovimentoBancario);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                foreach(MovimentoBancario oMovBanco in lstMovimento)
                {
                    MovimentoBancario oMBanco = new MovimentoBancario();
                    oMBanco = ObterPor(oMovBanco);
                    lstMovimentoBancario.Add(oMBanco);
                }
            }
            catch(MySqlException oErro)
            {
                throw oErro;
            }

            return lstMovimentoBancario;

        }

        public DataTable extratoPeriodo(CtaBancaria oCta, DateTime dataInicio, DateTime dataFinal)
        {
            try
            {
             
                //Monta comando para a gravação do registro
                String strSQL = "select datamovimento, documento, valormovimento, tipomovimento, historico, idmovimentobancario from MovimentoBancario " +
                                " where ctabancaria_idempresa=@ctabancaria_idempresa and " + 
                                      " ctabancaria_idctabancaria=@ctabancaria_idctabancaria and " + 
                                      " datamovimento>=@datainicio " + 
                                      " and datamovimento<=@datafinal order by datamovimento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oCta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idctabancaria", oCta.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
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

        public MovimentoBancario ObterPor(MovimentoBancario oMovimentoBancario)
        {
            bool consulta = false;
            try
            {
                MySqlDataReader drCon;
                if (oMovimentoBancario.idMovimentoBancario > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from MovimentoBancario Where idMovimentoBancario=@idMovimentoBancario";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idMovimentoBancario", oMovimentoBancario.idMovimentoBancario);
                    
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from MovimentoBancario Where documento=@documento";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@documento", oMovimentoBancario.documento);
                   
                    drCon = Sqlcon.ExecuteReader();
                }

                MovimentoBancario objMovimentoBancario = new MovimentoBancario();                
                while (drCon.Read())
                {
                    consulta = true;
                    objMovimentoBancario.idMovimentoBancario = Convert.ToInt32(drCon["idMovimentoBancario"].ToString());
                    objMovimentoBancario.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objMovimentoBancario.documento = drCon["documento"].ToString();
                    objMovimentoBancario.documentoorigem = drCon["documentoorigem"].ToString();
                    objMovimentoBancario.dataMovimento = Convert.ToDateTime(drCon["datamovimento"].ToString());
                    objMovimentoBancario.dataConciliacao = EmcResources.cDate(drCon["dataconciliacao"].ToString());

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistorico"].ToString());
                    objMovimentoBancario.idHistorico = oHistorico;

                    CtaBancaria oCta = new CtaBancaria();
                    oCta.codEmpresa = Convert.ToInt32(drCon["ctabancaria_idempresa"].ToString());
                    oCta.idCtaBancaria = Convert.ToInt32(drCon["ctabancaria_idctabancaria"].ToString());
                    objMovimentoBancario.contaBancaria = oCta;

                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = Convert.ToInt32(drCon["codempresa_pessoa"].ToString());
                    oPessoa.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objMovimentoBancario.pessoa = oPessoa;

                    objMovimentoBancario.tipoMovimento = drCon["tipomovimento"].ToString();
                    objMovimentoBancario.valorMovimento = Convert.ToDecimal(drCon["valormovimento"].ToString());
                    objMovimentoBancario.historico = drCon["historico"].ToString();
                    objMovimentoBancario.nominal = drCon["nominal"].ToString();
                    objMovimentoBancario.nroCheque = drCon["nrocheque"].ToString();
                    objMovimentoBancario.situacao = drCon["situacao"].ToString();
                    objMovimentoBancario.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objMovimentoBancario.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());


                    objMovimentoBancario.idRecibo = EmcResources.cInt(drCon["idrecibo"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    CtaBancariaDAO oCtaRN = new CtaBancariaDAO(parConexao,oOcorrencia,codEmpresa);
                    objMovimentoBancario.contaBancaria = oCtaRN.ObterPor(objMovimentoBancario.contaBancaria);

                    PessoaDAO oPessoaRN = new PessoaDAO(parConexao,oOcorrencia,codEmpresa);
                    objMovimentoBancario.pessoa = oPessoaRN.ObterPor(objMovimentoBancario.pessoa);

                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia,codEmpresa);
                    objMovimentoBancario.idHistorico = oHistDAO.ObterPor(objMovimentoBancario.idHistorico);
                }

                return objMovimentoBancario;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Decimal calculaCredito(int codEmpresa, DateTime dataInicio, DateTime dataFinal, CtaBancaria oConta, bool conciliado)
        {
            Decimal valorCredito = 0;
            try
            {
                MySqlDataReader drCon;
                //Monta comando para a gravação do registro
                String strSQL = "select sum(valormovimento) as valorcredito from MovimentoBancario " +
                                " Where ctabancaria_idempresa=@idempresa and ctabancaria_idctabancaria=@ctabancaria " +
                                "   and codempresa=@codempresa and datamovimento >= @datainicio and datamovimento <= @datafinal "+
                                "   and tipomovimento='C'";
                if (conciliado)
                {
                    strSQL = strSQL + " and situacao='C' ";
                }
                                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria", oConta.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    valorCredito = EmcResources.cCur(drCon["valorcredito"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch(MySqlException erro)
            {
                throw erro;
            }

            return valorCredito;
        }
        public Decimal calculaDebito(int codEmpresa, DateTime dataInicio, DateTime dataFinal, CtaBancaria oConta, bool conciliado)
        {
            Decimal valorDebito=0;
            try
            {
                MySqlDataReader drCon;
                //Monta comando para a gravação do registro
                String strSQL = "select sum(valormovimento) as valordebito from MovimentoBancario " +
                                " Where ctabancaria_idempresa=@idempresa and ctabancaria_idctabancaria=@ctabancaria " +
                                "   and codempresa=@codempresa and datamovimento >= @datainicio and datamovimento <= @datafinal " + 
                                "   and tipomovimento='D'";
                if (conciliado)
                {
                    strSQL = strSQL + " and situacao='C' ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria", oConta.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    valorDebito = EmcResources.cCur(drCon["valordebito"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return valorDebito;
        }

        public DataTable listaControleCaixa(int idControleCaixa)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idmovimentobancario, idcaixacontrole, datamovimento, valormovimento, tipomovimento, nominal " + 
                                "from MovimentoBancario where idcaixacontrole=@caixa " + 
                                "order by idmovimentobancario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@caixa", idControleCaixa);

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
        public List<MovimentoBancario> lstMovimentoCaixa(int idControleCaixa)
        {
            bool consulta = false;
            List<MovimentoBancario> lstMovBanco = new List<MovimentoBancario>();
            try
            {
                MySqlDataReader drCon;
                
                String strSQL = "select * from MovimentoBancario Where idcaixacontrole=@caixa order by idmovimentobancario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@caixa", idControleCaixa);
                    
                drCon = Sqlcon.ExecuteReader();
                List<MovimentoBancario> lstMov = new List<MovimentoBancario>();
                
                while (drCon.Read())
                {
                    consulta = true;
                    MovimentoBancario objMovimentoBancario = new MovimentoBancario();
                    objMovimentoBancario.idMovimentoBancario = Convert.ToInt32(drCon["idMovimentoBancario"].ToString());
                    lstMov.Add(objMovimentoBancario);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {

                    foreach (MovimentoBancario oMov in lstMov)
                    {
                        lstMovBanco.Add(ObterPor(oMov));
                    }
                }

            }
            catch(MySqlException oErro)
            {
                throw oErro;
            }


            return lstMovBanco;

        }
        public decimal calculaSdoCtrCaixa(int idControleCaixa)
        {
            decimal saldoAtual, saldoInicial, valorDebito, valorCredito;
            try
            {

                /* Calcula Valor de Débitos no Caixa */

                MySqlDataReader drCon;
                //Monta comando para a gravação do registro
                String strSQL = "select sum(valormovimento) as valordebito from MovimentoBancario " +
                                " Where idcaixacontrole=@caixa " +
                                "   and tipomovimento='D'";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@caixa", idControleCaixa);

                drCon = Sqlcon.ExecuteReader();

                valorDebito = 0;
                while (drCon.Read())
                {
                    valorDebito = EmcResources.cCur(drCon["valordebito"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                /* Calcula de valor de créditos no caixa */
                
                //Monta comando para a gravação do registro
                strSQL = "select sum(valormovimento) as valorcredito from MovimentoBancario " +
                                " Where idcaixacontrole=@caixa " +
                                "   and tipomovimento='C'";

                Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@caixa", idControleCaixa);

                drCon = Sqlcon.ExecuteReader();

                valorCredito = 0;
                while (drCon.Read())
                {
                    valorCredito = EmcResources.cCur(drCon["valorcredito"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                ControleCaixaDAO oCtrDAO = new ControleCaixaDAO(parConexao, oOcorrencia, codEmpresa);
                ControleCaixa oCtr = new ControleCaixa();
                oCtr.idControleCaixa = idControleCaixa;

                oCtr = oCtrDAO.ObterPor(oCtr);

                saldoInicial = oCtr.saldoAbertura;

                saldoAtual = ((saldoInicial + valorCredito) - valorDebito);

                return saldoAtual;

            }
            catch(MySqlException oErro)
            {
                throw oErro;
            }
        }

        private void geraOcorrencia(MovimentoBancario oMovimentoBancario, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oMovimentoBancario.idMovimentoBancario.ToString();

                if (flag == "A")
                {

                    MovimentoBancario oMov = new MovimentoBancario();
                    oMov = ObterPor(oMovimentoBancario);

                    if (!oMov.Equals(oMovimentoBancario))
                    {
                        descricao = "Movimento Bancario id: " + oMovimentoBancario.idMovimentoBancario + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oMov.dataConciliacao.Equals(oMovimentoBancario.dataConciliacao))
                        {
                            descricao += " Data Concialiação de " + oMov.dataConciliacao + " para " + oMovimentoBancario.dataConciliacao;
                        }
                        if (!oMov.dataMovimento.Equals(oMovimentoBancario.dataMovimento))
                        {
                            descricao += " Data Movimento de " + oMov.dataMovimento + " para " + oMovimentoBancario.dataMovimento;
                        }
                        if (!oMov.dataPreDatado.Equals(oMovimentoBancario.dataPreDatado))
                        {
                            descricao += " Data Pre datado de " + oMov.dataPreDatado + " para " + oMovimentoBancario.dataPreDatado;
                        }
                        if (!oMov.documento.Equals(oMovimentoBancario.documento))
                        {
                            descricao += " Documento de " + oMov.documento + " para " + oMovimentoBancario.documento;
                        }
                        if (!oMov.documentoorigem.Equals(oMovimentoBancario.documentoorigem))
                        {
                            descricao += " Documento Origem de " + oMov.documentoorigem + " para " + oMovimentoBancario.documentoorigem;
                        }
                        if (!oMov.historico.Equals(oMovimentoBancario.historico))
                        {
                            descricao += " Historico de " + oMov.historico + " para " + oMovimentoBancario.historico;
                        }
                        if (!oMov.nominal.Equals(oMovimentoBancario.nominal))
                        {
                            descricao += " Nominal de " + oMov.nominal + " para " + oMovimentoBancario.nominal;
                        }
                        if (!oMov.nroCheque.Equals(oMovimentoBancario.nroCheque))
                        {
                            descricao += " Numero Cheque de " + oMov.nroCheque + " para " + oMovimentoBancario.nroCheque;
                        }
                        if (!oMov.pessoa.Equals(oMovimentoBancario.pessoa))
                        {
                            descricao += " Pessoa de " + oMov.pessoa.idPessoa + " - " +oMov.pessoa.nome + " para " + oMovimentoBancario.pessoa.idPessoa + " - " +oMovimentoBancario.pessoa.nome;
                        }
                        if (!oMov.situacao.Equals(oMovimentoBancario.situacao))
                        {
                            descricao += " Situacao de " + oMov.situacao + " para " + oMovimentoBancario.situacao;
                        }
                        if (!oMov.tipoMovimento.Equals(oMovimentoBancario.tipoMovimento))
                        {
                            descricao += " Tipo Movimento de " + oMov.tipoMovimento + " para " + oMovimentoBancario.tipoMovimento;
                        }
                        if (!oMov.valorDesconto.Equals(oMovimentoBancario.valorDesconto))
                        {
                            descricao += " Valor Desconto de " + oMov.valorDesconto + " para " + oMovimentoBancario.valorDesconto;
                        }
                        if (!oMov.valorDocumento.Equals(oMovimentoBancario.valorDocumento))
                        {
                            descricao += " Valor Documento de " + oMov.valorDocumento + " para " + oMovimentoBancario.valorDocumento;
                        }
                        if (!oMov.valorJuros.Equals(oMovimentoBancario.valorJuros))
                        {
                            descricao += " Valor Juros de " + oMov.valorJuros + " para " + oMovimentoBancario.valorJuros;
                        }
                        if (!oMov.valorMovimento.Equals(oMovimentoBancario.valorMovimento))
                        {
                            descricao += " Valor Movimento de " + oMov.valorMovimento + " para " + oMovimentoBancario.valorMovimento;
                        }
                        if (!oMov.contaBancaria.Equals(oMovimentoBancario.contaBancaria))
                        {
                            descricao += " Conta Bancaria de " + oMov.contaBancaria.idCtaBancaria + " - " + oMov.contaBancaria.descricao + " para " + oMovimentoBancario.contaBancaria.idCtaBancaria + " - " + oMovimentoBancario.contaBancaria.descricao;
                        }
                        if (!oMov.idHistorico.idHistorico.Equals(oMovimentoBancario.idHistorico.idHistorico))
                        {
                            descricao += " idHistorico de " + oMov.idHistorico.idHistorico + " - " + oMov.idHistorico.descricao + 
                                         " para " + oMovimentoBancario.idHistorico.idHistorico + " - " + oMovimentoBancario.idHistorico.descricao;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "Movimento Bancario id : " + oMovimentoBancario.idMovimentoBancario + 
                                " - Nominal - " + oMovimentoBancario.nominal + 
                                " - CodEmpresa - " + oMovimentoBancario.codEmpresa +
                                " - Documento - " + oMovimentoBancario.documento + 
                                " - Documento Origem - " + oMovimentoBancario.documentoorigem +
                                " - Data Movimento - " + oMovimentoBancario.dataMovimento +
                                " - Data Conciliacao - " + oMovimentoBancario.dataConciliacao +
                                " - Tipo Movimento - " + oMovimentoBancario.tipoMovimento + 
                                " - Valor Documento - " + oMovimentoBancario.valorDocumento +
                                " - Valor Juros - " + oMovimentoBancario.valorJuros +
                                " - Valor Desconto - " +oMovimentoBancario.valorDesconto +
                                " - Valor Movimento - " + oMovimentoBancario.valorMovimento +
                                " - idHistorico - " + oMovimentoBancario.idHistorico.idHistorico + " - " + oMovimentoBancario.idHistorico.descricao +
                                " - Historico - " + oMovimentoBancario.historico + 
                                " - Numero Cheque - " + oMovimentoBancario.nroCheque +
                                " - Situacao - " + oMovimentoBancario.situacao +
                                " - CodEmpresa_Pessoa - " + oMovimentoBancario.pessoa.codEmpresa +
                                " - id Pessoa - " + oMovimentoBancario.pessoa.idPessoa +
                                " - Nome Pessoa - " + oMovimentoBancario.pessoa.nome +
                                " - Pre Datado - " + oMovimentoBancario.dataPreDatado +
                                " - Cta Bancaria Empresa - " +oMovimentoBancario.contaBancaria.codEmpresa+
                                " - Cta Bancaria id - " + oMovimentoBancario.contaBancaria.idCtaBancaria +
                                " - Cta Bancaria Descricao - " + oMovimentoBancario.contaBancaria.descricao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Movimento Bancario id : " + oMovimentoBancario.idMovimentoBancario +
                                " - Nominal - " + oMovimentoBancario.nominal +
                                " - CodEmpresa - " + oMovimentoBancario.codEmpresa +
                                " - Documento - " + oMovimentoBancario.documento +
                                " - Documento Origem - " + oMovimentoBancario.documentoorigem +
                                " - Data Movimento - " + oMovimentoBancario.dataMovimento +
                                " - Data Conciliacao - " + oMovimentoBancario.dataConciliacao +
                                " - Tipo Movimento - " + oMovimentoBancario.tipoMovimento +
                                " - Valor Documento - " + oMovimentoBancario.valorDocumento +
                                " - Valor Juros - " + oMovimentoBancario.valorJuros +
                                " - Valor Desconto - " + oMovimentoBancario.valorDesconto +
                                " - Valor Movimento - " + oMovimentoBancario.valorMovimento +
                                " - idHistorico - " + oMovimentoBancario.idHistorico.idHistorico + " - " + oMovimentoBancario.idHistorico.descricao +
                                " - Historico - " + oMovimentoBancario.historico +
                                " - Numero Cheque - " + oMovimentoBancario.nroCheque +
                                " - Situacao - " + oMovimentoBancario.situacao +
                                " - CodEmpresa_Pessoa - " + oMovimentoBancario.pessoa.codEmpresa +
                                " - id Pessoa - " + oMovimentoBancario.pessoa.idPessoa +
                                " - Nome Pessoa - " + oMovimentoBancario.pessoa.nome +
                                " - Pre Datado - " + oMovimentoBancario.dataPreDatado +
                                " - Cta Bancaria Empresa - " + oMovimentoBancario.contaBancaria.codEmpresa +
                                " - Cta Bancaria id - " + oMovimentoBancario.contaBancaria.idCtaBancaria +
                                " - Cta Bancaria Descricao - " + oMovimentoBancario.contaBancaria.descricao +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "C")
                {
                    descricao = "Movimento Bancario id : " + oMovimentoBancario.idMovimentoBancario +
                                " - Nominal - " + oMovimentoBancario.nominal +
                                " - CodEmpresa - " + oMovimentoBancario.codEmpresa +
                                " - Documento - " + oMovimentoBancario.documento +
                                " - Documento Origem - " + oMovimentoBancario.documentoorigem +
                                " - Data Movimento - " + oMovimentoBancario.dataMovimento +
                                " - Data Conciliacao - " + oMovimentoBancario.dataConciliacao +
                                " - Tipo Movimento - " + oMovimentoBancario.tipoMovimento +
                                " - Valor Movimento - " + oMovimentoBancario.valorMovimento +
                                " foi conciliado por " + oOcorrencia.usuario.nome;

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
