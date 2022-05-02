namespace EMCImob
{
    partial class frmPrincipal
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
            this.aplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAplicacao)).BeginInit();
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
            this.aplicacao});
            this.grdAplicacao.Location = new System.Drawing.Point(2, 12);
            this.grdAplicacao.MultiSelect = false;
            this.grdAplicacao.Name = "grdAplicacao";
            this.grdAplicacao.ReadOnly = true;
            this.grdAplicacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAplicacao.Size = new System.Drawing.Size(449, 279);
            this.grdAplicacao.TabIndex = 11;
            this.grdAplicacao.DoubleClick += new System.EventHandler(this.grdAplicacao_DoubleClick);
            // 
            // aplicacao
            // 
            this.aplicacao.HeaderText = "Aplicação";
            this.aplicacao.Name = "aplicacao";
            this.aplicacao.ReadOnly = true;
            this.aplicacao.Width = 79;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 292);
            this.Controls.Add(this.grdAplicacao);
            this.Name = "frmPrincipal";
            this.Text = "Menu p/ Teste";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAplicacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicacao;
    }
}

