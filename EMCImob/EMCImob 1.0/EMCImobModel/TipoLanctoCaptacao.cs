using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class TipoLanctoCaptacao
    {
        public TipoLanctoCaptacao()
        {
        }
        public TipoLanctoCaptacao(int id, String vDescricao, String vTipoLancamento)
        {

            this.idTipoLanctoCaptacao = id;
            this.Descricao = vDescricao;
            this.TipoLancamento = vTipoLancamento;
        }


        public virtual int idTipoLanctoCaptacao { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string TipoLancamento { get; set; }

    }
}
