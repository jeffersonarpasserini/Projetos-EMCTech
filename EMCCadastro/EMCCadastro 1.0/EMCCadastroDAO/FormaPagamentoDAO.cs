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
    public class FormaPagamentoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FormaPagamentoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
                codEmpresa = idEmpresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = idEmpresa;
            }

        }

        public void Salvar(FormaPagamento objFormaPagamento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de FormaPagamento
            try
            {

                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'formapagamento'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFormaPagamento.idFormaPagamento = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFormaPagamento, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into FormaPagamento ( descricao, idhistoricopadrao ) values (@descricao, @idhistoricopadrao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFormaPagamento.descricao);
                Sqlcon.Parameters.AddWithValue("@idhistoricopadrao", objFormaPagamento.historicoPadrao.idHistorico);
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

        public void Atualizar(FormaPagamento objFormaPagamento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de FormaPagamento
            try
            {
                geraOcorrencia(objFormaPagamento, "A");               
                //Monta comando para a gravação do registro
                String strSQL = "update FormaPagamento set descricao = @descricao, idhistoricopadrao=@idhistoricopadrao where idFormaPagamento = @idFormaPagamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFormaPagamento", objFormaPagamento.idFormaPagamento);
                Sqlcon.Parameters.AddWithValue("@descricao", objFormaPagamento.descricao);
                Sqlcon.Parameters.AddWithValue("@idhistoricopadrao", objFormaPagamento.historicoPadrao.idHistorico);
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

        public void Excluir(FormaPagamento objFormaPagamento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de FormaPagamento
            try
            {
                geraOcorrencia(objFormaPagamento, "E");               
                //Monta comando para a gravação do registro
                String strSQL = "delete from FormaPagamento where idFormaPagamento = @idFormaPagamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFormaPagamento", objFormaPagamento.idFormaPagamento);
                
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

        public DataTable ListaFormaPagamento()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select f.*, h.descricao as descricaohistorico from FormaPagamento f, historico h "
                                +" where h.idhistorico = f.idhistoricopadrao order by f.descricao";
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

        public DataTable dstRelatorio(String sSQL)
           {
           try
              {
              //Monta comando para a gravação do registro
              //String strSQL = "select * from pessoa order by idpessoa";
              string strSQL = sSQL.ToString();
              MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
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

        public FormaPagamento ObterPor(FormaPagamento oFormaPagamento)
        {
            MySqlDataReader drCon;
            try
            {

                
                //Monta comando para a gravação do registro
                String strSQL = "select * from FormaPagamento Where idformapagamento=@idformapagamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idFormaPagamento", oFormaPagamento.idFormaPagamento);
                

                drCon = Sqlcon.ExecuteReader();

                bool bConsulta = false;
                FormaPagamento objFormaPagamento = new FormaPagamento();

                while (drCon.Read())
                {
                    bConsulta = true;

                
                    objFormaPagamento.idFormaPagamento = Convert.ToInt32(drCon["idFormaPagamento"].ToString());
                    objFormaPagamento.descricao = drCon["descricao"].ToString();

                    Historico oHistorico = new Historico();
                    oHistorico.idHistorico = EmcResources.cInt(drCon["idhistoricopadrao"].ToString());
                    objFormaPagamento.historicoPadrao = oHistorico;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bConsulta)
                {
                    HistoricoDAO oHistDAO = new HistoricoDAO(parConexao, oOcorrencia,codEmpresa);
                    objFormaPagamento.historicoPadrao = oHistDAO.ObterPor(objFormaPagamento.historicoPadrao);
                }

                return objFormaPagamento;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(FormaPagamento oFPagto, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFPagto.idFormaPagamento.ToString();

                if (flag == "A")
                {

                    FormaPagamento oForm = new FormaPagamento();
                    oForm = ObterPor(oFPagto);

                    if (!oForm.Equals(oFPagto))
                    {
                        descricao = "Forma Pagamento " + oFPagto.idFormaPagamento + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oForm.descricao.Equals(oFPagto.descricao))
                        {
                            descricao += " Descricao de " + oForm.descricao + " para " + oFPagto.descricao;
                        }
                        if (!oForm.historicoPadrao.idHistorico.Equals(oFPagto.historicoPadrao.idHistorico))
                        {
                            descricao += " Historico  de " + oForm.historicoPadrao.idHistorico+"-"+oForm.historicoPadrao.descricao + 
                                         " para " + oFPagto.historicoPadrao.idHistorico+"-"+oFPagto.historicoPadrao.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Forma Pagamento " + oFPagto.idFormaPagamento + " - " + oFPagto.descricao +
                                " Historico  " + oFPagto.historicoPadrao.idHistorico + "-" + oFPagto.historicoPadrao.descricao +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Forma Pagamento " + oFPagto.idFormaPagamento + " - " + oFPagto.descricao +
                                " Historico  " + oFPagto.historicoPadrao.idHistorico + "-" + oFPagto.historicoPadrao.descricao + 
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

        public DataTable pesquisaFormaPagamento(int empMaster, int idFormaPagamento, string descricao)
        {
            try
            {
                int colocaWhere = 1;

                //Monta comando para a gravação do registro
                String strSQL = "select fp.*, h.descricao as descricaohistorico from FormaPagamento fp, historico h "
                                +"where h.idhistorico = fp.idhistoricopadrao ";

                if (idFormaPagamento > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " fp.idformapagamento = @idformapagamento ";
                }

                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " fp.descricao like @descricao ";
                }

                strSQL += " order by @descricao";
               
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idformapagamento", idFormaPagamento);
                Sqlcon.Parameters.AddWithValue("@descricao", "%" + descricao.Trim() + "%");
                
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
