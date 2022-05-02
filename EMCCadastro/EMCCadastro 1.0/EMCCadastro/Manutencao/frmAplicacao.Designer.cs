namespace EMCCadastro
{
    partial class frmAplicacao
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
            this.grdAplicacao = new System.Windows.Forms.DataGridView();
            this.idaplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdAplicacao = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAplicacao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdAplicacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAplicacao
            // 
            this.grdAplicacao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdAplicacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAplicacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdAplicacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAplicacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAplicacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idaplicacao,
            this.descricao});
            this.grdAplicacao.Location = new System.Drawing.Point(2, 135);
            this.grdAplicacao.MultiSelect = false;
            this.grdAplicacao.Name = "grdAplicacao";
            this.grdAplicacao.ReadOnly = true;
            this.grdAplicacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAplicacao.Size = new System.Drawing.Size(626, 187);
            this.grdAplicacao.TabIndex = 8;
            this.grdAplicacao.DoubleClick += new System.EventHandler(this.grdAplicacao_DoubleClick);
            // 
            // idaplicacao
            // 
            this.idaplicacao.DataPropertyName = "idaplicacao";
            this.idaplicacao.HeaderText = "Código";
            this.idaplicacao.Name = "idaplicacao";
            this.idaplicacao.ReadOnly = true;
            this.idaplicacao.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtIdAplicacao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblAplicacao);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 7;
            // 
            // txtIdAplicacao
            // 
            this.txtIdAplicacao.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdAplicacao.Location = new System.Drawing.Point(11, 23);
            this.txtIdAplicacao.Mask = "00000";
            this.txtIdAplicacao.Name = "txtIdAplicacao";
            this.txtIdAplicacao.PromptChar = ' ';
            this.txtIdAplicacao.Size = new System.Drawing.Size(49, 20);
            this.txtIdAplicacao.TabIndex = 6;
            this.txtIdAplicacao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdAplicacao.ValidatingType = typeof(int);
            this.txtIdAplicacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdAplicacao_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // lblAplicacao
            // 
            this.lblAplicacao.AutoSize = true;
            this.lblAplicacao.Location = new System.Drawing.Point(62, 7);
            this.lblAplicacao.Name = "lblAplicacao";
            this.lblAplicacao.Size = new System.Drawing.Size(54, 13);
            this.lblAplicacao.TabIndex = 5;
            this.lblAplicacao.Text = "Aplicação";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(65, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(552, 20);
            this.txtDescricao.TabIndex = 7;
            // 
            // frmAplicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 329);
            this.Controls.Add(this.grdAplicacao);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmAplicacao";
            this.Text = "Aplicação";
            this.Load += new System.EventHandler(this.frmAplicacao_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdAplicacao, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdAplicacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAplicacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAplicacao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idaplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.MaskedTextBox txtIdAplicacao;
    }
}
