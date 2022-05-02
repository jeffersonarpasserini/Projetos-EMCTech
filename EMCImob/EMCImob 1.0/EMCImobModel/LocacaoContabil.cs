using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoContabil
    {
        public LocacaoContabil() { }

        public virtual int idLocacaoContabil { get; set; }
        public virtual int idLocacaoContrato { get; set; }
        public virtual LocacaoProventos provento { get; set; }
        public virtual string tipoProvento { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime dataEmissao { get; set; }
        public virtual DateTime dataLancamento { get; set; }
        public virtual decimal valorLancamento { get; set; }
        /*
         * Campo situacao 
         * 
         * A - Aberto (permite operacoes diversas)
         * G - Gerado (momento em que a parcela ao qual pertence este provento já foi integrada na contabilidade)
         */
        public virtual string situacao { get; set; }
        public virtual string statusOperacao { get; set; }
    }
}
