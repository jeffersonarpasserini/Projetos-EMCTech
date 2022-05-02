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
    public class ClienteDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ClienteDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Cliente objCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Cliente
            try
            {
                geraOcorrencia(objCliente, "I");

                //pega data atual para o cadastro
                objCliente.dataCadastro = DateTime.Now;

                //Monta comando para a gravação do registro
                String strSQL = "insert into Cliente (codempresa, idpessoa, spc, observacao, datacadastro, " + 
                                                     "microempresa, contricms, retemiss, alerta1, avisaalerta1, " + 
                                                     "alerta2, avisaalerta2,dtvalidadealerta) " +
                                " values (@codempresa, @idpessoa, @spc, @observacao, @datacadastro, " + 
                                         "@microempresa, @contricms, @retemiss, @alerta1, @avisaalerta1, " + 
                                         "@alerta2, @avisaalerta2, @dtvalidadealerta)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@spc", objCliente.spc);
                Sqlcon.Parameters.AddWithValue("@observacao", objCliente.observacao);
                Sqlcon.Parameters.AddWithValue("@datacadastro", objCliente.dataCadastro);
                Sqlcon.Parameters.AddWithValue("@microempresa", objCliente.microEmpresa);
                Sqlcon.Parameters.AddWithValue("@contricms", objCliente.contrIcms);
                Sqlcon.Parameters.AddWithValue("@retemiss", objCliente.retemISS);
                Sqlcon.Parameters.AddWithValue("@alerta1", objCliente.alerta1);
                Sqlcon.Parameters.AddWithValue("@avisaalerta1", objCliente.avisoAlerta1);
                Sqlcon.Parameters.AddWithValue("@alerta2", objCliente.alerta2);
                Sqlcon.Parameters.AddWithValue("@avisaalerta2", objCliente.avisoAlerta2);
                Sqlcon.Parameters.AddWithValue("@dtvalidadealerta", objCliente.dtValidadeAlerta);
                
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

        public void Atualizar(Cliente objCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de Contato
            try
            {
                geraOcorrencia(objCliente, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Cliente set  spc=@spc, observacao=@observacao, microempresa=@microempresa, "+
                                                    "contricms=@contricms, retemiss=@retemiss, alerta1=@alerta1, "+
                                                    "avisaalerta1=@avisaalerta1,alerta2=@alerta2, " + 
                                                    "avisaalerta2=@avisaalerta2, dtvalidadealerta=@dtvalidadealerta " +
                                " where codempresa=@codempresa and idpessoa=@idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objCliente.idPessoa);
                Sqlcon.Parameters.AddWithValue("@spc", objCliente.spc);
                Sqlcon.Parameters.AddWithValue("@observacao", objCliente.observacao);
                Sqlcon.Parameters.AddWithValue("@microempresa", objCliente.microEmpresa);
                Sqlcon.Parameters.AddWithValue("@contricms", objCliente.contrIcms);
                Sqlcon.Parameters.AddWithValue("@retemiss", objCliente.retemISS);
                Sqlcon.Parameters.AddWithValue("@alerta1", objCliente.alerta1);
                Sqlcon.Parameters.AddWithValue("@avisaalerta1", objCliente.avisoAlerta1);
                Sqlcon.Parameters.AddWithValue("@alerta2", objCliente.alerta2);
                Sqlcon.Parameters.AddWithValue("@avisaalerta2", objCliente.avisoAlerta2);
                Sqlcon.Parameters.AddWithValue("@dtvalidadealerta", objCliente.dtValidadeAlerta);

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

        public void Excluir(Cliente objCliente)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de Contato
            try
            {
                geraOcorrencia(objCliente, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from Cliente where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objCliente.idPessoa);
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

        public DataTable pesquisaCliente(int empMaster, int idCliente, string nome, string cnpj)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select f.idpessoa, p.nome, p.cnpjcpf from cliente f, pessoa p where p.idpessoa = f.idpessoa " +
                                " and p.codempresa = f.codempresa and f.codempresa = @codempresa ";

                if (idCliente > 0)
                    strSQL += " and f.idpessoa = @idpessoa ";

                if (!String.IsNullOrEmpty(nome.Trim()))
                    strSQL += " and p.nome like @nome ";

                if (!String.IsNullOrEmpty(cnpj.Trim()))
                    strSQL += " and p.cnpjcpf = @cnpj ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empMaster);
                Sqlcon.Parameters.AddWithValue("@idpessoa", idCliente);
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

        public DataTable ListaCliente(Cliente objCliente)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select c.*, p.nome from cliente c, pessoa p where p.idpessoa = c.idpessoa " +
                                " and p.codempresa = c.codempresa and c.codempresa = @codempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objCliente.codEmpresa);
                

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

        public Cliente ObterPor(int empresaMaster, string cnpjcpf)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from v_cliente f Where f.codempresa=@codempresa and f.cnpjcpf=@cnpj";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empresaMaster);
                Sqlcon.Parameters.AddWithValue("@cnpj", cnpjcpf);

                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objCliente.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objCliente.spc = drCon["spc"].ToString();
                    objCliente.observacao = drCon["observacao"].ToString();
                    objCliente.dataCadastro = Convert.ToDateTime(drCon["datacadastro"].ToString());
                    objCliente.microEmpresa = drCon["microempresa"].ToString(); ;
                    objCliente.contrIcms = drCon["contricms"].ToString();
                    objCliente.retemISS = drCon["retemiss"].ToString();
                    objCliente.alerta1 = drCon["alerta1"].ToString();
                    objCliente.avisoAlerta1 = drCon["avisaalerta1"].ToString();
                    objCliente.alerta2 = drCon["alerta2"].ToString();
                    objCliente.avisoAlerta2 = drCon["avisaalerta2"].ToString();
                    objCliente.dtValidadeAlerta = Convert.ToDateTime(drCon["dtvalidadealerta"].ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    //carregando informações de fornecedor vinculado a pessoa
                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = objCliente.codEmpresa;
                    oPessoa.idPessoa = EmcResources.cInt(objCliente.idPessoa.ToString());
                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao, oOcorrencia, codEmpresa);
                    objCliente.pessoa = oPessoaDAO.ObterPessoa(oPessoa);
                    return objCliente;
                }

                drCon.Close();
                drCon.Dispose();
                Cliente objCliente1 = new Cliente();
                return objCliente1;
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
        public Cliente ObterPor(Cliente oCliente)
        {
            MySqlDataReader drCon;

            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from Cliente Where codempresa=@codempresa and idpessoa=@idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oCliente.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oCliente.idPessoa);
                
                drCon = Sqlcon.ExecuteReader();
                
                while (drCon.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    objCliente.idPessoa = Convert.ToInt32(drCon["idpessoa"].ToString());
                    objCliente.spc = drCon["spc"].ToString();
                    objCliente.observacao = drCon["observacao"].ToString();
                    objCliente.dataCadastro = Convert.ToDateTime(drCon["datacadastro"].ToString());
                    objCliente.microEmpresa = drCon["microempresa"].ToString(); ;
                    objCliente.contrIcms = drCon["contricms"].ToString();
                    objCliente.retemISS = drCon["retemiss"].ToString();
                    objCliente.alerta1 = drCon["alerta1"].ToString();
                    objCliente.avisoAlerta1 = drCon["avisaalerta1"].ToString();
                    objCliente.alerta2 = drCon["alerta2"].ToString();
                    objCliente.avisoAlerta2 = drCon["avisaalerta2"].ToString();
                    objCliente.dtValidadeAlerta = Convert.ToDateTime(drCon["dtvalidadealerta"].ToString());

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    //carregando informações de fornecedor vinculado a pessoa
                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = objCliente.codEmpresa;
                    oPessoa.idPessoa = EmcResources.cInt(objCliente.idPessoa.ToString());
                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao,oOcorrencia,codEmpresa);
                    objCliente.pessoa = oPessoaDAO.ObterPessoa(oPessoa);
                    return objCliente;
                }

                drCon.Close();
                drCon.Dispose();
                Cliente objCliente1 = new Cliente();
                return objCliente1;

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

        private void geraOcorrencia(Cliente oCliente, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCliente.idPessoa.ToString();

                if (flag == "A")
                {

                    Cliente oCli = new Cliente();
                    oCli = ObterPor(oCliente);

                    if (!oCli.Equals(oCliente))
                    {
                        descricao = "Cliente " + oCliente.idPessoa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCli.alerta1.Equals(oCliente.alerta1))
                        {
                            descricao += " Alerta1 de " + oCli.alerta1 + " para " + oCliente.alerta1;
                        }
                        if (!oCli.alerta2.Equals(oCliente.alerta2))
                        {
                            descricao += " Alerta2 de " + oCli.alerta2 + " para " + oCliente.alerta2;
                        }
                        if (!oCli.avisoAlerta1.Equals(oCliente.avisoAlerta1))
                        {
                            descricao += " Aviso Alerta1 de " + oCli.avisoAlerta1 + " para " + oCliente.avisoAlerta1;
                        }
                        if (!oCli.avisoAlerta2.Equals(oCliente.avisoAlerta2))
                        {
                            descricao += " Aviso Alerta2 de " + oCli.avisoAlerta2 + " para " + oCliente.avisoAlerta2;
                        }
                        if (!oCli.codEmpresa.Equals(oCliente.codEmpresa))
                        {
                            descricao += " Empresa de " + oCli.codEmpresa + " para " + oCliente.codEmpresa;
                        }
                        if (!oCli.contrIcms.Equals(oCliente.contrIcms))
                        {
                            descricao += " Contr.ICMS de " + oCli.contrIcms + " para " + oCliente.contrIcms;
                        }
                        if (!oCli.dtValidadeAlerta.Equals(oCliente.dtValidadeAlerta))
                        {
                            descricao += " Data Validade Alerta1 de " + oCli.dtValidadeAlerta + " para " + oCliente.dtValidadeAlerta;
                        }
                        if (!oCli.microEmpresa.Equals(oCliente.microEmpresa))
                        {
                            descricao += " Micro Empresa de " + oCli.microEmpresa + " para " + oCliente.microEmpresa;
                        }
                        if (!oCli.observacao.Equals(oCliente.observacao))
                        {
                            descricao += " Observação de " + oCli.observacao + " para " + oCliente.observacao;
                        }
                        if (!oCli.retemISS.Equals(oCliente.retemISS))
                        {
                            descricao += " Retem ISS de " + oCli.retemISS + " para " + oCliente.retemISS;
                        }
                        if (!oCli.spc.Equals(oCliente.spc))
                        {
                            descricao += " SPC de " + oCli.spc + " para " + oCliente.spc;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Cliente " + oCliente.idPessoa + " - Alerta 01 : " + oCliente.alerta1 +
                        " - Alerta 02 : " + oCliente.alerta2 + " - Aviso Alerta 1 :" + oCliente.avisoAlerta1 + " - Aviso Alerta 2 : " + oCliente.avisoAlerta2 +
                        " - Contr. ICMS : " + oCliente.contrIcms + " - Data Cadastro : " + oCliente.dataCadastro + " - Dta Validade Alerta : " + oCliente.dtValidadeAlerta +
                        " - Micro Empresa : " + oCliente.microEmpresa + " - Observacao : " + oCliente.observacao + " - Retem ISS :" + oCliente.retemISS +
                        " - SPC :" + oCliente.spc + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Cliente " + oCliente.idPessoa + " - Alerta 01 : " + oCliente.alerta1 +
                        " - Alerta 02 : " + oCliente.alerta2 + " - Aviso Alerta 1 :" + oCliente.avisoAlerta1 + " - Aviso Alerta 2 : " + oCliente.avisoAlerta2 +
                        " - Contr. ICMS : " + oCliente.contrIcms + " - Data Cadastro : " + oCliente.dataCadastro + " - Dta Validade Alerta : " + oCliente.dtValidadeAlerta +
                        " - Micro Empresa : " + oCliente.microEmpresa + " - Observacao : " + oCliente.observacao + " - Retem ISS :" + oCliente.retemISS +
                        " - SPC :" + oCliente.spc + " foi excluída por " + oOcorrencia.usuario.nome;

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
