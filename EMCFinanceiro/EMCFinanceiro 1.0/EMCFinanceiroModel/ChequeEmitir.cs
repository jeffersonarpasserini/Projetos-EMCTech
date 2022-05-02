using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class ChequeEmitir
    {

        public ChequeEmitir() { }

        public virtual int idChequeEmitir { get; set; }
        public virtual int idMovimentoBancario {get; set;}
        public virtual Empresa empresa { get; set; }
        public virtual string nroCheque{ get; set; }
        public virtual DateTime dataCheque { get; set; }
        public virtual DateTime dataPreDatado { get; set; }
        public virtual string preDatado { get; set; }
        public virtual Decimal valorCheque { get; set; }
        public virtual string nominal { get; set; }
        public virtual CtaBancaria contaBancaria { get; set; }
        /*
         * A - Aberto
         * C - Compensado
         * X - Cancelado
         */ 
        public virtual string compensacao { get; set; }
        public virtual string historico { get; set; }
        public virtual Formulario formulario { get; set; }
        public virtual List<PagarBaixa> pagarBaixa { get; set; }

    }
}
