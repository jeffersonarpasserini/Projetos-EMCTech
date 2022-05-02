using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_TributacaoIPI
    {

        public Fatu_TributacaoIPI() { }

        public virtual int idFatu_TributacaoIPI { get; set; }
        public virtual string descricao { get; set; }
        public virtual double percTributado { get; set; }
        public virtual double percIsento { get; set; }
        public virtual double percOutros { get; set; }
        public virtual double aliquotaIPI { get; set; }
        public virtual Fatu_SituacaoFiscalIPI situacaoIPIEntrada { get; set; }
        public virtual Fatu_SituacaoFiscalIPI situacaoIPISaida { get; set; }

    }
}
