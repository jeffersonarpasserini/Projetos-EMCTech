using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmcMenuModel
{
    public class MenuModel
    {
         public MenuModel() {

        }
        public virtual int idUsuario { get; set; }
        public virtual int idMenuSistema { get; set; }
        public virtual string descricao { get; set; }
        public virtual string nNamespace { get; set; }
        public virtual string endereco { get; set; }
        public virtual string urlimagem { get; set; }
        public virtual string exibeimagem { get; set; }
        public virtual string itemseguranca { get; set; }
        public virtual string indicadorabertura { get; set; }
        public virtual int ordem { get; set; }
        public virtual int menupai { get; set; }
        public virtual int nivel { get; set; }

    }
}
