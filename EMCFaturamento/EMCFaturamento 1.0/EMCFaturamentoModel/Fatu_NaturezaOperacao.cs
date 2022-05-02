using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_NaturezaOperacao
    {
        public Fatu_NaturezaOperacao() { }

        public virtual int idFatu_NaturezaOperacao { get; set; }
        public virtual string descricao { get; set; }
        public virtual string tipo { get; set; }
        public virtual Fatu_CFOP idCfopEstadual { get; set; }
        public virtual Fatu_CFOP idCfopInterestadual { get; set; }
        public virtual Fatu_CFOP idCfopExterior { get; set; }

    }
}
