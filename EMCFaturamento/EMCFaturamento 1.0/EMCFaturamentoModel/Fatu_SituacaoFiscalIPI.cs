using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_SituacaoFiscalIPI
    {
        public Fatu_SituacaoFiscalIPI() { }

        public virtual int idfatu_situacaofiscalipi { get; set; }
        public virtual string codigosituacaoipi { get; set; }
        public virtual string descricao { get; set; }
        public virtual string entradasaida { get; set; }
    }
}
