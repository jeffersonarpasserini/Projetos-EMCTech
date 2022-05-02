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
using EMCIntegracaoDAO;
using EMCIntegracaoModel;

namespace EMCFinanceiroDAO
{
    public class ReceberDocumentoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberDocumentoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public int Salvar(ReceberDocumento objReceberDocumento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                int idDocReceber = 0;
                idDocReceber = Salvar(Conexao, transacao, objReceberDocumento);

                transacao.Commit();

                return idDocReceber;
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
        public int Salvar(MySqlConnection Conecta, MySqlTransaction transacao, ReceberDocumento objReceberDocumento)
        {

            //Grava um novo registro de ReceberDocumento
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'ReceberDocumento'"+
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idReceber = 0;
                while (drCon.Read())
                {
                    idReceber = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    objReceberDocumento.idReceberDocumento = idReceber;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objReceberDocumento, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into ReceberDocumento (empresa_idempresa, nrodocumento, dataemissao, dataentrada, valordocumento, " +
                                                            "nroparcelas, periodicidade, diafixo, origemdocumento, descricao, " +
                                                            "idtipodocumento, idindexador, " +
                                                            "cliente_codempresa, idcliente, idfatura, cadastro_idusuario, cadastro_datahora, " + 
                                                            " situacao, taxajuros, taxamulta ) " + 
                                                            "values (@codempresa, @nrodocumento, @dataemissao, @dataentrada, " +
                                                            "@valordocumento, @nroparcelas, @periodicidade, @diafixo, @origemdocumento, @descricao, " +
                                                            "@idtipodocumento, @idindexador, @cliente_codempresa, @idcliente, @idfatura, @cadastro_idusuario, " + 
                                                            "@cadastro_datahora, @situacao, @taxajuros, @taxamulta )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objReceberDocumento.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", objReceberDocumento.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@dataemissao", objReceberDocumento.dataEmissao);
                Sqlcon.Parameters.AddWithValue("@dataentrada", objReceberDocumento.dataEntrada);
                Sqlcon.Parameters.AddWithValue("@valordocumento", objReceberDocumento.valorDocumento);
                Sqlcon.Parameters.AddWithValue("@nroparcelas", objReceberDocumento.nroParcelas);
                Sqlcon.Parameters.AddWithValue("@periodicidade", objReceberDocumento.periodicidade);
                Sqlcon.Parameters.AddWithValue("@diafixo", objReceberDocumento.diaFixo);
                Sqlcon.Parameters.AddWithValue("@origemdocumento", objReceberDocumento.origemDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", objReceberDocumento.descricao);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", objReceberDocumento.tipoDocumento.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@idindexador", objReceberDocumento.indexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@cliente_codempresa", objReceberDocumento.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", objReceberDocumento.cliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idfatura", null);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", objReceberDocumento.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objReceberDocumento.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@situacao", objReceberDocumento.situacao);
                Sqlcon.Parameters.AddWithValue("@taxajuros", objReceberDocumento.taxaJuros);
                Sqlcon.Parameters.AddWithValue("@taxamulta", objReceberDocumento.taxaMulta);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                //grava parcelas
                ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ReceberParcela objParcela in objReceberDocumento.parcelas)
                {
                    objParcela.receberDocumento.idReceberDocumento = idReceber;
                    oParcelaDAO.Salvar(objParcela, Conecta, transacao);
                }


                //GRAVA BASE RATEIO
                Boolean retornoRateio = false;
                List<ReceberBaseRateio> lstBaseRateio = new List<ReceberBaseRateio>();
                foreach (ReceberBaseRateio oRat in objReceberDocumento.baseRateio)
                {
                    oRat.idReceberDocumento = idReceber;
                    lstBaseRateio.Add(oRat);
                }


                ReceberBaseRateioDAO oRateioDAO = new ReceberBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                retornoRateio = oRateioDAO.Salvar(Conecta, transacao, lstBaseRateio);

                //se houve alterações na base rateio refaz o pagarrateio.
                if (retornoRateio)
                {
                    ReceberRateioDAO oRateio = new ReceberRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.rateioBaixaDocumento(objReceberDocumento, Conecta, transacao);
                }

                return idReceber;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Atualizar(ReceberDocumento objReceberDocumento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {

                Atualizar(Conexao, transacao, objReceberDocumento);
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
        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, ReceberDocumento objReceberDocumento)
        {
            
            //atualiza um registro de ReceberDocumento
            try
            {
                geraOcorrencia(objReceberDocumento, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update ReceberDocumento set dataemissao=@dataemissao, valordocumento=@valordocumento, dataentrada=@dataentrada, " + 
                                                         " nroparcelas=@nroparcelas, periodicidade=@periodicidade, " + 
                                                         " diafixo=@diafixo, descricao=@descricao, idtipodocumento=@idtipodocumento, " + 
                                                         " idindexador=@idindexador, " + 
                                                         " cliente_codempresa=@cliente_codempresa, idcliente=@idcliente, " + 
                                                         " cadastro_idusuario=@cadastro_idusuario, cadastro_datahora=@cadastro_datahora, " +
                                                         " taxajuros=@taxajuros, taxamulta=@taxamulta " +
                                                         " where idReceberDocumento = @idReceberDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idReceberDocumento", objReceberDocumento.idReceberDocumento);
                Sqlcon.Parameters.AddWithValue("@codempresa", objReceberDocumento.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", objReceberDocumento.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@dataemissao", objReceberDocumento.dataEmissao);
                Sqlcon.Parameters.AddWithValue("@dataentrada", objReceberDocumento.dataEntrada);
                Sqlcon.Parameters.AddWithValue("@valordocumento", objReceberDocumento.valorDocumento);
                Sqlcon.Parameters.AddWithValue("@nroparcelas", objReceberDocumento.nroParcelas);
                Sqlcon.Parameters.AddWithValue("@periodicidade", objReceberDocumento.periodicidade);
                Sqlcon.Parameters.AddWithValue("@diafixo", objReceberDocumento.diaFixo);
                Sqlcon.Parameters.AddWithValue("@origemdocumento", objReceberDocumento.origemDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", objReceberDocumento.descricao);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", objReceberDocumento.tipoDocumento.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@idindexador", objReceberDocumento.indexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@cliente_codempresa", objReceberDocumento.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idcliente", objReceberDocumento.cliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idfatura", objReceberDocumento.idFatura);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", objReceberDocumento.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objReceberDocumento.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@taxajuros", objReceberDocumento.taxaJuros);
                Sqlcon.Parameters.AddWithValue("@taxamulta", objReceberDocumento.taxaMulta);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                //grava parcelas
                ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ReceberParcela objParcela in objReceberDocumento.parcelas)
                {
                    if (objParcela.status == "E")
                    {
                        oParcelaDAO.Excluir(objParcela, Conexao, transacao);
                    }
                    else if (objParcela.status == "A")
                    {
                        oParcelaDAO.Atualizar(objParcela, Conexao, transacao);
                    }
                    else if (objParcela.status == "I")
                    {
                        oParcelaDAO.Salvar(objParcela, Conexao, transacao);
                    }
                }

                //GRAVA BASE RATEIO
                Boolean retornoRateio = false;
                ReceberBaseRateioDAO oRateioDAO = new ReceberBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                retornoRateio = oRateioDAO.Salvar(Conexao, transacao, objReceberDocumento.baseRateio);

                //se houve alteracao na base de rateio refaz o rateio dos pagamentos
                if (retornoRateio)
                {
                    ReceberRateioDAO oRateio = new ReceberRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.rateioBaixaDocumento(objReceberDocumento, Conexao, transacao);
                }

               
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void atualizarBaseRateio(ReceberDocumento objReceberDocumento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de PagarDocumento
            try
            {
                geraOcorrencia(objReceberDocumento, "A");

                //GRAVA BASE RATEIO
                Boolean retornoRateio = false;
                ReceberBaseRateioDAO oRateioDAO = new ReceberBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                retornoRateio = oRateioDAO.Salvar(Conexao, transacao, objReceberDocumento.baseRateio);

                //se houve alteracao na base de rateio refaz o rateio dos pagamentos
                if (retornoRateio)
                {
                    ReceberRateioDAO oRateio = new ReceberRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.rateioBaixaDocumento(objReceberDocumento, Conexao, transacao);
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

        public void Excluir(ReceberDocumento objReceberDocumento)
        {
            //apaga registro de ReceberDocumento
            MySqlTransaction transacao = Conexao.BeginTransaction();
            try
            {
                geraOcorrencia(objReceberDocumento, "E");
                
                // eliminando integraçãoes nivel documento
                if (objReceberDocumento.origemDocumento != "CTARECEBER")
                {
                    IntegFinanceiro oIntegFinanceiro = new IntegFinanceiro();
                    IntegFinanceiroDAO oIntegFinanceiroDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);

                    if (objReceberDocumento.origemDocumento == "EMCIMOB")
                    {
                        // não faz nada integração nivel de parcela.
                    }

                }

                //excluindo todas as parcelas
                ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ReceberParcela objParcela in objReceberDocumento.parcelas)
                {
                    oParcelaDAO.Excluir(objParcela, Conexao, transacao);
                }


                //GRAVA BASE RATEIO
                ReceberBaseRateioDAO oRateioDAO = new ReceberBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                oRateioDAO.Excluir(Conexao, transacao, objReceberDocumento.baseRateio);

                //Monta comando para a gravação do registro
                String strSQL = "delete from ReceberDocumento where idReceberDocumento = @idReceberDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idReceberDocumento", objReceberDocumento.idReceberDocumento);

                //abre conexao e executa o comando
               
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

        public void alteraSitucao(MySqlConnection Conecta, MySqlTransaction Transacao,ReceberDocumento objReceberDocumento, string Situacao)
        {
            
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update ReceberDocumento set situacao=@situacao where idReceberDocumento = @idReceberDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@idReceberDocumento", objReceberDocumento.idReceberDocumento);
                Sqlcon.Parameters.AddWithValue("@situacao", Situacao);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        
        public DataTable ListaReceberDocumento(int codEmpresa)
        {

            try
            {
            
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberDocumento order by nrodocumento where empresa_idempresa = @codempresa";
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

        public DataTable pesquisaReceberDocumento(int codEmpresa, int empMaster, int idCliente, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
        {

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select d.idReceberDocumento, d.nrodocumento, d.dataemissao, d.dataentrada, d.valordocumento, p.nome as nomecliente, d.situacao " + 
                                                                 " from ReceberDocumento d, pessoa p where d.empresa_idempresa=@codempresa " + 
                                                                          " and p.codempresa = d.cliente_codempresa " + 
                                                                          " and p.idpessoa = d.idcliente ";

               //Documento com situação em aberto
                if (docAberto)
                    strSQL += " and situacao = 'A' ";
                
                //filtra fornecedor
                if (idCliente > 0)
                    strSQL += " and cliente_codempresa=@cliente_codempresa and idcliente=@idcliente ";

                //filtra por data
                if (!chkTodasContas)
                    strSQL += " and dataemissao >= @datainicio and dataemissao <= @datafinal ";

                //filtra por valor
                if (!valorDocumento)
                {
                    strSQL += " and valordocumento >= @valorinicio ";
                    if (valorFinal > 0 && valorFinal >= valorInicio)
                        strSQL += " and valordocumento <= @valorfinal";

                }
                strSQL += " order by nrodocumento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@cliente_codempresa", empMaster);
                Sqlcon.Parameters.AddWithValue("@idcliente", idCliente);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@valorinicio", valorInicio);
                Sqlcon.Parameters.AddWithValue("@valorfinal", valorFinal);

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

        public ReceberDocumento ObterPor(ReceberDocumento oReceberDocumento)
        {
            bool Consulta = false;

            try
            {
                string strSQL = "";
                MySqlCommand Sqlcon = null;
                //Monta comando para a gravação do registro
                if (oReceberDocumento.idReceberDocumento > 0)
                {
                    strSQL = "select * from ReceberDocumento Where idReceberDocumento = @idReceberDocumento ";
                    Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idReceberDocumento", oReceberDocumento.idReceberDocumento);
                }
                else
                {
                    strSQL = "select * from ReceberDocumento Where empresa_idempresa=@codempresa and nrodocumento = @idReceberDocumento "+
                                                             " and cliente_codempresa=@emp and idcliente=@cli "; ;
                    Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codempresa", oReceberDocumento.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idReceberDocumento", oReceberDocumento.nroDocumento);
                    Sqlcon.Parameters.AddWithValue("@emp", oReceberDocumento.cliente.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@cli", oReceberDocumento.cliente.idPessoa);
                }
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                ReceberDocumento objReceberDocumento = new ReceberDocumento();
                while (drCon.Read())
                {
                    Consulta = true;        
                    objReceberDocumento.idReceberDocumento = Convert.ToInt32(drCon["idReceberDocumento"].ToString());
                    objReceberDocumento.codEmpresa = Convert.ToInt32(drCon["empresa_idempresa"].ToString());
                    objReceberDocumento.nroDocumento = drCon["nrodocumento"].ToString();
                    objReceberDocumento.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    objReceberDocumento.dataEntrada = Convert.ToDateTime(drCon["dataentrada"].ToString());
                    objReceberDocumento.valorDocumento = EmcResources.cCur(drCon["valordocumento"].ToString());
                    objReceberDocumento.nroParcelas = Convert.ToInt32(drCon["nroparcelas"].ToString());
                    objReceberDocumento.periodicidade = drCon["periodicidade"].ToString();
                    objReceberDocumento.diaFixo = drCon["diafixo"].ToString();
                    objReceberDocumento.origemDocumento = drCon["origemdocumento"].ToString();
                    objReceberDocumento.descricao = drCon["descricao"].ToString();
                    objReceberDocumento.situacao = drCon["situacao"].ToString();
                    objReceberDocumento.taxaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString());
                    objReceberDocumento.taxaJuros = EmcResources.cDouble(drCon["taxajuros"].ToString());

                    TipoDocumento oTipoDocumento = new TipoDocumento();
                    oTipoDocumento.idTipoDocumento = Convert.ToInt32(drCon["idtipodocumento"].ToString());
                    objReceberDocumento.tipoDocumento = oTipoDocumento;

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = Convert.ToInt32(drCon["idindexador"].ToString());
                    objReceberDocumento.indexador = oIndexador;
                    

                    Cliente oCliente = new Cliente();
                    oCliente.codEmpresa = Convert.ToInt32(drCon["cliente_codempresa"].ToString());
                    oCliente.idPessoa = Convert.ToInt32(drCon["idcliente"].ToString());
                    objReceberDocumento.cliente = oCliente;

                    objReceberDocumento.idFatura = EmcResources.cInt(drCon["idfatura"].ToString());
                    objReceberDocumento.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objReceberDocumento.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    ReceberParcela oParcela = new ReceberParcela();
                    oParcela.receberDocumento = objReceberDocumento;

                    List<ReceberParcela> lstParcela2 = new List<ReceberParcela>();
                    lstParcela2 = oParcelaDAO.ParcelaDocumento(oParcela);

                    objReceberDocumento.parcelas = lstParcela2;

                    ReceberBaseRateioDAO oBaseRateioDAO = new ReceberBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    List<ReceberBaseRateio> lstBaseRateio = new List<ReceberBaseRateio>();
                    lstBaseRateio = oBaseRateioDAO.listaRateioDocumento(EmcResources.cInt(objReceberDocumento.idReceberDocumento.ToString()));
                    objReceberDocumento.baseRateio = lstBaseRateio;

                    TipoDocumentoDAO oTipoDAO = new TipoDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberDocumento.tipoDocumento = oTipoDAO.ObterPor(objReceberDocumento.tipoDocumento);

                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberDocumento.indexador = oIndexadorDAO.ObterPor(objReceberDocumento.indexador);

                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberDocumento.cliente = oClienteDAO.ObterPor(objReceberDocumento.cliente);
                }
                return objReceberDocumento;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        /// <summary>
        /// Realiza
        /// </summary>
        /// <param name="oReceberDocumento"></param>
        /// <returns></returns>
        public ReceberDocumento ObterDocParcela(ReceberDocumento oReceberDocumento)
        {
            bool Consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberDocumento Where idReceberDocumento = @idReceberDocumento ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberDocumento", oReceberDocumento.idReceberDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                ReceberDocumento objReceberDocumento = new ReceberDocumento();

                while (drCon.Read())
                {
                    Consulta = true;
                    objReceberDocumento.idReceberDocumento = Convert.ToInt32(drCon["idReceberDocumento"].ToString());
                    objReceberDocumento.codEmpresa = Convert.ToInt32(drCon["empresa_idempresa"].ToString());
                    objReceberDocumento.nroDocumento = drCon["nrodocumento"].ToString();
                    objReceberDocumento.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    objReceberDocumento.dataEntrada = Convert.ToDateTime(drCon["dataentrada"].ToString());
                    objReceberDocumento.valorDocumento = EmcResources.cCur(drCon["valordocumento"].ToString());
                    objReceberDocumento.nroParcelas = Convert.ToInt32(drCon["nroparcelas"].ToString());
                    objReceberDocumento.periodicidade = drCon["periodicidade"].ToString();
                    objReceberDocumento.diaFixo = drCon["diafixo"].ToString();
                    objReceberDocumento.origemDocumento = drCon["origemdocumento"].ToString();
                    objReceberDocumento.descricao = drCon["descricao"].ToString();
                    objReceberDocumento.idFatura = EmcResources.cInt(drCon["idfatura"].ToString());
                    objReceberDocumento.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objReceberDocumento.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objReceberDocumento.situacao = drCon["situacao"].ToString();
                    objReceberDocumento.taxaMulta = EmcResources.cDouble(drCon["taxamulta"].ToString());
                    objReceberDocumento.taxaJuros = EmcResources.cDouble(drCon["taxajuros"].ToString());
                    
                    TipoDocumento oTipoDocumento = new TipoDocumento();
                    oTipoDocumento.idTipoDocumento = Convert.ToInt32(drCon["idtipodocumento"].ToString());
                    objReceberDocumento.tipoDocumento = oTipoDocumento;

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = Convert.ToInt32(drCon["idindexador"].ToString());
                    objReceberDocumento.indexador = oIndexador;

                    Cliente oCliente = new Cliente();
                    oCliente.codEmpresa = Convert.ToInt32(drCon["cliente_codempresa"].ToString());
                    oCliente.idPessoa = Convert.ToInt32(drCon["idcliente"].ToString());
                    objReceberDocumento.cliente = oCliente;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    TipoDocumentoDAO oTipoDAO = new TipoDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberDocumento.tipoDocumento = oTipoDAO.ObterPor(objReceberDocumento.tipoDocumento);

                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberDocumento.indexador = oIndexadorDAO.ObterPor(objReceberDocumento.indexador);

                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    objReceberDocumento.cliente = oClienteDAO.ObterPor(objReceberDocumento.cliente);

                    ReceberBaseRateioDAO oBaseRateioDAO = new ReceberBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    List<ReceberBaseRateio> lstBaseRateio = new List<ReceberBaseRateio>();
                    lstBaseRateio = oBaseRateioDAO.listaRateioDocumento(EmcResources.cInt(objReceberDocumento.idReceberDocumento.ToString()));
                    objReceberDocumento.baseRateio = lstBaseRateio;
                }
                return objReceberDocumento;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(ReceberDocumento oReceberDocumento, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oReceberDocumento.idReceberDocumento.ToString();

                if (flag == "A")
                {

                    ReceberDocumento oPgDocumento = new ReceberDocumento();
                    oPgDocumento = ObterPor(oReceberDocumento);

                    if (!oPgDocumento.Equals(oReceberDocumento))
                    {
                        descricao = " Cod empresa : " + oReceberDocumento.codEmpresa + "Documento id: " + oReceberDocumento.idReceberDocumento + " Nro documento :" + oReceberDocumento.nroDocumento  + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oPgDocumento.dataEmissao.Equals(oReceberDocumento.dataEmissao))
                        {
                            descricao += " Data Emissão de " + oPgDocumento.dataEmissao + " para " + oReceberDocumento.dataEmissao;
                        }
                        if (!oPgDocumento.dataEntrada.Equals(oReceberDocumento.dataEntrada))
                        {
                            descricao += " Data Entrada de " + oPgDocumento.dataEntrada + " para " + oReceberDocumento.dataEntrada;
                        }
                        if (!oPgDocumento.valorDocumento.Equals(oReceberDocumento.valorDocumento))
                        {
                            descricao += " Valor Docuemento  de " + oPgDocumento.valorDocumento + " para " + oReceberDocumento.valorDocumento;
                        }
                        if (!oPgDocumento.nroParcelas.Equals(oReceberDocumento.nroParcelas))
                        {
                            descricao += " Nro Parcelas  de " + oPgDocumento.nroParcelas + " para " + oReceberDocumento.valorDocumento;
                        }
                        if (!oPgDocumento.periodicidade.Equals(oReceberDocumento.periodicidade))
                        {
                            descricao += " Periodicidade  de " + oPgDocumento.periodicidade + " para " + oReceberDocumento.periodicidade;
                        }
                        if (!oPgDocumento.diaFixo.Equals(oReceberDocumento.diaFixo))
                        {
                            descricao += " Dia Fixo  de " + oPgDocumento.diaFixo + " para " + oReceberDocumento.diaFixo;
                        }
                        if (!oPgDocumento.origemDocumento.Equals(oReceberDocumento.origemDocumento))
                        {
                            descricao += " Origem Documento  de " + oPgDocumento.origemDocumento + " para " + oReceberDocumento.origemDocumento;
                        }
                        if (!oPgDocumento.descricao.Equals(oReceberDocumento.descricao))
                        {
                            descricao += " Descricao  de " + oPgDocumento.descricao + " para " + oReceberDocumento.descricao;
                        }
                        if (!oPgDocumento.tipoDocumento.idTipoDocumento.Equals(oReceberDocumento.tipoDocumento.idTipoDocumento))
                        {
                            descricao += " Tipo Documento  de " + oPgDocumento.tipoDocumento.idTipoDocumento + " - " + oPgDocumento.tipoDocumento.descricao + 
                                                    " para " + oReceberDocumento.tipoDocumento.idTipoDocumento + " - " + oReceberDocumento.tipoDocumento.descricao;
                        }
                        if (!oPgDocumento.indexador.idIndexador.Equals(oReceberDocumento.indexador.idIndexador))
                        {
                            descricao += " Indexador  de " + oPgDocumento.indexador.idIndexador + " - " + oPgDocumento.indexador.descricao +
                                                    " para " + oReceberDocumento.indexador.idIndexador + " - " + oReceberDocumento.indexador.descricao;
                        }
                        if (!oPgDocumento.cliente.idPessoa.Equals(oReceberDocumento.cliente.idPessoa))
                        {
                            descricao += " Cliente  de " + oPgDocumento.cliente.idPessoa + " - " + oPgDocumento.cliente.pessoa.nome +
                                               " para " + oReceberDocumento.cliente.idPessoa + " - " + oReceberDocumento.cliente.pessoa.nome;
                        }
                        if (!oPgDocumento.idFatura.Equals(oReceberDocumento.idFatura))
                        {
                            descricao += " Fatura de " + oPgDocumento.idFatura + " - " + " para " + oReceberDocumento.idFatura;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "Parcela Pagar id : " + oReceberDocumento.idReceberDocumento +
                                " - CodEmpresa - " + oReceberDocumento.codEmpresa +
                                " - Documento - " + oReceberDocumento.nroDocumento +
                                " - Nro Parcelas - " + oReceberDocumento.nroParcelas +
                                " - Data Emissão - " + oReceberDocumento.dataEmissao +
                                " - Data Entrada - " + oReceberDocumento.dataEntrada +
                                " - Valor Documento - " + oReceberDocumento.valorDocumento +
                                " - Periodicidade - " + oReceberDocumento.periodicidade +
                                " - Dia Fixo - " + oReceberDocumento.diaFixo +
                                " - Origem Documento - " + oReceberDocumento.origemDocumento +
                                " - Descrição - " + oReceberDocumento.descricao +
                                " - Tipo Documento - " + oReceberDocumento.tipoDocumento.idTipoDocumento + " - " + oReceberDocumento.tipoDocumento.descricao +
                                " - Indexador - " + oReceberDocumento.indexador.idIndexador + " - " +oReceberDocumento.indexador.descricao + 
                                " - Fornecedor - " + oReceberDocumento.cliente.idPessoa + " - " + oReceberDocumento.cliente.pessoa.nome + 
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Parcela Pagar id : " + oReceberDocumento.idReceberDocumento +
                                " - CodEmpresa - " + oReceberDocumento.codEmpresa +
                                " - Documento - " + oReceberDocumento.nroDocumento +
                                " - Nro Parcelas - " + oReceberDocumento.nroParcelas +
                                " - Data Emissão - " + oReceberDocumento.dataEmissao +
                                " - Data Entrada - " + oReceberDocumento.dataEntrada +
                                " - Valor Documento - " + oReceberDocumento.valorDocumento +
                                " - Periodicidade - " + oReceberDocumento.periodicidade +
                                " - Dia Fixo - " + oReceberDocumento.diaFixo +
                                " - Origem Documento - " + oReceberDocumento.origemDocumento +
                                " - Descrição - " + oReceberDocumento.descricao +
                                " - Tipo Documento - " + oReceberDocumento.tipoDocumento.idTipoDocumento + " - " + oReceberDocumento.tipoDocumento.descricao +
                                " - Indexador - " + oReceberDocumento.indexador.idIndexador + " - " + oReceberDocumento.indexador.descricao +
                                " - Fornecedor - " + oReceberDocumento.cliente.idPessoa + " - " + oReceberDocumento.cliente.pessoa.nome +
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
