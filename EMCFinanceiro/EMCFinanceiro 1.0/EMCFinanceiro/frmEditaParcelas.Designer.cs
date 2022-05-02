namespace EMCFinanceiro
{
    partial class frmEditaParcelas
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigoBarras = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoCobranca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNossoNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroParcela = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorParcela = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCFinanceiro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(264, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::EMCFinanceiro.Properties.Resources.ImgSalvar;
            this.btnSalvar.Location = new System.Drawing.Point(190, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(68, 58);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCodigoBarras);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboTipoCobranca);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNossoNumero);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNroParcela);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtValorParcela);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDataVencimento);
            this.panel1.Location = new System.Drawing.Point(5, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 176);
            this.panel1.TabIndex = 13;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(10, 70);
            this.txtCodigoBarras.Mask = "99999.99999  99999.999999  99999.999999  9  99999999999999";
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(328, 20);
            this.txtCodigoBarras.TabIndex = 3;
            this.txtCodigoBarras.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Tipo Cobrança";
            // 
            // cboTipoCobranca
            // 
            this.cboTipoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCobranca.FormattingEnabled = true;
            this.cboTipoCobranca.Location = new System.Drawing.Point(7, 152);
            this.cboTipoCobranca.Name = "cboTipoCobranca";
            this.cboTipoCobranca.Size = new System.Drawing.Size(331, 21);
            this.cboTipoCobranca.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Nosso Número";
            // 
            // txtNossoNumero
            // 
            this.txtNossoNumero.Location = new System.Drawing.Point(7, 109);
            this.txtNossoNumero.Name = "txtNossoNumero";
            this.txtNossoNumero.Size = new System.Drawing.Size(331, 20);
            this.txtNossoNumero.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Código Barras";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Parc";
            // 
            // txtNroParcela
            // 
            this.txtNroParcela.Location = new System.Drawing.Point(10, 26);
            this.txtNroParcela.Name = "txtNroParcela";
            this.txtNroParcela.ReadOnly = true;
            this.txtNroParcela.Size = new System.Drawing.Size(33, 20);
            this.txtNroParcela.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(183, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Valor Documento";
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(186, 29);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.Size = new System.Drawing.Size(152, 20);
            this.txtValorParcela.TabIndex = 2;
            this.txtValorParcela.Text = "0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Vencimento";
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataVencimento.Location = new System.Drawing.Point(66, 26);
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.Size = new System.Drawing.Size(114, 20);
            this.txtDataVencimento.TabIndex = 1;
            // 
            // frmEditaParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 255);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmEditaParcelas";
            this.Text = "Parcelamento";
            this.Load += new System.EventHandler(this.frmEditaParcelas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataVencimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroParcela;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorParcela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipoCobranca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNossoNumero;
        private System.Windows.Forms.MaskedTextBox txtCodigoBarras;
    }
}