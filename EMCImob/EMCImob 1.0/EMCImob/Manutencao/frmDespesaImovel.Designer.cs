namespace EMCImob
{
    partial class frmDespesaImovel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDespesaImovel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDataLancamento = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.txtPessoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLocalizarProprietario = new System.Windows.Forms.Button();
            this.txtIdDespesaImovel = new System.Windows.Forms.TextBox();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocacaoProvento = new System.Windows.Forms.TextBox();
            this.btnLocacaoProvento = new System.Windows.Forms.Button();
            this.txtIdLocacaoProvento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.txtDescricaoAcerto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHistorico = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDataAcerto = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtValorDespesa = new MaskedNumber.MaskedNumber();
            this.grdDespesaImovel = new System.Windows.Forms.DataGridView();
            this.iddespesaimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomefornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocacaoproventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datalancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataacerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoacerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoprovento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_codempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_idpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDespesaImovel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Código";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDataLancamento);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtIdPessoa);
            this.panel1.Controls.Add(this.txtPessoa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnLocalizarProprietario);
            this.panel1.Controls.Add(this.txtIdDespesaImovel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 41);
            this.panel1.TabIndex = 2;
            // 
            // txtDataLancamento
            // 
            this.txtDataLancamento.DateValue = null;
            this.txtDataLancamento.Location = new System.Drawing.Point(46, 16);
            this.txtDataLancamento.Mask = "00/00/0000";
            this.txtDataLancamento.Name = "txtDataLancamento";
            this.txtDataLancamento.RequireValidEntry = true;
            this.txtDataLancamento.Size = new System.Drawing.Size(88, 20);
            this.txtDataLancamento.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 102;
            this.label5.Text = "Fornecedor";
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdPessoa.Location = new System.Drawing.Point(136, 16);
            this.txtIdPessoa.MaxLength = 50;
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(40, 20);
            this.txtIdPessoa.TabIndex = 3;
            this.txtIdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPessoa_Validating);
            // 
            // txtPessoa
            // 
            this.txtPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPessoa.Location = new System.Drawing.Point(208, 16);
            this.txtPessoa.MaxLength = 50;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(416, 20);
            this.txtPessoa.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Data Lançamento";
            // 
            // btnLocalizarProprietario
            // 
            this.btnLocalizarProprietario.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizarProprietario.Image")));
            this.btnLocalizarProprietario.Location = new System.Drawing.Point(177, 15);
            this.btnLocalizarProprietario.Name = "btnLocalizarProprietario";
            this.btnLocalizarProprietario.Size = new System.Drawing.Size(30, 22);
            this.btnLocalizarProprietario.TabIndex = 4;
            this.btnLocalizarProprietario.UseVisualStyleBackColor = true;
            this.btnLocalizarProprietario.Click += new System.EventHandler(this.btnLocalizarProprietario_Click);
            // 
            // txtIdDespesaImovel
            // 
            this.txtIdDespesaImovel.Location = new System.Drawing.Point(4, 16);
            this.txtIdDespesaImovel.Name = "txtIdDespesaImovel";
            this.txtIdDespesaImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdDespesaImovel.TabIndex = 1;
            this.txtIdDespesaImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdDespesaImovel_Validating);
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(106, 16);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(205, 20);
            this.txtImovel.TabIndex = 8;
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(75, 15);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 7;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(46, -2);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(38, 20);
            this.txtIdImovel.TabIndex = 600;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Imóvel";
            // 
            // txtLocacaoProvento
            // 
            this.txtLocacaoProvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocacaoProvento.Location = new System.Drawing.Point(74, 51);
            this.txtLocacaoProvento.MaxLength = 50;
            this.txtLocacaoProvento.Name = "txtLocacaoProvento";
            this.txtLocacaoProvento.Size = new System.Drawing.Size(237, 20);
            this.txtLocacaoProvento.TabIndex = 11;
            // 
            // btnLocacaoProvento
            // 
            this.btnLocacaoProvento.Image = ((System.Drawing.Image)(resources.GetObject("btnLocacaoProvento.Image")));
            this.btnLocacaoProvento.Location = new System.Drawing.Point(43, 50);
            this.btnLocacaoProvento.Name = "btnLocacaoProvento";
            this.btnLocacaoProvento.Size = new System.Drawing.Size(30, 22);
            this.btnLocacaoProvento.TabIndex = 10;
            this.btnLocacaoProvento.UseVisualStyleBackColor = true;
            this.btnLocacaoProvento.Click += new System.EventHandler(this.btnLocacaoProvento_Click);
            // 
            // txtIdLocacaoProvento
            // 
            this.txtIdLocacaoProvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdLocacaoProvento.Location = new System.Drawing.Point(4, 51);
            this.txtIdLocacaoProvento.MaxLength = 50;
            this.txtIdLocacaoProvento.Name = "txtIdLocacaoProvento";
            this.txtIdLocacaoProvento.Size = new System.Drawing.Size(38, 20);
            this.txtIdLocacaoProvento.TabIndex = 9;
            this.txtIdLocacaoProvento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdLocacaoProvento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdLocacaoProvento_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Locação Proventos";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtIdEmpresa);
            this.panel2.Controls.Add(this.txtCodigoImovel);
            this.panel2.Controls.Add(this.txtDescricaoAcerto);
            this.panel2.Controls.Add(this.btnImovel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtImovel);
            this.panel2.Controls.Add(this.txtLocacaoProvento);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtIdImovel);
            this.panel2.Controls.Add(this.btnLocacaoProvento);
            this.panel2.Controls.Add(this.txtIdLocacaoProvento);
            this.panel2.Location = new System.Drawing.Point(2, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 140);
            this.panel2.TabIndex = 36;
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdEmpresa.Location = new System.Drawing.Point(105, -2);
            this.txtIdEmpresa.MaxLength = 50;
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(38, 20);
            this.txtIdEmpresa.TabIndex = 601;
            this.txtIdEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdEmpresa.Visible = false;
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(4, 16);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(70, 20);
            this.txtCodigoImovel.TabIndex = 6;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // txtDescricaoAcerto
            // 
            this.txtDescricaoAcerto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoAcerto.Location = new System.Drawing.Point(4, 88);
            this.txtDescricaoAcerto.Multiline = true;
            this.txtDescricaoAcerto.Name = "txtDescricaoAcerto";
            this.txtDescricaoAcerto.Size = new System.Drawing.Size(307, 47);
            this.txtDescricaoAcerto.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 109;
            this.label9.Text = "Descrição";
            // 
            // txtHistorico
            // 
            this.txtHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHistorico.Location = new System.Drawing.Point(2, 51);
            this.txtHistorico.Multiline = true;
            this.txtHistorico.Name = "txtHistorico";
            this.txtHistorico.Size = new System.Drawing.Size(305, 84);
            this.txtHistorico.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 105;
            this.label6.Text = "Histórico";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Valor Despesa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 107;
            this.label8.Text = "Data Acerto";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(205, 14);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(80, 20);
            this.lblSituacao.TabIndex = 108;
            this.lblSituacao.Text = "Situação";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtDataAcerto);
            this.panel3.Controls.Add(this.txtHistorico);
            this.panel3.Controls.Add(this.txtValorDespesa);
            this.panel3.Controls.Add(this.lblSituacao);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(319, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 140);
            this.panel3.TabIndex = 37;
            // 
            // txtDataAcerto
            // 
            this.txtDataAcerto.DateValue = null;
            this.txtDataAcerto.Location = new System.Drawing.Point(98, 16);
            this.txtDataAcerto.Mask = "00/00/0000";
            this.txtDataAcerto.Name = "txtDataAcerto";
            this.txtDataAcerto.RequireValidEntry = true;
            this.txtDataAcerto.Size = new System.Drawing.Size(88, 20);
            this.txtDataAcerto.TabIndex = 14;
            // 
            // txtValorDespesa
            // 
            this.txtValorDespesa.CustomFormat = "0:0";
            this.txtValorDespesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorDespesa.Format = MaskedNumberFormat.Moeda;
            this.txtValorDespesa.Location = new System.Drawing.Point(2, 16);
            this.txtValorDespesa.Name = "txtValorDespesa";
            this.txtValorDespesa.Size = new System.Drawing.Size(94, 20);
            this.txtValorDespesa.TabIndex = 13;
            this.txtValorDespesa.Text = "R$ 0,00";
            this.txtValorDespesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grdDespesaImovel
            // 
            this.grdDespesaImovel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdDespesaImovel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDespesaImovel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdDespesaImovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDespesaImovel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddespesaimovel,
            this.nomefornecedor,
            this.descricao,
            this.idimovel,
            this.codigoimovel,
            this.tipoimovel,
            this.idlocacaoproventos,
            this.datalancamento,
            this.historico,
            this.valordespesa,
            this.dataacerto,
            this.situacao,
            this.descricaoacerto,
            this.tipoprovento,
            this.fornecedor_codempresa,
            this.fornecedor_idpessoa});
            this.grdDespesaImovel.Location = new System.Drawing.Point(2, 257);
            this.grdDespesaImovel.MultiSelect = false;
            this.grdDespesaImovel.Name = "grdDespesaImovel";
            this.grdDespesaImovel.ReadOnly = true;
            this.grdDespesaImovel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDespesaImovel.Size = new System.Drawing.Size(629, 129);
            this.grdDespesaImovel.TabIndex = 38;
            this.grdDespesaImovel.DoubleClick += new System.EventHandler(this.grdDespesaImovel_DoubleClick);
            // 
            // iddespesaimovel
            // 
            this.iddespesaimovel.DataPropertyName = "iddespesaimovel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.iddespesaimovel.DefaultCellStyle = dataGridViewCellStyle2;
            this.iddespesaimovel.HeaderText = "Cód. Despesa";
            this.iddespesaimovel.Name = "iddespesaimovel";
            this.iddespesaimovel.ReadOnly = true;
            this.iddespesaimovel.Width = 99;
            // 
            // nomefornecedor
            // 
            this.nomefornecedor.DataPropertyName = "nome_proprietario";
            this.nomefornecedor.HeaderText = "Fornecedor";
            this.nomefornecedor.Name = "nomefornecedor";
            this.nomefornecedor.ReadOnly = true;
            this.nomefornecedor.Width = 86;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "desc_proventos";
            this.descricao.HeaderText = "Proventos";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // idimovel
            // 
            this.idimovel.DataPropertyName = "idimovel";
            this.idimovel.HeaderText = "Imóvel";
            this.idimovel.Name = "idimovel";
            this.idimovel.ReadOnly = true;
            this.idimovel.Visible = false;
            this.idimovel.Width = 63;
            // 
            // codigoimovel
            // 
            this.codigoimovel.DataPropertyName = "codigoimovel";
            this.codigoimovel.HeaderText = "Código Imóvel";
            this.codigoimovel.Name = "codigoimovel";
            this.codigoimovel.ReadOnly = true;
            this.codigoimovel.Width = 99;
            // 
            // tipoimovel
            // 
            this.tipoimovel.DataPropertyName = "tipoimovel";
            this.tipoimovel.HeaderText = "tipoimovel";
            this.tipoimovel.Name = "tipoimovel";
            this.tipoimovel.ReadOnly = true;
            this.tipoimovel.Visible = false;
            this.tipoimovel.Width = 79;
            // 
            // idlocacaoproventos
            // 
            this.idlocacaoproventos.DataPropertyName = "idlocacaoproventos";
            this.idlocacaoproventos.HeaderText = "Cód. Proventos";
            this.idlocacaoproventos.Name = "idlocacaoproventos";
            this.idlocacaoproventos.ReadOnly = true;
            this.idlocacaoproventos.Visible = false;
            this.idlocacaoproventos.Width = 105;
            // 
            // datalancamento
            // 
            this.datalancamento.DataPropertyName = "datalancamento";
            this.datalancamento.HeaderText = "Data Lançamento";
            this.datalancamento.Name = "datalancamento";
            this.datalancamento.ReadOnly = true;
            this.datalancamento.Width = 107;
            // 
            // historico
            // 
            this.historico.DataPropertyName = "historico";
            this.historico.HeaderText = "Histórico";
            this.historico.Name = "historico";
            this.historico.ReadOnly = true;
            this.historico.Width = 73;
            // 
            // valordespesa
            // 
            this.valordespesa.DataPropertyName = "valordespesa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.valordespesa.DefaultCellStyle = dataGridViewCellStyle3;
            this.valordespesa.HeaderText = "Despesa";
            this.valordespesa.Name = "valordespesa";
            this.valordespesa.ReadOnly = true;
            this.valordespesa.Width = 74;
            // 
            // dataacerto
            // 
            this.dataacerto.DataPropertyName = "dataacerto";
            this.dataacerto.HeaderText = "Data Acerto";
            this.dataacerto.Name = "dataacerto";
            this.dataacerto.ReadOnly = true;
            this.dataacerto.Width = 82;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.situacao.DefaultCellStyle = dataGridViewCellStyle4;
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 74;
            // 
            // descricaoacerto
            // 
            this.descricaoacerto.DataPropertyName = "descricaoacerto";
            this.descricaoacerto.HeaderText = "Descrição do Acerto";
            this.descricaoacerto.Name = "descricaoacerto";
            this.descricaoacerto.ReadOnly = true;
            this.descricaoacerto.Width = 90;
            // 
            // tipoprovento
            // 
            this.tipoprovento.DataPropertyName = "tipoprovento";
            this.tipoprovento.HeaderText = "TipoProvento";
            this.tipoprovento.Name = "tipoprovento";
            this.tipoprovento.ReadOnly = true;
            this.tipoprovento.Visible = false;
            this.tipoprovento.Width = 96;
            // 
            // fornecedor_codempresa
            // 
            this.fornecedor_codempresa.DataPropertyName = "fornecedor_codempresa";
            this.fornecedor_codempresa.HeaderText = "Cod. Empresa";
            this.fornecedor_codempresa.Name = "fornecedor_codempresa";
            this.fornecedor_codempresa.ReadOnly = true;
            this.fornecedor_codempresa.Visible = false;
            this.fornecedor_codempresa.Width = 90;
            // 
            // fornecedor_idpessoa
            // 
            this.fornecedor_idpessoa.DataPropertyName = "fornecedor_idpessoa";
            this.fornecedor_idpessoa.HeaderText = "Cód. Fornecedor";
            this.fornecedor_idpessoa.Name = "fornecedor_idpessoa";
            this.fornecedor_idpessoa.ReadOnly = true;
            this.fornecedor_idpessoa.Visible = false;
            this.fornecedor_idpessoa.Width = 102;
            // 
            // frmDespesaImovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 389);
            this.Controls.Add(this.grdDespesaImovel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmDespesaImovel";
            this.Text = "Despesas do Imóvel";
            this.Load += new System.EventHandler(this.frmDespesaImovel_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.grdDespesaImovel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDespesaImovel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdDespesaImovel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocacaoProvento;
        private System.Windows.Forms.Button btnLocacaoProvento;
        private System.Windows.Forms.TextBox txtIdLocacaoProvento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.TextBox txtPessoa;
        private System.Windows.Forms.Button btnLocalizarProprietario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtHistorico;
        private System.Windows.Forms.TextBox txtDescricaoAcerto;
        private MaskedNumber.MaskedNumber txtValorDespesa;
        private System.Windows.Forms.DataGridView grdDespesaImovel;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataLancamento;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataAcerto;
        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Windows.Forms.TextBox txtIdEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesaimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomefornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaoproventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn datalancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataacerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoacerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoprovento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_codempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_idpessoa;
    }
}
