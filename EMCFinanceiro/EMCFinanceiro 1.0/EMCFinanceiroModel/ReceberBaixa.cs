using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class ReceberBaixa
    {
        public ReceberBaixa() { }

        public virtual int idReceberBaixa { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual ReceberParcela receberParcela { get; set; }
        public virtual DateTime dataPagamento { get; set; }
        public virtual DateTime? dataPreDatado { get; set; }
        public virtual Decimal valorBaixa { get; set; }
        public virtual Decimal valorJuros { get; set; }
        public virtual Decimal valorDesconto { get; set; }
        public virtual Decimal valorTotal { get; set; }
        public virtual FormaPagamento formaPagamento { get; set; }
        public virtual Historico idHistorico { get; set; }
        public virtual string historico { get; set; }
        public virtual CtaBancaria contaCorrente { get; set; }
        public virtual int idControleCaixa { get; set; }
        public virtual string documentoBaixa { get; set; }
        public virtual string nominal { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual int cadastro_idusuario { get; set; }
        public virtual DateTime cadastro_datahora { get; set; }
        public virtual int idMovimentoBancario { get; set; }
        //atributos abaixo não são gravado no banco de dados
        public virtual Decimal totalDocumento { get; set; }
        public virtual Decimal totalJuros { get; set; }
        public virtual Decimal totalDesconto { get; set; }
        public virtual Decimal totalPagamento { get; set; }

      /* 
       * A situação da baixa pode ser:
       * P - Pago (Lançamento confirmado apoós a emissão do cheque ou retorno da remessa do pagfor)
       * B - Baixado ( baixado mas não confirmado pela emissão do cheque ou retorno da remessa pagfor )
       * C - Cancelado
       * A - Amortização de Adiantamento previo ( baixa a parcela e amortiza saldo de adiantamento )
       * H - Baixa com CH Pre Datado ( Baixa a Parcela e gera um novo documento a pagar como ch pre)
       * G - Baixa por Bonificação
       * F - Baixa por transferência FATURA
      */
        public virtual string situacaoBaixa { get; set; }
        public virtual decimal sdoAmortizacao { get; set; }
        public virtual ReceberBaixa idAmortizacao { get; set; }
        public virtual ReceberParcela idDivida { get; set; }
        public virtual List<ChequeRecebido> lstCheque { get; set; }
        
        
    }
}
