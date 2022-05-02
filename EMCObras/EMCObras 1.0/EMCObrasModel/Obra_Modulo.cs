using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCObrasModel
{
    public class Obra_Modulo
    {
        public Obra_Modulo() { }

        public virtual int idobra_modulo { get; set; }
        public virtual Obra_Etapa obra_etapa { get; set; }
        public virtual string descricao { get; set; }

    }
}

