using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;
using EMCSecurityModel;
using EMCEstoqueModel;


namespace EMCObrasModel
{
    public class Obra
    {
        public Obra() { }

        public virtual int idObra_Cronograma { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual string abreviacao { get; set; }
        public virtual string descricao { get; set; }
        public virtual DateTime dtaInicio { get; set; }
        public virtual DateTime dtaFinal { get; set; }
        public virtual Usuario responsavel_idUsuario { get; set; }
        public virtual Usuario aprovador_idUsuario { get; set; }
        public virtual DateTime dtaCronograma { get; set; }
        public virtual DateTime dtaAprovacao { get; set; }
        public virtual ContaCusto contaCusto { get; set; }
        public virtual Aplicacao aplicacao { get; set; }
        public virtual Pessoa engenheiro { get; set; }
        public virtual string situacao { get; set; }
        public virtual string nroCEI { get; set; }
        public virtual string obraPropria { get; set; }
        public virtual Estq_Almoxarifado almoxarifado { get; set; }
        public virtual Obra_TipoContrato tipoContrato { get; set; }

    }
}
