namespace EMCObras
{
    partial class frmObra_Tarefa
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
            this.grdObra_Tarefa = new System.Windows.Forms.DataGridView();
            this.idobra_tarefa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtObra_EtapaDescricao = new System.Windows.Forms.TextBox();
            this.txtidObra_Modulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboObra_Modulo = new System.Windows.Forms.ComboBox();
            this.txtidObra_Etapa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidObra_Tarefas = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Tarefa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdObra_Tarefa
            // 
            this.grdObra_Tarefa.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra_Tarefa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdObra_Tarefa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdObra_Tarefa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra_Tarefa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra_Tarefa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_tarefa,
            this.descricao,
            this.idobra_modulo,
            this.Modulo,
            this.idobra_etapa,
            this.etapa});
            this.grdObra_Tarefa.Location = new System.Drawing.Point(1, 211);
            this.grdObra_Tarefa.MultiSelect = false;
            this.grdObra_Tarefa.Name = "grdObra_Tarefa";
            this.grdObra_Tarefa.ReadOnly = true;
            this.grdObra_Tarefa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra_Tarefa.Size = new System.Drawing.Size(629, 254);
            this.grdObra_Tarefa.TabIndex = 16;
            this.grdObra_Tarefa.DoubleClick += new System.EventHandler(this.grdObra_Tarefa_DoubleClick);
            // 
            // idobra_tarefa
            // 
            this.idobra_tarefa.DataPropertyName = "idobra_tarefas";
            this.idobra_tarefa.HeaderText = "Código";
            this.idobra_tarefa.Name = "idobra_tarefa";
            this.idobra_tarefa.ReadOnly = true;
            this.idobra_tarefa.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Tarefa";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 63;
            // 
            // idobra_modulo
            // 
            this.idobra_modulo.DataPropertyName = "idobra_modulo";
            this.idobra_modulo.HeaderText = "idobra_modulo";
            this.idobra_modulo.Name = "idobra_modulo";
            this.idobra_modulo.ReadOnly = true;
            this.idobra_modulo.Visible = false;
            this.idobra_modulo.Width = 101;
            // 
            // Modulo
            // 
            this.Modulo.DataPropertyName = "Obra_Modulo_Descricao";
            this.Modulo.HeaderText = "Módulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            this.Modulo.Width = 67;
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
            this.panel1.Controls.Add(this.txtObra_EtapaDescricao);
            this.panel1.Controls.Add(this.txtidObra_Modulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboObra_Modulo);
            this.panel1.Controls.Add(this.txtidObra_Etapa);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidObra_Tarefas);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(1, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 133);
            this.panel1.TabIndex = 15;
            // 
            // txtObra_EtapaDescricao
            // 
            this.txtObra_EtapaDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObra_EtapaDescricao.Location = new System.Drawing.Point(77, 104);
            this.txtObra_EtapaDescricao.MaxLength = 50;
            this.txtObra_EtapaDescricao.Name = "txtObra_EtapaDescricao";
            this.txtObra_EtapaDescricao.Size = new System.Drawing.Size(542, 20);
            this.txtObra_EtapaDescricao.TabIndex = 6;
            // 
            // txtidObra_Modulo
            // 
            this.txtidObra_Modulo.Location = new System.Drawing.Point(8, 63);
            this.txtidObra_Modulo.Name = "txtidObra_Modulo";
            this.txtidObra_Modulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Modulo.Size = new System.Drawing.Size(65, 20);
            this.txtidObra_Modulo.TabIndex = 3;
            this.txtidObra_Modulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Modulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Modulo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Módulo da Obra";
            // 
            // cboObra_Modulo
            // 
            this.cboObra_Modulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboObra_Modulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboObra_Modulo.FormattingEnabled = true;
            this.cboObra_Modulo.Location = new System.Drawing.Point(77, 63);
            this.cboObra_Modulo.Name = "cboObra_Modulo";
            this.cboObra_Modulo.Size = new System.Drawing.Size(540, 21);
            this.cboObra_Modulo.TabIndex = 4;
            this.cboObra_Modulo.SelectedValueChanged += new System.EventHandler(this.cboObra_Modulo_SelectedValueChanged);
            // 
            // txtidObra_Etapa
            // 
            this.txtidObra_Etapa.Location = new System.Drawing.Point(10, 104);
            this.txtidObra_Etapa.Name = "txtidObra_Etapa";
            this.txtidObra_Etapa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Etapa.Size = new System.Drawing.Size(65, 20);
            this.txtidObra_Etapa.TabIndex = 5;
            this.txtidObra_Etapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Etapa da Obra";
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
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tarefa";
            // 
            // txtidObra_Tarefas
            // 
            this.txtidObra_Tarefas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Tarefas.Location = new System.Drawing.Point(10, 23);
            this.txtidObra_Tarefas.MaxLength = 50;
            this.txtidObra_Tarefas.Name = "txtidObra_Tarefas";
            this.txtidObra_Tarefas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Tarefas.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_Tarefas.TabIndex = 1;
            this.txtidObra_Tarefas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Tarefas.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Tarefas_Validating);
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
            // frmObra_Tarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 467);
            this.Controls.Add(this.grdObra_Tarefa);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmObra_Tarefa";
            this.Text = "Tarefas da Obra";
            this.Activated += new System.EventHandler(this.frmObra_Tarefa_Activated);
            this.Load += new System.EventHandler(this.frmObra_Tarefa_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdObra_Tarefa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Tarefa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdObra_Tarefa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtidObra_Etapa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidObra_Tarefas;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtidObra_Modulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboObra_Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_tarefa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
        private System.Windows.Forms.TextBox txtObra_EtapaDescricao;
    }
}
