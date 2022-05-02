using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCFinanceiroModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCFinanceiroDAO
{
    public class TarifaBancariaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public TarifaBancariaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(TarifaBancaria oTarifaBancaria)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {

                //Gera o novo documento de cobrança
                int idDocPagar = 0;

                Ocorrencia ocoPgDoc = new Ocorrencia();
                ocoPgDoc.aplicativo = oOcorrencia.aplicativo;
                ocoPgDoc.chaveidentificacao = "";
                ocoPgDoc.data_hora = DateTime.Now;
                ocoPgDoc.descricao = "";
                ocoPgDoc.formulario = "frmPagarDocumento";
                ocoPgDoc.seqLogin = oOcorrencia.seqLogin;
                ocoPgDoc.tabela = "pagardocumento";
                ocoPgDoc.usuario = oOcorrencia.usuario;
                PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, ocoPgDoc, codEmpresa);
                idDocPagar = oPgDocDAO.Salvar(Conexao, transacao, oTarifaBancaria.pagarDocumento);


                /* Busca Chave primaria da tarifa bancaria - prox. codigo */
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'tarifabancaria'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oTarifaBancaria.idTarifaBancaria = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;



                geraOcorrencia(oTarifaBancaria, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into TarifaBancaria (idempresa, idtarifabancaria, descricao, nrodocumento, datatarifa, valortarifa, " + 
                                                        "idcontacusto, idaplicacao, idctabancaria, ctabancaria_idempresa, " + 
                                                        "fornecedor_codempresa, fornecedor_idpessoa, idpagardocumento, idtipodocumento ) " + 
                                " values (@idempresa, @idtarifabancaria, @descricao, @nrodocumento, @datatarifa, @valortarifa, " + 
                                         "@idcontacusto, @idaplicacao, @idctabancaria, @ctabancaria_idempresa, @fornecedor_codempresa, " + 
                                         "@fornecedor_idpessoa, @idpagardocumento, @idtipodocumento )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oTarifaBancaria.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@idtarifabancaria", oTarifaBancaria.idTarifaBancaria);
                Sqlcon.Parameters.AddWithValue("@descricao", oTarifaBancaria.descricao);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", oTarifaBancaria.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@datatarifa", oTarifaBancaria.dataTarifa);
                Sqlcon.Parameters.AddWithValue("@valortarifa", oTarifaBancaria.valorTarifa);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", oTarifaBancaria.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", oTarifaBancaria.aplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oTarifaBancaria.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oTarifaBancaria.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", oTarifaBancaria.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", oTarifaBancaria.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idDocPagar);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", oTarifaBancaria.pagarDocumento.tipoDocumento.idTipoDocumento);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

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

        public void Atualizar(TarifaBancaria oTarifaBancaria)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                //Gera o novo documento de cobrança
               
                Ocorrencia ocoPgDoc = new Ocorrencia();
                ocoPgDoc.aplicativo = oOcorrencia.aplicativo;
                ocoPgDoc.chaveidentificacao = "";
                ocoPgDoc.data_hora = DateTime.Now;
                ocoPgDoc.descricao = "";
                ocoPgDoc.formulario = "frmPagarDocumento";
                ocoPgDoc.seqLogin = oOcorrencia.seqLogin;
                ocoPgDoc.tabela = "pagardocumento";
                ocoPgDoc.usuario = oOcorrencia.usuario;
                PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, ocoPgDoc, codEmpresa);
                oPgDocDAO.Atualizar(Conexao, transacao, oTarifaBancaria.pagarDocumento);
                
                geraOcorrencia(oTarifaBancaria, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update TarifaBancaria set descricao=@descricao, nrodocumento=@nrodocumento, datatarifa=@datatarifa, " +
                                                         " valortarifa=@valortarifa, idcontacusto=@idcontacusto, idaplicacao=@idaplicacao," +
                                                         " idctabancaria=@idctabancaria, ctabancaria_idempresa=@ctabancaria_idempresa, " +
                                                         " fornecedor_codempresa=@fornecedor_codempresa, fornecedor_idpessoa=@fornecedor_idpessoa, " +
                                                         " idtipodocumento=@idtipodocumento " +
                                " where idempresa=@idempresa and idtarifabancaria=@idtarifabancaria";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oTarifaBancaria.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@idtarifabancaria", oTarifaBancaria.idTarifaBancaria);
                Sqlcon.Parameters.AddWithValue("@descricao", oTarifaBancaria.descricao);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", oTarifaBancaria.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@datatarifa", oTarifaBancaria.dataTarifa);
                Sqlcon.Parameters.AddWithValue("@valortarifa", oTarifaBancaria.valorTarifa);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", oTarifaBancaria.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", oTarifaBancaria.aplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oTarifaBancaria.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@ctabancaria_idempresa", oTarifaBancaria.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", oTarifaBancaria.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", oTarifaBancaria.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", oTarifaBancaria.pagarDocumento.tipoDocumento.idTipoDocumento);
                Sqlcon.ExecuteNonQuery();

                
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

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

        public void Excluir(TarifaBancaria oTarifaBancaria)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                

                geraOcorrencia(oTarifaBancaria, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from TarifaBancaria where idTarifaBancaria = @idTarifaBancaria";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idTarifaBancaria", oTarifaBancaria.idTarifaBancaria);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                Ocorrencia ocoPgDoc = new Ocorrencia();
                ocoPgDoc.aplicativo = oOcorrencia.aplicativo;
                ocoPgDoc.chaveidentificacao = "";
                ocoPgDoc.data_hora = DateTime.Now;
                ocoPgDoc.descricao = "";
                ocoPgDoc.formulario = "frmPagarDocumento";
                ocoPgDoc.seqLogin = oOcorrencia.seqLogin;
                ocoPgDoc.tabela = "pagardocumento";
                ocoPgDoc.usuario = oOcorrencia.usuario;
                PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, ocoPgDoc, codEmpresa);
                oPgDocDAO.Excluir(Conexao, transacao, oTarifaBancaria.pagarDocumento);

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

       
        public DataTable ListaTarifaBancaria()
        {

            try
            {
                //Monta comando para a gravação do registro
                string strSQL = "select t.idtarifabancaria, t.datatarifa, t.valortarifa, t.nrodocumento, c.situacao, " + 
                                      " c.autorizado, t.idpagardocumento, c.idpagarparcelas, cta.descricao as descricaoconta " + 
                                " from tarifabancaria t " +
                                " left join pagardocumento p  on p.idpagardocumento = t.idpagardocumento " +
                                " left join pagarparcelas c on c.idpagardocumento = t.idpagardocumento " +
                                " left join ctabancaria cta on cta.idctabancaria = t.idctabancaria and cta.idempresa = t.ctabancaria_idempresa " +
                                "  Where t.idempresa = @codempresa and c.situacao='A'";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);

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

        public DataTable ListaTarifaBancariaBaixa(int idCtaBancaria)
        {

            try
            {
                //Monta comando para a gravação do registro
                string strSQL = "select t.idtarifabancaria, t.datatarifa, t.valortarifa, t.nrodocumento, c.situacao, " +
                                      " c.autorizado, t.idpagardocumento, c.idpagarparcelas, cta.descricao as descricaoconta " +
                                " from tarifabancaria t " +
                                " left join pagardocumento p  on p.idpagardocumento = t.idpagardocumento " +
                                " left join pagarparcelas c on c.idpagardocumento = t.idpagardocumento " +
                                " left join ctabancaria cta on cta.idctabancaria = t.idctabancaria and cta.idempresa = t.ctabancaria_idempresa " +
                                "  Where t.idempresa = @codempresa and c.situacao='A' and c.autorizado='S' " + 
                                  "  and t.idctabancaria=@idconta";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idconta", idCtaBancaria);

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

        public TarifaBancaria ObterPor(TarifaBancaria oTarifaBancaria)
        {
            MySqlDataReader drConta;
            try
            {

                bool Consulta = false;

                string strSQL = "";
                MySqlCommand Sqlcon = null;
                //Monta comando para a gravação do registro
                if (oTarifaBancaria.idTarifaBancaria > 0)
                {
                    strSQL = "select t.*, c.idpagarparcelas, c.autorizado, c.situacao from tarifabancaria t " +
                    " left join pagardocumento p  on p.idpagardocumento = t.idpagardocumento " +
		            " left join pagarparcelas c on c.idpagardocumento = t.idpagardocumento " +
                    "  Where t.idTarifaBancaria = @idtarifabancaria";

                    Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idtarifabancaria", oTarifaBancaria.idTarifaBancaria);
                }
                else
                {
                    strSQL = "select t.*, c.idpagarparcelas, c.autorizado, c.situacao from tarifabancaria t " +
                    " left join pagardocumento p  on p.idpagardocumento = t.idpagardocumento " +
                    " left join pagarparcelas c on c.idpagardocumento = t.idpagardocumento " +
                    " Where t.idempresa=@codempresa and t.nrodocumento = @nrodoc "+ 
                      " and t.fornecedor_codempresa=@emp and t.fornecedor_idpessoa=@forn ";

                    Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codempresa", oTarifaBancaria.idEmpresa);
                    Sqlcon.Parameters.AddWithValue("@nrodoc", oTarifaBancaria.nroDocumento);
                    Sqlcon.Parameters.AddWithValue("@emp", oTarifaBancaria.fornecedor.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@forn", oTarifaBancaria.fornecedor.idPessoa);
                }


                drConta = Sqlcon.ExecuteReader();


                Boolean bConsulta = false;
                TarifaBancaria oTarifa = new TarifaBancaria();

                while (drConta.Read())
                {
                    bConsulta = true;

                    //localiza banco da contabancaria
                    

                    oTarifa.idEmpresa = EmcResources.cInt(drConta["idempresa"].ToString());
                    oTarifa.idTarifaBancaria = EmcResources.cInt(drConta["idtarifabancaria"].ToString());
                    oTarifa.dataTarifa = Convert.ToDateTime(drConta["datatarifa"].ToString());
                    oTarifa.descricao = drConta["descricao"].ToString();
                    oTarifa.nroDocumento = drConta["nrodocumento"].ToString();
                    oTarifa.valorTarifa = EmcResources.cCur(drConta["valortarifa"].ToString());

                    CtaBancaria oCtaBancaria = new CtaBancaria();
                    oCtaBancaria.idCtaBancaria = EmcResources.cInt(drConta["idctabancaria"].ToString());
                    oCtaBancaria.codEmpresa = EmcResources.cInt(drConta["idempresa"].ToString());
                    oTarifa.contaBancaria = oCtaBancaria;

                    Aplicacao oAplicacao = new Aplicacao();
                    oAplicacao.idAplicacao = EmcResources.cInt(drConta["idaplicacao"].ToString());
                    oTarifa.aplicacao = oAplicacao;

                    ContaCusto oContaCusto = new ContaCusto();
                    oContaCusto.idContaCusto = EmcResources.cInt(drConta["idcontacusto"].ToString());
                    oTarifa.contaCusto = oContaCusto;

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.idPessoa = EmcResources.cInt(drConta["fornecedor_idpessoa"].ToString());
                    oFornecedor.codEmpresa = EmcResources.cInt(drConta["fornecedor_codempresa"].ToString());
                    oTarifa.fornecedor = oFornecedor;

                    PagarDocumento oPagarDocumento = new PagarDocumento();
                    oPagarDocumento.idPagarDocumento = EmcResources.cInt(drConta["idpagardocumento"].ToString());
                    oTarifa.pagarDocumento = oPagarDocumento;

                    oTarifa.situacao = drConta["situacao"].ToString();
                    oTarifa.autorizado = drConta["autorizado"].ToString();
                }

                drConta.Close();
                drConta.Dispose();
                drConta = null;

                if (bConsulta)
                {
                    CtaBancariaDAO oCtaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                    oTarifa.contaBancaria = oCtaDAO.ObterPor(oTarifa.contaBancaria);

                    AplicacaoDAO oAplDAO = new AplicacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    oTarifa.aplicacao = oAplDAO.ObterPor(oTarifa.aplicacao);

                    ContaCustoDAO oCcDAO = new ContaCustoDAO(parConexao, oOcorrencia, codEmpresa);
                    oTarifa.contaCusto = oCcDAO.ObterPor(oTarifa.contaCusto);

                    FornecedorDAO oForDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oTarifa.fornecedor = oForDAO.ObterPor(oTarifa.fornecedor);

                    PagarDocumentoDAO oPgDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    oTarifa.pagarDocumento = oPgDAO.ObterPor(oTarifa.pagarDocumento);

                }


                return oTarifa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drConta = null;
            }

        }

        private void geraOcorrencia(TarifaBancaria oTarifaBancaria, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oTarifaBancaria.idTarifaBancaria.ToString();

                if (flag == "A" || flag=="AS")
                {

                    TarifaBancaria oTar = new TarifaBancaria();
                    oTar = ObterPor(oTarifaBancaria);

                    if (flag == "AS")
                    {
                        descricao = " Atualização de Numero : de " + " foi excluída por " + oOcorrencia.usuario.nome;
                    }

                    if ((!oTar.Equals(oTarifaBancaria) && flag=="A") || (flag=="AC") )
                    {
                        descricao = "TarifaBancaria :" + oTarifaBancaria.idTarifaBancaria + "-" + oTarifaBancaria.descricao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oTar.descricao.Equals(oTarifaBancaria.descricao))
                        {
                            descricao += " Descricao TarifaBancaria : " + oTar.descricao + " para " + oTarifaBancaria.descricao;
                        }
                        if (!oTar.dataTarifa.Equals(oTarifaBancaria.dataTarifa))
                        {
                            descricao += " Data TarifaBancaria : " + oTar.dataTarifa.ToString() + " para " + oTarifaBancaria.dataTarifa.ToString();
                        }
                        if (!oTar.valorTarifa.Equals(oTarifaBancaria.valorTarifa))
                        {
                            descricao += " Valor : " + oTar.valorTarifa.ToString() + " para " + oTarifaBancaria.valorTarifa.ToString();
                        }
                        if (!oTar.contaCusto.Equals(oTarifaBancaria.contaCusto))
                        {
                            descricao += " Conta Custo de: Id:" + oTar.contaCusto.idContaCusto + " Código :" + oTar.contaCusto.codigoConta + " Descricao  : " + oTar.contaCusto.descricao +
                                          " para Id :" + oTarifaBancaria.contaCusto.idContaCusto + " Código : " + oTarifaBancaria.contaCusto.codigoConta + " Descricao : " + oTarifaBancaria.contaCusto.descricao;
                        }
                        if (!oTar.contaBancaria.Equals(oTarifaBancaria.contaBancaria))
                        {
                            descricao += " Cta Bancaria de: Empresa : " + oTar.contaBancaria.codEmpresa + " - Id Conta :" + oTar.contaBancaria.idCtaBancaria + " Descricao  : " + oTar.contaBancaria.descricao +
                                          " para Empresa :" + oTarifaBancaria.contaBancaria.codEmpresa + " id Conta : " + oTarifaBancaria.contaBancaria.idCtaBancaria + " Descricao : " + oTarifaBancaria.contaBancaria.descricao;
                        }
                        if (!oTar.fornecedor.Equals(oTarifaBancaria.fornecedor))
                        {
                            descricao += " Fornecedor de:" + oTar.fornecedor.idPessoa + " Nome  : " + oTar.fornecedor.pessoa.nome +
                                          " para :" + oTarifaBancaria.fornecedor.idPessoa + " Nome : " + oTarifaBancaria.fornecedor.pessoa.nome;
                        }
                        if (!oTar.aplicacao.Equals(oTarifaBancaria.aplicacao))
                        {
                            descricao += " Aplicacao de:" + oTar.aplicacao.idAplicacao + " descricao  : " + oTar.aplicacao.descricao +
                                          " para :" + oTarifaBancaria.aplicacao.idAplicacao + " descricao : " + oTarifaBancaria.aplicacao.descricao;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = " TarifaBancaria : " + oTarifaBancaria.idTarifaBancaria + " - Descricao : " + oTarifaBancaria.descricao +
                                " - Conta Bancaria : " + oTarifaBancaria.contaBancaria.codEmpresa + " " + oTarifaBancaria.contaBancaria.idCtaBancaria + " " + oTarifaBancaria.contaBancaria.descricao + 
                                " - idEmpresa : " + oTarifaBancaria.idEmpresa + " - NroDocumento : " + oTarifaBancaria.nroDocumento + " - data : " + oTarifaBancaria.dataTarifa.ToString() +
                                " - Valor : " + oTarifaBancaria.valorTarifa + " - IdPagarDocumento : " + oTarifaBancaria.pagarDocumento.idPagarDocumento +
                                " - Conta Custo - Id : " + oTarifaBancaria.contaCusto.idContaCusto + " Codigo : " + oTarifaBancaria.contaCusto.codigoConta + " Descricao : " + oTarifaBancaria.contaCusto.descricao +
                                " - Aplicacao : " + oTarifaBancaria.aplicacao.idAplicacao + " Descricao " + oTarifaBancaria.aplicacao.descricao +
                                " - Fornecedor : " + oTarifaBancaria.fornecedor.idPessoa + " Nome " + oTarifaBancaria.fornecedor.pessoa.nome + 
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " TarifaBancaria : " + oTarifaBancaria.idTarifaBancaria + " - Descricao : " + oTarifaBancaria.descricao +
                                " - Conta Bancaria : " + oTarifaBancaria.contaBancaria.codEmpresa + " " + oTarifaBancaria.contaBancaria.idCtaBancaria + " " + oTarifaBancaria.contaBancaria.descricao +
                                " - idEmpresa : " + oTarifaBancaria.idEmpresa + " - NroDocumento : " + oTarifaBancaria.nroDocumento + " - data : " + oTarifaBancaria.dataTarifa.ToString() +
                                " - Valor : " + oTarifaBancaria.valorTarifa + " - IdPagarDocumento : " + oTarifaBancaria.pagarDocumento.idPagarDocumento +
                                " - Conta Custo - Id : " + oTarifaBancaria.contaCusto.idContaCusto + " Codigo : " + oTarifaBancaria.contaCusto.codigoConta + " Descricao : " + oTarifaBancaria.contaCusto.descricao +
                                " - Aplicacao : " + oTarifaBancaria.aplicacao.idAplicacao + " Descricao " + oTarifaBancaria.aplicacao.descricao +
                                " - Fornecedor : " + oTarifaBancaria.fornecedor.idPessoa + " Nome " + oTarifaBancaria.fornecedor.pessoa.nome +
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
