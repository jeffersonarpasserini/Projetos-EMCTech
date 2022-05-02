using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Custo_Componente
    {
        public Custo_Componente() { }

        public virtual int idcusto_componente { get; set; }
        public virtual Custo_ComponenteGrupo Custo_ComponenteGrupo { get; set; }
        public virtual string descricao { get; set; }
        
    }
}
