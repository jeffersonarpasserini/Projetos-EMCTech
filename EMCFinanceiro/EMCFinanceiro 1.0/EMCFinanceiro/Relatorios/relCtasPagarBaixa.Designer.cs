namespace EMCFinanceiro
{
    partial class relCtasPagarBaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCtasPagarBaixa));
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFornecedor = new System.Windows.Forms.CheckBox();
            this.txtIdFornecedor = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboCtaBancaria = new System.Windows.Forms.ComboBox();
            this.chkTodasContas = new System.Windows.Forms.CheckBox();
            this.dstPagarBaixa = new System.Data.DataSet();
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
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.dataColumn29 = new System.Data.DataColumn();
            this.rptBaixas = new FastReport.Report();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboFormaPagamento = new System.Windows.Forms.ComboBox();
            this.chkFormaPagto = new System.Windows.Forms.CheckBox();
            this.panBotoes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstPagarBaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptBaixas)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.chkPDF);
            this.panBotoes.Size = new System.Drawing.Size(574, 68);
            this.panBotoes.Controls.SetChildIndex(this.chkPDF, 0);
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(475, 46);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(86, 17);
            this.chkPDF.TabIndex = 105;
            this.chkPDF.Text = "Exporta PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
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
            this.groupBox2.Size = new System.Drawing.Size(227, 59);
            this.groupBox2.TabIndex = 6;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFornecedor);
            this.groupBox1.Controls.Add(this.txtIdFornecedor);
            this.groupBox1.Controls.Add(this.txtFornecedor);
            this.groupBox1.Controls.Add(this.btnFornecedor);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(10, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 47);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fornecedor (Filtro)";
            // 
            // chkFornecedor
            // 
            this.chkFornecedor.AutoSize = true;
            this.chkFornecedor.Checked = true;
            this.chkFornecedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFornecedor.ForeColor = System.Drawing.Color.Black;
            this.chkFornecedor.Location = new System.Drawing.Point(506, 24);
            this.chkFornecedor.Name = "chkFornecedor";
            this.chkFornecedor.Size = new System.Drawing.Size(56, 17);
            this.chkFornecedor.TabIndex = 42;
            this.chkFornecedor.Text = "Todas";
            this.chkFornecedor.UseVisualStyleBackColor = true;
            // 
            // txtIdFornecedor
            // 
            this.txtIdFornecedor.Location = new System.Drawing.Point(6, 19);
            this.txtIdFornecedor.Name = "txtIdFornecedor";
            this.txtIdFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdFornecedor.Size = new System.Drawing.Size(56, 20);
            this.txtIdFornecedor.TabIndex = 4;
            this.txtIdFornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFornecedor_Validating);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(93, 19);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(406, 20);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboCtaBancaria);
            this.groupBox3.Controls.Add(this.chkTodasContas);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(240, 81);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 59);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conta Bancária (Filtro)";
            // 
            // cboCtaBancaria
            // 
            this.cboCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCtaBancaria.FormattingEnabled = true;
            this.cboCtaBancaria.Location = new System.Drawing.Point(6, 31);
            this.cboCtaBancaria.Name = "cboCtaBancaria";
            this.cboCtaBancaria.Size = new System.Drawing.Size(265, 21);
            this.cboCtaBancaria.TabIndex = 7;
            // 
            // chkTodasContas
            // 
            this.chkTodasContas.AutoSize = true;
            this.chkTodasContas.Checked = true;
            this.chkTodasContas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasContas.ForeColor = System.Drawing.Color.Black;
            this.chkTodasContas.Location = new System.Drawing.Point(276, 35);
            this.chkTodasContas.Name = "chkTodasContas";
            this.chkTodasContas.Size = new System.Drawing.Size(56, 17);
            this.chkTodasContas.TabIndex = 6;
            this.chkTodasContas.Text = "Todas";
            this.chkTodasContas.UseVisualStyleBackColor = true;
            // 
            // dstPagarBaixa
            // 
            this.dstPagarBaixa.DataSetName = "NewDataSet";
            this.dstPagarBaixa.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25,
            this.dataColumn26,
            this.dataColumn27,
            this.dataColumn28,
            this.dataColumn29});
            this.dataTable1.TableName = "baixa";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "codempresa";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "idpagarbaixa";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "idpagardocumento";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "idpagarparcelas";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "fornecedor_codempresa";
            this.dataColumn5.DataType = typeof(int);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "idfornecedor";
            this.dataColumn6.DataType = typeof(int);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "nome";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "cnpjcpf";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "idformapagamento";
            this.dataColumn9.DataType = typeof(int);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "formapagamento";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "ctabancaria_idempresa";
            this.dataColumn11.DataType = typeof(int);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "idcontacorrente";
            this.dataColumn12.DataType = typeof(int);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "nrodocumento";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "dataentrada";
            this.dataColumn14.DataType = typeof(System.DateTime);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "nroparcela";
            this.dataColumn15.DataType = typeof(int);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "valordocumento";
            this.dataColumn16.DataType = typeof(decimal);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "valorparcela";
            this.dataColumn17.DataType = typeof(decimal);
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "datavencimento";
            this.dataColumn18.DataType = typeof(System.DateTime);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "datapagamento";
            this.dataColumn19.DataType = typeof(System.DateTime);
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "valorbaixa";
            this.dataColumn20.DataType = typeof(decimal);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "jurosbaixa";
            this.dataColumn21.DataType = typeof(decimal);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "descontobaixa";
            this.dataColumn22.DataType = typeof(decimal);
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "valorpagamento";
            this.dataColumn23.DataType = typeof(decimal);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "idchequeemitir";
            this.dataColumn24.DataType = typeof(int);
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "nrocheque";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "valorcheque";
            this.dataColumn26.DataType = typeof(decimal);
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "datacheque";
            this.dataColumn27.DataType = typeof(System.DateTime);
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "nominal";
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "descricaoconta";
            // 
            // rptBaixas
            // 
            this.rptBaixas.ReportResourceString = resources.GetString("rptBaixas.ReportResourceString");
            this.rptBaixas.RegisterData(this.dstPagarBaixa, "dstPagarBaixa");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboFormaPagamento);
            this.groupBox4.Controls.Add(this.chkFormaPagto);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(10, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 59);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Forma Pagamento (Filtro)";
            // 
            // cboFormaPagamento
            // 
            this.cboFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaPagamento.FormattingEnabled = true;
            this.cboFormaPagamento.Location = new System.Drawing.Point(6, 31);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Size = new System.Drawing.Size(265, 21);
            this.cboFormaPagamento.TabIndex = 7;
            // 
            // chkFormaPagto
            // 
            this.chkFormaPagto.AutoSize = true;
            this.chkFormaPagto.Checked = true;
            this.chkFormaPagto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormaPagto.ForeColor = System.Drawing.Color.Black;
            this.chkFormaPagto.Location = new System.Drawing.Point(276, 35);
            this.chkFormaPagto.Name = "chkFormaPagto";
            this.chkFormaPagto.Size = new System.Drawing.Size(56, 17);
            this.chkFormaPagto.TabIndex = 6;
            this.chkFormaPagto.Text = "Todas";
            this.chkFormaPagto.UseVisualStyleBackColor = true;
            // 
            // relCtasPagarBaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(584, 260);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "relCtasPagarBaixa";
            this.Text = "Baixas Contas a Pagar";
            this.Load += new System.EventHandler(this.relCtasPagarBaixa_Load);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstPagarBaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptBaixas)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPDF;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtaInicial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboCtaBancaria;
        private System.Windows.Forms.CheckBox chkTodasContas;
        private System.Windows.Forms.CheckBox chkFornecedor;
        private System.Data.DataSet dstPagarBaixa;
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
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private System.Data.DataColumn dataColumn26;
        private System.Data.DataColumn dataColumn27;
        private System.Data.DataColumn dataColumn28;
        private FastReport.Report rptBaixas;
        private System.Data.DataColumn dataColumn29;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboFormaPagamento;
        private System.Windows.Forms.CheckBox chkFormaPagto;
    }
}
