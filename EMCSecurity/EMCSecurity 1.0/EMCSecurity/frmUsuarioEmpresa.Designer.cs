namespace EMCSecurity
{
    partial class frmUsuarioEmpresa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboIdEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdUsuarioEmpresa = new System.Windows.Forms.DataGridView();
            this.cboIdUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nomeusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuarioEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cboIdEmpresa);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.grdUsuarioEmpresa);
            this.panel1.Controls.Add(this.cboIdUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 251);
            this.panel1.TabIndex = 1;
            // 
            // cboIdEmpresa
            // 
            this.cboIdEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdEmpresa.FormattingEnabled = true;
            this.cboIdEmpresa.Location = new System.Drawing.Point(7, 56);
            this.cboIdEmpresa.Name = "cboIdEmpresa";
            this.cboIdEmpresa.Size = new System.Drawing.Size(610, 21);
            this.cboIdEmpresa.TabIndex = 4;
            this.cboIdEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboIdEmpresa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Empresa";
            // 
            // grdUsuarioEmpresa
            // 
            this.grdUsuarioEmpresa.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdUsuarioEmpresa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUsuarioEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdUsuarioEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsuarioEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deleta,
            this.nomeusuario,
            this.nomeempresa,
            this.idusuario,
            this.idempresa});
            this.grdUsuarioEmpresa.Location = new System.Drawing.Point(3, 81);
            this.grdUsuarioEmpresa.Name = "grdUsuarioEmpresa";
            this.grdUsuarioEmpresa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUsuarioEmpresa.Size = new System.Drawing.Size(619, 166);
            this.grdUsuarioEmpresa.TabIndex = 2;
            this.grdUsuarioEmpresa.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsuarioEmpresa_CellValueChanged);
            this.grdUsuarioEmpresa.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdUsuarioEmpresa_CurrentCellDirtyStateChanged);
            // 
            // cboIdUsuario
            // 
            this.cboIdUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdUsuario.FormattingEnabled = true;
            this.cboIdUsuario.Location = new System.Drawing.Point(7, 18);
            this.cboIdUsuario.Name = "cboIdUsuario";
            this.cboIdUsuario.Size = new System.Drawing.Size(610, 21);
            this.cboIdUsuario.TabIndex = 1;
            this.cboIdUsuario.SelectedIndexChanged += new System.EventHandler(this.cboIdUsuario_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuário";
            // 
            // deleta
            // 
            this.deleta.FalseValue = "0";
            this.deleta.HeaderText = "Remove";
            this.deleta.IndeterminateValue = "0";
            this.deleta.Name = "deleta";
            this.deleta.TrueValue = "1";
            this.deleta.Width = 50;
            // 
            // nomeusuario
            // 
            this.nomeusuario.DataPropertyName = "nomeusuario";
            this.nomeusuario.HeaderText = "Usuário";
            this.nomeusuario.Name = "nomeusuario";
            this.nomeusuario.ReadOnly = true;
            // 
            // nomeempresa
            // 
            this.nomeempresa.DataPropertyName = "razaosocial";
            this.nomeempresa.HeaderText = "Empresa";
            this.nomeempresa.Name = "nomeempresa";
            this.nomeempresa.ReadOnly = true;
            this.nomeempresa.Width = 400;
            // 
            // idusuario
            // 
            this.idusuario.DataPropertyName = "idusuario";
            this.idusuario.HeaderText = "codigo";
            this.idusuario.Name = "idusuario";
            this.idusuario.ReadOnly = true;
            this.idusuario.Visible = false;
            // 
            // idempresa
            // 
            this.idempresa.DataPropertyName = "idempresa";
            this.idempresa.HeaderText = "codigo";
            this.idempresa.Name = "idempresa";
            this.idempresa.ReadOnly = true;
            this.idempresa.Visible = false;
            // 
            // frmUsuarioEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.panel1);
            this.Name = "frmUsuarioEmpresa";
            this.Text = "UsuárioEmpresa";
            this.Load += new System.EventHandler(this.frmUsuarioEmpresa_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuarioEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboIdEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdUsuarioEmpresa;
        private System.Windows.Forms.ComboBox cboIdUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn deleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeusuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresa;
    }
}
