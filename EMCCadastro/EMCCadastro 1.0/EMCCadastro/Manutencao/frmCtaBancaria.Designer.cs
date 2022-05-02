namespace EMCCadastro
{
    partial class frmCtaBancaria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidCtaBancaria = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCedenteDigito = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCedente = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContaDigito = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAgenciaDigito = new System.Windows.Forms.TextBox();
            this.txtLimite = new System.Windows.Forms.Sample.DecimalTextBox();
            this.txtSdoFechamento = new System.Windows.Forms.Sample.DecimalTextBox();
            this.txtSaldoAtual = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVencLimite = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.grdConta = new System.Windows.Forms.DataGridView();
            this.idctabancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agenciadigito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contadigito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitocedente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venclimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datafechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldofechamentp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoatual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDtaFechamento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtConta = new System.Windows.Forms.TextBox();
            this.txtAgencia = new System.Windows.Forms.TextBox();
            this.cboContaCaixa = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cboContaCaixa);
            this.panel1.Controls.Add(this.txtidCtaBancaria);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCedenteDigito);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtCedente);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtContaDigito);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtAgenciaDigito);
            this.panel1.Controls.Add(this.txtLimite);
            this.panel1.Controls.Add(this.txtSdoFechamento);
            this.panel1.Controls.Add(this.txtSaldoAtual);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboBanco);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtVencLimite);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.grdConta);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDtaFechamento);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtConta);
            this.panel1.Controls.Add(this.txtAgencia);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 276);
            this.panel1.TabIndex = 1;
            // 
            // txtidCtaBancaria
            // 
            this.txtidCtaBancaria.BackColor = System.Drawing.SystemColors.Control;
            this.txtidCtaBancaria.Location = new System.Drawing.Point(10, 29);
            this.txtidCtaBancaria.Mask = "00000";
            this.txtidCtaBancaria.Name = "txtidCtaBancaria";
            this.txtidCtaBancaria.PromptChar = ' ';
            this.txtidCtaBancaria.Size = new System.Drawing.Size(60, 20);
            this.txtidCtaBancaria.TabIndex = 6;
            this.txtidCtaBancaria.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidCtaBancaria.ValidatingType = typeof(int);
            this.txtidCtaBancaria.Validating += new System.ComponentModel.CancelEventHandler(this.txtidCtaBancaria_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(592, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "Dg";
            // 
            // txtCedenteDigito
            // 
            this.txtCedenteDigito.Location = new System.Drawing.Point(595, 68);
            this.txtCedenteDigito.MaxLength = 5;
            this.txtCedenteDigito.Name = "txtCedenteDigito";
            this.txtCedenteDigito.Size = new System.Drawing.Size(31, 20);
            this.txtCedenteDigito.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(412, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 103;
            this.label14.Text = "Codigo Cedente";
            // 
            // txtCedente
            // 
            this.txtCedente.Location = new System.Drawing.Point(415, 68);
            this.txtCedente.MaxLength = 20;
            this.txtCedente.Name = "txtCedente";
            this.txtCedente.Size = new System.Drawing.Size(178, 20);
            this.txtCedente.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 101;
            this.label11.Text = "Dg";
            // 
            // txtContaDigito
            // 
            this.txtContaDigito.Location = new System.Drawing.Point(302, 29);
            this.txtContaDigito.MaxLength = 5;
            this.txtContaDigito.Name = "txtContaDigito";
            this.txtContaDigito.Size = new System.Drawing.Size(31, 20);
            this.txtContaDigito.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Dg";
            // 
            // txtAgenciaDigito
            // 
            this.txtAgenciaDigito.Location = new System.Drawing.Point(133, 29);
            this.txtAgenciaDigito.MaxLength = 5;
            this.txtAgenciaDigito.Name = "txtAgenciaDigito";
            this.txtAgenciaDigito.Size = new System.Drawing.Size(31, 20);
            this.txtAgenciaDigito.TabIndex = 8;
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(91, 109);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.numeroDecimais = 0;
            this.txtLimite.Size = new System.Drawing.Size(90, 20);
            this.txtLimite.TabIndex = 16;
            this.txtLimite.Text = "0,00";
            // 
            // txtSdoFechamento
            // 
            this.txtSdoFechamento.Enabled = false;
            this.txtSdoFechamento.Location = new System.Drawing.Point(264, 108);
            this.txtSdoFechamento.Name = "txtSdoFechamento";
            this.txtSdoFechamento.numeroDecimais = 0;
            this.txtSdoFechamento.Size = new System.Drawing.Size(102, 20);
            this.txtSdoFechamento.TabIndex = 18;
            this.txtSdoFechamento.Text = "0,00";
            // 
            // txtSaldoAtual
            // 
            this.txtSaldoAtual.Enabled = false;
            this.txtSaldoAtual.Location = new System.Drawing.Point(368, 108);
            this.txtSaldoAtual.Name = "txtSaldoAtual";
            this.txtSaldoAtual.numeroDecimais = 0;
            this.txtSaldoAtual.Size = new System.Drawing.Size(110, 20);
            this.txtSaldoAtual.TabIndex = 19;
            this.txtSaldoAtual.Text = "0,00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 97;
            this.label8.Text = "Banco";
            // 
            // cboBanco
            // 
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(340, 29);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(284, 21);
            this.cboBanco.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Agência";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Conta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 93;
            this.label1.Text = "Código";
            // 
            // txtVencLimite
            // 
            this.txtVencLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtVencLimite.Location = new System.Drawing.Point(7, 109);
            this.txtVencLimite.Name = "txtVencLimite";
            this.txtVencLimite.Size = new System.Drawing.Size(84, 20);
            this.txtVencLimite.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(368, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "Sdo Atual";
            // 
            // grdConta
            // 
            this.grdConta.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdConta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdConta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdConta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdConta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idctabancaria,
            this.descricao,
            this.banco,
            this.agencia,
            this.agenciadigito,
            this.conta,
            this.contadigito,
            this.cedente,
            this.digitocedente,
            this.venclimite,
            this.limite,
            this.datafechamento,
            this.saldofechamentp,
            this.saldoatual,
            this.idempresa,
            this.idbanco,
            this.empresa});
            this.grdConta.Location = new System.Drawing.Point(3, 134);
            this.grdConta.MultiSelect = false;
            this.grdConta.Name = "grdConta";
            this.grdConta.ReadOnly = true;
            this.grdConta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConta.Size = new System.Drawing.Size(623, 136);
            this.grdConta.TabIndex = 20;
            this.grdConta.DoubleClick += new System.EventHandler(this.grdConta_DoubleClick);
            // 
            // idctabancaria
            // 
            this.idctabancaria.DataPropertyName = "idctabancaria";
            this.idctabancaria.HeaderText = "Código";
            this.idctabancaria.Name = "idctabancaria";
            this.idctabancaria.ReadOnly = true;
            this.idctabancaria.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // banco
            // 
            this.banco.DataPropertyName = "descricaobanco";
            this.banco.HeaderText = "Banco";
            this.banco.Name = "banco";
            this.banco.ReadOnly = true;
            this.banco.Width = 63;
            // 
            // agencia
            // 
            this.agencia.DataPropertyName = "agencia";
            this.agencia.HeaderText = "Agência";
            this.agencia.Name = "agencia";
            this.agencia.ReadOnly = true;
            this.agencia.Width = 71;
            // 
            // agenciadigito
            // 
            this.agenciadigito.DataPropertyName = "agenciadigito";
            this.agenciadigito.HeaderText = "Dg Agência";
            this.agenciadigito.Name = "agenciadigito";
            this.agenciadigito.ReadOnly = true;
            this.agenciadigito.Width = 81;
            // 
            // conta
            // 
            this.conta.DataPropertyName = "conta";
            this.conta.HeaderText = "Conta";
            this.conta.Name = "conta";
            this.conta.ReadOnly = true;
            this.conta.Width = 60;
            // 
            // contadigito
            // 
            this.contadigito.DataPropertyName = "contadigito";
            this.contadigito.HeaderText = "Dg Conta";
            this.contadigito.Name = "contadigito";
            this.contadigito.ReadOnly = true;
            this.contadigito.Width = 71;
            // 
            // cedente
            // 
            this.cedente.DataPropertyName = "cedente";
            this.cedente.HeaderText = "Cedente";
            this.cedente.Name = "cedente";
            this.cedente.ReadOnly = true;
            this.cedente.Width = 72;
            // 
            // digitocedente
            // 
            this.digitocedente.DataPropertyName = "cedentedigito";
            this.digitocedente.HeaderText = "Dg Cedente";
            this.digitocedente.Name = "digitocedente";
            this.digitocedente.ReadOnly = true;
            this.digitocedente.Width = 82;
            // 
            // venclimite
            // 
            this.venclimite.DataPropertyName = "venclimite";
            this.venclimite.HeaderText = "Vencimento Limite";
            this.venclimite.Name = "venclimite";
            this.venclimite.ReadOnly = true;
            this.venclimite.Width = 108;
            // 
            // limite
            // 
            this.limite.DataPropertyName = "limite";
            this.limite.HeaderText = "Limite";
            this.limite.Name = "limite";
            this.limite.ReadOnly = true;
            this.limite.Width = 59;
            // 
            // datafechamento
            // 
            this.datafechamento.DataPropertyName = "dtafechamento";
            this.datafechamento.HeaderText = "Fechamento";
            this.datafechamento.Name = "datafechamento";
            this.datafechamento.ReadOnly = true;
            this.datafechamento.Width = 91;
            // 
            // saldofechamentp
            // 
            this.saldofechamentp.DataPropertyName = "saldofechamento";
            this.saldofechamentp.HeaderText = "Saldo Fechamento";
            this.saldofechamentp.Name = "saldofechamentp";
            this.saldofechamentp.ReadOnly = true;
            this.saldofechamentp.Width = 111;
            // 
            // saldoatual
            // 
            this.saldoatual.DataPropertyName = "saldoatual";
            this.saldoatual.HeaderText = "Saldo Atual";
            this.saldoatual.Name = "saldoatual";
            this.saldoatual.ReadOnly = true;
            this.saldoatual.Width = 79;
            // 
            // idempresa
            // 
            this.idempresa.DataPropertyName = "idempresa";
            this.idempresa.HeaderText = "idempresa";
            this.idempresa.Name = "idempresa";
            this.idempresa.ReadOnly = true;
            this.idempresa.Visible = false;
            this.idempresa.Width = 80;
            // 
            // idbanco
            // 
            this.idbanco.DataPropertyName = "idbanco";
            this.idbanco.HeaderText = "idbanco";
            this.idbanco.Name = "idbanco";
            this.idbanco.ReadOnly = true;
            this.idbanco.Visible = false;
            this.idbanco.Width = 70;
            // 
            // empresa
            // 
            this.empresa.DataPropertyName = "empresa";
            this.empresa.HeaderText = "Empresa";
            this.empresa.Name = "empresa";
            this.empresa.ReadOnly = true;
            this.empresa.Width = 73;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "Formulários";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Sdo Fecham.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Dta Fecham.";
            // 
            // txtDtaFechamento
            // 
            this.txtDtaFechamento.Enabled = false;
            this.txtDtaFechamento.Location = new System.Drawing.Point(185, 108);
            this.txtDtaFechamento.Mask = "00/00/0000";
            this.txtDtaFechamento.Name = "txtDtaFechamento";
            this.txtDtaFechamento.ReadOnly = true;
            this.txtDtaFechamento.Size = new System.Drawing.Size(75, 20);
            this.txtDtaFechamento.TabIndex = 17;
            this.txtDtaFechamento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDtaFechamento.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Limite";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 86;
            this.label13.Text = "Venc. Limite";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 85;
            this.label7.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(10, 68);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(399, 20);
            this.txtDescricao.TabIndex = 12;
            // 
            // txtConta
            // 
            this.txtConta.Location = new System.Drawing.Point(170, 29);
            this.txtConta.MaxLength = 10;
            this.txtConta.Name = "txtConta";
            this.txtConta.Size = new System.Drawing.Size(130, 20);
            this.txtConta.TabIndex = 9;
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(76, 29);
            this.txtAgencia.MaxLength = 10;
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Size = new System.Drawing.Size(56, 20);
            this.txtAgencia.TabIndex = 7;
            // 
            // cboContaCaixa
            // 
            this.cboContaCaixa.FormattingEnabled = true;
            this.cboContaCaixa.Location = new System.Drawing.Point(481, 107);
            this.cboContaCaixa.Name = "cboContaCaixa";
            this.cboContaCaixa.Size = new System.Drawing.Size(73, 21);
            this.cboContaCaixa.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(478, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 13);
            this.label15.TabIndex = 107;
            this.label15.Text = "Cta Caixa ?";
            // 
            // frmCtaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 357);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCtaBancaria";
            this.Text = "Conta Bancária";
            this.Load += new System.EventHandler(this.frmCtaBancaria_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtVencLimite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grdConta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtDtaFechamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtConta;
        private System.Windows.Forms.TextBox txtAgencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Sample.DecimalTextBox txtLimite;
        private System.Windows.Forms.Sample.DecimalTextBox txtSdoFechamento;
        private System.Windows.Forms.Sample.DecimalTextBox txtSaldoAtual;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCedenteDigito;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCedente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtContaDigito;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAgenciaDigito;
        private System.Windows.Forms.MaskedTextBox txtidCtaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idctabancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn agenciadigito;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn contadigito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedente;
        private System.Windows.Forms.DataGridViewTextBoxColumn digitocedente;
        private System.Windows.Forms.DataGridViewTextBoxColumn venclimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn datafechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldofechamentp;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoatual;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboContaCaixa;
    }
}
