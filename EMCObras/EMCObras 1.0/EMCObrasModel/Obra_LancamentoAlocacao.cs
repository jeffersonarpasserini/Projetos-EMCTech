using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCObrasModel
{
    public class Obra_LancamentoAlocacao
    {

        public Obra_LancamentoAlocacao() { }


        public virtual int idAlocacao { get; set; }
        public virtual int idObra_LancamentoItem { get; set; }
        public virtual int idObra_Lancamento { get; set; }
        public virtual int idEmpresa { get; set; }
        public virtual Obra idObra { get; set; }
        public virtual Obra_PrevisaoDespesa previsaoDespesa { get; set; }
        public virtual Obra_Tarefa obraTarefa { get; set; }
        public virtual double percentual { get; set; }
        public virtual decimal valor { get; set; }
        public virtual string status { get; set; }

    }
}
