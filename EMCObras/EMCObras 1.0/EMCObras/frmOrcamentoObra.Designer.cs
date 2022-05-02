namespace EMCObras
{
    partial class frmOrcamentoObra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrcamentoObra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAprovaCronograma = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdSintetico = new System.Windows.Forms.RadioButton();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.rdAnalitico = new System.Windows.Forms.RadioButton();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBuscaObra = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.txtIdObra_Cronograma = new System.Windows.Forms.TextBox();
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdObra = new System.Windows.Forms.DataGridView();
            this.idobra_cronograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abreviacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_cronogramaitem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_tarefas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarefas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtainicioprevisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtafinalprevisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodiasprevisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdeprevisto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdTarefas = new System.Windows.Forms.DataGridView();
            this.codigoproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custocomponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupocomponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrunitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlrdespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpOrcamentoObra = new System.Windows.Forms.ToolTip(this.components);
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
            this.orcamentoObra = new FastReport.Report();
            this.OrcamentoObraItens = new FastReport.Report();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarefas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstOrcamentoObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orcamentoObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoObraItens)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAprovaCronograma);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 61);
            this.panel1.TabIndex = 18;
            // 
            // btnAprovaCronograma
            // 
            this.btnAprovaCronograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprovaCronograma.Image = global::EMCObras.Properties.Resources.ok_26_32x32;
            this.btnAprovaCronograma.Location = new System.Drawing.Point(1002, 0);
            this.btnAprovaCronograma.Name = "btnAprovaCronograma";
            this.btnAprovaCronograma.Size = new System.Drawing.Size(165, 58);
            this.btnAprovaCronograma.TabIndex = 47;
            this.btnAprovaCronograma.Text = "Aprova Cronograma de Obra";
            this.btnAprovaCronograma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpOrcamentoObra.SetToolTip(this.btnAprovaCronograma, "Cancela Operação [F12]");
            this.btnAprovaCronograma.UseVisualStyleBackColor = true;
            this.btnAprovaCronograma.Click += new System.EventHandler(this.btnAprovaCronograma_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdSintetico);
            this.groupBox4.Controls.Add(this.btnImprimir);
            this.groupBox4.Controls.Add(this.rdAnalitico);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(212, -1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 59);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Imprimir";
            // 
            // rdSintetico
            // 
            this.rdSintetico.AutoSize = true;
            this.rdSintetico.ForeColor = System.Drawing.Color.Black;
            this.rdSintetico.Location = new System.Drawing.Point(13, 36);
            this.rdSintetico.Name = "rdSintetico";
            this.rdSintetico.Size = new System.Drawing.Size(66, 17);
            this.rdSintetico.TabIndex = 50;
            this.rdSintetico.TabStop = true;
            this.rdSintetico.Text = "Sintético";
            this.rdSintetico.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = global::EMCObras.Properties.Resources.printer32x32;
            this.btnImprimir.Location = new System.Drawing.Point(87, 7);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(68, 53);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpOrcamentoObra.SetToolTip(this.btnImprimir, "Novo Registro [F2]");
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // rdAnalitico
            // 
            this.rdAnalitico.AutoSize = true;
            this.rdAnalitico.ForeColor = System.Drawing.Color.Black;
            this.rdAnalitico.Location = new System.Drawing.Point(13, 19);
            this.rdAnalitico.Name = "rdAnalitico";
            this.rdAnalitico.Size = new System.Drawing.Size(67, 17);
            this.rdAnalitico.TabIndex = 49;
            this.rdAnalitico.TabStop = true;
            this.rdAnalitico.Text = "Analítico";
            this.rdAnalitico.UseVisualStyleBackColor = true;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCObras.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 0);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 3;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpOrcamentoObra.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::EMCObras.Properties.Resources.binoculo_32x32;
            this.btnNovo.Location = new System.Drawing.Point(71, 0);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(68, 58);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpOrcamentoObra.SetToolTip(this.btnNovo, "Novo Registro [F2]");
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCObras.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpOrcamentoObra.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnBuscaObra);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtSituacao);
            this.panel2.Controls.Add(this.txtIdObra_Cronograma);
            this.panel2.Controls.Add(this.txtDescricaoObra);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtAbreviacao);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1176, 42);
            this.panel2.TabIndex = 19;
            // 
            // btnBuscaObra
            // 
            this.btnBuscaObra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaObra.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaObra.Location = new System.Drawing.Point(78, 14);
            this.btnBuscaObra.Name = "btnBuscaObra";
            this.btnBuscaObra.Size = new System.Drawing.Size(33, 21);
            this.btnBuscaObra.TabIndex = 88;
            this.btnBuscaObra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaObra.UseVisualStyleBackColor = true;
            this.btnBuscaObra.Click += new System.EventHandler(this.btnBuscaObra_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(562, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 87;
            this.label12.Text = "Situação";
            // 
            // txtSituacao
            // 
            this.txtSituacao.Location = new System.Drawing.Point(562, 14);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.ReadOnly = true;
            this.txtSituacao.Size = new System.Drawing.Size(96, 20);
            this.txtSituacao.TabIndex = 86;
            // 
            // txtIdObra_Cronograma
            // 
            this.txtIdObra_Cronograma.Location = new System.Drawing.Point(697, 2);
            this.txtIdObra_Cronograma.Name = "txtIdObra_Cronograma";
            this.txtIdObra_Cronograma.Size = new System.Drawing.Size(72, 20);
            this.txtIdObra_Cronograma.TabIndex = 85;
            this.txtIdObra_Cronograma.Visible = false;
            // 
            // txtDescricaoObra
            // 
            this.txtDescricaoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoObra.Location = new System.Drawing.Point(116, 15);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.Size = new System.Drawing.Size(439, 20);
            this.txtDescricaoObra.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Descrição";
            // 
            // txtAbreviacao
            // 
            this.txtAbreviacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviacao.Location = new System.Drawing.Point(5, 15);
            this.txtAbreviacao.Name = "txtAbreviacao";
            this.txtAbreviacao.Size = new System.Drawing.Size(71, 20);
            this.txtAbreviacao.TabIndex = 82;
            this.txtAbreviacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbreviacao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Código";
            // 
            // grdObra
            // 
            this.grdObra.AllowUserToAddRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdObra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_cronograma,
            this.idobra_etapa,
            this.abreviacao,
            this.obra,
            this.etapa,
            this.idobra_modulo,
            this.modulo,
            this.idobra_cronogramaitem,
            this.idobra_tarefas,
            this.tarefas,
            this.dtainicioprevisto,
            this.dtafinalprevisto,
            this.nrodiasprevisto,
            this.qtdeprevisto,
            this.valordespesa});
            this.grdObra.Location = new System.Drawing.Point(2, 112);
            this.grdObra.Name = "grdObra";
            this.grdObra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra.Size = new System.Drawing.Size(1178, 248);
            this.grdObra.TabIndex = 20;
            this.grdObra.DoubleClick += new System.EventHandler(this.grdObra_DoubleClick);
            // 
            // idobra_cronograma
            // 
            this.idobra_cronograma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idobra_cronograma.DataPropertyName = "idobra_cronograma";
            this.idobra_cronograma.HeaderText = "idobra_cronograma";
            this.idobra_cronograma.Name = "idobra_cronograma";
            this.idobra_cronograma.Visible = false;
            this.idobra_cronograma.Width = 70;
            // 
            // idobra_etapa
            // 
            this.idobra_etapa.DataPropertyName = "idobra_etapa";
            this.idobra_etapa.HeaderText = "idobra_etapa";
            this.idobra_etapa.Name = "idobra_etapa";
            this.idobra_etapa.Visible = false;
            // 
            // abreviacao
            // 
            this.abreviacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.abreviacao.DataPropertyName = "abreviacao";
            this.abreviacao.HeaderText = "Abreviação";
            this.abreviacao.Name = "abreviacao";
            this.abreviacao.Width = 80;
            // 
            // obra
            // 
            this.obra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.obra.DataPropertyName = "obra";
            this.obra.HeaderText = "Obra";
            this.obra.Name = "obra";
            this.obra.Width = 150;
            // 
            // etapa
            // 
            this.etapa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.etapa.DataPropertyName = "etapa";
            this.etapa.HeaderText = "Etapa";
            this.etapa.Name = "etapa";
            this.etapa.Width = 160;
            // 
            // idobra_modulo
            // 
            this.idobra_modulo.DataPropertyName = "idobra_modulo";
            this.idobra_modulo.HeaderText = "idobra_modulo";
            this.idobra_modulo.Name = "idobra_modulo";
            this.idobra_modulo.Visible = false;
            // 
            // modulo
            // 
            this.modulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.modulo.DataPropertyName = "modulo";
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.Width = 150;
            // 
            // idobra_cronogramaitem
            // 
            this.idobra_cronogramaitem.DataPropertyName = "idobra_cronogramaitem";
            this.idobra_cronogramaitem.HeaderText = "idobra_cronogramaitem";
            this.idobra_cronogramaitem.Name = "idobra_cronogramaitem";
            this.idobra_cronogramaitem.Visible = false;
            // 
            // idobra_tarefas
            // 
            this.idobra_tarefas.DataPropertyName = "idobra_tarefas";
            this.idobra_tarefas.HeaderText = "idobra_tarefas";
            this.idobra_tarefas.Name = "idobra_tarefas";
            this.idobra_tarefas.Visible = false;
            // 
            // tarefas
            // 
            this.tarefas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tarefas.DataPropertyName = "tarefas";
            this.tarefas.HeaderText = "Tarefa";
            this.tarefas.Name = "tarefas";
            this.tarefas.Width = 178;
            // 
            // dtainicioprevisto
            // 
            this.dtainicioprevisto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dtainicioprevisto.DataPropertyName = "dtainicioprevisto";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "d";
            dataGridViewCellStyle13.NullValue = null;
            this.dtainicioprevisto.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtainicioprevisto.HeaderText = "Dta. Início Prevista";
            this.dtainicioprevisto.Name = "dtainicioprevisto";
            this.dtainicioprevisto.ReadOnly = true;
            this.dtainicioprevisto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dtafinalprevisto
            // 
            this.dtafinalprevisto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dtafinalprevisto.DataPropertyName = "dtafinalprevisto";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "d";
            dataGridViewCellStyle14.NullValue = null;
            this.dtafinalprevisto.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtafinalprevisto.HeaderText = "Dta. Final Prevista";
            this.dtafinalprevisto.Name = "dtafinalprevisto";
            // 
            // nrodiasprevisto
            // 
            this.nrodiasprevisto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nrodiasprevisto.DataPropertyName = "nrodiasprevisto";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nrodiasprevisto.DefaultCellStyle = dataGridViewCellStyle15;
            this.nrodiasprevisto.HeaderText = "Dias Previsto";
            this.nrodiasprevisto.Name = "nrodiasprevisto";
            this.nrodiasprevisto.Width = 50;
            // 
            // qtdeprevisto
            // 
            this.qtdeprevisto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.qtdeprevisto.DataPropertyName = "qtdeprevisto";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.NullValue = null;
            this.qtdeprevisto.DefaultCellStyle = dataGridViewCellStyle16;
            this.qtdeprevisto.HeaderText = "Qtde. Prevista";
            this.qtdeprevisto.Name = "qtdeprevisto";
            this.qtdeprevisto.Width = 50;
            // 
            // valordespesa
            // 
            this.valordespesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.valordespesa.DataPropertyName = "vlrdespesa";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C2";
            dataGridViewCellStyle17.NullValue = null;
            this.valordespesa.DefaultCellStyle = dataGridViewCellStyle17;
            this.valordespesa.HeaderText = "Valor Despesa";
            this.valordespesa.Name = "valordespesa";
            // 
            // grdTarefas
            // 
            this.grdTarefas.AllowUserToAddRows = false;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTarefas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle18;
            this.grdTarefas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdTarefas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTarefas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoproduto,
            this.produto,
            this.unidade,
            this.custocomponente,
            this.grupocomponente,
            this.quantidade,
            this.vlrunitario,
            this.vlrdespesa});
            this.grdTarefas.Location = new System.Drawing.Point(2, 363);
            this.grdTarefas.Name = "grdTarefas";
            this.grdTarefas.ReadOnly = true;
            this.grdTarefas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTarefas.Size = new System.Drawing.Size(1179, 255);
            this.grdTarefas.TabIndex = 21;
            // 
            // codigoproduto
            // 
            this.codigoproduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigoproduto.DataPropertyName = "codigoproduto";
            this.codigoproduto.HeaderText = "Código";
            this.codigoproduto.Name = "codigoproduto";
            this.codigoproduto.ReadOnly = true;
            this.codigoproduto.Width = 80;
            // 
            // produto
            // 
            this.produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.produto.DataPropertyName = "produto";
            this.produto.HeaderText = "Produto";
            this.produto.Name = "produto";
            this.produto.ReadOnly = true;
            this.produto.Width = 310;
            // 
            // unidade
            // 
            this.unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.unidade.DataPropertyName = "unidade";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.unidade.DefaultCellStyle = dataGridViewCellStyle19;
            this.unidade.HeaderText = "Unidade";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            this.unidade.Width = 70;
            // 
            // custocomponente
            // 
            this.custocomponente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.custocomponente.DataPropertyName = "custocomponente";
            this.custocomponente.HeaderText = "Custo Componente";
            this.custocomponente.Name = "custocomponente";
            this.custocomponente.ReadOnly = true;
            this.custocomponente.Width = 190;
            // 
            // grupocomponente
            // 
            this.grupocomponente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.grupocomponente.DataPropertyName = "grupocomponente";
            this.grupocomponente.HeaderText = "Grupo Componente";
            this.grupocomponente.Name = "grupocomponente";
            this.grupocomponente.ReadOnly = true;
            this.grupocomponente.Width = 190;
            // 
            // quantidade
            // 
            this.quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.quantidade.DataPropertyName = "quantidade";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.quantidade.DefaultCellStyle = dataGridViewCellStyle20;
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            this.quantidade.Width = 80;
            // 
            // vlrunitario
            // 
            this.vlrunitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.vlrunitario.DataPropertyName = "vlrunitario";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "C2";
            dataGridViewCellStyle21.NullValue = null;
            this.vlrunitario.DefaultCellStyle = dataGridViewCellStyle21;
            this.vlrunitario.HeaderText = "Valor Unitário";
            this.vlrunitario.Name = "vlrunitario";
            this.vlrunitario.ReadOnly = true;
            // 
            // vlrdespesa
            // 
            this.vlrdespesa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.vlrdespesa.DataPropertyName = "vlrdespesa";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "C2";
            dataGridViewCellStyle22.NullValue = null;
            this.vlrdespesa.DefaultCellStyle = dataGridViewCellStyle22;
            this.vlrdespesa.HeaderText = "Valor Despesa";
            this.vlrdespesa.Name = "vlrdespesa";
            this.vlrdespesa.ReadOnly = true;
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
            this.dataColumn22});
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
            // orcamentoObra
            // 
            this.orcamentoObra.ReportResourceString = resources.GetString("orcamentoObra.ReportResourceString");
            this.orcamentoObra.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // OrcamentoObraItens
            // 
            this.OrcamentoObraItens.ReportResourceString = resources.GetString("OrcamentoObraItens.ReportResourceString");
            this.OrcamentoObraItens.RegisterData(this.dstOrcamentoObra, "dstOrcamentoObra");
            // 
            // frmOrcamentoObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 619);
            this.Controls.Add(this.grdTarefas);
            this.Controls.Add(this.grdObra);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmOrcamentoObra";
            this.Text = "Previsão de Despesas";
            this.Load += new System.EventHandler(this.frmOrcamentoObra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrcamentoObra_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarefas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstOrcamentoObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orcamentoObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrcamentoObraItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSituacao;
        private System.Windows.Forms.TextBox txtIdObra_Cronograma;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdObra;
        private System.Windows.Forms.DataGridView grdTarefas;
        private System.Windows.Forms.ToolTip ttpOrcamentoObra;
        private System.Windows.Forms.Button btnBuscaObra;
        private System.Windows.Forms.Button btnImprimir;
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
        private FastReport.Report orcamentoObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_cronograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn obra;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_cronogramaitem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_tarefas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarefas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtainicioprevisto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtafinalprevisto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodiasprevisto;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdeprevisto;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordespesa;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private FastReport.Report OrcamentoObraItens;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdSintetico;
        private System.Windows.Forms.RadioButton rdAnalitico;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn custocomponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupocomponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrunitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlrdespesa;
        private System.Data.DataColumn dataColumn22;
        private System.Windows.Forms.Button btnAprovaCronograma;
    }
}