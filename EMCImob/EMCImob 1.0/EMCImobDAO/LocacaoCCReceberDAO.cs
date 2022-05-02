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
    public class LocacaoCCReceberDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoCCReceberDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoCCReceber> lstLocacaoCCReceber(int idContrato, int idLocacaoReceber)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                
                String strSQL = "select * from locacaoccReceber Where idlocacaocontrato = @idcontrato and idlocacaoReceber=@parcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);
                Sqlcon.Parameters.AddWithValue("@parcela", idLocacaoReceber);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoCCReceber> lstLocacaoCCReceber = new List<LocacaoCCReceber>();
                List<LocacaoCCReceber> lstRetorno = new List<LocacaoCCReceber>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoCCReceber oCCReceber = new LocacaoCCReceber();

                    oCCReceber.idLocacaoCCReceber = EmcResources.cInt(drCon["idlocacaoccReceber"].ToString());

                    lstLocacaoCCReceber.Add(oCCReceber);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoCCReceber oCC in lstLocacaoCCReceber)
                    {
                        LocacaoCCReceber oCCP = new LocacaoCCReceber();
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

        public int Salvar(LocacaoCCReceber oCCReceber, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oCCReceber.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'locacaoccreceber'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oCCReceber.idLocacaoCCReceber = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oCCReceber, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into locacaoccReceber (idlocacaoReceber, idlocacaoproventos, cliente_codempresa, idcliente, " +  
                                                                "tipoprovento, descricao, dataemissao, datalancamento, valorlancamento, situacao, " + 
                                                                "idlocacaocontrato, nroparcela )" +
                                    "values (@idlocacaoReceber, @idlocacaoproventos, @codempresa, @idlocatario, "+
                                            "@tipoprovento, @descricao, @dataemissao, @datalancamento, @valorlancamento, @situacao, " +
                                            "@idlocacaocontrato, @nroparcela )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoReceber", oCCReceber.idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoproventos", oCCReceber.provento.idLocacaoProventos);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oCCReceber.locatario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocatario", oCCReceber.locatario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@tipoprovento", oCCReceber.tipoProvento);
                    SqlconPar.Parameters.AddWithValue("@descricao", oCCReceber.descricao);
                    SqlconPar.Parameters.AddWithValue("@dataemissao", oCCReceber.dataEmissao);
                    SqlconPar.Parameters.AddWithValue("@datalancamento", oCCReceber.dataLancamento);
                    SqlconPar.Parameters.AddWithValue("@valorlancamento", oCCReceber.valorLancamento);
                    SqlconPar.Parameters.AddWithValue("@situacao", oCCReceber.situacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oCCReceber.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", oCCReceber.nroParcela);


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }

                else if (oCCReceber.statusOperacao == "A")
                {
                    geraOcorrencia(oCCReceber, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update locacaoccReceber set idlocacaoReceber=@idlocacaoReceber, idlocacaoproventos=@idlocacaoproventos, " +
                                                             " cliente_codempresa=@codempresa, idcliente=@idlocatario, tipoprovento=@tipoprovento, " +
                                                             " descricao=@descricao, dataemissao=@dataemissao, datalancamento=@datalancamento, " +
                                                             " valorlancamento=@valorlancamento, situacao=@situacao, " +
                                                             " idlocacaocontrato=@idlocacaocontrato " +
                                            " Where idlocacaoccReceber = @idlocacaoccReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoccReceber", oCCReceber.idLocacaoCCReceber);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoReceber", oCCReceber.idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoproventos", oCCReceber.provento.idLocacaoProventos);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oCCReceber.locatario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocatario", oCCReceber.locatario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@tipoprovento", oCCReceber.tipoProvento);
                    SqlconPar.Parameters.AddWithValue("@descricao", oCCReceber.descricao);
                    SqlconPar.Parameters.AddWithValue("@dataemissao", oCCReceber.dataEmissao);
                    SqlconPar.Parameters.AddWithValue("@datalancamento", oCCReceber.dataLancamento);
                    SqlconPar.Parameters.AddWithValue("@valorlancamento", oCCReceber.valorLancamento);
                    SqlconPar.Parameters.AddWithValue("@situacao", oCCReceber.situacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oCCReceber.idLocacaoContrato);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }

                else if (oCCReceber.statusOperacao == "C")
                {
                    geraOcorrencia(oCCReceber, "E");

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from locacaoccReceber where idlocacaoccReceber = @idlocacaoccReceber";
                    String strSQL = "update locacaoccReceber set situacao='C' where idlocacaoccReceber = @idlocacaoccReceber";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idlocacaoccReceber", oCCReceber.idLocacaoCCReceber);

                    Sqlcon.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oCCReceber.statusOperacao == "R")
                {
                    geraOcorrencia(oCCReceber, "R");

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from locacaoccReceber where idlocacaoccReceber = @idlocacaoccReceber";
                    String strSQL = "update locacaoccReceber set situacao='A' where idlocacaoccReceber = @idlocacaoccReceber";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idlocacaoccReceber", oCCReceber.idLocacaoCCReceber);

                    Sqlcon.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oCCReceber.statusOperacao == "G")
                {
                    /* Estorna integração com o financeiro */
                    String strSQL = "update locacaoccReceber set situacao='A' where idlocacaoccReceber = @idlocacaoccReceber";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idlocacaoccReceber", oCCReceber.idLocacaoCCReceber);

                    Sqlcon.ExecuteNonQuery();

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

            return oCCReceber.idLocacaoCCReceber;
        }

        public void integracao(int idLocacaoReceber, string statusOperacao, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (statusOperacao == "I")
                {

                    /* Muda status do conta corrente da parcela para G - de integrado ao financeiro */
                    String strSQL = "update locacaoccReceber set situacao=@situacao " +
                                            " Where idlocacaoreceber = @idlocacaoReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoReceber", idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@situacao", "G");


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    
                }
                else if (statusOperacao == "C")
                {
                   
                    //Monta comando para a gravação do registro
                    String strSQL = "update locacaoccReceber set situacao=@situacao " +
                                            " Where idlocacaoreceber = @idlocacaoReceber";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoReceber", idLocacaoReceber);
                    SqlconPar.Parameters.AddWithValue("@situacao", "A");

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LocacaoCCReceber ObterPor(LocacaoCCReceber oCC)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from locacaoccReceber Where idlocacaoccReceber = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oCC.idLocacaoCCReceber);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoCCReceber oCCReceber = new LocacaoCCReceber();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oCCReceber.idLocacaoCCReceber = EmcResources.cInt(drCon["idlocacaoccReceber"].ToString());
                    oCCReceber.idLocacaoReceber = EmcResources.cInt(drCon["idlocacaoReceber"].ToString());
                    oCCReceber.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    LocacaoProventos oProvento = new LocacaoProventos();
                    oProvento.idLocacaoProventos = EmcResources.cInt(drCon["idlocacaoproventos"].ToString());
                    oCCReceber.provento = oProvento;

                    Cliente oLocatario = new Cliente();
                    oLocatario.codEmpresa = EmcResources.cInt(drCon["cliente_codempresa"].ToString());
                    oLocatario.idPessoa = EmcResources.cInt(drCon["idcliente"].ToString());
                    oCCReceber.locatario = oLocatario;

                    oCCReceber.tipoProvento = drCon["tipoprovento"].ToString();
                    oCCReceber.descricao = drCon["descricao"].ToString();
                    oCCReceber.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    oCCReceber.dataLancamento = Convert.ToDateTime(drCon["datalancamento"].ToString());
                    oCCReceber.valorLancamento = EmcResources.cCur(drCon["valorlancamento"].ToString());
                    oCCReceber.situacao = drCon["situacao"].ToString();
                    oCCReceber.statusOperacao = "";
                    oCCReceber.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCReceber.locatario = oClienteDAO.ObterPor(oCCReceber.locatario);

                    LocacaoProventosDAO oProventoDAO = new LocacaoProventosDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCReceber.provento = oProventoDAO.ObterPor(oCCReceber.provento);

                }
                return oCCReceber;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoCCReceber oCCReceber, string flag)
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

                    LocacaoCCReceber oCCP = new LocacaoCCReceber();
                    oCCP = ObterPor(oCCReceber);

                    if (!oCCP.Equals(oCCReceber))
                    {
                        descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato + 
                                    " Locacao Receber id : " + oCCReceber.idLocacaoReceber + 
                                    " CCReceber id : " + oCCReceber.idLocacaoCCReceber + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.locatario.Equals(oCCReceber.locatario))
                        {
                            descricao += " Locatario de " + oCCP.locatario.pessoa.nome + " para " + oCCReceber.locatario.pessoa.nome;
                        }
                        if (!oCCP.tipoProvento.Equals(oCCReceber.tipoProvento))
                        {
                            descricao += " Tipo Provento de " + oCCP.tipoProvento + " para " + oCCReceber.tipoProvento;
                        }
                        if (!oCCP.descricao.Equals(oCCReceber.descricao))
                        {
                            descricao += " Descrição de " + oCCP.descricao + " para " + oCCReceber.descricao;
                        }
                        if (!oCCP.dataLancamento.Equals(oCCReceber.dataLancamento))
                        {
                            descricao += " Data Lancamento de " + oCCP.dataLancamento + " para " + oCCReceber.dataLancamento;
                        }
                        if (!oCCP.dataEmissao.Equals(oCCReceber.dataEmissao))
                        {
                            descricao += " Data Emissão de " + oCCP.dataEmissao + " para " + oCCReceber.dataEmissao;
                        }
                        if (!oCCP.valorLancamento.Equals(oCCReceber.valorLancamento))
                        {
                            descricao += " Valor Lancamento de " + oCCP.valorLancamento + " para " + oCCReceber.valorLancamento;
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
                                " CCReceber id : " + oCCReceber.idLocacaoCCReceber + 
                                " Locatario : " + oCCReceber.locatario.pessoa.nome + " - " + oCCReceber.locatario.pessoa.idPessoa +
                                " Tipo Provento : " + oCCReceber.tipoProvento +
                                " Descrição : " + oCCReceber.descricao +
                                " Data Lançamento : " + oCCReceber.dataLancamento.ToShortDateString() +
                                " Data Emissão : " + oCCReceber.dataEmissao.ToShortDateString() +
                                " Valor Lançamento : " + oCCReceber.valorLancamento.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoReceber +
                                " CCReceber id : " + oCCReceber.idLocacaoCCReceber +
                                " Locatario : " + oCCReceber.locatario.pessoa.nome + " - " + oCCReceber.locatario.pessoa.idPessoa +
                                " Tipo Provento : " + oCCReceber.tipoProvento +
                                " Descrição : " + oCCReceber.descricao +
                                " Data Lançamento : " + oCCReceber.dataLancamento.ToShortDateString() +
                                " Data Emissão : " + oCCReceber.dataEmissao.ToShortDateString() +
                                " Valor Lançamento : " + oCCReceber.valorLancamento.ToString() +
                                " Situação : " + oCCReceber.situacao +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "R")
                {
                    descricao = "Registro Recuperado : Contrato Locacao id: " + oCCReceber.idLocacaoContrato +
                                " Locacao Receber id : " + oCCReceber.idLocacaoReceber +
                                " CCReceber id : " + oCCReceber.idLocacaoCCReceber +
                                " Locatario : " + oCCReceber.locatario.pessoa.nome + " - " + oCCReceber.locatario.pessoa.idPessoa +
                                " Tipo Provento : " + oCCReceber.tipoProvento +
                                " Descrição : " + oCCReceber.descricao +
                                " Data Lançamento : " + oCCReceber.dataLancamento.ToShortDateString() +
                                " Data Emissão : " + oCCReceber.dataEmissao.ToShortDateString() +
                                " Valor Lançamento : " + oCCReceber.valorLancamento.ToString() +
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

    }
}
