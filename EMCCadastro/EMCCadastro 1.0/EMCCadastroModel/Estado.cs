using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Estado
    {
        public Estado() { }

        public virtual string idEstado { get; set; }
        public virtual string nome { get; set; }
        public virtual string abreviatura { get; set; }
    }
}
