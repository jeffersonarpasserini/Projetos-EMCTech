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
using EMCFinanceiroModel;
using EMCIntegracaoModel;
using EMCIntegracaoDAO;

namespace EMCFinanceiroDAO
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

        public void Salvar(ReceberDocumento oReceber, IntegFinanceiro oInteg)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                int idReceber = 0;

                ReceberDocumentoDAO oRecDAO = new ReceberDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                idReceber = oRecDAO.Salvar(Conexao, transacao, oReceber);
                
                /* busca dados do documento gravado */
                oReceber.idReceberDocumento = idReceber;
                oReceber = oRecDAO.ObterPor(oReceber);

                /* atualiza integracao */
                oInteg.idReceberDocumento = oReceber;
                foreach (ReceberParcela oParcela in oReceber.parcelas)
                {
                    oInteg.idReceberParcela = oParcela;
                }
                
                IntegFinanceiroDAO oIntegDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);
                oIntegDAO.Salvar(oInteg, Conexao, transacao);

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

        public void Salvar(PagarDocumento oPagar, IntegFinanceiro oInteg)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //Grava um novo registro de Conta Bancaria
            try
            {
                int idPagar = 0;

                PagarDocumentoDAO oPagDAO = new PagarDocumentoDAO(parConexao, oOcorrencia, codEmpresa);
                idPagar = oPagDAO.Salvar(Conexao, transacao, oPagar);

                /* busca dados do documento gravado */
                oPagar.idPagarDocumento = idPagar;
                oPagar = oPagDAO.ObterPor(oPagar);

                /* atualiza integracao */
                oInteg.idPagarDocumento = oPagar;
                foreach (PagarParcela oParcela in oPagar.parcelas)
                {
                    oInteg.idPagarParcela = oParcela;
                }

                IntegFinanceiroDAO oIntegDAO = new IntegFinanceiroDAO(parConexao, oOcorrencia, codEmpresa);
                oIntegDAO.Salvar(oInteg, Conexao, transacao);

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
