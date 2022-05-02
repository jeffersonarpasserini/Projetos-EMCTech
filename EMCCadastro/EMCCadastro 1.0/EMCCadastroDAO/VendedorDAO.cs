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
    public class VendedorDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public VendedorDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Vendedor objVendedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Empresa
            try
            {
                geraOcorrencia(objVendedor, "I");

                
                //Monta comando para a gravação do registro
                String strSQL = "insert into vendedor (codempresa, idpessoa, taxacomissao) Values (@codempresa, @idpessoa, @taxacomissao)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objVendedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objVendedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@taxacomissao", objVendedor.taxaComissao);
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

        public void Atualizar(Vendedor objVendedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objVendedor, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Vendedor set taxacomissao = @taxacomissao " +
                                                    " Where codempresa = @codempresa " +
                                                    " and idpessoa = @idpessoa";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objVendedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objVendedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@taxacomissao", objVendedor.taxaComissao);
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

        public void Excluir(Vendedor objVendedor)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objVendedor, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from vendedor where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objVendedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objVendedor.idPessoa);

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

        public DataTable ListaVendedor()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select v.*, p.* from vendedor v, pessoa p where v.codempresa = p.codempresa and v.idpessoa = p.idpessoa order by v.codempresa, v.idpessoa";
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

        public Vendedor ObterPor(Vendedor oVendedor)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oVendedor.idPessoa > 0)
                {


                    //Monta comando para a gravação do registro
                    strSQL = "select * from vendedor Where codempresa = " + oVendedor.codEmpresa + " and idpessoa = " + oVendedor.idPessoa + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {

                        Vendedor objRetorno = new Vendedor();
                        objRetorno.codEmpresa =  Convert.ToInt32(drCon["codempresa"]);
                        objRetorno.idPessoa =    Convert.ToInt32(drCon["idpessoa"]);
                        objRetorno.taxaComissao = Convert.ToDecimal(drCon["taxacomissao"]);

                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;
                        
                        
                        //carregando os todos os dados da pessoa com base no vendedor
                        Pessoa oPessoa = new Pessoa();
                        oPessoa.codEmpresa = objRetorno.codEmpresa;
                        oPessoa.idPessoa = EmcResources.cInt(objRetorno.idPessoa.ToString());
                        PessoaDAO oPessoaDAO = new PessoaDAO(parConexao,oOcorrencia,codEmpresa);
                        objRetorno.pessoa = oPessoaDAO.ObterPessoa(oPessoa);

                        
                        return objRetorno;
                    }
                    drCon.Close();
                    drCon.Dispose();
                }
                
                Vendedor objVendedor = new Vendedor();
                return objVendedor;

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

        public bool ExisteCodigo(Vendedor oVendedor)
        {
            MySqlDataReader drCon;
            try
            {
                String strSQL = "";
                //verifica se o atributo está vazio
                if (oVendedor.idPessoa > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from vendedor Where codempresa = " + oVendedor.codEmpresa + 
                        " and idpessoa = " + oVendedor.idPessoa;
                }
                else
                {
                    Exception oErro = new Exception("Informe o código do vendedor");
                    throw oErro;
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    if (!drCon.IsDBNull(0))
                    {
                        drCon.Close();
                        return true;
                    }
                }
                drCon.Close();
                return false;

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

        private void geraOcorrencia(Vendedor oVendedor, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oVendedor.idPessoa.ToString();

                if (flag == "A")
                {

                    Vendedor oVen = new Vendedor();
                    oVen = ObterPor(oVendedor);

                    if (!oVen.Equals(oVendedor))
                    {
                        descricao = "Vendedor " + oVendedor.idPessoa + " - " + oVendedor.pessoa.nome + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oVen.taxaComissao.Equals(oVendedor.taxaComissao))
                        {
                            descricao += " Comissão de " + oVen.taxaComissao + " para " + oVendedor.taxaComissao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Vendedor " + oVendedor.idPessoa + " - " + oVendedor.pessoa.nome + " -  Comissão : " + oVendedor.taxaComissao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Vendedor " + oVendedor.idPessoa + " - " + oVendedor.pessoa.nome + " -  Comissão : " + oVendedor.taxaComissao + " foi excluida por " + oOcorrencia.usuario.nome;
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
