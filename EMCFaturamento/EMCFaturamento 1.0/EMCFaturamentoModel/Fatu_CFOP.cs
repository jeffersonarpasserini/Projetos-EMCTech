using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_CFOP
    {
        public Fatu_CFOP() { }

        public virtual int idfatu_cfop { get; set; }
        public virtual string nrocfop { get; set; }
        public virtual string descricao { get; set; }
        public virtual string observacao { get; set; }
    }
}
