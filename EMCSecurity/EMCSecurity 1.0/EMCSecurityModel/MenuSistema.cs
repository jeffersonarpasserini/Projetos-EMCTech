using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCSecurityModel
{
    public class MenuSistema
    {
        public MenuSistema() { }

        //public virtual int idUsuario { get; set; }
        public virtual string modulo { get; set; }
        public virtual int idMenuSistema { get; set; }
        public virtual string nNamespace { get; set; }
        public virtual string descricao { get; set; }
        public virtual string endereco { get; set; }
        public virtual string urlImagem { get; set; }
        public virtual string exibeImagem { get; set; }
        public virtual string itemSeguranca { get; set; }
        public virtual string indicadorAbertura { get; set; }
        public virtual int ordem { get; set; }
        public virtual int menuPai { get; set; }
        public virtual int nivel { get; set; }
        public virtual string exclusivoJLM { get; set; }
        public virtual int nivelUsuario { get; set; }    

    }
}
