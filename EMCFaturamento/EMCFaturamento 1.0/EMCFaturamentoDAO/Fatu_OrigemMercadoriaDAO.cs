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
    public class Fatu_OrigemMercadoriaDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_OrigemMercadoriaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_OrigemMercadoria'"+
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_OrigemMercadoria.idfatu_origemmercadoria = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_OrigemMercadoria, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_OrigemMercadoria (descricao, codigoorigem) values (@descricao, @codigoorigem)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_OrigemMercadoria.descricao);
                Sqlcon.Parameters.AddWithValue("@codigoorigem", objFatu_OrigemMercadoria.codigoOrigem);
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

        public void Atualizar(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_OrigemMercadoria, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_OrigemMercadoria set codigoorigem=@codigoorigem, descricao = @descricao where idFatu_OrigemMercadoria = @idFatu_OrigemMercadoria";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_OrigemMercadoria", objFatu_OrigemMercadoria.idfatu_origemmercadoria);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_OrigemMercadoria.descricao);
                Sqlcon.Parameters.AddWithValue("@codigoorigem", objFatu_OrigemMercadoria.codigoOrigem);
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

        public void Excluir(Fatu_OrigemMercadoria objFatu_OrigemMercadoria)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_OrigemMercadoria, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_OrigemMercadoria where idFatu_OrigemMercadoria = @idFatu_OrigemMercadoria";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_OrigemMercadoria", objFatu_OrigemMercadoria.idfatu_origemmercadoria);

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

        public DataTable ListaFatu_OrigemMercadoria()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_origemmercadoria, concat(codigoorigem, '-', descricao) as descricao from Fatu_OrigemMercadoria order by descricao";
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

        public Fatu_OrigemMercadoria ObterPor(Fatu_OrigemMercadoria oFatu_OrigemMercadoria)
        {
            MySqlDataReader drCon;
            try
            {

                if (oFatu_OrigemMercadoria.idfatu_origemmercadoria > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_OrigemMercadoria Where idFatu_OrigemMercadoria=@idFatu_OrigemMercadoria";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_OrigemMercadoria", oFatu_OrigemMercadoria.idfatu_origemmercadoria);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_OrigemMercadoria Where codigoorigem=@codigoorigem";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigoorigem", oFatu_OrigemMercadoria.codigoOrigem);
                    drCon = Sqlcon.ExecuteReader();
                }

                


                while (drCon.Read())
                {
                    Fatu_OrigemMercadoria objFatu_OrigemMercadoria = new Fatu_OrigemMercadoria();
                    objFatu_OrigemMercadoria.idfatu_origemmercadoria = Convert.ToInt32(drCon["idFatu_OrigemMercadoria"].ToString());
                    objFatu_OrigemMercadoria.descricao = drCon["descricao"].ToString();
                    objFatu_OrigemMercadoria.codigoOrigem = drCon["codigoorigem"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_OrigemMercadoria;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_OrigemMercadoria objFatu_OrigemMercadoria1 = new Fatu_OrigemMercadoria();
                return objFatu_OrigemMercadoria1;

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

        private void geraOcorrencia(Fatu_OrigemMercadoria oFatu_OrigemMercadoria, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_OrigemMercadoria.idfatu_origemmercadoria.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_OrigemMercadoria oCobr = new Fatu_OrigemMercadoria();
                    oCobr = ObterPor(oFatu_OrigemMercadoria);

                    if (!oCobr.Equals(oFatu_OrigemMercadoria))
                    {
                        descricao = "Origem da Mercadoria id: " + oFatu_OrigemMercadoria.idfatu_origemmercadoria + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_OrigemMercadoria.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_OrigemMercadoria.descricao;
                        }
                        if (!oCobr.codigoOrigem.Equals(oFatu_OrigemMercadoria.codigoOrigem))
                        {
                            descricao += " Codigo Origem de " + oCobr.codigoOrigem + " para " + oFatu_OrigemMercadoria.codigoOrigem;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Origem da Mercadoria : " + oFatu_OrigemMercadoria.idfatu_origemmercadoria + " - " + oFatu_OrigemMercadoria.descricao + " - " + oFatu_OrigemMercadoria.codigoOrigem + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Origem da Mercadoria : " + oFatu_OrigemMercadoria.idfatu_origemmercadoria + " - " + oFatu_OrigemMercadoria.descricao + " - " + oFatu_OrigemMercadoria.codigoOrigem + " foi excluído por " + oOcorrencia.usuario.nome;
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
