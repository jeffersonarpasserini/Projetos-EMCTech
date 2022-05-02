namespace EMCFinanceiro
{
    partial class relChequeEmitidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relChequeEmitidos));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboContaBancaria = new System.Windows.Forms.ComboBox();
            this.grdCheques = new System.Windows.Forms.DataGridView();
            this.imprime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idchequeemitir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmovimentobancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrocheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorcheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datacheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPesquisarCheques = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDesmarcarTodos = new System.Windows.Forms.Button();
            this.btnMarcarTodos = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboRelatorioEmitir = new System.Windows.Forms.ComboBox();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.dstCheques = new System.Data.DataSet();
            this.dataTable3 = new System.Data.DataTable();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn40 = new System.Data.DataColumn();
            this.dataColumn41 = new System.Data.DataColumn();
            this.dataColumn42 = new System.Data.DataColumn();
            this.dataColumn43 = new System.Data.DataColumn();
            this.dataColumn44 = new System.Data.DataColumn();
            this.dataColumn45 = new System.Data.DataColumn();
            this.dataColumn46 = new System.Data.DataColumn();
            this.dataColumn47 = new System.Data.DataColumn();
            this.dataColumn48 = new System.Data.DataColumn();
            this.dataColumn49 = new System.Data.DataColumn();
            this.dataColumn50 = new System.Data.DataColumn();
            this.dataColumn51 = new System.Data.DataColumn();
            this.dataColumn52 = new System.Data.DataColumn();
            this.dataColumn53 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataTable4 = new System.Data.DataTable();
            this.dataColumn54 = new System.Data.DataColumn();
            this.dataColumn55 = new System.Data.DataColumn();
            this.dataColumn56 = new System.Data.DataColumn();
            this.dataColumn57 = new System.Data.DataColumn();
            this.dataColumn58 = new System.Data.DataColumn();
            this.dataColumn59 = new System.Data.DataColumn();
            this.dataColumn60 = new System.Data.DataColumn();
            this.dataColumn61 = new System.Data.DataColumn();
            this.dataColumn62 = new System.Data.DataColumn();
            this.dataColumn63 = new System.Data.DataColumn();
            this.dataColumn64 = new System.Data.DataColumn();
            this.dataColumn65 = new System.Data.DataColumn();
            this.dataColumn66 = new System.Data.DataColumn();
            this.dataColumn67 = new System.Data.DataColumn();
            this.dataColumn68 = new System.Data.DataColumn();
            this.dataColumn69 = new System.Data.DataColumn();
            this.dataColumn70 = new System.Data.DataColumn();
            this.dataColumn71 = new System.Data.DataColumn();
            this.dataColumn72 = new System.Data.DataColumn();
            this.dataColumn73 = new System.Data.DataColumn();
            this.rptRelCheque = new FastReport.Report();
            this.rptChequeNaoEmitido = new FastReport.Report();
            this.rptChequeDetalhado = new FastReport.Report();
            this.rptCopiaCheque = new FastReport.Report();
            this.panBotoes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheques)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptRelCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptChequeNaoEmitido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptChequeDetalhado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCopiaCheque)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.chkPDF);
            this.panBotoes.Size = new System.Drawing.Size(544, 68);
            this.panBotoes.Controls.SetChildIndex(this.chkPDF, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDtaFinal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDtaInicial);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(7, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 59);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(109, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Até";
            // 
            // txtDtaFinal
            // 
            this.txtDtaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaFinal.Location = new System.Drawing.Point(112, 30);
            this.txtDtaFinal.Name = "txtDtaFinal";
            this.txtDtaFinal.Size = new System.Drawing.Size(99, 20);
            this.txtDtaFinal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "De";
            // 
            // txtDtaInicial
            // 
            this.txtDtaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaInicial.Location = new System.Drawing.Point(7, 30);
            this.txtDtaInicial.Name = "txtDtaInicial";
            this.txtDtaInicial.Size = new System.Drawing.Size(99, 20);
            this.txtDtaInicial.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboContaBancaria);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(7, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(247, 47);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Conta Bancária";
            // 
            // cboContaBancaria
            // 
            this.cboContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContaBancaria.FormattingEnabled = true;
            this.cboContaBancaria.Location = new System.Drawing.Point(7, 19);
            this.cboContaBancaria.Name = "cboContaBancaria";
            this.cboContaBancaria.Size = new System.Drawing.Size(235, 21);
            this.cboContaBancaria.TabIndex = 3;
            // 
            // grdCheques
            // 
            this.grdCheques.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCheques.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imprime,
            this.idchequeemitir,
            this.idmovimentobancario,
            this.idEmpresa,
            this.nrocheque,
            this.valorcheque,
            this.datacheque,
            this.nominal});
            this.grdCheques.Location = new System.Drawing.Point(7, 199);
            this.grdCheques.MultiSelect = false;
            this.grdCheques.Name = "grdCheques";
            this.grdCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCheques.Size = new System.Drawing.Size(544, 240);
            this.grdCheques.TabIndex = 44;
            // 
            // imprime
            // 
            this.imprime.FalseValue = "0";
            this.imprime.HeaderText = "Imprimir";
            this.imprime.Name = "imprime";
            this.imprime.TrueValue = "1";
            this.imprime.Width = 50;
            // 
            // idchequeemitir
            // 
            this.idchequeemitir.DataPropertyName = "idchequeemitir";
            this.idchequeemitir.HeaderText = "idchequeemitir";
            this.idchequeemitir.Name = "idchequeemitir";
            this.idchequeemitir.Visible = false;
            // 
            // idmovimentobancario
            // 
            this.idmovimentobancario.DataPropertyName = "idmovimentobancario";
            this.idmovimentobancario.HeaderText = "idmovimentobancario";
            this.idmovimentobancario.Name = "idmovimentobancario";
            this.idmovimentobancario.Visible = false;
            // 
            // idEmpresa
            // 
            this.idEmpresa.DataPropertyName = "idEmpresa";
            this.idEmpresa.HeaderText = "idEmpresa";
            this.idEmpresa.Name = "idEmpresa";
            this.idEmpresa.Visible = false;
            // 
            // nrocheque
            // 
            this.nrocheque.DataPropertyName = "nrocheque";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.nrocheque.DefaultCellStyle = dataGridViewCellStyle2;
            this.nrocheque.HeaderText = "Nro Cheque";
            this.nrocheque.Name = "nrocheque";
            this.nrocheque.ReadOnly = true;
            this.nrocheque.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nrocheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nrocheque.Width = 70;
            // 
            // valorcheque
            // 
            this.valorcheque.DataPropertyName = "valorcheque";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valorcheque.DefaultCellStyle = dataGridViewCellStyle3;
            this.valorcheque.HeaderText = "Valor";
            this.valorcheque.Name = "valorcheque";
            // 
            // datacheque
            // 
            this.datacheque.DataPropertyName = "datacheque";
            dataGridViewCellStyle4.NullValue = null;
            this.datacheque.DefaultCellStyle = dataGridViewCellStyle4;
            this.datacheque.HeaderText = "Dt. Cheque";
            this.datacheque.Name = "datacheque";
            this.datacheque.ReadOnly = true;
            // 
            // nominal
            // 
            this.nominal.DataPropertyName = "nominal";
            this.nominal.HeaderText = "Nominal";
            this.nominal.Name = "nominal";
            this.nominal.Width = 150;
            // 
            // btnPesquisarCheques
            // 
            this.btnPesquisarCheques.ForeColor = System.Drawing.Color.Black;
            this.btnPesquisarCheques.Location = new System.Drawing.Point(203, 16);
            this.btnPesquisarCheques.Name = "btnPesquisarCheques";
            this.btnPesquisarCheques.Size = new System.Drawing.Size(93, 23);
            this.btnPesquisarCheques.TabIndex = 45;
            this.btnPesquisarCheques.Text = "Buscar Cheques";
            this.btnPesquisarCheques.UseVisualStyleBackColor = true;
            this.btnPesquisarCheques.Click += new System.EventHandler(this.btnPesquisarCheques_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDesmarcarTodos);
            this.groupBox1.Controls.Add(this.btnMarcarTodos);
            this.groupBox1.Controls.Add(this.btnPesquisarCheques);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(255, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 47);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cheques";
            // 
            // btnDesmarcarTodos
            // 
            this.btnDesmarcarTodos.ForeColor = System.Drawing.Color.Black;
            this.btnDesmarcarTodos.Location = new System.Drawing.Point(102, 16);
            this.btnDesmarcarTodos.Name = "btnDesmarcarTodos";
            this.btnDesmarcarTodos.Size = new System.Drawing.Size(99, 23);
            this.btnDesmarcarTodos.TabIndex = 47;
            this.btnDesmarcarTodos.Text = "Desmarcar Todos";
            this.btnDesmarcarTodos.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodos.Click += new System.EventHandler(this.btnDesmarcarTodos_Click);
            // 
            // btnMarcarTodos
            // 
            this.btnMarcarTodos.ForeColor = System.Drawing.Color.Black;
            this.btnMarcarTodos.Location = new System.Drawing.Point(5, 16);
            this.btnMarcarTodos.Name = "btnMarcarTodos";
            this.btnMarcarTodos.Size = new System.Drawing.Size(95, 23);
            this.btnMarcarTodos.TabIndex = 46;
            this.btnMarcarTodos.Text = "Marcar Todos";
            this.btnMarcarTodos.UseVisualStyleBackColor = true;
            this.btnMarcarTodos.Click += new System.EventHandler(this.btnMarcarTodos_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboRelatorioEmitir);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(228, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 59);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Relatório a Emitir";
            // 
            // cboRelatorioEmitir
            // 
            this.cboRelatorioEmitir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelatorioEmitir.FormattingEnabled = true;
            this.cboRelatorioEmitir.Location = new System.Drawing.Point(6, 29);
            this.cboRelatorioEmitir.Name = "cboRelatorioEmitir";
            this.cboRelatorioEmitir.Size = new System.Drawing.Size(311, 21);
            this.cboRelatorioEmitir.TabIndex = 0;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(451, 46);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(86, 17);
            this.chkPDF.TabIndex = 107;
            this.chkPDF.Text = "Exporta PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // dstCheques
            // 
            this.dstCheques.DataSetName = "NewDataSet";
            this.dstCheques.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("cheque_pagamento_movbanco", "cheque", "pagamentos", new string[] {
                        "idmovimentobancario"}, new string[] {
                        "idmovimentobancario"}, false)});
            this.dstCheques.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable3,
            this.dataTable4});
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn40,
            this.dataColumn41,
            this.dataColumn42,
            this.dataColumn43,
            this.dataColumn44,
            this.dataColumn45,
            this.dataColumn46,
            this.dataColumn47,
            this.dataColumn48,
            this.dataColumn49,
            this.dataColumn50,
            this.dataColumn51,
            this.dataColumn52,
            this.dataColumn53,
            this.dataColumn14});
            this.dataTable3.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idmovimentobancario"}, false)});
            this.dataTable3.TableName = "cheque";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "idchequeemitir";
            this.dataColumn19.DataType = typeof(int);
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "idmovimentobancario";
            this.dataColumn20.DataType = typeof(int);
            // 
            // dataColumn40
            // 
            this.dataColumn40.ColumnName = "idempresa";
            this.dataColumn40.DataType = typeof(int);
            // 
            // dataColumn41
            // 
            this.dataColumn41.ColumnName = "datacheque";
            this.dataColumn41.DataType = typeof(System.DateTime);
            // 
            // dataColumn42
            // 
            this.dataColumn42.ColumnName = "valorcheque";
            this.dataColumn42.DataType = typeof(decimal);
            // 
            // dataColumn43
            // 
            this.dataColumn43.ColumnName = "nrocheque";
            // 
            // dataColumn44
            // 
            this.dataColumn44.ColumnName = "nominal";
            // 
            // dataColumn45
            // 
            this.dataColumn45.ColumnName = "predatado";
            // 
            // dataColumn46
            // 
            this.dataColumn46.ColumnName = "datapredatado";
            this.dataColumn46.DataType = typeof(System.DateTime);
            // 
            // dataColumn47
            // 
            this.dataColumn47.ColumnName = "compensado";
            // 
            // dataColumn48
            // 
            this.dataColumn48.ColumnName = "idctabancaria";
            this.dataColumn48.DataType = typeof(int);
            // 
            // dataColumn49
            // 
            this.dataColumn49.ColumnName = "idbanco";
            // 
            // dataColumn50
            // 
            this.dataColumn50.ColumnName = "descricaobanco";
            // 
            // dataColumn51
            // 
            this.dataColumn51.ColumnName = "nroconta";
            // 
            // dataColumn52
            // 
            this.dataColumn52.ColumnName = "nroagencia";
            // 
            // dataColumn53
            // 
            this.dataColumn53.ColumnName = "descricaoconta";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "extenso";
            // 
            // dataTable4
            // 
            this.dataTable4.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn54,
            this.dataColumn55,
            this.dataColumn56,
            this.dataColumn57,
            this.dataColumn58,
            this.dataColumn59,
            this.dataColumn60,
            this.dataColumn61,
            this.dataColumn62,
            this.dataColumn63,
            this.dataColumn64,
            this.dataColumn65,
            this.dataColumn66,
            this.dataColumn67,
            this.dataColumn68,
            this.dataColumn69,
            this.dataColumn70,
            this.dataColumn71,
            this.dataColumn72,
            this.dataColumn73});
            this.dataTable4.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("cheque_pagamento_movbanco", "cheque", new string[] {
                        "idmovimentobancario"}, new string[] {
                        "idmovimentobancario"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable4.TableName = "pagamentos";
            // 
            // dataColumn54
            // 
            this.dataColumn54.ColumnName = "idpagardocumento";
            this.dataColumn54.DataType = typeof(int);
            // 
            // dataColumn55
            // 
            this.dataColumn55.ColumnName = "idpagarparcelas";
            this.dataColumn55.DataType = typeof(int);
            // 
            // dataColumn56
            // 
            this.dataColumn56.ColumnName = "idpagarbaixa";
            this.dataColumn56.DataType = typeof(int);
            // 
            // dataColumn57
            // 
            this.dataColumn57.ColumnName = "idmovimentobancario";
            this.dataColumn57.DataType = typeof(int);
            // 
            // dataColumn58
            // 
            this.dataColumn58.ColumnName = "nrodocumento";
            // 
            // dataColumn59
            // 
            this.dataColumn59.ColumnName = "dataentrada";
            this.dataColumn59.DataType = typeof(System.DateTime);
            // 
            // dataColumn60
            // 
            this.dataColumn60.ColumnName = "dataemissao";
            this.dataColumn60.DataType = typeof(System.DateTime);
            // 
            // dataColumn61
            // 
            this.dataColumn61.ColumnName = "idfornecedor";
            this.dataColumn61.DataType = typeof(int);
            // 
            // dataColumn62
            // 
            this.dataColumn62.ColumnName = "nomefornecedor";
            // 
            // dataColumn63
            // 
            this.dataColumn63.ColumnName = "cnpjfornecedor";
            // 
            // dataColumn64
            // 
            this.dataColumn64.ColumnName = "nroparcelas";
            // 
            // dataColumn65
            // 
            this.dataColumn65.ColumnName = "nroparcela";
            // 
            // dataColumn66
            // 
            this.dataColumn66.ColumnName = "datavencimento";
            this.dataColumn66.DataType = typeof(System.DateTime);
            // 
            // dataColumn67
            // 
            this.dataColumn67.ColumnName = "datapagamento";
            this.dataColumn67.DataType = typeof(System.DateTime);
            // 
            // dataColumn68
            // 
            this.dataColumn68.ColumnName = "valorbaixa";
            this.dataColumn68.DataType = typeof(decimal);
            // 
            // dataColumn69
            // 
            this.dataColumn69.ColumnName = "cmbaixa";
            this.dataColumn69.DataType = typeof(decimal);
            // 
            // dataColumn70
            // 
            this.dataColumn70.ColumnName = "jurosbaixa";
            this.dataColumn70.DataType = typeof(decimal);
            // 
            // dataColumn71
            // 
            this.dataColumn71.ColumnName = "descontobaixa";
            this.dataColumn71.DataType = typeof(decimal);
            // 
            // dataColumn72
            // 
            this.dataColumn72.ColumnName = "totalbaixa";
            this.dataColumn72.DataType = typeof(decimal);
            // 
            // dataColumn73
            // 
            this.dataColumn73.ColumnName = "historico";
            // 
            // rptRelCheque
            // 
            this.rptRelCheque.ReportResourceString = resources.GetString("rptRelCheque.ReportResourceString");
            this.rptRelCheque.RegisterData(this.dstCheques, "dstCheques");
            // 
            // rptChequeNaoEmitido
            // 
            this.rptChequeNaoEmitido.ReportResourceString = resources.GetString("rptChequeNaoEmitido.ReportResourceString");
            this.rptChequeNaoEmitido.RegisterData(this.dstCheques, "dstCheques");
            // 
            // rptChequeDetalhado
            // 
            this.rptChequeDetalhado.ReportResourceString = resources.GetString("rptChequeDetalhado.ReportResourceString");
            this.rptChequeDetalhado.RegisterData(this.dstCheques, "dstCheques");
            // 
            // rptCopiaCheque
            // 
            this.rptCopiaCheque.ReportResourceString = resources.GetString("rptCopiaCheque.ReportResourceString");
            this.rptCopiaCheque.RegisterData(this.dstCheques, "dstCheques");
            // 
            // relChequeEmitidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(557, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdCheques);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "relChequeEmitidos";
            this.Text = "Relatório de Cheques";
            this.Load += new System.EventHandler(this.relChequeEmitidos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relChequeEmitidos_KeyDown);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.grdCheques, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheques)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dstCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptRelCheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptChequeNaoEmitido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptChequeDetalhado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCopiaCheque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtaInicial;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView grdCheques;
        private System.Windows.Forms.Button btnPesquisarCheques;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDesmarcarTodos;
        private System.Windows.Forms.Button btnMarcarTodos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboRelatorioEmitir;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Data.DataSet dstCheques;
        private System.Data.DataTable dataTable3;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn40;
        private System.Data.DataColumn dataColumn41;
        private System.Data.DataColumn dataColumn42;
        private System.Data.DataColumn dataColumn43;
        private System.Data.DataColumn dataColumn44;
        private System.Data.DataColumn dataColumn45;
        private System.Data.DataColumn dataColumn46;
        private System.Data.DataColumn dataColumn47;
        private System.Data.DataColumn dataColumn48;
        private System.Data.DataColumn dataColumn49;
        private System.Data.DataColumn dataColumn50;
        private System.Data.DataColumn dataColumn51;
        private System.Data.DataColumn dataColumn52;
        private System.Data.DataColumn dataColumn53;
        private System.Data.DataTable dataTable4;
        private System.Data.DataColumn dataColumn54;
        private System.Data.DataColumn dataColumn55;
        private System.Data.DataColumn dataColumn56;
        private System.Data.DataColumn dataColumn57;
        private System.Data.DataColumn dataColumn58;
        private System.Data.DataColumn dataColumn59;
        private System.Data.DataColumn dataColumn60;
        private System.Data.DataColumn dataColumn61;
        private System.Data.DataColumn dataColumn62;
        private System.Data.DataColumn dataColumn63;
        private System.Data.DataColumn dataColumn64;
        private System.Data.DataColumn dataColumn65;
        private System.Data.DataColumn dataColumn66;
        private System.Data.DataColumn dataColumn67;
        private System.Data.DataColumn dataColumn68;
        private System.Data.DataColumn dataColumn69;
        private System.Data.DataColumn dataColumn70;
        private System.Data.DataColumn dataColumn71;
        private System.Data.DataColumn dataColumn72;
        private System.Data.DataColumn dataColumn73;
        private FastReport.Report rptRelCheque;
        private FastReport.Report rptChequeNaoEmitido;
        private FastReport.Report rptChequeDetalhado;
        private FastReport.Report rptCopiaCheque;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.ComboBox cboContaBancaria;
        private System.Windows.Forms.DataGridViewCheckBoxColumn imprime;
        private System.Windows.Forms.DataGridViewTextBoxColumn idchequeemitir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmovimentobancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorcheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn datacheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
    }
}
