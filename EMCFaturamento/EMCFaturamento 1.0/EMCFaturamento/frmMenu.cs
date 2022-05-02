using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCFaturamento
{
    public partial class frmMenu : Form
    {
        ConectaBancoMySql Conexao;

        public frmMenu()
        {
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
            InitializeComponent();
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            frmFatu_SituacaoFiscalIPI ofrm = new frmFatu_SituacaoFiscalIPI("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmFatu_NCM ofrm = new frmFatu_NCM("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFatu_OrigemMercadoria ofrm = new frmFatu_OrigemMercadoria("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmFatu_NaturezaOperacao ofrm = new frmFatu_NaturezaOperacao("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmFatu_SituacaoCofins ofrm = new frmFatu_SituacaoCofins("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmFatu_SituacaoPis ofrm = new frmFatu_SituacaoPis("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmFatu_CFOP ofrm = new frmFatu_CFOP("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmFatu_Tributacao ofrm = new frmFatu_Tributacao("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmFatu_TributacaoIPI ofrm = new frmFatu_TributacaoIPI("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmFatu_MotivoIcms ofrm = new frmFatu_MotivoIcms("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmFatu_TributacaoUf ofrm = new frmFatu_TributacaoUf();
            ofrm.Show();
        }

    }
}
