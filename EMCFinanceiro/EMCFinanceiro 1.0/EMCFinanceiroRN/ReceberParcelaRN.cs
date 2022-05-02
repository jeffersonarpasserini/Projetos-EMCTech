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
    public class ReceberParcelaRN
    {
         ReceberParcelaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ReceberParcelaRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        /// <summary>
        /// Realiza busca ao banco de dados das parcelas em aberto para pagamento de acordo com o parametros informados
        /// Retornando um List
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docReceber"></param>
        /// <returns></returns>
        public List<ReceberParcela> listaParcelaBaixa(int codempresa, int empMaster, int idCliente, DateTime? dataInicio, DateTime? dataFinal, bool todos, string docReceber, int chaveAcordo = 0)
        {
            List<ReceberParcela> lstParcelaBaixa = new List<ReceberParcela>();

            try
            {
                if (dataInicio > dataFinal)
                {
                    Exception err = new Exception("Data Inicial é maior que data final");
                    throw err;
                }

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcelaBaixa = objBLL.listaParcelaBaixa(codempresa, empMaster, idCliente,dataInicio,dataFinal,todos,docReceber, chaveAcordo);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstParcelaBaixa;
        }
        /// <summary>
        /// Lista as parcelas do contas a pagar retornando um datatable
        /// </summary>
        /// <param name="oDocumento"></param>
        /// <returns></returns>
        public DataTable ListaReceberParcela(ReceberDocumento oDocumento)
        {
            DataTable dtCon = new DataTable();

            try
            {
                ReceberParcela oParcela = new ReceberParcela();
                oParcela.receberDocumento = oDocumento;

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaReceberParcela(oParcela);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas em aberto para  sem aprovação de pagamento para geração de uma fatura
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <param name="DataInicio"></param>
        /// <param name="Datafinal"></param>
        /// <param name="todosValores"></param>
        /// <returns></returns>
        public List<ReceberParcela> listaReceberFatura(int idUsuario, int codempresa, int empmaster, int idCliente, DateTime? dataInicio, DateTime? dataFinal, bool todos)
        {
            List<ReceberParcela> lstParcelaBaixa = new List<ReceberParcela>();

            try
            {
                if (dataInicio > dataFinal)
                {
                    Exception err = new Exception("Data Inicial é maior que data final");
                    throw err;
                }
                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcelaBaixa = objBLL.listaReceberFatura(idUsuario, codempresa, empmaster, idCliente, dataInicio, dataFinal, todos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstParcelaBaixa;


        }
        /// <summary>
        /// Atualiza as parcelas do contas a pagar (desativado)
        /// </summary>
        /// <param name="objReceberParcela"></param>
        public void Atualizar(ReceberParcela objReceberParcela)
        {
           

        }
        /// <summary>
        /// Salva parcelas do contas a pagar ( desativado )
        /// </summary>
        /// <param name="objReceberParcela"></param>
        public void Salvar(ReceberParcela objReceberParcela)
        {
        
        }
        /// <summary>
        /// Exclui parcelas do contas a pagar ( desativado )
        /// </summary>
        /// <param name="objReceberParcela"></param>
        public void Excluir(ReceberParcela objReceberParcela)
        {
           

        }
        /// <summary>
        /// Busca informações no banco de dados de uma parcela do contas a pagar
        /// retornando um objeto do tipo ReceberParcela
        /// </summary>
        /// <param name="objReceberParcela"></param>
        /// <returns></returns>
        public ReceberParcela ObterPor(ReceberParcela objReceberParcela)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objReceberParcela);

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                objReceberParcela = objBLL.ObterPor(objReceberParcela);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objReceberParcela;

        }
        /// <summary>
        /// Calcula Saldo Devedor para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSaldoDevedor(int codCliente)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSaldoDevedor(codCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Atraso para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSaldoAtraso(int codCliente)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSaldoAtraso(codCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Vencimento até 30 dias para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaVencimento30Dias(int codCliente)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaVencimento30Dias(codCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo Vencimento acima 30 dias para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSdoVencimentoUp30Dias(int codCliente)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSdoVencimentoUp30Dias(codCliente);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo de parcelas de um documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocParcela(int idReceberDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocParcela(idReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }

        /// <summary>
        /// Calcula Saldo de descontos de um documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocDesconto(int idReceberDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocDesconto(idReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }

        /// <summary>
        /// Calcula Saldo de juros de um documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocJuros(int idReceberDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocJuros(idReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }

        /// <summary>
        /// Calcula Saldo de parcelas pagas de um documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocSdoPago(int idReceberDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocSdoPago(idReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }

        /// <summary>
        /// Calcula Saldo de parcelas a pagar de um documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocSdoPagar(int idReceberDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocSdoPagar(idReceberDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }


        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string DataReport6(DateTime dataInicial, DateTime dataFinal, int idTipoDocumento, int idCliente)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select rd.nrodocumento, rd.dataentrada as dataentradadocumento, rd.dataemissao,");
            strSQL.Append(" rd.descricao as descricaodocumento, rd.nroparcelas as nroparcelasdocumento, rp.nroparcela,");
            strSQL.Append(" rp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.descricao as tipodocumento, rp.valorparcela, rp.saldopago,");
            strSQL.Append(" rp.saldopagar, rp.situacao as situacaoparcela, v_cliente.nome as cliente, rd.valordocumento");
            strSQL.Append(" from receberdocumento rd, receberparcela rp, tipodocumento, v_cliente");
            strSQL.Append(" where rp.empresa_idempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rd.cliente_codempresa = v_cliente.codempresa and rd.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rp.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and rd.idtipodocumento = '" + idTipoDocumento + "'");
            strSQL.Append(" and v_cliente.idpessoa = '" + idCliente.ToString() + "'");
            strSQL.Append(" and rp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rp.situacao = 'A'");
            strSQL.Append(" order by rp.datavencimento");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport5(DateTime dataInicial, DateTime dataFinal, int idTipoDocumento)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select rd.nrodocumento, rd.dataentrada as dataentradadocumento, rd.dataemissao,");
            strSQL.Append(" rd.descricao as descricaodocumento, rd.nroparcelas as nroparcelasdocumento, rp.nroparcela,");
            strSQL.Append(" rp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.descricao as tipodocumento, rp.valorparcela, rp.saldopago,");
            strSQL.Append(" rp.saldopagar, rp.situacao as situacaoparcela, v_cliente.nome as cliente, rd.valordocumento");
            strSQL.Append(" from receberdocumento rd, receberparcela rp, tipodocumento, v_cliente");
            strSQL.Append(" where rp.empresa_idempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rd.cliente_codempresa = v_cliente.codempresa and rd.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rp.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and rd.idtipodocumento = '"+idTipoDocumento+"'");
            strSQL.Append(" and rp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rp.situacao = 'A'");
            strSQL.Append(" order by rp.datavencimento");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport4(int idCliente, DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select rd.nrodocumento, rd.dataentrada as dataentradadocumento, rd.dataemissao,");
            strSQL.Append(" rd.descricao as descricaodocumento, rd.nroparcelas as nroparcelasdocumento, rp.nroparcela,");
            strSQL.Append(" rp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.descricao as tipodocumento, rp.valorparcela, rp.saldopago,");
            strSQL.Append(" rp.saldopagar, rp.situacao as situacaoparcela, v_cliente.nome as cliente, rd.valordocumento");
            strSQL.Append(" from receberdocumento rd, receberparcela rp, tipodocumento, v_cliente");
            strSQL.Append(" where rp.empresa_idempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rd.cliente_codempresa = v_cliente.codempresa and rd.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rp.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and v_cliente.idpessoa = '" + idCliente.ToString() + "'");
            strSQL.Append(" and rp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rp.situacao = 'A'");
            strSQL.Append(" order by rp.datavencimento");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport3(DateTime dataVencimento)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select rd.nrodocumento, rd.dataentrada as dataentradadocumento, rd.dataemissao,");
            strSQL.Append(" rd.descricao as descricaodocumento, rd.nroparcelas as nroparcelasdocumento, rp.nroparcela,");
            strSQL.Append(" rp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.descricao as tipodocumento, rp.valorparcela, rp.saldopago,");
            strSQL.Append(" rp.saldopagar, rp.situacao as situacaoparcela, v_cliente.nome as cliente, rd.valordocumento");
            strSQL.Append(" from receberdocumento rd, receberparcela rp, tipodocumento, v_cliente");
            strSQL.Append(" where rp.empresa_idempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rd.cliente_codempresa = v_cliente.codempresa and rd.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rp.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and rp.datavencimento <= '" + dataVencimento.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rp.situacao = 'A'");
            strSQL.Append(" order by rp.datavencimento");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }
       
        public string DataReport2(DateTime dataVencimento)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select rd.nrodocumento, rd.dataentrada as dataentradadocumento, rd.dataemissao,");
            strSQL.Append(" rd.descricao as descricaodocumento, rd.nroparcelas as nroparcelasdocumento, rp.nroparcela,");
            strSQL.Append(" rp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.descricao as tipodocumento, rp.valorparcela, rp.saldopago,");
            strSQL.Append(" rp.saldopagar, rp.situacao as situacaoparcela, v_cliente.nome as cliente, rd.valordocumento");
            strSQL.Append(" from receberdocumento rd, receberparcela rp, tipodocumento, v_cliente");
            strSQL.Append(" where rp.empresa_idempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rd.cliente_codempresa = v_cliente.codempresa and rd.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rp.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and rp.datavencimento = '" + dataVencimento.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rp.situacao = 'A'");
            strSQL.Append(" order by rp.datavencimento");



            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        
        public string DataReport(DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select rd.nrodocumento, rd.dataentrada as dataentradadocumento, rd.dataemissao,");
            strSQL.Append(" rd.descricao as descricaodocumento, rd.nroparcelas as nroparcelasdocumento, rp.nroparcela,");
            strSQL.Append(" rp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, rp.valorparcela, rp.saldopago,");
            strSQL.Append(" rp.saldopagar, rp.situacao as situacaoparcela, v_cliente.nome as cliente, rd.valordocumento,");
            strSQL.Append(" tb.abreviatura as tipocobranca ");
            strSQL.Append(" from receberdocumento rd, receberparcela rp, tipodocumento, v_cliente, tipocobranca tb");
            strSQL.Append(" where rp.empresa_idempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (rd.cliente_codempresa = v_cliente.codempresa and rd.idcliente = v_cliente.idpessoa)");
            strSQL.Append(" and rp.idreceberdocumento = rd.idreceberdocumento");
            strSQL.Append(" and rp.idtipocobranca = tb.idtipocobranca");
            strSQL.Append(" and rd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and rp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and rp.situacao = 'A'");
            strSQL.Append(" order by rp.datavencimento");



            //retorna string com consulta SQL
            return strSQL.ToString();

        }


        #endregion

        #region Metodos Privados da Classe
        /// <summary>
        /// Verifica dados dos atributos do objeto ReceberParcela retornando uma Exception
        /// Deve ser circundada por um try catch
        /// </summary>
        /// <param name="obj"></param>
        private void VerificaDados(ReceberParcela obj)
        {

            //Exception objErro;

            //if (String.IsNullOrEmpty(obj.descricao))
            //{
            //    objErro = new Exception("A descrição do ReceberParcela não pode estar vazia");
            //    throw objErro;
            //}
        }

        #endregion



    }
}
