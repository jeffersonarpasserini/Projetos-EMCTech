using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCFinanceiroModel;


namespace EMCFinanceiroDAO
{
    public class FormularioDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public FormularioDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        /*
        public void atualizarSaldos(MySqlConnection Conexao, MySqlTransaction Transacao, String Operacao, String tipoMovimento, Decimal valorAtual, Decimal valorAnterior, Formulario Formulario )
        {
            try
            {

                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                //verifica o parametro se gera ocorrencias para atualização de saldos nas contas bancarias
                if (oParametroDAO.retParametro(Formulario.codEmpresa, "EMCCADASTRO", "Formulario", "OCORRENCIA_SALDO") == "S")
                {
                    geraOcorrencia(Formulario, "AS");
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao);
                    oOcoDAO.Salvar(oOcorrencia, Transacao);
                }

                //Monta comando para a gravação do registro
                String strSQL = "update Formulario set saldoatual=saldoatual+@valormovimento  " +
                                "where idempresa = @idempresa and idFormulario = @idFormulario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", Formulario.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idFormulario", Formulario.idFormulario);

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

          */

        public void Salvar(Formulario oFormulario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'formulario'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oFormulario.idFormulario = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oFormulario, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Formulario (idempresa, idctabancaria, descricao, tipoformulario, nroinicial, nrofinal, " + 
                                                        "nroatual, dtainicio, dtafinal, carteiracobranca, situacao, idlayoutcheque ) " + 
                                " values (@idempresa, @idctabancaria, @descricao, @tipoformulario, @nroinicial, @nrofinal, @nroatual, " + 
                                         "@dtainicio, @dtafinal, @carteiracobranca, @situacao, @idlayoutcheque )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oFormulario.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oFormulario.contaBancaria.idCtaBancaria );
                Sqlcon.Parameters.AddWithValue("@descricao", oFormulario.descricaoFormulario);
                Sqlcon.Parameters.AddWithValue("@tipoformulario", oFormulario.tipoFormulario);
                Sqlcon.Parameters.AddWithValue("@nroinicial", oFormulario.nroInicial);
                Sqlcon.Parameters.AddWithValue("@nrofinal", oFormulario.nroFinal);
                Sqlcon.Parameters.AddWithValue("@nroatual", oFormulario.nroAtual);
                Sqlcon.Parameters.AddWithValue("@dtainicio", oFormulario.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", oFormulario.dtaFinal);
                Sqlcon.Parameters.AddWithValue("@carteiracobranca", oFormulario.carteiraCobranca);
                Sqlcon.Parameters.AddWithValue("@situacao", oFormulario.situacao);
                Sqlcon.Parameters.AddWithValue("@idlayoutcheque", oFormulario.layoutCheque.idLayoutCheque);
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

        public void Atualizar(Formulario oFormulario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oFormulario, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Formulario set idempresa=@idempresa, idctabancaria=@idctabancaria, descricao=@descricao, " + 
                                                      "tipoformulario=@tipoformulario, nroinicial=@nroinicial, nrofinal=@nrofinal, " + 
                                                      "nroatual=@nroatual, dtainicio=@dtainicio, dtafinal=@dtafinal, " + 
                                                      "carteiracobranca=@carteiracobranca, situacao=@situacao,  " +
                                                      "idlayoutcheque=@layout " +
                                                      "where idFormulario = @idFormulario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oFormulario.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oFormulario.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@descricao", oFormulario.descricaoFormulario);
                Sqlcon.Parameters.AddWithValue("@tipoformulario", oFormulario.tipoFormulario);
                Sqlcon.Parameters.AddWithValue("@nroinicial", oFormulario.nroInicial);
                Sqlcon.Parameters.AddWithValue("@nrofinal", oFormulario.nroFinal);
                Sqlcon.Parameters.AddWithValue("@nroatual", oFormulario.nroAtual);
                Sqlcon.Parameters.AddWithValue("@dtainicio", oFormulario.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", oFormulario.dtaFinal);
                Sqlcon.Parameters.AddWithValue("@carteiracobranca", oFormulario.carteiraCobranca);
                Sqlcon.Parameters.AddWithValue("@situacao", oFormulario.situacao);
                Sqlcon.Parameters.AddWithValue("@idFormulario", oFormulario.idFormulario);
                Sqlcon.Parameters.AddWithValue("@layout", oFormulario.layoutCheque.idLayoutCheque);
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

        public void AtualizaControle(Formulario oFormulario, MySqlConnection Conecta, MySqlTransaction Transacao)
        {
            try
            {
                geraOcorrencia(oFormulario, "AC");

                if (EmcResources.cInt(oFormulario.nroAtual)+1 >= EmcResources.cInt(oFormulario.nroFinal))
                {
                    oFormulario.situacao = "F";
                }
                //Monta comando para a gravação do registro
                String strSQL = "update Formulario set nroatual=@nroatual, situacao=@situacao  " +
                                                      "where idFormulario = @idFormulario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, Transacao);
                Sqlcon.Parameters.AddWithValue("@nroatual", (EmcResources.cInt(oFormulario.nroAtual)+1).ToString());
                Sqlcon.Parameters.AddWithValue("@situacao", oFormulario.situacao);
                Sqlcon.Parameters.AddWithValue("@idFormulario", oFormulario.idFormulario);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public void Excluir(Formulario oFormulario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oFormulario, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from Formulario where idFormulario = @idFormulario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idFormulario", oFormulario.idFormulario);
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

        public DataTable ListaFormulario(Formulario oFormulario)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select f.idformulario, f.descricao, b.descricao as conta, f.tipoformulario " +
                                " from Formulario f, ctabancaria b " +
                                " where b.idempresa = f.idempresa and b.idctabancaria = f.idctabancaria " +
                                "  and f.idempresa =@codempresa ";

                if (!String.IsNullOrEmpty(oFormulario.tipoFormulario.ToString()))
                {
                    strSQL += " and tipoformulario=@tipoformulario ";
                }
                
                
                strSQL += " order by idFormulario ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oFormulario.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@tipoformulario", oFormulario.tipoFormulario);


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

        public Formulario ObterPor(Formulario oFormulario)
        {
            MySqlDataReader drConta;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from Formulario Where idFormulario = " + oFormulario.idFormulario;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                Boolean bConsulta = false;
                Formulario oForm = new Formulario();
                while (drConta.Read())
                {
                    bConsulta = true;

                    //localiza banco da contabancaria
                    CtaBancaria oCtaBancaria = new CtaBancaria();
                    

                    oForm.idFormulario = EmcResources.cInt(drConta["idformulario"].ToString());
                    oForm.descricaoFormulario = drConta["descricao"].ToString();
                    oForm.tipoFormulario = drConta["tipoformulario"].ToString();
                    oForm.nroInicial = drConta["nroinicial"].ToString();
                    oForm.nroFinal = drConta["nrofinal"].ToString();
                    oForm.nroAtual = drConta["nroatual"].ToString();
                    oForm.dtaInicio = Convert.ToDateTime(drConta["dtainicio"].ToString());
                    oForm.dtaFinal = Convert.ToDateTime(drConta["dtafinal"].ToString());
                    oForm.carteiraCobranca = drConta["carteiracobranca"].ToString();
                    oForm.situacao = drConta["situacao"].ToString();

                    oCtaBancaria.idCtaBancaria = EmcResources.cInt(drConta["idctabancaria"].ToString());
                    oCtaBancaria.codEmpresa = EmcResources.cInt(drConta["idempresa"].ToString());
                    oForm.contaBancaria = oCtaBancaria;

                    LayoutCheque oLayout = new LayoutCheque();
                    oLayout.idLayoutCheque = EmcResources.cInt(drConta["idlayoutcheque"].ToString());
                    oForm.layoutCheque = oLayout;
                }

                drConta.Close();
                drConta.Dispose();

                if (bConsulta)
                {
                    CtaBancariaDAO oCtaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                    oForm.contaBancaria = oCtaDAO.ObterPor(oForm.contaBancaria);

                    LayoutChequeDAO oLayDAO = new LayoutChequeDAO(parConexao, oOcorrencia, codEmpresa);
                    oForm.layoutCheque = oLayDAO.ObterPor(oForm.layoutCheque);


                }


                return oForm;

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

        private void geraOcorrencia(Formulario oFormulario, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oFormulario.idFormulario.ToString();

                if (flag == "A" || flag=="AS")
                {

                    Formulario oForm = new Formulario();
                    oForm = ObterPor(oFormulario);

                    if (flag == "AS")
                    {
                        descricao = " Atualização de Numero : de " + " foi excluída por " + oOcorrencia.usuario.nome;
                    }

                    if ((!oForm.Equals(oFormulario) && flag=="A") || (flag=="AC") )
                    {
                        descricao = "Formulario :" + oFormulario.idFormulario + "-" + oFormulario.descricaoFormulario + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oForm.descricaoFormulario.Equals(oFormulario.descricaoFormulario))
                        {
                            descricao += " Descricao Formulario : " + oForm.descricaoFormulario + " para " + oFormulario.descricaoFormulario;
                        }
                        if (!oForm.contaBancaria.Equals(oFormulario.contaBancaria))
                        {
                            descricao += " Cta Bancaria de: Empresa : " + oForm.contaBancaria.codEmpresa + " - Id Conta :" + oForm.contaBancaria.idCtaBancaria + " Descricao  : " + oForm.contaBancaria.descricao +
                                          " para Empresa :" + oFormulario.contaBancaria.codEmpresa + " id Conta : " + oFormulario.contaBancaria.idCtaBancaria + " Descricao : " + oFormulario.contaBancaria.descricao;
                        }
                        if (!oForm.tipoFormulario.Equals(oFormulario.tipoFormulario))
                        {
                            descricao += " Tipo Formulario de  " + oForm.tipoFormulario + " para " + oFormulario.tipoFormulario;
                        }
                        if (!oForm.nroInicial.Equals(oFormulario.nroInicial))
                        {
                            descricao += " Nro Inicial Formulario de " + oForm.nroInicial + " para " + oFormulario.nroInicial;
                        }
                        if (!oForm.nroFinal.Equals(oFormulario.nroFinal))
                        {
                            descricao += " Nro Final Formulario de " + oForm.nroFinal + " para " + oFormulario.nroFinal;
                        }
                        if (!oForm.nroAtual.Equals(oFormulario.nroAtual))
                        {
                            descricao += " Nro Atual " + oForm.nroAtual + " para " + oFormulario.nroAtual;
                        }
                        if (!oForm.dtaInicio.Equals(oFormulario.dtaInicio))
                        {
                            descricao += " Dta Inicio : " + oForm.dtaInicio + " para " + oFormulario.dtaInicio;
                        }
                        if (!oForm.dtaFinal.Equals(oFormulario.dtaFinal))
                        {
                            descricao += " Dta Final " + oForm.dtaFinal + " para " + oFormulario.dtaFinal;
                        }
                        if (!oForm.carteiraCobranca.Equals(oFormulario.carteiraCobranca))
                        {
                            descricao += " Carteira Cobranca " + oForm.carteiraCobranca + " para " + oFormulario.carteiraCobranca;
                        }
                        if (!oForm.situacao.Equals(oFormulario.situacao))
                        {
                            descricao += " Situacao de " + oForm.situacao + " para " + oFormulario.situacao;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = " Formulario : " + oFormulario.idFormulario + " - Descricao : " + oFormulario.descricaoFormulario +
                                " - Conta Bancaria : " + oFormulario.contaBancaria.codEmpresa + " " + oFormulario.contaBancaria.idCtaBancaria + " " + oFormulario.contaBancaria.descricao + 
                                " - Tipo formulario : " + oFormulario.tipoFormulario + " - Nro Inicial : " + oFormulario.nroInicial + " - Nro Final : " + oFormulario.nroFinal +
                                " - Nro Atual : " + oFormulario.nroAtual + " - Data Inicio : " + oFormulario.dtaInicio +
                                " - Dta Final : " + oFormulario.dtaFinal + " - Carteira Cobranca : " + oFormulario.carteiraCobranca +
                                " - Situacao : " + oFormulario.situacao + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Formulario : " + oFormulario.idFormulario + " - Descricao : " + oFormulario.descricaoFormulario +
                                " - Conta Bancaria : " + oFormulario.contaBancaria.codEmpresa + " " + oFormulario.contaBancaria.idCtaBancaria + " " + oFormulario.contaBancaria.descricao +
                                " - Tipo formulario : " + oFormulario.tipoFormulario + " - Nro Inicial : " + oFormulario.nroInicial + " - Nro Final : " + oFormulario.nroFinal +
                                " - Nro Atual : " + oFormulario.nroAtual + " - Data Inicio : " + oFormulario.dtaInicio +
                                " - Dta Final : " + oFormulario.dtaFinal + " - Carteira Cobranca : " + oFormulario.carteiraCobranca +
                                " - Situacao : " + oFormulario.situacao + " foi incluida por " + oOcorrencia.usuario.nome;

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
