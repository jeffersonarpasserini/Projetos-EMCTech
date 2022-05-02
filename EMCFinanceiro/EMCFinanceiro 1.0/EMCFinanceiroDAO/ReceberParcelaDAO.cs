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
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCIntegracaoDAO;
using EMCIntegracaoModel;

namespace EMCFinanceiroDAO
{
    public class ReceberParcelaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
        string tipoJuros = "S";

        public ReceberParcelaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas em aberto para recebimento de acordo com o parametros informados
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docReceber"></param>
        /// <returns></returns>
        public List<ReceberParcela> listaParcelaBaixa(int codempresa, int empMaster, int idCliente, DateTime? dataInicio, DateTime? dataFinal, bool todos, string docReceber, int chaveAcordo = 0)
        {
            bool consulta = false;
            try
            {

                ParametroDAO oParametroDAO = new ParametroDAO(parConexao, oOcorrencia, codEmpresa);
                tipoJuros = oParametroDAO.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "TIPO_JUROS");

                //Monta comando para a gravação do registro
                String strSQL = "select p.*, d.*, a.situacao as situacaoacordo, a.datalimiterecebimento " + 
                                " from ReceberParcela p left join receberdocumento d on d.idreceberdocumento = p.idreceberdocumento " +
                                                      " left join receberacordo a on a.idacordo = p.idacordo" +
                                " where p.situacao='A' " +
                                "   and d.empresa_idempresa = @codempresa ";

                if (!String.IsNullOrEmpty(docReceber))
                {
                    strSQL = strSQL + "and d.nrodocumento=@nrodocumento " ;
                }
                if (!todos)
                {
                    strSQL = strSQL + "and p.datavencimento >= @datainicio and p.datavencimento <= @datafinal " ;
                }                
                if (idCliente > 0)
                {
                    strSQL = strSQL + "and d.cliente_codempresa = @empmaster and d.idcliente = @idcliente " ;
                }
                if (chaveAcordo>0)
                {
                    strSQL = strSQL + "and p.idacordo = @chaveacordo ";
                }
                
                strSQL = strSQL + " order by p.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", docReceber);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@empmaster", empMaster);
                Sqlcon.Parameters.AddWithValue("@idcliente", idCliente);
                Sqlcon.Parameters.AddWithValue("@codempresa", codempresa);
                Sqlcon.Parameters.AddWithValue("@chaveacordo", chaveAcordo);


                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ReceberParcela> lstRetorno = new List<ReceberParcela>();
                List<ReceberParcela> lstParcela = new List<ReceberParcela>();

                //lstParcela = null;

                
                ReceberParcela oParcela;

                while (drCon.Read())
                {
                    consulta = true;
                    oParcela = new ReceberParcela();

                    oParcela.idReceberParcela = EmcResources.cInt(drCon["idReceberParcela"].ToString());
                    oParcela.codEmpresa = EmcResources.cInt(drCon["empresa_idempresa"].ToString());

                    //receberdocumento
                    ReceberDocumento oReceberDoc = new ReceberDocumento();
                    oReceberDoc.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
                    oParcela.receberDocumento = oReceberDoc;

                    oParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    oParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    oParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    oParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    oParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    oParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    oParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    oParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    oParcela.situacao = drCon["situacao"].ToString();
                    oParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    oParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());

                    oParcela.boleto_NossoNumero = drCon["boleto_nossonumero"].ToString();

                    Formulario oForm = new Formulario();
                    oForm.idFormulario = EmcResources.cInt(drCon["boleto_idformulario"].ToString());
                    oParcela.formulario = oForm;

                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    oParcela.tipoCobranca = oTpCobr;
                    
                    /* Calculo do Juros e Multa */
                    double txaJuros = EmcResources.taxaMensal2Diaria(EmcResources.cDouble(drCon["taxajuros"].ToString()));
                    double txaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString())/100;

                    if (DateTime.Now.Date > oParcela.dataVencimento && oParcela.situacao == "A")
                    {
                        oParcela.multaPrevisto = EmcResources.cCur((EmcResources.cDouble(oParcela.saldoPagar.ToString()) * txaMulta).ToString());
                        oParcela.jurosPrevisto = EmcResources.calculaJurosParcela(Convert.ToDateTime(oParcela.dataVencimento.ToString()), DateTime.Now, oParcela.saldoPagar, txaJuros, tipoJuros);
                    }
                    else
                    {
                        oParcela.jurosPrevisto = 0;
                        oParcela.multaPrevisto = 0;
                    }

                    oParcela.dtaUltCalculoJuros = EmcResources.cDate(drCon["dtaultcalcjuros"].ToString());
                    oParcela.multaAcordo = EmcResources.cCur(drCon["multaacordo"].ToString());
                    oParcela.jurosAcordo = EmcResources.cCur(drCon["jurosacordo"].ToString());
                    oParcela.descontoAcordo = EmcResources.cCur(drCon["descontoacordo"].ToString());
                    oParcela.idAcordo = EmcResources.cInt(drCon["idacordo"].ToString());
                    oParcela.situacaoAcordo = drCon["situacaoacordo"].ToString();
                    oParcela.dataLimiteAcordo = EmcResources.cDate(drCon["datalimiterecebimento"].ToString());

                    lstParcela.Add(oParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (ReceberParcela oRcParcDoc in lstParcela)
                    {
                        ReceberDocumentoDAO oReceberDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oRcParcDoc.receberDocumento = oReceberDocDAO.ObterDocParcela(oRcParcDoc.receberDocumento);

                        FormularioDAO oFormDAO = new FormularioDAO(parConexao, oOcorrencia, codEmpresa);
                        oRcParcDoc.formulario = oFormDAO.ObterPor(oRcParcDoc.formulario);

                        TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                        oRcParcDoc.tipoCobranca = oTpCobrDAO.ObterPor(oRcParcDoc.tipoCobranca);

                        lstRetorno.Add(oRcParcDoc);
                    }
                }
                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Salva as parcelas do contas a receber recebendo também a conexão com o Banco de dados e a transação
        /// </summary>
        /// <param name="oParcela"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public void Salvar(ReceberParcela oParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'receberparcela'"+
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idReceber = 0;
                while (drCon.Read())
                {
                    idReceber = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oParcela.idReceberParcela = idReceber;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oParcela, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into ReceberParcela (empresa_idempresa, idreceberdocumento, datavencimento, dataquitacao, " +
                                                            "valorparcela, saldopagar, saldopago, situacao, boleto_nossonumero,  " +
                                                            "valorjuros, valordesconto, nroparcela,idtipocobranca,cadastro_idusuario, " + 
                                                            "cadastro_datahora, boleto_idformulario, jurosprevisto, multaprevista, " + 
                                                            "dtaultcalcjuros )" +
                                                            "values (@codempresa, @idreceberdocumento, @datavencimento, " +
                                                            "@dataquitacao, @valorparcela, @saldopagar, @saldopago, @situacao, " +
                                                            "@nossonumero, @valorjuros, @valordesconto, @nroparcela, @idtipocobranca, " + 
                                                            "@cadastro_idusuario, @cadastro_datahora, @boleto_idformulario, " + 
                                                            "@jurosprevisto, @multaprevista, @dtaultcalcjuros )";
                MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                SqlconPar.Parameters.AddWithValue("@codempresa", oParcela.codEmpresa);
                SqlconPar.Parameters.AddWithValue("@idreceberdocumento", oParcela.receberDocumento.idReceberDocumento);
                SqlconPar.Parameters.AddWithValue("@datavencimento", oParcela.dataVencimento);
                SqlconPar.Parameters.AddWithValue("@dataquitacao", oParcela.dataQuitacao);
                SqlconPar.Parameters.AddWithValue("@valorparcela", oParcela.valorParcela);
                SqlconPar.Parameters.AddWithValue("@saldopago", oParcela.saldoPago);
                SqlconPar.Parameters.AddWithValue("@saldopagar", oParcela.saldoPagar);
                SqlconPar.Parameters.AddWithValue("@situacao", oParcela.situacao);
                SqlconPar.Parameters.AddWithValue("@nossonumero", oParcela.boleto_NossoNumero);
                SqlconPar.Parameters.AddWithValue("@valorjuros", oParcela.valorJuros);
                SqlconPar.Parameters.AddWithValue("@valordesconto", oParcela.valorDesconto);
                SqlconPar.Parameters.AddWithValue("@nroparcela", oParcela.nroParcela);
                SqlconPar.Parameters.AddWithValue("@idtipocobranca", oParcela.tipoCobranca.idTipoCobranca);
                SqlconPar.Parameters.AddWithValue("@cadastro_idusuario", oParcela.cadastro_idusuario);
                SqlconPar.Parameters.AddWithValue("@cadastro_datahora", oParcela.cadastro_datahora);
                if (oParcela.formulario.idFormulario>0)
                    SqlconPar.Parameters.AddWithValue("@boleto_idformulario", oParcela.formulario.idFormulario);
                else
                    SqlconPar.Parameters.AddWithValue("@boleto_idformulario", null);
                SqlconPar.Parameters.AddWithValue("@jurosprevisto", oParcela.jurosPrevisto);
                SqlconPar.Parameters.AddWithValue("@multaprevista", oParcela.multaPrevisto);
                SqlconPar.Parameters.AddWithValue("@dtaultcalcjuros", oParcela.dtaUltCalculoJuros);
                //abre conexao e executa o comando
                SqlconPar.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        /// <summary>
        /// Atualiza as parcelas do contas a receber recebendo também a conexão com o Banco de dados e a transação
        /// </summary>
        /// <param name="oParcela"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public void Atualizar(ReceberParcela oParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //atualiza um registro de ReceberParcela
            try
            {
                geraOcorrencia(oParcela, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update ReceberParcela set datavencimento=@datavencimento, " +
                                                         " valorparcela=@valorparcela, " +
                                                         " situacao=@situacao, " +
                                                         " nroparcela=@nroparcela, idtipocobranca=@idtipocobranca, " +
                                                         " cadastro_idusuario=@cadastro_usuario, cadastro_datahora=@cadastro_datahora, " +
                                                         " saldopagar=@saldopagar, " +
                                                         " jurosprevisto=@jurosprevisto, multaprevista=@multaprevista, " +
                                                         " dtaultcalcjuros=@dtaultcalcjuros " +
                                                         " where idreceberParcela = @idReceberParcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idReceberParcela", oParcela.idReceberParcela);
                Sqlcon.Parameters.AddWithValue("@codempresa", oParcela.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datavencimento", oParcela.dataVencimento);
                //Sqlcon.Parameters.AddWithValue("@dataquitacao", objReceberParcela.dataQuitacao);
                Sqlcon.Parameters.AddWithValue("@valorparcela", oParcela.valorParcela);
                //Sqlcon.Parameters.AddWithValue("@saldopago", objReceberParcela.saldoPago);
                Sqlcon.Parameters.AddWithValue("@saldopagar", oParcela.saldoPagar);
                Sqlcon.Parameters.AddWithValue("@situacao", oParcela.situacao);
                //Sqlcon.Parameters.AddWithValue("@valorjuros", objReceberParcela.valorJuros);
                //Sqlcon.Parameters.AddWithValue("@valordesconto", objReceberParcela.valorDesconto);
                Sqlcon.Parameters.AddWithValue("@nroparcela", oParcela.nroParcela);
                Sqlcon.Parameters.AddWithValue("@idtipocobranca", oParcela.tipoCobranca.idTipoCobranca);
                Sqlcon.Parameters.AddWithValue("@cadastro_usuario", oParcela.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oParcela.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@jurosprevisto", oParcela.jurosPrevisto);
                Sqlcon.Parameters.AddWithValue("@multaprevista", oParcela.multaPrevisto);
                Sqlcon.Parameters.AddWithValue("@dtaultcalcjuros", oParcela.dtaUltCalculoJuros);
                
                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            
        }
        /// <summary>
        /// Atualiza os saldos da parcela de acordo com a baixa realizada
        /// </summary>
        /// <param name="oBaixa"></param>
        public void atualizaSaldos(ReceberBaixa oBaixa, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            //atualiza um registro de ReceberParcela
            try
            {
                String situacaoParcela = "A";
                DateTime? dataQuitacao = null;
                if ((oBaixa.receberParcela.saldoPagar - oBaixa.valorBaixa) == 0)
                {
                    situacaoParcela = "P";
                    dataQuitacao = oBaixa.dataPagamento;
                    oBaixa.receberParcela.dataQuitacao = dataQuitacao;
                    oBaixa.receberParcela.situacao = situacaoParcela;
                }

                oBaixa.receberParcela.dataQuitacao = dataQuitacao;
                oBaixa.receberParcela.situacao = situacaoParcela;
                oBaixa.receberParcela.saldoPago = (oBaixa.receberParcela.saldoPago + oBaixa.valorBaixa);
                oBaixa.receberParcela.saldoPagar = (oBaixa.receberParcela.saldoPagar-oBaixa.valorBaixa);
                oBaixa.receberParcela.valorJuros = (oBaixa.receberParcela.valorJuros+oBaixa.valorJuros);
                oBaixa.receberParcela.valorDesconto = (oBaixa.receberParcela.valorDesconto+oBaixa.valorDesconto);

                geraOcorrencia(oBaixa.receberParcela, "SDO");
                
                //Monta comando para a gravação do registro
                String strSQL = "update ReceberParcela set dataquitacao=@dataquitacao, situacao=@situacao, " +
                                                         " saldopagar=@saldopagar, saldopago=@saldopago, " +
                                                         " valorjuros=@valorjuros, valordesconto=@valordesconto " +
                                                         " where idReceberParcela = @idReceberParcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@saldopago", oBaixa.receberParcela.saldoPago );
                Sqlcon.Parameters.AddWithValue("@saldopagar", oBaixa.receberParcela.saldoPagar);
                Sqlcon.Parameters.AddWithValue("@valorjuros", oBaixa.receberParcela.valorJuros);
                Sqlcon.Parameters.AddWithValue("@valordesconto", oBaixa.receberParcela.valorDesconto);
                Sqlcon.Parameters.AddWithValue("@dataquitacao", dataQuitacao);
                Sqlcon.Parameters.AddWithValue("@situacao", situacaoParcela);
                Sqlcon.Parameters.AddWithValue("@idReceberParcela", oBaixa.receberParcela.idReceberParcela);

                Sqlcon.ExecuteNonQuery();

                if (verificaSituacaoDocumento( oBaixa, Conecta, Transacao))
                {
                    ReceberDocumentoDAO oRcDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    oRcDocDAO.alteraSitucao(Conecta, Transacao, oBaixa.receberParcela.receberDocumento, "P");
                }

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Atualiza numero da Fatura da parcela de acordo com a baixa realizada
        /// </summary>
        /// <param name="oBaixa"></param>
        public void atualizaFatura(ReceberBaixa oBaixa, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            //atualiza um registro de PagarParcela
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "update ReceberParcela set receberfatura_idreceberfatura=@idfatura " +
                                                         " where idreceberParcela = @idReceberParcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@idfatura", oBaixa.receberParcela.idreceberfatura);
                Sqlcon.Parameters.AddWithValue("@idReceberParcela", oBaixa.receberParcela.idReceberParcela);

                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void atualizaAcordo(ReceberParcela oParcela, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            //atualiza um registro de PagarParcela
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "update ReceberParcela set idacordo=@idacordo, " +
                                                         " jurosacordo=@jurosacordo, " +
                                                         " multaacordo=@multaacordo, " +
                                                         " descontoacordo=@descontoacordo, " +
                                                         " jurosoriginal=@jurosoriginal, " +
                                                         " multaoriginal=@multaoriginal, " +
                                                         " descontooriginal=@descontooriginal " +
                                                " where idreceberParcela = @idReceberParcela and situacao = 'A'";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@idReceberParcela", oParcela.idReceberParcela);
                Sqlcon.Parameters.AddWithValue("@jurosacordo", oParcela.jurosAcordo);
                Sqlcon.Parameters.AddWithValue("@multaacordo", oParcela.multaAcordo);
                Sqlcon.Parameters.AddWithValue("@descontoacordo", oParcela.descontoAcordo);
                Sqlcon.Parameters.AddWithValue("@jurosoriginal", oParcela.jurosOriginal);
                Sqlcon.Parameters.AddWithValue("@multaoriginal", oParcela.multaOriginal);
                Sqlcon.Parameters.AddWithValue("@descontooriginal", oParcela.descontoOriginal);
                if (oParcela.idAcordo > 0)
                    Sqlcon.Parameters.AddWithValue("@idacordo", oParcela.idAcordo);
                else
                    Sqlcon.Parameters.AddWithValue("@idacordo", null);



                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Verifica se todas as parcelas estão quitadas para alterar a situação do documento
        /// </summary>
        /// <param name="objBaixa"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public bool verificaSituacaoDocumento(ReceberBaixa oBaixa, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            bool quitado = true;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberParcela Where idreceberdocumento = @idreceberdocumento and situacao = 'A' ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", oBaixa.receberParcela.receberDocumento.idReceberDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    quitado = false;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return quitado;
        }
        /// <summary>
        /// Exclui as parcelas do contas a receber recebendo também a conexão com o Banco de dados e a transação
        /// </summary>
        /// <param name="oParcela"></param>
        /// <param name="Conexao"></param>
        /// <param name="transacao"></param>
        public void Excluir(ReceberParcela oParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //apaga registro de ReceberParcela
            try
            {

                geraOcorrencia(oParcela, "E");

                // antes de excluir a parcela verifica se existe integração nivel parcela.
                if (oParcela.receberDocumento.origemDocumento != "CTARECEBER")
                {
                    IntegFinanceiro oIntegFinanceiro = new IntegFinanceiro();
                    IntegFinanceiroDAO oIntegFinanceiroDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);

                    if (oParcela.receberDocumento.origemDocumento == "EMCIMOB")
                    {
                        var idReceberParcela = EmcResources.cInt(oParcela.idReceberParcela.ToString());

                        oIntegFinanceiro = oIntegFinanceiroDAO.ObterPorReceberParcela(idReceberParcela);
                        oIntegFinanceiro.statusOperacao = "E";

                        oIntegFinanceiroDAO.Salvar(oIntegFinanceiro, Conexao, transacao);
                    }

                }

                //Monta comando para a gravação do registro
                String strSQL = "delete from receberparcela where idreceberparcela = @idreceberparcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idreceberparcela", oParcela.idReceberParcela);

                Sqlcon.ExecuteNonQuery();

                


                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        /// <summary>
        /// Lista as parcelas do contas a receber retornando um datatable
        /// </summary>
        /// <param name="oParcela"></param>
        /// <returns></returns>
        public DataTable ListaReceberParcela(ReceberParcela oParcela)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberParcela where idreceberdocumento=@idreceberdocumento order by nroparcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", oParcela.receberDocumento.idReceberDocumento);

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
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas para montagem de uma fatura
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <param name="DataInicio"></param>
        /// <param name="Datafinal"></param>
        /// <param name="todosValores"></param>
        /// <returns></returns>
        public List<ReceberParcela> listaReceberFatura(int idUsuario, int codempresa, int empmaster, int idCliente, DateTime? dataInicio, DateTime? dataFinal, bool todos)
        {

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberParcela p, receberdocumento d " +
                                " where d.idreceberdocumento = p.idreceberdocumento and p.situacao='A' ";

                if (!todos)
                {
                    strSQL = strSQL + "and p.datavencimento >= @datainicio and p.datavencimento <= @datafinal ";
                }
                if (idCliente > 0)
                {
                    strSQL = strSQL + "and d.cliente_codempresa = @empmaster and d.idcliente = @idcliente ";
                }

                strSQL = strSQL + " order by p.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@empmaster", empmaster);
                Sqlcon.Parameters.AddWithValue("@idcliente", idCliente);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ReceberParcela> lstParcela = new List<ReceberParcela>();
                List<ReceberParcela> lstRetorno = new List<ReceberParcela>();

                while (drCon.Read())
                {

                    ReceberParcela objReceberParcela = new ReceberParcela();

                    objReceberParcela.idReceberParcela = EmcResources.cInt(drCon["idReceberParcela"].ToString());

                    lstParcela.Add(objReceberParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                foreach (ReceberParcela oParc in lstParcela)
                {
                    lstRetorno.Add(ObterPor(oParc));
                }


                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas pertencentes a uma fatura
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <param name="DataInicio"></param>
        /// <param name="Datafinal"></param>
        /// <param name="todosValores"></param>
        /// <returns></returns>
        public List<ReceberParcela> listaParcelasFatura(int idReceberFatura)
        {

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberParcela p where p.receberfatura_idreceberfatura=@idfatura ";
                strSQL = strSQL + " order by p.datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idfatura", idReceberFatura);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ReceberParcela> lstParcela = new List<ReceberParcela>();
                List<ReceberParcela> lstRetorno = new List<ReceberParcela>();
                //lstParcela = null

                while (drCon.Read())
                {

                    ReceberParcela objReceberParcela = new ReceberParcela();

                    objReceberParcela.idReceberParcela = EmcResources.cInt(drCon["idreceberparcela"].ToString());

                    lstParcela.Add(objReceberParcela);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                foreach (ReceberParcela oParc in lstParcela)
                {
                    lstRetorno.Add(ObterPor(oParc));
                }

                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Retorna uma lista "List" das parcelas a receber
        /// </summary>
        /// <param name="oParcela"></param>
        /// <returns></returns>
        public List<ReceberParcela> ParcelaDocumento(ReceberParcela oParcela)
        {
            bool consulta = false;
            try
            {
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao, oOcorrencia, codEmpresa);
                tipoJuros = oParametroDAO.retParametro(codEmpresa, "EMCFINANCEIRO", "CTARECEBER", "TIPO_JUROS");

               
                //Monta comando para a gravação do registro
                String strSQL = "select r.*, d.taxajuros, d.taxamulta, a.situacao as situacaoacordo, a.datalimiterecebimento " +
                                "from ReceberParcela r left join receberdocumento d on d.idreceberdocumento = r.idreceberdocumento  " +
                                                      " left join receberacordo a on a.idacordo = r.idacordo " +
                                "Where r.idReceberDocumento=@idReceberDocumento order by r.nroparcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberDocumento", oParcela.receberDocumento.idReceberDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();
                
                List<ReceberParcela> lstParcela = new List<ReceberParcela>();
                List<ReceberParcela> lstRetorno = new List<ReceberParcela>();

                //lstParcela = null;

                ReceberDocumento oReceberDoc = new ReceberDocumento();
                ReceberParcela objReceberParcela;
                
                while (drCon.Read())
                {
                    consulta = true;
                    objReceberParcela = new ReceberParcela();

                    objReceberParcela.idReceberParcela = EmcResources.cInt(drCon["idReceberParcela"].ToString());
                    objReceberParcela.codEmpresa = EmcResources.cInt(drCon["empresa_idempresa"].ToString());
                    
                    oReceberDoc.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
                    objReceberParcela.receberDocumento = oReceberDoc;

                    objReceberParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objReceberParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objReceberParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objReceberParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objReceberParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objReceberParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objReceberParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objReceberParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objReceberParcela.situacao = drCon["situacao"].ToString();
                    objReceberParcela.boleto_NossoNumero = drCon["boleto_nossonumero"].ToString();

                    Formulario oForm = new Formulario();
                    if (!String.IsNullOrEmpty(drCon["boleto_idformulario"].ToString()))
                        oForm.idFormulario = EmcResources.cInt(drCon["boleto_idformulario"].ToString());
                    else
                        oForm.idFormulario = 0;
                    objReceberParcela.formulario = oForm;

                    objReceberParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objReceberParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    
                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objReceberParcela.tipoCobranca = oTpCobr;

                    /* Calculo do Juros e Multa */
                    
                    double txaJuros = Math.Abs(EmcResources.taxaMensal2Diaria(EmcResources.cDouble(drCon["taxajuros"].ToString())));
                    double txaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString()) / 100;

                    if (DateTime.Now > objReceberParcela.dataVencimento && objReceberParcela.situacao == "A")
                    {
                        objReceberParcela.multaPrevisto = EmcResources.cCur((EmcResources.cDouble(objReceberParcela.saldoPagar.ToString()) * txaMulta).ToString());
                        objReceberParcela.jurosPrevisto = EmcResources.calculaJurosParcela(Convert.ToDateTime(objReceberParcela.dataVencimento.ToString()), DateTime.Now, objReceberParcela.saldoPagar, txaJuros, tipoJuros);
                    }
                    else
                    {
                        objReceberParcela.jurosPrevisto = 0;
                        objReceberParcela.multaPrevisto = 0;
                    }

                    objReceberParcela.dtaUltCalculoJuros = EmcResources.cDate(drCon["dtaultcalcjuros"].ToString());
                    oParcela.multaAcordo = EmcResources.cCur(drCon["multaacordo"].ToString());
                    oParcela.jurosAcordo = EmcResources.cCur(drCon["jurosacordo"].ToString());
                    oParcela.descontoAcordo = EmcResources.cCur(drCon["descontoacordo"].ToString());
                    oParcela.idAcordo = EmcResources.cInt(drCon["idacordo"].ToString());
                    oParcela.situacaoAcordo = drCon["situacaoacordo"].ToString();
                    oParcela.dataLimiteAcordo = EmcResources.cDate(drCon["datalimiterecebimento"].ToString());


                    lstParcela.Add(objReceberParcela);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (ReceberParcela oRcParcDoc in lstParcela)
                    {
                        ReceberDocumentoDAO oReceberDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                        oRcParcDoc.receberDocumento = oReceberDocDAO.ObterDocParcela(oRcParcDoc.receberDocumento);

                        TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                        oRcParcDoc.tipoCobranca = oTpCobrDAO.ObterPor(oRcParcDoc.tipoCobranca);

                        if ( EmcResources.cInt(oRcParcDoc.formulario.idFormulario.ToString() ) > 0)
                        {
                            FormularioDAO oFormDAO = new FormularioDAO(parConexao, oOcorrencia, codEmpresa);
                            oRcParcDoc.formulario = oFormDAO.ObterPor(oRcParcDoc.formulario);
                        }
                        lstRetorno.Add(oRcParcDoc);
                    }
                }

                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        /// <summary>
        /// Busca uma parcela especifica retornando um objeto tipo ReceberParcela
        /// </summary>
        /// <param name="oReceberParcela"></param>
        /// <returns></returns>
        public ReceberParcela ObterPor(string nroDocumento, int nroParcela, int codEmpresa)
        {
            bool consulta = false;
            try
            {
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao, oOcorrencia, codEmpresa);
                tipoJuros = oParametroDAO.retParametro(codEmpresa, "EMCFINANCEIRO", "CTARECEBER", "TIPO_JUROS");

                ReceberDocumento oPgDoc = new ReceberDocumento();
                oPgDoc.nroDocumento = nroDocumento;
                oPgDoc.codEmpresa = codEmpresa;

                ReceberDocumentoDAO oPgDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                oPgDoc = oPgDAO.ObterPor(oPgDoc);

                //Monta comando para a gravação do registro
                String strSQL = "select r.*, d.taxajuros, d.taxamulta, a.situacao as situacaoacordo, a.datalimiterecebimento " +
                                "from ReceberParcela r left join receberdocumento d on d.idreceberdocumento = r.idreceberdocumento  " +
                                                     " left join receberacordo a on a.idacordo = r.idacordo " +
                                " Where idreceberdocumento=@idreceberdocumento and nroparcela=@nroparcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", oPgDoc.idReceberDocumento);
                Sqlcon.Parameters.AddWithValue("@nroparcela", nroParcela);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                ReceberDocumento oReceberDoc = new ReceberDocumento();

                ReceberParcela objReceberParcela = new ReceberParcela();

                while (drCon.Read())
                {
                    consulta = true;
                    objReceberParcela.idReceberParcela = EmcResources.cInt(drCon["idReceberParcela"].ToString());
                    objReceberParcela.codEmpresa = EmcResources.cInt(drCon["empresa_idempresa"].ToString());


                    oReceberDoc.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
                    objReceberParcela.receberDocumento = oReceberDoc;

                    objReceberParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objReceberParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objReceberParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objReceberParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objReceberParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objReceberParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objReceberParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objReceberParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objReceberParcela.situacao = drCon["situacao"].ToString();
                    objReceberParcela.boleto_NossoNumero = drCon["boleto_nossonumero"].ToString();

                    Formulario oForm = new Formulario();
                    oForm.idFormulario = EmcResources.cInt(drCon["boleto_idformulario"].ToString());
                    objReceberParcela.formulario = oForm;

                    objReceberParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objReceberParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());


                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objReceberParcela.tipoCobranca = oTpCobr;

                    /* Calculo do Juros e Multa */

                    double txaJuros = Math.Abs(EmcResources.taxaMensal2Diaria(EmcResources.cDouble(drCon["taxajuros"].ToString())));
                    double txaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString()) / 100;

                    if (DateTime.Now.Date > objReceberParcela.dataVencimento && objReceberParcela.situacao == "A")
                    {
                        objReceberParcela.multaPrevisto = EmcResources.cCur((EmcResources.cDouble(objReceberParcela.saldoPagar.ToString()) * txaMulta).ToString());
                        objReceberParcela.jurosPrevisto = EmcResources.calculaJurosParcela(Convert.ToDateTime(objReceberParcela.dataVencimento.ToString()), DateTime.Now, objReceberParcela.saldoPagar, txaJuros, tipoJuros);
                    }
                    else
                    {
                        objReceberParcela.jurosPrevisto = 0;
                        objReceberParcela.multaPrevisto = 0;
                    }

                    objReceberParcela.dtaUltCalculoJuros = EmcResources.cDate(drCon["dtaultcalcjuros"].ToString());
                    objReceberParcela.multaAcordo = EmcResources.cCur(drCon["multaacordo"].ToString());
                    objReceberParcela.jurosAcordo = EmcResources.cCur(drCon["jurosacordo"].ToString());
                    objReceberParcela.descontoAcordo = EmcResources.cCur(drCon["descontoacordo"].ToString());
                    objReceberParcela.idAcordo = EmcResources.cInt(drCon["idacordo"].ToString());
                    objReceberParcela.situacaoAcordo = drCon["situacaoacordo"].ToString();
                    objReceberParcela.dataLimiteAcordo = EmcResources.cDate(drCon["datalimiterecebimento"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ReceberDocumentoDAO oReceberDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.receberDocumento = oReceberDocDAO.ObterDocParcela(objReceberParcela.receberDocumento);

                    TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.tipoCobranca = oTpCobrDAO.ObterPor(objReceberParcela.tipoCobranca);

                    FormularioDAO oFormDAO = new FormularioDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.formulario = oFormDAO.ObterPor(objReceberParcela.formulario);

                    //busca as baixas da parcela
                    ReceberBaixaDAO oBaixaDAO = new ReceberBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.baixas = oBaixaDAO.listaBaixasParcela(objReceberParcela.idReceberParcela);
                }
                return objReceberParcela;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        /// <summary>
        /// Busca uma parcela especifica retornando um objeto tipo ReceberParcela
        /// </summary>
        /// <param name="oReceberParcela"></param>
        /// <returns></returns>
        public ReceberParcela ObterPor(ReceberParcela oReceberParcela)
        {
            bool consulta = false;
            try
            {
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao, oOcorrencia, codEmpresa);
                tipoJuros = oParametroDAO.retParametro(codEmpresa, "EMCFINANCEIRO", "CTARECEBER", "TIPO_JUROS");

                //Monta comando para a gravação do registro
                String strSQL = "select r.*, d.taxajuros, d.taxamulta, a.situacao as situacaoacordo, a.datalimiterecebimento " +
                                "from ReceberParcela r left join receberdocumento d on d.idreceberdocumento = r.idreceberdocumento  " +
                                                     " left join receberacordo a on a.idacordo = r.idacordo " +
                                "Where r.idReceberParcela = @idReceberParcela ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberParcela", oReceberParcela.idReceberParcela);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                ReceberDocumento oReceberDoc = new ReceberDocumento();
                
                ReceberParcela objReceberParcela = new ReceberParcela();

                while (drCon.Read())
                {
                    consulta = true;
                    objReceberParcela.idReceberParcela = EmcResources.cInt(drCon["idReceberParcela"].ToString());
                    objReceberParcela.codEmpresa = EmcResources.cInt(drCon["empresa_idempresa"].ToString());


                    oReceberDoc.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
                    objReceberParcela.receberDocumento = oReceberDoc;

                    objReceberParcela.dataVencimento = EmcResources.cDate(drCon["datavencimento"].ToString());
                    objReceberParcela.dataQuitacao = EmcResources.cDate(drCon["dataquitacao"].ToString());

                    objReceberParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objReceberParcela.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    objReceberParcela.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    objReceberParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objReceberParcela.saldoPagar = EmcResources.cCur(drCon["saldopagar"].ToString());
                    objReceberParcela.saldoPago = EmcResources.cCur(drCon["saldopago"].ToString());
                    objReceberParcela.situacao = drCon["situacao"].ToString();
                    objReceberParcela.boleto_NossoNumero = drCon["boleto_nossonumero"].ToString();

                    Formulario oForm = new Formulario();
                    oForm.idFormulario = EmcResources.cInt(drCon["boleto_idformulario"].ToString());
                    objReceberParcela.formulario = oForm;

                    objReceberParcela.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objReceberParcela.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    
                    
                    TipoCobranca oTpCobr = new TipoCobranca();
                    oTpCobr.idTipoCobranca = EmcResources.cInt(drCon["idtipocobranca"].ToString());
                    objReceberParcela.tipoCobranca = oTpCobr;

                    /* Calculo do Juros e Multa */
       
                    double txaJuros = Math.Abs(EmcResources.taxaMensal2Diaria(EmcResources.cDouble(drCon["taxajuros"].ToString())));
                    double txaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString()) / 100;

                    if (DateTime.Now.Date > objReceberParcela.dataVencimento && objReceberParcela.situacao == "A")
                    {
                        objReceberParcela.multaPrevisto = EmcResources.cCur((EmcResources.cDouble(objReceberParcela.saldoPagar.ToString()) * txaMulta).ToString());
                        objReceberParcela.jurosPrevisto = EmcResources.calculaJurosParcela(Convert.ToDateTime(objReceberParcela.dataVencimento.ToString()), DateTime.Now, objReceberParcela.saldoPagar, txaJuros, tipoJuros);
                    }
                    else
                    {
                        objReceberParcela.jurosPrevisto = 0;
                        objReceberParcela.multaPrevisto = 0;
                    }

                    objReceberParcela.dtaUltCalculoJuros = EmcResources.cDate(drCon["dtaultcalcjuros"].ToString());
                    objReceberParcela.multaAcordo = EmcResources.cCur(drCon["multaacordo"].ToString());
                    objReceberParcela.jurosAcordo = EmcResources.cCur(drCon["jurosacordo"].ToString());
                    objReceberParcela.descontoAcordo = EmcResources.cCur(drCon["descontoacordo"].ToString());
                    objReceberParcela.idAcordo = EmcResources.cInt(drCon["idacordo"].ToString());
                    objReceberParcela.situacaoAcordo = drCon["situacaoacordo"].ToString();
                    objReceberParcela.dataLimiteAcordo = EmcResources.cDate(drCon["datalimiterecebimento"].ToString());
    
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                if (consulta)
                {
                    ReceberDocumentoDAO oReceberDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.receberDocumento = oReceberDocDAO.ObterDocParcela(objReceberParcela.receberDocumento);

                    TipoCobrancaDAO oTpCobrDAO = new TipoCobrancaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.tipoCobranca = oTpCobrDAO.ObterPor(objReceberParcela.tipoCobranca);

                    if (!String.IsNullOrEmpty(objReceberParcela.formulario.idFormulario.ToString()))
                    {
                        FormularioDAO oFormDAO = new FormularioDAO(parConexao, oOcorrencia, codEmpresa);
                        objReceberParcela.formulario = oFormDAO.ObterPor(objReceberParcela.formulario);
                    }

                    //busca as baixas da parcela
                    ReceberBaixaDAO oBaixaDAO = new ReceberBaixaDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberParcela.baixas = oBaixaDAO.listaBaixasParcela(objReceberParcela.idReceberParcela);
                }
                return objReceberParcela;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
          
        }

        public void estornaValidadeAcordo(ReceberParcela oParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //estorna id do acordo de parcela já recebidas
            //apaga registro de CEP
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update receberparcela set idacordo=null where idreceberparcela = @idparcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idparcela", oParcela.idReceberParcela);
                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        /// <summary>
        /// Gera uma ocorrencia de alteração, inclusão ou atualização para receberParcela
        /// </summary>
        /// <param name="oReceberParcela"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private void geraOcorrencia(ReceberParcela oReceberParcela, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oReceberParcela.receberDocumento.idReceberDocumento.ToString();

                if (flag == "A")
                {

                    ReceberParcela oRcParcela = new ReceberParcela();
                    oRcParcela = ObterPor(oReceberParcela);

                    if (!oRcParcela.Equals(oReceberParcela))
                    {
                        descricao = "Parcela id: " + oReceberParcela.idReceberParcela + " Nro documento :" + oReceberParcela.receberDocumento.idReceberDocumento + " Nro Parcela : " + oReceberParcela.nroParcela + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oRcParcela.dataVencimento.Equals(oReceberParcela.dataVencimento))
                        {
                            descricao += " Data Vencimento de " + oRcParcela.dataVencimento + " para " + oReceberParcela.dataVencimento;
                        }
                        if (!oRcParcela.dataQuitacao.Equals(oReceberParcela.dataQuitacao))
                        {
                            descricao += " Data Quitação de " + oRcParcela.dataQuitacao + " para " + oReceberParcela.dataQuitacao;
                        }
                        if (!oRcParcela.valorParcela.Equals(oReceberParcela.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oRcParcela.valorParcela + " para " + oReceberParcela.valorParcela;
                        }
                        if (!oRcParcela.saldoPagar.Equals(oReceberParcela.saldoPagar))
                        {
                            descricao += " Saldo Pagar de " + oRcParcela.saldoPagar + " para " + oReceberParcela.saldoPagar;
                        }
                        if (!oRcParcela.saldoPago.Equals(oReceberParcela.saldoPago))
                        {
                            descricao += " Saldo Pago de " + oRcParcela.saldoPago + " para " + oReceberParcela.saldoPago;
                        }
                        if (!oRcParcela.situacao.Equals(oReceberParcela.situacao))
                        {
                            descricao += " Situação de " + oRcParcela.situacao + " para " + oReceberParcela.situacao;
                        }
                        if (!oRcParcela.boleto_NossoNumero.Equals(oReceberParcela.boleto_NossoNumero))
                        {
                            descricao += " Nosso Numero de " + oRcParcela.boleto_NossoNumero + " para " + oReceberParcela.boleto_NossoNumero;
                        }
                        if (!oRcParcela.formulario.idFormulario.Equals(oReceberParcela.formulario.idFormulario))
                        {
                            descricao += " id Formulario de " + oRcParcela.formulario.idFormulario + " para " + oReceberParcela.formulario.idFormulario;
                        }
                        if (!oRcParcela.valorJuros.Equals(oReceberParcela.valorJuros))
                        {
                            descricao += " Juros de " + oRcParcela.valorJuros + " para " + oReceberParcela.valorJuros;
                        }
                        if (!oRcParcela.valorDesconto.Equals(oReceberParcela.valorDesconto))
                        {
                            descricao += " Valor Desconto de " + oRcParcela.valorDesconto + " para " + oReceberParcela.valorDesconto;
                        }
                        if (!oRcParcela.tipoCobranca.Equals(oReceberParcela.tipoCobranca))
                        {
                            descricao += " Tipo de Cobrança  de " + oRcParcela.tipoCobranca.idTipoCobranca + "-" + oRcParcela.tipoCobranca.descricao + 
                                         " para " + oReceberParcela.tipoCobranca.idTipoCobranca+"-"+oReceberParcela.tipoCobranca.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Parcela Pagar id : " + oReceberParcela.idReceberParcela +
                                " - CodEmpresa - " + oReceberParcela.codEmpresa +
                                " - Documento - " + oReceberParcela.receberDocumento.idReceberDocumento +
                                " - Nro Parcela - " + oReceberParcela.nroParcela +
                                " - Data Vencimento - " + oReceberParcela.dataVencimento +
                                " - Data Quitação - " + oReceberParcela.dataQuitacao +
                                " - Valor Parcela - " + oReceberParcela.valorParcela +
                                " - Valor Desconto - " + oReceberParcela.valorDesconto +
                                " - Valor Juros - " + oReceberParcela.valorJuros +
                                " - Saldo Pagar - " + oReceberParcela.saldoPagar +
                                " - Saldo Pago - " + oReceberParcela.saldoPago +
                                " - Situação - " + oReceberParcela.situacao +
                                " - Nosso Numero - " + oReceberParcela.boleto_NossoNumero +
                                " - id Formulario - " + oReceberParcela.formulario.idFormulario +
                                " - Tipo cobrança  - " + oReceberParcela.tipoCobranca.idTipoCobranca + "-" + oReceberParcela.tipoCobranca.descricao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Parcela Pagar id : " + oReceberParcela.idReceberParcela +
                                " - CodEmpresa - " + oReceberParcela.codEmpresa +
                                " - Documento - " + oReceberParcela.receberDocumento.idReceberDocumento +
                                " - Nro Parcela - " + oReceberParcela.nroParcela +
                                " - Data Vencimento - " + oReceberParcela.dataVencimento +
                                " - Data Quitação - " + oReceberParcela.dataQuitacao +
                                " - Valor Parcela - " + oReceberParcela.valorParcela +
                                " - Valor Desconto - " + oReceberParcela.valorDesconto +
                                " - Valor Juros - " + oReceberParcela.valorJuros +
                                " - Saldo Pagar - " + oReceberParcela.saldoPagar +
                                " - Saldo Pago - " + oReceberParcela.saldoPago +
                                " - Situação - " + oReceberParcela.situacao +
                                " - Nosso Numero - " + oReceberParcela.boleto_NossoNumero +
                                " - id Formulario - " + oReceberParcela.formulario.idFormulario +
                                " - Tipo cobrança  - " + oReceberParcela.tipoCobranca.idTipoCobranca + "-" + oReceberParcela.tipoCobranca.descricao +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "LIB")
                {

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
        /// <summary>
        /// Calcula Saldo Devedor para um cliente
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public decimal calculaSaldoDevedor(int codCliente)
        {
            decimal saldo=0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from ReceberParcela pc, receberdocumento d " + 
                                " where pc.empresa_idempresa=@codempresa " + 
                                "   and d.idreceberdocumento = pc.idreceberdocumento and d.idcliente = @idcliente";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", codCliente);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Devedor em atraso para um Cliente
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public decimal calculaSaldoAtraso(int codCliente)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where pc.empresa_idempresa=@codempresa " + 
                                "   and d.idreceberdocumento = pc.idreceberdocumento and d.idcliente = @idcliente" + 
                                "   and pc.datavencimento < @datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", codCliente);
                Sqlcon.Parameters.AddWithValue("@datavencimento", DateTime.Now);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Vencendo em 30 dias para um cliente
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public decimal calculaVencimento30Dias(int codCliente)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where pc.empresa_idempresa=@codempresa " + 
                                "   and d.idreceberdocumento = pc.idreceberdocumento and d.idcliente = @idcliente" +
                                "   and pc.datavencimento >= @inicioperiodo and pc.datavencimento <= @finalperiodo ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", codCliente);
                Sqlcon.Parameters.AddWithValue("@inicioperiodo", DateTime.Now);
                Sqlcon.Parameters.AddWithValue("@finalperiodo", DateTime.Now.AddDays(30));

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Devedor em atraso para um cliente
        /// </summary>
        /// <param name="codCliente"></param>
        /// <returns></returns>
        public decimal calculaSdoVencimentoUp30Dias(int codCliente)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where pc.empresa_idempresa=@codempresa " + 
                                "   and d.idreceberdocumento = pc.idreceberdocumento and d.idcliente = @idcliente" +
                                "   and pc.datavencimento > @datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", codCliente);
                Sqlcon.Parameters.AddWithValue("@datavencimento", DateTime.Now.AddDays(30));

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Documento
        /// </summary>
        /// <param name="idreceberdocumento"></param>
        /// <returns></returns>
        public decimal calculaDocParcela(int idreceberdocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valorparcela) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where d.idreceberdocumento = pc.idreceberdocumento and pc.idreceberdocumento = @idreceberdocumento"; 
                                

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idreceberdocumento);
                

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Descontos Documento
        /// </summary>
        /// <param name="idreceberdocumento"></param>
        /// <returns></returns>
        public decimal calculaDocDesconto(int idreceberdocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valordesconto) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where d.idreceberdocumento = pc.idreceberdocumento and pc.idreceberdocumento = @idreceberdocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idreceberdocumento);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Juros Documento
        /// </summary>
        /// <param name="idreceberdocumento"></param>
        /// <returns></returns>
        public decimal calculaDocJuros(int idreceberdocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(valorjuros) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where d.idreceberdocumento = pc.idreceberdocumento and pc.idreceberdocumento = @idreceberdocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idreceberdocumento);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Pago Documento
        /// </summary>
        /// <param name="idreceberdocumento"></param>
        /// <returns></returns>
        public decimal calculaDocSdoPago(int idreceberdocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopago) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where d.idreceberdocumento = pc.idreceberdocumento and pc.idreceberdocumento = @idreceberdocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idreceberdocumento);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Descontos Documento
        /// </summary>
        /// <param name="idreceberdocumento"></param>
        /// <returns></returns>
        public decimal calculaDocSdoPagar(int idreceberdocumento)
        {
            decimal saldo = 0;
            try
            {
                string strSQL = "select sum(saldopagar) as saldopagar from ReceberParcela pc, receberdocumento d " +
                                " where d.idreceberdocumento = pc.idreceberdocumento and pc.idreceberdocumento = @idreceberdocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idreceberdocumento);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    saldo = EmcResources.cCur(drCon["saldopagar"].ToString());
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return saldo;
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
