using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using System.Collections;

namespace EMCEstoque
{
    public partial class frmNotaCompraItem : EMCLibrary.EMCForm
    {
        public frmNotaCompraItem()
        {
            InitializeComponent();
        }

        private void frmNotaCompraItem_Load(object sender, EventArgs e)
        {
            //montando combo's
            ArrayList arrEntradaSaida = new ArrayList();
            arrEntradaSaida.Add(new popCombo("1-Item Estoque", "1"));
            arrEntradaSaida.Add(new popCombo("2-Apl.Direta-Cta Custo/Despesa", "2"));
            arrEntradaSaida.Add(new popCombo("3-Apl.Direta-Controle Obras", "3"));
            arrEntradaSaida.Add(new popCombo("4-Apl.Direta-Manut.Eqptos", "4"));


            //cboTipoAplicacao.DataSource = arrEntradaSaida;
            //cboTipoAplicacao.DisplayMember = "nome";
            //cboTipoAplicacao.ValueMember = "valor";
        }
    }
}
