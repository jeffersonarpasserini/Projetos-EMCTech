namespace EMCImob
{
    partial class frmTipoLanctoCaptacao
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
            this.grdTipoLanctoCaptacao = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoLancamento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidTipoLanctoCaptacao = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.idTipoLanctoCaptacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoLancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoLanctoCaptacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTipoLanctoCaptacao
            // 
            this.grdTipoLanctoCaptacao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTipoLanctoCaptacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTipoLanctoCaptacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTipoLanctoCaptacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdTipoLanctoCaptacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoLanctoCaptacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idTipoLanctoCaptacao,
            this.descricao,
            this.TipoLancamento});
            this.grdTipoLanctoCaptacao.Location = new System.Drawing.Point(2, 132);
            this.grdTipoLanctoCaptacao.MultiSelect = false;
            this.grdTipoLanctoCaptacao.Name = "grdTipoLanctoCaptacao";
            this.grdTipoLanctoCaptacao.ReadOnly = true;
            this.grdTipoLanctoCaptacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoLanctoCaptacao.Size = new System.Drawing.Size(626, 194);
            this.grdTipoLanctoCaptacao.TabIndex = 13;
            this.grdTipoLanctoCaptacao.DoubleClick += new System.EventHandler(this.grdTipoLanctoCaptacao_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTipoLancamento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidTipoLanctoCaptacao);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 53);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(456, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lançamento";
            // 
            // cboTipoLancamento
            // 
            this.cboTipoLancamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoLancamento.FormattingEnabled = true;
            this.cboTipoLancamento.Items.AddRange(new object[] {
            "Teste",
            "Teste_2",
            "Teste_3"});
            this.cboTipoLancamento.Location = new System.Drawing.Point(456, 21);
            this.cboTipoLancamento.Name = "cboTipoLancamento";
            this.cboTipoLancamento.Size = new System.Drawing.Size(165, 21);
            this.cboTipoLancamento.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de Lançamento";
            // 
            // txtidTipoLanctoCaptacao
            // 
            this.txtidTipoLanctoCaptacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidTipoLanctoCaptacao.Location = new System.Drawing.Point(10, 22);
            this.txtidTipoLanctoCaptacao.MaxLength = 50;
            this.txtidTipoLanctoCaptacao.Name = "txtidTipoLanctoCaptacao";
            this.txtidTipoLanctoCaptacao.Size = new System.Drawing.Size(53, 20);
            this.txtidTipoLanctoCaptacao.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(64, 22);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(390, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // idTipoLanctoCaptacao
            // 
            this.idTipoLanctoCaptacao.DataPropertyName = "idtipolanctocaptacao";
            this.idTipoLanctoCaptacao.HeaderText = "Código";
            this.idTipoLanctoCaptacao.Name = "idTipoLanctoCaptacao";
            this.idTipoLanctoCaptacao.ReadOnly = true;
            this.idTipoLanctoCaptacao.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // TipoLancamento
            // 
            this.TipoLancamento.DataPropertyName = "tipolancamento";
            this.TipoLancamento.HeaderText = "Lançamento";
            this.TipoLancamento.Name = "TipoLancamento";
            this.TipoLancamento.ReadOnly = true;
            this.TipoLancamento.Width = 91;
            // 
            // frmTipoLanctoCaptacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(636, 329);
            this.Controls.Add(this.grdTipoLanctoCaptacao);
            this.Controls.Add(this.panel1);
            this.Name = "frmTipoLanctoCaptacao";
            this.Text = "Tabela de Tipos de Lançamentos de Captação";
            this.Load += new System.EventHandler(this.frmTipoLanctoCaptacao_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdTipoLanctoCaptacao, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoLanctoCaptacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTipoLanctoCaptacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidTipoLanctoCaptacao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoLancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoLanctoCaptacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLancamento;
    }
}
