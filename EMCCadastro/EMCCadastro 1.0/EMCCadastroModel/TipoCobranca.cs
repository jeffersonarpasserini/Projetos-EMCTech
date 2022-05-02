using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class TipoCobranca
    {
        public TipoCobranca() { }

        public virtual int idTipoCobranca { get; set; }
        public virtual string descricao { get; set; }
        public virtual string abreviatura { get; set; }

    }
}
