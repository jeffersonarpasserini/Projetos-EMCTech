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
   public partial class tplRelatorio : Form
    {
        //private String usuario = "";
        //private String login = "";
        //private int codempresa = 0;

   #region "metodos do form"
        //public EMCForm(String idUsuario, String seqLogin, string idEmpresa)
        //{
        //    usuario = idUsuario;
        //    login = seqLogin;
        //    codempresa = Convert.ToInt32(idEmpresa);
        //    InitializeComponent();
        //}

        public tplRelatorio()
        {
            InitializeComponent();
        }

        private void tplRelatorio_Load(object sender, EventArgs e)
        {
            //define mudar cor do fundo dos campos
            this.ConfigurarFocoComponentes(this);

            //define se campos entram selecionados
            if (this.AutoSelectOnFocus)
            {
                this.DelegateEnterFocus(this);
            }
        }

        protected virtual void tplRelatorio_KeyDown(object sender, KeyEventArgs e)
        {
            // vamos verificar se o usuário pressionou a tecla F5
               if (e.KeyCode == Keys.Enter)
                    SendKeys.Send("{TAB}");

               if (e.KeyCode == Keys.F2)
               {
                   LimpaCampos();
               }

        }


       #endregion


        #region Metodos dos botões
        public virtual void btnNovo_Click(object sender, EventArgs e)
        {
            //limpa texts para adicionar um novo item
              LimpaCampos();
        }
        public virtual void btnRelatorio_Click(object sender, EventArgs e)
        {
            if  (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public virtual void btnSair_Click(object sender, EventArgs e)
        {
            //fecha o formulario
            this.Close();
        }
        #endregion


        #region Metodos Alteraveis
        public virtual bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag) 
        {
            return true;
        }
        public virtual void Ocorrencia()
        {
            //Chama formulario de ocorrencias passando parametros necessarios.

        }
        public virtual void ImprimeObjeto()
        {

        }
        public virtual void LimpaCampos()
        {

            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                {
                    (c as System.Windows.Forms.Sample.DecimalTextBox).Text = "";
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Text = "";
                }
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                }
                if (c is MaskedTextBox)
                {
                    (c as MaskedTextBox).Text = "";
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Text = "";
                }


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
                        if (c.Controls[i] is ComboBox)
                        {
                            (c.Controls[i] as ComboBox).Text = "";
                        }
                    }
                }

                // dentro de um group box
                if (c is GroupBox)
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
                        if (c.Controls[i] is ComboBox)
                        {
                            (c.Controls[i] as ComboBox).Text = "";
                        }
                    }
                }

                //dentro de tab
                foreach (Control item in c.Controls)
                {
                    if (item.HasChildren)
                    {
                        //LimpaControle(item);
                    }
                    if (item.GetType() == typeof(ComboBox))
                    {
                        ComboBox cbo;
                        cbo = (ComboBox)item;
                        cbo.SelectedIndex = -1;
                    }
                    else if (item.GetType() == typeof(TextBox))
                    {
                        TextBox txt;
                        txt = (TextBox)item;
                        txt.Text = string.Empty;
                    }
                    else if (item.GetType() == typeof(DateTimePicker))
                    {
                        DateTimePicker dtp;
                        dtp = (DateTimePicker)item;
                        dtp.Text = string.Empty;
                    }
                    else if (item.GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                    {
                        System.Windows.Forms.Sample.DecimalTextBox dec;
                        dec = (System.Windows.Forms.Sample.DecimalTextBox)item;
                        dec.Text = String.Empty;

                    }

                }
            }
           
        }

        #endregion


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


