using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCSecurityModel
{
    public class UsuarioEmpresa
    {
        public UsuarioEmpresa() { }

        public virtual int idUsuario { get; set; }
        public virtual int idEmpresa { get; set; }
    }
}
