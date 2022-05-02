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
    public class FeriadoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FeriadoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia,int idEmpresa)
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
                codEmpresa = idEmpresa;
            }

        }

        public void Salvar(Feriado objFeriado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Feriado
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'feriado'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objFeriado.idFeriado = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objFeriado, "I");


                //Monta comando para a gravação do registro
                String strSQL = "insert into Feriado ( dataferiado, descricao) values (@dataferiado, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@dataFeriado", objFeriado.dataFeriado);
                Sqlcon.Parameters.AddWithValue("@descricao", objFeriado.descricao);
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

        public void Atualizar(Feriado objFeriado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Feriado
            try
            {
                geraOcorrencia(objFeriado, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Feriado set dataferiado=@dataferiado, descricao = @descricao where idFeriados = @idFeriado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFeriado", objFeriado.idFeriado);
                Sqlcon.Parameters.AddWithValue("@dataferiado", objFeriado.dataFeriado);
                Sqlcon.Parameters.AddWithValue("@descricao", objFeriado.descricao);
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

        public void Excluir(Feriado objFeriado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Feriado
            try
            {
                geraOcorrencia(objFeriado, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Feriado where idFeriados = @idFeriado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFeriado", objFeriado.idFeriado);

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

        public DataTable ListaFeriado()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from Feriado order by dataferiado desc";
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

        public bool dataFeriado(DateTime data)
        {
            Feriado oFeriado = new Feriado();
            oFeriado.dataFeriado = data;
            oFeriado = ObterPor(oFeriado);
            if (String.IsNullOrEmpty(oFeriado.descricao))
                return false;

            return true;

        }

        public Feriado ObterPor(Feriado oFeriado)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Feriado Where dataferiado=@dataferiado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@dataferiado", oFeriado.dataFeriado);
 
                drCon = Sqlcon.ExecuteReader();
             
                Feriado objFeriado = new Feriado();

                while (drCon.Read())
                {
                
                    objFeriado.idFeriado = Convert.ToInt32(drCon["idFeriados"].ToString());
                    objFeriado.dataFeriado = Convert.ToDateTime(drCon["dataferiado"].ToString());
                    objFeriado.descricao = drCon["descricao"].ToString();
                
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                return objFeriado;
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

        private void geraOcorrencia(Feriado oFeriado, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFeriado.idFeriado.ToString();

                if (flag == "A")
                {

                    Feriado oFer = new Feriado();
                    oFer = ObterPor(oFeriado);

                    if (!oFer.Equals(oFeriado))
                    {
                        descricao = "Feriado " + oFeriado.idFeriado + " - " + oFeriado.dataFeriado + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oFer.descricao.Equals(oFeriado.descricao))
                        {
                            descricao += " Descricao de " + oFer.descricao + " para " + oFeriado.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Feriado " + oFeriado.idFeriado + " - " + oFeriado.dataFeriado + " - " + oFeriado.descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Feriado " + oFeriado.idFeriado + " - " + oFeriado.dataFeriado + " - " + oFeriado.descricao + " foi excluida por " + oOcorrencia.usuario.nome;
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
