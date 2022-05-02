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
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCFaturamentoModel;
using EMCFaturamentoDAO;


namespace EMCEstoqueDAO
{
    public class Estq_ProdutoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_ProdutoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Produto objEstq_Produto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Estq_Produto'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Produto.idestq_produto = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Produto, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Estq_Produto (codigoproduto, descricao, descricaodetalhada, situacao, codigoean, " + 
                                           " qtde_estoqueminimo, qtde_estoquemaxima, estq_subgrupo_idestq_subgrupo, " +
                                           " estq_subgrupo_estq_grupo_idEstq_grupo, estq_familia_idestq_familia, " +
                                           " estq_tipoproduto_idestq_tipoproduto, custo_componente_idcusto_componente, " +
                                           " custo_componente_idgrupo_componente, fatu_ncm_idfatu_ncm, fatu_origemmercadoria_idfatu_origemmercadoria, " +
                                           " fatu_tributacao_idfatu_tributacao, idfatu_tributacaoipi, " + 
                                           " estq_produto_unidade_idestq_produto_unidade, fabricante_codempresa, fabricante_idpessoa ) " + 
                               " values (@codigoproduto, @descricao, @descricaodetalhada, @situacao, @codigoean, " +  
                                       " @qtde_estoqueminimo, @qtde_estoquemaximo, @estq_subgrupo_idestq_subgrupo, " +
                                       " @estq_subgrupo_estq_grupo_idEstq_grupo, @familia, @tipoproduto,@componente, " +
                                       " @grupocomponente, @ncm, @origemmercadoria, @tributacao, @tributacaoipi, " + 
                                       " @unidade, @fabr_empresa, @fabr_pessoa )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codigoproduto", objEstq_Produto.codigoProduto);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Produto.descricao);
                Sqlcon.Parameters.AddWithValue("@descricaodetalhada", objEstq_Produto.descricaodetalhada);
                Sqlcon.Parameters.AddWithValue("@situacao", objEstq_Produto.situacao);
                Sqlcon.Parameters.AddWithValue("@codigoean", objEstq_Produto.codigoean);
                Sqlcon.Parameters.AddWithValue("@qtde_estoqueminimo", objEstq_Produto.qtde_estoqueminimo);
                Sqlcon.Parameters.AddWithValue("@qtde_estoquemaximo", objEstq_Produto.qtde_estoquemaxima);
                Sqlcon.Parameters.AddWithValue("@estq_subgrupo_idestq_subgrupo", objEstq_Produto.Estq_SubGrupo.idestq_subgrupo);
                Sqlcon.Parameters.AddWithValue("@estq_subgrupo_estq_grupo_idEstq_grupo", objEstq_Produto.Estq_Grupo.idestq_grupo);
                Sqlcon.Parameters.AddWithValue("@familia", objEstq_Produto.Estq_Familia.idestq_familia);
                Sqlcon.Parameters.AddWithValue("@tipoproduto", objEstq_Produto.Estq_TipoProduto.idestq_tipoproduto);
                Sqlcon.Parameters.AddWithValue("@componente", objEstq_Produto.componenteCusto.idcusto_componente);
                Sqlcon.Parameters.AddWithValue("@grupocomponente", objEstq_Produto.componenteCusto.Custo_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@ncm", objEstq_Produto.ncm.idfatu_ncm);
                Sqlcon.Parameters.AddWithValue("@origemmercadoria", objEstq_Produto.origemMercadoria.idfatu_origemmercadoria);
                Sqlcon.Parameters.AddWithValue("@tributacao", objEstq_Produto.tributacao.idfatu_tributacao);
                Sqlcon.Parameters.AddWithValue("@unidade", objEstq_Produto.Estq_Produto_Unidade.idestq_produto_unidade);
                Sqlcon.Parameters.AddWithValue("@fabr_empresa", objEstq_Produto.fabricante.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fabr_pessoa", objEstq_Produto.fabricante.idPessoa);
                Sqlcon.Parameters.AddWithValue("@tributacaoipi", objEstq_Produto.tributacaoIPI.idFatu_TributacaoIPI);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                //verifica o parametro considera data valida para vencimento de parcelas.
                /* if (oParametroDAO.retParametro(codEmpresa, "EMCESTOQUE", "PRODUTO", "UTILIZA_LOTE") == "N")
                {
                    // Criar lote padrão e gravar

                    Estq_Produto_Lote oLote = new Estq_Produto_Lote();
                    oLote.Estq_Produto = objEstq_Produto;
                    oLote.datavalidade = DateTime.Now;
                    oLote.loteproduto = "PADRAO";
                    oLote.descricao = "LOTE PADRAO";
                    Estq_Embalagem oEmbalagem = new Estq_Embalagem();
                    oLote.embalagem = oEmbalagem;

                    Estq_Produto_LoteDAO oLoteDAO = new Estq_Produto_LoteDAO(parConexao, oOcorrencia, codEmpresa);
                    oLoteDAO.Salvar(oLote,Conexao,transacao);
                }*/

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

        public void Atualizar(Estq_Produto objEstq_Produto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Produto, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Estq_Produto set descricao = @descricao, descricaodetalhada = @descricaodetalhada"; 
                strSQL += ", situacao = @situacao, codigoean = @codigoean";
                strSQL += ", qtde_estoqueminimo = @qtde_estoqueminimo, qtde_estoquemaxima = @qtde_estoquemaxima";
                strSQL += ", estq_subgrupo_idestq_subgrupo = @estq_subgrupo_idestq_subgrupo, estq_subgrupo_estq_grupo_idEstq_grupo = @estq_subgrupo_estq_grupo_idEstq_grupo";
                strSQL += ", estq_familia_idestq_familia=@familia, estq_tipoproduto_idestq_tipoproduto=@tipoproduto ";
                strSQL += ", custo_componente_idcusto_componente=@componente, custo_componente_idgrupo_componente=@grupocomponente ";
                strSQL += ", fatu_ncm_idfatu_ncm=@ncm, fatu_origemmercadoria_idfatu_origemmercadoria=@origemmercadoria ";
                strSQL += ", fatu_tributacao_idfatu_tributacao=@tributacao ";
                strSQL += ", idfatu_tributacaoipi=@tributacaoipi, fabricante_codempresa=@fabr_empresa, fabricante_idpessoa=@fabr_pessoa ";
                strSQL += " where idEstq_Produto = @idEstq_Produto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto", objEstq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Produto.descricao);
                Sqlcon.Parameters.AddWithValue("@descricaodetalhada", objEstq_Produto.descricaodetalhada);
                Sqlcon.Parameters.AddWithValue("@situacao", objEstq_Produto.situacao);
                Sqlcon.Parameters.AddWithValue("@codigoean", objEstq_Produto.codigoean);
                Sqlcon.Parameters.AddWithValue("@qtde_estoqueminimo", objEstq_Produto.qtde_estoqueminimo);
                Sqlcon.Parameters.AddWithValue("@qtde_estoquemaxima", objEstq_Produto.qtde_estoquemaxima);
                Sqlcon.Parameters.AddWithValue("@estq_subgrupo_idestq_subgrupo", objEstq_Produto.Estq_SubGrupo.idestq_subgrupo);
                Sqlcon.Parameters.AddWithValue("@estq_subgrupo_estq_grupo_idEstq_grupo", objEstq_Produto.Estq_Grupo.idestq_grupo);
                Sqlcon.Parameters.AddWithValue("@familia", objEstq_Produto.Estq_Familia.idestq_familia);
                Sqlcon.Parameters.AddWithValue("@tipoproduto", objEstq_Produto.Estq_TipoProduto.idestq_tipoproduto);
                Sqlcon.Parameters.AddWithValue("@componente", objEstq_Produto.componenteCusto.idcusto_componente);
                Sqlcon.Parameters.AddWithValue("@grupocomponente", objEstq_Produto.componenteCusto.Custo_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@ncm", objEstq_Produto.ncm.idfatu_ncm);
                Sqlcon.Parameters.AddWithValue("@origemmercadoria", objEstq_Produto.origemMercadoria.idfatu_origemmercadoria);
                Sqlcon.Parameters.AddWithValue("@tributacao", objEstq_Produto.tributacao.idfatu_tributacao);
                Sqlcon.Parameters.AddWithValue("@fabr_empresa", objEstq_Produto.fabricante.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fabr_pessoa", objEstq_Produto.fabricante.idPessoa);
                Sqlcon.Parameters.AddWithValue("@tributacaoipi", objEstq_Produto.tributacaoIPI.idFatu_TributacaoIPI);



                
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

        public void Excluir(Estq_Produto objEstq_Produto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Produto, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Estq_Produto where idEstq_Produto = @idEstq_Produto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto", objEstq_Produto.idestq_produto);

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

        public DataTable ListaEstq_Produto()
        {

            try
            {
                //Monta comando para a leitura do registro
                String strSQL = "select P.* from Estq_Produto P order by P.descricao";
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

        public Estq_Produto ObterPor(Estq_Produto oEstq_Produto)
        {
            MySqlDataReader drCon;
            try
            {
                String strSQL="";
                if (oEstq_Produto.idestq_produto > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Estq_Produto Where idEstq_Produto = @idEstq_Produto";
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Estq_Produto Where codigoProduto = @codigoproduto";
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto", oEstq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@codigoproduto", oEstq_Produto.codigoProduto);


                drCon = Sqlcon.ExecuteReader();
                Estq_Produto objEstq_Produto = new Estq_Produto();

                while (drCon.Read())
                {
                    objEstq_Produto.idestq_produto = Convert.ToInt32(drCon["idestq_produto"].ToString());
                    objEstq_Produto.descricao = drCon["descricao"].ToString();
                    objEstq_Produto.descricaodetalhada = drCon["descricaodetalhada"].ToString();
                    objEstq_Produto.situacao = drCon["situacao"].ToString();
                    objEstq_Produto.codigoean = drCon["codigoean"].ToString();
                    objEstq_Produto.qtde_estoqueminimo = EmcResources.nDec(drCon["qtde_estoqueminimo"].ToString());
                    objEstq_Produto.qtde_estoquemaxima = EmcResources.nDec(drCon["qtde_estoquemaxima"].ToString());
                    //Grupo
                    Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                    oEstq_Grupo.idestq_grupo = Convert.ToInt32(drCon["estq_subgrupo_estq_grupo_idEstq_grupo"].ToString());
                    //Subgrupo
                    Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                    oEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(drCon["estq_subgrupo_idestq_subgrupo"].ToString());
                    
                    //Unidade
                    Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                    oEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(drCon["estq_produto_unidade_idestq_produto_unidade"].ToString());
                    //Familia
                    Estq_Familia oEstq_Familia = new Estq_Familia();
                    oEstq_Familia.idestq_familia = Convert.ToInt32(drCon["estq_familia_idestq_familia"].ToString());
                    //Fabricante
                    Fornecedor oFabricante = new Fornecedor();
                    if (drCon["fabricante_idpessoa"] is DBNull)
                    {
                        oFabricante.idPessoa = 0;
                        oFabricante.codEmpresa = 0;
                    }
                    else
                    {
                        oFabricante.idPessoa = EmcResources.cInt(drCon["fabricante_idpessoa"].ToString());
                        oFabricante.codEmpresa = EmcResources.cInt(drCon["fabricante_codempresa"].ToString());
                    }
                    //Tipo Produto
                    Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
                    oEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(drCon["estq_tipoproduto_idestq_tipoproduto"].ToString());
                    //Componente Custo
                    Custo_ComponenteGrupo oGrupoCusto = new Custo_ComponenteGrupo();
                    oGrupoCusto.idcusto_componentegrupo = EmcResources.cInt(drCon["custo_componente_idgrupo_componente"].ToString());
                    Custo_Componente oCustoComponente = new Custo_Componente();
                    oCustoComponente.idcusto_componente = EmcResources.cInt(drCon["custo_componente_idcusto_componente"].ToString());
                    oCustoComponente.Custo_ComponenteGrupo = oGrupoCusto;
                    // NCM 
                    Fatu_NCM oNcm = new Fatu_NCM();
                    oNcm.idfatu_ncm = EmcResources.cInt(drCon["fatu_ncm_idfatu_ncm"].ToString());
                    //tributacao
                    Fatu_Tributacao oTributacao = new Fatu_Tributacao();
                    oTributacao.idfatu_tributacao = EmcResources.cInt(drCon["fatu_tributacao_idfatu_tributacao"].ToString());
                    //Origem Mercadoria
                    Fatu_OrigemMercadoria oOrigemMercadoria = new Fatu_OrigemMercadoria();
                    oOrigemMercadoria.idfatu_origemmercadoria = EmcResources.cInt(drCon["fatu_origemmercadoria_idfatu_origemmercadoria"].ToString());
                    //Tributacao IPI
                    Fatu_TributacaoIPI oIPI = new Fatu_TributacaoIPI();
                    oIPI.idFatu_TributacaoIPI = EmcResources.cInt(drCon["idfatu_tributacaoipi"].ToString());

                    drCon.Close();
                    drCon.Dispose();

                    //Lendo o Grupo e Subgrupo
                    Estq_GrupoDAO oEstq_GrupoDAO = new Estq_GrupoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto.Estq_Grupo = oEstq_GrupoDAO.ObterPor(oEstq_Grupo);
                    //
                    drCon.Close();
                    drCon.Dispose();
                    //
                    Estq_SubGrupoDAO oEstq_SubGrupoDAO = new Estq_SubGrupoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto.Estq_SubGrupo = oEstq_SubGrupoDAO.ObterPor(oEstq_SubGrupo);
                    //
                    Estq_Produto_UnidadeDAO oEstq_Produto_UnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto.Estq_Produto_Unidade = oEstq_Produto_UnidadeDAO.ObterPor(oEstq_Produto_Unidade);
                    //
                    Estq_FamiliaDAO oEstq_FamiliaDAO = new Estq_FamiliaDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto.Estq_Familia = oEstq_FamiliaDAO.ObterPor(oEstq_Familia);
                    //
                    FornecedorDAO oFabricanteDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.fabricante = oFabricanteDAO.ObterPor(oFabricante);
                    //
                    Estq_TipoProdutoDAO oEstq_TipoProdutoDAO = new Estq_TipoProdutoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Produto.Estq_TipoProduto = oEstq_TipoProdutoDAO.ObterPor(oEstq_TipoProduto);
                    //
                    Custo_ComponenteDAO oCustoDAO = new Custo_ComponenteDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.componenteCusto = oCustoDAO.ObterPor(oCustoComponente);
                    //
                    Fatu_NCMDAO oNcmDAO = new Fatu_NCMDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.ncm = oNcmDAO.ObterPor(oNcm);
                    //
                    Fatu_OrigemMercadoriaDAO oOrigemDAO = new Fatu_OrigemMercadoriaDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.origemMercadoria = oOrigemDAO.ObterPor(oOrigemMercadoria);
                    //
                    Fatu_TributacaoDAO oTributacaoDAO = new Fatu_TributacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.tributacao = oTributacaoDAO.ObterPor(oTributacao);
                    //
                    //
                    Estq_Produto_LoteDAO oEstq_Produto_LoteDAO = new Estq_Produto_LoteDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.lstProdutoLote = oEstq_Produto_LoteDAO.lstEstq_ProdutoLote(objEstq_Produto);
                    //
                    Fatu_TributacaoIPIDAO oIpiDAO = new Fatu_TributacaoIPIDAO(parConexao, oOcorrencia, codEmpresa);
                    oIPI = oIpiDAO.ObterPor(oIPI);
                    objEstq_Produto.tributacaoIPI = oIPI;

                    return objEstq_Produto;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Produto objEstq_Produto1 = new Estq_Produto();
                return objEstq_Produto1;

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

        public Estq_Produto ObterProduto(Estq_Produto oEstq_Produto)
        {
            MySqlDataReader drCon;
            try
            {
                String strSQL = "";
                if (oEstq_Produto.idestq_produto > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Estq_Produto Where idEstq_Produto = @idEstq_Produto";
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from Estq_Produto Where codigoProduto = @codigoproduto";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto", oEstq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@codigoproduto", oEstq_Produto.codigoProduto);


                drCon = Sqlcon.ExecuteReader();
                Estq_Produto objEstq_Produto = new Estq_Produto();

                while (drCon.Read())
                {
                    objEstq_Produto.idestq_produto = Convert.ToInt32(drCon["idestq_produto"].ToString());
                    objEstq_Produto.descricao = drCon["descricao"].ToString();
                    objEstq_Produto.descricaodetalhada = drCon["descricaodetalhada"].ToString();
                    objEstq_Produto.situacao = drCon["situacao"].ToString();
                    objEstq_Produto.codigoean = drCon["codigoean"].ToString();
                    objEstq_Produto.qtde_estoqueminimo = EmcResources.nDec(drCon["qtde_estoqueminimo"].ToString());
                    objEstq_Produto.qtde_estoquemaxima = EmcResources.nDec(drCon["qtde_estoquemaxima"].ToString());
                    //Grupo
                    Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                    oEstq_Grupo.idestq_grupo = Convert.ToInt32(drCon["estq_subgrupo_estq_grupo_idEstq_grupo"].ToString());
                    //Subgrupo
                    Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                    oEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(drCon["estq_subgrupo_idestq_subgrupo"].ToString());
                    
                    //Unidade
                    Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                    oEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(drCon["estq_produto_unidade_idestq_produto_unidade"].ToString());
                    //Familia
                    Estq_Familia oEstq_Familia = new Estq_Familia();
                    oEstq_Familia.idestq_familia = Convert.ToInt32(drCon["estq_familia_idestq_familia"].ToString());
                    //Fabricante
                    Fornecedor oFabricante = new Fornecedor();
                    if (drCon["fabricante_idpessoa"] is DBNull)
                    {
                        oFabricante.idPessoa = 0;
                        oFabricante.codEmpresa = 0;
                    }
                    else
                    {
                        oFabricante.idPessoa = EmcResources.cInt(drCon["fabricante_idpessoa"].ToString());
                        oFabricante.codEmpresa = EmcResources.cInt(drCon["fabricante_codempresa"].ToString());
                    }
                    //Tipo Produto
                    Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
                    oEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(drCon["estq_tipoproduto_idestq_tipoproduto"].ToString());
                    //Componente Custo
                    Custo_ComponenteGrupo oGrupoCusto = new Custo_ComponenteGrupo();
                    oGrupoCusto.idcusto_componentegrupo = EmcResources.cInt(drCon["custo_componente_idgrupo_componente"].ToString());
                    Custo_Componente oCustoComponente = new Custo_Componente();
                    oCustoComponente.idcusto_componente = EmcResources.cInt(drCon["custo_componente_idcusto_componente"].ToString());
                    oCustoComponente.Custo_ComponenteGrupo = oGrupoCusto;
                    // NCM 
                    Fatu_NCM oNcm = new Fatu_NCM();
                    oNcm.idfatu_ncm = EmcResources.cInt(drCon["fatu_ncm_idfatu_ncm"].ToString());
                    //tributacao
                    Fatu_Tributacao oTributacao = new Fatu_Tributacao();
                    oTributacao.idfatu_tributacao = EmcResources.cInt(drCon["fatu_tributacao_idfatu_tributacao"].ToString());
                    //Origem Mercadoria
                    Fatu_OrigemMercadoria oOrigemMercadoria = new Fatu_OrigemMercadoria();
                    oOrigemMercadoria.idfatu_origemmercadoria = EmcResources.cInt(drCon["fatu_origemmercadoria_idfatu_origemmercadoria"].ToString());

                    //Tributacao IPI
                    Fatu_TributacaoIPI oIPI = new Fatu_TributacaoIPI();
                    oIPI.idFatu_TributacaoIPI = EmcResources.cInt(drCon["idfatu_tributacaoipi"].ToString());


                    drCon.Close();
                    drCon.Dispose();

                    //Lendo o Grupo e Subgrupo
                    Estq_GrupoDAO oEstq_GrupoDAO = new Estq_GrupoDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.Estq_Grupo = oEstq_GrupoDAO.ObterPor(oEstq_Grupo);
                    //
                    drCon.Close();
                    drCon.Dispose();
                    //
                    Estq_SubGrupoDAO oEstq_SubGrupoDAO = new Estq_SubGrupoDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.Estq_SubGrupo = oEstq_SubGrupoDAO.ObterPor(oEstq_SubGrupo);
                    //
                    Estq_Produto_UnidadeDAO oEstq_Produto_UnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.Estq_Produto_Unidade = oEstq_Produto_UnidadeDAO.ObterPor(oEstq_Produto_Unidade);
                    //
                    Estq_FamiliaDAO oEstq_FamiliaDAO = new Estq_FamiliaDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.Estq_Familia = oEstq_FamiliaDAO.ObterPor(oEstq_Familia);
                    //
                    FornecedorDAO oFabricanteDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.fabricante = oFabricanteDAO.ObterPor(oFabricante);
                    //
                    Estq_TipoProdutoDAO oEstq_TipoProdutoDAO = new Estq_TipoProdutoDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.Estq_TipoProduto = oEstq_TipoProdutoDAO.ObterPor(oEstq_TipoProduto);
                    //
                    Custo_ComponenteDAO oCustoDAO = new Custo_ComponenteDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.componenteCusto = oCustoDAO.ObterPor(oCustoComponente);
                    //
                    Fatu_NCMDAO oNcmDAO = new Fatu_NCMDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.ncm = oNcmDAO.ObterPor(oNcm);
                    //
                    Fatu_OrigemMercadoriaDAO oOrigemDAO = new Fatu_OrigemMercadoriaDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.origemMercadoria = oOrigemDAO.ObterPor(oOrigemMercadoria);
                    //
                    Fatu_TributacaoDAO oTributacaoDAO = new Fatu_TributacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    objEstq_Produto.tributacao = oTributacaoDAO.ObterPor(oTributacao);
                    //
                    Fatu_TributacaoIPIDAO oIpiDAO = new Fatu_TributacaoIPIDAO(parConexao, oOcorrencia, codEmpresa);
                    oIPI = oIpiDAO.ObterPor(oIPI);
                    objEstq_Produto.tributacaoIPI = oIPI;

                    return objEstq_Produto;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Produto objEstq_Produto1 = new Estq_Produto();
                return objEstq_Produto1;

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
        
        private void geraOcorrencia(Estq_Produto oEstq_Produto, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Produto.idestq_produto.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Produto oCobr = new Estq_Produto();
                    oCobr = ObterPor(oEstq_Produto);

                    if (!oCobr.Equals(oEstq_Produto))
                    {
                        descricao = "Produto de Estoque id: " + oEstq_Produto.idestq_produto + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oEstq_Produto.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oEstq_Produto.descricao;
                        }
                        if (!oCobr.descricaodetalhada.Equals(oEstq_Produto.descricaodetalhada))
                        {
                            descricao += " Descrição Detalhada de " + oCobr.descricaodetalhada + " para " + oEstq_Produto.descricaodetalhada;
                        }
                        if (!oCobr.situacao.Equals(oEstq_Produto.situacao))
                        {
                            descricao += " Situação de " + oCobr.situacao + " para " + oEstq_Produto.situacao;
                        }
                        if (!oCobr.codigoean.Equals(oEstq_Produto.codigoean))
                        {
                            descricao += " Código EAN de " + oCobr.codigoean + " para " + oEstq_Produto.codigoean;
                        }
                        if (!oCobr.qtde_estoqueminimo.Equals(oEstq_Produto.qtde_estoqueminimo))
                        {
                            descricao += " Estoque Mínimo de " + oCobr.qtde_estoqueminimo + " para " + oEstq_Produto.qtde_estoqueminimo;
                        }
                        if (!oCobr.qtde_estoquemaxima.Equals(oEstq_Produto.qtde_estoquemaxima))
                        {
                            descricao += " Estoque Máximo de " + oCobr.qtde_estoquemaxima + " para " + oEstq_Produto.qtde_estoquemaxima;
                        }
                        if (!oCobr.fabricante.idPessoa.Equals(oEstq_Produto.fabricante.idPessoa))
                        {
                            if (!oCobr.fabricante.idPessoa.Equals(null))
                                descricao += " Fabricante de " + oCobr.fabricante.pessoa.nome + " para " + oEstq_Produto.fabricante.pessoa.nome;
                            else
                                descricao += " Fabricante de " + " " + " para " + oEstq_Produto.fabricante.pessoa.nome;
                        }
                        //Grupo do Estoque
                        if (!oCobr.Estq_Grupo.idestq_grupo.Equals(oEstq_Produto.Estq_Grupo.idestq_grupo))
                        {
                            descricao += " Grupo de Estoque de " + oCobr.Estq_Grupo.idestq_grupo + "-" + oCobr.Estq_Grupo.descricao + " para " + oEstq_Produto.Estq_Grupo.idestq_grupo + "-" + oEstq_Produto.Estq_Grupo.descricao;
                        }
                        //SubGrupo do Estoque
                        if (!oCobr.Estq_SubGrupo.idestq_subgrupo.Equals(oEstq_Produto.Estq_SubGrupo.idestq_subgrupo))
                        {
                            descricao += " Subgrupo de Estoque de " + oCobr.Estq_SubGrupo.idestq_subgrupo + "-" + oCobr.Estq_SubGrupo.descricao + " para " + oEstq_Produto.Estq_SubGrupo.idestq_subgrupo + "-" + oEstq_Produto.Estq_SubGrupo.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Produto de Estoque : " + oEstq_Produto.idestq_produto + " - " + oEstq_Produto.descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Produto de Estoque : " + oEstq_Produto.idestq_produto + " - " + oEstq_Produto.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaProduto(int empMaster, int codigoProduto, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select p.* from estq_produto p ";

                if (codigoProduto > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " p.codigoproduto = @codigoproduto ";
                }

                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " p.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoproduto", codigoProduto);
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
