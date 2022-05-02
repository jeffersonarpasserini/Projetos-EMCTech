using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoCliente
    {
        public LocacaoCliente() { }

        public virtual int idLocacaoCliente { get; set; }
        public virtual int idLocacaoContrato { get; set; }
        public virtual Cliente locatario { get; set; }
        public virtual double percParticipacao { get; set; }
        public virtual decimal valorAluguel { get; set; }
        public virtual string representante { get; set; }
        public virtual string situacao { get; set; }
        public virtual string statusOperacao { get; set; }
    }
}
