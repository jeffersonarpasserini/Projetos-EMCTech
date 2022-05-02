using EMCCadastroModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class LocacaoProventos
    {
        public LocacaoProventos()
        {
        }
        
        public LocacaoProventos(int id, String vDescricao, String vTipoProvento, String vIntegraDimob, Aplicacao vIdAplicacao, String vBaseTaxaAdm, String vBaseTaxaAdmCondominio, double vReferencia, String vValorReferencia, String vBaseIrpf, int vRotinaCalculo)
        {
            this.idLocacaoProventos = id;
            this.Descricao = vDescricao;
            this.TipoProvento = vTipoProvento;
            this.IntegraDimob = vIntegraDimob;
            this.aplicacao = vIdAplicacao;
            this.BaseTaxaAdm = vBaseTaxaAdm;
            this.BaseTaxaAdmCondominio = vBaseTaxaAdmCondominio;
            this.Referencia = vReferencia;
            this.ValorReferencia = vValorReferencia;
            this.BaseIrpf = vBaseIrpf;
            this.RotinaCalculo = vRotinaCalculo;
        }        

        public virtual int idLocacaoProventos { get; set; }
        public virtual string Descricao { get; set; }
        /*
         * Tipo Provento
         * D - Debito
         * C - Credito
         * T - Totalizador
         */
        public virtual string TipoProvento { get; set; }
        public virtual string IntegraDimob { get; set; }
        public virtual Aplicacao aplicacao { get; set; }
        public virtual string BaseTaxaAdm { get; set; }
        public virtual string BaseTaxaAdmCondominio { get; set; }
        public virtual double Referencia { get; set; }
        public virtual string ValorReferencia { get; set; }
        public virtual string BaseIrpf { get; set; }
        public virtual int RotinaCalculo { get; set; }

    }
}
