using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;


namespace EMCFinanceiroModel
{
    public class Recibo
    {
        public Recibo() { }

        public virtual Empresa empresa { get; set; }
        public virtual int idRecibo { get; set; }
        public virtual DateTime dataEmissao { get; set; }
        public virtual string descricao { get; set; }
        public virtual decimal valorRecibo { get; set; }
        public virtual int idMovimentoBancario { get; set; }
        public virtual int idUsuario { get; set; }
        public virtual DateTime dataRecibo { get; set; }

    }
}
