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
    public class Fatu_SituacaoFiscalIPIDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_SituacaoFiscalIPIDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'fatu_situacaofiscalipi'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_SituacaoFiscalIPI, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into fatu_situacaofiscalipi (codigosituacaoipi, descricao, entradasaida) values (@codigosituacaoipi, @descricao, @entradasaida)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codigosituacaoipi", objFatu_SituacaoFiscalIPI.codigosituacaoipi);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_SituacaoFiscalIPI.descricao);
                Sqlcon.Parameters.AddWithValue("@entradasaida", objFatu_SituacaoFiscalIPI.entradasaida);
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

        public void Atualizar(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_SituacaoFiscalIPI, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_SituacaoFiscalIPI set codigosituacaoipi = @codigosituacaoipi, descricao = @descricao, entradasaida = @entradasaida where idFatu_SituacaoFiscalIPI = @idFatu_SituacaoFiscalIPI";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoFiscalIPI", objFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi);
                Sqlcon.Parameters.AddWithValue("@codigosituacaoipi", objFatu_SituacaoFiscalIPI.codigosituacaoipi);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_SituacaoFiscalIPI.descricao);
                Sqlcon.Parameters.AddWithValue("@entradasaida", objFatu_SituacaoFiscalIPI.entradasaida);
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

        public void Excluir(Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_SituacaoFiscalIPI, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_SituacaoFiscalIPI where idFatu_SituacaoFiscalIPI = @idFatu_SituacaoFiscalIPI";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoFiscalIPI", objFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi);

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

        public DataTable ListaFatu_SituacaoFiscalIPI(string Situacao)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_situacaofiscalipi, concat(codigosituacaoipi, ' - ', descricao) as descricao from Fatu_SituacaoFiscalIPI ";
                if (Situacao == "E")
                    strSQL += " where entradasaida = 'E' ";
                else if (Situacao == "S")
                    strSQL += " where entradasaida = 'S' ";
                else
                    strSQL += "";

                strSQL += " order by descricao";
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

        public Fatu_SituacaoFiscalIPI ObterPor(Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_SituacaoFiscalIPI Where idFatu_SituacaoFiscalIPI=@idFatu_SituacaoFiscalIPI";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idFatu_SituacaoFiscalIPI", oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPI();
                    objFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi = Convert.ToInt32(drCon["idfatu_situacaofiscalipi"].ToString());
                    objFatu_SituacaoFiscalIPI.codigosituacaoipi = drCon["codigosituacaoipi"].ToString();
                    objFatu_SituacaoFiscalIPI.descricao = drCon["descricao"].ToString();
                    objFatu_SituacaoFiscalIPI.entradasaida = drCon["entradasaida"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_SituacaoFiscalIPI;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_SituacaoFiscalIPI objFatu_SituacaoFiscalIPI1 = new Fatu_SituacaoFiscalIPI();
                return objFatu_SituacaoFiscalIPI1;

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

        private void geraOcorrencia(Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_SituacaoFiscalIPI oCobr = new Fatu_SituacaoFiscalIPI();
                    oCobr = ObterPor(oFatu_SituacaoFiscalIPI);

                    if (!oCobr.Equals(oFatu_SituacaoFiscalIPI))
                    {
                        descricao = "Situação Fiscal IPI id: " + oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.codigosituacaoipi.Equals(oFatu_SituacaoFiscalIPI.codigosituacaoipi))
                        {
                            descricao += " Código Situação IPI de " + oCobr.codigosituacaoipi + " para " + oFatu_SituacaoFiscalIPI.codigosituacaoipi;
                        }
                        if (!oCobr.descricao.Equals(oFatu_SituacaoFiscalIPI.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_SituacaoFiscalIPI.descricao;
                        }
                        if (!oCobr.entradasaida.Equals(oFatu_SituacaoFiscalIPI.entradasaida))
                        {
                            descricao += " Tipo Entrada|Saída de " + oCobr.entradasaida + " para " + oFatu_SituacaoFiscalIPI.entradasaida;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Situação Fiscal IPI : " + oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi + " - " + oFatu_SituacaoFiscalIPI.descricao + " | Código Situação IPI :" + oFatu_SituacaoFiscalIPI.codigosituacaoipi + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Situação Fiscal IPI : " + oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi + " - " + oFatu_SituacaoFiscalIPI.descricao + " | Código Situação IPI :" + oFatu_SituacaoFiscalIPI.codigosituacaoipi + " foi excluído por " + oOcorrencia.usuario.nome;
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
