namespace EMCFinanceiro
{
    partial class frmMovimentoBancario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboIdPessoa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHistorico = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorMovimento = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoMovimento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataMovimento = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDocumentoOrigem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.txtIdMovimentoBancario = new System.Windows.Forms.TextBox();
            this.grdMovimentoBancario = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIdContaBancaria = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.datamovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valormovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.Sample.DecimalTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovimentoBancario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIdPessoa);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboIdPessoa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNominal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtHistorico);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtValorMovimento);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboTipoMovimento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDataMovimento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDocumentoOrigem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDocumento);
            this.panel1.Location = new System.Drawing.Point(2, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 176);
            this.panel1.TabIndex = 1;
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.Location = new System.Drawing.Point(7, 107);
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(65, 20);
            this.txtIdPessoa.TabIndex = 8;
            this.txtIdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPessoa_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Pessoa";
            // 
            // cboIdPessoa
            // 
            this.cboIdPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboIdPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIdPessoa.FormattingEnabled = true;
            this.cboIdPessoa.Location = new System.Drawing.Point(78, 107);
            this.cboIdPessoa.Name = "cboIdPessoa";
            this.cboIdPessoa.Size = new System.Drawing.Size(576, 21);
            this.cboIdPessoa.TabIndex = 9;
            this.cboIdPessoa.SelectedValueChanged += new System.EventHandler(this.cboIdPessoa_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Nominal";
            // 
            // txtNominal
            // 
            this.txtNominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNominal.Location = new System.Drawing.Point(7, 146);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(647, 20);
            this.txtNominal.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Histórico";
            // 
            // txtHistorico
            // 
            this.txtHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHistorico.Location = new System.Drawing.Point(7, 67);
            this.txtHistorico.Name = "txtHistorico";
            this.txtHistorico.Size = new System.Drawing.Size(647, 20);
            this.txtHistorico.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(519, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Valor Movimento";
            // 
            // txtValorMovimento
            // 
            this.txtValorMovimento.Location = new System.Drawing.Point(522, 29);
            this.txtValorMovimento.Name = "txtValorMovimento";
            this.txtValorMovimento.Size = new System.Drawing.Size(132, 20);
            this.txtValorMovimento.TabIndex = 6;
            this.txtValorMovimento.Text = "0,00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo Movimento";
            // 
            // cboTipoMovimento
            // 
            this.cboTipoMovimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimento.FormattingEnabled = true;
            this.cboTipoMovimento.Location = new System.Drawing.Point(389, 28);
            this.cboTipoMovimento.Name = "cboTipoMovimento";
            this.cboTipoMovimento.Size = new System.Drawing.Size(127, 21);
            this.cboTipoMovimento.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Lançamento";
            // 
            // txtDataMovimento
            // 
            this.txtDataMovimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataMovimento.Location = new System.Drawing.Point(291, 29);
            this.txtDataMovimento.Name = "txtDataMovimento";
            this.txtDataMovimento.Size = new System.Drawing.Size(92, 20);
            this.txtDataMovimento.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Documento Origem";
            // 
            // txtDocumentoOrigem
            // 
            this.txtDocumentoOrigem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumentoOrigem.Location = new System.Drawing.Point(165, 29);
            this.txtDocumentoOrigem.Name = "txtDocumentoOrigem";
            this.txtDocumentoOrigem.Size = new System.Drawing.Size(117, 20);
            this.txtDocumentoOrigem.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Documento";
            // 
            // txtDocumento
            // 
            this.txtDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocumento.Location = new System.Drawing.Point(7, 29);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(152, 20);
            this.txtDocumento.TabIndex = 0;
            this.txtDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtDocumento_Validating);
            // 
            // txtIdMovimentoBancario
            // 
            this.txtIdMovimentoBancario.Location = new System.Drawing.Point(97, 79);
            this.txtIdMovimentoBancario.Name = "txtIdMovimentoBancario";
            this.txtIdMovimentoBancario.Size = new System.Drawing.Size(100, 20);
            this.txtIdMovimentoBancario.TabIndex = 31;
            this.txtIdMovimentoBancario.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdMovimentoBancario_Validating);
            // 
            // grdMovimentoBancario
            // 
            this.grdMovimentoBancario.AllowUserToAddRows = false;
            this.grdMovimentoBancario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMovimentoBancario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datamovimento,
            this.documento,
            this.valormovimento,
            this.tipomovimento,
            this.historico,
            this.idmovimento});
            this.grdMovimentoBancario.Location = new System.Drawing.Point(2, 310);
            this.grdMovimentoBancario.MultiSelect = false;
            this.grdMovimentoBancario.Name = "grdMovimentoBancario";
            this.grdMovimentoBancario.ReadOnly = true;
            this.grdMovimentoBancario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMovimentoBancario.Size = new System.Drawing.Size(657, 224);
            this.grdMovimentoBancario.TabIndex = 2;
            this.grdMovimentoBancario.DoubleClick += new System.EventHandler(this.grdMovimentoBancario_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Conta Bancaria";
            // 
            // cboIdContaBancaria
            // 
            this.cboIdContaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdContaBancaria.FormattingEnabled = true;
            this.cboIdContaBancaria.Location = new System.Drawing.Point(5, 101);
            this.cboIdContaBancaria.Name = "cboIdContaBancaria";
            this.cboIdContaBancaria.Size = new System.Drawing.Size(233, 21);
            this.cboIdContaBancaria.TabIndex = 10;
            this.cboIdContaBancaria.SelectedValueChanged += new System.EventHandler(this.cboIdContaBancaria_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(241, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Data Inicio";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(241, 103);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(92, 20);
            this.txtDataInicio.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Data Final";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(339, 102);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(92, 20);
            this.txtDataFinal.TabIndex = 34;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnPesquisa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisa.Location = new System.Drawing.Point(573, 101);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(86, 24);
            this.btnPesquisa.TabIndex = 36;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // datamovimento
            // 
            this.datamovimento.DataPropertyName = "datamovimento";
            this.datamovimento.HeaderText = "Data Movimento";
            this.datamovimento.Name = "datamovimento";
            this.datamovimento.ReadOnly = true;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            this.documento.HeaderText = "Documento";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // valormovimento
            // 
            this.valormovimento.DataPropertyName = "valormovimento";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.valormovimento.DefaultCellStyle = dataGridViewCellStyle7;
            this.valormovimento.HeaderText = "Valor";
            this.valormovimento.Name = "valormovimento";
            this.valormovimento.ReadOnly = true;
            // 
            // tipomovimento
            // 
            this.tipomovimento.DataPropertyName = "tipomovimento";
            this.tipomovimento.HeaderText = "D/C";
            this.tipomovimento.Name = "tipomovimento";
            this.tipomovimento.ReadOnly = true;
            this.tipomovimento.Width = 30;
            // 
            // historico
            // 
            this.historico.DataPropertyName = "historico";
            this.historico.HeaderText = "Histórico";
            this.historico.Name = "historico";
            this.historico.ReadOnly = true;
            this.historico.Width = 300;
            // 
            // idmovimento
            // 
            this.idmovimento.DataPropertyName = "idmovimentobancario";
            this.idmovimento.HeaderText = "id";
            this.idmovimento.Name = "idmovimento";
            this.idmovimento.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(427, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Saldo";
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(430, 102);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(142, 21);
            this.txtSaldo.TabIndex = 37;
            this.txtSaldo.Text = "0,00";
            // 
            // frmMovimentoBancario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(661, 535);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboIdContaBancaria);
            this.Controls.Add(this.txtIdMovimentoBancario);
            this.Controls.Add(this.grdMovimentoBancario);
            this.Controls.Add(this.panel1);
            this.Name = "frmMovimentoBancario";
            this.Text = "Movimentação Bancaria";
            this.Load += new System.EventHandler(this.frmMovimentoBancario_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdMovimentoBancario, 0);
            this.Controls.SetChildIndex(this.txtIdMovimentoBancario, 0);
            this.Controls.SetChildIndex(this.cboIdContaBancaria, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtDataInicio, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtDataFinal, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.btnPesquisa, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovimentoBancario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDataMovimento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDocumentoOrigem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTipoMovimento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHistorico;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorMovimento;
        private System.Windows.Forms.TextBox txtIdMovimentoBancario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNominal;
        private System.Windows.Forms.DataGridView grdMovimentoBancario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboIdContaBancaria;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIdPessoa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn datamovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valormovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmovimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Sample.DecimalTextBox txtSaldo;
    }
}
