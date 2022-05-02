using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroDAO;

namespace EMCImobDAO
{
    public class DespesaImovelDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public DespesaImovelDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
            }
            codEmpresa = idEmpresa;

        }

        public void Salvar(DespesaImovel objDespesaImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'despesaimovel'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objDespesaImovel.idDespesaImovel = EmcResources.cInt(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objDespesaImovel, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into despesaimovel (idimovel, idlocacaoproventos, datalancamento, historico, valordespesa, dataacerto, situacao, descricaoacerto, " + 
                                                            " fornecedor_codempresa, fornecedor_idpessoa) " +
                                " values (@idimovel, @idlocacaoproventos, @datalancamento, @historico, @valordespesa, @dataacerto, @situacao, @descricaoacerto, " +
                                        " @fornecedor_codempresa, @fornecedor_idpessoa)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", objDespesaImovel.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idlocacaoproventos", objDespesaImovel.locacaoProventos.idLocacaoProventos);
                Sqlcon.Parameters.AddWithValue("@datalancamento", objDespesaImovel.dataLancamento);
                Sqlcon.Parameters.AddWithValue("@historico", objDespesaImovel.historico);
                Sqlcon.Parameters.AddWithValue("@valordespesa", objDespesaImovel.valorDespesa);
                Sqlcon.Parameters.AddWithValue("@dataacerto", objDespesaImovel.dataAcerto);
                Sqlcon.Parameters.AddWithValue("@situacao", objDespesaImovel.situacao);
                Sqlcon.Parameters.AddWithValue("@descricaoacerto", objDespesaImovel.descricaoAcerto);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", objDespesaImovel.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", objDespesaImovel.fornecedor.idPessoa);

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
                
        public void Atualizar(DespesaImovel objDespesaImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objDespesaImovel, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update despesaimovel set idimovel = @idimovel, idlocacaoproventos = @idlocacaoproventos, datalancamento = @datalancamento, historico = @historico, " +
                                                        " valordespesa = @valordespesa, dataacerto = @dataacerto, descricaoacerto = @descricaoacerto, " + 
                                                        " fornecedor_codempresa = @fornecedor_codempresa, fornecedor_idpessoa = @fornecedor_idpessoa " + 
                                                        " where iddespesaimovel = @iddespesaimovel";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@iddespesaimovel", objDespesaImovel.idDespesaImovel);
                Sqlcon.Parameters.AddWithValue("@idimovel", objDespesaImovel.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idlocacaoproventos", objDespesaImovel.locacaoProventos.idLocacaoProventos);
                Sqlcon.Parameters.AddWithValue("@datalancamento", objDespesaImovel.dataLancamento);
                Sqlcon.Parameters.AddWithValue("@historico", objDespesaImovel.historico);
                Sqlcon.Parameters.AddWithValue("@valordespesa", objDespesaImovel.valorDespesa);
                Sqlcon.Parameters.AddWithValue("@dataacerto", objDespesaImovel.dataAcerto);
                Sqlcon.Parameters.AddWithValue("@descricaoacerto", objDespesaImovel.descricaoAcerto);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", objDespesaImovel.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", objDespesaImovel.fornecedor.idPessoa);
                //Sqlcon.Parameters.AddWithValue("@situacao", objDespesaImovel.situacao);

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

        public void Excluir(DespesaImovel objDespesaImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objDespesaImovel, "E");

               // Monta comando para a gravação do registro
                String strSQL = "update despesaimovel set idimovel = @idimovel, idlocacaoproventos = @idlocacaoproventos, datalancamento = @datalancamento, historico = @historico, " +
                                                        " valordespesa = @valordespesa, dataacerto = @dataacerto, descricaoacerto = @descricaoacerto, " +
                                                        " fornecedor_codempresa = @fornecedor_codempresa, fornecedor_idpessoa = @fornecedor_idpessoa, situacao = @situacao, " + 
                                                        " idusuarioexclusao = @idusuarioexclusao, dataexclusao = @dataexclusao " +
                                                        " where iddespesaimovel = @iddespesaimovel";
               
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@iddespesaimovel", objDespesaImovel.idDespesaImovel);
                Sqlcon.Parameters.AddWithValue("@idimovel", objDespesaImovel.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idlocacaoproventos", objDespesaImovel.locacaoProventos.idLocacaoProventos);
                Sqlcon.Parameters.AddWithValue("@datalancamento", objDespesaImovel.dataLancamento);
                Sqlcon.Parameters.AddWithValue("@historico", objDespesaImovel.historico);
                Sqlcon.Parameters.AddWithValue("@valordespesa", objDespesaImovel.valorDespesa);
                Sqlcon.Parameters.AddWithValue("@dataacerto", objDespesaImovel.dataAcerto);
                Sqlcon.Parameters.AddWithValue("@descricaoacerto", objDespesaImovel.descricaoAcerto);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", objDespesaImovel.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", objDespesaImovel.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@situacao", objDespesaImovel.situacao);
                Sqlcon.Parameters.AddWithValue("@idusuarioexclusao", objDespesaImovel.idUsuarioExclusao);
                Sqlcon.Parameters.AddWithValue("@dataexclusao", objDespesaImovel.dataExclusao);


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

        public DataTable pesquisaDespesaImovel(int empMaster, int idPessoa, string codigoImovel)
        {
            try
            {
                return pesquisaDespesaImovel(empMaster, idPessoa, codigoImovel, null, null);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable pesquisaDespesaImovel(int empMaster, int idPessoa, string codigoImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                // String strSQL = "select i.* from imovel i ";

                String strSQL = "SELECT d.*, ti.descricao as desc_tipoimovel, l.descricao as desc_proventos, f.nome as nome_proprietario, i.codigoimovel as codigoimovel " +
                                " from despesaimovel d " +
                                " left join v_fornecedor f on f.codempresa = d.fornecedor_codempresa and f.idpessoa = d.fornecedor_idpessoa " +
                                " left join imovel i on i.idimovel = d.idimovel " +
                                " left join tipoimovel ti on ti.idtipoimovel = i.idimovel " +
                                " left join locacaoproventos l on l.idlocacaoproventos = d.idlocacaoproventos " ;  


                //filtra tipo despesa imovel
                if (idPessoa > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }                   
                    strSQL += " d.fornecedor_idpessoa = @fornecedor_idpessoa ";
                }

                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }

                //filtra por data
                //if (!String.IsNullOrEmpty(dataInicial.Value.Date.ToString("yyyy-MM-dd")) && !String.IsNullOrEmpty(dataFinal.Value.Date.ToString("yyyy-MM-dd")))
                if(dataInicial != null && dataFinal != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datalancamento >= @datainicial and datalancamento <= @datafinal ";
                }
               
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);

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

        public DataTable ListaDespesaImovel()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT d.*, l.descricao as desc_proventos, f.nome as nome_proprietario, i.codigoimovel as codigoimovel " +
                                " from despesaimovel d " +
                                " left join v_fornecedor f on f.codempresa = d.fornecedor_codempresa and f.idpessoa = d.fornecedor_idpessoa " +
                                " left join imovel i on i.idimovel = d.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = i.idimovel " +
                                " left join locacaoproventos l on l.idlocacaoproventos = d.idlocacaoproventos " +
                                " order by datalancamento";  

                //String strSQL = " SELECT * from despesaimovel order by datalancamento"; 

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                daCon.Dispose();
                daCon = null;
            }
        }

        //public DataTable dstRelatorioDespesaImovel(int idPessoa, bool chkFornecedor, string codigoImovel, bool chkImovel)
        //{
        //    try
        //    {
        //        return dstRelatorioDespesaImovel(idPessoa, chkFornecedor, codigoImovel, chkImovel, null, null);
        //    }
        //    catch (MySqlException erro)
        //    {
        //        throw erro;
        //    }

        //}

        public DataTable dstRelatorioDespesaImovel(int idPessoa, bool chkFornecedor, string codigoImovel, bool chkImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT d.*, f.nome as nome_proprietario, l.descricao as proventos, t.descricao as desc_tipoimovel, i.codigoimovel as codigoimovel " +
                                "from despesaimovel d " +
                                "left join v_fornecedor f on f.codempresa = d.fornecedor_codempresa and f.idpessoa = d.fornecedor_idpessoa " +
                                "left join imovel i on i.idimovel = d.idimovel " +
                                "left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                "left join locacaoproventos l on l.idlocacaoproventos = d.idlocacaoproventos " ;


                if (idPessoa > 0 && !chkFornecedor) 
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " d.fornecedor_idpessoa = @fornecedor_idpessoa ";
                }
                if (!String.IsNullOrEmpty(codigoImovel) && !chkImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.codigoimovel = @codigoimovel ";
                } 
             
                if(dataInicial != null && dataFinal != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datalancamento >= @datainicial and datalancamento <= @datafinal ";
                }
               

                strSQL += " order by iddespesaimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);               
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", idPessoa);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);

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

        public DataTable dstRelatorioImovel(int idPessoa, bool chkFornecedor, string codigoImovel, bool chkImovel)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro

                string strSQL = "SELECT i.*, t.descricao as tipoimovel" +
                               " from imovel i " +
                               " left join v_fornecedor f on f.codempresa = i.codempresa and f.idpessoa = i.idproprietario " +
                               " left join tipoimovel t on t.idtipoimovel = i.idtipoimovel ";


                if (!String.IsNullOrEmpty(codigoImovel) && !chkImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }
                
                strSQL += " order by idimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);

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
                
        public DespesaImovel ObterPor(DespesaImovel oDespesaImovel)
        {
            MySqlDataReader drCon;
            DespesaImovel objRetorno = new DespesaImovel();
            Boolean bControle = false;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oDespesaImovel.idDespesaImovel > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from despesaimovel Where iddespesaimovel = " + oDespesaImovel.idDespesaImovel + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        bControle = true;
                        objRetorno.idDespesaImovel = EmcResources.cInt(drCon["iddespesaimovel"].ToString());

                        Imovel oImovel = new Imovel();
                        oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                        objRetorno.imovel = oImovel;

                        LocacaoProventos oLocacaoProventos = new LocacaoProventos();
                        oLocacaoProventos.idLocacaoProventos = EmcResources.cInt(drCon["idlocacaoproventos"].ToString());
                        objRetorno.locacaoProventos = oLocacaoProventos;

                        objRetorno.dataLancamento = Convert.ToDateTime(drCon["datalancamento"].ToString());
                        objRetorno.historico = drCon["historico"].ToString();
                        objRetorno.valorDespesa = EmcResources.cCur(drCon["valordespesa"].ToString());
                        objRetorno.dataAcerto = Convert.ToDateTime(drCon["dataacerto"].ToString());
                        objRetorno.situacao = drCon["situacao"].ToString();
                        objRetorno.descricaoAcerto = drCon["descricaoacerto"].ToString();
                        
                        Fornecedor oFornecedor = new Fornecedor();
                        oFornecedor.codEmpresa = Convert.ToInt32(drCon["fornecedor_codempresa"].ToString());
                        oFornecedor.idPessoa = Convert.ToInt32(drCon["fornecedor_idpessoa"].ToString());
                        objRetorno.fornecedor = oFornecedor;

                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (bControle)
                    {
                        ImovelDAO oImovelDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.imovel = oImovelDAO.ObterPor(objRetorno.imovel);

                        LocacaoProventosDAO oLocacaoProvDAO = new LocacaoProventosDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.locacaoProventos = oLocacaoProvDAO.ObterPor(objRetorno.locacaoProventos);

                        FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.fornecedor = oFornecedorDAO.ObterPor(objRetorno.fornecedor);
                    }
                }
                return objRetorno;

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

        private void geraOcorrencia(DespesaImovel oDespesaImovel, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oDespesaImovel.idDespesaImovel.ToString();

                if (flag == "A")
                {

                    DespesaImovel oDespImo = new DespesaImovel();
                    oDespImo = ObterPor(oDespesaImovel);

                    if (!oDespImo.Equals(oDespesaImovel))
                    {
                        descricao = "Despesa Imóvel id: " + oDespesaImovel.idDespesaImovel + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oDespImo.imovel.idImovel.Equals(oDespesaImovel.imovel.idImovel))
                        {
                            descricao += " Imóvel de " + oDespImo.imovel.idImovel + " para " + oDespesaImovel.imovel.idImovel;
                        }
                        if (!oDespImo.locacaoProventos.idLocacaoProventos.Equals(oDespesaImovel.locacaoProventos.idLocacaoProventos))
                        {
                            descricao += " Locação Proventos de " + oDespImo.locacaoProventos.idLocacaoProventos + " para " + oDespesaImovel.locacaoProventos.idLocacaoProventos;
                        }
                        if (!oDespImo.dataLancamento.Equals(oDespesaImovel.dataLancamento))
                        {
                            descricao += " Data Lançamento de " + oDespImo.dataLancamento + " para " + oDespesaImovel.dataLancamento;
                        }
                        if (!oDespImo.historico.Equals(oDespesaImovel.historico))
                        {
                            descricao += " Histórico de " + oDespImo.historico + " para " + oDespesaImovel.historico;
                        }
                        if (!oDespImo.dataAcerto.Equals(oDespesaImovel.dataAcerto))
                        {
                            descricao += " Data Acerto de " + oDespImo.dataAcerto + " para " + oDespesaImovel.dataAcerto;
                        }
                        if (!oDespImo.situacao.Equals(oDespesaImovel.situacao))
                        {
                            descricao += " Situação de " + oDespImo.situacao + " para " + oDespesaImovel.situacao;
                        }
                        if (!oDespImo.descricaoAcerto.Equals(oDespesaImovel.descricaoAcerto))
                        {
                            descricao += " Descrição Acerto de " + oDespImo.descricaoAcerto + " para " + oDespesaImovel.descricaoAcerto;
                        }
                        if (!oDespImo.fornecedor.codEmpresa.Equals(oDespesaImovel.fornecedor.codEmpresa))
                        {
                            descricao += " Empresa de " + oDespImo.fornecedor.codEmpresa + " para " + oDespesaImovel.fornecedor.codEmpresa;
                        }
                        if (!oDespImo.fornecedor.idPessoa.Equals(oDespesaImovel.fornecedor.idPessoa))
                        {
                            descricao += " Fornecedor de " + oDespImo.fornecedor.idPessoa + " para " + oDespesaImovel.fornecedor.idPessoa;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "Despesa Imóvel : " + oDespesaImovel.idDespesaImovel +
                        " Imóvel: " + oDespesaImovel.imovel.idImovel +
                        " Locação Provento: " + oDespesaImovel.locacaoProventos.idLocacaoProventos +
                        " Data Lançamento: " + oDespesaImovel.dataLancamento +
                        " Histórico: " + oDespesaImovel.historico +
                        " Valor Despesa: " + oDespesaImovel.valorDespesa +
                        " Data Acerto: " + oDespesaImovel.dataAcerto +
                        " Situação: " + oDespesaImovel.situacao +
                        " Descrição Acerto: " + oDespesaImovel.descricaoAcerto +
                        " Empresa: " + oDespesaImovel.fornecedor.codEmpresa +
                        " Fornecedor: " + oDespesaImovel.fornecedor.idPessoa +                        
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Despesa Imóvel : " + oDespesaImovel.idDespesaImovel +
                         " Imóvel: " + oDespesaImovel.imovel.idImovel +
                         " Locação Provento: " + oDespesaImovel.locacaoProventos.idLocacaoProventos +
                         " Data Lançamento: " + oDespesaImovel.dataLancamento +
                         " Histórico: " + oDespesaImovel.historico +
                         " Valor Despesa: " + oDespesaImovel.valorDespesa +
                         " Data Acerto: " + oDespesaImovel.dataAcerto +
                         " Situação: " + oDespesaImovel.situacao +
                         " Descrição Acerto: " + oDespesaImovel.descricaoAcerto +
                         " Empresa: " + oDespesaImovel.fornecedor.codEmpresa +
                         " Fornecedor: " + oDespesaImovel.fornecedor.idPessoa +
                        " foi exluido por " + oOcorrencia.usuario.nome + oDespesaImovel.idUsuarioExclusao + oDespesaImovel.dataExclusao;
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
