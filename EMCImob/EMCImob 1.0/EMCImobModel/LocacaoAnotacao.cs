using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class LocacaoAnotacao
    {
        public LocacaoAnotacao() { }

        public int idLocacaoAnotacao { get; set; }
        public int idLocacaoContrato { get; set; }
        public DateTime dataAnotacao { get; set; }
        public string historico { get; set; }
        public int idUsuario { get; set; }
        public virtual string statusOperacao { get; set; }

    }
}
