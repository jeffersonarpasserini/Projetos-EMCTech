using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_OrigemMercadoria
    {
        public Fatu_OrigemMercadoria() { }

        public virtual int idfatu_origemmercadoria { get; set; }
        public virtual string codigoOrigem { get; set; }
        public virtual string descricao { get; set; }
    }
}
