using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCBoletosModel
{
    public class CtaBanco
    {

        public CtaBanco() { }

        public virtual int idCtaBancaria { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual int empMaster { get; set; }
        public virtual string descricao { get; set; }
        public virtual string nroAgencia { get; set; }
        public virtual string digAgencia { get; set; }
        public virtual string nroConta { get; set; }
        public virtual string digConta { get; set; }
        public virtual string nroCedente { get; set; }
        public virtual string digCedente { get; set; }
        public virtual string nossoNumero { get; set; }
        public virtual string nroBanco { get; set; }
        public virtual string empRazaoSocial { get; set; }
        public virtual string empCNPJ { get; set; }
        public virtual int seqArqRemessa { get; set; }
        public virtual string cedenteRazao { get; set; }
        public virtual string cedenteCnpj { get; set; }

    }
}
