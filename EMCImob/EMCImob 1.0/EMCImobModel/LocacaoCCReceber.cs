using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoCCReceber
    {
        public LocacaoCCReceber() { }

        public virtual int idLocacaoCCReceber { get; set; }
        public virtual int idLocacaoReceber { get; set; }
        public virtual int idLocacaoContrato { get; set; }
        public virtual Cliente locatario { get; set; }
        public virtual LocacaoProventos provento { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual string tipoProvento { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime dataEmissao { get; set; }
        public virtual DateTime dataLancamento { get; set; }
        public virtual decimal valorLancamento { get; set; }
        /*
         * Campo situacao 
         * 
         * A - Aberto (permite operacoes diversas)
         * G - Gerado (momento em que a parcela ao qual pertence este provento já foi integrada no financeiro)
         */ 
        public virtual string situacao { get; set; }
        public virtual string statusOperacao { get; set; }
    }
}
