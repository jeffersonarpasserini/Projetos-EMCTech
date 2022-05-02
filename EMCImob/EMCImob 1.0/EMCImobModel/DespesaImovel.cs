using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class DespesaImovel
    {
        public DespesaImovel() {}

        public virtual int idDespesaImovel { get; set; }
        public virtual Imovel imovel { get; set; }
        public virtual LocacaoProventos locacaoProventos { get; set; }
        public virtual DateTime dataLancamento { get; set; }
        public virtual string historico { get; set; }
        public virtual Decimal valorDespesa { get; set; }
        public virtual DateTime dataAcerto { get; set; }
        public virtual string situacao { get; set; }
        public virtual string descricaoAcerto { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual int idUsuarioExclusao { get; set; }
        public virtual DateTime dataExclusao { get; set; }

    }
}
