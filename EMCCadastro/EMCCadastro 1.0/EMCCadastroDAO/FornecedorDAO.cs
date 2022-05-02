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
    public class FornecedorDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FornecedorDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Fornecedor objFornecedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de Fornecedor
            try
            {
                geraOcorrencia(objFornecedor, "I");
                
                //pega data atual para o cadastro
                objFornecedor.dataCadastro = DateTime.Now;

                //Monta comando para a gravação do registro
                String strSQL = "insert into Fornecedor (codempresa, idpessoa, observacao, idbanco, agencia, " +
                                                     "contacorrente, titularconta, datacadastro ) " +
                                " values (@codempresa, @idpessoa, @observacao, @idbanco, @agencia, " +
                                         "@contacorrente, @titularconta, @datacadastro )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objFornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@observacao", objFornecedor.observacao);
                Sqlcon.Parameters.AddWithValue("@idbanco", objFornecedor.banco.idBanco);
                Sqlcon.Parameters.AddWithValue("@agencia", objFornecedor.agencia);
                Sqlcon.Parameters.AddWithValue("@contacorrente", objFornecedor.contaCorrente);
                Sqlcon.Parameters.AddWithValue("@titularconta", objFornecedor.titularConta);
                Sqlcon.Parameters.AddWithValue("@datacadastro", objFornecedor.dataCadastro);
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

        public void Atualizar(Fornecedor objFornecedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Contato
            try
            {
                geraOcorrencia(objFornecedor, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Fornecedor set  observacao=@observacao, idbanco=@idbanco, agencia=@agencia, " +
                                                    "contacorrente=@contacorrente, titularconta=@titularconta, " +
                                                    "datacadastro=@datacadastro " +
                                " where codempresa=@codempresa and idpessoa=@idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objFornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@observacao", objFornecedor.observacao);
                Sqlcon.Parameters.AddWithValue("@idbanco", objFornecedor.banco.idBanco);
                Sqlcon.Parameters.AddWithValue("@agencia", objFornecedor.agencia);
                Sqlcon.Parameters.AddWithValue("@contacorrente", objFornecedor.contaCorrente);
                Sqlcon.Parameters.AddWithValue("@titularconta", objFornecedor.titularConta);
                Sqlcon.Parameters.AddWithValue("@datacadastro", objFornecedor.dataCadastro);
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

        public void Excluir(Fornecedor objFornecedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Contato
            try
            {
                geraOcorrencia(objFornecedor, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from Fornecedor where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objFornecedor.idPessoa);
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

        public DataTable pesquisaFornecedor(int empMaster, int idFornecedor, string nome, string cnpj)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select f.idpessoa, p.nome, p.cnpjcpf from Fornecedor f, pessoa p where p.idpessoa = f.idpessoa " +
                                " and p.codempresa = f.codempresa and f.codempresa = @codempresa ";

                if (idFornecedor>0)
                    strSQL+= " and f.idpessoa = @idpessoa ";

                if (!String.IsNullOrEmpty(nome.Trim()))
                    strSQL += " and p.nome LIKE @nome "; 
                
                if (!String.IsNullOrEmpty(cnpj.Trim()))
                    strSQL += " and p.cnpjcpf = @cnpj ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empMaster);
                Sqlcon.Parameters.AddWithValue("@idpessoa", idFornecedor);
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

        public DataTable ListaFornecedor(Fornecedor objFornecedor)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select f.*, p.nome from Fornecedor f, pessoa p where p.idpessoa = f.idpessoa " + 
                                " and p.codempresa = f.codempresa and f.codempresa = @codempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objFornecedor.codEmpresa);


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

        public Fornecedor ObterPor(int empresaMaster, string cnpjcpf)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from v_fornecedor f Where f.codempresa=@codempresa and f.cnpjcpf=@cnpj";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empresaMaster);
                Sqlcon.Parameters.AddWithValue("@cnpj", cnpjcpf);

                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Fornecedor objFornecedor = new Fornecedor();
                    objFornecedor.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objFornecedor.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objFornecedor.observacao = drCon["observacao"].ToString();
                    objFornecedor.agencia = drCon["agencia"].ToString();
                    objFornecedor.contaCorrente = drCon["contacorrente"].ToString();
                    objFornecedor.titularConta = drCon["titularconta"].ToString();
                    objFornecedor.dataCadastro = Convert.ToDateTime(drCon["datacadastro"].ToString());


                    Banco bco = new Banco();
                    bco.idBanco = Convert.ToInt32(drCon["idbanco"].ToString());

                    //carregando informações de fornecedor vinculado a pessoa
                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = objFornecedor.codEmpresa;
                    oPessoa.idPessoa = EmcResources.cInt(objFornecedor.idPessoa.ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    BancoDAO bcoDAO = new BancoDAO(parConexao, oOcorrencia, codEmpresa);
                    objFornecedor.banco = bcoDAO.ObterPor(bco);

                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao, oOcorrencia, codEmpresa);
                    objFornecedor.pessoa = oPessoaDAO.ObterPessoa(oPessoa);

                    return objFornecedor;
                }

                drCon.Close();
                drCon.Dispose();
                Fornecedor objFornecedor1 = new Fornecedor();
                return objFornecedor1;

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
        public Fornecedor ObterPor(Fornecedor oFornecedor)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Fornecedor Where codempresa=@codempresa and idpessoa=@idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oFornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oFornecedor.idPessoa);
                
                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Fornecedor objFornecedor = new Fornecedor();
                    objFornecedor.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objFornecedor.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objFornecedor.observacao = drCon["observacao"].ToString();
                    objFornecedor.agencia = drCon["agencia"].ToString();
                    objFornecedor.contaCorrente = drCon["contacorrente"].ToString();
                    objFornecedor.titularConta = drCon["titularconta"].ToString();
                    objFornecedor.dataCadastro = Convert.ToDateTime(drCon["datacadastro"].ToString());

                    
                    Banco bco = new Banco();
                    bco.idBanco = Convert.ToInt32(drCon["idbanco"].ToString());

                    //carregando informações de fornecedor vinculado a pessoa
                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = objFornecedor.codEmpresa;
                    oPessoa.idPessoa = EmcResources.cInt(objFornecedor.idPessoa.ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    BancoDAO bcoDAO = new BancoDAO(parConexao,oOcorrencia,codEmpresa);
                    objFornecedor.banco = bcoDAO.ObterPor(bco);

                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao,oOcorrencia,codEmpresa);
                    objFornecedor.pessoa = oPessoaDAO.ObterPessoa(oPessoa);

                    return objFornecedor;
                }

                drCon.Close();
                drCon.Dispose();
                Fornecedor objFornecedor1 = new Fornecedor();
                return objFornecedor1;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon=null;
            }

        }

        private void geraOcorrencia(Fornecedor oFornecedor, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFornecedor.idPessoa.ToString();

                if (flag == "A")
                {

                    Fornecedor oForn = new Fornecedor();
                    oForn = ObterPor(oFornecedor);

                    if (!oForn.Equals(oFornecedor))
                    {
                        descricao = "Fornecedor id " + oFornecedor.idPessoa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oForn.agencia.Equals(oFornecedor.agencia))
                        {
                            descricao += " Agência de " + oForn.agencia + " para " + oFornecedor.agencia;
                        }
                        if (!oForn.banco.Equals(oFornecedor.banco))
                        {
                            descricao += " Banco de " + oForn.banco.idBanco + " para " + oFornecedor.banco.idBanco;
                        }
                        if (!oForn.contaCorrente.Equals(oFornecedor.contaCorrente))
                        {
                            descricao += " Conta Corrente de " + oForn.contaCorrente + " para " + oFornecedor.contaCorrente;
                        }
                        if (!oForn.observacao.Equals(oFornecedor.observacao))
                        {
                            descricao += " Observacao de " + oForn.observacao + " para " + oFornecedor.observacao;
                        }
                        if (!oForn.titularConta.Equals(oFornecedor.titularConta))
                        {
                            descricao += " Titular Conta de " + oForn.titularConta + " para " + oFornecedor.titularConta;
                        }
                        
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Fornecedor " + oFornecedor.idPessoa + " - Agencia : " + oFornecedor.agencia + 
                                " - Banco :" + oFornecedor.banco + " - Conta Corrente " + oFornecedor.contaCorrente +
                                " - Observação : " + oFornecedor.observacao + " - Titular Conta " + oFornecedor.titularConta +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Fornecedor " + oFornecedor.idPessoa + " - Agencia : " + oFornecedor.agencia +
                                " - Banco :" + oFornecedor.banco + " - Conta Corrente " + oFornecedor.contaCorrente +
                                " - Observação : " + oFornecedor.observacao + " - Titular Conta " + oFornecedor.titularConta +
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
