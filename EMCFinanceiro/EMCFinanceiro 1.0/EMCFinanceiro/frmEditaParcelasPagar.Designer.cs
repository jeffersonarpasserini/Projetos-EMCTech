namespace EMCFinanceiro
{
    partial class frmEditaParcelasPagar
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJuros = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorPagar = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroParcela = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorParcela = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCFinanceiro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(78, 5);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::EMCFinanceiro.Properties.Resources.ImgSalvar;
            this.btnSalvar.Location = new System.Drawing.Point(4, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(68, 58);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNominal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtValorTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtJuros);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtValorPagar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDesconto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNroParcela);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtValorParcela);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDataVencimento);
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 192);
            this.panel1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Valor Final Pagar";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(181, 73);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(152, 20);
            this.txtValorTotal.TabIndex = 96;
            this.txtValorTotal.Text = "0,00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Juros";
            // 
            // txtJuros
            // 
            this.txtJuros.Location = new System.Drawing.Point(181, 115);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.Size = new System.Drawing.Size(152, 20);
            this.txtJuros.TabIndex = 2;
            this.txtJuros.Text = "0,00";
            this.txtJuros.Validating += new System.ComponentModel.CancelEventHandler(this.txtJuros_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Valor Documento Pagar";
            // 
            // txtValorPagar
            // 
            this.txtValorPagar.Location = new System.Drawing.Point(10, 73);
            this.txtValorPagar.Name = "txtValorPagar";
            this.txtValorPagar.Size = new System.Drawing.Size(152, 20);
            this.txtValorPagar.TabIndex = 0;
            this.txtValorPagar.Text = "0,00";
            this.txtValorPagar.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorPagar_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Desconto";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(10, 115);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(152, 20);
            this.txtDesconto.TabIndex = 1;
            this.txtDesconto.Text = "0,00";
            this.txtDesconto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDesconto_Validating);
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
            this.txtNroParcela.TabIndex = 98;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(178, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Valor Documento";
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(181, 26);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.ReadOnly = true;
            this.txtValorParcela.Size = new System.Drawing.Size(152, 20);
            this.txtValorParcela.TabIndex = 97;
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
            this.txtDataVencimento.Size = new System.Drawing.Size(96, 20);
            this.txtDataVencimento.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Nominal";
            // 
            // txtNominal
            // 
            this.txtNominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNominal.Location = new System.Drawing.Point(10, 163);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(323, 20);
            this.txtNominal.TabIndex = 3;
            // 
            // frmEditaParcelasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSalvar);
            this.Name = "frmEditaParcelasPagar";
            this.Text = "Edição Parcelas a Pagar";
            this.Load += new System.EventHandler(this.frmEditaParcelasPagar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Sample.DecimalTextBox txtJuros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorPagar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Sample.DecimalTextBox txtDesconto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroParcela;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorParcela;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataVencimento;
        private System.Windows.Forms.TextBox txtNominal;
        private System.Windows.Forms.Label label7;
    }
}