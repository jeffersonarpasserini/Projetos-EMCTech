namespace EMCCadastro
{
    partial class frmBanco
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
            this.grdBanco = new System.Windows.Forms.DataGridView();
            this.idbanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtidBanco = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdBanco)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBanco
            // 
            this.grdBanco.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdBanco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdBanco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdBanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBanco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idbanco,
            this.descricao});
            this.grdBanco.Location = new System.Drawing.Point(4, 143);
            this.grdBanco.MultiSelect = false;
            this.grdBanco.Name = "grdBanco";
            this.grdBanco.ReadOnly = true;
            this.grdBanco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBanco.Size = new System.Drawing.Size(624, 146);
            this.grdBanco.TabIndex = 8;
            this.grdBanco.DoubleClick += new System.EventHandler(this.grdBanco_DoubleClick);
            // 
            // idbanco
            // 
            this.idbanco.DataPropertyName = "idBanco";
            this.idbanco.HeaderText = "Código";
            this.idbanco.Name = "idbanco";
            this.idbanco.ReadOnly = true;
            this.idbanco.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descricao";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtidBanco);
            this.panel1.Location = new System.Drawing.Point(3, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 61);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome Banco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Código";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(58, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(557, 20);
            this.txtDescricao.TabIndex = 7;
            // 
            // txtidBanco
            // 
            this.txtidBanco.BackColor = System.Drawing.SystemColors.Control;
            this.txtidBanco.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidBanco.Location = new System.Drawing.Point(10, 23);
            this.txtidBanco.Mask = "000";
            this.txtidBanco.Name = "txtidBanco";
            this.txtidBanco.PromptChar = ' ';
            this.txtidBanco.Size = new System.Drawing.Size(42, 20);
            this.txtidBanco.TabIndex = 6;
            this.txtidBanco.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidBanco.Validating += new System.ComponentModel.CancelEventHandler(this.txtidBanco_Validating);
            // 
            // frmBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 291);
            this.Controls.Add(this.grdBanco);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmBanco";
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.frmBanco_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdBanco, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdBanco)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdBanco;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.MaskedTextBox txtidBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
