using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Cep
    {
        public Cep() { }
        public Cep(String id, String vBairro, String vCidade, String vEstado)
        {

            this.idCep = id;
            this.bairro = vBairro;
            this.cidade = vCidade;
            this.estado = vEstado;
        }

        public virtual string idCep { get; set; }
        public virtual string cidade { get; set; }
        public virtual string estado { get; set; }
        public virtual string bairro { get; set; }
        public virtual string logradouro { get; set; }
        public virtual Cidade cepCidade { get; set; }

    }
}
