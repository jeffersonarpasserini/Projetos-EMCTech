using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoFiador
    {
        public LocacaoFiador() { }

        public virtual int idLocacaoFiador { get; set; }
        public virtual int idLocacaoContrato { get; set; }
        public virtual Fiador fiador { get; set; }
        public virtual string observacao { get; set; }
        public virtual string situacao { get; set; }
        public virtual string statusOperacao { get; set; }


    }
}
