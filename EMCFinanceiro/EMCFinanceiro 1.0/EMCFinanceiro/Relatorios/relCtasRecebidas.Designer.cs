namespace EMCFinanceiro
{
    partial class relCtasRecebidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCtasRecebidas));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckClientes = new System.Windows.Forms.CheckBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckContaCusto = new System.Windows.Forms.CheckBox();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.txtContaCusto = new System.Windows.Forms.TextBox();
            this.btnContaCusto = new System.Windows.Forms.Button();
            this.txtIdContaCusto = new System.Windows.Forms.MaskedTextBox();
            this.dstCtasRecebidas = new System.Data.DataSet();
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
            this.todos = new FastReport.Report();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIdTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.btnTipoDocumento = new System.Windows.Forms.Button();
            this.contaCusto = new FastReport.Report();
            this.cliente = new FastReport.Report();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCtasRecebidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todos)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cliente)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(571, 68);
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
            this.groupBox2.Size = new System.Drawing.Size(571, 59);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckClientes);
            this.groupBox3.Controls.Add(this.txtIdCliente);
            this.groupBox3.Controls.Add(this.txtCliente);
            this.groupBox3.Controls.Add(this.btnCliente);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(7, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 47);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cliente";
            // 
            // ckClientes
            // 
            this.ckClientes.AutoSize = true;
            this.ckClientes.ForeColor = System.Drawing.Color.Black;
            this.ckClientes.Location = new System.Drawing.Point(459, 18);
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
            this.txtCliente.Size = new System.Drawing.Size(359, 20);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckContaCusto);
            this.groupBox1.Controls.Add(this.txtCodigoConta);
            this.groupBox1.Controls.Add(this.txtContaCusto);
            this.groupBox1.Controls.Add(this.btnContaCusto);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 47);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centro de Custo";
            // 
            // ckContaCusto
            // 
            this.ckContaCusto.AutoSize = true;
            this.ckContaCusto.ForeColor = System.Drawing.Color.Black;
            this.ckContaCusto.Location = new System.Drawing.Point(465, 20);
            this.ckContaCusto.Name = "ckContaCusto";
            this.ckContaCusto.Size = new System.Drawing.Size(106, 17);
            this.ckContaCusto.TabIndex = 42;
            this.ckContaCusto.Text = "Todos os Contas";
            this.ckContaCusto.UseVisualStyleBackColor = true;
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(7, 17);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConta.TabIndex = 3;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoConta_Validating);
            // 
            // txtContaCusto
            // 
            this.txtContaCusto.Location = new System.Drawing.Point(147, 19);
            this.txtContaCusto.Name = "txtContaCusto";
            this.txtContaCusto.ReadOnly = true;
            this.txtContaCusto.Size = new System.Drawing.Size(312, 20);
            this.txtContaCusto.TabIndex = 41;
            // 
            // btnContaCusto
            // 
            this.btnContaCusto.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnContaCusto.Location = new System.Drawing.Point(112, 17);
            this.btnContaCusto.Name = "btnContaCusto";
            this.btnContaCusto.Size = new System.Drawing.Size(29, 22);
            this.btnContaCusto.TabIndex = 40;
            this.btnContaCusto.UseVisualStyleBackColor = true;
            this.btnContaCusto.Click += new System.EventHandler(this.btnContaCusto_Click);
            // 
            // txtIdContaCusto
            // 
            this.txtIdContaCusto.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdContaCusto.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdContaCusto.Location = new System.Drawing.Point(242, 129);
            this.txtIdContaCusto.Name = "txtIdContaCusto";
            this.txtIdContaCusto.Size = new System.Drawing.Size(100, 20);
            this.txtIdContaCusto.TabIndex = 44;
            this.txtIdContaCusto.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdContaCusto.Visible = false;
            // 
            // dstCtasRecebidas
            // 
            this.dstCtasRecebidas.DataSetName = "NewDataSet";
            this.dstCtasRecebidas.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "codigoconta";
            this.dataColumn1.ColumnName = "codigoconta";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "tipolancamento";
            this.dataColumn2.ColumnName = "tipolancamento";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "nrodocumento";
            this.dataColumn3.ColumnName = "nrodocumento";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "descricao";
            this.dataColumn4.ColumnName = "descricao";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "datavencimento";
            this.dataColumn5.ColumnName = "datavencimento";
            this.dataColumn5.DataType = typeof(System.DateTime);
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "tipodocumento";
            this.dataColumn6.ColumnName = "tipodocumento";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "nroparcela";
            this.dataColumn7.ColumnName = "nroparcela";
            this.dataColumn7.DataType = typeof(long);
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "cliente";
            this.dataColumn8.ColumnName = "cliente";
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "documentobaixa";
            this.dataColumn9.ColumnName = "documentobaixa";
            // 
            // dataColumn10
            // 
            this.dataColumn10.Caption = "databaixa";
            this.dataColumn10.ColumnName = "databaixa";
            this.dataColumn10.DataType = typeof(System.DateTime);
            // 
            // dataColumn11
            // 
            this.dataColumn11.Caption = "valorbaixa";
            this.dataColumn11.ColumnName = "valorbaixa";
            this.dataColumn11.DataType = typeof(decimal);
            // 
            // dataColumn12
            // 
            this.dataColumn12.Caption = "valorjuros";
            this.dataColumn12.ColumnName = "valorjuros";
            this.dataColumn12.DataType = typeof(double);
            // 
            // dataColumn13
            // 
            this.dataColumn13.Caption = "valordesconto";
            this.dataColumn13.ColumnName = "valordesconto";
            this.dataColumn13.DataType = typeof(decimal);
            // 
            // dataColumn14
            // 
            this.dataColumn14.Caption = "historicobaixa";
            this.dataColumn14.ColumnName = "historicobaixa";
            // 
            // dataColumn15
            // 
            this.dataColumn15.Caption = "valordocumento";
            this.dataColumn15.ColumnName = "valordocumento";
            this.dataColumn15.DataType = typeof(decimal);
            // 
            // dataColumn16
            // 
            this.dataColumn16.Caption = "nroparcelas";
            this.dataColumn16.ColumnName = "nroparcelas";
            this.dataColumn16.DataType = typeof(long);
            // 
            // dataColumn17
            // 
            this.dataColumn17.Caption = "valorparcela";
            this.dataColumn17.ColumnName = "valorparcela";
            this.dataColumn17.DataType = typeof(decimal);
            // 
            // todos
            // 
            this.todos.ReportResourceString = resources.GetString("todos.ReportResourceString");
            this.todos.RegisterData(this.dstCtasRecebidas, "dstCtasRecebidas");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIdTipoDocumento);
            this.groupBox4.Controls.Add(this.txtTipoDocumento);
            this.groupBox4.Controls.Add(this.btnTipoDocumento);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(7, 252);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(571, 47);
            this.groupBox4.TabIndex = 45;
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
            this.txtTipoDocumento.Size = new System.Drawing.Size(468, 20);
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
            // contaCusto
            // 
            this.contaCusto.ReportResourceString = resources.GetString("contaCusto.ReportResourceString");
            this.contaCusto.RegisterData(this.dstCtasRecebidas, "dstCtasRecebidas");
            // 
            // cliente
            // 
            this.cliente.ReportResourceString = resources.GetString("cliente.ReportResourceString");
            this.cliente.RegisterData(this.dstCtasRecebidas, "dstCtasRecebidas");
            // 
            // relCtasRecebidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(587, 321);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txtIdContaCusto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "relCtasRecebidas";
            this.Text = "Relatório - Títulos Recebidos";
            this.Load += new System.EventHandler(this.relCtasRecebidas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relCtasRecebidas_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.txtIdContaCusto, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstCtasRecebidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtaInicial;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckClientes;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckContaCusto;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;
        private System.Windows.Forms.TextBox txtContaCusto;
        private System.Windows.Forms.Button btnContaCusto;
        private System.Windows.Forms.MaskedTextBox txtIdContaCusto;
        private System.Data.DataSet dstCtasRecebidas;
        private FastReport.Report todos;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIdTipoDocumento;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Button btnTipoDocumento;
        private FastReport.Report contaCusto;
        private FastReport.Report cliente;
    }
}
