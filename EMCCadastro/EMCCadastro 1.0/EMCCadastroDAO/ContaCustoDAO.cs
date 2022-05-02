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
    public class ContaCustoDAO
    {
        //Variaveis de Configuração do Formato da Conta Custo
        int vTamMaximo = 0; //tamanho da conta custo no nivel 7
        int vNroNiveis = 0; // numero de niveis
        int vTamNV1 = 0; // tamanho no nivel 1
        int vTamNV2 = 0; // tamanho no nivel 2
        int vTamNV3 = 0; // tamanho no nivel 3
        int vTamNV4 = 0; // tamanho no nivel 4
        int vTamNV5 = 0; // tamanho no nivel 5
        int vTamNV6 = 0; // tamanho no nivel 6
        int vTamNV7 = 0; // tamanho no nivel 7
        string vMascara = "";

        int codEmpresa;

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        

        public ContaCustoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            try
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

                this.codEmpresa = idEmpresa;

                Parametro oParametro = new Parametro();
                ParametroDAO oParametroDAO = new ParametroDAO(parConexao);
                //verifica o parametro considera data valida para vencimento de parcelas.
                vTamMaximo = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAMANHO_CONTACUSTO"));
                vNroNiveis = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "NRONIVEIS_CONTACUSTO"));
                vTamNV1 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV1_CONTACUSTO"));
                vTamNV2 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV2_CONTACUSTO"));
                vTamNV3 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV3_CONTACUSTO"));
                vTamNV4 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV4_CONTACUSTO"));
                vTamNV5 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV5_CONTACUSTO"));
                vTamNV6 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV6_CONTACUSTO"));
                vTamNV7 = EmcResources.cInt(oParametroDAO.retParametro(codEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV7_CONTACUSTO"));
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Salvar(ContaCusto objContaCusto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de ContaCusto
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'contacusto'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objContaCusto.idContaCusto = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objContaCusto, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into ContaCusto ( codigoconta, tipoconta, contaacima, descricao, idfilial, idgrupoempresa, idmatriz, idholding ) " +
                                " values (@codigoconta, @tipoconta, @contaacima, @descricao, @idfilial, @idgrupoempresa, @idmatriz, @idholding )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@codigoconta", objContaCusto.codigoConta);
                Sqlcon.Parameters.AddWithValue("@tipoconta", objContaCusto.tipoConta);
                if (objContaCusto.codigoConta.Trim().Length==1)
                    Sqlcon.Parameters.AddWithValue("@contaacima", null);
                else
                    Sqlcon.Parameters.AddWithValue("@contaacima", objContaCusto.contaAcima.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@descricao", objContaCusto.descricao);
                if (objContaCusto.tipoConta == "A")
                {
                    Sqlcon.Parameters.AddWithValue("@idfilial", objContaCusto.filial.idEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idgrupoempresa", objContaCusto.filial.grupoEmpresa.idGrupoEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idmatriz", objContaCusto.filial.matriz.idEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idholding", objContaCusto.filial.grupoEmpresa.holding.idHolding);
                }
                else
                {
                    Sqlcon.Parameters.AddWithValue("@idfilial", null);
                    Sqlcon.Parameters.AddWithValue("@idgrupoempresa", null);
                    Sqlcon.Parameters.AddWithValue("@idmatriz", null);
                    Sqlcon.Parameters.AddWithValue("@idholding", null);
                }
                
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

        public void Atualizar(ContaCusto objContaCusto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro de ContaCusto
            try
            {
                geraOcorrencia(objContaCusto, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update ContaCusto set descricao=@descricao, idfilial=@idfilial, idgrupoempresa=@idgrupoempresa, " +
                                " idmatriz=@idmatriz, idholding=@idholding " +
                                " where idcontacusto = @idcontacusto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objContaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@descricao", objContaCusto.descricao);
                if (objContaCusto.tipoConta == "A")
                {
                    Sqlcon.Parameters.AddWithValue("@idfilial", objContaCusto.filial.idEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idgrupoempresa", objContaCusto.filial.grupoEmpresa.idGrupoEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idmatriz", objContaCusto.filial.matriz.idEmpresa);
                    Sqlcon.Parameters.AddWithValue("@idholding", objContaCusto.filial.grupoEmpresa.holding.idHolding);
                }
                else
                {
                    Sqlcon.Parameters.AddWithValue("@idfilial", null);
                    Sqlcon.Parameters.AddWithValue("@idgrupoempresa", null);
                    Sqlcon.Parameters.AddWithValue("@idmatriz", null);
                    Sqlcon.Parameters.AddWithValue("@idholding", null);
                }
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

        public void Excluir(ContaCusto objContaCusto)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de ContaCusto
            try
            {

                geraOcorrencia(objContaCusto, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from ContaCusto where idcontacusto = @idcontacusto";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objContaCusto.idContaCusto);
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

        public DataTable pesquisaContaCusto(int empmaster, String codigoConta, string nome, Boolean todas)
        {
            try
            {
                int colocaWhere = 0;


                Empresa oEmp = new Empresa();
                oEmp.idEmpresa = codEmpresa;

                EmpresaDAO oEmpDAO = new EmpresaDAO(parConexao, oOcorrencia);
                oEmp = oEmpDAO.ObterPor(oEmp);


                //Monta comando para a gravação do registro
                String strSQL = "select c.* from contacusto c ";

                if (!String.IsNullOrEmpty(codigoConta.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " c.codigoconta = @codigoconta ";
                }

                if (!String.IsNullOrEmpty(nome.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " c.descricao like @nome ";
                }

                if (!todas)
                {

                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";

                    strSQL += " c.idmatriz = @idmatriz ";

                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codigoconta", codigoConta);
                Sqlcon.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@idmatriz", oEmp.matriz.idEmpresa);



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

        public DataTable ListaContaEmpresa()
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select codigoconta, concat(descricao, ' - ', codigoconta) as descricao " + 
                                " from contacusto where tipoconta = 'A' " + 
                                " and idfilial = @codempresa order by codigoconta";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", codEmpresa);
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

        public DataTable ListaContaDespesa()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select codigoconta, concat(descricao, ' - ', codigoconta) as descricao from contacusto where tipoconta = 'A' and substr(codigoconta from 1 for 1) = '2' order by codigoconta";
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

        public DataTable ListaContaReceita()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select codigoconta, concat(descricao, ' - ', codigoconta) as descricao from contacusto where tipoconta = 'A' and substr(codigoconta from 1 for 1) = '1' order by codigoconta";
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

        public DataTable ListaContaCusto()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select codigoconta, tipoconta, descricao, idcontacusto, contaacima, idfilial" +
                                 " from contacusto order by codigoconta";
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

        public ContaCusto ObterPor(ContaCusto oContaCusto)
        {
            ContaCusto oCta = new ContaCusto();
            MySqlDataReader drCon;
            try
            {

                String strSQL = "";

                if (oContaCusto.idContaCusto > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from contacusto where idcontacusto=@idcontacusto";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idcontacusto", oContaCusto.idContaCusto);

                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from contacusto where codigoconta=@codigoconta";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigoconta", oContaCusto.codigoConta);
                    
                    drCon = Sqlcon.ExecuteReader();
                }
              
                while (drCon.Read())
                {
                    ContaCusto objContaCusto = new ContaCusto();
                    objContaCusto.idContaCusto = Convert.ToInt32(drCon["idcontacusto"].ToString());
                    objContaCusto.codigoConta = drCon["codigoconta"].ToString();
                    objContaCusto.tipoConta = drCon["tipoconta"].ToString();
                    objContaCusto.descricao = drCon["descricao"].ToString();

                    Empresa oFilial = new Empresa();
                    oFilial.idEmpresa = EmcResources.cInt(drCon["idfilial"].ToString());


                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;
                    
                    if (objContaCusto.codigoConta.Trim().Length == 1)
                        objContaCusto.contaAcima = oCta;
                    else
                        objContaCusto.contaAcima = buscaContaAcima(objContaCusto);

                    EmpresaDAO oFilialDAO = new EmpresaDAO(parConexao, oOcorrencia);
                    oFilial = oFilialDAO.ObterPor(oFilial);

                    objContaCusto.filial = oFilial;
                    
                    return objContaCusto;
                }


                ContaCusto objContaCusto1 = new ContaCusto();
                drCon.Close();
                drCon.Dispose();
                return objContaCusto1;

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

        public ContaCusto buscaContaAcima(ContaCusto oContaCusto)
        {
            String codCtaAcima = "";
            ContaCusto oCta = new ContaCusto();
            MySqlDataReader drCon;
            try
            {

                if (!String.IsNullOrEmpty(oContaCusto.codigoConta))
                {
                    //verifica nivel 7 para nivel 6
                    if (oContaCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6 + vTamNV7) && 7 <= vNroNiveis)
                    {
                        //Validação de nível 6
                        codCtaAcima = oContaCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6));
                    }
                    //verifica nivel 6 para nivel 5
                    else if (oContaCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6) && 6 <= vNroNiveis)
                    {
                        //Validação de nivel 5
                        codCtaAcima = oContaCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5));
                        
                    }
                    //verifica nivel 5 para nivel 4
                    else if (oContaCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5) && 5 <= vNroNiveis)
                    {
                        //Validação de nivel 4
                        codCtaAcima = oContaCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4));
                        
                    }
                    //verifica nivel 4 para nivel 3
                    else if (oContaCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4) && 4 <= vNroNiveis)
                    {
                        //Validação de nivel 3
                        codCtaAcima = oContaCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3));
                        
                    }
                    //verifica nivel 3 para nivel 2
                    else if (oContaCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3) && 3 <= vNroNiveis)
                    {
                        //Validação de nivel 2
                        codCtaAcima = oContaCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2));
                        
                    }
                    //verifica nivel 2 para nivel 1
                    else if (oContaCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2) && 2 <= vNroNiveis)
                    {
                        //Validação de nivel 1
                        codCtaAcima = oContaCusto.codigoConta.Trim().Substring(0, (vTamNV1));
                    }
                }
                //verifica nivel 1 - não precisa ser verificado pois não tem nivel anterior
                else if (oContaCusto.codigoConta.Trim().Length == (vTamNV1) && 1 <= vNroNiveis)
                {
                    //Validação de nivel 1
                    codCtaAcima="";
                }
                
                if (!String.IsNullOrEmpty(codCtaAcima))
                {

                    //Monta comando para a gravação do registro
                    String strSQL = "select * from contacusto where codigoconta=@codigoconta";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigoconta", codCtaAcima.Trim());

                    drCon = Sqlcon.ExecuteReader(); 

                    while (drCon.Read())
                    {
                        ContaCusto objContaCusto = objContaCusto = new ContaCusto();
                        objContaCusto.idContaCusto = Convert.ToInt32(drCon["idcontacusto"].ToString());
                        objContaCusto.codigoConta = drCon["codigoconta"].ToString();
                        objContaCusto.tipoConta = drCon["tipoconta"].ToString();
                        objContaCusto.contaAcima = oCta;
                        objContaCusto.descricao = drCon["descricao"].ToString();
                        drCon.Close();
                        drCon.Dispose();
                        return objContaCusto;
                    }
                    drCon.Close();
                    drCon.Dispose();
                }

                ContaCusto objContaCusto1 = new ContaCusto();
                return objContaCusto1;

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

        private void geraOcorrencia(ContaCusto oCtaCusto, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oCtaCusto.idContaCusto.ToString();

                if (flag == "A")
                {

                    ContaCusto oCta = new ContaCusto();
                    oCta = ObterPor(oCtaCusto);

                    if (!oCta.Equals(oCtaCusto))
                    {
                        descricao = "Conta Custo : " + oCtaCusto.idContaCusto + " - " + oCtaCusto.codigoConta + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oCta.descricao.Equals(oCtaCusto.descricao))
                        {
                            descricao += " Descricao de " + oCta.descricao + " para " + oCtaCusto.descricao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Conta Custo : " + oCtaCusto.idContaCusto + " - " + oCtaCusto.codigoConta + " - " + oCtaCusto.descricao + " - Cta Acima : " + oCtaCusto.contaAcima + " - Tipo : " + oCtaCusto.tipoConta + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Conta Custo : " + oCtaCusto.idContaCusto + " - " + oCtaCusto.codigoConta + " - " + oCtaCusto.descricao + " - Cta Acima : " + oCtaCusto.contaAcima + " - Tipo : " + oCtaCusto.tipoConta + " foi excluída por " + oOcorrencia.usuario.nome;
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
