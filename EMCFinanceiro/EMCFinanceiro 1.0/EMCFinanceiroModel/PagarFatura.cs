using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class PagarFatura
    {

        public PagarFatura(){ }

        public virtual int idPagarFatura{get; set;}
        public virtual int codEmpresa { get; set; }
        public virtual DateTime dataFatura { get; set; }
        public virtual decimal valorFatura { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual string numeroDocumento { get; set; }
        public virtual string situacao { get; set; }
        public virtual PagarDocumento pagarDocumento { get; set; }
        public virtual List<PagarParcela> lstParcelas { get; set; }
        public virtual int cadastro_idusuario { get; set; }
        public virtual DateTime cadastro_datahora { get; set; }

    }
}
