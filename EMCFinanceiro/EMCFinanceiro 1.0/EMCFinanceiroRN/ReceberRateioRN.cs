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
    public class ReceberRateioRN
    {
        ReceberRateioDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;


        public ReceberRateioRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
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
                objBLL = new ReceberRateioDAO(Conexao, oOcorrencia, codEmpresa);
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
            strSQL.Append("select cc.codigoconta, rr.tipolancamento, rr.nrodocumento,cc.descricao,");
            strSQL.Append(" rr.datavencimento, td.descricao as tipodocumento, rr.nroparcela,");
            strSQL.Append(" v_cliente.nome as cliente, rr.documentobaixa, rr.databaixa,");
            strSQL.Append(" rr.valorbaixa, rr.valorjuros, rr.valordesconto, rr.historicoBaixa, rd.valordocumento, rd.nroparcelas, rp.valorparcela");
            strSQL.Append(" from receberrateio rr, tipodocumento td, v_cliente, contacusto cc, receberdocumento rd, receberparcela rp");
            strSQL.Append(" where rr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rr.cliente_codempresa = v_cliente.codempresa and rr.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and rr.idtipodocumento = '" + idTipoDocumento + "'");
            strSQL.Append(" and rr.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and rr.idreceberparcela = rp.idreceberparcela");
            strSQL.Append(" and rr.situacaobaixa = 'P'");
            strSQL.Append(" order by rr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport3(DateTime dataInicial, DateTime dataFinal, String codigoConta, int idCliente)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, rr.tipolancamento, rr.nrodocumento,cc.descricao,");
            strSQL.Append(" rr.datavencimento, td.descricao as tipodocumento, rr.nroparcela,");
            strSQL.Append(" v_cliente.nome as cliente, rr.documentobaixa, rr.databaixa,");
            strSQL.Append(" rr.valorbaixa, rr.valorjuros, rr.valordesconto, rr.historicoBaixa, rd.valordocumento, rd.nroparcelas, rp.valorparcela");
            strSQL.Append(" from receberrateio rr, tipodocumento td, v_cliente, contacusto cc, receberdocumento rd, receberparcela rp");
            strSQL.Append(" where rr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rr.cliente_codempresa = v_cliente.codempresa and rr.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and cc.codigoconta = '" + codigoConta + "'");
            strSQL.Append(" and rr.idcliente = '" + idCliente + "'");
            strSQL.Append(" and rr.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and rr.idreceberparcela = rp.idreceberparcela");
            strSQL.Append(" and rr.situacaobaixa = 'P'");
            strSQL.Append(" order by rr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }
                
        public string DataReport2(DateTime dataInicial, DateTime dataFinal, int idCliente)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, rr.tipolancamento, rr.nrodocumento, cc.descricao,");
            strSQL.Append(" rr.datavencimento, td.descricao as tipodocumento, rr.nroparcela,");
            strSQL.Append(" v_cliente.nome as cliente, rr.documentobaixa, rr.databaixa,");
            strSQL.Append(" rr.valorbaixa, rr.valorjuros, rr.valordesconto, rr.historicoBaixa, rd.valordocumento, rd.nroparcelas, rp.valorparcela");
            strSQL.Append(" from receberrateio rr, tipodocumento td, v_cliente, contacusto cc, receberdocumento rd, receberparcela rp");
            strSQL.Append(" where rr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rr.cliente_codempresa = v_cliente.codempresa and rr.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and rr.idcliente = '" + idCliente + "'");
            strSQL.Append(" and rr.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and rr.idreceberparcela = rp.idreceberparcela");
            strSQL.Append(" and rr.situacaobaixa = 'P'");
            strSQL.Append(" order by rr.databaixa");
            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport1(DateTime dataInicial, DateTime dataFinal, String codigoConta)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, rr.tipolancamento, rr.nrodocumento,cc.descricao,");
            strSQL.Append(" rr.datavencimento, td.descricao as tipodocumento, rr.nroparcela,");
            strSQL.Append(" v_cliente.nome as cliente, rr.documentobaixa, rr.databaixa,");
            strSQL.Append(" rr.valorbaixa, rr.valorjuros, rr.valordesconto, rr.historicoBaixa, rd.valordocumento, rd.nroparcelas, rp.valorparcela");
            strSQL.Append(" from receberrateio rr, tipodocumento td, v_cliente, contacusto cc, receberdocumento rd, receberparcela rp");
            strSQL.Append(" where rr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rr.cliente_codempresa = v_cliente.codempresa and rr.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and cc.codigoconta = '" + codigoConta + "'");
            strSQL.Append(" and rr.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and rr.idreceberparcela = rp.idreceberparcela");
            strSQL.Append(" and rr.situacaobaixa = 'P'");
            strSQL.Append(" order by rr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string DataReport(DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select cc.codigoconta, rr.tipolancamento, rr.nrodocumento, cc.descricao,");
            strSQL.Append(" rr.datavencimento, td.descricao as tipodocumento, rr.nroparcela,");
            strSQL.Append(" v_cliente.nome as cliente, rr.documentobaixa, rr.databaixa,");
            strSQL.Append(" rr.valorbaixa, rr.valorjuros, rr.valordesconto, rr.historicoBaixa, rd.valordocumento, rd.nroparcelas, rp.valorparcela");
            strSQL.Append(" from receberrateio rr, tipodocumento td, v_cliente, contacusto cc, receberdocumento rd, receberparcela rp");
            strSQL.Append(" where rr.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rr.cliente_codempresa = v_cliente.codempresa and rr.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rr.idcontacusto = cc.idcontacusto");
            strSQL.Append(" and rr.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rr.databaixa between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rr.idtipodocumento = td.idtipodocumento");
            strSQL.Append(" and rr.idreceberparcela = rp.idreceberparcela");
            strSQL.Append(" and rr.situacaobaixa = 'P'");
            strSQL.Append(" order by rr.databaixa");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion
    }

}
