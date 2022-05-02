namespace EMCObras
{
    partial class frmObra
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
            this.grdObra = new System.Windows.Forms.DataGridView();
            this.abreviacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtainicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtafinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_cronograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtIdAplicacao = new MaskedNumber.MaskedNumber();
            this.btnAplicacao = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.btnContaCusto = new System.Windows.Forms.Button();
            this.txtIdObra_Cronograma = new System.Windows.Forms.TextBox();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.txtEngenheiro = new System.Windows.Forms.TextBox();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDtaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.txtIdContaCusto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContaCusto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtResponsavel_idUsuario = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDtaCronograma = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrcamentador = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtAprovador_idUsuario = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDtaAprovacao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAprovador = new System.Windows.Forms.TextBox();
            this.txtAlmoxarifado = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdEstq_Almoxarifado = new MaskedNumber.MaskedNumber();
            this.btnAlmoxarifado = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNroCEI = new System.Windows.Forms.MaskedTextBox();
            this.cboTipoContrato = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboObraPropria = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdObra
            // 
            this.grdObra.AllowUserToAddRows = false;
            this.grdObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.abreviacao,
            this.DescricaoObra,
            this.dtainicio,
            this.dtafinal,
            this.situacao,
            this.idobra_cronograma});
            this.grdObra.Location = new System.Drawing.Point(3, 313);
            this.grdObra.Name = "grdObra";
            this.grdObra.ReadOnly = true;
            this.grdObra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra.Size = new System.Drawing.Size(789, 186);
            this.grdObra.TabIndex = 1;
            this.grdObra.DoubleClick += new System.EventHandler(this.grdObra_DoubleClick);
            // 
            // abreviacao
            // 
            this.abreviacao.DataPropertyName = "abreviacao";
            this.abreviacao.HeaderText = "Código";
            this.abreviacao.Name = "abreviacao";
            this.abreviacao.ReadOnly = true;
            // 
            // DescricaoObra
            // 
            this.DescricaoObra.DataPropertyName = "descricao";
            this.DescricaoObra.HeaderText = "Descrição";
            this.DescricaoObra.Name = "DescricaoObra";
            this.DescricaoObra.ReadOnly = true;
            // 
            // dtainicio
            // 
            this.dtainicio.DataPropertyName = "dtainicio";
            this.dtainicio.HeaderText = "Início";
            this.dtainicio.Name = "dtainicio";
            this.dtainicio.ReadOnly = true;
            // 
            // dtafinal
            // 
            this.dtafinal.DataPropertyName = "dtafinal";
            this.dtafinal.HeaderText = "Final";
            this.dtafinal.Name = "dtafinal";
            this.dtafinal.ReadOnly = true;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            // 
            // idobra_cronograma
            // 
            this.idobra_cronograma.DataPropertyName = "idobra_cronograma";
            this.idobra_cronograma.HeaderText = "Id";
            this.idobra_cronograma.Name = "idobra_cronograma";
            this.idobra_cronograma.ReadOnly = true;
            this.idobra_cronograma.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cboObraPropria);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cboTipoContrato);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtNroCEI);
            this.panel1.Controls.Add(this.txtAlmoxarifado);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtIdEstq_Almoxarifado);
            this.panel1.Controls.Add(this.btnAlmoxarifado);
            this.panel1.Controls.Add(this.txtAplicacao);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtIdAplicacao);
            this.panel1.Controls.Add(this.btnAplicacao);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtSituacao);
            this.panel1.Controls.Add(this.btnContaCusto);
            this.panel1.Controls.Add(this.txtIdObra_Cronograma);
            this.panel1.Controls.Add(this.btnPessoa);
            this.panel1.Controls.Add(this.txtEngenheiro);
            this.panel1.Controls.Add(this.txtIdPessoa);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtDtaFinal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDtaInicio);
            this.panel1.Controls.Add(this.txtCodigoConta);
            this.panel1.Controls.Add(this.txtIdContaCusto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtContaCusto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDescricaoObra);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAbreviacao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 174);
            this.panel1.TabIndex = 2;
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAplicacao.Location = new System.Drawing.Point(82, 104);
            this.txtAplicacao.MaxLength = 50;
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.ReadOnly = true;
            this.txtAplicacao.Size = new System.Drawing.Size(310, 20);
            this.txtAplicacao.TabIndex = 283;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(6, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 282;
            this.label19.Text = "Aplicação";
            // 
            // txtIdAplicacao
            // 
            this.txtIdAplicacao.CustomFormat = "000000000";
            this.txtIdAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAplicacao.Format = MaskedNumberFormat.Custom;
            this.txtIdAplicacao.Location = new System.Drawing.Point(6, 104);
            this.txtIdAplicacao.MaxLength = 9;
            this.txtIdAplicacao.Name = "txtIdAplicacao";
            this.txtIdAplicacao.Size = new System.Drawing.Size(44, 20);
            this.txtIdAplicacao.TabIndex = 7;
            this.txtIdAplicacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdAplicacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdAplicacao_Validating);
            // 
            // btnAplicacao
            // 
            this.btnAplicacao.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnAplicacao.Location = new System.Drawing.Point(52, 102);
            this.btnAplicacao.Name = "btnAplicacao";
            this.btnAplicacao.Size = new System.Drawing.Size(31, 23);
            this.btnAplicacao.TabIndex = 280;
            this.btnAplicacao.UseVisualStyleBackColor = true;
            this.btnAplicacao.Click += new System.EventHandler(this.btnAplicacao_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(716, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 80;
            this.label12.Text = "Situação";
            // 
            // txtSituacao
            // 
            this.txtSituacao.Location = new System.Drawing.Point(719, 26);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.ReadOnly = true;
            this.txtSituacao.Size = new System.Drawing.Size(66, 20);
            this.txtSituacao.TabIndex = 79;
            // 
            // btnContaCusto
            // 
            this.btnContaCusto.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnContaCusto.Location = new System.Drawing.Point(369, 63);
            this.btnContaCusto.Name = "btnContaCusto";
            this.btnContaCusto.Size = new System.Drawing.Size(31, 23);
            this.btnContaCusto.TabIndex = 78;
            this.btnContaCusto.UseVisualStyleBackColor = true;
            this.btnContaCusto.Click += new System.EventHandler(this.btnContaCusto_Click);
            // 
            // txtIdObra_Cronograma
            // 
            this.txtIdObra_Cronograma.Location = new System.Drawing.Point(139, 3);
            this.txtIdObra_Cronograma.Name = "txtIdObra_Cronograma";
            this.txtIdObra_Cronograma.Size = new System.Drawing.Size(72, 20);
            this.txtIdObra_Cronograma.TabIndex = 77;
            this.txtIdObra_Cronograma.Visible = false;
            this.txtIdObra_Cronograma.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdObra_Cronograma_Validating);
            // 
            // btnPessoa
            // 
            this.btnPessoa.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnPessoa.Location = new System.Drawing.Point(233, 144);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(31, 23);
            this.btnPessoa.TabIndex = 76;
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // txtEngenheiro
            // 
            this.txtEngenheiro.Location = new System.Drawing.Point(266, 146);
            this.txtEngenheiro.Name = "txtEngenheiro";
            this.txtEngenheiro.ReadOnly = true;
            this.txtEngenheiro.Size = new System.Drawing.Size(517, 20);
            this.txtEngenheiro.TabIndex = 75;
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.Location = new System.Drawing.Point(191, 146);
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(40, 20);
            this.txtIdPessoa.TabIndex = 11;
            this.txtIdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPessoa_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Engenheiro - Responsável";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 72;
            this.label9.Text = "Código";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(96, 130);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "Data Final";
            // 
            // txtDtaFinal
            // 
            this.txtDtaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaFinal.Location = new System.Drawing.Point(98, 146);
            this.txtDtaFinal.Name = "txtDtaFinal";
            this.txtDtaFinal.Size = new System.Drawing.Size(88, 20);
            this.txtDtaFinal.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Data Início";
            // 
            // txtDtaInicio
            // 
            this.txtDtaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaInicio.Location = new System.Drawing.Point(6, 146);
            this.txtDtaInicio.Name = "txtDtaInicio";
            this.txtDtaInicio.Size = new System.Drawing.Size(88, 20);
            this.txtDtaInicio.TabIndex = 9;
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(267, 66);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(101, 20);
            this.txtCodigoConta.TabIndex = 6;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoConta_Validating);
            // 
            // txtIdContaCusto
            // 
            this.txtIdContaCusto.Location = new System.Drawing.Point(529, 47);
            this.txtIdContaCusto.Name = "txtIdContaCusto";
            this.txtIdContaCusto.Size = new System.Drawing.Size(89, 20);
            this.txtIdContaCusto.TabIndex = 11;
            this.txtIdContaCusto.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Descrição";
            // 
            // txtContaCusto
            // 
            this.txtContaCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContaCusto.Location = new System.Drawing.Point(401, 66);
            this.txtContaCusto.MaxLength = 50;
            this.txtContaCusto.Name = "txtContaCusto";
            this.txtContaCusto.ReadOnly = true;
            this.txtContaCusto.Size = new System.Drawing.Size(384, 20);
            this.txtContaCusto.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Número Conta";
            // 
            // txtDescricaoObra
            // 
            this.txtDescricaoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoObra.Location = new System.Drawing.Point(73, 26);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.Size = new System.Drawing.Size(439, 20);
            this.txtDescricaoObra.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
            // 
            // txtAbreviacao
            // 
            this.txtAbreviacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviacao.Location = new System.Drawing.Point(3, 26);
            this.txtAbreviacao.Name = "txtAbreviacao";
            this.txtAbreviacao.Size = new System.Drawing.Size(67, 20);
            this.txtAbreviacao.TabIndex = 1;
            this.txtAbreviacao.TextChanged += new System.EventHandler(this.txtAbreviacao_TextChanged);
            this.txtAbreviacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbreviacao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtResponsavel_idUsuario);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtDtaCronograma);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtOrcamentador);
            this.panel2.Location = new System.Drawing.Point(2, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 53);
            this.panel2.TabIndex = 3;
            // 
            // txtResponsavel_idUsuario
            // 
            this.txtResponsavel_idUsuario.Location = new System.Drawing.Point(140, 2);
            this.txtResponsavel_idUsuario.Name = "txtResponsavel_idUsuario";
            this.txtResponsavel_idUsuario.Size = new System.Drawing.Size(41, 20);
            this.txtResponsavel_idUsuario.TabIndex = 40;
            this.txtResponsavel_idUsuario.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Data Cadastro";
            // 
            // txtDtaCronograma
            // 
            this.txtDtaCronograma.Enabled = false;
            this.txtDtaCronograma.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaCronograma.Location = new System.Drawing.Point(322, 25);
            this.txtDtaCronograma.Name = "txtDtaCronograma";
            this.txtDtaCronograma.Size = new System.Drawing.Size(88, 20);
            this.txtDtaCronograma.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Usuário Orçamentador";
            // 
            // txtOrcamentador
            // 
            this.txtOrcamentador.Enabled = false;
            this.txtOrcamentador.Location = new System.Drawing.Point(7, 25);
            this.txtOrcamentador.Name = "txtOrcamentador";
            this.txtOrcamentador.ReadOnly = true;
            this.txtOrcamentador.Size = new System.Drawing.Size(309, 20);
            this.txtOrcamentador.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtAprovador_idUsuario);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDtaAprovacao);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtAprovador);
            this.panel3.Location = new System.Drawing.Point(421, 254);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 53);
            this.panel3.TabIndex = 4;
            // 
            // txtAprovador_idUsuario
            // 
            this.txtAprovador_idUsuario.Location = new System.Drawing.Point(105, 2);
            this.txtAprovador_idUsuario.Name = "txtAprovador_idUsuario";
            this.txtAprovador_idUsuario.Size = new System.Drawing.Size(84, 20);
            this.txtAprovador_idUsuario.TabIndex = 42;
            this.txtAprovador_idUsuario.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Data Aprovação";
            // 
            // txtDtaAprovacao
            // 
            this.txtDtaAprovacao.Enabled = false;
            this.txtDtaAprovacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaAprovacao.Location = new System.Drawing.Point(278, 25);
            this.txtDtaAprovacao.Name = "txtDtaAprovacao";
            this.txtDtaAprovacao.Size = new System.Drawing.Size(88, 20);
            this.txtDtaAprovacao.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Usuário Aprovador";
            // 
            // txtAprovador
            // 
            this.txtAprovador.Enabled = false;
            this.txtAprovador.Location = new System.Drawing.Point(5, 25);
            this.txtAprovador.Name = "txtAprovador";
            this.txtAprovador.ReadOnly = true;
            this.txtAprovador.Size = new System.Drawing.Size(267, 20);
            this.txtAprovador.TabIndex = 38;
            // 
            // txtAlmoxarifado
            // 
            this.txtAlmoxarifado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlmoxarifado.Location = new System.Drawing.Point(463, 105);
            this.txtAlmoxarifado.MaxLength = 50;
            this.txtAlmoxarifado.Name = "txtAlmoxarifado";
            this.txtAlmoxarifado.ReadOnly = true;
            this.txtAlmoxarifado.Size = new System.Drawing.Size(320, 20);
            this.txtAlmoxarifado.TabIndex = 287;
            this.txtAlmoxarifado.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(395, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 286;
            this.label13.Text = "Almoxarifado";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtIdEstq_Almoxarifado
            // 
            this.txtIdEstq_Almoxarifado.CustomFormat = "000000000";
            this.txtIdEstq_Almoxarifado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdEstq_Almoxarifado.Format = MaskedNumberFormat.Custom;
            this.txtIdEstq_Almoxarifado.Location = new System.Drawing.Point(395, 105);
            this.txtIdEstq_Almoxarifado.MaxLength = 9;
            this.txtIdEstq_Almoxarifado.Name = "txtIdEstq_Almoxarifado";
            this.txtIdEstq_Almoxarifado.Size = new System.Drawing.Size(37, 20);
            this.txtIdEstq_Almoxarifado.TabIndex = 8;
            this.txtIdEstq_Almoxarifado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdEstq_Almoxarifado.TextChanged += new System.EventHandler(this.maskedNumber1_TextChanged);
            this.txtIdEstq_Almoxarifado.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEstq_Almoxarifado_Validating);
            // 
            // btnAlmoxarifado
            // 
            this.btnAlmoxarifado.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnAlmoxarifado.Location = new System.Drawing.Point(433, 103);
            this.btnAlmoxarifado.Name = "btnAlmoxarifado";
            this.btnAlmoxarifado.Size = new System.Drawing.Size(31, 23);
            this.btnAlmoxarifado.TabIndex = 285;
            this.btnAlmoxarifado.UseVisualStyleBackColor = true;
            this.btnAlmoxarifado.Click += new System.EventHandler(this.btnAlmoxarifado_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(512, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 289;
            this.label14.Text = "CEI";
            // 
            // txtNroCEI
            // 
            this.txtNroCEI.Location = new System.Drawing.Point(515, 26);
            this.txtNroCEI.Mask = "00.000.00000/00";
            this.txtNroCEI.Name = "txtNroCEI";
            this.txtNroCEI.PromptChar = ' ';
            this.txtNroCEI.Size = new System.Drawing.Size(112, 20);
            this.txtNroCEI.TabIndex = 3;
            this.txtNroCEI.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cboTipoContrato
            // 
            this.cboTipoContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoContrato.FormattingEnabled = true;
            this.cboTipoContrato.Location = new System.Drawing.Point(6, 65);
            this.cboTipoContrato.Name = "cboTipoContrato";
            this.cboTipoContrato.Size = new System.Drawing.Size(255, 21);
            this.cboTipoContrato.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 291;
            this.label15.Text = "Tipo Contrato";
            // 
            // cboObraPropria
            // 
            this.cboObraPropria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObraPropria.FormattingEnabled = true;
            this.cboObraPropria.Location = new System.Drawing.Point(631, 25);
            this.cboObraPropria.Name = "cboObraPropria";
            this.cboObraPropria.Size = new System.Drawing.Size(84, 21);
            this.cboObraPropria.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(633, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 293;
            this.label16.Text = "Obra Própria";
            // 
            // frmObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(796, 502);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdObra);
            this.MaximizeBox = false;
            this.Name = "frmObra";
            this.Text = "Obra";
            this.Load += new System.EventHandler(this.frmObra_Load);
            this.Controls.SetChildIndex(this.grdObra, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdObra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;
        private System.Windows.Forms.TextBox txtIdContaCusto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContaCusto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDtaInicio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrcamentador;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAprovador;
        private System.Windows.Forms.Button btnPessoa;
        private System.Windows.Forms.TextBox txtEngenheiro;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdObra_Cronograma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtDtaCronograma;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtDtaAprovacao;
        private System.Windows.Forms.TextBox txtResponsavel_idUsuario;
        private System.Windows.Forms.TextBox txtAprovador_idUsuario;
        private System.Windows.Forms.Button btnContaCusto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSituacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtainicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtafinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_cronograma;
        private System.Windows.Forms.TextBox txtAplicacao;
        private System.Windows.Forms.Label label19;
        private MaskedNumber.MaskedNumber txtIdAplicacao;
        private System.Windows.Forms.Button btnAplicacao;
        private System.Windows.Forms.TextBox txtAlmoxarifado;
        private System.Windows.Forms.Label label13;
        private MaskedNumber.MaskedNumber txtIdEstq_Almoxarifado;
        private System.Windows.Forms.Button btnAlmoxarifado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtNroCEI;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboTipoContrato;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboObraPropria;
    }
}
