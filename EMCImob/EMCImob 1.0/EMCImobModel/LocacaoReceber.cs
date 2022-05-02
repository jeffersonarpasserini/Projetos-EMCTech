using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoReceber
    {

        public LocacaoReceber() { }

        public virtual int idLocacaoReceber { get; set; }
        public virtual int idLocacaoContrato { get; set; }
        public virtual LocacaoContrato contrato { get; set; }
        public virtual Cliente locatario { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual DateTime periodoInicio { get; set; }
        public virtual DateTime periodoFim { get; set; }
        public virtual DateTime dataVencimento { get; set; }
        public virtual int diasCarencia { get; set; }
        public virtual DateTime dataCarencia { get; set; }
        public virtual DateTime? dataIntegracao { get; set; }
        public virtual double percParticipacao { get; set; }
        public virtual decimal valorParcela { get; set; }
        public virtual decimal valorPago { get; set; }
        public virtual decimal valorDesconto { get; set; }
        public virtual decimal valorJuros { get; set; }
        public virtual decimal valorJurosCalculado { get; set; }
        public virtual List<LocacaoCCReceber> lstCtaCorrente { get; set; }
        /*
         * Situacao
         * A - Aberto
         * G - Gerado para o financeiro
         * P - Quitado Financeiro
         */
        public virtual string situacao { get; set; }
        public virtual string statusOperacao { get; set; }


    }
}
