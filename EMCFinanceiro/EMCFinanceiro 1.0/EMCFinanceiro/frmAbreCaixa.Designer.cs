namespace EMCFinanceiro
{
    partial class frmAbreCaixa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdControleCaixa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSdoAbertura = new MaskedNumber.MaskedNumber();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCtaBancaria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDtHoraAbertura = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.grdCaixa = new System.Windows.Forms.DataGridView();
            this.dthoraabertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoabertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dthorafechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldofechamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioresponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conferido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcaixacontrole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioconferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idctabancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaixa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIdControleCaixa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSdoAbertura);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboCtaBancaria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDtHoraAbertura);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNomeUsuario);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 102);
            this.panel1.TabIndex = 1;
            // 
            // txtIdControleCaixa
            // 
            this.txtIdControleCaixa.Location = new System.Drawing.Point(113, 4);
            this.txtIdControleCaixa.Name = "txtIdControleCaixa";
            this.txtIdControleCaixa.Size = new System.Drawing.Size(100, 20);
            this.txtIdControleCaixa.TabIndex = 8;
            this.txtIdControleCaixa.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(486, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Saldo Abertura";
            // 
            // txtSdoAbertura
            // 
            this.txtSdoAbertura.CustomFormat = "0:0";
            this.txtSdoAbertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSdoAbertura.Format = MaskedNumberFormat.Moeda;
            this.txtSdoAbertura.Location = new System.Drawing.Point(486, 31);
            this.txtSdoAbertura.Name = "txtSdoAbertura";
            this.txtSdoAbertura.ReadOnly = true;
            this.txtSdoAbertura.Size = new System.Drawing.Size(134, 20);
            this.txtSdoAbertura.TabIndex = 2;
            this.txtSdoAbertura.Text = "R$ 0,00";
            this.txtSdoAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Conta Caixa";
            // 
            // cboCtaBancaria
            // 
            this.cboCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCtaBancaria.FormattingEnabled = true;
            this.cboCtaBancaria.Location = new System.Drawing.Point(10, 30);
            this.cboCtaBancaria.Name = "cboCtaBancaria";
            this.cboCtaBancaria.Size = new System.Drawing.Size(367, 21);
            this.cboCtaBancaria.TabIndex = 0;
            this.cboCtaBancaria.SelectedIndexChanged += new System.EventHandler(this.cboCtaBancaria_SelectedIndexChanged);
            this.cboCtaBancaria.ValueMemberChanged += new System.EventHandler(this.cboCtaBancaria_ValueMemberChanged);
            this.cboCtaBancaria.TextChanged += new System.EventHandler(this.cboCtaBancaria_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data";
            // 
            // txtDtHoraAbertura
            // 
            this.txtDtHoraAbertura.Enabled = false;
            this.txtDtHoraAbertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtHoraAbertura.Location = new System.Drawing.Point(383, 31);
            this.txtDtHoraAbertura.Name = "txtDtHoraAbertura";
            this.txtDtHoraAbertura.Size = new System.Drawing.Size(97, 20);
            this.txtDtHoraAbertura.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Location = new System.Drawing.Point(10, 71);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.ReadOnly = true;
            this.txtNomeUsuario.Size = new System.Drawing.Size(610, 20);
            this.txtNomeUsuario.TabIndex = 3;
            // 
            // grdCaixa
            // 
            this.grdCaixa.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCaixa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dthoraabertura,
            this.saldoabertura,
            this.dthorafechamento,
            this.saldofechamento,
            this.usuarioresponsavel,
            this.fechado,
            this.conferido,
            this.idcaixacontrole,
            this.usuarioconferencia,
            this.ctabancaria_idempresa,
            this.ctabancaria_idctabancaria});
            this.grdCaixa.Location = new System.Drawing.Point(2, 184);
            this.grdCaixa.Name = "grdCaixa";
            this.grdCaixa.ReadOnly = true;
            this.grdCaixa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCaixa.Size = new System.Drawing.Size(629, 177);
            this.grdCaixa.TabIndex = 2;
            this.grdCaixa.DoubleClick += new System.EventHandler(this.grdCaixa_DoubleClick);
            // 
            // dthoraabertura
            // 
            this.dthoraabertura.DataPropertyName = "dthoraabertura";
            this.dthoraabertura.HeaderText = "Data Abertura";
            this.dthoraabertura.Name = "dthoraabertura";
            this.dthoraabertura.ReadOnly = true;
            // 
            // saldoabertura
            // 
            this.saldoabertura.DataPropertyName = "saldoabertura";
            this.saldoabertura.HeaderText = "Saldo Abertura";
            this.saldoabertura.Name = "saldoabertura";
            this.saldoabertura.ReadOnly = true;
            // 
            // dthorafechamento
            // 
            this.dthorafechamento.DataPropertyName = "dthorafechamento";
            this.dthorafechamento.HeaderText = "Data Fechamento";
            this.dthorafechamento.Name = "dthorafechamento";
            this.dthorafechamento.ReadOnly = true;
            // 
            // saldofechamento
            // 
            this.saldofechamento.DataPropertyName = "saldofechamento";
            this.saldofechamento.HeaderText = "Saldo Fechamento";
            this.saldofechamento.Name = "saldofechamento";
            this.saldofechamento.ReadOnly = true;
            // 
            // usuarioresponsavel
            // 
            this.usuarioresponsavel.DataPropertyName = "usuarioresponsavel";
            this.usuarioresponsavel.HeaderText = "Reponsável";
            this.usuarioresponsavel.Name = "usuarioresponsavel";
            this.usuarioresponsavel.ReadOnly = true;
            // 
            // fechado
            // 
            this.fechado.DataPropertyName = "fechado";
            this.fechado.HeaderText = "Fechado";
            this.fechado.Name = "fechado";
            this.fechado.ReadOnly = true;
            // 
            // conferido
            // 
            this.conferido.DataPropertyName = "conferido";
            this.conferido.HeaderText = "Conferido";
            this.conferido.Name = "conferido";
            this.conferido.ReadOnly = true;
            // 
            // idcaixacontrole
            // 
            this.idcaixacontrole.DataPropertyName = "idcaixacontrole";
            this.idcaixacontrole.HeaderText = "idcaixacontrole";
            this.idcaixacontrole.Name = "idcaixacontrole";
            this.idcaixacontrole.ReadOnly = true;
            this.idcaixacontrole.Visible = false;
            // 
            // usuarioconferencia
            // 
            this.usuarioconferencia.DataPropertyName = "usuarioconferencia";
            this.usuarioconferencia.HeaderText = "usuarioconferencia";
            this.usuarioconferencia.Name = "usuarioconferencia";
            this.usuarioconferencia.ReadOnly = true;
            this.usuarioconferencia.Visible = false;
            // 
            // ctabancaria_idempresa
            // 
            this.ctabancaria_idempresa.DataPropertyName = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.HeaderText = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.Name = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.ReadOnly = true;
            this.ctabancaria_idempresa.Visible = false;
            // 
            // ctabancaria_idctabancaria
            // 
            this.ctabancaria_idctabancaria.DataPropertyName = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.HeaderText = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.Name = "ctabancaria_idctabancaria";
            this.ctabancaria_idctabancaria.ReadOnly = true;
            this.ctabancaria_idctabancaria.Visible = false;
            // 
            // frmAbreCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 364);
            this.Controls.Add(this.grdCaixa);
            this.Controls.Add(this.panel1);
            this.Name = "frmAbreCaixa";
            this.Text = "Caixa - Abertura";
            this.Load += new System.EventHandler(this.frmAbreCaixa_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdCaixa, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaixa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private MaskedNumber.MaskedNumber txtSdoAbertura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCtaBancaria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtDtHoraAbertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.DataGridView grdCaixa;
        private System.Windows.Forms.TextBox txtIdControleCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dthoraabertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoabertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn dthorafechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldofechamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioresponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechado;
        private System.Windows.Forms.DataGridViewTextBoxColumn conferido;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcaixacontrole;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioconferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idctabancaria;
    }
}
