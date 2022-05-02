namespace EMCCadastro
{
    partial class frmIndice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckData = new System.Windows.Forms.CheckBox();
            this.txtIdIndice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.NumericUpDown();
            this.txtDataIndice = new System.Windows.Forms.DateTimePicker();
            this.cboIdIndexador = new System.Windows.Forms.ComboBox();
            this.grdIndice = new System.Windows.Forms.DataGridView();
            this.idindexador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idindices = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoindexador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataindice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckData);
            this.panel1.Controls.Add(this.txtIdIndice);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.txtDataIndice);
            this.panel1.Controls.Add(this.cboIdIndexador);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 57);
            this.panel1.TabIndex = 1;
            // 
            // ckData
            // 
            this.ckData.AutoSize = true;
            this.ckData.Location = new System.Drawing.Point(376, 33);
            this.ckData.Name = "ckData";
            this.ckData.Size = new System.Drawing.Size(95, 17);
            this.ckData.TabIndex = 9;
            this.ckData.Text = "Filtrar por Data";
            this.ckData.UseVisualStyleBackColor = true;
            // 
            // txtIdIndice
            // 
            this.txtIdIndice.Location = new System.Drawing.Point(147, 3);
            this.txtIdIndice.Name = "txtIdIndice";
            this.txtIdIndice.Size = new System.Drawing.Size(118, 20);
            this.txtIdIndice.TabIndex = 6;
            this.txtIdIndice.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Indexador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data Índice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.DecimalPlaces = 4;
            this.txtValor.Location = new System.Drawing.Point(477, 30);
            this.txtValor.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtValor.Name = "txtValor";
            this.txtValor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValor.Size = new System.Drawing.Size(149, 20);
            this.txtValor.TabIndex = 10;
            this.txtValor.ThousandsSeparator = true;
            this.txtValor.Enter += new System.EventHandler(this.txtValor_Enter);
            // 
            // txtDataIndice
            // 
            this.txtDataIndice.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataIndice.Location = new System.Drawing.Point(271, 30);
            this.txtDataIndice.Name = "txtDataIndice";
            this.txtDataIndice.Size = new System.Drawing.Size(99, 20);
            this.txtDataIndice.TabIndex = 8;
            // 
            // cboIdIndexador
            // 
            this.cboIdIndexador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdIndexador.FormattingEnabled = true;
            this.cboIdIndexador.Location = new System.Drawing.Point(7, 30);
            this.cboIdIndexador.Name = "cboIdIndexador";
            this.cboIdIndexador.Size = new System.Drawing.Size(258, 21);
            this.cboIdIndexador.TabIndex = 7;
            this.cboIdIndexador.ValueMemberChanged += new System.EventHandler(this.cboIdIndexador_ValueMemberChanged);
            this.cboIdIndexador.Validating += new System.ComponentModel.CancelEventHandler(this.cboIdIndexador_Validating);
            // 
            // grdIndice
            // 
            this.grdIndice.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdIndice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIndice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdIndice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIndice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idindexador,
            this.idindices,
            this.descricaoindexador,
            this.dataindice,
            this.valor});
            this.grdIndice.Location = new System.Drawing.Point(2, 135);
            this.grdIndice.MultiSelect = false;
            this.grdIndice.Name = "grdIndice";
            this.grdIndice.ReadOnly = true;
            this.grdIndice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIndice.Size = new System.Drawing.Size(629, 193);
            this.grdIndice.TabIndex = 11;
            this.grdIndice.DoubleClick += new System.EventHandler(this.grdIndice_DoubleClick);
            // 
            // idindexador
            // 
            this.idindexador.DataPropertyName = "idindexador";
            this.idindexador.HeaderText = "Código Indexador";
            this.idindexador.Name = "idindexador";
            this.idindexador.ReadOnly = true;
            this.idindexador.Visible = false;
            // 
            // idindices
            // 
            this.idindices.DataPropertyName = "idindices";
            this.idindices.HeaderText = "Código";
            this.idindices.Name = "idindices";
            this.idindices.ReadOnly = true;
            // 
            // descricaoindexador
            // 
            this.descricaoindexador.DataPropertyName = "descricaoindexador";
            this.descricaoindexador.HeaderText = "Indexador";
            this.descricaoindexador.Name = "descricaoindexador";
            this.descricaoindexador.ReadOnly = true;
            // 
            // dataindice
            // 
            this.dataindice.DataPropertyName = "dataindice";
            this.dataindice.HeaderText = "Data";
            this.dataindice.Name = "dataindice";
            this.dataindice.ReadOnly = true;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "valor";
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            // 
            // frmIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdIndice);
            this.MinimizeBox = false;
            this.Name = "frmIndice";
            this.Text = "Índices Financeiros";
            this.Load += new System.EventHandler(this.frmIndice_Load);
            this.Controls.SetChildIndex(this.grdIndice, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtDataIndice;
        private System.Windows.Forms.ComboBox cboIdIndexador;
        private System.Windows.Forms.DataGridView grdIndice;
        private System.Windows.Forms.NumericUpDown txtValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdIndice;
        private System.Windows.Forms.DataGridViewTextBoxColumn idindexador;
        private System.Windows.Forms.DataGridViewTextBoxColumn idindices;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoindexador;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataindice;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.CheckBox ckData;
    }
}
