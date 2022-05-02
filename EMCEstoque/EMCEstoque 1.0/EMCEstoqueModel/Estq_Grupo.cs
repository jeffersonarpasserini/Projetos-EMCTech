using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_Grupo
    {
        public Estq_Grupo() { }

        public virtual int idestq_grupo { get; set; }
        public virtual string descricao { get; set; }
        public virtual string faturamentoentrada { get; set; }
        public virtual string faturamentosaida { get; set; }
    }
}

