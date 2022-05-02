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
    public class ReceberFaturaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberFaturaDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public void Salvar(ReceberFatura oFatura)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            //Grava um novo registro de ReceberBaixa
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
        public void Salvar(ReceberFatura oFatura, MySqlConnection xConexao, MySqlTransaction Transacao)
        {
            try
            {

                //Gera o novo documento de cobrança
                int idDocReceber = 0;

                Ocorrencia ocoPgDoc = new Ocorrencia();
                ocoPgDoc.aplicativo = oOcorrencia.aplicativo;
                ocoPgDoc.chaveidentificacao = "";
                ocoPgDoc.data_hora = DateTime.Now;
                ocoPgDoc.descricao = "";
                ocoPgDoc.formulario = "frmReceberDocumento";
                ocoPgDoc.seqLogin = oOcorrencia.seqLogin;
                ocoPgDoc.tabela = "receberdocumento";
                ocoPgDoc.usuario = oOcorrencia.usuario;
                ReceberDocumentoDAO oPgDocDAO = new ReceberDocumentoDAO(parConexao, ocoPgDoc,codEmpresa);
                idDocReceber=oPgDocDAO.Salvar(xConexao, Transacao, oFatura.receberDocumento);


                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'receberfatura'"+
                                 "  and a.table_schema ='"+schemaBD.Trim()+"'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, xConexao, Transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oFatura.idReceberFatura = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oFatura, "I");

                //Grava fatura
                String strSQL = "insert into receberfatura (codempresa, datafatura, valorfatura, nrodocumento, cliente_codempresa, " + 
                                                       " cliente_idpessoa, idreceberdocumento, situacao, cadastro_datahora, " + 
                                                       " cadastro_idusuario ) " +
                                " values (@codempresa, @datafatura, @valorfatura, @nrodocumento, @cliente_codempresa, " + 
                                        " @cliente_idpessoa, @idreceberdocumento, @situacao, @cadastro_datahora, " + 
                                        " @cadastro_idusuario ) ";
                                         

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, xConexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oFatura.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datafatura", oFatura.dataFatura);
                Sqlcon.Parameters.AddWithValue("@valorfatura", oFatura.valorFatura);
                Sqlcon.Parameters.AddWithValue("@nrodocumento", oFatura.numeroDocumento);
                Sqlcon.Parameters.AddWithValue("@cliente_codempresa", oFatura.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@cliente_idpessoa", oFatura.cliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idreceberdocumento", idDocReceber);
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
                ocoPgBX.formulario = "frmReceberDocumento";
                ocoPgBX.seqLogin = oOcorrencia.seqLogin;
                ocoPgBX.tabela = "receberbaixa";
                ocoPgBX.usuario = oOcorrencia.usuario;

                List<ReceberBaixa> lstBxReceber = new List<ReceberBaixa>();
                ReceberBaixaDAO oPgBxDAO = new ReceberBaixaDAO(parConexao, ocoPgBX, codEmpresa);
                foreach (ReceberParcela oParcela in oFatura.lstParcelas)
                {
                    oParcela.idreceberfatura = oFatura.idReceberFatura;

                    ReceberBaixa oBaixa = new ReceberBaixa();

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
                    oBaixa.nominal = oFatura.cliente.pessoa.nome;
                    oBaixa.receberParcela = oParcela;
                    oBaixa.pessoa = oParcela.receberDocumento.cliente.pessoa;
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

                    lstBxReceber.Add(oBaixa);
                }

                oPgBxDAO.Salvar(lstBxReceber, "1", xConexao, Transacao);
                
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }

        }

        public DataTable ListaReceberFatura(ReceberFatura oFatura)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberFatura where cliente_codempresa=@empmaster and cliente_idpessoa=@idpessoa order by datafatura";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@empmaster", oFatura.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oFatura.cliente.idPessoa);

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

        public DataTable pesquisaReceberFatura(int codEmpresa, int empMaster, int idCliente, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select d.idreceberfatura, d.nrodocumento, d.datafatura, d.valorfatura, p.nome as nomecliente, d.situacao " +
                                                                 " from Receberfatura d, pessoa p where d.codempresa=@codempresa " +
                                                                          " and p.codempresa = d.cliente_codempresa " +
                                                                          " and p.idpessoa = d.cliente_idpessoa ";

                //Documento com situação em aberto
                if (docAberto)
                    strSQL += " and situacao = 'A' ";

                //filtra cliente
                if (idCliente > 0)
                    strSQL += " and cliente_codempresa=@cliente_codempresa and cliente_idpessoa=@idcliente ";

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

        public ReceberFatura ObterPor(ReceberFatura oFatura)
        {
            bool consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from ReceberFatura Where idReceberFatura = @idReceberFatura ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idReceberFatura", oFatura.idReceberFatura);

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();


                ReceberFatura objFatura = new ReceberFatura();

                while (drCon.Read())
                {
                    consulta = true;
                    objFatura.idReceberFatura = Convert.ToInt32(drCon["idReceberFatura"].ToString());
                    objFatura.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objFatura.dataFatura = Convert.ToDateTime(drCon["datafatura"].ToString());
                    objFatura.numeroDocumento = drCon["nrodocumento"].ToString();
                    objFatura.valorFatura = EmcResources.cCur(drCon["valorfatura"].ToString());
                    objFatura.situacao = drCon["situacao"].ToString();

                    Cliente oForn = new Cliente();
                    oForn.codEmpresa = EmcResources.cInt(drCon["cliente_codempresa"].ToString());
                    oForn.idPessoa = EmcResources.cInt(drCon["cliente_idpessoa"].ToString());
                    objFatura.cliente = oForn;

                    ReceberDocumento oDoc = new ReceberDocumento();
                    oDoc.idReceberDocumento = EmcResources.cInt(drCon["idreceberdocumento"].ToString());
                    objFatura.receberDocumento = oDoc;

                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ReceberDocumentoDAO oDocDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatura.receberDocumento = oDocDAO.ObterPor(objFatura.receberDocumento);

                    ClienteDAO oClieDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatura.cliente = oClieDAO.ObterPor(objFatura.cliente);

                    ReceberParcelaDAO oParcDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatura.lstParcelas = oParcDAO.listaParcelasFatura(objFatura.idReceberFatura);
                }

                return objFatura;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(ReceberFatura oReceberFatura, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoreceber pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oReceberFatura.idReceberFatura.ToString();

                if (flag == "A")
                {

                    ReceberFatura oPgFatura = new ReceberFatura();
                    oPgFatura = ObterPor(oReceberFatura);

                    if (!oPgFatura.Equals(oReceberFatura))
                    {
                        
                       // alteração de pagamento não implementada
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Receber Fatura id : " + oReceberFatura.idReceberFatura +
                                " - CodEmpresa - " + oReceberFatura.codEmpresa +
                                " - Id Documento Gerado - " + oReceberFatura.receberDocumento.idReceberDocumento +
                                " - Nro Documento - " + oReceberFatura.numeroDocumento +
                                " - Cliente - " + oReceberFatura.cliente.pessoa.idPessoa + " - " +
                                                    oReceberFatura.cliente.pessoa.nome +
                                " - Data Fatura - " + oReceberFatura.dataFatura +
                                " - Valor Fatura - " + oReceberFatura.valorFatura +
                                " - Situacao - " + oReceberFatura.situacao +
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
