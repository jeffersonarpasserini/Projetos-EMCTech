namespace EMCFinanceiro
{
    partial class frmPagarBaseRateio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdBaseRateio = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalRateio = new System.Windows.Forms.Sample.DecimalTextBox();
            this.btnExcluiParcela = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIdContaCusto = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.txtContaCusto = new System.Windows.Forms.TextBox();
            this.btnContaCusto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdAplicacao = new MaskedNumber.MaskedNumber();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.btnAplicacao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVlrPercentual = new MaskedNumber.MaskedNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVlrUnitario = new MaskedNumber.MaskedNumber();
            this.label11 = new System.Windows.Forms.Label();
            this.btnNovoRateio = new System.Windows.Forms.Button();
            this.btnAlteraRateio = new System.Windows.Forms.Button();
            this.txtValorAnterior = new MaskedNumber.MaskedNumber();
            this.txtGridIndex = new MaskedNumber.MaskedNumber();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorDocumento = new System.Windows.Forms.Sample.DecimalTextBox();
            this.idpagardocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpagarbaserateio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idaplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoconta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaocontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorrateio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentualrateio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaseRateio)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBaseRateio
            // 
            this.grdBaseRateio.AllowUserToAddRows = false;
            this.grdBaseRateio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdBaseRateio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdBaseRateio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBaseRateio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpagardocumento,
            this.idpagarbaserateio,
            this.idaplicacao,
            this.aplicacao,
            this.idcontacusto,
            this.codigoconta,
            this.descricaocontacusto,
            this.valorrateio,
            this.percentualrateio,
            this.status});
            this.grdBaseRateio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdBaseRateio.Location = new System.Drawing.Point(2, 177);
            this.grdBaseRateio.MultiSelect = false;
            this.grdBaseRateio.Name = "grdBaseRateio";
            this.grdBaseRateio.ReadOnly = true;
            this.grdBaseRateio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBaseRateio.Size = new System.Drawing.Size(819, 203);
            this.grdBaseRateio.TabIndex = 1;
            this.grdBaseRateio.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBaseRateio_CellEndEdit);
            this.grdBaseRateio.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBaseRateio_CellEnter);
            this.grdBaseRateio.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdBaseRateio_CellValidated);
            this.grdBaseRateio.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdBaseRateio_CellValidating);
            this.grdBaseRateio.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdBaseRateio_CurrentCellDirtyStateChanged);
            this.grdBaseRateio.DoubleClick += new System.EventHandler(this.grdBaseRateio_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(671, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Valor Documento";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTotalRateio
            // 
            this.txtTotalRateio.Location = new System.Drawing.Point(674, 146);
            this.txtTotalRateio.Name = "txtTotalRateio";
            this.txtTotalRateio.numeroDecimais = 0;
            this.txtTotalRateio.ReadOnly = true;
            this.txtTotalRateio.Size = new System.Drawing.Size(146, 20);
            this.txtTotalRateio.TabIndex = 29;
            this.txtTotalRateio.Text = "0,00";
            this.txtTotalRateio.TextChanged += new System.EventHandler(this.txtTotalRateio_TextChanged);
            // 
            // btnExcluiParcela
            // 
            this.btnExcluiParcela.Image = global::EMCFinanceiro.Properties.Resources.Deletar_16x16;
            this.btnExcluiParcela.Location = new System.Drawing.Point(637, 137);
            this.btnExcluiParcela.Name = "btnExcluiParcela";
            this.btnExcluiParcela.Size = new System.Drawing.Size(31, 29);
            this.btnExcluiParcela.TabIndex = 6;
            this.btnExcluiParcela.UseVisualStyleBackColor = true;
            this.btnExcluiParcela.Click += new System.EventHandler(this.btnExcluiParcela_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIdContaCusto);
            this.groupBox3.Controls.Add(this.txtCodigoConta);
            this.groupBox3.Controls.Add(this.txtContaCusto);
            this.groupBox3.Controls.Add(this.btnContaCusto);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(2, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 47);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Centro de Custo";
            // 
            // txtIdContaCusto
            // 
            this.txtIdContaCusto.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdContaCusto.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdContaCusto.Location = new System.Drawing.Point(145, 0);
            this.txtIdContaCusto.Name = "txtIdContaCusto";
            this.txtIdContaCusto.Size = new System.Drawing.Size(100, 20);
            this.txtIdContaCusto.TabIndex = 44;
            this.txtIdContaCusto.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdContaCusto.Visible = false;
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(7, 17);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConta.TabIndex = 0;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoConta_Validating);
            // 
            // txtContaCusto
            // 
            this.txtContaCusto.Location = new System.Drawing.Point(136, 19);
            this.txtContaCusto.Name = "txtContaCusto";
            this.txtContaCusto.ReadOnly = true;
            this.txtContaCusto.Size = new System.Drawing.Size(312, 20);
            this.txtContaCusto.TabIndex = 41;
            // 
            // btnContaCusto
            // 
            this.btnContaCusto.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnContaCusto.Location = new System.Drawing.Point(107, 17);
            this.btnContaCusto.Name = "btnContaCusto";
            this.btnContaCusto.Size = new System.Drawing.Size(29, 22);
            this.btnContaCusto.TabIndex = 40;
            this.btnContaCusto.UseVisualStyleBackColor = true;
            this.btnContaCusto.Click += new System.EventHandler(this.btnContaCusto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIdAplicacao);
            this.groupBox1.Controls.Add(this.txtAplicacao);
            this.groupBox1.Controls.Add(this.btnAplicacao);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(2, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 47);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aplicação";
            // 
            // txtIdAplicacao
            // 
            this.txtIdAplicacao.CustomFormat = "000000000";
            this.txtIdAplicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAplicacao.Format = MaskedNumberFormat.Custom;
            this.txtIdAplicacao.Location = new System.Drawing.Point(7, 17);
            this.txtIdAplicacao.MaxLength = 9;
            this.txtIdAplicacao.Name = "txtIdAplicacao";
            this.txtIdAplicacao.Size = new System.Drawing.Size(44, 20);
            this.txtIdAplicacao.TabIndex = 1;
            this.txtIdAplicacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdAplicacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdAplicacao_Validating);
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.Location = new System.Drawing.Point(81, 17);
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.ReadOnly = true;
            this.txtAplicacao.Size = new System.Drawing.Size(367, 20);
            this.txtAplicacao.TabIndex = 41;
            // 
            // btnAplicacao
            // 
            this.btnAplicacao.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnAplicacao.Location = new System.Drawing.Point(51, 17);
            this.btnAplicacao.Name = "btnAplicacao";
            this.btnAplicacao.Size = new System.Drawing.Size(29, 22);
            this.btnAplicacao.TabIndex = 40;
            this.btnAplicacao.UseVisualStyleBackColor = true;
            this.btnAplicacao.Click += new System.EventHandler(this.btnAplicacao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVlrPercentual);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtVlrUnitario);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(462, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 100);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Valores";
            // 
            // txtVlrPercentual
            // 
            this.txtVlrPercentual.CustomFormat = "0:0";
            this.txtVlrPercentual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtVlrPercentual.Format = MaskedNumberFormat.Porcentagem;
            this.txtVlrPercentual.Location = new System.Drawing.Point(9, 32);
            this.txtVlrPercentual.Name = "txtVlrPercentual";
            this.txtVlrPercentual.Size = new System.Drawing.Size(154, 20);
            this.txtVlrPercentual.TabIndex = 2;
            this.txtVlrPercentual.Text = "0,0000%";
            this.txtVlrPercentual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVlrPercentual.Validating += new System.ComponentModel.CancelEventHandler(this.txtVlrPercentual_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Percentual";
            // 
            // txtVlrUnitario
            // 
            this.txtVlrUnitario.CustomFormat = "0:0";
            this.txtVlrUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtVlrUnitario.Format = MaskedNumberFormat.Moeda;
            this.txtVlrUnitario.Location = new System.Drawing.Point(9, 72);
            this.txtVlrUnitario.Name = "txtVlrUnitario";
            this.txtVlrUnitario.Size = new System.Drawing.Size(154, 20);
            this.txtVlrUnitario.TabIndex = 3;
            this.txtVlrUnitario.Text = "R$ 0,00";
            this.txtVlrUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVlrUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtVlrUnitario_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "Custo Unitário";
            // 
            // btnNovoRateio
            // 
            this.btnNovoRateio.Image = global::EMCFinanceiro.Properties.Resources.Incluir_16x16;
            this.btnNovoRateio.Location = new System.Drawing.Point(637, 79);
            this.btnNovoRateio.Name = "btnNovoRateio";
            this.btnNovoRateio.Size = new System.Drawing.Size(31, 29);
            this.btnNovoRateio.TabIndex = 4;
            this.btnNovoRateio.UseVisualStyleBackColor = true;
            this.btnNovoRateio.Click += new System.EventHandler(this.btnNovoRateio_Click);
            // 
            // btnAlteraRateio
            // 
            this.btnAlteraRateio.Image = global::EMCFinanceiro.Properties.Resources.alteracao_16x16;
            this.btnAlteraRateio.Location = new System.Drawing.Point(637, 108);
            this.btnAlteraRateio.Name = "btnAlteraRateio";
            this.btnAlteraRateio.Size = new System.Drawing.Size(31, 29);
            this.btnAlteraRateio.TabIndex = 5;
            this.btnAlteraRateio.UseVisualStyleBackColor = true;
            this.btnAlteraRateio.Click += new System.EventHandler(this.btnAlteraRateio_Click);
            // 
            // txtValorAnterior
            // 
            this.txtValorAnterior.CustomFormat = "0:0";
            this.txtValorAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorAnterior.Format = MaskedNumberFormat.Moeda;
            this.txtValorAnterior.Location = new System.Drawing.Point(667, 8);
            this.txtValorAnterior.Name = "txtValorAnterior";
            this.txtValorAnterior.Size = new System.Drawing.Size(154, 20);
            this.txtValorAnterior.TabIndex = 100;
            this.txtValorAnterior.Text = "R$ 0,00";
            this.txtValorAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorAnterior.Visible = false;
            // 
            // txtGridIndex
            // 
            this.txtGridIndex.CustomFormat = "000000000";
            this.txtGridIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGridIndex.Format = MaskedNumberFormat.Custom;
            this.txtGridIndex.Location = new System.Drawing.Point(777, 28);
            this.txtGridIndex.MaxLength = 9;
            this.txtGridIndex.Name = "txtGridIndex";
            this.txtGridIndex.Size = new System.Drawing.Size(44, 20);
            this.txtGridIndex.TabIndex = 101;
            this.txtGridIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGridIndex.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(777, 50);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(43, 20);
            this.txtStatus.TabIndex = 102;
            this.txtStatus.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(674, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Valor Rateio";
            // 
            // txtValorDocumento
            // 
            this.txtValorDocumento.Location = new System.Drawing.Point(674, 105);
            this.txtValorDocumento.Name = "txtValorDocumento";
            this.txtValorDocumento.numeroDecimais = 0;
            this.txtValorDocumento.ReadOnly = true;
            this.txtValorDocumento.Size = new System.Drawing.Size(146, 20);
            this.txtValorDocumento.TabIndex = 104;
            this.txtValorDocumento.Text = "0,00";
            // 
            // idpagardocumento
            // 
            this.idpagardocumento.DataPropertyName = "idpagardocumento";
            this.idpagardocumento.HeaderText = "idpagardocumento";
            this.idpagardocumento.Name = "idpagardocumento";
            this.idpagardocumento.ReadOnly = true;
            this.idpagardocumento.Visible = false;
            // 
            // idpagarbaserateio
            // 
            this.idpagarbaserateio.DataPropertyName = "idpagarbaserateio";
            this.idpagarbaserateio.HeaderText = "idpagarbaserateio";
            this.idpagarbaserateio.Name = "idpagarbaserateio";
            this.idpagarbaserateio.ReadOnly = true;
            this.idpagarbaserateio.Visible = false;
            // 
            // idaplicacao
            // 
            this.idaplicacao.DataPropertyName = "idaplicacao";
            this.idaplicacao.HeaderText = "Código";
            this.idaplicacao.Name = "idaplicacao";
            this.idaplicacao.ReadOnly = true;
            this.idaplicacao.Width = 50;
            // 
            // aplicacao
            // 
            this.aplicacao.DataPropertyName = "descricaoaplicacao";
            this.aplicacao.HeaderText = "Aplicação";
            this.aplicacao.Name = "aplicacao";
            this.aplicacao.ReadOnly = true;
            this.aplicacao.Width = 200;
            // 
            // idcontacusto
            // 
            this.idcontacusto.DataPropertyName = "idcontacusto";
            this.idcontacusto.HeaderText = "idcontacusto";
            this.idcontacusto.Name = "idcontacusto";
            this.idcontacusto.ReadOnly = true;
            this.idcontacusto.Visible = false;
            // 
            // codigoconta
            // 
            this.codigoconta.DataPropertyName = "codigoconta";
            this.codigoconta.HeaderText = "Conta Custo";
            this.codigoconta.Name = "codigoconta";
            this.codigoconta.ReadOnly = true;
            // 
            // descricaocontacusto
            // 
            this.descricaocontacusto.DataPropertyName = "descricaocontacusto";
            this.descricaocontacusto.HeaderText = "Descrição";
            this.descricaocontacusto.Name = "descricaocontacusto";
            this.descricaocontacusto.ReadOnly = true;
            this.descricaocontacusto.Width = 200;
            // 
            // valorrateio
            // 
            this.valorrateio.DataPropertyName = "valorrateio";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = "0";
            this.valorrateio.DefaultCellStyle = dataGridViewCellStyle8;
            this.valorrateio.HeaderText = "Valor";
            this.valorrateio.Name = "valorrateio";
            this.valorrateio.ReadOnly = true;
            // 
            // percentualrateio
            // 
            this.percentualrateio.DataPropertyName = "percentualrateio";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N4";
            dataGridViewCellStyle9.NullValue = "0";
            this.percentualrateio.DefaultCellStyle = dataGridViewCellStyle9;
            this.percentualrateio.HeaderText = "Percentual";
            this.percentualrateio.Name = "percentualrateio";
            this.percentualrateio.ReadOnly = true;
            this.percentualrateio.Width = 80;
            // 
            // status
            // 
            this.status.HeaderText = "ST";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 30;
            // 
            // frmPagarBaseRateio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(826, 383);
            this.Controls.Add(this.txtValorDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtGridIndex);
            this.Controls.Add(this.txtValorAnterior);
            this.Controls.Add(this.btnAlteraRateio);
            this.Controls.Add(this.btnNovoRateio);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExcluiParcela);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalRateio);
            this.Controls.Add(this.grdBaseRateio);
            this.Name = "frmPagarBaseRateio";
            this.Text = "Contas a Pagar - Base de Rateio";
            this.Load += new System.EventHandler(this.frmPagarBaseRateio_Load);
            this.Controls.SetChildIndex(this.grdBaseRateio, 0);
            this.Controls.SetChildIndex(this.txtTotalRateio, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnExcluiParcela, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnNovoRateio, 0);
            this.Controls.SetChildIndex(this.btnAlteraRateio, 0);
            this.Controls.SetChildIndex(this.txtValorAnterior, 0);
            this.Controls.SetChildIndex(this.txtGridIndex, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtValorDocumento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaseRateio)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdBaseRateio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Sample.DecimalTextBox txtTotalRateio;
        private System.Windows.Forms.Button btnExcluiParcela;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;
        private System.Windows.Forms.TextBox txtContaCusto;
        private System.Windows.Forms.Button btnContaCusto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAplicacao;
        private System.Windows.Forms.Button btnAplicacao;
        private System.Windows.Forms.MaskedTextBox txtIdContaCusto;
        private MaskedNumber.MaskedNumber txtIdAplicacao;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaskedNumber.MaskedNumber txtVlrPercentual;
        private System.Windows.Forms.Label label1;
        private MaskedNumber.MaskedNumber txtVlrUnitario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnNovoRateio;
        private System.Windows.Forms.Button btnAlteraRateio;
        private MaskedNumber.MaskedNumber txtValorAnterior;
        private MaskedNumber.MaskedNumber txtGridIndex;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagardocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagarbaserateio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idaplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcontacusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoconta;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaocontacusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorrateio;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentualrateio;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}
