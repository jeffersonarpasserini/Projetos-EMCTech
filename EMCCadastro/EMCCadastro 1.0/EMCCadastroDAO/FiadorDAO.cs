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
    public class FiadorDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FiadorDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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
            }

        }

        public void Salvar(Fiador objFiador)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Fiador
            try
            {
                geraOcorrencia(objFiador, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fiador (codempresa, idfiador, observacao, rendimento ) " + 
                                " values (@codempresa, @idfiador, @observacao, @rendimento )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFiador.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfiador", objFiador.idPessoa);
                Sqlcon.Parameters.AddWithValue("@observacao", objFiador.observacao);
                Sqlcon.Parameters.AddWithValue("@rendimento", objFiador.rendimento);
                
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

        public void Atualizar(Fiador objFiador)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Contato
            try
            {
                geraOcorrencia(objFiador, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Fiador set  observacao=@observacao, rendimento=@rendimento " +
                                " where codempresa=@codempresa and idfiador=@idfiador ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFiador.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfiador", objFiador.idPessoa);
                Sqlcon.Parameters.AddWithValue("@observacao", objFiador.observacao);
                Sqlcon.Parameters.AddWithValue("@rendimento", objFiador.rendimento);

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

        public void Excluir(Fiador objFiador)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Contato
            try
            {
                geraOcorrencia(objFiador, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Fiador where codempresa = @codempresa and idfiador = @idfiador";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFiador.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idfiador", objFiador.idPessoa);
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

        public DataTable pesquisaFiador(int empMaster, int idFiador, string nome, string cnpj)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select f.idfiador, p.nome, p.cnpjcpf from Fiador f, pessoa p where p.idpessoa = f.idfiador " +
                                " and p.codempresa = f.codempresa and f.codempresa = @codempresa ";

                if (idFiador > 0)
                    strSQL += " and f.idfiador = @idfiador ";

                if (!String.IsNullOrEmpty(nome.Trim()))
                    strSQL += " and p.nome like @nome ";

                if (!String.IsNullOrEmpty(cnpj.Trim()))
                    strSQL += " and p.cnpjcpf = @cnpj ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empMaster);
                Sqlcon.Parameters.AddWithValue("@idfiador", idFiador);
                Sqlcon.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@cnpj", cnpj);


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

        public DataTable ListaFiador(Fiador objFiador)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select c.*, p.nome from Fiador c, pessoa p where p.idpessoa = c.idfiador " +
                                " and p.codempresa = c.codempresa and c.codempresa = @codempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFiador.codEmpresa);
                

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

        public Fiador ObterPor(int empresaMaster, string cnpjcpf)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from v_Fiador f Where f.codempresa=@codempresa and f.cnpjcpf=@cnpj";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empresaMaster);
                Sqlcon.Parameters.AddWithValue("@cnpj", cnpjcpf);

                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Fiador objFiador = new Fiador();
                    objFiador.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    objFiador.idPessoa = EmcResources.cInt(drCon["idpessoa"].ToString());
                    objFiador.observacao = drCon["observacao"].ToString();
                    objFiador.rendimento =  EmcResources.cCur(drCon["rendimento"].ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    //carregando informações de fornecedor vinculado a pessoa
                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = objFiador.codEmpresa;
                    oPessoa.idPessoa = EmcResources.cInt(objFiador.idPessoa.ToString());
                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao, oOcorrencia, codEmpresa);
                    objFiador.pessoa = oPessoaDAO.ObterPessoa(oPessoa);
                    return objFiador;
                }

                drCon.Close();
                drCon.Dispose();
                Fiador objFiador1 = new Fiador();
                return objFiador1;
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
        public Fiador ObterPor(Fiador oFiador)
        {
            MySqlDataReader drCon;

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from v_Fiador Where codempresa=@codempresa and idpessoa=@idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oFiador.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oFiador.idPessoa);
                
                drCon = Sqlcon.ExecuteReader();
                
                while (drCon.Read())
                {
                    Fiador objFiador = new Fiador();
                    objFiador.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objFiador.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objFiador.observacao = drCon["observacao"].ToString();
                    objFiador.rendimento = EmcResources.cCur(drCon["rendimento"].ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    //carregando informações de fornecedor vinculado a pessoa
                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = objFiador.codEmpresa;
                    oPessoa.idPessoa = EmcResources.cInt(objFiador.idPessoa.ToString());
                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao,oOcorrencia,codEmpresa);
                    objFiador.pessoa = oPessoaDAO.ObterPessoa(oPessoa);
                    return objFiador;
                }

                drCon.Close();
                drCon.Dispose();
                Fiador objFiador1 = new Fiador();
                return objFiador1;

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

        private void geraOcorrencia(Fiador oFiador, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFiador.idPessoa.ToString();

                if (flag == "A")
                {

                    Fiador oCli = new Fiador();
                    oCli = ObterPor(oFiador);

                    if (!oCli.Equals(oFiador))
                    {
                        descricao = "Fiador " + oFiador.idPessoa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCli.observacao.Equals(oFiador.observacao))
                        {
                            descricao += " Observacao de " + oCli.observacao + " para " + oFiador.observacao;
                        }
                        if (!oCli.rendimento.Equals(oFiador.rendimento))
                        {
                            descricao += " Rendimento de " + oCli.rendimento + " para " + oFiador.rendimento;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Fiador " + oFiador.idPessoa + " - Empresa : " + oFiador.codEmpresa +
                        " - Observação : " + oFiador.observacao + " - rendimento :" + oFiador.rendimento +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Fiador " + oFiador.idPessoa + " - Empresa : " + oFiador.codEmpresa +
                        " - Observação : " + oFiador.observacao + " - rendimento :" + oFiador.rendimento +
                        " foi excluída por " + oOcorrencia.usuario.nome;

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
