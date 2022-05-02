using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFinanceiroModel
{
    public class PagarRateio
    {

        public PagarRateio() { }

        public virtual int idPagarRateio { get; set; }
        public virtual string tipoLancamento { get; set; }
        public virtual int idHolding { get; set; }
        public virtual int idGrupoEmpresa { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual int idMatriz { get; set; }
        public virtual int idPagarDocumento { get; set; }
        public virtual int idPagarParcela { get; set; }
        public virtual int idPagarBaixa { get; set; }
        public virtual int idAplicacao { get; set; }
        public virtual int idContaCusto { get; set; }
        public virtual int idTipoDocumento { get; set; }
        public virtual int idIndexador { get; set; }
        public virtual int fornecedor_CodEmpresa { get; set; }
        public virtual int idFornecedor { get; set; }
        public virtual int idFormaPagamento { get; set; }
        public virtual int idHistorico { get; set; }
        public virtual string historico { get; set; }
        public virtual string historicoBaixa { get; set; }
        public virtual string situacaoBaixa { get; set; }
        public virtual DateTime dataEmissao { get; set; }
        public virtual DateTime dataEntrada { get; set; }
        public virtual DateTime dataVencimento { get; set; }
        public virtual DateTime dataQuitacao { get; set; }
        public virtual DateTime dataPredatado { get; set; }
        public virtual DateTime dataBaixa { get; set; }
        public virtual int ctaBancaria_Empresa { get; set; }
        public virtual int idCtaBancaria { get; set; }
        public virtual int idMovimentoBancario { get; set; }
        public virtual string nroDocumento { get; set; }
        public virtual string documentoBaixa { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual decimal valorBaixa { get; set; }
        public virtual decimal valorJuros { get; set; }
        public virtual decimal valorDesconto { get; set; }
        public virtual double percentualRateio { get; set; }

    }
}
