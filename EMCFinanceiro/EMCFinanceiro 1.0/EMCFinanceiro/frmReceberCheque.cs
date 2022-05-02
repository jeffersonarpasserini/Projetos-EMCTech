using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFinanceiro.Pesquisa;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;


namespace EMCFinanceiro
{
    public partial class frmReceberCheque : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        private string sTipoCheque = "";

        public frmReceberCheque()
        {
            InitializeComponent();
        }

        public frmReceberCheque(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, string tipoCheque)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            sTipoCheque = tipoCheque;

            List<ChequeRecebido> lstChequeRecebido = new List<ChequeRecebido>();
            chequeRecebido.lstChequeRecebido = lstChequeRecebido;

            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdBanco_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Banco oBanco = new Banco();
                BancoRN oBancoRN = new BancoRN(Conexao, oOcorrencia, codempresa);

                oBanco.idBanco = EmcResources.cInt(txtIdBanco.Text);
                
                oBanco = oBancoRN.ObterPor(oBanco);

                txtBanco.Text = oBanco.descricao;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void btnBanco_Click(object sender, EventArgs e)
        {
            //psqBanco ofrm = new psqBanco(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, oOcorrencia);
            //ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdBanco.Text = "";
            else
                txtIdBanco.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdBanco.Focus();
            SendKeys.Send("{TAB}");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ChequeRecebido oCheque = new ChequeRecebido();
                List<ChequeRecebido> lstChequeRecebido = new List<ChequeRecebido>();

                oCheque.idChequeRecebido = EmcResources.cInt(txtIdChequeRecebido.Text);

                if (sTipoCheque == "PRE")
                    oCheque.dataPreDatado = Convert.ToDateTime(txtDataPreDatado.Text);
                else
                    oCheque.dataPreDatado = null;

                oCheque.dataCheque = Convert.ToDateTime(txtDataEmissao.Text);
                oCheque.valorCheque = EmcResources.cCur(txtValorDocumento.Text);
                oCheque.nominal = txtNominal.Text;
                oCheque.nroCheque = String.Format("{0:0000000}", EmcResources.cInt(txtNroCheque.Text));

                Empresa oEmp = new Empresa();
                oEmp.idEmpresa = codempresa;

                oCheque.empresa = oEmp;
                oCheque.nroAgencia = txtNroAgencia.Text;
                oCheque.nroConta = txtNroConta.Text;

                Banco oBanco = new Banco();
                oBanco.idBanco = EmcResources.cInt(txtIdBanco.Text);

                oCheque.banco = oBanco;

                lstChequeRecebido.Add(oCheque);

                //Atribui no parametro global
                chequeRecebido.lstChequeRecebido = lstChequeRecebido;

                this.Close();

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Cheque : " + oErro.Message);
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            List<ChequeRecebido> lstChequeRecebido = new List<ChequeRecebido>();
            chequeRecebido.lstChequeRecebido = lstChequeRecebido;
            this.Close();
        }

        private void frmReceberCheque_Load(object sender, EventArgs e)
        {
            if (sTipoCheque == "PRE")
            {
                txtDataPreDatado.Enabled = true;
            }
            else
                txtDataPreDatado.Enabled = false;

            
            this.ActiveControl = txtNroCheque;
        }

   
    }
}
