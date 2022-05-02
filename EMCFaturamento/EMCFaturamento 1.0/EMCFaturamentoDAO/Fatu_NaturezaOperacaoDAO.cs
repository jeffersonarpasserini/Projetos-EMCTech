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
    public class Fatu_NaturezaOperacaoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Fatu_NaturezaOperacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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

        public void Salvar(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Fatu_NaturezaOperacao'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFatu_NaturezaOperacao.idFatu_NaturezaOperacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objFatu_NaturezaOperacao, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fatu_NaturezaOperacao (descricao, tipo, idcfop_estadual, idcfop_interestadual, idcfop_exterior ) " + 
                                                           "values (@descricao, @tipo, @idcfopestadual, @idcfopinterestadual, @idcfopexterior )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_NaturezaOperacao.descricao);
                Sqlcon.Parameters.AddWithValue("@tipo", objFatu_NaturezaOperacao.tipo);
                if (objFatu_NaturezaOperacao.idCfopEstadual.idfatu_cfop>0)
                    Sqlcon.Parameters.AddWithValue("@idcfopestadual", objFatu_NaturezaOperacao.idCfopEstadual.idfatu_cfop);
                else
                    Sqlcon.Parameters.AddWithValue("@idcfopestadual", null);
                if (objFatu_NaturezaOperacao.idCfopInterestadual.idfatu_cfop>0)
                    Sqlcon.Parameters.AddWithValue("@idcfopinterestadual", objFatu_NaturezaOperacao.idCfopInterestadual.idfatu_cfop);
                else
                    Sqlcon.Parameters.AddWithValue("@idcfopinterestadual", null);
                if (objFatu_NaturezaOperacao.idCfopExterior.idfatu_cfop>0)
                    Sqlcon.Parameters.AddWithValue("@idcfopexterior", objFatu_NaturezaOperacao.idCfopExterior.idfatu_cfop);
                else
                    Sqlcon.Parameters.AddWithValue("@idcfopexterior", null);
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

        public void Atualizar(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objFatu_NaturezaOperacao, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Fatu_NaturezaOperacao set descricao=@descricao, tipo=@tipo, idcfop_estadual=@idcfopestadual, " + 
                                                                " idcfop_interestadual=@idcfopinterestadual, idcfop_exterior=@idcfopexterior " +
                                                          " where idfatu_naturezaoperacao = @idfatu_naturezaoperacao ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objFatu_NaturezaOperacao.descricao);
                Sqlcon.Parameters.AddWithValue("@tipo", objFatu_NaturezaOperacao.tipo);
                if (objFatu_NaturezaOperacao.idCfopEstadual.idfatu_cfop > 0)
                    Sqlcon.Parameters.AddWithValue("@idcfopestadual", objFatu_NaturezaOperacao.idCfopEstadual.idfatu_cfop);
                else
                    Sqlcon.Parameters.AddWithValue("@idcfopestadual", null);
                if (objFatu_NaturezaOperacao.idCfopInterestadual.idfatu_cfop > 0)
                    Sqlcon.Parameters.AddWithValue("@idcfopinterestadual", objFatu_NaturezaOperacao.idCfopInterestadual.idfatu_cfop);
                else
                    Sqlcon.Parameters.AddWithValue("@idcfopinterestadual", null);
                if (objFatu_NaturezaOperacao.idCfopExterior.idfatu_cfop > 0)
                    Sqlcon.Parameters.AddWithValue("@idcfopexterior", objFatu_NaturezaOperacao.idCfopExterior.idfatu_cfop);
                else
                    Sqlcon.Parameters.AddWithValue("@idcfopexterior", null);
                Sqlcon.Parameters.AddWithValue("@idfatu_naturezaoperacao", objFatu_NaturezaOperacao.idFatu_NaturezaOperacao);
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

        public void Excluir(Fatu_NaturezaOperacao objFatu_NaturezaOperacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objFatu_NaturezaOperacao, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fatu_NaturezaOperacao where idFatu_NaturezaOperacao = @idFatu_NaturezaOperacao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFatu_NaturezaOperacao", objFatu_NaturezaOperacao.idFatu_NaturezaOperacao);

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

        public DataTable ListaFatu_NaturezaOperacao()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idfatu_naturezaoperacao, descricao from Fatu_NaturezaOperacao order by descricao";
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

        public Fatu_NaturezaOperacao ObterPor(Fatu_NaturezaOperacao oFatu_NaturezaOperacao)
        {
            MySqlDataReader drCon;
            Boolean bControle = false;
            Fatu_NaturezaOperacao objFatu_NaturezaOperacao = new Fatu_NaturezaOperacao();

            try
            {

                //Monta comando sql
                String strSQL = "select * from Fatu_NaturezaOperacao where ";
                //se não informado o Numero NCM, busca pela chave da tabela 
                strSQL += "idfatu_naturezaoperacao=@idfatu_naturezaoperacao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idfatu_naturezaoperacao", oFatu_NaturezaOperacao.idFatu_NaturezaOperacao);
                
                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    bControle = true;

                    
                    objFatu_NaturezaOperacao.idFatu_NaturezaOperacao = EmcResources.cInt(drCon["idfatu_naturezaoperacao"].ToString());
                    objFatu_NaturezaOperacao.descricao = drCon["descricao"].ToString();
                    objFatu_NaturezaOperacao.tipo = drCon["tipo"].ToString();

                    Fatu_CFOP oCfOPEstaudal = new Fatu_CFOP();
                    if (drCon["idcfop_estadual"] is DBNull)
                        oCfOPEstaudal.idfatu_cfop = 0;
                    else
                        oCfOPEstaudal.idfatu_cfop = EmcResources.cInt(drCon["idcfop_estadual"].ToString());
                    objFatu_NaturezaOperacao.idCfopEstadual = oCfOPEstaudal;

                    Fatu_CFOP oCfOPInterEstaudal = new Fatu_CFOP();
                    if (drCon["idcfop_interestadual"] is DBNull)
                        oCfOPInterEstaudal.idfatu_cfop = 0;
                    else
                        oCfOPInterEstaudal.idfatu_cfop = EmcResources.cInt(drCon["idcfop_interestadual"].ToString());
                    objFatu_NaturezaOperacao.idCfopInterestadual = oCfOPInterEstaudal;

                    Fatu_CFOP oCfOPExterior = new Fatu_CFOP();
                    if (drCon["idcfop_exterior"] is DBNull)
                        oCfOPExterior.idfatu_cfop = 0;
                    else
                        oCfOPExterior.idfatu_cfop = EmcResources.cInt(drCon["idcfop_exterior"].ToString());
                    objFatu_NaturezaOperacao.idCfopExterior = oCfOPExterior;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                if (bControle)
                {
                    Fatu_CFOPDAO oCfOPDao = new Fatu_CFOPDAO(parConexao, oOcorrencia, codEmpresa);
                    objFatu_NaturezaOperacao.idCfopEstadual = oCfOPDao.ObterPor(objFatu_NaturezaOperacao.idCfopEstadual);
                    objFatu_NaturezaOperacao.idCfopInterestadual = oCfOPDao.ObterPor(objFatu_NaturezaOperacao.idCfopInterestadual);
                    objFatu_NaturezaOperacao.idCfopExterior = oCfOPDao.ObterPor(objFatu_NaturezaOperacao.idCfopExterior);

                }

                return objFatu_NaturezaOperacao;

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

        private void geraOcorrencia(Fatu_NaturezaOperacao oFatu_NaturezaOperacao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFatu_NaturezaOperacao.idFatu_NaturezaOperacao.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Fatu_NaturezaOperacao oCobr = new Fatu_NaturezaOperacao();
                    oCobr = ObterPor(oFatu_NaturezaOperacao);

                    if (!oCobr.Equals(oFatu_NaturezaOperacao))
                    {
                        descricao = "Natureza Operacao id: " + oFatu_NaturezaOperacao.idFatu_NaturezaOperacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oFatu_NaturezaOperacao.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oFatu_NaturezaOperacao.descricao;
                        }
                        if (!oCobr.idCfopEstadual.idfatu_cfop.Equals(oFatu_NaturezaOperacao.idCfopEstadual.idfatu_cfop))
                        {
                            descricao += " Número CFOP Estadual " + oCobr.idCfopEstadual.nrocfop + " para " + oFatu_NaturezaOperacao.idCfopEstadual.nrocfop;
                        }
                        if (!oCobr.idCfopInterestadual.idfatu_cfop.Equals(oFatu_NaturezaOperacao.idCfopInterestadual.idfatu_cfop))
                        {
                            descricao += " Número CFOP interEstadual " + oCobr.idCfopInterestadual.nrocfop + " para " + oFatu_NaturezaOperacao.idCfopInterestadual.nrocfop;
                        }
                        if (!oCobr.idCfopExterior.idfatu_cfop.Equals(oFatu_NaturezaOperacao.idCfopExterior.idfatu_cfop))
                        {
                            descricao += " Número CFOP Exterior " + oCobr.idCfopExterior.nrocfop + " para " + oFatu_NaturezaOperacao.idCfopExterior.nrocfop;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Código CFOP : " + oFatu_NaturezaOperacao.idFatu_NaturezaOperacao +" - " + oFatu_NaturezaOperacao.descricao + 
                           " | CFOP Estaudal :" + oFatu_NaturezaOperacao.idCfopEstadual.nrocfop +
                           " | CFOP InterEstadual : "+ oFatu_NaturezaOperacao.idCfopInterestadual.nrocfop +
                           " | CFOP Exterior " + oFatu_NaturezaOperacao.idCfopExterior.nrocfop + 
                           " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Código CFOP : " + oFatu_NaturezaOperacao.idFatu_NaturezaOperacao + " - " + oFatu_NaturezaOperacao.descricao +
                               " | CFOP Estaudal :" + oFatu_NaturezaOperacao.idCfopEstadual.nrocfop +
                                " | CFOP InterEstadual : " + oFatu_NaturezaOperacao.idCfopInterestadual.nrocfop +
                                " | CFOP Exterior " + oFatu_NaturezaOperacao.idCfopExterior.nrocfop + 
                                " foi excluído por " + oOcorrencia.usuario.nome;
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
