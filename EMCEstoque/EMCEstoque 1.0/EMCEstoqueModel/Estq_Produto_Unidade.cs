using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_Produto_Unidade
    {
        public Estq_Produto_Unidade() { }

        public virtual int idestq_produto_unidade { get; set; }
        public virtual string unidade_descricao { get; set; }
        public virtual string unidade_abreviatura { get; set; }
    }
}

