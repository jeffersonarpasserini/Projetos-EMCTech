namespace EMCImob
{
    partial class frmTipoImovel
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
            this.grdTipoImovel = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdTipoImovel = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.idTipoImovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoImovel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTipoImovel
            // 
            this.grdTipoImovel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTipoImovel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTipoImovel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTipoImovel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdTipoImovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoImovel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoImovel,
            this.descricao});
            this.grdTipoImovel.Location = new System.Drawing.Point(2, 134);
            this.grdTipoImovel.MultiSelect = false;
            this.grdTipoImovel.Name = "grdTipoImovel";
            this.grdTipoImovel.ReadOnly = true;
            this.grdTipoImovel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoImovel.Size = new System.Drawing.Size(627, 194);
            this.grdTipoImovel.TabIndex = 13;
            this.grdTipoImovel.DoubleClick += new System.EventHandler(this.grdTipoImovel_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdTipoImovel);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 53);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de Imóvel";
            // 
            // txtIdTipoImovel
            // 
            this.txtIdTipoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdTipoImovel.Location = new System.Drawing.Point(10, 23);
            this.txtIdTipoImovel.MaxLength = 50;
            this.txtIdTipoImovel.Name = "txtIdTipoImovel";
            this.txtIdTipoImovel.Size = new System.Drawing.Size(63, 20);
            this.txtIdTipoImovel.TabIndex = 8;
            this.txtIdTipoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtidTipoImovel_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(542, 20);
            this.txtDescricao.TabIndex = 9;
            // 
            // idTipoImovel
            // 
            this.idTipoImovel.DataPropertyName = "idtipoimovel";
            this.idTipoImovel.HeaderText = "Código";
            this.idTipoImovel.Name = "idTipoImovel";
            this.idTipoImovel.ReadOnly = true;
            this.idTipoImovel.Width = 65;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 300;
            // 
            // frmTipoImovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(632, 329);
            this.Controls.Add(this.grdTipoImovel);
            this.Controls.Add(this.panel1);
            this.Name = "frmTipoImovel";
            this.Text = "Tabela de Tipos de Imóveis";
            this.Load += new System.EventHandler(this.frmTipoImovel_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdTipoImovel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoImovel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTipoImovel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdTipoImovel;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoImovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
