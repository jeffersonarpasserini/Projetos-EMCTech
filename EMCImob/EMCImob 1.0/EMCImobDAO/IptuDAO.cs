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
    public class IptuDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IptuDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(List<Iptu> lstIptu)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                foreach(Iptu oIptu in lstIptu)
                {
                    if (oIptu.flag == "I")
                    {
                        Salvar(oIptu, Conexao, transacao);
                    }
                    else if (oIptu.flag == "A")
                    {
                        Atualizar(oIptu, Conexao, transacao);
                    }
                    else if (oIptu.flag == "E")
                    {
                        Excluir(oIptu, Conexao, transacao);
                    }
                    else if (oIptu.flag == "R")
                    {
                        Recuperar(oIptu, Conexao, transacao);
                    }
                }
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

        public void Salvar(Iptu objIptu, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'iptu'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();


                while (drCon.Read())
                {
                    objIptu.idIptu = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objIptu, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into iptu (idimovel, nroparcela, datavencimento, valorparcela, observacao, " + 
                                                    "tipoacerto, situacao, anobase, idempresa, " +  
                                                    "fornecedor_codempresa, fornecedor_idpessoa, situacaocobranca, " + 
                                                    "diafixo, valorparcelacarne, valorimposto, data1vencimento, parcelaano ) " +
                                " values (@idimovel, @nroparcela, @datavencimento, @valorparcela, @observacao, " + 
                                            "@tipoacerto, @situacao, @anobase, @idempresa, " + 
                                            "@fornecedor_codempresa, @fornecedor_idpessoa, @situacaocobranca, " +
                                            "@diafixo, @valorparcelacarne, @valorimposto, @data1vencimento, @parcelaano )";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);

                Sqlcon.Parameters.AddWithValue("@idimovel", objIptu.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idempresa", objIptu.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@nroparcela", objIptu.nroParcela);
                Sqlcon.Parameters.AddWithValue("@datavencimento", objIptu.dataVencimento);
                Sqlcon.Parameters.AddWithValue("@valorparcela", objIptu.valorParcela);
                Sqlcon.Parameters.AddWithValue("@observacao", objIptu.observacao);
                Sqlcon.Parameters.AddWithValue("@tipoacerto", objIptu.tipoAcerto);
                Sqlcon.Parameters.AddWithValue("@situacao", objIptu.situacao);
                Sqlcon.Parameters.AddWithValue("@anobase", objIptu.anoBase);
                Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", objIptu.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", objIptu.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@situacaocobranca", objIptu.situacaoCobranca);
                Sqlcon.Parameters.AddWithValue("@diafixo", objIptu.diaFixo);
                Sqlcon.Parameters.AddWithValue("@valorparcelacarne", objIptu.valorParcelaCarne);
                Sqlcon.Parameters.AddWithValue("@valorimposto", objIptu.valorImposto);
                Sqlcon.Parameters.AddWithValue("@data1vencimento", objIptu.data1Vencimento);
                Sqlcon.Parameters.AddWithValue("@parcelaano", objIptu.parcelaAno);

                   
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);


            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Atualizar(Iptu objIptu, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //atualiza um registro
            try
            {
                geraOcorrencia(objIptu, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update iptu set idimovel = @idimovel, nroparcela = @nroparcela, datavencimento = @datavencimento, valorparcela = @valorparcela, observacao = @observacao, " +
                                                            " tipoacerto = @tipoacerto, situacao = @situacao, anobase = @anobase " +
                                                        " where idiptu = @idiptu";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idiptu", objIptu.idIptu);
                Sqlcon.Parameters.AddWithValue("@idimovel", objIptu.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@nroparcela", objIptu.nroParcela);
                Sqlcon.Parameters.AddWithValue("@datavencimento", objIptu.dataVencimento);
                Sqlcon.Parameters.AddWithValue("@valorparcela", objIptu.valorParcela);
                Sqlcon.Parameters.AddWithValue("@observacao", objIptu.observacao);
                Sqlcon.Parameters.AddWithValue("@tipoacerto", objIptu.tipoAcerto);
                Sqlcon.Parameters.AddWithValue("@situacao", objIptu.situacao);
                Sqlcon.Parameters.AddWithValue("@anobase", objIptu.anoBase);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Excluir(Iptu objIptu, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //apaga registro
            try
            {
                geraOcorrencia(objIptu, "E");

                //Monta comando para a gravação do registro
                //String strSQL = "delete from iptu where idiptu = @idiptu";
                //MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                //Sqlcon.Parameters.AddWithValue("@idiptu", objIptu.idIptu);

                String strSQL = "update iptu set situacao = @situacao, idusuarioexclusao = @idusuarioexclusao, dataexclusao = @dataexclusao " +
                                                            " where idiptu = @idiptu";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idiptu", objIptu.idIptu);
                Sqlcon.Parameters.AddWithValue("@situacao", objIptu.situacao);
                Sqlcon.Parameters.AddWithValue("@idusuarioexclusao", objIptu.idUsuarioExclusao);
                Sqlcon.Parameters.AddWithValue("@dataexclusao", objIptu.dataExclusao);
                    

                Sqlcon.ExecuteNonQuery();
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Recuperar(Iptu objIptu, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //apaga registro
            try
            {
                geraOcorrencia(objIptu, "R");

                String strSQL = "update iptu set situacao = @situacao, idusuarioexclusao = @idusuarioexclusao, dataexclusao = @dataexclusao " +
                                                            " where idiptu = @idiptu";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idiptu", objIptu.idIptu);
                Sqlcon.Parameters.AddWithValue("@situacao", "A");
                Sqlcon.Parameters.AddWithValue("@idusuarioexclusao", null);
                Sqlcon.Parameters.AddWithValue("@dataexclusao", null);


                Sqlcon.ExecuteNonQuery();
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public DataTable pesquisaIptu(int empMaster, string codigoImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                // String strSQL = "select i.* from imovel i ";

                String strSQL = "SELECT i.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from iptu i " +
                                " left join imovel im on im.idimovel = i.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = im.idimovel ";


                //filtra tipo despesa imovel


                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " im.codigoimovel = @codigoimovel ";
                }

                if (dataInicial != null && dataFinal != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datavencimento >= @datainicial and datavencimento <= @datafinal ";
                }

                strSQL += " order by idimovel";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
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

        public DataTable ListaIptu()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT i.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from iptu i " +
                                " left join imovel im on im.idimovel = i.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = im.idimovel " +
                                " order by idimovel";

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
                
        public List<Iptu> lstIptu(int idIptu, int idImovel, string codigoImovel, string anoBase)
        {
            bool consulta = false;
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro 
                String strSQL = "SELECT i.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from iptu i " +
                                " left join imovel im on im.idimovel = i.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = im.idimovel ";

                if (idImovel > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.idimovel = @idimovel ";
                }
                if (!String.IsNullOrEmpty(anoBase))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.anobase = @anobase ";
                }

                strSQL += " order by idiptu ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", idImovel);
                Sqlcon.Parameters.AddWithValue("@anobase", anoBase);
                                               

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<Iptu> lstIptu = new List<Iptu>();
                List<Iptu> lstRetorno = new List<Iptu>();
                             

                Iptu objIptu;

                while (drCon.Read())
                {
                    consulta = true;
                    objIptu = new Iptu();

                    objIptu.idIptu = EmcResources.cInt(drCon["idiptu"].ToString());
                    lstIptu.Add(objIptu);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (Iptu oIptu in lstIptu)
                    {
                        Iptu obIptu = new Iptu();
                        obIptu = ObterPor(oIptu);

                        lstRetorno.Add(obIptu);
                    }
                }

                return lstRetorno;
                    
            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable dstRelatorioIptu(int idIptu, int idImovel, string codigoImovel, bool chkImovel, string anoBase, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT i.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from iptu i " +
                                " left join imovel im on im.idimovel = i.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = im.idtipoimovel "; 


                if (!String.IsNullOrEmpty(codigoImovel) && !chkImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " im.codigoimovel = @codigoimovel ";
                }

                if (dataInicial != null && dataFinal != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " datavencimento >= @datainicial and datavencimento <= @datafinal ";
                }
                if (!String.IsNullOrEmpty(anoBase))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.anobase = @anobase ";
                }


                strSQL += " order by idiptu ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);
                Sqlcon.Parameters.AddWithValue("@datainicial", dataInicial);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);
                Sqlcon.Parameters.AddWithValue("@anobase", anoBase);

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

        public DataTable dstRelatorioImovel(int idIptu, int idImovel, string codigoImovel, bool chkImovel, string anoBase, DateTime? dataInicial, DateTime? dataFinal)
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
                    //else
                    //    strSQL += " and ";
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

        public Iptu ObterPor(Iptu oIptu)
        {
            MySqlDataReader drCon;
            Iptu objRetorno = new Iptu();
            Boolean bControle = false;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oIptu.idIptu > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from iptu Where idiptu = " + oIptu.idIptu + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        bControle = true;
                        objRetorno.idIptu = EmcResources.cInt(drCon["idiptu"].ToString());

                        Imovel oImovel = new Imovel();
                        oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                        objRetorno.imovel = oImovel;

                        objRetorno.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                        objRetorno.dataVencimento = Convert.ToDateTime(drCon["datavencimento"].ToString());
                        objRetorno.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                        objRetorno.observacao = drCon["observacao"].ToString();
                        objRetorno.tipoAcerto = drCon["tipoacerto"].ToString();
                        objRetorno.situacao = drCon["situacao"].ToString();
                        objRetorno.anoBase = drCon["anobase"].ToString();
                        objRetorno.situacaoCobranca = drCon["situacaocobranca"].ToString();
                        objRetorno.valorParcelaCarne = EmcResources.cCur(drCon["valorparcelacarne"].ToString());
                        objRetorno.valorImposto = EmcResources.cCur(drCon["valorimposto"].ToString());
                        objRetorno.observacao = drCon["observacao"].ToString();
                        objRetorno.diaFixo = drCon["diafixo"].ToString();
                        objRetorno.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                        objRetorno.data1Vencimento = Convert.ToDateTime(drCon["data1vencimento"].ToString());
                        objRetorno.parcelaAno = EmcResources.cInt(drCon["parcelaano"].ToString());

                        Fornecedor oFornecedor = new Fornecedor();
                        oFornecedor.idPessoa = EmcResources.cInt(drCon["fornecedor_idpessoa"].ToString());
                        oFornecedor.codEmpresa = EmcResources.cInt(drCon["fornecedor_codempresa"].ToString());
                        objRetorno.fornecedor = oFornecedor;

                        //LocacaoReceber oReceber = new LocacaoReceber();
                       // oReceber.idLocacaoReceber = EmcResources.cInt(drCon["idlocacaoreceber"].ToString());

                        //LocacaoPagar oPagar = new LocacaoPagar();
                       // oPagar.idLocacaoPagar = EmcResources.cInt(drCon["idlocacaopagar"].ToString());

                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (bControle)
                    {
                        ImovelDAO oImovelDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.imovel = oImovelDAO.ObterPor(objRetorno.imovel);

                        FornecedorDAO oFornDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.fornecedor = oFornDAO.ObterPor(objRetorno.fornecedor);

                        //LocacaoReceberDAO oRecDAO = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                        //objRetorno.locacaoReceber = oRecDAO.ObterPor(objRetorno.locacaoReceber);

                        //LocacaoPagarDAO oPagDAO = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                        //objRetorno.locacaoPagar = oPagDAO.ObterPor(objRetorno.locacaoPagar);

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

        private void geraOcorrencia(Iptu oIptu, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oIptu.idIptu.ToString();

                if (flag == "A")
                {

                    Iptu oIPTU = new Iptu();
                    oIPTU = ObterPor(oIptu);

                    if (!oIPTU.Equals(oIptu))
                    {
                        descricao = "IPTU id: " + oIptu.idIptu + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oIPTU.imovel.idImovel.Equals(oIptu.imovel.idImovel))
                        {
                            descricao += " Imóvel de " + oIPTU.imovel.idImovel + " para " + oIptu.imovel.idImovel;
                        }
                        if (!oIPTU.nroParcela.Equals(oIptu.nroParcela))
                        {
                            descricao += " Nro. Parcela de " + oIPTU.nroParcela + " para " + oIptu.nroParcela;
                        }
                        if (!oIPTU.dataVencimento.Equals(oIptu.dataVencimento))
                        {
                            descricao += " Data Vencimento de " + oIPTU.dataVencimento + " para " + oIptu.dataVencimento;
                        }
                        if (!oIPTU.valorParcela.Equals(oIptu.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oIPTU.valorParcela + " para " + oIptu.valorParcela;
                        }
                        if (!oIPTU.observacao.Equals(oIptu.observacao))
                        {
                            descricao += " Observação de " + oIPTU.observacao + " para " + oIptu.observacao;
                        }
                        if (!oIPTU.tipoAcerto.Equals(oIptu.tipoAcerto))
                        {
                            descricao += " Tipo de Acerto de " + oIPTU.tipoAcerto + " para " + oIptu.tipoAcerto;
                        }
                        if (!oIPTU.situacao.Equals(oIptu.situacao))
                        {
                            descricao += " Situação de " + oIPTU.situacao + " para " + oIptu.situacao;
                        }
                        if (!oIPTU.anoBase.Equals(oIptu.anoBase))
                        {
                            descricao += " Ano Base de " + oIPTU.anoBase + " para " + oIptu.anoBase;
                        }
                        if (!oIPTU.situacaoCobranca.Equals(oIptu.situacaoCobranca))
                        {
                            descricao += " Situação Cobrança de " + oIPTU.situacaoCobranca + " para " + oIptu.situacaoCobranca;
                        }
                        if (!oIPTU.fornecedor.Equals(oIptu.fornecedor))
                        {
                            descricao += " Fornecedor de " + oIPTU.fornecedor.idPessoa+" - "+oIPTU.fornecedor.pessoa.nome + 
                                         " para " + oIptu.fornecedor.idPessoa +" - "+oIptu.fornecedor.pessoa.nome;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "IPTU : " + oIptu.idIptu +
                        " Imóvel: " + oIptu.imovel.idImovel +
                        " Nro. Parcela: " + oIptu.nroParcela +
                        " Data Vencimento: " + oIptu.dataVencimento +
                        " Valor Parcela: " + oIptu.valorParcela +
                        " Observação: " + oIptu.observacao +
                        " Tipo Acerto: " + oIptu.tipoAcerto +
                        " Situação: " + oIptu.situacao +
                        " Situacao Cobrança: " + oIptu.situacaoCobranca +
                        " Fornecedor : " + oIptu.fornecedor.idPessoa + "-" + oIptu.fornecedor.pessoa.nome +
                        " Ano Base: " + oIptu.anoBase +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "IPTU : " + oIptu.idIptu +
                         " Imóvel: " + oIptu.imovel.idImovel +
                        " Nro. Parcela: " + oIptu.nroParcela +
                        " Data Vencimento: " + oIptu.dataVencimento +
                        " Valor Parcela: " + oIptu.valorParcela +
                        " Observação: " + oIptu.observacao +
                        " Tipo Acerto: " + oIptu.tipoAcerto +
                        " Situação: " + oIptu.situacao +
                        " Situacao Cobrança: " + oIptu.situacaoCobranca +
                        " Fornecedor : " + oIptu.fornecedor.idPessoa + "-" + oIptu.fornecedor.pessoa.nome +
                        " Ano Base: " + oIptu.anoBase +
                        " foi exluido por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "R")
                {
                    descricao = "IPTU : " + oIptu.idIptu +
                         " Imóvel: " + oIptu.imovel.idImovel +
                        " Nro. Parcela: " + oIptu.nroParcela +
                        " Data Vencimento: " + oIptu.dataVencimento +
                        " Valor Parcela: " + oIptu.valorParcela +
                        " Observação: " + oIptu.observacao +
                        " Tipo Acerto: " + oIptu.tipoAcerto +
                        " Situação: " + oIptu.situacao +
                        " Situacao Cobrança: " + oIptu.situacaoCobranca +
                        " Fornecedor : " + oIptu.fornecedor.idPessoa + "-" + oIptu.fornecedor.pessoa.nome +
                        " Ano Base: " + oIptu.anoBase +
                        " foi recuperado por " + oOcorrencia.usuario.nome;
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
