using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class ReferenciaCliente
    {
        public ReferenciaCliente() { }

        public virtual int idReferencia { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual int idPessoa { get; set; }
        public virtual string tipoReferencia { get; set; }
        public virtual string nome { get; set; }
        public virtual string contato { get; set; }
        public virtual string telefone1 { get; set; }
        public virtual string telefone2 { get; set; }
        public virtual string eMail { get; set; }
    }
}
