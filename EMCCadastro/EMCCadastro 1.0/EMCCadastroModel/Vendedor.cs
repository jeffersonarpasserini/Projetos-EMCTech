using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Vendedor
    {
        public Vendedor() { }

        public virtual int codEmpresa { get; set; }
        public virtual int idPessoa { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual Decimal taxaComissao { get; set; }
    }
}
