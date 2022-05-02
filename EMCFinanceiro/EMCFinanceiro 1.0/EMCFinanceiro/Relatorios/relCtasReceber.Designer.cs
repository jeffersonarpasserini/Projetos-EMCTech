namespace EMCFinanceiro
{
    partial class relCtasReceber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCtasReceber));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
            this.dstCtasReceber = new System.Data.DataSet();
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
            this.report1 = new FastReport.Report();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckatevencimento = new System.Windows.Forms.CheckBox();
            this.ckdatavencimento = new System.Windows.Forms.CheckBox();
            this.txtDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckSintetico = new System.Windows.Forms.CheckBox();
            this.ckClientes = new System.Windows.Forms.CheckBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.report2 = new FastReport.Report();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIdTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.btnTipoDocumento = new System.Windows.Forms.Button();
            this.report3 = new FastReport.Report();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.dataColumn15 = new System.Data.DataColumn();
            this.panBotoes.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCtasReceber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report3)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.chkPDF);
            this.panBotoes.Size = new System.Drawing.Size(562, 68);
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
            // dstCtasReceber
            // 
            this.dstCtasReceber.DataSetName = "NewDataSet";
            this.dstCtasReceber.Tables.AddRange(new System.Data.DataTable[] {
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
            // dataColumn4
            // 
            this.dataColumn4.Caption = "nroparcelasdocumento";
            this.dataColumn4.ColumnName = "nroparcelasdocumento";
            this.dataColumn4.DataType = typeof(long);
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "nroparcela";
            this.dataColumn5.ColumnName = "nroparcela";
            this.dataColumn5.DataType = typeof(long);
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "datavencimentodoparcela";
            this.dataColumn6.ColumnName = "datavencimentoparcela";
            this.dataColumn6.DataType = typeof(System.DateTime);
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "tipodocumento";
            this.dataColumn7.ColumnName = "tipodocumento";
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "valorparcela";
            this.dataColumn8.ColumnName = "valorparcela";
            this.dataColumn8.DataType = typeof(decimal);
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "saldopago";
            this.dataColumn9.ColumnName = "saldopago";
            this.dataColumn9.DataType = typeof(decimal);
            // 
            // dataColumn10
            // 
            this.dataColumn10.Caption = "saldopagar";
            this.dataColumn10.ColumnName = "saldopagar";
            this.dataColumn10.DataType = typeof(decimal);
            // 
            // dataColumn11
            // 
            this.dataColumn11.Caption = "situacaoparcela";
            this.dataColumn11.ColumnName = "situacaoparcela";
            // 
            // dataColumn12
            // 
            this.dataColumn12.Caption = "cliente";
            this.dataColumn12.ColumnName = "cliente";
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
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            this.report1.RegisterData(this.dstCtasReceber, "dstCtasReceber");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckatevencimento);
            this.groupBox1.Controls.Add(this.ckdatavencimento);
            this.groupBox1.Controls.Add(this.txtDataVencimento);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(228, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 59);
            this.groupBox1.TabIndex = 6;
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
            this.groupBox3.Controls.Add(this.ckClientes);
            this.groupBox3.Controls.Add(this.txtIdCliente);
            this.groupBox3.Controls.Add(this.txtCliente);
            this.groupBox3.Controls.Add(this.btnCliente);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(7, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(562, 47);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // ckSintetico
            // 
            this.ckSintetico.AutoSize = true;
            this.ckSintetico.ForeColor = System.Drawing.Color.Black;
            this.ckSintetico.Location = new System.Drawing.Point(489, 22);
            this.ckSintetico.Name = "ckSintetico";
            this.ckSintetico.Size = new System.Drawing.Size(67, 17);
            this.ckSintetico.TabIndex = 43;
            this.ckSintetico.Text = "Sintético";
            this.ckSintetico.UseVisualStyleBackColor = true;
            // 
            // ckClientes
            // 
            this.ckClientes.AutoSize = true;
            this.ckClientes.ForeColor = System.Drawing.Color.Black;
            this.ckClientes.Location = new System.Drawing.Point(381, 21);
            this.ckClientes.Name = "ckClientes";
            this.ckClientes.Size = new System.Drawing.Size(110, 17);
            this.ckClientes.TabIndex = 42;
            this.ckClientes.Text = "Todos os Clientes";
            this.ckClientes.UseVisualStyleBackColor = true;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(6, 19);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdCliente.Size = new System.Drawing.Size(56, 20);
            this.txtIdCliente.TabIndex = 39;
            this.txtIdCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCliente_Validating);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(94, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(283, 20);
            this.txtCliente.TabIndex = 41;
            // 
            // btnCliente
            // 
            this.btnCliente.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnCliente.Location = new System.Drawing.Point(64, 18);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(29, 22);
            this.btnCliente.TabIndex = 40;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // report2
            // 
            this.report2.ReportResourceString = resources.GetString("report2.ReportResourceString");
            this.report2.RegisterData(this.dstCtasReceber, "dstCtasReceber");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIdTipoDocumento);
            this.groupBox4.Controls.Add(this.txtTipoDocumento);
            this.groupBox4.Controls.Add(this.btnTipoDocumento);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(7, 199);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(562, 47);
            this.groupBox4.TabIndex = 42;
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
            this.txtTipoDocumento.Size = new System.Drawing.Size(425, 20);
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
            // report3
            // 
            this.report3.ReportResourceString = resources.GetString("report3.ReportResourceString");
            this.report3.RegisterData(this.dstCtasReceber, "dstCtasReceber");
            // 
            // chkPDF
            // 
            this.chkPDF.AutoSize = true;
            this.chkPDF.Location = new System.Drawing.Point(469, 46);
            this.chkPDF.Name = "chkPDF";
            this.chkPDF.Size = new System.Drawing.Size(86, 17);
            this.chkPDF.TabIndex = 107;
            this.chkPDF.Text = "Exporta PDF";
            this.chkPDF.UseVisualStyleBackColor = true;
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "tipocobranca";
            // 
            // relCtasReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(574, 261);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "relCtasReceber";
            this.Text = "Relatório - Contas a Receber";
            this.Load += new System.EventHandler(this.relCtasReceber_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relCtasReceber_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCtasReceber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtaInicial;
        private System.Data.DataSet dstCtasReceber;
        private FastReport.Report report1;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckatevencimento;
        private System.Windows.Forms.CheckBox ckdatavencimento;
        private System.Windows.Forms.DateTimePicker txtDataVencimento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckClientes;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnCliente;
        private FastReport.Report report2;
        private System.Data.DataColumn dataColumn14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIdTipoDocumento;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Button btnTipoDocumento;
        private FastReport.Report report3;
        private System.Windows.Forms.CheckBox ckSintetico;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Data.DataColumn dataColumn15;
    }
}
