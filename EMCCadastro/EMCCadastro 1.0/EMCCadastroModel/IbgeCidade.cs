using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class IbgeCidade
    {
        public IbgeCidade() { }

        public virtual int idIbgeCidade { get; set; }
        public virtual string codigoIbge { get; set; }
        public virtual string nomeCidade { get; set; }
        public virtual Estado estado { get; set; }
    }
}
