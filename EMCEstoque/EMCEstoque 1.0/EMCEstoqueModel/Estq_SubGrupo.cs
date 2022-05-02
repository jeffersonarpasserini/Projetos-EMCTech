using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCEstoqueModel
{
    public class Estq_SubGrupo
    {
        public Estq_SubGrupo() { }

        public virtual int idestq_subgrupo { get; set; }
        public virtual string descricao { get; set; }
        public virtual Estq_Grupo Estq_Grupo { get; set; }
        public virtual Estq_Produto_Unidade Unidade_MenorControle { get; set; }
        public virtual Estq_Produto_Unidade UnidadePadrao { get; set; }
        public virtual Estq_Produto_Unidade UnidadeVenda { get; set; }
        public virtual Estq_Produto_Unidade UnidadeRequisicao { get; set; }
        public virtual Estq_Produto_Unidade UnidadeSolicitacao { get; set; }
        public virtual Estq_Produto_Unidade UnidadeRecebimento { get; set; }
        public virtual Estq_Produto_Unidade UnidadeIndustria { get; set; }
    }
}

