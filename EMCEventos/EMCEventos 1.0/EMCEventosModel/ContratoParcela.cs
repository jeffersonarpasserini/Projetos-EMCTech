using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEventosModel
{
    public class ContratoParcela
    {
        public ContratoParcela()
        { }

        public virtual int idContratoParcela { get; set; }
        public virtual Contrato contrato { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual DateTime dataVencimento { get; set; }
        public virtual Decimal valorParcela { get; set; }
        public virtual string situacao { get; set; }
        /*
         * A - Aberto
         */
        public virtual string flag { get; set; }
    }
}
