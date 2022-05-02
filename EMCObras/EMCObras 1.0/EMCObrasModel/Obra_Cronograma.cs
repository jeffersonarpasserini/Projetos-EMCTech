using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;
using EMCEstoqueModel;

namespace EMCObrasModel
{
    public class Obra_Cronograma
    {

        public Obra_Cronograma() { }

        public virtual int idObra_CronogramaItem { get; set; }
        public virtual Obra idObra_Cronograma { get; set; }
        public virtual Obra_Tarefa obra_tarefa { get; set; }
        public virtual DateTime dtaInicioPrevisto { get; set; }
        public virtual DateTime dtaFinalPreveisto { get; set; }
        public virtual int nroDiasPrevisto { get; set; }
        public virtual DateTime? dtaInicio { get; set; }
        public virtual DateTime? dtaFinal { get; set; }
        public virtual int nroDiasRealizado { get; set; }
        public virtual decimal custoPrevisto { get; set; }
        public virtual decimal qtdePrevisto { get; set; }
        public virtual decimal custoUnitarioPrevisto { get; set; }
        public virtual decimal custoRealizado { get; set; }
        public virtual decimal qtdeRealizado { get; set; }
        public virtual decimal custoUnitarioRealizado { get; set; }
        public virtual Estq_Produto_Unidade idUnidadeMedida { get; set; }
        public virtual string atividadeCritica { get; set; }
        // Situação
        // P - Planejado
        // E - Em execução
        // F - Finalizado
        public virtual string situacao { get; set; }

    }
}
