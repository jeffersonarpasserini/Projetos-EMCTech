namespace EMCCadastro
{
    partial class frmHistorico
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.grdHistorico = new System.Windows.Forms.DataGridView();
            this.cboExigeComplemento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdHistorico = new System.Windows.Forms.MaskedTextBox();
            this.idhistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomehistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exigecomplemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 99);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(458, 20);
            this.txtDescricao.TabIndex = 7;
            // 
            // grdHistorico
            // 
            this.grdHistorico.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdHistorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idhistorico,
            this.nomehistorico,
            this.exigecomplemento});
            this.grdHistorico.Location = new System.Drawing.Point(3, 134);
            this.grdHistorico.Name = "grdHistorico";
            this.grdHistorico.ReadOnly = true;
            this.grdHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdHistorico.Size = new System.Drawing.Size(629, 191);
            this.grdHistorico.TabIndex = 7;
            this.grdHistorico.DoubleClick += new System.EventHandler(this.grdHistorico_DoubleClick);
            // 
            // cboExigeComplemento
            // 
            this.cboExigeComplemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExigeComplemento.FormattingEnabled = true;
            this.cboExigeComplemento.Location = new System.Drawing.Point(542, 98);
            this.cboExigeComplemento.Name = "cboExigeComplemento";
            this.cboExigeComplemento.Size = new System.Drawing.Size(86, 21);
            this.cboExigeComplemento.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(539, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Complemento";
            // 
            // txtIdHistorico
            // 
            this.txtIdHistorico.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdHistorico.Location = new System.Drawing.Point(9, 99);
            this.txtIdHistorico.Mask = "00000";
            this.txtIdHistorico.Name = "txtIdHistorico";
            this.txtIdHistorico.PromptChar = ' ';
            this.txtIdHistorico.Size = new System.Drawing.Size(64, 20);
            this.txtIdHistorico.TabIndex = 13;
            this.txtIdHistorico.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdHistorico.ValidatingType = typeof(int);
            this.txtIdHistorico.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdHistorico_Validating);
            // 
            // idhistorico
            // 
            this.idhistorico.DataPropertyName = "idhistorico";
            this.idhistorico.HeaderText = "Código";
            this.idhistorico.Name = "idhistorico";
            this.idhistorico.ReadOnly = true;
            this.idhistorico.Width = 66;
            // 
            // nomehistorico
            // 
            this.nomehistorico.DataPropertyName = "descricao";
            this.nomehistorico.HeaderText = "Descrição";
            this.nomehistorico.Name = "nomehistorico";
            this.nomehistorico.ReadOnly = true;
            this.nomehistorico.Width = 420;
            // 
            // exigecomplemento
            // 
            this.exigecomplemento.DataPropertyName = "exigecomplemento";
            this.exigecomplemento.HeaderText = "Complemento";
            this.exigecomplemento.Name = "exigecomplemento";
            this.exigecomplemento.ReadOnly = true;
            // 
            // frmHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.txtIdHistorico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboExigeComplemento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.grdHistorico);
            this.MinimizeBox = false;
            this.Name = "frmHistorico";
            this.Text = "Histórico de Lançamentos";
            this.Load += new System.EventHandler(this.frmHistorico_Load);
            this.Controls.SetChildIndex(this.grdHistorico, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cboExigeComplemento, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtIdHistorico, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView grdHistorico;
        private System.Windows.Forms.ComboBox cboExigeComplemento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtIdHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn idhistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomehistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn exigecomplemento;
    }
}
