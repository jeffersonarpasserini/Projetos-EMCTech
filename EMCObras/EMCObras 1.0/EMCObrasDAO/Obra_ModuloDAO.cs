using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCObrasModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCObrasDAO
{
    public class Obra_ModuloDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_ModuloDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
                codEmpresa = idEmpresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
            }
            codEmpresa = idEmpresa;
        }

        public void Salvar(Obra_Modulo objObra_Modulo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'obra_modulo'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objObra_Modulo.idobra_modulo = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objObra_Modulo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into obra_modulo (obra_etapa_idobra_etapa, descricao) values (@obra_etapa_idobra_etapa, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@obra_etapa_idobra_etapa", objObra_Modulo.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_Modulo.descricao);
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

        public void Atualizar(Obra_Modulo objObra_Modulo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra_Modulo, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update obra_modulo set obra_etapa_idobra_etapa = @obra_etapa_idobra_etapa, descricao = @descricao where idobra_modulo = @idobra_modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", objObra_Modulo.idobra_modulo);
                Sqlcon.Parameters.AddWithValue("@obra_etapa_idobra_etapa", objObra_Modulo.obra_etapa.idobra_etapa);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_Modulo.descricao);
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

        public void Excluir(Obra_Modulo objObra_Modulo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objObra_Modulo, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from obra_modulo where idobra_modulo = @idobra_modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", objObra_Modulo.idobra_modulo);

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
        public List<Obra_Modulo> LstObra_Modulo(Obra_Etapa oEtapa)
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_modulo where obra_etapa_idobra_etapa=@obra_etapa_idobra_etapa order by idobra_modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@obra_etapa_idobra_etapa", oEtapa.idobra_etapa);
                drCon = Sqlcon.ExecuteReader();

                List<Obra_Modulo> lstModulo = new List<Obra_Modulo>();

                while (drCon.Read())
                {
                    Obra_Modulo objObra_Modulo = new Obra_Modulo();

                    objObra_Modulo.idobra_modulo = EmcResources.cInt(drCon["idobra_modulo"].ToString());
                    objObra_Modulo.obra_etapa = oEtapa;
                    objObra_Modulo.descricao = drCon["descricao"].ToString();

                    lstModulo.Add(objObra_Modulo);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return lstModulo;
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
        public DataTable ListaObra_Modulo()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select M.*, E.Descricao as Obra_Etapa_Descricao from Obra_Modulo M, Obra_Etapa E where E.idobra_etapa = M.obra_etapa_idobra_etapa order by M.descricao";
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

        public Obra_Modulo ObterPor(Obra_Modulo oObra_Modulo)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_modulo Where idobra_modulo = @idobra_modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_modulo", oObra_Modulo.idobra_modulo);


                drCon = Sqlcon.ExecuteReader();
                Obra_Modulo objObra_Modulo = new Obra_Modulo();

                while (drCon.Read())
                {

                    objObra_Modulo.idobra_modulo = Convert.ToInt32(drCon["idobra_modulo"].ToString());
                    objObra_Modulo.descricao = drCon["descricao"].ToString();

                    Obra_Etapa oObra_Etapa = new Obra_Etapa();
                    oObra_Etapa.idobra_etapa = Convert.ToInt32(drCon["obra_etapa_idobra_etapa"].ToString());

                    drCon.Close();
                    drCon.Dispose();


                    Obra_EtapaDAO oObra_EtapaDAO = new Obra_EtapaDAO(parConexao, oOcorrencia,codEmpresa);
                    objObra_Modulo.obra_etapa = oObra_EtapaDAO.ObterPor(oObra_Etapa);
                    
                    return objObra_Modulo;
                }
                
                                
                drCon.Close();
                drCon.Dispose();
                Obra_Modulo objObra_Modulo1 = new Obra_Modulo();
                return objObra_Modulo1;

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

        private void geraOcorrencia(Obra_Modulo oObra_Modulo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oObra_Modulo.idobra_modulo.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra_Modulo oCobr = new Obra_Modulo();
                    oCobr = ObterPor(oObra_Modulo);

                    if (!oCobr.Equals(oObra_Modulo))
                    {
                        descricao = "Modulo da Obra id: " + oObra_Modulo.idobra_modulo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oObra_Modulo.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oObra_Modulo.descricao;
                        }
                        if (!oCobr.obra_etapa.idobra_etapa.Equals(oObra_Modulo.obra_etapa.idobra_etapa))
                        {
                            descricao += " Etapa da Obra de " + oCobr.obra_etapa.idobra_etapa + "-" + oCobr.obra_etapa.descricao + " para " + oObra_Modulo.obra_etapa.idobra_etapa + "-" + oObra_Modulo.obra_etapa.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Modulo da Obra : " + oObra_Modulo.idobra_modulo + " - " + oObra_Modulo.descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Modulo da Obra : " + oObra_Modulo.idobra_modulo + " - " + oObra_Modulo.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaObraModulo(int empMaster, int idObraModulo, string descricaoModulo, int idObraEtapa, string descricaoEtapa)
        {
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select om.*, oe.Descricao as Obra_Etapa_Descricao from obra_modulo om, obra_etapa oe " +
                                " where oe.idobra_etapa = om.obra_etapa_idobra_etapa";

                if (idObraModulo > 0)
                {

                    strSQL += " and om.idobra_modulo = @idobramodulo ";

                }
                if (idObraEtapa > 0)
                {

                    strSQL += " and om.obra_etapa_idobra_etapa = @idobraetapa ";

                }

                if (!String.IsNullOrEmpty(descricaoModulo.Trim()))
                {

                    strSQL += " and om.descricao like @descricaomodulo ";
                }

                if (!String.IsNullOrEmpty(descricaoEtapa.Trim()))
                {

                    strSQL += " and oe.descricao like @descricaoetapa ";
                }

                strSQL += " order by om.descricao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobramodulo", idObraModulo);
                Sqlcon.Parameters.AddWithValue("@idobraetapa", idObraEtapa);
                Sqlcon.Parameters.AddWithValue("@descricaomodulo", "%" + descricaoModulo.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@descricaoetapa", "%" + descricaoEtapa.Trim() + "%");

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
