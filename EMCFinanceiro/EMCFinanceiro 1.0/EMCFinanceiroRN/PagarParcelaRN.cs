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
    public class PagarParcelaRN
    {

        PagarParcelaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PagarParcelaRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe

        /// <summary>
        /// Realiza a liberação do documento para pagamento - gerando a propria transação
        /// </summary>
        /// <param name="List<PagarParcela> lstParcelas"></param>
        /// <returns></returns>
        public void liberacaoPagamento(List<PagarParcela> lstParcelas, int codEmpresa)
        {
            try
            {
                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.liberacaoPagamento(lstParcelas, codEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
         /// <summary>
        /// Realiza busca ao banco de dados das parcelas em aberto para aprovação de pagamento de acordo com o parametros informados
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
        public List<PagarParcela> listaPagarLiberacao(int idUsuario, int codempresa, int idFornecedor, DateTime? dataInicio, DateTime? dataFinal, bool todos, string docPagar, decimal valorInicio, decimal valorFinal, bool todosValores)
        {
            List<PagarParcela> lstParcelaBaixa = new List<PagarParcela>();

            try
            {
                if (dataInicio > dataFinal)
                {
                    Exception err = new Exception("Data Inicial é maior que data final");
                    throw err;
                }
                if (valorInicio > valorFinal)
                {
                    Exception err = new Exception("Valor Inicial é maior que valor final");
                    throw err;
                }


                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcelaBaixa = objBLL.listaPagarLiberacao(idUsuario, codempresa, idFornecedor, dataInicio, dataFinal, todos, docPagar,valorInicio,valorFinal,todosValores);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstParcelaBaixa;


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
        public List<PagarParcela> listaPagarFatura(int idUsuario, int codempresa, int idFornecedor, DateTime? dataInicio, DateTime? dataFinal, bool todos)
        {
            List<PagarParcela> lstParcelaBaixa = new List<PagarParcela>();

            try
            {
                if (dataInicio > dataFinal)
                {
                    Exception err = new Exception("Data Inicial é maior que data final");
                    throw err;
                }
                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcelaBaixa = objBLL.listaPagarFatura(idUsuario, codempresa, idFornecedor, dataInicio, dataFinal, todos);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstParcelaBaixa;


        }
        /// <summary>
        /// Realiza busca ao banco de dados das parcelas em aberto para pagamento de acordo com o parametros informados
        /// Retornando um List
        /// </summary>
        /// <param name="idFornecedor"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFinal"></param>
        /// <param name="todos"></param>
        /// <param name="docPagar"></param>
        /// <returns></returns>
        public List<PagarParcela> listaParcelaBaixa(int empmaster, int idFornecedor, DateTime? dataInicio, DateTime? dataFinal, bool todos, string docPagar)
        {
            List<PagarParcela> lstParcelaBaixa = new List<PagarParcela>();

            try
            {
                if (dataInicio > dataFinal)
                {
                    Exception err = new Exception("Data Inicial é maior que data final");
                    throw err;
                }

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                lstParcelaBaixa = objBLL.listaParcelaBaixa(empmaster, idFornecedor,dataInicio,dataFinal,todos,docPagar);
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
        public DataTable ListaPagarParcela(PagarDocumento oDocumento)
        {
            DataTable dtCon = new DataTable();

            try
            {
                PagarParcela oParcela = new PagarParcela();
                oParcela.pagarDocumento = oDocumento;

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaPagarParcela(oParcela);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        /// <summary>
        /// Atualiza as parcelas do contas a pagar (desativado)
        /// </summary>
        /// <param name="objPagarParcela"></param>
        public void Atualizar(PagarParcela objPagarParcela)
        {
           

        }
        /// <summary>
        /// Salva parcelas do contas a pagar ( desativado )
        /// </summary>
        /// <param name="objPagarParcela"></param>
        public void Salvar(PagarParcela objPagarParcela)
        {
        
        }
        /// <summary>
        /// Exclui parcelas do contas a pagar ( desativado )
        /// </summary>
        /// <param name="objPagarParcela"></param>
        public void Excluir(PagarParcela objPagarParcela)
        {
           

        }
        /// <summary>
        /// Busca informações no banco de dados de uma parcela do contas a pagar
        /// retornando um objeto do tipo PagarParcela
        /// </summary>
        /// <param name="objPagarParcela"></param>
        /// <returns></returns>
        public PagarParcela ObterPor(string nroDocumento, int nroParcela, int codEmpresa, Fornecedor oFornecedor)
        {
            PagarParcela objPagarParcela = new PagarParcela();
            try
            {
                

                //Valida informações a serem gravadas
                //VerificaDados(objPagarParcela);

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                objPagarParcela = objBLL.ObterPor(nroDocumento,nroParcela,codEmpresa, oFornecedor);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objPagarParcela;

        }
        /// <summary>
        /// Busca informações no banco de dados de uma parcela do contas a pagar
        /// retornando um objeto do tipo PagarParcela
        /// </summary>
        /// <param name="objPagarParcela"></param>
        /// <returns></returns>
        public PagarParcela ObterPor(PagarParcela objPagarParcela)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objPagarParcela);

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                objPagarParcela = objBLL.ObterPor(objPagarParcela);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objPagarParcela;

        }
        /// <summary>
        /// Calcula Saldo Devedor para um fornecedor
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaSaldoDevedor(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSaldoDevedor(codFornecedor);


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
        public decimal calculaSaldoAtraso(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSaldoAtraso(codFornecedor);


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
        public decimal calculaVencimento30Dias(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaVencimento30Dias(codFornecedor);


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
        public decimal calculaSdoVencimentoUp30Dias(int codFornecedor)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaSdoVencimentoUp30Dias(codFornecedor);


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
        public decimal calculaDocParcela(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocParcela(idPagarDocumento);


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
        public decimal calculaDocDesconto(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocDesconto(idPagarDocumento);


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
        public decimal calculaDocJuros(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocJuros(idPagarDocumento);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return saldo;
        }
        /// <summary>
        /// Calcula Saldo de CM de um documento
        /// </summary>
        /// <param name="codigo Fornecedor"></param>
        /// <returns></returns>
        public decimal calculaDocCM(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocCM(idPagarDocumento);


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
        public decimal calculaDocSdoPago(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocSdoPago(idPagarDocumento);


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
        public decimal calculaDocSdoPagar(int idPagarDocumento)
        {
            decimal saldo = 0;
            try
            {

                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                saldo = objBLL.calculaDocSdoPagar(idPagarDocumento);


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
                objBLL = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        
        public string DataReport( DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder strSQL = new StringBuilder();
                     

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
           strSQL.Clear();
           strSQL.Append ("select pd.nrodocumento, pd.dataentrada as dataentradadocumento, pd.dataemissao,");
           strSQL.Append (" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,"); 
           strSQL.Append (" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
           strSQL.Append (" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento,");
           strSQL.Append (" tb.abreviatura as tipocobranca ");
           strSQL.Append (" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor, tipocobranca tb");
           strSQL.Append (" where pp.codempresa = '"+ codEmpresa + "'");
           strSQL.Append (" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
           strSQL.Append (" and pp.idpagardocumento = pd.idpagardocumento");
           strSQL.Append (" and pp.idtipocobranca = tb.idtipocobranca"); 
           strSQL.Append (" and pd.idtipodocumento = tipodocumento.idtipodocumento");
           strSQL.Append (" and pp.datavencimento between '"+ dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
           strSQL.Append (" and pp.situacao = 'A'");
           strSQL.Append (" order by pp.datavencimento");
                 
           
                        
            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        
        public string DataReport2(DateTime dataVencimento)
        {
            StringBuilder strSQL = new StringBuilder();
                       
            strSQL.Clear();
            strSQL.Append("select pd.nrodocumento, pd.dataentrada as dataentradadocumento, pd.dataemissao,");
            strSQL.Append(" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
            strSQL.Append(" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento");
            strSQL.Append(" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor");
            strSQL.Append(" where pp.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pp.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and pp.datavencimento = '" + dataVencimento.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pp.situacao = 'A'");
            strSQL.Append(" order by pp.datavencimento");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport3(DateTime dataVencimento)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("select pd.nrodocumento, pd.dataentrada as dataentradadocumento, pd.dataemissao,");
            strSQL.Append(" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
            strSQL.Append(" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento");
            strSQL.Append(" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor");
            strSQL.Append(" where pp.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pp.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and pp.datavencimento <= '" + dataVencimento.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pp.situacao = 'A'");
            strSQL.Append(" order by pp.datavencimento");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport4(int idFornecedor, DateTime dataInicial, DateTime dataFinal )
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("select pd.nrodocumento, pd.dataentrada as dataentradadocumento,");
            strSQL.Append(" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
            strSQL.Append(" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento");
            strSQL.Append(" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor");
            strSQL.Append(" where pp.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pp.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and v_fornecedor.idpessoa = '" + idFornecedor.ToString()+ "'");
            strSQL.Append(" and pp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pp.situacao = 'A'");
            strSQL.Append(" order by pp.datavencimento");
                        
            return strSQL.ToString();

        }

        public string DataReport5(DateTime dataInicial, DateTime dataFinal)
        {
            StringBuilder strSQL = new StringBuilder();
                                  
            strSQL.Clear();
            strSQL.Append("select pd.nrodocumento, pd.dataentrada as dataentradadocumento, pd.dataemissao,");
            strSQL.Append(" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
            strSQL.Append(" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento");
            strSQL.Append(" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor");
            strSQL.Append(" where pp.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pp.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and pp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pp.situacao = 'A'");
            strSQL.Append(" order by v_fornecedor.nome and pp.datavencimento");

            return strSQL.ToString();

        }

        public string DataReport6(DateTime dataInicial, DateTime dataFinal, int idTipoDocumento)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select pd.nrodocumento, pd.dataentrada as dataentradadocumento, pd.dataemissao,");
            strSQL.Append(" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
            strSQL.Append(" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento");
            strSQL.Append(" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor");
            strSQL.Append(" where pp.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pp.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and pd.idtipodocumento = '"+idTipoDocumento+"'");
            strSQL.Append(" and pp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pp.situacao = 'A'");
            strSQL.Append(" order by pp.datavencimento");



            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport7(DateTime dataInicial, DateTime dataFinal, int idTipoDocumento, int idFornecedor)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select pd.nrodocumento, pd.dataentrada as dataentradadocumento, pd.dataemissao,");
            strSQL.Append(" pd.descricao as descricaodocumento, pp.nroparcela, pp.datavencimento as datavencimentoparcela,");
            strSQL.Append(" tipodocumento.abreviatura as tipodocumento, pp.valorparcela, pp.saldopago,");
            strSQL.Append(" pp.saldopagar, pp.situacao as situacaoparcela, v_fornecedor.nome as fornecedor, pd.nroparcelas as nroparcelasdocumento, pd.valordocumento");
            strSQL.Append(" from pagardocumento pd, pagarparcelas pp, tipodocumento, v_fornecedor");
            strSQL.Append(" where pp.codempresa = '" + codEmpresa + "'");
            strSQL.Append(" and (pd.fornecedor_codempresa = v_fornecedor.codempresa and pd.idfornecedor = v_fornecedor.idpessoa)");
            strSQL.Append(" and pp.idpagardocumento = pd.idpagardocumento");
            strSQL.Append(" and pd.idtipodocumento = tipodocumento.idtipodocumento");
            strSQL.Append(" and pd.idtipodocumento = '" + idTipoDocumento + "'");
            strSQL.Append(" and v_fornecedor.idpessoa = '" + idFornecedor.ToString() + "'");
            strSQL.Append(" and pp.datavencimento between '" + dataInicial.Date.ToString("yyyy-MM-dd") + "' and '" + dataFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" and pp.situacao = 'A'");
            strSQL.Append(" order by pp.datavencimento");



            //retorna string com consulta SQL
            return strSQL.ToString();

        }
        
        #endregion

        #region Metodos Privados da Classe
        /// <summary>
        /// Verifica dados dos atributos do objeto PagarParcela retornando uma Exception
        /// Deve ser circundada por um try catch
        /// </summary>
        /// <param name="obj"></param>
        private void VerificaDados(PagarParcela obj)
        {

            //Exception objErro;

            //if (String.IsNullOrEmpty(obj.descricao))
            //{
            //    objErro = new Exception("A descrição do PagarParcela não pode estar vazia");
            //    throw objErro;
            //}
        }
        #endregion




    }
}
