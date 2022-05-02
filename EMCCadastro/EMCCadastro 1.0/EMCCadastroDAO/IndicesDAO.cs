using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCCadastroDAO
{
    public class IndicesDAO
    {
        ParametroBanco strConn = new ParametroBanco();

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IndicesDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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
        
        public void Salvar(Indices objIndices)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Indices
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'indices'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objIndices.idIndice = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objIndices, "I");               

                //Monta comando para a gravação do registro
                String strSQL = "insert into Indices ( idindexador, dataIndice, valor) values (@idindexador, @dataIndice, @valor)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idindexador", objIndices.indexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@dataIndice", objIndices.dataIndice);
                Sqlcon.Parameters.AddWithValue("@valor", objIndices.valor);
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

        public void Atualizar(Indices objIndices)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Indices
            try
            {

                geraOcorrencia(objIndices, "A");               

                //Monta comando para a gravação do registro
                String strSQL = "update Indices set valor = @valor, dataindice =@dataindice where idindexador=@idindexador and idIndices = @idIndices";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idIndices", objIndices.idIndice);
                Sqlcon.Parameters.AddWithValue("@idindexador", objIndices.indexador.idIndexador);
                Sqlcon.Parameters.AddWithValue("@valor", objIndices.valor);
                Sqlcon.Parameters.AddWithValue("@dataindice", objIndices.dataIndice);
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

        public void Excluir(Indices objIndices)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Indices
            try
            {
                geraOcorrencia(objIndices, "E");               

                //Monta comando para a gravação do registro
                String strSQL = "delete from Indices where idindexador=@idindexador and idIndices = @idIndices";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idIndices", objIndices.idIndice);
                Sqlcon.Parameters.AddWithValue("@idindexador", objIndices.indexador.idIndexador);
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

        public DataTable pesquisaIndice(int empMaster, int idindexador, DateTime dataindice, Decimal valor, bool ckData)
        {
            try
            {
                               
                String strSQL = "Select i.*, ind.descricao as descricaoindexador from indices i, indexador ind"
                                +" where i.idindexador = ind.idindexador";
                
                if (idindexador > 0)
                {
                    strSQL += " and i.idindexador =@idindexador"; 
                }
                if (ckData)
                {
                    strSQL += " and i.dataindice =@dataindice";
                }
                if (valor > 0)
                {
                    strSQL += " and i.valor =@valor";
                }
                strSQL += " order by ind.descricao, i.dataindice";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idindexador", idindexador);
                Sqlcon.Parameters.AddWithValue("@dataindice", dataindice);
                Sqlcon.Parameters.AddWithValue("@valor", valor);
                

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

        public DataTable ListaIndices(Indexador oIndice)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select i.*, ind.descricao as descricaoindexador from indices i, indexador ind "
                                + " Where i.idindexador=ind.idindexador and i.idindexador =@idindexador order by dataIndice desc";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idindexador", oIndice.idIndexador);


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
        public Indices ObterPor(int idIndexador, DateTime dataIndice, Boolean obterUltimoIndice)
        {
            MySqlDataReader drCon;
            try
            {

                if (!obterUltimoIndice)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from Indices Where idindexador=@idindexador and dataindice=@data";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idindexador", idIndexador);
                    Sqlcon.Parameters.AddWithValue("@data", dataIndice);

                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select max(dataindice) as dataindice,valor,idindexador,idindices from Indices Where idindexador=@idindexador";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idindexador", idIndexador);
                    
                    drCon = Sqlcon.ExecuteReader();

                }
                bool bConsulta = false;
                Indices objIndices = new Indices();

                while (drCon.Read())
                {
                    bConsulta = true;

                    objIndices.idIndice = Convert.ToInt32(drCon["idIndices"].ToString());
                    objIndices.dataIndice = Convert.ToDateTime(drCon["dataIndice"].ToString());
                    objIndices.valor = Convert.ToDecimal(drCon["valor"].ToString());

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = EmcResources.cInt(drCon["idIndexador"].ToString());
                    objIndices.indexador = oIndexador;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bConsulta)
                {
                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia, codEmpresa);
                    objIndices.indexador = oIndexadorDAO.ObterPor(objIndices.indexador);
                }

                return objIndices;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public Indices ObterPor(Indices oIndices)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Indices Where idindices=@idindices";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idIndices", oIndices.idIndice);
                Sqlcon.Parameters.AddWithValue("@dataindice", oIndices.dataIndice);
                Sqlcon.Parameters.AddWithValue("@valor", oIndices.valor);
                                
                drCon = Sqlcon.ExecuteReader();

                bool bConsulta = false;
                Indices objIndices = new Indices();

                while (drCon.Read())
                {
                    bConsulta = true;

                
                    objIndices.idIndice = Convert.ToInt32(drCon["idIndices"].ToString());
                    objIndices.dataIndice = Convert.ToDateTime(drCon["dataIndice"].ToString());
                    objIndices.valor = Convert.ToDecimal(drCon["valor"].ToString());

                    Indexador oIndexador = new Indexador();
                    oIndexador.idIndexador = EmcResources.cInt(drCon["idIndexador"].ToString());
                    objIndices.indexador = oIndexador;

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bConsulta)
                {
                    IndexadorDAO oIndexadorDAO = new IndexadorDAO(parConexao, oOcorrencia,codEmpresa);
                    objIndices.indexador = oIndexadorDAO.ObterPor(objIndices.indexador);
                }

                return objIndices;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        
        private void geraOcorrencia(Indices oIndice, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario=oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oIndice.idIndice.ToString();

                if (flag == "A")
                {
            
                    Indices oInd = new Indices();
                    oInd = ObterPor(oIndice);

                    if (!oInd.Equals(oIndice))
                    {
                        descricao = "Indice : " + oIndice.indexador.idIndexador+"-"+oIndice.indexador.descricao+" - de :" + oIndice.dataIndice + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oInd.valor.Equals(oIndice.valor))
                        {
                            descricao += " Valor de " + oInd.valor + " para " + oIndice.valor;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Indice "+ oIndice.indexador.idIndexador+"-"+oIndice.indexador.descricao+" - de :" + oIndice.dataIndice  + " no valor de " + oIndice.valor + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Indice " + oIndice.indexador.idIndexador + "-" + oIndice.indexador.descricao + " - de :" + oIndice.dataIndice + " no valor de " + oIndice.valor + " foi excluida por " + oOcorrencia.usuario.nome;
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
