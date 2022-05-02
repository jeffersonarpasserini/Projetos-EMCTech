using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class ImovelComodo
    {
        public ImovelComodo(){}

        public virtual Imovel idImovel { get; set; }
        public virtual Comodo idComodos { get; set; }
        public virtual int nroDepencia { get; set; }
        public virtual string descricao { get; set; }
        public virtual string flag { get; set; }
    }

    
}
