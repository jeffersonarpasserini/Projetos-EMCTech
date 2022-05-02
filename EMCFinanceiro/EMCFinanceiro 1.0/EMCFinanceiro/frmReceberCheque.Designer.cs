namespace EMCFinanceiro
{
    partial class frmReceberCheque
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
            this.txtIdChequeRecebido = new System.Windows.Forms.TextBox();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDataPreDatado = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorDocumento = new System.Windows.Forms.Sample.DecimalTextBox();
            this.txtNroConta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroAgencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBanco = new System.Windows.Forms.Button();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtIdBanco = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIdChequeRecebido);
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 63);
            this.panel1.TabIndex = 5;
            // 
            // txtIdChequeRecebido
            // 
            this.txtIdChequeRecebido.Location = new System.Drawing.Point(484, 22);
            this.txtIdChequeRecebido.Name = "txtIdChequeRecebido";
            this.txtIdChequeRecebido.Size = new System.Drawing.Size(77, 20);
            this.txtIdChequeRecebido.TabIndex = 16;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCFinanceiro.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 15;
            this.btnCancela.Text = "Cancela";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::EMCFinanceiro.Properties.Resources.ImgSalvar;
            this.btnSalvar.Location = new System.Drawing.Point(71, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(68, 58);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCFinanceiro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNominal);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.txtDataPreDatado);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDataEmissao);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtValorDocumento);
            this.panel2.Controls.Add(this.txtNroConta);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtNroAgencia);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnBanco);
            this.panel2.Controls.Add(this.txtBanco);
            this.panel2.Controls.Add(this.txtIdBanco);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNroCheque);
            this.panel2.Location = new System.Drawing.Point(2, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 107);
            this.panel2.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Titular";
            // 
            // txtNominal
            // 
            this.txtNominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNominal.Location = new System.Drawing.Point(327, 72);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(282, 20);
            this.txtNominal.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(234, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 13);
            this.label24.TabIndex = 49;
            this.label24.Text = "Data Pré Datado";
            // 
            // txtDataPreDatado
            // 
            this.txtDataPreDatado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataPreDatado.Location = new System.Drawing.Point(236, 72);
            this.txtDataPreDatado.Name = "txtDataPreDatado";
            this.txtDataPreDatado.Size = new System.Drawing.Size(88, 20);
            this.txtDataPreDatado.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Data Emissão";
            // 
            // txtDataEmissao
            // 
            this.txtDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataEmissao.Location = new System.Drawing.Point(145, 72);
            this.txtDataEmissao.Name = "txtDataEmissao";
            this.txtDataEmissao.Size = new System.Drawing.Size(88, 20);
            this.txtDataEmissao.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Valor Documento";
            // 
            // txtValorDocumento
            // 
            this.txtValorDocumento.Location = new System.Drawing.Point(4, 72);
            this.txtValorDocumento.Name = "txtValorDocumento";
            this.txtValorDocumento.Size = new System.Drawing.Size(139, 20);
            this.txtValorDocumento.TabIndex = 4;
            this.txtValorDocumento.Text = "0,00";
            // 
            // txtNroConta
            // 
            this.txtNroConta.Location = new System.Drawing.Point(507, 27);
            this.txtNroConta.Name = "txtNroConta";
            this.txtNroConta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNroConta.Size = new System.Drawing.Size(102, 20);
            this.txtNroConta.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Conta";
            // 
            // txtNroAgencia
            // 
            this.txtNroAgencia.Location = new System.Drawing.Point(436, 27);
            this.txtNroAgencia.Name = "txtNroAgencia";
            this.txtNroAgencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNroAgencia.Size = new System.Drawing.Size(68, 20);
            this.txtNroAgencia.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Agência";
            // 
            // btnBanco
            // 
            this.btnBanco.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnBanco.Location = new System.Drawing.Point(145, 24);
            this.btnBanco.Name = "btnBanco";
            this.btnBanco.Size = new System.Drawing.Size(31, 23);
            this.btnBanco.TabIndex = 39;
            this.btnBanco.UseVisualStyleBackColor = true;
            this.btnBanco.Click += new System.EventHandler(this.btnBanco_Click);
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(178, 26);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(252, 20);
            this.txtBanco.TabIndex = 38;
            // 
            // txtIdBanco
            // 
            this.txtIdBanco.Location = new System.Drawing.Point(91, 26);
            this.txtIdBanco.Name = "txtIdBanco";
            this.txtIdBanco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdBanco.Size = new System.Drawing.Size(52, 20);
            this.txtIdBanco.TabIndex = 1;
            this.txtIdBanco.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdBanco_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Banco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número Cheque";
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(4, 26);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNroCheque.Size = new System.Drawing.Size(84, 20);
            this.txtNroCheque.TabIndex = 0;
            // 
            // frmReceberCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 181);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmReceberCheque";
            this.Text = "Cheque Recebido";
            this.Load += new System.EventHandler(this.frmReceberCheque_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.TextBox txtIdChequeRecebido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroCheque;
        private System.Windows.Forms.TextBox txtNroConta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroAgencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBanco;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtIdBanco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorDocumento;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker txtDataPreDatado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataEmissao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNominal;
    }
}