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
    public class ParametroDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ParametroDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                codEmpresa = idEmpresa;
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
                codEmpresa = idEmpresa;
            }
            codEmpresa = idEmpresa;
        }    
        public ParametroDAO(ConectaBancoMySql pConexao)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql myConexao = new ConectaBancoMySql();
                Conexao = myConexao.getConexao();
            }
            else
            {
                Conexao = pConexao.getConexao();
            }
        }

        /// <summary>
        /// Realiza a gravação de um novo parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns></returns>
        
        public void Salvar(Parametro objParametro)
        {           
            //Grava um novo registro de Parametro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'parametro'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    objParametro.idParametro = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;
                

                //Monta comando para a gravação do registro
                String strSQL = "insert into parametro (idparametro, codempresa, aplicacao, sessao, chave, tipo, valor, descricao) values (@idparametro, @codempresa, @aplicacao, @sessao, @chave, @tipo, @valor, @descricao)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idparametro", objParametro.idParametro);
                Sqlcon.Parameters.AddWithValue("@codempresa", objParametro.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@aplicacao", objParametro.aplicacao);
                Sqlcon.Parameters.AddWithValue("@sessao", objParametro.sessao);
                Sqlcon.Parameters.AddWithValue("@chave", objParametro.chave);
                Sqlcon.Parameters.AddWithValue("@tipo", objParametro.tipo);
                Sqlcon.Parameters.AddWithValue("@valor", objParametro.valor);
                Sqlcon.Parameters.AddWithValue("@descricao", objParametro.descricao);
                Sqlcon.ExecuteNonQuery();
                
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
   
        /// <summary>
        /// Realiza a alteracao de um parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns></returns>
    
        public void Atualizar(Parametro objParametro)
        {
            //atualiza um registro
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "update parametro set aplicacao=@aplicacao, sessao=@sessao, chave=@chave, tipo=@tipo, valor=@valor, " + 
                                 " descricao=@descricao, codempresa=@codempresa  where idparametro = @idparametro";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idparametro", objParametro.idParametro);
                Sqlcon.Parameters.AddWithValue("@aplicacao", objParametro.aplicacao);
                Sqlcon.Parameters.AddWithValue("@sessao", objParametro.sessao);
                Sqlcon.Parameters.AddWithValue("@chave", objParametro.chave);
                Sqlcon.Parameters.AddWithValue("@tipo", objParametro.tipo);
                Sqlcon.Parameters.AddWithValue("@valor", objParametro.valor);
                Sqlcon.Parameters.AddWithValue("@descricao", objParametro.descricao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objParametro.codEmpresa);
                //abre conexao e executa o comando

                Sqlcon.ExecuteNonQuery();

                //falta implementar a gravação de empresas
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }    

        /// <summary>
        /// Realiza a exclusao de um parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns></returns>
   
        public void Excluir(Parametro objParametro)
        {
            //apaga registro
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "delete from parametro where idparametro = @idparametro";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idparametro", objParametro.idParametro);

                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
   
        /// <summary>
        /// Lista os Parametros Cadastrados em um Banco de Dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns name="datatable">Retorna um datatable com os parametros do banco de dados</returns>
        public DataTable ListaParametro(Parametro objParametro)
        {
            try
            {
                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();
                String strSQL = "";

                if (objParametro.codEmpresa > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from parametro where codempresa = @codempresa order by aplicacao, sessao, chave";
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from parametro where codempresa = @codempresa ";

                    if (!String.IsNullOrEmpty(objParametro.aplicacao))
                        strSQL += " and aplicacao=@aplicacao ";
                    if (!String.IsNullOrEmpty(objParametro.sessao))
                        strSQL += " and sessao=@sessao ";
                    if (!String.IsNullOrEmpty(objParametro.chave))
                        strSQL += " and chave=@chave ";

                    strSQL+=" order by aplicacao, sessao, chave";

                    objParametro.codEmpresa = codEmpresa;
                    
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objParametro.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@aplicacao", objParametro.aplicacao);
                Sqlcon.Parameters.AddWithValue("@sessao", objParametro.sessao);
                Sqlcon.Parameters.AddWithValue("@Chave", objParametro.chave);

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
        /// retorna o valor de um parametro do sistema 
        /// </summary>
        /// <param name="codempresa">codigo da empresa ou empresa master</param>
        /// <param name="Aplicacao">codigo da aplicacao</param>
        /// <param name="Sessao">codigo da sessao</param>
        /// <param name="Chave">codigo da chave</param>
        /// <returns name="Valor (string)">Retorna uma string com o valor assumido pelo parametro solicitado</returns>
        public string retParametro(int codEmpresa, string Aplicacao, string Sessao, string Chave)
        {
            string retChave="";
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from parametro Where codempresa=@codempresa and aplicacao=@aplicacao and sessao=@sessao and chave=@chave";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                Sqlcon.Parameters.AddWithValue("@aplicacao", Aplicacao);
                Sqlcon.Parameters.AddWithValue("@sessao", Sessao);
                Sqlcon.Parameters.AddWithValue("@chave", Chave);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    retChave = drCon["valor"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                return retChave;

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

        /// <summary>
        /// Busca informações de um objeto parametro no banco de dados
        /// </summary>
        /// <param name="objParametro"></param>
        /// <returns name="datatable">Retorna um datatable com os parametros do banco de dados</returns>     
        public Parametro ObterPor(Parametro objParametro)
        {            
            MySqlDataReader drCon;

            try
            {
                if (objParametro.idParametro > 0)
                {
                    //Monta comando para a gravação do registro
                    String strSQL = "select * from parametro Where idparametro=@idparametro";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idparametro", objParametro.idParametro);

                    drCon = Sqlcon.ExecuteReader();
                }
                else 
                {
                    String strSQL = "select * from parametro Where aplicacao=@aplicacao and sessao=@sessao and chave=@chave and codempresa = @codempresa";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@aplicacao", objParametro.aplicacao);
                    Sqlcon.Parameters.AddWithValue("@sessao", objParametro.sessao);
                    Sqlcon.Parameters.AddWithValue("@chave", objParametro.chave);
                    Sqlcon.Parameters.AddWithValue("@codempresa", objParametro.codEmpresa);

                    drCon = Sqlcon.ExecuteReader();
                }

                Parametro oParametro = new Parametro();
                while (drCon.Read())
                {
                    oParametro.idParametro = Convert.ToInt32(drCon["idparametro"].ToString());
                    oParametro.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    oParametro.aplicacao = drCon["aplicacao"].ToString();
                    oParametro.sessao = drCon["sessao"].ToString();
                    oParametro.chave = drCon["chave"].ToString();
                    oParametro.tipo = drCon["tipo"].ToString();
                    oParametro.valor = drCon["valor"].ToString();
                    oParametro.descricao = drCon["descricao"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                return oParametro;

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

        private void geraOcorrencia(Parametro oParametro, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao, oOcorrencia, codEmpresa);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oParametro.idParametro.ToString();

                if (flag == "A")
                {

                    Parametro oParam = new Parametro();
                    oParam = ObterPor(oParametro);

                    if (!oParam.Equals(oParametro) && flag == "A")
                    {
                        descricao = "Parametro :" + oParametro.idParametro + " - " + oParametro.aplicacao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        //if (!oParam.aplicacao.Equals(oParametro.aplicacao))
                        //{
                        //    descricao += " Aplicação : " + oParam.aplicacao + " para " + oParametro.aplicacao;
                        //}
                        if (!oParam.sessao.Equals(oParametro.sessao))
                        {
                            descricao += " Sessão : " + oParam.sessao + " para " + oParametro.sessao;
                        }
                        if (!oParam.chave.Equals(oParametro.chave))
                        {
                            descricao += " Chave : " + oParam.chave + " para " + oParametro.chave;
                        }
                        if (!oParam.tipo.Equals(oParametro.tipo))
                        {
                            descricao += " Tipo : " + oParam.tipo + " para " + oParametro.tipo;
                        }
                        if (!oParam.valor.Equals(oParametro.valor))
                        {
                            descricao += " Valor : " + oParam.valor + " para " + oParametro.valor;
                        }
                        if (!oParam.descricao.Equals(oParametro.descricao))
                        {
                            descricao += " Descrição : " + oParam.descricao + " para " + oParametro.descricao;
                        }
                        //if (!oParam.codEmpresa.Equals(oParametro.codEmpresa))
                        //{
                        //    descricao += " Código Empresa : " + oParam.codEmpresa + " para " + oParametro.codEmpresa;
                        //}
                        
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Parametro : " + oParametro.idParametro
                              + " - Aplicação : " + oParametro.aplicacao
                              + " - Sessão : " + oParametro.sessao
                              + " - Chave : " + oParametro.chave
                              + " - Tipo : " + oParametro.tipo
                              + " - Valor : " + oParametro.valor
                              + " - Descrição : " + oParametro.descricao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Parametro : " + oParametro.idParametro
                              + " - Aplicação : " + oParametro.aplicacao
                              + " - Sessão : " + oParametro.sessao
                              + " - Chave : " + oParametro.chave
                              + " - Tipo : " + oParametro.tipo
                              + " - Valor : " + oParametro.valor
                              + " - Descrição : " + oParametro.descricao +
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
