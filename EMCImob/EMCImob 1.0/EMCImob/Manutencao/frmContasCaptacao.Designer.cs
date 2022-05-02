namespace EMCImob
{
    partial class frmContasCaptacao
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVendedor_IdPessoa = new System.Windows.Forms.TextBox();
            this.cboIdVendedor = new System.Windows.Forms.ComboBox();
            this.grdContasCaptacao = new System.Windows.Forms.DataGridView();
            this.idContasCaptacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datalancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoLanctoCaptacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorLancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFiltrarLancamentos = new System.Windows.Forms.Button();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataInicial = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorLancamento = new System.Windows.Forms.Sample.DecimalTextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cboTipoLanctoCaptacao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataLancamento = new System.Windows.Forms.DateTimePicker();
            this.txtIdContasCaptacao = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContasCaptacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtVendedor_IdPessoa);
            this.panel2.Controls.Add(this.cboIdVendedor);
            this.panel2.Location = new System.Drawing.Point(2, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 55);
            this.panel2.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 24);
            this.label9.TabIndex = 37;
            this.label9.Text = "Vendedor";
            // 
            // txtVendedor_IdPessoa
            // 
            this.txtVendedor_IdPessoa.Location = new System.Drawing.Point(107, 23);
            this.txtVendedor_IdPessoa.Name = "txtVendedor_IdPessoa";
            this.txtVendedor_IdPessoa.Size = new System.Drawing.Size(54, 20);
            this.txtVendedor_IdPessoa.TabIndex = 8;
            this.txtVendedor_IdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVendedor_IdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtVendedor_IdPessoa_Validating);
            // 
            // cboIdVendedor
            // 
            this.cboIdVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboIdVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIdVendedor.FormattingEnabled = true;
            this.cboIdVendedor.Location = new System.Drawing.Point(165, 22);
            this.cboIdVendedor.Name = "cboIdVendedor";
            this.cboIdVendedor.Size = new System.Drawing.Size(326, 21);
            this.cboIdVendedor.TabIndex = 9;
            this.cboIdVendedor.SelectedValueChanged += new System.EventHandler(this.cboIdVendedor_SelectedValueChanged);
            // 
            // grdContasCaptacao
            // 
            this.grdContasCaptacao.AllowUserToAddRows = false;
            this.grdContasCaptacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContasCaptacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idContasCaptacao,
            this.datalancamento,
            this.TipoLanctoCaptacao,
            this.tipomovimento,
            this.descricao,
            this.ValorLancamento,
            this.Situacao});
            this.grdContasCaptacao.Location = new System.Drawing.Point(2, 195);
            this.grdContasCaptacao.MultiSelect = false;
            this.grdContasCaptacao.Name = "grdContasCaptacao";
            this.grdContasCaptacao.ReadOnly = true;
            this.grdContasCaptacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdContasCaptacao.Size = new System.Drawing.Size(796, 272);
            this.grdContasCaptacao.TabIndex = 4;
            // 
            // idContasCaptacao
            // 
            this.idContasCaptacao.DataPropertyName = "idContasCaptacao";
            this.idContasCaptacao.HeaderText = "idContasCaptacao";
            this.idContasCaptacao.Name = "idContasCaptacao";
            this.idContasCaptacao.ReadOnly = true;
            this.idContasCaptacao.Visible = false;
            // 
            // datalancamento
            // 
            this.datalancamento.DataPropertyName = "datalancamento";
            this.datalancamento.HeaderText = "Data Movimento";
            this.datalancamento.Name = "datalancamento";
            this.datalancamento.ReadOnly = true;
            // 
            // TipoLanctoCaptacao
            // 
            this.TipoLanctoCaptacao.DataPropertyName = "TipoLanctoCaptacao";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.TipoLanctoCaptacao.DefaultCellStyle = dataGridViewCellStyle1;
            this.TipoLanctoCaptacao.HeaderText = "Tipo Lançamento";
            this.TipoLanctoCaptacao.Name = "TipoLanctoCaptacao";
            this.TipoLanctoCaptacao.ReadOnly = true;
            // 
            // tipomovimento
            // 
            this.tipomovimento.DataPropertyName = "tipomovimento";
            this.tipomovimento.HeaderText = "D/C";
            this.tipomovimento.Name = "tipomovimento";
            this.tipomovimento.ReadOnly = true;
            this.tipomovimento.Width = 30;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // ValorLancamento
            // 
            this.ValorLancamento.DataPropertyName = "ValorLancamento";
            this.ValorLancamento.HeaderText = "Valor";
            this.ValorLancamento.Name = "ValorLancamento";
            this.ValorLancamento.ReadOnly = true;
            // 
            // Situacao
            // 
            this.Situacao.DataPropertyName = "Situacao";
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            this.Situacao.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFiltrarLancamentos);
            this.panel1.Controls.Add(this.txtDataFinal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDataInicial);
            this.panel1.Location = new System.Drawing.Point(506, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 55);
            this.panel1.TabIndex = 5;
            // 
            // btnFiltrarLancamentos
            // 
            this.btnFiltrarLancamentos.Location = new System.Drawing.Point(237, 18);
            this.btnFiltrarLancamentos.Name = "btnFiltrarLancamentos";
            this.btnFiltrarLancamentos.Size = new System.Drawing.Size(48, 22);
            this.btnFiltrarLancamentos.TabIndex = 42;
            this.btnFiltrarLancamentos.Text = "Filtrar";
            this.btnFiltrarLancamentos.UseVisualStyleBackColor = true;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(151, 20);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(80, 20);
            this.txtDataFinal.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "até";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Período:";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicial.Location = new System.Drawing.Point(49, 20);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(80, 20);
            this.txtDataInicial.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtValorLancamento);
            this.panel3.Controls.Add(this.txtDescricao);
            this.panel3.Controls.Add(this.cboTipoLanctoCaptacao);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cboSituacao);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtDataLancamento);
            this.panel3.Location = new System.Drawing.Point(2, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 53);
            this.panel3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Descrição";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(660, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Valor";
            // 
            // txtValorLancamento
            // 
            this.txtValorLancamento.Location = new System.Drawing.Point(660, 25);
            this.txtValorLancamento.Name = "txtValorLancamento";
            this.txtValorLancamento.numeroDecimais = 0;
            this.txtValorLancamento.Size = new System.Drawing.Size(69, 20);
            this.txtValorLancamento.TabIndex = 5;
            this.txtValorLancamento.Text = "0,00";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(308, 25);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(346, 20);
            this.txtDescricao.TabIndex = 4;
            // 
            // cboTipoLanctoCaptacao
            // 
            this.cboTipoLanctoCaptacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoLanctoCaptacao.FormattingEnabled = true;
            this.cboTipoLanctoCaptacao.Location = new System.Drawing.Point(99, 24);
            this.cboTipoLanctoCaptacao.Name = "cboTipoLanctoCaptacao";
            this.cboTipoLanctoCaptacao.Size = new System.Drawing.Size(203, 21);
            this.cboTipoLanctoCaptacao.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tipo de Lançamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Data";
            // 
            // cboSituacao
            // 
            this.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacao.Enabled = false;
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Items.AddRange(new object[] {
            "Aberto",
            "Pago"});
            this.cboSituacao.Location = new System.Drawing.Point(733, 24);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(58, 21);
            this.cboSituacao.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(730, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Situação";
            // 
            // txtDataLancamento
            // 
            this.txtDataLancamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataLancamento.Location = new System.Drawing.Point(12, 25);
            this.txtDataLancamento.Name = "txtDataLancamento";
            this.txtDataLancamento.Size = new System.Drawing.Size(80, 20);
            this.txtDataLancamento.TabIndex = 2;
            // 
            // txtIdContasCaptacao
            // 
            this.txtIdContasCaptacao.Location = new System.Drawing.Point(584, 27);
            this.txtIdContasCaptacao.Name = "txtIdContasCaptacao";
            this.txtIdContasCaptacao.Size = new System.Drawing.Size(52, 20);
            this.txtIdContasCaptacao.TabIndex = 9;
            this.txtIdContasCaptacao.Visible = false;
            // 
            // frmContasCaptacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(801, 471);
            this.Controls.Add(this.txtIdContasCaptacao);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdContasCaptacao);
            this.Controls.Add(this.panel2);
            this.Name = "frmContasCaptacao";
            this.Text = "Conta Corrente Vendedor";
            this.Load += new System.EventHandler(this.frmContasCaptacao_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.grdContasCaptacao, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.txtIdContasCaptacao, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContasCaptacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtVendedor_IdPessoa;
        private System.Windows.Forms.ComboBox cboIdVendedor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grdContasCaptacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDataInicial;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker txtDataLancamento;
        private System.Windows.Forms.ComboBox cboTipoLanctoCaptacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFiltrarLancamentos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorLancamento;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtIdContasCaptacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idContasCaptacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn datalancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLanctoCaptacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
    }
}
