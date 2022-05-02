namespace EMCFinanceiro.Relatorios
{
    partial class relCentroCusto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIdContaCusto = new System.Windows.Forms.TextBox();
            this.ckContaCusto = new System.Windows.Forms.CheckBox();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.txtContaCusto = new System.Windows.Forms.TextBox();
            this.btnContaCusto = new System.Windows.Forms.Button();
            this.grdContaCusto = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedDateTextBox1 = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt1Vencimento = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.codigoconta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGeracao = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContaCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(219, 68);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIdContaCusto);
            this.groupBox3.Controls.Add(this.ckContaCusto);
            this.groupBox3.Controls.Add(this.txtCodigoConta);
            this.groupBox3.Controls.Add(this.txtContaCusto);
            this.groupBox3.Controls.Add(this.btnContaCusto);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(229, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 68);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Centro de Custo";
            // 
            // txtIdContaCusto
            // 
            this.txtIdContaCusto.Location = new System.Drawing.Point(142, 14);
            this.txtIdContaCusto.Name = "txtIdContaCusto";
            this.txtIdContaCusto.Size = new System.Drawing.Size(44, 20);
            this.txtIdContaCusto.TabIndex = 43;
            // 
            // ckContaCusto
            // 
            this.ckContaCusto.AutoSize = true;
            this.ckContaCusto.ForeColor = System.Drawing.Color.Black;
            this.ckContaCusto.Location = new System.Drawing.Point(224, 18);
            this.ckContaCusto.Name = "ckContaCusto";
            this.ckContaCusto.Size = new System.Drawing.Size(106, 17);
            this.ckContaCusto.TabIndex = 42;
            this.ckContaCusto.Text = "Todos as Contas";
            this.ckContaCusto.UseVisualStyleBackColor = true;
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(7, 15);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConta.TabIndex = 3;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtContaCusto
            // 
            this.txtContaCusto.Location = new System.Drawing.Point(7, 41);
            this.txtContaCusto.Name = "txtContaCusto";
            this.txtContaCusto.ReadOnly = true;
            this.txtContaCusto.Size = new System.Drawing.Size(323, 20);
            this.txtContaCusto.TabIndex = 41;
            // 
            // btnContaCusto
            // 
            this.btnContaCusto.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnContaCusto.Location = new System.Drawing.Point(107, 14);
            this.btnContaCusto.Name = "btnContaCusto";
            this.btnContaCusto.Size = new System.Drawing.Size(29, 22);
            this.btnContaCusto.TabIndex = 40;
            this.btnContaCusto.UseVisualStyleBackColor = true;
            // 
            // grdContaCusto
            // 
            this.grdContaCusto.AllowUserToAddRows = false;
            this.grdContaCusto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdContaCusto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdContaCusto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContaCusto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoconta,
            this.descricao,
            this.credito,
            this.debito,
            this.saldo,
            this.idcontacusto});
            this.grdContaCusto.Location = new System.Drawing.Point(4, 97);
            this.grdContaCusto.Name = "grdContaCusto";
            this.grdContaCusto.Size = new System.Drawing.Size(596, 231);
            this.grdContaCusto.TabIndex = 43;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(606, 97);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(541, 231);
            this.dataGridView2.TabIndex = 44;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(4, 349);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1143, 196);
            this.dataGridView3.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Conta Custo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(606, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Aplicação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Documentos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedDateTextBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt1Vencimento);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(567, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 68);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período";
            // 
            // maskedDateTextBox1
            // 
            this.maskedDateTextBox1.DateValue = null;
            this.maskedDateTextBox1.Location = new System.Drawing.Point(30, 41);
            this.maskedDateTextBox1.Mask = "00/00/0000";
            this.maskedDateTextBox1.Name = "maskedDateTextBox1";
            this.maskedDateTextBox1.RequireValidEntry = true;
            this.maskedDateTextBox1.Size = new System.Drawing.Size(77, 20);
            this.maskedDateTextBox1.TabIndex = 624;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 625;
            this.label4.Text = "até";
            // 
            // txt1Vencimento
            // 
            this.txt1Vencimento.DateValue = null;
            this.txt1Vencimento.Location = new System.Drawing.Point(30, 15);
            this.txt1Vencimento.Mask = "00/00/0000";
            this.txt1Vencimento.Name = "txt1Vencimento";
            this.txt1Vencimento.RequireValidEntry = true;
            this.txt1Vencimento.Size = new System.Drawing.Size(77, 20);
            this.txt1Vencimento.TabIndex = 622;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 623;
            this.label20.Text = "De";
            // 
            // codigoconta
            // 
            this.codigoconta.HeaderText = "Conta";
            this.codigoconta.Name = "codigoconta";
            // 
            // descricao
            // 
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            // 
            // credito
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.credito.DefaultCellStyle = dataGridViewCellStyle2;
            this.credito.HeaderText = "Crédito";
            this.credito.Name = "credito";
            // 
            // debito
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.debito.DefaultCellStyle = dataGridViewCellStyle3;
            this.debito.HeaderText = "Débito";
            this.debito.Name = "debito";
            // 
            // saldo
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.saldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            // 
            // idcontacusto
            // 
            this.idcontacusto.HeaderText = "idcontacusto";
            this.idcontacusto.Name = "idcontacusto";
            this.idcontacusto.Visible = false;
            // 
            // btnGeracao
            // 
            this.btnGeracao.Location = new System.Drawing.Point(1062, 30);
            this.btnGeracao.Name = "btnGeracao";
            this.btnGeracao.Size = new System.Drawing.Size(85, 41);
            this.btnGeracao.TabIndex = 50;
            this.btnGeracao.Text = "Processa Informações";
            this.btnGeracao.UseVisualStyleBackColor = true;
            // 
            // relCentroCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1153, 548);
            this.Controls.Add(this.btnGeracao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.grdContaCusto);
            this.Controls.Add(this.groupBox3);
            this.Name = "relCentroCusto";
            this.Text = "Relatório por Centro de Custo";
            this.Load += new System.EventHandler(this.relCentroCusto_Load);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grdContaCusto, 0);
            this.Controls.SetChildIndex(this.dataGridView2, 0);
            this.Controls.SetChildIndex(this.dataGridView3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnGeracao, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContaCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckContaCusto;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;
        private System.Windows.Forms.TextBox txtContaCusto;
        private System.Windows.Forms.Button btnContaCusto;
        private System.Windows.Forms.DataGridView grdContaCusto;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdContaCusto;
        private MaskedDateEntryControl.MaskedDateTextBox maskedDateTextBox1;
        private System.Windows.Forms.Label label4;
        private MaskedDateEntryControl.MaskedDateTextBox txt1Vencimento;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoconta;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn credito;
        private System.Windows.Forms.DataGridViewTextBoxColumn debito;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcontacusto;
        private System.Windows.Forms.Button btnGeracao;
    }
}
