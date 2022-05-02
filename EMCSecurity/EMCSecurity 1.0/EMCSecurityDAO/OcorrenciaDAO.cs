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
    public class OcorrenciaDAO
    {
        
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        int codEmpresa;
        
        public OcorrenciaDAO(ConectaBancoMySql pConexao, int idEmpresa)
        {
            if (pConexao == null)
            {
                parConexao = new ConectaBancoMySql();
                Conexao = parConexao.getConexao();
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
            }
            codEmpresa = idEmpresa;

        }


        public void Salvar(Ocorrencia objOcorrencia, MySqlTransaction transacao)
        {
            //Grava um novo registro de Ocorrencia
            try
            {
                            
                //Monta comando para a gravação do registro
                String strSQL = "insert into sect_ocorrencia ( aplicativo, formulario, seqlogin, idusuario, tabela, chaveidentificacao, descricao, data_hora ) " +
                                " values (@aplicativo, @formulario, @seqlogin, @idusuario, @tabela, @chaveidentificacao, @descricao, @data_hora)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@aplicativo", objOcorrencia.aplicativo.nome);
                Sqlcon.Parameters.AddWithValue("@formulario", objOcorrencia.formulario);
                Sqlcon.Parameters.AddWithValue("@seqlogin", objOcorrencia.seqLogin);
                Sqlcon.Parameters.AddWithValue("@idusuario", objOcorrencia.usuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@tabela", objOcorrencia.tabela);
                Sqlcon.Parameters.AddWithValue("@chaveidentificacao", objOcorrencia.chaveidentificacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objOcorrencia.descricao);
                Sqlcon.Parameters.AddWithValue("@data_hora", objOcorrencia.data_hora);
                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            
        }

        public List<Ocorrencia> ListaOcorrencia(Ocorrencia oOcorrencia)

        {
            bool consulta = false;
            try
            {
           
                //Monta comando para a gravação do registro
                String strSQL = "select * from sect_Ocorrencia where aplicativo=@aplicativo and formulario=@formulario " + 
                                " and chaveidentificacao=@chaveidentificacao order by data_hora asc";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@aplicativo", oOcorrencia.aplicativo.nome);
                Sqlcon.Parameters.AddWithValue("@formulario", oOcorrencia.formulario);
                Sqlcon.Parameters.AddWithValue("@chaveidentificacao", oOcorrencia.chaveidentificacao);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<Ocorrencia> lstRetorno = new List<Ocorrencia>();
                List<Ocorrencia> lstOcorrencia = new List<Ocorrencia>();

                Usuario oUsuario = new Usuario();
                Aplicativo oAplicativo = new Aplicativo();
                Ocorrencia objOcorrencia;

                while (drCon.Read())
                {
                    consulta = true;
                    objOcorrencia = new Ocorrencia();

                    objOcorrencia.idOcorrencia = EmcResources.cInt(drCon["idocorrencia"].ToString());
                    objOcorrencia.formulario = drCon["formulario"].ToString();

                    //usuario
                    oUsuario.idUsuario = EmcResources.cInt(drCon["idusuario"].ToString());
                    objOcorrencia.usuario = oUsuario;

                    //aplicativo
                    oAplicativo.nome = drCon["aplicativo"].ToString();
                    objOcorrencia.aplicativo = oAplicativo;

                    objOcorrencia.seqLogin = EmcResources.cInt(drCon["seqlogin"].ToString());
                    objOcorrencia.data_hora = Convert.ToDateTime(drCon["data_hora"].ToString());

                    objOcorrencia.tabela = drCon["tabela"].ToString();
                    objOcorrencia.chaveidentificacao = drCon["chaveidentificacao"].ToString();
                    objOcorrencia.descricao = drCon["descricao"].ToString();

                    lstOcorrencia.Add(objOcorrencia);

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (Ocorrencia oOcorr in lstOcorrencia)
                    {
                        UsuarioDAO oUsuarioDAO = new UsuarioDAO(parConexao);
                        oOcorr.usuario = oUsuarioDAO.ObterPor(oOcorr.usuario);

                        AplicativoDAO oAplicativoDAO = new AplicativoDAO(parConexao,oOcorrencia,codEmpresa);
                        oOcorr.aplicativo = oAplicativoDAO.ObterPor(oOcorr.aplicativo);

                        lstRetorno.Add(oOcorr);
                    }
                }
                return lstRetorno;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
           
        }
        }


    }

