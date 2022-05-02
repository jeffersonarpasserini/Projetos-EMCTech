namespace EMCImob
{
    partial class frmAtivoGrupo
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
            this.grdAtivoGrupo = new System.Windows.Forms.DataGridView();
            this.idcomodos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodAtivoGrupo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtivoGrupo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAtivoGrupo
            // 
            this.grdAtivoGrupo.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdAtivoGrupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdAtivoGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdAtivoGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAtivoGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAtivoGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcomodos,
            this.descricao});
            this.grdAtivoGrupo.Location = new System.Drawing.Point(2, 133);
            this.grdAtivoGrupo.MultiSelect = false;
            this.grdAtivoGrupo.Name = "grdAtivoGrupo";
            this.grdAtivoGrupo.ReadOnly = true;
            this.grdAtivoGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAtivoGrupo.Size = new System.Drawing.Size(558, 194);
            this.grdAtivoGrupo.TabIndex = 13;
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
            this.panel1.Controls.Add(this.txtCodAtivoGrupo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 53);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grupo Ativo";
            // 
            // txtCodAtivoGrupo
            // 
            this.txtCodAtivoGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodAtivoGrupo.Location = new System.Drawing.Point(10, 23);
            this.txtCodAtivoGrupo.MaxLength = 50;
            this.txtCodAtivoGrupo.Name = "txtCodAtivoGrupo";
            this.txtCodAtivoGrupo.Size = new System.Drawing.Size(63, 20);
            this.txtCodAtivoGrupo.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(474, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // frmAtivoGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(564, 329);
            this.Controls.Add(this.grdAtivoGrupo);
            this.Controls.Add(this.panel1);
            this.Name = "frmAtivoGrupo";
            this.Text = "Tabela de Gropos Ativos";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdAtivoGrupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdAtivoGrupo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAtivoGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodAtivoGrupo;
        private System.Windows.Forms.TextBox txtDescricao;
    }
}
