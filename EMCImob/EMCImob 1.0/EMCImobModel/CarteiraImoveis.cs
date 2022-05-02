using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
   public class CarteiraImoveis
    {
        public CarteiraImoveis()
        {
        }
        public CarteiraImoveis(int id, String vDescricao)
        {

            this.idCarteiraImoveis = id;
            this.Descricao = vDescricao;
        }


        public virtual int idCarteiraImoveis { get; set; }
        public virtual string Descricao { get; set; }
    }
}
