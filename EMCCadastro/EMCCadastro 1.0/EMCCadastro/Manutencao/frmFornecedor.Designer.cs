namespace EMCCadastro
{
    partial class frmFornecedor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtTitularConta = new System.Windows.Forms.TextBox();
            this.txtContaCorrente = new System.Windows.Forms.TextBox();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Controls.Add(this.txtTitularConta);
            this.panel1.Controls.Add(this.txtContaCorrente);
            this.panel1.Controls.Add(this.txtAgencia);
            this.panel1.Controls.Add(this.cboBanco);
            this.panel1.Location = new System.Drawing.Point(2, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 251);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Observação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Titular da Conta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Conta Corrente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Agência";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Banco";
            // 
            // txtObservacao
            // 
            this.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacao.Location = new System.Drawing.Point(13, 113);
            this.txtObservacao.MaxLength = 150;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(606, 114);
            this.txtObservacao.TabIndex = 4;
            // 
            // txtTitularConta
            // 
            this.txtTitularConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTitularConta.Location = new System.Drawing.Point(10, 70);
            this.txtTitularConta.MaxLength = 100;
            this.txtTitularConta.Name = "txtTitularConta";
            this.txtTitularConta.ReadOnly = true;
            this.txtTitularConta.Size = new System.Drawing.Size(608, 20);
            this.txtTitularConta.TabIndex = 3;
            // 
            // txtContaCorrente
            // 
            this.txtContaCorrente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContaCorrente.Location = new System.Drawing.Point(345, 24);
            this.txtContaCorrente.MaxLength = 20;
            this.txtContaCorrente.Name = "txtContaCorrente";
            this.txtContaCorrente.Size = new System.Drawing.Size(274, 20);
            this.txtContaCorrente.TabIndex = 2;
            // 
            // txtAgencia
            // 
            this.txtAgencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgencia.Location = new System.Drawing.Point(252, 24);
            this.txtAgencia.MaxLength = 10;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(84, 20);
            this.txtAgencia.TabIndex = 1;
            // 
            // cboBanco
            // 
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(10, 24);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(236, 21);
            this.cboBanco.TabIndex = 0;
            // 
            // frmFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 329);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmFornecedor";
            this.Text = "Fornecedor";
            this.Load += new System.EventHandler(this.frmFornecedor_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtTitularConta;
        private System.Windows.Forms.TextBox txtContaCorrente;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
