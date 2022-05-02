using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_Produto_Volume
    {
        public Estq_Produto_Volume() { }

        public virtual int idestq_produto_volume { get; set; }
        public virtual Estq_Produto Estq_Produto { get; set; }
        public virtual Estq_Produto_Unidade Estq_Produto_Unidade { get; set; }
        public virtual string fatorconversao { get; set; }
        
    }
}

