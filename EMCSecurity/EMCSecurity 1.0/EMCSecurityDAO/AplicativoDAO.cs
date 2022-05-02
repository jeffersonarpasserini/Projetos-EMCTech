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
    public class AplicativoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
        
        public AplicativoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int codempresa)
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


    public void Salvar(Aplicativo objAplicativo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de aplicativo
            try
            {
                
                geraOcorrencia(objAplicativo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into sect_aplicativo ( descricao, modulo ) values (@descricao, @modulo)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@descricao", objAplicativo.descricao);
                Sqlcon.Parameters.AddWithValue("@modulo", objAplicativo.nome);
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

        public void Atualizar(Aplicativo objAplicativo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de TipoDocumento
            try
            {
                geraOcorrencia(objAplicativo, "A");
            
                //Monta comando para a gravação do registro
                String strSQL = "update sect_aplicativo set descricao = @descricao where modulo = @modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@descricao", objAplicativo.descricao);
                Sqlcon.Parameters.AddWithValue("@modulo", objAplicativo.nome);
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

        public void Excluir(Aplicativo objAplicativo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de TipoDocumento
            try
            {
                geraOcorrencia(objAplicativo, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from sect_aplicativo where modulo = @modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                
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

        public List<Aplicativo> lstAplicativo()
        {
            List<Aplicativo> lstAplicativo = new List<Aplicativo>();
            try
            {
                DataTable dtCon = ListaAplicativo();

                foreach(DataRow oRow in dtCon.Rows)
                {
                    Aplicativo oAplicativo = new Aplicativo();
                    oAplicativo.nome = oRow["modulo"].ToString();
                    oAplicativo.descricao = oRow["descricao"].ToString();

                    lstAplicativo.Add(oAplicativo);
                }

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            return lstAplicativo;
        }
        public DataTable ListaAplicativo()

        {

            try
            {
           
                //Monta comando para a gravação do registro
                String strSQL = "select * from sect_Aplicativo order by descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
           
        }

        public Aplicativo ObterPor(Aplicativo oAplicativo)

        {
            MySqlDataReader drCon;
            try
           {
                //Monta comando para a gravação do registro
                String strSQL = "select modulo, Descricao from sect_Aplicativo Where modulo=@modulo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@modulo", oAplicativo.nome.ToUpper());
                drCon = Sqlcon.ExecuteReader();

                Aplicativo objRetorno = new Aplicativo();

                while (drCon.Read())
                {
                    objRetorno.nome = drCon["modulo"].ToString();
                    objRetorno.descricao = drCon["descricao"].ToString();
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

        private void geraOcorrencia(Aplicativo oAplicativo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oAplicativo.nome.ToString();

                if (flag == "A")
                {

                    Aplicativo oApl = new Aplicativo();
                    oApl.nome = "";
                    oApl.nome = oAplicativo.nome;
                    oApl = ObterPor(oApl);

                    if (!oApl.Equals(oAplicativo))
                    {
                        descricao = "Aplicativo " + oAplicativo.nome + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        
                        if (!oApl.descricao.Equals(oAplicativo.descricao))
                        {
                            descricao = descricao + " Descricao de " + oApl.descricao + " para " + oAplicativo.descricao;
                        }                       
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Aplicativo " + oAplicativo.nome + " - " + oAplicativo.descricao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Aplicativo " + oAplicativo.nome + " - " + oAplicativo.descricao + " foi excluido por " + oOcorrencia.usuario.nome;
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


