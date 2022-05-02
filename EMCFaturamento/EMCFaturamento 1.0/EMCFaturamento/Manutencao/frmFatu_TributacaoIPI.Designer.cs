namespace EMCFaturamento
{
    partial class frmFatu_TributacaoIPI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtIdFatu_TributacaoIPI = new MaskedNumber.MaskedNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIpi_Perc_Ipi = new MaskedNumber.MaskedNumber();
            this.txtIpi_Perc_Outros = new MaskedNumber.MaskedNumber();
            this.txtIpi_Perc_Isentos = new MaskedNumber.MaskedNumber();
            this.txtIpi_Perc_Tributado = new MaskedNumber.MaskedNumber();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cboFatu_SitFiscalIPISaida = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboFatu_SitFiscalIPIEntrada = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.grdTributacaoIPI = new System.Windows.Forms.DataGridView();
            this.idfatu_tributacaoipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTributacaoIPI)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.txtIdFatu_TributacaoIPI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIpi_Perc_Ipi);
            this.groupBox1.Controls.Add(this.txtIpi_Perc_Outros);
            this.groupBox1.Controls.Add(this.txtIpi_Perc_Isentos);
            this.groupBox1.Controls.Add(this.txtIpi_Perc_Tributado);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(2, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 144);
            this.groupBox1.TabIndex = 248;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IPI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(13, 71);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(610, 20);
            this.txtDescricao.TabIndex = 5;
            // 
            // txtIdFatu_TributacaoIPI
            // 
            this.txtIdFatu_TributacaoIPI.CustomFormat = "0";
            this.txtIdFatu_TributacaoIPI.Format = MaskedNumberFormat.Custom;
            this.txtIdFatu_TributacaoIPI.Location = new System.Drawing.Point(13, 32);
            this.txtIdFatu_TributacaoIPI.Name = "txtIdFatu_TributacaoIPI";
            this.txtIdFatu_TributacaoIPI.Size = new System.Drawing.Size(70, 20);
            this.txtIdFatu_TributacaoIPI.TabIndex = 0;
            this.txtIdFatu_TributacaoIPI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdFatu_TributacaoIPI.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFatu_TributacaoIPI_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Código";
            // 
            // txtIpi_Perc_Ipi
            // 
            this.txtIpi_Perc_Ipi.CustomFormat = "0:0";
            this.txtIpi_Perc_Ipi.Format = MaskedNumberFormat.Porcentagem;
            this.txtIpi_Perc_Ipi.Location = new System.Drawing.Point(548, 30);
            this.txtIpi_Perc_Ipi.Name = "txtIpi_Perc_Ipi";
            this.txtIpi_Perc_Ipi.Size = new System.Drawing.Size(76, 20);
            this.txtIpi_Perc_Ipi.TabIndex = 4;
            this.txtIpi_Perc_Ipi.Text = "0,00%";
            this.txtIpi_Perc_Ipi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIpi_Perc_Outros
            // 
            this.txtIpi_Perc_Outros.CustomFormat = "0:0";
            this.txtIpi_Perc_Outros.Format = MaskedNumberFormat.Porcentagem;
            this.txtIpi_Perc_Outros.Location = new System.Drawing.Point(470, 30);
            this.txtIpi_Perc_Outros.Name = "txtIpi_Perc_Outros";
            this.txtIpi_Perc_Outros.Size = new System.Drawing.Size(76, 20);
            this.txtIpi_Perc_Outros.TabIndex = 3;
            this.txtIpi_Perc_Outros.Text = "0,00%";
            this.txtIpi_Perc_Outros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIpi_Perc_Isentos
            // 
            this.txtIpi_Perc_Isentos.CustomFormat = "0:0";
            this.txtIpi_Perc_Isentos.Format = MaskedNumberFormat.Porcentagem;
            this.txtIpi_Perc_Isentos.Location = new System.Drawing.Point(399, 30);
            this.txtIpi_Perc_Isentos.Name = "txtIpi_Perc_Isentos";
            this.txtIpi_Perc_Isentos.Size = new System.Drawing.Size(70, 20);
            this.txtIpi_Perc_Isentos.TabIndex = 2;
            this.txtIpi_Perc_Isentos.Text = "0,00%";
            this.txtIpi_Perc_Isentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIpi_Perc_Tributado
            // 
            this.txtIpi_Perc_Tributado.CustomFormat = "0:0";
            this.txtIpi_Perc_Tributado.Format = MaskedNumberFormat.Porcentagem;
            this.txtIpi_Perc_Tributado.Location = new System.Drawing.Point(327, 30);
            this.txtIpi_Perc_Tributado.Name = "txtIpi_Perc_Tributado";
            this.txtIpi_Perc_Tributado.Size = new System.Drawing.Size(70, 20);
            this.txtIpi_Perc_Tributado.TabIndex = 1;
            this.txtIpi_Perc_Tributado.Text = "0,00%";
            this.txtIpi_Perc_Tributado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cboFatu_SitFiscalIPISaida);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(315, 95);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(308, 42);
            this.groupBox8.TabIndex = 59;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Situação Fiscal IPI - Saída";
            // 
            // cboFatu_SitFiscalIPISaida
            // 
            this.cboFatu_SitFiscalIPISaida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFatu_SitFiscalIPISaida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFatu_SitFiscalIPISaida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFatu_SitFiscalIPISaida.FormattingEnabled = true;
            this.cboFatu_SitFiscalIPISaida.Location = new System.Drawing.Point(6, 15);
            this.cboFatu_SitFiscalIPISaida.Name = "cboFatu_SitFiscalIPISaida";
            this.cboFatu_SitFiscalIPISaida.Size = new System.Drawing.Size(301, 21);
            this.cboFatu_SitFiscalIPISaida.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboFatu_SitFiscalIPIEntrada);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(6, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(307, 43);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Situação Fiscal IPI - Entrada";
            // 
            // cboFatu_SitFiscalIPIEntrada
            // 
            this.cboFatu_SitFiscalIPIEntrada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFatu_SitFiscalIPIEntrada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFatu_SitFiscalIPIEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFatu_SitFiscalIPIEntrada.FormattingEnabled = true;
            this.cboFatu_SitFiscalIPIEntrada.Location = new System.Drawing.Point(7, 17);
            this.cboFatu_SitFiscalIPIEntrada.Name = "cboFatu_SitFiscalIPIEntrada";
            this.cboFatu_SitFiscalIPIEntrada.Size = new System.Drawing.Size(295, 21);
            this.cboFatu_SitFiscalIPIEntrada.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(545, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "% Aliq. IPI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(467, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "% Outros";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(396, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "% Isento";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(319, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = " %Tributado";
            // 
            // grdTributacaoIPI
            // 
            this.grdTributacaoIPI.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTributacaoIPI.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTributacaoIPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTributacaoIPI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_tributacaoipi,
            this.descricao});
            this.grdTributacaoIPI.Location = new System.Drawing.Point(2, 226);
            this.grdTributacaoIPI.Name = "grdTributacaoIPI";
            this.grdTributacaoIPI.ReadOnly = true;
            this.grdTributacaoIPI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTributacaoIPI.Size = new System.Drawing.Size(629, 227);
            this.grdTributacaoIPI.TabIndex = 249;
            this.grdTributacaoIPI.DoubleClick += new System.EventHandler(this.grdTributacaoIPI_DoubleClick);
            // 
            // idfatu_tributacaoipi
            // 
            this.idfatu_tributacaoipi.DataPropertyName = "idfatu_tributacaoipi";
            this.idfatu_tributacaoipi.HeaderText = "Codigo";
            this.idfatu_tributacaoipi.Name = "idfatu_tributacaoipi";
            this.idfatu_tributacaoipi.ReadOnly = true;
            this.idfatu_tributacaoipi.Width = 50;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 300;
            // 
            // frmFatu_TributacaoIPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(635, 456);
            this.Controls.Add(this.grdTributacaoIPI);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFatu_TributacaoIPI";
            this.Text = "Tributação IPI";
            this.Load += new System.EventHandler(this.frmFatu_TributacaoIPI_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grdTributacaoIPI, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTributacaoIPI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaskedNumber.MaskedNumber txtIpi_Perc_Ipi;
        private MaskedNumber.MaskedNumber txtIpi_Perc_Outros;
        private MaskedNumber.MaskedNumber txtIpi_Perc_Isentos;
        private MaskedNumber.MaskedNumber txtIpi_Perc_Tributado;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cboFatu_SitFiscalIPISaida;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboFatu_SitFiscalIPIEntrada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private MaskedNumber.MaskedNumber txtIdFatu_TributacaoIPI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView grdTributacaoIPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_tributacaoipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
