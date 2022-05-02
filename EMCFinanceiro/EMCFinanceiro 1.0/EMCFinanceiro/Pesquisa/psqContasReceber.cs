using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastro;


namespace EMCFinanceiro.Pesquisa
{
    public partial class psqContasReceber : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;


        public psqContasReceber()
        {
            InitializeComponent();
        }

        public psqContasReceber(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia pOcorrencia)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;

            retPesquisa.codempresa = codempresa;
            retPesquisa.chavebusca = "";
            retPesquisa.chaveinterna = 0;

            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                ReceberDocumentoRN oRcDocumentoRN = new ReceberDocumentoRN(Conexao, oOcorrencia, codempresa);

                DataTable dtCon = oRcDocumentoRN.pesquisaReceberDocumento(codempresa,
                                                                        empMaster,
                                                                        EmcResources.cInt(txtIdCliente.Text),
                                                                        Convert.ToDateTime(txtDataInicio.Text),
                                                                        Convert.ToDateTime(txtDataFinal.Text),
                                                                        chkTodasContas.Checked,
                                                                        EmcResources.cCur(txtValorInicio.Text),
                                                                        EmcResources.cCur(txtValorFinal.Text),
                                                                        chkValorDocumento.Checked,
                                                                        chkDocumentosAberto.Checked);

                grdPsqCtaReceber.DataSource = dtCon;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdPsqCtaReceber_DoubleClick(object sender, EventArgs e)
        {

            retPesquisa.codempresa = codempresa;
            retPesquisa.chaveinterna = EmcResources.cInt(grdPsqCtaReceber.Rows[grdPsqCtaReceber.CurrentRow.Index].Cells["idreceberdocumento"].Value.ToString());
            retPesquisa.chavebusca = grdPsqCtaReceber.Rows[grdPsqCtaReceber.CurrentRow.Index].Cells["nrodocumento"].Value.ToString();
            this.Close();
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao, oOcorrencia, codempresa);

                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);

                txtCliente.Text = oCliente.pessoa.nome;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, oOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdCliente.Text = "";
            else
                txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdCliente.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void psqContasReceber_KeyDown(object sender, KeyEventArgs e)
        {
            // vamos verificar se o usuário pressionou a tecla F5
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

            if (e.KeyCode == Keys.F8)
                btnPesquisa_Click(null, null);
        }
    }
}
