using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoFornecedor
    {
        public LocacaoFornecedor() { }

        public virtual int idLocacaoFornecedor { get; set; }
        public virtual int idLocacaoContrato { get; set; }
        public virtual Fornecedor locador { get; set; }
        public virtual double percParticipacao { get; set; }
        public virtual decimal valorAluguel { get; set; }
        public virtual string situacao { get; set; }
        public virtual string statusOperacao { get; set; }
    }
}
