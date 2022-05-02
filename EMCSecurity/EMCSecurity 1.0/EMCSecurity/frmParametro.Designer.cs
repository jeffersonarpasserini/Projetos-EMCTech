namespace EMCSecurity
{
    partial class frmParametro
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
            this.txtIdParametro = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.grdParametro = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtChave = new System.Windows.Forms.TextBox();
            this.txtSessao = new System.Windows.Forms.TextBox();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.idparametro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoparametro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParametro)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdParametro
            // 
            this.txtIdParametro.Location = new System.Drawing.Point(647, 46);
            this.txtIdParametro.Name = "txtIdParametro";
            this.txtIdParametro.Size = new System.Drawing.Size(105, 20);
            this.txtIdParametro.TabIndex = 2;
            this.txtIdParametro.TextChanged += new System.EventHandler(this.txtIdParametro_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cboTipo);
            this.panel1.Controls.Add(this.grdParametro);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.txtChave);
            this.panel1.Controls.Add(this.txtSessao);
            this.panel1.Controls.Add(this.txtAplicacao);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 336);
            this.panel1.TabIndex = 3;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(514, 15);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(197, 21);
            this.cboTipo.TabIndex = 7;
            // 
            // grdParametro
            // 
            this.grdParametro.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdParametro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdParametro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdParametro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdParametro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idparametro,
            this.codigoempresa,
            this.aplicacao,
            this.sessao,
            this.chave,
            this.tipo,
            this.valor,
            this.descricaoparametro});
            this.grdParametro.Location = new System.Drawing.Point(2, 71);
            this.grdParametro.Name = "grdParametro";
            this.grdParametro.ReadOnly = true;
            this.grdParametro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdParametro.Size = new System.Drawing.Size(866, 260);
            this.grdParametro.TabIndex = 17;
            this.grdParametro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdParametro_CellContentClick);
            this.grdParametro.DoubleClick += new System.EventHandler(this.grdParametro_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Descrição";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(717, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Valor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Chave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sessão";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Aplicação";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(2, 49);
            this.txtDescricao.MaxLength = 500;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(866, 20);
            this.txtDescricao.TabIndex = 9;
            // 
            // txtValor
            // 
            this.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValor.Location = new System.Drawing.Point(717, 15);
            this.txtValor.MaxLength = 20;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(151, 20);
            this.txtValor.TabIndex = 8;
            // 
            // txtChave
            // 
            this.txtChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtChave.Location = new System.Drawing.Point(329, 14);
            this.txtChave.MaxLength = 20;
            this.txtChave.Name = "txtChave";
            this.txtChave.Size = new System.Drawing.Size(181, 20);
            this.txtChave.TabIndex = 6;
            this.txtChave.Validating += new System.ComponentModel.CancelEventHandler(this.txtChave_Validating);
            // 
            // txtSessao
            // 
            this.txtSessao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSessao.Location = new System.Drawing.Point(165, 14);
            this.txtSessao.MaxLength = 20;
            this.txtSessao.Name = "txtSessao";
            this.txtSessao.Size = new System.Drawing.Size(161, 20);
            this.txtSessao.TabIndex = 5;
            this.txtSessao.Validating += new System.ComponentModel.CancelEventHandler(this.txtSessao_Validating);
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAplicacao.Location = new System.Drawing.Point(2, 14);
            this.txtAplicacao.MaxLength = 20;
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.Size = new System.Drawing.Size(160, 20);
            this.txtAplicacao.TabIndex = 4;
            this.txtAplicacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtAplicacao_Validating);
            // 
            // idparametro
            // 
            this.idparametro.DataPropertyName = "idparametro";
            this.idparametro.HeaderText = "Cod Parametro";
            this.idparametro.Name = "idparametro";
            this.idparametro.ReadOnly = true;
            // 
            // codigoempresa
            // 
            this.codigoempresa.DataPropertyName = "codempresa";
            this.codigoempresa.HeaderText = "Cod Empresa";
            this.codigoempresa.Name = "codigoempresa";
            this.codigoempresa.ReadOnly = true;
            this.codigoempresa.Width = 95;
            // 
            // aplicacao
            // 
            this.aplicacao.DataPropertyName = "aplicacao";
            this.aplicacao.HeaderText = "Aplicação";
            this.aplicacao.Name = "aplicacao";
            this.aplicacao.ReadOnly = true;
            this.aplicacao.Width = 120;
            // 
            // sessao
            // 
            this.sessao.DataPropertyName = "sessao";
            this.sessao.HeaderText = "Sessão";
            this.sessao.Name = "sessao";
            this.sessao.ReadOnly = true;
            this.sessao.Width = 120;
            // 
            // chave
            // 
            this.chave.DataPropertyName = "chave";
            this.chave.HeaderText = "Chave";
            this.chave.Name = "chave";
            this.chave.ReadOnly = true;
            this.chave.Width = 150;
            // 
            // tipo
            // 
            this.tipo.DataPropertyName = "tipo";
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Width = 40;
            // 
            // valor
            // 
            this.valor.DataPropertyName = "valor";
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 50;
            // 
            // descricaoparametro
            // 
            this.descricaoparametro.DataPropertyName = "descricao";
            this.descricaoparametro.HeaderText = "Descrição";
            this.descricaoparametro.Name = "descricaoparametro";
            this.descricaoparametro.ReadOnly = true;
            this.descricaoparametro.Width = 330;
            // 
            // frmParametro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(877, 410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdParametro);
            this.Name = "frmParametro";
            this.Text = "Parametro";
            this.Load += new System.EventHandler(this.frmParametro_Load);
            this.Controls.SetChildIndex(this.txtIdParametro, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParametro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdParametro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtChave;
        private System.Windows.Forms.TextBox txtSessao;
        private System.Windows.Forms.TextBox txtAplicacao;
        private System.Windows.Forms.DataGridView grdParametro;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparametro;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn aplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessao;
        private System.Windows.Forms.DataGridViewTextBoxColumn chave;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoparametro;
    }
}
