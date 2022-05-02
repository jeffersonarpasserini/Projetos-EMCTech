using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastroRN;
using EMCCadastroModel;


namespace EMCCadastro
{
    public partial class psqContaCusto : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private Boolean todas = false;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
       

        int vTamMaximo = 0; //tamanho da conta custo no nivel 7
        int vNroNiveis = 0; // numero de niveis
        int vTamNV1 = 0; // tamanho no nivel 1
        int vTamNV2 = 0; // tamanho no nivel 2
        int vTamNV3 = 0; // tamanho no nivel 3
        int vTamNV4 = 0; // tamanho no nivel 4
        int vTamNV5 = 0; // tamanho no nivel 5
        int vTamNV6 = 0; // tamanho no nivel 6
        int vTamNV7 = 0; // tamanho no nivel 7
        string vMascara = "";

        public psqContaCusto()
        {
            InitializeComponent();
        }

        public psqContaCusto(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, Boolean vTodas)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            todas = vTodas;

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
                ContaCustoRN oCtaRN = new ContaCustoRN(Conexao, oOcorrencia,codempresa);

                DataTable dtCon = oCtaRN.pesquisaContaCusto(empMaster, txtCodigoConta.Text, txtContaCusto.Text, todas);
                
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
            retPesquisa.codempresa = empMaster;
            retPesquisa.chaveinterna = EmcResources.cInt(grdPsqCtaReceber.Rows[grdPsqCtaReceber.CurrentRow.Index].Cells["idContaCusto"].Value.ToString());
            retPesquisa.chavebusca = grdPsqCtaReceber.Rows[grdPsqCtaReceber.CurrentRow.Index].Cells["codigoConta"].Value.ToString();
            this.Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            CancelaOperacao();
        }

        public virtual void CancelaOperacao()
        {
            btnPesquisa.Enabled = true;
            btnCancela.Enabled = true;
            btnSair.Enabled = true;
            txtCodigoConta.Focus();
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

        private void psqContaCusto_Load(object sender, EventArgs e)
        {
          
            Parametro oParametro = new Parametro();
            ParametroRN oParametroRN = new ParametroRN(Conexao,oOcorrencia,codempresa);
            //verifica o parametro considera data valida para vencimento de parcelas.
            vTamMaximo = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAMANHO_CONTACUSTO"));
            vNroNiveis = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "NRONIVEIS_CONTACUSTO"));
            vTamNV1 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV1_CONTACUSTO"));
            vTamNV2 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV2_CONTACUSTO"));
            vTamNV3 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV3_CONTACUSTO"));
            vTamNV4 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV4_CONTACUSTO"));
            vTamNV5 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV5_CONTACUSTO"));
            vTamNV6 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV6_CONTACUSTO"));
            vTamNV7 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV7_CONTACUSTO"));

            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, oOcorrencia, codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;

            //define mudar cor do fundo dos campos
            this.ConfigurarFocoComponentes(this);

            //define se campos entram selecionados
            if (this.AutoSelectOnFocus)
            {
                this.DelegateEnterFocus(this);
            }

            this.ActiveControl = txtCodigoConta;
        }

        private void psqContaCusto_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

            if (e.KeyCode == Keys.F12)
                CancelaOperacao();

            if (e.KeyCode == Keys.F8)
                btnPesquisa_Click(null, null);
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
 