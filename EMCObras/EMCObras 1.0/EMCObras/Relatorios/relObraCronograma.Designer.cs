namespace EMCObras.Relatorios
{
    partial class relObraCronograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relObraCronograma));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdDtaFinal = new System.Windows.Forms.RadioButton();
            this.rdDtaInicio = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtaInicio = new System.Windows.Forms.DateTimePicker();
            this.dstObras = new System.Data.DataSet();
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
            this.obras = new FastReport.Report();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstObras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obras)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(367, 68);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdDtaFinal);
            this.groupBox2.Controls.Add(this.rdDtaInicio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboSituacao);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDtaFinal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDtaInicio);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(7, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 166);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Obras";
            // 
            // rdDtaFinal
            // 
            this.rdDtaFinal.AutoSize = true;
            this.rdDtaFinal.ForeColor = System.Drawing.Color.Black;
            this.rdDtaFinal.Location = new System.Drawing.Point(231, 48);
            this.rdDtaFinal.Name = "rdDtaFinal";
            this.rdDtaFinal.Size = new System.Drawing.Size(99, 17);
            this.rdDtaFinal.TabIndex = 107;
            this.rdDtaFinal.TabStop = true;
            this.rdDtaFinal.Text = "Data Final Obra";
            this.rdDtaFinal.UseVisualStyleBackColor = true;
            // 
            // rdDtaInicio
            // 
            this.rdDtaInicio.AutoSize = true;
            this.rdDtaInicio.ForeColor = System.Drawing.Color.Black;
            this.rdDtaInicio.Location = new System.Drawing.Point(231, 25);
            this.rdDtaInicio.Name = "rdDtaInicio";
            this.rdDtaInicio.Size = new System.Drawing.Size(104, 17);
            this.rdDtaInicio.TabIndex = 106;
            this.rdDtaInicio.TabStop = true;
            this.rdDtaInicio.Text = "Data Início Obra";
            this.rdDtaInicio.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Situação";
            // 
            // cboSituacao
            // 
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(9, 90);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(90, 21);
            this.cboSituacao.TabIndex = 104;
            this.cboSituacao.Text = "ABERTA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(109, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Até";
            // 
            // txtDtaFinal
            // 
            this.txtDtaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaFinal.Location = new System.Drawing.Point(112, 38);
            this.txtDtaFinal.Name = "txtDtaFinal";
            this.txtDtaFinal.Size = new System.Drawing.Size(99, 20);
            this.txtDtaFinal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 100;
            this.label2.Text = "De";
            // 
            // txtDtaInicio
            // 
            this.txtDtaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaInicio.Location = new System.Drawing.Point(7, 38);
            this.txtDtaInicio.Name = "txtDtaInicio";
            this.txtDtaInicio.Size = new System.Drawing.Size(99, 20);
            this.txtDtaInicio.TabIndex = 1;
            // 
            // dstObras
            // 
            this.dstObras.DataSetName = "NewDataSet";
            this.dstObras.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn18});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idobra_cronograma";
            this.dataColumn1.DataType = typeof(long);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "empresa_idEmpresa";
            this.dataColumn2.DataType = typeof(long);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "abreviacao";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "descricao";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "dtainicio";
            this.dataColumn5.DataType = typeof(System.DateTime);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "dtafinal";
            this.dataColumn6.DataType = typeof(System.DateTime);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "responsavel_idUsuario";
            this.dataColumn7.DataType = typeof(long);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "dtacronograma";
            this.dataColumn8.DataType = typeof(System.DateTime);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "dtaaprovacao";
            this.dataColumn9.DataType = typeof(System.DateTime);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "aprovador_idUsuario";
            this.dataColumn10.DataType = typeof(long);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "pessoa_CodEmpresa";
            this.dataColumn11.DataType = typeof(long);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "pessoa_idPessoa";
            this.dataColumn12.DataType = typeof(long);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "idcontacusto";
            this.dataColumn13.DataType = typeof(long);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "situacao";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "idaplicacao";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "responsavel";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "codigoconta";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "contacusto";
            // 
            // obras
            // 
            this.obras.ReportResourceString = resources.GetString("obras.ReportResourceString");
            this.obras.RegisterData(this.dstObras, "dstObras");
            // 
            // relObraCronograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(377, 249);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "relObraCronograma";
            this.Text = "Relatório - Obras";
            this.Load += new System.EventHandler(this.relObraCronograma_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relObraCronograma_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstObras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDtaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtaInicio;
        private System.Windows.Forms.Label label3;
        private System.Data.DataSet dstObras;
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
        private FastReport.Report obras;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Windows.Forms.RadioButton rdDtaFinal;
        private System.Windows.Forms.RadioButton rdDtaInicio;
    }
}
