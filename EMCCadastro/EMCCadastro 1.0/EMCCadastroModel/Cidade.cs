using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Cidade
    {
        public Cidade() { }

        public virtual string cepCidade { get; set; }
        public virtual string nomeCidade { get; set; }
        public virtual IbgeCidade ibgeCidade { get; set; }
    }
}
