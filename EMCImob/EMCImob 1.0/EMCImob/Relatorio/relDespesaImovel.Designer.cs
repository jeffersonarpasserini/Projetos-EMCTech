namespace EMCImob.Relatorios
{
    partial class relDespesaImovel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relDespesaImovel));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.txtPessoa = new System.Windows.Forms.TextBox();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRelatorio = new System.Windows.Forms.ComboBox();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.chkFornecedor = new System.Windows.Forms.CheckBox();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.chkImovel = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dstDespesaImovel = new System.Data.DataSet();
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
            this.dataTable6 = new System.Data.DataTable();
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
            this.dataColumn14 = new System.Data.DataColumn();
            this.rptDespesaImovel = new FastReport.Report();
            this.rptFornecedor = new FastReport.Report();
            this.rptImovel = new FastReport.Report();
            this.txtIdDespesaImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.panBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstDespesaImovel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptDespesaImovel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptImovel)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.txtIdDespesaImovel);
            this.panBotoes.Controls.Add(this.txtIdImovel);
            this.panBotoes.Size = new System.Drawing.Size(468, 68);
            this.panBotoes.Controls.SetChildIndex(this.txtIdImovel, 0);
            this.panBotoes.Controls.SetChildIndex(this.txtIdDespesaImovel, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Fornecedor";
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdPessoa.Location = new System.Drawing.Point(9, 190);
            this.txtIdPessoa.MaxLength = 50;
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(40, 20);
            this.txtIdPessoa.TabIndex = 8;
            this.txtIdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPessoa_Validating);
            // 
            // txtPessoa
            // 
            this.txtPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPessoa.Location = new System.Drawing.Point(81, 190);
            this.txtPessoa.MaxLength = 50;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(389, 20);
            this.txtPessoa.TabIndex = 10;
            // 
            // btnPessoa
            // 
            this.btnPessoa.Image = ((System.Drawing.Image)(resources.GetObject("btnPessoa.Image")));
            this.btnPessoa.Location = new System.Drawing.Point(50, 189);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(30, 22);
            this.btnPessoa.TabIndex = 9;
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboRelatorio);
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataInicial);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 49);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(387, 9);
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
            this.cboRelatorio.Size = new System.Drawing.Size(204, 21);
            this.cboRelatorio.TabIndex = 1;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(387, 24);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(71, 20);
            this.txtDataFinal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(307, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 500;
            this.label3.Text = "Período de";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(310, 24);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(71, 20);
            this.txtDataInicial.TabIndex = 2;
            // 
            // chkFornecedor
            // 
            this.chkFornecedor.AutoSize = true;
            this.chkFornecedor.Checked = true;
            this.chkFornecedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFornecedor.ForeColor = System.Drawing.Color.Black;
            this.chkFornecedor.Location = new System.Drawing.Point(333, 172);
            this.chkFornecedor.Name = "chkFornecedor";
            this.chkFornecedor.Size = new System.Drawing.Size(138, 17);
            this.chkFornecedor.TabIndex = 11;
            this.chkFornecedor.Text = "Todos os Fornecedores";
            this.chkFornecedor.UseVisualStyleBackColor = true;
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(112, 149);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(215, 20);
            this.txtImovel.TabIndex = 6;
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(351, 3);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdImovel.TabIndex = 4;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // chkImovel
            // 
            this.chkImovel.AutoSize = true;
            this.chkImovel.Checked = true;
            this.chkImovel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImovel.ForeColor = System.Drawing.Color.Black;
            this.chkImovel.Location = new System.Drawing.Point(333, 151);
            this.chkImovel.Name = "chkImovel";
            this.chkImovel.Size = new System.Drawing.Size(109, 17);
            this.chkImovel.TabIndex = 7;
            this.chkImovel.Text = "Todos os Imóveis";
            this.chkImovel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "Imóvel";
            // 
            // dstDespesaImovel
            // 
            this.dstDespesaImovel.DataSetName = "NewDataSet";
            this.dstDespesaImovel.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "Imovel", "DespesaImovel", new string[] {
                        "IdImovel"}, new string[] {
                        "idimovel"}, false)});
            this.dstDespesaImovel.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable6});
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
            this.dataColumn13});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation1", "Imovel", new string[] {
                        "IdImovel"}, new string[] {
                        "idimovel"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable1.TableName = "DespesaImovel";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AllowDBNull = false;
            this.dataColumn1.ColumnName = "IdDespesaImovel";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "idimovel";
            this.dataColumn2.DataType = typeof(short);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "idlocacaoproventos";
            this.dataColumn3.DataType = typeof(short);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "desc_tipoimovel";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "proventos";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "datalancamento";
            this.dataColumn6.DataType = typeof(System.DateTime);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "historico";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "valordespesa";
            this.dataColumn8.DataType = typeof(double);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "dataacerto";
            this.dataColumn9.DataType = typeof(System.DateTime);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "situacao";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "descricaoacerto";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "fornecedor_idpessoa";
            this.dataColumn12.DataType = typeof(short);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "nome_proprietario";
            // 
            // dataTable6
            // 
            this.dataTable6.Columns.AddRange(new System.Data.DataColumn[] {
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
            this.dataColumn14});
            this.dataTable6.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "IdImovel"}, false)});
            this.dataTable6.TableName = "Imovel";
            // 
            // dataColumn57
            // 
            this.dataColumn57.AllowDBNull = false;
            this.dataColumn57.ColumnName = "IdImovel";
            this.dataColumn57.DataType = typeof(short);
            // 
            // dataColumn58
            // 
            this.dataColumn58.ColumnName = "idtipoimovel";
            this.dataColumn58.DataType = typeof(short);
            // 
            // dataColumn59
            // 
            this.dataColumn59.ColumnName = "tipoimovel";
            // 
            // dataColumn60
            // 
            this.dataColumn60.ColumnName = "rua";
            // 
            // dataColumn61
            // 
            this.dataColumn61.ColumnName = "numero";
            // 
            // dataColumn62
            // 
            this.dataColumn62.ColumnName = "complemento";
            // 
            // dataColumn63
            // 
            this.dataColumn63.ColumnName = "bairro";
            // 
            // dataColumn64
            // 
            this.dataColumn64.ColumnName = "nrocep";
            // 
            // dataColumn65
            // 
            this.dataColumn65.ColumnName = "cidade";
            // 
            // dataColumn66
            // 
            this.dataColumn66.ColumnName = "estado";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "codigoimovel";
            // 
            // rptDespesaImovel
            // 
            this.rptDespesaImovel.ReportResourceString = resources.GetString("rptDespesaImovel.ReportResourceString");
            this.rptDespesaImovel.RegisterData(this.dstDespesaImovel, "dstDespesaImovel");
            // 
            // rptFornecedor
            // 
            this.rptFornecedor.ReportResourceString = resources.GetString("rptFornecedor.ReportResourceString");
            this.rptFornecedor.RegisterData(this.dstDespesaImovel, "dstDespesaImovel");
            // 
            // rptImovel
            // 
            this.rptImovel.ReportResourceString = resources.GetString("rptImovel.ReportResourceString");
            this.rptImovel.RegisterData(this.dstDespesaImovel, "dstDespesaImovel");
            // 
            // txtIdDespesaImovel
            // 
            this.txtIdDespesaImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdDespesaImovel.Location = new System.Drawing.Point(417, 3);
            this.txtIdDespesaImovel.MaxLength = 50;
            this.txtIdDespesaImovel.Name = "txtIdDespesaImovel";
            this.txtIdDespesaImovel.Size = new System.Drawing.Size(41, 20);
            this.txtIdDespesaImovel.TabIndex = 503;
            this.txtIdDespesaImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdDespesaImovel.Visible = false;
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(81, 148);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 121;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(9, 149);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(71, 20);
            this.txtCodigoImovel.TabIndex = 503;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // relDespesaImovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 217);
            this.Controls.Add(this.txtCodigoImovel);
            this.Controls.Add(this.btnImovel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPessoa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkImovel);
            this.Controls.Add(this.txtIdPessoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImovel);
            this.Controls.Add(this.chkFornecedor);
            this.Controls.Add(this.btnPessoa);
            this.Name = "relDespesaImovel";
            this.Text = "Relatório Despesas do Imóvel";
            this.Load += new System.EventHandler(this.relDespesaImovel_Load);
            this.Controls.SetChildIndex(this.btnPessoa, 0);
            this.Controls.SetChildIndex(this.chkFornecedor, 0);
            this.Controls.SetChildIndex(this.txtImovel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtIdPessoa, 0);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.chkImovel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtPessoa, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnImovel, 0);
            this.Controls.SetChildIndex(this.txtCodigoImovel, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstDespesaImovel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptDespesaImovel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptImovel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.TextBox txtPessoa;
        private System.Windows.Forms.Button btnPessoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFornecedor;
        private System.Windows.Forms.ComboBox cboRelatorio;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.CheckBox chkImovel;
        private System.Windows.Forms.Label label2;
        private System.Data.DataSet dstDespesaImovel;
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
        private FastReport.Report rptDespesaImovel;
        private FastReport.Report rptFornecedor;
        private System.Data.DataTable dataTable6;
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
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.Label label3;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private System.Windows.Forms.Label label4;
        private FastReport.Report rptImovel;
        private System.Windows.Forms.TextBox txtIdDespesaImovel;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Data.DataColumn dataColumn14;
    }
}