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
using EMCIntegracaoModel;
using EMCIntegracaoDAO;

namespace EMCImobDAO
{
    public class LocacaoReceberDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia; 
        int codEmpresa;

        public LocacaoReceberDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoReceber> lstLocacaoReceber(DateTime? dataInicial, DateTime? dataFinal, string idContrato, int nroParcela, int idImovel, int empMaster, int idLocatario)
        {
            bool consulta = false;

            try
            {

                //Monta comando para a gravação do registro

                String strSQL = "select r.idLocacaoReceber, r.idLocacaoContrato, c.IdentificacaoContrato, " +
                                       "r.datavencimento, r.diascarencia, r.datacarencia, r.PeriodoInicio, r.PeriodoFim, " +
                                       "r.idCliente, r.cliente_CodEmpresa, r.valorparcela, r.situacao, c.idimovel, i.codigoImovel " +
                               "from locacaoreceber r left join locacaocontrato c on c.idLocacaoContrato = r.idLocacaoContrato, " +
                                    "locacaocontrato c1 left join imovel i on i.idimovel = c1.idimovel " +
                               "Where c.idempresa=@codempresa and r.situacao = 'A' ";

                if (dataInicial is DateTime && dataFinal is DateTime)
                {
                    strSQL = strSQL + " and r.datavencimento between @datainicial and @datafinal ";
                }

                if (!String.IsNullOrEmpty(idContrato))
                {
                    strSQL = strSQL + " and c.identificacaocontrato = @idcontrato ";
                }

                if (nroParcela > 0)
                {
                    strSQL = strSQL + " and r.nroparcela = @nroparcela ";
                }

                if (idImovel > 0)
                {
                    strSQL = strSQL + " and c.idimovel=@idimovel ";
                }

                if (idLocatario > 0)
                {
                    strSQL = strSQL + " and r.cliente_codempresa=@empmaster and r.idcliente = @idlocatario";
                }
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);
                Sqlcon.Parameters.AddWithValue("@nroparcela", nroParcela);
                Sqlcon.Parameters.AddWithValue("@idimovel", idImovel);
                Sqlcon.Parameters.AddWithValue("@empmaster", empMaster);
                Sqlcon.Parameters.AddWithValue("@idlocatario", idLocatario);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoReceber> lstLocacaoReceber = new List<LocacaoReceber>();
                List<LocacaoReceber> lstRetorno = new List<LocacaoReceber>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoReceber oReceber = new LocacaoReceber();

                    oReceber.idLocacaoReceber = EmcResources.cInt(drCon["idlocacaoReceber"].ToString());

                    lstLocacaoReceber.Add(oReceber);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoReceber oCC in lstLocacaoReceber)
                    {
                        LocacaoReceber oCCP = new LocacaoReceber();
                        oCCP = ObterPor(oCC);

                        lstRetorno.Add(oCCP);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public List<LocacaoReceber> lstLocacaoReceber(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro

                String strSQL = "select * from locacaoreceber Where idlocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoReceber> lstLocacaoReceber = new List<LocacaoReceber>();
                List<LocacaoReceber> lstRetorno = new List<LocacaoReceber>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoReceber oReceber = new LocacaoReceber();

                    oReceber.idLocacaoReceber = EmcResources.cInt(drCon["idLocacaoReceber"].ToString());

                    lstLocacaoReceber.Add(oReceber);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoReceber oCC in lstLocacaoReceber)
                    {
                        LocacaoReceber oRec = new LocacaoReceber();
                        oRec = ObterPor(oCC);

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

        public void Salvar(LocacaoReceber oReceber, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oReceber.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoReceber'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oReceber.idLocacaoReceber = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oReceber, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoReceber (idlocacaocontrato, nroparcela, cliente_codempresa, idcliente, " +
                                                                "periodoinicio, periodofim, datavencimento, diascarencia, datacarencia, " +
                                                                "valordesconto, valorjuros, valorjuroscalculado, valorparcela, " +
                                                                "percparticipacao, situacao, valorpago )" +
                                    "values (@idlocacaocontrato, @nroparcela, @codempresa, @idlocatario, " +
                                            "@periodoinicio, @periodofim, @datavencimento, @diascarencia, @datacarencia, " +
                                            "@valordesconto, @valorjuros, @valorjuroscalculado, @valorparcela, " +
                                            "@percparticipacao, @situacao, @valorpago )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oReceber.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", oReceber.nroParcela);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oReceber.locatario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocatario", oReceber.locatario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@periodoinicio", oReceber.periodoInicio);
                    SqlconPar.Parameters.AddWithValue("@periodofim", oReceber.periodoFim);
                    SqlconPar.Parameters.AddWithValue("@datavencimento", oReceber.dataVencimento);
                    SqlconPar.Parameters.AddWithValue("@diascarencia", oReceber.diasCarencia);
                    SqlconPar.Parameters.AddWithValue("@datacarencia", oReceber.dataCarencia);
                    SqlconPar.Parameters.AddWithValue("@valordesconto", oReceber.valorDesconto);
                    SqlconPar.Parameters.AddWithValue("@valorjuros", oReceber.valorJuros);
                    SqlconPar.Parameters.AddWithValue("@valorjuroscalculado", oReceber.valorJurosCalculado);
                    SqlconPar.Parameters.AddWithValue("@valorparcela", oReceber.valorParcela);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oReceber.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oReceber.situacao);
                    SqlconPar.Parameters.AddWithValue("@valorpago", 0);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCReceber oCCReceber in oReceber.lstCtaCorrente)
                    {
                        LocacaoCCReceberDAO oCCreceberDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        //atribui o id gerado na inclusão ao provento a ser gravado.
                        oCCReceber.idLocacaoReceber = oReceber.idLocacaoReceber;
                        oCCReceber.idLocacaoContrato = oReceber.idLocacaoContrato;
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }

                }
                else if (oReceber.statusOperacao == "A")
                {
                    geraOcorrencia(oReceber, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoReceber set idlocacaocontrato=@idlocacaocontrato, nroparcela=@nroparcela, " +
                                                             " cliente_codempresa=@codempresa, idcliente=@idlocatario, " +
                                                             " periodoinicio=@periodoinicio, periodofim=@periodofim, " +
                                                             " datavencimento=@datavencimento, diascarencia=@diascarencia, " +
                                                             " datacarencia=@datacarencia, valordesconto=@valordesconto, " +
                                                             " valorjuros=@valorjuros, valorjuroscalculado=@valorjuroscalculado, " +
                                                             " valorparcela=@valorparcela, percparticipacao=@percparticipacao, situacao=@situacao, " +
                                                             " valorpago=@valorpago " +
                                            " Where idLocacaoReceber = @idLocacaoReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oReceber.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", oReceber.nroParcela);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oReceber.locatario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocatario", oReceber.locatario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@periodoinicio", oReceber.periodoInicio);
                    SqlconPar.Parameters.AddWithValue("@periodofim", oReceber.periodoFim);
                    SqlconPar.Parameters.AddWithValue("@datavencimento", oReceber.dataVencimento);
                    SqlconPar.Parameters.AddWithValue("@diascarencia", oReceber.diasCarencia);
                    SqlconPar.Parameters.AddWithValue("@datacarencia", oReceber.dataCarencia);
                    SqlconPar.Parameters.AddWithValue("@valordesconto", oReceber.valorDesconto);
                    SqlconPar.Parameters.AddWithValue("@valorjuros", oReceber.valorJuros);
                    SqlconPar.Parameters.AddWithValue("@valorjuroscalculado", oReceber.valorJurosCalculado);
                    SqlconPar.Parameters.AddWithValue("@valorparcela", oReceber.valorParcela);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oReceber.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oReceber.situacao);
                    SqlconPar.Parameters.AddWithValue("@valorpago", oReceber.valorPago);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCReceber oCCReceber in oReceber.lstCtaCorrente)
                    {
                        LocacaoCCReceberDAO oCCreceberDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }
                }
                else if (oReceber.statusOperacao == "C")
                {
                    geraOcorrencia(oReceber, "E");

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCReceber oCCReceber in oReceber.lstCtaCorrente)
                    {
                        LocacaoCCReceberDAO oCCreceberDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from LocacaoReceber where idLocacaoReceber = @idLocacaoReceber";

                    String strSQL = "update LocacaoReceber set situacao='C' where idLocacaoReceber = @idLocacaoReceber";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);


                }
                else if (oReceber.statusOperacao == "R")
                {
                    geraOcorrencia(oReceber, "R");

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCReceber oCCReceber in oReceber.lstCtaCorrente)
                    {
                        LocacaoCCReceberDAO oCCreceberDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from LocacaoReceber where idLocacaoReceber = @idLocacaoReceber";

                    String strSQL = "update LocacaoReceber set situacao='A' where idLocacaoReceber = @idLocacaoReceber";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);


                }
                else if (oReceber.statusOperacao == "G")
                {

                    /* Realiza a gravação dos proventos da parcela */
                    foreach (LocacaoCCReceber oCCReceber in oReceber.lstCtaCorrente)
                    {
                        oCCReceber.statusOperacao = "G";
                        LocacaoCCReceberDAO oCCreceberDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        oCCreceberDAO.Salvar(oCCReceber, Conexao, transacao);
                    }

                    /* estorna a integração com o financeiro */

                    String strSQL = "update LocacaoReceber set situacao='A', dataintegracao = null where idLocacaoReceber = @idLocacaoReceber";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);

                    Sqlcon.ExecuteNonQuery();


                    /* deleta a integração com o financeiro */
                    IntegFinanceiro oInteg = new IntegFinanceiro();
                    IntegFinanceiroDAO oIntegDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);

                    //oInteg = oIntegDAO.ObterPorLocacaoReceber(oReceber.idLocacaoReceber);
                    oInteg.imob_LocacaoReceber = oReceber;
                    oInteg.statusOperacao = "C";
                    oInteg.sistemaOrigem = "EMCIMOB";

                    oIntegDAO.Salvar(oInteg, Conexao, transacao);

                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Integracao(LocacaoReceber oReceber, MySqlConnection Conexao, MySqlTransaction transacao, string Operacao, DateTime integracao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (Operacao == "I")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoReceber set situacao=@situacao, dataintegracao=@data " +
                                            " Where idLocacaoReceber = @idLocacaoReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@situacao", "G");
                    SqlconPar.Parameters.AddWithValue("@data", integracao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (Operacao == "P")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoReceber set situacao=@situacao, dataintegracao=@data " +
                                            " Where idLocacaoReceber = @idLocacaoReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@situacao", "P");
                    SqlconPar.Parameters.AddWithValue("@data", integracao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
                else if (Operacao == "E")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoReceber set situacao=@situacao " +
                                            " Where idLocacaoReceber = @idLocacaoReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoReceber", oReceber.idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@situacao", "G");

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LocacaoReceber ObterPor(LocacaoReceber oCC)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoReceber Where idLocacaoReceber = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oCC.idLocacaoReceber);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoReceber oCCReceber = new LocacaoReceber();

                while (drCon.Read())
                {
                    consulta = true;

                    oCCReceber.idLocacaoReceber = EmcResources.cInt(drCon["idLocacaoReceber"].ToString());
                    oCCReceber.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    LocacaoContrato oContrato = new LocacaoContrato();
                    oContrato.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());
                    oCCReceber.contrato = oContrato;

                    Cliente oLocatario = new Cliente();
                    oLocatario.codEmpresa = EmcResources.cInt(drCon["cliente_codempresa"].ToString());
                    oLocatario.idPessoa = EmcResources.cInt(drCon["idcliente"].ToString());
                    oCCReceber.locatario = oLocatario;

                    oCCReceber.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    oCCReceber.periodoInicio = Convert.ToDateTime(drCon["periodoinicio"].ToString());
                    oCCReceber.periodoFim = Convert.ToDateTime(drCon["periodofim"].ToString());
                    oCCReceber.dataVencimento = Convert.ToDateTime(drCon["datavencimento"].ToString());
                    oCCReceber.diasCarencia = EmcResources.cInt(drCon["diascarencia"].ToString());
                    oCCReceber.dataCarencia = Convert.ToDateTime(drCon["datacarencia"].ToString());

                    if (drCon["dataintegracao"] is DBNull)
                    {
                        oCCReceber.dataIntegracao = null;
                    }
                    else
                        oCCReceber.dataIntegracao = Convert.ToDateTime(drCon["dataintegracao"].ToString());

                    oCCReceber.percParticipacao = EmcResources.cDouble(drCon["percparticipacao"].ToString());
                    oCCReceber.valorJuros = EmcResources.cCur(drCon["valorjuros"].ToString());
                    oCCReceber.valorJurosCalculado = EmcResources.cCur(drCon["valorjuroscalculado"].ToString());
                    oCCReceber.valorDesconto = EmcResources.cCur(drCon["valordesconto"].ToString());
                    oCCReceber.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    oCCReceber.valorPago = EmcResources.cCur(drCon["valorpago"].ToString());
                    oCCReceber.situacao = drCon["situacao"].ToString();
                    oCCReceber.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCReceber.locatario = oClienteDAO.ObterPor(oCCReceber.locatario);

                    LocacaoCCReceberDAO oCCDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCReceber.lstCtaCorrente = oCCDAO.lstLocacaoCCReceber(oCCReceber.idLocacaoContrato, oCCReceber.idLocacaoReceber);

                    LocacaoContratoDAO oContratoDAO = new LocacaoContratoDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCReceber.contrato = oContratoDAO.ObterPor(oCCReceber.contrato, "N");


                }
                return oCCReceber;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoReceber oCCReceber, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoReceber pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oCCReceber.idLocacaoContrato.ToString();

                if (flag == "A")
                {

                    LocacaoReceber oCCP = new LocacaoReceber();
                    oCCP = ObterPor(oCCReceber);

                    if (!oCCP.Equals(oCCReceber))
                    {
                        descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                    " Locacao Receber id : " + oCCReceber.idLocacaoReceber +
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.locatario.Equals(oCCReceber.locatario))
                        {
                            descricao += " Locatario de " + oCCP.locatario.pessoa.nome + " para " + oCCReceber.locatario.pessoa.nome;
                        }
                        if (!oCCP.nroParcela.Equals(oCCReceber.nroParcela))
                        {
                            descricao += " Nro Parcela de " + oCCP.nroParcela + " para " + oCCReceber.nroParcela;
                        }
                        if (!oCCP.periodoInicio.Equals(oCCReceber.periodoInicio))
                        {
                            descricao += " Periodo Inicio de " + oCCP.periodoInicio + " para " + oCCReceber.periodoInicio;
                        }
                        if (!oCCP.periodoFim.Equals(oCCReceber.periodoFim))
                        {
                            descricao += " Periodo Fim de " + oCCP.periodoFim + " para " + oCCReceber.periodoFim;
                        }
                        if (!oCCP.dataVencimento.Equals(oCCReceber.dataVencimento))
                        {
                            descricao += " Data Vencimento de " + oCCP.dataVencimento + " para " + oCCReceber.dataVencimento;
                        }
                        if (!oCCP.diasCarencia.Equals(oCCReceber.diasCarencia))
                        {
                            descricao += " Dias Carencia de " + oCCP.diasCarencia + " para " + oCCReceber.diasCarencia;
                        }
                        if (!oCCP.dataCarencia.Equals(oCCReceber.dataCarencia))
                        {
                            descricao += " Data Carencia de " + oCCP.dataCarencia + " para " + oCCReceber.dataCarencia;
                        }
                        if (!oCCP.percParticipacao.Equals(oCCReceber.percParticipacao))
                        {
                            descricao += " Percentual Participação de " + oCCP.percParticipacao + " para " + oCCReceber.percParticipacao;
                        }
                        if (!oCCP.valorDesconto.Equals(oCCReceber.valorDesconto))
                        {
                            descricao += " Valor Desconto de " + oCCP.valorDesconto + " para " + oCCReceber.valorDesconto;
                        }
                        if (!oCCP.valorJurosCalculado.Equals(oCCReceber.valorJurosCalculado))
                        {
                            descricao += " Valor Juros Calculado de " + oCCP.valorJurosCalculado + " para " + oCCReceber.valorJurosCalculado;
                        }
                        if (!oCCP.valorJuros.Equals(oCCReceber.valorJuros))
                        {
                            descricao += " Valor Juros de " + oCCP.valorJuros + " para " + oCCReceber.valorJuros;
                        }
                        if (!oCCP.valorParcela.Equals(oCCReceber.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oCCP.valorParcela + " para " + oCCReceber.valorParcela;
                        }
                        if (!oCCP.valorPago.Equals(oCCReceber.valorPago))
                        {
                            descricao += " Valor Pago de " + oCCP.valorPago + " para " + oCCReceber.valorPago;
                        }

                        if (!oCCP.situacao.Equals(oCCReceber.situacao))
                        {
                            descricao += " Situação de " + oCCP.situacao + " para " + oCCReceber.situacao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoReceber +
                                " Locatario : " + oCCReceber.locatario.pessoa.nome + " - " + oCCReceber.locatario.pessoa.idPessoa +
                                " Nro Parcela : " + oCCReceber.nroParcela +
                                " Periodo Inicio : " + oCCReceber.periodoInicio +
                                " Periodo Fim : " + oCCReceber.periodoFim +
                                " Data Vencimento : " + oCCReceber.dataVencimento.ToShortDateString() +
                                " Dias Carencia : " + oCCReceber.diasCarencia.ToString() +
                                " Data Carencia : " + oCCReceber.dataCarencia.ToShortDateString() +
                                " Percentual Partipação : " + oCCReceber.percParticipacao.ToString() +
                                " Valor desconto : " + oCCReceber.valorDesconto.ToString() +
                                " Valor Juros : " + oCCReceber.valorJuros.ToString() +
                                " Valor Juros Calculado : " + oCCReceber.valorJurosCalculado.ToString() +
                                " Valor Parcela : " + oCCReceber.valorParcela.ToString() +
                                " Valor Pago : " + oCCReceber.valorPago.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoReceber +
                                " Locatario : " + oCCReceber.locatario.pessoa.nome + " - " + oCCReceber.locatario.pessoa.idPessoa +
                                " Nro Parcela : " + oCCReceber.nroParcela +
                                " Periodo Inicio : " + oCCReceber.periodoInicio +
                                " Periodo Fim : " + oCCReceber.periodoFim +
                                " Data Vencimento : " + oCCReceber.dataVencimento.ToShortDateString() +
                                " Dias Carencia : " + oCCReceber.diasCarencia.ToString() +
                                " Data Carencia : " + oCCReceber.dataCarencia.ToShortDateString() +
                                " Percentual Partipação : " + oCCReceber.percParticipacao.ToString() +
                                " Valor desconto : " + oCCReceber.valorDesconto.ToString() +
                                " Valor Juros : " + oCCReceber.valorJuros.ToString() +
                                " Valor Juros Calculado : " + oCCReceber.valorJurosCalculado.ToString() +
                                " Valor Pago : " + oCCReceber.valorPago.ToString() +
                                " Valor Parcela : " + oCCReceber.valorParcela.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "R")
                {
                    descricao = "Recuperação de Registro : Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoReceber +
                                " Locatario : " + oCCReceber.locatario.pessoa.nome + " - " + oCCReceber.locatario.pessoa.idPessoa +
                                " Nro Parcela : " + oCCReceber.nroParcela +
                                " Periodo Inicio : " + oCCReceber.periodoInicio +
                                " Periodo Fim : " + oCCReceber.periodoFim +
                                " Data Vencimento : " + oCCReceber.dataVencimento.ToShortDateString() +
                                " Dias Carencia : " + oCCReceber.diasCarencia.ToString() +
                                " Data Carencia : " + oCCReceber.dataCarencia.ToShortDateString() +
                                " Percentual Partipação : " + oCCReceber.percParticipacao.ToString() +
                                " Valor desconto : " + oCCReceber.valorDesconto.ToString() +
                                " Valor Juros : " + oCCReceber.valorJuros.ToString() +
                                " Valor Juros Calculado : " + oCCReceber.valorJurosCalculado.ToString() +
                                " Valor Pago : " + oCCReceber.valorPago.ToString() +
                                " Valor Parcela : " + oCCReceber.valorParcela.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi recuperado por " + oOcorrencia.usuario.nome;
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
         
        public DataTable PesquisaLocacaoReceber(DateTime dataInicial, DateTime dataFinal)
        {

            try
            {

                //Monta comando para a gravação do registro
                //String strSQL = "select lr.*, lr.nroparcela as parcela " +
                //                " from locacaoreceber lr, locacaocontrato lc, v_cliente cl " +
                //                " where lc.idlocacaocontrato = lr.idlocacaocontrato " +
                //                " and cl.codempresa = lr.cliente_codempresa and cl.idpessoa = lr.idcliente " +
                //                " and lr.datavencimento between @datainicial and @datafinal " +
                //                " order by lr.datavencimento";
                int colocaWhere = 0;
                String strSQL = "select lr.*, lr.nroparcela as parcela, cl.nome as nome_locatario, f.nome as nome_locador " +
                                " from locacaoreceber lr " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lr.idlocacaocontrato " +
                                " left join v_cliente cl on cl.codempresa = lr.cliente_codempresa and cl.idpessoa = lr.idcliente " +
                                " left join v_fornecedor f on f.codempresa = lc.codempresa_locador and f.idpessoa = lc.idlocadorrepresentante ";



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


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
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

        public DataTable dstListaLocatario(DateTime? dataInicial)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = " select lr.*, cl.nome as nome_locatario, lc.identificacaocontrato as identificacaocontrato " +
                                " from locacaoreceber lr " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lr.idlocacaocontrato " +
                                " left join v_cliente cl on cl.codempresa = lr.cliente_codempresa and cl.idpessoa = lr.idcliente " ;

                if (dataInicial != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }                   
                    strSQL += " datavencimento < @datainicio ";
                }                              

                strSQL += " and situacao = 'A' ";

                strSQL += " order by datavencimento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);               
                

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

        public DataTable dstListaCCReceber(DateTime? dataInicial, string identificacaoContrato)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = " select lcc.*, cl.nome as nome_locatario, lc.identificacaocontrato as identificacaocontrato, lp.descricao as descricao_prov, lr.datavencimento as datavencimento " +
                                " from locacaoccreceber lcc " +
                                " left join locacaoreceber lr on lr.idlocacaoreceber = lcc.idlocacaoreceber " +
                                " left join locacaoproventos lp on lp.idlocacaoproventos = lcc.idlocacaoproventos " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lcc.idlocacaocontrato " +
                                " left join v_cliente cl on cl.codempresa = lcc.cliente_codempresa and cl.idpessoa = lcc.idcliente ";

                if (dataInicial != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " lr.datavencimento < @datainicio ";
                }
                
                if (!String.IsNullOrEmpty(identificacaoContrato))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " lc.identificacaocontrato = @identificacaocontrato ";
                }                

                strSQL += " and lcc.situacao = 'A' ";

                strSQL += " order by nroparcela ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicial);
                Sqlcon.Parameters.AddWithValue("@identificacaocontrato", identificacaoContrato);


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
        
        public List<LocacaoReceber> listaParcelaVencida(int idUsuario, int codempresa, int idLocatario, DateTime? dataInicial)
        {

            try
            {
                //Monta comando para a gravação do registro
                int colocaWhere = 0;             
                String strSQL = "select lr.*, cl.nome as pessoa " +
                                " from locacaoreceber lr  " +
                                " left join locacaocontrato lc on lc.idlocacaocontrato = lr.idlocacaocontrato " +
                                " left join v_cliente cl on cl.codempresa = lr.cliente_codempresa and cl.idpessoa = lr.idcliente" ;


                if (idLocatario > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " lr.idcliente = @idcliente ";
                }
                
               if (dataInicial is DateTime)                
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datavencimento < @datainicial ";
                }
                strSQL += " and situacao = 'A'";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcliente", idLocatario);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoReceber> lstParcela = new List<LocacaoReceber>();
                List<LocacaoReceber> lstRetorno = new List<LocacaoReceber>();

                while (drCon.Read())
                {

                    LocacaoReceber objLocacaoReceber = new LocacaoReceber();

                    objLocacaoReceber.idLocacaoReceber = EmcResources.cInt(drCon["idlocacaoreceber"].ToString());
                    //objLocacaoReceber.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    lstParcela.Add(objLocacaoReceber);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                foreach (LocacaoReceber oLRec in lstParcela)
                {
                    lstRetorno.Add(ObterPor(oLRec));
                }


                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
              
    }
}
