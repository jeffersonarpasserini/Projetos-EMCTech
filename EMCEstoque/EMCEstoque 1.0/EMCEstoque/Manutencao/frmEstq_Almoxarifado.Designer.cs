namespace EMCEstoque
{
    partial class frmEstq_Almoxarifado
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
            this.grdEstq_Almoxarifado = new System.Windows.Forms.DataGridView();
            this.idestq_almoxarifado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa_idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidEstq_Almoxarifado = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Almoxarifado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstq_Almoxarifado
            // 
            this.grdEstq_Almoxarifado.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Almoxarifado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Almoxarifado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Almoxarifado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Almoxarifado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Almoxarifado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_almoxarifado,
            this.descricao,
            this.empresa_idempresa});
            this.grdEstq_Almoxarifado.Location = new System.Drawing.Point(3, 130);
            this.grdEstq_Almoxarifado.MultiSelect = false;
            this.grdEstq_Almoxarifado.Name = "grdEstq_Almoxarifado";
            this.grdEstq_Almoxarifado.ReadOnly = true;
            this.grdEstq_Almoxarifado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Almoxarifado.Size = new System.Drawing.Size(629, 187);
            this.grdEstq_Almoxarifado.TabIndex = 16;
            this.grdEstq_Almoxarifado.DoubleClick += new System.EventHandler(this.grdEstq_Almoxarifado_DoubleClick);
            // 
            // idestq_almoxarifado
            // 
            this.idestq_almoxarifado.DataPropertyName = "idestq_almoxarifado";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_almoxarifado.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_almoxarifado.HeaderText = "Código";
            this.idestq_almoxarifado.Name = "idestq_almoxarifado";
            this.idestq_almoxarifado.ReadOnly = true;
            this.idestq_almoxarifado.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Almoxarifado";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 92;
            // 
            // empresa_idempresa
            // 
            this.empresa_idempresa.DataPropertyName = "empresa_idempresa";
            this.empresa_idempresa.HeaderText = "Empresa";
            this.empresa_idempresa.Name = "empresa_idempresa";
            this.empresa_idempresa.ReadOnly = true;
            this.empresa_idempresa.Visible = false;
            this.empresa_idempresa.Width = 73;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidEstq_Almoxarifado);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 15;
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
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Almoxarifado";
            // 
            // txtidEstq_Almoxarifado
            // 
            this.txtidEstq_Almoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Almoxarifado.Location = new System.Drawing.Point(10, 23);
            this.txtidEstq_Almoxarifado.MaxLength = 50;
            this.txtidEstq_Almoxarifado.Name = "txtidEstq_Almoxarifado";
            this.txtidEstq_Almoxarifado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Almoxarifado.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Almoxarifado.TabIndex = 1;
            this.txtidEstq_Almoxarifado.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Almoxarifado_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(76, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(541, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // frmEstq_Almoxarifado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 320);
            this.Controls.Add(this.grdEstq_Almoxarifado);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmEstq_Almoxarifado";
            this.Text = "Almoxarifado";
            this.Activated += new System.EventHandler(this.frmEstq_Almoxarifado_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Almoxarifado_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Almoxarifado, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Almoxarifado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Almoxarifado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidEstq_Almoxarifado;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_almoxarifado;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa_idempresa;
    }
}
