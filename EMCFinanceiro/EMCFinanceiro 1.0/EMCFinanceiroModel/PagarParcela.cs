using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class PagarParcela
    {
        public PagarParcela() { }

        public virtual int? idPagarParcela { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual PagarDocumento pagarDocumento { get; set; }
        public virtual int nroParcela { get; set; }
        public virtual DateTime? dataVencimento { get; set; }
        public virtual DateTime? dataQuitacao { get; set; }
        public virtual Decimal valorParcela { get; set; }
        public virtual Decimal valorCorrecaoMonetaria { get; set; }
        public virtual Decimal valorCMPago { get; set; }
        public virtual Decimal valorJuros { get; set; }
        public virtual Decimal valorDesconto { get; set; }
        public virtual Decimal saldoPagar { get; set; }
        public virtual Decimal saldoPago { get; set; }
        public virtual string situacao { get; set; }
        public virtual string nossoNumero { get; set; }
        public virtual string codigoBarras { get; set; }
        public virtual string status { get; set; }
        public virtual TipoCobranca tipoCobranca { get; set; }
        public virtual int cadastro_idusuario { get; set; }
        public virtual DateTime cadastro_datahora { get; set; }
        public virtual int autorizador_idUsuario { get; set; }
        public virtual int autorizador2_idUsuario { get; set; }
        public virtual string autorizado { get; set; }
        public virtual int idpagarfatura { get; set; }
        public virtual double valorIndexado { get; set; }
        public virtual DateTime dataUltimaCorrecao { get; set; }
        public virtual double valorIndice { get; set; }
        public virtual List<PagarBaixa> baixas { get; set; }
        public virtual decimal jurosPrevisto { get; set; }
        public virtual decimal multaPrevisto { get; set; }
        public virtual DateTime dtaUltCalculoJuros { get; set; }

    }
}
