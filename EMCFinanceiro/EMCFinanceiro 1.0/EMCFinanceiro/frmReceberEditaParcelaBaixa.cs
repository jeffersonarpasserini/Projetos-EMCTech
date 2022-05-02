using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurityRN;
using EMCSecurityModel;

namespace EMCFinanceiro
{
    public partial class frmReceberEditaParcelaBaixa : Form
    {
        public frmReceberEditaParcelaBaixa()
        {
            InitializeComponent();
        }

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private string tipoJuros = "S";

        public frmReceberEditaParcelaBaixa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = EmcResources.cInt(idEmpresa);
            empMaster = EmcResources.cInt(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         public void montaTela()
         {
             txtNroParcela.Text = gReceberParcela.nroParcela.ToString();
             txtDataVencimento.Text = gReceberParcela.dataVencimento.ToString();
             txtValorParcela.Text = gReceberParcela.valorParcela.ToString();
             txtValorPagar.Text = gReceberParcela.valorPagar.ToString();
             txtDesconto.Text = gReceberParcela.valorDesconto.ToString();
             txtDescontoRecalculo.Text = gReceberParcela.valorDesconto.ToString();
             txtJuros.Text = gReceberParcela.valorJuros.ToString();
             txtJurosRecalculo.Text = gReceberParcela.valorJuros.ToString();
             txtMultaRecalculo.Text = "0";
             txtValorTotal.Text = gReceberParcela.valorTotalPagar.ToString();
             txtValorPagarRecalculo.Text = gReceberParcela.valorTotalPagar.ToString();
             txtNominal.Text = gReceberParcela.nominal;
             txtTaxaJuros.Text = gReceberParcela.txajuros.ToString();
             txtTaxaMulta.Text = gReceberParcela.txamulta.ToString();
             tipoJuros = gReceberParcela.tipoJuros;

         }

         private void frmEditaParcelasPagar_Load(object sender, EventArgs e)
         {
             montaTela();
             this.ActiveControl = txtValorPagar;
         }

         private void btnSair_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnSalvar_Click(object sender, EventArgs e)
         {
             gReceberParcela.nroParcela = EmcResources.cInt(txtNroParcela.Text);
             gReceberParcela.valorParcela = EmcResources.cCur(txtValorParcela.Value.ToString());
             gReceberParcela.valorPagar = EmcResources.cCur(txtValorPagar.Value.ToString());
             gReceberParcela.valorDesconto = EmcResources.cCur(txtDescontoRecalculo.Value.ToString());
             gReceberParcela.valorJuros = EmcResources.cCur( (txtJurosRecalculo.Value+txtMultaRecalculo.Value).ToString());
             gReceberParcela.valorTotalPagar = EmcResources.cCur(txtValorPagarRecalculo.Value.ToString());
             gReceberParcela.nominal = txtNominal.Text;

         }

         private void txtValorPagar_Validating(object sender, CancelEventArgs e)
         {
             try
             {
                 if (!txtValorPagar.Value.Equals(txtValorParcela.Value))
                 {
                     double txaJuros = Math.Abs(EmcResources.taxaMensal2Diaria(EmcResources.cDouble(txtTaxaJuros.Value.ToString())));
                     double txaMulta = EmcResources.cDouble(txtTaxaMulta.Value.ToString()) / 100;

                     txtMultaRecalculo.Text = EmcResources.cCur((EmcResources.cDouble(txtValorPagar.Value.ToString()) * txaMulta).ToString()).ToString();
                     txtJurosRecalculo.Text = EmcResources.calculaJurosParcela(Convert.ToDateTime(txtDataVencimento.DateValue.ToString()), DateTime.Now, EmcResources.cCur(txtValorPagar.Value.ToString()), txaJuros, tipoJuros).ToString();

                     txtDescontoRecalculo.Text = "0";

                     txtValorPagarRecalculo.Text = ((txtValorPagar.Value + txtJurosRecalculo.Value + txtMultaRecalculo.Value) - txtDescontoRecalculo.Value).ToString();
                 }
                 else
                 {
                     txtMultaRecalculo.Text = "0";
                     txtJurosRecalculo.Text = txtJuros.Text;
                     txtDescontoRecalculo.Text = txtDesconto.Text;
                     txtValorPagarRecalculo.Text = txtValorTotal.Text;
                 }

                 txtNominal.Focus();
                 
             }
             catch(Exception oErro)
             {
                 MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }

    }
}
