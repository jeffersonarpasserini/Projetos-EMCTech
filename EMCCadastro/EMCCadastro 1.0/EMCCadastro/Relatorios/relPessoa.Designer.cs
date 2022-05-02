namespace EMCCadastro.Relatorios
{
    partial class relPessoa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relPessoa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstCategoriaPessoa = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTipoPessoa = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboOrdenar = new System.Windows.Forms.ComboBox();
            this.dstPessoa = new System.Data.DataSet();
            this.MyTable = new System.Data.DataTable();
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
            this.report1 = new FastReport.Report();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboLayout = new System.Windows.Forms.ComboBox();
            this.dstAutorizado = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.reportAutorizado = new FastReport.Report();
            this.dstReferencia = new System.Data.DataSet();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.dataColumn29 = new System.Data.DataColumn();
            this.dataColumn30 = new System.Data.DataColumn();
            this.dataColumn31 = new System.Data.DataColumn();
            this.dataColumn32 = new System.Data.DataColumn();
            this.dataColumn33 = new System.Data.DataColumn();
            this.dataColumn34 = new System.Data.DataColumn();
            this.dataColumn35 = new System.Data.DataColumn();
            this.dataColumn36 = new System.Data.DataColumn();
            this.reportReferencia = new FastReport.Report();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstPessoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstAutorizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportAutorizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstReferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportReferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(405, 68);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstCategoriaPessoa);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(224, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 163);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categoria Pessoa a Emitir";
            // 
            // lstCategoriaPessoa
            // 
            this.lstCategoriaPessoa.CheckOnClick = true;
            this.lstCategoriaPessoa.FormattingEnabled = true;
            this.lstCategoriaPessoa.Location = new System.Drawing.Point(12, 24);
            this.lstCategoriaPessoa.Name = "lstCategoriaPessoa";
            this.lstCategoriaPessoa.Size = new System.Drawing.Size(164, 124);
            this.lstCategoriaPessoa.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTipoPessoa);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(7, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo Pessoa";
            // 
            // cboTipoPessoa
            // 
            this.cboTipoPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPessoa.FormattingEnabled = true;
            this.cboTipoPessoa.Location = new System.Drawing.Point(7, 20);
            this.cboTipoPessoa.Name = "cboTipoPessoa";
            this.cboTipoPessoa.Size = new System.Drawing.Size(198, 21);
            this.cboTipoPessoa.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboOrdenar);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(7, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 51);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar";
            // 
            // cboOrdenar
            // 
            this.cboOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenar.FormattingEnabled = true;
            this.cboOrdenar.Location = new System.Drawing.Point(7, 20);
            this.cboOrdenar.Name = "cboOrdenar";
            this.cboOrdenar.Size = new System.Drawing.Size(198, 21);
            this.cboOrdenar.TabIndex = 5;
            // 
            // dstPessoa
            // 
            this.dstPessoa.DataSetName = "NewDataSet";
            this.dstPessoa.Tables.AddRange(new System.Data.DataTable[] {
            this.MyTable});
            // 
            // MyTable
            // 
            this.MyTable.Columns.AddRange(new System.Data.DataColumn[] {
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
            this.dataColumn19});
            this.MyTable.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "DescrCategoria";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Categoria";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "IdPessoa";
            this.dataColumn3.DataType = typeof(double);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Nome";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "NomeFantasia";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "CNPJCPF";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "NroRG";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "InscrEstadual";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "Endereco";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "Numero";
            this.dataColumn10.DataType = typeof(int);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "Bairro";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "Complemento";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "Cidade";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "Estado";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "IdCEP";
            this.dataColumn15.DataType = typeof(long);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "DtaNascimento";
            this.dataColumn16.DataType = typeof(System.DateTime);
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "Email";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "Site";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "TipoPessoa";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            this.report1.RegisterData(this.dstPessoa, "dstPessoa");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboLayout);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(7, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(211, 51);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Relatório a Emitir";
            // 
            // cboLayout
            // 
            this.cboLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayout.FormattingEnabled = true;
            this.cboLayout.Location = new System.Drawing.Point(7, 20);
            this.cboLayout.Name = "cboLayout";
            this.cboLayout.Size = new System.Drawing.Size(198, 21);
            this.cboLayout.TabIndex = 1;
            // 
            // dstAutorizado
            // 
            this.dstAutorizado.DataSetName = "NewDataSet";
            this.dstAutorizado.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "IdPessoa";
            this.dataColumn20.DataType = typeof(double);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "Nome";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "IdAutorizado";
            this.dataColumn22.DataType = typeof(double);
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "Autorizado";
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "Parentesco";
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "Grupo1";
            // 
            // reportAutorizado
            // 
            this.reportAutorizado.ReportResourceString = resources.GetString("reportAutorizado.ReportResourceString");
            this.reportAutorizado.RegisterData(this.dstAutorizado, "dstAutorizado");
            // 
            // dstReferencia
            // 
            this.dstReferencia.DataSetName = "NewDataSet";
            this.dstReferencia.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable2});
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn26,
            this.dataColumn27,
            this.dataColumn28,
            this.dataColumn29,
            this.dataColumn30,
            this.dataColumn31,
            this.dataColumn32,
            this.dataColumn33,
            this.dataColumn34,
            this.dataColumn35,
            this.dataColumn36});
            this.dataTable2.TableName = "MyTable";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "IdPessoa";
            this.dataColumn26.DataType = typeof(double);
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "Nome";
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "IdReferencia";
            this.dataColumn28.DataType = typeof(double);
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "TipoReferencia";
            this.dataColumn29.DataType = typeof(short);
            // 
            // dataColumn30
            // 
            this.dataColumn30.ColumnName = "Referencia";
            // 
            // dataColumn31
            // 
            this.dataColumn31.ColumnName = "Contato";
            // 
            // dataColumn32
            // 
            this.dataColumn32.ColumnName = "Telefone01";
            // 
            // dataColumn33
            // 
            this.dataColumn33.ColumnName = "Telefone02";
            // 
            // dataColumn34
            // 
            this.dataColumn34.ColumnName = "Email";
            // 
            // dataColumn35
            // 
            this.dataColumn35.ColumnName = "Grupo1";
            // 
            // dataColumn36
            // 
            this.dataColumn36.ColumnName = "Grupo2";
            // 
            // reportReferencia
            // 
            this.reportReferencia.ReportResourceString = resources.GetString("reportReferencia.ReportResourceString");
            this.reportReferencia.RegisterData(this.dstReferencia, "dstReferencia");
            // 
            // relPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 251);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "relPessoa";
            this.Text = "Relatório do Cadastro de Pessoas";
            this.Load += new System.EventHandler(this.relPessoa_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dstPessoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dstAutorizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportAutorizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstReferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportReferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox lstCategoriaPessoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTipoPessoa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboOrdenar;
        private System.Data.DataSet dstPessoa;
        private System.Data.DataTable MyTable;
        private FastReport.Report report1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboLayout;
        private System.Data.DataSet dstAutorizado;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private FastReport.Report reportAutorizado;
        private System.Data.DataSet dstReferencia;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn26;
        private System.Data.DataColumn dataColumn27;
        private System.Data.DataColumn dataColumn28;
        private System.Data.DataColumn dataColumn29;
        private System.Data.DataColumn dataColumn30;
        private System.Data.DataColumn dataColumn31;
        private System.Data.DataColumn dataColumn32;
        private System.Data.DataColumn dataColumn33;
        private System.Data.DataColumn dataColumn34;
        private System.Data.DataColumn dataColumn35;
        private System.Data.DataColumn dataColumn36;
        private FastReport.Report reportReferencia;

    }
}