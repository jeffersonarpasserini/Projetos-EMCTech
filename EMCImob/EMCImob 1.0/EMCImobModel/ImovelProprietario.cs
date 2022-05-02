using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class ImovelProprietario
    {
        public ImovelProprietario(){}

        public virtual int idImovelProprietario {get;set;}
        public virtual Imovel idImovel { get; set; }
        //public virtual Fornecedor codEmpresa { get; set; }
        public virtual Fornecedor idProprietario { get; set; }
        public virtual double participacao { get; set; }
        public virtual string representante { get; set; }
        public virtual string flag { get; set; }

    }
}
