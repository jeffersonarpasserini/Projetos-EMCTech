namespace EMCSecurity
{
    partial class frmMenuUsuario
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
            this.cboIdUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.txtMenuPai = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboExclusivoJlm = new System.Windows.Forms.ComboBox();
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
            this.label15 = new System.Windows.Forms.Label();
            this.grdMenuUsuario = new System.Windows.Forms.DataGridView();
            this.idusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmenusistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nnamespace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaomenuuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlimagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemseguranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indicadorabertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menupai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exclusivojlm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboImpressao = new System.Windows.Forms.ComboBox();
            this.cboOcorrencia = new System.Windows.Forms.ComboBox();
            this.cboExclusao = new System.Windows.Forms.ComboBox();
            this.cboAlteracao = new System.Windows.Forms.ComboBox();
            this.cboInclusao = new System.Windows.Forms.ComboBox();
            this.cboExecuta = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboNivelUsuario = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenuUsuario)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboIdUsuario
            // 
            this.cboIdUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdUsuario.FormattingEnabled = true;
            this.cboIdUsuario.Location = new System.Drawing.Point(3, 15);
            this.cboIdUsuario.Name = "cboIdUsuario";
            this.cboIdUsuario.Size = new System.Drawing.Size(619, 21);
            this.cboIdUsuario.TabIndex = 1;
            this.cboIdUsuario.SelectedIndexChanged += new System.EventHandler(this.cboIdUsuario_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Usuário";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtNivel);
            this.panel1.Controls.Add(this.txtMenuPai);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cboExclusivoJlm);
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
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboIdUsuario);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 190);
            this.panel1.TabIndex = 3;
            // 
            // txtNivel
            // 
            this.txtNivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNivel.Location = new System.Drawing.Point(258, 165);
            this.txtNivel.MaxLength = 11;
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.ReadOnly = true;
            this.txtNivel.Size = new System.Drawing.Size(125, 20);
            this.txtNivel.TabIndex = 12;
            // 
            // txtMenuPai
            // 
            this.txtMenuPai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMenuPai.Location = new System.Drawing.Point(131, 165);
            this.txtMenuPai.MaxLength = 11;
            this.txtMenuPai.Name = "txtMenuPai";
            this.txtMenuPai.ReadOnly = true;
            this.txtMenuPai.Size = new System.Drawing.Size(125, 20);
            this.txtMenuPai.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(101, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 102;
            this.label14.Text = "Módulo";
            // 
            // cboExclusivoJlm
            // 
            this.cboExclusivoJlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExclusivoJlm.FormattingEnabled = true;
            this.cboExclusivoJlm.Location = new System.Drawing.Point(506, 164);
            this.cboExclusivoJlm.Name = "cboExclusivoJlm";
            this.cboExclusivoJlm.Size = new System.Drawing.Size(117, 21);
            this.cboExclusivoJlm.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(508, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 113;
            this.label12.Text = "Exclusivo JLM";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(258, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 112;
            this.label11.Text = "Nível";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 111;
            this.label10.Text = "Menu Pai";
            // 
            // txtOrdem
            // 
            this.txtOrdem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrdem.Location = new System.Drawing.Point(3, 165);
            this.txtOrdem.MaxLength = 11;
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.ReadOnly = true;
            this.txtOrdem.Size = new System.Drawing.Size(125, 20);
            this.txtOrdem.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "Ordem";
            // 
            // cboIndicadorAbertura
            // 
            this.cboIndicadorAbertura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndicadorAbertura.FormattingEnabled = true;
            this.cboIndicadorAbertura.Location = new System.Drawing.Point(387, 164);
            this.cboIndicadorAbertura.Name = "cboIndicadorAbertura";
            this.cboIndicadorAbertura.Size = new System.Drawing.Size(117, 21);
            this.cboIndicadorAbertura.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(386, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 109;
            this.label8.Text = "Indicador Abertura";
            // 
            // cboItemSeguranca
            // 
            this.cboItemSeguranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemSeguranca.FormattingEnabled = true;
            this.cboItemSeguranca.Location = new System.Drawing.Point(506, 127);
            this.cboItemSeguranca.Name = "cboItemSeguranca";
            this.cboItemSeguranca.Size = new System.Drawing.Size(116, 21);
            this.cboItemSeguranca.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(516, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "Item Segurança";
            // 
            // cboExibeImagem
            // 
            this.cboExibeImagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExibeImagem.FormattingEnabled = true;
            this.cboExibeImagem.Location = new System.Drawing.Point(387, 127);
            this.cboExibeImagem.Name = "cboExibeImagem";
            this.cboExibeImagem.Size = new System.Drawing.Size(117, 21);
            this.cboExibeImagem.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(408, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "Exibe Imagem";
            // 
            // txtModulo
            // 
            this.txtModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModulo.Location = new System.Drawing.Point(100, 54);
            this.txtModulo.MaxLength = 20;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.ReadOnly = true;
            this.txtModulo.Size = new System.Drawing.Size(149, 20);
            this.txtModulo.TabIndex = 3;
            // 
            // txtUrlImagem
            // 
            this.txtUrlImagem.Location = new System.Drawing.Point(3, 128);
            this.txtUrlImagem.MaxLength = 150;
            this.txtUrlImagem.Name = "txtUrlImagem";
            this.txtUrlImagem.ReadOnly = true;
            this.txtUrlImagem.Size = new System.Drawing.Size(380, 20);
            this.txtUrlImagem.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "URL Imagem";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(297, 92);
            this.txtEndereco.MaxLength = 50;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.ReadOnly = true;
            this.txtEndereco.Size = new System.Drawing.Size(326, 20);
            this.txtEndereco.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 105;
            this.label4.Text = "Endereço";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(3, 92);
            this.txtNamespace.MaxLength = 50;
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.ReadOnly = true;
            this.txtNamespace.Size = new System.Drawing.Size(290, 20);
            this.txtNamespace.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "NameSpace";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(251, 54);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(371, 20);
            this.txtDescricao.TabIndex = 4;
            // 
            // txtIdMenuSistema
            // 
            this.txtIdMenuSistema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdMenuSistema.Location = new System.Drawing.Point(3, 54);
            this.txtIdMenuSistema.MaxLength = 11;
            this.txtIdMenuSistema.Name = "txtIdMenuSistema";
            this.txtIdMenuSistema.ReadOnly = true;
            this.txtIdMenuSistema.Size = new System.Drawing.Size(95, 20);
            this.txtIdMenuSistema.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 88;
            this.label15.Text = "Código";
            // 
            // grdMenuUsuario
            // 
            this.grdMenuUsuario.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdMenuUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMenuUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdMenuUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMenuUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idusuario,
            this.modulo,
            this.idmenusistema,
            this.nnamespace,
            this.descricaomenuuser,
            this.endereco,
            this.urlimagem,
            this.itemseguranca,
            this.indicadorabertura,
            this.ordem,
            this.menupai,
            this.nivel,
            this.exclusivojlm,
            this.nivelusuario});
            this.grdMenuUsuario.Location = new System.Drawing.Point(4, 310);
            this.grdMenuUsuario.Name = "grdMenuUsuario";
            this.grdMenuUsuario.ReadOnly = true;
            this.grdMenuUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMenuUsuario.Size = new System.Drawing.Size(627, 149);
            this.grdMenuUsuario.TabIndex = 3;
            this.grdMenuUsuario.DoubleClick += new System.EventHandler(this.grdMenuUsuario_DoubleClick);
            // 
            // idusuario
            // 
            this.idusuario.DataPropertyName = "idusuario";
            this.idusuario.HeaderText = "Usuario";
            this.idusuario.Name = "idusuario";
            this.idusuario.ReadOnly = true;
            this.idusuario.Width = 50;
            // 
            // modulo
            // 
            this.modulo.DataPropertyName = "modulo";
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.ReadOnly = true;
            // 
            // idmenusistema
            // 
            this.idmenusistema.DataPropertyName = "idmenusistema";
            this.idmenusistema.HeaderText = "Menu Sistema";
            this.idmenusistema.Name = "idmenusistema";
            this.idmenusistema.ReadOnly = true;
            this.idmenusistema.Width = 50;
            // 
            // nnamespace
            // 
            this.nnamespace.DataPropertyName = "namespace";
            this.nnamespace.HeaderText = "Namespace";
            this.nnamespace.Name = "nnamespace";
            this.nnamespace.ReadOnly = true;
            // 
            // descricaomenuuser
            // 
            this.descricaomenuuser.DataPropertyName = "descricao";
            this.descricaomenuuser.HeaderText = "Descrição";
            this.descricaomenuuser.Name = "descricaomenuuser";
            this.descricaomenuuser.ReadOnly = true;
            // 
            // endereco
            // 
            this.endereco.DataPropertyName = "endereco";
            this.endereco.HeaderText = "Endereço";
            this.endereco.Name = "endereco";
            this.endereco.ReadOnly = true;
            // 
            // urlimagem
            // 
            this.urlimagem.DataPropertyName = "urlimagem";
            this.urlimagem.HeaderText = "URL Imagem";
            this.urlimagem.Name = "urlimagem";
            this.urlimagem.ReadOnly = true;
            // 
            // itemseguranca
            // 
            this.itemseguranca.DataPropertyName = "itemseguranca";
            this.itemseguranca.HeaderText = "Item Segurança";
            this.itemseguranca.Name = "itemseguranca";
            this.itemseguranca.ReadOnly = true;
            // 
            // indicadorabertura
            // 
            this.indicadorabertura.DataPropertyName = "indicadorabertura";
            this.indicadorabertura.HeaderText = "Indicador Abertura";
            this.indicadorabertura.Name = "indicadorabertura";
            this.indicadorabertura.ReadOnly = true;
            // 
            // ordem
            // 
            this.ordem.DataPropertyName = "ordem";
            this.ordem.HeaderText = "Ordem";
            this.ordem.Name = "ordem";
            this.ordem.ReadOnly = true;
            // 
            // menupai
            // 
            this.menupai.DataPropertyName = "menupai";
            this.menupai.HeaderText = "Menu Pai";
            this.menupai.Name = "menupai";
            this.menupai.ReadOnly = true;
            // 
            // nivel
            // 
            this.nivel.DataPropertyName = "nivel";
            this.nivel.HeaderText = "Nível";
            this.nivel.Name = "nivel";
            this.nivel.ReadOnly = true;
            // 
            // exclusivojlm
            // 
            this.exclusivojlm.DataPropertyName = "exclusivojlm";
            this.exclusivojlm.HeaderText = "Exclusivo JLM";
            this.exclusivojlm.Name = "exclusivojlm";
            this.exclusivojlm.ReadOnly = true;
            // 
            // nivelusuario
            // 
            this.nivelusuario.DataPropertyName = "nivelusuario";
            this.nivelusuario.HeaderText = "Nível Usuário";
            this.nivelusuario.Name = "nivelusuario";
            this.nivelusuario.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cboImpressao);
            this.panel2.Controls.Add(this.cboOcorrencia);
            this.panel2.Controls.Add(this.cboExclusao);
            this.panel2.Controls.Add(this.cboAlteracao);
            this.panel2.Controls.Add(this.cboInclusao);
            this.panel2.Controls.Add(this.cboExecuta);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cboNivelUsuario);
            this.panel2.Location = new System.Drawing.Point(2, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 41);
            this.panel2.TabIndex = 4;
            // 
            // cboImpressao
            // 
            this.cboImpressao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpressao.FormattingEnabled = true;
            this.cboImpressao.Location = new System.Drawing.Point(541, 15);
            this.cboImpressao.Name = "cboImpressao";
            this.cboImpressao.Size = new System.Drawing.Size(83, 21);
            this.cboImpressao.TabIndex = 21;
            // 
            // cboOcorrencia
            // 
            this.cboOcorrencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOcorrencia.FormattingEnabled = true;
            this.cboOcorrencia.Location = new System.Drawing.Point(456, 15);
            this.cboOcorrencia.Name = "cboOcorrencia";
            this.cboOcorrencia.Size = new System.Drawing.Size(83, 21);
            this.cboOcorrencia.TabIndex = 20;
            // 
            // cboExclusao
            // 
            this.cboExclusao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExclusao.FormattingEnabled = true;
            this.cboExclusao.Location = new System.Drawing.Point(371, 15);
            this.cboExclusao.Name = "cboExclusao";
            this.cboExclusao.Size = new System.Drawing.Size(83, 21);
            this.cboExclusao.TabIndex = 19;
            // 
            // cboAlteracao
            // 
            this.cboAlteracao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlteracao.FormattingEnabled = true;
            this.cboAlteracao.Location = new System.Drawing.Point(286, 15);
            this.cboAlteracao.Name = "cboAlteracao";
            this.cboAlteracao.Size = new System.Drawing.Size(83, 21);
            this.cboAlteracao.TabIndex = 18;
            // 
            // cboInclusao
            // 
            this.cboInclusao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInclusao.FormattingEnabled = true;
            this.cboInclusao.Location = new System.Drawing.Point(201, 15);
            this.cboInclusao.Name = "cboInclusao";
            this.cboInclusao.Size = new System.Drawing.Size(83, 21);
            this.cboInclusao.TabIndex = 17;
            // 
            // cboExecuta
            // 
            this.cboExecuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExecuta.FormattingEnabled = true;
            this.cboExecuta.Location = new System.Drawing.Point(116, 15);
            this.cboExecuta.Name = "cboExecuta";
            this.cboExecuta.Size = new System.Drawing.Size(83, 21);
            this.cboExecuta.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(541, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 102;
            this.label21.Text = "Impressão";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(456, 1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 101;
            this.label20.Text = "Ocorrência";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(370, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 13);
            this.label19.TabIndex = 100;
            this.label19.Text = "Exclusão";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(286, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 99;
            this.label18.Text = "Alteração";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(202, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 98;
            this.label17.Text = "Inclusão";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(-1, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "Nível Usuário";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(116, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 97;
            this.label16.Text = "Executa";
            // 
            // cboNivelUsuario
            // 
            this.cboNivelUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelUsuario.FormattingEnabled = true;
            this.cboNivelUsuario.Location = new System.Drawing.Point(3, 15);
            this.cboNivelUsuario.Name = "cboNivelUsuario";
            this.cboNivelUsuario.Size = new System.Drawing.Size(111, 21);
            this.cboNivelUsuario.TabIndex = 15;
            // 
            // frmMenuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdMenuUsuario);
            this.Name = "frmMenuUsuario";
            this.Text = "Menu Usuário";
            this.Load += new System.EventHandler(this.frmMenuUsuario_Load);
            this.Controls.SetChildIndex(this.grdMenuUsuario, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMenuUsuario)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboIdUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdMenuUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.TextBox txtMenuPai;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboExclusivoJlm;
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboImpressao;
        private System.Windows.Forms.ComboBox cboOcorrencia;
        private System.Windows.Forms.ComboBox cboExclusao;
        private System.Windows.Forms.ComboBox cboAlteracao;
        private System.Windows.Forms.ComboBox cboInclusao;
        private System.Windows.Forms.ComboBox cboExecuta;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboNivelUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmenusistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn nnamespace;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaomenuuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlimagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemseguranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn indicadorabertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordem;
        private System.Windows.Forms.DataGridViewTextBoxColumn menupai;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusivojlm;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelusuario;
    }
}
