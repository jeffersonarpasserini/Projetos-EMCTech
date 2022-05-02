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
    public class LocacaoFornecedorDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoFornecedorDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<LocacaoFornecedor> lstLocacaoFornecedor(int idContrato)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoFornecedor Where idlocacaocontrato = @idcontrato ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idcontrato", idContrato);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<LocacaoFornecedor> lstLocacaoFornecedor = new List<LocacaoFornecedor>();
                List<LocacaoFornecedor> lstRetorno = new List<LocacaoFornecedor>();


                while (drCon.Read())
                {
                    consulta = true;
                    LocacaoFornecedor oLocFornecedor = new LocacaoFornecedor();

                    oLocFornecedor.idLocacaoFornecedor = EmcResources.cInt(drCon["idLocacaoFornecedor"].ToString());

                    lstLocacaoFornecedor.Add(oLocFornecedor);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (LocacaoFornecedor oFornecedor in lstLocacaoFornecedor)
                    {
                        LocacaoFornecedor oRec = new LocacaoFornecedor();
                        oRec = ObterPor(oFornecedor);

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

        public void Salvar(LocacaoFornecedor oLocFornecedor, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de ReceberParcela
            try
            {
                if (oLocFornecedor.statusOperacao == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'LocacaoFornecedor'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        oLocFornecedor.idLocacaoFornecedor = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oLocFornecedor, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into LocacaoFornecedor ( idLocacaoFornecedor, idlocacaocontrato, codempresa, idlocador, percparticipacao, valoraluguel, situacao )" +
                                    "values (@idLocacaoFornecedor, @idlocacaocontrato, @codempresa, @idlocador, @percparticipacao, @valoraluguel, @situacao )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoFornecedor", oLocFornecedor.idLocacaoFornecedor);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocFornecedor.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oLocFornecedor.locador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oLocFornecedor.locador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oLocFornecedor.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@valoraluguel", oLocFornecedor.valorAluguel);
                    SqlconPar.Parameters.AddWithValue("@situacao", "A");
                    
                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }
                else if (oLocFornecedor.statusOperacao == "A")
                {

                    geraOcorrencia(oLocFornecedor, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoFornecedor set idlocacaocontrato=@idlocacaocontrato, codempresa=@codempresa, " + 
                                                              "idlocador=@idlocador, percparticipacao=@percparticipacao, valoraluguel=@valoraluguel " +
                                    "where idLocacaoFornecedor=@idLocacaoFornecedor";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoFornecedor", oLocFornecedor.idLocacaoFornecedor);
                    SqlconPar.Parameters.AddWithValue("@idlocacaocontrato", oLocFornecedor.idLocacaoContrato);
                    SqlconPar.Parameters.AddWithValue("@codempresa", oLocFornecedor.locador.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idlocador", oLocFornecedor.locador.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@percparticipacao", oLocFornecedor.percParticipacao);
                    SqlconPar.Parameters.AddWithValue("@valoraluguel", oLocFornecedor.valorAluguel);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                }

                else if (oLocFornecedor.statusOperacao == "E")
                {
                    geraOcorrencia(oLocFornecedor, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "update LocacaoFornecedor set situacao=@situacao " +
                                    " where idLocacaoFornecedor=@idLocacaoFornecedor ";

                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idLocacaoFornecedor", oLocFornecedor.idLocacaoFornecedor);
                    SqlconPar.Parameters.AddWithValue("@situacao", "C" );
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                }
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public LocacaoFornecedor ObterPor(LocacaoFornecedor oLocFornecedor)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoFornecedor Where idLocacaoFornecedor = @id";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@id", oLocFornecedor.idLocacaoFornecedor);


                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();
                LocacaoFornecedor oLocacaoFornecedor = new LocacaoFornecedor();

                while (drCon.Read())
                {
                    consulta = true;
                    
                    oLocacaoFornecedor.idLocacaoFornecedor = EmcResources.cInt(drCon["idLocacaoFornecedor"].ToString());
                    oLocacaoFornecedor.idLocacaoContrato = EmcResources.cInt(drCon["idlocacaocontrato"].ToString());

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    oFornecedor.idPessoa = EmcResources.cInt(drCon["idlocador"].ToString());
                    oLocacaoFornecedor.locador = oFornecedor;

                    oLocacaoFornecedor.percParticipacao = EmcResources.cDouble(drCon["percparticipacao"].ToString());
                    oLocacaoFornecedor.valorAluguel = EmcResources.cCur(drCon["valoraluguel"].ToString());
                    oLocacaoFornecedor.situacao = drCon["situacao"].ToString();

                    oLocacaoFornecedor.statusOperacao = "";

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLocacaoFornecedor.locador = oFornecedorDAO.ObterPor(oLocacaoFornecedor.locador);
                }
                return oLocacaoFornecedor;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(LocacaoFornecedor oLocFornecedor, string flag)
        {
            try
            {
                string descricao = "";
                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentoPagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLocFornecedor.idLocacaoContrato.ToString();

                if (flag == "A")
                {
                    LocacaoFornecedor oCCP = new LocacaoFornecedor();
                    oCCP = ObterPor(oLocFornecedor);

                    if (!oCCP.Equals(oLocFornecedor))
                    {
                        descricao = "Locacao Fornecedor id: " + oLocFornecedor.idLocacaoFornecedor + 
                                    " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                        if (!oCCP.idLocacaoContrato.Equals(oLocFornecedor.idLocacaoContrato))
                        {
                            descricao += " Contrato de " + oCCP.idLocacaoContrato + " para " + oLocFornecedor.idLocacaoContrato;
                        }
                        if (!oCCP.locador.Equals(oLocFornecedor.locador))
                        {
                            descricao += " locador de " + oCCP.locador.pessoa.nome + " para " + oLocFornecedor.locador.pessoa.nome;
                        }
                        if (!oCCP.percParticipacao.Equals(oLocFornecedor.percParticipacao))
                        {
                            descricao += " %Participação de " + oCCP.percParticipacao.ToString() + " para " + oLocFornecedor.percParticipacao.ToString();
                        }
                        if (!oCCP.valorAluguel.Equals(oLocFornecedor.valorAluguel))
                        {
                            descricao += " Valor Aluguel de " + oCCP.valorAluguel.ToString() + " para " + oLocFornecedor.valorAluguel.ToString();
                        }
                        if (!oCCP.situacao.Equals(oLocFornecedor.situacao))
                        {
                            descricao += " Situacao de " + oCCP.situacao + " para " + oLocFornecedor.situacao;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Locacao Fiador id: " + oLocFornecedor.idLocacaoFornecedor + 
                                " Contrato Locacao id : " + oLocFornecedor.idLocacaoContrato + 
                                " locador : " + oLocFornecedor.locador.pessoa.nome + " - " + oLocFornecedor.locador.pessoa.idPessoa +
                                " %Participação : " + oLocFornecedor.percParticipacao.ToString() +
                                " Valor Aluguel : " + oLocFornecedor.valorAluguel.ToString() +
                                " Situação : " + oLocFornecedor.situacao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Locacao Fiador id: " + oLocFornecedor.idLocacaoFornecedor +
                                " Contrato Locacao id : " + oLocFornecedor.idLocacaoContrato +
                                " locador : " + oLocFornecedor.locador.pessoa.nome + " - " + oLocFornecedor.locador.pessoa.idPessoa +
                                " %Participação : " + oLocFornecedor.percParticipacao.ToString() +
                                " Valor Aluguel : " + oLocFornecedor.valorAluguel.ToString() +
                                " Situação : " + oLocFornecedor.situacao +
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
