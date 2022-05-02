using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class Comodo
    {
        public Comodo()
        {
        }
        public Comodo(int id, String vDescricao)
        {

            this.idComodos = id;
            this.descricao = vDescricao;
        }


        public virtual int idComodos { get; set; }
        public virtual string descricao { get; set; }

    }
}
