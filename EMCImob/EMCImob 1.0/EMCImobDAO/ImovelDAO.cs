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
    public class ImovelDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
        //  int idIm = 0;

        public ImovelDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(Imovel objImovel)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro de PagarDocumento
            try
            {
                Salvar(Conexao, transacao, objImovel);
                //transacao.Commit();
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
        public void Salvar(MySqlConnection Conecta, MySqlTransaction transacao, Imovel objImovel)
        {
            //  MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'imovel'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                //    int idIm = 0;

                while (drCon.Read())
                {
                    objImovel.idImovel = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                    //     objImovel.idImovel = idIm;
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objImovel, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into imovel (idtipoimovel, descricao, rua, numero, complemento, bairro, cidade, estado, nrocep, " +
                                                    "anotacoes, observacoes, valorvenda, valoraluguel, valorcondominio, enderecochave, " +
                                                    "matriculacri, areaconstruida, codempresa, idproprietario, idcarteiraimoveis, idcontacusto, situacao, " + 
                                                    "idempresa, codigoimovel ) " +
                                            "values (@idtipoimovel, @descricao, @rua, @numero, @complemento, @bairro, @cidade, @estado, @nrocep, " +
                                                    "@anotacoes, @observacoes, @valorvenda, @valoraluguel, @valorcondominio, @enderecochave, " +
                                                    "@matriculacri, @areaconstruida, @codempresa, @idproprietario, @idcarteiraimoveis, @idcontacusto, @situacao, " + 
                                                    "@idempresa, @codigoimovel )";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", objImovel.tipoImovel.idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@descricao", objImovel.descricao);
                Sqlcon.Parameters.AddWithValue("@rua", objImovel.rua);
                Sqlcon.Parameters.AddWithValue("@numero", objImovel.numero);
                Sqlcon.Parameters.AddWithValue("@complemento", objImovel.complemento);
                Sqlcon.Parameters.AddWithValue("@bairro", objImovel.bairro);
                Sqlcon.Parameters.AddWithValue("@cidade", objImovel.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objImovel.estado);
                Sqlcon.Parameters.AddWithValue("@nrocep", objImovel.nroCep);
                Sqlcon.Parameters.AddWithValue("@anotacoes", objImovel.anotacoes);
                Sqlcon.Parameters.AddWithValue("@observacoes", objImovel.observacoes);
                Sqlcon.Parameters.AddWithValue("@valorvenda", objImovel.valorVenda);
                Sqlcon.Parameters.AddWithValue("@valoraluguel", objImovel.valorAluguel);
                Sqlcon.Parameters.AddWithValue("@valorcondominio", objImovel.valorCondominio);
                Sqlcon.Parameters.AddWithValue("@enderecochave", objImovel.enderecoChave);
                Sqlcon.Parameters.AddWithValue("@matriculacri", objImovel.matriculaCri);
                Sqlcon.Parameters.AddWithValue("@areaconstruida", objImovel.areaConstruida);
                Sqlcon.Parameters.AddWithValue("@codempresa", objImovel.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idproprietario", objImovel.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", objImovel.carteiraImoveis.idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objImovel.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@situacao", objImovel.situacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", objImovel.empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", objImovel.codigoImovel);


                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);
                transacao.Commit();

                //grava ImovelComodo
                ImovelComodoDAO oImovelComDAO = new ImovelComodoDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ImovelComodo objImoCom in objImovel.lstComodo)
                {
                    if (objImoCom.idImovel.idImovel <= 0)
                    {
                        objImoCom.idImovel = objImovel;
                    }
                    oImovelComDAO.Salvar(objImoCom, Conecta, transacao);
                }

                //grava ImovelProprietário
                ImovelProprietarioDAO oImovelPropDAO = new ImovelProprietarioDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ImovelProprietario objImoProp in objImovel.lstProprietario)
                {
                    if (objImoProp.idImovel.idImovel <= 0)
                    {
                        objImoProp.idImovel = objImovel;
                    }
                    oImovelPropDAO.Salvar(objImoProp, Conecta, transacao);
                }

            }
            catch (MySqlException erro)
            {
                // transacao.Rollback();
                throw erro;
            }
            //finally
            //{
            //    transacao.Dispose();
            //    transacao = null;
            //}

        }

        public void Atualizar(Imovel objImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro
            try
            {
                Atualizar(Conexao, transacao, objImovel);

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
        public void Atualizar(MySqlConnection Conecta, MySqlTransaction transacao, Imovel objImovel)
        {
            
            //atualiza um registro
            try
            {
                geraOcorrencia(objImovel, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update imovel set idtipoimovel = @idtipoimovel, descricao = @descricao, rua = @rua, numero = @numero, complemento = @complemento, " +
                            " bairro = @bairro, cidade = @cidade, estado = @estado, nrocep = @nrocep, anotacoes = @anotacoes, observacoes = @observacoes, valorvenda = @valorvenda, " +
                            " valoraluguel = @valoraluguel, valorcondominio = @valorcondominio, enderecochave = @enderecochave, matriculacri = @matriculacri, areaconstruida = @areaconstruida, " +
                            " codempresa = @codempresa, idproprietario = @idproprietario, idcarteiraimoveis = @idcarteiraimoveis, idcontacusto = @idcontacusto, situacao = @situacao, " + 
                            " idempresa = @idempresa, codigoimovel = @codigoimovel " +
                            " where idimovel = @idimovel";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                Sqlcon.Parameters.AddWithValue("@idimovel", objImovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", objImovel.tipoImovel.idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@descricao", objImovel.descricao);
                Sqlcon.Parameters.AddWithValue("@rua", objImovel.rua);
                Sqlcon.Parameters.AddWithValue("@numero", objImovel.numero);
                Sqlcon.Parameters.AddWithValue("@complemento", objImovel.complemento);
                Sqlcon.Parameters.AddWithValue("@bairro", objImovel.bairro);
                Sqlcon.Parameters.AddWithValue("@cidade", objImovel.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objImovel.estado);
                Sqlcon.Parameters.AddWithValue("@nrocep", objImovel.nroCep);
                Sqlcon.Parameters.AddWithValue("@anotacoes", objImovel.anotacoes);
                Sqlcon.Parameters.AddWithValue("@observacoes", objImovel.observacoes);
                Sqlcon.Parameters.AddWithValue("@valorvenda", objImovel.valorVenda);
                Sqlcon.Parameters.AddWithValue("@valoraluguel", objImovel.valorAluguel);
                Sqlcon.Parameters.AddWithValue("@valorcondominio", objImovel.valorCondominio);
                Sqlcon.Parameters.AddWithValue("@enderecochave", objImovel.enderecoChave);
                Sqlcon.Parameters.AddWithValue("@matriculacri", objImovel.matriculaCri);
                Sqlcon.Parameters.AddWithValue("@areaconstruida", objImovel.areaConstruida);
                Sqlcon.Parameters.AddWithValue("@codempresa", objImovel.fornecedor.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idproprietario", objImovel.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", objImovel.carteiraImoveis.idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objImovel.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@situacao", objImovel.situacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", objImovel.empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", objImovel.codigoImovel);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);


                //chamar a lista de atualização do imovelcomodo e imovelproprietario
                ImovelComodoDAO oImovelComDAO = new ImovelComodoDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ImovelComodo objImoCom in objImovel.lstComodo)
                {
                    if (objImoCom.idImovel.idImovel <= 0)
                    {
                        objImoCom.idImovel = objImovel;
                    }
                    oImovelComDAO.Salvar(objImoCom, Conecta, transacao);
                }

                ImovelProprietarioDAO oImovelPropDAO = new ImovelProprietarioDAO(parConexao, oOcorrencia, codEmpresa);
                foreach (ImovelProprietario objImoProp in objImovel.lstProprietario)
                {
                    if (objImoProp.idImovel.idImovel <= 0)
                    {
                        objImoProp.idImovel = objImovel;
                    }
                    oImovelPropDAO.Salvar(objImoProp, Conexao, transacao);
                }

               

            }
            catch (MySqlException erro)
            {
               
                throw erro;
            }
            

        }

        public void Excluir(Imovel objImovel)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objImovel, "E");

                //Monta comando para a gravação do registro
                //String strSQL = "delete from imovel where idimovel = @idimovel";
                String strSQL = "update imovel set idtipoimovel = @idtipoimovel, descricao = @descricao, rua = @rua, numero = @numero, complemento = @complemento, " +
                            " bairro = @bairro, cidade = @cidade, estado = @estado, nrocep = @nrocep, anotacoes = @anotacoes, observacoes = @observacoes, valorvenda = @valorvenda, " +
                            " valoraluguel = @valoraluguel, valorcondominio = @valorcondominio, enderecochave = @enderecochave, matriculacri = @matriculacri, areaconstruida = @areaconstruida, " +
                            " idcarteiraimoveis = @idcarteiraimoveis, idcontacusto = @idcontacusto, situacao = @situacao, " +
                            " idempresa = @idempresa, codigoimovel = @codigoimovel " +
                            " where idimovel = @idimovel";


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", objImovel.idImovel);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", objImovel.tipoImovel.idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@descricao", objImovel.descricao);
                Sqlcon.Parameters.AddWithValue("@rua", objImovel.rua);
                Sqlcon.Parameters.AddWithValue("@numero", objImovel.numero);
                Sqlcon.Parameters.AddWithValue("@complemento", objImovel.complemento);
                Sqlcon.Parameters.AddWithValue("@bairro", objImovel.bairro);
                Sqlcon.Parameters.AddWithValue("@cidade", objImovel.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objImovel.estado);
                Sqlcon.Parameters.AddWithValue("@nrocep", objImovel.nroCep);
                Sqlcon.Parameters.AddWithValue("@anotacoes", objImovel.anotacoes);
                Sqlcon.Parameters.AddWithValue("@observacoes", objImovel.observacoes);
                Sqlcon.Parameters.AddWithValue("@valorvenda", objImovel.valorVenda);
                Sqlcon.Parameters.AddWithValue("@valoraluguel", objImovel.valorAluguel);
                Sqlcon.Parameters.AddWithValue("@valorcondominio", objImovel.valorCondominio);
                Sqlcon.Parameters.AddWithValue("@enderecochave", objImovel.enderecoChave);
                Sqlcon.Parameters.AddWithValue("@matriculacri", objImovel.matriculaCri);
                Sqlcon.Parameters.AddWithValue("@areaconstruida", objImovel.areaConstruida);
                //Sqlcon.Parameters.AddWithValue("@codempresa", objImovel.fornecedor.codEmpresa);
                //Sqlcon.Parameters.AddWithValue("@idproprietario", objImovel.fornecedor.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", objImovel.carteiraImoveis.idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objImovel.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@situacao", objImovel.situacao);
                Sqlcon.Parameters.AddWithValue("@idempresa", objImovel.empresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", objImovel.codigoImovel);

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

        public DataTable pesquisaImovel(int empMaster, int idImovel, string codigoImovel, int idEmpresa, int idTipoImovel, int idCarteiraImoveis, string idCep, string cidade,
                                        string estado, string bairro, string rua, string numero, string complemento, bool chkTipoImovel, bool chkCarteiraImoveis)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                // String strSQL = "select i.* from imovel i ";

                String strSQL = "SELECT i.*, t.descricao as desc_tipoimovel, c.descricao as desc_carteira, i.nrocep as idcep" +
                                " from imovel i " +
                                " left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                " left join empresa e on e.idempresa = i.idempresa " +
                                " left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis ";


                //filtra tipo imovel
                if (idTipoImovel > 0 && !chkTipoImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.idtipoimovel = @idtipoimovel ";
                }

                //filtra tipo carteira
                if (idCarteiraImoveis > 0 && !chkCarteiraImoveis)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " and i.idcarteiraimoveis = @idcarteiraimoveis ";
                }

                //filtra tipo cep
                if (!String.IsNullOrEmpty(idCep.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.nrocep like @idcep ";
                }

                if (!String.IsNullOrEmpty(cidade.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.cidade like @cidade ";
                }

                if (!String.IsNullOrEmpty(estado.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.estado like @estado ";
                }
                if (!String.IsNullOrEmpty(bairro.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.bairro like @bairro ";
                }

                //filtra tipo rua
                if (!String.IsNullOrEmpty(rua.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.rua like @rua ";
                }

                //filtra tipo numero
                if (!String.IsNullOrEmpty(numero.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.numero like @numero ";
                }

                //filtra tipo complemento
                if (!String.IsNullOrEmpty(complemento.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.complemento like @complemento ";
                }
                if (!String.IsNullOrEmpty(codigoImovel.Trim()))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.codigoimovel like @codigoimovel ";
                }
                if (idEmpresa > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idempresa = @idempresa ";
                }



                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@idcep", "%" + idCep.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@cidade", "%" + cidade.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@estado", "%" + estado.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@bairro", "%" + bairro.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@rua", "%" + rua.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@numero", "%" + numero.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@complemento", "%" + complemento.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@codigoimovel", "%" + codigoImovel.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@idempresa", idEmpresa);



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

        public DataTable ListaImovel()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT i.*, t.descricao as desc_tipoimovel, c.descricao as desc_carteira " +
                                " from imovel i  " +
                                " left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                " left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis " +
                                " order by i.descricao";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                daCon.Dispose();
                daCon = null;
            }
        }

        public DataTable dstRelatorioSimplificado(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                                  int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT i.*, t.descricao as desc_tipoimovel, c.descricao as desc_carteira, f.nome as nomeproprietario, cc.codigoconta as contacusto " +
                                " from imovel i " +
                                " left join v_fornecedor f on f.codempresa = i.codempresa and f.idpessoa = i.idproprietario " +
                                " left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                " left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis " +
                                " left join contacusto cc on cc.idcontacusto = i.idcontacusto ";


                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }

                //filtra tipo imovel
                if (idTipoImovel > 0 && !chkTipoImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idtipoimovel = @idtipoimovel ";
                }
                //filtra tipo carteira
                if (idCarteiraImoveis > 0 && !chkCarteiraImoveis)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idcarteiraimoveis = @idcarteiraimoveis ";
                }

                if (!String.IsNullOrEmpty(situacao) && !chkSituacao)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL = strSQL + " situacao = @situacao ";
                }

                if (idProprietario > 0 && !chkProprietario)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idproprietario = @idproprietario ";
                }
                strSQL += " order by idimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@situacao", situacao);
                Sqlcon.Parameters.AddWithValue("@idproprietario", idProprietario);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);

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

        public DataTable dstRelatorioCompleto(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao, 
                                              int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL ="SELECT i.*, t.descricao as desc_tipoimovel, c.descricao as desc_carteira, f.nome as nomeproprietario, cc.codigoconta as contacusto, ip.participacao as participacao, ip.representante as representante " +
                               "from imovel i " +
                               "left join v_fornecedor f on f.codempresa = i.codempresa and f.idpessoa = i.idproprietario "+
                               "left join tipoimovel t on t.idtipoimovel = i.idtipoimovel "+
                               "left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis "+ 
                               "left join contacusto cc on cc.idcontacusto = i.idcontacusto " +
                               "left join imovelproprietario ip on ip.idimovel = i.idimovel ";


                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }                   
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }
                

                    //filtra tipo imovel
                    if (idTipoImovel > 0 && !chkTipoImovel)
                    {
                        if (colocaWhere == 0)
                        {
                            strSQL += " where ";
                            colocaWhere++;
                        }
                        else
                            strSQL += " and ";
                        strSQL += " i.idtipoimovel = @idtipoimovel ";
                    }
                    //filtra tipo carteira
                    if (idCarteiraImoveis > 0 && !chkCarteiraImoveis)
                    {
                        if (colocaWhere == 0)
                        {
                            strSQL += " where ";
                            colocaWhere++;
                        }
                        else
                            strSQL += " and ";
                        strSQL += " i.idcarteiraimoveis = @idcarteiraimoveis ";
                    }

                    if (!String.IsNullOrEmpty(situacao) && !chkSituacao)
                    {
                        if (colocaWhere == 0)
                        {
                            strSQL += " where ";
                            colocaWhere++;
                        }
                        else
                            strSQL += " and ";
                        strSQL = strSQL + " situacao = @situacao ";
                    }
                
                if (idProprietario > 0 && !chkProprietario)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idproprietario = @idproprietario ";
                }

                strSQL += " order by idimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@situacao", situacao);
                Sqlcon.Parameters.AddWithValue("@idproprietario", idProprietario);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);

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

        public DataTable dstRelatorioProprietario(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                                  int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT ip.*, f.nome as nomeproprietario " +
                                "from imovelproprietario ip " +                                
                                "left join imovel i on i.idimovel = ip.idimovel " +
                                "left join v_fornecedor f on f.codempresa = ip.codempresa and f.idpessoa = ip.idproprietario " +
                                "left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                "left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis " ;



                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }               

                //filtra tipo imovel
                if (idTipoImovel > 0 && !chkTipoImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idtipoimovel = @idtipoimovel ";
                }
                //filtra tipo carteira
                if (idCarteiraImoveis > 0 && !chkCarteiraImoveis)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idcarteiraimoveis = @idcarteiraimoveis ";
                }

                if (!String.IsNullOrEmpty(situacao) && !chkSituacao)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL = strSQL + " i.situacao = @situacao ";
                }

                if (idProprietario > 0 && !chkProprietario)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " ip.idproprietario = @idproprietario ";
                }
                //strSQL += " order by idimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@situacao", situacao);
                Sqlcon.Parameters.AddWithValue("@idproprietario", idProprietario);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);

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


        public DataTable dstRelatorioImovelProprietario(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                                        int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT ip.*, f.nome as nomeproprietario, t.descricao as desc_tipoimovel, i.rua as rua, i.numero as numero, i.cidade as cidade, i.valoraluguel as valoraluguel, i.situacao as situacao " +
                                "from imovelproprietario ip " +
                                "left join imovel i on i.idimovel = ip.idimovel " +
                                "left join v_fornecedor f on f.codempresa = ip.codempresa and f.idpessoa = ip.idproprietario " +
                                "left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                "left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis ";



                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }

                //filtra tipo imovel
                if (idTipoImovel > 0 && !chkTipoImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idtipoimovel = @idtipoimovel ";
                }
                //filtra tipo carteira
                if (idCarteiraImoveis > 0 && !chkCarteiraImoveis)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idcarteiraimoveis = @idcarteiraimoveis ";
                }

                if (!String.IsNullOrEmpty(situacao) && !chkSituacao)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL = strSQL + " i.situacao = @situacao ";
                }

                if (idProprietario > 0 && !chkProprietario)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " ip.idproprietario = @idproprietario ";
                }
                strSQL += " order by idimovel ";

                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@situacao", situacao);
                Sqlcon.Parameters.AddWithValue("@idproprietario", idProprietario);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);

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

        public DataTable dstRelatorioComodo(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                            int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            try
            {
                int colocaWhere = 0;
                //Monta comando para a gravação do registro
                string strSQL = "SELECT ic.*, p.nome as nomeproprietario, cm.descricao as desc_comodo, ic.nrodepencia as dependencia " +
                                " from imovelcomodo ic " +
                                " left join imovel i on i.idimovel = ic.idimovel " +
                                " left join comodos cm on cm.idcomodos = ic.idcomodos " +
                                " left join tipoimovel t on t.idtipoimovel = i.idtipoimovel " +
                                " left join carteiraimoveis c on c.idcarteiraimoveis = i.idcarteiraimoveis " +
                                " left join pessoa p on p.idpessoa = i.idproprietario ";

                if (!String.IsNullOrEmpty(codigoImovel))
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    strSQL += " i.codigoimovel = @codigoimovel ";
                }

                //filtra tipo imovel
                if (idTipoImovel > 0 && !chkTipoImovel)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idtipoimovel = @idtipoimovel ";
                }
                //filtra tipo carteira
                if (idCarteiraImoveis > 0 && !chkCarteiraImoveis)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " i.idcarteiraimoveis = @idcarteiraimoveis ";
                }

                if (!String.IsNullOrEmpty(situacao) && !chkSituacao)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL = strSQL + " situacao = @situacao ";
                }

                if (idProprietario > 0 && !chkProprietario)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }
                    else
                        strSQL += " and ";
                    strSQL += " p.idpessoa = @idproprietario ";
                }



                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idtipoimovel", idTipoImovel);
                Sqlcon.Parameters.AddWithValue("@idcarteiraimoveis", idCarteiraImoveis);
                Sqlcon.Parameters.AddWithValue("@situacao", situacao);
                Sqlcon.Parameters.AddWithValue("@idproprietario", idProprietario);
                Sqlcon.Parameters.AddWithValue("@codigoimovel", codigoImovel);

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


        public Imovel ObterPor(Imovel oImovel)
        {
            MySqlDataReader drCon;
            Imovel objRetorno = new Imovel();
            Boolean bControle = false;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oImovel.idImovel > 0)
                {
                    //Monta comando para a gravação do registro
                    //strSQL = "select * from imovel Where idimovel = " + oImovel.idImovel + " ";
                    strSQL = "select * from imovel where idimovel=@idimovel";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@idimovel", oImovel.idImovel);

                    drCon = Sqlcon.ExecuteReader();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from imovel where codigoimovel=@codigoimovel and idempresa=@idempresa";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                    Sqlcon.Parameters.AddWithValue("@codigoimovel", oImovel.codigoImovel);
                    Sqlcon.Parameters.AddWithValue("@idempresa", oImovel.empresa.idEmpresa);
                    
                    drCon = Sqlcon.ExecuteReader();
                }

                    while (drCon.Read())
                    {
                        bControle = true;
                        objRetorno.idImovel = EmcResources.cInt(drCon["idimovel"].ToString());

                        TipoImovel oTipoImovel = new TipoImovel();
                        oTipoImovel.idTipoImovel = EmcResources.cInt(drCon["idtipoimovel"].ToString());
                        //oTipoImovel.descricao = drCon["descricao"].ToString();
                        objRetorno.tipoImovel = oTipoImovel;

                        objRetorno.descricao = drCon["descricao"].ToString();
                        objRetorno.rua = drCon["rua"].ToString();
                        objRetorno.numero = drCon["numero"].ToString();
                        objRetorno.complemento = drCon["complemento"].ToString();
                        objRetorno.bairro = drCon["bairro"].ToString();
                        objRetorno.cidade = drCon["cidade"].ToString();
                        objRetorno.estado = drCon["estado"].ToString();
                        objRetorno.nroCep = drCon["nrocep"].ToString();
                        objRetorno.anotacoes = drCon["anotacoes"].ToString();
                        objRetorno.observacoes = drCon["observacoes"].ToString();
                        objRetorno.valorVenda = EmcResources.cCur(drCon["valorvenda"].ToString());
                        objRetorno.valorAluguel = EmcResources.cCur(drCon["valoraluguel"].ToString());
                        objRetorno.valorCondominio = EmcResources.cCur(drCon["valorcondominio"].ToString());
                        objRetorno.enderecoChave = drCon["enderecochave"].ToString();
                        objRetorno.matriculaCri = drCon["matriculacri"].ToString();
                        objRetorno.areaConstruida = EmcResources.cDouble(drCon["areaconstruida"].ToString());

                        Fornecedor oFornecedor = new Fornecedor();
                        oFornecedor.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                        oFornecedor.idPessoa = Convert.ToInt32(drCon["idproprietario"].ToString());
                        // oFornecedor.pessoa.nome = drCon["nome"].ToString();
                        objRetorno.fornecedor = oFornecedor;

                        CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
                        oCarteiraImoveis.idCarteiraImoveis = EmcResources.cInt(drCon["idcarteiraimoveis"].ToString());
                        // oCarteiraImoveis.Descricao = drCon["descricao"].ToString();
                        objRetorno.carteiraImoveis = oCarteiraImoveis;

                        ContaCusto oContaCusto = new ContaCusto();
                        oContaCusto.idContaCusto = EmcResources.cInt(drCon["idcontacusto"].ToString());
                        objRetorno.contaCusto = oContaCusto;

                        objRetorno.situacao = drCon["situacao"].ToString();

                        Empresa oEmpresa = new Empresa();
                        oEmpresa.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                        objRetorno.empresa = oEmpresa;

                        objRetorno.codigoImovel = drCon["codigoimovel"].ToString();

                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    if (bControle)
                    {
                        ContaCustoDAO oCtaCustoDAO = new ContaCustoDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.contaCusto = oCtaCustoDAO.ObterPor(objRetorno.contaCusto);                       

                        TipoImovelDAO oTipoImovelDAO = new TipoImovelDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.tipoImovel = oTipoImovelDAO.ObterPor(objRetorno.tipoImovel);

                        FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.fornecedor = oFornecedorDAO.ObterPor(objRetorno.fornecedor);

                        CarteiraImoveisDAO oCarteiraImoveisDAO = new CarteiraImoveisDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.carteiraImoveis = oCarteiraImoveisDAO.ObterPor(objRetorno.carteiraImoveis);

                        EmpresaDAO oEmpresaDAO = new EmpresaDAO(parConexao, oOcorrencia);
                        objRetorno.empresa = oEmpresaDAO.ObterPor(objRetorno.empresa);


                        ImovelComodoDAO oImovelComodoDAO = new ImovelComodoDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.lstComodo = oImovelComodoDAO.lstImovelComodo(objRetorno.idImovel);

                        ImovelProprietarioDAO oImovelProprietarioDAO = new ImovelProprietarioDAO(parConexao, oOcorrencia, codEmpresa);
                        objRetorno.lstProprietario = oImovelProprietarioDAO.lstImovelProprietario(objRetorno.idImovel);
                        

                    }
                //}
                return objRetorno;

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

        public Imovel ObterPorLstImovel(Imovel oImovel)
        {
            bool Consulta = false;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from imovel Where idimovel = @idimovel ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idimovel", oImovel.idImovel);

                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Imovel objImovel = new Imovel();

                while (drCon.Read())
                {
                    Consulta = true;

                    objImovel.idImovel = Convert.ToInt32(drCon["idimovel"].ToString());

                    TipoImovel oTipoImovel = new TipoImovel();
                    oTipoImovel.idTipoImovel = EmcResources.cInt(drCon["idtipoimovel"].ToString());
                    // oTipoImovel.descricao = drCon["descricao"].ToString();
                    objImovel.tipoImovel = oTipoImovel;

                    objImovel.descricao = drCon["descricao"].ToString();
                    objImovel.rua = drCon["rua"].ToString();
                    objImovel.numero = drCon["numero"].ToString();
                    objImovel.complemento = drCon["complemento"].ToString();
                    objImovel.bairro = drCon["bairro"].ToString();
                    objImovel.cidade = drCon["cidade"].ToString();
                    objImovel.estado = drCon["estado"].ToString();
                    objImovel.nroCep = drCon["nrocep"].ToString();
                    objImovel.anotacoes = drCon["anotacoes"].ToString();
                    objImovel.observacoes = drCon["observacoes"].ToString();
                    objImovel.valorVenda = EmcResources.cCur(drCon["valorvenda"].ToString());
                    objImovel.valorAluguel = EmcResources.cCur(drCon["valoraluguel"].ToString());
                    objImovel.valorCondominio = EmcResources.cCur(drCon["valorcondominio"].ToString());
                    objImovel.enderecoChave = drCon["enderecochave"].ToString();
                    objImovel.matriculaCri = drCon["matriculacri"].ToString();
                    objImovel.areaConstruida = EmcResources.cDouble(drCon["areaconstruida"].ToString());

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = Convert.ToInt32(drCon["codempresa"].ToString());
                    oFornecedor.idPessoa = Convert.ToInt32(drCon["idproprietario"].ToString());
                    objImovel.fornecedor = oFornecedor;

                    CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
                    oCarteiraImoveis.idCarteiraImoveis = EmcResources.cInt(drCon["idcarteiraimoveis"].ToString());
                    objImovel.carteiraImoveis = oCarteiraImoveis;

                    ContaCusto oContaCusto = new ContaCusto();
                    oContaCusto.idContaCusto = EmcResources.cInt(drCon["idcontacusto"].ToString());
                    objImovel.contaCusto = oContaCusto;                   

                    objImovel.situacao = drCon["situacao"].ToString();

                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                    objImovel.empresa = oEmpresa;

                    objImovel.codigoImovel = drCon["codigoimovel"].ToString();
                }

                drCon.Close();
                drCon.Dispose();
                drCon = null;


                return objImovel;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(Imovel oImovel, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oImovel.idImovel.ToString();

                if (flag == "A")
                {

                    Imovel oImo = new Imovel();
                    oImo = ObterPor(oImovel);

                    if (!oImo.Equals(oImovel))
                    {
                        descricao = "Imóvel id: " + oImovel.idImovel + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oImo.tipoImovel.idTipoImovel.Equals(oImovel.tipoImovel.idTipoImovel))
                        {
                            descricao += " Tipo Imóvel de " + oImo.tipoImovel.idTipoImovel + " para " + oImovel.tipoImovel.idTipoImovel;
                        }

                        if (!oImo.descricao.Equals(oImovel.descricao))
                        {
                            descricao += " Descrição de " + oImo.descricao + " para " + oImovel.descricao;
                        }
                        if (!oImo.rua.Equals(oImovel.rua))
                        {
                            descricao += " Rua de " + oImo.rua + " para " + oImovel.rua;
                        }
                        if (!oImo.numero.Equals(oImovel.numero))
                        {
                            descricao += " Número de " + oImo.numero + " para " + oImovel.numero;
                        }
                        if (!oImo.complemento.Equals(oImovel.complemento))
                        {
                            descricao += " Complemento de " + oImo.complemento + " para " + oImovel.complemento;
                        }
                        if (!oImo.bairro.Equals(oImovel.bairro))
                        {
                            descricao += " Bairro de " + oImo.bairro + " para " + oImovel.bairro;
                        }
                        if (!oImo.cidade.Equals(oImovel.cidade))
                        {
                            descricao += " Cidade de " + oImo.cidade + " para " + oImovel.cidade;
                        }
                        if (!oImo.estado.Equals(oImovel.estado))
                        {
                            descricao += " Estado de " + oImo.estado + " para " + oImovel.estado;
                        }
                        if (!oImo.nroCep.Equals(oImovel.nroCep))
                        {
                            descricao += " CEP de " + oImo.nroCep + " para " + oImovel.nroCep;
                        }
                        if (!oImo.anotacoes.Equals(oImovel.anotacoes))
                        {
                            descricao += " Anotações de " + oImo.anotacoes + " para " + oImovel.anotacoes;
                        }
                        if (!oImo.observacoes.Equals(oImovel.observacoes))
                        {
                            descricao += " Observações de " + oImo.observacoes + " para " + oImovel.observacoes;
                        }
                        if (!oImo.valorVenda.Equals(oImovel.valorVenda))
                        {
                            descricao += " Valor Venda de " + oImo.valorVenda + " para " + oImovel.valorVenda;
                        }
                        if (!oImo.valorAluguel.Equals(oImovel.valorAluguel))
                        {
                            descricao += " Valor Aluguel de " + oImo.valorAluguel + " para " + oImovel.valorAluguel;
                        }
                        if (!oImo.valorCondominio.Equals(oImovel.valorCondominio))
                        {
                            descricao += " Valor Condominio de " + oImo.valorCondominio + " para " + oImovel.valorCondominio;
                        }
                        if (!oImo.enderecoChave.Equals(oImovel.enderecoChave))
                        {
                            descricao += " Endereço Chave de " + oImo.enderecoChave + " para " + oImovel.enderecoChave;
                        }
                        if (!oImo.matriculaCri.Equals(oImovel.matriculaCri))
                        {
                            descricao += " Matricula CRI de " + oImo.matriculaCri + " para " + oImovel.matriculaCri;
                        }
                        if (!oImo.areaConstruida.Equals(oImovel.areaConstruida))
                        {
                            descricao += " Área Construída de " + oImo.areaConstruida + " para " + oImovel.areaConstruida;
                        }
                        //if (!oImo.empresa.codEmpresa.Equals(oImovel.empresa.codEmpresa))
                        //{
                        //    descricao += " Empresa de " + oImo.empresa.codEmpresa + " para " + oImovel.empresa.codEmpresa;
                        //}
                        //if (!oImo.fornecedor.idPessoa.Equals(oImovel.fornecedor.idPessoa))
                        //{
                        //    descricao += " Proprietário de " + oImo.fornecedor.idPessoa + " para " + oImovel.fornecedor.idPessoa;
                        //}
                        if (!oImo.carteiraImoveis.idCarteiraImoveis.Equals(oImovel.carteiraImoveis.idCarteiraImoveis))
                        {
                            descricao += " Carteira Imóveis de " + oImo.carteiraImoveis.idCarteiraImoveis + " para " + oImovel.carteiraImoveis.idCarteiraImoveis;
                        }
                        if (!oImo.contaCusto.idContaCusto.Equals(oImovel.contaCusto.idContaCusto))
                        {
                            descricao += " Conta Custo de " + oImo.contaCusto.idContaCusto + " para " + oImovel.contaCusto.idContaCusto;
                        }
                        if (!oImo.empresa.idEmpresa.Equals(oImovel.empresa.idEmpresa))
                        {
                            descricao += " Empresa de " + oImo.empresa.idEmpresa + " para " + oImovel.empresa.idEmpresa;
                        }
                        if (!oImo.codigoImovel.Equals(oImovel.codigoImovel))
                        {
                            descricao += " Código do Imóvel " + oImo.codigoImovel + " para " + oImovel.codigoImovel;
                        }

                    }
                }
                else if (flag == "I")
                {
                    descricao = "Imóvel : " + oImovel.idImovel +
                        " Tipo de Imóvel: " + oImovel.tipoImovel.idTipoImovel +
                        " Descrição: " + oImovel.descricao +
                        " Rua: " + oImovel.rua +
                        " Número: " + oImovel.numero +
                        " Complemento: " + oImovel.complemento +
                        " Bairro: " + oImovel.bairro +
                        " Cidade: " + oImovel.cidade +
                        " Estado: " + oImovel.estado +
                        " CEP: " + oImovel.nroCep +
                        " Anotações: " + oImovel.anotacoes +
                        " Observações: " + oImovel.observacoes +
                        " Valor Venda: " + oImovel.valorVenda +
                        " Valor Aluguel: " + oImovel.valorAluguel +
                        " Valor Condomínio: " + oImovel.valorCondominio +
                        " Endereço Chave: " + oImovel.enderecoChave +
                        " Matricula CRI: " + oImovel.matriculaCri +
                        " Área Construída: " + oImovel.areaConstruida +
                        //" Empresa: " + oImovel.empresa.codEmpresa +
                        " Proprietário: " + oImovel.fornecedor.idPessoa +
                        " Carteira Imóveis: " + oImovel.carteiraImoveis.idCarteiraImoveis +
                        " Conta Custo: " + oImovel.contaCusto.idContaCusto +
                        " Código Imóvel: " + oImovel.codigoImovel +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Imóvelo : " + oImovel.idImovel +
                        " Tipo de Imóvel: " + oImovel.tipoImovel.idTipoImovel +
                        " Descrição: " + oImovel.descricao +
                        " Rua: " + oImovel.rua +
                        " Número: " + oImovel.numero +
                        " Complemento: " + oImovel.complemento +
                        " Bairro: " + oImovel.bairro +
                        " Cidade: " + oImovel.cidade +
                        " Estado: " + oImovel.estado +
                        " CEP: " + oImovel.nroCep +
                        " Anotações: " + oImovel.anotacoes +
                        " Observações: " + oImovel.observacoes +
                        " Valor Venda: " + oImovel.valorVenda +
                        " Valor Aluguel: " + oImovel.valorAluguel +
                        " Valor Condomínio: " + oImovel.valorCondominio +
                        " Endereço Chave: " + oImovel.enderecoChave +
                        " Matricula CRI: " + oImovel.matriculaCri +
                        " Área Construída: " + oImovel.areaConstruida +
                        //" Empresa: " + oImovel.empresa.codEmpresa +
                        //" Proprietário: " + oImovel.fornecedor.idPessoa +
                        " Carteira Imóveis: " + oImovel.carteiraImoveis.idCarteiraImoveis +
                        " Conta Custo: " + oImovel.contaCusto.idContaCusto +
                        " Empresa: " + oImovel.empresa.idEmpresa +
                        " Código Imóvel: " + oImovel.codigoImovel +
                        " foi exluido por " + oOcorrencia.usuario.nome;
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
