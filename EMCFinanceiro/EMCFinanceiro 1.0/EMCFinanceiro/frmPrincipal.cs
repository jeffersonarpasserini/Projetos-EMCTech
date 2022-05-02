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
    public partial class frmPrincipal : Form
    {
        ConectaBancoMySql Conexao;

        public frmPrincipal()
        {
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPagarDocumento ofrm = new frmPagarDocumento("1","1","1","1",Conexao);
            ofrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGrdMovBancario ofrm = new frmGrdMovBancario("1", "1", "25", "1", Conexao);
            //frmMovimentoBancario ofrm = new frmMovimentoBancario("1", "1", "1", "1",Conexao);
            ofrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPagarBaixa ofrm = new frmPagarBaixa("1", "1", "25", "1",Conexao);
            ofrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPagarLiberacao ofrm = new frmPagarLiberacao("2", "1", "25", "1", Conexao);
            
            ofrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmReceberFormulario ofrm = new frmReceberFormulario("1", "1", "15", "1", Conexao); 
            ofrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmReceberDocumento ofrm = new frmReceberDocumento("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmReceberBaixa ofrm = new frmReceberBaixa("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmPagarFatura ofrm = new frmPagarFatura("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmEmissaoCheques ofrm = new frmEmissaoCheques("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmReceberFatura ofrm = new frmReceberFatura("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            relCtasPagar ofrm = new relCtasPagar("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            relCtasReceber ofrm = new relCtasReceber("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            relCtasPagas ofrm = new relCtasPagas("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            relCtasRecebidas ofrm = new relCtasRecebidas("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            relChequeEmitidos ofrm = new relChequeEmitidos("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmAbreCaixa ofrm = new frmAbreCaixa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            frmFechaCaixa ofrm = new frmFechaCaixa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            frmConfereCaixa ofrm = new frmConfereCaixa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            frmEmissaoRecibos ofrm = new frmEmissaoRecibos("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void btnTarifa_Click(object sender, EventArgs e)
        {
            frmTarifasBancarias ofrm = new frmTarifasBancarias("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            relCtasPagarBaixa ofrm = new relCtasPagarBaixa("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            frmReceberAcordo ofrm = new frmReceberAcordo("1", "1", "120", "1", Conexao);
            ofrm.Show();
        }

        private void btnIntegracao_Click(object sender, EventArgs e)
        {
            frmIntegracao ofrm = new frmIntegracao("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

     }
}
