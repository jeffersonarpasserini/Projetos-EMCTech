using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;



namespace EMCEstoqueModel
{
    class Estq_Requisicao
    {
        public virtual int idestq_requisicao { get; set; }
        public virtual int empresa_idEmpresa{ get; set; }
        public virtual DateTime datarequisicao { get; set; }
        public virtual string tipoaplicacao { get; set; }
        public virtual int idobra_cronograma { get; set; }
        public virtual int idobra_tarefas { get; set; }
        public virtual int idobra_modulo { get; set; }
        public virtual int idobra_etapa { get; set; }
        
        public virtual Pessoa requisitante { get; set; }
        public virtual List<Estq_RequisicaoItem> lstItens { get; set; }

    }
}
