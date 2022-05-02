namespace EMCCadastro
{
    partial class frmIndexador
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
            this.grdIndexador = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdIndexador = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIndexador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSimbolo = new System.Windows.Forms.TextBox();
            this.cboTipoIndexador = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndexador)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdIndexador
            // 
            this.grdIndexador.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdIndexador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdIndexador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdIndexador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdIndexador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIndexador.Location = new System.Drawing.Point(2, 131);
            this.grdIndexador.MultiSelect = false;
            this.grdIndexador.Name = "grdIndexador";
            this.grdIndexador.ReadOnly = true;
            this.grdIndexador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIndexador.Size = new System.Drawing.Size(629, 187);
            this.grdIndexador.TabIndex = 8;
            this.grdIndexador.DoubleClick += new System.EventHandler(this.grdIndexador_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboTipoIndexador);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSimbolo);
            this.panel1.Controls.Add(this.txtIdIndexador);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIndexador);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 5;
            // 
            // txtIdIndexador
            // 
            this.txtIdIndexador.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdIndexador.Location = new System.Drawing.Point(10, 23);
            this.txtIdIndexador.Mask = "00000";
            this.txtIdIndexador.Name = "txtIdIndexador";
            this.txtIdIndexador.PromptChar = ' ';
            this.txtIdIndexador.Size = new System.Drawing.Size(47, 20);
            this.txtIdIndexador.TabIndex = 0;
            this.txtIdIndexador.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdIndexador.ValidatingType = typeof(int);
            this.txtIdIndexador.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdIndexador_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Indexador";
            // 
            // txtIndexador
            // 
            this.txtIndexador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIndexador.Location = new System.Drawing.Point(60, 23);
            this.txtIndexador.MaxLength = 45;
            this.txtIndexador.Name = "txtIndexador";
            this.txtIndexador.Size = new System.Drawing.Size(357, 20);
            this.txtIndexador.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Abreviatura";
            // 
            // txtSimbolo
            // 
            this.txtSimbolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSimbolo.Location = new System.Drawing.Point(553, 23);
            this.txtSimbolo.MaxLength = 5;
            this.txtSimbolo.Name = "txtSimbolo";
            this.txtSimbolo.Size = new System.Drawing.Size(71, 20);
            this.txtSimbolo.TabIndex = 3;
            // 
            // cboTipoIndexador
            // 
            this.cboTipoIndexador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoIndexador.FormattingEnabled = true;
            this.cboTipoIndexador.Location = new System.Drawing.Point(419, 23);
            this.cboTipoIndexador.Name = "cboTipoIndexador";
            this.cboTipoIndexador.Size = new System.Drawing.Size(132, 21);
            this.cboTipoIndexador.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo Indexador";
            // 
            // frmIndexador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 321);
            this.Controls.Add(this.grdIndexador);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmIndexador";
            this.Text = "Indexador";
            this.Load += new System.EventHandler(this.frmIndexador_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdIndexador, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdIndexador)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdIndexador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIndexador;
        private System.Windows.Forms.MaskedTextBox txtIdIndexador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipoIndexador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSimbolo;
    }
}
