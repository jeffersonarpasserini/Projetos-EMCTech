using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class ReceberAcordo
    {

        public ReceberAcordo() { }

        public virtual int idAcordo { get; set; }
        public virtual int idEmpresa { get; set; }
        public virtual int idGeradorAcordo { get; set; }
        public virtual string nomeGerador { get; set; }
        public virtual DateTime dataAcordo { get; set; }
        public virtual int idAprovadorAcordo { get; set; }
        public virtual string nomeAprovador { get; set; }
        public virtual DateTime? dataAprovacao { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual DateTime? dataLimite { get; set; }
        /* 
         *Situação Acordo
         *P - Pendente 
         *A - Aprovado
         *C - Cancelado
         */
        public virtual string situacao { get; set; }
        public virtual List<ReceberParcela> lstParcelas { get; set; }
    }
}
