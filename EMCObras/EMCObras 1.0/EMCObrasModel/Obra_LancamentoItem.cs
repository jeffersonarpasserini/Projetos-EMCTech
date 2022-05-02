using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCEstoqueModel;

namespace EMCObrasModel
{
    public class Obra_LancamentoItem
    {
        public Obra_LancamentoItem() { }

        public virtual int idObra_LancamentoItem { get; set; }
        public virtual int idObra_Lancamento { get; set; }
        public virtual Estq_Produto idEstq_Produto { get; set; }
        public virtual double quantidade { get; set; }
        public virtual decimal vlrUnitario { get; set; }
        public virtual decimal vlrProduto { get; set; }
        public virtual Estq_Produto_Unidade idUnidadeEntrada { get; set; }
        public virtual List<Obra_LancamentoAlocacao> lstAlocacao { get; set; }
        public virtual double quantidadeEntrada { get; set; }
        public virtual string status { get; set; }

    }
}
