using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class Formulario
    {
        public Formulario() {}

        public virtual int idFormulario { get; set; }
        public virtual CtaBancaria contaBancaria { get; set; }
        public virtual string descricaoFormulario { get; set; }
        public virtual string tipoFormulario { get; set; }
        public virtual string nroInicial { get; set; }
        public virtual string nroFinal { get; set; }
        public virtual string nroAtual { get; set; }
        public virtual DateTime dtaInicio { get; set; }
        public virtual DateTime dtaFinal { get; set; }
        public virtual string carteiraCobranca { get; set; }
        public virtual string situacao { get; set; }
        public virtual LayoutCheque layoutCheque { get; set; }
    }
}
