namespace EMCImob.Relatorios
{
    partial class relParcelasVencidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relParcelasVencidas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSelecionar = new System.Windows.Forms.ComboBox();
            this.grdParcelas = new System.Windows.Forms.DataGridView();
            this.idlocacaoreceber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocacaopagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocacaocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identificacaocontrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_locatario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_locador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocatariorepresentante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocadorrepresentante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.btnBuscarParcelas = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIdLocacaoReceber = new System.Windows.Forms.TextBox();
            this.txtIdLocacaoPagar = new System.Windows.Forms.TextBox();
            this.txtIdLocatario = new System.Windows.Forms.TextBox();
            this.txtIdLocador = new System.Windows.Forms.TextBox();
            this.dstLocacaoReceber = new System.Data.DataSet();
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
            this.rptLocatario = new FastReport.Report();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dstLocacaoPagar = new System.Data.DataSet();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.rptLocador = new FastReport.Report();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.panBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParcelas)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoReceber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocatario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocador)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Controls.Add(this.txtIdLocacaoPagar);
            this.panBotoes.Controls.Add(this.txtIdLocador);
            this.panBotoes.Controls.Add(this.txtIdLocatario);
            this.panBotoes.Controls.Add(this.txtIdLocacaoReceber);
            this.panBotoes.Size = new System.Drawing.Size(693, 68);
            this.panBotoes.Controls.SetChildIndex(this.txtIdLocacaoReceber, 0);
            this.panBotoes.Controls.SetChildIndex(this.txtIdLocatario, 0);
            this.panBotoes.Controls.SetChildIndex(this.txtIdLocador, 0);
            this.panBotoes.Controls.SetChildIndex(this.txtIdLocacaoPagar, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSelecionar);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parcelas Vencidas";
            // 
            // cboSelecionar
            // 
            this.cboSelecionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelecionar.FormattingEnabled = true;
            this.cboSelecionar.Location = new System.Drawing.Point(5, 24);
            this.cboSelecionar.Name = "cboSelecionar";
            this.cboSelecionar.Size = new System.Drawing.Size(299, 21);
            this.cboSelecionar.TabIndex = 2;
            // 
            // grdParcelas
            // 
            this.grdParcelas.AllowUserToAddRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdParcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.grdParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idlocacaoreceber,
            this.idlocacaopagar,
            this.idlocacaocontrato,
            this.identificacaocontrato,
            this.nroparcela,
            this.valorparcela,
            this.datavencimento,
            this.pessoa,
            this.idcliente,
            this.idlocador,
            this.nome_locatario,
            this.nome_locador,
            this.idlocatariorepresentante,
            this.idlocadorrepresentante});
            this.grdParcelas.Location = new System.Drawing.Point(7, 141);
            this.grdParcelas.MultiSelect = false;
            this.grdParcelas.Name = "grdParcelas";
            this.grdParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdParcelas.Size = new System.Drawing.Size(693, 225);
            this.grdParcelas.TabIndex = 3;
            // 
            // idlocacaoreceber
            // 
            this.idlocacaoreceber.HeaderText = "Cód. LR";
            this.idlocacaoreceber.Name = "idlocacaoreceber";
            this.idlocacaoreceber.Visible = false;
            this.idlocacaoreceber.Width = 60;
            // 
            // idlocacaopagar
            // 
            this.idlocacaopagar.HeaderText = "cod LP";
            this.idlocacaopagar.Name = "idlocacaopagar";
            this.idlocacaopagar.Visible = false;
            // 
            // idlocacaocontrato
            // 
            this.idlocacaocontrato.HeaderText = "Cod Contrato";
            this.idlocacaocontrato.Name = "idlocacaocontrato";
            this.idlocacaocontrato.Visible = false;
            // 
            // identificacaocontrato
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.identificacaocontrato.DefaultCellStyle = dataGridViewCellStyle20;
            this.identificacaocontrato.HeaderText = "Contrato";
            this.identificacaocontrato.Name = "identificacaocontrato";
            // 
            // nroparcela
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nroparcela.DefaultCellStyle = dataGridViewCellStyle21;
            this.nroparcela.HeaderText = "Parcela";
            this.nroparcela.Name = "nroparcela";
            this.nroparcela.Width = 50;
            // 
            // valorparcela
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "C2";
            dataGridViewCellStyle22.NullValue = null;
            this.valorparcela.DefaultCellStyle = dataGridViewCellStyle22;
            this.valorparcela.HeaderText = "Valor";
            this.valorparcela.Name = "valorparcela";
            // 
            // datavencimento
            // 
            dataGridViewCellStyle23.Format = "d";
            dataGridViewCellStyle23.NullValue = null;
            this.datavencimento.DefaultCellStyle = dataGridViewCellStyle23;
            this.datavencimento.HeaderText = "Vencimento";
            this.datavencimento.Name = "datavencimento";
            // 
            // pessoa
            // 
            this.pessoa.HeaderText = "Pessoa";
            this.pessoa.Name = "pessoa";
            this.pessoa.Width = 300;
            // 
            // idcliente
            // 
            this.idcliente.HeaderText = "IdCliente";
            this.idcliente.Name = "idcliente";
            this.idcliente.Visible = false;
            // 
            // idlocador
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idlocador.DefaultCellStyle = dataGridViewCellStyle24;
            this.idlocador.HeaderText = "Cód. Locador";
            this.idlocador.Name = "idlocador";
            this.idlocador.Visible = false;
            // 
            // nome_locatario
            // 
            this.nome_locatario.HeaderText = "Locatario";
            this.nome_locatario.Name = "nome_locatario";
            this.nome_locatario.Visible = false;
            this.nome_locatario.Width = 250;
            // 
            // nome_locador
            // 
            this.nome_locador.HeaderText = "Locador";
            this.nome_locador.Name = "nome_locador";
            this.nome_locador.Visible = false;
            this.nome_locador.Width = 300;
            // 
            // idlocatariorepresentante
            // 
            this.idlocatariorepresentante.HeaderText = "LocLocatario";
            this.idlocatariorepresentante.Name = "idlocatariorepresentante";
            this.idlocatariorepresentante.Visible = false;
            // 
            // idlocadorrepresentante
            // 
            this.idlocadorrepresentante.HeaderText = "LocRepres";
            this.idlocadorrepresentante.Name = "idlocadorrepresentante";
            this.idlocadorrepresentante.Visible = false;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(6, 24);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(79, 20);
            this.txtDataInicial.TabIndex = 501;
            // 
            // btnBuscarParcelas
            // 
            this.btnBuscarParcelas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscarParcelas.Location = new System.Drawing.Point(625, 81);
            this.btnBuscarParcelas.Name = "btnBuscarParcelas";
            this.btnBuscarParcelas.Size = new System.Drawing.Size(75, 52);
            this.btnBuscarParcelas.TabIndex = 505;
            this.btnBuscarParcelas.Text = "Buscar Parcelas";
            this.btnBuscarParcelas.UseVisualStyleBackColor = true;
            this.btnBuscarParcelas.Click += new System.EventHandler(this.btnBuscarParcelas_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataInicial);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(323, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Base";
            // 
            // txtIdLocacaoReceber
            // 
            this.txtIdLocacaoReceber.Location = new System.Drawing.Point(631, 4);
            this.txtIdLocacaoReceber.Name = "txtIdLocacaoReceber";
            this.txtIdLocacaoReceber.Size = new System.Drawing.Size(49, 20);
            this.txtIdLocacaoReceber.TabIndex = 8;
            this.txtIdLocacaoReceber.Visible = false;
            // 
            // txtIdLocacaoPagar
            // 
            this.txtIdLocacaoPagar.Location = new System.Drawing.Point(631, 30);
            this.txtIdLocacaoPagar.Name = "txtIdLocacaoPagar";
            this.txtIdLocacaoPagar.Size = new System.Drawing.Size(49, 20);
            this.txtIdLocacaoPagar.TabIndex = 503;
            this.txtIdLocacaoPagar.Visible = false;
            // 
            // txtIdLocatario
            // 
            this.txtIdLocatario.Location = new System.Drawing.Point(576, 4);
            this.txtIdLocatario.Name = "txtIdLocatario";
            this.txtIdLocatario.Size = new System.Drawing.Size(49, 20);
            this.txtIdLocatario.TabIndex = 9;
            this.txtIdLocatario.Visible = false;
            // 
            // txtIdLocador
            // 
            this.txtIdLocador.Location = new System.Drawing.Point(576, 30);
            this.txtIdLocador.Name = "txtIdLocador";
            this.txtIdLocador.Size = new System.Drawing.Size(49, 20);
            this.txtIdLocador.TabIndex = 10;
            this.txtIdLocador.Visible = false;
            // 
            // dstLocacaoReceber
            // 
            this.dstLocacaoReceber.DataSetName = "NewDataSet";
            this.dstLocacaoReceber.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn10});
            this.dataTable1.TableName = "LocacaoReceber";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idlocacaoreceber";
            this.dataColumn1.DataType = typeof(short);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "datavencimento";
            this.dataColumn2.DataType = typeof(System.DateTime);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "nroparcela";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "valorparcela";
            this.dataColumn4.DataType = typeof(decimal);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "idlocacaocontrato";
            this.dataColumn5.DataType = typeof(short);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "identificacaocontrato";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "cliente_codempresa";
            this.dataColumn7.DataType = typeof(short);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "idcliente";
            this.dataColumn8.DataType = typeof(short);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "nome_locatario";
            // 
            // rptLocatario
            // 
            this.rptLocatario.ReportResourceString = resources.GetString("rptLocatario.ReportResourceString");
            this.rptLocatario.RegisterData(this.dstLocacaoReceber, "dstLocacaoReceber");
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "periodoinicio";
            this.dataColumn10.DataType = typeof(System.DateTime);
            // 
            // dstLocacaoPagar
            // 
            this.dstLocacaoPagar.DataSetName = "NewDataSet";
            this.dstLocacaoPagar.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable2});
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20});
            this.dataTable2.TableName = "LocacaoPagar";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "idlocacaopagar";
            this.dataColumn11.DataType = typeof(short);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "codempresa";
            this.dataColumn12.DataType = typeof(short);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "idlocador";
            this.dataColumn13.DataType = typeof(short);
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "nome_locador";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "datavencimento";
            this.dataColumn15.DataType = typeof(System.DateTime);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "idlocacaocontrato";
            this.dataColumn16.DataType = typeof(short);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "identificacaocontrato";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "periodoinicio";
            this.dataColumn18.DataType = typeof(System.DateTime);
            // 
            // rptLocador
            // 
            this.rptLocador.ReportResourceString = resources.GetString("rptLocador.ReportResourceString");
            this.rptLocador.RegisterData(this.dstLocacaoPagar, "dstLocacaoPagar");
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "nroparcela";
            this.dataColumn19.DataType = typeof(int);
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "valorparcela";
            this.dataColumn20.DataType = typeof(decimal);
            // 
            // relParcelasVencidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grdParcelas);
            this.Controls.Add(this.btnBuscarParcelas);
            this.Controls.Add(this.groupBox1);
            this.Name = "relParcelasVencidas";
            this.Text = "Relatório de Parcelas Vencidas";
            this.Load += new System.EventHandler(this.relParcelasVencidas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relParcelasVencidas_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnBuscarParcelas, 0);
            this.Controls.SetChildIndex(this.grdParcelas, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.panBotoes.ResumeLayout(false);
            this.panBotoes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdParcelas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoReceber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocatario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstLocacaoPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptLocador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdParcelas;
        private System.Windows.Forms.ComboBox cboSelecionar;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.Button btnBuscarParcelas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIdLocacaoReceber;
        private System.Windows.Forms.TextBox txtIdLocacaoPagar;
        private System.Windows.Forms.TextBox txtIdLocatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaoreceber;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaopagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaocontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn identificacaocontrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocador;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_locatario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_locador;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocatariorepresentante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocadorrepresentante;
        private System.Windows.Forms.TextBox txtIdLocador;
        private System.Data.DataSet dstLocacaoReceber;
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
        private FastReport.Report rptLocatario;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataSet dstLocacaoPagar;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private FastReport.Report rptLocador;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
    }
}