namespace EMCObras
{
    partial class frmObra_Modulo
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
            this.grdObra_Modulo = new System.Windows.Forms.DataGridView();
            this.idobra_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Módulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidObra_Etapa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboObra_Etapa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidObra_Modulo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Modulo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdObra_Modulo
            // 
            this.grdObra_Modulo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra_Modulo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdObra_Modulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdObra_Modulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra_Modulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra_Modulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_modulo,
            this.Módulo,
            this.idobra_etapa,
            this.etapa});
            this.grdObra_Modulo.Location = new System.Drawing.Point(3, 171);
            this.grdObra_Modulo.MultiSelect = false;
            this.grdObra_Modulo.Name = "grdObra_Modulo";
            this.grdObra_Modulo.ReadOnly = true;
            this.grdObra_Modulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra_Modulo.Size = new System.Drawing.Size(629, 187);
            this.grdObra_Modulo.TabIndex = 14;
            this.grdObra_Modulo.DoubleClick += new System.EventHandler(this.grdObra_Modulo_DoubleClick);
            // 
            // idobra_modulo
            // 
            this.idobra_modulo.DataPropertyName = "idobra_modulo";
            this.idobra_modulo.HeaderText = "Código";
            this.idobra_modulo.Name = "idobra_modulo";
            this.idobra_modulo.ReadOnly = true;
            this.idobra_modulo.Width = 65;
            // 
            // Módulo
            // 
            this.Módulo.DataPropertyName = "descricao";
            this.Módulo.HeaderText = "Módulo";
            this.Módulo.Name = "Módulo";
            this.Módulo.ReadOnly = true;
            this.Módulo.Width = 67;
            // 
            // idobra_etapa
            // 
            this.idobra_etapa.DataPropertyName = "obra_etapa_idobra_etapa";
            this.idobra_etapa.HeaderText = "idobra_etapa";
            this.idobra_etapa.Name = "idobra_etapa";
            this.idobra_etapa.ReadOnly = true;
            this.idobra_etapa.Visible = false;
            this.idobra_etapa.Width = 94;
            // 
            // etapa
            // 
            this.etapa.DataPropertyName = "Obra_Etapa_Descricao";
            this.etapa.HeaderText = "Etapa";
            this.etapa.Name = "etapa";
            this.etapa.ReadOnly = true;
            this.etapa.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtidObra_Etapa);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboObra_Etapa);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidObra_Modulo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 92);
            this.panel1.TabIndex = 13;
            // 
            // txtidObra_Etapa
            // 
            this.txtidObra_Etapa.Location = new System.Drawing.Point(10, 63);
            this.txtidObra_Etapa.Name = "txtidObra_Etapa";
            this.txtidObra_Etapa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Etapa.Size = new System.Drawing.Size(65, 20);
            this.txtidObra_Etapa.TabIndex = 7;
            this.txtidObra_Etapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Etapa.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Etapa_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Etapa da Obra";
            // 
            // cboObra_Etapa
            // 
            this.cboObra_Etapa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboObra_Etapa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboObra_Etapa.FormattingEnabled = true;
            this.cboObra_Etapa.Location = new System.Drawing.Point(79, 63);
            this.cboObra_Etapa.Name = "cboObra_Etapa";
            this.cboObra_Etapa.Size = new System.Drawing.Size(540, 21);
            this.cboObra_Etapa.TabIndex = 8;
            this.cboObra_Etapa.SelectedValueChanged += new System.EventHandler(this.cboObra_Etapa_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Módulo";
            // 
            // txtidObra_Modulo
            // 
            this.txtidObra_Modulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Modulo.Location = new System.Drawing.Point(10, 23);
            this.txtidObra_Modulo.MaxLength = 50;
            this.txtidObra_Modulo.Name = "txtidObra_Modulo";
            this.txtidObra_Modulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Modulo.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_Modulo.TabIndex = 1;
            this.txtidObra_Modulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Modulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Modulo_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(77, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(542, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // frmObra_Modulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.grdObra_Modulo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmObra_Modulo";
            this.Text = "Módulos da Obra";
            this.Activated += new System.EventHandler(this.frmObra_Modulo_Activated);
            this.Load += new System.EventHandler(this.frmObra_Modulo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdObra_Modulo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Modulo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdObra_Modulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtidObra_Etapa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboObra_Etapa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidObra_Modulo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Módulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
    }
}
