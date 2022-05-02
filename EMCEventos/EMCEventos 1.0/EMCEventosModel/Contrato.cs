using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;
using EMCSecurityModel;

namespace EMCEventosModel
{
    public class Contrato
    {
        public Contrato()
        { }

        public virtual int idContrato { get; set; }
        public virtual DateTime dataContrato { get; set; }
        public virtual Decimal valorContrato { get; set; }
        public virtual int nroParcelas { get; set; }
        public virtual SubLocacao subLocacao { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual string geraContasPagar { get; set; }
        public virtual string geraTaxaAdministracao { get; set; }
        public virtual Decimal percenturalAdministracao { get; set; }
        public virtual Decimal valorAdministracao { get; set; }
        public virtual DateTime dataAprovacao { get; set; }        
        public virtual Usuario usuario { get; set; }
        public virtual string situacao { get; set; }
        /*
         * A - Aberto
         * C - Cancelado
         */
        public virtual string flag { get; set; }
        public virtual List<ContratoParcela> lstContratoParcela { get; set; }
    }
}
