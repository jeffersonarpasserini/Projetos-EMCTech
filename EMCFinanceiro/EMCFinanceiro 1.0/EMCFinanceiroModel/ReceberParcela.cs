using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class ReceberParcela
    {
        public ReceberParcela() { }

        public virtual int? idReceberParcela { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual ReceberDocumento receberDocumento { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual DateTime? dataVencimento { get; set; }
        public virtual DateTime? dataQuitacao { get; set; }
        public virtual Decimal valorParcela { get; set; }
        public virtual Decimal valorJuros { get; set; }
        public virtual Decimal valorDesconto { get; set; }
        public virtual Decimal saldoPagar { get; set; }
        public virtual Decimal saldoPago { get; set; }
        public virtual string situacao { get; set; }
        public virtual TipoCobranca tipoCobranca { get; set; }
        public virtual int cadastro_idusuario { get; set; }
        public virtual DateTime cadastro_datahora { get; set; }
        public virtual Formulario formulario { get; set; }
        public virtual string boleto_NossoNumero { get; set; }
        public virtual string status { get; set; }
        public virtual int idreceberfatura { get; set; }
        public virtual List<ReceberBaixa> baixas { get; set; }
        public virtual decimal jurosPrevisto { get; set; }
        public virtual decimal multaPrevisto { get; set; }
        public virtual DateTime? dtaUltCalculoJuros { get; set; }

        /* Acordo */
        public virtual decimal jurosAcordo { get; set; }
        public virtual decimal multaAcordo { get; set; }
        public virtual decimal descontoAcordo { get; set; }
        public virtual decimal jurosOriginal { get; set; }
        public virtual decimal multaOriginal { get; set; }
        public virtual decimal descontoOriginal { get; set; }
        public virtual decimal idAcordo { get; set; }
        public virtual string situacaoAcordo { get; set; }
        public virtual DateTime? dataLimiteAcordo { get; set; }
        


    }
}
