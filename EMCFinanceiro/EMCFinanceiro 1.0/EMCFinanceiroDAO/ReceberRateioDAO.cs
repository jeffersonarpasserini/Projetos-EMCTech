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
    public class ReceberRateioDAO
    {
         MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberRateioDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
        //Fazer o rateio de uma baixa
        public void rateioBaixa(ReceberBaixa oBaixa, List<ReceberBaseRateio> lstBaseRateio, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                //Calcula valor do rateio
                int contaBase = 1;
                decimal totRatBaixa = 0;
                decimal totRatJuros = 0;
                decimal totRatDesconto = 0;

                foreach (ReceberBaseRateio oRat in lstBaseRateio)
                {

                    if (oRat.status != "E")
                    {
                        decimal vlrRatBaixa = 0;
                        decimal vlrRatJuros = 0;
                        decimal vlrRatDesconto = 0;

                        if (contaBase.Equals(lstBaseRateio.Count))
                        {
                            vlrRatBaixa = (EmcResources.cCur(oBaixa.valorBaixa.ToString()) - totRatBaixa);
                            vlrRatJuros = (EmcResources.cCur(oBaixa.valorJuros.ToString()) - totRatJuros);
                            vlrRatDesconto = (EmcResources.cCur(oBaixa.valorDesconto.ToString()) - totRatDesconto);
                            contaBase++;
                        }
                        else
                        {
                            vlrRatBaixa = (EmcResources.cCur(oBaixa.valorBaixa.ToString()) * EmcResources.cCur(oRat.percentualRateio.ToString())) / 100;
                            vlrRatJuros = (EmcResources.cCur(oBaixa.valorJuros.ToString()) * EmcResources.cCur(oRat.percentualRateio.ToString())) / 100;
                            vlrRatDesconto = (EmcResources.cCur(oBaixa.valorDesconto.ToString()) * EmcResources.cCur(oRat.percentualRateio.ToString())) / 100;

                            totRatBaixa += vlrRatBaixa;
                            totRatJuros += vlrRatJuros;
                            totRatDesconto += vlrRatDesconto;
                            contaBase++;
                        }

                        //monta objeto ReceberRateio para a baixa
                        ReceberRateio oPgRateio = new ReceberRateio();

                        //define os valores rateados
                        oPgRateio.tipoLancamento = "D";
                        oPgRateio.valorBaixa = vlrRatBaixa;
                        oPgRateio.valorDesconto = vlrRatDesconto;
                        oPgRateio.valorJuros = vlrRatJuros;
                        //define o percentual de rateio
                        oPgRateio.percentualRateio = oRat.percentualRateio;
                        //monta as informações para classificação do lancamento
                        //codempresa
                        oPgRateio.codEmpresa = oBaixa.codEmpresa;

                        Empresa oEmp = new Empresa();
                        oEmp.idEmpresa = oBaixa.codEmpresa;

                        EmpresaDAO oEmpDAO = new EmpresaDAO(parConexao, oOcorrencia);
                        oEmp = oEmpDAO.ObterPor(oEmp);

                        oPgRateio.idHolding = EmcResources.cInt(oEmp.grupoEmpresa.holding.idHolding.ToString());
                        oPgRateio.idGrupoEmpresa = EmcResources.cInt(oEmp.grupoEmpresa.idGrupoEmpresa.ToString());
                        oPgRateio.idMatriz = EmcResources.cInt(oEmp.matriz.idEmpresa.ToString());

                        //Busca a parcela
                        ReceberParcela oParcela = new ReceberParcela();
                        ReceberParcelaDAO oParcDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oParcela = oBaixa.receberParcela;
                        oParcela = oParcDAO.ObterPor(oParcela);

                        //Chaves Documento, Parcela e Baixa
                        oPgRateio.idReceberDocumento = EmcResources.cInt(oParcela.receberDocumento.idReceberDocumento.ToString());
                        oPgRateio.idReceberParcela = EmcResources.cInt(oParcela.idReceberParcela.ToString());
                        oPgRateio.idReceberBaixa = EmcResources.cInt(oBaixa.idReceberBaixa.ToString());
                        //define a aplicacao e a conta custo do rateio
                        oPgRateio.idAplicacao = EmcResources.cInt(oRat.aplicacao.idAplicacao.ToString());
                        oPgRateio.idContaCusto = EmcResources.cInt(oRat.contaCusto.idContaCusto.ToString());
                        //define as classificações do documento
                        oPgRateio.nroDocumento = oParcela.receberDocumento.nroDocumento;
                        oPgRateio.dataEmissao = Convert.ToDateTime(oParcela.receberDocumento.dataEmissao.ToString());
                        oPgRateio.dataEntrada = Convert.ToDateTime(oParcela.receberDocumento.dataEntrada.ToString());
                        oPgRateio.idTipoDocumento = EmcResources.cInt(oParcela.receberDocumento.tipoDocumento.idTipoDocumento.ToString());
                        oPgRateio.idIndexador = EmcResources.cInt(oParcela.receberDocumento.indexador.idIndexador.ToString());
                        oPgRateio.cliente_CodEmpresa = EmcResources.cInt(oParcela.receberDocumento.cliente.codEmpresa.ToString());
                        oPgRateio.idCliente = EmcResources.cInt(oParcela.receberDocumento.cliente.idPessoa.ToString());
                        oPgRateio.historico = oParcela.receberDocumento.descricao;
                        //define informaçõs da parcela
                        oPgRateio.dataVencimento = Convert.ToDateTime(oParcela.dataVencimento.ToString());
                        oPgRateio.nroParcela = oParcela.nroParcela;
                        //define informações da baixa
                        oPgRateio.situacaoBaixa = oBaixa.situacaoBaixa;
                        oPgRateio.idFormaPagamento = EmcResources.cInt(oBaixa.formaPagamento.idFormaPagamento.ToString());
                        oPgRateio.idHistorico = EmcResources.cInt(oBaixa.idHistorico.idHistorico.ToString());
                        oPgRateio.dataBaixa = oBaixa.dataPagamento;
                        oPgRateio.idMovimentoBancario = oBaixa.idMovimentoBancario;
                        oPgRateio.documentoBaixa = oBaixa.documentoBaixa;
                        oPgRateio.historicoBaixa = oBaixa.historico;
                        //cta bancaria da baixa
                        oPgRateio.ctaBancaria_Empresa = oBaixa.contaCorrente.codEmpresa;
                        oPgRateio.idCtaBancaria = oBaixa.contaCorrente.idCtaBancaria;

                        //salva rateio
                        salvaRateio(oPgRateio, xConexao, Transacao);
                    }
                    else
                    {
                        contaBase++;
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // refazer os rateios da baixa de um documento quando sua base de rateio for alterada
        public void rateioBaixaDocumento(ReceberDocumento oDoc, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                //percorre parcelas do documento
                foreach (ReceberParcela oParcela in oDoc.parcelas)
                {
                    //percorre as baixa de cada parcela
                    foreach (ReceberBaixa oBaixa in oParcela.baixas)
                    {
                        //elimina os rateios desta baixa
                        eliminaRateioBaixa(oBaixa, xConexao, Transacao);
                        //refaz o rateio da baixa
                        rateioBaixa(oBaixa, oDoc.baseRateio, xConexao, Transacao);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        // salva rateios
        public void salvaRateio(ReceberRateio oRateio, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "insert into receberrateio (tipolancamento, idreceberdocumento, idreceberparcela, idreceberbaixa, idaplicacao, idcontacusto, " + 
                                                         "idtipodocumento, idindexador, cliente_codempresa, idcliente, codempresa, idmatriz,  " + 
                                                         "idgrupoempresa, idholding, situacaobaixa, idformapagamento, idhistorico, dataemissao, " +
                                                         "dataentrada, databaixa, datavencimento, ctabancaria_empresa, idctabancaria, idmovimentobancario, " + 
                                                         "nrodocumento, documentobaixa, nroparcela, valorbaixa, valorjuros, valordesconto, percentualrateio, " + 
                                                         "historico, historicobaixa ) " +
                                                         " values ( " +
                                                         "@tipolancamento, @idreceberdocumento, @idreceberparcela, @idreceberbaixa, @idaplicacao, @idcontacusto, " +
                                                         "@idtipodocumento, @idindexador, @cliente_codempresa, @idcliente, @codempresa, @idmatriz,  " +
                                                         "@idgrupoempresa, @idholding, @situacaobaixa, @idformapagamento, @idhistorico, @dataemissao, " +
                                                         "@dataentrada, @databaixa, @datavencimento, @ctabancaria_empresa, @idctabancaria, @idmovimentobancario, " +
                                                         "@nrodocumento, @documentobaixa, @nroparcela, @valorbaixa, @valorjuros, @valordesconto, @percentualrateio, " +
                                                         "@historico, @historicobaixa ) ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@tipolancamento", oRateio.tipoLancamento);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", oRateio.idReceberDocumento);
                Sqlcon.Parameters.AddWithValue("@idreceberparcela", oRateio.idReceberParcela);
                Sqlcon.Parameters.AddWithValue("@idreceberbaixa", oRateio.idReceberBaixa);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", oRateio.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", oRateio.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", oRateio.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@idindexador", oRateio.idIndexador);
                Sqlcon.Parameters.AddWithValue("@cliente_codempresa", oRateio.cliente_CodEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", oRateio.idCliente);
                Sqlcon.Parameters.AddWithValue("@codempresa", oRateio.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idmatriz", oRateio.idMatriz);
                Sqlcon.Parameters.AddWithValue("@idgrupoempresa", oRateio.idGrupoEmpresa);
                Sqlcon.Parameters.AddWithValue("@idholding", oRateio.idHolding);
                Sqlcon.Parameters.AddWithValue("@situacaobaixa", oRateio.situacaoBaixa);
                Sqlcon.Parameters.AddWithValue("@idformapagamento", oRateio.idFormaPagamento);
                Sqlcon.Parameters.AddWithValue("@idhistorico", oRateio.idHistorico);
                Sqlcon.Parameters.AddWithValue("@dataemissao", oRateio.dataEmissao);
                Sqlcon.Parameters.AddWithValue("@dataentrada", oRateio.dataEntrada);
                Sqlcon.Parameters.AddWithValue("@databaixa", oRateio.dataBaixa);
                Sqlcon.Parameters.AddWithValue("@datavencimento", oRateio.dataVencimento);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_empresa", oRateio.ctaBancaria_Empresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oRateio.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@idmovimentobancario", oRateio.idMovimentoBancario);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", oRateio.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@documentobaixa", oRateio.documentoBaixa);
                Sqlcon.Parameters.AddWithValue("@nroparcela", oRateio.nroParcela);
                Sqlcon.Parameters.AddWithValue("@valorbaixa", oRateio.valorBaixa);
                Sqlcon.Parameters.AddWithValue("@valorjuros", oRateio.valorJuros);
                Sqlcon.Parameters.AddWithValue("@valordesconto", oRateio.valorDesconto);
                Sqlcon.Parameters.AddWithValue("@percentualrateio", oRateio.percentualRateio);
                Sqlcon.Parameters.AddWithValue("@historico", oRateio.historico);
                Sqlcon.Parameters.AddWithValue("@historicobaixa", oRateio.historicoBaixa);
                
                                                       
                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                throw e;
            }
        }
        // elimina todos os rateios do documento para refazer seus rateios de acordo com a alteração da base de rateio
        public void eliminaRateioDocumento(ReceberDocumento oDoc, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                string strSQL = "delete from receberrateio where idreceberdocumento=@idreceberdocumento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", oDoc.idReceberDocumento);

                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }
        // elimina todos os rateios do documento para refazer seus rateios de acordo com a alteração da base de rateio
        public void eliminaRateioBaixa(ReceberBaixa oBaixa, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                string strSQL = "delete from receberrateio where idreceberbaixa=@idreceberbaixa";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idreceberbaixa", oBaixa.idReceberBaixa);

                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw e;
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
