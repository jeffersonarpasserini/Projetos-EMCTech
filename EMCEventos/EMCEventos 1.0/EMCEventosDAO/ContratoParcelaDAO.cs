using EMCEventosModel;
using EMCLibrary;
using EMCSecurityDAO;
using EMCSecurityModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEventosDAO
{
    public class ContratoParcelaDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public ContratoParcelaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<ContratoParcela> lstContratoParcela(int idContrato)
        {
            bool consulta = false;
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro 
                //String strSQL = "SELECT cp.*, c.idevt_contrato as idevt_contr, cp.situacao as situacaoparcela " +
                //               " from evt_contratoparcela cp " +
                //               " left join evt_contrato c on c.idevt_contrato = cp.idevt_contrato " ;
                String strSQL = "select * from evt_contratoparcela Where idevt_contrato = @idevt_contrato"; 

                //if (idContrato > 0)
                //{
                //    if (colocaWhere == 0)
                //    {
                //        strSQL += " where ";
                //        colocaWhere++;
                //    }
                //    strSQL += " c.idevt_contrato = @idevt_contrato ";
                //}                


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_contrato", idContrato);


                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ContratoParcela> lstContratoParcela = new List<ContratoParcela>();
                List<ContratoParcela> lstRetorno = new List<ContratoParcela>();


                ContratoParcela objContratoParcela;

                while (drCon.Read())
                {
                    consulta = true;
                    objContratoParcela = new ContratoParcela();

                    objContratoParcela.idContratoParcela = EmcResources.cInt(drCon["idevt_contratoparcela"].ToString());
                   
                    //Contrato oContrato = new Contrato();
                    //oContrato.idContrato = EmcResources.cInt(drCon["idevt_contr"].ToString());
                    //objContratoParcela.contrato = oContrato;

                    // objContratoParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    //objContratoParcela.dataVencimento = Convert.ToDateTime(drCon["datavencimento"].ToString());
                    //objContratoParcela.situacao = drCon["situacaoparcela"].ToString();

                    lstContratoParcela.Add(objContratoParcela);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (ContratoParcela oContratoParcela in lstContratoParcela)
                    {
                        ContratoParcela obContParc = new ContratoParcela();
                        obContParc = ObterPor(oContratoParcela);

                        lstRetorno.Add(obContParc);
                    }
                }

                return lstRetorno;

            }

            catch (MySqlException erro)
            {
                throw erro;
            }
        }


        public void Salvar(ContratoParcela objContratoParcela, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                if (objContratoParcela.flag == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'evt_contratoparcela'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        objContratoParcela.idContratoParcela = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(objContratoParcela, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into evt_contratoparcela (idevt_contrato, nroparcela, datavencimento, valorparcela, situacao)" +
                                                                "values (@idevt_contrato, @nroparcela, @datavencimento, @valorparcela, @situacao )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idevt_contrato", objContratoParcela.contrato.idContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", objContratoParcela.nroParcela);
                    SqlconPar.Parameters.AddWithValue("@datavencimento", objContratoParcela.dataVencimento);
                    SqlconPar.Parameters.AddWithValue("@valorparcela", objContratoParcela.valorParcela);
                    SqlconPar.Parameters.AddWithValue("@situacao", objContratoParcela.situacao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();
                }

                else if (objContratoParcela.flag == "A")
                {
                    geraOcorrencia(objContratoParcela, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update evt_contratoparcela set idevt_contrato = @idevt_contrato, nroparcela = @nroparcela, datavencimento = @datavencimento, " + 
                                                                  " valorparcela = @valorparcela, situacao = @situacao where idevt_contratoparcela = @idevt_contratoparcela";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idevt_contratoparcela", objContratoParcela.idContratoParcela);
                    SqlconPar.Parameters.AddWithValue("@idevt_contrato", objContratoParcela.contrato.idContrato);
                    SqlconPar.Parameters.AddWithValue("@nroparcela", objContratoParcela.nroParcela);
                    SqlconPar.Parameters.AddWithValue("@datavencimento", objContratoParcela.dataVencimento);
                    SqlconPar.Parameters.AddWithValue("@valorparcela", objContratoParcela.valorParcela);
                    SqlconPar.Parameters.AddWithValue("@situacao", objContratoParcela.situacao);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();
                }

                else if (objContratoParcela.flag == "E")
                {
                    geraOcorrencia(objContratoParcela, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "delete from evt_contratoparcela where idevt_contratoparcela = @idevt_contratoparcela";
                    
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);                    
                    Sqlcon.Parameters.AddWithValue("@idevt_contratoparcela", objContratoParcela.idContratoParcela);

                    Sqlcon.ExecuteNonQuery();
                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();

                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public ContratoParcela ObterPor(ContratoParcela oContratoParcela)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from evt_contratoparcela Where idevt_contratoparcela = @idevt_contratoparcela";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idevt_contratoparcela", oContratoParcela.idContratoParcela);
                

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                Contrato oContrato = new Contrato();

                ContratoParcela objContratoParcela = new ContratoParcela();

                while (drCon.Read())
                {
                    consulta = true;
                    objContratoParcela.idContratoParcela = EmcResources.cInt(drCon["idevt_contratoparcela"].ToString());

                    oContrato.idContrato = EmcResources.cInt(drCon["idevt_contrato"].ToString());
                    objContratoParcela.contrato = oContrato;
                                        
                    objContratoParcela.nroParcela = EmcResources.cInt(drCon["nroparcela"].ToString());
                    objContratoParcela.dataVencimento = Convert.ToDateTime(drCon["datavencimento"].ToString());
                    objContratoParcela.valorParcela = EmcResources.cCur(drCon["valorparcela"].ToString());
                    objContratoParcela.situacao = drCon["situacao"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ContratoDAO oContrDAO = new ContratoDAO(parConexao, oOcorrencia, codEmpresa);
                    objContratoParcela.contrato = oContrDAO.ObterPorLstContrato(objContratoParcela.contrato);

                }
                return objContratoParcela;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(ContratoParcela oContratoParcela, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oContratoParcela.contrato.idContrato.ToString();

                if (flag == "A")
                {

                    ContratoParcela oContParc = new ContratoParcela();
                    oContParc = ObterPor(oContratoParcela);

                    if (!oContParc.Equals(oContratoParcela))
                    {
                        descricao = "Contrato Parcela id: " + oContratoParcela.idContratoParcela + " Contrato :" + oContratoParcela.contrato.idContrato + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        //if (!oContParc.contrato.idContrato.Equals(oContratoParcela.contrato.idContrato))
                        //{
                        //    descricao += " Contrato " + oContParc.contrato.idContrato + " para " + oContratoParcela.contrato.idContrato;
                        //}
                        if (!oContParc.nroParcela.Equals(oContratoParcela.nroParcela))
                        {
                            descricao += " Nro. Parcelas de " + oContParc.nroParcela + " para " + oContratoParcela.nroParcela;
                        }
                        if (!oContParc.dataVencimento.Equals(oContratoParcela.dataVencimento))
                        {
                            descricao += " Data Vencimento de " + oContParc.dataVencimento + " para " + oContratoParcela.dataVencimento;
                        }
                        if (!oContParc.valorParcela.Equals(oContratoParcela.valorParcela))
                        {
                            descricao += " Valor Parcela de " + oContParc.valorParcela + " para " + oContratoParcela.valorParcela;
                        }
                        //if (!oContParc.situacao.Equals(oContratoParcela.situacao))
                        //{
                        //    descricao += " Situação de " + oContParc.situacao + " para " + oContratoParcela.situacao;
                        //}
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Contrato Parcela id : " + oContratoParcela.idContratoParcela +
                                " - Contrato - " + oContratoParcela.contrato.idContrato +
                                " - Nro. Parcela - " + oContratoParcela.nroParcela +
                                " - Data Vencimento - " + oContratoParcela.dataVencimento +
                                " - Valor Parcela - " + oContratoParcela.valorParcela +
                                " - Situação - " + oContratoParcela.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Contrato Parcela id : " + oContratoParcela.idContratoParcela +
                                " - Contrato - " + oContratoParcela.contrato.idContrato +
                                " - Nro. Parcela - " + oContratoParcela.nroParcela +
                                " - Data Vencimento - " + oContratoParcela.dataVencimento +
                                " - Valor Parcela - " + oContratoParcela.valorParcela +
                                " - Situação - " + oContratoParcela.situacao +
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
