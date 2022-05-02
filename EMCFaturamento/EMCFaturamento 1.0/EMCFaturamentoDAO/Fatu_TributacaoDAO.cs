using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCFaturamentoModel;


namespace EMCFaturamentoDAO
{
    public class Fatu_TributacaoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_TributacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
                codEmpresa = codempresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = codempresa;
            }

        }

        public void Salvar(Fatu_Tributacao objFatu_Tributacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_Tributacao'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_Tributacao.idfatu_tributacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_Tributacao, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_Tributacao (descricao, advertencia, situacao, sistematributacao, codigotributacao) values (@descricao, @advertencia, @situacao, @sistematributacao, @codigotributacao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_Tributacao.descricao);
                Sqlcon.Parameters.AddWithValue("@advertencia", objFatu_Tributacao.advertencia);
                Sqlcon.Parameters.AddWithValue("@situacao", objFatu_Tributacao.situacao);
                Sqlcon.Parameters.AddWithValue("@sistematributacao", objFatu_Tributacao.sistematributacao);
                Sqlcon.Parameters.AddWithValue("@codigotributacao", objFatu_Tributacao.codigotributacao);
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

        public void Atualizar(Fatu_Tributacao objFatu_Tributacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_Tributacao, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_Tributacao set descricao = @descricao, advertencia = @advertencia, situacao = @situacao, sistematributacao = @sistematributacao, codigotributacao = @codigotributacao where idfatu_tributacao = @idfatu_tributacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_tributacao", objFatu_Tributacao.idfatu_tributacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_Tributacao.descricao);
                Sqlcon.Parameters.AddWithValue("@advertencia", objFatu_Tributacao.advertencia);
                Sqlcon.Parameters.AddWithValue("@situacao", objFatu_Tributacao.situacao);
                Sqlcon.Parameters.AddWithValue("@sistematributacao", objFatu_Tributacao.sistematributacao);
                Sqlcon.Parameters.AddWithValue("@codigotributacao", objFatu_Tributacao.codigotributacao);
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

        public void Excluir(Fatu_Tributacao objFatu_Tributacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_Tributacao, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_Tributacao where idFatu_Tributacao = @idFatu_Tributacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_Tributacao", objFatu_Tributacao.idfatu_tributacao);

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

        public DataTable ListaFatu_Tributacao()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_Tributacao order by descricao";
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

        public Fatu_Tributacao ObterPor(Fatu_Tributacao oFatu_Tributacao)
        {
            MySqlDataReader drCon;
            try
            {

                if (oFatu_Tributacao.idfatu_tributacao > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_Tributacao Where idFatu_Tributacao=@idFatu_Tributacao";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_Tributacao", oFatu_Tributacao.idfatu_tributacao);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_Tributacao Where codigotributacao=@codigotributacao";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("codigotributacao", oFatu_Tributacao.codigotributacao);
                    drCon = Sqlcon.ExecuteReader();
                }

                


                while (drCon.Read())
                {
                    Fatu_Tributacao objFatu_Tributacao = new Fatu_Tributacao();
                    objFatu_Tributacao.idfatu_tributacao = Convert.ToInt32(drCon["idfatu_tributacao"].ToString());
                    objFatu_Tributacao.descricao = drCon["descricao"].ToString();
                    objFatu_Tributacao.advertencia = drCon["advertencia"].ToString();
                    objFatu_Tributacao.situacao = drCon["situacao"].ToString();
                    objFatu_Tributacao.sistematributacao = drCon["sistematributacao"].ToString();
                    objFatu_Tributacao.codigotributacao = drCon["codigotributacao"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_Tributacao;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_Tributacao objFatu_Tributacao1 = new Fatu_Tributacao();
                return objFatu_Tributacao1;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }

        }

        private void geraOcorrencia(Fatu_Tributacao oFatu_Tributacao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_Tributacao.idfatu_tributacao.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_Tributacao oCobr = new Fatu_Tributacao();
                    oCobr = ObterPor(oFatu_Tributacao);

                    if (!oCobr.Equals(oFatu_Tributacao))
                    {
                        descricao = "Tributação id: " + oFatu_Tributacao.idfatu_tributacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_Tributacao.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_Tributacao.descricao;
                        }
                        if (!oCobr.advertencia.Equals(oFatu_Tributacao.advertencia))
                        {
                            descricao += " Advertência de " + oCobr.advertencia + " para " + oFatu_Tributacao.advertencia;
                        }
                        if (!oCobr.situacao.Equals(oFatu_Tributacao.situacao))
                        {
                            descricao += " Situação de " + oCobr.situacao + " para " + oFatu_Tributacao.situacao;
                        }
                        if (!oCobr.situacao.Equals(oFatu_Tributacao.situacao))
                        {
                            descricao += " Situação de " + oCobr.situacao + " para " + oFatu_Tributacao.situacao;
                        }
                        if (!oCobr.sistematributacao.Equals(oFatu_Tributacao.sistematributacao))
                        {
                            descricao += " Sistema de Tributação de " + oCobr.sistematributacao + " para " + oFatu_Tributacao.sistematributacao;
                        }
                        if (!oCobr.situacao.Equals(oFatu_Tributacao.codigotributacao))
                        {
                            descricao += " Código de Tributação de " + oCobr.codigotributacao + " para " + oFatu_Tributacao.codigotributacao;
                        }

                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Tributação : " + oFatu_Tributacao.idfatu_tributacao + " - " + oFatu_Tributacao.descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Tributação : " + oFatu_Tributacao.idfatu_tributacao + " - " + oFatu_Tributacao.descricao + " | Sistema de Tributação :" + oFatu_Tributacao.sistematributacao + " | Código de Tributação :" + oFatu_Tributacao.codigotributacao + " foi excluído por " + oOcorrencia.usuario.nome;
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
