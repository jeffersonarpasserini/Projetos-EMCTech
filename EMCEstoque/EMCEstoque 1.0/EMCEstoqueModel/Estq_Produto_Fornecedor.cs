using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCEstoqueModel
{
    public class Estq_Produto_Fornecedor
    {
        public Estq_Produto_Fornecedor() { }

        public virtual int idestq_produto_fornecedor { get; set; }
        public virtual Estq_Produto Estq_Produto { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual string idproduto_fornecedor { get; set; }
    }
}

