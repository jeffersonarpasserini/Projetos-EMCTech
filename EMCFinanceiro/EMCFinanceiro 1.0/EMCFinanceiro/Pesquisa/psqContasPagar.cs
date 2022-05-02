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
    public partial class psqContasPagar : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;

        public psqContasPagar()
        {
            InitializeComponent();
        }

        public psqContasPagar(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia pOcorrencia )
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
                PagarDocumentoRN oPgDocumentoRN = new PagarDocumentoRN(Conexao, oOcorrencia, codempresa);

                DataTable dtCon = oPgDocumentoRN.pesquisaPagarDocumento(codempresa, 
                                                                        empMaster, 
                                                                        EmcResources.cInt(txtIdFornecedor.Text), 
                                                                        Convert.ToDateTime(txtDataInicio.Text), 
                                                                        Convert.ToDateTime(txtDataFinal.Text), 
                                                                        chkTodasContas.Checked, 
                                                                        EmcResources.cCur(txtValorInicio.Text), 
                                                                        EmcResources.cCur(txtValorFinal.Text),
                                                                        chkValorDocumento.Checked,
                                                                        chkDocumentosAberto.Checked);

                grdPsqCtaPagar.DataSource = dtCon;

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

        private void grdPsqCtaPagar_DoubleClick(object sender, EventArgs e)
        {

            retPesquisa.codempresa = codempresa;
            retPesquisa.chaveinterna = EmcResources.cInt(grdPsqCtaPagar.Rows[grdPsqCtaPagar.CurrentRow.Index].Cells["idpagardocumento"].Value.ToString());
            retPesquisa.chavebusca = grdPsqCtaPagar.Rows[grdPsqCtaPagar.CurrentRow.Index].Cells["nrodocumento"].Value.ToString();
            this.Close();
        }

        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, oOcorrencia, codempresa);

                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                txtFornecedor.Text = oFornecedor.pessoa.nome;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, oOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdFornecedor.Text = "";
            else
                txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
    
            txtIdFornecedor.Focus();
            SendKeys.Send("{TAB}");

        }

        private void txtIdFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void psqContasPagar_KeyDown(object sender, KeyEventArgs e)
        {
            // vamos verificar se o usuário pressionou a tecla F5
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

            if (e.KeyCode == Keys.F8)
                btnPesquisa_Click(null, null);
            
        }

    }
}
