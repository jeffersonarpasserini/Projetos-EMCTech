using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class TarifaBancaria
    {
        public TarifaBancaria() { }

        public virtual int idTarifaBancaria { get; set; }
        public virtual int idEmpresa { get; set; }
        public virtual string nroDocumento { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime dataTarifa { get; set; }
        public virtual Decimal valorTarifa { get; set; }
        public virtual ContaCusto contaCusto { get; set; }
        public virtual Aplicacao aplicacao { get; set; }
        public virtual CtaBancaria contaBancaria { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual PagarDocumento pagarDocumento { get; set; }
        public virtual string autorizado { get; set; }
        public virtual string situacao { get; set; }

    }
}
