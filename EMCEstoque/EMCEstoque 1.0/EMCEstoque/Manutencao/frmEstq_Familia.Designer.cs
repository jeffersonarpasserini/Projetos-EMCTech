namespace EMCEstoque
{
    partial class frmEstq_Familia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdEstq_Familia = new System.Windows.Forms.DataGridView();
            this.idestq_familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidEstq_Familia = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Familia)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstq_Familia
            // 
            this.grdEstq_Familia.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Familia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Familia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Familia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Familia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Familia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_familia,
            this.descricao});
            this.grdEstq_Familia.Location = new System.Drawing.Point(3, 129);
            this.grdEstq_Familia.MultiSelect = false;
            this.grdEstq_Familia.Name = "grdEstq_Familia";
            this.grdEstq_Familia.ReadOnly = true;
            this.grdEstq_Familia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Familia.Size = new System.Drawing.Size(629, 184);
            this.grdEstq_Familia.TabIndex = 19;
            this.grdEstq_Familia.DoubleClick += new System.EventHandler(this.grdEstq_Familia_DoubleClick);
            // 
            // idestq_familia
            // 
            this.idestq_familia.DataPropertyName = "idestq_familia";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_familia.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_familia.HeaderText = "Código";
            this.idestq_familia.Name = "idestq_familia";
            this.idestq_familia.ReadOnly = true;
            this.idestq_familia.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Família";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 66;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidEstq_Familia);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 18;
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
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Família";
            // 
            // txtidEstq_Familia
            // 
            this.txtidEstq_Familia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Familia.Location = new System.Drawing.Point(10, 23);
            this.txtidEstq_Familia.MaxLength = 50;
            this.txtidEstq_Familia.Name = "txtidEstq_Familia";
            this.txtidEstq_Familia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Familia.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Familia.TabIndex = 1;
            this.txtidEstq_Familia.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Familia_Validating);
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
            // frmEstq_Familia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 318);
            this.Controls.Add(this.grdEstq_Familia);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_Familia";
            this.Text = "Família de Produto";
            this.Activated += new System.EventHandler(this.frmEstq_Familia_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Familia_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Familia, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Familia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidEstq_Familia;
        private System.Windows.Forms.TextBox txtDescricao;
    }
}
