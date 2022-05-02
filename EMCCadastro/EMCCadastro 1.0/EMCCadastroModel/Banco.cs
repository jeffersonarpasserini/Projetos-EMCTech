using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Banco
    {
        public Banco()
        {

        }

        public Banco(int id, String descricao) {

            this.idBanco = id;
            this.descricao = descricao;
        }
        public virtual int idBanco { get; set; }
        public virtual string descricao { get; set; }
        public virtual string ordem { get; set; }
    }
    
}
