using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCFinanceiroModel;

namespace EMCFinanceiroDAO
{
    public class ReceberAcordoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public ReceberAcordoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public int Salvar(ReceberAcordo oAcordo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'receberacordo'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oAcordo.idAcordo = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oAcordo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into receberacordo (idgeradoracordo, idaprovadoracordo, dataacordo, dataaprovacao, situacao, " + 
                                                           "cliente_codempresa, cliente_idpessoa, datalimiterecebimento, idempresa ) " +
                                " values (@idgeradoracordo, @idaprovadoracordo, @dataacordo, @dataaprovacao, @situacao, " +
                                                           "@cliente_codempresa, @cliente_idpessoa, @datalimiterecebimento, @idempresa )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idgeradoracordo", oAcordo.idGeradorAcordo);
                Sqlcon.Parameters.AddWithValue("@idaprovadoracordo", oAcordo.idAprovadorAcordo);
                Sqlcon.Parameters.AddWithValue("@dataacordo", oAcordo.dataAcordo);
                Sqlcon.Parameters.AddWithValue("@dataaprovacao", oAcordo.dataAprovacao);
                Sqlcon.Parameters.AddWithValue("@situacao", oAcordo.situacao);
                Sqlcon.Parameters.AddWithValue("@cliente_codempresa", oAcordo.cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@cliente_idpessoa", oAcordo.cliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@datalimiterecebimento", oAcordo.dataLimite);
                Sqlcon.Parameters.AddWithValue("@idempresa", oAcordo.idEmpresa);
                Sqlcon.ExecuteNonQuery();

                ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao,oOcorrencia,codEmpresa);

                foreach (ReceberParcela oParcela in oAcordo.lstParcelas)
                {
                    oParcela.idAcordo = oAcordo.idAcordo;
                    oParcelaDAO.atualizaAcordo(oParcela, Conexao, transacao);
                }

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                transacao.Commit();

                return oAcordo.idAcordo;
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

        public void Atualizar(ReceberAcordo oAcordo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oAcordo, "A");

                if (oAcordo.situacao == "A")
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "update receberacordo set situacao=@situacao " +
                                                             "Where idacordo=@idacordo ";


                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                    Sqlcon.Parameters.AddWithValue("@idacordo", oAcordo.idAcordo);
                    Sqlcon.Parameters.AddWithValue("@situacao", "P");
                    Sqlcon.ExecuteNonQuery();
                }
                ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);

                foreach (ReceberParcela oParcela in oAcordo.lstParcelas)
                {
                    oParcela.idAcordo = oAcordo.idAcordo;
                    oParcelaDAO.atualizaAcordo(oParcela, Conexao, transacao);
                }

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

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

        public void Excluir(ReceberAcordo oAcordo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oAcordo, "E");

                //Monta comando para a gravação do registro
                String strSQL = "update receberacordo set situacao = 'C' where idacordo = @idacordo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idacordo", oAcordo.idAcordo);
                Sqlcon.ExecuteNonQuery();

                ReceberParcelaDAO oParcelaDAO = new ReceberParcelaDAO(parConexao, oOcorrencia, codEmpresa);

                foreach (ReceberParcela oParcela in oAcordo.lstParcelas)
                {
                    oParcela.idAcordo = 0;
                    oParcela.jurosAcordo = 0;
                    oParcela.multaAcordo = 0;
                    oParcela.descontoAcordo = 0;

                    oParcelaDAO.atualizaAcordo(oParcela, Conexao, transacao);
                }

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

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

        public void aprovaAcordo( ReceberAcordo oAcordo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update receberacordo set idaprovadoracordo=@usr, situacao=@sit, dataaprovacao=@data, datalimiterecebimento=@limite where idacordo = @idacordo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idacordo", oAcordo.idAcordo);
                Sqlcon.Parameters.AddWithValue("@sit", "A");
                Sqlcon.Parameters.AddWithValue("@usr", oAcordo.idAprovadorAcordo);
                Sqlcon.Parameters.AddWithValue("@data", oAcordo.dataAprovacao);
                Sqlcon.Parameters.AddWithValue("@limite", oAcordo.dataLimite);
                Sqlcon.ExecuteNonQuery();

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

        public void estornaAprovacao(ReceberAcordo oAcordo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update receberacordo set idaprovadoracordo=@usr, situacao=@sit, dataaprovacao=@data, datalimiterecebimento=@limite where idacordo = @idacordo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idacordo", oAcordo.idAcordo);
                Sqlcon.Parameters.AddWithValue("@usr", oAcordo.idAprovadorAcordo);
                Sqlcon.Parameters.AddWithValue("@sit", "P");
                Sqlcon.Parameters.AddWithValue("@data", null);
                Sqlcon.Parameters.AddWithValue("@limite", null);
                Sqlcon.ExecuteNonQuery();

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

        public ReceberAcordo ObterPor(ReceberAcordo oAcordo)
        {
            MySqlDataReader drConta;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select a.*, u.nome as nomegerador, us.nome as nomeaprovador " +
                                "from receberacordo a " +
                                "  left join usuario u on u.idusuario =  a.idgeradoracordo " +
                                "  left join usuario us on us.idusuario = a.idaprovadoracordo " + 
                                "Where idacordo = " + oAcordo.idAcordo;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                Boolean bConsulta = false;
                Formulario oForm = new Formulario();
                while (drConta.Read())
                {
                    bConsulta = true;

                    oAcordo.idAcordo = EmcResources.cInt(drConta["idacordo"].ToString());
                    oAcordo.idGeradorAcordo = EmcResources.cInt(drConta["idgeradoracordo"].ToString());
                    oAcordo.nomeGerador = drConta["nomegerador"].ToString();
                    oAcordo.dataAcordo = Convert.ToDateTime(drConta["dataacordo"].ToString());
                    oAcordo.idAprovadorAcordo = EmcResources.cInt(drConta["idaprovadoracordo"].ToString());
                    oAcordo.nomeAprovador = drConta["nomeaprovador"].ToString();
                    oAcordo.dataAprovacao = EmcResources.cDate(drConta["dataaprovacao"].ToString());
                    oAcordo.situacao = drConta["situacao"].ToString();
                    oAcordo.dataLimite = EmcResources.cDate(drConta["datalimiterecebimento"].ToString());

                    Cliente oCliente = new Cliente();
                    oCliente.idPessoa = EmcResources.cInt(drConta["cliente_idpessoa"].ToString());
                    oCliente.codEmpresa = EmcResources.cInt(drConta["cliente_codempresa"].ToString());

                    oAcordo.cliente = oCliente;

                }

                drConta.Close();
                drConta.Dispose();

                if (bConsulta)
                {
                    ClienteDAO oCliDAO = new ClienteDAO(parConexao, oOcorrencia, codEmpresa);
                    oAcordo.cliente = oCliDAO.ObterPor(oAcordo.cliente);
                                        
                }


                return oAcordo;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drConta = null;
            }

        }

        private void geraOcorrencia(ReceberAcordo oAcordo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oAcordo.idAcordo.ToString();

                if (flag == "A" || flag == "AS")
                {

                    ReceberAcordo oAc = new ReceberAcordo();
                    oAc = ObterPor(oAcordo);

                    if ((!oAc.Equals(oAcordo) && flag == "A"))
                    {
                        descricao = "Acordo :" + oAcordo.idAcordo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oAc.idGeradorAcordo.Equals(oAcordo.idGeradorAcordo))
                        {
                            descricao += " Usario gerador : " + oAc.idGeradorAcordo + " - " + oAc.nomeGerador + 
                                         " para " + oAcordo.idGeradorAcordo + " - " + oAcordo.nomeGerador;
                        }
                        if (!oAc.idAprovadorAcordo.Equals(oAcordo.idAprovadorAcordo))
                        {
                            descricao += " Aprovador de: " + oAc.idAprovadorAcordo + " - " + oAc.nomeAprovador +
                                          " para :" + oAcordo.idAprovadorAcordo + " - " + oAcordo.nomeAprovador;
                        }
                        if (!oAc.dataAcordo.Equals(oAcordo.dataAcordo))
                        {
                            descricao += " Data Acordo :" + oAc.dataAcordo +" para " + oAcordo.dataAcordo;
                        }
                        if (!oAc.dataAprovacao.Equals(oAcordo.dataAprovacao))
                        {
                            descricao += " Data Aprovação : " + oAc.dataAprovacao + " para " + oAcordo.dataAprovacao;
                        }
                        if (!oAc.dataLimite.Equals(oAcordo.dataLimite))
                        {
                            descricao += " Data Limite Recebimento " + oAc.dataLimite + " para " + oAcordo.dataLimite;
                        }
                        if (!oAc.cliente.Equals(oAcordo.cliente))
                        {
                            descricao += " Cliente : " + oAc.cliente.codEmpresa + " - " + oAc.cliente.idPessoa + " - " + oAc.cliente.pessoa.nome +
                                         " para " + oAcordo.cliente.codEmpresa + " - " + oAcordo.cliente.idPessoa + " - " + oAcordo.cliente.pessoa.nome;
                        }
                        if (!oAc.situacao.Equals(oAcordo.situacao))
                        {
                            descricao += " Situacao: " + oAc.situacao + " para " + oAcordo.situacao;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = " Acordo : " + oAcordo.idAcordo + " - Data : " + oAcordo.dataAcordo +
                                " - Cliente : " + oAcordo.cliente.codEmpresa + " " + oAcordo.cliente.idPessoa + " " + oAcordo.cliente.pessoa.nome +
                                " - User gerador : " + oAcordo.idGeradorAcordo + " - nome : " + oAcordo.nomeGerador + 
                                " - User aprovador : " + oAcordo.idAprovadorAcordo + " - nome : " + oAcordo.nomeAprovador +
                                " - Dta Aprovação : " + oAcordo.dataAprovacao + " - Data Limite : " + oAcordo.dataLimite +
                                " - Situacao : " + oAcordo.situacao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Acordo : " + oAcordo.idAcordo + " - Data : " + oAcordo.dataAcordo +
                                " - Cliente : " + oAcordo.cliente.codEmpresa + " " + oAcordo.cliente.idPessoa + " " + oAcordo.cliente.pessoa.nome +
                                " - User gerador : " + oAcordo.idGeradorAcordo + " - nome : " + oAcordo.nomeGerador +
                                " - User aprovador : " + oAcordo.idAprovadorAcordo + " - nome : " + oAcordo.nomeAprovador +
                                " - Dta Aprovação : " + oAcordo.dataAprovacao + " - Data Limite : " + oAcordo.dataLimite +
                                " - Situacao : " + oAcordo.situacao + " foi cancelada por " + oOcorrencia.usuario.nome;

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
