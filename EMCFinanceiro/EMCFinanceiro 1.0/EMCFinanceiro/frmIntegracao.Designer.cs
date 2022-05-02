namespace EMCFinanceiro
{
    partial class frmIntegracao
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
            this.grdIntegracao = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSistema = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkReceber = new System.Windows.Forms.CheckBox();
            this.chkPagar = new System.Windows.Forms.CheckBox();
            this.chkdocumento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sistema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipointegracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomepessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idintegracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdIntegracao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdIntegracao
            // 
            this.grdIntegracao.AllowUserToAddRows = false;
            this.grdIntegracao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdIntegracao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIntegracao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIntegracao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkdocumento,
            this.sistema,
            this.sessao,
            this.tipointegracao,
            this.nrodocumento,
            this.datavencimento,
            this.valordocumento,
            this.nomepessoa,
            this.idpessoa,
            this.idintegracao});
            this.grdIntegracao.Location = new System.Drawing.Point(2, 141);
            this.grdIntegracao.Name = "grdIntegracao";
            this.grdIntegracao.Size = new System.Drawing.Size(927, 298);
            this.grdIntegracao.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboSistema);
            this.groupBox1.Location = new System.Drawing.Point(2, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro -Sistema";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sistema";
            // 
            // cboSistema
            // 
            this.cboSistema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistema.FormattingEnabled = true;
            this.cboSistema.Location = new System.Drawing.Point(5, 34);
            this.cboSistema.Name = "cboSistema";
            this.cboSistema.Size = new System.Drawing.Size(202, 21);
            this.cboSistema.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkReceber);
            this.groupBox2.Controls.Add(this.chkPagar);
            this.groupBox2.Location = new System.Drawing.Point(216, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 63);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro -Tipo Lançamento";
            // 
            // chkReceber
            // 
            this.chkReceber.AutoSize = true;
            this.chkReceber.Checked = true;
            this.chkReceber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReceber.Location = new System.Drawing.Point(81, 34);
            this.chkReceber.Name = "chkReceber";
            this.chkReceber.Size = new System.Drawing.Size(86, 17);
            this.chkReceber.TabIndex = 1;
            this.chkReceber.Text = "Cta Receber";
            this.chkReceber.UseVisualStyleBackColor = true;
            // 
            // chkPagar
            // 
            this.chkPagar.AutoSize = true;
            this.chkPagar.Checked = true;
            this.chkPagar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPagar.Location = new System.Drawing.Point(6, 34);
            this.chkPagar.Name = "chkPagar";
            this.chkPagar.Size = new System.Drawing.Size(73, 17);
            this.chkPagar.TabIndex = 0;
            this.chkPagar.Text = "Cta Pagar";
            this.chkPagar.UseVisualStyleBackColor = true;
            // 
            // chkdocumento
            // 
            this.chkdocumento.FalseValue = "false";
            this.chkdocumento.HeaderText = "Ck";
            this.chkdocumento.Name = "chkdocumento";
            this.chkdocumento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkdocumento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chkdocumento.TrueValue = "true";
            this.chkdocumento.Width = 30;
            // 
            // sistema
            // 
            this.sistema.HeaderText = "Sistema";
            this.sistema.Name = "sistema";
            this.sistema.ReadOnly = true;
            // 
            // sessao
            // 
            this.sessao.HeaderText = "Sessão";
            this.sessao.Name = "sessao";
            this.sessao.ReadOnly = true;
            // 
            // tipointegracao
            // 
            this.tipointegracao.HeaderText = "TP";
            this.tipointegracao.Name = "tipointegracao";
            this.tipointegracao.ReadOnly = true;
            this.tipointegracao.Width = 30;
            // 
            // nrodocumento
            // 
            this.nrodocumento.HeaderText = "Documento";
            this.nrodocumento.Name = "nrodocumento";
            this.nrodocumento.ReadOnly = true;
            this.nrodocumento.Width = 150;
            // 
            // datavencimento
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.datavencimento.DefaultCellStyle = dataGridViewCellStyle2;
            this.datavencimento.HeaderText = "Vencimento";
            this.datavencimento.Name = "datavencimento";
            this.datavencimento.ReadOnly = true;
            // 
            // valordocumento
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valordocumento.DefaultCellStyle = dataGridViewCellStyle3;
            this.valordocumento.HeaderText = "Valor";
            this.valordocumento.Name = "valordocumento";
            this.valordocumento.ReadOnly = true;
            // 
            // nomepessoa
            // 
            this.nomepessoa.HeaderText = "Nome";
            this.nomepessoa.Name = "nomepessoa";
            this.nomepessoa.ReadOnly = true;
            this.nomepessoa.Width = 200;
            // 
            // idpessoa
            // 
            this.idpessoa.HeaderText = "Id";
            this.idpessoa.Name = "idpessoa";
            this.idpessoa.ReadOnly = true;
            this.idpessoa.Visible = false;
            // 
            // idintegracao
            // 
            this.idintegracao.HeaderText = "idintegracao";
            this.idintegracao.Name = "idintegracao";
            this.idintegracao.Visible = false;
            // 
            // frmIntegracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(931, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdIntegracao);
            this.Name = "frmIntegracao";
            this.Text = "Integração Documentos";
            this.Load += new System.EventHandler(this.frmIntegracao_Load);
            this.Controls.SetChildIndex(this.grdIntegracao, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdIntegracao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdIntegracao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSistema;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkReceber;
        private System.Windows.Forms.CheckBox chkPagar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkdocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipointegracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomepessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idintegracao;
    }
}
