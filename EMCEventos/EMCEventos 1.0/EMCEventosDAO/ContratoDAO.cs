using EMCCadastroDAO;
using EMCCadastroModel;
using EMCEventosModel;
using EMCLibrary;
using EMCSecurityDAO;
using EMCSecurityModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EMCEventosDAO
{
    public class ContratoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ContratoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Contrato objContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                Salvar(Conexao, transacao, objContrato);
                //transacao.Commit();
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

        public void Salvar(MySqlConnection Conecta, MySqlTransaction transacao, Contrato objContrato)
        {
            //MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'evt_contrato'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();


                while (drCon.Read())
                {
                    objContrato.idContrato = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objContrato, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into evt_contrato (datacontrato, valorcontrato, nroparcelas, idev_sublocacao, cliente_CodEmpresa, cliente_idPessoa, fornecedor_CodEmpresa, " +
                                                           " fornecedor_idPessoa, geraContasPagar, geraTaxaAdministracao, percenturaladministracao, valoradministracao, dataaprovacao, " + 
                                                           " situacao, idusuarioaprovador, idusuariocontrato) " +
                                " values (@datacontrato, @valorcontrato, @nroparcelas, @idev_sublocacao, @cliente_CodEmpresa, @cliente_idPessoa, @fornecedor_CodEmpresa, " +
                                                           " @fornecedor_idPessoa, @geraContasPagar, @geraTaxaAdministracao, @percenturaladministracao, @valoradministracao, @dataaprovacao, " +
                                                           " @situacao, @idusuarioaprovador, @idusuariocontrato)";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);

                Sqlcon.Parameters.AddWithValue("@datacontrato", objContrato.dataContrato);
                Sqlcon.Parameters.AddWithValue("@valorcontrato", objContrato.valorContrato);
                Sqlcon.Parameters.AddWithValue("@nroparcelas", objContrato.nroParcelas);
                Sqlcon.Parameters.AddWithValue("@idev_sublocacao", objContrato.subLocacao.idSublocacao);
                Sqlcon.Parameters.AddWithValue("@cliente_CodEmpresa", objContrato.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@cliente_idPessoa", objContrato.cliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_CodEmpresa", objContrato.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idPessoa", objContrato.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@geraContasPagar", objContrato.geraContasPagar);
                Sqlcon.Parameters.AddWithValue("@geraTaxaAdministracao", objContrato.geraTaxaAdministracao);
                Sqlcon.Parameters.AddWithValue("@percenturalAdministracao", objContrato.percenturalAdministracao);
                Sqlcon.Parameters.AddWithValue("@valoradministracao", objContrato.valorAdministracao);
                Sqlcon.Parameters.AddWithValue("@dataaprovacao", objContrato.dataAprovacao);
                Sqlcon.Parameters.AddWithValue("@situacao", objContrato.situacao);
                Sqlcon.Parameters.AddWithValue("@idusuarioaprovador", objContrato.usuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@idusuariocontrato", objContrato.usuario.idUsuario);


                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
                transacao.Commit();

                ContratoParcelaDAO oContParcelaDAO = new ContratoParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ContratoParcela objContratoParcela in objContrato.lstContratoParcela)
                {
                    if (objContratoParcela.contrato.idContrato <= 0)
                    {
                        objContratoParcela.contrato = objContrato;
                    }
                    oContParcelaDAO.Salvar(objContratoParcela, Conecta, transacao);
                }

            }
            catch (MySqlException erro)
            {                
                throw erro;
            }          
           
        }

        public void Atualizar(Contrato objContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {
                Atualizar(Conexao, transacao, objContrato);

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

        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, Contrato objContrato)
        {
            //MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objContrato, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update evt_contrato set datacontrato = @datacontrato, valorcontrato = @valorcontrato, nroparcelas = @nroparcelas, idev_sublocacao = @idev_sublocacao, " + 
                                                        " cliente_CodEmpresa = @cliente_CodEmpresa, cliente_idPessoa = @cliente_idPessoa, fornecedor_CodEmpresa = @fornecedor_CodEmpresa, " +
                                                        " fornecedor_idPessoa = @fornecedor_idPessoa, geraContasPagar = @geraContasPagar, geraTaxaAdministracao = geraTaxaAdministracao, " + 
                                                        " percenturaladministracao = @percenturaladministracao, valoradministracao = @valoradministracao, dataaprovacao = @dataaprovacao, " +
                                                        " situacao = @situacao, idusuarioaprovador = @idusuarioaprovador, idusuariocontrato = @idusuariocontrato  where idevt_contrato = @idevt_contrato";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@idevt_contrato", objContrato.idContrato);
                Sqlcon.Parameters.AddWithValue("@datacontrato", objContrato.dataContrato);
                Sqlcon.Parameters.AddWithValue("@valorcontrato", objContrato.valorContrato);
                Sqlcon.Parameters.AddWithValue("@nroparcelas", objContrato.nroParcelas);
                Sqlcon.Parameters.AddWithValue("@idev_sublocacao", objContrato.subLocacao.idSublocacao);
                Sqlcon.Parameters.AddWithValue("@cliente_CodEmpresa", objContrato.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@cliente_idPessoa", objContrato.cliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_CodEmpresa", objContrato.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idPessoa", objContrato.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@geraContasPagar", objContrato.geraContasPagar);
                Sqlcon.Parameters.AddWithValue("@geraTaxaAdministracao", objContrato.geraTaxaAdministracao);
                Sqlcon.Parameters.AddWithValue("@percenturalAdministracao", objContrato.percenturalAdministracao);
                Sqlcon.Parameters.AddWithValue("@valoradministracao", objContrato.valorAdministracao);
                Sqlcon.Parameters.AddWithValue("@dataaprovacao", objContrato.dataAprovacao);
                Sqlcon.Parameters.AddWithValue("@situacao", objContrato.situacao);
                Sqlcon.Parameters.AddWithValue("@idusuarioaprovador", objContrato.usuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@idusuariocontrato", objContrato.usuario.idUsuario);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
                //transacao.Commit();   

                ContratoParcelaDAO oContParcelaDAO = new ContratoParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ContratoParcela objContParcela in objContrato.lstContratoParcela)
                {
                    if (objContParcela.contrato.idContrato <= 0)
                    {
                        objContParcela.contrato = objContrato;
                    }
                    oContParcelaDAO.Salvar(objContParcela, Conecta, transacao);
                }

            }
            catch (MySqlException erro)
            {                
                throw erro;
            }
           
        }

        public void Excluir(Contrato objContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objContrato, "E");

                //Monta comando para a gravação do registro 
                String strSQL = "delete from evt_contrato where idevt_contrato = @idevt_contrato";

                //String strSQL = "update evt_contrato set datacontrato = @datacontrato, valorcontrato = @valorcontrato, nroparcelas = @nroparcelas, idev_sublocacao = @idev_sublocacao, " +
                //                                        " cliente_CodEmpresa = @cliente_CodEmpresa, cliente_idPessoa = @cliente_idPessoa, fornecedor_CodEmpresa = @fornecedor_CodEmpresa, " +
                //                                        " fornecedor_idPessoa = @fornecedor_idPessoa, geraContasPagar = @geraContasPagar, geraTaxaAdministracao = geraTaxaAdministracao, " +
                //                                        " percenturaladministracao = @percenturaladministracao, valoradministracao = @valoradministracao, dataaprovacao = @dataaprovacao, " +
                //                                        " situacao = @situacao, idusuarioaprovador = @idusuarioaprovador, idusuariocontrato = @idusuariocontrato  where idevt_contrato = @idevt_contrato";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idevt_contrato", objContrato.idContrato);
                //Sqlcon.Parameters.AddWithValue("@datacontrato", objContrato.dataContrato);
                //Sqlcon.Parameters.AddWithValue("@valorcontrato", objContrato.valorContrato);
                //Sqlcon.Parameters.AddWithValue("@nroparcelas", objContrato.nroParcelas);
                //Sqlcon.Parameters.AddWithValue("@idev_sublocacao", objContrato.subLocacao.idSublocacao);
                //Sqlcon.Parameters.AddWithValue("@cliente_CodEmpresa", objContrato.cliente.codEmpresa);
                //Sqlcon.Parameters.AddWithValue("@cliente_idPessoa", objContrato.cliente.idPessoa);
                //Sqlcon.Parameters.AddWithValue("@fornecedor_CodEmpresa", objContrato.fornecedor.codEmpresa);
                //Sqlcon.Parameters.AddWithValue("@fornecedor_idPessoa", objContrato.fornecedor.idPessoa);
                //Sqlcon.Parameters.AddWithValue("@geraContasPagar", objContrato.geraContasPagar);
                //Sqlcon.Parameters.AddWithValue("@geraTaxaAdministracao", objContrato.geraTaxaAdministracao);
                //Sqlcon.Parameters.AddWithValue("@percenturalAdministracao", objContrato.percenturalAdministracao);
                //Sqlcon.Parameters.AddWithValue("@valoradministracao", objContrato.valorAdministracao);
                //Sqlcon.Parameters.AddWithValue("@dataaprovacao", objContrato.dataAprovacao);
                //Sqlcon.Parameters.AddWithValue("@situacao", objContrato.situacao);
                //Sqlcon.Parameters.AddWithValue("@idusuarioaprovador", objContrato.usuario.idUsuario);
                //Sqlcon.Parameters.AddWithValue("@idusuariocontrato", objContrato.usuario.idUsuario);


                Sqlcon.ExecuteNonQuery();
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
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

        public DataTable pesquisaContrato(int empMaster, int idSubLocacao, int idCliente, int idFornecedor, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro

                String strSQL = "SELECT c.*, s.descricao as desc_sublocacao, cl.nome as nome_cliente, f.nome as nome_fornecedor " +
                                " from evt_contrato c " +
                                " left join evt_sublocacao s on s.idevt_sublocacao = c.idev_sublocacao " +
                                " left join v_cliente cl on cl.codempresa = c.cliente_codempresa and cl.idpessoa = c.cliente_idpessoa " +
                                " left join v_fornecedor f on f.codempresa = c.fornecedor_codempresa and f.idpessoa = c.fornecedor_idpessoa ";


                //filtra tipo despesa imovel


                if (idSubLocacao > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " c.idev_sublocacao = @idev_sublocacao ";
                }

                if (idCliente > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " cl.idpessoa = @cliente_idpessoa ";
                }

                if (idFornecedor > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " f.idpessoa = @fornecedor_idpessoa ";
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
                    strSQL += " datacontrato >= @datainicio and datacontrato <= @datafinal ";
                }



                strSQL += " order by datacontrato";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idev_sublocacao", idSubLocacao);
                Sqlcon.Parameters.AddWithValue("@cliente_idpessoa", idCliente);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", idFornecedor);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
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

        public DataTable ListaContrato()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT c.*, s.descricao as desc_sublocacao, cli.nome as nome_cliente, f.nome as nome_fornecedor " +
                                " from evt_contrato c " +
                                " left join evt_sublocacao s on s.idevt_sublocacao = c.idev_sublocacao " +
                                " left join v_cliente cli on cli.codempresa = c.cliente_codempresa and cli.idpessoa = c.cliente_idpessoa " +
                                " left join v_fornecedor f on f.codempresa = c.fornecedor_codempresa and f.idpessoa = c.fornecedor_idpessoa " +
                                " order by idevt_contrato";

                //String strSQL = " SELECT * from evt_contrato order by idevt_contrato"; 

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                daCon.Dispose();
                daCon = null;
            }
        }

        public DataTable dstRelContrato(int idCliente, bool chkCliente, int idSubLocacao, bool chkSubLocacao, int idFornecedor, bool chkFornecedor, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT c.*, s.descricao as desc_sublocacao, cl.nome as nome_cliente, f.nome as nome_fornecedor " +
                                " from evt_contrato c " +
                                " left join evt_sublocacao s on s.idevt_sublocacao = c.idev_sublocacao " +
                                " left join v_cliente cl on cl.codempresa = c.cliente_codempresa and cl.idpessoa = c.cliente_idpessoa " +
                                " left join v_fornecedor f on f.codempresa = c.fornecedor_codempresa and f.idpessoa = c.fornecedor_idpessoa ";


                if (idSubLocacao >= 0 && !chkSubLocacao)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " c.idev_sublocacao = @idev_sublocacao ";
                }

                if (idCliente >= 0 && !chkCliente)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " cl.idpessoa = @cliente_idpessoa ";
                }

                if (idFornecedor >= 0 && !chkFornecedor)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " f.idpessoa = @fornecedor_idpessoa ";
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
                    strSQL += " datacontrato >= @datainicio and datacontrato <= @datafinal ";
                }


                //strSQL += " order by idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idev_sublocacao", idSubLocacao);
                Sqlcon.Parameters.AddWithValue("@cliente_idpessoa", idCliente);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", idFornecedor);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
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

        public DataTable dstRelatorioCli(int idCliente, bool chkCliente, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT c.*, c.nome as nome_cliente " +
                                " from v_cliente c " +
                                " left join evt_contrato ct on ct.cliente_codempresa = c.codempresa and ct.cliente_idpessoa = c.idpessoa ";
                
                if (idCliente >= 0 && !chkCliente)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " c.idpessoa = @cliente_idpessoa ";
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
                    strSQL += " ct.datacontrato >= @datainicio and ct.datacontrato <= @datafinal ";
                }
                 

                //strSQL += " order by idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@cliente_idpessoa", idCliente);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
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

        public DataTable dstRelatorioSubLoc(int idSubLocacao, bool chkSubLocacao, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro

                string strSQL = "SELECT s.*, s.descricao as desc_sublocacao " +
                                " from evt_sublocacao s " +
                                " left join evt_evento e on e.idevt_evento = s.idevt_evento " + 
                                " left join evt_contrato c on c.idev_sublocacao = s.idevt_sublocacao " ;


                if (idSubLocacao > 0 && !chkSubLocacao)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " idevt_sublocacao = @idev_sublocacao ";
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
                    strSQL += " c.datacontrato >= @datainicio and c.datacontrato <= @datafinal ";
                }


                //strSQL += " order by idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idev_sublocacao", idSubLocacao);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
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

        public DataTable dstRelatorioForn(int idFornecedor, bool chkFornecedor, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro

                string strSQL = "SELECT f.*, f.nome as nome_fornecedor " +
                                " from v_fornecedor f " +
                                " left join evt_contrato c on c.fornecedor_codempresa = f.codempresa and c.fornecedor_idpessoa = f.idpessoa " ;

                
                if (idFornecedor >= 0 && !chkFornecedor)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " idpessoa = @fornecedor_idpessoa ";
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
                    strSQL += " c.datacontrato >= @datainicio and c.datacontrato <= @datafinal ";
                   
                }


                //strSQL += " order by idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", idFornecedor);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
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

        public Contrato ObterPor(Contrato oContrato)
        {
            MySqlDataReader drCon;
            Contrato objRetorno = new Contrato();
            Boolean bControle = false;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oContrato.idContrato > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from evt_contrato Where idevt_contrato = " + oContrato.idContrato + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        bControle = true;
                        objRetorno.idContrato = EmcResources.cInt(drCon["idevt_contrato"].ToString());
                        objRetorno.dataContrato = Convert.ToDateTime(drCon["datacontrato"].ToString());
                        objRetorno.valorContrato = EmcResources.cCur(drCon["valorcontrato"].ToString());
                        objRetorno.nroParcelas = EmcResources.cInt(drCon["nroparcelas"].ToString());

                        SubLocacao oSubLoc = new SubLocacao();
                        oSubLoc.idSublocacao = EmcResources.cInt(drCon["idev_sublocacao"].ToString());
                        objRetorno.subLocacao = oSubLoc;

                        Cliente oCliente = new Cliente();
                        oCliente.idPessoa = EmcResources.cInt(drCon["cliente_idPessoa"].ToString());
                        oCliente.codEmpresa = EmcResources.cInt(drCon["cliente_CodEmpresa"].ToString());
                        objRetorno.cliente = oCliente;

                        Fornecedor oFornecedor = new Fornecedor();
                        oFornecedor.idPessoa = EmcResources.cInt(drCon["fornecedor_idPessoa"].ToString());
                        oFornecedor.codEmpresa = EmcResources.cInt(drCon["fornecedor_CodEmpresa"].ToString());
                        objRetorno.fornecedor = oFornecedor;

                        objRetorno.geraContasPagar = drCon["geraContasPagar"].ToString();
                        objRetorno.geraTaxaAdministracao = drCon["geraTaxaAdministracao"].ToString();
                        objRetorno.percenturalAdministracao = EmcResources.cCur(drCon["percenturalAdministracao"].ToString());
                        objRetorno.valorAdministracao = EmcResources.cCur(drCon["valoradministracao"].ToString());
                        objRetorno.dataAprovacao = Convert.ToDateTime(drCon["dataaprovacao"].ToString());
                        objRetorno.situacao = drCon["situacao"].ToString();

                        Usuario oUsuario = new Usuario();
                        oUsuario.idUsuario = EmcResources.cInt(drCon["idusuariocontrato"].ToString());
                        objRetorno.usuario = oUsuario;
                        
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (bControle)
                    {
                        SubLocacaoDAO oSubLocDAO = new SubLocacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.subLocacao = oSubLocDAO.ObterPor(objRetorno.subLocacao);

                        ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.cliente = oClienteDAO.ObterPor(objRetorno.cliente);

                        FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.fornecedor = oFornecedorDAO.ObterPor(objRetorno.fornecedor);

                        UsuarioDAO oUsuarioDAO = new UsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.usuario = oUsuarioDAO.ObterPor(objRetorno.usuario);

                    }
                }
                return objRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }
        }

        public Contrato ObterPorLstContrato(Contrato oContrato)
        {
            bool Consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from evt_contrato Where idevt_contrato = @idevt_contrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_contrato", oContrato.idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Contrato objContrato = new Contrato();

                while (drCon.Read())
                {
                    Consulta = true;

                    objContrato.idContrato = EmcResources.cInt(drCon["idevt_contrato"].ToString());
                    objContrato.dataContrato = Convert.ToDateTime(drCon["datacontrato"].ToString());
                    objContrato.valorContrato = EmcResources.cCur(drCon["valorcontrato"].ToString());
                    objContrato.nroParcelas = EmcResources.cInt(drCon["nroparcelas"].ToString());

                    SubLocacao oSubLoc = new SubLocacao();
                    oSubLoc.idSublocacao = EmcResources.cInt(drCon["idev_sublocacao"].ToString());
                    objContrato.subLocacao = oSubLoc;

                    Cliente oCliente = new Cliente();
                    oCliente.idPessoa = EmcResources.cInt(drCon["cliente_idPessoa"].ToString());
                    oCliente.codEmpresa = EmcResources.cInt(drCon["cliente_CodEmpresa"].ToString());
                    objContrato.cliente = oCliente;

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.idPessoa = EmcResources.cInt(drCon["fornecedor_idPessoa"].ToString());
                    oFornecedor.codEmpresa = EmcResources.cInt(drCon["fornecedor_CodEmpresa"].ToString());
                    objContrato.fornecedor = oFornecedor;

                    objContrato.geraContasPagar = drCon["geraContasPagar"].ToString();
                    objContrato.geraTaxaAdministracao = drCon["geraTaxaAdministracao"].ToString();
                    objContrato.percenturalAdministracao = EmcResources.cCur(drCon["percenturalAdministracao"].ToString());
                    objContrato.valorAdministracao = EmcResources.cCur(drCon["valoradministracao"].ToString());
                    objContrato.dataAprovacao = Convert.ToDateTime(drCon["dataaprovacao"].ToString());
                    objContrato.situacao = drCon["situacao"].ToString();

                    Usuario oUsuario = new Usuario();
                    oUsuario.idUsuario = EmcResources.cInt(drCon["idusuariocontrato"].ToString());
                    objContrato.usuario = oUsuario;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                return objContrato;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(Contrato oContrato, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oContrato.idContrato.ToString();

                if (flag == "A")
                {

                    Contrato objContrato = new Contrato();
                    objContrato = ObterPor(oContrato);

                    if (!objContrato.Equals(oContrato))
                    {
                        descricao = "Contrato id: " + oContrato.idContrato + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!objContrato.dataContrato.Equals(oContrato.dataContrato))
                        {
                            descricao += " Data Contrato de " + objContrato.dataContrato + " para " + oContrato.dataContrato;
                        }                        
                        if (!objContrato.valorContrato.Equals(oContrato.valorContrato))
                        {
                            descricao += " Valor Contrato de " + objContrato.valorContrato + " para " + oContrato.valorContrato;
                        }
                        if (!objContrato.nroParcelas.Equals(oContrato.nroParcelas))
                        {
                            descricao += " Nro Parcelas de " + objContrato.nroParcelas + " para " + oContrato.nroParcelas;
                        }
                        if (!objContrato.subLocacao.idSublocacao.Equals(oContrato.subLocacao.idSublocacao))
                        {
                            descricao += " Sub Locação de " + objContrato.subLocacao.idSublocacao + " para " + oContrato.subLocacao.idSublocacao;
                        }
                        if (!objContrato.cliente.idPessoa.Equals(oContrato.cliente.idPessoa))
                        {
                            descricao += " Cliente de " + objContrato.cliente.idPessoa + " para " + oContrato.cliente.idPessoa;
                        }
                        if (!objContrato.fornecedor.idPessoa.Equals(oContrato.fornecedor.idPessoa))
                        {
                            descricao += " Fornecedor de " + objContrato.fornecedor.idPessoa + " para " + oContrato.fornecedor.idPessoa;
                        }
                        if (!objContrato.geraContasPagar.Equals(oContrato.geraContasPagar))
                        {
                            descricao += " Gera Contas a Pagar de " + objContrato.geraContasPagar + " para " + oContrato.geraContasPagar;
                        }
                        if (!objContrato.geraTaxaAdministracao.Equals(oContrato.geraTaxaAdministracao))
                        {
                            descricao += " Gera Taxa Adm. de " + objContrato.geraTaxaAdministracao + " para " + oContrato.geraTaxaAdministracao;
                        }
                        if (!objContrato.percenturalAdministracao.Equals(oContrato.percenturalAdministracao))
                        {
                            descricao += " Percentural Adm. de " + objContrato.percenturalAdministracao + " para " + oContrato.percenturalAdministracao;
                        }
                        if (!objContrato.valorAdministracao.Equals(oContrato.valorAdministracao))
                        {
                            descricao += " Valor Administração de " + objContrato.valorAdministracao + " para " + oContrato.valorAdministracao;
                        }
                        if (!objContrato.dataAprovacao.Equals(oContrato.dataAprovacao))
                        {
                            descricao += " Data Aprovação de " + objContrato.dataAprovacao + " para " + oContrato.dataAprovacao;
                        }
                        if (!objContrato.situacao.Equals(oContrato.situacao))
                        {
                            descricao += " Situação de " + objContrato.situacao + " para " + oContrato.situacao;
                        }                       
                        
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Contrato : " + oContrato.idContrato +
                        " Data Contrato: " + oContrato.dataContrato +
                        " Valor Contrato: " + oContrato.valorContrato +
                        " Nro Parcela: " + oContrato.nroParcelas +
                        "SubLocação : " + oContrato.subLocacao.idSublocacao +
                        "Cliente : " + oContrato.cliente.idPessoa +
                        "Fornecedor : " + oContrato.fornecedor.idPessoa +
                        "Gera Contas Pagar : " + oContrato.geraContasPagar +
                        "Gera Taxa Adm : " + oContrato.geraTaxaAdministracao +
                        "Percentural Adm : " + oContrato.percenturalAdministracao +
                        "Valor Administração : " + oContrato.valorAdministracao +
                        "Data Aprovação : " + oContrato.dataAprovacao +
                        "Situação : " + oContrato.situacao +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contrato : " + oContrato.idContrato +
                        " Data Contrato: " + oContrato.dataContrato +
                        " Valor Contrato: " + oContrato.valorContrato +
                        " Nro Parcela: " + oContrato.nroParcelas +
                        "SubLocação : " + oContrato.subLocacao.idSublocacao +
                        "Cliente : " + oContrato.cliente.idPessoa +
                        "Fornecedor : " + oContrato.fornecedor.idPessoa +
                        "Gera Contas Pagar : " + oContrato.geraContasPagar +
                        "Gera Taxa Adm : " + oContrato.geraTaxaAdministracao +
                        "Percentural Adm : " + oContrato.percenturalAdministracao +
                        "Valor Administração : " + oContrato.valorAdministracao +
                        "Data Aprovação : " + oContrato.dataAprovacao +
                        "Situação : " + oContrato.situacao +
                        " foi exluido por " + oOcorrencia.usuario.nome;
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
