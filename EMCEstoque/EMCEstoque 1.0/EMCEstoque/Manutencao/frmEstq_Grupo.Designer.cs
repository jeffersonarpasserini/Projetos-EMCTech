namespace EMCEstoque
{
    partial class frmEstq_Grupo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFaturamentoSaida = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFaturamentoEntrada = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidEstq_Grupo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.grdEstq_Grupo = new System.Windows.Forms.DataGridView();
            this.idestq_grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaturamentoEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaturamentoSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatuentrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatusaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Grupo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboFaturamentoSaida);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboFaturamentoEntrada);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidEstq_Grupo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 104);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(82, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Faturamento na Saída";
            // 
            // cboFaturamentoSaida
            // 
            this.cboFaturamentoSaida.FormattingEnabled = true;
            this.cboFaturamentoSaida.Location = new System.Drawing.Point(82, 75);
            this.cboFaturamentoSaida.Name = "cboFaturamentoSaida";
            this.cboFaturamentoSaida.Size = new System.Drawing.Size(70, 21);
            this.cboFaturamentoSaida.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Faturamento na Entrada";
            // 
            // cboFaturamentoEntrada
            // 
            this.cboFaturamentoEntrada.FormattingEnabled = true;
            this.cboFaturamentoEntrada.Location = new System.Drawing.Point(8, 75);
            this.cboFaturamentoEntrada.Name = "cboFaturamentoEntrada";
            this.cboFaturamentoEntrada.Size = new System.Drawing.Size(70, 21);
            this.cboFaturamentoEntrada.TabIndex = 11;
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
            this.label2.Location = new System.Drawing.Point(72, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grupo";
            // 
            // txtidEstq_Grupo
            // 
            this.txtidEstq_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Grupo.Location = new System.Drawing.Point(8, 23);
            this.txtidEstq_Grupo.MaxLength = 50;
            this.txtidEstq_Grupo.Name = "txtidEstq_Grupo";
            this.txtidEstq_Grupo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Grupo.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Grupo.TabIndex = 1;
            this.txtidEstq_Grupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Grupo_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(72, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(541, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // grdEstq_Grupo
            // 
            this.grdEstq_Grupo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Grupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Grupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Grupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Grupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_grupo,
            this.descricao,
            this.FaturamentoEntrada,
            this.FaturamentoSaida,
            this.fatuentrada,
            this.fatusaida});
            this.grdEstq_Grupo.Location = new System.Drawing.Point(3, 179);
            this.grdEstq_Grupo.MultiSelect = false;
            this.grdEstq_Grupo.Name = "grdEstq_Grupo";
            this.grdEstq_Grupo.ReadOnly = true;
            this.grdEstq_Grupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Grupo.Size = new System.Drawing.Size(629, 193);
            this.grdEstq_Grupo.TabIndex = 17;
            this.grdEstq_Grupo.DoubleClick += new System.EventHandler(this.grdEstq_Grupo_DoubleClick);
            // 
            // idestq_grupo
            // 
            this.idestq_grupo.DataPropertyName = "idestq_grupo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_grupo.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_grupo.HeaderText = "Código";
            this.idestq_grupo.Name = "idestq_grupo";
            this.idestq_grupo.ReadOnly = true;
            this.idestq_grupo.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Grupo";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 61;
            // 
            // FaturamentoEntrada
            // 
            this.FaturamentoEntrada.DataPropertyName = "faturamentoentrada";
            this.FaturamentoEntrada.HeaderText = "Faturamento na Entrada";
            this.FaturamentoEntrada.Name = "FaturamentoEntrada";
            this.FaturamentoEntrada.ReadOnly = true;
            this.FaturamentoEntrada.Visible = false;
            this.FaturamentoEntrada.Width = 146;
            // 
            // FaturamentoSaida
            // 
            this.FaturamentoSaida.DataPropertyName = "faturamentosaida";
            this.FaturamentoSaida.HeaderText = "Faturamento na Saída";
            this.FaturamentoSaida.Name = "FaturamentoSaida";
            this.FaturamentoSaida.ReadOnly = true;
            this.FaturamentoSaida.Visible = false;
            this.FaturamentoSaida.Width = 138;
            // 
            // fatuentrada
            // 
            this.fatuentrada.DataPropertyName = "fatuentrada";
            this.fatuentrada.HeaderText = "Faturamento Entrada";
            this.fatuentrada.Name = "fatuentrada";
            this.fatuentrada.ReadOnly = true;
            this.fatuentrada.Width = 120;
            // 
            // fatusaida
            // 
            this.fatusaida.DataPropertyName = "fatusaida";
            this.fatusaida.HeaderText = "Faturamento Saída";
            this.fatusaida.Name = "fatusaida";
            this.fatusaida.ReadOnly = true;
            this.fatusaida.Width = 113;
            // 
            // frmEstq_Grupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 373);
            this.Controls.Add(this.grdEstq_Grupo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmEstq_Grupo";
            this.Text = "Grupo de Estoque";
            this.Activated += new System.EventHandler(this.frmEstq_Grupo_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Grupo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Grupo, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Grupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidEstq_Grupo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView grdEstq_Grupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFaturamentoSaida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFaturamentoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturamentoEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturamentoSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatuentrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatusaida;
    }
}
