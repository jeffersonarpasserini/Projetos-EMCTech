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
    public class PagarRateioDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarRateioDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
        public void rateioBaixa(PagarBaixa oBaixa, List<PagarBaseRateio> lstBaseRateio, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                //Calcula valor do rateio
                int contaBase = 1;
                decimal totRatBaixa = 0;
                decimal totRatJuros = 0;
                decimal totRatDesconto = 0;

                foreach (PagarBaseRateio oRat in lstBaseRateio)
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

                        //monta objeto PagarRateio para a baixa
                        PagarRateio oPgRateio = new PagarRateio();

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
                        PagarParcela oParcela = new PagarParcela();
                        PagarParcelaDAO oParcDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                        oParcela = oBaixa.pagarParcela;
                        oParcela = oParcDAO.ObterPor(oParcela);

                        //Chaves Documento, Parcela e Baixa
                        oPgRateio.idPagarDocumento = EmcResources.cInt(oParcela.pagarDocumento.idPagarDocumento.ToString());
                        oPgRateio.idPagarParcela = EmcResources.cInt(oParcela.idPagarParcela.ToString());
                        oPgRateio.idPagarBaixa = EmcResources.cInt(oBaixa.idPagarBaixa.ToString());
                        //define a aplicacao e a conta custo do rateio
                        oPgRateio.idAplicacao = EmcResources.cInt(oRat.aplicacao.idAplicacao.ToString());
                        oPgRateio.idContaCusto = EmcResources.cInt(oRat.contaCusto.idContaCusto.ToString());
                        //define as classificações do documento
                        oPgRateio.nroDocumento = oParcela.pagarDocumento.nroDocumento;
                        oPgRateio.dataEmissao = Convert.ToDateTime(oParcela.pagarDocumento.dataEmissao.ToString());
                        oPgRateio.dataEntrada = Convert.ToDateTime(oParcela.pagarDocumento.dataEntrada.ToString());
                        oPgRateio.idTipoDocumento = EmcResources.cInt(oParcela.pagarDocumento.tipoDocumento.idTipoDocumento.ToString());
                        oPgRateio.idIndexador = EmcResources.cInt(oParcela.pagarDocumento.indexador.idIndexador.ToString());
                        oPgRateio.fornecedor_CodEmpresa = EmcResources.cInt(oParcela.pagarDocumento.fornecedor.codEmpresa.ToString());
                        oPgRateio.idFornecedor = EmcResources.cInt(oParcela.pagarDocumento.fornecedor.idPessoa.ToString());
                        oPgRateio.historico = oParcela.pagarDocumento.descricao;
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
        public void rateioBaixaDocumento(PagarDocumento oDoc, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                //percorre parcelas do documento
                foreach (PagarParcela oParcela in oDoc.parcelas)
                {
                    //percorre as baixa de cada parcela
                    foreach (PagarBaixa oBaixa in oParcela.baixas)
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
        public void salvaRateio(PagarRateio oRateio, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "insert into pagarrateio (tipolancamento, idpagardocumento, idpagarparcela, idpagarbaixa, idaplicacao, idcontacusto, " + 
                                                         "idtipodocumento, idindexador, fornecedor_codempresa, idfornecedor, codempresa, idmatriz,  " + 
                                                         "idgrupoempresa, idholding, situacaobaixa, idformapagamento, idhistorico, dataemissao, " +
                                                         "dataentrada, databaixa, datavencimento, ctabancaria_empresa, idctabancaria, idmovimentobancario, " + 
                                                         "nrodocumento, documentobaixa, nroparcela, valorbaixa, valorjuros, valordesconto, percentualrateio, " + 
                                                         "historico, historicobaixa ) " +
                                                         " values ( " +
                                                         "@tipolancamento, @idpagardocumento, @idpagarparcela, @idpagarbaixa, @idaplicacao, @idcontacusto, " +
                                                         "@idtipodocumento, @idindexador, @fornecedor_codempresa, @idfornecedor, @codempresa, @idmatriz,  " +
                                                         "@idgrupoempresa, @idholding, @situacaobaixa, @idformapagamento, @idhistorico, @dataemissao, " +
                                                         "@dataentrada, @databaixa, @datavencimento, @ctabancaria_empresa, @idctabancaria, @idmovimentobancario, " +
                                                         "@nrodocumento, @documentobaixa, @nroparcela, @valorbaixa, @valorjuros, @valordesconto, @percentualrateio, " +
                                                         "@historico, @historicobaixa ) ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@tipolancamento", oRateio.tipoLancamento);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", oRateio.idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@idpagarparcela", oRateio.idPagarParcela);
                Sqlcon.Parameters.AddWithValue("@idpagarbaixa", oRateio.idPagarBaixa);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", oRateio.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", oRateio.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", oRateio.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@idindexador", oRateio.idIndexador);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", oRateio.fornecedor_CodEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", oRateio.idFornecedor);
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
        public void eliminaRateioDocumento(PagarDocumento oDoc, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                string strSQL = "delete from pagarrateio where idpagardocumento=@idpagardocumento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", oDoc.idPagarDocumento);

                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw e;
            }

        }
        // elimina todos os rateios do documento para refazer seus rateios de acordo com a alteração da base de rateio
        public void eliminaRateioBaixa(PagarBaixa oBaixa, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {
                string strSQL = "delete from pagarrateio where idpagarbaixa=@idpagarbaixa";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idpagarbaixa", oBaixa.idPagarBaixa);

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
