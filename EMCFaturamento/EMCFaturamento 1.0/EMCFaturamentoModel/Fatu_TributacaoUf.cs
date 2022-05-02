using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCFaturamentoModel
{
    public class Fatu_TributacaoUf
    {

        public Fatu_TributacaoUf() { }

        public virtual int idFatu_TributacaoUf { get; set; }
        public virtual Fatu_Tributacao tributacao { get; set; }
        public virtual Fatu_NaturezaOperacao naturezaOperacao { get; set; }
        public virtual string ufOrigem { get; set; }
        public virtual string ufDestino { get; set; }
        public virtual string entradaSaida { get; set; }
        public virtual string tipoTabela { get; set; }
        public virtual string contribuinteICMS { get; set; }
        public virtual string tipoContribuinte { get; set; }
        public virtual double icmsTributado { get; set; }
        public virtual double icmsIsento { get; set; }
        public virtual double icmsOutros { get; set; }
        public virtual string deduzReducao { get; set; }
        public virtual double icmsAliquota { get; set; }
        public virtual double subIcmsTributado { get; set; }
        public virtual double subIcmsAcrescimo { get; set; }
        public virtual double subIcmsAliquota { get; set; }
        public virtual string ipiSomaBase { get; set;  }
        public virtual string ipiSomaBaseSubIcms { get; set; }
        public virtual string situacaoIcms { get; set; }
        public virtual string impRuralTributado { get; set; }
        public virtual double impRuralAliquota { get; set; }
        public virtual string fundepectributado { get; set; }
        public virtual double fundepecaliquota { get; set; }
        public virtual double livrecomerciodesconto { get; set; }
        public virtual Fatu_MotivoIcms motivoDesnoneracaoIcms { get; set; }
        public virtual string codigoAjusteIcms { get; set; }
        public virtual string codigoAjusteIncentivo { get; set; }
        public virtual string ajusteIncentivo { get; set; }
        public virtual string mensagem { get; set; }

    }
}
