using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCEstoqueModel
{
    class Estq_RequisicaoItem
    {
        public virtual int idestq_requisicaoitem { get; set; }
        public virtual int idestq_requisicao { get; set; }
        public virtual int empresa_idEmpresa { get; set; }

        public virtual decimal quantidade { get; set; }
        public virtual decimal valorunitario { get; set; }
        public virtual decimal valortotal { get; set; }
        public virtual string tipoaplicacao { get; set; }
        public virtual int idobra_tarefa { get; set; }
        public virtual int idobra_modulo { get; set; }
        public virtual int idobra_etapa { get; set; }
        public virtual int idestq_movimentacao { get; set; }
        public virtual decimal qtdrecebida { get; set; }
        public virtual int idobra_cronogramaitem { get; set; }

        public virtual Pessoa requisitante { get; set; }
        public virtual Estq_Produto_Lote_Estoque produto { get; set; }
        public virtual string stOperacao { get; set; }

    }
}
