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
using EMCObrasModel;
using EMCEstoqueModel;
using EMCEstoqueDAO;

namespace EMCObrasDAO
{
    public class Obra_LancamentoDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_LancamentoDAO(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = pOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = pOcorrencia;
            }
            codEmpresa = idEmpresa;
        }

        public Boolean Salvar(Obra_Lancamento oLancamento)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            Boolean verificaAlteracao = false;
            //Grava um novo registro de PagarDocumento
            try
            {

                verificaAlteracao = Salvar(Conexao, transacao, oLancamento);

                transacao.Commit();

                return verificaAlteracao;

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
        public Boolean Salvar(MySqlConnection Conecta, MySqlTransaction transacao, Obra_Lancamento oLancamento)
        {

            //Grava um novo registro de PagarDocumento
            try
            {

                Boolean verificaAlteracao = false;

                if (oLancamento.status == "I")
                {
                    ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                    string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                        "where a.table_name = 'obra_lancamento'" +
                                        "  and a.table_schema ='" + schemaBD.Trim() + "'";

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conecta, transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();

                    int idItem = 0;
                    while (drCon.Read())
                    {
                        idItem = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                        oLancamento.idObra_Lancamento = idItem;
                    }

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    geraOcorrencia(oLancamento, "I");

                    //Monta comando para a gravação do registro
                    String strSQL = "insert into obra_lancamento ( fornecedor_codempresa, fornecedor_idpessoa, " +
                                                                 " nrodocumento, datadocumento, dataentrada, " +
                                                                 " valordocumento, idobra_cronograma ) " +
                                                        "values ( @fornecedor_codempresa, @fornecedor_idpessoa, " +
                                                                "@nrodocumento, @datadocumento, @dataentrada, " +
                                                                "@valordocumento, @idobra_cronograma ) ";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conecta, transacao);
                    //Sqlcon.Parameters.AddWithValue("@idobra_lancamento", oLancamento.idObra_Lancamento);
                    Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", oLancamento.fornecedor.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", oLancamento.fornecedor.idPessoa);
                    Sqlcon.Parameters.AddWithValue("@nrodocumento", oLancamento.nroDocuemnto);
                    Sqlcon.Parameters.AddWithValue("@datadocumento", oLancamento.dataDocumento);
                    Sqlcon.Parameters.AddWithValue("@dataentrada", oLancamento.dataEntrada);
                    Sqlcon.Parameters.AddWithValue("@valordocumento", oLancamento.vlrDocumento);
                    Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oLancamento.obra.idObra_Cronograma);

                    //abre conexao e executa o comando
                    Sqlcon.ExecuteNonQuery();

                    Obra_LancamentoItemDAO oItemDAO = new Obra_LancamentoItemDAO(parConexao, oOcorrencia, codEmpresa);
                    oItemDAO.Salvar(Conecta, transacao, oLancamento.lstItens, oLancamento.idObra_Lancamento);

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    verificaAlteracao = true;
                }
                else if (oLancamento.status == "A")
                {
                    geraOcorrencia(oLancamento, "A");

                    //Monta comando para a gravação do registro
                    String strSQL = "update obra_lancamento set fornecedor_codempresa=@fornecedor_codempresa, " +
                                                               "fornecedor_idpessoa=@fornecedor_idpessoa, " +
                                                               "nrodocumento=@nrodocumento, datadocumento=@datadocumento, " +
                                                               "dataentrada=@dataentrada, valordocumento=@valordocumento, " +
                                                               "idobra_cronograma=@idobra_cronograma " +
                                                               " where idobra_lancamento=@idobra_lancamento";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                    Sqlcon.Parameters.AddWithValue("@idobra_lancamento", oLancamento.idObra_Lancamento);
                    Sqlcon.Parameters.AddWithValue("@fornecedor_codempresa", oLancamento.fornecedor.codEmpresa);
                    Sqlcon.Parameters.AddWithValue("@fornecedor_idpessoa", oLancamento.fornecedor.idPessoa);
                    Sqlcon.Parameters.AddWithValue("@nrodocumento", oLancamento.nroDocuemnto);
                    Sqlcon.Parameters.AddWithValue("@datadocumento", oLancamento.dataDocumento);
                    Sqlcon.Parameters.AddWithValue("@dataentrada", oLancamento.dataEntrada);
                    Sqlcon.Parameters.AddWithValue("@valordocumento", oLancamento.vlrDocumento);
                    Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oLancamento.obra.idObra_Cronograma);

                    Sqlcon.ExecuteNonQuery();

                    Obra_LancamentoItemDAO oItemDAO = new Obra_LancamentoItemDAO(parConexao, oOcorrencia, codEmpresa);
                    oItemDAO.Salvar(Conecta, transacao, oLancamento.lstItens, oLancamento.idObra_Lancamento);

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    verificaAlteracao = true;
                }
                else if (oLancamento.status == "E")
                {
                    geraOcorrencia(oLancamento, "E");
                    //Monta comando para a gravação do registro
                    String strSQL = "delete from obra_lancamento where idobra_lancamento = @idobra_lancamento";
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                    Sqlcon.Parameters.AddWithValue("@idobra_lancamentoitem", oLancamento.idObra_Lancamento);
                    Sqlcon.ExecuteNonQuery();

                    Obra_LancamentoItemDAO oItemDAO = new Obra_LancamentoItemDAO(parConexao, oOcorrencia, codEmpresa);
                    oItemDAO.Salvar(Conecta, transacao, oLancamento.lstItens, oLancamento.idObra_Lancamento);

                    OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                    oOcoDAO.Salvar(oOcorrencia, transacao);

                    verificaAlteracao = true;
                }

                

                return verificaAlteracao;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public DataTable ListaObraLancamento()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamento";
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

        public Obra_Lancamento ObterPor(Obra_Lancamento oLancamento)
        {
            bool Consulta = false;

            try
            {


                //Monta comando para a gravação do registro
                String strSQL = "select * from obra_lancamento a where a.idobra_lancamento = @idobra_lancamento";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_lancamento", oLancamento.idObra_Lancamento);
                MySqlDataReader drCon;

                drCon = Sqlcon.ExecuteReader();

                Obra_Lancamento oLacto = new Obra_Lancamento();

                while (drCon.Read())
                {
                    Consulta = true;
                    oLacto.idObra_Lancamento = EmcResources.cInt(drCon["idobra_lancamento"].ToString());
                    oLacto.dataDocumento = Convert.ToDateTime(drCon["datadocumento"].ToString());
                    oLacto.dataEntrada = Convert.ToDateTime(drCon["dataentrada"].ToString());

                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = EmcResources.cInt(drCon["fornecedor_codempresa"].ToString());
                    oFornecedor.idPessoa = EmcResources.cInt(drCon["fornecedor_idpessoa"].ToString());
                    oLacto.fornecedor = oFornecedor;

                    oLacto.nroDocuemnto = drCon["nrodocumento"].ToString();
                    oLacto.vlrDocumento = EmcResources.cCur(drCon["valordocumento"].ToString());
                    
                    oLacto.status = "";

                }


                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (Consulta)
                {

                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao, oOcorrencia, codEmpresa);
                    oLacto.fornecedor = oFornecedorDAO.ObterPor(oLacto.fornecedor);

                    Obra_LancamentoItemDAO oItensDAO = new Obra_LancamentoItemDAO(parConexao, oOcorrencia, codEmpresa);
                    oLacto.lstItens = oItensDAO.listaObraLancamentoItem(oLacto.idObra_Lancamento);

                }
                return oLacto;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(Obra_Lancamento oLacto, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                // pega a chave do documentopagar pois a ocorrencia da parcela estará exibida na tela de documentos
                oOcorrencia.chaveidentificacao = oLacto.idObra_Lancamento.ToString();

                if (flag == "A")
                {

                    Obra_Lancamento oRat = new Obra_Lancamento();
                    oRat = ObterPor(oLacto);

                    if (!oRat.Equals(oLacto))
                    {
                        descricao = " Lancamento id : " + oLacto.idObra_Lancamento +
                                    " -  foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oRat.dataDocumento.Equals(oLacto.dataDocumento))
                        {
                            descricao += " Data Documento de  " + oRat.dataDocumento +
                                         " para " + oLacto.dataDocumento;
                        }
                        if (!oRat.dataEntrada.Equals(oLacto.dataEntrada))
                        {
                            descricao += " Data Entrada de  " + oRat.dataEntrada +
                                         " para " + oLacto.dataEntrada;
                        }
                        if (!oRat.fornecedor.Equals(oLacto.fornecedor))
                        {
                            descricao += " Fornecedor de " + oRat.fornecedor.idPessoa +" - "+oRat.fornecedor.pessoa.nome
                                       + " para " + oLacto.fornecedor.idPessoa+" - "+oLacto.fornecedor.pessoa.nome;
                        }
                        if (!oRat.nroDocuemnto.Equals(oLacto.nroDocuemnto))
                        {
                            descricao += " Numero Documento de " + oRat.nroDocuemnto + " para " + oLacto.nroDocuemnto;
                        }
                        if (!oRat.obra.idObra_Cronograma.Equals(oLacto.obra.idObra_Cronograma))
                        {
                            descricao += " Obra de " + oRat.obra.descricao + " para " + oLacto.obra.descricao;
                        }
                        if (!oRat.vlrDocumento.Equals(oLacto.vlrDocumento))
                        {
                            descricao += " Valor Documento de " + oRat.vlrDocumento + " para " + oLacto.vlrDocumento;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = " Lancamento id : " + oLacto.idObra_Lancamento +
                                " - Documento nro : " + oLacto.nroDocuemnto +
                                " - Fornecedor    : " + oLacto.fornecedor.idPessoa + " - " + oLacto.fornecedor.pessoa.nome +
                                " - Data Documento: " + oLacto.dataDocumento +
                                " - Data Entrada  : " + oLacto.dataEntrada +
                                " - Obra : " + oLacto.obra.abreviacao + " - " + oLacto.obra.descricao +
                                " - Valor Documento : " + oLacto.vlrDocumento +
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Lancamento id : " + oLacto.idObra_Lancamento +
                                " - Documento nro : " + oLacto.nroDocuemnto +
                                " - Fornecedor    : " + oLacto.fornecedor.idPessoa + " - " + oLacto.fornecedor.pessoa.nome +
                                " - Data Documento: " + oLacto.dataDocumento +
                                " - Data Entrada  : " + oLacto.dataEntrada +
                                " - Obra : " + oLacto.obra.abreviacao + " - " + oLacto.obra.descricao +
                                " - Valor Documento : " + oLacto.vlrDocumento +
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
