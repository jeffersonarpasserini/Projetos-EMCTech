using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCCadastroDAO
{
    public class HistoricoDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public HistoricoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Historico oHistorico)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'Historico'"+
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oHistorico.idHistorico = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oHistorico, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Historico (idHistorico, descricao, exigecomplemento ) " + 
                                " values (@idHistorico, @descricao, @exigecomplemento)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idHistorico", oHistorico.idHistorico);
                Sqlcon.Parameters.AddWithValue("@descricao", oHistorico.descricao );
                Sqlcon.Parameters.AddWithValue("@exigecomplemento", oHistorico.exigecomplemento);
                Sqlcon.ExecuteNonQuery();


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

        public void Atualizar(Historico oHistorico)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oHistorico, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Historico set descricao = @descricao, exigecomplemento=@exigecomplemento " +
                                                      "where idHistorico = @idHistorico";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idHistorico", oHistorico.idHistorico);
                Sqlcon.Parameters.AddWithValue("@descricao", oHistorico.descricao);
                Sqlcon.Parameters.AddWithValue("@exigecomplemento", oHistorico.exigecomplemento);
                Sqlcon.ExecuteNonQuery();



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

        public void Excluir(Historico oHistorico)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oHistorico, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from Historico where idHistorico = @idHistorico";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idHistorico", oHistorico.idHistorico);
                Sqlcon.ExecuteNonQuery();

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

        public DataTable ListaHistorico(Historico oHistorico)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idHistorico, descricao, exigecomplemento from Historico "; 
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);


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

        public Historico ObterPor(Historico oHistorico)
        {
            MySqlDataReader drConta;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from Historico Where idHistorico = " + oHistorico.idHistorico;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                while (drConta.Read())
                {

                    Historico oHold = new Historico();

                    oHold.idHistorico = EmcResources.cInt(drConta["idHistorico"].ToString());
                    oHold.descricao = drConta["descricao"].ToString();
                    oHold.exigecomplemento = drConta["exigecomplemento"].ToString();

                    drConta.Close();
                    drConta.Dispose();

                    return oHold;
                }

                drConta.Close();
                drConta.Dispose();
                Historico objCta1 = new Historico();
                return objCta1;

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

        private void geraOcorrencia(Historico oHistorico, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oHistorico.idHistorico.ToString();

                if (flag == "A" || flag=="AS")
                {

                    Historico oHold = new Historico();
                    oHold = ObterPor(oHistorico);

                    if (flag == "AS")
                    {
                        descricao = " Atualização de Numero : de " + " foi excluída por " + oOcorrencia.usuario.nome;
                    }

                    if (!oHold.Equals(oHistorico) && flag=="A")
                    {
                        descricao = "Historico :" + oHistorico.idHistorico + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oHold.descricao.Equals(oHistorico.descricao))
                        {
                            descricao += " Nome Historico : " + oHold.descricao + " para " + oHistorico.descricao;
                        }
                        if (!oHold.exigecomplemento.Equals(oHistorico.exigecomplemento))
                        {
                            descricao += " Exige Complemento de : " + oHold.exigecomplemento + " para " + oHistorico.exigecomplemento;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Historico : " + oHistorico.idHistorico + " - Nome : " + oHistorico.descricao +
                                " Exige Complemento : " + oHistorico.exigecomplemento +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Historico : " + oHistorico.idHistorico + " - Nome : " + oHistorico.descricao +
                                " Exige Complemento : " + oHistorico.exigecomplemento +        
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

        public DataTable pesquisaHistorico(int empMaster, int idHistorico, String descricao, String exigeComplemento)
        {
            try
            {

                String strSQL = "select h.* from historico h ";
                                

                if (idHistorico > 0)
                {

                    strSQL += " where h.idhistorico =@idhistorico";
                }
                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                    strSQL += " where h.descricao like @descricao";
                }
                if (!String.IsNullOrEmpty(exigeComplemento.Trim()))
                {
                    strSQL += " where h.exigecomplemento like @exigecomplemento";
                }

                strSQL += " order by h.descricao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idhistorico", idHistorico);
                Sqlcon.Parameters.AddWithValue("@descricao", "%" + descricao.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@exigecomplemento", "%" + exigeComplemento.Trim() + "%");

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

    }
}
