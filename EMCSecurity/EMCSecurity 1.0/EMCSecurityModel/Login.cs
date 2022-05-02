using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCSecurityModel
{
    public class Login
    {
        public virtual int seqLogin { get; set; }
        public virtual int idUsuario { get; set; }
        public virtual String nome { get; set; }
        public virtual String nivelAcesso { get; set; }
        public virtual DateTime dtaLogin { get; set; }
        public virtual DateTime dtaLogout { get; set; }
        public virtual String macAddress { get; set; }
        public virtual int idEmpresa { get; set; }
        public virtual int empMaster { get; set; }
        public virtual String nomeEmpresa { get; set; }

        public Login() { }


    }
}
