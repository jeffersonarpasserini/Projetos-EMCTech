namespace EMCFinanceiro
{
    partial class frmTarifasBancarias
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCNPJ = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtIdFornecedor = new System.Windows.Forms.TextBox();
            this.grdTarifa = new System.Windows.Forms.DataGridView();
            this.txtIdPagarDocumento = new System.Windows.Forms.TextBox();
            this.txtIdTarifaBancaria = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtValorTarifa = new MaskedNumber.MaskedNumber();
            this.label8 = new System.Windows.Forms.Label();
            this.cboIdContaBancaria = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboIdTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDataTarifa = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtIdAplicacao = new MaskedNumber.MaskedNumber();
            this.btnContaCusto = new System.Windows.Forms.Button();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.txtIdContaCusto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContaCusto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBaixaTarifa = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.cboHistorico = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIdFormaPagamento = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPsqTarifas = new System.Windows.Forms.Button();
            this.cboCtaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdPagarParcela = new System.Windows.Forms.TextBox();
            this.txtIdPagarBaseRateio = new System.Windows.Forms.TextBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.txtConciliado = new System.Windows.Forms.TextBox();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.st = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idtarifabancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autorizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datatarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valortarifa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoconta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpagardocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpagarparcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarifa)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 87);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFornecedor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNroDocumento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblCNPJ);
            this.groupBox1.Controls.Add(this.txtCNPJCPF);
            this.groupBox1.Controls.Add(this.txtRazaoSocial);
            this.groupBox1.Controls.Add(this.txtIdFornecedor);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 80);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identificação Documento";
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnFornecedor.Location = new System.Drawing.Point(163, 30);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(31, 23);
            this.btnFornecedor.TabIndex = 84;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Número Documento";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDocumento.Location = new System.Drawing.Point(195, 32);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(195, 20);
            this.txtNroDocumento.TabIndex = 2;
            this.txtNroDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroDocumento_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 81;
            this.label6.Text = "Código";
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.Location = new System.Drawing.Point(2, 16);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(65, 13);
            this.lblCNPJ.TabIndex = 80;
            this.lblCNPJ.Text = "CNPJ / CPF";
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(4, 32);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.Size = new System.Drawing.Size(113, 20);
            this.txtCNPJCPF.TabIndex = 0;
            this.txtCNPJCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCNPJCPF.Enter += new System.EventHandler(this.txtCNPJCPF_Enter);
            this.txtCNPJCPF.Validating += new System.ComponentModel.CancelEventHandler(this.txtCNPJCPF_Validating);
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(2, 58);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.ReadOnly = true;
            this.txtRazaoSocial.Size = new System.Drawing.Size(387, 20);
            this.txtRazaoSocial.TabIndex = 78;
            // 
            // txtIdFornecedor
            // 
            this.txtIdFornecedor.Location = new System.Drawing.Point(119, 32);
            this.txtIdFornecedor.Name = "txtIdFornecedor";
            this.txtIdFornecedor.ReadOnly = true;
            this.txtIdFornecedor.Size = new System.Drawing.Size(44, 20);
            this.txtIdFornecedor.TabIndex = 1;
            this.txtIdFornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFornecedor_Validating);
            // 
            // grdTarifa
            // 
            this.grdTarifa.AllowUserToAddRows = false;
            this.grdTarifa.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTarifa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTarifa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTarifa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.st,
            this.idtarifabancaria,
            this.situacao,
            this.autorizado,
            this.datatarifa,
            this.nrodocumento,
            this.valortarifa,
            this.descricaoconta,
            this.idpagardocumento,
            this.idpagarparcelas});
            this.grdTarifa.Location = new System.Drawing.Point(404, 72);
            this.grdTarifa.Name = "grdTarifa";
            this.grdTarifa.Size = new System.Drawing.Size(497, 315);
            this.grdTarifa.TabIndex = 2;
            // 
            // txtIdPagarDocumento
            // 
            this.txtIdPagarDocumento.Location = new System.Drawing.Point(842, 8);
            this.txtIdPagarDocumento.Name = "txtIdPagarDocumento";
            this.txtIdPagarDocumento.Size = new System.Drawing.Size(22, 20);
            this.txtIdPagarDocumento.TabIndex = 0;
            this.txtIdPagarDocumento.Visible = false;
            // 
            // txtIdTarifaBancaria
            // 
            this.txtIdTarifaBancaria.Location = new System.Drawing.Point(840, 34);
            this.txtIdTarifaBancaria.Name = "txtIdTarifaBancaria";
            this.txtIdTarifaBancaria.Size = new System.Drawing.Size(24, 20);
            this.txtIdTarifaBancaria.TabIndex = 1;
            this.txtIdTarifaBancaria.Visible = false;
            this.txtIdTarifaBancaria.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdTarifaBancaria_Validating);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtValorTarifa);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cboIdContaBancaria);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cboIdTipoDocumento);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.txtDataTarifa);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtAplicacao);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtIdAplicacao);
            this.panel2.Controls.Add(this.btnContaCusto);
            this.panel2.Controls.Add(this.txtCodigoConta);
            this.panel2.Controls.Add(this.txtIdContaCusto);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtContaCusto);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 225);
            this.panel2.TabIndex = 3;
            // 
            // txtValorTarifa
            // 
            this.txtValorTarifa.CustomFormat = "0:0";
            this.txtValorTarifa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorTarifa.Format = MaskedNumberFormat.Moeda;
            this.txtValorTarifa.Location = new System.Drawing.Point(282, 100);
            this.txtValorTarifa.Name = "txtValorTarifa";
            this.txtValorTarifa.Size = new System.Drawing.Size(112, 20);
            this.txtValorTarifa.TabIndex = 7;
            this.txtValorTarifa.Text = "R$ 0,00";
            this.txtValorTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 298;
            this.label8.Text = "Conta Bancaria";
            // 
            // cboIdContaBancaria
            // 
            this.cboIdContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdContaBancaria.FormattingEnabled = true;
            this.cboIdContaBancaria.Location = new System.Drawing.Point(3, 140);
            this.cboIdContaBancaria.Name = "cboIdContaBancaria";
            this.cboIdContaBancaria.Size = new System.Drawing.Size(391, 21);
            this.cboIdContaBancaria.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 296;
            this.label11.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(5, 181);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(386, 35);
            this.txtDescricao.TabIndex = 9;
            this.txtDescricao.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescricao_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 294;
            this.label9.Text = "Tipo Documento";
            // 
            // cboIdTipoDocumento
            // 
            this.cboIdTipoDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboIdTipoDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIdTipoDocumento.FormattingEnabled = true;
            this.cboIdTipoDocumento.Location = new System.Drawing.Point(3, 100);
            this.cboIdTipoDocumento.Name = "cboIdTipoDocumento";
            this.cboIdTipoDocumento.Size = new System.Drawing.Size(194, 21);
            this.cboIdTipoDocumento.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(279, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 292;
            this.label14.Text = "Valor Tarifa";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(196, 84);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 290;
            this.label24.Text = "Data Tarifa";
            // 
            // txtDataTarifa
            // 
            this.txtDataTarifa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataTarifa.Location = new System.Drawing.Point(198, 100);
            this.txtDataTarifa.Name = "txtDataTarifa";
            this.txtDataTarifa.Size = new System.Drawing.Size(82, 20);
            this.txtDataTarifa.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.button1.Location = new System.Drawing.Point(48, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 288;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAplicacao_Click);
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAplicacao.Location = new System.Drawing.Point(80, 61);
            this.txtAplicacao.MaxLength = 50;
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.ReadOnly = true;
            this.txtAplicacao.Size = new System.Drawing.Size(314, 20);
            this.txtAplicacao.TabIndex = 287;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(4, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 286;
            this.label19.Text = "Aplicação";
            // 
            // txtIdAplicacao
            // 
            this.txtIdAplicacao.CustomFormat = "000000000";
            this.txtIdAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAplicacao.Format = MaskedNumberFormat.Custom;
            this.txtIdAplicacao.Location = new System.Drawing.Point(4, 61);
            this.txtIdAplicacao.MaxLength = 9;
            this.txtIdAplicacao.Name = "txtIdAplicacao";
            this.txtIdAplicacao.Size = new System.Drawing.Size(44, 20);
            this.txtIdAplicacao.TabIndex = 4;
            this.txtIdAplicacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdAplicacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdAplicacao_Validating);
            // 
            // btnContaCusto
            // 
            this.btnContaCusto.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnContaCusto.Location = new System.Drawing.Point(104, 21);
            this.btnContaCusto.Name = "btnContaCusto";
            this.btnContaCusto.Size = new System.Drawing.Size(31, 23);
            this.btnContaCusto.TabIndex = 85;
            this.btnContaCusto.UseVisualStyleBackColor = true;
            this.btnContaCusto.Click += new System.EventHandler(this.btnContaCusto_Click);
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(4, 23);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConta.TabIndex = 3;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoConta_Validating);
            // 
            // txtIdContaCusto
            // 
            this.txtIdContaCusto.Location = new System.Drawing.Point(268, 4);
            this.txtIdContaCusto.Name = "txtIdContaCusto";
            this.txtIdContaCusto.Size = new System.Drawing.Size(89, 20);
            this.txtIdContaCusto.TabIndex = 82;
            this.txtIdContaCusto.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Descrição";
            // 
            // txtContaCusto
            // 
            this.txtContaCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContaCusto.Location = new System.Drawing.Point(136, 23);
            this.txtContaCusto.MaxLength = 50;
            this.txtContaCusto.Name = "txtContaCusto";
            this.txtContaCusto.ReadOnly = true;
            this.txtContaCusto.Size = new System.Drawing.Size(258, 20);
            this.txtContaCusto.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Número Conta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBaixaTarifa);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.cboHistorico);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboIdFormaPagamento);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(2, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(899, 124);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Baixa Tarifas";
            // 
            // btnBaixaTarifa
            // 
            this.btnBaixaTarifa.Location = new System.Drawing.Point(729, 48);
            this.btnBaixaTarifa.Name = "btnBaixaTarifa";
            this.btnBaixaTarifa.Size = new System.Drawing.Size(133, 44);
            this.btnBaixaTarifa.TabIndex = 312;
            this.btnBaixaTarifa.Text = "Baixa Tarifas Bancárias";
            this.btnBaixaTarifa.UseVisualStyleBackColor = true;
            this.btnBaixaTarifa.Click += new System.EventHandler(this.btnBaixaTarifa_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(300, 67);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 309;
            this.label28.Text = "Histórico";
            // 
            // cboHistorico
            // 
            this.cboHistorico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboHistorico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboHistorico.FormattingEnabled = true;
            this.cboHistorico.Location = new System.Drawing.Point(301, 83);
            this.cboHistorico.Name = "cboHistorico";
            this.cboHistorico.Size = new System.Drawing.Size(383, 21);
            this.cboHistorico.TabIndex = 308;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 307;
            this.label5.Text = "Forma Pagamento";
            // 
            // cboIdFormaPagamento
            // 
            this.cboIdFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdFormaPagamento.FormattingEnabled = true;
            this.cboIdFormaPagamento.Location = new System.Drawing.Point(300, 32);
            this.cboIdFormaPagamento.Name = "cboIdFormaPagamento";
            this.cboIdFormaPagamento.Size = new System.Drawing.Size(384, 21);
            this.cboIdFormaPagamento.TabIndex = 302;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnPsqTarifas);
            this.panel3.Controls.Add(this.cboCtaBancaria);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(10, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 100);
            this.panel3.TabIndex = 301;
            // 
            // btnPsqTarifas
            // 
            this.btnPsqTarifas.Location = new System.Drawing.Point(7, 59);
            this.btnPsqTarifas.Name = "btnPsqTarifas";
            this.btnPsqTarifas.Size = new System.Drawing.Size(147, 29);
            this.btnPsqTarifas.TabIndex = 301;
            this.btnPsqTarifas.Text = "Pesquisa Tarifas Liberadas";
            this.btnPsqTarifas.UseVisualStyleBackColor = true;
            this.btnPsqTarifas.Click += new System.EventHandler(this.btnPsqTarifas_Click);
            // 
            // cboCtaBancaria
            // 
            this.cboCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCtaBancaria.FormattingEnabled = true;
            this.cboCtaBancaria.Location = new System.Drawing.Point(7, 29);
            this.cboCtaBancaria.Name = "cboCtaBancaria";
            this.cboCtaBancaria.Size = new System.Drawing.Size(270, 21);
            this.cboCtaBancaria.TabIndex = 299;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 300;
            this.label2.Text = "Conta Bancaria";
            // 
            // txtIdPagarParcela
            // 
            this.txtIdPagarParcela.Location = new System.Drawing.Point(870, 8);
            this.txtIdPagarParcela.Name = "txtIdPagarParcela";
            this.txtIdPagarParcela.Size = new System.Drawing.Size(26, 20);
            this.txtIdPagarParcela.TabIndex = 5;
            this.txtIdPagarParcela.Visible = false;
            // 
            // txtIdPagarBaseRateio
            // 
            this.txtIdPagarBaseRateio.Location = new System.Drawing.Point(870, 34);
            this.txtIdPagarBaseRateio.Name = "txtIdPagarBaseRateio";
            this.txtIdPagarBaseRateio.Size = new System.Drawing.Size(23, 20);
            this.txtIdPagarBaseRateio.TabIndex = 6;
            this.txtIdPagarBaseRateio.Visible = false;
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(637, 34);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(98, 20);
            this.lblSituacao.TabIndex = 33;
            this.lblSituacao.Text = "lblSituacao";
            // 
            // txtConciliado
            // 
            this.txtConciliado.Location = new System.Drawing.Point(812, 8);
            this.txtConciliado.Name = "txtConciliado";
            this.txtConciliado.Size = new System.Drawing.Size(24, 20);
            this.txtConciliado.TabIndex = 34;
            this.txtConciliado.Visible = false;
            // 
            // txtSituacao
            // 
            this.txtSituacao.Location = new System.Drawing.Point(812, 36);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.Size = new System.Drawing.Size(24, 20);
            this.txtSituacao.TabIndex = 35;
            this.txtSituacao.Visible = false;
            // 
            // st
            // 
            this.st.FalseValue = "False";
            this.st.HeaderText = "Pg";
            this.st.IndeterminateValue = "False";
            this.st.Name = "st";
            this.st.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st.TrueValue = "True";
            this.st.Width = 30;
            // 
            // idtarifabancaria
            // 
            this.idtarifabancaria.DataPropertyName = "idtarifabancaria";
            this.idtarifabancaria.HeaderText = "idtarifabancaria";
            this.idtarifabancaria.Name = "idtarifabancaria";
            this.idtarifabancaria.ReadOnly = true;
            this.idtarifabancaria.Visible = false;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Sit";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 30;
            // 
            // autorizado
            // 
            this.autorizado.DataPropertyName = "autorizado";
            this.autorizado.HeaderText = "Autoriz";
            this.autorizado.Name = "autorizado";
            this.autorizado.ReadOnly = true;
            this.autorizado.Width = 30;
            // 
            // datatarifa
            // 
            this.datatarifa.DataPropertyName = "datatarifa";
            this.datatarifa.HeaderText = "Data ";
            this.datatarifa.Name = "datatarifa";
            this.datatarifa.ReadOnly = true;
            // 
            // nrodocumento
            // 
            this.nrodocumento.DataPropertyName = "nrodocumento";
            this.nrodocumento.HeaderText = "Documento";
            this.nrodocumento.Name = "nrodocumento";
            this.nrodocumento.ReadOnly = true;
            this.nrodocumento.Width = 70;
            // 
            // valortarifa
            // 
            this.valortarifa.DataPropertyName = "valortarifa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.valortarifa.DefaultCellStyle = dataGridViewCellStyle2;
            this.valortarifa.HeaderText = "Valor";
            this.valortarifa.Name = "valortarifa";
            this.valortarifa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // descricaoconta
            // 
            this.descricaoconta.DataPropertyName = "descricaoconta";
            this.descricaoconta.HeaderText = "Conta Bancária";
            this.descricaoconta.Name = "descricaoconta";
            this.descricaoconta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // idpagardocumento
            // 
            this.idpagardocumento.DataPropertyName = "idpagardocumento";
            this.idpagardocumento.HeaderText = "idpagardocumento";
            this.idpagardocumento.Name = "idpagardocumento";
            this.idpagardocumento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idpagardocumento.Visible = false;
            // 
            // idpagarparcelas
            // 
            this.idpagarparcelas.DataPropertyName = "idpagarparcelas";
            this.idpagarparcelas.HeaderText = "idpagarparcelas";
            this.idpagarparcelas.Name = "idpagarparcelas";
            this.idpagarparcelas.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idpagarparcelas.Visible = false;
            // 
            // frmTarifasBancarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(903, 517);
            this.Controls.Add(this.txtSituacao);
            this.Controls.Add(this.txtConciliado);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.txtIdPagarBaseRateio);
            this.Controls.Add(this.txtIdPagarParcela);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtIdTarifaBancaria);
            this.Controls.Add(this.txtIdPagarDocumento);
            this.Controls.Add(this.grdTarifa);
            this.Controls.Add(this.panel1);
            this.Name = "frmTarifasBancarias";
            this.Text = "Tarifas Bancárias";
            this.Load += new System.EventHandler(this.frmTarifasBancarias_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdTarifa, 0);
            this.Controls.SetChildIndex(this.txtIdPagarDocumento, 0);
            this.Controls.SetChildIndex(this.txtIdTarifaBancaria, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.txtIdPagarParcela, 0);
            this.Controls.SetChildIndex(this.txtIdPagarBaseRateio, 0);
            this.Controls.SetChildIndex(this.lblSituacao, 0);
            this.Controls.SetChildIndex(this.txtConciliado, 0);
            this.Controls.SetChildIndex(this.txtSituacao, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarifa)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdTarifa;
        private System.Windows.Forms.TextBox txtIdTarifaBancaria;
        private System.Windows.Forms.TextBox txtIdPagarDocumento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCNPJ;
        private System.Windows.Forms.MaskedTextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.TextBox txtIdFornecedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnContaCusto;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;
        private System.Windows.Forms.TextBox txtIdContaCusto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContaCusto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAplicacao;
        private System.Windows.Forms.Label label19;
        private MaskedNumber.MaskedNumber txtIdAplicacao;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker txtDataTarifa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboIdTipoDocumento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIdContaBancaria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCtaBancaria;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPsqTarifas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboIdFormaPagamento;
        private System.Windows.Forms.Button btnBaixaTarifa;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboHistorico;
        private MaskedNumber.MaskedNumber txtValorTarifa;
        private System.Windows.Forms.TextBox txtIdPagarParcela;
        private System.Windows.Forms.TextBox txtIdPagarBaseRateio;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.TextBox txtConciliado;
        private System.Windows.Forms.TextBox txtSituacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtarifabancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn autorizado;
        private System.Windows.Forms.DataGridViewTextBoxColumn datatarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valortarifa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoconta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagardocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagarparcelas;
    }
}
