using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroRN;
using EMCCadastroModel;
using EMCSecurityModel;

namespace EMCFinanceiro
{
    public partial class frmEditaParcelas : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;

        public frmEditaParcelas()
        {
            InitializeComponent();
        }

         public frmEditaParcelas(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia pOcorrencia )
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;

            InitializeComponent();
        }

         public void montaTela()
         {
             txtNroParcela.Text = gPagarParcela.nroParcela.ToString();
             txtDataVencimento.Text = gPagarParcela.dataVencimento.ToString();
             txtValorParcela.Text = gPagarParcela.valorParcela.ToString();
             txtNossoNumero.Text = gPagarParcela.nossoNumero.ToString();
             txtCodigoBarras.Text = gPagarParcela.codigoBarras.ToString();
             cboTipoCobranca.SelectedValue = gPagarParcela.tipoCobranca.idTipoCobranca;
             
         }

         private void frmEditaParcelas_Load(object sender, EventArgs e)
         {
             TipoCobrancaRN oCb = new TipoCobrancaRN(Conexao, oOcorrencia, codempresa);
             cboTipoCobranca.DataSource = oCb.ListaTipoCobranca();
             cboTipoCobranca.DisplayMember = "descricao";
             cboTipoCobranca.ValueMember = "idtipocobranca";

             montaTela();

             if (String.IsNullOrEmpty(txtNroParcela.Text) || EmcResources.cInt(txtNroParcela.Text) == 0)
                 txtNroParcela.ReadOnly = false;

             this.ActiveControl = txtDataVencimento;
         }

         private void btnSair_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnSalvar_Click(object sender, EventArgs e)
         {
             if (EmcResources.cInt(txtNroParcela.Text) == 0)
             {
                 MessageBox.Show("Informe o número da nova parcela", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             gPagarParcela.nroParcela = EmcResources.cInt(txtNroParcela.Text);
             gPagarParcela.nossoNumero = txtNossoNumero.Text;
             gPagarParcela.codigoBarras = txtCodigoBarras.Text;
             gPagarParcela.valorParcela = Convert.ToDecimal(txtValorParcela.Text);
             gPagarParcela.dataVencimento = EmcResources.cDate(txtDataVencimento.Text);

             TipoCobrancaRN oCob = new TipoCobrancaRN(Conexao, oOcorrencia, codempresa);
             TipoCobranca oCobr = new TipoCobranca();
             oCobr.idTipoCobranca = EmcResources.cInt(cboTipoCobranca.SelectedValue.ToString());
             gPagarParcela.tipoCobranca = oCob.ObterPor(oCobr);

             if (gPagarParcela.nroLinha == -1)
             {
                 gPagarParcela.status = "I";
                 gPagarParcela.saldoPagar = Convert.ToDecimal(txtValorParcela.Text);
             }
             else
             {
                 gPagarParcela.status = "A";
                 gPagarParcela.saldoPagar = gPagarParcela.valorParcela - gPagarParcela.saldoPago;
             }
         }

     

    }
}
