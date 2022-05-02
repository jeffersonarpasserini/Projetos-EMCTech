namespace EMCCadastro
{
    partial class frmGrupoEmpresa
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeGrupoEmpresa = new System.Windows.Forms.TextBox();
            this.grdGrupoEmpresa = new System.Windows.Forms.DataGridView();
            this.cboHolding = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdGrupoEmpresa = new System.Windows.Forms.MaskedTextBox();
            this.idgrupoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrupoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Grupo Empresa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código";
            // 
            // txtNomeGrupoEmpresa
            // 
            this.txtNomeGrupoEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeGrupoEmpresa.Location = new System.Drawing.Point(79, 99);
            this.txtNomeGrupoEmpresa.MaxLength = 100;
            this.txtNomeGrupoEmpresa.Name = "txtNomeGrupoEmpresa";
            this.txtNomeGrupoEmpresa.Size = new System.Drawing.Size(343, 20);
            this.txtNomeGrupoEmpresa.TabIndex = 7;
            // 
            // grdGrupoEmpresa
            // 
            this.grdGrupoEmpresa.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdGrupoEmpresa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGrupoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdGrupoEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGrupoEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idgrupoempresa,
            this.grupoempresa,
            this.holding});
            this.grdGrupoEmpresa.Location = new System.Drawing.Point(3, 134);
            this.grdGrupoEmpresa.Name = "grdGrupoEmpresa";
            this.grdGrupoEmpresa.ReadOnly = true;
            this.grdGrupoEmpresa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGrupoEmpresa.Size = new System.Drawing.Size(629, 191);
            this.grdGrupoEmpresa.TabIndex = 7;
            this.grdGrupoEmpresa.DoubleClick += new System.EventHandler(this.grdGrupoEmpresa_DoubleClick);
            // 
            // cboHolding
            // 
            this.cboHolding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHolding.FormattingEnabled = true;
            this.cboHolding.Location = new System.Drawing.Point(427, 98);
            this.cboHolding.Name = "cboHolding";
            this.cboHolding.Size = new System.Drawing.Size(200, 21);
            this.cboHolding.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Holding";
            // 
            // txtIdGrupoEmpresa
            // 
            this.txtIdGrupoEmpresa.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdGrupoEmpresa.Location = new System.Drawing.Point(10, 99);
            this.txtIdGrupoEmpresa.Mask = "00000";
            this.txtIdGrupoEmpresa.Name = "txtIdGrupoEmpresa";
            this.txtIdGrupoEmpresa.PromptChar = ' ';
            this.txtIdGrupoEmpresa.Size = new System.Drawing.Size(64, 20);
            this.txtIdGrupoEmpresa.TabIndex = 13;
            this.txtIdGrupoEmpresa.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdGrupoEmpresa.ValidatingType = typeof(int);
            this.txtIdGrupoEmpresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdGrupoEmpresa_Validating);
            // 
            // idgrupoempresa
            // 
            this.idgrupoempresa.DataPropertyName = "idgrupoempresa";
            this.idgrupoempresa.HeaderText = "Código";
            this.idgrupoempresa.Name = "idgrupoempresa";
            this.idgrupoempresa.ReadOnly = true;
            this.idgrupoempresa.Width = 60;
            // 
            // grupoempresa
            // 
            this.grupoempresa.DataPropertyName = "nomegrupoempresa";
            this.grupoempresa.HeaderText = "Grupo Empresa";
            this.grupoempresa.Name = "grupoempresa";
            this.grupoempresa.ReadOnly = true;
            this.grupoempresa.Width = 300;
            // 
            // holding
            // 
            this.holding.DataPropertyName = "nomeholding";
            this.holding.HeaderText = "Holding";
            this.holding.Name = "holding";
            this.holding.ReadOnly = true;
            this.holding.Width = 226;
            // 
            // frmGrupoEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.txtIdGrupoEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboHolding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeGrupoEmpresa);
            this.Controls.Add(this.grdGrupoEmpresa);
            this.MaximizeBox = false;
            this.Name = "frmGrupoEmpresa";
            this.Text = "Grupo de Empresas";
            this.Load += new System.EventHandler(this.frmGrupoEmpresa_Load);
            this.Controls.SetChildIndex(this.grdGrupoEmpresa, 0);
            this.Controls.SetChildIndex(this.txtNomeGrupoEmpresa, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboHolding, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtIdGrupoEmpresa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdGrupoEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeGrupoEmpresa;
        private System.Windows.Forms.DataGridView grdGrupoEmpresa;
        private System.Windows.Forms.ComboBox cboHolding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtIdGrupoEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgrupoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn holding;
    }
}
