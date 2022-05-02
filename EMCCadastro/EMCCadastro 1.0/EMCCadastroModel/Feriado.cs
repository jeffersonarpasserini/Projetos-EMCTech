using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Feriado
    {

        public Feriado() { }

        public virtual int idFeriado { get; set; }
        public virtual DateTime dataFeriado { get; set; }
        public virtual string descricao { get; set; }

        
    }
}
