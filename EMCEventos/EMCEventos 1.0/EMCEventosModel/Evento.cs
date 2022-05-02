using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMCImobModel;


namespace EMCEventosModel
{
    public class Evento
    {
        public Evento()
        {

        }

        public virtual int idEvento { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime dataInicio { get; set; }
        public virtual DateTime dataFinal { get; set; }
        public virtual Imovel imovel { get; set; }
        public virtual string statusEvento { get; set; }
        /*
         * D - Disponível
         * R - Reservado
         * C - Confirmado
         */
        public virtual List<Agenda> lstAgenda { get; set; }
        //public virtual string flag { get; set; }
    }
}
