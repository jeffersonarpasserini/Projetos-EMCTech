using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_TipoProduto
    {
        public Estq_TipoProduto() { }

        public virtual int idestq_tipoproduto { get; set; }
        public virtual string descricao { get; set; }
        public virtual string controlaestoqueminimo { get; set; }
        public virtual string prestacaoservico { get; set; }
        public virtual string familiaobrigatoria { get; set; }
    }
}

