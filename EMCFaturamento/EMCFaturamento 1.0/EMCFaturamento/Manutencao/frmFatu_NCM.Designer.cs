namespace EMCFaturamento
{
    partial class frmFatu_NCM
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
            this.grdFatu_NCM = new System.Windows.Forms.DataGridView();
            this.idfatu_ncm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroncm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classificacaofiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroNCM = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidFatu_NCM = new System.Windows.Forms.TextBox();
            this.txtClassificacaoFiscal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_NCM)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_NCM
            // 
            this.grdFatu_NCM.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_NCM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFatu_NCM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_NCM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_NCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_NCM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_ncm,
            this.descricao,
            this.situacao,
            this.nroncm,
            this.classificacaofiscal});
            this.grdFatu_NCM.Location = new System.Drawing.Point(3, 168);
            this.grdFatu_NCM.MultiSelect = false;
            this.grdFatu_NCM.Name = "grdFatu_NCM";
            this.grdFatu_NCM.ReadOnly = true;
            this.grdFatu_NCM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_NCM.Size = new System.Drawing.Size(629, 211);
            this.grdFatu_NCM.TabIndex = 23;
            this.grdFatu_NCM.DoubleClick += new System.EventHandler(this.grdFatu_NCM_DoubleClick);
            // 
            // idfatu_ncm
            // 
            this.idfatu_ncm.DataPropertyName = "idfatu_ncm";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_ncm.DefaultCellStyle = dataGridViewCellStyle2;
            this.idfatu_ncm.HeaderText = "Código";
            this.idfatu_ncm.Name = "idfatu_ncm";
            this.idfatu_ncm.ReadOnly = true;
            this.idfatu_ncm.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 74;
            // 
            // nroncm
            // 
            this.nroncm.DataPropertyName = "nroncm";
            this.nroncm.HeaderText = "NCM";
            this.nroncm.Name = "nroncm";
            this.nroncm.ReadOnly = true;
            this.nroncm.Width = 56;
            // 
            // classificacaofiscal
            // 
            this.classificacaofiscal.DataPropertyName = "classificacaofiscal";
            this.classificacaofiscal.HeaderText = "Class. Fiscal";
            this.classificacaofiscal.Name = "classificacaofiscal";
            this.classificacaofiscal.ReadOnly = true;
            this.classificacaofiscal.Width = 90;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNroNCM);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboSituacao);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidFatu_NCM);
            this.panel1.Controls.Add(this.txtClassificacaoFiscal);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 90);
            this.panel1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "NCM";
            // 
            // txtNroNCM
            // 
            this.txtNroNCM.Location = new System.Drawing.Point(7, 63);
            this.txtNroNCM.Mask = "0000,00,00";
            this.txtNroNCM.Name = "txtNroNCM";
            this.txtNroNCM.Size = new System.Drawing.Size(65, 20);
            this.txtNroNCM.TabIndex = 4;
            this.txtNroNCM.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNroNCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroNCM_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Situação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // cboSituacao
            // 
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(532, 23);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(85, 21);
            this.cboSituacao.TabIndex = 3;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(75, 23);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(452, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Class. Fiscal";
            // 
            // txtidFatu_NCM
            // 
            this.txtidFatu_NCM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_NCM.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_NCM.MaxLength = 50;
            this.txtidFatu_NCM.Name = "txtidFatu_NCM";
            this.txtidFatu_NCM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_NCM.Size = new System.Drawing.Size(63, 20);
            this.txtidFatu_NCM.TabIndex = 1;
            this.txtidFatu_NCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidFatu_NCM_KeyPress);
            this.txtidFatu_NCM.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_NCM_Validating);
            // 
            // txtClassificacaoFiscal
            // 
            this.txtClassificacaoFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtClassificacaoFiscal.Location = new System.Drawing.Point(79, 63);
            this.txtClassificacaoFiscal.MaxLength = 2;
            this.txtClassificacaoFiscal.Name = "txtClassificacaoFiscal";
            this.txtClassificacaoFiscal.Size = new System.Drawing.Size(62, 20);
            this.txtClassificacaoFiscal.TabIndex = 5;
            this.txtClassificacaoFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmFatu_NCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 382);
            this.Controls.Add(this.grdFatu_NCM);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_NCM";
            this.Text = "Classificação Fiscal | NCM";
            this.Load += new System.EventHandler(this.frmFatu_NCM_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_NCM, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_NCM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_NCM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtNroNCM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidFatu_NCM;
        private System.Windows.Forms.TextBox txtClassificacaoFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_ncm;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroncm;
        private System.Windows.Forms.DataGridViewTextBoxColumn classificacaofiscal;
    }
}
