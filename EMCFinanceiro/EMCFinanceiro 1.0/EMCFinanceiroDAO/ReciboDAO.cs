using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCFinanceiroModel;
using System.Data;

namespace EMCFinanceiroDAO
{
    public class ReciboDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
     
        public ReciboDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public int Salvar(Recibo oRecibo)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select max(idrecibo) as ultimorecibo from recibo where idempresa = @codempresa";
                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);
                Sqlcon2.Parameters.AddWithValue("@codempresa", oRecibo.empresa.idEmpresa);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                int idRecibo = 0;
                while (drCon.Read())
                {
                    idRecibo = EmcResources.cInt(drCon["ultimorecibo"].ToString());
                    oRecibo.idRecibo = idRecibo+1;
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(oRecibo, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into Recibo (idempresa, idrecibo, dataemissao, descricao, valorrecibo, datarecibo, idusuario ) " + 
                                " values ( @idempresa, @idrecibo, @dataemissao, @descricao, @valorrecibo, @datarecibo, @idusuario )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oRecibo.empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@idrecibo", oRecibo.idRecibo );
                Sqlcon.Parameters.AddWithValue("@descricao", oRecibo.descricao);
                Sqlcon.Parameters.AddWithValue("@dataemissao", oRecibo.dataEmissao);
                Sqlcon.Parameters.AddWithValue("@valorrecibo", oRecibo.valorRecibo);
                Sqlcon.Parameters.AddWithValue("@datarecibo", oRecibo.dataRecibo);
                Sqlcon.Parameters.AddWithValue("@idusuario", oRecibo.idUsuario);
                Sqlcon.ExecuteNonQuery();

                
                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao,codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

                //vincula recibo ao movimento bancario
                MovimentoBancarioDAO oMovBancoDAO = new MovimentoBancarioDAO(parConexao, oOcorrencia, codEmpresa);
                oMovBancoDAO.AtualizarNroRecibo(oRecibo.idMovimentoBancario, oRecibo.idRecibo, Conexao, transacao);

                transacao.Commit();

                return oRecibo.idRecibo;
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

        public void Atualizar(Recibo oRecibo)
        {
            /*
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(oRecibo, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update Recibo set idempresa=@idempresa, idctabancaria=@idctabancaria, descricao=@descricao, " + 
                                                      "tipoRecibo=@tipoRecibo, nroinicial=@nroinicial, nrofinal=@nrofinal, " + 
                                                      "nroatual=@nroatual, dtainicio=@dtainicio, dtafinal=@dtafinal, " + 
                                                      "carteiracobranca=@carteiracobranca, situacao=@situacao  " +
                                                      "where idRecibo = @idRecibo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", oRecibo.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idctabancaria", oRecibo.contaBancaria.idCtaBancaria);
                Sqlcon.Parameters.AddWithValue("@descricao", oRecibo.descricaoRecibo);
                Sqlcon.Parameters.AddWithValue("@tipoRecibo", oRecibo.tipoRecibo);
                Sqlcon.Parameters.AddWithValue("@nroinicial", oRecibo.nroInicial);
                Sqlcon.Parameters.AddWithValue("@nrofinal", oRecibo.nroFinal);
                Sqlcon.Parameters.AddWithValue("@nroatual", oRecibo.nroAtual);
                Sqlcon.Parameters.AddWithValue("@dtainicio", oRecibo.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", oRecibo.dtaFinal);
                Sqlcon.Parameters.AddWithValue("@carteiracobranca", oRecibo.carteiraCobranca);
                Sqlcon.Parameters.AddWithValue("@situacao", oRecibo.situacao);
                Sqlcon.Parameters.AddWithValue("@idRecibo", oRecibo.idRecibo);
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
             */ 

        }

        public void Excluir(Recibo oRecibo)
        {
            /*
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(oRecibo, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from Recibo where idRecibo = @idRecibo";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idRecibo", oRecibo.idRecibo);
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
             */ 

        }

        public DataTable dstReciboSimples(String idRecibo)
        {
            DataTable dtCon = new DataTable();

            try
            {

                String strSQL = "";

                strSQL = "select m.idmovimentobancario, m.idrecibo, concat(h.descricao, ' ', m.historico) as historico, m.valormovimento, " +
                              "  m.datamovimento as datarecibo, p.nome as nomepessoa, p.cnpjcpf as cpfpessoa, c.idbanco as nomebanco, " +
                              "  concat(c.conta, ' - ', c.contadigito) as nroconta, concat(c.agencia,' - ', c.agenciadigito) as nroagencia, " +
                              "  concat('(',ucase(valorextenso(m.valormovimento)),')') as extenso, lpad(ch.nrocheque,7,0) as nrocheque, c.descricao as descricaoconta " +
                         " from MovimentoBancario m " +
                         " left join chequeemitir ch " +
                           " on m.idmovimentobancario = ch.idmovimentobancario " +
                         " left join historico h " +
                           " on m.idhistorico = h.idhistorico " +
                         " left join pessoa p " +
                           " on m.codempresa_pessoa = p.codempresa and m.idpessoa = p.idpessoa " +
                         " left join ctabancaria c " +
                           " on m.ctabancaria_idempresa=c.idempresa and m.ctabancaria_idctabancaria=c.idctabancaria " +
                         " where m.codempresa=@codempresa and m.idrecibo in (" +idRecibo+ ")";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
                

                MySqlDataAdapter daCon = new MySqlDataAdapter();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();

            }
            catch(MySqlException oErro)
            {
                throw oErro;
            }
            return dtCon;

        }

        /*
        public DataTable listaRecibo(DateTime dataInicio, DateTime dataFinal, Pessoa oPessoa, int nroRecibo)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select  " +
                                " from recibo r, ctabancaria b " +
                                " where b.idempresa = f.idempresa and b.idctabancaria = f.idctabancaria " +
                                "  and f.idempresa =@codempresa ";

                if (!String.IsNullOrEmpty(oRecibo.tipoRecibo.ToString()))
                {
                    strSQL += " and tipoRecibo=@tipoRecibo ";
                }
                
                
                strSQL += " order by idRecibo ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oRecibo.contaBancaria.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@tipoRecibo", oRecibo.tipoRecibo);


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

        public Recibo ObterPor(Recibo oRecibo)
        {
            MySqlDataReader drConta;
            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from Recibo Where idRecibo = " + oRecibo.idRecibo;

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drConta = Sqlcon.ExecuteReader();

                Boolean bConsulta = false;
                Recibo oForm = new Recibo();
                while (drConta.Read())
                {
                    bConsulta = true;

                    //localiza banco da contabancaria
                    CtaBancaria oCtaBancaria = new CtaBancaria();
                    

                    oForm.idRecibo = EmcResources.cInt(drConta["idRecibo"].ToString());
                    oForm.descricaoRecibo = drConta["descricao"].ToString();
                    oForm.tipoRecibo = drConta["tipoRecibo"].ToString();
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

          */
        private void geraOcorrencia(Recibo oRecibo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oRecibo.empresa.idEmpresa + " - " + oRecibo.idRecibo.ToString();

                if (flag == "A")
                {

                   
                }
                else if (flag == "I")
                {
                    descricao = "Empresa :" + oRecibo.empresa.idEmpresa + " - " + oRecibo.empresa.razaoSocial +
                                " - Recibo : " + oRecibo.idRecibo + " - Descricao : " + oRecibo.descricao +
                                " - Data Emissão : " + oRecibo.dataEmissao +
                                " - Data Recibo : " + oRecibo.dataRecibo +
                                " - Valor : " + oRecibo.valorRecibo + " foi incluida por " + oOcorrencia.usuario.nome;
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
