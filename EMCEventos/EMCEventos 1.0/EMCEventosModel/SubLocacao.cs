using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEventosModel
{
    public class SubLocacao
    {
        public SubLocacao()
        {
        }

        public virtual int idSublocacao { get; set; }
        public virtual string descricao { get; set; }
        public virtual Evento evento { get; set; }
        public virtual string idBox { get; set; }

    }
}
