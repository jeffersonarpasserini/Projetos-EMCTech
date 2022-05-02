namespace EMCFinanceiro
{
    partial class frmReceberFormulario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdFormulario = new System.Windows.Forms.DataGridView();
            this.idformulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoformulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdFormulario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboIdContaBancaria = new System.Windows.Forms.ComboBox();
            this.cboTipoFormulario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.txtNroInicial = new System.Windows.Forms.TextBox();
            this.txtNroFinal = new System.Windows.Forms.TextBox();
            this.txtNroAtual = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCarteiraCobranca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboIdLayoutCheque = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFormulario)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFormulario
            // 
            this.grdFormulario.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFormulario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFormulario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFormulario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idformulario,
            this.descricao,
            this.conta,
            this.tipoformulario});
            this.grdFormulario.Location = new System.Drawing.Point(2, 210);
            this.grdFormulario.Name = "grdFormulario";
            this.grdFormulario.ReadOnly = true;
            this.grdFormulario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFormulario.Size = new System.Drawing.Size(629, 161);
            this.grdFormulario.TabIndex = 20;
            this.grdFormulario.DoubleClick += new System.EventHandler(this.grdFormulario_DoubleClick);
            // 
            // idformulario
            // 
            this.idformulario.DataPropertyName = "idformulario";
            this.idformulario.HeaderText = "Id";
            this.idformulario.Name = "idformulario";
            this.idformulario.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // conta
            // 
            this.conta.DataPropertyName = "conta";
            this.conta.HeaderText = "Conta";
            this.conta.Name = "conta";
            this.conta.ReadOnly = true;
            // 
            // tipoformulario
            // 
            this.tipoformulario.DataPropertyName = "tipoformulario";
            this.tipoformulario.HeaderText = "Tipo Formulário";
            this.tipoformulario.Name = "tipoformulario";
            this.tipoformulario.ReadOnly = true;
            this.tipoformulario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tipoformulario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtIdFormulario
            // 
            this.txtIdFormulario.Location = new System.Drawing.Point(9, 91);
            this.txtIdFormulario.Name = "txtIdFormulario";
            this.txtIdFormulario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdFormulario.Size = new System.Drawing.Size(46, 20);
            this.txtIdFormulario.TabIndex = 9;
            this.txtIdFormulario.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFormulario_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(58, 91);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(359, 20);
            this.txtDescricao.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(423, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Conta Bancaria";
            // 
            // cboIdContaBancaria
            // 
            this.cboIdContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdContaBancaria.FormattingEnabled = true;
            this.cboIdContaBancaria.Location = new System.Drawing.Point(423, 91);
            this.cboIdContaBancaria.Name = "cboIdContaBancaria";
            this.cboIdContaBancaria.Size = new System.Drawing.Size(205, 21);
            this.cboIdContaBancaria.TabIndex = 11;
            // 
            // cboTipoFormulario
            // 
            this.cboTipoFormulario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoFormulario.FormattingEnabled = true;
            this.cboTipoFormulario.Location = new System.Drawing.Point(9, 137);
            this.cboTipoFormulario.Name = "cboTipoFormulario";
            this.cboTipoFormulario.Size = new System.Drawing.Size(137, 21);
            this.cboTipoFormulario.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Tipo Formulário";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(236, 122);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "Data Final";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(238, 138);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(88, 20);
            this.txtDataFinal.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Data Inicio";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(147, 138);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(88, 20);
            this.txtDataInicio.TabIndex = 13;
            // 
            // txtNroInicial
            // 
            this.txtNroInicial.Location = new System.Drawing.Point(332, 138);
            this.txtNroInicial.Name = "txtNroInicial";
            this.txtNroInicial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNroInicial.Size = new System.Drawing.Size(97, 20);
            this.txtNroInicial.TabIndex = 15;
            // 
            // txtNroFinal
            // 
            this.txtNroFinal.Location = new System.Drawing.Point(432, 138);
            this.txtNroFinal.Name = "txtNroFinal";
            this.txtNroFinal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNroFinal.Size = new System.Drawing.Size(97, 20);
            this.txtNroFinal.TabIndex = 16;
            // 
            // txtNroAtual
            // 
            this.txtNroAtual.Location = new System.Drawing.Point(531, 138);
            this.txtNroAtual.Name = "txtNroAtual";
            this.txtNroAtual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNroAtual.Size = new System.Drawing.Size(97, 20);
            this.txtNroAtual.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Nro Inicial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(430, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Nro Final";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Nro Atual";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Carteira Cobrança";
            // 
            // txtCarteiraCobranca
            // 
            this.txtCarteiraCobranca.Location = new System.Drawing.Point(9, 184);
            this.txtCarteiraCobranca.Name = "txtCarteiraCobranca";
            this.txtCarteiraCobranca.Size = new System.Drawing.Size(95, 20);
            this.txtCarteiraCobranca.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(430, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Layout Cheque";
            // 
            // cboIdLayoutCheque
            // 
            this.cboIdLayoutCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdLayoutCheque.FormattingEnabled = true;
            this.cboIdLayoutCheque.Location = new System.Drawing.Point(433, 183);
            this.cboIdLayoutCheque.Name = "cboIdLayoutCheque";
            this.cboIdLayoutCheque.Size = new System.Drawing.Size(195, 21);
            this.cboIdLayoutCheque.TabIndex = 19;
            // 
            // frmReceberFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 373);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboIdLayoutCheque);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCarteiraCobranca);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNroAtual);
            this.Controls.Add(this.txtNroFinal);
            this.Controls.Add(this.txtNroInicial);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoFormulario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboIdContaBancaria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdFormulario);
            this.Controls.Add(this.grdFormulario);
            this.Name = "frmReceberFormulario";
            this.Text = "Formulários";
            this.Load += new System.EventHandler(this.frmReceberFormulario_Load);
            this.Controls.SetChildIndex(this.grdFormulario, 0);
            this.Controls.SetChildIndex(this.txtIdFormulario, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboIdContaBancaria, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.cboTipoFormulario, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtDataInicio, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDataFinal, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.txtNroInicial, 0);
            this.Controls.SetChildIndex(this.txtNroFinal, 0);
            this.Controls.SetChildIndex(this.txtNroAtual, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtCarteiraCobranca, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cboIdLayoutCheque, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFormulario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFormulario;
        private System.Windows.Forms.TextBox txtIdFormulario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIdContaBancaria;
        private System.Windows.Forms.ComboBox cboTipoFormulario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.TextBox txtNroInicial;
        private System.Windows.Forms.TextBox txtNroFinal;
        private System.Windows.Forms.TextBox txtNroAtual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCarteiraCobranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn idformulario;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoformulario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboIdLayoutCheque;
    }
}
