namespace EMCEventos
{
    partial class psqContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqContrato));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.btnSubLocacao = new System.Windows.Forms.Button();
            this.txtDescSubLocacao = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdSubLocacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtIdContrato = new System.Windows.Forms.TextBox();
            this.grdPsqContrato = new System.Windows.Forms.DataGridView();
            this.idevt_contrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datacontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorcontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroparcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idev_sublocacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_sublocacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_CodEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_idPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_CodEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_idPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geraContasPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.geraTaxaAdministracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percenturalAdministracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoradministracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataaprovacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuarioaprovador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuariocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqContrato)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtIdCliente);
            this.panel3.Controls.Add(this.cboFornecedor);
            this.panel3.Controls.Add(this.btnSubLocacao);
            this.panel3.Controls.Add(this.txtDescSubLocacao);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtIdSubLocacao);
            this.panel3.Controls.Add(this.btnCliente);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtRazaoSocial);
            this.panel3.Controls.Add(this.txtDataFinal);
            this.panel3.Controls.Add(this.txtDataInicial);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(2, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 126);
            this.panel3.TabIndex = 133;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(6, 91);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(603, 21);
            this.cboFornecedor.TabIndex = 505;
            // 
            // btnSubLocacao
            // 
            this.btnSubLocacao.Image = ((System.Drawing.Image)(resources.GetObject("btnSubLocacao.Image")));
            this.btnSubLocacao.Location = new System.Drawing.Point(48, 53);
            this.btnSubLocacao.Name = "btnSubLocacao";
            this.btnSubLocacao.Size = new System.Drawing.Size(30, 22);
            this.btnSubLocacao.TabIndex = 500;
            this.btnSubLocacao.UseVisualStyleBackColor = true;
            this.btnSubLocacao.Click += new System.EventHandler(this.btnSubLocacao_Click);
            // 
            // txtDescSubLocacao
            // 
            this.txtDescSubLocacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescSubLocacao.Location = new System.Drawing.Point(79, 54);
            this.txtDescSubLocacao.MaxLength = 50;
            this.txtDescSubLocacao.Name = "txtDescSubLocacao";
            this.txtDescSubLocacao.ReadOnly = true;
            this.txtDescSubLocacao.Size = new System.Drawing.Size(530, 20);
            this.txtDescSubLocacao.TabIndex = 501;
            // 
            // btnCliente
            // 
            this.btnCliente.Image = global::EMCEventos.Properties.Resources.binoculo_16x16;
            this.btnCliente.Location = new System.Drawing.Point(48, 15);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(30, 22);
            this.btnCliente.TabIndex = 503;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(79, 16);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.ReadOnly = true;
            this.txtRazaoSocial.Size = new System.Drawing.Size(362, 20);
            this.txtRazaoSocial.TabIndex = 504;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 511;
            this.label13.Text = "Fornecedor";
            // 
            // txtIdSubLocacao
            // 
            this.txtIdSubLocacao.Location = new System.Drawing.Point(7, 54);
            this.txtIdSubLocacao.Name = "txtIdSubLocacao";
            this.txtIdSubLocacao.Size = new System.Drawing.Size(40, 20);
            this.txtIdSubLocacao.TabIndex = 499;
            this.txtIdSubLocacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdSubLocacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdSubLocacao_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 509;
            this.label5.Text = "SubLocação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 510;
            this.label6.Text = "Cliente";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(532, 18);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(76, 20);
            this.txtDataFinal.TabIndex = 498;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(454, 18);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(76, 20);
            this.txtDataInicial.TabIndex = 497;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "até";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Data Contrato";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.txtIdContrato);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 63);
            this.panel1.TabIndex = 132;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 14;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 13;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtIdContrato
            // 
            this.txtIdContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdContrato.Location = new System.Drawing.Point(427, 11);
            this.txtIdContrato.MaxLength = 50;
            this.txtIdContrato.Name = "txtIdContrato";
            this.txtIdContrato.Size = new System.Drawing.Size(40, 20);
            this.txtIdContrato.TabIndex = 111;
            this.txtIdContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdContrato.Visible = false;
            // 
            // grdPsqContrato
            // 
            this.grdPsqContrato.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqContrato.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqContrato.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idevt_contrato,
            this.datacontrato,
            this.valorcontrato,
            this.nroparcelas,
            this.idev_sublocacao,
            this.desc_sublocacao,
            this.cliente_CodEmpresa,
            this.cliente_idPessoa,
            this.nome_cliente,
            this.fornecedor_CodEmpresa,
            this.fornecedor_idPessoa,
            this.nome_fornecedor,
            this.geraContasPagar,
            this.geraTaxaAdministracao,
            this.percenturalAdministracao,
            this.valoradministracao,
            this.dataaprovacao,
            this.situacao,
            this.idusuarioaprovador,
            this.idusuariocontrato});
            this.grdPsqContrato.Location = new System.Drawing.Point(2, 195);
            this.grdPsqContrato.MultiSelect = false;
            this.grdPsqContrato.Name = "grdPsqContrato";
            this.grdPsqContrato.ReadOnly = true;
            this.grdPsqContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqContrato.Size = new System.Drawing.Size(616, 198);
            this.grdPsqContrato.TabIndex = 135;
            this.grdPsqContrato.DoubleClick += new System.EventHandler(this.grdPsqContrato_DoubleClick);
            this.grdPsqContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqContrato_KeyDown);
            // 
            // idevt_contrato
            // 
            this.idevt_contrato.DataPropertyName = "idevt_contrato";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idevt_contrato.DefaultCellStyle = dataGridViewCellStyle2;
            this.idevt_contrato.HeaderText = "Cód. Contrato";
            this.idevt_contrato.Name = "idevt_contrato";
            this.idevt_contrato.ReadOnly = true;
            this.idevt_contrato.Width = 50;
            // 
            // datacontrato
            // 
            this.datacontrato.DataPropertyName = "datacontrato";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.datacontrato.DefaultCellStyle = dataGridViewCellStyle3;
            this.datacontrato.HeaderText = "Data Contrato";
            this.datacontrato.Name = "datacontrato";
            this.datacontrato.ReadOnly = true;
            // 
            // valorcontrato
            // 
            this.valorcontrato.DataPropertyName = "valorcontrato";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.valorcontrato.DefaultCellStyle = dataGridViewCellStyle4;
            this.valorcontrato.HeaderText = "Valor Contrato";
            this.valorcontrato.Name = "valorcontrato";
            this.valorcontrato.ReadOnly = true;
            // 
            // nroparcelas
            // 
            this.nroparcelas.DataPropertyName = "nroparcelas";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nroparcelas.DefaultCellStyle = dataGridViewCellStyle5;
            this.nroparcelas.HeaderText = "Nro Parcelas";
            this.nroparcelas.Name = "nroparcelas";
            this.nroparcelas.ReadOnly = true;
            this.nroparcelas.Width = 50;
            // 
            // idev_sublocacao
            // 
            this.idev_sublocacao.DataPropertyName = "idev_sublocacao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idev_sublocacao.DefaultCellStyle = dataGridViewCellStyle6;
            this.idev_sublocacao.HeaderText = "Cód. SubLocação";
            this.idev_sublocacao.Name = "idev_sublocacao";
            this.idev_sublocacao.ReadOnly = true;
            this.idev_sublocacao.Width = 80;
            // 
            // desc_sublocacao
            // 
            this.desc_sublocacao.DataPropertyName = "desc_sublocacao";
            this.desc_sublocacao.HeaderText = "Descrição SubLocação";
            this.desc_sublocacao.Name = "desc_sublocacao";
            this.desc_sublocacao.ReadOnly = true;
            this.desc_sublocacao.Width = 300;
            // 
            // cliente_CodEmpresa
            // 
            this.cliente_CodEmpresa.DataPropertyName = "cliente_codempresa";
            this.cliente_CodEmpresa.HeaderText = "Cli_CodEmpresa";
            this.cliente_CodEmpresa.Name = "cliente_CodEmpresa";
            this.cliente_CodEmpresa.ReadOnly = true;
            this.cliente_CodEmpresa.Visible = false;
            // 
            // cliente_idPessoa
            // 
            this.cliente_idPessoa.DataPropertyName = "cliente_idPessoa";
            this.cliente_idPessoa.HeaderText = "Cli_idPessoa";
            this.cliente_idPessoa.Name = "cliente_idPessoa";
            this.cliente_idPessoa.ReadOnly = true;
            this.cliente_idPessoa.Visible = false;
            // 
            // nome_cliente
            // 
            this.nome_cliente.DataPropertyName = "nome_cliente";
            this.nome_cliente.HeaderText = "Cliente";
            this.nome_cliente.Name = "nome_cliente";
            this.nome_cliente.ReadOnly = true;
            this.nome_cliente.Width = 300;
            // 
            // fornecedor_CodEmpresa
            // 
            this.fornecedor_CodEmpresa.DataPropertyName = "fornecedor_codempresa";
            this.fornecedor_CodEmpresa.HeaderText = "Forn_CodEmp";
            this.fornecedor_CodEmpresa.Name = "fornecedor_CodEmpresa";
            this.fornecedor_CodEmpresa.ReadOnly = true;
            this.fornecedor_CodEmpresa.Visible = false;
            // 
            // fornecedor_idPessoa
            // 
            this.fornecedor_idPessoa.DataPropertyName = "fornecedor_idpessoa";
            this.fornecedor_idPessoa.HeaderText = "Forn_idPessoa";
            this.fornecedor_idPessoa.Name = "fornecedor_idPessoa";
            this.fornecedor_idPessoa.ReadOnly = true;
            this.fornecedor_idPessoa.Visible = false;
            // 
            // nome_fornecedor
            // 
            this.nome_fornecedor.DataPropertyName = "nome_fornecedor";
            this.nome_fornecedor.HeaderText = "Fornecedor";
            this.nome_fornecedor.Name = "nome_fornecedor";
            this.nome_fornecedor.ReadOnly = true;
            this.nome_fornecedor.Width = 300;
            // 
            // geraContasPagar
            // 
            this.geraContasPagar.DataPropertyName = "geracontaspagar";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.geraContasPagar.DefaultCellStyle = dataGridViewCellStyle7;
            this.geraContasPagar.HeaderText = "Contas Pagar";
            this.geraContasPagar.Name = "geraContasPagar";
            this.geraContasPagar.ReadOnly = true;
            this.geraContasPagar.Width = 50;
            // 
            // geraTaxaAdministracao
            // 
            this.geraTaxaAdministracao.DataPropertyName = "gerataxaadministracao";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.geraTaxaAdministracao.DefaultCellStyle = dataGridViewCellStyle8;
            this.geraTaxaAdministracao.HeaderText = "Taxa Adm";
            this.geraTaxaAdministracao.Name = "geraTaxaAdministracao";
            this.geraTaxaAdministracao.ReadOnly = true;
            this.geraTaxaAdministracao.Width = 50;
            // 
            // percenturalAdministracao
            // 
            this.percenturalAdministracao.DataPropertyName = "percenturaladministracao";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.percenturalAdministracao.DefaultCellStyle = dataGridViewCellStyle9;
            this.percenturalAdministracao.HeaderText = "Perc. Adm";
            this.percenturalAdministracao.Name = "percenturalAdministracao";
            this.percenturalAdministracao.ReadOnly = true;
            this.percenturalAdministracao.Width = 50;
            // 
            // valoradministracao
            // 
            this.valoradministracao.DataPropertyName = "valoradministracao";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.valoradministracao.DefaultCellStyle = dataGridViewCellStyle10;
            this.valoradministracao.HeaderText = "Valor Adm";
            this.valoradministracao.Name = "valoradministracao";
            this.valoradministracao.ReadOnly = true;
            // 
            // dataaprovacao
            // 
            this.dataaprovacao.DataPropertyName = "dataaprovacao";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataaprovacao.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataaprovacao.HeaderText = "Data Aprovação";
            this.dataaprovacao.Name = "dataaprovacao";
            this.dataaprovacao.ReadOnly = true;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.situacao.DefaultCellStyle = dataGridViewCellStyle12;
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 50;
            // 
            // idusuarioaprovador
            // 
            this.idusuarioaprovador.DataPropertyName = "idusuarioaprovador";
            this.idusuarioaprovador.HeaderText = "IdUsuarioAprovador";
            this.idusuarioaprovador.Name = "idusuarioaprovador";
            this.idusuarioaprovador.ReadOnly = true;
            this.idusuarioaprovador.Visible = false;
            // 
            // idusuariocontrato
            // 
            this.idusuariocontrato.DataPropertyName = "idusuariocontrato";
            this.idusuariocontrato.HeaderText = "IdUsuarioContrato";
            this.idusuariocontrato.Name = "idusuariocontrato";
            this.idusuariocontrato.ReadOnly = true;
            this.idusuariocontrato.Visible = false;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(7, 16);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(40, 20);
            this.txtIdCliente.TabIndex = 512;
            this.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCliente_Validating);
            // 
            // psqContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 395);
            this.Controls.Add(this.grdPsqContrato);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "psqContrato";
            this.Text = "Pesquisa Contrato";
            this.Load += new System.EventHandler(this.psqContrato_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqContrato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtIdContrato;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Button btnSubLocacao;
        private System.Windows.Forms.TextBox txtDescSubLocacao;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.TextBox txtIdSubLocacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdPsqContrato;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_contrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn datacontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorcontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroparcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idev_sublocacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_sublocacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_CodEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_idPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_CodEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_idPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn geraContasPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn geraTaxaAdministracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn percenturalAdministracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoradministracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataaprovacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioaprovador;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuariocontrato;
        private System.Windows.Forms.TextBox txtIdCliente;
    }
}