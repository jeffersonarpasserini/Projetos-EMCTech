namespace EMCEstoque
{
    partial class frmEstq_Produto_Unidade
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
            this.grdEstq_Produto_Unidade = new System.Windows.Forms.DataGridView();
            this.idestq_produto_unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade_abreviatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUnidade_Abreviatura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidEstq_Produto_Unidade = new System.Windows.Forms.TextBox();
            this.txtUnidade_Descricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Unidade)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstq_Produto_Unidade
            // 
            this.grdEstq_Produto_Unidade.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Produto_Unidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Produto_Unidade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Produto_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Produto_Unidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Produto_Unidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_produto_unidade,
            this.unidade_descricao,
            this.unidade_abreviatura});
            this.grdEstq_Produto_Unidade.Location = new System.Drawing.Point(3, 132);
            this.grdEstq_Produto_Unidade.MultiSelect = false;
            this.grdEstq_Produto_Unidade.Name = "grdEstq_Produto_Unidade";
            this.grdEstq_Produto_Unidade.ReadOnly = true;
            this.grdEstq_Produto_Unidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Produto_Unidade.Size = new System.Drawing.Size(629, 193);
            this.grdEstq_Produto_Unidade.TabIndex = 16;
            this.grdEstq_Produto_Unidade.DoubleClick += new System.EventHandler(this.grdEstq_Porduto_Unidade_DoubleClick);
            // 
            // idestq_produto_unidade
            // 
            this.idestq_produto_unidade.DataPropertyName = "idestq_produto_unidade";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_produto_unidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_produto_unidade.HeaderText = "Código";
            this.idestq_produto_unidade.Name = "idestq_produto_unidade";
            this.idestq_produto_unidade.ReadOnly = true;
            this.idestq_produto_unidade.Width = 65;
            // 
            // unidade_descricao
            // 
            this.unidade_descricao.DataPropertyName = "unidade_descricao";
            this.unidade_descricao.HeaderText = "Unidade";
            this.unidade_descricao.Name = "unidade_descricao";
            this.unidade_descricao.ReadOnly = true;
            this.unidade_descricao.Width = 72;
            // 
            // unidade_abreviatura
            // 
            this.unidade_abreviatura.DataPropertyName = "unidade_abreviatura";
            this.unidade_abreviatura.HeaderText = "Abreviatura";
            this.unidade_abreviatura.Name = "unidade_abreviatura";
            this.unidade_abreviatura.ReadOnly = true;
            this.unidade_abreviatura.Width = 86;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUnidade_Abreviatura);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidEstq_Produto_Unidade);
            this.panel1.Controls.Add(this.txtUnidade_Descricao);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Abreviatura";
            // 
            // txtUnidade_Abreviatura
            // 
            this.txtUnidade_Abreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade_Abreviatura.Location = new System.Drawing.Point(557, 23);
            this.txtUnidade_Abreviatura.MaxLength = 45;
            this.txtUnidade_Abreviatura.Name = "txtUnidade_Abreviatura";
            this.txtUnidade_Abreviatura.Size = new System.Drawing.Size(58, 20);
            this.txtUnidade_Abreviatura.TabIndex = 7;
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
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unidade";
            // 
            // txtidEstq_Produto_Unidade
            // 
            this.txtidEstq_Produto_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Produto_Unidade.Location = new System.Drawing.Point(10, 23);
            this.txtidEstq_Produto_Unidade.MaxLength = 5;
            this.txtidEstq_Produto_Unidade.Name = "txtidEstq_Produto_Unidade";
            this.txtidEstq_Produto_Unidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Produto_Unidade.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Produto_Unidade.TabIndex = 1;
            this.txtidEstq_Produto_Unidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Produto_Unidade_Validating);
            // 
            // txtUnidade_Descricao
            // 
            this.txtUnidade_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade_Descricao.Location = new System.Drawing.Point(76, 23);
            this.txtUnidade_Descricao.MaxLength = 45;
            this.txtUnidade_Descricao.Name = "txtUnidade_Descricao";
            this.txtUnidade_Descricao.Size = new System.Drawing.Size(476, 20);
            this.txtUnidade_Descricao.TabIndex = 2;
            // 
            // frmEstq_Produto_Unidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.grdEstq_Produto_Unidade);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmEstq_Produto_Unidade";
            this.Text = "Unidade de Produto";
            this.Activated += new System.EventHandler(this.frmEstq_Produto_Unidade_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Produto_Unidade_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Produto_Unidade, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Unidade)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Produto_Unidade;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidEstq_Produto_Unidade;
        private System.Windows.Forms.TextBox txtUnidade_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_produto_unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade_abreviatura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnidade_Abreviatura;
    }
}
