using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class TipoDocumento
    {
        public TipoDocumento() { }

        public virtual int idTipoDocumento { get; set; }
        public virtual string descricao { get; set; }
        public virtual string abreviatura { get; set; }

    }
}
