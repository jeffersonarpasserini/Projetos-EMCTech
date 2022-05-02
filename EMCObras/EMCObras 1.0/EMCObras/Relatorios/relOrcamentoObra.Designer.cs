namespace EMCObras.Relatorios
{
    partial class relOrcamentoObra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relOrcamentoObra));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoTarefa = new System.Windows.Forms.TextBox();
            this.txtidObra_Tarefas = new System.Windows.Forms.TextBox();
            this.btnBuscaTarefa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdObra_Cronograma = new System.Windows.Forms.TextBox();
            this.btnBuscaObra = new System.Windows.Forms.Button();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoModulo = new System.Windows.Forms.TextBox();
            this.txtidObra_Modulo = new System.Windows.Forms.TextBox();
            this.btnBuscaModulo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescricaoEtapa = new System.Windows.Forms.TextBox();
            this.txtidObra_Etapa = new System.Windows.Forms.TextBox();
            this.btnBuscaEtapa = new System.Windows.Forms.Button();
            this.rdSintetico = new System.Windows.Forms.RadioButton();
            this.rdAnalitico = new System.Windows.Forms.RadioButton();
            this.dstOrcamentoObra = new System.Data.DataSet();
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
            this.OrcamentoObra = new FastReport.Report();
            this.OrcamentoObraItens = new FastReport.Report();
            this.SinteticoObraEtapa = new FastReport.Report();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.AnaliticoObraEtapa = new FastReport.Report();
            this.SinteticoObraEtapaModulo = new FastReport.Report();
            this.AnaliticoObraEtapaModulo = new FastReport.Report();
            this.dataColumn25 = new System.Data.DataColumn();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstOrcamentoObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoObraItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinteticoObraEtapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnaliticoObraEtapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinteticoObraEtapaModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnaliticoObraEtapaModulo)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Location = new System.Drawing.Point(1, 1);
            this.panBotoes.Size = new System.Drawing.Size(644, 68);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.rdSintetico);
            this.groupBox4.Controls.Add(this.rdAnalitico);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(1, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(644, 315);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Imprimir";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDescricaoTarefa);
            this.groupBox5.Controls.Add(this.txtidObra_Tarefas);
            this.groupBox5.Controls.Add(this.btnBuscaTarefa);
            this.groupBox5.ForeColor = System.Drawing.Color.Blue;
            this.groupBox5.Location = new System.Drawing.Point(7, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(631, 60);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tarefa";
            // 
            // txtDescricaoTarefa
            // 
            this.txtDescricaoTarefa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoTarefa.Location = new System.Drawing.Point(125, 23);
            this.txtDescricaoTarefa.MaxLength = 50;
            this.txtDescricaoTarefa.Name = "txtDescricaoTarefa";
            this.txtDescricaoTarefa.Size = new System.Drawing.Size(434, 20);
            this.txtDescricaoTarefa.TabIndex = 102;
            // 
            // txtidObra_Tarefas
            // 
            this.txtidObra_Tarefas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Tarefas.Location = new System.Drawing.Point(16, 23);
            this.txtidObra_Tarefas.MaxLength = 50;
            this.txtidObra_Tarefas.Name = "txtidObra_Tarefas";
            this.txtidObra_Tarefas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Tarefas.Size = new System.Drawing.Size(71, 20);
            this.txtidObra_Tarefas.TabIndex = 101;
            this.txtidObra_Tarefas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Tarefas.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Tarefas_Validating);
            // 
            // btnBuscaTarefa
            // 
            this.btnBuscaTarefa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaTarefa.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaTarefa.Location = new System.Drawing.Point(88, 22);
            this.btnBuscaTarefa.Name = "btnBuscaTarefa";
            this.btnBuscaTarefa.Size = new System.Drawing.Size(33, 21);
            this.btnBuscaTarefa.TabIndex = 98;
            this.btnBuscaTarefa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaTarefa.UseVisualStyleBackColor = true;
            this.btnBuscaTarefa.Click += new System.EventHandler(this.btnBuscaTarefa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdObra_Cronograma);
            this.groupBox1.Controls.Add(this.btnBuscaObra);
            this.groupBox1.Controls.Add(this.txtSituacao);
            this.groupBox1.Controls.Add(this.txtDescricaoObra);
            this.groupBox1.Controls.Add(this.txtAbreviacao);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 58);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obra";
            // 
            // txtIdObra_Cronograma
            // 
            this.txtIdObra_Cronograma.Location = new System.Drawing.Point(194, 0);
            this.txtIdObra_Cronograma.Name = "txtIdObra_Cronograma";
            this.txtIdObra_Cronograma.Size = new System.Drawing.Size(72, 20);
            this.txtIdObra_Cronograma.TabIndex = 99;
            this.txtIdObra_Cronograma.Visible = false;
            // 
            // btnBuscaObra
            // 
            this.btnBuscaObra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaObra.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaObra.Location = new System.Drawing.Point(89, 17);
            this.btnBuscaObra.Name = "btnBuscaObra";
            this.btnBuscaObra.Size = new System.Drawing.Size(33, 21);
            this.btnBuscaObra.TabIndex = 98;
            this.btnBuscaObra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaObra.UseVisualStyleBackColor = true;
            this.btnBuscaObra.Click += new System.EventHandler(this.btnBuscaObra_Click);
            // 
            // txtSituacao
            // 
            this.txtSituacao.Location = new System.Drawing.Point(567, 18);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.ReadOnly = true;
            this.txtSituacao.Size = new System.Drawing.Size(58, 20);
            this.txtSituacao.TabIndex = 97;
            // 
            // txtDescricaoObra
            // 
            this.txtDescricaoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoObra.Location = new System.Drawing.Point(126, 18);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.Size = new System.Drawing.Size(433, 20);
            this.txtDescricaoObra.TabIndex = 96;
            // 
            // txtAbreviacao
            // 
            this.txtAbreviacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviacao.Location = new System.Drawing.Point(17, 18);
            this.txtAbreviacao.Name = "txtAbreviacao";
            this.txtAbreviacao.Size = new System.Drawing.Size(71, 20);
            this.txtAbreviacao.TabIndex = 90;
            this.txtAbreviacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbreviacao_Validating);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDescricaoModulo);
            this.groupBox3.Controls.Add(this.txtidObra_Modulo);
            this.groupBox3.Controls.Add(this.btnBuscaModulo);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(7, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(631, 60);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Módulo";
            // 
            // txtDescricaoModulo
            // 
            this.txtDescricaoModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoModulo.Location = new System.Drawing.Point(125, 23);
            this.txtDescricaoModulo.MaxLength = 50;
            this.txtDescricaoModulo.Name = "txtDescricaoModulo";
            this.txtDescricaoModulo.Size = new System.Drawing.Size(434, 20);
            this.txtDescricaoModulo.TabIndex = 100;
            // 
            // txtidObra_Modulo
            // 
            this.txtidObra_Modulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Modulo.Location = new System.Drawing.Point(16, 23);
            this.txtidObra_Modulo.MaxLength = 50;
            this.txtidObra_Modulo.Name = "txtidObra_Modulo";
            this.txtidObra_Modulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Modulo.Size = new System.Drawing.Size(71, 20);
            this.txtidObra_Modulo.TabIndex = 99;
            this.txtidObra_Modulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Modulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Modulo_Validating);
            // 
            // btnBuscaModulo
            // 
            this.btnBuscaModulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaModulo.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaModulo.Location = new System.Drawing.Point(88, 22);
            this.btnBuscaModulo.Name = "btnBuscaModulo";
            this.btnBuscaModulo.Size = new System.Drawing.Size(33, 21);
            this.btnBuscaModulo.TabIndex = 98;
            this.btnBuscaModulo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaModulo.UseVisualStyleBackColor = true;
            this.btnBuscaModulo.Click += new System.EventHandler(this.btnBuscaModulo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescricaoEtapa);
            this.groupBox2.Controls.Add(this.txtidObra_Etapa);
            this.groupBox2.Controls.Add(this.btnBuscaEtapa);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(7, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 60);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Etapa";
            // 
            // txtDescricaoEtapa
            // 
            this.txtDescricaoEtapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoEtapa.Location = new System.Drawing.Point(125, 23);
            this.txtDescricaoEtapa.Name = "txtDescricaoEtapa";
            this.txtDescricaoEtapa.Size = new System.Drawing.Size(434, 20);
            this.txtDescricaoEtapa.TabIndex = 100;
            // 
            // txtidObra_Etapa
            // 
            this.txtidObra_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Etapa.Location = new System.Drawing.Point(16, 23);
            this.txtidObra_Etapa.MaxLength = 50;
            this.txtidObra_Etapa.Name = "txtidObra_Etapa";
            this.txtidObra_Etapa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Etapa.Size = new System.Drawing.Size(71, 20);
            this.txtidObra_Etapa.TabIndex = 99;
            this.txtidObra_Etapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidObra_Etapa.Validating += new System.ComponentModel.CancelEventHandler(this.txtidObra_Etapa_Validating);
            // 
            // btnBuscaEtapa
            // 
            this.btnBuscaEtapa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaEtapa.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaEtapa.Location = new System.Drawing.Point(88, 22);
            this.btnBuscaEtapa.Name = "btnBuscaEtapa";
            this.btnBuscaEtapa.Size = new System.Drawing.Size(33, 21);
            this.btnBuscaEtapa.TabIndex = 98;
            this.btnBuscaEtapa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaEtapa.UseVisualStyleBackColor = true;
            this.btnBuscaEtapa.Click += new System.EventHandler(this.btnBuscaEtapa_Click);
            // 
            // rdSintetico
            // 
            this.rdSintetico.AutoSize = true;
            this.rdSintetico.ForeColor = System.Drawing.Color.Black;
            this.rdSintetico.Location = new System.Drawing.Point(123, 19);
            this.rdSintetico.Name = "rdSintetico";
            this.rdSintetico.Size = new System.Drawing.Size(66, 17);
            this.rdSintetico.TabIndex = 52;
            this.rdSintetico.TabStop = true;
            this.rdSintetico.Text = "Sintético";
            this.rdSintetico.UseVisualStyleBackColor = true;
            // 
            // rdAnalitico
            // 
            this.rdAnalitico.AutoSize = true;
            this.rdAnalitico.ForeColor = System.Drawing.Color.Black;
            this.rdAnalitico.Location = new System.Drawing.Point(50, 19);
            this.rdAnalitico.Name = "rdAnalitico";
            this.rdAnalitico.Size = new System.Drawing.Size(67, 17);
            this.rdAnalitico.TabIndex = 51;
            this.rdAnalitico.TabStop = true;
            this.rdAnalitico.Text = "Analítico";
            this.rdAnalitico.UseVisualStyleBackColor = true;
            // 
            // dstOrcamentoObra
            // 
            this.dstOrcamentoObra.DataSetName = "NewDataSet";
            this.dstOrcamentoObra.Tables.AddRange(new System.Data.DataTable[] {
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
            this.dataColumn25});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idobra_cronograma";
            this.dataColumn1.DataType = typeof(long);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "abreviacao";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "obra";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "idobra_etapa";
            this.dataColumn4.DataType = typeof(long);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "etapa";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "idobra_modulo";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "modulo";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "idobra_cronogramaitem";
            this.dataColumn8.DataType = typeof(long);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "idobra_tarefas";
            this.dataColumn9.DataType = typeof(long);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "tarefas";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "dtainicioprevisto";
            this.dataColumn11.DataType = typeof(System.DateTime);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "dtafinalprevisto";
            this.dataColumn12.DataType = typeof(System.DateTime);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "nrodiasprevisto";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "vlrdespesa";
            this.dataColumn14.DataType = typeof(decimal);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "codigoproduto";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "produto";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "unidade";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "custocomponente";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "grupocomponente";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "qtdeproduto";
            this.dataColumn20.DataType = typeof(long);
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "vlrunitario";
            this.dataColumn21.DataType = typeof(decimal);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "qtdeprevisto";
            // 
            // OrcamentoObra
            // 
            this.OrcamentoObra.ReportResourceString = resources.GetString("OrcamentoObra.ReportResourceString");
            this.OrcamentoObra.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // OrcamentoObraItens
            // 
            this.OrcamentoObraItens.ReportResourceString = resources.GetString("OrcamentoObraItens.ReportResourceString");
            this.OrcamentoObraItens.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // SinteticoObraEtapa
            // 
            this.SinteticoObraEtapa.ReportResourceString = resources.GetString("SinteticoObraEtapa.ReportResourceString");
            this.SinteticoObraEtapa.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "vlretapa";
            this.dataColumn23.DataType = typeof(decimal);
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "vlrobra";
            this.dataColumn24.DataType = typeof(decimal);
            // 
            // AnaliticoObraEtapa
            // 
            this.AnaliticoObraEtapa.ReportResourceString = resources.GetString("AnaliticoObraEtapa.ReportResourceString");
            this.AnaliticoObraEtapa.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // SinteticoObraEtapaModulo
            // 
            this.SinteticoObraEtapaModulo.ReportResourceString = resources.GetString("SinteticoObraEtapaModulo.ReportResourceString");
            this.SinteticoObraEtapaModulo.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // AnaliticoObraEtapaModulo
            // 
            this.AnaliticoObraEtapaModulo.ReportResourceString = resources.GetString("AnaliticoObraEtapaModulo.ReportResourceString");
            this.AnaliticoObraEtapaModulo.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "vlrmodulo";
            this.dataColumn25.DataType = typeof(decimal);
            // 
            // relOrcamentoObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(646, 387);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.Name = "relOrcamentoObra";
            this.Text = "Relatório - Previsão de Despesas";
            this.Load += new System.EventHandler(this.relOrcamentoObra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relOrcamentoObra_KeyDown);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstOrcamentoObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoObraItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinteticoObraEtapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnaliticoObraEtapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinteticoObraEtapaModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnaliticoObraEtapaModulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdSintetico;
        private System.Windows.Forms.RadioButton rdAnalitico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscaObra;
        private System.Windows.Forms.TextBox txtSituacao;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.TextBox txtIdObra_Cronograma;
        private System.Data.DataSet dstOrcamentoObra;
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
        private FastReport.Report OrcamentoObra;
        private FastReport.Report OrcamentoObraItens;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscaEtapa;
        private System.Windows.Forms.TextBox txtidObra_Etapa;
        private System.Windows.Forms.TextBox txtDescricaoEtapa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscaModulo;
        private System.Windows.Forms.TextBox txtidObra_Modulo;
        private System.Windows.Forms.TextBox txtDescricaoModulo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnBuscaTarefa;
        private System.Windows.Forms.TextBox txtidObra_Tarefas;
        private System.Windows.Forms.TextBox txtDescricaoTarefa;
        private FastReport.Report SinteticoObraEtapa;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private FastReport.Report AnaliticoObraEtapa;
        private FastReport.Report SinteticoObraEtapaModulo;
        private FastReport.Report AnaliticoObraEtapaModulo;
        private System.Data.DataColumn dataColumn25;
    }
}
