using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class LocacaoContrato
    {
        public LocacaoContrato() { }

        public virtual int idLocacaoContrato { get; set; }
        public virtual int idEmpresa { get; set; }
        public virtual string identificacaoContrato { get; set; }
        public virtual Imovel imovel { get; set; }
        public virtual DateTime dataContrato { get; set; }
        public virtual DateTime dataInicial { get; set; }
        public virtual DateTime dataFinal { get; set; }
        public virtual Indexador indexador { get; set; }
        public virtual DateTime? dataDesocupacao { get; set; }
        /*
         * A - Aberto - em andamento
         * E - Encerrado
         * C - Cancelado
         */
        public virtual string situacaoContrato { get; set; }
        /*
         * N - Encerrado Normalmente
         * O - Ordem de despejo
         * 
         */ 
        public virtual string situacaoEncerramento { get; set; }
        /*
         * Define quem é responsavel pelo pagamento do iptu
         * P - Proprietário (locador)
         * I - Inquilino (locatário)
         */
        public virtual string pagamentoIptu { get; set; }
        public virtual decimal valorAluguel { get; set; }
        public virtual int nroMeses { get; set; }
        public virtual decimal valorTotalContrato { get; set; }
        public virtual List<LocacaoContabil> lstLocacaoContabil { get; set; }
        public virtual List<LocacaoAnotacao> lstAnotacao { get; set; }
        public virtual List<LocacaoFiador> listaFiadores { get; set; }


        /* ------------------------------------Atributos para cálculo da parte do locatário---------------------------------------------- */
        public virtual Cliente locatarioRepresentante { get; set; }
        public virtual double locatarioRepresentanteParticipacao { get; set; }
        public virtual List<LocacaoCliente> listaLocatarios { get; set; }
        /*
         * Locatario Rateio
         * I - Contrato Individual
         * C - Contrato compartilhado entre varios locatarios
         */
        public virtual string locatarioRateio { get; set; }
        /*
         * Locatario Forma Pagamento
         * A - antecipado - paga a parcela antecipadamente ao beneficio da moradia 
         * N - não antecipado - o locatario habita a residencia e paga no final do periodo aquisitivo
         */
        public virtual string locatarioFormaPagamento { get; set; }
        public virtual int diaFixoLocatario { get; set; }
        public virtual DateTime? dataEntradaInicio { get; set; }
        public virtual DateTime? dataEntradaFinal { get; set; }
        public virtual decimal valorEntrada { get; set; }
        public virtual decimal saldoContratoParcela { get; set; }
        public virtual int nroParcelas { get; set; }
        public virtual decimal valorMensal { get; set; }
        public virtual double taxaJuros { get; set; }
        public virtual double taxaMulta { get; set; }
        public virtual DateTime? dataInicioDesconto { get; set; }
        public virtual DateTime? dataFinalDesconto { get; set; }
        public virtual decimal valorDescontoConcedido { get; set; }
        public virtual DateTime data1Parcela { get; set; }
        public virtual string temCarencia { get; set; }
        public virtual int diasCarencia { get; set; }
        public virtual DateTime data1ParcelaCarencia { get; set; }
        public virtual int diasProporcionais { get; set; }
        public virtual decimal valorProporcional { get; set; }
        public virtual List<LocacaoReceber> lstLocacaoReceber { get; set; }
        public virtual string integraCondominio { get; set; }

        /* ------------------------------------Atributos para cálculo da parte do locador---------------------------------------------- */
        public virtual Fornecedor locadorRepresentante { get; set; }
        public virtual List<LocacaoFornecedor> listaLocadores { get; set; }
        /*
         * Locador Rateio
         * I - Contrato Individual
         * C - Contrato compartilhado entre varios locadores
         */
        public virtual string locadorRateio { get; set; }
        /*
         * Locador Forma Pagamento
         * D - Dia Fixo - Fixa o dia de pagamento do locador
         * N - N Dias Uteis - numero dias uteis após o vencimento da parcela do locatário
         */
        public virtual string locadorFormaPagamento { get; set; }
        public virtual double taxaAdministracao { get; set; }
        public virtual string diaFixoPagamento { get; set; }
        public virtual string nroDiasPagamento { get; set; }
        public virtual string contratoGarantido { get; set; }
        public virtual List<LocacaoPagar> lstLocacaoPagar { get; set; }

        public virtual string statusOperacao { get; set; }

    }
}
