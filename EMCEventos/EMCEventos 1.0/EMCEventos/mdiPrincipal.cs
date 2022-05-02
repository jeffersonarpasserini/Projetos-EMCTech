using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCEventos
{
    public partial class mdiPrincipal : Form
    {
        ConectaBancoMySql Conexao;

        public mdiPrincipal()
        {
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
            InitializeComponent();
        }

        private void mdiPrincipal_Load(object sender, EventArgs e)
        {
            grdAplicacao.Rows.Add("Eventos");
            grdAplicacao.Rows.Add("SubLocacao");
            grdAplicacao.Rows.Add("Contrato");

        }

        private void grdAplicacao_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Form oForm = new Form();
                switch (grdAplicacao.Rows[grdAplicacao.CurrentRow.Index].Cells["aplicacao"].Value.ToString())
                {
                    case ("Eventos"):
                        oForm = new frmEvento("1", "1", "1", "1", Conexao);
                        break;
                    case ("SubLocacao"):
                        oForm = new frmSubLocacao("1", "1", "1", "1", Conexao);
                        break;
                    case ("Contrato"):
                        oForm = new frmContrato("1", "1", "1", "1", Conexao);
                        break;

                }
                oForm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.StackTrace);
            }
        }
    }

}
