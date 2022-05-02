using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;
using EMCFaturamentoModel;


namespace EMCEstoqueModel
{
    public class Estq_Produto
    {
        public Estq_Produto() { }

        public virtual int idestq_produto { get; set; }
        public virtual string codigoProduto { get; set; }
        public virtual string descricao { get; set; }
        public virtual string descricaodetalhada { get; set; }
        public virtual string situacao { get; set; }
        public virtual string codigoean { get; set; }
        public virtual Decimal qtde_estoqueminimo { get; set; }
        public virtual Decimal qtde_estoquemaxima { get; set; }
        /* Valor calulado que representa a média ponderada dos custos médios dos lotes de produtos */
        public virtual Decimal custoMedio_Medio { get; set; }
        //
        public virtual Estq_Grupo Estq_Grupo { get; set; }
        public virtual Estq_SubGrupo Estq_SubGrupo { get; set; }
        public virtual Estq_Produto_Unidade Estq_Produto_Unidade { get; set; }
        public virtual Estq_Familia Estq_Familia { get; set; }
        public virtual Estq_TipoProduto Estq_TipoProduto { get; set; }
        public virtual Fornecedor fabricante { get; set; }
        public virtual Custo_Componente componenteCusto { get; set; }
        public virtual Fatu_NCM ncm { get; set; }
        public virtual Fatu_OrigemMercadoria origemMercadoria { get; set; }
        public virtual Fatu_Tributacao tributacao { get; set; }
        public virtual Fatu_TributacaoIPI tributacaoIPI { get; set; }
        

        public virtual List<Estq_Produto_Lote> lstProdutoLote { get; set; }

    }
}

