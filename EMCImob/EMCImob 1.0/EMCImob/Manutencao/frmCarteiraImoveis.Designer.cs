namespace EMCImob
{
    partial class frmCarteiraImoveis
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
            this.grdCarteiraImoveis = new System.Windows.Forms.DataGridView();
            this.idCarteiraImoveis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdCarteiraImoveis = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCarteiraImoveis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCarteiraImoveis
            // 
            this.grdCarteiraImoveis.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCarteiraImoveis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCarteiraImoveis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdCarteiraImoveis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdCarteiraImoveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCarteiraImoveis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCarteiraImoveis,
            this.descricao});
            this.grdCarteiraImoveis.Location = new System.Drawing.Point(2, 134);
            this.grdCarteiraImoveis.MultiSelect = false;
            this.grdCarteiraImoveis.Name = "grdCarteiraImoveis";
            this.grdCarteiraImoveis.ReadOnly = true;
            this.grdCarteiraImoveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCarteiraImoveis.Size = new System.Drawing.Size(628, 194);
            this.grdCarteiraImoveis.TabIndex = 15;
            this.grdCarteiraImoveis.DoubleClick += new System.EventHandler(this.grdCarteiraImoveis_DoubleClick);
            // 
            // idCarteiraImoveis
            // 
            this.idCarteiraImoveis.DataPropertyName = "idCarteiraImoveis";
            this.idCarteiraImoveis.HeaderText = "Código";
            this.idCarteiraImoveis.Name = "idCarteiraImoveis";
            this.idCarteiraImoveis.ReadOnly = true;
            this.idCarteiraImoveis.Width = 65;
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
            this.panel1.Controls.Add(this.txtIdCarteiraImoveis);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 53);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Carteira de Imóvel";
            // 
            // txtIdCarteiraImoveis
            // 
            this.txtIdCarteiraImoveis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdCarteiraImoveis.Location = new System.Drawing.Point(10, 23);
            this.txtIdCarteiraImoveis.MaxLength = 50;
            this.txtIdCarteiraImoveis.Name = "txtIdCarteiraImoveis";
            this.txtIdCarteiraImoveis.Size = new System.Drawing.Size(63, 20);
            this.txtIdCarteiraImoveis.TabIndex = 0;
            this.txtIdCarteiraImoveis.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCarteiraImoveis_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(544, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // frmCarteiraImoveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 329);
            this.Controls.Add(this.grdCarteiraImoveis);
            this.Controls.Add(this.panel1);
            this.Name = "frmCarteiraImoveis";
            this.Text = "Tabela de Carteira de Imóveis";
            this.Load += new System.EventHandler(this.frmCarteiraImoveis_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdCarteiraImoveis, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdCarteiraImoveis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCarteiraImoveis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdCarteiraImoveis;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCarteiraImoveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
