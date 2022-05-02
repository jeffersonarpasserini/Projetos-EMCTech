using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Indices
    {
        public Indices() { }

        public virtual Indexador indexador { get; set; }
        public virtual int idIndice { get; set; }
        public virtual DateTime dataIndice { get; set; }
        public virtual Decimal valor { get; set; }

    }
}
