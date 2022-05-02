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
using System.Threading.Tasks;

namespace EMCEventosDAO
{
    public class EventoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public EventoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Evento objEvento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                Salvar(Conexao, transacao, objEvento);
                //transacao.Commit();
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

        public void Salvar(MySqlConnection Conecta, MySqlTransaction transacao, Evento objEvento)
        {
            //MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'evt_evento'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();


                while (drCon.Read())
                {
                    objEvento.idEvento = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objEvento, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into evt_evento (descricao, datainicio, datafinal, idimovel, statusevento) " +
                                " values (@descricao, @datainicio, @datafinal, @idimovel, @statusevento)";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);

                Sqlcon.Parameters.AddWithValue("@descricao", objEvento.descricao);
                Sqlcon.Parameters.AddWithValue("@datainicio", objEvento.dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", objEvento.dataFinal);
                Sqlcon.Parameters.AddWithValue("@idimovel", objEvento.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@statusevento", objEvento.statusEvento);


                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
                transacao.Commit();

                AgendaDAO oAgendaDAO = new AgendaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (Agenda objAgenda in objEvento.lstAgenda)
                {
                    if (objAgenda.evento.idEvento <= 0)
                    {
                        objAgenda.evento = objEvento;
                    }
                    oAgendaDAO.Salvar(objAgenda, Conecta, transacao);
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
           
        }

        public void Atualizar(Evento objEvento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {
                Atualizar(Conexao, transacao, objEvento);

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

        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, Evento objEvento)
        {
            //MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEvento, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update evt_evento set descricao = @descricao, datainicio = @datainicio, datafinal = @datafinal, " +
                                " idimovel = @idimovel, statusevento = @statusevento  where idevt_evento = @idevt_evento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", objEvento.idEvento);
                Sqlcon.Parameters.AddWithValue("@descricao", objEvento.descricao);
                Sqlcon.Parameters.AddWithValue("@datainicio", objEvento.dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", objEvento.dataFinal);
                Sqlcon.Parameters.AddWithValue("@idimovel", objEvento.imovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@statusevento", objEvento.statusEvento);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
                //transacao.Commit();

                AgendaDAO oAgendaDAO = new AgendaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (Agenda objAgenda in objEvento.lstAgenda)
                {
                    if (objAgenda.evento.idEvento <= 0)
                    {
                        objAgenda.evento = objEvento;
                    }
                    oAgendaDAO.Salvar(objAgenda, Conecta, transacao);
                }

            }
            catch (MySqlException erro)
            {               
                throw erro;
            }
        }

        public void Excluir(Evento objEvento)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {
                Excluir(Conexao, transacao, objEvento);

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

        public void Excluir(MySqlConnection Conecta, MySqlTransaction transacao, Evento objEvento)
        {
            //MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {

                AgendaDAO oAgendaDAO = new AgendaDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (Agenda objAgenda in objEvento.lstAgenda)
                {
                    if (objAgenda.evento.idEvento <= 0)
                    {
                        objAgenda.evento = objEvento;
                    }
                    oAgendaDAO.Salvar(objAgenda, Conecta, transacao);
                }

                geraOcorrencia(objEvento, "E");

                //Monta comando para a gravação do registro 
                String strSQL = "delete from evt_evento where idevt_evento = @idevt_evento";

                //String strSQL = "update evt_evento set descricao = @descricao, datainicio = @datainicio, datafinal = @datafinal, " +
                //                " idimovel = @idimovel, statusevento = @statusevento  where idevt_evento = @idevt_evento";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", objEvento.idEvento);
                //Sqlcon.Parameters.AddWithValue("@descricao", objEvento.descricao);
                //Sqlcon.Parameters.AddWithValue("@datainicio", objEvento.dataInicio);
                //Sqlcon.Parameters.AddWithValue("@datafinal", objEvento.dataFinal);
                //Sqlcon.Parameters.AddWithValue("@idimovel", objEvento.imovel.idImovel);
                //Sqlcon.Parameters.AddWithValue("@statusevento", objEvento.statusEvento);


                Sqlcon.ExecuteNonQuery();
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
                //transacao.Commit();



            }
            catch (MySqlException erro)
            {
                //transacao.Rollback();
                throw erro;
            }
            //finally
            //{
            //    transacao.Dispose();
            //    transacao = null;
            //}

        }

        public DataTable pesquisaEvento(int empMaster, string codigoImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                // String strSQL = "select i.* from imovel i ";

                String strSQL = "SELECT e.*, im.codigoimovel as codigoimovel " +
                                " from evt_evento e " +
                                " left join imovel im on im.idimovel = e.idimovel " ;


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
                    strSQL += " datainicio >= @datainicial and datafinal <= @datafinal ";
                }

                strSQL += " order by datainicio, idimovel";

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

        public DataTable ListaEvento()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT e.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from evt_evento e " +
                                " left join imovel im on im.idimovel = e.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = im.idtipoimovel" +
                                " order by datainicio";

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

        public List<Evento> lstEvento(int idEvento, int idImovel, string codigoImovel)
        {
            bool consulta = false;
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro 
                String strSQL = "SELECT e.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from evt_evento e " +
                                " left join imovel im on im.idimovel = e.idimovel " +
                                " left join tipoimovel t on t.idtipoimovel = im.idtipoimovel ";

                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " im.codigoimovel = @codigoimovel ";
                }

                strSQL += " order by codigoimovel, idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);


                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<Evento> lstEvento = new List<Evento>();
                List<Evento> lstRetorno = new List<Evento>();


                Evento objEvento;

                while (drCon.Read())
                {
                    consulta = true;
                    objEvento = new Evento();

                    objEvento.idEvento = EmcResources.cInt(drCon["idevt_evento"].ToString());
                    objEvento.descricao = drCon["descricao"].ToString();
                    objEvento.dataInicio = Convert.ToDateTime(drCon["datainicio"].ToString());
                    objEvento.dataFinal = Convert.ToDateTime(drCon["datafinal"].ToString());

                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objEvento.imovel = oImovel;

                    objEvento.statusEvento = drCon["statusevento"].ToString();

                    lstEvento.Add(objEvento);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (Evento oEvento in lstEvento)
                    {
                        Evento obEvento = new Evento();
                        obEvento = ObterPor(oEvento);

                        lstRetorno.Add(obEvento);
                    }
                }

                return lstRetorno;

            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable dstRelatorioEvento(int idEvento, int idImovel, string codigoImovel, bool chkImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT e.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                                " from evt_evento e " +
                                " left join imovel im on im.idimovel = e.idimovel " +
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
                    strSQL += " datainicio >= @datainicial and datafinal <= @datafinal ";
                }


                strSQL += " order by idevt_evento ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
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

        public DataTable dstRelatorioImovel(int idEvento, int idImovel, string codigoImovel, bool chkImovel, DateTime? dataInicial, DateTime? dataFinal)
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

        public Evento ObterPor(Evento oEvento)
        {
            MySqlDataReader drCon;
            Evento objRetorno = new Evento();
            Boolean bControle = false;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oEvento.idEvento > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from evt_evento Where idevt_evento = " + oEvento.idEvento + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        bControle = true;
                        objRetorno.idEvento = EmcResources.cInt(drCon["idevt_evento"].ToString());
                        objRetorno.descricao = drCon["descricao"].ToString();
                        objRetorno.dataInicio = Convert.ToDateTime(drCon["datainicio"].ToString());
                        objRetorno.dataFinal = Convert.ToDateTime(drCon["datafinal"].ToString());

                        Imovel oImovel = new Imovel();
                        oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                        objRetorno.imovel = oImovel;

                        objRetorno.statusEvento = drCon["statusevento"].ToString();

                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (bControle)
                    {
                        ImovelDAO oImovelDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.imovel = oImovelDAO.ObterPor(objRetorno.imovel);

                        AgendaDAO oAgendaDAO = new AgendaDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.lstAgenda = oAgendaDAO.lstAgenda(objRetorno.idEvento);
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

        public Evento ObterPorLstEvento(Evento oEvento)
        {
            bool Consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from evt_evento Where idevt_evento = @idevt_evento ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", oEvento.idEvento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Evento objEvento = new Evento();


                while (drCon.Read())
                {
                    Consulta = true;
                    objEvento.idEvento = EmcResources.cInt(drCon["idevt_evento"].ToString());
                    objEvento.descricao = drCon["descricao"].ToString();
                    objEvento.dataInicio = Convert.ToDateTime(drCon["datainicio"].ToString());
                    objEvento.dataFinal = Convert.ToDateTime(drCon["datafinal"].ToString());

                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objEvento.imovel = oImovel;

                    objEvento.statusEvento = drCon["statusevento"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                return objEvento;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(Evento oEvento, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEvento.idEvento.ToString();

                if (flag == "A")
                {

                    Evento oEvt = new Evento();
                    oEvt = ObterPor(oEvento);

                    if (!oEvt.Equals(oEvento))
                    {
                        descricao = "Evento id: " + oEvento.idEvento + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oEvt.descricao.Equals(oEvento.descricao))
                        {
                            descricao += " Descrição de " + oEvt.descricao + " para " + oEvento.descricao;
                        }
                        if (!oEvt.dataInicio.Equals(oEvento.dataInicio))
                        {
                            descricao += " Data Inicio de " + oEvt.dataInicio + " para " + oEvento.dataInicio;
                        }
                        if (!oEvt.dataFinal.Equals(oEvento.dataFinal))
                        {
                            descricao += " Data Final de " + oEvt.dataFinal + " para " + oEvento.dataFinal;
                        }
                        if (!oEvt.imovel.idImovel.Equals(oEvento.imovel.idImovel))
                        {
                            descricao += " Imóvel de " + oEvt.imovel.idImovel + " para " + oEvento.imovel.idImovel;
                        }
                        if (!oEvt.statusEvento.Equals(oEvento.statusEvento))
                        {
                            descricao += " Status de " + oEvt.statusEvento + " para " + oEvento.statusEvento;
                        }


                    }
                }
                else if (flag == "I")
                {
                    descricao = "Evento : " + oEvento.idEvento +
                        " Descrição: " + oEvento.descricao +
                        " Data Início: " + oEvento.dataInicio +
                        " Data Final: " + oEvento.dataFinal +
                        " Imóvel: " + oEvento.imovel.idImovel +
                        " Status: " + oEvento.statusEvento +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Evento : " + oEvento.idEvento +
                        " Descrição: " + oEvento.descricao +
                        " Data Início: " + oEvento.dataInicio +
                        " Data Final: " + oEvento.dataFinal +
                        " Imóvel: " + oEvento.imovel.idImovel +
                        " Status: " + oEvento.statusEvento +
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
