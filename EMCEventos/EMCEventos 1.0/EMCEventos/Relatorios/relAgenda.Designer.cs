namespace EMCEventos.Relatorios
{
    partial class relAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relAgenda));
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRelatorio = new System.Windows.Forms.ComboBox();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataInicio = new MaskedDateEntryControl.MaskedDateTextBox();
            this.chkImovel = new System.Windows.Forms.CheckBox();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.txtIdAgenda = new System.Windows.Forms.TextBox();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.btnEvento = new System.Windows.Forms.Button();
            this.txtDescEvento = new System.Windows.Forms.TextBox();
            this.txtIdEvento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkEvento = new System.Windows.Forms.CheckBox();
            this.dstAgenda = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
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
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataTable3 = new System.Data.DataTable();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.rptEvento = new FastReport.Report();
            this.rptImovel = new FastReport.Report();
            this.panBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstAgenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptEvento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptImovel)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.txtIdAgenda);
            this.panBotoes.Controls.Add(this.txtIdImovel);
            this.panBotoes.Location = new System.Drawing.Point(4, 5);
            this.panBotoes.Size = new System.Drawing.Size(471, 68);
            this.panBotoes.Controls.SetChildIndex(this.txtIdImovel, 0);
            this.panBotoes.Controls.SetChildIndex(this.txtIdAgenda, 0);
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(4, 19);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(71, 20);
            this.txtCodigoImovel.TabIndex = 517;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(76, 18);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 516;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 515;
            this.label2.Text = "Imóvel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboRelatorio);
            this.groupBox1.Controls.Add(this.txtDataFinal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataInicio);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(4, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 49);
            this.groupBox1.TabIndex = 514;
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
            this.label3.Location = new System.Drawing.Point(298, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 500;
            this.label3.Text = "Data Início";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.DateValue = null;
            this.txtDataInicio.Location = new System.Drawing.Point(302, 24);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.RequireValidEntry = true;
            this.txtDataInicio.Size = new System.Drawing.Size(79, 20);
            this.txtDataInicio.TabIndex = 2;
            // 
            // chkImovel
            // 
            this.chkImovel.AutoSize = true;
            this.chkImovel.Checked = true;
            this.chkImovel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImovel.ForeColor = System.Drawing.Color.Black;
            this.chkImovel.Location = new System.Drawing.Point(358, 10);
            this.chkImovel.Name = "chkImovel";
            this.chkImovel.Size = new System.Drawing.Size(109, 17);
            this.chkImovel.TabIndex = 513;
            this.chkImovel.Text = "Todos os Imóveis";
            this.chkImovel.UseVisualStyleBackColor = true;
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(107, 19);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(215, 20);
            this.txtImovel.TabIndex = 512;
            // 
            // txtIdAgenda
            // 
            this.txtIdAgenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdAgenda.Location = new System.Drawing.Point(417, 5);
            this.txtIdAgenda.MaxLength = 50;
            this.txtIdAgenda.Name = "txtIdAgenda";
            this.txtIdAgenda.Size = new System.Drawing.Size(41, 20);
            this.txtIdAgenda.TabIndex = 507;
            this.txtIdAgenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdAgenda.Visible = false;
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(351, 5);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdImovel.TabIndex = 506;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // btnEvento
            // 
            this.btnEvento.Image = ((System.Drawing.Image)(resources.GetObject("btnEvento.Image")));
            this.btnEvento.Location = new System.Drawing.Point(54, 58);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(30, 22);
            this.btnEvento.TabIndex = 519;
            this.btnEvento.UseVisualStyleBackColor = true;
            this.btnEvento.Click += new System.EventHandler(this.btnEvento_Click);
            // 
            // txtDescEvento
            // 
            this.txtDescEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescEvento.Location = new System.Drawing.Point(85, 59);
            this.txtDescEvento.MaxLength = 50;
            this.txtDescEvento.Name = "txtDescEvento";
            this.txtDescEvento.ReadOnly = true;
            this.txtDescEvento.Size = new System.Drawing.Size(378, 20);
            this.txtDescEvento.TabIndex = 520;
            // 
            // txtIdEvento
            // 
            this.txtIdEvento.Location = new System.Drawing.Point(4, 59);
            this.txtIdEvento.Name = "txtIdEvento";
            this.txtIdEvento.Size = new System.Drawing.Size(49, 20);
            this.txtIdEvento.TabIndex = 518;
            this.txtIdEvento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEvento_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 521;
            this.label1.Text = "Evento";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkEvento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnEvento);
            this.panel1.Controls.Add(this.txtImovel);
            this.panel1.Controls.Add(this.txtDescEvento);
            this.panel1.Controls.Add(this.chkImovel);
            this.panel1.Controls.Add(this.txtIdEvento);
            this.panel1.Controls.Add(this.btnImovel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodigoImovel);
            this.panel1.Location = new System.Drawing.Point(4, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 88);
            this.panel1.TabIndex = 522;
            // 
            // chkEvento
            // 
            this.chkEvento.AutoSize = true;
            this.chkEvento.Checked = true;
            this.chkEvento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEvento.ForeColor = System.Drawing.Color.Black;
            this.chkEvento.Location = new System.Drawing.Point(358, 33);
            this.chkEvento.Name = "chkEvento";
            this.chkEvento.Size = new System.Drawing.Size(112, 17);
            this.chkEvento.TabIndex = 522;
            this.chkEvento.Text = "Todos os Eventos";
            this.chkEvento.UseVisualStyleBackColor = true;
            // 
            // dstAgenda
            // 
            this.dstAgenda.DataSetName = "NewDataSet";
            this.dstAgenda.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("Relation1", "Imovel", "Agenda", new string[] {
                        "idImovel"}, new string[] {
                        "idImovel"}, false),
            new System.Data.DataRelation("Relation2", "Evento", "Agenda", new string[] {
                        "idevt_evento"}, new string[] {
                        "idevt_evento"}, false),
            new System.Data.DataRelation("Relation3", "Imovel", "Evento", new string[] {
                        "idImovel"}, new string[] {
                        "idimovel"}, false)});
            this.dstAgenda.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.dataTable3});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn17});
            this.dataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.ForeignKeyConstraint("Relation1", "Imovel", new string[] {
                        "idImovel"}, new string[] {
                        "idImovel"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
            new System.Data.ForeignKeyConstraint("Relation2", "Evento", new string[] {
                        "idevt_evento"}, new string[] {
                        "idevt_evento"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable1.TableName = "Agenda";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idevt_agenda";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "dataagenda";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "situacao";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "idImovel";
            this.dataColumn4.DataType = typeof(short);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "idevt_evento";
            this.dataColumn5.DataType = typeof(short);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "desc_evento";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
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
            this.dataColumn18,
            this.dataColumn19});
            this.dataTable2.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idImovel"}, false)});
            this.dataTable2.TableName = "Imovel";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "idImovel";
            this.dataColumn6.DataType = typeof(short);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "codigoimovel";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "tipoimovel";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "rua";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "numero";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "complemento";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "nrocep";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "bairro";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "cidade";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "estado";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "valoraluguel";
            this.dataColumn16.DataType = typeof(decimal);
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "idproprietario";
            this.dataColumn18.DataType = typeof(short);
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "nomeproprietario";
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25});
            this.dataTable3.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "idevt_evento"}, false),
            new System.Data.ForeignKeyConstraint("Relation3", "Imovel", new string[] {
                        "idImovel"}, new string[] {
                        "idimovel"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.dataTable3.TableName = "Evento";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "idevt_evento";
            this.dataColumn20.DataType = typeof(short);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "desc_evento";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "datainicio";
            this.dataColumn22.DataType = typeof(System.DateTime);
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "datafinal";
            this.dataColumn23.DataType = typeof(System.DateTime);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "idimovel";
            this.dataColumn24.DataType = typeof(short);
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "statusevento";
            // 
            // rptEvento
            // 
            this.rptEvento.ReportResourceString = resources.GetString("rptEvento.ReportResourceString");
            this.rptEvento.RegisterData(this.dstAgenda, "dstAgenda");
            // 
            // rptImovel
            // 
            this.rptImovel.ReportResourceString = resources.GetString("rptImovel.ReportResourceString");
            this.rptImovel.RegisterData(this.dstAgenda, "dstAgenda");
            // 
            // relAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 218);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "relAgenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.relAgenda_Load);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstAgenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptEvento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptImovel)).EndInit();
            this.ResumeLayout(false);

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
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicio;
        private System.Windows.Forms.CheckBox chkImovel;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.TextBox txtIdAgenda;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.TextBox txtDescEvento;
        private System.Windows.Forms.TextBox txtIdEvento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkEvento;
        private System.Data.DataSet dstAgenda;
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
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private FastReport.Report rptEvento;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataTable dataTable3;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private FastReport.Report rptImovel;
    }
}