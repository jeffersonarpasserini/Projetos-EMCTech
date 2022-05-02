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
    public class Fatu_NCMDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_NCMDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_NCM objFatu_NCM)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_NCM'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_NCM.idfatu_ncm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_NCM, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_NCM (descricao, situacao, nroncm, classificacaofiscal) values (@descricao, @situacao, @nroncm, @classificacaofiscal)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_NCM.descricao);
                Sqlcon.Parameters.AddWithValue("@situacao", objFatu_NCM.situacao);
                Sqlcon.Parameters.AddWithValue("@nroncm", objFatu_NCM.nroncm);
                Sqlcon.Parameters.AddWithValue("@classificacaofiscal", objFatu_NCM.classificacaofiscal);
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

        public void Atualizar(Fatu_NCM objFatu_NCM)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_NCM, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update fatu_ncm set descricao = @descricao, situacao = @situacao, nroncm = @nroncm, classificacaofiscal = @classificacaofiscal where idfatu_ncm = @idfatu_ncm";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idfatu_ncm", objFatu_NCM.idfatu_ncm);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_NCM.descricao);
                Sqlcon.Parameters.AddWithValue("@situacao", objFatu_NCM.situacao);
                Sqlcon.Parameters.AddWithValue("@nroncm", objFatu_NCM.nroncm);
                Sqlcon.Parameters.AddWithValue("@classificacaofiscal", objFatu_NCM.classificacaofiscal);
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

        public void Excluir(Fatu_NCM objFatu_NCM)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_NCM, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_NCM where idFatu_NCM = @idFatu_NCM";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_NCM", objFatu_NCM.idfatu_ncm);

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

        public DataTable ListaFatu_NCM()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from Fatu_NCM order by descricao";
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

        public Fatu_NCM ObterPor(Fatu_NCM oFatu_NCM)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando sql
                String strSQL = "select * from Fatu_NCM where ";
                //se não informado o Numero NCM, busca pela chave da tabela 
                if (string.IsNullOrEmpty(oFatu_NCM.nroncm))
                {
                    strSQL += "idFatu_NCM=@idFatu_NCM";
                }
                else
                {
                    strSQL += "nroncm=@nroncm";
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idfatu_ncm", oFatu_NCM.idfatu_ncm);
                Sqlcon.Parameters.AddWithValue("@nroncm", oFatu_NCM.nroncm);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Fatu_NCM objFatu_NCM = new Fatu_NCM();
                    objFatu_NCM.idfatu_ncm = Convert.ToInt32(drCon["idFatu_NCM"].ToString());
                    objFatu_NCM.descricao = drCon["descricao"].ToString();
                    objFatu_NCM.situacao = drCon["situacao"].ToString();
                    objFatu_NCM.nroncm = drCon["nroncm"].ToString();
                    objFatu_NCM.classificacaofiscal = drCon["classificacaofiscal"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objFatu_NCM;
                }

                drCon.Close();
                drCon.Dispose();
                Fatu_NCM objFatu_NCM1 = new Fatu_NCM();
                return objFatu_NCM1;

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

        private void geraOcorrencia(Fatu_NCM oFatu_NCM, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_NCM.idfatu_ncm.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_NCM oCobr = new Fatu_NCM();
                    oCobr = ObterPor(oFatu_NCM);

                    if (!oCobr.Equals(oFatu_NCM))
                    {
                        descricao = "Código NCM id: " + oFatu_NCM.idfatu_ncm + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_NCM.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_NCM.descricao;
                        }
                        if (!oCobr.situacao.Equals(oFatu_NCM.situacao))
                        {
                            descricao += " Situação " + oCobr.situacao + " para " + oFatu_NCM.situacao;
                        }
                        if (!oCobr.nroncm.Equals(oFatu_NCM.nroncm))
                        {
                            descricao += " NCM " + oCobr.nroncm + " para " + oFatu_NCM.nroncm;
                        }
                        if (!oCobr.classificacaofiscal.Equals(oFatu_NCM.classificacaofiscal))
                        {
                            descricao += " Classificação Fiscal " + oCobr.classificacaofiscal + " para " + oFatu_NCM.classificacaofiscal;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Código NCM : " + oFatu_NCM.idfatu_ncm + " - " + oFatu_NCM.descricao + " | NCM :" + oFatu_NCM.nroncm + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Código NCM : " + oFatu_NCM.idfatu_ncm + " - " + oFatu_NCM.descricao + " | NCM :" + oFatu_NCM.nroncm + " foi excluído por " + oOcorrencia.usuario.nome;
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
