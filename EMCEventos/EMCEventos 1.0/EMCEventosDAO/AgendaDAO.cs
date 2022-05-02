using EMCCadastroModel;
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
    public class AgendaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public AgendaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Agenda objAgenda, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                if (objAgenda.flag == "I")
                {
                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                        "where a.table_name = 'evt_agenda'" +
                                        "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();


                    while (drCon.Read())
                    {
                        objAgenda.idAgenda = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }
                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(objAgenda, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into evt_agenda (dataagenda, situacao, idimovel, idevt_evento) " +
                                    " values (@dataagenda, @situacao, @idimovel, @idevt_evento)";


                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);

                    SqlconPar.Parameters.AddWithValue("@dataagenda", objAgenda.dataAgenda);
                    SqlconPar.Parameters.AddWithValue("@situacao", objAgenda.situacao);
                    SqlconPar.Parameters.AddWithValue("@idimovel", objAgenda.imovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@idevt_evento", objAgenda.evento.idEvento);


                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();
                }
                else if (objAgenda.flag == "A")
                {
                    geraOcorrencia(objAgenda, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update evt_agenda set dataagenda = @dataagenda, situacao = @situacao, idimovel = @idimovel, idevt_evento = @idevt_evento " +
                                    " where idevt_agenda = @idevt_agenda";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idevt_agenda", objAgenda.idAgenda);
                    SqlconPar.Parameters.AddWithValue("@dataagenda", objAgenda.dataAgenda);
                    SqlconPar.Parameters.AddWithValue("@situacao", objAgenda.situacao);
                    SqlconPar.Parameters.AddWithValue("@idimovel", objAgenda.imovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@idevt_evento", objAgenda.evento.idEvento);

                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }
                else if (objAgenda.flag == "E")
                {
                    geraOcorrencia(objAgenda, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "delete from evt_agenda where idevt_agenda = @idevt_agenda";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idevt_agenda", objAgenda.idAgenda);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }       

        public List<Agenda> ListaCalendario(DateTime? dataAgenda)
        {
            bool consulta = false;
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                String strSQL = "SELECT a.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                               " from evt_agenda a " +
                               " left join imovel im on im.idimovel = a.idimovel " +
                               " left join tipoimovel t on t.idtipoimovel = im.idtipoimovel " +
                               " left join evt_evento e on e.idevt_evento = a.idevt_evento ";

                if (dataAgenda != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    //else
                    //    strSQL += " and ";
                    strSQL += " dataagenda = @dataagenda ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@dataagenda", dataAgenda);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<Agenda> listaAgenda = new List<Agenda>();
                List<Agenda> lstRetorno = new List<Agenda>();


                Agenda objAgenda;

                while (drCon.Read())
                {
                    consulta = true;
                    objAgenda = new Agenda();

                    objAgenda.idAgenda = EmcResources.cInt(drCon["idevt_agenda"].ToString());

                    listaAgenda.Add(objAgenda);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (Agenda oAgenda in listaAgenda)
                    {
                        Agenda obAgenda = new Agenda();
                        obAgenda = ObterPor(oAgenda);

                        lstRetorno.Add(obAgenda);
                    }
                }

                return lstRetorno;

            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<Agenda> lstAgenda(int idEvento)
        {
            bool consulta = false;
            try
            {             

                String strSQL = "select * from evt_agenda Where idevt_evento = @idevt_evento";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_evento", idEvento);


                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<Agenda> listaAgenda = new List<Agenda>();
                List<Agenda> lstRetorno = new List<Agenda>();


                Agenda objAgenda;

                while (drCon.Read())
                {
                    consulta = true;
                    objAgenda = new Agenda();

                    objAgenda.idAgenda = EmcResources.cInt(drCon["idevt_agenda"].ToString());

                    listaAgenda.Add(objAgenda);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (Agenda oAgenda in listaAgenda)
                    {
                        Agenda obAgenda = new Agenda();
                        obAgenda = ObterPor(oAgenda);

                        lstRetorno.Add(obAgenda);
                    }
                }

                return lstRetorno;

            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public List<Agenda> listAgendaGrid(int idEvento, int idImovel, string codigoImovel, DateTime? dataInicio, DateTime? dataFinal)
        {
            bool consulta = false;
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro 
                String strSQL = "SELECT a.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel " +
                               " from evt_agenda a " +
                               " left join imovel im on im.idimovel = a.idimovel " +
                               " left join tipoimovel t on t.idtipoimovel = im.idtipoimovel " +
                               " left join evt_evento e on e.idevt_evento = a.idevt_evento ";

                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " im.codigoimovel = @codigoimovel ";
                }
                if (dataInicio != null && dataFinal != null)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " e.datainicio >= @datainicio and e.datafinal <= @datafinal ";
                }


                strSQL += " order by dataagenda desc, codigoimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);
                Sqlcon.Parameters.AddWithValue("@datainicio", dataInicio);
                Sqlcon.Parameters.AddWithValue("@datafinal", dataFinal);


                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<Agenda> lstAgenda = new List<Agenda>();
                List<Agenda> lstRetorno = new List<Agenda>();


                Agenda objAgenda;

                while (drCon.Read())
                {
                    consulta = true;
                    objAgenda = new Agenda();

                    objAgenda.idAgenda = EmcResources.cInt(drCon["idevt_agenda"].ToString());
                    objAgenda.dataAgenda = Convert.ToDateTime(drCon["dataagenda"].ToString());

                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objAgenda.imovel = oImovel;

                    Evento oEvento = new Evento();
                    oEvento.idEvento = EmcResources.cInt(drCon["idevt_evento"].ToString());
                    objAgenda.evento = oEvento;

                    objAgenda.situacao = drCon["situacao"].ToString();

                    lstAgenda.Add(objAgenda);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (Agenda oAgenda in lstAgenda)
                    {
                        Agenda obAgenda = new Agenda();
                        obAgenda = ObterPor(oAgenda);

                        lstRetorno.Add(obAgenda);
                    }
                }

                return lstRetorno;

            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }
               
        public DataTable dstRelatorioEvento(int idImovel, string codigoImovel, int idEvento, string descEvento, bool chkImovel, bool chkEvento, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT a.*, t.descricao as tipoimovel, im.codigoimovel as codigoimovel, e.descricao as desc_evento " +
                                " from evt_agenda a " +
                                " left join evt_evento e on e.idevt_evento = a.idevt_evento " +
                                " left join imovel im on im.idimovel = a.idimovel " +
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
                    strSQL += " dataagenda >= @datainicial and dataagenda <= @datafinal ";
                }


                strSQL += " order by dataagenda, codigoimovel ";

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

        public Agenda ObterPor(Agenda oAgenda)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from evt_agenda Where idevt_agenda = @idevt_agenda";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_agenda", oAgenda.idAgenda);


                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Agenda objAgenda = new Agenda();

                while (drCon.Read())
                {
                    consulta = true;
                    objAgenda.idAgenda = EmcResources.cInt(drCon["idevt_agenda"].ToString());

                    Evento oEvento = new Evento();
                    oEvento.idEvento = EmcResources.cInt(drCon["idevt_evento"].ToString());
                    objAgenda.evento = oEvento;

                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objAgenda.imovel = oImovel;

                    objAgenda.dataAgenda = Convert.ToDateTime(drCon["dataagenda"].ToString());
                    objAgenda.situacao = drCon["situacao"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ImovelDAO oImovDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                    objAgenda.imovel = oImovDAO.ObterPor(objAgenda.imovel);

                    EventoDAO oEventoDAO = new EventoDAO(parConexao, oOcorrencia, codEmpresa);
                    objAgenda.evento = oEventoDAO.ObterPorLstEvento(objAgenda.evento);

                }
                return objAgenda;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public Agenda ObterPor(int idImovel, DateTime dataEvento)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from evt_agenda Where idimovel = @idimovel and dataagenda=@dataagenda";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", idImovel);
                Sqlcon.Parameters.AddWithValue("@dataagenda", dataEvento);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Agenda objAgenda = new Agenda();

                while (drCon.Read())
                {
                    consulta = true;
                    objAgenda.idAgenda = EmcResources.cInt(drCon["idevt_agenda"].ToString());
                    //objAgenda.imovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                objAgenda = ObterPor(objAgenda);


                return objAgenda;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(Agenda oAgenda, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oAgenda.idAgenda.ToString();

                if (flag == "A")
                {

                    Agenda oAgd = new Agenda();
                    oAgd = ObterPor(oAgenda);

                    if (!oAgd.Equals(oAgenda))
                    {
                        descricao = "Agenda id: " + oAgenda.idAgenda + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        //if (!oAgd.situacao.Equals(oAgenda.situacao))
                        //{
                        //    descricao += " Situação de " + oAgd.situacao + " para " + oAgenda.situacao;
                        //}

                        if (!oAgd.dataAgenda.Equals(oAgenda.dataAgenda))
                        {
                            descricao += " Data Agenda de " + oAgd.dataAgenda + " para " + oAgenda.dataAgenda;
                        }
                        //if (!oAgd.imovel.idImovel.Equals(oAgenda.imovel.idImovel))
                        //{
                        //    descricao += " Imóvel de " + oAgd.imovel.idImovel + " para " + oAgenda.imovel.idImovel;
                        //}
                        //if (!oAgd.evento.idEvento.Equals(oAgenda.evento.idEvento))
                        //{
                        //    descricao += " Evento de " + oAgd.evento.idEvento + " para " + oAgenda.evento.idEvento;
                        //}



                    }
                }
                else if (flag == "I")
                {
                    descricao = "Agenda : " + oAgenda.idAgenda +
                        " Situação: " + oAgenda.situacao +
                        " Data Agenda: " + oAgenda.dataAgenda +
                        " Imóvel: " + oAgenda.imovel.idImovel +
                        " Evento: " + oAgenda.evento.idEvento +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Agenda : " + oAgenda.idAgenda +
                        " Situação: " + oAgenda.situacao +
                        " Data Agenda: " + oAgenda.dataAgenda +
                        " Imóvel: " + oAgenda.imovel.idImovel +
                        " Evento: " + oAgenda.evento.idEvento +
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
