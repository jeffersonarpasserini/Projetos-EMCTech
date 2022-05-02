namespace EMCImob.Relatorios
{
    partial class relContratoProventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relContratoProventos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSelecionar = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtIdentificacaoContrato = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dstLocacaoCCPagar = new System.Data.DataSet();
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
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dstLocacaoCCReceber = new System.Data.DataSet();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.rptLocador = new FastReport.Report();
            this.rptLocatario = new FastReport.Report();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoCCPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoCCReceber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocatario)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(257, 68);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSelecionar);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 57);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parcelas ";
            // 
            // cboSelecionar
            // 
            this.cboSelecionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelecionar.FormattingEnabled = true;
            this.cboSelecionar.Location = new System.Drawing.Point(5, 24);
            this.cboSelecionar.Name = "cboSelecionar";
            this.cboSelecionar.Size = new System.Drawing.Size(246, 21);
            this.cboSelecionar.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataInicial);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(7, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 57);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Base";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(6, 24);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(79, 20);
            this.txtDataInicial.TabIndex = 3;
            // 
            // txtIdentificacaoContrato
            // 
            this.txtIdentificacaoContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacaoContrato.Location = new System.Drawing.Point(6, 24);
            this.txtIdentificacaoContrato.Name = "txtIdentificacaoContrato";
            this.txtIdentificacaoContrato.Size = new System.Drawing.Size(149, 20);
            this.txtIdentificacaoContrato.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIdentificacaoContrato);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(103, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 57);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contrato";
            // 
            // dstLocacaoCCPagar
            // 
            this.dstLocacaoCCPagar.DataSetName = "NewDataSet";
            this.dstLocacaoCCPagar.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn24,
            this.dataColumn25,
            this.dataColumn26});
            this.dataTable1.TableName = "LocacaoCCPagar";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idlocacaoccpagar";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "idlocacaopagar";
            this.dataColumn2.DataType = typeof(short);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "idlocacaoproventos";
            this.dataColumn3.DataType = typeof(short);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "codempresa";
            this.dataColumn4.DataType = typeof(short);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "idlocador";
            this.dataColumn5.DataType = typeof(short);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "nome_locador";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "tipoprovento";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "valorlancamento";
            this.dataColumn8.DataType = typeof(decimal);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "datalancamento";
            this.dataColumn9.DataType = typeof(System.DateTime);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "datavencimento";
            this.dataColumn10.DataType = typeof(System.DateTime);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "descricao_prov";
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "nroparcela";
            this.dataColumn24.DataType = typeof(int);
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "identificacaocontrato";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "idlocacaocontrato";
            this.dataColumn26.DataType = typeof(short);
            // 
            // dstLocacaoCCReceber
            // 
            this.dstLocacaoCCReceber.DataSetName = "NewDataSet";
            this.dstLocacaoCCReceber.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable2});
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn27,
            this.dataColumn28});
            this.dataTable2.TableName = "LocacaoCCReceber";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "idlocacaoccreceber";
            this.dataColumn12.DataType = typeof(short);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "idlocacaoreceber";
            this.dataColumn13.DataType = typeof(short);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "idlocacaoproventos";
            this.dataColumn14.DataType = typeof(short);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "tipoprovento";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "datalancamento";
            this.dataColumn16.DataType = typeof(System.DateTime);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "valorlancamento";
            this.dataColumn17.DataType = typeof(decimal);
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "datavencimento";
            this.dataColumn18.DataType = typeof(System.DateTime);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "descricao_prov";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "cliente_codempresa";
            this.dataColumn20.DataType = typeof(short);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "idcliente";
            this.dataColumn21.DataType = typeof(short);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "nome_locatario";
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "nroparcela";
            this.dataColumn23.DataType = typeof(int);
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "identificacaocontrato";
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "idlocacaocontrato";
            this.dataColumn28.DataType = typeof(short);
            // 
            // rptLocador
            // 
            this.rptLocador.ReportResourceString = resources.GetString("rptLocador.ReportResourceString");
            this.rptLocador.RegisterData(this.dstLocacaoCCPagar, "dstLocacaoCCPagar");
            // 
            // rptLocatario
            // 
            this.rptLocatario.ReportResourceString = resources.GetString("rptLocatario.ReportResourceString");
            this.rptLocatario.RegisterData(this.dstLocacaoCCReceber, "dstLocacaoCCReceber");
            // 
            // relContratoProventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 200);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "relContratoProventos";
            this.Text = "Contrato Proventos";
            this.Load += new System.EventHandler(this.relContratoProventos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relContratoProventos_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoCCPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoCCReceber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocatario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSelecionar;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.TextBox txtIdentificacaoContrato;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Data.DataSet dstLocacaoCCPagar;
        private System.Data.DataSet dstLocacaoCCReceber;
        private FastReport.Report rptLocador;
        private FastReport.Report rptLocatario;
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
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private System.Data.DataColumn dataColumn26;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn27;
        private System.Data.DataColumn dataColumn28;
    }
}