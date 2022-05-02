using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_SituacaoPis
    {
        public Fatu_SituacaoPis() { }

        public virtual int idFatu_SituacaoPis { get; set; }
        public virtual string codigoFiscal { get; set; }
        public virtual string descricao { get; set; }
    }
}
