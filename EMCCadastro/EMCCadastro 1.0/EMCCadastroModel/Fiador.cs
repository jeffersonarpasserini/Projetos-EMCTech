using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Fiador
    {
        public Fiador() { }

        public virtual int codEmpresa { get; set; }
        public virtual int? idPessoa { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual string observacao { get; set; }
        public virtual decimal rendimento { get; set; }

    }
}
