using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCCadastroDAO;
using EMCCadastroModel;

namespace EMCImobDAO
{
    public class LocacaoAnotacaoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoAnotacaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoAnotacao> lstLocacaoAnotacao(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoAnotacao Where idlocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoAnotacao> lstLocacaoAnotacao = new List<LocacaoAnotacao>();
                List<LocacaoAnotacao> lstRetorno = new List<LocacaoAnotacao>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoAnotacao oLocAnotacao = new LocacaoAnotacao();

                    oLocAnotacao.idLocacaoAnotacao = EmcResources.cInt(drCon["idLocacaoAnotacao"].ToString());

                    lstLocacaoAnotacao.Add(oLocAnotacao);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoAnotacao oAnotacao in lstLocacaoAnotacao)
                    {
                        LocacaoAnotacao oRec = new LocacaoAnotacao();
                        oRec = ObterPor(oAnotacao);

                        lstRetorno.Add(oRec);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(LocacaoAnotacao oLocAnotacao, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oLocAnotacao.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoAnotacao'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oLocAnotacao.idLocacaoAnotacao = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oLocAnotacao, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoAnotacao ( idLocacaoAnotacao, idlocacaocontrato, dataanotacao, historico, idusuario )" +
                                    "values (@idLocacaoAnotacao, @idlocacaocontrato, @dataanotacao, @historico, @idusuario )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoAnotacao", oLocAnotacao.idLocacaoAnotacao);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocAnotacao.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@dataanotacao", oLocAnotacao.dataAnotacao);
                    SqlconPar.Parameters.AddWithValue("@historico", oLocAnotacao.historico);
                    SqlconPar.Parameters.AddWithValue("@idusuario", oLocAnotacao.idUsuario);
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oLocAnotacao.statusOperacao == "A")
                {

                }
                else if (oLocAnotacao.statusOperacao == "E")
                {
                    
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LocacaoAnotacao ObterPor(LocacaoAnotacao oLocAnotacao)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoAnotacao Where idLocacaoAnotacao = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oLocAnotacao.idLocacaoAnotacao);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoAnotacao oLocacaoAnotacao = new LocacaoAnotacao();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oLocacaoAnotacao.idLocacaoAnotacao = EmcResources.cInt(drCon["idLocacaoAnotacao"].ToString());
                    oLocacaoAnotacao.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());
                    oLocacaoAnotacao.dataAnotacao = Convert.ToDateTime(drCon["dataanotacao"].ToString());
                    oLocacaoAnotacao.historico = drCon["historico"].ToString();
                    oLocacaoAnotacao.idUsuario = EmcResources.cInt(drCon["idusuario"].ToString());
                    oLocacaoAnotacao.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                return oLocacaoAnotacao;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoAnotacao oLocAnotacao, string flag)
        {
            try
            {
                string descricao = "";
                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLocAnotacao.idLocacaoContrato.ToString();

                if (flag == "A")
                {
                    LocacaoAnotacao oCCP = new LocacaoAnotacao();
                    oCCP = ObterPor(oLocAnotacao);

                    if (!oCCP.Equals(oLocAnotacao))
                    {
                        descricao = "Locacao Anotacao id: " + oLocAnotacao.idLocacaoAnotacao + 
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.idLocacaoContrato.Equals(oLocAnotacao.idLocacaoContrato))
                        {
                            descricao += " Contrato de " + oCCP.idLocacaoContrato + " para " + oLocAnotacao.idLocacaoContrato;
                        }
                        if (!oCCP.dataAnotacao.Equals(oLocAnotacao.dataAnotacao))
                        {
                            descricao += " Data de " + oCCP.dataAnotacao + " para " + oLocAnotacao.dataAnotacao;
                        }
                        if (!oCCP.historico.Equals(oLocAnotacao.historico))
                        {
                            descricao += " Historico de " + oCCP.historico.ToString() + " para " + oLocAnotacao.historico.ToString();
                        }
                        if (!oCCP.idUsuario.Equals(oLocAnotacao.idUsuario))
                        {
                            descricao += " Usuario de " + oCCP.idUsuario.ToString() + " para " + oLocAnotacao.idUsuario.ToString();
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Locacao Anotacao id: " + oLocAnotacao.idLocacaoAnotacao + 
                                " Contrato Locacao id : " + oLocAnotacao.idLocacaoContrato + 
                                " Data : " + oLocAnotacao.dataAnotacao + " - " + oLocAnotacao.dataAnotacao +
                                " Historico : " + oLocAnotacao.historico +
                                " Usuario : " + oLocAnotacao.idUsuario.ToString() +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Locacao Anotacao id: " + oLocAnotacao.idLocacaoAnotacao +
                                " Contrato Locacao id : " + oLocAnotacao.idLocacaoContrato +
                                " Data : " + oLocAnotacao.dataAnotacao + " - " + oLocAnotacao.dataAnotacao +
                                " Historico : " + oLocAnotacao.historico +
                                " Usuario : " + oLocAnotacao.idUsuario.ToString() +
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
