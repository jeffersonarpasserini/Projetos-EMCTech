namespace EMCImob.Relatorios
{
    partial class relExtratoContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relExtratoContrato));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIdLocacaoContrato = new System.Windows.Forms.TextBox();
            this.txtIdentificacaoContrato = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdLocatarioRepresentante = new System.Windows.Forms.TextBox();
            this.btnLocatario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeLocatario = new System.Windows.Forms.TextBox();
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dstExtratoContrato = new System.Data.DataSet();
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
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.rptExtrato = new FastReport.Report();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstExtratoContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptExtrato)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(471, 68);
            this.panBotoes.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIdLocacaoContrato);
            this.groupBox3.Controls.Add(this.txtIdentificacaoContrato);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(7, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 54);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contrato";
            // 
            // txtIdLocacaoContrato
            // 
            this.txtIdLocacaoContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdLocacaoContrato.Location = new System.Drawing.Point(99, 2);
            this.txtIdLocacaoContrato.MaxLength = 50;
            this.txtIdLocacaoContrato.Name = "txtIdLocacaoContrato";
            this.txtIdLocacaoContrato.Size = new System.Drawing.Size(44, 20);
            this.txtIdLocacaoContrato.TabIndex = 619;
            this.txtIdLocacaoContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdLocacaoContrato.Visible = false;
            // 
            // txtIdentificacaoContrato
            // 
            this.txtIdentificacaoContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacaoContrato.Location = new System.Drawing.Point(6, 24);
            this.txtIdentificacaoContrato.Name = "txtIdentificacaoContrato";
            this.txtIdentificacaoContrato.Size = new System.Drawing.Size(149, 20);
            this.txtIdentificacaoContrato.TabIndex = 1;
            this.txtIdentificacaoContrato.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdentificacaoContrato_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDataFinal);
            this.groupBox2.Controls.Add(this.txtDataInicial);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(174, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 56);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(88, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "De";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(91, 31);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(79, 20);
            this.txtDataFinal.TabIndex = 3;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(6, 31);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(79, 20);
            this.txtDataInicial.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIdLocatarioRepresentante);
            this.panel1.Controls.Add(this.btnLocatario);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNomeLocatario);
            this.panel1.Controls.Add(this.txtCodigoImovel);
            this.panel1.Controls.Add(this.btnImovel);
            this.panel1.Controls.Add(this.txtIdImovel);
            this.panel1.Controls.Add(this.txtImovel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 87);
            this.panel1.TabIndex = 16;
            // 
            // txtIdLocatarioRepresentante
            // 
            this.txtIdLocatarioRepresentante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdLocatarioRepresentante.Location = new System.Drawing.Point(6, 17);
            this.txtIdLocatarioRepresentante.MaxLength = 50;
            this.txtIdLocatarioRepresentante.Name = "txtIdLocatarioRepresentante";
            this.txtIdLocatarioRepresentante.Size = new System.Drawing.Size(44, 20);
            this.txtIdLocatarioRepresentante.TabIndex = 4;
            this.txtIdLocatarioRepresentante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdLocatarioRepresentante.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdLocatarioRepresentante_Validating);
            // 
            // btnLocatario
            // 
            this.btnLocatario.Image = ((System.Drawing.Image)(resources.GetObject("btnLocatario.Image")));
            this.btnLocatario.Location = new System.Drawing.Point(51, 15);
            this.btnLocatario.Name = "btnLocatario";
            this.btnLocatario.Size = new System.Drawing.Size(30, 25);
            this.btnLocatario.TabIndex = 5;
            this.btnLocatario.UseVisualStyleBackColor = true;
            this.btnLocatario.Click += new System.EventHandler(this.btnLocatario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 618;
            this.label4.Text = "Locatário";
            // 
            // txtNomeLocatario
            // 
            this.txtNomeLocatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeLocatario.Enabled = false;
            this.txtNomeLocatario.Location = new System.Drawing.Point(82, 17);
            this.txtNomeLocatario.MaxLength = 50;
            this.txtNomeLocatario.Name = "txtNomeLocatario";
            this.txtNomeLocatario.Size = new System.Drawing.Size(380, 20);
            this.txtNomeLocatario.TabIndex = 6;
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(5, 56);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(128, 20);
            this.txtCodigoImovel.TabIndex = 7;
            this.txtCodigoImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(133, 54);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 25);
            this.btnImovel.TabIndex = 8;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(83, 41);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(44, 20);
            this.txtIdImovel.TabIndex = 614;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Enabled = false;
            this.txtImovel.Location = new System.Drawing.Point(163, 57);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(298, 20);
            this.txtImovel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 613;
            this.label3.Text = "Imóvel";
            // 
            // dstExtratoContrato
            // 
            this.dstExtratoContrato.DataSetName = "NewDataSet";
            this.dstExtratoContrato.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21});
            this.dataTable1.TableName = "LocacaoContrato";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idlocacaocontrato";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "cliente_codempresa";
            this.dataColumn2.DataType = typeof(short);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "idcliente";
            this.dataColumn3.DataType = typeof(short);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "codempresa_locador";
            this.dataColumn4.DataType = typeof(short);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "idlocador";
            this.dataColumn5.DataType = typeof(short);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "nome_locatario";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "nome_locador";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "identificacaocontrato";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "idimovel";
            this.dataColumn9.DataType = typeof(short);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "tipoimovel";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "rua";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "numero";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "nroparcelas";
            this.dataColumn15.DataType = typeof(int);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "taxaadministracao";
            this.dataColumn16.DataType = typeof(decimal);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "valordescontoconcedido";
            this.dataColumn17.DataType = typeof(decimal);
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "valormensal";
            this.dataColumn18.DataType = typeof(decimal);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "periodoinicio";
            this.dataColumn19.DataType = typeof(System.DateTime);
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "periodofim";
            this.dataColumn20.DataType = typeof(System.DateTime);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "nroparcela";
            this.dataColumn21.DataType = typeof(int);
            // 
            // rptExtrato
            // 
            this.rptExtrato.ReportResourceString = resources.GetString("rptExtrato.ReportResourceString");
            this.rptExtrato.RegisterData(this.dstExtratoContrato, "dstExtratoContrato");
            // 
            // relExtratoContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 232);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "relExtratoContrato";
            this.Text = "Extrato Contrato";
            this.Load += new System.EventHandler(this.relExtratoContrato_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relExtratoContrato_KeyDown);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstExtratoContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptExtrato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIdentificacaoContrato;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdLocatarioRepresentante;
        private System.Windows.Forms.Button btnLocatario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomeLocatario;
        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdLocacaoContrato;
        private System.Data.DataSet dstExtratoContrato;
        private FastReport.Report rptExtrato;
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
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;


    }
}