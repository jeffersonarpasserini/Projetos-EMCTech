namespace EMCObras
{
    partial class frmObra_Etapa
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
            this.grdObra_Etapa = new System.Windows.Forms.DataGridView();
            this.idobra_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidObra_Etapa = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Etapa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdObra_Etapa
            // 
            this.grdObra_Etapa.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra_Etapa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdObra_Etapa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdObra_Etapa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra_Etapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra_Etapa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_etapa,
            this.descricao});
            this.grdObra_Etapa.Location = new System.Drawing.Point(2, 130);
            this.grdObra_Etapa.MultiSelect = false;
            this.grdObra_Etapa.Name = "grdObra_Etapa";
            this.grdObra_Etapa.ReadOnly = true;
            this.grdObra_Etapa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra_Etapa.Size = new System.Drawing.Size(629, 187);
            this.grdObra_Etapa.TabIndex = 12;
            this.grdObra_Etapa.DoubleClick += new System.EventHandler(this.grdObra_Etapa_DoubleClick);
            // 
            // idobra_etapa
            // 
            this.idobra_etapa.DataPropertyName = "idobra_etapa";
            this.idobra_etapa.HeaderText = "Código";
            this.idobra_etapa.Name = "idobra_etapa";
            this.idobra_etapa.ReadOnly = true;
            this.idobra_etapa.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Etapa";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidObra_Etapa);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 11;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Etapa";
            // 
            // txtidObra_Etapa
            // 
            this.txtidObra_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Etapa.Location = new System.Drawing.Point(10, 23);
            this.txtidObra_Etapa.MaxLength = 50;
            this.txtidObra_Etapa.Name = "txtidObra_Etapa";
            this.txtidObra_Etapa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Etapa.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_Etapa.TabIndex = 1;
            this.txtidObra_Etapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Etapa.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Etapa_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(76, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(541, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // frmObra_Etapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 320);
            this.Controls.Add(this.grdObra_Etapa);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmObra_Etapa";
            this.Text = "Etapas da Obra";
            this.Activated += new System.EventHandler(this.frmObra_Etapa_Activated);
            this.Load += new System.EventHandler(this.frmObra_Etapa_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdObra_Etapa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Etapa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdObra_Etapa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidObra_Etapa;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}