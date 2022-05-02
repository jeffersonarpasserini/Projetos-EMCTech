using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using EMCSecurityModel;
using EMCLibrary;

namespace EMCSecurityDAO
{
    public class MenuUsuarioDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public MenuUsuarioDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
        {
            if (pConexao == null)
            {
                parConexao = new ConectaBancoMySql();
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = codempresa;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = codempresa;
            }
        }

        //----------------------------------

        public DataTable ListaMenuUsuario()
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario order by idusuario, modulo, idmenusistema";
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
        public DataTable ListaMenuUsuario(int idUsuario)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario where idusuario=@idusuario order by idusuario, modulo, idmenusistema";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);

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
        /// <summary>
        /// Lista de menu usuário
        /// Desenvolvido por : Jefferson em 28/02/2014
        /// </summary>
        /// <param></param>
        /// <returns>
        /// List<Usuario>
        /// </returns>
        public List<MenuUsuario> LstMenuUsuario()
        {
            List<MenuUsuario> lstMenuUsuario = new List<MenuUsuario>();
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    MenuUsuario objMenuUsuario = new MenuUsuario();
                    objMenuUsuario.idUsuario = EmcResources.cInt(drCon["idusuario"].ToString());
                    objMenuUsuario.idMenuSistema = EmcResources.cInt(drCon["idmenusistema"].ToString());
                    objMenuUsuario.modulo = Convert.ToString(drCon["modulo"]);
                    objMenuUsuario.descricao = Convert.ToString(drCon["descricao"]);
                    objMenuUsuario.nNamespace = Convert.ToString(drCon["namespace"]);
                    objMenuUsuario.endereco = Convert.ToString(drCon["endereco"]);
                    objMenuUsuario.urlImagem = Convert.ToString(drCon["urlimagem"]);
                    objMenuUsuario.exibeImagem = Convert.ToString(drCon["exibeimagem"]);
                    objMenuUsuario.itemSeguranca = Convert.ToString(drCon["itemseguranca"]);
                    objMenuUsuario.indicadorAbertura = Convert.ToString(drCon["indicadorabertura"]);
                    objMenuUsuario.ordem = EmcResources.cInt(drCon["ordem"].ToString());
                    objMenuUsuario.menuPai = EmcResources.cInt(drCon["menupai"].ToString());
                    objMenuUsuario.nivel = EmcResources.cInt(drCon["nivel"].ToString());
                    objMenuUsuario.exclusivoJLM = Convert.ToString(drCon["exclusivojlm"]);
                    if (drCon["nivelusuario"] is DBNull)
                        objMenuUsuario.nivelUsuario = 8;
                    else
                        objMenuUsuario.nivelUsuario = EmcResources.cInt(drCon["nivelusuario"].ToString());

                    objMenuUsuario.executa = Convert.ToString(drCon["executa"]);
                    objMenuUsuario.inclusao = Convert.ToString(drCon["inclusao"]);
                    objMenuUsuario.alteracao = Convert.ToString(drCon["alteracao"]);
                    objMenuUsuario.exclusao = Convert.ToString(drCon["exclusao"]);
                    objMenuUsuario.ocorrencia = Convert.ToString(drCon["ocorrencia"]);
                    objMenuUsuario.impressao = Convert.ToString(drCon["impressao"]);


                    lstMenuUsuario.Add(objMenuUsuario);
                }

                drCon.Close();
                drCon.Dispose();
                return lstMenuUsuario;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(MenuUsuario objMenuUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                Salvar(objMenuUsuario, Conexao, transacao);
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
        public void Salvar(MenuUsuario objMenuUsuario, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro
            try
            {
                geraOcorrencia(objMenuUsuario, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into menuusuario (idusuario, idmenusistema, modulo, descricao, namespace, endereco, urlimagem, exibeimagem, itemseguranca, indicadorabertura, ordem, menupai, nivel, exclusivojlm, nivelusuario, executa, inclusao, alteracao, exclusao, ocorrencia, impressao) " +
                                "values (@idusuario, @idmenusistema, @modulo, @descricao, @namespace, @endereco, @urlimagem, @exibeimagem, @itemseguranca, @indicadorabertura, @ordem, @menupai, @nivel, @exclusivojlm, @nivelusuario, @executa, @inclusao, @alteracao, @exclusao, @ocorrencia, @impressao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objMenuUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuUsuario.idMenuSistema);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuUsuario.modulo);
                Sqlcon.Parameters.AddWithValue("@descricao", objMenuUsuario.descricao);
                Sqlcon.Parameters.AddWithValue("@namespace", objMenuUsuario.nNamespace);
                Sqlcon.Parameters.AddWithValue("@endereco", objMenuUsuario.endereco);
                Sqlcon.Parameters.AddWithValue("@urlimagem", objMenuUsuario.urlImagem);
                Sqlcon.Parameters.AddWithValue("@exibeimagem", objMenuUsuario.exibeImagem);
                Sqlcon.Parameters.AddWithValue("@itemseguranca", objMenuUsuario.itemSeguranca);
                Sqlcon.Parameters.AddWithValue("@indicadorabertura", objMenuUsuario.indicadorAbertura);
                Sqlcon.Parameters.AddWithValue("@ordem", objMenuUsuario.ordem);
                Sqlcon.Parameters.AddWithValue("@menupai", objMenuUsuario.menuPai);
                Sqlcon.Parameters.AddWithValue("@nivel", objMenuUsuario.nivel);
                Sqlcon.Parameters.AddWithValue("@exclusivojlm", objMenuUsuario.exclusivoJLM);
                Sqlcon.Parameters.AddWithValue("@nivelusuario", objMenuUsuario.nivelUsuario);
                Sqlcon.Parameters.AddWithValue("@executa", objMenuUsuario.executa);
                Sqlcon.Parameters.AddWithValue("@inclusao", objMenuUsuario.inclusao);
                Sqlcon.Parameters.AddWithValue("@alteracao", objMenuUsuario.alteracao);
                Sqlcon.Parameters.AddWithValue("@exclusao", objMenuUsuario.exclusao);
                Sqlcon.Parameters.AddWithValue("@ocorrencia", objMenuUsuario.ocorrencia);
                Sqlcon.Parameters.AddWithValue("@impressao", objMenuUsuario.impressao);


                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }
        public void SalvarNovoUsuario(int idUsuario, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            try
            {
                List<MenuSistema> lstMenuSistema = new List<MenuSistema>();
                MenuSistemaDAO oMenuSistemaDAO = new MenuSistemaDAO(parConexao, oOcorrencia, codEmpresa);
                lstMenuSistema = oMenuSistemaDAO.LstMenuSistema();

                foreach (MenuSistema oMenu in lstMenuSistema)
                {

                    MenuUsuario oMenuUsuario = new MenuUsuario();
                    oMenuUsuario.idUsuario = idUsuario;
                    oMenuUsuario.idMenuSistema = oMenu.idMenuSistema;
                    oMenuUsuario.modulo = oMenu.modulo;
                    oMenuUsuario.nNamespace = oMenu.nNamespace;
                    oMenuUsuario.descricao = oMenu.descricao;
                    oMenuUsuario.endereco = oMenu.endereco;
                    oMenuUsuario.urlImagem = oMenu.urlImagem;
                    oMenuUsuario.exibeImagem = oMenu.exibeImagem;
                    oMenuUsuario.itemSeguranca = oMenu.itemSeguranca;
                    oMenuUsuario.indicadorAbertura = oMenu.indicadorAbertura;
                    oMenuUsuario.ordem = oMenu.ordem;
                    oMenuUsuario.menuPai = oMenu.menuPai;
                    oMenuUsuario.nivel = oMenu.nivel;
                    oMenuUsuario.exclusivoJLM = oMenu.exclusivoJLM;
                    oMenuUsuario.nivelUsuario = oMenu.nivelUsuario;
                    oMenuUsuario.executa = "N";
                    oMenuUsuario.inclusao = "N";
                    oMenuUsuario.alteracao = "N";
                    oMenuUsuario.exclusao = "N";
                    oMenuUsuario.ocorrencia = "N";
                    oMenuUsuario.impressao = "N";

                    Salvar(oMenuUsuario, Conexao, Transacao);

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Atualizar(MenuUsuario objMenuUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {

                Atualizar(objMenuUsuario, Conexao, transacao);

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
        public void Atualizar(MenuUsuario objMenuUsuario, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            try
            {
                geraOcorrencia(objMenuUsuario, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update menuusuario set idusuario = @idusuario, modulo = @modulo, descricao = @descricao, namespace = @nnamespace, " +
                                                      " endereco = @endereco, urlimagem = @urlimagem, exibeimagem = @exibeimagem, " +
                                                      " itemseguranca = @itemseguranca, indicadorabertura = @indicadorabertura, " +
                                                      " ordem = @ordem, menupai = @menupai, nivel = @nivel, exclusivojlm = exclusivojlm, " +
                                                      " nivelusuario = @nivelusuario, executa = @executa, inclusao = @inclusao, alteracao = @alteracao, " +
                                                      " exclusao = @exclusao, ocorrencia = @ocorrencia, impressao = @impressao " +
                                                    " where idusuario = @idusuario and modulo = @modulo and idmenusistema = @idmenusistema";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objMenuUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuUsuario.idMenuSistema);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuUsuario.modulo);
                Sqlcon.Parameters.AddWithValue("@descricao", objMenuUsuario.descricao);
                Sqlcon.Parameters.AddWithValue("@nnamespace", objMenuUsuario.nNamespace);
                Sqlcon.Parameters.AddWithValue("@endereco", objMenuUsuario.endereco);
                Sqlcon.Parameters.AddWithValue("@urlimagem", objMenuUsuario.urlImagem);
                Sqlcon.Parameters.AddWithValue("@exibeimagem", objMenuUsuario.exibeImagem);
                Sqlcon.Parameters.AddWithValue("@itemseguranca", objMenuUsuario.itemSeguranca);
                Sqlcon.Parameters.AddWithValue("@indicadorabertura", objMenuUsuario.indicadorAbertura);
                Sqlcon.Parameters.AddWithValue("@ordem", objMenuUsuario.ordem);
                Sqlcon.Parameters.AddWithValue("@menupai", objMenuUsuario.menuPai);
                Sqlcon.Parameters.AddWithValue("@nivel", objMenuUsuario.nivel);
                Sqlcon.Parameters.AddWithValue("@exclusivojlm", objMenuUsuario.exclusivoJLM);
                Sqlcon.Parameters.AddWithValue("@nivelusuario", objMenuUsuario.nivelUsuario);
                Sqlcon.Parameters.AddWithValue("@executa", objMenuUsuario.executa);
                Sqlcon.Parameters.AddWithValue("@inclusao", objMenuUsuario.inclusao);
                Sqlcon.Parameters.AddWithValue("@alteracao", objMenuUsuario.alteracao);
                Sqlcon.Parameters.AddWithValue("@exclusao", objMenuUsuario.exclusao);
                Sqlcon.Parameters.AddWithValue("@ocorrencia", objMenuUsuario.ocorrencia);
                Sqlcon.Parameters.AddWithValue("@impressao", objMenuUsuario.impressao);



                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

                //falta implementar a gravação de empresas
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }       

        public void Excluir(MenuUsuario objMenuUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                Excluir(objMenuUsuario, Conexao, transacao);
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
        public void Excluir(MenuUsuario objMenuUsuario, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //apaga registro
            try
            {
                geraOcorrencia(objMenuUsuario, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from menuusuario where idusuario = @idusuario and modulo = @modulo and idmenusistema = @idmenusistema";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objMenuUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuUsuario.modulo);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuUsuario.idMenuSistema);

                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        public void ExcluirUsuario(int idUsuario, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            try
            {
                List<MenuSistema> lstMenuSistema = new List<MenuSistema>();
                MenuSistemaDAO oMenuSistemaDAO = new MenuSistemaDAO(parConexao, oOcorrencia, codEmpresa);
                lstMenuSistema = oMenuSistemaDAO.LstMenuSistema();

                foreach (MenuSistema oMenu in lstMenuSistema)
                {

                    MenuUsuario oMenuUsuario = new MenuUsuario();
                    oMenuUsuario.idUsuario = idUsuario;
                    oMenuUsuario.idMenuSistema = oMenu.idMenuSistema;
                    oMenuUsuario.modulo = oMenu.modulo;
                    oMenuUsuario.nNamespace = oMenu.nNamespace;
                    oMenuUsuario.descricao = oMenu.descricao;
                    oMenuUsuario.endereco = oMenu.endereco;
                    oMenuUsuario.urlImagem = oMenu.urlImagem;
                    oMenuUsuario.exibeImagem = oMenu.exibeImagem;
                    oMenuUsuario.itemSeguranca = oMenu.itemSeguranca;
                    oMenuUsuario.indicadorAbertura = oMenu.indicadorAbertura;
                    oMenuUsuario.ordem = oMenu.ordem;
                    oMenuUsuario.menuPai = oMenu.menuPai;
                    oMenuUsuario.nivel = oMenu.nivel;
                    oMenuUsuario.exclusivoJLM = oMenu.exclusivoJLM;
                    oMenuUsuario.nivelUsuario = oMenu.nivelUsuario;
                    oMenuUsuario.executa = "N";
                    oMenuUsuario.inclusao = "N";
                    oMenuUsuario.alteracao = "N";
                    oMenuUsuario.exclusao = "N";
                    oMenuUsuario.ocorrencia = "N";
                    oMenuUsuario.impressao = "N";

                    Excluir(oMenuUsuario, Conexao, Transacao);
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
       
        
        public MenuUsuario ObterPor(MenuUsuario objMenuUser)
        {
            MySqlDataReader drCon;
            try
            {
                //Abre Conexão com o banco                             

                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario Where idusuario = @idusuario and modulo = @modulo and idmenusistema = @idmenusistema";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", objMenuUser.idUsuario);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuUser.modulo);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuUser.idMenuSistema);
                drCon = Sqlcon.ExecuteReader();


                MenuUsuario objMenuUsuario = new MenuUsuario();

                while (drCon.Read())
                {
                    objMenuUsuario.idUsuario = Convert.ToInt32(drCon["idusuario"]);
                    objMenuUsuario.idMenuSistema = Convert.ToInt32(drCon["idmenusistema"]);
                    objMenuUsuario.modulo = Convert.ToString(drCon["modulo"]);
                    objMenuUsuario.descricao = Convert.ToString(drCon["descricao"]);
                    objMenuUsuario.nNamespace = Convert.ToString(drCon["namespace"]);
                    objMenuUsuario.endereco = Convert.ToString(drCon["endereco"]);
                    objMenuUsuario.urlImagem = Convert.ToString(drCon["urlimagem"]);
                    objMenuUsuario.exibeImagem = Convert.ToString(drCon["exibeimagem"]);
                    objMenuUsuario.itemSeguranca = Convert.ToString(drCon["itemseguranca"]);
                    objMenuUsuario.indicadorAbertura = Convert.ToString(drCon["indicadorabertura"]);
                    objMenuUsuario.ordem = Convert.ToInt32(drCon["ordem"]);
                    objMenuUsuario.menuPai = Convert.ToInt32(drCon["menupai"]);
                    objMenuUsuario.nivel = Convert.ToInt32(drCon["nivel"]);
                    objMenuUsuario.exclusivoJLM = Convert.ToString(drCon["exclusivojlm"]);
                    objMenuUsuario.nivelUsuario = Convert.ToInt32(drCon["nivelusuario"]);
                    objMenuUsuario.executa = Convert.ToString(drCon["executa"]);
                    objMenuUsuario.inclusao = Convert.ToString(drCon["inclusao"]);
                    objMenuUsuario.alteracao = Convert.ToString(drCon["alteracao"]);
                    objMenuUsuario.exclusao = Convert.ToString(drCon["exclusao"]);
                    objMenuUsuario.ocorrencia = Convert.ToString(drCon["ocorrencia"]);
                    objMenuUsuario.impressao = Convert.ToString(drCon["impressao"]);

                }

                drCon.Close();
                drCon.Dispose();
                return objMenuUsuario;

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

        //------------------------------------

        public MenuUsuario ObterPor(int idMenuUsuario, int idUsuario, string Aplicativo)
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario Where idmenusistema=@idmenuusuario and idusuario=@idusuario and modulo=@modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idmenuusuario", idMenuUsuario);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);
                Sqlcon.Parameters.AddWithValue("@modulo", Aplicativo);
                drCon = Sqlcon.ExecuteReader();

                MenuUsuario objRetorno = new MenuUsuario();

                while (drCon.Read())
                {

                    objRetorno.idMenuSistema = Convert.ToInt32(drCon["idmenusistema"].ToString());
                    objRetorno.idUsuario = Convert.ToInt32(drCon["idusuario"].ToString());
                    objRetorno.modulo = drCon["modulo"].ToString();
                    objRetorno.alteracao = drCon["alteracao"].ToString();
                    objRetorno.descricao = drCon["descricao"].ToString();
                    objRetorno.endereco = drCon["endereco"].ToString();
                    objRetorno.exclusao = drCon["exclusao"].ToString();
                    objRetorno.exclusivoJLM = drCon["exclusivojlm"].ToString();
                    objRetorno.executa = drCon["executa"].ToString();
                    objRetorno.exibeImagem = drCon["exibeimagem"].ToString();
                    objRetorno.impressao = drCon["impressao"].ToString();
                    objRetorno.inclusao = drCon["inclusao"].ToString();
                    objRetorno.indicadorAbertura = drCon["indicadorabertura"].ToString();
                    objRetorno.itemSeguranca = drCon["itemseguranca"].ToString();
                    objRetorno.menuPai = Convert.ToInt32(drCon["menupai"].ToString());
                    objRetorno.nivel = Convert.ToInt32(drCon["nivel"].ToString());
                    objRetorno.nivelUsuario = Convert.ToInt32(drCon["nivelusuario"].ToString());
                    objRetorno.nNamespace = drCon["namespace"].ToString();
                    objRetorno.ocorrencia = drCon["ocorrencia"].ToString();
                    objRetorno.ordem = Convert.ToInt32(drCon["ordem"].ToString());
                    objRetorno.urlImagem = drCon["urlimagem"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
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

        public MenuUsuario ObterPor(string Formulario, int idUsuario, string Aplicativo)
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario Where endereco=@endereco and idusuario=@idusuario and modulo=@modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@endereco", Formulario);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);
                Sqlcon.Parameters.AddWithValue("@modulo", Aplicativo);
                drCon = Sqlcon.ExecuteReader();

                MenuUsuario objRetorno = new MenuUsuario();

                while (drCon.Read())
                {

                    objRetorno.idMenuSistema = Convert.ToInt32(drCon["idmenusistema"].ToString());
                    objRetorno.idUsuario = Convert.ToInt32(drCon["idusuario"].ToString());
                    objRetorno.modulo = drCon["modulo"].ToString();
                    objRetorno.alteracao = drCon["alteracao"].ToString();
                    objRetorno.descricao = drCon["descricao"].ToString();
                    objRetorno.endereco = drCon["endereco"].ToString();
                    objRetorno.exclusao = drCon["exclusao"].ToString();
                    objRetorno.exclusivoJLM = drCon["exclusivojlm"].ToString();
                    objRetorno.executa = drCon["executa"].ToString();
                    objRetorno.exibeImagem = drCon["exibeimagem"].ToString();
                    objRetorno.impressao = drCon["impressao"].ToString();
                    objRetorno.inclusao = drCon["inclusao"].ToString();
                    objRetorno.indicadorAbertura = drCon["indicadorabertura"].ToString();
                    objRetorno.itemSeguranca = drCon["itemseguranca"].ToString();
                    objRetorno.menuPai = Convert.ToInt32(drCon["menupai"].ToString());
                    objRetorno.nivel = Convert.ToInt32(drCon["nivel"].ToString());
                    objRetorno.nivelUsuario = Convert.ToInt32(drCon["nivelusuario"].ToString());
                    objRetorno.nNamespace = drCon["namespace"].ToString();
                    objRetorno.ocorrencia = drCon["ocorrencia"].ToString();
                    objRetorno.ordem = Convert.ToInt32(drCon["ordem"].ToString());
                    objRetorno.urlImagem = drCon["urlimagem"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
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


        //------------------------------------
        private void geraOcorrencia(MenuUsuario oMenuUsuario, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oMenuUsuario.idUsuario.ToString();

                if (flag == "A")
                {

                    MenuUsuario oMenuUser = new MenuUsuario();
                    //   oMenuUser = ObterPor(oMenuUsuario);

                    if (!oMenuUser.Equals(oMenuUsuario) && flag == "A")
                    {
                        descricao = "Menu Usuário :" + oMenuUsuario.idUsuario + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oMenuUser.nivelUsuario.Equals(oMenuUsuario.nivelUsuario))
                        {
                            descricao += " Nível Usuário : " + oMenuUser.nivelUsuario + " para " + oMenuUsuario.nivelUsuario;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Menu Usuário : " + oMenuUsuario.idMenuSistema
                              + " - Módulo : " + oMenuUsuario.modulo
                              + " - Descrição : " + oMenuUsuario.descricao
                              + " - Namespace : " + oMenuUsuario.nNamespace
                              + " - Endereço : " + oMenuUsuario.endereco
                              + " - URL Imagem : " + oMenuUsuario.urlImagem
                              + " - Exibe Imagem : " + oMenuUsuario.exibeImagem
                              + " - Item Segurança : " + oMenuUsuario.itemSeguranca
                              + " - Indicador Abertura : " + oMenuUsuario.indicadorAbertura
                              + " - Ordem : " + oMenuUsuario.ordem
                              + " - Menu Pai : " + oMenuUsuario.menuPai
                              + " - Nível : " + oMenuUsuario.nivel
                              + " - Exclusivo JLM : " + oMenuUsuario.exclusivoJLM
                              + " Nível Usuário : " + oMenuUsuario.nivelUsuario +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Menu Usuário : " + oMenuUsuario.idMenuSistema
                              + " - Módulo : " + oMenuUsuario.modulo
                              + " - Descrição : " + oMenuUsuario.descricao
                              + " - Namespace : " + oMenuUsuario.nNamespace
                              + " - Endereço : " + oMenuUsuario.endereco
                              + " - URL Imagem : " + oMenuUsuario.urlImagem
                              + " - Exibe Imagem : " + oMenuUsuario.exibeImagem
                              + " - Item Segurança : " + oMenuUsuario.itemSeguranca
                              + " - Indicador Abertura : " + oMenuUsuario.indicadorAbertura
                              + " - Ordem : " + oMenuUsuario.ordem
                              + " - Menu Pai : " + oMenuUsuario.menuPai
                              + " - Nível : " + oMenuUsuario.nivel
                              + " - Exclusivo JLM : " + oMenuUsuario.exclusivoJLM
                              + " Nível Usuário : " + oMenuUsuario.nivelUsuario +
                                " foi excluida por " + oOcorrencia.usuario.nome;
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
