using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCObrasModel;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCEstoqueModel;
using EMCEstoqueDAO;


namespace EMCObrasDAO
{
    public class ObraDAO
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ObraDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void salvar(Obra objObra)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //Grava um novo registro
            try
            {
                ParametroDAO oParamDAO = new ParametroDAO(parConexao);
                string schemaBD = oParamDAO.retParametro(codEmpresa, "EMCSECURITY", "BANCODADOS", "SCHEMA");
                //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                String strSQL2 = "select a.AUTO_INCREMENT from information_schema.tables a " +
                                    "where a.table_name = 'obra_cronograma'"+
                                    "  and a.table_schema ='" + schemaBD.Trim() + "'";

                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, transacao);

                MySqlDataReader drCon;
                drCon = Sqlcon2.ExecuteReader();

                while (drCon.Read())
                {
                    objObra.idObra_Cronograma = Convert.ToInt32(drCon["AUTO_INCREMENT"].ToString());
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;


                geraOcorrencia(objObra, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into obra_cronograma ( abreviacao, empresa_idempresa, descricao, " + 
                                                            " dtainicio, dtafinal, responsavel_idusuario, " + 
                                                            " dtacronograma, dtaaprovacao, aprovador_idusuario, " + 
                                                            " idcontacusto, pessoa_codempresa, pessoa_idpessoa, " + 
                                                            " situacao, idaplicacao, nrocei, obrapropria, " +
                                                            " idestq_almoxarifado, almoxarifado_idempresa, idobra_tipocontrato ) " +
                                                            " values ( @abreviacao, @empresa_idempresa, @descricao, " +
                                                            " @dtainicio, @dtafinal, @responsavel_idusuario, " +
                                                            " @dtacronograma, @dtaaprovacao, @aprovador_idusuario, " +
                                                            " @idcontacusto, @pessoa_codempresa, @pessoa_idpessoa, " + 
                                                            " @situacao, @idaplicacao, @nrocei, @obrapropria, " +
                                                            " @idestq_almoxarifado, @almoxarifado_idempresa, @idobra_tipocontrato ) ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@abreviacao", objObra.abreviacao);
                Sqlcon.Parameters.AddWithValue("@empresa_idempresa", objObra.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra.descricao );
                Sqlcon.Parameters.AddWithValue("@dtainicio", objObra.dtaInicio );
                Sqlcon.Parameters.AddWithValue("@dtafinal", objObra.dtaFinal );
                Sqlcon.Parameters.AddWithValue("@responsavel_idusuario", objObra.responsavel_idUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@dtacronograma", objObra.dtaCronograma );
                Sqlcon.Parameters.AddWithValue("@dtaaprovacao", objObra.dtaAprovacao );
                Sqlcon.Parameters.AddWithValue("@aprovador_idusuario", null );
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objObra.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@pessoa_codempresa", objObra.engenheiro.codEmpresa );
                Sqlcon.Parameters.AddWithValue("@pessoa_idpessoa", objObra.engenheiro.idPessoa );
                Sqlcon.Parameters.AddWithValue("@situacao", objObra.situacao);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", objObra.aplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@nrocei", objObra.nroCEI);
                Sqlcon.Parameters.AddWithValue("@obrapropria", objObra.obraPropria);
                if (objObra.almoxarifado.idestq_almoxarifado > 0)
                {
                    Sqlcon.Parameters.AddWithValue("@idestq_almoxarifado", objObra.almoxarifado.idestq_almoxarifado);
                    Sqlcon.Parameters.AddWithValue("@almoxarifado_idempresa", objObra.almoxarifado.Empresa.idEmpresa);
                }
                else
                {
                    Sqlcon.Parameters.AddWithValue("@idestq_almoxarifado", null);
                    Sqlcon.Parameters.AddWithValue("@almoxarifado_idempresa", null);
                }
                Sqlcon.Parameters.AddWithValue("@idobra_tipocontrato", objObra.tipoContrato.idObra_TipoContrato);
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
        }

        public void atualizar(Obra objObra)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update obra_cronograma  set abreviacao=@abreviacao, empresa_idempresa=@empresa_idempresa, descricao=@descricao, " +
                                                            " dtainicio=@dtainicio, dtafinal=@dtafinal, responsavel_idusuario=@responsavel_idusuario, " +
                                                            " dtacronograma=@dtacronograma, dtaaprovacao=@dtaaprovacao, aprovador_idusuario=@aprovador_idusuario, " +
                                                            " idcontacusto=@idcontacusto, pessoa_codempresa=@pessoa_codempresa, pessoa_idpessoa=@pessoa_idpessoa, " +
                                                            " idaplicacao=@idaplicacao, nrocei=@nrocei, obrapropria=@obrapropria, " +
                                                            " idestq_almoxarifado=@idestq_almoxarifado, almoxarifado_idempresa=@almoxarifado_idempresa, " +
                                                            " idobra_tipocontrato=@idobra_tipocontrato  " +
                                                            " Where idobra_cronograma=@idobra_cronograma ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", objObra.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@abreviacao", objObra.abreviacao);
                Sqlcon.Parameters.AddWithValue("@empresa_idempresa", objObra.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@descricao", objObra.descricao);
                Sqlcon.Parameters.AddWithValue("@dtainicio", objObra.dtaInicio);
                Sqlcon.Parameters.AddWithValue("@dtafinal", objObra.dtaFinal);
                Sqlcon.Parameters.AddWithValue("@responsavel_idusuario", objObra.responsavel_idUsuario.idUsuario);
                Sqlcon.Parameters.AddWithValue("@dtacronograma", objObra.dtaCronograma);
                Sqlcon.Parameters.AddWithValue("@dtaaprovacao", objObra.dtaAprovacao);
                Sqlcon.Parameters.AddWithValue("@aprovador_idusuario", null);
                Sqlcon.Parameters.AddWithValue("@idcontacusto", objObra.contaCusto.idContaCusto);
                Sqlcon.Parameters.AddWithValue("@pessoa_codempresa", objObra.engenheiro.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@pessoa_idpessoa", objObra.engenheiro.idPessoa);
                Sqlcon.Parameters.AddWithValue("@idaplicacao", objObra.aplicacao.idAplicacao);
                Sqlcon.Parameters.AddWithValue("@nrocei", objObra.nroCEI);
                Sqlcon.Parameters.AddWithValue("@obrapropria", objObra.obraPropria);
                if (objObra.almoxarifado.idestq_almoxarifado > 0)
                {
                    Sqlcon.Parameters.AddWithValue("@idestq_almoxarifado", objObra.almoxarifado.idestq_almoxarifado);
                    Sqlcon.Parameters.AddWithValue("@almoxarifado_idempresa", objObra.almoxarifado.Empresa.idEmpresa);
                }
                else
                {
                    Sqlcon.Parameters.AddWithValue("@idestq_almoxarifado", null);
                    Sqlcon.Parameters.AddWithValue("@almoxarifado_idempresa", null);
                }
                Sqlcon.Parameters.AddWithValue("@idobra_tipocontrato", objObra.tipoContrato.idObra_TipoContrato);

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

        }

        public void excluir(Obra objObra)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro
            try
            {
                geraOcorrencia(objObra, "E");
                //Monta comando para a gravação do registro
                String strSQL = "delete from obra_cronograma where idobra_cronograma = @idobra_cronograma";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", objObra.idObra_Cronograma);

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

        }

        public void alteraSituacaoObra(Obra objObra)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objObra, "A");
                //Monta comando para a gravação do registro
                String strSQL = "update obra_cronograma  set situacao=@situacao, aprovador_idusuario=@aprovador " +
                                                            " Where idobra_cronograma=@idobra_cronograma ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", objObra.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@situacao", objObra.situacao);
                Sqlcon.Parameters.AddWithValue("@aprovador", objObra.aprovador_idUsuario.idUsuario);

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

        public DataTable listaObra()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select idobra_cronograma, abreviacao, descricao, dtainicio, dtafinal, situacao " + 
                                "from obra_cronograma " + 
                                "where empresa_idempresa="+codEmpresa.ToString()+" "+
                                "order by abreviacao";
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

        public Obra ObterPor(Obra oObra)
        {
            MySqlDataReader drCon;
            Boolean bControle = false;
            try
            {
                string strSQL = "";
                if (oObra.idObra_Cronograma > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from obra_cronograma Where idobra_cronograma=@idobra_cronograma"+
                             " and empresa_idempresa=" + codEmpresa.ToString();
                }
                else
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from obra_cronograma Where abreviacao=@abreviacao " +
                             " and empresa_idempresa="+codEmpresa.ToString();
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idobra_cronograma", oObra.idObra_Cronograma);
                Sqlcon.Parameters.AddWithValue("@abreviacao", oObra.abreviacao);

                drCon = Sqlcon.ExecuteReader();

                Obra objObra = new Obra();
                while (drCon.Read())
                {
                    bControle = true;

                    objObra.idObra_Cronograma = EmcResources.cInt(drCon["idobra_cronograma"].ToString());
                    objObra.abreviacao = drCon["abreviacao"].ToString();

                    Usuario oAprovador = new Usuario();
                    oAprovador.idUsuario = EmcResources.cInt(drCon["aprovador_idusuario"].ToString());
                    objObra.aprovador_idUsuario = oAprovador;

                    objObra.codEmpresa = EmcResources.cInt(drCon["empresa_idempresa"].ToString());

                    ContaCusto oCusto = new ContaCusto();
                    oCusto.idContaCusto = EmcResources.cInt(drCon["idcontacusto"].ToString());
                    objObra.contaCusto = oCusto;

                    Aplicacao oAplicacao = new Aplicacao();
                    oAplicacao.idAplicacao = EmcResources.cInt(drCon["idaplicacao"].ToString());
                    objObra.aplicacao = oAplicacao;

                    objObra.descricao = drCon["descricao"].ToString();
                    objObra.dtaAprovacao = Convert.ToDateTime(drCon["dtaaprovacao"].ToString());
                    objObra.dtaCronograma = Convert.ToDateTime(drCon["dtacronograma"].ToString());
                    objObra.dtaFinal = Convert.ToDateTime(drCon["dtafinal"].ToString());
                    objObra.dtaInicio = Convert.ToDateTime(drCon["dtainicio"].ToString());

                    Pessoa oPessoa = new Pessoa();
                    oPessoa.codEmpresa = EmcResources.cInt(drCon["pessoa_codempresa"].ToString());
                    oPessoa.idPessoa = EmcResources.cInt(drCon["pessoa_idpessoa"].ToString());
                    objObra.engenheiro = oPessoa;

                    Usuario oResponsavel = new Usuario();
                    oResponsavel.idUsuario= EmcResources.cInt(drCon["responsavel_idusuario"].ToString());   
                    objObra.responsavel_idUsuario = oResponsavel;

                    objObra.nroCEI = drCon["nrocei"].ToString();
                    objObra.obraPropria = drCon["obrapropria"].ToString();

                    Obra_TipoContrato oTpCtr = new Obra_TipoContrato();
                    oTpCtr.idObra_TipoContrato = EmcResources.cInt(drCon["idobra_tipocontrato"].ToString());
                    objObra.tipoContrato = oTpCtr;

                    Estq_Almoxarifado oAlmoxarifado = new Estq_Almoxarifado();
                    oAlmoxarifado.idestq_almoxarifado = EmcResources.cInt(drCon["idestq_almoxarifado"].ToString());
                    objObra.almoxarifado = oAlmoxarifado;

                    objObra.situacao = drCon["situacao"].ToString();
                }
                    
                drCon.Close();
                drCon.Dispose();
                drCon = null;

                if (bControle)
                {
                    ContaCustoDAO oCtaCustoDAO = new ContaCustoDAO(parConexao, oOcorrencia, codEmpresa);
                    objObra.contaCusto = oCtaCustoDAO.ObterPor(objObra.contaCusto);

                    AplicacaoDAO oAplDAO = new AplicacaoDAO(parConexao, oOcorrencia, codEmpresa);
                    objObra.aplicacao = oAplDAO.ObterPor(objObra.aplicacao);

                    PessoaDAO oPessoaDAO = new PessoaDAO(parConexao, oOcorrencia, codEmpresa);
                    objObra.engenheiro = oPessoaDAO.ObterPor(objObra.engenheiro);

                    UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                    objObra.responsavel_idUsuario = oUsrDAO.ObterPor(objObra.responsavel_idUsuario);
                    objObra.aprovador_idUsuario = oUsrDAO.ObterPor(objObra.aprovador_idUsuario);

                    Estq_AlmoxarifadoDAO oAlmoxarifadoDAO = new Estq_AlmoxarifadoDAO(parConexao,oOcorrencia,codEmpresa);
                    objObra.almoxarifado = oAlmoxarifadoDAO.ObterPor(objObra.almoxarifado);

                    Obra_TipoContratoDAO oTpContratoDAO = new Obra_TipoContratoDAO(parConexao,oOcorrencia,codEmpresa);
                    objObra.tipoContrato = oTpContratoDAO.ObterPor(objObra.tipoContrato);

                }

                return objObra;
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

        private void geraOcorrencia(Obra oObra, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oObra.idObra_Cronograma.ToString();

                //se ocorrência de alteração, passa campo a campo
                if (flag == "A")
                {

                    Obra oObrabk = new Obra();
                    oObrabk = ObterPor(oObra);

                    if (!oObrabk.Equals(oObra))
                    {
                        descricao = "Etapa da Obra id: " + oObra.idObra_Cronograma + 
                                   " Abreviatura : " + oObra.abreviacao +
                                   " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oObrabk.descricao.Equals(oObra.descricao))
                        {
                            descricao += " Descricao de " + oObrabk.descricao + " para " + oObra.descricao;
                        }
                        if (!oObrabk.nroCEI.Equals(oObra.nroCEI))
                        {
                            descricao += " CEI de " + oObrabk.nroCEI + " para " + oObra.nroCEI;
                        }
                        if (!oObrabk.obraPropria.Equals(oObra.obraPropria))
                        {
                            descricao += " Obra Propria de " + oObrabk.obraPropria + " para " + oObra.obraPropria;
                        }
                        if (!oObrabk.dtaInicio.Equals(oObra.dtaInicio))
                        {
                            descricao += " Data Inicio de " + oObrabk.dtaInicio + " para " + oObra.dtaInicio;
                        }
                        if (!oObrabk.dtaFinal.Equals(oObra.dtaFinal))
                        {
                            descricao += " Data Final de " + oObrabk.dtaFinal + " para " + oObra.dtaFinal;
                        }
                        if (!oObrabk.dtaCronograma.Equals(oObra.dtaCronograma))
                        {
                            descricao += " Data Cronograma de " + oObrabk.dtaCronograma + " para " + oObra.dtaCronograma;
                        }
                        if (!oObrabk.dtaAprovacao.Equals(oObra.dtaAprovacao))
                        {
                            descricao += " Data Aprovação de " + oObrabk.dtaAprovacao + " para " + oObra.dtaAprovacao;
                        }
                        if (!oObrabk.responsavel_idUsuario.Equals(oObra.responsavel_idUsuario))
                        {
                            descricao += " Usuario Cronograma de " + oObrabk.responsavel_idUsuario + " para " + oObra.responsavel_idUsuario;
                        }
                        if (!oObrabk.aprovador_idUsuario.Equals(oObra.aprovador_idUsuario))
                        {
                            descricao += " Usuario Aprovador de " + oObrabk.aprovador_idUsuario + " para " + oObra.aprovador_idUsuario;
                        }
                        if (!oObrabk.contaCusto.idContaCusto.Equals(oObra.contaCusto.idContaCusto))
                        {
                            descricao += " Conta Custo de " + oObrabk.contaCusto.codigoConta + " - " + oObrabk.contaCusto.descricao + " para " + oObra.contaCusto.codigoConta + " - " + oObra.contaCusto.descricao;
                        }
                        if (!oObrabk.engenheiro.idPessoa.Equals(oObra.engenheiro.idPessoa))
                        {
                            descricao += " Engenheiro de " + oObrabk.engenheiro.idPessoa + " - " + oObrabk.engenheiro.nome + " para " + oObra.engenheiro.idPessoa + " - " + oObra.engenheiro.nome;
                        }
                        if (!oObrabk.tipoContrato.idObra_TipoContrato.Equals(oObra.tipoContrato.idObra_TipoContrato))
                        {
                            descricao += " Contrato de " + oObrabk.tipoContrato.idObra_TipoContrato + " - " + oObrabk.tipoContrato.descricao + " para " 
                                                         + oObra.tipoContrato.idObra_TipoContrato + " - " + oObra.tipoContrato.descricao;
                        }
                        if (!oObrabk.almoxarifado.idestq_almoxarifado.Equals(oObra.almoxarifado.idestq_almoxarifado))
                        {
                            descricao += " Almoxarifado de " + oObrabk.almoxarifado.idestq_almoxarifado + " - " + oObrabk.almoxarifado.descricao + " para "
                                                         + oObra.almoxarifado.idestq_almoxarifado + " - " + oObra.almoxarifado.descricao;
                        }
                    }
                }
                //se ocorrência de Inclusão
                else if (flag == "I")
                {
                    descricao = "Etapa da Obra : " + oObra.idObra_Cronograma + " - " + oObra.abreviacao + " - " + oObra.descricao + 
                        " Empresa : " + oObra.codEmpresa +
                        " Data Inicio : " + oObra.dtaInicio.ToShortDateString() +
                        " Data Final : " + oObra.dtaFinal.ToShortDateString() +
                        " Usuario Responsavel : " + oObra.responsavel_idUsuario +
                        " Data Cronograma : " + oObra.dtaCronograma.ToShortDateString() +
                        " Aprovador : " + oObra.aprovador_idUsuario +
                        " Data Aprovação : " + oObra.dtaAprovacao.ToShortDateString() +
                        " Conta Custo : " + oObra.contaCusto.codigoConta + " - " + oObra.contaCusto.descricao +
                        " Engenheiro : " + oObra.engenheiro.codEmpresa + " - " + oObra.engenheiro.idPessoa + " - " + oObra.engenheiro.nome +
                        " Obra Propria : " + oObra.obraPropria + " CEI : " + oObra.nroCEI +
                        " Contrato de " + oObra.tipoContrato.idObra_TipoContrato + " - " + oObra.tipoContrato.descricao +
                        " Almoxarifado de " + oObra.almoxarifado.idestq_almoxarifado + " - " + oObra.almoxarifado.descricao +
                        " foi incluída por " + oOcorrencia.usuario.nome;
                }
                //se ocorrência de Exclusão
                else if (flag == "E")
                {
                    descricao = "Etapa da Obra : " + oObra.idObra_Cronograma + " - " + oObra.abreviacao + " - " + oObra.descricao +
                    " Empresa : " + oObra.codEmpresa +
                    " Data Inicio : " + oObra.dtaInicio.ToShortDateString() +
                    " Data Final : " + oObra.dtaFinal.ToShortDateString() +
                    " Usuario Responsavel : " + oObra.responsavel_idUsuario +
                    " Data Cronograma : " + oObra.dtaCronograma.ToShortDateString() +
                    " Aprovador : " + oObra.aprovador_idUsuario +
                    " Data Aprovação : " + oObra.dtaAprovacao.ToShortDateString() +
                    " Conta Custo : " + oObra.contaCusto.codigoConta + " - " + oObra.contaCusto.descricao +
                    " Engenheiro : " + oObra.engenheiro.codEmpresa + " - " + oObra.engenheiro.idPessoa + " - " + oObra.engenheiro.nome +
                    " Obra Propria : " + oObra.obraPropria + " CEI : " + oObra.nroCEI +
                    " Contrato de " + oObra.tipoContrato.idObra_TipoContrato + " - " + oObra.tipoContrato.descricao +
                    " Almoxarifado de " + oObra.almoxarifado.idestq_almoxarifado + " - " + oObra.almoxarifado.descricao +
                    " foi excluído por " + oOcorrencia.usuario.nome;
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
