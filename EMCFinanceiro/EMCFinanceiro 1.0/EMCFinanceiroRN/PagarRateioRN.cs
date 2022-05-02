using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;
using EMCSecurityModel;

namespace EMCFinanceiroRN
{
    public class PagarRateioRN
    {
        PagarRateioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;
    

        public PagarRateioRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Métodos Publicos da Classe

        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PagarRateioDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string DataReport4(DateTime dataInicial, DateTime dataFinal, int idTipoDocumento)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, pr.tipolancamento, pr.nrodocumento,cc.descricao,");
            strSQL.Append(" pr.datavencimento, td.descricao as tipodocumento, pr.nroparcela,");
            strSQL.Append(" v_fornecedor.nome as fornecedor, pr.documentobaixa, pr.databaixa,");
            strSQL.Append(" pr.valorbaixa, pr.valorjuros, pr.valordesconto, pr.historicoBaixa, pd.valordocumento, pd.nroparcelas, pp.valorparcela");
            strSQL.Append(" from pagarrateio pr, tipodocumento td, v_fornecedor, contacusto cc, pagardocumento pd, pagarparcelas pp");
            strSQL.Append(" where pr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pr.fornecedor_codempresa = v_fornecedor.codempresa and pr.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and pr.idtipodocumento = '" + idTipoDocumento + "'");
            strSQL.Append(" and pr.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and pr.idpagarparcela = pp.idpagarparcelas");
            strSQL.Append(" and pr.situacaobaixa = 'P'");
            strSQL.Append(" order by pr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport3(DateTime dataInicial, DateTime dataFinal, String codigoConta, int idFornecedor)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, pr.tipolancamento, pr.nrodocumento,cc.descricao,");
            strSQL.Append(" pr.datavencimento, td.descricao as tipodocumento, pr.nroparcela,");
            strSQL.Append(" v_fornecedor.nome as fornecedor, pr.documentobaixa, pr.databaixa,");
            strSQL.Append(" pr.valorbaixa, pr.valorjuros, pr.valordesconto, pr.historicoBaixa, pd.valordocumento, pd.nroparcelas, pp.valorparcela");
            strSQL.Append(" from pagarrateio pr, tipodocumento td, v_fornecedor, contacusto cc, pagardocumento pd, pagarparcelas pp");
            strSQL.Append(" where pr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pr.fornecedor_codempresa = v_fornecedor.codempresa and pr.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and cc.codigoconta = '" + codigoConta + "'");
            strSQL.Append(" and pr.idfornecedor = '" + idFornecedor + "'");
            strSQL.Append(" and pr.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and pr.idpagarparcela = pp.idpagarparcelas");
            strSQL.Append(" and pr.situacaobaixa = 'P'");
            strSQL.Append(" order by pr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport2(DateTime dataInicial, DateTime dataFinal, int idFornecedor)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, pr.tipolancamento, pr.nrodocumento, cc.descricao,");
            strSQL.Append(" pr.datavencimento, td.descricao as tipodocumento, pr.nroparcela,");
            strSQL.Append(" v_fornecedor.nome as fornecedor, pr.documentobaixa, pr.databaixa,");
            strSQL.Append(" pr.valorbaixa, pr.valorjuros, pr.valordesconto, pr.historicoBaixa, pd.valordocumento, pd.nroparcelas, pp.valorparcela");
            strSQL.Append(" from pagarrateio pr, tipodocumento td, v_fornecedor, contacusto cc, pagardocumento pd, pagarparcelas pp");
            strSQL.Append(" where pr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pr.fornecedor_codempresa = v_fornecedor.codempresa and pr.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and pr.idfornecedor = '" + idFornecedor + "'");
            strSQL.Append(" and pr.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and pr.idpagarparcela = pp.idpagarparcelas");
            strSQL.Append(" and pr.situacaobaixa = 'P'");
            strSQL.Append(" order by pr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport1(DateTime dataInicial, DateTime dataFinal, String codigoConta)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, pr.tipolancamento, pr.nrodocumento,cc.descricao,");
            strSQL.Append(" pr.datavencimento, td.descricao as tipodocumento, pr.nroparcela,");
            strSQL.Append(" v_fornecedor.nome as fornecedor, pr.documentobaixa, pr.databaixa,");
            strSQL.Append(" pr.valorbaixa, pr.valorjuros, pr.valordesconto, pr.historicoBaixa, pd.valordocumento, pd.nroparcelas, pp.valorparcela");
            strSQL.Append(" from pagarrateio pr, tipodocumento td, v_fornecedor, contacusto cc, pagardocumento pd, pagarparcelas pp");
            strSQL.Append(" where pr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pr.fornecedor_codempresa = v_fornecedor.codempresa and pr.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and cc.codigoconta = '"+codigoConta +"'");
            strSQL.Append(" and pr.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and pr.idpagarparcela = pp.idpagarparcelas");
            strSQL.Append(" and pr.situacaobaixa = 'P'");
            strSQL.Append(" order by pr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport(DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder strSQL = new StringBuilder();
            
            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, pr.tipolancamento, pr.nrodocumento,cc.descricao,");
            strSQL.Append(" pr.datavencimento, td.descricao as tipodocumento, pr.nroparcela,");
            strSQL.Append(" v_fornecedor.nome as fornecedor, pr.documentobaixa, pr.databaixa, cc.descricao,");
            strSQL.Append(" pr.valorbaixa, pr.valorjuros, pr.valordesconto, pr.historicoBaixa, pd.valordocumento, pd.nroparcelas, pp.valorparcela");
            strSQL.Append(" from pagarrateio pr, tipodocumento td, v_fornecedor, contacusto cc, pagardocumento pd, pagarparcelas pp");
            strSQL.Append(" where pr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pr.fornecedor_codempresa = v_fornecedor.codempresa and pr.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and pr.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and pr.idpagarparcela = pp.idpagarparcelas");
            strSQL.Append(" and pr.situacaobaixa = 'P'");
            strSQL.Append(" order by pr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        
        #endregion

    }
}
