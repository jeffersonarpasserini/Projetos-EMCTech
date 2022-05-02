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
using EMCIntegracaoModel;
using EMCIntegracaoDAO;

namespace EMCFinanceiroDAO
{
    public class PagarDocumentoDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarDocumentoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public int Salvar(PagarDocumento objPagarDocumento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                int idDocPagar = 0;
                idDocPagar = Salvar(Conexao, transacao, objPagarDocumento);

                transacao.Commit();

                return idDocPagar;

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
        public int Salvar(MySqlConnection Conecta, MySqlTransaction transacao, PagarDocumento objPagarDocumento)
        {

            //Grava um novo registro de PagarDocumento
            try
            {

                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'pagardocumento'" + 
                                 "  and a.table_schema ='"+schemaBD.Trim()+"'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idPagar = 0;
                while (drCon.Read())
                {
                    idPagar = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    objPagarDocumento.idPagarDocumento = idPagar;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objPagarDocumento, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into PagarDocumento (codempresa, nrodocumento, dataemissao, dataentrada, valordocumento, " +
                                                            "nroparcelas, periodicidade, diafixo, origemdocumento, descricao, " +
                                                            "idtipodocumento, idindexador, " +
                                                            "fornecedor_codempresa, idfornecedor, idfatura, cadastro_idusuario, cadastro_datahora, situacao, " +
                                                            " valorindexado, dataultimacorrecao, valorindice ) " +
                                                            "values (@codempresa, @nrodocumento, @dataemissao, @dataentrada, " +
                                                            "@valordocumento, @nroparcelas, @periodicidade, @diafixo, @origemdocumento, @descricao, " +
                                                            "@idtipodocumento, @idindexador, @fornecedor_codempresa, @idfornecedor, @idfatura, @cadastro_idusuario, @cadastro_datahora, @situacao, " + 
                                                            "@valorindexado, @dataultimacorrecao, @valorindice )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objPagarDocumento.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", objPagarDocumento.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@dataemissao", objPagarDocumento.dataEmissao);
                Sqlcon.Parameters.AddWithValue("@dataentrada", objPagarDocumento.dataEntrada);
                Sqlcon.Parameters.AddWithValue("@valordocumento", objPagarDocumento.valorDocumento);
                Sqlcon.Parameters.AddWithValue("@nroparcelas", objPagarDocumento.nroParcelas);
                Sqlcon.Parameters.AddWithValue("@periodicidade", objPagarDocumento.periodicidade);
                Sqlcon.Parameters.AddWithValue("@diafixo", objPagarDocumento.diaFixo);
                Sqlcon.Parameters.AddWithValue("@origemdocumento", objPagarDocumento.origemDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", objPagarDocumento.descricao);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", objPagarDocumento.tipoDocumento.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@idindexador", objPagarDocumento.indexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", objPagarDocumento.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", objPagarDocumento.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idfatura", null);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", objPagarDocumento.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objPagarDocumento.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@situacao", objPagarDocumento.situacao);
                Sqlcon.Parameters.AddWithValue("@valorindexado", objPagarDocumento.valorIndexado);
                Sqlcon.Parameters.AddWithValue("@dataultimacorrecao", objPagarDocumento.dataUltimaCorrecao);
                Sqlcon.Parameters.AddWithValue("@valorindice", objPagarDocumento.valorIndice);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                //grava parcelas
                PagarParcelaDAO oParcelaDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (PagarParcela objParcela in objPagarDocumento.parcelas)
                {
                    objParcela.pagarDocumento.idPagarDocumento = idPagar;
                    oParcelaDAO.Salvar(objParcela, Conecta, transacao);
                }

                //GRAVA BASE RATEIO
                Boolean retornoRateio = false;
                List<PagarBaseRateio> lstBaseRateio = new List<PagarBaseRateio>();
                foreach(PagarBaseRateio oRat in objPagarDocumento.baseRateio)
                {
                    oRat.idPagarDocumento = idPagar;
                    lstBaseRateio.Add(oRat);
                }


                PagarBaseRateioDAO oRateioDAO = new PagarBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                retornoRateio = oRateioDAO.Salvar(Conecta, transacao, lstBaseRateio);

                //se houve alterações na base rateio refaz o pagarrateio.
                if (retornoRateio)
                {
                    PagarRateioDAO oRateio = new PagarRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.rateioBaixaDocumento(objPagarDocumento, Conecta, transacao);
                }
                return idPagar;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Atualizar(PagarDocumento objPagarDocumento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {

                Atualizar(Conexao, transacao, objPagarDocumento);
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
        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, PagarDocumento objPagarDocumento)
        {
            
            //atualiza um registro de PagarDocumento
            try
            {
                geraOcorrencia(objPagarDocumento, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update PagarDocumento set dataemissao=@dataemissao, valordocumento=@valordocumento, dataentrada=@dataentrada, " + 
                                                         " nroparcelas=@nroparcelas, periodicidade=@periodicidade, " + 
                                                         " diafixo=@diafixo, descricao=@descricao, idtipodocumento=@idtipodocumento, " + 
                                                         " idindexador=@idindexador, " + 
                                                         " fornecedor_codempresa=@fornecedor_codempresa, idfornecedor=@idfornecedor, " + 
                                                         " cadastro_idusuario=@cadastro_idusuario, cadastro_datahora=@cadastro_datahora, " +
                                                         " valorindexado=@valorindexado, dataultimacorrecao=@dataultimacorrecao, valorindice=@valorindice " +
                                                         " where idPagarDocumento = @idPagarDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarDocumento", objPagarDocumento.idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@codempresa", objPagarDocumento.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", objPagarDocumento.nroDocumento);
                Sqlcon.Parameters.AddWithValue("@dataemissao", objPagarDocumento.dataEmissao);
                Sqlcon.Parameters.AddWithValue("@dataentrada", objPagarDocumento.dataEntrada);
                Sqlcon.Parameters.AddWithValue("@valordocumento", objPagarDocumento.valorDocumento);
                Sqlcon.Parameters.AddWithValue("@nroparcelas", objPagarDocumento.nroParcelas);
                Sqlcon.Parameters.AddWithValue("@periodicidade", objPagarDocumento.periodicidade);
                Sqlcon.Parameters.AddWithValue("@diafixo", objPagarDocumento.diaFixo);
                Sqlcon.Parameters.AddWithValue("@origemdocumento", objPagarDocumento.origemDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", objPagarDocumento.descricao);
                Sqlcon.Parameters.AddWithValue("@idtipodocumento", objPagarDocumento.tipoDocumento.idTipoDocumento);
                Sqlcon.Parameters.AddWithValue("@idindexador", objPagarDocumento.indexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", objPagarDocumento.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", objPagarDocumento.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idfatura", objPagarDocumento.idFatura);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", objPagarDocumento.cadastro_idusuario);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", objPagarDocumento.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@valorindexado", objPagarDocumento.valorIndexado);
                Sqlcon.Parameters.AddWithValue("@dataultimacorrecao", objPagarDocumento.dataUltimaCorrecao);
                Sqlcon.Parameters.AddWithValue("@valorindice", objPagarDocumento.valorIndice);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                //grava parcelas
                PagarParcelaDAO oParcelaDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (PagarParcela objParcela in objPagarDocumento.parcelas)
                {
                    if (objParcela.status == "E")
                    {
                        oParcelaDAO.Excluir(objParcela, Conecta, transacao);
                    }
                    else if (objParcela.status == "A")
                    {
                        oParcelaDAO.Atualizar(objParcela, Conecta, transacao);
                    }
                    else if (objParcela.status == "I")
                    {
                        oParcelaDAO.Salvar(objParcela, Conecta, transacao);
                    }
                }

                //GRAVA BASE RATEIO
                Boolean retornoRateio = false;
                PagarBaseRateioDAO oRateioDAO = new PagarBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                retornoRateio = oRateioDAO.Salvar(Conecta, transacao, objPagarDocumento.baseRateio);

                //se houve alteracao na base de rateio refaz o rateio dos pagamentos
                if (retornoRateio)
                {
                    PagarRateioDAO oRateio = new PagarRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.rateioBaixaDocumento(objPagarDocumento, Conecta, transacao);
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void atualizarBaseRateio(PagarDocumento objPagarDocumento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de PagarDocumento
            try
            {
                geraOcorrencia(objPagarDocumento, "A");

                //GRAVA BASE RATEIO
                Boolean retornoRateio = false;
                PagarBaseRateioDAO oRateioDAO = new PagarBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                retornoRateio = oRateioDAO.Salvar(Conexao, transacao, objPagarDocumento.baseRateio);

                //se houve alteracao na base de rateio refaz o rateio dos pagamentos
                if (retornoRateio)
                {
                    PagarRateioDAO oRateio = new PagarRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.rateioBaixaDocumento(objPagarDocumento, Conexao, transacao);
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

        public void Excluir(PagarDocumento objPagarDocumento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {

                Excluir(Conexao, transacao, objPagarDocumento);
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
        public void Excluir(MySqlConnection Conecta, MySqlTransaction transacao, PagarDocumento objPagarDocumento)
        {

            try
            {
                geraOcorrencia(objPagarDocumento, "E");

                //eliminando integrações nivel documento.
                if (objPagarDocumento.origemDocumento != "CTAPAGAR")
                {
                    IntegFinanceiro oIntegFinanceiro = new IntegFinanceiro();
                    IntegFinanceiroDAO oIntegFinanceiroDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);

                    if (objPagarDocumento.origemDocumento == "EMCIMOB")
                    {
                        // não faz nada integração nivel de parcela.
                    }

                }

                //excluindo todas as parcelas
                PagarParcelaDAO oParcelaDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (PagarParcela objParcela in objPagarDocumento.parcelas)
                {
                    oParcelaDAO.Excluir(objParcela, Conecta, transacao);
                }

                //GRAVA BASE RATEIO
                PagarBaseRateioDAO oRateioDAO = new PagarBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                oRateioDAO.Excluir(Conecta, transacao, objPagarDocumento.baseRateio);
                

                //Monta comando para a gravação do registro
                String strSQL = "delete from PagarDocumento where idPagarDocumento = @idPagarDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta,transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarDocumento", objPagarDocumento.idPagarDocumento);

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

        public void alteraSitucao(MySqlConnection Conecta, MySqlTransaction Transacao,PagarDocumento objPagarDocumento, string Situacao)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update PagarDocumento set situacao=@situacao where idPagarDocumento = @idPagarDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarDocumento", objPagarDocumento.idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@situacao", Situacao);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void alteraHistoricoChequePre(MySqlConnection Conecta, MySqlTransaction Transacao, PagarDocumento objPagarDocumento, string nroCheque)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update PagarDocumento set descricao=@descricao where idPagarDocumento = @idPagarDocumento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@idPagarDocumento", objPagarDocumento.idPagarDocumento);
                Sqlcon.Parameters.AddWithValue("@descricao", objPagarDocumento.descricao+" "+nroCheque);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        
        public DataTable ListaPagarDocumento(int codEmpresa)
        {

            try
            {
            
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarDocumento order by nrodocumento where codempresa = @codempresa";
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

        public DataTable pesquisaPagarDocumento(int codEmpresa, int empMaster, int idFornecedor, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
        {

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select d.idpagardocumento, d.nrodocumento, d.dataemissao, d.dataentrada, d.valordocumento, p.nome as nomefornecedor, d.situacao " + 
                                                                 " from PagarDocumento d, pessoa p where d.codempresa=@codempresa " + 
                                                                          " and p.codempresa = d.fornecedor_codempresa " + 
                                                                          " and p.idpessoa = d.idfornecedor ";

               //Documento com situação em aberto
                if (docAberto)
                    strSQL += " and situacao = 'A' ";
                
                //filtra fornecedor
                if (idFornecedor > 0)
                    strSQL += " and fornecedor_codempresa=@fornecedor_codempresa and idfornecedor=@idfornecedor ";

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
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", empMaster);
                Sqlcon.Parameters.AddWithValue("@idfornecedor", idFornecedor);
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

        public PagarDocumento ObterPor(PagarDocumento oPagarDocumento)
        {
            bool Consulta = false;

            try
            {
                string strSQL = "";
                MySqlCommand Sqlcon = null;
                //Monta comando para a gravação do registro
                if (oPagarDocumento.idPagarDocumento > 0)
                {
                    strSQL = "select * from PagarDocumento Where idpagardocumento = @idPagarDocumento ";
                    Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idPagarDocumento", oPagarDocumento.idPagarDocumento);
                }
                else
                {
                    strSQL = "select * from PagarDocumento Where codempresa=@codempresa and nrodocumento = @idPagarDocumento "+ 
                                                           " and fornecedor_codempresa=@emp and idfornecedor=@forn ";
                    Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codempresa", oPagarDocumento.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idPagarDocumento", oPagarDocumento.nroDocumento);
                    Sqlcon.Parameters.AddWithValue("@emp", oPagarDocumento.fornecedor.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@forn", oPagarDocumento.fornecedor.idPessoa);
                }
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                PagarDocumento objPagarDocumento = new PagarDocumento();
                while (drCon.Read())
                {
                    Consulta = true;        
                    objPagarDocumento.idPagarDocumento = Convert.ToInt32(drCon["idPagarDocumento"].ToString());
                    objPagarDocumento.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objPagarDocumento.nroDocumento = drCon["nrodocumento"].ToString();
                    objPagarDocumento.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    objPagarDocumento.dataEntrada = Convert.ToDateTime(drCon["dataentrada"].ToString());
                    objPagarDocumento.valorDocumento = EmcResources.cCur(drCon["valordocumento"].ToString());
                    objPagarDocumento.nroParcelas = Convert.ToInt32(drCon["nroparcelas"].ToString());
                    objPagarDocumento.periodicidade = drCon["periodicidade"].ToString();
                    objPagarDocumento.diaFixo = drCon["diafixo"].ToString();
                    objPagarDocumento.origemDocumento = drCon["origemdocumento"].ToString();
                    objPagarDocumento.descricao = drCon["descricao"].ToString();
                    objPagarDocumento.situacao = drCon["situacao"].ToString();

                    TipoDocumento oTipoDocumento = new TipoDocumento();
                    oTipoDocumento.idTipoDocumento = Convert.ToInt32(drCon["idtipodocumento"].ToString());
                    objPagarDocumento.tipoDocumento = oTipoDocumento;

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = Convert.ToInt32(drCon["idindexador"].ToString());
                    objPagarDocumento.indexador = oIndexador;
                    
                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = Convert.ToInt32(drCon["fornecedor_codempresa"].ToString());
                    oFornecedor.idPessoa = Convert.ToInt32(drCon["idfornecedor"].ToString());
                    objPagarDocumento.fornecedor = oFornecedor;

                    objPagarDocumento.idFatura = EmcResources.cInt(drCon["idfatura"].ToString());
                    objPagarDocumento.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarDocumento.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarDocumento.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarDocumento.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarDocumento.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());

                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    PagarParcelaDAO oParcelaDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    PagarParcela oParcela = new PagarParcela();
                    oParcela.pagarDocumento = objPagarDocumento;

                    List<PagarParcela> lstParcela2 = new List<PagarParcela>();
                    lstParcela2 = oParcelaDAO.ParcelaDocumento(oParcela);

                    PagarBaseRateioDAO oBaseRateioDAO = new PagarBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    List<PagarBaseRateio> lstBaseRateio = new List<PagarBaseRateio>();
                    lstBaseRateio = oBaseRateioDAO.listaRateioDocumento(EmcResources.cInt(objPagarDocumento.idPagarDocumento.ToString()));
                    objPagarDocumento.baseRateio = lstBaseRateio;

                    objPagarDocumento.parcelas = lstParcela2;

                    TipoDocumentoDAO oTipoDAO = new TipoDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarDocumento.tipoDocumento = oTipoDAO.ObterPor(objPagarDocumento.tipoDocumento);

                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarDocumento.indexador = oIndexadorDAO.ObterPor(objPagarDocumento.indexador);

                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarDocumento.fornecedor = oFornecedorDAO.ObterPor(objPagarDocumento.fornecedor);
                }
                return objPagarDocumento;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        /// <summary>
        /// Realiza
        /// </summary>
        /// <param name="oPagarDocumento"></param>
        /// <returns></returns>
        public PagarDocumento ObterDocParcela(PagarDocumento oPagarDocumento)
        {
            bool Consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarDocumento Where idpagardocumento = @idPagarDocumento ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idPagarDocumento", oPagarDocumento.idPagarDocumento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                PagarDocumento objPagarDocumento = new PagarDocumento();

                while (drCon.Read())
                {
                    Consulta = true;
                    objPagarDocumento.idPagarDocumento = Convert.ToInt32(drCon["idPagarDocumento"].ToString());
                    objPagarDocumento.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objPagarDocumento.nroDocumento = drCon["nrodocumento"].ToString();
                    objPagarDocumento.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    objPagarDocumento.dataEntrada = Convert.ToDateTime(drCon["dataentrada"].ToString());
                    objPagarDocumento.valorDocumento = EmcResources.cCur(drCon["valordocumento"].ToString());
                    objPagarDocumento.nroParcelas = Convert.ToInt32(drCon["nroparcelas"].ToString());
                    objPagarDocumento.periodicidade = drCon["periodicidade"].ToString();
                    objPagarDocumento.diaFixo = drCon["diafixo"].ToString();
                    objPagarDocumento.origemDocumento = drCon["origemdocumento"].ToString();
                    objPagarDocumento.descricao = drCon["descricao"].ToString();
                    objPagarDocumento.idFatura = EmcResources.cInt(drCon["idfatura"].ToString());
                    objPagarDocumento.cadastro_datahora = Convert.ToDateTime(drCon["cadastro_datahora"].ToString());
                    objPagarDocumento.cadastro_idusuario = Convert.ToInt32(drCon["cadastro_idusuario"].ToString());
                    objPagarDocumento.situacao = drCon["situacao"].ToString();
                    objPagarDocumento.dataUltimaCorrecao = Convert.ToDateTime(drCon["dataultimacorrecao"].ToString());
                    objPagarDocumento.valorIndexado = EmcResources.cDouble(drCon["valorindexado"].ToString());
                    objPagarDocumento.valorIndice = EmcResources.cDouble(drCon["valorindice"].ToString());
                    
                    TipoDocumento oTipoDocumento = new TipoDocumento();
                    oTipoDocumento.idTipoDocumento = Convert.ToInt32(drCon["idtipodocumento"].ToString());
                    objPagarDocumento.tipoDocumento = oTipoDocumento;

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = Convert.ToInt32(drCon["idindexador"].ToString());
                    objPagarDocumento.indexador = oIndexador;

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = Convert.ToInt32(drCon["fornecedor_codempresa"].ToString());
                    oFornecedor.idPessoa = Convert.ToInt32(drCon["idfornecedor"].ToString());
                    objPagarDocumento.fornecedor = oFornecedor;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    TipoDocumentoDAO oTipoDAO = new TipoDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarDocumento.tipoDocumento = oTipoDAO.ObterPor(objPagarDocumento.tipoDocumento);

                    PagarBaseRateioDAO oBaseRateioDAO = new PagarBaseRateioDAO(parConexao, oOcorrencia, codEmpresa);
                    List<PagarBaseRateio> lstBaseRateio = new List<PagarBaseRateio>();
                    lstBaseRateio = oBaseRateioDAO.listaRateioDocumento(EmcResources.cInt(objPagarDocumento.idPagarDocumento.ToString()));
                    objPagarDocumento.baseRateio = lstBaseRateio;

                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarDocumento.indexador = oIndexadorDAO.ObterPor(objPagarDocumento.indexador);

                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    objPagarDocumento.fornecedor = oFornecedorDAO.ObterPor(objPagarDocumento.fornecedor);
                }
                return objPagarDocumento;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(PagarDocumento oPagarDocumento, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oPagarDocumento.idPagarDocumento.ToString();

                if (flag == "A")
                {

                    PagarDocumento oPgDocumento = new PagarDocumento();
                    oPgDocumento = ObterPor(oPagarDocumento);

                    if (!oPgDocumento.Equals(oPagarDocumento))
                    {
                        descricao = " Cod empresa : " + oPagarDocumento.codEmpresa + "Documento id: " + oPagarDocumento.idPagarDocumento + " Nro documento :" + oPagarDocumento.nroDocumento  + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oPgDocumento.dataEmissao.Equals(oPagarDocumento.dataEmissao))
                        {
                            descricao += " Data Emissão de " + oPgDocumento.dataEmissao + " para " + oPagarDocumento.dataEmissao;
                        }
                        if (!oPgDocumento.dataEntrada.Equals(oPagarDocumento.dataEntrada))
                        {
                            descricao += " Data Entrada de " + oPgDocumento.dataEntrada + " para " + oPagarDocumento.dataEntrada;
                        }
                        if (!oPgDocumento.valorDocumento.Equals(oPagarDocumento.valorDocumento))
                        {
                            descricao += " Valor Docuemento  de " + oPgDocumento.valorDocumento + " para " + oPagarDocumento.valorDocumento;
                        }
                        if (!oPgDocumento.nroParcelas.Equals(oPagarDocumento.nroParcelas))
                        {
                            descricao += " Nro Parcelas  de " + oPgDocumento.nroParcelas + " para " + oPagarDocumento.valorDocumento;
                        }
                        if (!oPgDocumento.periodicidade.Equals(oPagarDocumento.periodicidade))
                        {
                            descricao += " Periodicidade  de " + oPgDocumento.periodicidade + " para " + oPagarDocumento.periodicidade;
                        }
                        if (!oPgDocumento.diaFixo.Equals(oPagarDocumento.diaFixo))
                        {
                            descricao += " Dia Fixo  de " + oPgDocumento.diaFixo + " para " + oPagarDocumento.diaFixo;
                        }
                        if (!oPgDocumento.origemDocumento.Equals(oPagarDocumento.origemDocumento))
                        {
                            descricao += " Origem Documento  de " + oPgDocumento.origemDocumento + " para " + oPagarDocumento.origemDocumento;
                        }
                        if (!oPgDocumento.descricao.Equals(oPagarDocumento.descricao))
                        {
                            descricao += " Descricao  de " + oPgDocumento.descricao + " para " + oPagarDocumento.descricao;
                        }
                        if (!oPgDocumento.tipoDocumento.idTipoDocumento.Equals(oPagarDocumento.tipoDocumento.idTipoDocumento))
                        {
                            descricao += " Tipo Documento  de " + oPgDocumento.tipoDocumento.idTipoDocumento + " - " + oPgDocumento.tipoDocumento.descricao + 
                                                    " para " + oPagarDocumento.tipoDocumento.idTipoDocumento + " - " + oPagarDocumento.tipoDocumento.descricao;
                        }
                        if (!oPgDocumento.indexador.idIndexador.Equals(oPagarDocumento.indexador.idIndexador))
                        {
                            descricao += " Indexador  de " + oPgDocumento.indexador.idIndexador + " - " + oPgDocumento.indexador.descricao +
                                                    " para " + oPagarDocumento.indexador.idIndexador + " - " + oPagarDocumento.indexador.descricao;
                        }
                        if (!oPgDocumento.fornecedor.idPessoa.Equals(oPagarDocumento.fornecedor.idPessoa))
                        {
                            descricao += " Fornecedor  de " + oPgDocumento.fornecedor.idPessoa + " - " + oPgDocumento.fornecedor.pessoa.nome +
                                                    " para " + oPagarDocumento.fornecedor.idPessoa + " - " + oPagarDocumento.fornecedor.pessoa.nome;
                        }
                        if (!oPgDocumento.idFatura.Equals(oPagarDocumento.idFatura))
                        {
                            descricao += " Fatura de " + oPgDocumento.idFatura + " - " + " para " + oPagarDocumento.idFatura;
                        }





                    }
                }
                else if (flag == "I")
                {
                    descricao = "Parcela Pagar id : " + oPagarDocumento.idPagarDocumento +
                                " - CodEmpresa - " + oPagarDocumento.codEmpresa +
                                " - Documento - " + oPagarDocumento.nroDocumento +
                                " - Nro Parcelas - " + oPagarDocumento.nroParcelas +
                                " - Data Emissão - " + oPagarDocumento.dataEmissao +
                                " - Data Entrada - " + oPagarDocumento.dataEntrada +
                                " - Valor Documento - " + oPagarDocumento.valorDocumento +
                                " - Periodicidade - " + oPagarDocumento.periodicidade +
                                " - Dia Fixo - " + oPagarDocumento.diaFixo +
                                " - Origem Documento - " + oPagarDocumento.origemDocumento +
                                " - Descrição - " + oPagarDocumento.descricao +
                                " - Tipo Documento - " + oPagarDocumento.tipoDocumento.idTipoDocumento + " - " + oPagarDocumento.tipoDocumento.descricao +
                                " - Indexador - " + oPagarDocumento.indexador.idIndexador + " - " +oPagarDocumento.indexador.descricao + 
                                " - Fornecedor - " + oPagarDocumento.fornecedor.idPessoa + " - " + oPagarDocumento.fornecedor.pessoa.nome + 
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Parcela Pagar id : " + oPagarDocumento.idPagarDocumento +
                                " - CodEmpresa - " + oPagarDocumento.codEmpresa +
                                " - Documento - " + oPagarDocumento.nroDocumento +
                                " - Nro Parcelas - " + oPagarDocumento.nroParcelas +
                                " - Data Emissão - " + oPagarDocumento.dataEmissao +
                                " - Data Entrada - " + oPagarDocumento.dataEntrada +
                                " - Valor Documento - " + oPagarDocumento.valorDocumento +
                                " - Periodicidade - " + oPagarDocumento.periodicidade +
                                " - Dia Fixo - " + oPagarDocumento.diaFixo +
                                " - Origem Documento - " + oPagarDocumento.origemDocumento +
                                " - Descrição - " + oPagarDocumento.descricao +
                                " - Tipo Documento - " + oPagarDocumento.tipoDocumento.idTipoDocumento + " - " + oPagarDocumento.tipoDocumento.descricao +
                                " - Indexador - " + oPagarDocumento.indexador.idIndexador + " - " + oPagarDocumento.indexador.descricao +
                                " - Fornecedor - " + oPagarDocumento.fornecedor.idPessoa + " - " + oPagarDocumento.fornecedor.pessoa.nome +
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
