using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCEstoqueModel
{
    public class Estq_NFCompra
    {

        public Estq_NFCompra() { }

        public virtual int idEstq_NFCompra { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual string nroNotaFiscal { get; set; }
        public virtual string serieNotaFiscal { get; set; }
        public virtual string chaveAcesso { get; set; }
        public virtual DateTime dataEmissao { get; set; }
        public virtual DateTime dataSaida { get; set; }
        public virtual DateTime dataEntrada { get; set; }
        public virtual string tipoNotaFiscal { get; set; }
        public virtual Decimal valorProdutos { get; set; }
        public virtual Decimal valorIPI { get; set; }
        public virtual Decimal valorFrete { get; set; }
        public virtual Decimal valorTotalNota { get; set; }
        public virtual Decimal bcIcms { get; set; }
        public virtual Decimal valorIcms { get; set; }
        public virtual Decimal bcIcmsST { get; set; }
        public virtual Decimal valorIcmsST { get; set; }
        public virtual Decimal valorSeguro { get; set; }
        public virtual Decimal valorDesconto { get; set; }
        public virtual Decimal valorOutrasDepesas { get; set; }
        public virtual Decimal valorServicos { get; set; }
        public virtual Decimal valorISSQN { get; set; }
        public virtual List<Estq_NFCompraParcelamento> parcelamento { get; set; }
        public virtual List<Estq_NFCompraItem> itensNotaFiscal { get; set; }

    }
}
