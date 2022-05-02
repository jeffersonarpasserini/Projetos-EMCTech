namespace EMCCadastro
{
    partial class frmTipoDocumento
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
            this.grdTipoDocumento = new System.Windows.Forms.DataGridView();
            this.idtipodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abreviatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdTipoDocumento = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAbreviatura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoDocumento)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTipoDocumento
            // 
            this.grdTipoDocumento.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTipoDocumento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdTipoDocumento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdTipoDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTipoDocumento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtipodocumento,
            this.descricao,
            this.abreviatura});
            this.grdTipoDocumento.Location = new System.Drawing.Point(2, 135);
            this.grdTipoDocumento.MultiSelect = false;
            this.grdTipoDocumento.Name = "grdTipoDocumento";
            this.grdTipoDocumento.ReadOnly = true;
            this.grdTipoDocumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTipoDocumento.Size = new System.Drawing.Size(626, 187);
            this.grdTipoDocumento.TabIndex = 8;
            this.grdTipoDocumento.DoubleClick += new System.EventHandler(this.grdTipoDocumento_DoubleClick);
            // 
            // idtipodocumento
            // 
            this.idtipodocumento.DataPropertyName = "idtipodocumento";
            this.idtipodocumento.HeaderText = "Código";
            this.idtipodocumento.Name = "idtipodocumento";
            this.idtipodocumento.ReadOnly = true;
            this.idtipodocumento.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // abreviatura
            // 
            this.abreviatura.DataPropertyName = "abreviatura";
            this.abreviatura.HeaderText = "Abreviatura";
            this.abreviatura.Name = "abreviatura";
            this.abreviatura.ReadOnly = true;
            this.abreviatura.Width = 86;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIdTipoDocumento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAbreviatura);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 7;
            // 
            // txtIdTipoDocumento
            // 
            this.txtIdTipoDocumento.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdTipoDocumento.Location = new System.Drawing.Point(10, 23);
            this.txtIdTipoDocumento.Mask = "00000";
            this.txtIdTipoDocumento.Name = "txtIdTipoDocumento";
            this.txtIdTipoDocumento.PromptChar = ' ';
            this.txtIdTipoDocumento.Size = new System.Drawing.Size(63, 20);
            this.txtIdTipoDocumento.TabIndex = 9;
            this.txtIdTipoDocumento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdTipoDocumento.ValidatingType = typeof(int);
            this.txtIdTipoDocumento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdTipoDocumento_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Abreviatura";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviatura.Location = new System.Drawing.Point(532, 23);
            this.txtAbreviatura.MaxLength = 6;
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(90, 20);
            this.txtAbreviatura.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo Documento";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(447, 20);
            this.txtDescricao.TabIndex = 8;
            // 
            // frmTipoDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.grdTipoDocumento);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmTipoDocumento";
            this.Text = "Tipo Documento";
            this.Load += new System.EventHandler(this.frmTipoDocumento_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdTipoDocumento, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTipoDocumento)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTipoDocumento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAbreviatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviatura;
        private System.Windows.Forms.MaskedTextBox txtIdTipoDocumento;
    }
}
