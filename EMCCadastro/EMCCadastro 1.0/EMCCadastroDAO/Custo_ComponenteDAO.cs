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
    public class Custo_ComponenteDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Custo_ComponenteDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = pOcorrencia;
                codEmpresa = idEmpresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = pOcorrencia;
                codEmpresa = idEmpresa;
            }

        }

        public void Salvar(Custo_Componente objCusto_Componente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Custo_Componente'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objCusto_Componente.idcusto_componente = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objCusto_Componente, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Custo_Componente (idgrupo_componente, descricao) values (@idgrupo_componente, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idgrupo_componente", objCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objCusto_Componente.descricao);
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

        public void Atualizar(Custo_Componente objCusto_Componente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objCusto_Componente, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Custo_Componente set idgrupo_componente = @idgrupo_componente, descricao = @descricao where idCusto_Componente = @idCusto_Componente";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idCusto_Componente", objCusto_Componente.idcusto_componente);
                Sqlcon.Parameters.AddWithValue("@idgrupo_componente", objCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo);
                Sqlcon.Parameters.AddWithValue("@descricao", objCusto_Componente.descricao);
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

        public void Excluir(Custo_Componente objCusto_Componente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objCusto_Componente, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Custo_Componente where idCusto_Componente = @idCusto_Componente";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idCusto_Componente", objCusto_Componente.idcusto_componente);

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

        public DataTable ListaCusto_Componente(int idGrupoComponente)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select CC.*, CCG.Descricao as CCG_Descricao " +
                                " from Custo_ComponenteGrupo CCG, Custo_Componente CC " +
                                " where CCG.idCusto_ComponenteGrupo = CC.idGrupo_Componente ";

               if (idGrupoComponente > 0)
                   strSQL += " and CC.idGrupo_Componente = @grupocomponente ";

                strSQL+= "order by CC.descricao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@grupocomponente", idGrupoComponente);

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

        public Custo_Componente ObterPor(Custo_Componente oCusto_Componente)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Custo_Componente Where idCusto_Componente = @idCusto_Componente";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idCusto_Componente", oCusto_Componente.idcusto_componente);


                drCon = Sqlcon.ExecuteReader();
                Custo_Componente objCusto_Componente = new Custo_Componente();

                while (drCon.Read())
                {

                    objCusto_Componente.idcusto_componente = Convert.ToInt32(drCon["idCusto_Componente"].ToString());
                    objCusto_Componente.descricao = drCon["descricao"].ToString();

                    //Carregando grupo do estoque
                    Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
                    oCusto_ComponenteGrupo.idcusto_componentegrupo = Convert.ToInt32(drCon["idgrupo_componente"].ToString());
                    //fechando o datareader
                    drCon.Close();
                    drCon.Dispose();
                    //lendo dados do grupo
                    Custo_ComponenteGrupoDAO oCusto_ComponenteGrupoDAO = new Custo_ComponenteGrupoDAO(parConexao, oOcorrencia,codEmpresa);
                    objCusto_Componente.Custo_ComponenteGrupo = oCusto_ComponenteGrupoDAO.ObterPor(oCusto_ComponenteGrupo);
                    //fechando o datareader
                    drCon.Close();
                    drCon.Dispose();
                    return objCusto_Componente;
                }


                drCon.Close();
                drCon.Dispose();
                Custo_Componente objCusto_Componente1 = new Custo_Componente();
                return objCusto_Componente1;

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

        private void geraOcorrencia(Custo_Componente oCusto_Componente, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCusto_Componente.idcusto_componente.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Custo_Componente oCobr = new Custo_Componente();
                    oCobr = ObterPor(oCusto_Componente);

                    if (!oCobr.Equals(oCusto_Componente))
                    {
                        descricao = "Componente de Custo id: " + oCusto_Componente.idcusto_componente + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.descricao.Equals(oCusto_Componente.descricao))
                        {
                            descricao += " Descrição de " + oCobr.descricao + " para " + oCusto_Componente.descricao;
                        }
                        if (!oCobr.Custo_ComponenteGrupo.idcusto_componentegrupo.Equals(oCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo))
                        {
                            descricao += " Grupo do Custo de Componente de " + oCobr.Custo_ComponenteGrupo.idcusto_componentegrupo + "-" + oCobr.Custo_ComponenteGrupo.descricao + " para " + oCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo + "-" + oCusto_Componente.Custo_ComponenteGrupo.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Componente de Custo : " + oCusto_Componente.idcusto_componente + " - " + oCusto_Componente.descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Componente de Custo : " + oCusto_Componente.idcusto_componente + " - " + oCusto_Componente.descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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

        public DataTable pesquisaComponente(int empMaster, int idComponente, string descricao)
        {
            try
            {
               
                //Monta comando para a gravação do registro
                String strSQL = "select cc.*, cg.descricao as cg_descricao from custo_componente cc, custo_componentegrupo cg" +
                                " where cg.idcusto_componentegrupo = cc.idgrupo_componente";

                if (idComponente > 0)
                {
                   strSQL += " and cc.idcusto_componente = @idcustocomponente";
                }

                if (!String.IsNullOrEmpty(descricao.Trim()))
                {
                    strSQL += " cc.descricao like @descricao";
                }

                strSQL += " order by cc.descricao";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcustocomponente", idComponente);
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
