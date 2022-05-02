using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class FormaPagamento
    {
        public FormaPagamento() { }

        public int idFormaPagamento { get; set; }
        public string descricao { get; set; }
        public Historico historicoPadrao { get; set; }

    }
}
