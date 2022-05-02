namespace EMCObras
{
    partial class frmObra_TipoContrato
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidObra_TipoContrato = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.grdTipoContrato = new System.Windows.Forms.DataGridView();
            this.idobra_tipocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoContrato)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidObra_TipoContrato);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 60);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Descriçao";
            // 
            // txtidObra_TipoContrato
            // 
            this.txtidObra_TipoContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_TipoContrato.Location = new System.Drawing.Point(11, 27);
            this.txtidObra_TipoContrato.MaxLength = 50;
            this.txtidObra_TipoContrato.Name = "txtidObra_TipoContrato";
            this.txtidObra_TipoContrato.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_TipoContrato.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_TipoContrato.TabIndex = 7;
            this.txtidObra_TipoContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_TipoContrato.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_TipoContrato_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(77, 27);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(541, 20);
            this.txtDescricao.TabIndex = 8;
            // 
            // grdTipoContrato
            // 
            this.grdTipoContrato.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTipoContrato.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTipoContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoContrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_tipocontrato,
            this.descricao});
            this.grdTipoContrato.Location = new System.Drawing.Point(2, 138);
            this.grdTipoContrato.MultiSelect = false;
            this.grdTipoContrato.Name = "grdTipoContrato";
            this.grdTipoContrato.ReadOnly = true;
            this.grdTipoContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoContrato.Size = new System.Drawing.Size(629, 189);
            this.grdTipoContrato.TabIndex = 2;
            this.grdTipoContrato.DoubleClick += new System.EventHandler(this.grdTipoContrato_DoubleClick);
            // 
            // idobra_tipocontrato
            // 
            this.idobra_tipocontrato.DataPropertyName = "idobra_tipocontrato";
            this.idobra_tipocontrato.HeaderText = "Código";
            this.idobra_tipocontrato.Name = "idobra_tipocontrato";
            this.idobra_tipocontrato.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Tipo Contrato";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 400;
            // 
            // frmObra_TipoContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.grdTipoContrato);
            this.Controls.Add(this.panel1);
            this.Name = "frmObra_TipoContrato";
            this.Text = "Tipo Contrato de Obra";
            this.Activated += new System.EventHandler(this.frmObra_TipoContrato_Activated);
            this.Load += new System.EventHandler(this.frmObra_TipoContrato_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdTipoContrato, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoContrato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdTipoContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidObra_TipoContrato;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_tipocontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
