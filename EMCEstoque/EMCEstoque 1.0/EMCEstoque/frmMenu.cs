using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCEstoque
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
            frmEstq_Grupo ofrm = new frmEstq_Grupo("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEstq_SubGrupo ofrm = new frmEstq_SubGrupo("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEstq_Almoxarifado ofrm = new frmEstq_Almoxarifado("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmEstq_Produto_Unidade ofrm = new frmEstq_Produto_Unidade("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmEstq_TipoProduto ofrm = new frmEstq_TipoProduto("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmEstq_Familia ofrm = new frmEstq_Familia("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmEstq_Produto ofrm = new frmEstq_Produto("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmNotaCompra ofrm = new frmNotaCompra();
            ofrm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmEstq_Embalagem ofrm = new frmEstq_Embalagem("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            relProdutos ofrm = new relProdutos("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Relatorios.relFamilia ofrm = new Relatorios.relFamilia("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Relatorios.relEmbalagens ofrm = new Relatorios.relEmbalagens("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Relatorios.relAlmoxarifado ofrm = new Relatorios.relAlmoxarifado("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Relatorios.relUnidade ofrm = new Relatorios.relUnidade("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Relatorios.relTipoProduto ofrm = new Relatorios.relTipoProduto("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Relatorios.relGrupoEstoque ofrm = new Relatorios.relGrupoEstoque("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Relatorios.relSubGrupo ofrm = new Relatorios.relSubGrupo("1", "1", "1", "1", Conexao);
            ofrm.Show();

        }

    }
}
