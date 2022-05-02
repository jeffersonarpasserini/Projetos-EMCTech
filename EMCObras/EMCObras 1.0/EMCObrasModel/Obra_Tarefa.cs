using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCObrasModel
{
    public class Obra_Tarefa
    {
        public Obra_Tarefa() { }

        public virtual int idobra_tarefas { get; set; }
        public virtual Obra_Etapa obra_etapa { get; set; }
        public virtual Obra_Modulo obra_modulo { get; set; }
        public virtual string descricao { get; set; }

    }
}

