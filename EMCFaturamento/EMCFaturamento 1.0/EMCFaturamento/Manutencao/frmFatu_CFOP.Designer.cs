namespace EMCFaturamento
{
    partial class frmFatu_CFOP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdFatu_CFOP = new System.Windows.Forms.DataGridView();
            this.idfatu_cfop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrocfop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroCFOP = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtidFatu_CFOP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_CFOP)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_CFOP
            // 
            this.grdFatu_CFOP.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_CFOP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdFatu_CFOP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_CFOP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_CFOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_CFOP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_cfop,
            this.descricao,
            this.nrocfop});
            this.grdFatu_CFOP.Location = new System.Drawing.Point(3, 192);
            this.grdFatu_CFOP.MultiSelect = false;
            this.grdFatu_CFOP.Name = "grdFatu_CFOP";
            this.grdFatu_CFOP.ReadOnly = true;
            this.grdFatu_CFOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_CFOP.Size = new System.Drawing.Size(629, 253);
            this.grdFatu_CFOP.TabIndex = 25;
            this.grdFatu_CFOP.DoubleClick += new System.EventHandler(this.grdFatu_CFOP_DoubleClick);
            // 
            // idfatu_cfop
            // 
            this.idfatu_cfop.DataPropertyName = "idfatu_cfop";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_cfop.DefaultCellStyle = dataGridViewCellStyle4;
            this.idfatu_cfop.HeaderText = "Código";
            this.idfatu_cfop.Name = "idfatu_cfop";
            this.idfatu_cfop.ReadOnly = true;
            this.idfatu_cfop.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // nrocfop
            // 
            this.nrocfop.DataPropertyName = "nrocfop";
            this.nrocfop.HeaderText = "CFOP";
            this.nrocfop.Name = "nrocfop";
            this.nrocfop.ReadOnly = true;
            this.nrocfop.Width = 60;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNroCFOP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtidFatu_CFOP);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 113);
            this.panel1.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(581, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "CFOP";
            // 
            // txtNroCFOP
            // 
            this.txtNroCFOP.Location = new System.Drawing.Point(580, 23);
            this.txtNroCFOP.Mask = "0,000";
            this.txtNroCFOP.Name = "txtNroCFOP";
            this.txtNroCFOP.Size = new System.Drawing.Size(36, 20);
            this.txtNroCFOP.TabIndex = 4;
            this.txtNroCFOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroCFOP.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNroCFOP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCFOP_KeyPress);
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
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(75, 23);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(499, 20);
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
            // txtidFatu_CFOP
            // 
            this.txtidFatu_CFOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_CFOP.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_CFOP.MaxLength = 50;
            this.txtidFatu_CFOP.Name = "txtidFatu_CFOP";
            this.txtidFatu_CFOP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_CFOP.Size = new System.Drawing.Size(63, 20);
            this.txtidFatu_CFOP.TabIndex = 1;
            this.txtidFatu_CFOP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidFatu_CFOP_KeyPress);
            this.txtidFatu_CFOP.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_CFOP_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacao.Location = new System.Drawing.Point(10, 60);
            this.txtObservacao.MaxLength = 1000;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(606, 46);
            this.txtObservacao.TabIndex = 5;
            // 
            // frmFatu_CFOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 446);
            this.Controls.Add(this.grdFatu_CFOP);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_CFOP";
            this.Text = "CFOP - Código Fiscal da Operação";
            this.Load += new System.EventHandler(this.frmFatu_CFOP_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_CFOP, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_CFOP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_CFOP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtNroCFOP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtidFatu_CFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_cfop;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocfop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacao;
    }
}
