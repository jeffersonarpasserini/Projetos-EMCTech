namespace EMCObras
{
    partial class frmPrevisaoDespesa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSituacaoDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdObra_CronogramaItem = new System.Windows.Forms.TextBox();
            this.txtObra_Tarefa = new System.Windows.Forms.TextBox();
            this.txtIdObra_Tarefa = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdObra = new System.Windows.Forms.TextBox();
            this.btnBuscaObra = new System.Windows.Forms.Button();
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvwTarefa = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboUnidade = new System.Windows.Forms.ComboBox();
            this.txtVlrUnitario = new MaskedNumber.MaskedNumber();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustoPrevisto = new MaskedNumber.MaskedNumber();
            this.txtQtdePrevista = new MaskedNumber.MaskedNumber();
            this.txtIdUnidade = new System.Windows.Forms.TextBox();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.txtIdObra_PrevisaoDespesa = new System.Windows.Forms.TextBox();
            this.btnProduto = new System.Windows.Forms.Button();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdEstq_Produto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grdDespesa = new System.Windows.Forms.DataGridView();
            this.tarefa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_tarefa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalObra = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalTarefa = new System.Windows.Forms.Sample.DecimalTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDespesa)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSituacao);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSituacaoDesc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtIdObra_CronogramaItem);
            this.groupBox2.Controls.Add(this.txtObra_Tarefa);
            this.groupBox2.Controls.Add(this.txtIdObra_Tarefa);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(553, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 61);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarefa";
            // 
            // txtSituacao
            // 
            this.txtSituacao.Enabled = false;
            this.txtSituacao.Location = new System.Drawing.Point(387, 8);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.ReadOnly = true;
            this.txtSituacao.Size = new System.Drawing.Size(18, 22);
            this.txtSituacao.TabIndex = 90;
            this.txtSituacao.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Situação";
            // 
            // txtSituacaoDesc
            // 
            this.txtSituacaoDesc.Enabled = false;
            this.txtSituacaoDesc.Location = new System.Drawing.Point(319, 33);
            this.txtSituacaoDesc.Name = "txtSituacaoDesc";
            this.txtSituacaoDesc.ReadOnly = true;
            this.txtSituacaoDesc.Size = new System.Drawing.Size(93, 22);
            this.txtSituacaoDesc.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Tarefa";
            // 
            // txtIdObra_CronogramaItem
            // 
            this.txtIdObra_CronogramaItem.Location = new System.Drawing.Point(169, 13);
            this.txtIdObra_CronogramaItem.Name = "txtIdObra_CronogramaItem";
            this.txtIdObra_CronogramaItem.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_CronogramaItem.TabIndex = 86;
            this.txtIdObra_CronogramaItem.Visible = false;
            // 
            // txtObra_Tarefa
            // 
            this.txtObra_Tarefa.Enabled = false;
            this.txtObra_Tarefa.Location = new System.Drawing.Point(6, 33);
            this.txtObra_Tarefa.Name = "txtObra_Tarefa";
            this.txtObra_Tarefa.ReadOnly = true;
            this.txtObra_Tarefa.Size = new System.Drawing.Size(309, 22);
            this.txtObra_Tarefa.TabIndex = 83;
            // 
            // txtIdObra_Tarefa
            // 
            this.txtIdObra_Tarefa.Location = new System.Drawing.Point(63, 12);
            this.txtIdObra_Tarefa.Name = "txtIdObra_Tarefa";
            this.txtIdObra_Tarefa.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_Tarefa.TabIndex = 84;
            this.txtIdObra_Tarefa.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdObra);
            this.groupBox1.Controls.Add(this.btnBuscaObra);
            this.groupBox1.Controls.Add(this.txtDescricaoObra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAbreviacao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 61);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obra";
            // 
            // txtIdObra
            // 
            this.txtIdObra.Location = new System.Drawing.Point(228, 9);
            this.txtIdObra.Name = "txtIdObra";
            this.txtIdObra.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra.TabIndex = 87;
            this.txtIdObra.Visible = false;
            // 
            // btnBuscaObra
            // 
            this.btnBuscaObra.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaObra.Location = new System.Drawing.Point(101, 34);
            this.btnBuscaObra.Name = "btnBuscaObra";
            this.btnBuscaObra.Size = new System.Drawing.Size(31, 23);
            this.btnBuscaObra.TabIndex = 84;
            this.btnBuscaObra.UseVisualStyleBackColor = true;
            this.btnBuscaObra.Click += new System.EventHandler(this.btnBuscaObra_Click);
            // 
            // txtDescricaoObra
            // 
            this.txtDescricaoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoObra.Enabled = false;
            this.txtDescricaoObra.Location = new System.Drawing.Point(134, 34);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.ReadOnly = true;
            this.txtDescricaoObra.Size = new System.Drawing.Size(409, 22);
            this.txtDescricaoObra.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Descrição";
            // 
            // txtAbreviacao
            // 
            this.txtAbreviacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviacao.Location = new System.Drawing.Point(5, 34);
            this.txtAbreviacao.Name = "txtAbreviacao";
            this.txtAbreviacao.Size = new System.Drawing.Size(94, 22);
            this.txtAbreviacao.TabIndex = 81;
            this.txtAbreviacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbreviacao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Código";
            // 
            // tvwTarefa
            // 
            this.tvwTarefa.Location = new System.Drawing.Point(3, 136);
            this.tvwTarefa.Name = "tvwTarefa";
            this.tvwTarefa.Size = new System.Drawing.Size(272, 342);
            this.tvwTarefa.TabIndex = 7;
            this.tvwTarefa.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwTarefa_NodeMouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboUnidade);
            this.groupBox3.Controls.Add(this.txtVlrUnitario);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtCustoPrevisto);
            this.groupBox3.Controls.Add(this.txtQtdePrevista);
            this.groupBox3.Controls.Add(this.txtIdUnidade);
            this.groupBox3.Controls.Add(this.txtIdProduto);
            this.groupBox3.Controls.Add(this.txtIdObra_PrevisaoDespesa);
            this.groupBox3.Controls.Add(this.btnProduto);
            this.groupBox3.Controls.Add(this.txtDescricaoProduto);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtIdEstq_Produto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(281, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(693, 98);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Previsão - Despesa";
            // 
            // cboUnidade
            // 
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Location = new System.Drawing.Point(238, 31);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Size = new System.Drawing.Size(121, 24);
            this.cboUnidade.TabIndex = 1;
            // 
            // txtVlrUnitario
            // 
            this.txtVlrUnitario.CustomFormat = "0:0";
            this.txtVlrUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtVlrUnitario.Format = MaskedNumberFormat.Moeda;
            this.txtVlrUnitario.Location = new System.Drawing.Point(438, 34);
            this.txtVlrUnitario.Name = "txtVlrUnitario";
            this.txtVlrUnitario.Size = new System.Drawing.Size(115, 20);
            this.txtVlrUnitario.TabIndex = 3;
            this.txtVlrUnitario.Text = "R$ 0,00";
            this.txtVlrUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVlrUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustoUnitario_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(435, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 98;
            this.label11.Text = "Custo Unitário";
            // 
            // txtCustoPrevisto
            // 
            this.txtCustoPrevisto.CustomFormat = "0:0";
            this.txtCustoPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCustoPrevisto.Format = MaskedNumberFormat.Moeda;
            this.txtCustoPrevisto.Location = new System.Drawing.Point(556, 34);
            this.txtCustoPrevisto.Name = "txtCustoPrevisto";
            this.txtCustoPrevisto.Size = new System.Drawing.Size(131, 20);
            this.txtCustoPrevisto.TabIndex = 4;
            this.txtCustoPrevisto.Text = "R$ 0,00";
            this.txtCustoPrevisto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustoPrevisto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustoPrevisto_Validating);
            // 
            // txtQtdePrevista
            // 
            this.txtQtdePrevista.CustomFormat = "0:0";
            this.txtQtdePrevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtQtdePrevista.Format = MaskedNumberFormat.Peso;
            this.txtQtdePrevista.Location = new System.Drawing.Point(365, 33);
            this.txtQtdePrevista.Name = "txtQtdePrevista";
            this.txtQtdePrevista.Size = new System.Drawing.Size(70, 20);
            this.txtQtdePrevista.TabIndex = 2;
            this.txtQtdePrevista.Text = "0,000";
            this.txtQtdePrevista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdePrevista.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtdePrevista_Validating);
            // 
            // txtIdUnidade
            // 
            this.txtIdUnidade.Location = new System.Drawing.Point(275, 2);
            this.txtIdUnidade.Name = "txtIdUnidade";
            this.txtIdUnidade.Size = new System.Drawing.Size(100, 22);
            this.txtIdUnidade.TabIndex = 96;
            this.txtIdUnidade.Visible = false;
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Location = new System.Drawing.Point(381, 0);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(100, 22);
            this.txtIdProduto.TabIndex = 95;
            this.txtIdProduto.Visible = false;
            // 
            // txtIdObra_PrevisaoDespesa
            // 
            this.txtIdObra_PrevisaoDespesa.Location = new System.Drawing.Point(487, -3);
            this.txtIdObra_PrevisaoDespesa.Name = "txtIdObra_PrevisaoDespesa";
            this.txtIdObra_PrevisaoDespesa.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_PrevisaoDespesa.TabIndex = 94;
            this.txtIdObra_PrevisaoDespesa.Visible = false;
            // 
            // btnProduto
            // 
            this.btnProduto.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnProduto.Location = new System.Drawing.Point(201, 31);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(31, 25);
            this.btnProduto.TabIndex = 93;
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoProduto.Enabled = false;
            this.txtDescricaoProduto.Location = new System.Drawing.Point(6, 70);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.ReadOnly = true;
            this.txtDescricaoProduto.Size = new System.Drawing.Size(681, 22);
            this.txtDescricaoProduto.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "Descrição";
            // 
            // txtIdEstq_Produto
            // 
            this.txtIdEstq_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdEstq_Produto.Enabled = false;
            this.txtIdEstq_Produto.Location = new System.Drawing.Point(6, 32);
            this.txtIdEstq_Produto.Name = "txtIdEstq_Produto";
            this.txtIdEstq_Produto.Size = new System.Drawing.Size(192, 22);
            this.txtIdEstq_Produto.TabIndex = 0;
            this.txtIdEstq_Produto.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEstq_Produto_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(553, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Custo Previsto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(361, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Unidade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Produto";
            // 
            // grdDespesa
            // 
            this.grdDespesa.AllowUserToAddRows = false;
            this.grdDespesa.AllowUserToDeleteRows = false;
            this.grdDespesa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdDespesa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDespesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDespesa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tarefa,
            this.codigoproduto,
            this.unidade,
            this.quantidade,
            this.valordespesa,
            this.descricao,
            this.iddespesa,
            this.idproduto,
            this.idobra_tarefa});
            this.grdDespesa.Location = new System.Drawing.Point(281, 242);
            this.grdDespesa.MultiSelect = false;
            this.grdDespesa.Name = "grdDespesa";
            this.grdDespesa.ReadOnly = true;
            this.grdDespesa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDespesa.Size = new System.Drawing.Size(693, 233);
            this.grdDespesa.TabIndex = 11;
            this.grdDespesa.DoubleClick += new System.EventHandler(this.grdDespesa_DoubleClick);
            // 
            // tarefa
            // 
            this.tarefa.DataPropertyName = "descricaotarefa";
            this.tarefa.HeaderText = "Tarefa";
            this.tarefa.Name = "tarefa";
            this.tarefa.ReadOnly = true;
            // 
            // codigoproduto
            // 
            this.codigoproduto.DataPropertyName = "codigoproduto";
            this.codigoproduto.HeaderText = "Produto";
            this.codigoproduto.Name = "codigoproduto";
            this.codigoproduto.ReadOnly = true;
            // 
            // unidade
            // 
            this.unidade.DataPropertyName = "descricaounidade";
            this.unidade.HeaderText = "Unidade";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            this.unidade.Width = 50;
            // 
            // quantidade
            // 
            this.quantidade.DataPropertyName = "quantidade";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N3";
            dataGridViewCellStyle2.NullValue = null;
            this.quantidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            // 
            // valordespesa
            // 
            this.valordespesa.DataPropertyName = "vlrdespesa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valordespesa.DefaultCellStyle = dataGridViewCellStyle3;
            this.valordespesa.HeaderText = "Valor";
            this.valordespesa.Name = "valordespesa";
            this.valordespesa.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricaoproduto";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descricao.DefaultCellStyle = dataGridViewCellStyle4;
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 250;
            // 
            // iddespesa
            // 
            this.iddespesa.DataPropertyName = "idobra_previsaodespesa";
            this.iddespesa.HeaderText = "iddespesa";
            this.iddespesa.Name = "iddespesa";
            this.iddespesa.ReadOnly = true;
            this.iddespesa.Visible = false;
            // 
            // idproduto
            // 
            this.idproduto.DataPropertyName = "idestq_produto";
            this.idproduto.HeaderText = "idproduto";
            this.idproduto.Name = "idproduto";
            this.idproduto.ReadOnly = true;
            this.idproduto.Visible = false;
            // 
            // idobra_tarefa
            // 
            this.idobra_tarefa.DataPropertyName = "idobra_tarefas";
            this.idobra_tarefa.HeaderText = "idobra_tarefa";
            this.idobra_tarefa.Name = "idobra_tarefa";
            this.idobra_tarefa.ReadOnly = true;
            this.idobra_tarefa.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtTotalObra);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtTotalTarefa);
            this.groupBox4.Location = new System.Drawing.Point(634, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(340, 68);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Valor Orçado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(174, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Obra";
            // 
            // txtTotalObra
            // 
            this.txtTotalObra.Enabled = false;
            this.txtTotalObra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalObra.Location = new System.Drawing.Point(177, 38);
            this.txtTotalObra.Name = "txtTotalObra";
            this.txtTotalObra.numeroDecimais = 0;
            this.txtTotalObra.ReadOnly = true;
            this.txtTotalObra.Size = new System.Drawing.Size(157, 20);
            this.txtTotalObra.TabIndex = 62;
            this.txtTotalObra.Text = "0,00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Tarefa";
            // 
            // txtTotalTarefa
            // 
            this.txtTotalTarefa.Enabled = false;
            this.txtTotalTarefa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalTarefa.Location = new System.Drawing.Point(12, 38);
            this.txtTotalTarefa.Name = "txtTotalTarefa";
            this.txtTotalTarefa.numeroDecimais = 0;
            this.txtTotalTarefa.ReadOnly = true;
            this.txtTotalTarefa.Size = new System.Drawing.Size(159, 20);
            this.txtTotalTarefa.TabIndex = 60;
            this.txtTotalTarefa.Text = "0,00";
            // 
            // frmPrevisaoDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(977, 480);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grdDespesa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvwTarefa);
            this.MaximizeBox = false;
            this.Name = "frmPrevisaoDespesa";
            this.Text = "Obras - Previsão de Despesas";
            this.Load += new System.EventHandler(this.frmPrevisaoDespesa_Load);
            this.Controls.SetChildIndex(this.tvwTarefa, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grdDespesa, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDespesa)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSituacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSituacaoDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdObra_CronogramaItem;
        private System.Windows.Forms.TextBox txtObra_Tarefa;
        private System.Windows.Forms.TextBox txtIdObra_Tarefa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscaObra;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvwTarefa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIdEstq_Produto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView grdDespesa;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Sample.DecimalTextBox txtTotalObra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Sample.DecimalTextBox txtTotalTarefa;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdObra_PrevisaoDespesa;
        private System.Windows.Forms.TextBox txtIdObra;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.TextBox txtIdUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarefa;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_tarefa;
        private MaskedNumber.MaskedNumber txtQtdePrevista;
        private MaskedNumber.MaskedNumber txtCustoPrevisto;
        private MaskedNumber.MaskedNumber txtVlrUnitario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboUnidade;
    }
}
