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
    public class PagarFaturaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarFaturaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public void Salvar(PagarFatura oFatura)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            //Grava um novo registro de PagarBaixa
            try
            {
                Salvar(oFatura, Conexao, Transacao);
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
        public void Salvar(PagarFatura oFatura, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
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
                PagarDocumentoDAO oPgDocDAO = new PagarDocumentoDAO(parConexao, ocoPgDoc,codEmpresa);
                idDocPagar=oPgDocDAO.Salvar(Conexao, Transacao, oFatura.pagarDocumento);


                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'pagarfatura'"+
                                 "  and a.table_schema ='"+schemaBD.Trim()+"'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oFatura.idPagarFatura = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oFatura, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into pagarfatura (codempresa, datafatura, valorfatura, nrodocumento, fornecedor_codempresa, " + 
                                                       " fornecedor_idpessoa, idpagardocumento, situacao, cadastro_datahora, " + 
                                                       " cadastro_idusuario ) " +
                                " values (@codempresa, @datafatura, @valorfatura, @nrodocumento, @fornecedor_codempresa, " + 
                                        " @fornecedor_idpessoa, @idpagardocumento, @situacao, @cadastro_datahora, " + 
                                        " @cadastro_idusuario ) ";
                                         

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oFatura.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datafatura", oFatura.dataFatura);
                Sqlcon.Parameters.AddWithValue("@valorfatura", oFatura.valorFatura);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", oFatura.numeroDocumento);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", oFatura.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", oFatura.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idpagardocumento", idDocPagar);
                Sqlcon.Parameters.AddWithValue("@situacao", oFatura.situacao);
                Sqlcon.Parameters.AddWithValue("@cadastro_datahora", oFatura.cadastro_datahora);
                Sqlcon.Parameters.AddWithValue("@cadastro_idusuario", oFatura.cadastro_idusuario);
                Sqlcon.ExecuteNonQuery();


                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);


                //Salvar Baixas dos documentos transferidos para novo documento de cobrança
                Ocorrencia ocoPgBX = new Ocorrencia();
                ocoPgBX.aplicativo = oOcorrencia.aplicativo;
                ocoPgBX.chaveidentificacao = "";
                ocoPgBX.data_hora = DateTime.Now;
                ocoPgBX.descricao = "";
                ocoPgBX.formulario = "frmPagarDocumento";
                ocoPgBX.seqLogin = oOcorrencia.seqLogin;
                ocoPgBX.tabela = "pagarbaixa";
                ocoPgBX.usuario = oOcorrencia.usuario;

                List<PagarBaixa> lstBxPagar = new List<PagarBaixa>();
                PagarBaixaDAO oPgBxDAO = new PagarBaixaDAO(parConexao, ocoPgBX, codEmpresa);
                foreach (PagarParcela oParcela in oFatura.lstParcelas)
                {
                    oParcela.idpagarfatura = oFatura.idPagarFatura;

                    PagarBaixa oBaixa = new PagarBaixa();

                    oBaixa.codEmpresa = oFatura.codEmpresa;

                    oBaixa.cadastro_datahora = oFatura.cadastro_datahora;
                    oBaixa.cadastro_idusuario = oFatura.cadastro_idusuario;
                    oBaixa.codEmpresa = oFatura.codEmpresa;
                    oBaixa.dataPagamento = oFatura.dataFatura;
                    oBaixa.documentoBaixa = oFatura.numeroDocumento;


                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = oFatura.codEmpresa;
                    oConta.idCtaBancaria = 0;
                    oBaixa.contaCorrente = oConta;

                    FormaPagamento oFPagto = new FormaPagamento();
                    FormaPagamentoDAO oFPagtoDAO = new FormaPagamentoDAO(parConexao, oOcorrencia, codEmpresa);
                    oFPagto.idFormaPagamento = 9;

                    oFPagto = oFPagtoDAO.ObterPor(oFPagto);
                    oBaixa.formaPagamento = oFPagto;


                    oBaixa.historico = "Baixa por TRF FATURA NRO : " + oFatura.numeroDocumento;

                    Historico oHistorico = new Historico();
                    if (String.IsNullOrEmpty(oFPagto.historicoPadrao.idHistorico.ToString()))
                    {
                        Exception oExcep = new Exception("Forma de Pagamento : " + oFPagto.descricao + " não tem historico padrão informado ");
                        throw oExcep;
                    }

                    oBaixa.idHistorico = oFPagto.historicoPadrao;
                    oBaixa.nominal = oFatura.fornecedor.pessoa.nome;
                    oBaixa.pagarParcela = oParcela;
                    oBaixa.pessoa = oParcela.pagarDocumento.fornecedor.pessoa;
                    oBaixa.sdoAmortizacao = 0;
                    oBaixa.situacaoBaixa = "F";
                    oBaixa.totalDesconto = 0;
                    oBaixa.totalDocumento = oParcela.valorParcela;
                    oBaixa.totalJuros = 0;
                    oBaixa.totalPagamento = oParcela.valorParcela;
                    oBaixa.valorBaixa = oParcela.valorParcela;
                    oBaixa.valorDesconto = 0;
                    oBaixa.valorJuros = 0;
                    oBaixa.valorTotal = oParcela.valorParcela;

                    
                    /* arrumar dados de indexadores */
                    oBaixa.valorIndiceAjuste = oParcela.valorIndice;
                    oBaixa.valorBaixaIndexado = oParcela.valorIndexado;
                    oBaixa.valorCorrecaoMonetaria = oParcela.valorCorrecaoMonetaria;

                    lstBxPagar.Add(oBaixa);
                }

                oPgBxDAO.Salvar(lstBxPagar, "1", Conexao, Transacao);
                
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }

        }

        public DataTable ListaPagarFatura(PagarFatura oFatura)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarFatura where fornecedor_codempresa=@empmaster and fornecedor_idpessoa=@idpessoa order by datafatura";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@empmaster", oFatura.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oFatura.fornecedor.idPessoa);

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

        public DataTable pesquisaPagarFatura(int codEmpresa, int empMaster, int idFornecedor, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select d.idpagarfatura, d.nrodocumento, d.datafatura, d.valorfatura, p.nome as nomefornecedor, d.situacao " +
                                                                 " from Pagarfatura d, pessoa p where d.codempresa=@codempresa " +
                                                                          " and p.codempresa = d.fornecedor_codempresa " +
                                                                          " and p.idpessoa = d.fornecedor_idpessoa ";

                //Documento com situação em aberto
                if (docAberto)
                    strSQL += " and situacao = 'A' ";

                //filtra fornecedor
                if (idFornecedor > 0)
                    strSQL += " and fornecedor_codempresa=@fornecedor_codempresa and fornecedor_idpessoa=@idfornecedor ";

                //filtra por data
                if (!chkTodasContas)
                    strSQL += " and dataemissao >= @datainicio and dataemissao <= @datafinal ";

                //filtra por valor
                if (!valorDocumento)
                {
                    strSQL += " and valorfatura >= @valorinicio ";
                    if (valorFinal > 0 && valorFinal >= valorInicio)
                        strSQL += " and valorfatura <= @valorfinal";

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

        public PagarFatura ObterPor(PagarFatura oFatura)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from PagarFatura Where idPagarFatura = @idPagarFatura ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idPagarFatura", oFatura.idPagarFatura);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                PagarFatura objFatura = new PagarFatura();

                while (drCon.Read())
                {
                    consulta = true;
                    objFatura.idPagarFatura = Convert.ToInt32(drCon["idPagarFatura"].ToString());
                    objFatura.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objFatura.dataFatura = Convert.ToDateTime(drCon["datafatura"].ToString());
                    objFatura.numeroDocumento = drCon["nrodocumento"].ToString();
                    objFatura.valorFatura = EmcResources.cCur(drCon["valorfatura"].ToString());
                    objFatura.situacao = drCon["situacao"].ToString();

                    Fornecedor oForn = new Fornecedor();
                    oForn.codEmpresa = EmcResources.cInt(drCon["fornecedor_codempresa"].ToString());
                    oForn.idPessoa = EmcResources.cInt(drCon["fornecedor_idpessoa"].ToString());
                    objFatura.fornecedor = oForn;

                    PagarDocumento oDoc = new PagarDocumento();
                    oDoc.idPagarDocumento = EmcResources.cInt(drCon["idpagardocumento"].ToString());
                    objFatura.pagarDocumento = oDoc;

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    PagarDocumentoDAO oDocDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatura.pagarDocumento = oDocDAO.ObterPor(objFatura.pagarDocumento);

                    FornecedorDAO oFornDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatura.fornecedor = oFornDAO.ObterPor(objFatura.fornecedor);

                    PagarParcelaDAO oParcDAO = new PagarParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatura.lstParcelas = oParcDAO.listaParcelasFatura(objFatura.idPagarFatura);
                }

                return objFatura;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(PagarFatura oPagarFatura, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oPagarFatura.idPagarFatura.ToString();

                if (flag == "A")
                {

                    PagarFatura oPgFatura = new PagarFatura();
                    oPgFatura = ObterPor(oPagarFatura);

                    if (!oPgFatura.Equals(oPagarFatura))
                    {
                        
                       // alteração de pagamento não implementada
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Pagar Fatura id : " + oPagarFatura.idPagarFatura +
                                " - CodEmpresa - " + oPagarFatura.codEmpresa +
                                " - Id Documento Gerado - " + oPagarFatura.pagarDocumento.idPagarDocumento +
                                " - Nro Documento - " + oPagarFatura.numeroDocumento +
                                " - Fornecedor - " + oPagarFatura.fornecedor.pessoa.idPessoa + " - " +
                                                    oPagarFatura.fornecedor.pessoa.nome +
                                " - Data Fatura - " + oPagarFatura.dataFatura +
                                " - Valor Fatura - " + oPagarFatura.valorFatura +
                                " - Situacao - " + oPagarFatura.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    // implementar cancelamento de pagamento
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
