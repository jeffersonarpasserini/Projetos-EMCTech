namespace EMCFinanceiro
{
    partial class frmEmissaoCheques
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdCheque = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrocheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datacheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datapredatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorcheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idchequeemitir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmovimentobancario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idctabancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctabancaria_idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.predatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compensado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idformulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdCtaBancaria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContaBancaria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.cboFormulario = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cboImpressora = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheque)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCheque
            // 
            this.grdCheque.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCheque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCheque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.nrocheque,
            this.datacheque,
            this.datapredatado,
            this.valorcheque,
            this.descricao,
            this.nominal,
            this.idchequeemitir,
            this.idmovimentobancario,
            this.idempresa,
            this.idctabancaria,
            this.ctabancaria_idempresa,
            this.predatado,
            this.compensado,
            this.idformulario});
            this.grdCheque.Location = new System.Drawing.Point(4, 134);
            this.grdCheque.Name = "grdCheque";
            this.grdCheque.Size = new System.Drawing.Size(913, 325);
            this.grdCheque.TabIndex = 1;
            // 
            // status
            // 
            this.status.HeaderText = "Emite";
            this.status.Name = "status";
            this.status.Width = 40;
            // 
            // nrocheque
            // 
            this.nrocheque.DataPropertyName = "nrocheque";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.nrocheque.DefaultCellStyle = dataGridViewCellStyle2;
            this.nrocheque.HeaderText = "Nro Cheque";
            this.nrocheque.Name = "nrocheque";
            this.nrocheque.ReadOnly = true;
            this.nrocheque.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nrocheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // datacheque
            // 
            this.datacheque.DataPropertyName = "datacheque";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.datacheque.DefaultCellStyle = dataGridViewCellStyle3;
            this.datacheque.HeaderText = "Data";
            this.datacheque.Name = "datacheque";
            this.datacheque.ReadOnly = true;
            // 
            // datapredatado
            // 
            this.datapredatado.DataPropertyName = "datapredatado";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.datapredatado.DefaultCellStyle = dataGridViewCellStyle4;
            this.datapredatado.HeaderText = "Data Pré";
            this.datapredatado.Name = "datapredatado";
            this.datapredatado.ReadOnly = true;
            // 
            // valorcheque
            // 
            this.valorcheque.DataPropertyName = "valorcheque";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.valorcheque.DefaultCellStyle = dataGridViewCellStyle5;
            this.valorcheque.HeaderText = "Valor";
            this.valorcheque.Name = "valorcheque";
            this.valorcheque.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Conta";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 150;
            // 
            // nominal
            // 
            this.nominal.DataPropertyName = "nominal";
            this.nominal.HeaderText = "Nominal";
            this.nominal.Name = "nominal";
            this.nominal.ReadOnly = true;
            this.nominal.Width = 250;
            // 
            // idchequeemitir
            // 
            this.idchequeemitir.DataPropertyName = "idchequeemitir";
            this.idchequeemitir.HeaderText = "idchequeemitir";
            this.idchequeemitir.Name = "idchequeemitir";
            this.idchequeemitir.ReadOnly = true;
            this.idchequeemitir.Visible = false;
            // 
            // idmovimentobancario
            // 
            this.idmovimentobancario.DataPropertyName = "idmovimentobancario";
            this.idmovimentobancario.HeaderText = "idmovimentobancario";
            this.idmovimentobancario.Name = "idmovimentobancario";
            this.idmovimentobancario.ReadOnly = true;
            this.idmovimentobancario.Visible = false;
            // 
            // idempresa
            // 
            this.idempresa.DataPropertyName = "idempresa";
            this.idempresa.HeaderText = "idempresa";
            this.idempresa.Name = "idempresa";
            this.idempresa.ReadOnly = true;
            this.idempresa.Visible = false;
            // 
            // idctabancaria
            // 
            this.idctabancaria.DataPropertyName = "idctabancaria";
            this.idctabancaria.HeaderText = "idctabancaria";
            this.idctabancaria.Name = "idctabancaria";
            this.idctabancaria.ReadOnly = true;
            this.idctabancaria.Visible = false;
            // 
            // ctabancaria_idempresa
            // 
            this.ctabancaria_idempresa.DataPropertyName = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.HeaderText = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.Name = "ctabancaria_idempresa";
            this.ctabancaria_idempresa.Visible = false;
            // 
            // predatado
            // 
            this.predatado.DataPropertyName = "predatado";
            this.predatado.HeaderText = "predatado";
            this.predatado.Name = "predatado";
            this.predatado.ReadOnly = true;
            this.predatado.Visible = false;
            // 
            // compensado
            // 
            this.compensado.DataPropertyName = "compensado";
            this.compensado.HeaderText = "compensado";
            this.compensado.Name = "compensado";
            this.compensado.ReadOnly = true;
            this.compensado.Visible = false;
            // 
            // idformulario
            // 
            this.idformulario.DataPropertyName = "formulario_idformulario";
            this.idformulario.HeaderText = "Formulario";
            this.idformulario.Name = "idformulario";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIdCtaBancaria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtContaBancaria);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNroDocumento);
            this.panel1.Controls.Add(this.cboFormulario);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 56);
            this.panel1.TabIndex = 2;
            // 
            // txtIdCtaBancaria
            // 
            this.txtIdCtaBancaria.Location = new System.Drawing.Point(365, 4);
            this.txtIdCtaBancaria.Name = "txtIdCtaBancaria";
            this.txtIdCtaBancaria.Size = new System.Drawing.Size(85, 20);
            this.txtIdCtaBancaria.TabIndex = 8;
            this.txtIdCtaBancaria.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Conta Bancária";
            // 
            // txtContaBancaria
            // 
            this.txtContaBancaria.Location = new System.Drawing.Point(263, 28);
            this.txtContaBancaria.Name = "txtContaBancaria";
            this.txtContaBancaria.ReadOnly = true;
            this.txtContaBancaria.Size = new System.Drawing.Size(259, 20);
            this.txtContaBancaria.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Número";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Formulário";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(527, 28);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.ReadOnly = true;
            this.txtNroDocumento.Size = new System.Drawing.Size(102, 20);
            this.txtNroDocumento.TabIndex = 2;
            // 
            // cboFormulario
            // 
            this.cboFormulario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormulario.FormattingEnabled = true;
            this.cboFormulario.Location = new System.Drawing.Point(7, 27);
            this.cboFormulario.Name = "cboFormulario";
            this.cboFormulario.Size = new System.Drawing.Size(253, 21);
            this.cboFormulario.TabIndex = 1;
            this.cboFormulario.Validating += new System.ComponentModel.CancelEventHandler(this.cboFormulario_Validating);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboImpressora);
            this.panel2.Location = new System.Drawing.Point(633, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 66);
            this.panel2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Impressora";
            // 
            // cboImpressora
            // 
            this.cboImpressora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImpressora.FormattingEnabled = true;
            this.cboImpressora.Location = new System.Drawing.Point(4, 32);
            this.cboImpressora.Name = "cboImpressora";
            this.cboImpressora.Size = new System.Drawing.Size(274, 21);
            this.cboImpressora.TabIndex = 6;
            // 
            // frmEmissaoCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(921, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdCheque);
            this.Name = "frmEmissaoCheques";
            this.Text = "Contas a Pagar - Emissão de Cheques";
            this.Load += new System.EventHandler(this.frmEmissaoCheques_Load);
            this.Controls.SetChildIndex(this.grdCheque, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheque)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCheque;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.ComboBox cboFormulario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContaBancaria;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboImpressora;
        private System.Windows.Forms.TextBox txtIdCtaBancaria;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn datacheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn datapredatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorcheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idchequeemitir;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmovimentobancario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idctabancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctabancaria_idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn predatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn compensado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idformulario;
    }
}
