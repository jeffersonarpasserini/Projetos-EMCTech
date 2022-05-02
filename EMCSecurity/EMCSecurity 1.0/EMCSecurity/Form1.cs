using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCSecurity
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
            frmAplicativo ofrm = new frmAplicativo("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUsuario ofrm = new frmUsuario("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMenuSistema ofrm = new frmMenuSistema("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmUsuarioEmpresa ofrm = new frmUsuarioEmpresa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmParametro ofrm = new frmParametro("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMenuUsuario ofrm = new frmMenuUsuario("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmTrocaSenha ofrm = new frmTrocaSenha("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }


    }
}
