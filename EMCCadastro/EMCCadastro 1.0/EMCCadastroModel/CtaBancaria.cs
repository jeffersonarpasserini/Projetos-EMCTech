using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class CtaBancaria
    {
        public CtaBancaria(int vIdEmpresa, int vIdCtaBancaria, String vDescricao, String vAgencia,
                             String vConta, Banco vBanco, double vLimite, DateTime vVencLimite, 
                             DateTime dtaFechamento, double vlrFechamento, double vSaldoAtual, string agenciaDigito, 
                             string contaDigito, string vCedente, string vCedenteDigito )
        {
            this.codEmpresa = vIdEmpresa;
            this.idCtaBancaria = vIdCtaBancaria;
            this.descricao = vDescricao;
            this.agencia = vAgencia;
            this.conta = vConta;
            this.Banco = vBanco;
            this.limite = vLimite;
            this.VencLimite = vVencLimite;
            this.dataFechamento = dtaFechamento;
            this.sdoFechamento = vlrFechamento;
            this.saldoAtual = vSaldoAtual;
            this.cedente = vCedente;
            this.cedenteDigito = vCedenteDigito;
        }
       
        public CtaBancaria()
        {

        }

        public virtual int codEmpresa { get; set; }
        public virtual int idCtaBancaria { get; set; }
        public virtual string descricao { get; set; }
        public virtual string agencia { get; set; }
        public virtual string agenciaDigito { get; set; }
        public virtual string conta { get; set; }
        public virtual string contaDigito { get; set; }
        public virtual Banco Banco { get; set; }
        public virtual double saldoAtual { get; set; }
        public virtual double limite { get; set; }
        public virtual DateTime? dataFechamento { get; set; }
        public virtual DateTime? VencLimite { get; set; }
        public virtual double sdoFechamento { get; set; }
        public virtual string cedente { get; set; }
        public virtual string cedenteDigito { get; set; }
        public virtual string contaCaixa { get; set; }
    }
}
