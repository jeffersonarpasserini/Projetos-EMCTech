namespace EMCCadastro
{
    partial class frmCusto_ComponenteGrupo
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
            this.grdCusto_ComponenteGrupo = new System.Windows.Forms.DataGridView();
            this.idcusto_componentegrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidCusto_ComponenteGrupo = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCusto_ComponenteGrupo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCusto_ComponenteGrupo
            // 
            this.grdCusto_ComponenteGrupo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCusto_ComponenteGrupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCusto_ComponenteGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdCusto_ComponenteGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdCusto_ComponenteGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCusto_ComponenteGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcusto_componentegrupo,
            this.descricao});
            this.grdCusto_ComponenteGrupo.Location = new System.Drawing.Point(3, 124);
            this.grdCusto_ComponenteGrupo.MultiSelect = false;
            this.grdCusto_ComponenteGrupo.Name = "grdCusto_ComponenteGrupo";
            this.grdCusto_ComponenteGrupo.ReadOnly = true;
            this.grdCusto_ComponenteGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCusto_ComponenteGrupo.Size = new System.Drawing.Size(629, 193);
            this.grdCusto_ComponenteGrupo.TabIndex = 19;
            this.grdCusto_ComponenteGrupo.DoubleClick += new System.EventHandler(this.grdCusto_ComponenteGrupo_DoubleClick);
            // 
            // idcusto_componentegrupo
            // 
            this.idcusto_componentegrupo.DataPropertyName = "idcusto_componentegrupo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idcusto_componentegrupo.DefaultCellStyle = dataGridViewCellStyle2;
            this.idcusto_componentegrupo.HeaderText = "Código";
            this.idcusto_componentegrupo.Name = "idcusto_componentegrupo";
            this.idcusto_componentegrupo.ReadOnly = true;
            this.idcusto_componentegrupo.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Grupo do Componente de Custo";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 143;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtidCusto_ComponenteGrupo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 49);
            this.panel1.TabIndex = 18;
            // 
            // txtidCusto_ComponenteGrupo
            // 
            this.txtidCusto_ComponenteGrupo.BackColor = System.Drawing.SystemColors.Control;
            this.txtidCusto_ComponenteGrupo.Location = new System.Drawing.Point(7, 22);
            this.txtidCusto_ComponenteGrupo.Mask = "00000";
            this.txtidCusto_ComponenteGrupo.Name = "txtidCusto_ComponenteGrupo";
            this.txtidCusto_ComponenteGrupo.PromptChar = ' ';
            this.txtidCusto_ComponenteGrupo.Size = new System.Drawing.Size(63, 20);
            this.txtidCusto_ComponenteGrupo.TabIndex = 8;
            this.txtidCusto_ComponenteGrupo.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidCusto_ComponenteGrupo.ValidatingType = typeof(int);
            this.txtidCusto_ComponenteGrupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidCusto_ComponenteGrupo_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grupo do Componente de Custo";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(72, 22);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(541, 20);
            this.txtDescricao.TabIndex = 9;
            // 
            // frmCusto_ComponenteGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 319);
            this.Controls.Add(this.grdCusto_ComponenteGrupo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmCusto_ComponenteGrupo";
            this.Text = "Grupo do Componente de Custo";
            this.Activated += new System.EventHandler(this.frmCusto_ComponenteGrupo_Activated);
            this.Load += new System.EventHandler(this.frmCusto_ComponenteGrupo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdCusto_ComponenteGrupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdCusto_ComponenteGrupo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCusto_ComponenteGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcusto_componentegrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.MaskedTextBox txtidCusto_ComponenteGrupo;
    }
}
