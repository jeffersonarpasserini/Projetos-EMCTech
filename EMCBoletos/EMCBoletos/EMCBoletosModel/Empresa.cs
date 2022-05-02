using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCBoletosModel
{
    public class Empresa
    {

        public Empresa() { }

        public virtual int codEmpresa { get; set; }
        public virtual int empMaster { get; set; }
        public virtual string razaoSocial { get; set; }


    }
}
