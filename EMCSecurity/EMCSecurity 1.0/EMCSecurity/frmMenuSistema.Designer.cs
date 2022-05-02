namespace EMCSecurity
{
    partial class frmMenuSistema
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
            this.grdMenuSistema = new System.Windows.Forms.DataGridView();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmenusistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaomenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNamespace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlimagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exibeimagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemseguranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indicadorabertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menupai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusivojlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.txtMenuPai = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboNivelUsuario = new System.Windows.Forms.ComboBox();
            this.cboExclusivoJlm = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrdem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboIndicadorAbertura = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboItemSeguranca = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboExibeImagem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.txtUrlImagem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtIdMenuSistema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenuSistema)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.grdMenuSistema);
            this.panel1.Controls.Add(this.txtNivel);
            this.panel1.Controls.Add(this.txtMenuPai);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cboNivelUsuario);
            this.panel1.Controls.Add(this.cboExclusivoJlm);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtOrdem);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboIndicadorAbertura);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboItemSeguranca);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboExibeImagem);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtModulo);
            this.panel1.Controls.Add(this.txtUrlImagem);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEndereco);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNamespace);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtIdMenuSistema);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 350);
            this.panel1.TabIndex = 1;
            // 
            // grdMenuSistema
            // 
            this.grdMenuSistema.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdMenuSistema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMenuSistema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdMenuSistema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMenuSistema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modulo,
            this.idmenusistema,
            this.endereco,
            this.descricaomenu,
            this.nNamespace,
            this.urlimagem,
            this.exibeimagem,
            this.itemseguranca,
            this.indicadorabertura,
            this.ordem,
            this.menupai,
            this.nivel,
            this.exclusivojlm,
            this.nivelusuario});
            this.grdMenuSistema.Location = new System.Drawing.Point(5, 151);
            this.grdMenuSistema.Name = "grdMenuSistema";
            this.grdMenuSistema.ReadOnly = true;
            this.grdMenuSistema.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMenuSistema.Size = new System.Drawing.Size(617, 191);
            this.grdMenuSistema.TabIndex = 61;
            this.grdMenuSistema.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMenuSistema_CellContentClick);
            this.grdMenuSistema.DoubleClick += new System.EventHandler(this.grdMenuSistema_DoubleClick);
            // 
            // modulo
            // 
            this.modulo.DataPropertyName = "modulo";
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.ReadOnly = true;
            this.modulo.Width = 120;
            // 
            // idmenusistema
            // 
            this.idmenusistema.DataPropertyName = "idmenusistema";
            this.idmenusistema.HeaderText = "Código";
            this.idmenusistema.Name = "idmenusistema";
            this.idmenusistema.ReadOnly = true;
            this.idmenusistema.Width = 75;
            // 
            // endereco
            // 
            this.endereco.DataPropertyName = "endereco";
            this.endereco.HeaderText = "Endereço";
            this.endereco.Name = "endereco";
            this.endereco.ReadOnly = true;
            this.endereco.Width = 120;
            // 
            // descricaomenu
            // 
            this.descricaomenu.DataPropertyName = "descricao";
            this.descricaomenu.HeaderText = "Descrição";
            this.descricaomenu.Name = "descricaomenu";
            this.descricaomenu.ReadOnly = true;
            this.descricaomenu.Width = 250;
            // 
            // nNamespace
            // 
            this.nNamespace.DataPropertyName = "namespace";
            this.nNamespace.HeaderText = "Namespace";
            this.nNamespace.Name = "nNamespace";
            this.nNamespace.ReadOnly = true;
            this.nNamespace.Visible = false;
            // 
            // urlimagem
            // 
            this.urlimagem.DataPropertyName = "urlimagem";
            this.urlimagem.HeaderText = "URL Imagem";
            this.urlimagem.Name = "urlimagem";
            this.urlimagem.ReadOnly = true;
            this.urlimagem.Visible = false;
            // 
            // exibeimagem
            // 
            this.exibeimagem.DataPropertyName = "exibeimagem";
            this.exibeimagem.HeaderText = "Exibe Imagem";
            this.exibeimagem.Name = "exibeimagem";
            this.exibeimagem.ReadOnly = true;
            this.exibeimagem.Visible = false;
            // 
            // itemseguranca
            // 
            this.itemseguranca.DataPropertyName = "itemseguranca";
            this.itemseguranca.HeaderText = "Item Segurança";
            this.itemseguranca.Name = "itemseguranca";
            this.itemseguranca.ReadOnly = true;
            this.itemseguranca.Visible = false;
            // 
            // indicadorabertura
            // 
            this.indicadorabertura.DataPropertyName = "indicadorabertura";
            this.indicadorabertura.HeaderText = "Indicador Abertura";
            this.indicadorabertura.Name = "indicadorabertura";
            this.indicadorabertura.ReadOnly = true;
            this.indicadorabertura.Visible = false;
            // 
            // ordem
            // 
            this.ordem.DataPropertyName = "ordem";
            this.ordem.HeaderText = "Ordem";
            this.ordem.Name = "ordem";
            this.ordem.ReadOnly = true;
            this.ordem.Visible = false;
            // 
            // menupai
            // 
            this.menupai.DataPropertyName = "menupai";
            this.menupai.HeaderText = "Menu Pai";
            this.menupai.Name = "menupai";
            this.menupai.ReadOnly = true;
            this.menupai.Visible = false;
            // 
            // nivel
            // 
            this.nivel.DataPropertyName = "nivel";
            this.nivel.HeaderText = "Nível";
            this.nivel.Name = "nivel";
            this.nivel.ReadOnly = true;
            this.nivel.Visible = false;
            // 
            // exclusivojlm
            // 
            this.exclusivojlm.DataPropertyName = "exclusivojlm";
            this.exclusivojlm.HeaderText = "Exclusivo JLM";
            this.exclusivojlm.Name = "exclusivojlm";
            this.exclusivojlm.ReadOnly = true;
            this.exclusivojlm.Visible = false;
            // 
            // nivelusuario
            // 
            this.nivelusuario.DataPropertyName = "nivelusuario";
            this.nivelusuario.HeaderText = "Nivel Usuário";
            this.nivelusuario.Name = "nivelusuario";
            this.nivelusuario.ReadOnly = true;
            this.nivelusuario.Visible = false;
            // 
            // txtNivel
            // 
            this.txtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNivel.Location = new System.Drawing.Point(253, 125);
            this.txtNivel.MaxLength = 11;
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(122, 20);
            this.txtNivel.TabIndex = 12;
            // 
            // txtMenuPai
            // 
            this.txtMenuPai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMenuPai.Location = new System.Drawing.Point(129, 125);
            this.txtMenuPai.MaxLength = 11;
            this.txtMenuPai.Name = "txtMenuPai";
            this.txtMenuPai.Size = new System.Drawing.Size(122, 20);
            this.txtMenuPai.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(103, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 48;
            this.label14.Text = "Módulo";
            // 
            // cboNivelUsuario
            // 
            this.cboNivelUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelUsuario.FormattingEnabled = true;
            this.cboNivelUsuario.Location = new System.Drawing.Point(501, 124);
            this.cboNivelUsuario.Name = "cboNivelUsuario";
            this.cboNivelUsuario.Size = new System.Drawing.Size(122, 21);
            this.cboNivelUsuario.TabIndex = 14;
            // 
            // cboExclusivoJlm
            // 
            this.cboExclusivoJlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExclusivoJlm.FormattingEnabled = true;
            this.cboExclusivoJlm.Location = new System.Drawing.Point(377, 124);
            this.cboExclusivoJlm.Name = "cboExclusivoJlm";
            this.cboExclusivoJlm.Size = new System.Drawing.Size(122, 21);
            this.cboExclusivoJlm.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(505, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Nível Usuário";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(378, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Exclusivo JLM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(252, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Nível";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Menu Pai";
            // 
            // txtOrdem
            // 
            this.txtOrdem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrdem.Location = new System.Drawing.Point(5, 125);
            this.txtOrdem.MaxLength = 11;
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.Size = new System.Drawing.Size(122, 20);
            this.txtOrdem.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Ordem";
            // 
            // cboIndicadorAbertura
            // 
            this.cboIndicadorAbertura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndicadorAbertura.FormattingEnabled = true;
            this.cboIndicadorAbertura.Location = new System.Drawing.Point(508, 89);
            this.cboIndicadorAbertura.Name = "cboIndicadorAbertura";
            this.cboIndicadorAbertura.Size = new System.Drawing.Size(115, 21);
            this.cboIndicadorAbertura.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(509, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Indicador Abertura";
            // 
            // cboItemSeguranca
            // 
            this.cboItemSeguranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemSeguranca.FormattingEnabled = true;
            this.cboItemSeguranca.Location = new System.Drawing.Point(401, 89);
            this.cboItemSeguranca.Name = "cboItemSeguranca";
            this.cboItemSeguranca.Size = new System.Drawing.Size(104, 21);
            this.cboItemSeguranca.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Item Segurança";
            // 
            // cboExibeImagem
            // 
            this.cboExibeImagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExibeImagem.FormattingEnabled = true;
            this.cboExibeImagem.Location = new System.Drawing.Point(303, 89);
            this.cboExibeImagem.Name = "cboExibeImagem";
            this.cboExibeImagem.Size = new System.Drawing.Size(95, 21);
            this.cboExibeImagem.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Exibe Imagem";
            // 
            // txtModulo
            // 
            this.txtModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModulo.Location = new System.Drawing.Point(102, 16);
            this.txtModulo.MaxLength = 20;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(149, 20);
            this.txtModulo.TabIndex = 2;
            this.txtModulo.TextChanged += new System.EventHandler(this.txtModulo_TextChanged);
            this.txtModulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtModulo_Validating);
            // 
            // txtUrlImagem
            // 
            this.txtUrlImagem.Location = new System.Drawing.Point(5, 90);
            this.txtUrlImagem.MaxLength = 150;
            this.txtUrlImagem.Name = "txtUrlImagem";
            this.txtUrlImagem.Size = new System.Drawing.Size(295, 20);
            this.txtUrlImagem.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "URL Imagem";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(299, 54);
            this.txtEndereco.MaxLength = 50;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(325, 20);
            this.txtEndereco.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Endereço";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(5, 54);
            this.txtNamespace.MaxLength = 50;
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(290, 20);
            this.txtNamespace.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "NameSpace";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(253, 16);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(370, 20);
            this.txtDescricao.TabIndex = 3;
            // 
            // txtIdMenuSistema
            // 
            this.txtIdMenuSistema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdMenuSistema.Location = new System.Drawing.Point(5, 16);
            this.txtIdMenuSistema.MaxLength = 11;
            this.txtIdMenuSistema.Name = "txtIdMenuSistema";
            this.txtIdMenuSistema.Size = new System.Drawing.Size(95, 20);
            this.txtIdMenuSistema.TabIndex = 1;
            this.txtIdMenuSistema.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdMenuSistema_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // frmMenuSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 427);
            this.Controls.Add(this.panel1);
            this.Name = "frmMenuSistema";
            this.Text = "Menu Sistema";
            this.Load += new System.EventHandler(this.frmMenuSistema_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenuSistema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboNivelUsuario;
        private System.Windows.Forms.ComboBox cboExclusivoJlm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrdem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboIndicadorAbertura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboItemSeguranca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboExibeImagem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.TextBox txtUrlImagem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtIdMenuSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.TextBox txtMenuPai;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView grdMenuSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmenusistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaomenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNamespace;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlimagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn exibeimagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemseguranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn indicadorabertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn menupai;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusivojlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelusuario;
    }
}
