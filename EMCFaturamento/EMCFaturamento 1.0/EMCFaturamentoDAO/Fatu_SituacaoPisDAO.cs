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
    public class Fatu_SituacaoPisDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_SituacaoPisDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'fatu_situacaopis'"+
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_SituacaoPis.idFatu_SituacaoPis = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_SituacaoPis, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_SituacaoPis (descricao, codigofiscal) values (@descricao, @codigofiscal)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_SituacaoPis.descricao);
                Sqlcon.Parameters.AddWithValue("@codigofiscal", objFatu_SituacaoPis.codigoFiscal);
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

        public void Atualizar(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_SituacaoPis, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_SituacaoPis set codigofiscal=@codigofiscal, descricao = @descricao where idFatu_SituacaoPis = @idFatu_SituacaoPis";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoPis", objFatu_SituacaoPis.idFatu_SituacaoPis);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_SituacaoPis.descricao);
                Sqlcon.Parameters.AddWithValue("@codigofiscal", objFatu_SituacaoPis.codigoFiscal);
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

        public void Excluir(Fatu_SituacaoPis objFatu_SituacaoPis)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_SituacaoPis, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_SituacaoPis where idFatu_SituacaoPis = @idFatu_SituacaoPis";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoPis", objFatu_SituacaoPis.idFatu_SituacaoPis);

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

        public DataTable ListaFatu_SituacaoPis()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_situacaopis, concat(codigofiscal, '-', descricao) as descricao from Fatu_SituacaoPis order by descricao";
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

        public Fatu_SituacaoPis ObterPor(Fatu_SituacaoPis oFatu_SituacaoPis)
        {
            MySqlDataReader drCon;
            try
            {

                if (oFatu_SituacaoPis.idFatu_SituacaoPis > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_SituacaoPis Where idFatu_SituacaoPis=@idFatu_SituacaoPis";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoPis", oFatu_SituacaoPis.idFatu_SituacaoPis);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_SituacaoPis Where codigofiscal=@codigofiscal";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigofiscal", oFatu_SituacaoPis.codigoFiscal);
                    drCon = Sqlcon.ExecuteReader();
                }

                


                while (drCon.Read())
                {
                    Fatu_SituacaoPis objFatu_SituacaoPis = new Fatu_SituacaoPis();
                    objFatu_SituacaoPis.idFatu_SituacaoPis = Convert.ToInt32(drCon["idFatu_SituacaoPis"].ToString());
                    objFatu_SituacaoPis.descricao = drCon["descricao"].ToString();
                    objFatu_SituacaoPis.codigoFiscal = drCon["codigofiscal"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_SituacaoPis;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_SituacaoPis objFatu_SituacaoPis1 = new Fatu_SituacaoPis();
                return objFatu_SituacaoPis1;

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

        private void geraOcorrencia(Fatu_SituacaoPis oFatu_SituacaoPis, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_SituacaoPis.idFatu_SituacaoPis.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_SituacaoPis oCobr = new Fatu_SituacaoPis();
                    oCobr = ObterPor(oFatu_SituacaoPis);

                    if (!oCobr.Equals(oFatu_SituacaoPis))
                    {
                        descricao = "Sit. Fiscal Pis id: " + oFatu_SituacaoPis.idFatu_SituacaoPis + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_SituacaoPis.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_SituacaoPis.descricao;
                        }
                        if (!oCobr.codigoFiscal.Equals(oFatu_SituacaoPis.codigoFiscal))
                        {
                            descricao += " Codigo Fiscal de " + oCobr.codigoFiscal + " para " + oFatu_SituacaoPis.codigoFiscal;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Sit. Fiscal Pis : " + oFatu_SituacaoPis.idFatu_SituacaoPis + " - " + oFatu_SituacaoPis.codigoFiscal + " - " + oFatu_SituacaoPis.descricao  + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Sit. Fiscal Pis : " + oFatu_SituacaoPis.idFatu_SituacaoPis + " - " + oFatu_SituacaoPis.codigoFiscal + " - " + oFatu_SituacaoPis.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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
