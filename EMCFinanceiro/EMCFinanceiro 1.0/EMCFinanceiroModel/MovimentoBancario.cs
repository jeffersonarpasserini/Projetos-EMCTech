using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class MovimentoBancario
    {
        public MovimentoBancario() { }

        public virtual int idMovimentoBancario { get; set; }
        public virtual int codEmpresa { get; set; }
        public virtual string documento { get; set; }
        public virtual string documentoorigem { get; set; }
        public virtual DateTime dataMovimento { get; set; }
        public virtual DateTime? dataConciliacao { get; set; }
        public virtual CtaBancaria contaBancaria { get; set; }
        public virtual Pessoa pessoa { get; set; }
        /*
         * D - Debito
         * C - Credito 
         * X - Cancelamento Movimento
         * F - Cancelamento Formulário Cheque
         */ 
        public virtual string tipoMovimento { get; set; }
        public virtual Decimal valorDocumento { get; set; }
        public virtual Decimal valorJuros { get; set; }
        public virtual Decimal valorDesconto { get; set; }
        public virtual Decimal valorMovimento { get; set; }
        public virtual Decimal valorMovimentoAnterior { get; set; }
        public virtual Historico idHistorico { get; set; }
        public virtual string historico { get; set; }
        public virtual string nominal { get; set; }
        public virtual string nroCheque { get; set; }
        public virtual string situacao { get; set; }
        public virtual DateTime? dataPreDatado { get; set; }
        public virtual int cadastro_idusuario { get; set; }
        public virtual DateTime cadastro_datahora { get; set; }
        public virtual int idControleCaixa { get; set; }
        public virtual int idRecibo { get; set; }
        

    }
}
