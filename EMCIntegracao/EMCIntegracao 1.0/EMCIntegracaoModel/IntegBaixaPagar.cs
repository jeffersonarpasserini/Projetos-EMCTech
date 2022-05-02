using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCFinanceiroModel;

namespace EMCIntegracaoModel
{
    public class IntegBaixaPagar
    {
        public IntegBaixaPagar() { }

        public virtual int idIntegFinanceiro { get; set; }
        public virtual PagarBaixa idBaixaPagar { get; set; }
        /*
         * Status de Geracao
         * G - Gerado Baixa pelo Financeiro
         * P - Processado a Baixa pelo sistema de Origem
         */
        public virtual string statusBaixa { get; set; }
        /*
         * Auditoria
         */
        public virtual int idUsuarioOrigem { get; set; }
        public virtual DateTime? dataProcessamento { get; set; }
        /*
         * Status de Operacao
         * I - inclusão de uma baixa pelo financeiro
         * P - processamento da baixa no sistema de origem
         * E - estorno da baixa pelo sistema de origem
         * C - cancelamento da inclusão da baixa pelo financeiro.
         */
        public string statusOperacao { get; set; }

    }
}
