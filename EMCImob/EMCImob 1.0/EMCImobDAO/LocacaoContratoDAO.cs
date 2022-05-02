using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCCadastroDAO;
using EMCCadastroModel;

namespace EMCImobDAO
{
    public class LocacaoContratoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoContratoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
            }
            codEmpresa = idEmpresa;
        }

        public List<LocacaoContrato> lstLocacaoContrato()
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoContrato";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                //Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoContrato> lstLocacaoContrato = new List<LocacaoContrato>();
                List<LocacaoContrato> lstRetorno = new List<LocacaoContrato>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoContrato oLocContrato = new LocacaoContrato();

                    oLocContrato.idLocacaoContrato = EmcResources.cInt(drCon["idLocacaoContrato"].ToString());

                    lstLocacaoContrato.Add(oLocContrato);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoContrato oContrato in lstLocacaoContrato)
                    {
                        LocacaoContrato oRec = new LocacaoContrato();
                        oRec = ObterPor(oContrato);

                        lstRetorno.Add(oRec);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(LocacaoContrato oLocContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oLocContrato.statusOperacao == "I")
                {


                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoContrato'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    //int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oLocContrato.idLocacaoContrato = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oLocContrato, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoContrato ( idLocacaoContrato, idempresa, identificacaocontrato, " +
                                                                 " idimovel, datacontrato, datainicial, datafinal, " +
                                                                 " diafixopagamento, nrodiaspagamento, taxaadministracao, " +
                                                                 " valoraluguel, nromeses, valortotalcontrato, valorentrada, " +
                                                                 " dataentradainicio, dataentradafinal, saldocontratoparcela, " +
                                                                 " locatarioformapagamento, locadorformapagamento, " +
                                                                 " nroparcelas, valormensal, taxajuros, taxamulta, " +
                                                                 " contratogarantido, valordescontoconcedido, datainiciodesconto, " +
                                                                 " datafinaldesconto, idindexador, pagamentoiptu, datadesocupacao, " +
                                                                 " situacaoencerramento, situacaocontrato, data1parcela, " +
                                                                 " temcarencia, diascarencia, data1parcelacarencia, " +
                                                                 " diafixolocatario, diasproporcionais, valorproporcional, " +
                                                                 " codempresa_locatario, idlocatariorepresentante, " +
                                                                 " codempresa_locador, idlocadorrepresentante, " +
                                                                 " locatariorateio, locadorrateio, integracondominio, " +
                                                                 " locatariorepresentanteparticipacao )" +
                                    "values ( @idLocacaoContrato, @idempresa, @identificacaocontrato, " +
                                                                 " @idimovel, @datacontrato, @datainicial, @datafinal, " +
                                                                 " @diafixopagamento, @nrodiaspagamento, @taxaadministracao, " +
                                                                 " @valoraluguel, @nromeses, @valortotalcontrato, @valorentrada, " +
                                                                 " @dataentradainicio, @dataentradafinal, @saldocontratoparcela, " +
                                                                 " @locatarioformapagamento, @locadorformapagamento, " +
                                                                 " @nroparcelas, @valormensal, @taxajuros, @taxamulta, " +
                                                                 " @contratogarantido, @valordescontoconcedido, @datainiciodesconto, " +
                                                                 " @datafinaldesconto, @idindexador, @pagamentoiptu, @datadesocupacao, " +
                                                                 " @situacaoencerramento, @situacaocontrato, @data1parcela, " +
                                                                 " @temcarencia, @diascarencia, @data1parcelacarencia, " +
                                                                 " @diafixolocatario, @diasproporcionais, @valorproporcional, " +
                                                                 " @codempresa_locatario, @idlocatariorepresentante, " +
                                                                 " @codempresa_locador, @idlocadorrepresentante, " +
                                                                 " @locatariorateio, @locadorrateio, @integracondominio, " +
                                                                 " @locatariorepresentanteparticipacao )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoContrato", oLocContrato.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@idempresa", oLocContrato.idEmpresa);
                    SqlconPar.Parameters.AddWithValue("@identificacaocontrato", oLocContrato.identificacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@idimovel", oLocContrato.imovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@datacontrato", oLocContrato.dataContrato);
                    SqlconPar.Parameters.AddWithValue("@datainicial", oLocContrato.dataInicial);
                    SqlconPar.Parameters.AddWithValue("@datafinal", oLocContrato.dataFinal);
                    SqlconPar.Parameters.AddWithValue("@diafixopagamento", oLocContrato.diaFixoPagamento);
                    SqlconPar.Parameters.AddWithValue("@nrodiaspagamento", oLocContrato.nroDiasPagamento);
                    SqlconPar.Parameters.AddWithValue("@taxaadministracao", oLocContrato.taxaAdministracao);
                    SqlconPar.Parameters.AddWithValue("@valoraluguel", oLocContrato.valorAluguel);
                    SqlconPar.Parameters.AddWithValue("@nromeses", oLocContrato.nroMeses);
                    SqlconPar.Parameters.AddWithValue("@valortotalcontrato", oLocContrato.valorTotalContrato);
                    SqlconPar.Parameters.AddWithValue("@valorentrada", oLocContrato.valorEntrada);
                    SqlconPar.Parameters.AddWithValue("@dataentradainicio", oLocContrato.dataEntradaInicio);
                    SqlconPar.Parameters.AddWithValue("@dataentradafinal", oLocContrato.dataEntradaFinal);
                    SqlconPar.Parameters.AddWithValue("@saldocontratoparcela", oLocContrato.saldoContratoParcela);
                    SqlconPar.Parameters.AddWithValue("@locatarioformapagamento", oLocContrato.locatarioFormaPagamento);
                    SqlconPar.Parameters.AddWithValue("@locadorformapagamento", oLocContrato.locadorFormaPagamento);
                    SqlconPar.Parameters.AddWithValue("@nroparcelas", oLocContrato.nroParcelas);
                    SqlconPar.Parameters.AddWithValue("@valormensal", oLocContrato.valorMensal);
                    SqlconPar.Parameters.AddWithValue("@taxajuros", oLocContrato.taxaJuros);
                    SqlconPar.Parameters.AddWithValue("@taxamulta", oLocContrato.taxaMulta);
                    SqlconPar.Parameters.AddWithValue("@contratogarantido", oLocContrato.contratoGarantido);
                    SqlconPar.Parameters.AddWithValue("@valordescontoconcedido", oLocContrato.valorDescontoConcedido);
                    SqlconPar.Parameters.AddWithValue("@datainiciodesconto", oLocContrato.dataInicioDesconto);
                    SqlconPar.Parameters.AddWithValue("@datafinaldesconto", oLocContrato.dataFinalDesconto);
                    SqlconPar.Parameters.AddWithValue("@idindexador", oLocContrato.indexador.idIndexador);
                    SqlconPar.Parameters.AddWithValue("@pagamentoiptu", oLocContrato.pagamentoIptu);
                    SqlconPar.Parameters.AddWithValue("@datadesocupacao", oLocContrato.dataDesocupacao);
                    SqlconPar.Parameters.AddWithValue("@situacaoencerramento", oLocContrato.situacaoEncerramento);
                    SqlconPar.Parameters.AddWithValue("@situacaocontrato", oLocContrato.situacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@data1parcela", oLocContrato.data1Parcela);
                    SqlconPar.Parameters.AddWithValue("@temcarencia", oLocContrato.temCarencia);
                    SqlconPar.Parameters.AddWithValue("@diascarencia", oLocContrato.diasCarencia);
                    SqlconPar.Parameters.AddWithValue("@data1parcelacarencia", oLocContrato.data1ParcelaCarencia);
                    SqlconPar.Parameters.AddWithValue("@diafixolocatario", oLocContrato.diaFixoLocatario);
                    SqlconPar.Parameters.AddWithValue("@diasproporcionais", oLocContrato.diasProporcionais);
                    SqlconPar.Parameters.AddWithValue("@valorproporcional", oLocContrato.valorProporcional);
                    SqlconPar.Parameters.AddWithValue("@codempresa_locatario", oLocContrato.locatarioRepresentante.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocatariorepresentante", oLocContrato.locatarioRepresentante.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@codempresa_locador", oLocContrato.locadorRepresentante.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocadorrepresentante", oLocContrato.locadorRepresentante.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@locatariorateio", oLocContrato.locatarioRateio);
                    SqlconPar.Parameters.AddWithValue("@locadorrateio", oLocContrato.locadorRateio);
                    SqlconPar.Parameters.AddWithValue("@integracondominio", oLocContrato.integraCondominio);
                    SqlconPar.Parameters.AddWithValue("@locatariorepresentanteparticipacao", oLocContrato.locatarioRepresentanteParticipacao);


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oLocContrato.statusOperacao == "A") { }
                else if (oLocContrato.statusOperacao == "E") { }

                /****************** Operações nas tabelas auxiliares ao contato de locacação ************************/

                /* Realiza gravação dos Locadores do Contrato */
                foreach (LocacaoFornecedor oLocador in oLocContrato.listaLocadores)
                {
                    LocacaoFornecedorDAO oLocFornecedorDAO = new LocacaoFornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oLocador.statusOperacao != "")
                    {
                        if (oLocador.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oLocador.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocFornecedorDAO.Salvar(oLocador, Conexao, transacao);
                    }
                }


                /* Realiza gravação dos Locatarios do Contrato */
                foreach (LocacaoCliente oLocatario in oLocContrato.listaLocatarios)
                {
                    LocacaoClienteDAO oLocClienteDAO = new LocacaoClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oLocatario.statusOperacao != "")
                    {
                        if (oLocatario.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oLocatario.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocClienteDAO.Salvar(oLocatario, Conexao, transacao);
                    }
                }

                /* Realiza gravação dos fiadores do Contrato */
                foreach (LocacaoFiador oFiador in oLocContrato.listaFiadores)
                {
                    LocacaoFiadorDAO oLocFiadorDAO = new LocacaoFiadorDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oFiador.statusOperacao != "")
                    {
                        if (oFiador.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oFiador.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocFiadorDAO.Salvar(oFiador, Conexao, transacao);
                    }
                }

                /* Realiza gravação das anotações do Contrato */
                foreach (LocacaoAnotacao oAnotacao in oLocContrato.lstAnotacao)
                {
                    LocacaoAnotacaoDAO oLocAnotacaoDAO = new LocacaoAnotacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oAnotacao.statusOperacao != "")
                    {
                        if (oAnotacao.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oAnotacao.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocAnotacaoDAO.Salvar(oAnotacao, Conexao, transacao);
                    }
                }

                /* Realiza gravação das parcelas a receber do Contrato */
                foreach (LocacaoReceber oReceber in oLocContrato.lstLocacaoReceber)
                {
                    LocacaoReceberDAO oLocReceberDAO = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oReceber.statusOperacao != "")
                    {
                        if (oReceber.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oReceber.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocReceberDAO.Salvar(oReceber, Conexao, transacao);
                    }
                }

                /* Realiza gravação das parcelas a pagar do Contrato */
                foreach (LocacaoPagar oPagar in oLocContrato.lstLocacaoPagar)
                {
                    LocacaoPagarDAO oLocPagarDAO = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oPagar.statusOperacao != "")
                    {
                        if (oPagar.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oPagar.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocPagarDAO.Salvar(oPagar, Conexao, transacao);
                    }

                }

                /* Realiza gravação dos lancamentos contabeis do Contrato */
                foreach (LocacaoContabil oContabil in oLocContrato.lstLocacaoContabil)
                {
                    LocacaoContabilDAO oLocContabilDAO = new LocacaoContabilDAO(parConexao, oOcorrencia, codEmpresa);
                    if (oContabil.statusOperacao != "A")
                    {
                        if (oContabil.statusOperacao == "I")
                        {
                            //atribui o id gerado na inclusão
                            oContabil.idLocacaoContrato = oLocContrato.idLocacaoContrato;
                        }
                        oLocContabilDAO.Salvar(oContabil, Conexao, transacao);
                    }
                }



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

        public LocacaoContrato ObterPor(LocacaoContrato oLocContrato, string flagBusca = "S")
        {
            bool consulta = false;
            try
            {
                String strSQL = "";
                if (oLocContrato.idLocacaoContrato > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from LocacaoContrato Where idLocacaoContrato = @id";
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from LocacaoContrato Where idempresa=@codempresa and identificacaocontrato=@idContrato";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oLocContrato.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@idContrato", oLocContrato.identificacaoContrato);
                Sqlcon.Parameters.AddWithValue("@id", oLocContrato.idLocacaoContrato);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();

                LocacaoContrato oLocacaoContrato = new LocacaoContrato();

                while (drCon.Read())
                {
                    consulta = true;

                    oLocacaoContrato.idLocacaoContrato = EmcResources.cInt(drCon["idLocacaoContrato"].ToString());
                    oLocacaoContrato.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                    oLocacaoContrato.identificacaoContrato = drCon["identificacaocontrato"].ToString();

                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    oLocacaoContrato.imovel = oImovel;

                    oLocacaoContrato.dataContrato = Convert.ToDateTime(drCon["datacontrato"].ToString());
                    oLocacaoContrato.dataInicial = Convert.ToDateTime(drCon["datainicial"].ToString());
                    oLocacaoContrato.dataFinal = Convert.ToDateTime(drCon["datafinal"].ToString());

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = EmcResources.cInt(drCon["idindexador"].ToString());
                    oLocacaoContrato.indexador = oIndexador;

                    if (drCon["datadesocupacao"] is DBNull)
                    {
                        oLocacaoContrato.dataDesocupacao = null;
                    }
                    else
                        oLocacaoContrato.dataDesocupacao = Convert.ToDateTime(drCon["datadesocupacao"].ToString());

                    oLocacaoContrato.situacaoContrato = drCon["situacaocontrato"].ToString();
                    oLocacaoContrato.situacaoEncerramento = drCon["situacaoencerramento"].ToString();
                    oLocacaoContrato.pagamentoIptu = drCon["pagamentoiptu"].ToString();
                    oLocacaoContrato.valorAluguel = EmcResources.cCur(drCon["valoraluguel"].ToString());
                    oLocacaoContrato.nroMeses = EmcResources.cInt(drCon["nromeses"].ToString());
                    oLocacaoContrato.valorTotalContrato = EmcResources.cCur(drCon["valortotalcontrato"].ToString());

                    Cliente oLocatarioRepresentante = new Cliente();
                    oLocatarioRepresentante.codEmpresa = EmcResources.cInt(drCon["codempresa_locatario"].ToString());
                    oLocatarioRepresentante.idPessoa = EmcResources.cInt(drCon["idlocatariorepresentante"].ToString());
                    oLocacaoContrato.locatarioRepresentante = oLocatarioRepresentante;

                    oLocacaoContrato.locatarioRateio = drCon["locatariorateio"].ToString();
                    oLocacaoContrato.locatarioFormaPagamento = drCon["locatarioformapagamento"].ToString();
                    oLocacaoContrato.diaFixoLocatario = EmcResources.cInt(drCon["diafixolocatario"].ToString());

                    if (drCon["dataentradainicio"] is DBNull)
                    {
                        oLocacaoContrato.dataEntradaInicio = null;
                    }
                    else
                        oLocacaoContrato.dataEntradaInicio = Convert.ToDateTime(drCon["dataentradainicio"].ToString());

                    if (drCon["dataentradafinal"] is DBNull)
                    {
                        oLocacaoContrato.dataEntradaFinal = null;
                    }
                    else
                        oLocacaoContrato.dataEntradaFinal = Convert.ToDateTime(drCon["dataentradafinal"].ToString());

                    oLocacaoContrato.valorEntrada = EmcResources.cCur(drCon["valorentrada"].ToString());
                    oLocacaoContrato.saldoContratoParcela = EmcResources.cCur(drCon["saldocontratoparcela"].ToString());
                    oLocacaoContrato.nroParcelas = EmcResources.cInt(drCon["nroparcelas"].ToString());
                    oLocacaoContrato.valorMensal = EmcResources.cCur(drCon["valormensal"].ToString());
                    oLocacaoContrato.taxaJuros = EmcResources.cDouble(drCon["taxajuros"].ToString());
                    oLocacaoContrato.taxaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString());
                    oLocacaoContrato.integraCondominio = drCon["integracondominio"].ToString();

                    if (drCon["datainiciodesconto"] is DBNull)
                    {
                        oLocacaoContrato.dataInicioDesconto = null;
                    }
                    else
                        oLocacaoContrato.dataInicioDesconto = Convert.ToDateTime(drCon["datainiciodesconto"].ToString());

                    if (drCon["datafinaldesconto"] is DBNull)
                    {
                        oLocacaoContrato.dataFinalDesconto = null;
                    }
                    else
                        oLocacaoContrato.dataFinalDesconto = Convert.ToDateTime(drCon["datafinaldesconto"].ToString());

                    oLocacaoContrato.valorDescontoConcedido = EmcResources.cCur(drCon["valordescontoconcedido"].ToString());
                    oLocacaoContrato.data1Parcela = Convert.ToDateTime(drCon["data1parcela"].ToString());
                    oLocacaoContrato.temCarencia = drCon["temcarencia"].ToString();
                    oLocacaoContrato.diasCarencia = EmcResources.cInt(drCon["diascarencia"].ToString());
                    oLocacaoContrato.data1ParcelaCarencia = Convert.ToDateTime(drCon["data1parcelacarencia"].ToString());
                    oLocacaoContrato.diasProporcionais = EmcResources.cInt(drCon["diasproporcionais"].ToString());
                    oLocacaoContrato.valorProporcional = EmcResources.cCur(drCon["valorproporcional"].ToString());

                    Fornecedor oLocadorRepresentante = new Fornecedor();
                    oLocadorRepresentante.codEmpresa = EmcResources.cInt(drCon["codempresa_locador"].ToString());
                    oLocadorRepresentante.idPessoa = EmcResources.cInt(drCon["idlocadorrepresentante"].ToString());
                    oLocacaoContrato.locadorRepresentante = oLocadorRepresentante;

                    oLocacaoContrato.locatarioRepresentanteParticipacao = EmcResources.cDouble(drCon["locatariorepresentanteparticipacao"].ToString());
                    oLocacaoContrato.locadorRateio = drCon["locadorrateio"].ToString();
                    oLocacaoContrato.locadorFormaPagamento = drCon["locadorformapagamento"].ToString();
                    oLocacaoContrato.taxaAdministracao = EmcResources.cDouble(drCon["taxaadministracao"].ToString());
                    oLocacaoContrato.diaFixoPagamento = drCon["diafixopagamento"].ToString();
                    oLocacaoContrato.nroDiasPagamento = drCon["nrodiaspagamento"].ToString();
                    oLocacaoContrato.contratoGarantido = drCon["contratogarantido"].ToString();
                    oLocacaoContrato.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta && flagBusca == "S")
                {
                    ImovelDAO oImovelDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.imovel = oImovelDAO.ObterPor(oLocacaoContrato.imovel);

                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.indexador = oIndexadorDAO.ObterPor(oLocacaoContrato.indexador);

                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.locatarioRepresentante = oClienteDAO.ObterPor(oLocacaoContrato.locatarioRepresentante);

                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.locadorRepresentante = oFornecedorDAO.ObterPor(oLocacaoContrato.locadorRepresentante);

                    LocacaoContabilDAO oLocContabilDAO = new LocacaoContabilDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.lstLocacaoContabil = oLocContabilDAO.lstLocacaoContabil(oLocacaoContrato.idLocacaoContrato);

                    LocacaoAnotacaoDAO oLocAnotacaoDAO = new LocacaoAnotacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.lstAnotacao = oLocAnotacaoDAO.lstLocacaoAnotacao(oLocacaoContrato.idLocacaoContrato);

                    LocacaoClienteDAO oLocClienteDAO = new LocacaoClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.listaLocatarios = oLocClienteDAO.lstLocacaoCliente(oLocacaoContrato.idLocacaoContrato);

                    LocacaoFornecedorDAO oLocFornecedorDAO = new LocacaoFornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.listaLocadores = oLocFornecedorDAO.lstLocacaoFornecedor(oLocacaoContrato.idLocacaoContrato);

                    LocacaoFiadorDAO oLocFiadorDAO = new LocacaoFiadorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.listaFiadores = oLocFiadorDAO.lstLocacaoFiador(oLocacaoContrato.idLocacaoContrato);

                    LocacaoReceberDAO oLocReceberDAO = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.lstLocacaoReceber = oLocReceberDAO.lstLocacaoReceber(oLocacaoContrato.idLocacaoContrato);

                    LocacaoPagarDAO oLocPagarDAO = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.lstLocacaoPagar = oLocPagarDAO.lstLocacaoPagar(oLocacaoContrato.idLocacaoContrato);


                }
                else if (consulta && flagBusca == "N")
                {
                    ImovelDAO oImovelDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContrato.imovel = oImovelDAO.ObterPor(oLocacaoContrato.imovel);
                }

                return oLocacaoContrato;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        } 

        private void geraOcorrencia(LocacaoContrato oLocContrato, string flag)
        {
            try
            {
                string descricao = "";
                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLocContrato.idLocacaoContrato.ToString();

                if (flag == "A")
                {
                    LocacaoContrato oCCP = new LocacaoContrato();
                    oCCP = ObterPor(oLocContrato);

                    if (!oCCP.Equals(oLocContrato))
                    {
                        descricao = "Locacao Contrato id: " + oLocContrato.idLocacaoContrato +
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";


                    }
                }
                else if (flag == "I")
                {
                    descricao = " Locacao Contrato id: " + oLocContrato.idLocacaoContrato +
                                " Contrato Locacao id : " + oLocContrato.idLocacaoContrato +
                                " Data : " + oLocContrato.dataContrato + " - " + oLocContrato.dataContrato +
                                " Historico : " + oLocContrato.identificacaoContrato +
                                " Usuario : " + oLocContrato.idLocacaoContrato.ToString() +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Locacao Contrato id: " + oLocContrato.idLocacaoContrato +
                                " Contrato Locacao id : " + oLocContrato.idLocacaoContrato +
                                " Data : " + oLocContrato.dataContrato + " - " + oLocContrato.dataContrato +
                                " Historico : " + oLocContrato.identificacaoContrato +
                                " Usuario : " + oLocContrato.idLocacaoContrato.ToString() +
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

        public DataTable dstListaExtrato(string identificacaoContrato, DateTime? dataInicial, DateTime? dataFinal, int idLocatario, string codigoImovel)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro          

                string strSQL = " select lr.*, cl.nome as nome_locatario, f.nome as nome_locador, t.descricao as tipoimovel, i.codigoimovel as codigoimovel, i.rua as rua, i.numero as numero, " +
                                " lc.identificacaocontrato as identificacaocontrato, lc.idlocadorrepresentante as idlocador, lc.nroparcelas as nroparcelas, lc.valoraluguel as alguel, " + 
                                " lc.valordescontoconcedido as valordescontoconcedido, lc.valormensal as valormensal, lc.taxaadministracao as taxaadministracao " +
                                " from locacaoreceber lr " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lr.idlocacaocontrato " +
                                " left join imovel i on i.idimovel = lc.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                " left join v_cliente cl on cl.codempresa = lr.cliente_codempresa and cl.idpessoa = lr.idcliente " +
                                " left join v_fornecedor f on f.codempresa = lc.codempresa_locador and f.idpessoa = lc.idlocadorrepresentante ";

                if (!String.IsNullOrEmpty(identificacaoContrato))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " lc.identificacaocontrato = @identificacaocontrato ";
                }

                if (idLocatario > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " idcliente = @idcliente ";
                }

                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }

                if (dataInicial != null && dataFinal != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datavencimento >= @datainicial and datavencimento <= @datafinal ";
                }                

                //strSQL += " order by nroparcela ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@identificacaocontrato", identificacaoContrato);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@idcliente", idLocatario);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);


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
