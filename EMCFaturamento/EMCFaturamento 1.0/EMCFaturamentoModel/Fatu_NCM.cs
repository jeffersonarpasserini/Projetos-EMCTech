using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_NCM
    {
        public Fatu_NCM() { }

        public virtual int idfatu_ncm { get; set; }
        public virtual string descricao { get; set; }
        public virtual string situacao { get; set; }
        public virtual string nroncm { get; set; }
        public virtual string classificacaofiscal { get; set; }
    }
}
