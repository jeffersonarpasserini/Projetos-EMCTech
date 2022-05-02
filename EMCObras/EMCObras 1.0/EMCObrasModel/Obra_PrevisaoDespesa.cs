using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCEstoqueModel;
using EMCCadastroModel;

namespace EMCObrasModel
{
    public class Obra_PrevisaoDespesa
    {
        public Obra_PrevisaoDespesa() { }

        public virtual int idObra_PrevisaoDespesa { get; set; }
        public virtual Obra idObra_Cronograma { get; set; }
        public virtual Obra_Cronograma idObra_CronogramaItem { get; set; }
        public virtual Obra_Tarefa idObra_Tarefa { get; set; }
        public virtual Estq_Produto idEstq_Produto { get; set; }
        public virtual double quantidade { get; set; }
        public virtual decimal vlrUnitario { get; set; }
        public virtual decimal vlrDespesa { get; set; }
        public virtual Custo_Componente idCusto_Componente { get; set; }
        public virtual Estq_Produto_Unidade idUnidade { get; set; }

    }
}
