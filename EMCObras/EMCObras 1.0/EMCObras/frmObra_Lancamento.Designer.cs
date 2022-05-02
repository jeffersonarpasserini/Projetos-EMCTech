namespace EMCObras
{
    partial class frmObra_Lancamento
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdObra = new System.Windows.Forms.TextBox();
            this.btnBuscaObra = new System.Windows.Forms.Button();
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.grdRateio = new System.Windows.Forms.DataGridView();
            this.grpRateio = new System.Windows.Forms.GroupBox();
            this.cboUnidade = new System.Windows.Forms.ComboBox();
            this.txtVlrUnitario = new MaskedNumber.MaskedNumber();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustoPrevisto = new MaskedNumber.MaskedNumber();
            this.txtQtdePrevista = new MaskedNumber.MaskedNumber();
            this.txtIdUnidade = new System.Windows.Forms.TextBox();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.txtIdObra_LancamentoItem = new System.Windows.Forms.TextBox();
            this.btnProduto = new System.Windows.Forms.Button();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdEstq_Produto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grpDocumento = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdObra_Lancamento = new System.Windows.Forms.TextBox();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtIdFornecedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtValorDocumento = new MaskedNumber.MaskedNumber();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSomaItens = new MaskedNumber.MaskedNumber();
            this.label15 = new System.Windows.Forms.Label();
            this.txtProdFornecedor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRateio)).BeginInit();
            this.grpDocumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(2, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 61);
            this.groupBox1.TabIndex = 9;
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
            this.btnBuscaObra.Location = new System.Drawing.Point(145, 34);
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
            this.txtDescricaoObra.Location = new System.Drawing.Point(178, 34);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.ReadOnly = true;
            this.txtDescricaoObra.Size = new System.Drawing.Size(363, 22);
            this.txtDescricaoObra.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 18);
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
            this.txtAbreviacao.Size = new System.Drawing.Size(139, 22);
            this.txtAbreviacao.TabIndex = 0;
            this.txtAbreviacao.TextChanged += new System.EventHandler(this.txtAbreviacao_TextChanged);
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
            // grpItem
            // 
            this.grpItem.Controls.Add(this.txtProdFornecedor);
            this.grpItem.Controls.Add(this.label16);
            this.grpItem.Controls.Add(this.grdRateio);
            this.grpItem.Controls.Add(this.grpRateio);
            this.grpItem.Controls.Add(this.cboUnidade);
            this.grpItem.Controls.Add(this.txtVlrUnitario);
            this.grpItem.Controls.Add(this.label11);
            this.grpItem.Controls.Add(this.txtCustoPrevisto);
            this.grpItem.Controls.Add(this.txtQtdePrevista);
            this.grpItem.Controls.Add(this.txtIdUnidade);
            this.grpItem.Controls.Add(this.txtIdProduto);
            this.grpItem.Controls.Add(this.txtIdObra_LancamentoItem);
            this.grpItem.Controls.Add(this.btnProduto);
            this.grpItem.Controls.Add(this.txtDescricaoProduto);
            this.grpItem.Controls.Add(this.label9);
            this.grpItem.Controls.Add(this.txtIdEstq_Produto);
            this.grpItem.Controls.Add(this.label6);
            this.grpItem.Controls.Add(this.label14);
            this.grpItem.Controls.Add(this.label5);
            this.grpItem.Controls.Add(this.label10);
            this.grpItem.Enabled = false;
            this.grpItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpItem.Location = new System.Drawing.Point(565, 76);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(690, 395);
            this.grpItem.TabIndex = 11;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "Item Lançamento";
            // 
            // grdRateio
            // 
            this.grdRateio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRateio.Location = new System.Drawing.Point(6, 185);
            this.grdRateio.Name = "grdRateio";
            this.grdRateio.Size = new System.Drawing.Size(678, 150);
            this.grdRateio.TabIndex = 100;
            // 
            // grpRateio
            // 
            this.grpRateio.Location = new System.Drawing.Point(6, 96);
            this.grpRateio.Name = "grpRateio";
            this.grpRateio.Size = new System.Drawing.Size(681, 83);
            this.grpRateio.TabIndex = 99;
            this.grpRateio.TabStop = false;
            this.grpRateio.Text = "Rateio do Produto";
            // 
            // cboUnidade
            // 
            this.cboUnidade.FormattingEnabled = true;
            this.cboUnidade.Location = new System.Drawing.Point(362, 31);
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Size = new System.Drawing.Size(56, 24);
            this.cboUnidade.TabIndex = 1;
            // 
            // txtVlrUnitario
            // 
            this.txtVlrUnitario.CustomFormat = "0:0";
            this.txtVlrUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtVlrUnitario.Format = MaskedNumberFormat.Moeda;
            this.txtVlrUnitario.Location = new System.Drawing.Point(482, 33);
            this.txtVlrUnitario.Name = "txtVlrUnitario";
            this.txtVlrUnitario.Size = new System.Drawing.Size(98, 20);
            this.txtVlrUnitario.TabIndex = 3;
            this.txtVlrUnitario.Text = "R$ 0,00";
            this.txtVlrUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(485, 18);
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
            this.txtCustoPrevisto.Location = new System.Drawing.Point(583, 32);
            this.txtCustoPrevisto.Name = "txtCustoPrevisto";
            this.txtCustoPrevisto.Size = new System.Drawing.Size(104, 20);
            this.txtCustoPrevisto.TabIndex = 4;
            this.txtCustoPrevisto.Text = "R$ 0,00";
            this.txtCustoPrevisto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQtdePrevista
            // 
            this.txtQtdePrevista.CustomFormat = "0:0";
            this.txtQtdePrevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtQtdePrevista.Format = MaskedNumberFormat.Peso;
            this.txtQtdePrevista.Location = new System.Drawing.Point(421, 33);
            this.txtQtdePrevista.Name = "txtQtdePrevista";
            this.txtQtdePrevista.Size = new System.Drawing.Size(59, 20);
            this.txtQtdePrevista.TabIndex = 2;
            this.txtQtdePrevista.Text = "0,000";
            this.txtQtdePrevista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIdUnidade
            // 
            this.txtIdUnidade.Location = new System.Drawing.Point(132, 0);
            this.txtIdUnidade.Name = "txtIdUnidade";
            this.txtIdUnidade.Size = new System.Drawing.Size(100, 22);
            this.txtIdUnidade.TabIndex = 96;
            this.txtIdUnidade.Visible = false;
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Location = new System.Drawing.Point(238, 0);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(100, 22);
            this.txtIdProduto.TabIndex = 95;
            this.txtIdProduto.Visible = false;
            this.txtIdProduto.TextChanged += new System.EventHandler(this.txtIdProduto_TextChanged);
            // 
            // txtIdObra_LancamentoItem
            // 
            this.txtIdObra_LancamentoItem.Location = new System.Drawing.Point(344, -3);
            this.txtIdObra_LancamentoItem.Name = "txtIdObra_LancamentoItem";
            this.txtIdObra_LancamentoItem.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_LancamentoItem.TabIndex = 94;
            this.txtIdObra_LancamentoItem.Visible = false;
            // 
            // btnProduto
            // 
            this.btnProduto.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnProduto.Location = new System.Drawing.Point(329, 30);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(31, 25);
            this.btnProduto.TabIndex = 93;
            this.btnProduto.UseVisualStyleBackColor = true;
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoProduto.Enabled = false;
            this.txtDescricaoProduto.Location = new System.Drawing.Point(6, 68);
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.ReadOnly = true;
            this.txtDescricaoProduto.Size = new System.Drawing.Size(681, 22);
            this.txtDescricaoProduto.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "Descrição";
            // 
            // txtIdEstq_Produto
            // 
            this.txtIdEstq_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdEstq_Produto.Enabled = false;
            this.txtIdEstq_Produto.Location = new System.Drawing.Point(159, 33);
            this.txtIdEstq_Produto.Name = "txtIdEstq_Produto";
            this.txtIdEstq_Produto.Size = new System.Drawing.Size(168, 22);
            this.txtIdEstq_Produto.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(583, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Custo Previsto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(418, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(359, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Unidade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(156, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Produto (Interno)";
            // 
            // grpDocumento
            // 
            this.grpDocumento.Controls.Add(this.txtSomaItens);
            this.grpDocumento.Controls.Add(this.label15);
            this.grpDocumento.Controls.Add(this.txtValorDocumento);
            this.grpDocumento.Controls.Add(this.label13);
            this.grpDocumento.Controls.Add(this.label12);
            this.grpDocumento.Controls.Add(this.dateTimePicker1);
            this.grpDocumento.Controls.Add(this.label8);
            this.grpDocumento.Controls.Add(this.txtDataInicio);
            this.grpDocumento.Controls.Add(this.label7);
            this.grpDocumento.Controls.Add(this.btnFornecedor);
            this.grpDocumento.Controls.Add(this.txtFornecedor);
            this.grpDocumento.Controls.Add(this.txtIdFornecedor);
            this.grpDocumento.Controls.Add(this.label4);
            this.grpDocumento.Controls.Add(this.txtNroDocumento);
            this.grpDocumento.Controls.Add(this.txtIdObra_Lancamento);
            this.grpDocumento.Enabled = false;
            this.grpDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDocumento.Location = new System.Drawing.Point(2, 142);
            this.grpDocumento.Name = "grpDocumento";
            this.grpDocumento.Size = new System.Drawing.Size(557, 110);
            this.grpDocumento.TabIndex = 12;
            this.grpDocumento.TabStop = false;
            this.grpDocumento.Text = "Dados do Documento";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 272);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(557, 199);
            this.dataGridView1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Itens do Documento";
            // 
            // txtIdObra_Lancamento
            // 
            this.txtIdObra_Lancamento.Location = new System.Drawing.Point(168, 0);
            this.txtIdObra_Lancamento.Name = "txtIdObra_Lancamento";
            this.txtIdObra_Lancamento.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_Lancamento.TabIndex = 0;
            this.txtIdObra_Lancamento.Visible = false;
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(11, 38);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(165, 22);
            this.txtNroDocumento.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Número Documento";
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnFornecedor.Location = new System.Drawing.Point(237, 36);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(31, 23);
            this.btnFornecedor.TabIndex = 88;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(270, 38);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(271, 22);
            this.txtFornecedor.TabIndex = 87;
            // 
            // txtIdFornecedor
            // 
            this.txtIdFornecedor.Location = new System.Drawing.Point(179, 38);
            this.txtIdFornecedor.Name = "txtIdFornecedor";
            this.txtIdFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdFornecedor.Size = new System.Drawing.Size(56, 22);
            this.txtIdFornecedor.TabIndex = 2;
            this.txtIdFornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFornecedor_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Fornecedor";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(13, 83);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(99, 22);
            this.txtDataInicio.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Data Documento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(115, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 93;
            this.label12.Text = "Data Entrada";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(118, 83);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(99, 22);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // txtValorDocumento
            // 
            this.txtValorDocumento.CustomFormat = "0:0";
            this.txtValorDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorDocumento.Format = MaskedNumberFormat.Moeda;
            this.txtValorDocumento.Location = new System.Drawing.Point(273, 83);
            this.txtValorDocumento.Name = "txtValorDocumento";
            this.txtValorDocumento.Size = new System.Drawing.Size(131, 20);
            this.txtValorDocumento.TabIndex = 5;
            this.txtValorDocumento.Text = "R$ 0,00";
            this.txtValorDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(270, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 95;
            this.label13.Text = "Valor Documento";
            // 
            // txtSomaItens
            // 
            this.txtSomaItens.CustomFormat = "0:0";
            this.txtSomaItens.Enabled = false;
            this.txtSomaItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSomaItens.Format = MaskedNumberFormat.Moeda;
            this.txtSomaItens.Location = new System.Drawing.Point(410, 83);
            this.txtSomaItens.Name = "txtSomaItens";
            this.txtSomaItens.Size = new System.Drawing.Size(131, 20);
            this.txtSomaItens.TabIndex = 96;
            this.txtSomaItens.Text = "R$ 0,00";
            this.txtSomaItens.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(407, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 97;
            this.label15.Text = "Soma Itens";
            // 
            // txtProdFornecedor
            // 
            this.txtProdFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProdFornecedor.Enabled = false;
            this.txtProdFornecedor.Location = new System.Drawing.Point(6, 33);
            this.txtProdFornecedor.Name = "txtProdFornecedor";
            this.txtProdFornecedor.Size = new System.Drawing.Size(151, 22);
            this.txtProdFornecedor.TabIndex = 101;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 13);
            this.label16.TabIndex = 102;
            this.label16.Text = "Produto ( Código Fornecedor)";
            // 
            // frmObra_Lancamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1266, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpDocumento);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmObra_Lancamento";
            this.Text = "Lançamento de Despesas de Obra";
            this.Load += new System.EventHandler(this.frmObra_Lancamento_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpItem, 0);
            this.Controls.SetChildIndex(this.grpDocumento, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRateio)).EndInit();
            this.grpDocumento.ResumeLayout(false);
            this.grpDocumento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdObra;
        private System.Windows.Forms.Button btnBuscaObra;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.GroupBox grpRateio;
        private System.Windows.Forms.ComboBox cboUnidade;
        private MaskedNumber.MaskedNumber txtVlrUnitario;
        private System.Windows.Forms.Label label11;
        private MaskedNumber.MaskedNumber txtCustoPrevisto;
        private MaskedNumber.MaskedNumber txtQtdePrevista;
        private System.Windows.Forms.TextBox txtIdUnidade;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.TextBox txtIdObra_LancamentoItem;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdEstq_Produto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpDocumento;
        private System.Windows.Forms.DataGridView grdRateio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdObra_Lancamento;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.TextBox txtIdFornecedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private MaskedNumber.MaskedNumber txtSomaItens;
        private System.Windows.Forms.Label label15;
        private MaskedNumber.MaskedNumber txtValorDocumento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtProdFornecedor;
        private System.Windows.Forms.Label label16;
    }
}
