using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_SituacaoCofins
    {
        public Fatu_SituacaoCofins() { }

        public virtual int idFatu_SituacaoCofins { get; set; }
        public virtual string codigoFiscal { get; set; }
        public virtual string descricao { get; set; }
    }
}
