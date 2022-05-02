namespace EMCCadastro
{
    partial class frmFormaPagamento
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
            this.grdFormaPagamento = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdFormaPagamento = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHistoricoPadrao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.idformapagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idhistoricopadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaohistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFormaPagamento)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFormaPagamento
            // 
            this.grdFormaPagamento.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFormaPagamento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFormaPagamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFormaPagamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFormaPagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idformapagamento,
            this.descricao,
            this.idhistoricopadrao,
            this.descricaohistorico});
            this.grdFormaPagamento.Location = new System.Drawing.Point(2, 172);
            this.grdFormaPagamento.MultiSelect = false;
            this.grdFormaPagamento.Name = "grdFormaPagamento";
            this.grdFormaPagamento.ReadOnly = true;
            this.grdFormaPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFormaPagamento.Size = new System.Drawing.Size(629, 168);
            this.grdFormaPagamento.TabIndex = 9;
            this.grdFormaPagamento.DoubleClick += new System.EventHandler(this.grdFormaPagamento_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtIdFormaPagamento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboHistoricoPadrao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 92);
            this.panel1.TabIndex = 7;
            // 
            // txtIdFormaPagamento
            // 
            this.txtIdFormaPagamento.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdFormaPagamento.Location = new System.Drawing.Point(10, 23);
            this.txtIdFormaPagamento.Mask = "00000";
            this.txtIdFormaPagamento.Name = "txtIdFormaPagamento";
            this.txtIdFormaPagamento.PromptChar = ' ';
            this.txtIdFormaPagamento.Size = new System.Drawing.Size(63, 20);
            this.txtIdFormaPagamento.TabIndex = 0;
            this.txtIdFormaPagamento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdFormaPagamento.ValidatingType = typeof(int);
            this.txtIdFormaPagamento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFormaPagamento_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Histórico Padrão";
            // 
            // cboHistoricoPadrao
            // 
            this.cboHistoricoPadrao.FormattingEnabled = true;
            this.cboHistoricoPadrao.Location = new System.Drawing.Point(10, 63);
            this.cboHistoricoPadrao.Name = "cboHistoricoPadrao";
            this.cboHistoricoPadrao.Size = new System.Drawing.Size(607, 21);
            this.cboHistoricoPadrao.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(538, 20);
            this.txtDescricao.TabIndex = 7;
            // 
            // idformapagamento
            // 
            this.idformapagamento.DataPropertyName = "idFormaPagamento";
            this.idformapagamento.HeaderText = "Código";
            this.idformapagamento.Name = "idformapagamento";
            this.idformapagamento.ReadOnly = true;
            this.idformapagamento.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // idhistoricopadrao
            // 
            this.idhistoricopadrao.DataPropertyName = "idHistoricoPadrao";
            this.idhistoricopadrao.HeaderText = "Código Histórico Padrão";
            this.idhistoricopadrao.Name = "idhistoricopadrao";
            this.idhistoricopadrao.ReadOnly = true;
            this.idhistoricopadrao.Visible = false;
            this.idhistoricopadrao.Width = 146;
            // 
            // descricaohistorico
            // 
            this.descricaohistorico.DataPropertyName = "descricaohistorico";
            this.descricaohistorico.HeaderText = "Histórico";
            this.descricaohistorico.Name = "descricaohistorico";
            this.descricaohistorico.ReadOnly = true;
            this.descricaohistorico.Width = 73;
            // 
            // frmFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 344);
            this.Controls.Add(this.grdFormaPagamento);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmFormaPagamento";
            this.Text = "Forma Pagamento";
            this.Load += new System.EventHandler(this.frmFormaPagamento_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFormaPagamento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFormaPagamento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFormaPagamento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHistoricoPadrao;
        private System.Windows.Forms.MaskedTextBox txtIdFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idformapagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idhistoricopadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaohistorico;
    }
}
