using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCImobModel
{
    public class Iptu
    {
        public Iptu() { }

        public virtual int idIptu { get; set; }
        public virtual int idEmpresa { get; set; }
        public virtual Imovel imovel { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual DateTime dataVencimento { get; set; }
        public virtual Decimal valorParcela { get; set; }
        public virtual string observacao { get; set; }
        /*
         * 1 - Imobiliaria paga e cobra Locador
         * 2 - Imobiliaria paga e cobra locatario
         * 3 - Imobiliaria cobra locatario e repassa locador
         */
        public virtual string tipoAcerto { get; set; }
        /*
         * Situação para IPTU - Pagamento Financeiro
         * A - Aberto
         * G - Gerado Financeiro
         * P - Processado Financeiro
         * Q - Quitado
         * C - Cancelado
         */
        public virtual string situacao { get; set; }
        /*
         * Situação para IPTU - Cobrança locador ou locatário
         * 
         * A - Aberto
         * G - Gerado Parcela Contrato
         * 
         */ 
        public virtual string situacaoCobranca { get; set; }
        public virtual string anoBase { get; set; }
        public virtual int idUsuarioExclusao { get; set; }
        public virtual DateTime dataExclusao { get; set; }
        public virtual LocacaoPagar locacaoPagar { get; set; }
        public virtual LocacaoReceber locacaoReceber { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual string diaFixo { get; set; }
        public virtual decimal valorParcelaCarne { get; set; }
        public virtual decimal valorImposto { get; set; }
        public virtual DateTime data1Vencimento { get; set; }
        public virtual int parcelaAno { get; set; }
        public virtual string flag { get; set; }
    }
}
