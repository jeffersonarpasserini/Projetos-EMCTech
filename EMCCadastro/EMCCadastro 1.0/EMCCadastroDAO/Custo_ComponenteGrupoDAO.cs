using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCCadastroModel;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCCadastroDAO
{
    public class Custo_ComponenteGrupoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Custo_ComponenteGrupoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'custo_componentegrupo'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";


                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objCusto_ComponenteGrupo.idcusto_componentegrupo = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objCusto_ComponenteGrupo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into custo_componentegrupo ( descricao ) values ( @descricao )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objCusto_ComponenteGrupo.descricao);
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

        public void Atualizar(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objCusto_ComponenteGrupo, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update custo_componentegrupo set descricao = @descricao where idcusto_componentegrupo = @idcusto_componentegrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcusto_componentegrupo", objCusto_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objCusto_ComponenteGrupo.descricao);
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

        public void Excluir(Custo_ComponenteGrupo objCusto_ComponenteGrupo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objCusto_ComponenteGrupo, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from custo_componentegrupo where idcusto_componentegrupo = @idcusto_componentegrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcusto_componentegrupo", objCusto_ComponenteGrupo.idcusto_componentegrupo);

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

        public DataTable ListaCusto_ComponenteGrupo()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from custo_componentegrupo order by descricao";
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

        public Custo_ComponenteGrupo ObterPor(Custo_ComponenteGrupo oCusto_ComponenteGrupo)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from custo_componentegrupo Where idcusto_componentegrupo = @idcusto_componentegrupo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcusto_componentegrupo", oCusto_ComponenteGrupo.idcusto_componentegrupo);


                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Custo_ComponenteGrupo objCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
                    objCusto_ComponenteGrupo.idcusto_componentegrupo = Convert.ToInt32(drCon["idcusto_componentegrupo"].ToString());
                    objCusto_ComponenteGrupo.descricao = drCon["descricao"].ToString();
                    
                    drCon.Close();
                    drCon.Dispose();
                    return objCusto_ComponenteGrupo;
                }

                drCon.Close();
                drCon.Dispose();
                Custo_ComponenteGrupo objCusto_ComponenteGrupo1 = new Custo_ComponenteGrupo();
                return objCusto_ComponenteGrupo1;

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

        private void geraOcorrencia(Custo_ComponenteGrupo oCusto_ComponenteGrupo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCusto_ComponenteGrupo.idcusto_componentegrupo.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Custo_ComponenteGrupo oCobr = new Custo_ComponenteGrupo();
                    oCobr = ObterPor(oCusto_ComponenteGrupo);

                    if (!oCobr.Equals(oCusto_ComponenteGrupo))
                    {
                        descricao = "Grupo de Componente de Custo id: " + oCusto_ComponenteGrupo.idcusto_componentegrupo + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oCusto_ComponenteGrupo.descricao))
                        {
                            descricao += " Descricao de " + oCobr.descricao + " para " + oCusto_ComponenteGrupo.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Grupo de Componente de Custo : " + oCusto_ComponenteGrupo.idcusto_componentegrupo + " - " + oCusto_ComponenteGrupo.descricao + " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Grupo de Componente de Custo : " + oCusto_ComponenteGrupo.idcusto_componentegrupo + " - " + oCusto_ComponenteGrupo.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaComponenteGrupo(int empMaster, int idComponenteGrupo, string descricao)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select cg.* from custo_componentegrupo cg ";

                if (idComponenteGrupo > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " cg.idcusto_componentegrupo = @idcustocomponentegrupo ";
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

                    strSQL += " cg.descricao like @descricao ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcustocomponentegrupo", idComponenteGrupo);
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
    }
}
