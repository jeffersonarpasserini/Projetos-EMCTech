namespace EMCCadastro
{
    partial class frmTipoCobranca
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdTipoCobranca = new System.Windows.Forms.DataGridView();
            this.idtipocobranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdTipoCobranca = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAbreviatura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoCobranca)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTipoCobranca
            // 
            this.grdTipoCobranca.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTipoCobranca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTipoCobranca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTipoCobranca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdTipoCobranca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoCobranca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtipocobranca,
            this.descricao});
            this.grdTipoCobranca.Location = new System.Drawing.Point(2, 131);
            this.grdTipoCobranca.MultiSelect = false;
            this.grdTipoCobranca.Name = "grdTipoCobranca";
            this.grdTipoCobranca.ReadOnly = true;
            this.grdTipoCobranca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoCobranca.Size = new System.Drawing.Size(629, 187);
            this.grdTipoCobranca.TabIndex = 10;
            this.grdTipoCobranca.DoubleClick += new System.EventHandler(this.grdTipoCobranca_DoubleClick);
            // 
            // idtipocobranca
            // 
            this.idtipocobranca.DataPropertyName = "idtipocobranca";
            this.idtipocobranca.HeaderText = "Código";
            this.idtipocobranca.Name = "idtipocobranca";
            this.idtipocobranca.ReadOnly = true;
            this.idtipocobranca.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAbreviatura);
            this.panel1.Controls.Add(this.txtIdTipoCobranca);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 9;
            // 
            // txtIdTipoCobranca
            // 
            this.txtIdTipoCobranca.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdTipoCobranca.Location = new System.Drawing.Point(10, 23);
            this.txtIdTipoCobranca.Mask = "00000";
            this.txtIdTipoCobranca.Name = "txtIdTipoCobranca";
            this.txtIdTipoCobranca.PromptChar = ' ';
            this.txtIdTipoCobranca.Size = new System.Drawing.Size(63, 20);
            this.txtIdTipoCobranca.TabIndex = 11;
            this.txtIdTipoCobranca.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdTipoCobranca.ValidatingType = typeof(int);
            this.txtIdTipoCobranca.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdTipoCobranca_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo Cobrança";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 45;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(436, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Abreviatura";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviatura.Location = new System.Drawing.Point(518, 23);
            this.txtAbreviatura.MaxLength = 10;
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(102, 20);
            this.txtAbreviatura.TabIndex = 3;
            // 
            // frmTipoCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 321);
            this.Controls.Add(this.grdTipoCobranca);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmTipoCobranca";
            this.Text = "Tipo Cobranca";
            this.Load += new System.EventHandler(this.frmTipoCobranca_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdTipoCobranca, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoCobranca)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTipoCobranca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipocobranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.MaskedTextBox txtIdTipoCobranca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAbreviatura;
    }
}
