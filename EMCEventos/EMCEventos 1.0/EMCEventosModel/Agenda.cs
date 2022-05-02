using EMCImobModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEventosModel
{
    public class Agenda
    {
        public Agenda()
        {

        }

        public virtual int idAgenda { get; set; }
        public virtual DateTime dataAgenda { get; set; }
        public virtual Imovel imovel { get; set; }
        public virtual Evento evento { get; set; }
        public virtual string situacao { get; set; }
        /*
         * D - Disponível
         * R - Reservado
         * C - Confirmado
         */
        public virtual string flag { get; set; }

    }
}
