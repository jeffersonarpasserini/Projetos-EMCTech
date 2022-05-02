using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class AutorizadosCliente
    {
        public AutorizadosCliente() { }

        public virtual int idAutorizado { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual int idPessoa { get; set; }
        public virtual string nome { get; set; }
        public virtual string parentesco { get; set; }
    }
}
