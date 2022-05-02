using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Contato
    {
        public Contato() { }

        public virtual int codEmpresa { get; set; }
        public virtual int idPessoa { get; set; }
        public virtual int codigo { get; set; }
        public virtual string numero { get; set; }
        public virtual string tipoTelefone { get; set; }
        public virtual string eMail { get; set; }
        public virtual string recado { get; set; }


    }
}
