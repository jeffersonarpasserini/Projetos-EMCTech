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
    public class Fatu_CFOPDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_CFOPDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_CFOP objFatu_CFOP)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_CFOP'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_CFOP.idfatu_cfop = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_CFOP, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_CFOP (nrocfop, descricao, observacao) values (@nrocfop, @descricao, @observacao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@nrocfop", objFatu_CFOP.nrocfop);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_CFOP.descricao);
                Sqlcon.Parameters.AddWithValue("@observacao", objFatu_CFOP.observacao);
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

        public void Atualizar(Fatu_CFOP objFatu_CFOP)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_CFOP, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_CFOP set nrocfop = @nrocfop, descricao = @descricao, observacao=@observacao where idfatu_cfop = @idfatu_cfop";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_cfop", objFatu_CFOP.idfatu_cfop);
                Sqlcon.Parameters.AddWithValue("@nrocfop", objFatu_CFOP.nrocfop);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_CFOP.descricao);
                Sqlcon.Parameters.AddWithValue("@observacao", objFatu_CFOP.observacao);
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

        public void Excluir(Fatu_CFOP objFatu_CFOP)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_CFOP, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_CFOP where idFatu_CFOP = @idFatu_CFOP";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_CFOP", objFatu_CFOP.idfatu_cfop);

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

        public DataTable ListaFatu_CFOP()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_CFOP order by descricao";
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

        public Fatu_CFOP ObterPor(Fatu_CFOP oFatu_CFOP)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando sql
                String strSQL = "select * from Fatu_CFOP where ";
                //se não informado o Numero NCM, busca pela chave da tabela 
                if (string.IsNullOrEmpty(oFatu_CFOP.nrocfop))
                {
                    strSQL += "idfatu_cfop=@idfatu_cfop";
                }
                else
                {
                    strSQL += "nrocfop=@nrocfop";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idfatu_cfop", oFatu_CFOP.idfatu_cfop);
                Sqlcon.Parameters.AddWithValue("@nrocfop", oFatu_CFOP.nrocfop);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Fatu_CFOP objFatu_CFOP = new Fatu_CFOP();
                    objFatu_CFOP.idfatu_cfop = Convert.ToInt32(drCon["idfatu_cfop"].ToString());
                    objFatu_CFOP.nrocfop = drCon["nrocfop"].ToString();
                    objFatu_CFOP.descricao = drCon["descricao"].ToString();
                    objFatu_CFOP.observacao = drCon["observacao"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_CFOP;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_CFOP objFatu_CFOP1 = new Fatu_CFOP();
                return objFatu_CFOP1;

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

        private void geraOcorrencia(Fatu_CFOP oFatu_CFOP, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_CFOP.idfatu_cfop.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_CFOP oCobr = new Fatu_CFOP();
                    oCobr = ObterPor(oFatu_CFOP);

                    if (!oCobr.Equals(oFatu_CFOP))
                    {
                        descricao = "CFOP id: " + oFatu_CFOP.idfatu_cfop + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_CFOP.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_CFOP.descricao;
                        }
                        if (!oCobr.nrocfop.Equals(oFatu_CFOP.nrocfop))
                        {
                            descricao += " Número CFOP " + oCobr.nrocfop + " para " + oFatu_CFOP.nrocfop;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Código CFOP : " + oFatu_CFOP.idfatu_cfop + " - " + oFatu_CFOP.descricao + " | CFOP :" + oFatu_CFOP.nrocfop + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Código CFOP : " + oFatu_CFOP.idfatu_cfop + " - " + oFatu_CFOP.descricao + " | CFOP :" + oFatu_CFOP.nrocfop + " foi excluído por " + oOcorrencia.usuario.nome;
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
