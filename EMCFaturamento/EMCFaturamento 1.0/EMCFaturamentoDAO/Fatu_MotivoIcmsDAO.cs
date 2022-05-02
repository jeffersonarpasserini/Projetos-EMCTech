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
    public class Fatu_MotivoIcmsDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_MotivoIcmsDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                geraOcorrencia(objFatu_MotivoIcms, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_MotivoIcms (idfatu_motivoicms, descricao, situacao) values (@id, @descricao, @situacao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@id", objFatu_MotivoIcms.idFatu_MotivoIcms);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_MotivoIcms.descricao);
                Sqlcon.Parameters.AddWithValue("@situacao", objFatu_MotivoIcms.situacao);
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

        public void Atualizar(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_MotivoIcms, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_MotivoIcms set situacao=@situacao, descricao = @descricao where idFatu_MotivoIcms = @idFatu_MotivoIcms";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_MotivoIcms", objFatu_MotivoIcms.idFatu_MotivoIcms);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_MotivoIcms.descricao);
                Sqlcon.Parameters.AddWithValue("@situacao", objFatu_MotivoIcms.situacao);
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

        public void Excluir(Fatu_MotivoIcms objFatu_MotivoIcms)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_MotivoIcms, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_MotivoIcms where idFatu_MotivoIcms = @idFatu_MotivoIcms";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_MotivoIcms", objFatu_MotivoIcms.idFatu_MotivoIcms);

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

        public DataTable ListaFatu_MotivoIcms()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_motivoicms, concat(situacao, '-', descricao) as descricao from Fatu_MotivoIcms order by descricao";
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

        public Fatu_MotivoIcms ObterPor(Fatu_MotivoIcms oFatu_MotivoIcms)
        {
            MySqlDataReader drCon;
            try
            {

               
                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_MotivoIcms Where idFatu_MotivoIcms=@idFatu_MotivoIcms";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idFatu_MotivoIcms", oFatu_MotivoIcms.idFatu_MotivoIcms);
                drCon = Sqlcon.ExecuteReader();
               
                              
                while (drCon.Read())
                {
                    Fatu_MotivoIcms objFatu_MotivoIcms = new Fatu_MotivoIcms();
                    objFatu_MotivoIcms.idFatu_MotivoIcms = drCon["idFatu_MotivoIcms"].ToString();
                    objFatu_MotivoIcms.descricao = drCon["descricao"].ToString();
                    objFatu_MotivoIcms.situacao = drCon["situacao"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_MotivoIcms;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_MotivoIcms objFatu_MotivoIcms1 = new Fatu_MotivoIcms();
                return objFatu_MotivoIcms1;

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

        private void geraOcorrencia(Fatu_MotivoIcms oFatu_MotivoIcms, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_MotivoIcms.idFatu_MotivoIcms.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_MotivoIcms oCobr = new Fatu_MotivoIcms();
                    oCobr = ObterPor(oFatu_MotivoIcms);

                    if (!oCobr.Equals(oFatu_MotivoIcms))
                    {
                        descricao = "Sit. Fiscal Cofins id: " + oFatu_MotivoIcms.idFatu_MotivoIcms + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_MotivoIcms.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_MotivoIcms.descricao;
                        }
                        if (!oCobr.situacao.Equals(oFatu_MotivoIcms.situacao))
                        {
                            descricao += " Codigo Fiscal de " + oCobr.situacao + " para " + oFatu_MotivoIcms.situacao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Sit. Fiscal Cofins : " + oFatu_MotivoIcms.idFatu_MotivoIcms + " - " + oFatu_MotivoIcms.situacao + " - " + oFatu_MotivoIcms.descricao  + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Sit. Fiscal Cofins : " + oFatu_MotivoIcms.idFatu_MotivoIcms + " - " + oFatu_MotivoIcms.situacao + " - " + oFatu_MotivoIcms.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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
