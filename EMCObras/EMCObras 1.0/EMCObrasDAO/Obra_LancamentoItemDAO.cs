using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCObrasModel;
using EMCEstoqueModel;
using EMCEstoqueDAO;

namespace EMCObrasDAO
{
    public class Obra_LancamentoItemDAO
    {

        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_LancamentoItemDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
            
        public Boolean Salvar(List<Obra_LancamentoItem> lstItem, int idLancamento )
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            Boolean verificaAlteracao = false;
            //Grava um novo registro de PagarDocumento
            try
            {
                
                verificaAlteracao =  Salvar(Conexao, transacao, lstItem, idLancamento);

                transacao.Commit();

                return verificaAlteracao;

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
        public Boolean Salvar(MySqlConnection Conecta, MySqlTransaction transacao, List<Obra_LancamentoItem> lstItem, int idLancamento)
        {

            //Grava um novo registro de PagarDocumento
            try
            {

                Boolean verificaAlteracao = false;

                foreach(Obra_LancamentoItem oItem in lstItem)
                {

                    if (oItem.status == "I")
                    {
                        ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                        string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                        //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                        String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                         "where a.table_name = 'obra_lancamentoitem'"+
                                         "  and a.table_schema ='" + schemaBD.Trim() + "'";

                        MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                        MySqlDataReader drCon;
                        drCon = Sqlcon2.ExecuteReader();

                        int idItem = 0;
                        while (drCon.Read())
                        {
                            idItem = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                            oItem.idObra_LancamentoItem = idItem;
                        }

                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        geraOcorrencia(oItem, "I");

                        //Monta comando para a gravação do registro
                        String strSQL = "insert into obra_lancamento_alocacao (idobra_lancamento, idestq_produto, "+
                                                                              "quantidade, vlrunitario, vlrproduto, " + 
                                                                              "idunidade_entrada, quantidadeentrada ) " +
                                                                    " values (@idobra_lancamento, @idestq_produto, " +
                                                                              "@quantidade, @vlrunitario, @vlrproduto, " +
                                                                              "@idunidade_entrada, @quantidadeentrada ) ";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                        Sqlcon.Parameters.AddWithValue("@idobra_lancamento", idLancamento);
                        Sqlcon.Parameters.AddWithValue("@idestq_produto", oItem.idEstq_Produto.idestq_produto);
                        Sqlcon.Parameters.AddWithValue("@quantidade", oItem.quantidade);
                        Sqlcon.Parameters.AddWithValue("@vlrunitario", oItem.vlrUnitario);
                        Sqlcon.Parameters.AddWithValue("@vlrproduto", oItem.vlrProduto);
                        Sqlcon.Parameters.AddWithValue("@idunidade_entrada", oItem.idUnidadeEntrada.idestq_produto_unidade);
                        Sqlcon.Parameters.AddWithValue("@quantidadeentrada", oItem.quantidadeEntrada);
                        
                        //abre conexao e executa o comando
                        Sqlcon.ExecuteNonQuery();

                        Obra_LancamentoAlocacaoDAO oAlocacaoDAO = new Obra_LancamentoAlocacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        oAlocacaoDAO.Salvar(Conecta, transacao, oItem.lstAlocacao, idItem);

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oItem.status == "A")
                    {
                        geraOcorrencia(oItem, "A");

                        //Monta comando para a gravação do registro
                        String strSQL = "update obra_lancamentoitem set quantidade=@quantidade, " +
                                                                       "vlrunitario=@vlrunitario, " +
                                                                       "vlrproduto=@vlrproduto, " +
                                                                       "idunidade_entrada=@idunidade_entrada, " +
                                                                       "quantidadeentrada=@quantidadeentrada " +
                                                                 " where idobra_lancamentoitem=@idobra_lancamentoitem";

                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", oItem.idObra_LancamentoItem);
                        Sqlcon.Parameters.AddWithValue("@quantidade", oItem.quantidade);
                        Sqlcon.Parameters.AddWithValue("@vlrunitario", oItem.vlrUnitario);
                        Sqlcon.Parameters.AddWithValue("@vlrproduto", oItem.vlrProduto);
                        Sqlcon.Parameters.AddWithValue("@idunidade_entrada", oItem.idUnidadeEntrada.idestq_produto_unidade);
                        Sqlcon.Parameters.AddWithValue("@quantidadeentrada", oItem.quantidadeEntrada);
                        Sqlcon.ExecuteNonQuery();

                        Obra_LancamentoAlocacaoDAO oAlocacaoDAO = new Obra_LancamentoAlocacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        oAlocacaoDAO.Salvar(Conecta, transacao, oItem.lstAlocacao, oItem.idObra_LancamentoItem);

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }
                    else if (oItem.status == "E")
                    {
                        geraOcorrencia(oItem, "E");
                        //Monta comando para a gravação do registro
                        String strSQL = "delete from obra_lancamentoitem where idobra_lancamentoitem = @idobra_lancamentoitem";
                        MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                        Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", oItem.idObra_LancamentoItem);
                        Sqlcon.ExecuteNonQuery();

                        Obra_LancamentoAlocacaoDAO oAlocacaoDAO = new Obra_LancamentoAlocacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        oAlocacaoDAO.Salvar(Conecta, transacao, oItem.lstAlocacao, oItem.idObra_LancamentoItem);

                        OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                        oOcoDAO.Salvar(oOcorrencia, transacao);

                        verificaAlteracao = true;
                    }

                }

                return verificaAlteracao;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable ListaObraLancamentoItem(int idObra_Lancamento)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamentoitem a where a.idobra_lancamento = @idobra_lancamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_lancamento", idObra_Lancamento);

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

        public List<Obra_LancamentoItem> listaObraLancamentoItem(int idObra_Lancamento)
        {
            try
            {
                List<Obra_LancamentoItem> lstRateio = new List<Obra_LancamentoItem>();
                List<Obra_LancamentoItem> lstRetorno = new List<Obra_LancamentoItem>();

                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamentoitem a where a.idobra_lancamento= @idobra_lancamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_lancamento", idObra_Lancamento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                
                Boolean Consulta = false;

                while (drCon.Read())
                {
                    Consulta = true;
                    Obra_LancamentoItem oItemLcto = new Obra_LancamentoItem();
                    oItemLcto.idObra_LancamentoItem = EmcResources.cInt(drCon["idobra_lancamentoitem"].ToString());
                    oItemLcto.idObra_Lancamento = EmcResources.cInt(drCon["idobra_lancamento"].ToString());

                    Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
                    oUnidade.idestq_produto_unidade = EmcResources.cInt(drCon["idunidade_entrada"].ToString());
                    oItemLcto.idUnidadeEntrada = oUnidade;

                    oItemLcto.quantidade = EmcResources.cDouble(drCon["quantidade"].ToString());
                    oItemLcto.quantidadeEntrada = EmcResources.cDouble(drCon["quantidadeentrada"].ToString());

                    oItemLcto.status = "";

                    oItemLcto.vlrProduto = EmcResources.cCur(drCon["vlrproduto"].ToString());
                    oItemLcto.vlrUnitario = EmcResources.cCur(drCon["vlrunitario"].ToString());

                    lstRateio.Add(oItemLcto);
                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {
                    foreach (Obra_LancamentoItem oRat in lstRateio)
                    {

                        Estq_Produto_UnidadeDAO oUnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                        oRat.idUnidadeEntrada = oUnidadeDAO.ObterPor(oRat.idUnidadeEntrada);

                        Obra_LancamentoAlocacaoDAO oAlocacaoDAO = new Obra_LancamentoAlocacaoDAO(parConexao, oOcorrencia, codEmpresa);
                        oRat.lstAlocacao = oAlocacaoDAO.listaObraLancamentoAlocacao(oRat.idObra_LancamentoItem);

                        lstRetorno.Add(oRat);
                    }

                }
                return lstRetorno;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Obra_LancamentoItem ObterPor(Obra_LancamentoItem oItem)
        {
            bool Consulta = false;

            try
            {
               
               
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamentoitem a where a.idobra_lancamentoitem = @idobra_lancamentoitem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", oItem.idObra_LancamentoItem);
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Obra_LancamentoItem oRateio = new Obra_LancamentoItem();

                while (drCon.Read())
                {
                    Consulta = true;
                    oRateio.idObra_LancamentoItem = EmcResources.cInt(drCon["idobra_lancamentoitem"].ToString());
                    oRateio.idObra_Lancamento = EmcResources.cInt(drCon["idobra_lancamento"].ToString());

                    Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
                    oUnidade.idestq_produto_unidade = EmcResources.cInt(drCon["idunidade_entrada"].ToString());
                    oRateio.idUnidadeEntrada = oUnidade;

                    oRateio.quantidade = EmcResources.cDouble(drCon["quantidade"].ToString());
                    oRateio.quantidadeEntrada = EmcResources.cDouble(drCon["quantidadeentrada"].ToString());

                    oRateio.status = "";

                    oRateio.vlrProduto = EmcResources.cCur(drCon["vlrproduto"].ToString());
                    oRateio.vlrUnitario = EmcResources.cCur(drCon["vlrunitario"].ToString());

                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {

                    Estq_Produto_UnidadeDAO oUnidadeDAO = new Estq_Produto_UnidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.idUnidadeEntrada = oUnidadeDAO.ObterPor(oRateio.idUnidadeEntrada);

                    Obra_LancamentoAlocacaoDAO oAlocacaoDAO = new Obra_LancamentoAlocacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    oRateio.lstAlocacao = oAlocacaoDAO.listaObraLancamentoAlocacao(oRateio.idObra_LancamentoItem);
                   
                }
                return oRateio;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(Obra_LancamentoItem oItem, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oItem.idObra_Lancamento.ToString();

                if (flag == "A")
                {

                    Obra_LancamentoItem oRat = new Obra_LancamentoItem();
                    oRat = ObterPor(oItem);

                    if (!oRat.Equals(oItem))
                    {
                        descricao = " Lancamento id : " + oItem.idObra_Lancamento + "Item ID: " + oItem.idObra_LancamentoItem +
                                    " -  foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oRat.idUnidadeEntrada.idestq_produto_unidade.Equals(oItem.idUnidadeEntrada.idestq_produto_unidade))
                        {
                            descricao += " Unidade Entrda de  " + oRat.idUnidadeEntrada.idestq_produto_unidade + "-" + oRat.idUnidadeEntrada.unidade_descricao +
                                         " para " + oItem.idUnidadeEntrada.idestq_produto_unidade + "-" + oItem.idUnidadeEntrada.unidade_descricao;
                        }
                        if (!oRat.vlrUnitario.Equals(oItem.vlrUnitario))
                        {
                            descricao += " Valor Unitario de " + oRat.vlrUnitario + " para " + oItem.vlrUnitario;
                        }
                        if (!oRat.vlrProduto.Equals(oItem.vlrProduto))
                        {
                            descricao += " Valor Produto de " + oRat.vlrProduto + " para " + oItem.vlrProduto;
                        }
                        if (!oRat.quantidade.Equals(oItem.quantidade))
                        {
                            descricao += " Quantidade de " + oRat.quantidade + " para " + oItem.quantidade;
                        }
                        if (!oRat.quantidadeEntrada.Equals(oItem.quantidadeEntrada))
                        {
                            descricao += " Quantidade Entrada de " + oRat.quantidadeEntrada + " para " + oItem.quantidadeEntrada;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Lancamento id : " + oItem.idObra_Lancamento + "Item ID: " + oItem.idObra_LancamentoItem +
                                " - Produto - " + oItem.idEstq_Produto.idestq_produto + " - " + oItem.idEstq_Produto.codigoProduto + "-" + oItem.idEstq_Produto.descricao +
                                " - Unidade  - " + oItem.idUnidadeEntrada.idestq_produto_unidade + " - " + oItem.idUnidadeEntrada.unidade_descricao +
                                " - quantidade Entrda  - " + oItem.quantidadeEntrada +
                                " - quantidade  - " + oItem.quantidade +
                                " - Valor Unitario  - " + oItem.vlrUnitario +
                                " - Valor Produto  - " + oItem.vlrProduto +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Lancamento id : " + oItem.idObra_Lancamento + "Item ID: " + oItem.idObra_LancamentoItem +
                                " - Produto - " + oItem.idEstq_Produto.idestq_produto + " - " + oItem.idEstq_Produto.codigoProduto + "-" + oItem.idEstq_Produto.descricao +
                                " - Unidade  - " + oItem.idUnidadeEntrada.idestq_produto_unidade + " - " + oItem.idUnidadeEntrada.unidade_descricao +
                                " - quantidade Entrda  - " + oItem.quantidadeEntrada +
                                " - quantidade  - " + oItem.quantidade +
                                " - Valor Unitario  - " + oItem.vlrUnitario +
                                " - Valor Produto  - " + oItem.vlrProduto +
                                " foi excluida por " + oOcorrencia.usuario.nome;
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
