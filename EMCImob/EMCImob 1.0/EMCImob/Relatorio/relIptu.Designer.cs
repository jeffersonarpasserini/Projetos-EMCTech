namespace EMCImob.Relatorios
{
    partial class relIptu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relIptu));
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRelatorio = new System.Windows.Forms.ComboBox();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.chkImovel = new System.Windows.Forms.CheckBox();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.txtAnoBase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdIptu = new System.Windows.Forms.TextBox();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.dstIptu = new System.Data.DataSet();
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
            this.dataTable2 = new System.Data.DataTable();
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
            this.rptIptuAnoBase = new FastReport.Report();
            this.rptIptu = new FastReport.Report();
            this.panBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstIptu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptIptuAnoBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptIptu)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.txtIdIptu);
            this.panBotoes.Controls.Add(this.txtIdImovel);
            this.panBotoes.Size = new System.Drawing.Size(468, 68);
            this.panBotoes.Controls.SetChildIndex(this.txtIdImovel, 0);
            this.panBotoes.Controls.SetChildIndex(this.txtIdIptu, 0);
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(7, 151);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(71, 20);
            this.txtCodigoImovel.TabIndex = 509;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(79, 150);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 508;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 507;
            this.label2.Text = "Imóvel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboRelatorio);
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataInicial);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(5, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 49);
            this.groupBox1.TabIndex = 506;
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
            this.txtDataFinal.Location = new System.Drawing.Point(385, 24);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(79, 20);
            this.txtDataFinal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(302, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 500;
            this.label3.Text = "Vencimento";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(304, 24);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(79, 20);
            this.txtDataInicial.TabIndex = 2;
            // 
            // chkImovel
            // 
            this.chkImovel.AutoSize = true;
            this.chkImovel.Checked = true;
            this.chkImovel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImovel.ForeColor = System.Drawing.Color.Black;
            this.chkImovel.Location = new System.Drawing.Point(216, 131);
            this.chkImovel.Name = "chkImovel";
            this.chkImovel.Size = new System.Drawing.Size(109, 17);
            this.chkImovel.TabIndex = 505;
            this.chkImovel.Text = "Todos os Imóveis";
            this.chkImovel.UseVisualStyleBackColor = true;
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(110, 151);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(215, 20);
            this.txtImovel.TabIndex = 504;
            // 
            // txtAnoBase
            // 
            this.txtAnoBase.Location = new System.Drawing.Point(369, 151);
            this.txtAnoBase.Name = "txtAnoBase";
            this.txtAnoBase.Size = new System.Drawing.Size(100, 20);
            this.txtAnoBase.TabIndex = 510;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(368, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 511;
            this.label1.Text = "Ano Base";
            // 
            // txtIdIptu
            // 
            this.txtIdIptu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdIptu.Location = new System.Drawing.Point(420, 5);
            this.txtIdIptu.MaxLength = 50;
            this.txtIdIptu.Name = "txtIdIptu";
            this.txtIdIptu.Size = new System.Drawing.Size(41, 20);
            this.txtIdIptu.TabIndex = 505;
            this.txtIdIptu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdIptu.Visible = false;
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(354, 5);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdImovel.TabIndex = 504;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // dstIptu
            // 
            this.dstIptu.DataSetName = "NewDataSet";
            this.dstIptu.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "Imovel", "Iptu", new string[] {
                        "idImovel"}, new string[] {
                        "idimovel"}, false)});
            this.dstIptu.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2});
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
            this.dataColumn12});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation1", "Imovel", new string[] {
                        "idImovel"}, new string[] {
                        "idimovel"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable1.TableName = "Iptu";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idIptu";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "idimovel";
            this.dataColumn2.DataType = typeof(short);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "nroparcela";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "datavencimento";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "valorparcela";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "observacao";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "pagoimobiliaria";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "tipoacerto";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "situacao";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "anobase";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "idusuarioexclusao";
            this.dataColumn11.DataType = typeof(short);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "dataexclusao";
            this.dataColumn12.DataType = typeof(System.DateTime);
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
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
            this.dataColumn28});
            this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idImovel"}, false)});
            this.dataTable2.TableName = "Imovel";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "idImovel";
            this.dataColumn13.DataType = typeof(short);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "tipoimovel";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "rua";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "numero";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "complemento";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "nrocep";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "bairro";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "cidade";
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "estado";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "valorvenda";
            this.dataColumn22.DataType = typeof(decimal);
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "valoraluguel";
            this.dataColumn23.DataType = typeof(decimal);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "valorcondominio";
            this.dataColumn24.DataType = typeof(decimal);
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "situacao";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "idproprietario";
            this.dataColumn26.DataType = typeof(short);
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "nomeproprietario";
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "codigoimovel";
            // 
            // rptIptuAnoBase
            // 
            this.rptIptuAnoBase.ReportResourceString = resources.GetString("rptIptuAnoBase.ReportResourceString");
            this.rptIptuAnoBase.RegisterData(this.dstIptu, "dstIptu");
            // 
            // rptIptu
            // 
            this.rptIptu.ReportResourceString = resources.GetString("rptIptu.ReportResourceString");
            this.rptIptu.RegisterData(this.dstIptu, "dstIptu");
            // 
            // relIptu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 178);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnoBase);
            this.Controls.Add(this.txtCodigoImovel);
            this.Controls.Add(this.btnImovel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkImovel);
            this.Controls.Add(this.txtImovel);
            this.Name = "relIptu";
            this.Text = "relIptu";
            this.Load += new System.EventHandler(this.relIptu_Load);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.txtImovel, 0);
            this.Controls.SetChildIndex(this.chkImovel, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnImovel, 0);
            this.Controls.SetChildIndex(this.txtCodigoImovel, 0);
            this.Controls.SetChildIndex(this.txtAnoBase, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstIptu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptIptuAnoBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptIptu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRelatorio;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private System.Windows.Forms.Label label3;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.CheckBox chkImovel;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.TextBox txtAnoBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdIptu;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Data.DataSet dstIptu;
        private System.Data.DataTable dataTable1;
        private System.Data.DataTable dataTable2;
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
        private FastReport.Report rptIptuAnoBase;
        private FastReport.Report rptIptu;
        private System.Data.DataColumn dataColumn28;
    }
}