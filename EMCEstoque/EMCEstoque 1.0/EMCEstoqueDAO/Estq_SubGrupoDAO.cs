using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCEstoqueModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCEstoqueDAO
{
    public class Estq_SubGrupoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_SubGrupoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = pOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = pOcorrencia;
            }
            codEmpresa = idEmpresa;
        }

        public void Salvar(Estq_SubGrupo objEstq_SubGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Estq_SubGrupo'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_SubGrupo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Estq_SubGrupo (estq_grupo_idEstq_grupo, descricao, menor_unidadecontrole, unidadepadrao, " + 
                                                          " unidadevenda, unidaderequisicao, unidadesolicitacao, unidaderecebimento, " + 
                                                          " unidadeindustria ) " +
                                                 " values (@estq_grupo_idEstq_grupo, @descricao, @menor_unidadecontrole, @unidadepadrao, " + 
                                                          " @unidadevenda, @unidaderequisicao, @unidadesolicitacao, @unidaderecebimento, " +
                                                          " @unidadeindustria )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@estq_grupo_idEstq_grupo", objEstq_SubGrupo.Estq_Grupo.idestq_grupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_SubGrupo.descricao);
                Sqlcon.Parameters.AddWithValue("@menor_unidadecontrole", objEstq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadepadrao", objEstq_SubGrupo.UnidadePadrao.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadevenda", objEstq_SubGrupo.UnidadeVenda.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidaderequisicao", objEstq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadesolicitacao", objEstq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidaderecebimento", objEstq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadeindustria", objEstq_SubGrupo.UnidadeIndustria.idestq_produto_unidade);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public void Atualizar(Estq_SubGrupo objEstq_SubGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_SubGrupo, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Estq_SubGrupo set estq_grupo_idEstq_grupo = @estq_grupo_idEstq_grupo, descricao = @descricao, " + 
                                                        " menor_unidadecontrole = @menor_unidadecontrole, unidadepadrao = @unidadepadrao, " + 
                                                        " unidadevenda=@unidadevenda, unidaderequisicao=@unidaderequisicao, " +
                                                        " unidadesolicitacao=@unidadesolicitacao, unidaderecebimento=@unidaderecebimento, " +
                                                        " unidadeindustria=@unidadeindustria " +
                                                        "  where idEstq_SubGrupo = @idEstq_SubGrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_SubGrupo", objEstq_SubGrupo.idestq_subgrupo);
                Sqlcon.Parameters.AddWithValue("@estq_grupo_idEstq_grupo", objEstq_SubGrupo.Estq_Grupo.idestq_grupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_SubGrupo.descricao);
                Sqlcon.Parameters.AddWithValue("@menor_unidadecontrole", objEstq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadepadrao", objEstq_SubGrupo.UnidadePadrao.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadevenda", objEstq_SubGrupo.UnidadeVenda.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidaderequisicao", objEstq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadesolicitacao", objEstq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidaderecebimento", objEstq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@unidadeindustria", objEstq_SubGrupo.UnidadeIndustria.idestq_produto_unidade);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public void Excluir(Estq_SubGrupo objEstq_SubGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_SubGrupo, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Estq_SubGrupo where idEstq_SubGrupo = @idEstq_SubGrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_SubGrupo", objEstq_SubGrupo.idestq_subgrupo);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
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

        public DataTable ListaEstq_SubGrupo()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select S.*, G.Descricao as Estq_Grupo_Descricao from Estq_SubGrupo S, Estq_Grupo G where G.idestq_grupo = S.estq_grupo_idestq_grupo order by S.descricao";
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

        public DataTable ListaEstq_SubGrupo(int pIDGrupoProduto)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select S.*, G.Descricao as Estq_Grupo_Descricao from Estq_SubGrupo S, Estq_Grupo G where G.idestq_grupo = S.estq_grupo_idestq_grupo and S.estq_grupo_idestq_grupo = @estq_grupo_idestq_grupo order by S.descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@estq_grupo_idestq_grupo", pIDGrupoProduto);

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

        public Estq_SubGrupo ObterPor(Estq_SubGrupo oEstq_SubGrupo)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Estq_SubGrupo Where idEstq_SubGrupo = @idEstq_SubGrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idEstq_SubGrupo", oEstq_SubGrupo.idestq_subgrupo);


                drCon = Sqlcon.ExecuteReader();
                Estq_SubGrupo objEstq_SubGrupo = new Estq_SubGrupo();

                while (drCon.Read())
                {

                    objEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(drCon["idestq_subgrupo"].ToString());
                    objEstq_SubGrupo.descricao = drCon["descricao"].ToString();

                    //Carregando grupo do estoque
                    Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                    oEstq_Grupo.idestq_grupo = Convert.ToInt32(drCon["estq_grupo_idEstq_grupo"].ToString());
                    //Carregando a Menor Unidade de Controle
                    Estq_Produto_Unidade oEstq_Produto_Unidade_Menor_UnidadeControle = new Estq_Produto_Unidade();
                    oEstq_Produto_Unidade_Menor_UnidadeControle.idestq_produto_unidade = Convert.ToInt32(drCon["menor_unidadecontrole"].ToString());
                    //Carregando a Unidade Padrão
                    Estq_Produto_Unidade oEstq_Produto_Unidade_UnidadePadrao = new Estq_Produto_Unidade();
                    oEstq_Produto_Unidade_UnidadePadrao.idestq_produto_unidade = Convert.ToInt32(drCon["unidadepadrao"].ToString());
                    //Carregando a Unidade venda
                    Estq_Produto_Unidade oUnidadeVenda = new Estq_Produto_Unidade();
                    oUnidadeVenda.idestq_produto_unidade = Convert.ToInt32(drCon["unidadevenda"].ToString());
                    //Carregando a Unidade requisicao
                    Estq_Produto_Unidade oUnidadeRequisicao = new Estq_Produto_Unidade();
                    oUnidadeRequisicao.idestq_produto_unidade = Convert.ToInt32(drCon["unidaderequisicao"].ToString());
                    //Carregando a Unidade solicitacao
                    Estq_Produto_Unidade oUnidadeSolicitacao = new Estq_Produto_Unidade();
                    oUnidadeSolicitacao.idestq_produto_unidade = Convert.ToInt32(drCon["unidadesolicitacao"].ToString());
                    //Carregando a Unidade recebimento
                    Estq_Produto_Unidade oUnidadeRecebimento = new Estq_Produto_Unidade();
                    oUnidadeRecebimento.idestq_produto_unidade = Convert.ToInt32(drCon["unidaderecebimento"].ToString());
                    //Carregando a Unidade industria
                    Estq_Produto_Unidade oUnidadeIndustria = new Estq_Produto_Unidade();
                    oUnidadeIndustria.idestq_produto_unidade = Convert.ToInt32(drCon["unidadeindustria"].ToString());


                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();

                    //lendo dados do grupo
                    Estq_GrupoDAO oGrupoDAO = new Estq_GrupoDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_SubGrupo.Estq_Grupo = oGrupoDAO.ObterPor(oEstq_Grupo);

                    //lendo os dados da Menor Unidade de Controle
                    Estq_Produto_UnidadeDAO oEstq_Produto_Unidade_Menor_UnidadeControleDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_SubGrupo.Unidade_MenorControle = oEstq_Produto_Unidade_Menor_UnidadeControleDAO.ObterPor(oEstq_Produto_Unidade_Menor_UnidadeControle);
                    
                    //lendo os dados da Unidade Padrão
                    Estq_Produto_UnidadeDAO oEstq_Produto_Unidade_UnidadePadraoDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_SubGrupo.UnidadePadrao = oEstq_Produto_Unidade_UnidadePadraoDAO.ObterPor(oEstq_Produto_Unidade_UnidadePadrao);

                    //lendo os dados da Unidade venda
                    Estq_Produto_UnidadeDAO oUnVendaDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_SubGrupo.UnidadeVenda = oUnVendaDAO.ObterPor(oUnidadeVenda);

                    //lendo os dados da Unidade requisicao
                    Estq_Produto_UnidadeDAO oUnRequisicaoDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_SubGrupo.UnidadeRequisicao = oUnRequisicaoDAO.ObterPor(oUnidadeRequisicao);

                    //lendo os dados da Unidade solicitacao
                    Estq_Produto_UnidadeDAO oUnSolicitacaoDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_SubGrupo.UnidadeSolicitacao = oUnSolicitacaoDAO.ObterPor(oUnidadeSolicitacao);

                    //lendo os dados da Unidade recebimento
                    Estq_Produto_UnidadeDAO oUnRecebimentoDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_SubGrupo.UnidadeRecebimento = oUnRecebimentoDAO.ObterPor(oUnidadeRecebimento);

                    //lendo os dados da Unidade industria
                    Estq_Produto_UnidadeDAO oUnIndustriaDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_SubGrupo.UnidadeIndustria = oUnIndustriaDAO.ObterPor(oUnidadeIndustria);
                    
                   
                    return objEstq_SubGrupo;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_SubGrupo objEstq_SubGrupo1 = new Estq_SubGrupo();
                return objEstq_SubGrupo1;

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

        private void geraOcorrencia(Estq_SubGrupo oEstq_SubGrupo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_SubGrupo.idestq_subgrupo.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_SubGrupo oCobr = new Estq_SubGrupo();
                    oCobr = ObterPor(oEstq_SubGrupo);

                    if (!oCobr.Equals(oEstq_SubGrupo))
                    {
                        descricao = "Subgrupo de Estoque id: " + oEstq_SubGrupo.idestq_subgrupo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oEstq_SubGrupo.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oEstq_SubGrupo.descricao;
                        }
                        if (!oCobr.Estq_Grupo.idestq_grupo.Equals(oEstq_SubGrupo.Estq_Grupo.idestq_grupo))
                        {
                            descricao += " Grupo de Estoque de " + oCobr.Estq_Grupo.idestq_grupo + "-" + oCobr.Estq_Grupo.descricao + " para " + oEstq_SubGrupo.Estq_Grupo.idestq_grupo + "-" + oEstq_SubGrupo.Estq_Grupo.descricao;
                        }
                        if (!oCobr.Unidade_MenorControle.idestq_produto_unidade.Equals(oEstq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade))
                        {
                            descricao += " Menor Unidade de Controle de " + oCobr.Unidade_MenorControle.idestq_produto_unidade + "-" + oCobr.Unidade_MenorControle.unidade_descricao + " para " + oEstq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade + "-" + oEstq_SubGrupo.Unidade_MenorControle.unidade_descricao;
                        }
                        if (!oCobr.UnidadePadrao.idestq_produto_unidade.Equals(oEstq_SubGrupo.UnidadePadrao.idestq_produto_unidade))
                        {
                            descricao += " Unidade Padrao de " + oCobr.UnidadePadrao.idestq_produto_unidade + "-" + oCobr.UnidadePadrao.unidade_descricao + " para " + oEstq_SubGrupo.UnidadePadrao.idestq_produto_unidade + "-" + oEstq_SubGrupo.UnidadePadrao.unidade_descricao;
                        }
                        if (!oCobr.UnidadeRequisicao.idestq_produto_unidade.Equals(oEstq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade))
                        {
                            descricao += " Unidade Requisicao de " + 
                                          oCobr.UnidadeRequisicao.idestq_produto_unidade + "-" + oCobr.UnidadeRequisicao.unidade_descricao + 
                                          " para " + 
                                          oEstq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade + "-" + oEstq_SubGrupo.UnidadeRequisicao.unidade_descricao;
                        }
                        if (!oCobr.UnidadeSolicitacao.idestq_produto_unidade.Equals(oEstq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade))
                        {
                            descricao += " Unidade Solicitacao de " +
                                          oCobr.UnidadeSolicitacao.idestq_produto_unidade + "-" + oCobr.UnidadeSolicitacao.unidade_descricao +
                                          " para " +
                                          oEstq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade + "-" + oEstq_SubGrupo.UnidadeSolicitacao.unidade_descricao;
                        }
                        if (!oCobr.UnidadeRecebimento.idestq_produto_unidade.Equals(oEstq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade))
                        {
                            descricao += " Unidade Recebimento de " +
                                          oCobr.UnidadeRecebimento.idestq_produto_unidade + "-" + oCobr.UnidadeRecebimento.unidade_descricao +
                                          " para " +
                                          oEstq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade + "-" + oEstq_SubGrupo.UnidadeRecebimento.unidade_descricao;
                        }
                        if (!oCobr.UnidadeIndustria.idestq_produto_unidade.Equals(oEstq_SubGrupo.UnidadeIndustria.idestq_produto_unidade))
                        {
                            descricao += " Unidade Requisicao de " +
                                          oCobr.UnidadeIndustria.idestq_produto_unidade + "-" + oCobr.UnidadeIndustria.unidade_descricao +
                                          " para " +
                                          oEstq_SubGrupo.UnidadeIndustria.idestq_produto_unidade + "-" + oEstq_SubGrupo.UnidadeIndustria.unidade_descricao;
                        }


                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Subgrupo de Estoque : " + oEstq_SubGrupo.idestq_subgrupo + " - " + oEstq_SubGrupo.descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Subgrupo de Estoque : " + oEstq_SubGrupo.idestq_subgrupo + " - " + oEstq_SubGrupo.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaSubGrupo(int empMaster, int idEstqSubGrupo, string descricao)
        {
            try
            {
                
                //Monta comando para a gravação do registro
                String strSQL = "select s.*, g.Descricao as Estq_Grupo_Descricao from estq_subgrupo s, estq_Grupo g " +
                                " where g.idestq_grupo = s.estq_grupo_idestq_grupo";

                if (idEstqSubGrupo > 0)
                {
                   
                    strSQL += " and s.idEstq_subgrupo = @idestqsubgrupo ";

                }

                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                   
                    strSQL += " and s.descricao like @descricao ";
                }

                strSQL += " order by s.descricao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idestqsubgrupo", idEstqSubGrupo);
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

        public DataTable dstRelatorio(String sSQL)
        {

            try
            {
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

    }
}
