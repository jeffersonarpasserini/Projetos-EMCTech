using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class PagarDocumento
    {
        public PagarDocumento() { }

        public virtual int? idPagarDocumento { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual string nroDocumento { get; set; }
        public virtual DateTime? dataEmissao { get; set; }
        public virtual DateTime? dataEntrada { get; set; }
        public virtual Decimal valorDocumento { get; set; }
        public virtual int nroParcelas { get; set; }
        public virtual string periodicidade { get; set; }
        public virtual string diaFixo { get; set; }
        public virtual string origemDocumento { get; set; }
        public virtual string descricao { get; set; }
        public virtual TipoDocumento tipoDocumento { get; set; }
        public virtual Indexador indexador { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual int idFatura { get; set; }
        public virtual List<PagarParcela> parcelas { get; set; }
        public virtual List<PagarBaseRateio> baseRateio { get; set; }
        /*
         * Situação Documento
         * 
         * A - Aberto
         * P - Pago
         * X - Cancelado
         * 
         */
        public virtual string situacao { get; set; }
        public virtual int cadastro_idusuario { get; set; }
        public virtual DateTime cadastro_datahora { get; set; }
        public virtual double valorIndexado { get; set; }
        public virtual double valorIndice { get; set; }
        public virtual DateTime dataUltimaCorrecao { get; set; }
        public virtual double taxaJuros { get; set; }
        public virtual double taxaMulta { get; set; }


    }
}
