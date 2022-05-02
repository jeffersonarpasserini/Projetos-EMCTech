using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;

namespace EMCFinanceiroRN
{
    public class ChequeEmitirRN
    {
        ChequeEmitirDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ChequeEmitirRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        public void emiteCheque(ChequeEmitir oCheque)
        {
            try
            {
                ChequeEmitirDAO oChDAO = new ChequeEmitirDAO(Conexao, oOcorrencia, codEmpresa);
                oChDAO.emiteCheque(oCheque);

            }
            catch (Exception oErro)
            {
                throw oErro;

            }

        }

        public ChequeEmitir ObterPor(ChequeEmitir oCheque)
        {
            try
            {
                ChequeEmitirDAO oChDAO = new ChequeEmitirDAO(Conexao, oOcorrencia, codEmpresa);
                oCheque = oChDAO.ObterPor(oCheque);

                return oCheque;
            }
            catch (Exception oErro)
            {
                throw oErro;
            }
        }

        public DataTable ListaChequeEmitir(CtaBancaria oConta)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ChequeEmitirDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaChequeEmitir(oConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable PesquisaChequeEmitir(DateTime dataInicial, DateTime dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ChequeEmitirDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.PesquisaChequeEmitir(dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ChequeEmitirDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        

        public string rptRelacaoCheque(DateTime dtaInicial, DateTime dtaFinal, int idConta)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select");
            strSQL.Append(" ch.idchequeemitir, ch.idmovimentobancario, ch.idEmpresa, ch.datacheque, ch.valorcheque,");
            strSQL.Append(" ucase(valorextenso(ch.valorcheque)) as extenso, ch.nominal, ch.datapredatado, ch.predatado,");
            strSQL.Append(" ch.compensado, lpad(ch.nrocheque,7,0) as nrocheque, ch.idCtaBancaria,");
            strSQL.Append(" concat(c.Agencia,'-',c.agenciadigito) as nroagencia,");
            strSQL.Append(" concat(c.Conta,'-',c.contadigito) as nroconta, c.Descricao as descricaoconta,");
            strSQL.Append(" c.idBanco, b.Descricao as descricaobanco");

            strSQL.Append(" from");
            strSQL.Append(" ChequeEmitir ch");
            strSQL.Append(" left join ctabancaria c on c.idctabancaria = ch.idCtaBancaria and c.idEmpresa = ch.ctabancaria_idEmpresa ");
            strSQL.Append(" left join banco b on b.idbanco = c.idBanco ");

            strSQL.Append(" where");
            strSQL.Append(" not isnull(ch.formulario_idFormulario)");
            strSQL.Append(" and ch.idEmpresa = " + codEmpresa);
            strSQL.Append(" and ch.datacheque between '"+ dtaInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dtaFinal.Date.ToString("yyyy-MM-dd") + "'");

            if (idConta>0)
                strSQL.Append(" and ch.idctabancaria = "+ idConta.ToString());

            strSQL.Append(" order by idctabancaria, nrocheque");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        public string rptCopiaCheque(string listaCheque)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select");
            strSQL.Append(" ch.idchequeemitir, ch.idmovimentobancario, ch.idEmpresa, ch.datacheque, ch.valorcheque,");
            strSQL.Append(" ucase(valorextenso(ch.valorcheque)) as extenso, ch.nominal, ch.datapredatado, ch.predatado,");
            strSQL.Append(" ch.compensado, lpad(ch.nrocheque,7,0) as nrocheque, ch.idCtaBancaria,");
            strSQL.Append(" concat(c.Agencia,'-',c.agenciadigito) as nroagencia,");
            strSQL.Append(" concat(c.Conta,'-',c.contadigito) as nroconta, c.Descricao as descricaoconta,");
            strSQL.Append(" c.idBanco, b.Descricao as descricaobanco");

            strSQL.Append(" from");
            strSQL.Append(" ChequeEmitir ch");
            strSQL.Append(" left join ctabancaria c on c.idctabancaria = ch.idCtaBancaria and c.idEmpresa = ch.ctabancaria_idEmpresa ");
            strSQL.Append(" left join banco b on b.idbanco = c.idBanco ");

            strSQL.Append(" where");
            strSQL.Append(" not isnull(ch.formulario_idFormulario)");
            strSQL.Append(" and ch.idEmpresa = " + codEmpresa);
            strSQL.Append(" and ch.idchequeemitir in ("+listaCheque+")");

            strSQL.Append(" order by idctabancaria, nrocheque");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        public string rptRelacaoChequeNaoEmitido(DateTime dtaInicial, DateTime dtaFinal, int idConta)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select");
            strSQL.Append(" ch.idchequeemitir, ch.idmovimentobancario, ch.idEmpresa, ch.datacheque, ch.valorcheque,");
            strSQL.Append(" ucase(valorextenso(ch.valorcheque)) as extenso, ch.nominal, ch.datapredatado, ch.predatado,");
            strSQL.Append(" ch.compensado, lpad(ch.nrocheque,7,0) as nrocheque, ch.idCtaBancaria,");
            strSQL.Append(" concat(c.Agencia,'-',c.agenciadigito) as nroagencia,");
            strSQL.Append(" concat(c.Conta,'-',c.contadigito) as nroconta, c.Descricao as descricaoconta,");
            strSQL.Append(" c.idBanco, b.Descricao as descricaobanco");

            strSQL.Append(" from");
            strSQL.Append(" ChequeEmitir ch");
            strSQL.Append(" left join ctabancaria c on c.idctabancaria = ch.idCtaBancaria and c.idEmpresa = ch.ctabancaria_idEmpresa ");
            strSQL.Append(" left join banco b on b.idbanco = c.idBanco ");

            strSQL.Append(" where");
            strSQL.Append(" isnull(ch.formulario_idFormulario)");
            strSQL.Append(" and ch.idEmpresa = " + codEmpresa);
            strSQL.Append(" and ch.datacheque between '" + dtaInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dtaFinal.Date.ToString("yyyy-MM-dd") + "'");

            if (idConta > 0)
                strSQL.Append(" and ch.idctabancaria = " + idConta.ToString());

            strSQL.Append(" order by idctabancaria, nrocheque");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        public string rptDetalheCheque(string listaCheque)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select");
            strSQL.Append(" pg.idpagardocumento, pg.idpagarparcelas, pg.idpagarbaixa, pg.idmovimentobancario,");
            strSQL.Append(" pg.nrodocumento, pg.dataemissao, pg.dataentrada, pg.idfornecedor, pg.nome as nomefornecedor,");
            strSQL.Append(" pg.cnpjcpf as cnpjfornecedor, pg.nroparcela, pg.nroparcelas, pg.datavencimento, pg.datapagamento,");
            strSQL.Append(" pg.valorbaixa, pg.cmbaixa, pg.jurosbaixa, pg.descontobaixa,");
            strSQL.Append(" (pg.valorbaixa+pg.cmbaixa+pg.jurosbaixa-pg.descontobaixa) as totalbaixa,");
            strSQL.Append(" pg.historico ");

            strSQL.Append(" from");
            strSQL.Append(" v_pagarbaixa pg");
            
            strSQL.Append(" where");
            strSQL.Append(" pg.codEmpresa = " + codEmpresa);
            strSQL.Append(" and pg.idmovimentobancario in ("+listaCheque+")");
            strSQL.Append(" order by pg.nrodocumento, pg.nroparcela ");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string listaCopiaCheque(int idConta, DateTime dtaInicial, DateTime dtaFinal)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select");
            strSQL.Append(" ch.idchequeemitir, ch.idmovimentobancario, ch.idEmpresa, ch.datacheque, ch.valorcheque,");
            strSQL.Append(" ch.nominal, lpad(ch.nrocheque,7,0) as nrocheque");

            strSQL.Append(" from");
            strSQL.Append(" ChequeEmitir ch");

            strSQL.Append(" where");
            strSQL.Append(" not isnull(ch.formulario_idFormulario)");
            strSQL.Append(" and ch.idEmpresa = " + codEmpresa);
            strSQL.Append(" and ch.idctabancaria = " + idConta.ToString());
            strSQL.Append(" and ch.datacheque between '" + dtaInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dtaFinal.Date.ToString("yyyy-MM-dd") + "'");

            strSQL.Append(" order by idctabancaria, nrocheque");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }


      



    }
}
