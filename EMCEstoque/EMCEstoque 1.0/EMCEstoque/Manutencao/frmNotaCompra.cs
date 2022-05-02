using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMCEstoque
{
    public partial class frmNotaCompra : EMCLibrary.EMCForm
    {
        public frmNotaCompra()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void maskedNumber10_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNFItens_Click(object sender, EventArgs e)
        {
            frmNotaCompraItem ofrmitem = new frmNotaCompraItem();
            ofrmitem.ShowDialog();
        }
    }
}
