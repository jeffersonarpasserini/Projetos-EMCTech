namespace EMCEventos.Relatorios
{
    partial class relContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relContrato));
            this.chkSubLocacao = new System.Windows.Forms.CheckBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRelatorio = new System.Windows.Forms.ComboBox();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataInicio = new MaskedDateEntryControl.MaskedDateTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkFornecedor = new System.Windows.Forms.CheckBox();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.btnSubLocacao = new System.Windows.Forms.Button();
            this.txtDescSubLocacao = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIdSubLocacao = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdContrato = new System.Windows.Forms.TextBox();
            this.dstContrato = new System.Data.DataSet();
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
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataTable3 = new System.Data.DataTable();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataTable4 = new System.Data.DataTable();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.rptCliente = new FastReport.Report();
            this.rptContrato = new FastReport.Report();
            this.rptFornecedor = new FastReport.Report();
            this.panBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptFornecedor)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.txtIdContrato);
            this.panBotoes.Location = new System.Drawing.Point(4, 4);
            this.panBotoes.Size = new System.Drawing.Size(583, 68);
            this.panBotoes.Controls.SetChildIndex(this.txtIdContrato, 0);
            // 
            // chkSubLocacao
            // 
            this.chkSubLocacao.AutoSize = true;
            this.chkSubLocacao.Checked = true;
            this.chkSubLocacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubLocacao.ForeColor = System.Drawing.Color.Black;
            this.chkSubLocacao.Location = new System.Drawing.Point(445, 53);
            this.chkSubLocacao.Name = "chkSubLocacao";
            this.chkSubLocacao.Size = new System.Drawing.Size(110, 17);
            this.chkSubLocacao.TabIndex = 522;
            this.chkSubLocacao.Text = "Todas as SubLoc";
            this.chkSubLocacao.UseVisualStyleBackColor = true;
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Checked = true;
            this.chkCliente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCliente.ForeColor = System.Drawing.Color.Black;
            this.chkCliente.Location = new System.Drawing.Point(445, 17);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(110, 17);
            this.chkCliente.TabIndex = 513;
            this.chkCliente.Text = "Todos os Clientes";
            this.chkCliente.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboRelatorio);
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDataInicio);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(4, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 49);
            this.groupBox1.TabIndex = 524;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(484, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 502;
            this.label4.Text = "Até";
            // 
            // cboRelatorio
            // 
            this.cboRelatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelatorio.FormattingEnabled = true;
            this.cboRelatorio.Location = new System.Drawing.Point(7, 23);
            this.cboRelatorio.Name = "cboRelatorio";
            this.cboRelatorio.Size = new System.Drawing.Size(251, 21);
            this.cboRelatorio.TabIndex = 1;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(482, 24);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(79, 20);
            this.txtDataFinal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(395, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 500;
            this.label1.Text = "Data Contrato";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.DateValue = null;
            this.txtDataInicio.Location = new System.Drawing.Point(399, 24);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.RequireValidEntry = true;
            this.txtDataInicio.Size = new System.Drawing.Size(79, 20);
            this.txtDataInicio.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkFornecedor);
            this.panel2.Controls.Add(this.chkSubLocacao);
            this.panel2.Controls.Add(this.cboFornecedor);
            this.panel2.Controls.Add(this.btnSubLocacao);
            this.panel2.Controls.Add(this.txtDescSubLocacao);
            this.panel2.Controls.Add(this.btnCliente);
            this.panel2.Controls.Add(this.chkCliente);
            this.panel2.Controls.Add(this.txtRazaoSocial);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtIdSubLocacao);
            this.panel2.Controls.Add(this.txtIdCliente);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(4, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 112);
            this.panel2.TabIndex = 526;
            // 
            // chkFornecedor
            // 
            this.chkFornecedor.AutoSize = true;
            this.chkFornecedor.Checked = true;
            this.chkFornecedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFornecedor.ForeColor = System.Drawing.Color.Black;
            this.chkFornecedor.Location = new System.Drawing.Point(445, 87);
            this.chkFornecedor.Name = "chkFornecedor";
            this.chkFornecedor.Size = new System.Drawing.Size(138, 17);
            this.chkFornecedor.TabIndex = 523;
            this.chkFornecedor.Text = "Todos os Fornecedores";
            this.chkFornecedor.UseVisualStyleBackColor = true;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(3, 86);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(435, 21);
            this.cboFornecedor.TabIndex = 18;
            // 
            // btnSubLocacao
            // 
            this.btnSubLocacao.Image = ((System.Drawing.Image)(resources.GetObject("btnSubLocacao.Image")));
            this.btnSubLocacao.Location = new System.Drawing.Point(45, 50);
            this.btnSubLocacao.Name = "btnSubLocacao";
            this.btnSubLocacao.Size = new System.Drawing.Size(30, 22);
            this.btnSubLocacao.TabIndex = 13;
            this.btnSubLocacao.UseVisualStyleBackColor = true;
            this.btnSubLocacao.Click += new System.EventHandler(this.btnSubLocacao_Click);
            // 
            // txtDescSubLocacao
            // 
            this.txtDescSubLocacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescSubLocacao.Location = new System.Drawing.Point(76, 51);
            this.txtDescSubLocacao.MaxLength = 50;
            this.txtDescSubLocacao.Name = "txtDescSubLocacao";
            this.txtDescSubLocacao.ReadOnly = true;
            this.txtDescSubLocacao.Size = new System.Drawing.Size(362, 20);
            this.txtDescSubLocacao.TabIndex = 14;
            // 
            // btnCliente
            // 
            this.btnCliente.Image = global::EMCEventos.Properties.Resources.binoculo_16x16;
            this.btnCliente.Location = new System.Drawing.Point(45, 14);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(30, 22);
            this.btnCliente.TabIndex = 16;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(76, 15);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.ReadOnly = true;
            this.txtRazaoSocial.Size = new System.Drawing.Size(362, 20);
            this.txtRazaoSocial.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 115;
            this.label13.Text = "Fornecedor";
            // 
            // txtIdSubLocacao
            // 
            this.txtIdSubLocacao.Location = new System.Drawing.Point(4, 51);
            this.txtIdSubLocacao.Name = "txtIdSubLocacao";
            this.txtIdSubLocacao.Size = new System.Drawing.Size(40, 20);
            this.txtIdSubLocacao.TabIndex = 12;
            this.txtIdSubLocacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdSubLocacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdSubLocacao_Validating);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(4, 15);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(40, 20);
            this.txtIdCliente.TabIndex = 15;
            this.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCliente_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "SubLocação";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Cliente";
            // 
            // txtIdContrato
            // 
            this.txtIdContrato.Location = new System.Drawing.Point(480, 7);
            this.txtIdContrato.Name = "txtIdContrato";
            this.txtIdContrato.Size = new System.Drawing.Size(78, 20);
            this.txtIdContrato.TabIndex = 8;
            this.txtIdContrato.Visible = false;
            // 
            // dstContrato
            // 
            this.dstContrato.DataSetName = "NewDataSet";
            this.dstContrato.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "SubLocacao", "Contrato", new string[] {
                        "idevt_sublocacao"}, new string[] {
                        "idev_sublocacao"}, false),
            new System.Data.DataRelation("Relation2", "Cliente", "Contrato", new string[] {
                        "idpessoa"}, new string[] {
                        "cliente_idpessoa"}, false),
            new System.Data.DataRelation("Relation3", "Fornecedor", "Contrato", new string[] {
                        "idpessoa"}, new string[] {
                        "fornecedor_idpessoa"}, false)});
            this.dstContrato.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.dataTable3,
            this.dataTable4});
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
            this.dataColumn26});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idevt_contrato"}, true),
            new System.Data.ForeignKeyConstraint("Relation1", "SubLocacao", new string[] {
                        "idevt_sublocacao"}, new string[] {
                        "idev_sublocacao"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
            new System.Data.ForeignKeyConstraint("Relation2", "Cliente", new string[] {
                        "idpessoa"}, new string[] {
                        "cliente_idpessoa"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
            new System.Data.ForeignKeyConstraint("Relation3", "Fornecedor", new string[] {
                        "idpessoa"}, new string[] {
                        "fornecedor_idpessoa"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable1.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn1};
            this.dataTable1.TableName = "Contrato";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "idevt_contrato";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "datacontrato";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "valorcontrato";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "nroparcelas";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "idev_sublocacao";
            this.dataColumn5.DataType = typeof(short);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "cliente_codempresa";
            this.dataColumn6.DataType = typeof(short);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "cliente_idpessoa";
            this.dataColumn7.DataType = typeof(short);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "fornecedor_codempresa";
            this.dataColumn8.DataType = typeof(short);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "fornecedor_idpessoa";
            this.dataColumn9.DataType = typeof(short);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "geracontaspagar";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "gerataxaadministracao";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "percenturaladministracao";
            this.dataColumn12.DataType = typeof(decimal);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "valoradministracao";
            this.dataColumn13.DataType = typeof(decimal);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "dataaprovacao";
            this.dataColumn14.DataType = typeof(System.DateTime);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "situacao";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "nome_cliente";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19});
            this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idevt_sublocacao"}, false)});
            this.dataTable2.TableName = "SubLocacao";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "idevt_sublocacao";
            this.dataColumn16.DataType = typeof(short);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "descricao";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "idevt_evento";
            this.dataColumn18.DataType = typeof(short);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "idbox";
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22});
            this.dataTable3.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idpessoa"}, false)});
            this.dataTable3.TableName = "Cliente";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "codempresa";
            this.dataColumn20.DataType = typeof(short);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "idpessoa";
            this.dataColumn21.DataType = typeof(short);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "nome";
            // 
            // dataTable4
            // 
            this.dataTable4.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25});
            this.dataTable4.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idpessoa"}, false)});
            this.dataTable4.TableName = "Fornecedor";
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "codempresa";
            this.dataColumn23.DataType = typeof(short);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "idpessoa";
            this.dataColumn24.DataType = typeof(short);
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "nome";
            // 
            // rptCliente
            // 
            this.rptCliente.ReportResourceString = resources.GetString("rptCliente.ReportResourceString");
            this.rptCliente.RegisterData(this.dstContrato, "dstContrato");
            // 
            // rptContrato
            // 
            this.rptContrato.ReportResourceString = resources.GetString("rptContrato.ReportResourceString");
            this.rptContrato.RegisterData(this.dstContrato, "dstContrato");
            // 
            // rptFornecedor
            // 
            this.rptFornecedor.ReportResourceString = resources.GetString("rptFornecedor.ReportResourceString");
            this.rptFornecedor.RegisterData(this.dstContrato, "dstContrato");
            // 
            // relContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 242);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "relContrato";
            this.Text = "relContrato";
            this.Load += new System.EventHandler(this.relContrato_Load);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptFornecedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSubLocacao;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRelatorio;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private System.Windows.Forms.Label label1;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkFornecedor;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Button btnSubLocacao;
        private System.Windows.Forms.TextBox txtDescSubLocacao;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIdSubLocacao;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdContrato;
        private System.Data.DataSet dstContrato;
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
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataTable dataTable3;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataTable dataTable4;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private FastReport.Report rptCliente;
        private System.Data.DataColumn dataColumn26;
        private FastReport.Report rptContrato;
        private FastReport.Report rptFornecedor;
    }
}