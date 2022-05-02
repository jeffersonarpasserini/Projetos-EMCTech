namespace EMCFinanceiro
{
    partial class frmFechaCaixa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCtaBancaria = new System.Windows.Forms.ComboBox();
            this.grdAberturas = new System.Windows.Forms.DataGridView();
            this.grdMovimento = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuarioResponsavel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtaabertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtafechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdoinicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdofechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcaixacontrole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conferido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioresponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioconferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idctabancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkFechaCaixa = new System.Windows.Forms.CheckBox();
            this.txtSaldoCaixa = new MaskedNumber.MaskedNumber();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSdoCtaCaixa = new MaskedNumber.MaskedNumber();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdControleCaixa = new System.Windows.Forms.TextBox();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idmovimentobancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcaixacontrolefecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datamovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valormovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomepessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAberturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovimento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboCtaBancaria);
            this.panel1.Location = new System.Drawing.Point(2, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 49);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Conta Caixa";
            // 
            // cboCtaBancaria
            // 
            this.cboCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCtaBancaria.FormattingEnabled = true;
            this.cboCtaBancaria.Location = new System.Drawing.Point(7, 20);
            this.cboCtaBancaria.Name = "cboCtaBancaria";
            this.cboCtaBancaria.Size = new System.Drawing.Size(510, 21);
            this.cboCtaBancaria.TabIndex = 6;
            this.cboCtaBancaria.SelectedIndexChanged += new System.EventHandler(this.cboCtaBancaria_SelectedIndexChanged);
            // 
            // grdAberturas
            // 
            this.grdAberturas.AllowUserToAddRows = false;
            this.grdAberturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAberturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtaabertura,
            this.dtafechamento,
            this.sdoinicial,
            this.sdofechamento,
            this.responsavel,
            this.idcaixacontrole,
            this.conferido,
            this.fechado,
            this.usuarioresponsavel,
            this.usuarioconferencia,
            this.ctabancaria_idctabancaria,
            this.ctabancaria_idempresa});
            this.grdAberturas.Location = new System.Drawing.Point(2, 146);
            this.grdAberturas.Name = "grdAberturas";
            this.grdAberturas.ReadOnly = true;
            this.grdAberturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAberturas.Size = new System.Drawing.Size(733, 109);
            this.grdAberturas.TabIndex = 2;
            this.grdAberturas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAberturas_CellValueChanged);
            this.grdAberturas.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdAberturas_CurrentCellDirtyStateChanged);
            this.grdAberturas.DoubleClick += new System.EventHandler(this.grdAberturas_DoubleClick);
            // 
            // grdMovimento
            // 
            this.grdMovimento.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdMovimento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdMovimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMovimento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.idmovimentobancario,
            this.idcaixacontrolefecha,
            this.datamovimento,
            this.valormovimento,
            this.tipomovimento,
            this.nomepessoa});
            this.grdMovimento.Location = new System.Drawing.Point(2, 277);
            this.grdMovimento.Name = "grdMovimento";
            this.grdMovimento.Size = new System.Drawing.Size(733, 217);
            this.grdMovimento.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aberturas de Caixa no Período";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Lançamentos";
            // 
            // txtUsuarioResponsavel
            // 
            this.txtUsuarioResponsavel.Location = new System.Drawing.Point(5, 516);
            this.txtUsuarioResponsavel.Name = "txtUsuarioResponsavel";
            this.txtUsuarioResponsavel.ReadOnly = true;
            this.txtUsuarioResponsavel.Size = new System.Drawing.Size(334, 20);
            this.txtUsuarioResponsavel.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 500);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Usuário Responsável";
            // 
            // dtaabertura
            // 
            this.dtaabertura.DataPropertyName = "dthoraabertura";
            this.dtaabertura.HeaderText = "Data Abertura";
            this.dtaabertura.Name = "dtaabertura";
            this.dtaabertura.ReadOnly = true;
            this.dtaabertura.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtaabertura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dtafechamento
            // 
            this.dtafechamento.DataPropertyName = "dthorafechamento";
            this.dtafechamento.HeaderText = "Data Fechamento";
            this.dtafechamento.Name = "dtafechamento";
            this.dtafechamento.ReadOnly = true;
            this.dtafechamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dtafechamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dtafechamento.Visible = false;
            // 
            // sdoinicial
            // 
            this.sdoinicial.DataPropertyName = "saldoabertura";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = null;
            this.sdoinicial.DefaultCellStyle = dataGridViewCellStyle11;
            this.sdoinicial.HeaderText = "Saldo Abertura";
            this.sdoinicial.Name = "sdoinicial";
            this.sdoinicial.ReadOnly = true;
            this.sdoinicial.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sdoinicial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sdofechamento
            // 
            this.sdofechamento.DataPropertyName = "saldofechamento";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.sdofechamento.DefaultCellStyle = dataGridViewCellStyle12;
            this.sdofechamento.HeaderText = "Saldo Fechamento";
            this.sdofechamento.Name = "sdofechamento";
            this.sdofechamento.ReadOnly = true;
            this.sdofechamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sdofechamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sdofechamento.Width = 120;
            // 
            // responsavel
            // 
            this.responsavel.DataPropertyName = "nome";
            this.responsavel.HeaderText = "Responsável";
            this.responsavel.Name = "responsavel";
            this.responsavel.ReadOnly = true;
            // 
            // idcaixacontrole
            // 
            this.idcaixacontrole.DataPropertyName = "idcaixacontrole";
            this.idcaixacontrole.HeaderText = "idcaixacontrole";
            this.idcaixacontrole.Name = "idcaixacontrole";
            this.idcaixacontrole.ReadOnly = true;
            this.idcaixacontrole.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idcaixacontrole.Visible = false;
            // 
            // conferido
            // 
            this.conferido.DataPropertyName = "conferido";
            this.conferido.HeaderText = "conferido";
            this.conferido.Name = "conferido";
            this.conferido.ReadOnly = true;
            this.conferido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.conferido.Visible = false;
            // 
            // fechado
            // 
            this.fechado.DataPropertyName = "fechado";
            this.fechado.HeaderText = "fechado";
            this.fechado.Name = "fechado";
            this.fechado.ReadOnly = true;
            this.fechado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fechado.Visible = false;
            // 
            // usuarioresponsavel
            // 
            this.usuarioresponsavel.DataPropertyName = "usuarioresponsavel";
            this.usuarioresponsavel.HeaderText = "usuarioresponsavel";
            this.usuarioresponsavel.Name = "usuarioresponsavel";
            this.usuarioresponsavel.ReadOnly = true;
            this.usuarioresponsavel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.usuarioresponsavel.Visible = false;
            // 
            // usuarioconferencia
            // 
            this.usuarioconferencia.DataPropertyName = "usuarioconferencia";
            this.usuarioconferencia.HeaderText = "usuarioconferencia";
            this.usuarioconferencia.Name = "usuarioconferencia";
            this.usuarioconferencia.ReadOnly = true;
            this.usuarioconferencia.Visible = false;
            // 
            // ctabancaria_idctabancaria
            // 
            this.ctabancaria_idctabancaria.DataPropertyName = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.HeaderText = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.Name = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.ReadOnly = true;
            this.ctabancaria_idctabancaria.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctabancaria_idctabancaria.Visible = false;
            // 
            // ctabancaria_idempresa
            // 
            this.ctabancaria_idempresa.DataPropertyName = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.HeaderText = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.Name = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.ReadOnly = true;
            this.ctabancaria_idempresa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ctabancaria_idempresa.Visible = false;
            // 
            // chkFechaCaixa
            // 
            this.chkFechaCaixa.AutoSize = true;
            this.chkFechaCaixa.Location = new System.Drawing.Point(641, 518);
            this.chkFechaCaixa.Name = "chkFechaCaixa";
            this.chkFechaCaixa.Size = new System.Drawing.Size(94, 17);
            this.chkFechaCaixa.TabIndex = 9;
            this.chkFechaCaixa.Text = "Fecha o Caixa";
            this.chkFechaCaixa.UseVisualStyleBackColor = true;
            // 
            // txtSaldoCaixa
            // 
            this.txtSaldoCaixa.CustomFormat = "0:0";
            this.txtSaldoCaixa.Enabled = false;
            this.txtSaldoCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSaldoCaixa.Format = MaskedNumberFormat.Moeda;
            this.txtSaldoCaixa.Location = new System.Drawing.Point(500, 516);
            this.txtSaldoCaixa.Name = "txtSaldoCaixa";
            this.txtSaldoCaixa.ReadOnly = true;
            this.txtSaldoCaixa.Size = new System.Drawing.Size(131, 20);
            this.txtSaldoCaixa.TabIndex = 98;
            this.txtSaldoCaixa.Text = "R$ 0,00";
            this.txtSaldoCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(497, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 99;
            this.label15.Text = "Saldo Fechamento";
            // 
            // txtSdoCtaCaixa
            // 
            this.txtSdoCtaCaixa.CustomFormat = "0:0";
            this.txtSdoCtaCaixa.Enabled = false;
            this.txtSdoCtaCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSdoCtaCaixa.Format = MaskedNumberFormat.Moeda;
            this.txtSdoCtaCaixa.Location = new System.Drawing.Point(363, 515);
            this.txtSdoCtaCaixa.Name = "txtSdoCtaCaixa";
            this.txtSdoCtaCaixa.ReadOnly = true;
            this.txtSdoCtaCaixa.Size = new System.Drawing.Size(131, 20);
            this.txtSdoCtaCaixa.TabIndex = 100;
            this.txtSdoCtaCaixa.Text = "R$ 0,00";
            this.txtSdoCtaCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 499);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Saldo Conta Caixa";
            // 
            // txtIdControleCaixa
            // 
            this.txtIdControleCaixa.Location = new System.Drawing.Point(607, 95);
            this.txtIdControleCaixa.Name = "txtIdControleCaixa";
            this.txtIdControleCaixa.Size = new System.Drawing.Size(100, 20);
            this.txtIdControleCaixa.TabIndex = 102;
            this.txtIdControleCaixa.Visible = false;
            // 
            // chk
            // 
            this.chk.HeaderText = "Cf";
            this.chk.Name = "chk";
            this.chk.Width = 40;
            // 
            // idmovimentobancario
            // 
            this.idmovimentobancario.DataPropertyName = "idmovimentobancario";
            this.idmovimentobancario.HeaderText = "idmovimentobancario";
            this.idmovimentobancario.Name = "idmovimentobancario";
            this.idmovimentobancario.Visible = false;
            // 
            // idcaixacontrolefecha
            // 
            this.idcaixacontrolefecha.DataPropertyName = "idcaixacontrole";
            this.idcaixacontrolefecha.HeaderText = "idcaixacontrole";
            this.idcaixacontrolefecha.Name = "idcaixacontrolefecha";
            this.idcaixacontrolefecha.Visible = false;
            // 
            // datamovimento
            // 
            this.datamovimento.DataPropertyName = "datamovimento";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.datamovimento.DefaultCellStyle = dataGridViewCellStyle8;
            this.datamovimento.HeaderText = "Data";
            this.datamovimento.Name = "datamovimento";
            this.datamovimento.ReadOnly = true;
            // 
            // valormovimento
            // 
            this.valormovimento.DataPropertyName = "valormovimento";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.valormovimento.DefaultCellStyle = dataGridViewCellStyle9;
            this.valormovimento.HeaderText = "Valor";
            this.valormovimento.Name = "valormovimento";
            this.valormovimento.ReadOnly = true;
            // 
            // tipomovimento
            // 
            this.tipomovimento.DataPropertyName = "tipomovimento";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tipomovimento.DefaultCellStyle = dataGridViewCellStyle10;
            this.tipomovimento.HeaderText = "Tipo";
            this.tipomovimento.Name = "tipomovimento";
            this.tipomovimento.ReadOnly = true;
            this.tipomovimento.Width = 40;
            // 
            // nomepessoa
            // 
            this.nomepessoa.DataPropertyName = "nominal";
            this.nomepessoa.HeaderText = "Nome";
            this.nomepessoa.Name = "nomepessoa";
            this.nomepessoa.ReadOnly = true;
            this.nomepessoa.Width = 300;
            // 
            // frmFechaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(739, 539);
            this.Controls.Add(this.txtIdControleCaixa);
            this.Controls.Add(this.txtSdoCtaCaixa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaldoCaixa);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkFechaCaixa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUsuarioResponsavel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdMovimento);
            this.Controls.Add(this.grdAberturas);
            this.Controls.Add(this.panel1);
            this.Name = "frmFechaCaixa";
            this.Text = "Fechamento do Caixa";
            this.Load += new System.EventHandler(this.frmFechaCaixa_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdAberturas, 0);
            this.Controls.SetChildIndex(this.grdMovimento, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtUsuarioResponsavel, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.chkFechaCaixa, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtSaldoCaixa, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSdoCtaCaixa, 0);
            this.Controls.SetChildIndex(this.txtIdControleCaixa, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAberturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCtaBancaria;
        private System.Windows.Forms.DataGridView grdAberturas;
        private System.Windows.Forms.DataGridView grdMovimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuarioResponsavel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtaabertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtafechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdoinicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdofechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcaixacontrole;
        private System.Windows.Forms.DataGridViewTextBoxColumn conferido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechado;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioresponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioconferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idctabancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idempresa;
        private System.Windows.Forms.CheckBox chkFechaCaixa;
        private MaskedNumber.MaskedNumber txtSaldoCaixa;
        private System.Windows.Forms.Label label15;
        private MaskedNumber.MaskedNumber txtSdoCtaCaixa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdControleCaixa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmovimentobancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcaixacontrolefecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn datamovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valormovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomepessoa;
    }
}
