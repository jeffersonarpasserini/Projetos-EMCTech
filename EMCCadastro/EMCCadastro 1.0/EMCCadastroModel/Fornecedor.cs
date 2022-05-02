using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Fornecedor
    {
        public Fornecedor() { }

        public virtual int codEmpresa { get; set; }
        public virtual int? idPessoa { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual string observacao { get; set; }
        public virtual string agencia { get; set; }
        public virtual string contaCorrente { get; set; }
        public virtual Banco banco { get; set; }
        public virtual DateTime dataCadastro { get; set; }
        public virtual string titularConta { get; set; }
    }
}
