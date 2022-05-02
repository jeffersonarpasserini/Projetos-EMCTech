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
    public class Obra_TipoContratoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_TipoContratoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Obra_TipoContrato objObra_TipoContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'obra_tipocontrato'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objObra_TipoContrato.idObra_TipoContrato = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objObra_TipoContrato, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into obra_tipocontrato ( descricao ) values (@descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_TipoContrato.descricao);
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

        public void Atualizar(Obra_TipoContrato objObra_TipoContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra_TipoContrato, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update obra_tipocontrato set descricao = @descricao where idObra_TipoContrato = @idObra_TipoContrato";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idObra_TipoContrato", objObra_TipoContrato.idObra_TipoContrato);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra_TipoContrato.descricao);
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

        public void Excluir(Obra_TipoContrato objObra_TipoContrato)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objObra_TipoContrato, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from obra_tipocontrato where idObra_TipoContrato = @idObra_TipoContrato";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idObra_TipoContrato", objObra_TipoContrato.idObra_TipoContrato);

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

        public List<Obra_TipoContrato> LstObra_TipoContrato()
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_tipocontrato order by idObra_TipoContrato";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                
                drCon = Sqlcon.ExecuteReader();

                List<Obra_TipoContrato> lstEtapa = new List<Obra_TipoContrato>();

                while (drCon.Read())
                {
                    Obra_TipoContrato objObra_TipoContrato = new Obra_TipoContrato();
                    objObra_TipoContrato.idObra_TipoContrato = Convert.ToInt32(drCon["idObra_TipoContrato"].ToString());
                    objObra_TipoContrato.descricao = drCon["descricao"].ToString();

                    lstEtapa.Add(objObra_TipoContrato);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return lstEtapa;
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

        public DataTable ListaObra_TipoContrato()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_tipocontrato order by descricao";
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

        public Obra_TipoContrato ObterPor(Obra_TipoContrato oObra_TipoContrato)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_tipocontrato Where idObra_TipoContrato=@idObra_TipoContrato";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idObra_TipoContrato", oObra_TipoContrato.idObra_TipoContrato);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Obra_TipoContrato objObra_TipoContrato = new Obra_TipoContrato();
                    objObra_TipoContrato.idObra_TipoContrato = Convert.ToInt32(drCon["idObra_TipoContrato"].ToString());
                    objObra_TipoContrato.descricao = drCon["descricao"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    return objObra_TipoContrato;
                }

                drCon.Close();
                drCon.Dispose();
                Obra_TipoContrato objObra_TipoContrato1 = new Obra_TipoContrato();
                return objObra_TipoContrato1;

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

        private void geraOcorrencia(Obra_TipoContrato oObra_TipoContrato, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oObra_TipoContrato.idObra_TipoContrato.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra_TipoContrato oCobr = new Obra_TipoContrato();
                    oCobr = ObterPor(oObra_TipoContrato);

                    if (!oCobr.Equals(oObra_TipoContrato))
                    {
                        descricao = "Tipo Contrato Obra id: " + oObra_TipoContrato.idObra_TipoContrato + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oObra_TipoContrato.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oObra_TipoContrato.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Tipo Contrato Obra : " + oObra_TipoContrato.idObra_TipoContrato + " - " + oObra_TipoContrato.descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Tipo Contrato Obra : " + oObra_TipoContrato.idObra_TipoContrato + " - " + oObra_TipoContrato.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaObraTipoContrato(int empMaster, int idObraTipoContrato, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select oe.* from obra_tipocontrato oe ";

                if (idObraTipoContrato > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " oe.idObra_TipoContrato = @idobraetapa ";
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

                    strSQL += " oe.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobraetapa", idObraTipoContrato);
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
