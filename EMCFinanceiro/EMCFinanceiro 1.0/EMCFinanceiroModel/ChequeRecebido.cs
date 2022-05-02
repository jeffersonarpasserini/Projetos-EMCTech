using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class ChequeRecebido
    {

        public ChequeRecebido() { }

        public virtual int idChequeRecebido { get; set; }
        public virtual DateTime dataCheque { get; set; }
        public virtual DateTime? dataPreDatado { get; set; }
        public virtual decimal valorCheque { get; set; }
        public virtual string nominal { get; set; }
        public virtual string nroCheque { get; set; }
        public virtual Empresa empresa { get; set; }
        public virtual ReceberBaixa receberBaixa { get; set; }
        public virtual Banco banco { get; set; }
        public virtual string nroAgencia { get; set; }
        public virtual string nroConta { get; set; }
        public virtual int idReceberParcela { get; set; }
        public virtual int idMovimentoBancario { get; set; }
        public virtual string compensacao { get; set; }
        public virtual string predatado { get; set; }


    }
}
