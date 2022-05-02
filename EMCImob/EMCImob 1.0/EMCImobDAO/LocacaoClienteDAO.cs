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
    public class LocacaoClienteDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoClienteDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoCliente> lstLocacaoCliente(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoCliente Where idlocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoCliente> lstLocacaoCliente = new List<LocacaoCliente>();
                List<LocacaoCliente> lstRetorno = new List<LocacaoCliente>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoCliente oLocCliente = new LocacaoCliente();

                    oLocCliente.idLocacaoCliente = EmcResources.cInt(drCon["idLocacaoCliente"].ToString());

                    lstLocacaoCliente.Add(oLocCliente);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoCliente oCliente in lstLocacaoCliente)
                    {
                        LocacaoCliente oRec = new LocacaoCliente();
                        oRec = ObterPor(oCliente);

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

        public void Salvar(LocacaoCliente oLocCliente, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oLocCliente.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoCliente'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oLocCliente.idLocacaoCliente = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oLocCliente, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoCliente ( idLocacaoCliente, idlocacaocontrato, cliente_codempresa, idcliente, percparticipacao, valoraluguel, situacao, representante )" +
                                    "values (@idLocacaoCliente, @idlocacaocontrato, @codempresa, @idcliente, @percparticipacao, @valoraluguel, @situacao, @representante )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoCliente", oLocCliente.idLocacaoCliente);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocCliente.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oLocCliente.locatario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idcliente", oLocCliente.locatario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oLocCliente.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@valoraluguel", oLocCliente.valorAluguel);
                    SqlconPar.Parameters.AddWithValue("@situacao", "A");
                    SqlconPar.Parameters.AddWithValue("@representante", oLocCliente.representante);
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oLocCliente.statusOperacao == "A")
                {

                    geraOcorrencia(oLocCliente, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoCliente set idlocacaocontrato=@idlocacaocontrato, cliente_codempresa=@codempresa, " + 
                                                              "idcliente=@idcliente, percparticipacao=@percparticipacao, valoraluguel=@valoraluguel, " +
                                                              "representante=@representante "+
                                    "where idLocacaoCliente=@idLocacaoCliente";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoCliente", oLocCliente.idLocacaoCliente);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocCliente.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oLocCliente.locatario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idcliente", oLocCliente.locatario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oLocCliente.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@valoraluguel", oLocCliente.valorAluguel);
                    SqlconPar.Parameters.AddWithValue("@representante", oLocCliente.representante);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }

                else if (oLocCliente.statusOperacao == "E")
                {
                    geraOcorrencia(oLocCliente, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoCliente set situacao=@situacao " +
                                    " where idLocacaoCliente=@idLocacaoCliente ";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoCliente", oLocCliente.idLocacaoCliente);
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

        public LocacaoCliente ObterPor(LocacaoCliente oLocCliente)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoCliente Where idLocacaoCliente = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oLocCliente.idLocacaoCliente);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoCliente oLocacaoCliente = new LocacaoCliente();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oLocacaoCliente.idLocacaoCliente = EmcResources.cInt(drCon["idLocacaoCliente"].ToString());
                    oLocacaoCliente.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    Cliente oCliente = new Cliente();
                    oCliente.codEmpresa = EmcResources.cInt(drCon["cliente_codempresa"].ToString());
                    oCliente.idPessoa = EmcResources.cInt(drCon["idcliente"].ToString());
                    oLocacaoCliente.locatario = oCliente;

                    oLocacaoCliente.percParticipacao = EmcResources.cDouble(drCon["percparticipacao"].ToString());
                    oLocacaoCliente.valorAluguel = EmcResources.cCur(drCon["valoraluguel"].ToString());
                    oLocacaoCliente.situacao = drCon["situacao"].ToString();
                    oLocacaoCliente.representante = drCon["representante"].ToString();

                    oLocacaoCliente.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoCliente.locatario = oClienteDAO.ObterPor(oLocacaoCliente.locatario);
                }
                return oLocacaoCliente;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoCliente oLocCliente, string flag)
        {
            try
            {
                string descricao = "";
                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLocCliente.idLocacaoContrato.ToString();

                if (flag == "A")
                {
                    LocacaoCliente oCCP = new LocacaoCliente();
                    oCCP = ObterPor(oLocCliente);

                    if (!oCCP.Equals(oLocCliente))
                    {
                        descricao = "Locacao Cliente id: " + oLocCliente.idLocacaoCliente + 
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.idLocacaoContrato.Equals(oLocCliente.idLocacaoContrato))
                        {
                            descricao += " Contrato de " + oCCP.idLocacaoContrato + " para " + oLocCliente.idLocacaoContrato;
                        }
                        if (!oCCP.locatario.Equals(oLocCliente.locatario))
                        {
                            descricao += " locatario de " + oCCP.locatario.pessoa.nome + " para " + oLocCliente.locatario.pessoa.nome;
                        }
                        if (!oCCP.percParticipacao.Equals(oLocCliente.percParticipacao))
                        {
                            descricao += " %Participação de " + oCCP.percParticipacao.ToString() + " para " + oLocCliente.percParticipacao.ToString();
                        }
                        if (!oCCP.valorAluguel.Equals(oLocCliente.valorAluguel))
                        {
                            descricao += " Valor Aluguel de " + oCCP.valorAluguel.ToString() + " para " + oLocCliente.valorAluguel.ToString();
                        }
                        if (!oCCP.situacao.Equals(oLocCliente.situacao))
                        {
                            descricao += " Situacao de " + oCCP.situacao + " para " + oLocCliente.situacao;
                        }
                        if (!oCCP.representante.Equals(oLocCliente.representante))
                        {
                            descricao += " Representante de " + oCCP.representante + " para " + oLocCliente.representante;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Locacao Fiador id: " + oLocCliente.idLocacaoCliente + 
                                " Contrato Locacao id : " + oLocCliente.idLocacaoContrato + 
                                " locatario : " + oLocCliente.locatario.pessoa.nome + " - " + oLocCliente.locatario.pessoa.idPessoa +
                                " %Participação : " + oLocCliente.percParticipacao.ToString() +
                                " Valor Aluguel : " + oLocCliente.valorAluguel.ToString() +
                                " Situação : " + oLocCliente.situacao +
                                " Representante : " + oLocCliente.representante +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Locacao Fiador id: " + oLocCliente.idLocacaoCliente +
                                " Contrato Locacao id : " + oLocCliente.idLocacaoContrato +
                                " locatario : " + oLocCliente.locatario.pessoa.nome + " - " + oLocCliente.locatario.pessoa.idPessoa +
                                " %Participação : " + oLocCliente.percParticipacao.ToString() +
                                " Valor Aluguel : " + oLocCliente.valorAluguel.ToString() +
                                " Situação : " + oLocCliente.situacao +
                                " Representante : " + oLocCliente.representante +
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
