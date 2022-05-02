using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

public enum MaskedNumberFormat
{
    Peso,
    Valor,
    Moeda,
    Porcentagem,
    Telefone,
    CPF,
    CNPJ,
    CEP,
    Custom
}

namespace MaskedNumber
{
    public partial class MaskedNumber : System.Windows.Forms.TextBox
    {
        #region Construtores
        public MaskedNumber()
        {
            InitializeComponent();
            this.TextAlign = HorizontalAlignment.Right;
            base.KeyPress += new KeyPressEventHandler(MaskedNumber_KeyPress);
            base.LostFocus += new EventHandler(MaskedNumber_LostFocus);
            this.Format = MaskedNumberFormat.Valor;
        }
        #endregion

        #region Eventos
        void MaskedNumber_LostFocus(object sender, EventArgs e)
        {
            this.Refresh();
        }

        void MaskedNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar.ToString())
            {
                case ",":
                case ".":
                    e.KeyChar = ',';
                    if (this.Text.Contains(e.KeyChar.ToString()) == true)
                    {
                        e.Handled = true;
                        e.KeyChar = '0';
                    }
                    break;
                case "+":
                    e.Handled = true;
                    e.KeyChar = '0';

                    if (Format == MaskedNumberFormat.Telefone)
                    {
                        if (!this.Text.Contains("+"))
                        {
                            this.Text = "+" + this.Text;
                            this.SelectionStart = this.Text.Length;
                        }
                    }
                    break;

                case "-":
                    e.Handled = true;
                    e.KeyChar = '0';

                    if (Format == MaskedNumberFormat.Moeda ||
                        Format == MaskedNumberFormat.Valor ||
                        Format == MaskedNumberFormat.Porcentagem ||
                        Format == MaskedNumberFormat.Peso)
                    {
                        if (!this.Text.Contains("-"))
                        {
                            this.Text = "-" + this.Text;
                            this.SelectionStart = this.Text.Length;
                        }
                    }
                    break;
                default:
                    if (!char.IsNumber(e.KeyChar) &&    //numero
                        e.KeyChar != '\b')            //backspace
                    {
                        e.Handled = true;
                        e.KeyChar = '0';
                    }
                    break;
            }
        }

        private void MaskedNumber_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }

        private void MaskedNumber_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }
        #endregion

        #region Propriedades
        private MaskedNumberFormat format;
        private String mCustomFormat = "0:0";
        public String CustomFormat
        {
            get
            {
                if (mCustomFormat == null ||
                    mCustomFormat.Length == 0) mCustomFormat = "0:0";
                return mCustomFormat;
            }
            set
            {
                mCustomFormat = value;
                this.Refresh();
            }
        }

        public MaskedNumberFormat Format
        {
            get { return format; }
            set
            {
                format = value;
                this.Refresh();
            }
        }

        public double Value
        {
            get
            {
                double ret = 0;
                double.TryParse(global::MaskedNumber.Format.OnlyNumbers(base.Text).ToString(), out ret);

                //se começar com ( é numero negativo
                if (Format == MaskedNumberFormat.Moeda && base.Text.StartsWith("("))
                    ret *= -1;
                return ret;
            }
        }

        #endregion

        #region Overrides and New
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Refresh();
            }
        }

        public override void Refresh()
        {
            switch (Format)
            {
                case MaskedNumberFormat.Peso:
                    base.Text = String.Format("{0:n3}", this.Value);
                    break;
                case MaskedNumberFormat.Valor:
                    base.Text = String.Format("{0:n2}", this.Value);
                    break;
                case MaskedNumberFormat.Moeda:
                    base.Text = String.Format("{0:C}", this.Value);
                    break;
                case MaskedNumberFormat.Porcentagem:
                    base.Text = String.Format("{0:P2}", this.Value / 100);
                    break;
                case MaskedNumberFormat.CPF:
                    base.Text = global::MaskedNumber.Format.CPF(Text);
                    break;
                case MaskedNumberFormat.CNPJ:
                    base.Text = global::MaskedNumber.Format.CNPJ(Text);
                    break;
                case MaskedNumberFormat.CEP:
                    base.Text = global::MaskedNumber.Format.CEP(Text);
                    break;
                case MaskedNumberFormat.Telefone:
                    base.Text = global::MaskedNumber.Format.Telefone(Text);
                    break;
                case MaskedNumberFormat.Custom:
                    base.Text = global::MaskedNumber.Format.Custom(Text, CustomFormat);
                    break;
            }

            base.Refresh();
        }
        #endregion

        #region MaskedNumber.Designer.cs
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // MaskedNumber
            //
            this.Size = new System.Drawing.Size(150, 20);
            this.Enter += new System.EventHandler(this.MaskedNumber_Enter);
            this.Click += new System.EventHandler(this.MaskedNumber_Click);
            this.ResumeLayout(false);

        }

        #endregion
        #endregion
    }

    /// <summary>
    /// Classe responsável pelas formatações do componente.
    /// </summary>
    internal static class Format
    {
        /// <summary>
        /// Formata o CNPJ
        /// </summary>
        /// <param name="_cnpj">cnpj a ser formatado</param>
        /// <returns>cnpj formatado</returns>
        public static string CNPJ(string _cnpj)
        {
            MaskedTextProvider mascara;
            //cnpj
            //##.###.###/####-##
            mascara = new MaskedTextProvider(@"00\.000\.000/0000-00");
            mascara.Set(_cnpj);
            return mascara.ToString();
        }

        /// <summary>
        /// Formata o CPF
        /// </summary>
        /// <param name="_cpf">CPF a ser formatado</param>
        /// <returns>cpf formatado</returns>
        public static string CPF(string _cpf)
        {
            MaskedTextProvider mascara;
            //cpf
            //###.###.###-##
            mascara = new MaskedTextProvider(@"000\.000\.000-00");
            mascara.Set(_cpf);
            return mascara.ToString();
        }

        /// <summary>
        /// formata o cep e retorna
        /// </summary>
        /// <param name="_cep">cep a ser formatado</param>
        /// <returns>cep formatado como 00000-000</returns>
        public static string CEP(string _cep)
        {
            _cep = OnlyNumbers(_cep).ToString().Replace("-", "");
            _cep = _cep.ToString(null).PadRight(8, '0');
            return _cep.Substring(0, 5) + "-" + _cep.Substring(5, 3);
        }

        /// <summary>
        /// Formata um número de telefone e retorna o numero formatado
        /// </summary>
        /// <param name="value">número de telefone</param>
        /// <returns>telefone formatado</returns>
        public static string Telefone(string value)
        {
            if (String.IsNullOrEmpty(value)) return "";
            string mascara = "";
            value = value.Trim();
            if (value.StartsWith("0800") ||
                value.StartsWith("0300") ||
                value.StartsWith("0500") ||
                value.StartsWith("0900"))
                mascara = @"0000\-000\-0000";
            else if (value.StartsWith("+"))
                mascara = @"+00\(00\)0000\-0000";
            else if (value.Length == 7)
                mascara = @"000\-0000";
            else if (value.Length == 8)
                mascara = @"0000\-0000";
            else if (value.Length == 10)
                mascara = @"\(00\)0000\-0000";
            else if (value.Length == 11)
                mascara = @"\(000\)0000\-0000";
            else if (value.Length == 12)
                mascara = @"00\(00\)0000\-0000";
            else if (value.Length == 13)
                mascara = @"000\(00\)0000\-0000";
            else
                mascara = "0".PadLeft(value.Length, '0');

            MaskedTextProvider maskProvider;

            maskProvider = new MaskedTextProvider(mascara);
            maskProvider.Set(value);

            if (!maskProvider.MaskCompleted)
                return value;

            return maskProvider.ToString();
        }

        public static string Custom(string Text, string CustomFormat)
        {
            MaskedTextProvider mascara;
            mascara = new MaskedTextProvider(CustomFormat);
            mascara.Set(Text);
            return mascara.ToString();
        }

        /// <summary>
        /// extrair todo caracter não numérico do text, deixando apenas a virgula e os números
        /// <para>Permite número negativo</para>
        /// </summary>
        /// <param name="text">texto a ser tratado</param>
        /// <returns></returns>
        public static object OnlyNumbers(object text)
        {
            bool flagNeg = false;

            if (text == null || text.ToString().Length == 0) return 0;
            string ret = "";

            foreach (char c in text.ToString().ToCharArray())
            {
                if (c.Equals('.') == true || c.Equals(',') == true || char.IsNumber(c) == true)
                    ret += c.ToString();
                else if (c.Equals('-') == true)
                    flagNeg = true;
            }

            if (flagNeg == true) ret = "-" + ret;

            return ret;
        }
    }
}
