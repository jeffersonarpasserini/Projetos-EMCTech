using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class GrupoEmpresa
    {

        public GrupoEmpresa() { }

        public virtual int idGrupoEmpresa { get; set; }
        public virtual string nomeGrupoEmpresa { get; set; }
        public virtual Holding holding { get; set; }
    }
}
