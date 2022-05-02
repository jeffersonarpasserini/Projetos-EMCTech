using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class ContaCusto
    {
        public ContaCusto() { }

        public virtual int? idContaCusto { get; set; }
        public virtual string codigoConta { get; set; }
        public virtual string tipoConta { get; set; }
        public virtual ContaCusto contaAcima { get; set; }
        public virtual string descricao { get; set; }
        public virtual Empresa filial { get; set; }
    }
}
