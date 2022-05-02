using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

//*** Utilizado para descrição personalizada do produto para cada cliente ***//

namespace EMCEstoqueModel
{
    public class Estq_Descricao
    {
        public Estq_Descricao() { }
        public virtual int idestq_descricao { get; set; }
        public virtual string descricao { get; set; }
        public virtual Estq_Produto Estq_Produto { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}

