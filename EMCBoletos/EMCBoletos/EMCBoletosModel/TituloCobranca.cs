using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCBoletosModel
{
    public class TituloCobranca
    {
        public TituloCobranca()
        {

        }
        public int codEmpresa { get; set; }
        public int empMaster { get; set; }
        public int idCliente { get; set; }
        public int idContrato { get; set; }
        public int nroParcela { get; set; }
        public string nossoNUmero { get; set; }
        public int nroContaTitulo { get; set; }
        public DateTime dtaVencimento { get; set; }
        public Decimal vlrBoleto { get; set; }
        public Decimal vlrAluguel { get; set; }
        public Decimal vlrAbono { get; set; }
        public Decimal vlrIptu { get; set; }
        public Decimal vlrCondominio { get; set; }
        public Decimal vlrDescontoConcedido { get; set; }
        public Decimal vlrOutros { get; set; }
        public Decimal vlrOutrosDimob { get; set; }
        public Decimal vlrTotalReceber { get; set; }
        public DateTime dtaInicioPeriodo { get; set; }
        public DateTime dtaFinalPeriodo { get; set; }
        public string sacadoRazaoSocial { get; set; }
        public string sacadoCNPJ { get; set; }
        public string sacadoEndereco { get; set; }
        public string sacadoNumero { get; set; }
        public string sacadoBairro { get; set; }
        public string sacadoCidade { get; set; }
        public string sacadoEstado { get; set; }
        public string sacadoCEP { get; set; }
        public int idImovel { get; set; }
        public string imovelEndereco { get; set; }
        public string imovelNumero { get; set; }
        public string imovelBairro { get; set; }
        public string nomeArquivo { get; set; }
        public Decimal taxaJuros { get; set; }
        public Decimal taxaMulta { get; set; }
        public Decimal boletoJurosDia { get; set; }
        public Decimal boletoMulta { get; set; }

    }
}
