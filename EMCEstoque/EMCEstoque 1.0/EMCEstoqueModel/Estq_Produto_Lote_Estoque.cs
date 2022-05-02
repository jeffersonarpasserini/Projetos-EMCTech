using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_Produto_Lote_Estoque
    {
        public Estq_Produto_Lote_Estoque() { }

        public virtual int idProduto_Lote_Estoque { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual Estq_Almoxarifado almoxarifado { get; set; }
        public virtual Estq_Produto_Lote produtoLote { get; set; }
        public virtual double quantidadeAtual { get; set; }
        public virtual double quantidadeAnterior { get; set; }
        public virtual decimal ultimoPrecoPago { get; set; }
        public virtual decimal custoMedio { get; set; }
        public virtual decimal vlrEstoque_CustoMedio { get; set; }
        public virtual decimal vlrEstoque_UltimoPrecoPago { get; set; }
        
    }
}
