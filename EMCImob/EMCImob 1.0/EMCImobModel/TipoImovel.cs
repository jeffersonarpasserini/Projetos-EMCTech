using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class TipoImovel
    {
        public TipoImovel()
        {
        }
        public TipoImovel(int id, String vDescricao)
        {

            this.idTipoImovel = id;
            this.descricao = vDescricao;
        }


        public virtual int idTipoImovel { get; set; }
        public virtual string descricao { get; set; }
    }
}
