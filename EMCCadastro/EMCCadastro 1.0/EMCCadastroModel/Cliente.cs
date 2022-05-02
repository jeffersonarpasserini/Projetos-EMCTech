using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Cliente
    {
        public Cliente() { }

        public virtual int codEmpresa { get; set; }
        public virtual int? idPessoa { get; set; }
        public virtual Pessoa pessoa { get; set; }
        public virtual string spc { get; set; }
        public virtual string observacao { get; set; }
        public virtual DateTime dataCadastro { get; set; }
        public virtual string microEmpresa { get; set; }
        public virtual string contrIcms { get; set; }
        public virtual string retemISS { get; set; }
        public virtual string alerta1 { get; set; }
        public virtual string avisoAlerta1 { get; set; }
        public virtual string alerta2 { get; set; }
        public virtual string avisoAlerta2 { get; set; }
        public virtual DateTime dtValidadeAlerta { get; set; }
    }
}
