using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_Tributacao
    {
        public Fatu_Tributacao() { }

        public virtual int idfatu_tributacao { get; set; }
        public virtual string descricao { get; set; }
        public virtual string advertencia { get; set; }
        public virtual string situacao { get; set; }
        public virtual string sistematributacao { get; set; }
        public virtual string codigotributacao { get; set; }
    }
}
