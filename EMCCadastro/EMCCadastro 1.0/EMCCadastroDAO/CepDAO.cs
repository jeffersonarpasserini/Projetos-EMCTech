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
    public class CepDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public CepDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Cep objCep)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de CEP
            try
            {

                geraOcorrencia(objCep, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into cep (idcep, cidade, estado, bairro, logradouro, idcepcidade ) " + 
                                " values (@idcep, @cidade, @estado, @bairro, @logradouro, @idcepcidade)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcep", objCep.idCep);
                Sqlcon.Parameters.AddWithValue("@cidade", objCep.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objCep.estado);
                Sqlcon.Parameters.AddWithValue("@bairro", objCep.bairro);
                Sqlcon.Parameters.AddWithValue("@logradouro", objCep.logradouro);
                Sqlcon.Parameters.AddWithValue("@idcepcidade", objCep.cepCidade.cepCidade);
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

        public void Atualizar(Cep objCep)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(objCep, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update cep set logradouro=@logradouro, cidade = @cidade, estado = @estado, bairro = @bairro, idcepcidade=@idcepcidade " + 
                                " where idcep = @idcep";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcep", objCep.idCep);
                Sqlcon.Parameters.AddWithValue("@cidade", objCep.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objCep.estado);
                Sqlcon.Parameters.AddWithValue("@bairro", objCep.bairro);
                Sqlcon.Parameters.AddWithValue("@logradouro", objCep.logradouro);
                Sqlcon.Parameters.AddWithValue("@idcepcidade", objCep.cepCidade.cepCidade);
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

        public void Excluir(Cep objCep)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(objCep, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from cep where idcep = @idcep";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcep", objCep.idCep);

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

        public DataTable pesquisaCep(int empMaster, int idCep, string cidade, string estado, bool checkEstado)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select c.* from cep c ";

                if (idCep > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " c.idcep like @idcep"; 
                }

                if (!String.IsNullOrEmpty(cidade.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " c.cidade like @cidade ";
                }
                if (!String.IsNullOrEmpty(estado.Trim()) && checkEstado)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " c.estado like @estado ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcep", idCep);
                Sqlcon.Parameters.AddWithValue("@cidade", "%" + cidade.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@estado", "%" + estado.Trim() + "%");



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

        public DataTable ListaCep()
        {

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from cep order by idcep";
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

        public DataTable dstRelatorio(string sSQL)
           {
           try
              {
              //Monta comando para a gravação do registro
              //String strSQL = "select * from pessoa order by idpessoa";
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

        public Cep ObterPor(Cep oCep)
        {
            MySqlDataReader drCon;
            Boolean bControle=false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from cep Where ";

                //verifica se o atributo está vazio
                if (oCep.idCep!=null && oCep.idCep!="")
                {
                    strSQL += "idCep = '" + oCep.idCep + "' ";
                }
                if (oCep.cidade!=null && oCep.cidade!="")
                {
                    strSQL += "cidade = '" + oCep.cidade + "' ";
                }
                if (oCep.bairro!=null && oCep.bairro!="")
                {
                    strSQL += "bairro = '" + oCep.bairro + "' ";
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drCon = Sqlcon.ExecuteReader();
                Cep objCep = new Cep();

                while (drCon.Read())
                {
                    bControle = true;

                    objCep.idCep = drCon["idCep"].ToString();
                    objCep.bairro = drCon["bairro"].ToString();
                    objCep.cidade = drCon["cidade"].ToString();
                    objCep.estado = drCon["estado"].ToString();
                    objCep.logradouro = drCon["logradouro"].ToString();

                    Cidade oCidade = new Cidade();
                    oCidade.cepCidade = drCon["idcepcidade"].ToString();

                    objCep.cepCidade = oCidade;
                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bControle)
                {
                    CidadeDAO oCidadeDAO = new CidadeDAO(parConexao, oOcorrencia, codEmpresa);
                    objCep.cepCidade = oCidadeDAO.ObterPor(objCep.cepCidade);
                }
                return objCep;

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

        private void geraOcorrencia(Cep oCep, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCep.idCep;

                if (flag == "A")
                {

                    Cep oCepBk = new Cep();
                    oCepBk.idCep = oCep.idCep;
                    oCepBk = ObterPor(oCepBk);

                    if (!oCepBk.Equals(oCep))
                    {
                        descricao = "CEP " + oCep.idCep + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCepBk.bairro.Equals(oCep.bairro))
                        {
                            descricao += " Bairro de " + oCepBk.bairro + " para " + oCep.bairro;
                        }
                        if (!oCepBk.cidade.Equals(oCep.cidade))
                        {
                            descricao += " Cidade de " + oCepBk.cidade + " para " + oCep.cidade;
                        }
                        if (!oCepBk.estado.Equals(oCep.estado))
                        {
                            descricao += " Estado de " + oCepBk.estado + " para " + oCep.estado;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "CEP : " + oCep.idCep + " - " + oCep.bairro + " - " + oCep.cidade + " - " + oCep.estado + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "CEP : " + oCep.idCep + " - " + oCep.bairro + " - " + oCep.cidade + " - " + oCep.estado + " foi excluida por " + oOcorrencia.usuario.nome;
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
