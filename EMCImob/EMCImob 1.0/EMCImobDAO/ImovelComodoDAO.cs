using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityDAO;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroDAO;

namespace EMCImobDAO
{
    public class ImovelComodoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ImovelComodoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public List<ImovelComodo> lstImovelComodo(int idImovel)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from imovelcomodo Where idimovel = @idimovel order by descricao ";
               

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", idImovel);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                List<ImovelComodo> lstImovComodo = new List<ImovelComodo>();
                List<ImovelComodo> lstRetorno = new List<ImovelComodo>();

                //lstParcela = null;
                //Imovel oImo = new Imovel();

                ImovelComodo objImovelComodo;

                while (drCon.Read())
                {
                    consulta = true;
                    objImovelComodo = new ImovelComodo();

                    Imovel oImovel = new Imovel();
                    oImovel.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objImovelComodo.idImovel = oImovel;

                    Comodo oComodo = new Comodo();
                    oComodo.idComodos = EmcResources.cInt(drCon["idcomodos"].ToString());
                    oComodo.descricao = drCon["descricao"].ToString();
                    objImovelComodo.idComodos = oComodo;

                   // objImovelComodo.idComodos.descricao = drCon["descricao"].ToString();
                    objImovelComodo.nroDepencia = EmcResources.cInt(drCon["nroDepencia"].ToString());
                    objImovelComodo.descricao = drCon["descricao"].ToString();
                    objImovelComodo.flag = "";

                    lstImovComodo.Add(objImovelComodo);
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    foreach (ImovelComodo oImCom in lstImovComodo)
                    {
                        ImovelDAO oImoDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                        oImCom.idImovel = oImoDAO.ObterPorLstImovel(oImCom.idImovel);

                        lstRetorno.Add(oImCom);
                    }
                }

                return lstRetorno;
            }

            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        public void Salvar(ImovelComodo objImovelComodo, MySqlConnection Conexao, MySqlTransaction transacao)
        {
            //Grava um novo registro de PagarParcela
            try
            {

                if (objImovelComodo.flag == "I")
                {
                    geraOcorrencia(objImovelComodo, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into imovelcomodo (idimovel, idcomodos, nrodepencia, descricao)" +
                                                                "values (@idimovel, @idcomodos, @nrodepencia, @descricao)";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idimovel", objImovelComodo.idImovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@idcomodos", objImovelComodo.idComodos.idComodos);
                    SqlconPar.Parameters.AddWithValue("@nrodepencia", objImovelComodo.nroDepencia);
                    SqlconPar.Parameters.AddWithValue("@descricao", objImovelComodo.descricao);



                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();
                }
                else if (objImovelComodo.flag == "A")
                {

                    geraOcorrencia(objImovelComodo, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update imovelcomodo set nrodepencia = @nrodepencia, descricao = @descricao where idimovel = @idimovel and idcomodos = @idcomodos";
                    //String strSQL = "update imovelcomodo set nrodepencia = @nrodepencia, descricao = @descricao where idimovel = @idimovel";
                    MySqlCommand SqlconPar = new MySqlCommand(@strSQL, Conexao, transacao);
                    SqlconPar.Parameters.AddWithValue("@idimovel", objImovelComodo.idImovel.idImovel);
                    SqlconPar.Parameters.AddWithValue("@idcomodos", objImovelComodo.idComodos.idComodos);
                    SqlconPar.Parameters.AddWithValue("@nrodepencia", objImovelComodo.nroDepencia);
                    SqlconPar.Parameters.AddWithValue("@descricao", objImovelComodo.descricao);


                    //abre conexao e executa o comando
                    SqlconPar.ExecuteNonQuery();

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);
                    //transacao.Commit();

                }
                else if (objImovelComodo.flag == "E")
                {
                    geraOcorrencia(objImovelComodo, "E");

                    //Monta comando para a gravação do registro
                    String strSQL = "delete from imovelcomodo where idimovel = @idimovel and idcomodos = @idcomodos";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idimovel", objImovelComodo.idImovel.idImovel);
                    Sqlcon.Parameters.AddWithValue("@idcomodos", objImovelComodo.idComodos.idComodos);

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

        public ImovelComodo ObterPor(ImovelComodo oImovelComodo)
        {
            bool consulta = false;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from imovelcomodo Where idimovel = @idimovel and idcomodos = @idcomodos";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", oImovelComodo.idImovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idcomodos", oImovelComodo.idComodos.idComodos);


                MySqlDataReader drCon;


                drCon = Sqlcon.ExecuteReader();

                Imovel oImo = new Imovel();

                ImovelComodo objImovelComodo = new ImovelComodo();

                while (drCon.Read())
                {
                    consulta = true;


                    oImo.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());
                    objImovelComodo.idImovel = oImo;

                    Comodo oCom = new Comodo();
                    oCom.idComodos = EmcResources.cInt(drCon["idcomodos"].ToString());
                    oCom.descricao = drCon["descricao"].ToString();
                    objImovelComodo.idComodos = oCom;

                    objImovelComodo.descricao = drCon["descricao"].ToString();
                    objImovelComodo.nroDepencia = EmcResources.cInt(drCon["nrodepencia"].ToString());


                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (consulta)
                {
                    ImovelDAO oImovDAO = new ImovelDAO(parConexao, oOcorrencia, codEmpresa);
                    objImovelComodo.idImovel = oImovDAO.ObterPorLstImovel(objImovelComodo.idImovel);

                }
                return objImovelComodo;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }

        private void geraOcorrencia(ImovelComodo oImovelComodo, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                //oOcorrencia.chaveidentificacao = oImovelComodo.idImovel.ToString();
                oOcorrencia.chaveidentificacao = oImovelComodo.idImovel.idImovel.ToString();

                if (flag == "A")
                {
                    //Imovel objImovel = new Imovel();
                    ImovelComodo oImovelCom = new ImovelComodo();
                    oImovelCom = ObterPor(oImovelComodo);

                   

                        if (!oImovelCom.Equals(oImovelComodo))
                        {
                            descricao = "Imovel Comodo id: " + oImovelComodo.idImovel.idImovel + " Imóvel :" + oImovelComodo.idImovel.idImovel + " foi alterada por " + oOcorrencia.usuario.nome + " - ";

                            if (!oImovelCom.nroDepencia.Equals(oImovelComodo.nroDepencia))
                            {
                                descricao += " Nro. Dependência de " + oImovelCom.nroDepencia + " para " + oImovelComodo.nroDepencia;
                            }
                            if (!oImovelCom.descricao.Equals(oImovelComodo.descricao))
                            {
                                descricao += " Descição de " + oImovelCom.descricao + " para " + oImovelComodo.descricao;
                            }
                        }
                    
                }
                else if (flag == "I")
                {
                    descricao = "Imóvel Comodo id : " + oImovelComodo.idImovel +
                                " - Imovel - " + oImovelComodo.idImovel.idImovel +
                                " - Comodo - " + oImovelComodo.idComodos +
                                " - Nro Dependencia - " + oImovelComodo.nroDepencia +
                                " - Descrição - " + oImovelComodo.descricao +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Imóvel Comodo id : " + oImovelComodo.idImovel +
                                " - Imovel - " + oImovelComodo.idImovel.idImovel +
                                " - Comodo - " + oImovelComodo.idComodos +
                                " - Nro Dependencia - " + oImovelComodo.nroDepencia +
                                " - Descrição - " + oImovelComodo.descricao +
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
