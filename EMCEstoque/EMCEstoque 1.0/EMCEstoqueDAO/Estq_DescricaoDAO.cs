using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCEstoqueModel;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCCadastroModel;
using EMCCadastroDAO;



namespace EMCEstoqueDAO
{
    public class Estq_DescricaoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_DescricaoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = pOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = pOcorrencia;
            }
            codEmpresa = idEmpresa;
        }

        public void Salvar(Estq_Descricao objEstq_Descricao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  a partir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'Estq_Descricao'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objEstq_Descricao.idestq_descricao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objEstq_Descricao, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Estq_Descricao (Descricao, idEstq_Produto, cliente_CodEmpresa, cliente_idPessoa) values (@Descricao, @idEstq_Produto, @cliente_CodEmpresa, @cliente_idPessoa)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@Descricao", objEstq_Descricao.descricao);
                Sqlcon.Parameters.AddWithValue("@idEstq_Produto", objEstq_Descricao.Estq_Produto.idestq_produto);
                Sqlcon.Parameters.AddWithValue("@cliente_CodEmpresa", objEstq_Descricao.Cliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@cliente_idPessoa", objEstq_Descricao.Cliente.idPessoa);
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

        public void Atualizar(Estq_Descricao objEstq_Descricao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objEstq_Descricao, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update Estq_Descricao set descricao = @descricao where idestq_descricao = @idestq_descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_descricao", objEstq_Descricao.idestq_descricao);
                Sqlcon.Parameters.AddWithValue("@descricao", objEstq_Descricao.descricao);
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

        public void Excluir(Estq_Descricao objEstq_Descricao)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objEstq_Descricao, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Estq_Descricao where idEstq_descricao = @idEstq_descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idestq_descricao", objEstq_Descricao.idestq_descricao);

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

        public DataTable ListaEstq_Descricao()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select D.*, PR.Descricao as Produto, P.Nome as Cliente from Estq_Descricao D, Estq_Produto PR, Pessoa P where PR.idEstq_Produto = D.idEstq_Produto and P.CodEmpresa = D.cliente_CodEmpresa and P.IdPessoa = D.cliente_IdPessoa order by D.cliente_CodEmpresa, D.cliente_idPessoa, D.idEstq_Produto";
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

        public Estq_Descricao ObterPor(Estq_Descricao oEstq_Descricao)
        {
            MySqlDataReader drCon;
            try
            {

                if (oEstq_Descricao.idestq_descricao > 0)
                {
                    //se informado a chave da tabela
                    String strSQL = "select * from Estq_Descricao Where idEstq_Descricao = @idEstq_Descricao";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idEstq_Descricao", oEstq_Descricao.idestq_descricao);
                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //se não informado a chave da tabela, faz a busca pelo Produto e Fornecedor
                    String strSQL = "select * from Estq_Descricao Where idEstq_Produto = @idEstq_Produto and cliente_CodEmpresa = @cliente_CodEmpresa and cliente_idPessoa = @cliente_idPessoa";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idEstq_Produto", oEstq_Descricao.Estq_Produto.idestq_produto);
                    Sqlcon.Parameters.AddWithValue("@cliente_CodEmpresa", oEstq_Descricao.Cliente.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@cliente_idPessoa", oEstq_Descricao.Cliente.idPessoa);
                    drCon = Sqlcon.ExecuteReader();
                }

                Estq_Descricao objEstq_Descricao = new Estq_Descricao();

                while (drCon.Read())
                {

                    objEstq_Descricao.idestq_descricao = Convert.ToInt32(drCon["idEstq_Descricao"].ToString());
                    objEstq_Descricao.descricao = drCon["descricao"].ToString();

                    //Carregando o produto
                    Estq_Produto oEstq_Produto = new Estq_Produto();
                    oEstq_Produto.idestq_produto = Convert.ToInt32(drCon["idEstq_Produto"].ToString());
                    //Carregando o cliente
                    Cliente oCliente = new Cliente();
                    oCliente.codEmpresa = Convert.ToInt32(drCon["cliente_CodEmpresa"].ToString());
                    oCliente.idPessoa = Convert.ToInt32(drCon["cliente_idPessoa"].ToString());
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();
                    //lendo dados do Produto
                    Estq_ProdutoDAO oEstq_ProdutoDAO = new Estq_ProdutoDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Descricao.Estq_Produto = oEstq_ProdutoDAO.ObterPor(oEstq_Produto);
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();
                    //lendo os dados do Fornecedor
                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao, oOcorrencia,codEmpresa);
                    objEstq_Descricao.Cliente = oClienteDAO.ObterPor(oCliente);
                    //fechando o datareader para abrir outro
                    drCon.Close();
                    drCon.Dispose();

                    return objEstq_Descricao;
                }


                drCon.Close();
                drCon.Dispose();
                Estq_Descricao objEstq_Descricao1 = new Estq_Descricao();
                return objEstq_Descricao1;

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

        private void geraOcorrencia(Estq_Descricao oEstq_Descricao, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEstq_Descricao.idestq_descricao.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Estq_Descricao oCobr = new Estq_Descricao();
                    oCobr = ObterPor(oEstq_Descricao);

                    if (!oCobr.Equals(oEstq_Descricao))
                    {
                        descricao = "Produto Cliente id: " + oEstq_Descricao.idestq_descricao + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCobr.idestq_descricao.Equals(oEstq_Descricao.idestq_descricao))
                        {
                            descricao += " Descrição Personalizada " + oCobr.descricao + " para " + oEstq_Descricao.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Produto Cliente : " + oEstq_Descricao.idestq_descricao + " foi incluído por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Produto Cliente : " + oEstq_Descricao.idestq_descricao + " foi excluído por " + oOcorrencia.usuario.nome;
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
