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
    public class LocacaoContabilDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoContabilDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoContabil> lstLocacaoContabil(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoContabil Where idlocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoContabil> lstLocacaoContabil = new List<LocacaoContabil>();
                List<LocacaoContabil> lstRetorno = new List<LocacaoContabil>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoContabil oLocContabil = new LocacaoContabil();

                    oLocContabil.idLocacaoContabil = EmcResources.cInt(drCon["idLocacaoContabil"].ToString());

                    lstLocacaoContabil.Add(oLocContabil);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoContabil oContabil in lstLocacaoContabil)
                    {
                        LocacaoContabil oRec = new LocacaoContabil();
                        oRec = ObterPor(oContabil);

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

        public void Salvar(LocacaoContabil oLocContabil, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oLocContabil.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoContabil'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oLocContabil.idLocacaoContabil = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oLocContabil, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoContabil ( idLocacaoContabil, idlocacaocontrato, idlocacaoproventos, dataemissao, " +
                                                                 " datalancamento, valorlancamento, descricao, situacao )" +
                                    "values (@idLocacaoContabil, @idlocacaocontrato, @idlocacaoproventos, @dataemissao, @datalancamento, " + 
                                            "@valorlancamento, @descricao, @situacao )";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoContabil", oLocContabil.idLocacaoContabil);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocContabil.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoproventos", oLocContabil.provento.idLocacaoProventos);
                    SqlconPar.Parameters.AddWithValue("@dataemissao", oLocContabil.dataEmissao);
                    SqlconPar.Parameters.AddWithValue("@datalancamento", oLocContabil.dataLancamento);
                    SqlconPar.Parameters.AddWithValue("@valorlancamento", oLocContabil.valorLancamento);
                    SqlconPar.Parameters.AddWithValue("@descricao", oLocContabil.descricao);
                    SqlconPar.Parameters.AddWithValue("@situacao", "A");
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oLocContabil.statusOperacao == "A")
                {

                    geraOcorrencia(oLocContabil, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoContabil set idlocacaocontrato=@idlocacaocontrato, idlocacaoproventos=@idlocacaoproventos, " +
                                                               "dataemissao=@dataemissao, datalancamento=@datalancamento, " +
                                                               "valorlancamento=@valorlancamento, descricao=@descricao, situacao=@situacao " +
                                    "where idLocacaoContabil=@idLocacaoContabil ";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoContabil", oLocContabil.idLocacaoContabil);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocContabil.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@idlocacaoproventos", oLocContabil.provento.idLocacaoProventos);
                    SqlconPar.Parameters.AddWithValue("@dataemissao", oLocContabil.dataEmissao);
                    SqlconPar.Parameters.AddWithValue("@datalancamento", oLocContabil.dataLancamento);
                    SqlconPar.Parameters.AddWithValue("@valorlancamento", oLocContabil.valorLancamento);
                    SqlconPar.Parameters.AddWithValue("@descricao", oLocContabil.descricao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oLocContabil.situacao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }

                else if (oLocContabil.statusOperacao == "E")
                {
                    geraOcorrencia(oLocContabil, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoContabil set situacao=@situacao " +
                                    " where idLocacaoContabil=@idLocacaoContabil ";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoContabil", oLocContabil.idLocacaoContabil);
                    SqlconPar.Parameters.AddWithValue("@situacao", "C" );
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LocacaoContabil ObterPor(LocacaoContabil oLocContabil)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoContabil Where idLocacaoContabil = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oLocContabil.idLocacaoContabil);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoContabil oLocacaoContabil = new LocacaoContabil();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oLocacaoContabil.idLocacaoContabil = EmcResources.cInt(drCon["idLocacaoContabil"].ToString());
                    oLocacaoContabil.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    LocacaoProventos oProvento = new LocacaoProventos();
                    oProvento.idLocacaoProventos = EmcResources.cInt(drCon["idlocacaoproventos"].ToString());
                    oLocacaoContabil.provento = oProvento;

                    oLocacaoContabil.dataEmissao = Convert.ToDateTime(drCon["dataemissao"].ToString());
                    oLocacaoContabil.dataLancamento = Convert.ToDateTime(drCon["datalancamento"].ToString());
                    oLocacaoContabil.valorLancamento = EmcResources.cCur(drCon["valorlancamento"].ToString());
                    oLocacaoContabil.descricao = drCon["descricao"].ToString();
                    oLocacaoContabil.situacao = drCon["situacao"].ToString();

                    oLocacaoContabil.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    LocacaoProventosDAO oProventoDAO = new LocacaoProventosDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoContabil.provento = oProventoDAO.ObterPor(oLocacaoContabil.provento);
                }
                return oLocacaoContabil;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoContabil oLocContabil, string flag)
        {
            try
            {
                string descricao = "";
                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLocContabil.idLocacaoContrato.ToString();

                if (flag == "A")
                {
                    LocacaoContabil oCCP = new LocacaoContabil();
                    oCCP = ObterPor(oLocContabil);

                    if (!oCCP.Equals(oLocContabil))
                    {
                        descricao = "Locacao Contabil id: " + oLocContabil.idLocacaoContabil + 
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.idLocacaoContrato.Equals(oLocContabil.idLocacaoContrato))
                        {
                            descricao += " Contrato de " + oCCP.idLocacaoContrato + " para " + oLocContabil.idLocacaoContrato;
                        }
                        if (!oCCP.provento.Equals(oLocContabil.provento))
                        {
                            descricao += " Provento de " + oCCP.provento.Descricao + " para " + oLocContabil.provento.Descricao;
                        }
                        if (!oCCP.dataEmissao.Equals(oLocContabil.dataEmissao))
                        {
                            descricao += " Data Emissão de " + oCCP.dataEmissao.ToString() + " para " + oLocContabil.dataEmissao.ToString();
                        }
                        if (!oCCP.dataLancamento.Equals(oLocContabil.dataLancamento))
                        {
                            descricao += " Data Lancamento de " + oCCP.dataLancamento.ToString() + " para " + oLocContabil.dataLancamento.ToString();
                        }
                        if (!oCCP.descricao.Equals(oLocContabil.descricao))
                        {
                            descricao += " Descricao de " + oCCP.descricao + " para " + oLocContabil.descricao;
                        }
                        if (!oCCP.situacao.Equals(oLocContabil.situacao))
                        {
                            descricao += " Situacao de " + oCCP.situacao + " para " + oLocContabil.situacao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Locacao Fiador id: " + oLocContabil.idLocacaoContabil + 
                                " Contrato Locacao id : " + oLocContabil.idLocacaoContrato + 
                                " Provento : " + oLocContabil.provento.idLocacaoProventos + " - " + oLocContabil.provento.Descricao +
                                " Data Emissao : " + oLocContabil.dataEmissao.ToString() +
                                " Data Lancamento : " + oLocContabil.dataLancamento.ToString() +
                                " Valor : " + oLocContabil.valorLancamento.ToString() +
                                " Descricao : " + oLocContabil.descricao +
                                " Situação : " + oLocContabil.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Locacao Fiador id: " + oLocContabil.idLocacaoContabil +
                                " Contrato Locacao id : " + oLocContabil.idLocacaoContrato +
                                " Provento : " + oLocContabil.provento.idLocacaoProventos + " - " + oLocContabil.provento.Descricao +
                                " Data Emissao : " + oLocContabil.dataEmissao.ToString() +
                                " Data Lancamento : " + oLocContabil.dataLancamento.ToString() +
                                " Valor : " + oLocContabil.valorLancamento.ToString() +
                                " Descricao : " + oLocContabil.descricao +
                                " Situação : " + oLocContabil.situacao + 
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
