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
    public class LocacaoProventosDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public LocacaoProventosDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void Salvar(LocacaoProventos objLocacaoProventos)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");

                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'locacaoproventos'" +
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objLocacaoProventos.idLocacaoProventos = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                geraOcorrencia(objLocacaoProventos, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into LocacaoProventos (descricao, tipoprovento, integradimob, idaplicacao, basetaxaadm, basetaxaadmcondominio, referencia, valor_referencia, baseirpf, rotinacalculo)" +
                                                     " values (@descricao, @tipoprovento, @integradimob, @idaplicacao, @basetaxaadm, @basetaxaadmcondominio, @referencia, @valor_referencia, @baseirpf, @rotinacalculo)";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@descricao", objLocacaoProventos.Descricao);
                Sqlcon.Parameters.AddWithValue("@tipoprovento", objLocacaoProventos.TipoProvento);
                Sqlcon.Parameters.AddWithValue("@integradimob", objLocacaoProventos.IntegraDimob);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", objLocacaoProventos.aplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@basetaxaadm", objLocacaoProventos.BaseTaxaAdm);
                Sqlcon.Parameters.AddWithValue("@basetaxaadmcondominio", objLocacaoProventos.BaseTaxaAdmCondominio);
                Sqlcon.Parameters.AddWithValue("@referencia", objLocacaoProventos.Referencia);
                Sqlcon.Parameters.AddWithValue("@valor_referencia", objLocacaoProventos.ValorReferencia);
                Sqlcon.Parameters.AddWithValue("@baseirpf", objLocacaoProventos.BaseIrpf);
                Sqlcon.Parameters.AddWithValue("@rotinacalculo", objLocacaoProventos.RotinaCalculo);

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

        public void Atualizar(LocacaoProventos objLocacaoProventos)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objLocacaoProventos, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update locacaoproventos set descricao = @descricao, tipoprovento = @tipoprovento, integradimob = @integradimob, idaplicacao = @idaplicacao, " +
                    " basetaxaadm = @basetaxaadm, basetaxaadmcondominio = @basetaxaadmcondominio, referencia = @referencia, valor_referencia = @valor_referencia, " +
                    " baseirpf = @baseirpf, rotinacalculo = @rotinacalculo where idlocacaoproventos = @idlocacaoproventos";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idlocacaoproventos", objLocacaoProventos.idLocacaoProventos);
                Sqlcon.Parameters.AddWithValue("@descricao", objLocacaoProventos.Descricao);
                Sqlcon.Parameters.AddWithValue("@tipoprovento", objLocacaoProventos.TipoProvento);
                Sqlcon.Parameters.AddWithValue("@integradimob", objLocacaoProventos.IntegraDimob);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", objLocacaoProventos.aplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@basetaxaadm", objLocacaoProventos.BaseTaxaAdm);
                Sqlcon.Parameters.AddWithValue("@basetaxaadmcondominio", objLocacaoProventos.BaseTaxaAdmCondominio);
                Sqlcon.Parameters.AddWithValue("@referencia", objLocacaoProventos.Referencia);
                Sqlcon.Parameters.AddWithValue("@valor_referencia", objLocacaoProventos.ValorReferencia);
                Sqlcon.Parameters.AddWithValue("@baseirpf", objLocacaoProventos.BaseIrpf);
                Sqlcon.Parameters.AddWithValue("@rotinacalculo", objLocacaoProventos.RotinaCalculo);

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

        public void Excluir(LocacaoProventos objLocacaoProventos)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objLocacaoProventos, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from locacaoproventos where idlocacaoproventos = @idlocacaoproventos";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idlocacaoproventos", objLocacaoProventos.idLocacaoProventos);

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

        public DataTable pesquisaLocacaoProventos(int empMaster, int idLocacaoProventos, string nome)
        {
            try
            {
                int colocaWhere = 0;

                //Monta comando para a gravação do registro
                String strSQL = "select b.* from locacaoproventos b ";

                if (idLocacaoProventos > 0)
                {
                    if (colocaWhere == 0)
                    {
                        strSQL += " where ";
                        colocaWhere++;
                    }

                    strSQL += " b.idlocacaoproventos = @idlocacaoproventos ";
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

                    strSQL += " b.descricao like @nome ";
                }


                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idlocacaoproventos", idLocacaoProventos);
                Sqlcon.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");



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

        public DataTable ListaLocacaoProventos()
        {
            MySqlDataAdapter daCon = new MySqlDataAdapter();
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from LocacaoProventos order by Descricao";
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

        public LocacaoProventos ObterPor(LocacaoProventos oLocacaoProventos)
        {
            MySqlDataReader drCon;
            LocacaoProventos objRetorno = new LocacaoProventos();

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oLocacaoProventos.idLocacaoProventos > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from locacaoproventos Where idlocacaoproventos = " + oLocacaoProventos.idLocacaoProventos + " ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();

                    while (drCon.Read())
                    {
                        objRetorno.idLocacaoProventos = EmcResources.cInt(drCon["idlocacaoproventos"].ToString());
                        objRetorno.Descricao = drCon["descricao"].ToString();
                        objRetorno.TipoProvento = drCon["tipoprovento"].ToString();
                        objRetorno.IntegraDimob = drCon["integradimob"].ToString();

                        Aplicacao oAplicacao = new Aplicacao();
                        oAplicacao.idAplicacao = EmcResources.cInt(drCon["idaplicacao"].ToString());
                        oAplicacao.descricao = drCon["descricao"].ToString();
                        objRetorno.aplicacao = oAplicacao;

                        objRetorno.BaseTaxaAdm = drCon["basetaxaadm"].ToString();
                        objRetorno.BaseTaxaAdmCondominio = drCon["basetaxaadmcondominio"].ToString();
                        objRetorno.Referencia = EmcResources.cDouble(drCon["referencia"].ToString());
                        objRetorno.ValorReferencia = drCon["valor_referencia"].ToString();
                        objRetorno.BaseIrpf = drCon["baseirpf"].ToString();
                        objRetorno.RotinaCalculo = EmcResources.cInt(drCon["rotinacalculo"].ToString());
                    }

                    drCon.Close();
                    drCon.Dispose();

                }
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

        private void geraOcorrencia(LocacaoProventos oProvento, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oProvento.idLocacaoProventos.ToString();

                if (flag == "A")
                {

                    LocacaoProventos oLocProv = new LocacaoProventos();
                    oLocProv = ObterPor(oProvento);

                    if (!oLocProv.Equals(oProvento))
                    {
                        descricao = "Locação Provento id: " + oProvento.idLocacaoProventos + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oLocProv.Descricao.Equals(oProvento.Descricao))
                        {
                            descricao += " Descrição de " + oLocProv.Descricao + " para " + oProvento.Descricao;
                        }
                        if (!oLocProv.TipoProvento.Equals(oProvento.TipoProvento))
                        {
                            descricao += " Tipo Provento de " + oLocProv.TipoProvento + " para " + oProvento.TipoProvento;
                        }
                        if (!oLocProv.IntegraDimob.Equals(oProvento.IntegraDimob))
                        {
                            descricao += " IntegraDimob de " + oLocProv.IntegraDimob + " para " + oProvento.IntegraDimob;
                        }
                        if (!oLocProv.BaseTaxaAdm.Equals(oProvento.BaseTaxaAdm))
                        {
                            descricao += " Base Taxa Adm de " + oLocProv.BaseTaxaAdm + " para " + oProvento.BaseTaxaAdm;
                        }
                        if (!oLocProv.BaseTaxaAdmCondominio.Equals(oProvento.BaseTaxaAdmCondominio))
                        {
                            descricao += " Base Taxa Adm Condomínio de " + oLocProv.BaseTaxaAdmCondominio + " para " + oProvento.BaseTaxaAdmCondominio;
                        }
                        if (!oLocProv.Referencia.Equals(oProvento.Referencia))
                        {
                            descricao += " Referência de " + oLocProv.Referencia + " para " + oProvento.Referencia;
                        }
                        if (!oLocProv.ValorReferencia.Equals(oProvento.ValorReferencia))
                        {
                            descricao += " Valor de Referência de " + oLocProv.ValorReferencia + " para " + oProvento.ValorReferencia;
                        }
                        if (!oLocProv.BaseIrpf.Equals(oProvento.BaseIrpf))
                        {
                            descricao += " Base IRPF de " + oLocProv.BaseIrpf + " para " + oProvento.BaseIrpf;
                        }
                        if (!oLocProv.RotinaCalculo.Equals(oProvento.RotinaCalculo))
                        {
                            descricao += " Rotina de Cálculo de " + oLocProv.RotinaCalculo + " para " + oProvento.RotinaCalculo;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Locação Provento : " + oProvento.idLocacaoProventos + 
                        " Descrição: " + oProvento.Descricao +
                        " Tipo de Provento: " + oProvento.TipoProvento +
                        " IntegraDimob: " + oProvento.IntegraDimob +
                        " Base Taxa Adm: " + oProvento.BaseTaxaAdm +
                        " Base Taxa Adm Condominio: " + oProvento.BaseTaxaAdmCondominio +
                        " Referência: " + oProvento.Referencia +
                        " Valor de Referência: " + oProvento.ValorReferencia +
                        " Base IRPF: " + oProvento.BaseIrpf +
                        " Rotina de Cálculo: " + oProvento.RotinaCalculo +
                        " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Locação Provento : " + oProvento.idLocacaoProventos + 
                        " Descrição: " + oProvento.Descricao +
                        " Tipo de Provento: " + oProvento.TipoProvento +
                        " IntegraDimob: " + oProvento.IntegraDimob +
                        " Base Taxa Adm: " + oProvento.BaseTaxaAdm +
                        " Base Taxa Adm Condominio: " + oProvento.BaseTaxaAdmCondominio +
                        " Referência: " + oProvento.Referencia +
                        " Valor de Referência: " + oProvento.ValorReferencia +
                        " Base IRPF: " + oProvento.BaseIrpf +
                        " Rotina de Cálculo: " + oProvento.RotinaCalculo +
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
