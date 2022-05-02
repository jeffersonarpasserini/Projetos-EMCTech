using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class ReceberDocumento
    {
        public ReceberDocumento() { }

        public virtual int? idReceberDocumento { get; set; }
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
        //public virtual Aplicacao aplicacao { get; set; }
        public virtual Indexador indexador { get; set; }
        //public virtual ContaCusto contaCusto { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual int idFatura { get; set; }
        public virtual List<ReceberParcela> parcelas { get; set; }
        public virtual List<ReceberBaseRateio> baseRateio { get; set; }
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
        public virtual double taxaJuros { get; set; }
        public virtual double taxaMulta { get; set; }

        /* campo virtual não existe na tabela */
        public virtual double jurosCalculado { get; set; }
        public virtual double multaCalculado { get; set; }

    }
}
