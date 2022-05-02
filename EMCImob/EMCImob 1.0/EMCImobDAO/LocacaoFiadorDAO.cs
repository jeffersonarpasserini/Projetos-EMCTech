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
    public class LocacaoFiadorDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoFiadorDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoFiador> lstLocacaoFiador(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoFiador Where idLocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoFiador> lstLocacaoFiador = new List<LocacaoFiador>();
                List<LocacaoFiador> lstRetorno = new List<LocacaoFiador>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoFiador oPagar = new LocacaoFiador();

                    oPagar.idLocacaoFiador = EmcResources.cInt(drCon["idLocacaoFiador"].ToString());

                    lstLocacaoFiador.Add(oPagar);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoFiador oCC in lstLocacaoFiador)
                    {
                        LocacaoFiador oRec = new LocacaoFiador();
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

        public void Salvar(LocacaoFiador oFiador, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oFiador.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoFiador'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oFiador.idLocacaoFiador = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oFiador, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoFiador ( idlocacaofiador, idlocacaocontrato, codempresa, idfiador, observacao, situacao )" +
                                    "values (@idlocacaofiador, @idlocacaocontrato, @codempresa, @idfiador, @observacao, @situacao )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaofiador", oFiador.idLocacaoFiador);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oFiador.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oFiador.fiador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idfiador", oFiador.fiador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@observacao", oFiador.observacao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oFiador.situacao);
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oFiador.statusOperacao == "A")
                {

                    geraOcorrencia(oFiador, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoFiador set codempresa=@codempresa, idfiador=@idfiador, observacao=@observacao, situacao=@situacao " +
                                    " where idlocacaofiador=@idlocacaofiador ";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaofiador", oFiador.idLocacaoFiador);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oFiador.fiador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idfiador", oFiador.fiador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oFiador.observacao);
                    SqlconPar.Parameters.AddWithValue("@situacao", oFiador.situacao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }

                else if (oFiador.statusOperacao == "E")
                {
                    geraOcorrencia(oFiador, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoFiador set observacao=@observacao, situacao=@situacao " +
                                    " where idlocacaofiador=@idlocacaofiador ";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaofiador", oFiador.idLocacaoFiador);
                    SqlconPar.Parameters.AddWithValue("@observacao", oFiador.observacao);
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

        public LocacaoFiador ObterPor(LocacaoFiador oCC)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoFiador Where idLocacaoFiador = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oCC.idLocacaoFiador);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoFiador oLocacaoFiador = new LocacaoFiador();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oLocacaoFiador.idLocacaoFiador = EmcResources.cInt(drCon["idLocacaoFiador"].ToString());
                    oLocacaoFiador.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    Fiador oFiador = new Fiador();
                    oFiador.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    oFiador.idPessoa = EmcResources.cInt(drCon["idfiador"].ToString());
                    oLocacaoFiador.fiador = oFiador;

                    oLocacaoFiador.observacao = drCon["observacao"].ToString();
                    oLocacaoFiador.situacao = drCon["situacao"].ToString();

                    oLocacaoFiador.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    FiadorDAO oFiadorDAO = new FiadorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoFiador.fiador = oFiadorDAO.ObterPor(oLocacaoFiador.fiador);
                }
                return oLocacaoFiador;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoFiador oLocFiador, string flag)
        {
            try
            {
                string descricao = "";
                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLocFiador.idLocacaoContrato.ToString();

                if (flag == "A")
                {
                    LocacaoFiador oCCP = new LocacaoFiador();
                    oCCP = ObterPor(oLocFiador);

                    if (!oCCP.Equals(oLocFiador))
                    {
                        descricao = "Locacao Fiador id: " + oLocFiador.idLocacaoFiador + 
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.idLocacaoContrato.Equals(oLocFiador.idLocacaoContrato))
                        {
                            descricao += " Contrato de " + oCCP.idLocacaoContrato + " para " + oLocFiador.idLocacaoContrato;
                        }
                        if (!oCCP.fiador.Equals(oLocFiador.fiador))
                        {
                            descricao += " Fiador de " + oCCP.fiador.pessoa.nome + " para " + oLocFiador.fiador.pessoa.nome;
                        }
                        if (!oCCP.observacao.Equals(oLocFiador.observacao))
                        {
                            descricao += " Observacao de " + oCCP.observacao + " para " + oLocFiador.observacao;
                        }
                        if (!oCCP.situacao.Equals(oLocFiador.situacao))
                        {
                            descricao += " Situacao de " + oCCP.situacao + " para " + oLocFiador.situacao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Locacao Fiador id: " + oLocFiador.idLocacaoFiador + 
                                " Contrato Locacao id : " + oLocFiador.idLocacaoContrato + 
                                " Fiador : " + oLocFiador.fiador.pessoa.nome + " - " + oLocFiador.fiador.pessoa.idPessoa +
                                " Observacao : " + oLocFiador.observacao +
                                " Situação : " + oLocFiador.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Locacao Fiador id: " + oLocFiador.idLocacaoFiador +
                                " Contrato Locacao id : " + oLocFiador.idLocacaoContrato +
                                " Fiador : " + oLocFiador.fiador.pessoa.nome + " - " + oLocFiador.fiador.pessoa.idPessoa +
                                " Observacao : " + oLocFiador.observacao +
                                " Situação : " + oLocFiador.situacao +
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
