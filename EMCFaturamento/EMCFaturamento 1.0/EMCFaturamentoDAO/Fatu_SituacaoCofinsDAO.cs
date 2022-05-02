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
    public class Fatu_SituacaoCofinsDAO
    {

         MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_SituacaoCofinsDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'fatu_situacaocofins'"+
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_SituacaoCofins.idFatu_SituacaoCofins = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_SituacaoCofins, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_SituacaoCofins (descricao, codigofiscal) values (@descricao, @codigofiscal)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_SituacaoCofins.descricao);
                Sqlcon.Parameters.AddWithValue("@codigofiscal", objFatu_SituacaoCofins.codigoFiscal);
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

        public void Atualizar(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_SituacaoCofins, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_SituacaoCofins set codigofiscal=@codigofiscal, descricao = @descricao where idFatu_SituacaoCofins = @idFatu_SituacaoCofins";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoCofins", objFatu_SituacaoCofins.idFatu_SituacaoCofins);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_SituacaoCofins.descricao);
                Sqlcon.Parameters.AddWithValue("@codigofiscal", objFatu_SituacaoCofins.codigoFiscal);
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

        public void Excluir(Fatu_SituacaoCofins objFatu_SituacaoCofins)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_SituacaoCofins, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_SituacaoCofins where idFatu_SituacaoCofins = @idFatu_SituacaoCofins";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoCofins", objFatu_SituacaoCofins.idFatu_SituacaoCofins);

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

        public DataTable ListaFatu_SituacaoCofins()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_situacaocofins, concat(codigofiscal, '-', descricao) as descricao from Fatu_SituacaoCofins order by descricao";
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

        public Fatu_SituacaoCofins ObterPor(Fatu_SituacaoCofins oFatu_SituacaoCofins)
        {
            MySqlDataReader drCon;
            try
            {

                if (oFatu_SituacaoCofins.idFatu_SituacaoCofins > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_SituacaoCofins Where idFatu_SituacaoCofins=@idFatu_SituacaoCofins";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoCofins", oFatu_SituacaoCofins.idFatu_SituacaoCofins);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Fatu_SituacaoCofins Where codigofiscal=@codigofiscal";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigofiscal", oFatu_SituacaoCofins.codigoFiscal);
                    drCon = Sqlcon.ExecuteReader();
                }

                


                while (drCon.Read())
                {
                    Fatu_SituacaoCofins objFatu_SituacaoCofins = new Fatu_SituacaoCofins();
                    objFatu_SituacaoCofins.idFatu_SituacaoCofins = Convert.ToInt32(drCon["idFatu_SituacaoCofins"].ToString());
                    objFatu_SituacaoCofins.descricao = drCon["descricao"].ToString();
                    objFatu_SituacaoCofins.codigoFiscal = drCon["codigofiscal"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_SituacaoCofins;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_SituacaoCofins objFatu_SituacaoCofins1 = new Fatu_SituacaoCofins();
                return objFatu_SituacaoCofins1;

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

        private void geraOcorrencia(Fatu_SituacaoCofins oFatu_SituacaoCofins, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_SituacaoCofins.idFatu_SituacaoCofins.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_SituacaoCofins oCobr = new Fatu_SituacaoCofins();
                    oCobr = ObterPor(oFatu_SituacaoCofins);

                    if (!oCobr.Equals(oFatu_SituacaoCofins))
                    {
                        descricao = "Sit. Fiscal Cofins id: " + oFatu_SituacaoCofins.idFatu_SituacaoCofins + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_SituacaoCofins.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_SituacaoCofins.descricao;
                        }
                        if (!oCobr.codigoFiscal.Equals(oFatu_SituacaoCofins.codigoFiscal))
                        {
                            descricao += " Codigo Fiscal de " + oCobr.codigoFiscal + " para " + oFatu_SituacaoCofins.codigoFiscal;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Sit. Fiscal Cofins : " + oFatu_SituacaoCofins.idFatu_SituacaoCofins + " - " + oFatu_SituacaoCofins.codigoFiscal + " - " + oFatu_SituacaoCofins.descricao  + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Sit. Fiscal Cofins : " + oFatu_SituacaoCofins.idFatu_SituacaoCofins + " - " + oFatu_SituacaoCofins.codigoFiscal + " - " + oFatu_SituacaoCofins.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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
