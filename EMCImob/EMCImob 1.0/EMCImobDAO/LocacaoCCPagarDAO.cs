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
    public class LocacaoCCPagarDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoCCPagarDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoCCPagar> lstLocacaoCCPagar(int idContrato, int idLocacaoPagar)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                
                String strSQL = "select * from locacaoccpagar Where idlocacaocontrato = @idcontrato and idlocacaopagar=@parcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);
                Sqlcon.Parameters.AddWithValue("@parcela", idLocacaoPagar);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoCCPagar> lstLocacaoCCPagar = new List<LocacaoCCPagar>();
                List<LocacaoCCPagar> lstRetorno = new List<LocacaoCCPagar>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoCCPagar oCCPagar = new LocacaoCCPagar();

                    oCCPagar.idLocacaoCCPagar = EmcResources.cInt(drCon["idlocacaoccpagar"].ToString());

                    lstLocacaoCCPagar.Add(oCCPagar);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoCCPagar oCC in lstLocacaoCCPagar)
                    {
                        LocacaoCCPagar oCCP = new LocacaoCCPagar();
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

        public int Salvar(LocacaoCCPagar oCCPagar, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                if (oCCPagar.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'locacaoccpagar'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oCCPagar.idLocacaoCCPagar = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oCCPagar, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into locacaoccpagar (idlocacaopagar, idlocacaoproventos, codempresa, idlocador, " +  
                                                                "tipoprovento, descricao, dataemissao, datalancamento, valorlancamento, situacao, " + 
                                                                "idlocacaocontrato, nroparcela )" +
                                    "values (@idlocacaopagar, @idlocacaoproventos, @codempresa, @idlocador, "+
                                            "@tipoprovento, @descricao, @dataemissao, @datalancamento, @valorlancamento, @situacao, " +
                                            "@idlocacaocontrato, @nroparcela )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaopagar", oCCPagar.idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoproventos", oCCPagar.provento.idLocacaoProventos);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oCCPagar.locador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oCCPagar.locador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@tipoprovento", oCCPagar.tipoProvento);
                    SqlconPar.Parameters.AddWithValue("@descricao", oCCPagar.descricao);
                    SqlconPar.Parameters.AddWithValue("@dataemissao", oCCPagar.dataEmissao);
                    SqlconPar.Parameters.AddWithValue("@datalancamento", oCCPagar.dataLancamento);
                    SqlconPar.Parameters.AddWithValue("@valorlancamento", oCCPagar.valorLancamento);
                    SqlconPar.Parameters.AddWithValue("@situacao", oCCPagar.situacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oCCPagar.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", oCCPagar.nroParcela);


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }
                else if (oCCPagar.statusOperacao == "A")
                {
                    geraOcorrencia(oCCPagar, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update locacaoccpagar set idlocacaopagar=@idlocacaopagar, idlocacaoproventos=@idlocacaoproventos, " +
                                                             " codempresa=@codempresa, idlocador=@idlocador, tipoprovento=@tipoprovento, " +
                                                             " descricao=@descricao, dataemissao=@dataemissao, datalancamento=@datalancamento, " +
                                                             " valorlancamento=@valorlancamento, situacao=@situacao, " +
                                                             " idlocacaocontrato=@idlocacaocontrato " +
                                            " Where idlocacaoccpagar = @idlocacaoccpagar";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoccpagar", oCCPagar.idLocacaoCCPagar);
                    SqlconPar.Parameters.AddWithValue("@idlocacaopagar", oCCPagar.idLocacaoPagar);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoproventos", oCCPagar.provento.idLocacaoProventos);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oCCPagar.locador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oCCPagar.locador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@tipoprovento", oCCPagar.tipoProvento);
                    SqlconPar.Parameters.AddWithValue("@descricao", oCCPagar.descricao);
                    SqlconPar.Parameters.AddWithValue("@dataemissao", oCCPagar.dataEmissao);
                    SqlconPar.Parameters.AddWithValue("@datalancamento", oCCPagar.dataLancamento);
                    SqlconPar.Parameters.AddWithValue("@valorlancamento", oCCPagar.valorLancamento);
                    SqlconPar.Parameters.AddWithValue("@situacao", oCCPagar.situacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oCCPagar.idLocacaoContrato);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }
                else if (oCCPagar.statusOperacao == "C")
                {
                    geraOcorrencia(oCCPagar, "E");

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from locacaoccpagar where idlocacaoccpagar = @idlocacaoccpagar";
                    String strSQL = "update locacaoccpagar set situacao='C' where idlocacaoccpagar = @idlocacaoccpagar";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idlocacaoccpagar", oCCPagar.idLocacaoCCPagar);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oCCPagar.statusOperacao == "R")
                {
                    geraOcorrencia(oCCPagar, "R");

                    //Monta comando para a gravação do registro
                    //String strSQL = "delete from locacaoccpagar where idlocacaoccpagar = @idlocacaoccpagar";
                    String strSQL = "update locacaoccpagar set situacao='A' where idlocacaoccpagar = @idlocacaoccpagar";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idlocacaoccpagar", oCCPagar.idLocacaoCCPagar);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oCCPagar.statusOperacao == "G")
                {
                    /* Estorna integração com o financeiro */
                    String strSQL = "update locacaoccpagar set situacao='A' where idlocacaoccpagar = @idlocacaoccpagar";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idlocacaoccpagar", oCCPagar.idLocacaoCCPagar);

                    Sqlcon.ExecuteNonQuery();

                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

            return oCCPagar.idLocacaoCCPagar;
        }

        public void integracao(int idLocacaoPagar, string statusOperacao, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (statusOperacao == "I")
                {

                    /* Muda status do conta corrente da parcela para G - de integrado ao financeiro */
                    String strSQL = "update locacaoccpagar set situacao=@situacao " +
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
                    String strSQL = "update locacaoccpagar set situacao=@situacao " +
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

        public LocacaoCCPagar ObterPor(LocacaoCCPagar oCC)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from locacaoccpagar Where idlocacaoccpagar = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oCC.idLocacaoCCPagar);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoCCPagar oCCPagar = new LocacaoCCPagar();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oCCPagar.idLocacaoCCPagar = EmcResources.cInt(drCon["idlocacaoccpagar"].ToString());
                    oCCPagar.idLocacaoPagar = EmcResources.cInt(drCon["idlocacaopagar"].ToString());
                    oCCPagar.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    LocacaoProventos oProvento = new LocacaoProventos();
                    oProvento.idLocacaoProventos = EmcResources.cInt(drCon["idlocacaoproventos"].ToString());
                    oCCPagar.provento = oProvento;

                    Fornecedor oLocador = new Fornecedor();
                    oLocador.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    oLocador.idPessoa = EmcResources.cInt(drCon["idlocador"].ToString());
                    oCCPagar.locador = oLocador;

                    oCCPagar.tipoProvento = drCon["tipoprovento"].ToString();
                    oCCPagar.descricao = drCon["descricao"].ToString();
                    oCCPagar.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    oCCPagar.dataLancamento = Convert.ToDateTime(drCon["datalancamento"].ToString());
                    oCCPagar.valorLancamento = EmcResources.cCur(drCon["valorlancamento"].ToString());
                    oCCPagar.situacao = drCon["situacao"].ToString();
                    oCCPagar.statusOperacao = "";
                    oCCPagar.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    FornecedorDAO oLocadorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCPagar.locador = oLocadorDAO.ObterPor(oCCPagar.locador);

                    LocacaoProventosDAO oProventoDAO = new LocacaoProventosDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCPagar.provento = oProventoDAO.ObterPor(oCCPagar.provento);

                }
                return oCCPagar;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoCCPagar oCCPagar, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oCCPagar.idLocacaoContrato.ToString();

                if (flag == "A")
                {

                    LocacaoCCPagar oCCP = new LocacaoCCPagar();
                    oCCP = ObterPor(oCCPagar);

                    if (!oCCP.Equals(oCCPagar))
                    {
                        descricao = "Contrato Locacao id: " + oCCPagar.idLocacaoContrato + 
                                    " Locacao Pagar id : " + oCCPagar.idLocacaoPagar + 
                                    " CCPagar id : " + oCCPagar.idLocacaoCCPagar + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.locador.Equals(oCCPagar.locador))
                        {
                            descricao += " Locador de " + oCCP.locador.pessoa.nome + " para " + oCCPagar.locador.pessoa.nome;
                        }
                        if (!oCCP.tipoProvento.Equals(oCCPagar.tipoProvento))
                        {
                            descricao += " Tipo Provento de " + oCCP.tipoProvento + " para " + oCCPagar.tipoProvento;
                        }
                        if (!oCCP.descricao.Equals(oCCPagar.descricao))
                        {
                            descricao += " Descrição de " + oCCP.descricao + " para " + oCCPagar.descricao;
                        }
                        if (!oCCP.dataLancamento.Equals(oCCPagar.dataLancamento))
                        {
                            descricao += " Data Lancamento de " + oCCP.dataLancamento + " para " + oCCPagar.dataLancamento;
                        }
                        if (!oCCP.dataEmissao.Equals(oCCPagar.dataEmissao))
                        {
                            descricao += " Data Emissão de " + oCCP.dataEmissao + " para " + oCCPagar.dataEmissao;
                        }
                        if (!oCCP.valorLancamento.Equals(oCCPagar.valorLancamento))
                        {
                            descricao += " Valor Lancamento de " + oCCP.valorLancamento + " para " + oCCPagar.valorLancamento;
                        }
                        if (!oCCP.situacao.Equals(oCCPagar.situacao))
                        {
                            descricao += " Situação de " + oCCP.situacao + " para " + oCCPagar.situacao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Contrato Locacao id: " + oCCPagar.idLocacaoContrato + 
                                " Locacao Pagar id : " + oCCPagar.idLocacaoPagar + 
                                " CCPagar id : " + oCCPagar.idLocacaoCCPagar + 
                                " Locador : " + oCCPagar.locador.pessoa.nome + " - " + oCCPagar.locador.pessoa.idPessoa +
                                " Tipo Provento : " + oCCPagar.tipoProvento +
                                " Descrição : " + oCCPagar.descricao +
                                " Data Lançamento : " + oCCPagar.dataLancamento.ToShortDateString() +
                                " Data Emissão : " + oCCPagar.dataEmissao.ToShortDateString() +
                                " Valor Lançamento : " + oCCPagar.valorLancamento.ToString() +
                                " Situação : " + oCCPagar.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contrato Locacao id: " + oCCPagar.idLocacaoContrato +
                                " Locacao Pagar id : " + oCCPagar.idLocacaoPagar +
                                " CCPagar id : " + oCCPagar.idLocacaoCCPagar +
                                " Locador : " + oCCPagar.locador.pessoa.nome + " - " + oCCPagar.locador.pessoa.idPessoa +
                                " Tipo Provento : " + oCCPagar.tipoProvento +
                                " Descrição : " + oCCPagar.descricao +
                                " Data Lançamento : " + oCCPagar.dataLancamento.ToShortDateString() +
                                " Data Emissão : " + oCCPagar.dataEmissao.ToShortDateString() +
                                " Valor Lançamento : " + oCCPagar.valorLancamento.ToString() +
                                " Situação : " + oCCPagar.situacao +
                                " foi excluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "R")
                {
                    descricao = "Recuperado :Contrato Locacao id: " + oCCPagar.idLocacaoContrato +
                                " Locacao Pagar id : " + oCCPagar.idLocacaoPagar +
                                " CCPagar id : " + oCCPagar.idLocacaoCCPagar +
                                " Locador : " + oCCPagar.locador.pessoa.nome + " - " + oCCPagar.locador.pessoa.idPessoa +
                                " Tipo Provento : " + oCCPagar.tipoProvento +
                                " Descrição : " + oCCPagar.descricao +
                                " Data Lançamento : " + oCCPagar.dataLancamento.ToShortDateString() +
                                " Data Emissão : " + oCCPagar.dataEmissao.ToShortDateString() +
                                " Valor Lançamento : " + oCCPagar.valorLancamento.ToString() +
                                " Situação : " + oCCPagar.situacao +
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
