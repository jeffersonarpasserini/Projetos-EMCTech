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
    public class IptuCobrancaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IptuCobrancaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<IptuCobranca> lstIptuCobranca(int idIptu)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                
                String strSQL = "select * from IptuCobranca Where idiptu = @idiptu";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idiptu", idIptu);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<IptuCobranca> lstIptuCobranca = new List<IptuCobranca>();
                List<IptuCobranca> lstRetorno = new List<IptuCobranca>();


                while (drCon.Read())
                {
                    consulta = true;
                    IptuCobranca oCCPagar = new IptuCobranca();

                    oCCPagar.idIptuCobranca = EmcResources.cInt(drCon["idIptuCobranca"].ToString());

                    lstIptuCobranca.Add(oCCPagar);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (IptuCobranca oCC in lstIptuCobranca)
                    {
                        IptuCobranca oCCP = new IptuCobranca();
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

        public void Salvar(IptuCobranca oIptu, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                if (oIptu.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'IptuCobranca'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oIptu.idIptuCobranca = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (oIptu.locacaoCCReceber.valorLancamento > 0)
                    {
                        /*
                         * Grava Lançamento no Proventos a Receber do contrato
                         */


                    }
                    else
                    {
                        /*
                         * Grava Lançamento no Proventos a Pagar do contrato
                         */


                    }



                    geraOcorrencia(oIptu, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into IptuCobranca (idiptu, idlocacaoccreceber, idlocacaoccpagar, rateio )" +
                                    "values (@idiptu, @idlocacaoccreceber, @idlocacaoccpagar, @rateio )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idiptu", oIptu.idIptu);
                    if ( oIptu.locacaoCCReceber.valorLancamento > 0)
                        SqlconPar.Parameters.AddWithValue("@idlocacaoccreceber", oIptu.locacaoCCReceber.idLocacaoCCReceber);
                    else
                        SqlconPar.Parameters.AddWithValue("@idlocacaoccreceber", null);

                    if (oIptu.locacaoCCPagar.valorLancamento > 0)
                        SqlconPar.Parameters.AddWithValue("@idlocacaoccpagar", oIptu.locacaoCCPagar.idLocacaoCCPagar);
                    else
                        SqlconPar.Parameters.AddWithValue("@idlocacaoccpagar", null);
                    SqlconPar.Parameters.AddWithValue("@rateio", oIptu.rateio);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }

                else if (oIptu.statusOperacao == "A")
                {
                    geraOcorrencia(oIptu, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update IptuCobranca set idlocacaopagar=@idlocacaopagar, idlocacaoproventos=@idlocacaoproventos, " +
                                                             " codempresa=@codempresa, idlocador=@idlocador, tipoprovento=@tipoprovento, " +
                                                             " descricao=@descricao, dataemissao=@dataemissao, datalancamento=@datalancamento, " +
                                                             " valorlancamento=@valorlancamento, situacao=@situacao, " +
                                                             " idlocacaocontrato=@idlocacaocontrato " +
                                            " Where idIptuCobranca = @idIptuCobranca";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idIptuCobranca", oIptu.idIptuCobranca);
                   

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }
                else if (oIptu.statusOperacao == "C")
                {
                    geraOcorrencia(oIptu, "E");

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from IptuCobranca where idIptuCobranca = @idIptuCobranca";
                    String strSQL = "update IptuCobranca set situacao='C' where idIptuCobranca = @idIptuCobranca";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idIptuCobranca", oIptu.idIptuCobranca);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oIptu.statusOperacao == "R")
                {
                    geraOcorrencia(oIptu, "R");

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from IptuCobranca where idIptuCobranca = @idIptuCobranca";
                    String strSQL = "update IptuCobranca set situacao='A' where idIptuCobranca = @idIptuCobranca";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idIptuCobranca", oIptu.idIptuCobranca);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oIptu.statusOperacao == "G")
                {
                    /* Estorna integração com o financeiro */
                    String strSQL = "update IptuCobranca set situacao='A' where idIptuCobranca = @idIptuCobranca";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idIptuCobranca", oIptu.idIptuCobranca);

                    Sqlcon.ExecuteNonQuery();

                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void integracao(int idLocacaoPagar, string statusOperacao, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (statusOperacao == "I")
                {

                    /* Muda status do conta corrente da parcela para G - de integrado ao financeiro */
                    String strSQL = "update IptuCobranca set situacao=@situacao " +
                                            " Where idlocacaopagar = @idlocacaopagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaopagar", idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@situacao", "G");


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();


                }
                else if (statusOperacao == "C")
                {

                    //Monta comando para a gravação do registro
                    String strSQL = "update IptuCobranca set situacao=@situacao " +
                                           " Where idlocacaopagar = @idlocacaopagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaopagar", idLocacaoPagar);
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

        public IptuCobranca ObterPor(IptuCobranca oCC)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from IptuCobranca Where idIptuCobranca = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oCC.idIptuCobranca);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                IptuCobranca oCCPagar = new IptuCobranca();

                while (drCon.Read())
                {
                    consulta = true;
                  

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    FornecedorDAO oLocadorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    //oCCPagar.locador = oLocadorDAO.ObterPor(oCCPagar.locador);

                    LocacaoProventosDAO oProventoDAO = new LocacaoProventosDAO(parConexao, oOcorrencia, codEmpresa);
                    //oCCPagar.provento = oProventoDAO.ObterPor(oCCPagar.provento);

                }
                return oCCPagar;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(IptuCobranca oCCPagar, string flag)
        {
            //try
            //{
            //    string descricao = "";

            //    UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
            //    oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
            //    // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
            //    oOcorrencia.chaveidentificacao = oCCPagar.idLocacaoContrato.ToString();

            //    if (flag == "A")
            //    {

            //        IptuCobranca oCCP = new IptuCobranca();
            //        oCCP = ObterPor(oCCPagar);

            //        if (!oCCP.Equals(oCCPagar))
            //        {
            //            descricao = "Contrato Locacao id: " + oCCPagar.idLocacaoContrato + 
            //                        " Locacao Pagar id : " + oCCPagar.idLocacaoPagar + 
            //                        " CCPagar id : " + oCCPagar.idIptuCobranca + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

            //            if (!oCCP.locador.Equals(oCCPagar.locador))
            //            {
            //                descricao += " Locador de " + oCCP.locador.pessoa.nome + " para " + oCCPagar.locador.pessoa.nome;
            //            }
            //            if (!oCCP.tipoProvento.Equals(oCCPagar.tipoProvento))
            //            {
            //                descricao += " Tipo Provento de " + oCCP.tipoProvento + " para " + oCCPagar.tipoProvento;
            //            }
            //            if (!oCCP.descricao.Equals(oCCPagar.descricao))
            //            {
            //                descricao += " Descrição de " + oCCP.descricao + " para " + oCCPagar.descricao;
            //            }
            //            if (!oCCP.dataLancamento.Equals(oCCPagar.dataLancamento))
            //            {
            //                descricao += " Data Lancamento de " + oCCP.dataLancamento + " para " + oCCPagar.dataLancamento;
            //            }
            //            if (!oCCP.dataEmissao.Equals(oCCPagar.dataEmissao))
            //            {
            //                descricao += " Data Emissão de " + oCCP.dataEmissao + " para " + oCCPagar.dataEmissao;
            //            }
            //            if (!oCCP.valorLancamento.Equals(oCCPagar.valorLancamento))
            //            {
            //                descricao += " Valor Lancamento de " + oCCP.valorLancamento + " para " + oCCPagar.valorLancamento;
            //            }
            //            if (!oCCP.situacao.Equals(oCCPagar.situacao))
            //            {
            //                descricao += " Situação de " + oCCP.situacao + " para " + oCCPagar.situacao;
            //            }
            //        }
            //    }
            //    else if (flag == "I")
            //    {
            //        descricao = "Contrato Locacao id: " + oCCPagar.idLocacaoContrato + 
            //                    " Locacao Pagar id : " + oCCPagar.idLocacaoPagar + 
            //                    " CCPagar id : " + oCCPagar.idIptuCobranca + 
            //                    " Locador : " + oCCPagar.locador.pessoa.nome + " - " + oCCPagar.locador.pessoa.idPessoa +
            //                    " Tipo Provento : " + oCCPagar.tipoProvento +
            //                    " Descrição : " + oCCPagar.descricao +
            //                    " Data Lançamento : " + oCCPagar.dataLancamento.ToShortDateString() +
            //                    " Data Emissão : " + oCCPagar.dataEmissao.ToShortDateString() +
            //                    " Valor Lançamento : " + oCCPagar.valorLancamento.ToString() +
            //                    " Situação : " + oCCPagar.situacao +
            //                    " foi incluida por " + oOcorrencia.usuario.nome;
            //    }
            //    else if (flag == "E")
            //    {
            //        descricao = "Contrato Locacao id: " + oCCPagar.idLocacaoContrato +
            //                    " Locacao Pagar id : " + oCCPagar.idLocacaoPagar +
            //                    " CCPagar id : " + oCCPagar.idIptuCobranca +
            //                    " Locador : " + oCCPagar.locador.pessoa.nome + " - " + oCCPagar.locador.pessoa.idPessoa +
            //                    " Tipo Provento : " + oCCPagar.tipoProvento +
            //                    " Descrição : " + oCCPagar.descricao +
            //                    " Data Lançamento : " + oCCPagar.dataLancamento.ToShortDateString() +
            //                    " Data Emissão : " + oCCPagar.dataEmissao.ToShortDateString() +
            //                    " Valor Lançamento : " + oCCPagar.valorLancamento.ToString() +
            //                    " Situação : " + oCCPagar.situacao +
            //                    " foi excluida por " + oOcorrencia.usuario.nome;
            //    }
            //    else if (flag == "R")
            //    {
            //        descricao = "Recuperado :Contrato Locacao id: " + oCCPagar.idLocacaoContrato +
            //                    " Locacao Pagar id : " + oCCPagar.idLocacaoPagar +
            //                    " CCPagar id : " + oCCPagar.idIptuCobranca +
            //                    " Locador : " + oCCPagar.locador.pessoa.nome + " - " + oCCPagar.locador.pessoa.idPessoa +
            //                    " Tipo Provento : " + oCCPagar.tipoProvento +
            //                    " Descrição : " + oCCPagar.descricao +
            //                    " Data Lançamento : " + oCCPagar.dataLancamento.ToShortDateString() +
            //                    " Data Emissão : " + oCCPagar.dataEmissao.ToShortDateString() +
            //                    " Valor Lançamento : " + oCCPagar.valorLancamento.ToString() +
            //                    " Situação : " + oCCPagar.situacao +
            //                    " foi recuperado por " + oOcorrencia.usuario.nome;
            //    }

            //    oOcorrencia.data_hora = DateTime.Now;
            //    descricao += " em " + oOcorrencia.data_hora.ToString();

            //    oOcorrencia.descricao = descricao;

            //}
            //catch (MySqlException erro)
            //{
            //    throw erro;
            //}


        }

    }
}
