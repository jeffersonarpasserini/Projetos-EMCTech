using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCSecurityModel
{
    public class Parametro
    {
        public Parametro() { }

        public virtual int idParametro { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual string aplicacao { get; set; }
        public virtual string sessao { get; set; }
        public virtual string chave { get; set; }
        public virtual string tipo { get; set; }
        public virtual string valor { get; set; }
        public virtual string descricao { get; set; }

    }
}
