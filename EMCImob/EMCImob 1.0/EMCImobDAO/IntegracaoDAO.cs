using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCImobModel;
using EMCLibrary;
using MySql.Data.MySqlClient;
using EMCSecurityModel;
using EMCSecurityDAO;
using EMCCadastroDAO;
using EMCCadastroModel;
using EMCIntegracaoModel;
using EMCIntegracaoDAO;

namespace EMCImobDAO
{
    public class IntegracaoDAO
    {
        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public IntegracaoDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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

        public void integraLocacaoReceber(List<LocacaoReceber> lstReceber, int idUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de ReceberParcela
            try
            {
                
                foreach(LocacaoReceber oReceber in lstReceber)
                {
                    IntegFinanceiroDAO oIntegDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);
                    IntegFinanceiro oInteg = new IntegFinanceiro();

                    /*Monta objeto de integração */
                    oInteg.dataFinanceiro = null;
                    oInteg.dataOrigem = DateTime.Now;
                    oInteg.idEmpresa = codEmpresa;
                    oInteg.idIntegFinanceiro = 0;
                    //oInteg.idPagarDocumento = null;
                    //oInteg.idPagarParcela = null;
                    //oInteg.idReceberDocumento = null;
                    //oInteg.idReceberParcela = null;
                    oInteg.idUsuarioFinanceiro = 0;
                    oInteg.idUsuarioOrigem = idUsuario;
                    oInteg.imob_BaixaCaptacao = null;
                    oInteg.imob_DespesaImovel = null;
                    oInteg.imob_Iptu = null;
                    oInteg.imob_LocacaoPagar = null;
                    oInteg.imob_LocacaoReceber = oReceber;
                    oInteg.lstBaixaPagar = null;
                    oInteg.lstBaixaReceber = null;
                    oInteg.sistemaOrigem = "EMCIMOB";
                    /* Conta Pagar = P ou Contas a Receber = R */
                    oInteg.tipoIntegracao = "R";
                    /* Parcela = P ou Documento = D */
                    oInteg.nivelIntegracao = "P";
                    /* Pendente = P ou Quitado = Q*/
                    oInteg.statusBaixa = "A";
                    /* Gerado = G ou Processado Financeiro = P */
                    oInteg.statusGeracao = "G";
                    /* Inclusao integracao = I ou Proc.Financeiro = P ou Estorno Financ. = E ou Cancel.Integ. = C */
                    oInteg.statusOperacao = "I";

                    oIntegDAO.Salvar(oInteg, Conexao, transacao);

                    LocacaoReceberDAO oReceberDAO = new LocacaoReceberDAO(parConexao, oOcorrencia, codEmpresa);
                    oReceberDAO.Integracao(oReceber, Conexao, transacao, "I", DateTime.Now);

                    LocacaoCCReceberDAO oCCReceberDAO = new LocacaoCCReceberDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCReceberDAO.integracao(oReceber.idLocacaoReceber, "I", Conexao, transacao);


                }
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

        public void integraLocacaoPagar(List<LocacaoPagar> lstPagar, int idUsuario)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de ReceberParcela
            try
            {

                foreach (LocacaoPagar oPagar in lstPagar)
                {
                    IntegFinanceiroDAO oIntegDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);
                    IntegFinanceiro oInteg = new IntegFinanceiro();

                    /*Monta objeto de integração */
                    oInteg.dataFinanceiro = null;
                    oInteg.dataOrigem = DateTime.Now;
                    oInteg.idEmpresa = codEmpresa;
                    oInteg.idIntegFinanceiro = 0;
                    //oInteg.idPagarDocumento = null;
                    //oInteg.idPagarParcela = null;
                    //oInteg.idReceberDocumento = null;
                    //oInteg.idReceberParcela = null;
                    oInteg.idUsuarioFinanceiro = 0;
                    oInteg.idUsuarioOrigem = idUsuario;
                    oInteg.imob_BaixaCaptacao = null;
                    oInteg.imob_DespesaImovel = null;
                    oInteg.imob_Iptu = null;
                    oInteg.imob_LocacaoPagar = oPagar;
                    oInteg.imob_LocacaoReceber = null;
                    oInteg.lstBaixaPagar = null;
                    oInteg.lstBaixaReceber = null;
                    oInteg.sistemaOrigem = "EMCIMOB";
                    /* Conta Pagar = P ou Contas a Receber = R */
                    oInteg.tipoIntegracao = "P";
                    /* Parcela = P ou Documento = D */
                    oInteg.nivelIntegracao = "P";
                    /* Pendente = P ou Quitado = Q*/
                    oInteg.statusBaixa = "A";
                    /* Gerado = G ou Processado Financeiro = P */
                    oInteg.statusGeracao = "G";
                    /* Inclusao integracao = I ou Proc.Financeiro = P ou Estorno Financ. = E ou Cancel.Integ. = C */
                    oInteg.statusOperacao = "I";

                    oIntegDAO.Salvar(oInteg, Conexao, transacao);

                    LocacaoPagarDAO oPagarDAO = new LocacaoPagarDAO(parConexao, oOcorrencia, codEmpresa);
                    oPagarDAO.Integracao(oPagar, Conexao, transacao, "I", DateTime.Now);

                    LocacaoCCPagarDAO oCCPagarDAO = new LocacaoCCPagarDAO(parConexao, oOcorrencia, codEmpresa);
                    oCCPagarDAO.integracao(oPagar.idLocacaoPagar, "I", Conexao, transacao);


                }
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
    }
}
