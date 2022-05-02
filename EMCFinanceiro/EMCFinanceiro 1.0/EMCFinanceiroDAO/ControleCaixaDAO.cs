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
    public class ControleCaixaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public ControleCaixaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(ControleCaixa oCaixa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                 "where a.table_name = 'caixacontrole'" +
                                 "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idForm = 0;
                while (drCon.Read())
                {
                    idForm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    oCaixa.idControleCaixa = idForm;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(oCaixa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into caixacontrole (ctabancaria_idempresa, ctabancaria_idctabancaria, dthoraabertura, dthorafechamento, saldoabertura, usuarioresponsavel, conferido, fechado, usuarioconferencia ) " + 
                                " values (@idempresa, @idctabancaria, @dthoraabertura, @dthorafechamento, @saldoabertura, @usuarioresponsavel, @conferido, @fechado, @usuarioconferencia )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oCaixa.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oCaixa.contaBancaria.idCtaBancaria );
                Sqlcon.Parameters.AddWithValue("@dthoraabertura", oCaixa.dtHoraAbertura);
                Sqlcon.Parameters.AddWithValue("@dthorafechamento", oCaixa.dtHoraAbertura);
                Sqlcon.Parameters.AddWithValue("@saldoabertura", oCaixa.saldoAbertura);
                Sqlcon.Parameters.AddWithValue("@usuarioresponsavel", oCaixa.usuarioResponsavel);
                Sqlcon.Parameters.AddWithValue("@conferido", oCaixa.conferido);
                Sqlcon.Parameters.AddWithValue("@fechado", oCaixa.fechado);
                Sqlcon.Parameters.AddWithValue("@usuarioconferencia", null);
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

        public void Atualizar(ControleCaixa oCaixa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro 
            try
            {
                geraOcorrencia(oCaixa, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update caixacontrole set dthorafechamento=@dthorafechamento, " + 
                                                        " saldofechamento=@saldofechamento, conferido=@conferido, " + 
                                                        " fechado=@fechado, usuarioconferencia=@usuarioconferencia, " +
                                                        " dthoraconferencia=@conferencia "+
                                                        "where idcaixacontrole = @idcontrolecaixa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcontrolecaixa", oCaixa.idControleCaixa);
                Sqlcon.Parameters.AddWithValue("@dthorafechamento", oCaixa.dtHoraFechamento);
                Sqlcon.Parameters.AddWithValue("@saldofechamento", oCaixa.saldoFechamento);
                Sqlcon.Parameters.AddWithValue("@conferido", oCaixa.conferido);
                Sqlcon.Parameters.AddWithValue("@fechado", oCaixa.fechado);
                Sqlcon.Parameters.AddWithValue("@conferencia", oCaixa.dtHoraConferencia);
                if (oCaixa.usuarioConferencia>0)
                    Sqlcon.Parameters.AddWithValue("@usuarioconferencia", oCaixa.usuarioConferencia);
                else
                    Sqlcon.Parameters.AddWithValue("@usuarioconferencia", null);

                Sqlcon.ExecuteNonQuery();

                //concilia os movimentos bancarios do controle de caixa conferido

                if (oCaixa.conferido=="S")
                {

                    MovimentoBancarioDAO oMovBcoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia, codEmpresa);
                    oMovBcoDAO.conciliaMovimentoCaixa(oCaixa.lstMovimentoCaixa, oCaixa.dtHoraConferencia, Conexao, transacao);

                }


                
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

        public DataTable ListaConfereCaixa(CtaBancaria oCtaBancaria)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select c.*, u.nome " +
                                " from caixacontrole c, usuario u " +
                                " where u.idusuario = c.usuarioresponsavel " +
                                "   and c.ctabancaria_idempresa =@codempresa " +
                                "   and c.ctabancaria_idctabancaria=@ctabancaria " +
                                "   and c.fechado = 'S' and c.conferido='N'";

                strSQL += " order by dthoraabertura ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oCtaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria", oCtaBancaria.idCtaBancaria);


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
        public DataTable ListaFechamentoCaixa(CtaBancaria oCtaBancaria, Usuario oUsuario)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select c.*, u.nome " +
                                " from caixacontrole c, usuario u " +
                                " where u.idusuario = c.usuarioresponsavel " + 
                                "   and c.ctabancaria_idempresa =@codempresa " +
                                "   and c.ctabancaria_idctabancaria=@ctabancaria " + 
                                "   and c.usuarioresponsavel=@usuario " + 
                                "   and c.fechado = 'N' ";
                strSQL += " order by dthoraabertura ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oCtaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria", oCtaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@usuario", oUsuario.idUsuario);


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
        public DataTable ListaControleCaixa(CtaBancaria oCtaBancaria)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * " +
                                " from caixacontrole c " +
                                " where c.ctabancaria_idempresa =@codempresa " +
                                "   and c.ctabancaria_idctabancaria=@ctabancaria ";
                strSQL += " order by dthoraabertura ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oCtaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@ctabancaria", oCtaBancaria.idCtaBancaria);


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

        public ControleCaixa ObterPor(ControleCaixa oCaixa)
        {
            MySqlDataReader drConta;
            try
            {

                String strSQL = "";
                //Monta comando para a gravação do registro
                if (oCaixa.idControleCaixa > 0)
                {
                    strSQL = "select * from caixacontrole Where idcaixacontrole=@id";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@id", oCaixa.idControleCaixa);
                    drConta = Sqlcon.ExecuteReader();
                    
                }
                else
                {
                    strSQL = "select * from caixacontrole Where ctabancaria_idempresa=@codempresa " +
                                                                 " and ctabancaria_idctabancaria=@idconta " +
                                                                 " and dthoraabertura=@dthoraabertura ";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codempresa", oCaixa.contaBancaria.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idconta", oCaixa.contaBancaria.idCtaBancaria);
                    Sqlcon.Parameters.AddWithValue("@dthoraabertura", oCaixa.dtHoraAbertura);
                    drConta = Sqlcon.ExecuteReader();

                }
                
                Boolean bConsulta = false;
                ControleCaixa oCtrCaixa = new ControleCaixa();
                while (drConta.Read())
                {
                    bConsulta = true;

                    //localiza banco da contabancaria
                    CtaBancaria oCtaBancaria = new CtaBancaria();
                    
                    oCtrCaixa.idControleCaixa = EmcResources.cInt(drConta["idcaixacontrole"].ToString());
                    oCtrCaixa.conferido = drConta["conferido"].ToString();

                    CtaBancaria oConta = new CtaBancaria();
                    oConta.idCtaBancaria = EmcResources.cInt(drConta["ctabancaria_idctabancaria"].ToString());
                    oConta.codEmpresa = EmcResources.cInt(drConta["ctabancaria_idempresa"].ToString());
                    oCtrCaixa.contaBancaria = oConta;

                    oCtrCaixa.dtHoraAbertura = Convert.ToDateTime(drConta["dthoraabertura"].ToString());
                    oCtrCaixa.dtHoraFechamento = Convert.ToDateTime(drConta["dthorafechamento"].ToString());
                    oCtrCaixa.saldoAbertura = EmcResources.cCur(drConta["saldoabertura"].ToString());
                    oCtrCaixa.saldoFechamento = EmcResources.cCur(drConta["saldofechamento"].ToString());
                    oCtrCaixa.usuarioConferencia = EmcResources.cInt(drConta["usuarioconferencia"].ToString());
                    oCtrCaixa.usuarioResponsavel = EmcResources.cInt(drConta["usuarioresponsavel"].ToString());
                    oCtrCaixa.fechado = drConta["fechado"].ToString();

                    
                }

                drConta.Close();
                drConta.Dispose();

                if (bConsulta)
                {
                    CtaBancariaDAO oCtaDAO = new CtaBancariaDAO(parConexao, oOcorrencia,codEmpresa);
                    oCtrCaixa.contaBancaria = oCtaDAO.ObterPor(oCtrCaixa.contaBancaria);


                    MovimentoBancarioDAO oMovBancoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia, codEmpresa);
                    oCtrCaixa.lstMovimentoCaixa = oMovBancoDAO.lstMovimentoCaixa(oCtrCaixa.idControleCaixa);
                }


                return oCtrCaixa;

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

        private void geraOcorrencia(ControleCaixa oCaixa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCaixa.idControleCaixa.ToString();

                if (flag == "A")
                {

                    ControleCaixa oMov = new ControleCaixa();
                    oMov = ObterPor(oCaixa);

                    if (!oMov.Equals(oCaixa))
                    {
                        descricao = "Controle Caixa id: " + oCaixa.idControleCaixa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oMov.dtHoraFechamento.Equals(oMov.dtHoraFechamento))
                        {
                            descricao += " Data Fechamento de " + oMov.dtHoraFechamento + " para " + oMov.dtHoraFechamento;
                        }
                        if (!oMov.fechado.Equals(oMov.fechado))
                        {
                            descricao += " Caixa Fechado de " + oMov.fechado + " para " + oMov.fechado;
                        }
                        if (!oMov.saldoFechamento.Equals(oMov.saldoFechamento))
                        {
                            descricao += " Saldo Fechamento de " + oMov.saldoFechamento + " para " + oMov.saldoFechamento;
                        }
                        if (!oMov.conferido.Equals(oMov.conferido))
                        {
                            descricao += " Caixa Conferido de " + oMov.conferido + " para " + oMov.conferido;
                        }
                        if (!oMov.usuarioConferencia.Equals(oMov.usuarioConferencia))
                        {
                            descricao += " Usuario Conferencia de " + oMov.usuarioConferencia + " para " + oMov.usuarioConferencia;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Abertura de Caixa : " + oCaixa.idControleCaixa + " - Conta : " +
                                                                oCaixa.contaBancaria.idCtaBancaria + " - Empresa :" +
                                                                oCaixa.contaBancaria.codEmpresa + " - Descricao : " +
                                                                oCaixa.contaBancaria.descricao + " - usuario : " +
                                                                oCaixa.usuarioResponsavel + " - Data Abertura :" +
                                                                oCaixa.dtHoraAbertura.ToString() + " - Saldo : " +
                                                                oCaixa.saldoAbertura.ToString() +
                                                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    
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
