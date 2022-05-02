using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCCadastroModel;

namespace EMCFinanceiroModel
{
    public class LayoutCheque
    {
        public LayoutCheque() { }

        public virtual int idLayoutCheque { get; set; }
        public virtual Banco idBanco { get; set; }
        public virtual string descricao { get; set; }
        /************ CONFIGURAÇÃO DA IMPRESSAO *************/
        public virtual int tamanhoLinha { get; set; }
        public virtual string valorCompacta { get; set; }
        public virtual string chequeCompacta { get; set; }
        /*********** TAMANHO MAXIMO DOS CAMPOS ***************/
        public virtual int espacoValor { get; set; }
        public virtual int espacoExtenso1 { get; set; }
        public virtual int espacoExtenso2 { get; set; }
        public virtual int espacoNominal { get; set; }
        public virtual int espacoCidade { get; set; }
        public virtual int espacoDia { get; set; }
        public virtual int espacoMes { get; set; }
        public virtual int espacoAno { get; set; }
        public virtual int espacoObservação { get; set; }
        public virtual int espacoPredatado { get; set; }
        /********* SALTOS ANTES DA IMPRESSÃO DO CAMPO *********/
        public virtual int saltoValor { get; set; }
        public virtual int saltoExtenso1 { get; set; }
        public virtual int saltoExtenso2 { get; set; }
        public virtual int saltoNominal { get; set; }
        public virtual int saltoCidade { get; set; }
        public virtual int saltoObservacao { get; set; }
        public virtual int saltoPreDatado { get; set; }
        public virtual int saltoProximaFolha { get; set; }
        /****************** MARGENS **************************/
        public virtual int margemValor { get; set; }
        public virtual int margemExtenso1 { get; set; }
        public virtual int margemExtenso2 { get; set; }
        public virtual int margemNominal { get; set; }
        public virtual int margemCidade { get; set; }
        public virtual int margemObservacao { get; set; }
        public virtual int margemPreDatado { get; set; }

    }
}
