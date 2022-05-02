using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;


namespace EMCFinanceiroModel
{
    public class ControleCaixa
    {
        public ControleCaixa() {}

        public virtual int idControleCaixa { get; set; }
        public virtual CtaBancaria contaBancaria { get; set; }
        public virtual DateTime dtHoraAbertura { get; set; }
        public virtual DateTime dtHoraFechamento { get; set; }
        public virtual DateTime dtHoraConferencia { get; set; }
        public virtual Decimal saldoAbertura { get; set; }
        public virtual Decimal saldoFechamento { get; set; }
        public virtual string conferido { get; set; }
        public virtual string fechado { get; set; }
        public virtual int usuarioResponsavel { get; set; }
        public virtual int usuarioConferencia { get; set; }
        public virtual List<MovimentoBancario> lstMovimentoCaixa { get; set; }

    }
}
