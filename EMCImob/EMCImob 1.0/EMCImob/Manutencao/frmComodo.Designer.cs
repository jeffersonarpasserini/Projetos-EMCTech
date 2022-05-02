namespace EMCImob
{
    partial class frmComodo
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
            this.grdComodo = new System.Windows.Forms.DataGridView();
            this.idcomodos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdComodo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdComodo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdComodo
            // 
            this.grdComodo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdComodo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdComodo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdComodo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdComodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdComodo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcomodos,
            this.descricao});
            this.grdComodo.Location = new System.Drawing.Point(2, 132);
            this.grdComodo.MultiSelect = false;
            this.grdComodo.Name = "grdComodo";
            this.grdComodo.ReadOnly = true;
            this.grdComodo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdComodo.Size = new System.Drawing.Size(626, 194);
            this.grdComodo.TabIndex = 11;
            this.grdComodo.DoubleClick += new System.EventHandler(this.grdComodo_DoubleClick);
            // 
            // idcomodos
            // 
            this.idcomodos.DataPropertyName = "idcomodos";
            this.idcomodos.HeaderText = "Código";
            this.idcomodos.Name = "idcomodos";
            this.idcomodos.ReadOnly = true;
            this.idcomodos.Width = 65;
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdComodo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 53);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comodos";
            // 
            // txtIdComodo
            // 
            this.txtIdComodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdComodo.Location = new System.Drawing.Point(10, 23);
            this.txtIdComodo.MaxLength = 50;
            this.txtIdComodo.Name = "txtIdComodo";
            this.txtIdComodo.Size = new System.Drawing.Size(63, 20);
            this.txtIdComodo.TabIndex = 0;
            this.txtIdComodo.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdComodo_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(537, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // frmComodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 329);
            this.Controls.Add(this.grdComodo);
            this.Controls.Add(this.panel1);
            this.Name = "frmComodo";
            this.Text = "Tabela de Comodos";
            this.Load += new System.EventHandler(this.frmComodo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdComodo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdComodo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdComodo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdComodo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
