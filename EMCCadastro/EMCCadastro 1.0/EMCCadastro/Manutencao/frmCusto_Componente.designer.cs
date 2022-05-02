namespace EMCCadastro
{
    partial class frmCusto_Componente
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
            this.grdCusto_Componente = new System.Windows.Forms.DataGridView();
            this.idcusto_componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustoComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idgrupo_componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccg_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidGrupo_Componente = new System.Windows.Forms.MaskedTextBox();
            this.txtidCusto_Componente = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboCusto_ComponenteGrupo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCusto_Componente)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCusto_Componente
            // 
            this.grdCusto_Componente.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCusto_Componente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCusto_Componente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdCusto_Componente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdCusto_Componente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCusto_Componente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcusto_componente,
            this.CustoComponente,
            this.idgrupo_componente,
            this.ccg_descricao});
            this.grdCusto_Componente.Location = new System.Drawing.Point(2, 167);
            this.grdCusto_Componente.MultiSelect = false;
            this.grdCusto_Componente.Name = "grdCusto_Componente";
            this.grdCusto_Componente.ReadOnly = true;
            this.grdCusto_Componente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCusto_Componente.Size = new System.Drawing.Size(629, 187);
            this.grdCusto_Componente.TabIndex = 18;
            this.grdCusto_Componente.DoubleClick += new System.EventHandler(this.grdCusto_Componente_DoubleClick);
            // 
            // idcusto_componente
            // 
            this.idcusto_componente.DataPropertyName = "idcusto_componente";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idcusto_componente.DefaultCellStyle = dataGridViewCellStyle2;
            this.idcusto_componente.HeaderText = "Código";
            this.idcusto_componente.Name = "idcusto_componente";
            this.idcusto_componente.ReadOnly = true;
            this.idcusto_componente.Width = 65;
            // 
            // CustoComponente
            // 
            this.CustoComponente.DataPropertyName = "descricao";
            this.CustoComponente.HeaderText = "Custo Componente";
            this.CustoComponente.Name = "CustoComponente";
            this.CustoComponente.ReadOnly = true;
            this.CustoComponente.Width = 112;
            // 
            // idgrupo_componente
            // 
            this.idgrupo_componente.DataPropertyName = "idgrupo_componente";
            this.idgrupo_componente.HeaderText = "idgrupo_componente";
            this.idgrupo_componente.Name = "idgrupo_componente";
            this.idgrupo_componente.ReadOnly = true;
            this.idgrupo_componente.Visible = false;
            this.idgrupo_componente.Width = 132;
            // 
            // ccg_descricao
            // 
            this.ccg_descricao.DataPropertyName = "ccg_descricao";
            this.ccg_descricao.HeaderText = "Grupo de Componente";
            this.ccg_descricao.Name = "ccg_descricao";
            this.ccg_descricao.ReadOnly = true;
            this.ccg_descricao.Width = 127;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtidGrupo_Componente);
            this.panel1.Controls.Add(this.txtidCusto_Componente);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboCusto_ComponenteGrupo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 91);
            this.panel1.TabIndex = 17;
            // 
            // txtidGrupo_Componente
            // 
            this.txtidGrupo_Componente.BackColor = System.Drawing.SystemColors.Control;
            this.txtidGrupo_Componente.Location = new System.Drawing.Point(10, 64);
            this.txtidGrupo_Componente.Mask = "00000";
            this.txtidGrupo_Componente.Name = "txtidGrupo_Componente";
            this.txtidGrupo_Componente.PromptChar = ' ';
            this.txtidGrupo_Componente.Size = new System.Drawing.Size(65, 20);
            this.txtidGrupo_Componente.TabIndex = 12;
            this.txtidGrupo_Componente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidGrupo_Componente.ValidatingType = typeof(int);
            this.txtidGrupo_Componente.Validating += new System.ComponentModel.CancelEventHandler(this.txtidGrupo_Componente_Validating);
            // 
            // txtidCusto_Componente
            // 
            this.txtidCusto_Componente.BackColor = System.Drawing.SystemColors.Control;
            this.txtidCusto_Componente.Location = new System.Drawing.Point(10, 23);
            this.txtidCusto_Componente.Mask = "00000";
            this.txtidCusto_Componente.Name = "txtidCusto_Componente";
            this.txtidCusto_Componente.PromptChar = ' ';
            this.txtidCusto_Componente.Size = new System.Drawing.Size(63, 20);
            this.txtidCusto_Componente.TabIndex = 10;
            this.txtidCusto_Componente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidCusto_Componente.ValidatingType = typeof(int);
            this.txtidCusto_Componente.Validating += new System.ComponentModel.CancelEventHandler(this.txtidCusto_Componente_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Grupo do Componente de Custo";
            // 
            // cboCusto_ComponenteGrupo
            // 
            this.cboCusto_ComponenteGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCusto_ComponenteGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCusto_ComponenteGrupo.FormattingEnabled = true;
            this.cboCusto_ComponenteGrupo.Location = new System.Drawing.Point(79, 63);
            this.cboCusto_ComponenteGrupo.Name = "cboCusto_ComponenteGrupo";
            this.cboCusto_ComponenteGrupo.Size = new System.Drawing.Size(540, 21);
            this.cboCusto_ComponenteGrupo.TabIndex = 13;
            this.cboCusto_ComponenteGrupo.SelectedValueChanged += new System.EventHandler(this.cboCusto_ComponenteGrupo_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Componente de Custo";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(77, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(542, 20);
            this.txtDescricao.TabIndex = 11;
            // 
            // frmCusto_Componente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 357);
            this.Controls.Add(this.grdCusto_Componente);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmCusto_Componente";
            this.Text = "Componente de Custo";
            this.Activated += new System.EventHandler(this.frmCusto_Componente_Activated);
            this.Load += new System.EventHandler(this.frmCusto_Componente_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdCusto_Componente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdCusto_Componente)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCusto_Componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcusto_componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustoComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgrupo_componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccg_descricao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCusto_ComponenteGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.MaskedTextBox txtidCusto_Componente;
        private System.Windows.Forms.MaskedTextBox txtidGrupo_Componente;
    }
}
