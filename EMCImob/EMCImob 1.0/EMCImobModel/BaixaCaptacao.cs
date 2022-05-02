using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class BaixaCaptacao
    {
        public BaixaCaptacao()
        {
        }


        public virtual int idBaixaCaptacao { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime dataBaixa { get; set; }
        public virtual Decimal valorBaixa { get; set; }
        public virtual List<ContasCaptacao> contasCaptacao { get; set; }
    }
}
