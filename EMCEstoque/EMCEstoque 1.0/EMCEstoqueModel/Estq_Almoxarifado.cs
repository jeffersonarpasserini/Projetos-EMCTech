using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCEstoqueModel
{
    public class Estq_Almoxarifado
    {
        public Estq_Almoxarifado() { }

        public virtual int idestq_almoxarifado { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual string descricao { get; set; }
    }
}

