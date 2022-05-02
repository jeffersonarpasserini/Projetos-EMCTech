using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class ContasCaptacao
    {   
        public ContasCaptacao()
        {

        }

        public virtual int idContasCaptacao { get; set; }
        public virtual TipoLanctoCaptacao tipoLanctoCaptacao { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual Vendedor vendedor { get; set; }
        public virtual DateTime dataLancamento { get; set; }
        public virtual Decimal valorLancamento { get; set; }
        public virtual string descricao { get; set; }
        public virtual string situacao { get; set; }
        public virtual BaixaCaptacao idBaixaCaptacao { get; set; }
    }
}
