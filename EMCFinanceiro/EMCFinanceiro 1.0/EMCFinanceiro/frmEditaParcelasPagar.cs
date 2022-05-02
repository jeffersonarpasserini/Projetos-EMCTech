using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCFinanceiro
{
    public partial class frmEditaParcelasPagar : Form
    {
        public frmEditaParcelasPagar()
        {
            InitializeComponent();
        }
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
   
         public frmEditaParcelasPagar(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao )
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         public void montaTela()
         {
             txtNroParcela.Text = gPagarParcela.nroParcela.ToString();
             txtDataVencimento.Text = gPagarParcela.dataVencimento.ToString();
             txtValorParcela.Text = gPagarParcela.valorParcela.ToString();
             txtValorPagar.Text = gPagarParcela.valorPagar.ToString();
             txtDesconto.Text = gPagarParcela.valorDesconto.ToString();
             txtJuros.Text = gPagarParcela.valorJuros.ToString();
             txtValorTotal.Text = gPagarParcela.valorTotalPagar.ToString();
             txtNominal.Text = gPagarParcela.nominal;

         }

         private void frmEditaParcelasPagar_Load(object sender, EventArgs e)
         {
             montaTela();

             this.ActiveControl = txtDataVencimento;

         }

         private void btnSair_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnSalvar_Click(object sender, EventArgs e)
         {
             gPagarParcela.nroParcela = EmcResources.cInt(txtNroParcela.Text);
             gPagarParcela.valorParcela = Convert.ToDecimal(txtValorParcela.Text);
             gPagarParcela.valorPagar = Convert.ToDecimal(txtValorPagar.Text);
             gPagarParcela.valorDesconto = Convert.ToDecimal(txtDesconto.Text);
             gPagarParcela.valorJuros = Convert.ToDecimal(txtJuros.Text);
             gPagarParcela.valorTotalPagar = Convert.ToDecimal(txtValorTotal.Text);
             gPagarParcela.nominal = txtNominal.Text;

         }

         private void txtValorPagar_Validating(object sender, CancelEventArgs e)
         {
             txtValorTotal.Text = Convert.ToString(EmcResources.cCur(txtValorPagar.Text) - EmcResources.cCur(txtDesconto.Text) + EmcResources.cCur(txtJuros.Text));

         }

         private void txtDesconto_Validating(object sender, CancelEventArgs e)
         {
             txtValorTotal.Text = Convert.ToString(EmcResources.cCur(txtValorPagar.Text) - EmcResources.cCur(txtDesconto.Text) + EmcResources.cCur(txtJuros.Text));
         }

         private void txtJuros_Validating(object sender, CancelEventArgs e)
         {
             txtValorTotal.Text = Convert.ToString(EmcResources.cCur(txtValorPagar.Text) - EmcResources.cCur(txtDesconto.Text) + EmcResources.cCur(txtJuros.Text));
         }




     

    }
}
