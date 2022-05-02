using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class PagarBaseRateio
    {
        public PagarBaseRateio() { }

        public virtual int idPagarBaseRateio { get; set; }
        public virtual int idPagarDocumento { get; set; }
        public virtual Aplicacao aplicacao { get; set; }
        public virtual ContaCusto contaCusto { get; set; }
        public virtual double percentualRateio { get; set; }
        public virtual decimal valorRateio { get; set; }
        public virtual string status { get; set; }
        public virtual int codEmpresa { get; set; }

    }
}
