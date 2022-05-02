namespace EMCCadastro
{
    partial class frmHolding
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
            this.grdHolding = new System.Windows.Forms.DataGridView();
            this.idholding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeholding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNomeHolding = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdHolding = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdHolding)).BeginInit();
            this.SuspendLayout();
            // 
            // grdHolding
            // 
            this.grdHolding.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdHolding.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdHolding.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdHolding.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHolding.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idholding,
            this.nomeholding});
            this.grdHolding.Location = new System.Drawing.Point(2, 137);
            this.grdHolding.Name = "grdHolding";
            this.grdHolding.ReadOnly = true;
            this.grdHolding.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHolding.Size = new System.Drawing.Size(629, 191);
            this.grdHolding.TabIndex = 8;
            this.grdHolding.DoubleClick += new System.EventHandler(this.grdHolding_DoubleClick);
            // 
            // idholding
            // 
            this.idholding.DataPropertyName = "idholding";
            this.idholding.HeaderText = "Código";
            this.idholding.Name = "idholding";
            this.idholding.ReadOnly = true;
            // 
            // nomeholding
            // 
            this.nomeholding.DataPropertyName = "nomeholding";
            this.nomeholding.HeaderText = "Nome";
            this.nomeholding.Name = "nomeholding";
            this.nomeholding.ReadOnly = true;
            this.nomeholding.Width = 400;
            // 
            // txtNomeHolding
            // 
            this.txtNomeHolding.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeHolding.Location = new System.Drawing.Point(78, 102);
            this.txtNomeHolding.MaxLength = 100;
            this.txtNomeHolding.Name = "txtNomeHolding";
            this.txtNomeHolding.Size = new System.Drawing.Size(481, 20);
            this.txtNomeHolding.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Holding";
            // 
            // txtIdHolding
            // 
            this.txtIdHolding.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdHolding.Location = new System.Drawing.Point(9, 102);
            this.txtIdHolding.Mask = "00000";
            this.txtIdHolding.Name = "txtIdHolding";
            this.txtIdHolding.PromptChar = ' ';
            this.txtIdHolding.Size = new System.Drawing.Size(64, 20);
            this.txtIdHolding.TabIndex = 6;
            this.txtIdHolding.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdHolding.ValidatingType = typeof(int);
            this.txtIdHolding.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdHolding_Validating);
            // 
            // frmHolding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.txtIdHolding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeHolding);
            this.Controls.Add(this.grdHolding);
            this.MinimizeBox = false;
            this.Name = "frmHolding";
            this.Text = "Holding";
            this.Load += new System.EventHandler(this.frmHolding_Load);
            this.Controls.SetChildIndex(this.grdHolding, 0);
            this.Controls.SetChildIndex(this.txtNomeHolding, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtIdHolding, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdHolding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdHolding;
        private System.Windows.Forms.DataGridViewTextBoxColumn idholding;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeholding;
        private System.Windows.Forms.TextBox txtNomeHolding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtIdHolding;
    }
}
