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
    public class MenuSistemaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public MenuSistemaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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
        
        public void Salvar(MenuSistema objMenuSistema)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                Salvar(objMenuSistema, Conexao, transacao);
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
        public void Salvar(MenuSistema objMenuSistema, MySqlConnection Conexao, MySqlTransaction transacao)
        {          
            //Grava um novo registro
            try
            {
                geraOcorrencia(objMenuSistema, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into menusistema (idmenusistema, modulo, descricao, namespace, endereco, urlimagem, exibeimagem, itemseguranca, indicadorabertura, ordem, menupai, nivel, exclusivojlm, nivelusuario) " +
                                "values (@idmenusistema, @modulo, @descricao, @namespace, @endereco, @urlimagem, @exibeimagem, @itemseguranca, @indicadorabertura, @ordem, @menupai, @nivel, @exclusivojlm, @nivelusuario)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuSistema.idMenuSistema);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuSistema.modulo);
                Sqlcon.Parameters.AddWithValue("@descricao", objMenuSistema.descricao);
                Sqlcon.Parameters.AddWithValue("@namespace", objMenuSistema.nNamespace);
                Sqlcon.Parameters.AddWithValue("@endereco", objMenuSistema.endereco);
                Sqlcon.Parameters.AddWithValue("@urlimagem", objMenuSistema.urlImagem);
                Sqlcon.Parameters.AddWithValue("@exibeimagem", objMenuSistema.exibeImagem);
                Sqlcon.Parameters.AddWithValue("@itemseguranca", objMenuSistema.itemSeguranca);
                Sqlcon.Parameters.AddWithValue("@indicadorabertura", objMenuSistema.indicadorAbertura);
                Sqlcon.Parameters.AddWithValue("@ordem", objMenuSistema.ordem);
                Sqlcon.Parameters.AddWithValue("@menupai", objMenuSistema.menuPai);
                Sqlcon.Parameters.AddWithValue("@nivel", objMenuSistema.nivel);
                Sqlcon.Parameters.AddWithValue("@exclusivojlm", objMenuSistema.exclusivoJLM);
                Sqlcon.Parameters.AddWithValue("@nivelusuario", objMenuSistema.nivelUsuario);


                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);


                List<Usuario> lstUsuario = new List<Usuario>();
                UsuarioDAO oUsuarioDAO = new UsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                lstUsuario = oUsuarioDAO.LstUsuario();

                MenuUsuarioDAO oMenuUsuarioDAO = new MenuUsuarioDAO(parConexao, oOcorrencia,codEmpresa);

                foreach (Usuario oUser in lstUsuario)
                {
                    MenuUsuario oMenuUsuario = new MenuUsuario();

                    oMenuUsuario.idUsuario = oUser.idUsuario;
                    oMenuUsuario.idMenuSistema = objMenuSistema.idMenuSistema;
                    oMenuUsuario.modulo = objMenuSistema.modulo;
                    oMenuUsuario.nNamespace = objMenuSistema.nNamespace;
                    oMenuUsuario.descricao = objMenuSistema.descricao;
                    oMenuUsuario.endereco = objMenuSistema.endereco;
                    oMenuUsuario.urlImagem = objMenuSistema.urlImagem;
                    oMenuUsuario.exibeImagem = objMenuSistema.exibeImagem;
                    oMenuUsuario.itemSeguranca = objMenuSistema.itemSeguranca;
                    oMenuUsuario.indicadorAbertura = objMenuSistema.indicadorAbertura;
                    oMenuUsuario.ordem = objMenuSistema.ordem;
                    oMenuUsuario.menuPai = objMenuSistema.menuPai;
                    oMenuUsuario.nivel = objMenuSistema.nivel;
                    oMenuUsuario.exclusivoJLM = objMenuSistema.exclusivoJLM;
                    oMenuUsuario.nivelUsuario = objMenuSistema.nivelUsuario;
                    oMenuUsuario.executa = "N";
                    oMenuUsuario.inclusao = "N";
                    oMenuUsuario.alteracao = "N";
                    oMenuUsuario.exclusao = "N";
                    oMenuUsuario.ocorrencia = "N";
                    oMenuUsuario.impressao = "N";
                    

                    oMenuUsuarioDAO.Salvar(oMenuUsuario, Conexao, transacao);
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
          

        }
        
        
        public void Atualizar(MenuSistema objMenuSistema)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {

                geraOcorrencia(objMenuSistema, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update menusistema set descricao = @descricao, namespace = @nnamespace, " + 
                                                      " endereco = @endereco, urlimagem = @urlimagem, exibeimagem = @exibeimagem, " +
                                                      " itemseguranca = @itemseguranca, indicadorabertura = @indicadorabertura, " + 
                                                      " ordem = @ordem, menupai = @menupai, nivel = @nivel, exclusivojlm = exclusivojlm, " + 
                                                      " nivelusuario = @nivelusuario " +
                                                    " where idmenusistema = @idmenusistema and modulo = @modulo ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL,Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuSistema.idMenuSistema);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuSistema.modulo);
                Sqlcon.Parameters.AddWithValue("@descricao", objMenuSistema.descricao);
                Sqlcon.Parameters.AddWithValue("@nnamespace", objMenuSistema.nNamespace);
                Sqlcon.Parameters.AddWithValue("@endereco", objMenuSistema.endereco);
                Sqlcon.Parameters.AddWithValue("@urlimagem", objMenuSistema.urlImagem);
                Sqlcon.Parameters.AddWithValue("@exibeimagem", objMenuSistema.exibeImagem);
                Sqlcon.Parameters.AddWithValue("@itemseguranca", objMenuSistema.itemSeguranca);
                Sqlcon.Parameters.AddWithValue("@indicadorabertura", objMenuSistema.indicadorAbertura);
                Sqlcon.Parameters.AddWithValue("@ordem", objMenuSistema.ordem);
                Sqlcon.Parameters.AddWithValue("@menupai", objMenuSistema.menuPai);
                Sqlcon.Parameters.AddWithValue("@nivel", objMenuSistema.nivel);
                Sqlcon.Parameters.AddWithValue("@exclusivojlm", objMenuSistema.exclusivoJLM);
                Sqlcon.Parameters.AddWithValue("@nivelusuario", objMenuSistema.nivelUsuario);
                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

                //falta implementar a gravação de empresas
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                MenuUsuarioDAO oMenuUsuarioDAO = new MenuUsuarioDAO(parConexao, oOcorrencia,codEmpresa);
                List<MenuUsuario> lstMenuUsuario = new List<MenuUsuario>();

                lstMenuUsuario = oMenuUsuarioDAO.LstMenuUsuario();

                foreach(MenuUsuario oMenuUsuario in lstMenuUsuario)
                {
                    if (oMenuUsuario.idMenuSistema == objMenuSistema.idMenuSistema &&
                        oMenuUsuario.modulo == objMenuSistema.modulo)
                    {
                        oMenuUsuario.descricao = objMenuSistema.descricao;
                        oMenuUsuario.nNamespace = objMenuSistema.nNamespace;
                        oMenuUsuario.endereco = objMenuSistema.endereco;
                        oMenuUsuario.urlImagem = objMenuSistema.urlImagem;
                        oMenuUsuario.exibeImagem = objMenuSistema.exibeImagem;
                        oMenuUsuario.itemSeguranca = objMenuSistema.itemSeguranca;
                        oMenuUsuario.indicadorAbertura = objMenuSistema.indicadorAbertura;
                        oMenuUsuario.ordem = objMenuSistema.ordem;
                        oMenuUsuario.menuPai = objMenuSistema.menuPai;
                        oMenuUsuario.nivel = objMenuSistema.nivel;
                        oMenuUsuario.exclusivoJLM = objMenuSistema.exclusivoJLM;
                        oMenuUsuario.nivelUsuario = objMenuSistema.nivelUsuario;

                        oMenuUsuarioDAO.Atualizar(oMenuUsuario, Conexao, transacao);
                    }
                }

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

        public void Excluir(MenuSistema objMenuSistema)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                MenuUsuarioDAO oMenuUsuarioDAO = new MenuUsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                List<MenuUsuario> lstMenuUsuario = new List<MenuUsuario>();

                lstMenuUsuario = oMenuUsuarioDAO.LstMenuUsuario();

                foreach (MenuUsuario oMenuUsuario in lstMenuUsuario)
                {
                    if (oMenuUsuario.idMenuSistema == objMenuSistema.idMenuSistema &&
                        oMenuUsuario.modulo == objMenuSistema.modulo)
                    {
                        oMenuUsuarioDAO.Excluir(oMenuUsuario,Conexao,transacao);
                    }
                }

                geraOcorrencia(objMenuSistema, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from menusistema where idmenusistema = @idmenusistema and modulo=@modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuSistema.idMenuSistema);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuSistema.modulo);

                //abre conexao e executa o comando

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

        public DataTable ListaMenuSistema()
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menusistema order by modulo, idmenusistema";
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

        //-----------------------------

        /// <summary>
        /// Lista de menu sistema
        /// Desenvolvido por : Kathia em 25/02/2014
        /// </summary>
        /// <param></param>
        /// <returns>
        /// List<MenuSistema>
        /// </returns>
        public List<MenuSistema> LstMenuSistema()
        {           
            List<MenuSistema> lstMenuSistema = new List<MenuSistema>();
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from menusistema ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    MenuSistema objMenuSistema = new MenuSistema();
                    objMenuSistema.idMenuSistema = Convert.ToInt32(drCon["idmenusistema"]);
                    objMenuSistema.modulo = Convert.ToString(drCon["modulo"]);
                    objMenuSistema.descricao = Convert.ToString(drCon["descricao"]);
                    objMenuSistema.nNamespace = Convert.ToString(drCon["namespace"]);
                    objMenuSistema.endereco = Convert.ToString(drCon["endereco"]);
                    objMenuSistema.urlImagem = Convert.ToString(drCon["urlimagem"]);
                    objMenuSistema.exibeImagem = Convert.ToString(drCon["exibeimagem"]);
                    objMenuSistema.itemSeguranca = Convert.ToString(drCon["itemseguranca"]);
                    objMenuSistema.indicadorAbertura = Convert.ToString(drCon["indicadorabertura"]);
                    objMenuSistema.ordem = Convert.ToInt32(drCon["ordem"]);
                    objMenuSistema.menuPai = Convert.ToInt32(drCon["menupai"]);
                    objMenuSistema.nivel = Convert.ToInt32(drCon["nivel"]);
                    objMenuSistema.exclusivoJLM = Convert.ToString(drCon["exclusivojlm"]);
                    objMenuSistema.nivelUsuario = Convert.ToInt32(drCon["nivelusuario"]);

                    lstMenuSistema.Add(objMenuSistema);
                }

                drCon.Close();
                drCon.Dispose();
                return lstMenuSistema;
                
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
           
        }

        //--------------------------
        

        public MenuSistema ObterPor(MenuSistema objMenuSis)
        {
            MySqlDataReader drCon;
            try
            {
                //Abre Conexão com o banco
                //List<Empresa> lstEmpresas = new List<Empresa>();

                //Monta comando para a gravação do registro
                String strSQL = "select * from menusistema Where idmenusistema = @idmenusistema and modulo=@modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idmenusistema", objMenuSis.idMenuSistema);
                Sqlcon.Parameters.AddWithValue("@modulo", objMenuSis.modulo);
                drCon = Sqlcon.ExecuteReader();

                              
                MenuSistema objMenuSistema = new MenuSistema();

                while (drCon.Read())
                {
                    objMenuSistema.idMenuSistema = EmcResources.cInt(drCon["idmenusistema"].ToString());
                    objMenuSistema.modulo = Convert.ToString(drCon["modulo"]);
                    objMenuSistema.descricao = Convert.ToString(drCon["descricao"]);
                    objMenuSistema.nNamespace = Convert.ToString(drCon["namespace"]);
                    objMenuSistema.endereco = Convert.ToString(drCon["endereco"]);
                    objMenuSistema.urlImagem = Convert.ToString(drCon["urlimagem"]);
                    objMenuSistema.exibeImagem = Convert.ToString(drCon["exibeimagem"]);
                    objMenuSistema.itemSeguranca = Convert.ToString(drCon["itemseguranca"]);
                    objMenuSistema.indicadorAbertura = Convert.ToString(drCon["indicadorabertura"]);
                    objMenuSistema.ordem = EmcResources.cInt(drCon["ordem"].ToString());
                    objMenuSistema.menuPai = EmcResources.cInt(drCon["menupai"].ToString());
                    objMenuSistema.nivel = EmcResources.cInt(drCon["nivel"].ToString());
                    objMenuSistema.exclusivoJLM = Convert.ToString(drCon["exclusivojlm"]);
                    if (drCon["nivelusuario"] is DBNull)
                    {
                        objMenuSistema.nivelUsuario = 8;
                    }
                    else
                        objMenuSistema.nivelUsuario = EmcResources.cInt(drCon["nivelusuario"].ToString());

                }

                drCon.Close();
                drCon.Dispose();
                return objMenuSistema;

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

        private void geraOcorrencia(MenuSistema oMenuSistema, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oMenuSistema.idMenuSistema.ToString();

                if (flag == "A")
                {

                    MenuSistema oMenuSis = new MenuSistema();
                    oMenuSis = ObterPor(oMenuSistema);

                    if (!oMenuSis.Equals(oMenuSistema) && flag == "A")
                    {
                        descricao = "Menu Sistema :" + oMenuSistema.idMenuSistema + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oMenuSis.modulo.Equals(oMenuSistema.modulo))
                        {
                            descricao += " Módulo : " + oMenuSis.modulo + " para " + oMenuSistema.modulo;
                        }
                        if (!oMenuSis.descricao.Equals(oMenuSistema.descricao))
                        {
                            descricao += " Descrição : " + oMenuSis.descricao + " para " + oMenuSistema.descricao;
                        }
                        if (!oMenuSis.nNamespace.Equals(oMenuSistema.nNamespace))
                        {
                            descricao += " Namespace : " + oMenuSis.nNamespace + " para " + oMenuSistema.nNamespace;
                        }
                        if (!oMenuSis.endereco.Equals(oMenuSistema.endereco))
                        {
                            descricao += " Endereço : " + oMenuSis.endereco + " para " + oMenuSistema.endereco;
                        }
                        if (!oMenuSis.urlImagem.Equals(oMenuSistema.urlImagem))
                        {
                            descricao += " URL Imagem : " + oMenuSis.urlImagem + " para " + oMenuSistema.urlImagem;
                        }
                        if (!oMenuSis.exibeImagem.Equals(oMenuSistema.exibeImagem))
                        {
                            descricao += " Exibe Imagem : " + oMenuSis.exibeImagem + " para " + oMenuSistema.exibeImagem;
                        }
                        if (!oMenuSis.itemSeguranca.Equals(oMenuSistema.itemSeguranca))
                        {
                            descricao += " Item Segurança : " + oMenuSis.itemSeguranca + " para " + oMenuSistema.itemSeguranca;
                        }
                        if (!oMenuSis.indicadorAbertura.Equals(oMenuSistema.indicadorAbertura))
                        {
                            descricao += " Indicador Abertura : " + oMenuSis.indicadorAbertura + " para " + oMenuSistema.indicadorAbertura;
                        }
                        if (!oMenuSis.ordem.Equals(oMenuSistema.ordem))
                        {
                            descricao += " Ordem : " + oMenuSis.ordem + " para " + oMenuSistema.ordem;
                        }
                        if (!oMenuSis.menuPai.Equals(oMenuSistema.menuPai))
                        {
                            descricao += " Menu Pai : " + oMenuSis.menuPai + " para " + oMenuSistema.menuPai;
                        }
                        if (!oMenuSis.nivel.Equals(oMenuSistema.nivel))
                        {
                            descricao += " Nível : " + oMenuSis.nivel + " para " + oMenuSistema.nivel;
                        }
                        if (!oMenuSis.exclusivoJLM.Equals(oMenuSistema.exclusivoJLM))
                        {
                            descricao += " Exclusivo JLM : " + oMenuSis.exclusivoJLM + " para " + oMenuSistema.exclusivoJLM;
                        }
                        if (!oMenuSis.nivelUsuario.Equals(oMenuSistema.nivelUsuario))
                        {
                            descricao += " Nível Usuário : " + oMenuSis.nivelUsuario + " para " + oMenuSistema.nivelUsuario;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Menu Sistema : " + oMenuSistema.idMenuSistema
                              + " - Módulo : " + oMenuSistema.modulo
                              + " - Descrição : " + oMenuSistema.descricao
                              + " - Namespace : " + oMenuSistema.nNamespace
                              + " - Endereço : " + oMenuSistema.endereco
                              + " - URL Imagem : " + oMenuSistema.urlImagem
                              + " - Exibe Imagem : " + oMenuSistema.exibeImagem
                              + " - Item Segurança : " + oMenuSistema.itemSeguranca
                              + " - Indicador Abertura : " + oMenuSistema.indicadorAbertura
                              + " - Ordem : " + oMenuSistema.ordem
                              + " - Menu Pai : " + oMenuSistema.menuPai
                              + " - Nível : " + oMenuSistema.nivel
                              + " - Exclusivo JLM : " + oMenuSistema.exclusivoJLM
                              + " Nível Usuário : " + oMenuSistema.nivelUsuario +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Menu Sistema : " + oMenuSistema.idMenuSistema
                              + " - Módulo : " + oMenuSistema.modulo
                              + " - Descrição : " + oMenuSistema.descricao
                              + " - Namespace : " + oMenuSistema.nNamespace
                              + " - Endereço : " + oMenuSistema.endereco
                              + " - URL Imagem : " + oMenuSistema.urlImagem
                              + " - Exibe Imagem : " + oMenuSistema.exibeImagem
                              + " - Item Segurança : " + oMenuSistema.itemSeguranca
                              + " - Indicador Abertura : " + oMenuSistema.indicadorAbertura
                              + " - Ordem : " + oMenuSistema.ordem
                              + " - Menu Pai : " + oMenuSistema.menuPai
                              + " - Nível : " + oMenuSistema.nivel
                              + " - Exclusivo JLM : " + oMenuSistema.exclusivoJLM
                              + " Nível Usuário : " + oMenuSistema.nivelUsuario +
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
