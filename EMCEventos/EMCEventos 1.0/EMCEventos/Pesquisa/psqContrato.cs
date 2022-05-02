using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCEventosModel;
using EMCEventosRN;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
namespace EMCEventos
{
    public partial class psqContrato : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;

        public psqContrato()
        {
            InitializeComponent();
        }

        public psqContrato(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia pOcorrencia)
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
                ContratoRN oContratoRN = new ContratoRN(Conexao, oOcorrencia, codempresa);

                DataTable dtCon = oContratoRN.pesquisaContrato(empMaster, EmcResources.cInt(txtIdSubLocacao.Text),
                                                                          EmcResources.cInt(txtIdCliente.Text), 
                                                                          EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), 
                                                                          txtDataInicial.DateValue, 
                                                                          txtDataFinal.DateValue);

                grdPsqContrato.DataSource = dtCon;

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

        private void grdPsqContrato_DoubleClick(object sender, EventArgs e)
        {
            retPesquisa.codempresa = empMaster;
            retPesquisa.chaveinterna = EmcResources.cInt(grdPsqContrato.Rows[grdPsqContrato.CurrentRow.Index].Cells["idevt_contrato"].Value.ToString());
            //retPesquisa.chaveinterna = EmcResources.cInt(grdPsqEvento.Rows[grdPsqEvento.CurrentRow.Index].Cells["idimovel"].Value.ToString());
            //retPesquisa.chavebusca = grdPsqEvento.Rows[grdPsqEvento.CurrentRow.Index].Cells["codigoimovel"].Value.ToString();

            this.Close();

        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            CancelaOperacao();
        }

        private void btnSubLocacao_Click(object sender, EventArgs e)
        {
            try
            {
                psqSubLocacao ofrm = new psqSubLocacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, oOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    txtIdSubLocacao.Text = "";
                }
                else
                {
                    txtIdSubLocacao.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    txtIdSubLocacao.Focus();
                    SendKeys.Send("{TAB}");
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdSubLocacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //SubLocacao objSubLocacao = new SubLocacao();

                if (!String.IsNullOrEmpty(txtIdSubLocacao.Text))
                {
                    SubLocacao oSubLocacao = new SubLocacao();
                    SubLocacaoRN oSubLocRN = new SubLocacaoRN(Conexao, oOcorrencia, codempresa);

                    oSubLocacao.idSublocacao = EmcResources.cInt(txtIdSubLocacao.Text);
                    oSubLocacao = oSubLocRN.ObterPor(oSubLocacao);

                    if (oSubLocacao.idSublocacao == 0)
                    {
                        MessageBox.Show("Sub Locação não encontrado", "Imóvel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdSubLocacao.Text = "";
                        btnSubLocacao.Focus();
                    }
                    else
                    {
                        txtDescSubLocacao.Text = oSubLocacao.descricao;
                        cboFornecedor.SelectedValue = oSubLocacao.evento.imovel.fornecedor.idPessoa;
                        txtDescSubLocacao.Focus();
                        //AtualizaGrid();
                    }
                }
                else
                {
                    btnSubLocacao.Focus();
                }
                //AtualizaGrid(objIptu);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text))
            {
                ClienteRN oClienteRN = new ClienteRN(Conexao, oOcorrencia, empMaster);
                Cliente oCliente = new Cliente();

                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);

                if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtIdCliente.Text = oCliente.idPessoa.ToString();
                    txtRazaoSocial.Text = oCliente.pessoa.nome;

                    txtRazaoSocial.Focus();
                }

            }
            else
            {
                btnCliente.Focus();
            }
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, oOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdCliente.Text = "";
                else
                    txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdCliente_Validating(null, null);
                txtRazaoSocial.Focus();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnFornecedor_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, oOcorrencia);
        //        ofrm.ShowDialog();

        //        if (EMCCadastro.retPesquisa.chaveinterna == 0)
        //            txtIdPessoa.Text = "";
        //        else
        //            txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

        //        txtIdPessoa.Focus();
        //        SendKeys.Send("{TAB}");
        //    }
        //    catch (Exception oErro)
        //    {
        //        MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        //private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(txtIdPessoa.Text))
        //        {
        //            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, oOcorrencia, empMaster);
        //            Fornecedor oFornecedor = new Fornecedor();

        //            oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
        //            oFornecedor.codEmpresa = empMaster;

        //            oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

        //            if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
        //            {
        //                MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                txtIdPessoa.Text = "";
        //                btnFornecedor.Focus();
        //            }
        //            else
        //            {
        //                txtPessoa.Text = oFornecedor.pessoa.nome;
        //                txtPessoa.Focus();
        //            }
        //        }
        //        else
        //        {
        //            btnFornecedor.Focus();
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        MessageBox.Show("Erro Pesquisa : " + erro.Message);
        //    }
        //}

        public virtual void CancelaOperacao()
        {
            btnPesquisa.Enabled = true;
            btnCancela.Enabled = true;
            btnSair.Enabled = true;
            txtIdSubLocacao.Focus();
            LimpaCampos();
        }

        public virtual void LimpaCampos()
        {
            foreach (Control c in Controls)

                //dentro de um Panel
                if (c is Panel)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i].GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                        {
                            (c.Controls[i] as System.Windows.Forms.Sample.DecimalTextBox).Text = "";
                        }
                        if (c.Controls[i] is DateTimePicker)
                        {
                            (c.Controls[i] as DateTimePicker).Text = "";
                        }
                        if (c.Controls[i] is TextBox)
                        {
                            (c.Controls[i] as TextBox).Text = "";
                        }
                        if (c.Controls[i] is MaskedTextBox)
                        {
                            (c.Controls[i] as MaskedTextBox).Text = "";
                        }

                        if (c.Controls[i] is CheckBox)
                        {
                            (c.Controls[i] as CheckBox).Checked = false;
                        }
                    }
                }
        }

        private void psqContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

            if (e.KeyCode == Keys.F12)
                CancelaOperacao();

            if (e.KeyCode == Keys.F8)
                btnPesquisa_Click(null, null);
        }

        private void psqContrato_Load(object sender, EventArgs e)
        {
                   
            //define mudar cor do fundo dos campos
            this.ConfigurarFocoComponentes(this);

            //define se campos entram selecionados
            if (this.AutoSelectOnFocus)
            {
                this.DelegateEnterFocus(this);
            }

            this.ActiveControl = txtIdContrato;


            Fornecedor oFornecedor = new Fornecedor();
            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, oOcorrencia, codempresa);
            oFornecedor.codEmpresa = codempresa;
            cboFornecedor.DataSource = oFornecedorRN.ListaFornecedor(oFornecedor);
            cboFornecedor.ValueMember = "idpessoa";
            cboFornecedor.DisplayMember = "nome";

            //cboFornecedor.SelectedIndex = -1;  

        }

        #region [Metodos para alterar a cor de fundo dos campos quando estiver em foco]

        private bool bolHighlightControlOnFocus = false;
        [Category("Focus")]
        [Description("Define se a cor de fundo de um campo é alterada sempre quando ele estiver em foco.")]
        [DisplayName("HighlightControlOnFocus")]
        public bool HighlightControlOnFocus
        {
            get { return bolHighlightControlOnFocus; }
            set { bolHighlightControlOnFocus = value; }
        }

        private void ConfiguraEnterComponente(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Control controle = (Control)sender;
                if (controle.Enabled)
                {
                    controle.BackColor = Color.LightYellow;
                }
            }
        }

        private void ConfiguraLeaveComponente(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                Control controle = (Control)sender;
                if (controle.Enabled)
                {
                    controle.BackColor = Color.White;
                }
            }
        }

        private void ConfigurarFocoComponentes(Control controle)
        {
            // Configura o Enter e o Leave do componente
            if ((controle is MaskedTextBox) ||
                 (controle is ComboBox) ||
                 (controle is TextBox) ||
                 (controle is RichTextBox) ||
                 (controle is NumericUpDown))
            {
                controle.Enter += this.ConfiguraEnterComponente;
                controle.Leave += this.ConfiguraLeaveComponente;
            }

            if (controle is DateTimePicker)
            {
                controle.Validated += this.ConfiguraLeaveComponente;
            }

            if (controle is ComboBox)
            {
                ComboBox combo = (ComboBox)controle;
                combo.DropDown += this.ConfiguraLeaveComponente;
            }

            // Chamada recursiva para configurar os controles filhos do item atual
            foreach (Control controleFilho in controle.Controls)
            {
                this.ConfigurarFocoComponentes(controleFilho);
            }
        }


        #endregion

        #region [Metodos para definir se os campos ficam selecinados quando ganham foco]
        private bool bolAutoSelectOnFocus;

        [Category("Focus")]
        [Description("Ativa o método de AutoSelect dos campos da interface.")]
        [DisplayName("AutoSelectOnFocus")]
        public bool AutoSelectOnFocus
        {
            get { return bolAutoSelectOnFocus; }
            set { bolAutoSelectOnFocus = value; }
        }

        //___ Seleciona todo o texto de um controle. _______________________________________
        private void SelectText_Enter(object sender, System.EventArgs e)
        {
            // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
            // select no evento "Enter" do foco, que acaba desfazendo a seleção.
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (sender is UpDownBase)
                {
                    ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                }
                else if (sender is TextBoxBase)
                {
                    ((TextBoxBase)sender).SelectAll();
                }
            });
        }


        //__ Associa o evento "SelectText_Enter" a cada um dos campos com texto ____________ 
        private void DelegateEnterFocus(Control ctrl)
        {
            if ((ctrl is UpDownBase) || (ctrl is TextBoxBase))
            {
                ctrl.Enter += SelectText_Enter;
                return;
            }

            // Chamada recursiva para associar o evento a todos os controles da interface
            foreach (Control ctrlChild in ctrl.Controls)
            {
                this.DelegateEnterFocus(ctrlChild);
            }
        }

        #endregion
    }
}
