using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMCLibrary
{
    public partial class frmGeral : Form
    {
        public frmGeral()
        {
            InitializeComponent();
        }

        public virtual void btnSair_Click(object sender, EventArgs e)
        {
            //fecha o formulario
            this.Close();
        }
    }
}
