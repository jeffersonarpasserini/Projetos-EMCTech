namespace EMCFinanceiro
{
    partial class frmEmissaoRecibos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmissaoRecibos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoRecibo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFinalPeriodo = new System.Windows.Forms.DateTimePicker();
            this.txtInicioPeriodo = new System.Windows.Forms.DateTimePicker();
            this.grdRecibo = new System.Windows.Forms.DataGridView();
            this.emite = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idrecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datamovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valormovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contadescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrocheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomepessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmovimentobancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCheque = new System.Windows.Forms.Panel();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboModeloRecibo = new System.Windows.Forms.ComboBox();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboContaBancaria = new System.Windows.Forms.ComboBox();
            this.btnDesmarcarTodos = new System.Windows.Forms.Button();
            this.btnMarcarTodos = new System.Windows.Forms.Button();
            this.dataTableAntigo = new System.Data.DataTable();
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
            this.dstRecibo = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.dataColumn29 = new System.Data.DataColumn();
            this.dataColumn30 = new System.Data.DataColumn();
            this.dataColumn31 = new System.Data.DataColumn();
            this.dataColumn32 = new System.Data.DataColumn();
            this.dataColumn33 = new System.Data.DataColumn();
            this.dataColumn34 = new System.Data.DataColumn();
            this.dataColumn35 = new System.Data.DataColumn();
            this.dataColumn36 = new System.Data.DataColumn();
            this.dataColumn37 = new System.Data.DataColumn();
            this.reciboPGSimples = new FastReport.Report();
            this.reciboPGCompleto = new FastReport.Report();
            this.reciboRCSimples = new FastReport.Report();
            this.reciboRCCompleto = new FastReport.Report();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecibo)).BeginInit();
            this.panCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAntigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstRecibo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboPGSimples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboPGCompleto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboRCSimples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboRCCompleto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboTipoRecibo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFinalPeriodo);
            this.panel1.Controls.Add(this.txtInicioPeriodo);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 40);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "de :";
            // 
            // cboTipoRecibo
            // 
            this.cboTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoRecibo.FormattingEnabled = true;
            this.cboTipoRecibo.Location = new System.Drawing.Point(165, 11);
            this.cboTipoRecibo.Name = "cboTipoRecibo";
            this.cboTipoRecibo.Size = new System.Drawing.Size(153, 21);
            this.cboTipoRecibo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Selecione o período dos";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(448, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Até";
            // 
            // txtFinalPeriodo
            // 
            this.txtFinalPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFinalPeriodo.Location = new System.Drawing.Point(478, 11);
            this.txtFinalPeriodo.Name = "txtFinalPeriodo";
            this.txtFinalPeriodo.Size = new System.Drawing.Size(96, 20);
            this.txtFinalPeriodo.TabIndex = 3;
            // 
            // txtInicioPeriodo
            // 
            this.txtInicioPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtInicioPeriodo.Location = new System.Drawing.Point(349, 11);
            this.txtInicioPeriodo.Name = "txtInicioPeriodo";
            this.txtInicioPeriodo.Size = new System.Drawing.Size(96, 20);
            this.txtInicioPeriodo.TabIndex = 2;
            // 
            // grdRecibo
            // 
            this.grdRecibo.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdRecibo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdRecibo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecibo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emite,
            this.idrecibo,
            this.datamovimento,
            this.valormovimento,
            this.contadescricao,
            this.nrocheque,
            this.nomepessoa,
            this.idmovimentobancario,
            this.idpessoa});
            this.grdRecibo.Location = new System.Drawing.Point(2, 175);
            this.grdRecibo.Name = "grdRecibo";
            this.grdRecibo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRecibo.Size = new System.Drawing.Size(629, 331);
            this.grdRecibo.TabIndex = 2;
            this.grdRecibo.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdRecibo_CurrentCellDirtyStateChanged);
            // 
            // emite
            // 
            this.emite.HeaderText = "Emite";
            this.emite.Name = "emite";
            this.emite.Width = 50;
            // 
            // idrecibo
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idrecibo.DefaultCellStyle = dataGridViewCellStyle6;
            this.idrecibo.HeaderText = "Nro Recibo";
            this.idrecibo.Name = "idrecibo";
            // 
            // datamovimento
            // 
            this.datamovimento.DataPropertyName = "datamovimento";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.datamovimento.DefaultCellStyle = dataGridViewCellStyle7;
            this.datamovimento.HeaderText = "Data";
            this.datamovimento.Name = "datamovimento";
            // 
            // valormovimento
            // 
            this.valormovimento.DataPropertyName = "valormovimento";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.valormovimento.DefaultCellStyle = dataGridViewCellStyle8;
            this.valormovimento.HeaderText = "Valor";
            this.valormovimento.Name = "valormovimento";
            // 
            // contadescricao
            // 
            this.contadescricao.DataPropertyName = "contadescricao";
            this.contadescricao.HeaderText = "Conta";
            this.contadescricao.Name = "contadescricao";
            // 
            // nrocheque
            // 
            this.nrocheque.DataPropertyName = "nrocheque";
            this.nrocheque.HeaderText = "Nro Cheque";
            this.nrocheque.Name = "nrocheque";
            // 
            // nomepessoa
            // 
            this.nomepessoa.DataPropertyName = "nomepessoa";
            this.nomepessoa.HeaderText = "Nome Pessoa";
            this.nomepessoa.Name = "nomepessoa";
            this.nomepessoa.Width = 300;
            // 
            // idmovimentobancario
            // 
            this.idmovimentobancario.DataPropertyName = "idmovimentobancario";
            this.idmovimentobancario.HeaderText = "idmovimentobancario";
            this.idmovimentobancario.Name = "idmovimentobancario";
            this.idmovimentobancario.Visible = false;
            // 
            // idpessoa
            // 
            this.idpessoa.DataPropertyName = "idpessoa";
            this.idpessoa.HeaderText = "idpessoa";
            this.idpessoa.Name = "idpessoa";
            this.idpessoa.Visible = false;
            // 
            // panCheque
            // 
            this.panCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCheque.Controls.Add(this.chkPDF);
            this.panCheque.Controls.Add(this.label6);
            this.panCheque.Controls.Add(this.cboModeloRecibo);
            this.panCheque.Controls.Add(this.txtNroCheque);
            this.panCheque.Controls.Add(this.label5);
            this.panCheque.Controls.Add(this.label4);
            this.panCheque.Controls.Add(this.cboContaBancaria);
            this.panCheque.Location = new System.Drawing.Point(3, 120);
            this.panCheque.Name = "panCheque";
            this.panCheque.Size = new System.Drawing.Size(628, 52);
            this.panCheque.TabIndex = 3;
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(534, 27);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(86, 17);
            this.chkPDF.TabIndex = 104;
            this.chkPDF.Text = "Exporta PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(367, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Modelo Recibo";
            // 
            // cboModeloRecibo
            // 
            this.cboModeloRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeloRecibo.FormattingEnabled = true;
            this.cboModeloRecibo.Location = new System.Drawing.Point(370, 24);
            this.cboModeloRecibo.Name = "cboModeloRecibo";
            this.cboModeloRecibo.Size = new System.Drawing.Size(158, 21);
            this.cboModeloRecibo.TabIndex = 103;
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Location = new System.Drawing.Point(254, 24);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(112, 20);
            this.txtNroCheque.TabIndex = 102;
            this.txtNroCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Número Cheque";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Conta Bancária";
            // 
            // cboContaBancaria
            // 
            this.cboContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContaBancaria.FormattingEnabled = true;
            this.cboContaBancaria.Location = new System.Drawing.Point(6, 24);
            this.cboContaBancaria.Name = "cboContaBancaria";
            this.cboContaBancaria.Size = new System.Drawing.Size(244, 21);
            this.cboContaBancaria.TabIndex = 2;
            // 
            // btnDesmarcarTodos
            // 
            this.btnDesmarcarTodos.ForeColor = System.Drawing.Color.Black;
            this.btnDesmarcarTodos.Location = new System.Drawing.Point(123, 512);
            this.btnDesmarcarTodos.Name = "btnDesmarcarTodos";
            this.btnDesmarcarTodos.Size = new System.Drawing.Size(113, 23);
            this.btnDesmarcarTodos.TabIndex = 49;
            this.btnDesmarcarTodos.Text = "Desmarcar Todos";
            this.btnDesmarcarTodos.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodos.Click += new System.EventHandler(this.btnDesmarcarTodos_Click);
            // 
            // btnMarcarTodos
            // 
            this.btnMarcarTodos.ForeColor = System.Drawing.Color.Black;
            this.btnMarcarTodos.Location = new System.Drawing.Point(4, 512);
            this.btnMarcarTodos.Name = "btnMarcarTodos";
            this.btnMarcarTodos.Size = new System.Drawing.Size(113, 23);
            this.btnMarcarTodos.TabIndex = 48;
            this.btnMarcarTodos.Text = "Marcar Todos";
            this.btnMarcarTodos.UseVisualStyleBackColor = true;
            this.btnMarcarTodos.Click += new System.EventHandler(this.btnMarcarTodos_Click);
            // 
            // dstRecibo
            // 
            this.dstRecibo.DataSetName = "NewDataSet";
            this.dstRecibo.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "recibo", "movimento", new string[] {
                        "idmovimentobancario"}, new string[] {
                        "idmovimentobancario"}, false)});
            this.dstRecibo.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn14,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25,
            this.dataColumn26});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idmovimentobancario"}, false)});
            this.dataTable1.TableName = "recibo";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "idmovimentobancario";
            this.dataColumn15.DataType = typeof(int);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "idrecibo";
            this.dataColumn16.DataType = typeof(int);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "historico";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "valormovimento";
            this.dataColumn18.DataType = typeof(decimal);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "datarecibo";
            this.dataColumn19.DataType = typeof(System.DateTime);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "nomepessoa";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "cpfpessoa";
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "nomebanco";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "nroconta";
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "nroagencia";
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "extenso";
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "nrocheque";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "descricaoconta";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn27,
            this.dataColumn28,
            this.dataColumn29,
            this.dataColumn30,
            this.dataColumn31,
            this.dataColumn32,
            this.dataColumn33,
            this.dataColumn34,
            this.dataColumn35,
            this.dataColumn36,
            this.dataColumn37});
            this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation1", "recibo", new string[] {
                        "idmovimentobancario"}, new string[] {
                        "idmovimentobancario"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable2.TableName = "movimento";
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "nrodocumento";
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "nroparcela";
            this.dataColumn28.DataType = typeof(int);
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "documentobaixa";
            // 
            // dataColumn30
            // 
            this.dataColumn30.ColumnName = "nomeforncli";
            // 
            // dataColumn31
            // 
            this.dataColumn31.ColumnName = "datapagamento";
            // 
            // dataColumn32
            // 
            this.dataColumn32.ColumnName = "valorparcela";
            this.dataColumn32.DataType = typeof(decimal);
            // 
            // dataColumn33
            // 
            this.dataColumn33.ColumnName = "jurosbaixa";
            this.dataColumn33.DataType = typeof(decimal);
            // 
            // dataColumn34
            // 
            this.dataColumn34.ColumnName = "descontobaixa";
            this.dataColumn34.DataType = typeof(decimal);
            // 
            // dataColumn35
            // 
            this.dataColumn35.ColumnName = "valorbaixa";
            this.dataColumn35.DataType = typeof(decimal);
            // 
            // dataColumn36
            // 
            this.dataColumn36.ColumnName = "idmovimentobancario";
            this.dataColumn36.DataType = typeof(int);
            // 
            // dataColumn37
            // 
            this.dataColumn37.ColumnName = "idbaixa";
            // 
            // reciboPGSimples
            // 
            this.reciboPGSimples.ReportResourceString = resources.GetString("reciboPGSimples.ReportResourceString");
            this.reciboPGSimples.RegisterData(this.dstRecibo, "dstRecibo");
            // 
            // reciboPGCompleto
            // 
            this.reciboPGCompleto.ReportResourceString = resources.GetString("reciboPGCompleto.ReportResourceString");
            this.reciboPGCompleto.RegisterData(this.dstRecibo, "dstRecibo");
            // 
            // reciboRCSimples
            // 
            this.reciboRCSimples.ReportResourceString = resources.GetString("reciboRCSimples.ReportResourceString");
            this.reciboRCSimples.RegisterData(this.dstRecibo, "dstRecibo");
            // 
            // reciboRCCompleto
            // 
            this.reciboRCCompleto.ReportResourceString = resources.GetString("reciboRCCompleto.ReportResourceString");
            this.reciboRCCompleto.RegisterData(this.dstRecibo, "dstRecibo");
            // 
            // frmEmissaoRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 538);
            this.Controls.Add(this.btnDesmarcarTodos);
            this.Controls.Add(this.btnMarcarTodos);
            this.Controls.Add(this.panCheque);
            this.Controls.Add(this.grdRecibo);
            this.Controls.Add(this.panel1);
            this.Name = "frmEmissaoRecibos";
            this.Text = "Emissão de Recibos";
            this.Load += new System.EventHandler(this.frmEmissaoRecibos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdRecibo, 0);
            this.Controls.SetChildIndex(this.panCheque, 0);
            this.Controls.SetChildIndex(this.btnMarcarTodos, 0);
            this.Controls.SetChildIndex(this.btnDesmarcarTodos, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecibo)).EndInit();
            this.panCheque.ResumeLayout(false);
            this.panCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAntigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstRecibo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboPGSimples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboPGCompleto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboRCSimples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reciboRCCompleto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFinalPeriodo;
        private System.Windows.Forms.DateTimePicker txtInicioPeriodo;
        private System.Windows.Forms.DataGridView grdRecibo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoRecibo;
        private System.Windows.Forms.Panel panCheque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboContaBancaria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNroCheque;
        private System.Windows.Forms.Button btnDesmarcarTodos;
        private System.Windows.Forms.Button btnMarcarTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn emite;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn datamovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valormovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn contadescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomepessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmovimentobancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpessoa;
        private System.Data.DataTable dataTableAntigo;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboModeloRecibo;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataSet dstRecibo;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private System.Data.DataColumn dataColumn26;
        public System.Data.DataTable dataTable1;
        private FastReport.Report reciboPGSimples;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn27;
        private System.Data.DataColumn dataColumn28;
        private System.Data.DataColumn dataColumn29;
        private System.Data.DataColumn dataColumn30;
        private System.Data.DataColumn dataColumn31;
        private System.Data.DataColumn dataColumn32;
        private System.Data.DataColumn dataColumn33;
        private System.Data.DataColumn dataColumn34;
        private System.Data.DataColumn dataColumn35;
        private System.Data.DataColumn dataColumn36;
        private System.Windows.Forms.CheckBox chkPDF;
        private FastReport.Report reciboPGCompleto;
        private FastReport.Report reciboRCSimples;
        private System.Data.DataColumn dataColumn37;
        private FastReport.Report reciboRCCompleto;
    }
}
