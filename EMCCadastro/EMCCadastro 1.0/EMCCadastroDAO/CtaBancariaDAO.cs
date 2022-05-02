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
    public class CtaBancariaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public CtaBancariaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void atualizarSaldos(MySqlConnection Conexao, MySqlTransaction Transacao, String Operacao, String tipoMovimento, Decimal valorAtual, Decimal valorAnterior, CtaBancaria ctaBancaria )
        {
            try
            {

                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                //verifica o parametro se gera ocorrencias para atualização de saldos nas contas bancarias
                if (oParametroDAO.retParametro(ctaBancaria.codEmpresa, "EMCCADASTRO", "CTABANCARIA", "OCORRENCIA_SALDO") == "S")
                {
                    geraOcorrencia(ctaBancaria, "AS");
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, Transacao);
                }

                //Monta comando para a gravação do registro
                String strSQL = "update ctabancaria set saldoatual=saldoatual+@valormovimento  " +
                                "where idempresa = @idempresa and idctabancaria = @idctabancaria";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", ctaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", ctaBancaria.idCtaBancaria);

                if (Operacao == "A")
                {
                    if (tipoMovimento == "C")
                        Sqlcon.Parameters.AddWithValue("@valormovimento", (valorAtual - valorAnterior));
                    else
                        Sqlcon.Parameters.AddWithValue("@valormovimento", ((valorAtual - valorAnterior) * -1));

                }
                else if (Operacao=="E")
                {

                    if (tipoMovimento == "D")
                        Sqlcon.Parameters.AddWithValue("@valormovimento", valorAtual);
                    else
                        Sqlcon.Parameters.AddWithValue("@valormovimento", (valorAtual * -1));

                }
                else if (Operacao == "I")
                {

                    if (tipoMovimento == "D")
                        Sqlcon.Parameters.AddWithValue("@valormovimento", (valorAtual*-1));
                    else
                        Sqlcon.Parameters.AddWithValue("@valormovimento", (valorAtual));

                }
                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

               

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(CtaBancaria oConta)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {

                geraOcorrencia(oConta, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into ctabancaria (idempresa, idctabancaria, descricao, cedente, cedentedigito, agencia, agenciadigito, conta, contadigito, idbanco, limite, venclimite, saldoatual, saldofechamento, contacaixa ) " + 
                                " values (@idempresa, @idctabancaria, @descricao, @cedente, @cedentedigito, @agencia, @agenciadigito, @conta, @contadigito, @idbanco, @limite, @venclimite, @saldoatual, @saldofechamento, @contacaixa)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oConta.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@descricao", oConta.descricao);
                Sqlcon.Parameters.AddWithValue("@cedente", oConta.cedente);
                Sqlcon.Parameters.AddWithValue("@cedentedigito", oConta.cedenteDigito);
                Sqlcon.Parameters.AddWithValue("@conta", oConta.conta);
                Sqlcon.Parameters.AddWithValue("@contadigito", oConta.contaDigito);
                Sqlcon.Parameters.AddWithValue("@agencia", oConta.agencia);
                Sqlcon.Parameters.AddWithValue("@agenciadigito", oConta.agenciaDigito);
                Sqlcon.Parameters.AddWithValue("@idbanco", oConta.Banco.idBanco);
                Sqlcon.Parameters.AddWithValue("@limite", oConta.limite);
                Sqlcon.Parameters.AddWithValue("@venclimite", oConta.VencLimite);
                Sqlcon.Parameters.AddWithValue("@saldoatual", 0);
                Sqlcon.Parameters.AddWithValue("@saldofechamento", 0);
                Sqlcon.Parameters.AddWithValue("@contacaixa", oConta.contaCaixa);
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

        public void Atualizar(CtaBancaria oConta)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oConta, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update ctabancaria set descricao = @descricao, agencia = @agencia, agenciadigito=@agenciadigito, conta = @conta, contadigito=@contadigito,  " +
                                                       "cedente=@cedente,cedentedigito=@cedentedigito, " +
                                                       "idbanco = @idbanco, limite = @limite, " +
                                                       "venclimite = @venclimite, contacaixa=@contacaixa " +
                                "where idempresa = @idempresa and idctabancaria = @idctabancaria";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oConta.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@descricao", oConta.descricao);
                Sqlcon.Parameters.AddWithValue("@cedente", oConta.cedente);
                Sqlcon.Parameters.AddWithValue("@cedentedigito", oConta.cedenteDigito);
                Sqlcon.Parameters.AddWithValue("@conta", oConta.conta);
                Sqlcon.Parameters.AddWithValue("@contadigito", oConta.contaDigito);
                Sqlcon.Parameters.AddWithValue("@agencia", oConta.agencia);
                Sqlcon.Parameters.AddWithValue("@agenciadigito", oConta.agenciaDigito);
                Sqlcon.Parameters.AddWithValue("@idbanco", oConta.Banco.idBanco);
                Sqlcon.Parameters.AddWithValue("@limite", oConta.limite);
                Sqlcon.Parameters.AddWithValue("@venclimite", oConta.VencLimite);
                Sqlcon.Parameters.AddWithValue("@contacaixa", oConta.contaCaixa);
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

        public void Excluir(CtaBancaria oConta)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oConta, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from ctabancaria where idempresa = @idempresa and idctabancaria = @idctabancaria";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oConta.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oConta.idCtaBancaria);
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

        public DataTable ListaCtaCaixa(CtaBancaria oConta)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select cb.*, b.descricao as descricaobanco, e.nomefantasia as empresa " +
                               " from ctabancaria cb, banco b, empresa e " +
                               " Where cb.idbanco=b.idbanco " +
                               "   and e.idempresa = cb.idempresa " +
                               "   and cb.contacaixa = 'S' " +
                               "   and cb.idempresa = " + oConta.codEmpresa +
                               " order by idctabancaria";
                //String strSQL = "select * from ctabancaria where idempresa = " + oConta.codEmpresa + " order by idctabancaria ";
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

        public DataTable ListaCtaBancaria(CtaBancaria oConta)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select cb.*, b.descricao as descricaobanco, e.nomefantasia as empresa " + 
                               " from ctabancaria cb, banco b, empresa e " +
                               " Where cb.idbanco=b.idbanco " + 
                               "   and e.idempresa = cb.idempresa " +
                               "   and cb.idempresa = " + oConta.codEmpresa + 
                               " order by idctabancaria";
                //String strSQL = "select * from ctabancaria where idempresa = " + oConta.codEmpresa + " order by idctabancaria ";
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

        public DataTable pesquisaCtaBancaria(int empMaster, int idctabancaria, int conta, int agencia, int idBanco)
        {
            try
            {

                String strSQL = "select cb.*, b.descricao as descricaobanco, e.nomefantasia as empresa from ctabancaria cb, banco b, empresa e "
                                 + " Where cb.idbanco=b.idbanco and cb.idempresa = e.idempresa";
               // if (idctabancaria > 0)
               // {
               //     strSQL += " cb.idctabancaria =@idCtaBancaria";
               // }
                if (conta > 0)
                {
                    strSQL += " and cb.conta =@conta";
                }
                if (idBanco > 0)
                {
                    strSQL += " and cb.idbanco =@idBanco";
                }
                if (agencia > 0)
                {
                    strSQL += " and cb.agencia =@agencia";
                }
                strSQL += " order by descricao";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idCtaBancaria", idctabancaria);
                Sqlcon.Parameters.AddWithValue("@conta", conta);
                Sqlcon.Parameters.AddWithValue("@idBanco", idBanco);
                Sqlcon.Parameters.AddWithValue("@agencia", agencia);


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

        public DataTable dstRelatorio(String sSQL)
           {

           try
              {
              //Monta comando para a gravação do registro
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

       public CtaBancaria ObterPor(CtaBancaria oConta)
        {
            MySqlDataReader drConta;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from ctabancaria Where idempresa = " + oConta.codEmpresa + 
                                                           " and idctabancaria = " + oConta.idCtaBancaria;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                while (drConta.Read())
                {

                    //localiza banco da contabancaria
                    Banco oBanco = new Banco();
                    

                    CtaBancaria objCta = new CtaBancaria();
                    objCta.codEmpresa = Convert.ToInt32(drConta["idempresa"]);
                    objCta.idCtaBancaria = Convert.ToInt32(drConta["idctabancaria"]);
                    oBanco.idBanco = Convert.ToInt32(drConta["idbanco"]);
                    objCta.descricao = Convert.ToString(drConta["descricao"]);
                    objCta.agencia = Convert.ToString(drConta["agencia"]);
                    objCta.agenciaDigito = Convert.ToString(drConta["agenciadigito"]);
                    objCta.conta = Convert.ToString(drConta["conta"]);
                    objCta.contaDigito = Convert.ToString(drConta["contadigito"]);
                    objCta.cedente = Convert.ToString(drConta["cedente"]);
                    objCta.cedenteDigito = Convert.ToString(drConta["cedentedigito"]);
                    objCta.Banco = oBanco;
                    objCta.limite = Convert.ToDouble(drConta["limite"]);
                    objCta.VencLimite = Convert.ToDateTime(drConta["venclimite"]);
                    objCta.contaCaixa = drConta["contacaixa"].ToString();
                    if (drConta["dtafechamento"] is DBNull)
                    {
                       
                    }
                    else
                    {
                        objCta.dataFechamento = Convert.ToDateTime(drConta["dtafechamento"]);
                    }

                    if (drConta["saldofechamento"] is DBNull)
                    {
                        objCta.sdoFechamento = 0;
                    }
                    else
                    {
                        objCta.sdoFechamento = Convert.ToDouble(drConta["saldofechamento"]);
                    }

                    if (drConta["saldoatual"] is DBNull)
                    {
                        objCta.saldoAtual = 0;
                    }
                    else
                    {
                        objCta.saldoAtual = Convert.ToDouble(drConta["saldoatual"]);
                    }

                    drConta.Close();
                    drConta.Dispose();


                    BancoDAO BcoDAO = new BancoDAO(parConexao,oOcorrencia,codEmpresa);
                    oBanco = BcoDAO.ObterPor(oBanco);

                    return objCta;
                }

                drConta.Close();
                drConta.Dispose();
                CtaBancaria objCta1 = new CtaBancaria();
                return objCta1;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drConta = null;
            }

        }

        private void geraOcorrencia(CtaBancaria oConta, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oConta.idCtaBancaria.ToString();

                if (flag == "A" || flag=="AS")
                {

                    CtaBancaria oCta = new CtaBancaria();
                    oCta = ObterPor(oConta);

                    if (flag == "AS")
                    {
                        descricao = " Atualização de Saldo : de " + oCta.saldoAtual + " para " +oConta.saldoAtual + " da Conta Bancaria : " + oConta.idCtaBancaria + " - Nro Agencia : " + oConta.agencia +
                                " Digito Agência : " + oConta.agenciaDigito + " - Banco : " + oConta.Banco +
                                " - Codigo Cedente : " + oConta.cedente + " - Digito Cedente : " + oConta.cedenteDigito +
                                " - Nro Conta : " + oConta.conta + " - Digito Conta : " + oConta.contaDigito +
                                " - Descrição : " + oConta.descricao + " - Limite : " + oConta.limite +
                                " - Vencimento Limite : " + oConta.VencLimite + " foi excluída por " + oOcorrencia.usuario.nome;
                    }

                    if (!oCta.Equals(oConta) && flag=="A")
                    {
                        descricao = "Cta Bancaria :" + oConta.idCtaBancaria + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCta.agencia.Equals(oConta.agencia))
                        {
                            descricao += " Nro Agência de " + oCta.agencia + " para " + oConta.agencia;
                        }
                        if (!oCta.agenciaDigito.Equals(oConta.agenciaDigito))
                        {
                            descricao += " Digito Agência de " + oCta.agenciaDigito + " para " + oConta.agenciaDigito;
                        }
                        if (!oCta.Banco.idBanco.Equals(oConta.Banco.idBanco))
                        {
                            descricao += " Nro Banco " + oCta.Banco.idBanco + " para " + oConta.Banco.idBanco;
                        }
                        if (!oCta.cedente.Equals(oConta.cedente))
                        {
                            descricao += " Nro Cedente de " + oCta.cedente + " para " + oConta.cedente;
                        }
                        if (!oCta.cedenteDigito.Equals(oConta.cedenteDigito))
                        {
                            descricao += " Nro Cedente Digito de " + oCta.cedenteDigito + " para " + oConta.cedenteDigito;
                        }
                        if (!oCta.conta.Equals(oConta.conta))
                        {
                            descricao += " Nro Conta de " + oCta.conta + " para " + oConta.conta;
                        }
                        if (!oCta.contaDigito.Equals(oConta.contaDigito))
                        {
                            descricao += " Nro Digito Conta de " + oCta.contaDigito + " para " + oConta.contaDigito;
                        }
                        if (!oCta.descricao.Equals(oConta.descricao))
                        {
                            descricao += " Descrição de " + oCta.descricao + " para " + oConta.descricao;
                        }
                        if (!oCta.limite.Equals(oConta.limite))
                        {
                            descricao += " Limite de " + oCta.limite + " para " + oConta.limite;
                        }
                        if (!oCta.VencLimite.Equals(oConta.VencLimite))
                        {
                            descricao += " Vencimento Limite de " + oCta.VencLimite + " para " + oConta.VencLimite;
                        }
                        if (!oCta.contaCaixa.Equals(oConta.contaCaixa))
                        {
                            descricao += " Conta Caixa de " + oCta.contaCaixa + " para " + oConta.contaCaixa;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = " Conta Bancaria : " + oConta.idCtaBancaria + " - Nro Agencia : " + oConta.agencia +
                                " Digito Agência : " + oConta.agenciaDigito + " - Banco : " + oConta.Banco +
                                " - Codigo Cedente : " + oConta.cedente + " - Digito Cedente : " + oConta.cedenteDigito +
                                " - Nro Conta : " + oConta.conta + " - Digito Conta : " + oConta.contaDigito +
                                " - Descrição : " + oConta.descricao + " - Limite : " + oConta.limite +
                                " - Vencimento Limite : " + oConta.VencLimite + 
                                " - Conta Caixa : " + oConta.contaCaixa +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Conta Bancaria : " + oConta.idCtaBancaria + " - Nro Agencia : " + oConta.agencia +
                                " Digito Agência : " + oConta.agenciaDigito + " - Banco : " + oConta.Banco +
                                " - Codigo Cedente : " + oConta.cedente + " - Digito Cedente : " + oConta.cedenteDigito +
                                " - Nro Conta : " + oConta.conta + " - Digito Conta : " + oConta.contaDigito +
                                " - Descrição : " + oConta.descricao + " - Limite : " + oConta.limite +
                                " - Vencimento Limite : " + oConta.VencLimite +
                                " - Conta Caixa : " + oConta.contaCaixa +
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
