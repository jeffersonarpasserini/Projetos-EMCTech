namespace EMCSecurity
{
    partial class frmUsuario
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
            this.lblNomeCompleto = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtNomeCompleto = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblNivelUsuario = new System.Windows.Forms.Label();
            this.grdUsuario = new System.Windows.Forms.DataGridView();
            this.idusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelacesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblConfirmaSenha = new System.Windows.Forms.Label();
            this.txtConfirmaSenha = new System.Windows.Forms.TextBox();
            this.cboNivelUsuario = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuario)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomeCompleto
            // 
            this.lblNomeCompleto.AutoSize = true;
            this.lblNomeCompleto.Location = new System.Drawing.Point(3, 0);
            this.lblNomeCompleto.Name = "lblNomeCompleto";
            this.lblNomeCompleto.Size = new System.Drawing.Size(38, 13);
            this.lblNomeCompleto.TabIndex = 1;
            this.lblNomeCompleto.Text = "Nome ";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(5, 15);
            this.txtNome.MaxLength = 10;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(80, 20);
            this.txtNome.TabIndex = 2;
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(85, 1);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(82, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Nome Completo";
            // 
            // txtNomeCompleto
            // 
            this.txtNomeCompleto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeCompleto.Location = new System.Drawing.Point(87, 15);
            this.txtNomeCompleto.MaxLength = 50;
            this.txtNomeCompleto.Name = "txtNomeCompleto";
            this.txtNomeCompleto.Size = new System.Drawing.Size(535, 20);
            this.txtNomeCompleto.TabIndex = 4;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(2, 37);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 5;
            this.lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(5, 52);
            this.txtSenha.MaxLength = 10;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(233, 20);
            this.txtSenha.TabIndex = 6;
            // 
            // lblNivelUsuario
            // 
            this.lblNivelUsuario.AutoSize = true;
            this.lblNivelUsuario.Location = new System.Drawing.Point(479, 37);
            this.lblNivelUsuario.Name = "lblNivelUsuario";
            this.lblNivelUsuario.Size = new System.Drawing.Size(70, 13);
            this.lblNivelUsuario.TabIndex = 11;
            this.lblNivelUsuario.Text = "Nivel Usuário";
            // 
            // grdUsuario
            // 
            this.grdUsuario.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idusuario,
            this.nivelacesso,
            this.senha,
            this.nome,
            this.nomecompleto,
            this.nivelusuario});
            this.grdUsuario.Location = new System.Drawing.Point(5, 78);
            this.grdUsuario.Name = "grdUsuario";
            this.grdUsuario.ReadOnly = true;
            this.grdUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUsuario.Size = new System.Drawing.Size(619, 170);
            this.grdUsuario.TabIndex = 13;
            this.grdUsuario.DoubleClick += new System.EventHandler(this.grdUsuario_DoubleClick);
            // 
            // idusuario
            // 
            this.idusuario.DataPropertyName = "idusuario";
            this.idusuario.HeaderText = "Codigo";
            this.idusuario.Name = "idusuario";
            this.idusuario.ReadOnly = true;
            this.idusuario.Visible = false;
            // 
            // nivelacesso
            // 
            this.nivelacesso.DataPropertyName = "nivelacesso";
            this.nivelacesso.HeaderText = "Nivel de Acesso";
            this.nivelacesso.Name = "nivelacesso";
            this.nivelacesso.ReadOnly = true;
            this.nivelacesso.Visible = false;
            // 
            // senha
            // 
            this.senha.DataPropertyName = "senha";
            this.senha.HeaderText = "Senha";
            this.senha.Name = "senha";
            this.senha.ReadOnly = true;
            this.senha.Visible = false;
            // 
            // nome
            // 
            this.nome.DataPropertyName = "nome";
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            // 
            // nomecompleto
            // 
            this.nomecompleto.DataPropertyName = "nomecompleto";
            this.nomecompleto.HeaderText = "Nome Completo";
            this.nomecompleto.Name = "nomecompleto";
            this.nomecompleto.ReadOnly = true;
            this.nomecompleto.Width = 350;
            // 
            // nivelusuario
            // 
            this.nivelusuario.DataPropertyName = "nivelusuario";
            this.nivelusuario.HeaderText = "Nível Usuário";
            this.nivelusuario.Name = "nivelusuario";
            this.nivelusuario.ReadOnly = true;
            // 
            // lblConfirmaSenha
            // 
            this.lblConfirmaSenha.AutoSize = true;
            this.lblConfirmaSenha.Location = new System.Drawing.Point(241, 38);
            this.lblConfirmaSenha.Name = "lblConfirmaSenha";
            this.lblConfirmaSenha.Size = new System.Drawing.Size(82, 13);
            this.lblConfirmaSenha.TabIndex = 7;
            this.lblConfirmaSenha.Text = "Confirma Senha";
            // 
            // txtConfirmaSenha
            // 
            this.txtConfirmaSenha.Location = new System.Drawing.Point(244, 52);
            this.txtConfirmaSenha.MaxLength = 10;
            this.txtConfirmaSenha.Name = "txtConfirmaSenha";
            this.txtConfirmaSenha.PasswordChar = '*';
            this.txtConfirmaSenha.Size = new System.Drawing.Size(232, 20);
            this.txtConfirmaSenha.TabIndex = 8;
            // 
            // cboNivelUsuario
            // 
            this.cboNivelUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelUsuario.FormattingEnabled = true;
            this.cboNivelUsuario.Location = new System.Drawing.Point(482, 51);
            this.cboNivelUsuario.Name = "cboNivelUsuario";
            this.cboNivelUsuario.Size = new System.Drawing.Size(142, 21);
            this.cboNivelUsuario.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtIdUsuario);
            this.panel1.Controls.Add(this.grdUsuario);
            this.panel1.Controls.Add(this.lblNomeCompleto);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.cboNivelUsuario);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.txtConfirmaSenha);
            this.panel1.Controls.Add(this.txtNomeCompleto);
            this.panel1.Controls.Add(this.lblConfirmaSenha);
            this.panel1.Controls.Add(this.lblSenha);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.lblNivelUsuario);
            this.panel1.Location = new System.Drawing.Point(2, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 257);
            this.panel1.TabIndex = 15;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(362, 37);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(100, 12);
            this.txtIdUsuario.TabIndex = 15;
            this.txtIdUsuario.Visible = false;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.panel1);
            this.Name = "frmUsuario";
            this.Text = "Cadastro de Usuário";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuario)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNomeCompleto;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtNomeCompleto;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblNivelUsuario;
        private System.Windows.Forms.DataGridView grdUsuario;
        private System.Windows.Forms.Label lblConfirmaSenha;
        private System.Windows.Forms.TextBox txtConfirmaSenha;
        private System.Windows.Forms.ComboBox cboNivelUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelacesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn senha;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelusuario;
    }
}
