using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Historico
    {

        public Historico() { }

        public virtual int idHistorico { get; set; }
        public virtual string descricao { get; set; }
        public virtual string exigecomplemento { get; set; }

    }
}
