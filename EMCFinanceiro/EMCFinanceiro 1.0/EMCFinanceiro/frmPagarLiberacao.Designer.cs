namespace EMCFinanceiro
{
    partial class frmPagarLiberacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdLiberacao = new System.Windows.Forms.DataGridView();
            this.chklibera = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idpagardocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpagarparcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomefornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDataEntrada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataEmissao = new System.Windows.Forms.TextBox();
            this.txtIndexador = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValorParcela = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDesmarcarTodos = new System.Windows.Forms.Button();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnMarcarTodos = new System.Windows.Forms.Button();
            this.txtNomeFornecedor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.chkValorDocumento = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorFinal = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorInicio = new System.Windows.Forms.Sample.DecimalTextBox();
            this.chkTodasContas = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.txtCodigoFornecedor = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.grdRateio = new System.Windows.Forms.DataGridView();
            this.idaplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoconta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaocontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicacaodescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorrateio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.txtValorDocumento = new System.Windows.Forms.Sample.DecimalTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdLiberacao)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRateio)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLiberacao
            // 
            this.grdLiberacao.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdLiberacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdLiberacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLiberacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chklibera,
            this.idpagardocumento,
            this.idpagarparcelas,
            this.nrodocumento,
            this.nroparcela,
            this.datavencimento,
            this.valorparcela,
            this.nomefornecedor});
            this.grdLiberacao.Location = new System.Drawing.Point(5, 159);
            this.grdLiberacao.Name = "grdLiberacao";
            this.grdLiberacao.Size = new System.Drawing.Size(662, 372);
            this.grdLiberacao.TabIndex = 1;
            this.grdLiberacao.Click += new System.EventHandler(this.grdLiberacao_Click);
            // 
            // chklibera
            // 
            this.chklibera.HeaderText = "ST";
            this.chklibera.Name = "chklibera";
            this.chklibera.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chklibera.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chklibera.Width = 25;
            // 
            // idpagardocumento
            // 
            this.idpagardocumento.HeaderText = "idpagardocumento";
            this.idpagardocumento.Name = "idpagardocumento";
            this.idpagardocumento.Visible = false;
            // 
            // idpagarparcelas
            // 
            this.idpagarparcelas.HeaderText = "idpagarparcelas";
            this.idpagarparcelas.Name = "idpagarparcelas";
            this.idpagarparcelas.Visible = false;
            // 
            // nrodocumento
            // 
            this.nrodocumento.HeaderText = "Documento";
            this.nrodocumento.Name = "nrodocumento";
            this.nrodocumento.ReadOnly = true;
            // 
            // nroparcela
            // 
            this.nroparcela.HeaderText = "Nro Parcela";
            this.nroparcela.Name = "nroparcela";
            this.nroparcela.ReadOnly = true;
            this.nroparcela.Width = 50;
            // 
            // datavencimento
            // 
            this.datavencimento.HeaderText = "Data Vencimento";
            this.datavencimento.Name = "datavencimento";
            this.datavencimento.ReadOnly = true;
            // 
            // valorparcela
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.valorparcela.DefaultCellStyle = dataGridViewCellStyle7;
            this.valorparcela.HeaderText = "Valor Parcela";
            this.valorparcela.Name = "valorparcela";
            this.valorparcela.ReadOnly = true;
            // 
            // nomefornecedor
            // 
            this.nomefornecedor.HeaderText = "Fornecedor";
            this.nomefornecedor.Name = "nomefornecedor";
            this.nomefornecedor.ReadOnly = true;
            this.nomefornecedor.Width = 300;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtValorDocumento);
            this.panel3.Controls.Add(this.txtCNPJCPF);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtDataEntrada);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtDataEmissao);
            this.panel3.Controls.Add(this.txtIndexador);
            this.panel3.Controls.Add(this.txtFornecedor);
            this.panel3.Controls.Add(this.txtTipoDocumento);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtValorParcela);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtNroDocumento);
            this.panel3.Location = new System.Drawing.Point(673, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(431, 233);
            this.panel3.TabIndex = 13;
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(302, 100);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.ReadOnly = true;
            this.txtCNPJCPF.Size = new System.Drawing.Size(125, 20);
            this.txtCNPJCPF.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "CNPJ/CPF";
            // 
            // txtDataEntrada
            // 
            this.txtDataEntrada.Location = new System.Drawing.Point(339, 24);
            this.txtDataEntrada.Name = "txtDataEntrada";
            this.txtDataEntrada.ReadOnly = true;
            this.txtDataEntrada.Size = new System.Drawing.Size(88, 20);
            this.txtDataEntrada.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Data Entrada";
            // 
            // txtDataEmissao
            // 
            this.txtDataEmissao.Location = new System.Drawing.Point(245, 24);
            this.txtDataEmissao.Name = "txtDataEmissao";
            this.txtDataEmissao.ReadOnly = true;
            this.txtDataEmissao.Size = new System.Drawing.Size(88, 20);
            this.txtDataEmissao.TabIndex = 26;
            // 
            // txtIndexador
            // 
            this.txtIndexador.Location = new System.Drawing.Point(245, 61);
            this.txtIndexador.Name = "txtIndexador";
            this.txtIndexador.ReadOnly = true;
            this.txtIndexador.Size = new System.Drawing.Size(182, 20);
            this.txtIndexador.TabIndex = 25;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(3, 100);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(296, 20);
            this.txtFornecedor.TabIndex = 22;
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Location = new System.Drawing.Point(4, 61);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(235, 20);
            this.txtTipoDocumento.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Descrição";
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValorParcela.Location = new System.Drawing.Point(3, 177);
            this.txtValorParcela.Multiline = true;
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.ReadOnly = true;
            this.txtValorParcela.Size = new System.Drawing.Size(424, 50);
            this.txtValorParcela.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Indexador";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tipo Documento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fornecedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Data Emissão";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Número Documento";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroDocumento.Location = new System.Drawing.Point(4, 24);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.ReadOnly = true;
            this.txtNroDocumento.Size = new System.Drawing.Size(235, 20);
            this.txtNroDocumento.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDesmarcarTodos);
            this.panel2.Controls.Add(this.btnFornecedor);
            this.panel2.Controls.Add(this.btnMarcarTodos);
            this.panel2.Controls.Add(this.txtNomeFornecedor);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtNumeroDocumento);
            this.panel2.Controls.Add(this.chkValorDocumento);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtValorFinal);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtValorInicio);
            this.panel2.Controls.Add(this.chkTodasContas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtDataFinal);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtDataInicio);
            this.panel2.Controls.Add(this.txtCodigoFornecedor);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(2, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 84);
            this.panel2.TabIndex = 14;
            // 
            // btnDesmarcarTodos
            // 
            this.btnDesmarcarTodos.Location = new System.Drawing.Point(858, 32);
            this.btnDesmarcarTodos.Name = "btnDesmarcarTodos";
            this.btnDesmarcarTodos.Size = new System.Drawing.Size(132, 23);
            this.btnDesmarcarTodos.TabIndex = 16;
            this.btnDesmarcarTodos.Text = "Desmarcar Todos";
            this.btnDesmarcarTodos.UseVisualStyleBackColor = true;
            this.btnDesmarcarTodos.Click += new System.EventHandler(this.btnDesmarcarTodos_Click);
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnFornecedor.Location = new System.Drawing.Point(342, 18);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(31, 23);
            this.btnFornecedor.TabIndex = 37;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnMarcarTodos
            // 
            this.btnMarcarTodos.Location = new System.Drawing.Point(858, 4);
            this.btnMarcarTodos.Name = "btnMarcarTodos";
            this.btnMarcarTodos.Size = new System.Drawing.Size(132, 23);
            this.btnMarcarTodos.TabIndex = 15;
            this.btnMarcarTodos.Text = "Marcar Todos";
            this.btnMarcarTodos.UseVisualStyleBackColor = true;
            this.btnMarcarTodos.Click += new System.EventHandler(this.btnMarcarTodos_Click);
            // 
            // txtNomeFornecedor
            // 
            this.txtNomeFornecedor.Location = new System.Drawing.Point(375, 20);
            this.txtNomeFornecedor.Name = "txtNomeFornecedor";
            this.txtNomeFornecedor.ReadOnly = true;
            this.txtNomeFornecedor.Size = new System.Drawing.Size(407, 20);
            this.txtNomeFornecedor.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Número Documento";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroDocumento.Location = new System.Drawing.Point(9, 20);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(259, 20);
            this.txtNumeroDocumento.TabIndex = 33;
            // 
            // chkValorDocumento
            // 
            this.chkValorDocumento.AutoSize = true;
            this.chkValorDocumento.Checked = true;
            this.chkValorDocumento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValorDocumento.Location = new System.Drawing.Point(261, 61);
            this.chkValorDocumento.Name = "chkValorDocumento";
            this.chkValorDocumento.Size = new System.Drawing.Size(162, 17);
            this.chkValorDocumento.TabIndex = 32;
            this.chkValorDocumento.Text = "Todas as Contas do Período";
            this.chkValorDocumento.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "até";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Valor Documento";
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(147, 58);
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.numeroDecimais = 0;
            this.txtValorFinal.Size = new System.Drawing.Size(109, 20);
            this.txtValorFinal.TabIndex = 29;
            this.txtValorFinal.Text = "0,00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Valor Documento";
            // 
            // txtValorInicio
            // 
            this.txtValorInicio.Location = new System.Drawing.Point(9, 58);
            this.txtValorInicio.Name = "txtValorInicio";
            this.txtValorInicio.numeroDecimais = 0;
            this.txtValorInicio.Size = new System.Drawing.Size(109, 20);
            this.txtValorInicio.TabIndex = 27;
            this.txtValorInicio.Text = "0,00";
            // 
            // chkTodasContas
            // 
            this.chkTodasContas.AutoSize = true;
            this.chkTodasContas.Checked = true;
            this.chkTodasContas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasContas.Location = new System.Drawing.Point(629, 63);
            this.chkTodasContas.Name = "chkTodasContas";
            this.chkTodasContas.Size = new System.Drawing.Size(162, 17);
            this.chkTodasContas.TabIndex = 15;
            this.chkTodasContas.Text = "Todas as Contas do Período";
            this.chkTodasContas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "até";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(535, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Data Vencimento";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(537, 61);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(88, 20);
            this.txtDataFinal.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(425, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Data Vencimento";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(427, 61);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(88, 20);
            this.txtDataInicio.TabIndex = 9;
            // 
            // txtCodigoFornecedor
            // 
            this.txtCodigoFornecedor.Location = new System.Drawing.Point(280, 20);
            this.txtCodigoFornecedor.Name = "txtCodigoFornecedor";
            this.txtCodigoFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodigoFornecedor.Size = new System.Drawing.Size(59, 20);
            this.txtCodigoFornecedor.TabIndex = 6;
            this.txtCodigoFornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoFornecedor_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(279, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Fornecedor";
            // 
            // grdRateio
            // 
            this.grdRateio.AllowUserToAddRows = false;
            this.grdRateio.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdRateio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdRateio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRateio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idaplicacao,
            this.idcontacusto,
            this.codigoconta,
            this.descricaocontacusto,
            this.aplicacaodescricao,
            this.valorrateio,
            this.percentual});
            this.grdRateio.Location = new System.Drawing.Point(673, 397);
            this.grdRateio.Name = "grdRateio";
            this.grdRateio.ReadOnly = true;
            this.grdRateio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRateio.Size = new System.Drawing.Size(430, 137);
            this.grdRateio.TabIndex = 15;
            // 
            // idaplicacao
            // 
            this.idaplicacao.DataPropertyName = "idaplicacao";
            this.idaplicacao.HeaderText = "idaplicacao";
            this.idaplicacao.Name = "idaplicacao";
            this.idaplicacao.ReadOnly = true;
            this.idaplicacao.Visible = false;
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
            this.codigoconta.HeaderText = "Cta Custo";
            this.codigoconta.Name = "codigoconta";
            this.codigoconta.ReadOnly = true;
            this.codigoconta.Width = 80;
            // 
            // descricaocontacusto
            // 
            this.descricaocontacusto.DataPropertyName = "descricaoconta";
            this.descricaocontacusto.HeaderText = "Descrição";
            this.descricaocontacusto.Name = "descricaocontacusto";
            this.descricaocontacusto.ReadOnly = true;
            // 
            // aplicacaodescricao
            // 
            this.aplicacaodescricao.DataPropertyName = "descricaoaplicacao";
            this.aplicacaodescricao.HeaderText = "Aplicação";
            this.aplicacaodescricao.Name = "aplicacaodescricao";
            this.aplicacaodescricao.ReadOnly = true;
            // 
            // valorrateio
            // 
            this.valorrateio.DataPropertyName = "valorrateio";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.valorrateio.DefaultCellStyle = dataGridViewCellStyle9;
            this.valorrateio.HeaderText = "Valor Rateio";
            this.valorrateio.Name = "valorrateio";
            this.valorrateio.ReadOnly = true;
            // 
            // percentual
            // 
            this.percentual.DataPropertyName = "percentual";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.percentual.DefaultCellStyle = dataGridViewCellStyle10;
            this.percentual.HeaderText = "Percentual";
            this.percentual.Name = "percentual";
            this.percentual.ReadOnly = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Valor Documento";
            // 
            // txtValorDocumento
            // 
            this.txtValorDocumento.Location = new System.Drawing.Point(6, 137);
            this.txtValorDocumento.Name = "txtValorDocumento";
            this.txtValorDocumento.numeroDecimais = 0;
            this.txtValorDocumento.ReadOnly = true;
            this.txtValorDocumento.Size = new System.Drawing.Size(234, 20);
            this.txtValorDocumento.TabIndex = 31;
            this.txtValorDocumento.Text = "0,00";
            // 
            // frmPagarLiberacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1106, 536);
            this.Controls.Add(this.grdRateio);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.grdLiberacao);
            this.Name = "frmPagarLiberacao";
            this.Text = "Liberação Pagamento";
            this.Load += new System.EventHandler(this.frmPagarLiberacao_Load);
            this.Controls.SetChildIndex(this.grdLiberacao, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.grdRateio, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdLiberacao)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRateio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLiberacao;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtValorParcela;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkValorDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorFinal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorInicio;
        private System.Windows.Forms.CheckBox chkTodasContas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.TextBox txtCodigoFornecedor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIndexador;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Button btnMarcarTodos;
        private System.Windows.Forms.Button btnDesmarcarTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chklibera;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagardocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagarparcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomefornecedor;
        private System.Windows.Forms.TextBox txtDataEmissao;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.TextBox txtNomeFornecedor;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataEntrada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grdRateio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idaplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcontacusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoconta;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaocontacusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicacaodescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorrateio;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentual;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorDocumento;
    }
}
