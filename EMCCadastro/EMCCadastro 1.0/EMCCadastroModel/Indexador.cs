using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Indexador
    {
        public Indexador() { }

        public virtual int idIndexador { get; set; }
        public virtual string descricao { get; set; }
        public virtual string tipoIndexador { get; set; }
        public virtual string simbolo { get; set; }

    }
}
