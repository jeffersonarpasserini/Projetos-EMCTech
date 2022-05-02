using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCEstoqueModel;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;


namespace EMCEstoqueDAO
{
    public class Estq_AlmoxarifadoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_AlmoxarifadoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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

        public void Salvar(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Estq_Almoxarifado'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Almoxarifado.idestq_almoxarifado = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Almoxarifado, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Estq_Almoxarifado (empresa_idEmpresa, descricao) values (@empresa_idEmpresa, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@empresa_idEmpresa", objEstq_Almoxarifado.Empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Almoxarifado.descricao);
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

        public void Atualizar(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Almoxarifado, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Estq_Almoxarifado set empresa_idEmpresa = @empresa_idEmpresa, descricao = @descricao where idEstq_Almoxarifado = @idEstq_Almoxarifado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Almoxarifado", objEstq_Almoxarifado.idestq_almoxarifado);
                Sqlcon.Parameters.AddWithValue("@empresa_idEmpresa", objEstq_Almoxarifado.Empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Almoxarifado.descricao);
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

        public void Excluir(Estq_Almoxarifado objEstq_Almoxarifado)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Almoxarifado, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Estq_Almoxarifado where idEstq_Almoxarifado = @idEstq_Almoxarifado";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Almoxarifado", objEstq_Almoxarifado.idestq_almoxarifado);

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

        public DataTable ListaEstq_Almoxarifado(String pEmpresa)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select E.* from Estq_Almoxarifado E where E.empresa_idempresa = @empresa_idEmpresa order by E.descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@empresa_idempresa", Convert.ToInt32(pEmpresa));

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

        public Estq_Almoxarifado ObterPor(Estq_Almoxarifado oEstq_Almoxarifado)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Estq_Almoxarifado Where idEstq_Almoxarifado = @idEstq_Almoxarifado and empresa_idempresa=@idempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Almoxarifado", oEstq_Almoxarifado.idestq_almoxarifado);
                Sqlcon.Parameters.AddWithValue("@idempresa", codEmpresa);


                drCon = Sqlcon.ExecuteReader();
                Estq_Almoxarifado objEstq_Almoxarifado = new Estq_Almoxarifado();

                while (drCon.Read())
                {

                    objEstq_Almoxarifado.idestq_almoxarifado = Convert.ToInt32(drCon["idEstq_Almoxarifado"].ToString());
                    objEstq_Almoxarifado.descricao = drCon["descricao"].ToString();

                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = Convert.ToInt32(drCon["empresa_idempresa"].ToString());

                    drCon.Close();
                    drCon.Dispose();


                    EmpresaDAO oEmpresaDAO = new EmpresaDAO(parConexao, oOcorrencia);
                    objEstq_Almoxarifado.Empresa = oEmpresaDAO.ObterPor(oEmpresa);

                    return objEstq_Almoxarifado;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Almoxarifado objEstq_Almoxarifado1 = new Estq_Almoxarifado();
                return objEstq_Almoxarifado1;

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

        private void geraOcorrencia(Estq_Almoxarifado oEstq_Almoxarifado, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Almoxarifado.idestq_almoxarifado.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Almoxarifado oCobr = new Estq_Almoxarifado();
                    oCobr = ObterPor(oEstq_Almoxarifado);

                    if (!oCobr.Equals(oEstq_Almoxarifado))
                    {
                        descricao = "Almoxarifado id: " + oEstq_Almoxarifado.idestq_almoxarifado + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oEstq_Almoxarifado.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oEstq_Almoxarifado.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Almoxarifado : " + oEstq_Almoxarifado.idestq_almoxarifado + " - " + oEstq_Almoxarifado.descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Almoxarifado : " + oEstq_Almoxarifado.idestq_almoxarifado + " - " + oEstq_Almoxarifado.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaAlmoxarifado(int empMaster, int idEstqAlmoxarifado, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select a.* from estq_almoxarifado a where empresa_idempresa=@codempresa ";

                if (idEstqAlmoxarifado > 0)
                {
                    strSQL += " and ";
                   
                    strSQL += " a.idEstq_Almoxarifado = @idestqalmoxarifado ";
                }

                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                   strSQL += " and ";
                   
                    strSQL += " a.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idestqalmoxarifado", idEstqAlmoxarifado);
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
