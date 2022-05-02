namespace EMCFinanceiro
{
    partial class frmGrdMovBancario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrdMovBancario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.chkMovimentoConciliado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboIdContaBancaria = new System.Windows.Forms.ComboBox();
            this.grdMovBanco = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lblSdoInicialConciliado = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblSdoInicial = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.txtNomePessoa = new System.Windows.Forms.TextBox();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkValorDocumento = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorFinal = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorInicio = new System.Windows.Forms.Sample.DecimalTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblSdoFinalConciliado = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblSdoFinal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnDesmarcarTodos = new System.Windows.Forms.Button();
            this.btnMarcarTodos = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDtaConciliacao = new System.Windows.Forms.DateTimePicker();
            this.dtMovBancario = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.rptExtrato = new FastReport.Report();
            this.rptExtratoConciliado = new FastReport.Report();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.historicooculto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vdataconciliacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datamovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataconciliacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrcredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrdebito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoconciliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.favorecido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmovimentobancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codempresa_pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idctabancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovBanco)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMovBancario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptExtrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptExtratoConciliado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkPDF);
            this.panel1.Controls.Add(this.chkMovimentoConciliado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDataFinal);
            this.panel1.Controls.Add(this.txtDataInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboIdContaBancaria);
            this.panel1.Location = new System.Drawing.Point(633, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 68);
            this.panel1.TabIndex = 1;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(347, 46);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(86, 17);
            this.chkPDF.TabIndex = 105;
            this.chkPDF.Text = "Exporta PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // chkMovimentoConciliado
            // 
            this.chkMovimentoConciliado.AutoSize = true;
            this.chkMovimentoConciliado.Location = new System.Drawing.Point(3, 46);
            this.chkMovimentoConciliado.Name = "chkMovimentoConciliado";
            this.chkMovimentoConciliado.Size = new System.Drawing.Size(192, 17);
            this.chkMovimentoConciliado.TabIndex = 42;
            this.chkMovimentoConciliado.Text = "Somente Lançamentos Conciliados";
            this.chkMovimentoConciliado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Data Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Data Inicio";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(349, 20);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(84, 20);
            this.txtDataFinal.TabIndex = 17;
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(236, 21);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(90, 20);
            this.txtDataInicio.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Até";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Conta Bancaria";
            // 
            // cboIdContaBancaria
            // 
            this.cboIdContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdContaBancaria.FormattingEnabled = true;
            this.cboIdContaBancaria.Location = new System.Drawing.Point(3, 20);
            this.cboIdContaBancaria.Name = "cboIdContaBancaria";
            this.cboIdContaBancaria.Size = new System.Drawing.Size(228, 21);
            this.cboIdContaBancaria.TabIndex = 14;
            this.cboIdContaBancaria.Validating += new System.ComponentModel.CancelEventHandler(this.cboIdContaBancaria_Validating);
            // 
            // grdMovBanco
            // 
            this.grdMovBanco.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdMovBanco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMovBanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMovBanco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.historicooculto,
            this.vdataconciliacao,
            this.datamovimento,
            this.dataconciliacao,
            this.vlrcredito,
            this.vlrdebito,
            this.saldo,
            this.saldoconciliado,
            this.documento,
            this.cheque,
            this.favorecido,
            this.historico,
            this.idmovimentobancario,
            this.codigoempresa,
            this.codempresa_pessoa,
            this.idpessoa,
            this.ctabancaria_idempresa,
            this.ctabancaria_idctabancaria,
            this.situacao});
            this.grdMovBanco.Location = new System.Drawing.Point(2, 144);
            this.grdMovBanco.Name = "grdMovBanco";
            this.grdMovBanco.Size = new System.Drawing.Size(1069, 342);
            this.grdMovBanco.TabIndex = 2;
            this.grdMovBanco.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMovBanco_CellEndEdit);
            this.grdMovBanco.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdMovBanco_CellFormatting);
            this.grdMovBanco.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMovBanco_CellValueChanged);
            this.grdMovBanco.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdMovBanco_CurrentCellDirtyStateChanged);
            this.grdMovBanco.DoubleClick += new System.EventHandler(this.grdMovBanco_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtNumeroDocumento);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(2, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 65);
            this.panel2.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Número Documento";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(4, 29);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(190, 20);
            this.txtNumeroDocumento.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(803, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 64);
            this.panel3.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.lblSdoInicialConciliado);
            this.panel11.Location = new System.Drawing.Point(133, 29);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(123, 23);
            this.panel11.TabIndex = 55;
            // 
            // lblSdoInicialConciliado
            // 
            this.lblSdoInicialConciliado.AutoSize = true;
            this.lblSdoInicialConciliado.Location = new System.Drawing.Point(3, 4);
            this.lblSdoInicialConciliado.Name = "lblSdoInicialConciliado";
            this.lblSdoInicialConciliado.Size = new System.Drawing.Size(28, 13);
            this.lblSdoInicialConciliado.TabIndex = 51;
            this.lblSdoInicialConciliado.Text = "0,00";
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.lblSdoInicial);
            this.panel12.Location = new System.Drawing.Point(8, 29);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(123, 23);
            this.panel12.TabIndex = 54;
            // 
            // lblSdoInicial
            // 
            this.lblSdoInicial.AutoSize = true;
            this.lblSdoInicial.Location = new System.Drawing.Point(3, 4);
            this.lblSdoInicial.Name = "lblSdoInicial";
            this.lblSdoInicial.Size = new System.Drawing.Size(28, 13);
            this.lblSdoInicial.TabIndex = 50;
            this.lblSdoInicial.Text = "0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Sdo Inicial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Sdo Inicial Conciliado";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnFornecedor);
            this.panel5.Controls.Add(this.txtNomePessoa);
            this.panel5.Controls.Add(this.txtIdPessoa);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Enabled = false;
            this.panel5.Location = new System.Drawing.Point(466, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(334, 65);
            this.panel5.TabIndex = 6;
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnFornecedor.Location = new System.Drawing.Point(67, 15);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(31, 23);
            this.btnFornecedor.TabIndex = 41;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            // 
            // txtNomePessoa
            // 
            this.txtNomePessoa.Location = new System.Drawing.Point(3, 39);
            this.txtNomePessoa.Name = "txtNomePessoa";
            this.txtNomePessoa.ReadOnly = true;
            this.txtNomePessoa.Size = new System.Drawing.Size(325, 20);
            this.txtNomePessoa.TabIndex = 40;
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.Location = new System.Drawing.Point(4, 17);
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdPessoa.Size = new System.Drawing.Size(59, 20);
            this.txtIdPessoa.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Favorecido";
            // 
            // chkValorDocumento
            // 
            this.chkValorDocumento.AutoSize = true;
            this.chkValorDocumento.Checked = true;
            this.chkValorDocumento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValorDocumento.Location = new System.Drawing.Point(7, 45);
            this.chkValorDocumento.Name = "chkValorDocumento";
            this.chkValorDocumento.Size = new System.Drawing.Size(162, 17);
            this.chkValorDocumento.TabIndex = 38;
            this.chkValorDocumento.Text = "Todas as Contas do Período";
            this.chkValorDocumento.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "até";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Valor Documento";
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(144, 21);
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.numeroDecimais = 0;
            this.txtValorFinal.Size = new System.Drawing.Size(109, 20);
            this.txtValorFinal.TabIndex = 35;
            this.txtValorFinal.Text = "0,00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Valor Documento";
            // 
            // txtValorInicio
            // 
            this.txtValorInicio.Location = new System.Drawing.Point(6, 21);
            this.txtValorInicio.Name = "txtValorInicio";
            this.txtValorInicio.numeroDecimais = 0;
            this.txtValorInicio.Size = new System.Drawing.Size(109, 20);
            this.txtValorInicio.TabIndex = 33;
            this.txtValorInicio.Text = "0,00";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.chkValorDocumento);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtValorFinal);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.txtValorInicio);
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(206, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(259, 65);
            this.panel4.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(803, 489);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(267, 64);
            this.panel6.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.lblSdoFinalConciliado);
            this.panel10.Location = new System.Drawing.Point(133, 31);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(123, 23);
            this.panel10.TabIndex = 53;
            // 
            // lblSdoFinalConciliado
            // 
            this.lblSdoFinalConciliado.AutoSize = true;
            this.lblSdoFinalConciliado.Location = new System.Drawing.Point(3, 4);
            this.lblSdoFinalConciliado.Name = "lblSdoFinalConciliado";
            this.lblSdoFinalConciliado.Size = new System.Drawing.Size(28, 13);
            this.lblSdoFinalConciliado.TabIndex = 51;
            this.lblSdoFinalConciliado.Text = "0,00";
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblSdoFinal);
            this.panel9.Location = new System.Drawing.Point(8, 31);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(123, 23);
            this.panel9.TabIndex = 52;
            // 
            // lblSdoFinal
            // 
            this.lblSdoFinal.AutoSize = true;
            this.lblSdoFinal.Location = new System.Drawing.Point(3, 4);
            this.lblSdoFinal.Name = "lblSdoFinal";
            this.lblSdoFinal.Size = new System.Drawing.Size(28, 13);
            this.lblSdoFinal.TabIndex = 50;
            this.lblSdoFinal.Text = "0,00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Sdo Final";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Sdo Final Conciliado";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btnDesmarcarTodos);
            this.panel7.Controls.Add(this.btnMarcarTodos);
            this.panel7.Location = new System.Drawing.Point(152, 489);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(273, 62);
            this.panel7.TabIndex = 8;
            this.panel7.Visible = false;
            // 
            // btnDesmarcarTodos
            // 
            this.btnDesmarcarTodos.Location = new System.Drawing.Point(7, 34);
            this.btnDesmarcarTodos.Name = "btnDesmarcarTodos";
            this.btnDesmarcarTodos.Size = new System.Drawing.Size(258, 23);
            this.btnDesmarcarTodos.TabIndex = 1;
            this.btnDesmarcarTodos.Text = "Desmarcar Todos os Movimentos Não Conciliados";
            this.btnDesmarcarTodos.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodos.Click += new System.EventHandler(this.btnDesmarcarTodos_Click);
            // 
            // btnMarcarTodos
            // 
            this.btnMarcarTodos.Location = new System.Drawing.Point(7, 5);
            this.btnMarcarTodos.Name = "btnMarcarTodos";
            this.btnMarcarTodos.Size = new System.Drawing.Size(258, 23);
            this.btnMarcarTodos.TabIndex = 0;
            this.btnMarcarTodos.Text = "Marcar Todos os Movimentos Não Conciliados";
            this.btnMarcarTodos.UseVisualStyleBackColor = true;
            this.btnMarcarTodos.Click += new System.EventHandler(this.btnMarcarTodos_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.txtDtaConciliacao);
            this.panel8.Location = new System.Drawing.Point(5, 489);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(141, 62);
            this.panel8.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Data Conciliação";
            // 
            // txtDtaConciliacao
            // 
            this.txtDtaConciliacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaConciliacao.Location = new System.Drawing.Point(12, 29);
            this.txtDtaConciliacao.Name = "txtDtaConciliacao";
            this.txtDtaConciliacao.Size = new System.Drawing.Size(111, 20);
            this.txtDtaConciliacao.TabIndex = 17;
            // 
            // dtMovBancario
            // 
            this.dtMovBancario.DataSetName = "NewDataSet";
            this.dtMovBancario.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17});
            this.dataTable1.TableName = "Extrato";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "codempresa";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.AllowDBNull = false;
            this.dataColumn2.ColumnName = "idmovimentobancario";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "datamovimento";
            this.dataColumn3.DataType = typeof(System.DateTime);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "dataconciliacao";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "valordebito";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "valorcredito";
            this.dataColumn6.DataType = typeof(decimal);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "documento";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "historicoagrupado";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "historico";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "codempresa_pessoa";
            this.dataColumn10.DataType = typeof(int);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "idpessoa";
            this.dataColumn11.DataType = typeof(int);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "nominal";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "situacao";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "ctabancaria_idempresa";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "ctabancaria_idctabancaria";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "chequeemitido";
            // 
            // rptExtrato
            // 
            this.rptExtrato.ReportResourceString = resources.GetString("rptExtrato.ReportResourceString");
            this.rptExtrato.RegisterData(this.dtMovBancario, "dtMovBancario");
            // 
            // rptExtratoConciliado
            // 
            this.rptExtratoConciliado.ReportResourceString = resources.GetString("rptExtratoConciliado.ReportResourceString");
            this.rptExtratoConciliado.RegisterData(this.dtMovBancario, "dtMovBancario");
            // 
            // status
            // 
            this.status.HeaderText = "ST";
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.status.Width = 25;
            // 
            // historicooculto
            // 
            this.historicooculto.DataPropertyName = "historico";
            this.historicooculto.HeaderText = "historicooculto";
            this.historicooculto.Name = "historicooculto";
            this.historicooculto.Visible = false;
            // 
            // vdataconciliacao
            // 
            dataGridViewCellStyle2.NullValue = null;
            this.vdataconciliacao.DefaultCellStyle = dataGridViewCellStyle2;
            this.vdataconciliacao.HeaderText = "Dt.Conciliação";
            this.vdataconciliacao.Name = "vdataconciliacao";
            this.vdataconciliacao.Width = 80;
            // 
            // datamovimento
            // 
            this.datamovimento.DataPropertyName = "datamovimento";
            this.datamovimento.HeaderText = "Dt.Movimento";
            this.datamovimento.Name = "datamovimento";
            this.datamovimento.ReadOnly = true;
            this.datamovimento.Width = 80;
            // 
            // dataconciliacao
            // 
            this.dataconciliacao.DataPropertyName = "dataconciliacao";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataconciliacao.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataconciliacao.HeaderText = "Conciliado";
            this.dataconciliacao.Name = "dataconciliacao";
            this.dataconciliacao.ReadOnly = true;
            this.dataconciliacao.Width = 80;
            // 
            // vlrcredito
            // 
            this.vlrcredito.DataPropertyName = "valorcredito";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.vlrcredito.DefaultCellStyle = dataGridViewCellStyle4;
            this.vlrcredito.HeaderText = "Crédito";
            this.vlrcredito.Name = "vlrcredito";
            this.vlrcredito.ReadOnly = true;
            // 
            // vlrdebito
            // 
            this.vlrdebito.DataPropertyName = "valordebito";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.vlrdebito.DefaultCellStyle = dataGridViewCellStyle5;
            this.vlrdebito.HeaderText = "Débito";
            this.vlrdebito.Name = "vlrdebito";
            this.vlrdebito.ReadOnly = true;
            // 
            // saldo
            // 
            this.saldo.DataPropertyName = "saldo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.saldo.DefaultCellStyle = dataGridViewCellStyle6;
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            this.saldo.ReadOnly = true;
            this.saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // saldoconciliado
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.saldoconciliado.DefaultCellStyle = dataGridViewCellStyle7;
            this.saldoconciliado.HeaderText = "Sdo Conciliado";
            this.saldoconciliado.Name = "saldoconciliado";
            this.saldoconciliado.Visible = false;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            this.documento.Width = 150;
            // 
            // cheque
            // 
            this.cheque.DataPropertyName = "chequeemitido";
            this.cheque.HeaderText = "Cheque";
            this.cheque.Name = "cheque";
            // 
            // favorecido
            // 
            this.favorecido.DataPropertyName = "nominal";
            this.favorecido.HeaderText = "Favorecido";
            this.favorecido.Name = "favorecido";
            this.favorecido.ReadOnly = true;
            this.favorecido.Width = 300;
            // 
            // historico
            // 
            this.historico.DataPropertyName = "historicoagrupado";
            this.historico.HeaderText = "Histórico";
            this.historico.Name = "historico";
            this.historico.ReadOnly = true;
            this.historico.Width = 300;
            // 
            // idmovimentobancario
            // 
            this.idmovimentobancario.DataPropertyName = "idmovimentobancario";
            this.idmovimentobancario.HeaderText = "Id";
            this.idmovimentobancario.Name = "idmovimentobancario";
            this.idmovimentobancario.ReadOnly = true;
            this.idmovimentobancario.Visible = false;
            // 
            // codigoempresa
            // 
            this.codigoempresa.DataPropertyName = "codempresa";
            this.codigoempresa.HeaderText = "codempresa";
            this.codigoempresa.Name = "codigoempresa";
            this.codigoempresa.ReadOnly = true;
            this.codigoempresa.Visible = false;
            // 
            // codempresa_pessoa
            // 
            this.codempresa_pessoa.DataPropertyName = "codempresa_pessoa";
            this.codempresa_pessoa.HeaderText = "codempresa_pessoa";
            this.codempresa_pessoa.Name = "codempresa_pessoa";
            this.codempresa_pessoa.ReadOnly = true;
            this.codempresa_pessoa.Visible = false;
            // 
            // idpessoa
            // 
            this.idpessoa.DataPropertyName = "idpessoa";
            this.idpessoa.HeaderText = "idpessoa";
            this.idpessoa.Name = "idpessoa";
            this.idpessoa.ReadOnly = true;
            this.idpessoa.Visible = false;
            // 
            // ctabancaria_idempresa
            // 
            this.ctabancaria_idempresa.DataPropertyName = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.HeaderText = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.Name = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.Visible = false;
            // 
            // ctabancaria_idctabancaria
            // 
            this.ctabancaria_idctabancaria.DataPropertyName = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.HeaderText = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.Name = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.Visible = false;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "situacao";
            this.situacao.Name = "situacao";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "nomepessoa";
            // 
            // frmGrdMovBancario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1072, 556);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grdMovBanco);
            this.Controls.Add(this.panel1);
            this.Name = "frmGrdMovBancario";
            this.Text = "Movimento Bancário";
            this.Load += new System.EventHandler(this.frmGrdMovBanario_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdMovBanco, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.panel8, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovBanco)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMovBancario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptExtrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptExtratoConciliado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdMovBanco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIdContaBancaria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkValorDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorFinal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorInicio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.TextBox txtNomePessoa;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkMovimentoConciliado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnDesmarcarTodos;
        private System.Windows.Forms.Button btnMarcarTodos;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtDtaConciliacao;
        private System.Windows.Forms.Label lblSdoFinal;
        private System.Windows.Forms.Label lblSdoFinalConciliado;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lblSdoInicialConciliado;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblSdoInicial;
        private System.Data.DataSet dtMovBancario;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private FastReport.Report rptExtrato;
        private System.Data.DataColumn dataColumn16;
        private System.Windows.Forms.CheckBox chkPDF;
        private FastReport.Report rptExtratoConciliado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn historicooculto;
        private System.Windows.Forms.DataGridViewTextBoxColumn vdataconciliacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn datamovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataconciliacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrcredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrdebito;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoconciliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn favorecido;
        private System.Windows.Forms.DataGridViewTextBoxColumn historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmovimentobancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn codempresa_pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idctabancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Data.DataColumn dataColumn17;
    }
}
