using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCObrasModel
{
    public class Obra_Lancamento
    {

        public Obra_Lancamento() { }

        public virtual int idObra_Lancamento { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual Obra obra { get; set; }
        public virtual string nroDocuemnto { get; set; }
        public virtual DateTime dataDocumento { get; set; }
        public virtual DateTime dataEntrada { get; set; }
        public virtual decimal vlrDocumento { get; set; }
        public virtual List<Obra_LancamentoItem> lstItens { get; set; }
        public virtual string status { get; set; }
 
    }
}
