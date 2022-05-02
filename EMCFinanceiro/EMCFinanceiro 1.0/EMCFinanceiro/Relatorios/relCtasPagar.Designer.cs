namespace EMCFinanceiro
{
    partial class relCtasPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCtasPagar));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
            this.dstCtasPagar = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.report1 = new FastReport.Report();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckatevencimento = new System.Windows.Forms.CheckBox();
            this.ckdatavencimento = new System.Windows.Forms.CheckBox();
            this.txtDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckSintetico = new System.Windows.Forms.CheckBox();
            this.ckFornecedores = new System.Windows.Forms.CheckBox();
            this.txtIdFornecedor = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIdTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.btnTipoDocumento = new System.Windows.Forms.Button();
            this.report2 = new FastReport.Report();
            this.report3 = new FastReport.Report();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.panBotoes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCtasPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report3)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.chkPDF);
            this.panBotoes.Size = new System.Drawing.Size(589, 68);
            this.panBotoes.Controls.SetChildIndex(this.chkPDF, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDtaFinal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDtaInicial);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(6, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 59);
            this.groupBox2.TabIndex = 4;
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
            // dstCtasPagar
            // 
            this.dstCtasPagar.DataSetName = "NewDataSet";
            this.dstCtasPagar.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn4,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "nrodocumento";
            this.dataColumn1.ColumnName = "nrodocumento";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "dataentradadocumento";
            this.dataColumn2.ColumnName = "dataentradadocumento";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "descricaodocumento";
            this.dataColumn3.ColumnName = "descricaodocumento";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "datavencimentoparcela";
            this.dataColumn5.ColumnName = "datavencimentoparcela";
            this.dataColumn5.DataType = typeof(System.DateTime);
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "tipodocumento";
            this.dataColumn6.ColumnName = "tipodocumento";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "valorparcela";
            this.dataColumn7.ColumnName = "valorparcela";
            this.dataColumn7.DataType = typeof(decimal);
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "saldopago";
            this.dataColumn8.ColumnName = "saldopago";
            this.dataColumn8.DataType = typeof(decimal);
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "saldopagar";
            this.dataColumn9.ColumnName = "saldopagar";
            this.dataColumn9.DataType = typeof(decimal);
            // 
            // dataColumn10
            // 
            this.dataColumn10.Caption = "situacaoparcela";
            this.dataColumn10.ColumnName = "situacaoparcela";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "nroparcela";
            this.dataColumn4.ColumnName = "nroparcela";
            this.dataColumn4.DataType = typeof(long);
            // 
            // dataColumn11
            // 
            this.dataColumn11.Caption = "fornecedor";
            this.dataColumn11.ColumnName = "fornecedor";
            // 
            // dataColumn12
            // 
            this.dataColumn12.Caption = "nroparcelasdocumento";
            this.dataColumn12.ColumnName = "nroparcelasdocumento";
            this.dataColumn12.DataType = typeof(long);
            // 
            // dataColumn13
            // 
            this.dataColumn13.Caption = "valordocumento";
            this.dataColumn13.ColumnName = "valordocumento";
            this.dataColumn13.DataType = typeof(decimal);
            // 
            // dataColumn14
            // 
            this.dataColumn14.Caption = "dataemissao";
            this.dataColumn14.ColumnName = "dataemissao";
            this.dataColumn14.DataType = typeof(System.DateTime);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "tipocobranca";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            this.report1.RegisterData(this.dstCtasPagar, "dstCtasPagar");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckatevencimento);
            this.groupBox1.Controls.Add(this.ckdatavencimento);
            this.groupBox1.Controls.Add(this.txtDataVencimento);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(223, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 59);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vencimento";
            // 
            // ckatevencimento
            // 
            this.ckatevencimento.AutoSize = true;
            this.ckatevencimento.ForeColor = System.Drawing.Color.Black;
            this.ckatevencimento.Location = new System.Drawing.Point(205, 27);
            this.ckatevencimento.Name = "ckatevencimento";
            this.ckatevencimento.Size = new System.Drawing.Size(100, 17);
            this.ckatevencimento.TabIndex = 3;
            this.ckatevencimento.Text = "Até vencimento";
            this.ckatevencimento.UseVisualStyleBackColor = true;
            // 
            // ckdatavencimento
            // 
            this.ckdatavencimento.AutoSize = true;
            this.ckdatavencimento.ForeColor = System.Drawing.Color.Black;
            this.ckdatavencimento.Location = new System.Drawing.Point(108, 27);
            this.ckdatavencimento.Name = "ckdatavencimento";
            this.ckdatavencimento.Size = new System.Drawing.Size(100, 17);
            this.ckdatavencimento.TabIndex = 2;
            this.ckdatavencimento.Text = "Dia vencimento";
            this.ckdatavencimento.UseVisualStyleBackColor = true;
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataVencimento.Location = new System.Drawing.Point(6, 27);
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.Size = new System.Drawing.Size(99, 20);
            this.txtDataVencimento.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckSintetico);
            this.groupBox3.Controls.Add(this.ckFornecedores);
            this.groupBox3.Controls.Add(this.txtIdFornecedor);
            this.groupBox3.Controls.Add(this.txtFornecedor);
            this.groupBox3.Controls.Add(this.btnFornecedor);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(6, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 47);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fornecedor";
            // 
            // ckSintetico
            // 
            this.ckSintetico.AutoSize = true;
            this.ckSintetico.ForeColor = System.Drawing.Color.Black;
            this.ckSintetico.Location = new System.Drawing.Point(517, 21);
            this.ckSintetico.Name = "ckSintetico";
            this.ckSintetico.Size = new System.Drawing.Size(67, 17);
            this.ckSintetico.TabIndex = 43;
            this.ckSintetico.Text = "Sintético";
            this.ckSintetico.UseVisualStyleBackColor = true;
            // 
            // ckFornecedores
            // 
            this.ckFornecedores.AutoSize = true;
            this.ckFornecedores.ForeColor = System.Drawing.Color.Black;
            this.ckFornecedores.Location = new System.Drawing.Point(381, 21);
            this.ckFornecedores.Name = "ckFornecedores";
            this.ckFornecedores.Size = new System.Drawing.Size(138, 17);
            this.ckFornecedores.TabIndex = 42;
            this.ckFornecedores.Text = "Todos os Fornecedores";
            this.ckFornecedores.UseVisualStyleBackColor = true;
            // 
            // txtIdFornecedor
            // 
            this.txtIdFornecedor.Location = new System.Drawing.Point(6, 19);
            this.txtIdFornecedor.Name = "txtIdFornecedor";
            this.txtIdFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdFornecedor.Size = new System.Drawing.Size(56, 20);
            this.txtIdFornecedor.TabIndex = 39;
            this.txtIdFornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFornecedor_Validating);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(94, 19);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(283, 20);
            this.txtFornecedor.TabIndex = 41;
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnFornecedor.Location = new System.Drawing.Point(64, 18);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(29, 22);
            this.btnFornecedor.TabIndex = 40;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIdTipoDocumento);
            this.groupBox4.Controls.Add(this.txtTipoDocumento);
            this.groupBox4.Controls.Add(this.btnTipoDocumento);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(6, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 47);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tipo Documento";
            // 
            // txtIdTipoDocumento
            // 
            this.txtIdTipoDocumento.Location = new System.Drawing.Point(6, 17);
            this.txtIdTipoDocumento.Name = "txtIdTipoDocumento";
            this.txtIdTipoDocumento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdTipoDocumento.Size = new System.Drawing.Size(56, 20);
            this.txtIdTipoDocumento.TabIndex = 42;
            this.txtIdTipoDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdTipoDocumento_Validating);
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Location = new System.Drawing.Point(94, 17);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(489, 20);
            this.txtTipoDocumento.TabIndex = 44;
            // 
            // btnTipoDocumento
            // 
            this.btnTipoDocumento.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnTipoDocumento.Location = new System.Drawing.Point(64, 16);
            this.btnTipoDocumento.Name = "btnTipoDocumento";
            this.btnTipoDocumento.Size = new System.Drawing.Size(29, 22);
            this.btnTipoDocumento.TabIndex = 43;
            this.btnTipoDocumento.UseVisualStyleBackColor = true;
            this.btnTipoDocumento.Click += new System.EventHandler(this.btnTipoDocumento_Click);
            // 
            // report2
            // 
            this.report2.ReportResourceString = resources.GetString("report2.ReportResourceString");
            this.report2.RegisterData(this.dstCtasPagar, "dstCtasPagar");
            // 
            // report3
            // 
            this.report3.ReportResourceString = resources.GetString("report3.ReportResourceString");
            this.report3.RegisterData(this.dstCtasPagar, "dstCtasPagar");
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(495, 46);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(86, 17);
            this.chkPDF.TabIndex = 106;
            this.chkPDF.Text = "Exporta PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // relCtasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(601, 254);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "relCtasPagar";
            this.Text = "Relatório - Contas a Pagar";
            this.Load += new System.EventHandler(this.relCtasPagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relCtasPagar_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCtasPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtaInicial;
        private System.Data.DataSet dstCtasPagar;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private FastReport.Report report1;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckdatavencimento;
        private System.Windows.Forms.DateTimePicker txtDataVencimento;
        private System.Windows.Forms.CheckBox ckatevencimento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIdFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIdTipoDocumento;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Button btnTipoDocumento;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Windows.Forms.CheckBox ckFornecedores;
        private FastReport.Report report2;
        private System.Data.DataColumn dataColumn14;
        private FastReport.Report report3;
        private System.Windows.Forms.CheckBox ckSintetico;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Data.DataColumn dataColumn15;
    }
}
