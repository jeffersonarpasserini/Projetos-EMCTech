using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class AtivoGrupo
    {
        public AtivoGrupo()
        {
        }
        public AtivoGrupo(int id, String vDescricao)
        {

            this.CodAtivoGrupo = id;
            this.Descricao = vDescricao;
        }


        public virtual int CodAtivoGrupo { get; set; }
        public virtual string Descricao { get; set; }
    }
}
