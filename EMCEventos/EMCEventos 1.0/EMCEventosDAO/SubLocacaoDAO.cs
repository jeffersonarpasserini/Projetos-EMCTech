using EMCEventosModel;
using EMCImobDAO;
using EMCImobModel;
using EMCLibrary;
using EMCSecurityDAO;
using EMCSecurityModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EMCEventosDAO
{
    public class SubLocacaoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public SubLocacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(SubLocacao objSubLocacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'evt_sublocacao'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();


                while (drCon.Read())
                {
                    objSubLocacao.idSublocacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objSubLocacao, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into evt_sublocacao (descricao, idevt_evento, idbox) " +
                                " values (@descricao, @idevt_evento, @idbox)";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);

                Sqlcon.Parameters.AddWithValue("@descricao", objSubLocacao.descricao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", objSubLocacao.evento.idEvento);
                Sqlcon.Parameters.AddWithValue("@idbox", objSubLocacao.idBox);


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

        public void Atualizar(SubLocacao objSubLocacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objSubLocacao, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update evt_sublocacao set descricao = @descricao, idevt_evento = @idevt_evento, idbox = @idbox  where idevt_sublocacao = @idevt_sublocacao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idevt_sublocacao", objSubLocacao.idSublocacao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", objSubLocacao.evento.idEvento);
                Sqlcon.Parameters.AddWithValue("@descricao", objSubLocacao.descricao);
                Sqlcon.Parameters.AddWithValue("@idbox", objSubLocacao.idBox);

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

        public void Excluir(SubLocacao objSubLocacao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objSubLocacao, "E");

                //Monta comando para a gravação do registro 
                String strSQL = "delete from evt_sublocacao where idevt_sublocacao = @idevt_sublocacao";

                //String strSQL = "update evt_evento set descricao = @descricao, datainicio = @datainicio, datafinal = @datafinal, " +
                //                " idimovel = @idimovel, statusevento = @statusevento  where idevt_evento = @idevt_evento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idevt_sublocacao", objSubLocacao.idSublocacao);
                //Sqlcon.Parameters.AddWithValue("@descricao", objEvento.descricao);
                //Sqlcon.Parameters.AddWithValue("@datainicio", objEvento.dataInicio);
                //Sqlcon.Parameters.AddWithValue("@datafinal", objEvento.dataFinal);
                //Sqlcon.Parameters.AddWithValue("@idimovel", objEvento.imovel.idImovel);
                //Sqlcon.Parameters.AddWithValue("@statusevento", objEvento.statusEvento);


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

        public DataTable pesquisaSubLocacao(int empMaster, int idEvento, string descEvento, string idBox)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                // String strSQL = "select i.* from imovel i ";

                String strSQL = "SELECT s.*, e.descricao as desc_evento " +
                                " from evt_sublocacao s " +
                                " left join evt_evento e on e.idevt_evento = s.idevt_evento " ;


                //filtra tipo despesa imovel

                if (idEvento > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " e.idevt_evento = @idevt_evento ";
                }
                if (!String.IsNullOrEmpty(descEvento))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " e.descricao = @descricao ";
                }

                if (!String.IsNullOrEmpty(idBox))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " idbox = @idbox ";
                }
                               

                strSQL += " order by idevt_evento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", idEvento);
                Sqlcon.Parameters.AddWithValue("@idbox", idBox);
                Sqlcon.Parameters.AddWithValue("@descricao", descEvento);

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

        public DataTable ListaSubLocacao()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT s.*,e.descricao as desc_evento " +
                                " from evt_sublocacao s " +
                                " left join evt_evento e on e.idevt_evento = s.idevt_evento " +
                                " order by idevt_evento, idbox";

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
                
        public DataTable dstRelatorioSubLoc(string codigoImovel, int idEvento, bool chkImovel, bool chkEvento, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT s.*, i.codigoimovel as codigoimovel, e.descricao as desc_evento " +
                                " from evt_sublocacao s " +
                                " left join evt_evento e on e.idevt_evento = s.idevt_evento " + 
                                " left join imovel i on i.idimovel = e.idimovel ";


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

                if (idEvento > 0 && !chkEvento)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " e.idevt_evento = @idevt_evento ";
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
                    strSQL += " datainicio >= @datainicial and datafinal <= @datafinal ";
                }


                //strSQL += " order by idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", idEvento);
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

        public DataTable dstRelatorioSubLocImovel(string codigoImovel, int idEvento, bool chkImovel, bool chkEvento)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro

                string strSQL = "SELECT e.*, t.descricao as tipoimovel, i.codigoimovel as codigoimovel, e.descricao as desc_evento" +
                               " from evt_evento e " +
                               " left join imovel i on i.idimovel = e.idimovel " +
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

                if (idEvento > 0 && !chkEvento)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " idevt_evento = @idevt_evento ";
                }

                //strSQL += " order by idimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", idEvento);

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

        public SubLocacao ObterPor(SubLocacao oSubLocacao)
        {
            MySqlDataReader drCon;
            SubLocacao objRetorno = new SubLocacao();
            Boolean bControle = false;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oSubLocacao.idSublocacao > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from evt_sublocacao Where idevt_sublocacao = " + oSubLocacao.idSublocacao + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        bControle = true;
                        objRetorno.idSublocacao = EmcResources.cInt(drCon["idevt_sublocacao"].ToString());
                        objRetorno.descricao = drCon["descricao"].ToString();

                        Evento oEvento = new Evento();
                        oEvento.idEvento = EmcResources.cInt(drCon["idevt_evento"].ToString());
                        objRetorno.evento = oEvento;

                        objRetorno.idBox = drCon["idbox"].ToString();
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (bControle)
                    {
                        EventoDAO oEventoDAO = new EventoDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.evento = oEventoDAO.ObterPor(objRetorno.evento);                        
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

        private void geraOcorrencia(SubLocacao oSubLocacao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oSubLocacao.idSublocacao.ToString();

                if (flag == "A")
                {

                    SubLocacao oSubLoc = new SubLocacao();
                    oSubLoc = ObterPor(oSubLocacao);

                    if (!oSubLoc.Equals(oSubLocacao))
                    {
                        descricao = "SubLocação id: " + oSubLocacao.idSublocacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oSubLoc.descricao.Equals(oSubLocacao.descricao))
                        {
                            descricao += " Descrição de " + oSubLoc.descricao + " para " + oSubLocacao.descricao;
                        }                        
                        if (!oSubLoc.evento.idEvento.Equals(oSubLocacao.evento.idEvento))
                        {
                            descricao += " Evento de " + oSubLoc.evento.idEvento + " para " + oSubLocacao.evento.idEvento;
                        }
                        if (!oSubLoc.idBox.Equals(oSubLocacao.idBox))
                        {
                            descricao += " idBox de " + oSubLoc.idBox + " para " + oSubLocacao.idBox;
                        }


                    }
                }
                else if (flag == "I")
                {
                    descricao = "SubLocação : " + oSubLocacao.idSublocacao +
                        " Descrição: " + oSubLocacao.descricao +
                        " Evento: " + oSubLocacao.evento.idEvento +
                        " Box: " + oSubLocacao.idBox +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "SubLocação : " + oSubLocacao.idSublocacao +
                        " Descrição: " + oSubLocacao.descricao +
                        " Evento: " + oSubLocacao.evento.idEvento +
                        " Box: " + oSubLocacao.idBox +
                        " foi exluido por " + oOcorrencia.usuario.nome;
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
