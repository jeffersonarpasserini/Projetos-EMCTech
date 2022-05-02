using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;
using EMCFinanceiroModel;

namespace EMCFinanceiro
{
    
    public static class gPagarParcela
    {

        private static int xnroLinha;
        public static int nroLinha
        {
            get { return xnroLinha; }
            set { xnroLinha = value; }
        }

        private static int xidPagarParcela;
        public static int idPagarParcela
        {
            get { return xidPagarParcela; }
            set { xidPagarParcela = value; }
        }

        private static int xcodEmpresa;
        public static int codEmpresa
        {
            get { return xcodEmpresa; }
            set { xcodEmpresa = value; }
        }

        private static PagarDocumento xpagarDocumento;
        public static PagarDocumento pagarDocumento
        {
            get { return xpagarDocumento; }
            set { xpagarDocumento = value; }
        }

        private static int xnroParcela;
        public static int nroParcela
        {
            get { return xnroParcela; }
            set { xnroParcela = value; }
        }

        private static DateTime? xdataVencimento;
        public static DateTime? dataVencimento
        {
            get { return xdataVencimento; }
            set { xdataVencimento = value; }
        }

        private static DateTime? xdataQuitacao;
        public static DateTime? dataQuitacao
        {
            get { return xdataQuitacao; }
            set { xdataQuitacao = value; }
        }

        private static Decimal xvalorParcela;
        public static Decimal valorParcela
        {
            get { return xvalorParcela; }
            set { xvalorParcela = value; }
        }

        private static Decimal xvalorPagar;
        public static Decimal valorPagar
        {
            get { return xvalorPagar; }
            set { xvalorPagar = value; }
        }

        private static Decimal xvalorTotalPagar;
        public static Decimal valorTotalPagar
        {
            get { return xvalorTotalPagar; }
            set { xvalorTotalPagar = value; }
        }

        private static Decimal xvalorCM;
        public static Decimal valorCM
        {
            get { return xvalorCM; }
            set { xvalorCM = value; }
        }

        private static Decimal xvalorJuros;
        public static Decimal valorJuros
        {
            get { return xvalorJuros; }
            set { xvalorJuros = value; }
        }

        private static Decimal xvalorDesconto;
        public static Decimal valorDesconto
        {
            get { return xvalorDesconto; }
            set { xvalorDesconto = value; }
        }

        private static Decimal xsaldoPagar;
        public static Decimal  saldoPagar
        {
            get { return xsaldoPagar; }
            set { xsaldoPagar = value; }
        }

        private static Decimal xsaldoPago;
        public static Decimal saldoPago
        {
            get { return xsaldoPago; }
            set { xsaldoPago = value; }
        }

        private static string xsituacao;
        public static string situacao
        {
            get { return xsituacao; }
            set { xsituacao = value; }
        }

        private static string xnossoNumero;
        public static string nossoNumero
        {
            get { return xnossoNumero; }
            set { xnossoNumero = value; }
        }

        private static string xcodigoBarras;
        public static string codigoBarras
        {
            get { return xcodigoBarras; }
            set { xcodigoBarras = value; }
        }

        private static string xstatus;
        public static string status
        {
            get { return xstatus; }
            set { xstatus = value; }
        }

        private static TipoCobranca xtipoCobranca;
        public static TipoCobranca tipoCobranca
        {
            get { return xtipoCobranca; }
            set { xtipoCobranca = value; }
        }

        private static Formulario xFormulario;
        public static Formulario formulario
        {
            get { return xFormulario; }
            set { xFormulario = value; }
        }

        private static string xnominal;
        public static string nominal
        {
            get { return xnominal; }
            set { xnominal = value; }
        }

        private static string xdocumento;
        public static string documento
        {
            get { return xdocumento; }
            set { xdocumento = value; }
        }
    }

    public static class gReceberParcela
    {

        private static int xnroLinha;
        public static int nroLinha
        {
            get { return xnroLinha; }
            set { xnroLinha = value; }
        }

        private static int xidReceberParcela;
        public static int idReceberParcela
        {
            get { return xidReceberParcela; }
            set { xidReceberParcela = value; }
        }

        private static int xcodEmpresa;
        public static int codEmpresa
        {
            get { return xcodEmpresa; }
            set { xcodEmpresa = value; }
        }

        private static ReceberDocumento xreceberDocumento;
        public static ReceberDocumento receberDocumento
        {
            get { return xreceberDocumento; }
            set { xreceberDocumento = value; }
        }

        private static int xnroParcela;
        public static int nroParcela
        {
            get { return xnroParcela; }
            set { xnroParcela = value; }
        }

        private static DateTime? xdataVencimento;
        public static DateTime? dataVencimento
        {
            get { return xdataVencimento; }
            set { xdataVencimento = value; }
        }

        private static DateTime? xdataQuitacao;
        public static DateTime? dataQuitacao
        {
            get { return xdataQuitacao; }
            set { xdataQuitacao = value; }
        }

        private static Decimal xvalorParcela;
        public static Decimal valorParcela
        {
            get { return xvalorParcela; }
            set { xvalorParcela = value; }
        }

        private static Decimal xvalorPagar;
        public static Decimal valorPagar
        {
            get { return xvalorPagar; }
            set { xvalorPagar = value; }
        }

        private static Decimal xvalorTotalPagar;
        public static Decimal valorTotalPagar
        {
            get { return xvalorTotalPagar; }
            set { xvalorTotalPagar = value; }
        }

        private static Decimal xvalorJuros;
        public static Decimal valorJuros
        {
            get { return xvalorJuros; }
            set { xvalorJuros = value; }
        }

        private static Decimal xvalorDesconto;
        public static Decimal valorDesconto
        {
            get { return xvalorDesconto; }
            set { xvalorDesconto = value; }
        }

        private static Decimal xsaldoPagar;
        public static Decimal saldoPagar
        {
            get { return xsaldoPagar; }
            set { xsaldoPagar = value; }
        }

        private static Decimal xsaldoPago;
        public static Decimal saldoPago
        {
            get { return xsaldoPago; }
            set { xsaldoPago = value; }
        }

        private static string xsituacao;
        public static string situacao
        {
            get { return xsituacao; }
            set { xsituacao = value; }
        }

        private static string xnossoNumero;
        public static string nossoNumero
        {
            get { return xnossoNumero; }
            set { xnossoNumero = value; }
        }

        private static string xcodigoBarras;
        public static string codigoBarras
        {
            get { return xcodigoBarras; }
            set { xcodigoBarras = value; }
        }

        private static string xstatus;
        public static string status
        {
            get { return xstatus; }
            set { xstatus = value; }
        }

        private static TipoCobranca xtipoCobranca;
        public static TipoCobranca tipoCobranca
        {
            get { return xtipoCobranca; }
            set { xtipoCobranca = value; }
        }

        private static Formulario xFormulario;
        public static Formulario formulario
        {
            get { return xFormulario; }
            set { xFormulario = value; }
        }

        private static string xnominal;
        public static string nominal
        {
            get { return xnominal; }
            set { xnominal = value; }
        }

        private static string xdocumento;
        public static string documento
        {
            get { return xdocumento; }
            set { xdocumento = value; }
        }

        private static double xtxajuros;
        public static double txajuros
        {
            get { return xtxajuros; }
            set { xtxajuros = value; }
        }

        private static double xtxamulta;
        public static double txamulta
        {
            get { return xtxamulta; }
            set { xtxamulta = value; }
        }

        private static string xtipoJuros;
        public static string tipoJuros
        {
            get { return xtipoJuros; }
            set { xtipoJuros = value; }
        }
    }

    public static class retPesquisa
    {

        private static int xcodempresa;
        public static int codempresa
        {
            get { return xcodempresa; }
            set { xcodempresa = value; }
        }

        private static string xchavebusca;
        public static string chavebusca
        {
            get { return xchavebusca; }
            set { xchavebusca = value; }
        }

        private static int xchaveinterna;
        public static int chaveinterna
        {
            get { return xchaveinterna; }
            set { xchaveinterna = value; }
        }

    }

    public static class chequeRecebido
    {
        private static List<ChequeRecebido> xLstChequeRecebido;
        public static List<ChequeRecebido> lstChequeRecebido
        {
            get { return xLstChequeRecebido; }
            set { xLstChequeRecebido = value; }
        }
    }

    public static class rateioPagar
    {
        private static List<PagarBaseRateio> xLstPagarBaseRateio;
        public static List<PagarBaseRateio> lstPagarBaseRateio
        {
            get { return xLstPagarBaseRateio; }
            set { xLstPagarBaseRateio = value; }
        }
    }

    public static class rateioReceber
    {
        private static List<ReceberBaseRateio> xLstReceberBaseRateio;
        public static List<ReceberBaseRateio> lstReceberBaseRateio
        {
            get { return xLstReceberBaseRateio; }
            set { xLstReceberBaseRateio = value; }
        }
    }
}
