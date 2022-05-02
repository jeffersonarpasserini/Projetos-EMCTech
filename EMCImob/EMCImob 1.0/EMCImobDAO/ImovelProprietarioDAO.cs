using EMCCadastroDAO;
using EMCCadastroModel;
using EMCImobModel;
using EMCLibrary;
using EMCSecurityDAO;
using EMCSecurityModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobDAO
{
    public class ImovelProprietarioDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ImovelProprietarioDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<ImovelProprietario> lstImovelProprietario(int idImovel)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                //String strSQL = "select * from imovelproprietario Where idimovel = @idimovel order by idproprietario "; 
                String strSQL = "select * from imovelproprietario Where idimovel = @idimovel"; 
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", idImovel);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ImovelProprietario> lstImovProprietario = new List<ImovelProprietario>();
                List<ImovelProprietario> lstRetorno = new List<ImovelProprietario>();

                //lstParcela = null;
                //Imovel oImo = new Imovel();

                ImovelProprietario objImovelProprietario;

                while (drCon.Read())
                {
                    consulta = true;
                    objImovelProprietario = new ImovelProprietario();

                    objImovelProprietario.idImovelProprietario = EmcResources.cInt(drCon["idimovelproprietario"].ToString());

                    lstImovProprietario.Add(objImovelProprietario);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (ImovelProprietario oImProp in lstImovProprietario)
                    {
                        ImovelProprietario oPropImovel = new ImovelProprietario();
                        oPropImovel = ObterPor(oImProp);

                        lstRetorno.Add(oPropImovel);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(ImovelProprietario objImovelProprietario, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {
                if (objImovelProprietario.flag == "I")
                {

                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                     "where a.table_name = 'imovelproprietario'" +
                                     "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    // int idIm = 0;
                    while (drCon.Read())
                    {
                        //idIm = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());                    
                        //objImovelProprietario.idImovelProprietario = idIm;
                        objImovelProprietario.idImovelProprietario = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(objImovelProprietario, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into imovelproprietario (idimovel, codempresa, idproprietario, participacao, representante)" +
                                                                "values (@idimovel, @codempresa, @idproprietario, @participacao, @representante )";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idimovel", objImovelProprietario.idImovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@codempresa", objImovelProprietario.idProprietario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idproprietario", objImovelProprietario.idProprietario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@participacao", objImovelProprietario.participacao);
                    SqlconPar.Parameters.AddWithValue("@representante", objImovelProprietario.representante);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();
                }

                else if (objImovelProprietario.flag == "A")
                {
                    geraOcorrencia(objImovelProprietario, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update imovelproprietario set idimovel = @idimovel, codempresa = @codempresa, idproprietario = @idproprietario, participacao = @participacao, representante = @representante where idimovelproprietario = @idimovelproprietario";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idimovelproprietario", objImovelProprietario.idImovelProprietario);
                    SqlconPar.Parameters.AddWithValue("@idimovel", objImovelProprietario.idImovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@codempresa", objImovelProprietario.idProprietario.codEmpresa);
                    SqlconPar.Parameters.AddWithValue("@idproprietario", objImovelProprietario.idProprietario.idPessoa);
                    SqlconPar.Parameters.AddWithValue("@participacao", objImovelProprietario.participacao);
                    SqlconPar.Parameters.AddWithValue("@representante", objImovelProprietario.representante);

                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();
                }

                else if (objImovelProprietario.flag == "E")
                {
                    geraOcorrencia(objImovelProprietario, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "delete from imovelproprietario where idimovelproprietario = @idimovelproprietario";
                    
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);                    
                    Sqlcon.Parameters.AddWithValue("@idimovelproprietario", objImovelProprietario.idImovelProprietario);

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

        public ImovelProprietario ObterPor(ImovelProprietario oImovelProprietario)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from imovelproprietario Where idimovelproprietario = @idimovelproprietario";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovelproprietario", oImovelProprietario.idImovelProprietario);
                

                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                Imovel oImo = new Imovel();

                ImovelProprietario objImovelProprietario = new ImovelProprietario();

                while (drCon.Read())
                {
                    consulta = true;
                    objImovelProprietario.idImovelProprietario = EmcResources.cInt(drCon["idimovelproprietario"].ToString());

                    oImo.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objImovelProprietario.idImovel = oImo;

                    
                    Fornecedor oProp = new Fornecedor();
                    oProp.codEmpresa = EmcResources.cInt(drCon["codempresa"].ToString());
                    oProp.idPessoa = EmcResources.cInt(drCon["idproprietario"].ToString());
                    objImovelProprietario.idProprietario = oProp;

                    objImovelProprietario.participacao = EmcResources.cDouble(drCon["participacao"].ToString());
                    objImovelProprietario.representante = drCon["representante"].ToString();

                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ImovelDAO oImovDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                    objImovelProprietario.idImovel = oImovDAO.ObterPorLstImovel(objImovelProprietario.idImovel);

                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    objImovelProprietario.idProprietario = oFornecedorDAO.ObterPor(objImovelProprietario.idProprietario);

                }
                return objImovelProprietario;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(ImovelProprietario oImovelProprietario, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oImovelProprietario.idImovel.idImovel.ToString();

                if (flag == "A")
                {

                    ImovelProprietario oImovelProp = new ImovelProprietario();
                    oImovelProp = ObterPor(oImovelProprietario);

                    if (!oImovelProp.Equals(oImovelProprietario))
                    {
                        descricao = "Imovel Proprietario id: " + oImovelProprietario.idImovel.idImovel + " Imóvel :" + oImovelProprietario.idImovel.idImovel + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oImovelProp.idProprietario.codEmpresa.Equals(oImovelProprietario.idProprietario.codEmpresa))
                        {
                            descricao += " Empresa de " + oImovelProp.idProprietario.codEmpresa + " para " + oImovelProprietario.idProprietario.codEmpresa;
                        }
                        if (!oImovelProp.idProprietario.idPessoa.Equals(oImovelProprietario.idProprietario.idPessoa))
                        {
                            descricao += " Proprietário de " + oImovelProp.idProprietario.idPessoa + " para " + oImovelProprietario.idProprietario.idPessoa;
                        }
                        if (!oImovelProp.participacao.Equals(oImovelProprietario.participacao))
                        {
                            descricao += " Participação de " + oImovelProp.participacao + " para " + oImovelProprietario.participacao;
                        }
                        if (!oImovelProp.representante.Equals(oImovelProprietario.representante))
                        {
                            descricao += " Representante de " + oImovelProp.representante + " para " + oImovelProprietario.representante;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Imóvel Proprietário id : " + oImovelProprietario.idImovelProprietario +
                                " - Imovel - " + oImovelProprietario.idImovel.idImovel +
                                " - Empresa - " + oImovelProprietario.idProprietario.codEmpresa +
                                " - Proprietário - " + oImovelProprietario.idProprietario.idPessoa +
                                " - Participação - " + oImovelProprietario.participacao +
                                " - Representante - " + oImovelProprietario.representante +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Imóvel Proprietário id : " + oImovelProprietario.idImovelProprietario +
                                " - Imovel - " + oImovelProprietario.idImovel.idImovel +
                                //" - Empresa - " + oImovelProprietario.idProprietario.codEmpresa +
                                //" - Proprietário - " + oImovelProprietario.idProprietario.idPessoa +
                                " - Participação - " + oImovelProprietario.participacao +
                                " - Representante - " + oImovelProprietario.representante +
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
