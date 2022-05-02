using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_Embalagem
    {

        public Estq_Embalagem() { }

        public virtual int idEstq_Embalagem { get; set; }
        public virtual string descricao { get; set; }
        public virtual double quantidade { get; set; }
        public virtual Estq_Produto_Unidade unidade { get; set; }

    }
}
