using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMCImobModel;
using EMCFinanceiroModel;

namespace EMCIntegracaoModel
{
    public class IntegFinanceiro
    {
        public IntegFinanceiro() { }

        public virtual int idIntegFinanceiro { get; set; }
        public virtual int idEmpresa { get; set; }
        /*
         * Integrações do Sistema de Controle Imobiliario
         * EMCImob
         */
        public virtual LocacaoPagar imob_LocacaoPagar { get; set; }
        public virtual LocacaoReceber imob_LocacaoReceber { get; set; }
        public virtual BaixaCaptacao imob_BaixaCaptacao { get; set; }
        public virtual DespesaImovel imob_DespesaImovel { get; set; }
        public virtual Iptu imob_Iptu { get; set; }
        /*
         * Tipo Integração 
         * R - Contas a Receber
         * P - Contas a Pagar
         */
        public virtual string tipoIntegracao { get; set; }
        public virtual string sistemaOrigem { get; set; }
        /*
         * Nivel de Integracao
         * P - nível de parcela (controla a geracao do documento para o financeiro e os retornos
         *     de pagamentos do financeiro para o documento origem)
         * D - nível de documento (controla somente a geracao do documento para o financeiro )
         */
        public virtual string nivelIntegracao { get; set; }
        /*
         * Status de Geração
         * G - status de gerado do sistema de origem para o financeiro sem que este tenha efetuado a importação do documento
         *     para o seu controle.
         * P - status de processado o documento já foi importado para o controle do financeiro não sendo mais possivel a 
         *     alteração do mesmo no sistema de origem.
         */
        public virtual string statusGeracao { get; set; }
        /*
         * StatusBaixa - verifica o pagamento nofinanceiro a nivel de documento
         * P - Pendente
         * Q - Quitado
         */
        public virtual string statusBaixa { get; set; }
        /*
         * Id de integração do documento de origem no controle financeiro.
         */
        public virtual PagarDocumento idPagarDocumento { get; set; }
        public virtual ReceberDocumento idReceberDocumento { get; set; } 
        /*
         * Id de integração de parcela 
         */
        public virtual PagarParcela idPagarParcela { get; set; }
        public virtual ReceberParcela idReceberParcela { get; set; }
        /*
         * Lista de Baixa a Pagar e a Receber
         */
        public virtual List<IntegBaixaPagar> lstBaixaPagar { get; set; }
        public virtual List<IntegBaixaReceber> lstBaixaReceber { get; set; }
        /*
         * Auditoria
         */
        public virtual int idUsuarioOrigem { get; set; }
        public virtual DateTime dataOrigem { get; set; }
        public virtual int idUsuarioFinanceiro { get; set; }
        public virtual DateTime? dataFinanceiro { get; set; }
        /*
         * Status de Operacao
         * I - inclusão de uma integração pelo sistema origem
         * P - processamento da integracao no financeiro
         * E - estorno da integracao pelo financeiro
         * C - cancelamento da integracao pelo sistema origem
         */
        public string statusOperacao { get; set; }

    }
}
