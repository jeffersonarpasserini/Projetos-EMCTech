using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class Ocorrencia
    {
        public Ocorrencia() { }
        public virtual int idOcorrencia { get; set; }
        public virtual Aplicativo aplicativo { get; set; }
        public virtual string formulario { get; set; }
        public virtual int seqLogin { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual string tabela { get; set; }
        public virtual string chaveidentificacao { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime data_hora { get; set; }
    }
}
