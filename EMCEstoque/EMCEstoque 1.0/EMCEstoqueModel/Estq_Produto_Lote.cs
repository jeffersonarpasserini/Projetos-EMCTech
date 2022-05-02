using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_Produto_Lote
    {
        public Estq_Produto_Lote() { }

        public virtual int idEstq_Produto_lote { get; set; }
        public virtual Estq_Produto Estq_Produto { get; set; }
        public virtual string loteproduto { get; set; }
        public virtual DateTime datavalidade { get; set; }
        public virtual Estq_Embalagem embalagem { get; set; }
        public virtual string descricao { get; set; }
        
    }
}

