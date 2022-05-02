namespace EMCCadastro
{
    partial class frmContaCusto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.txtIdContaCusto = new System.Windows.Forms.TextBox();
            this.grdContaCusto = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContaCusto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtCodigoConta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboEmpresa);
            this.panel1.Controls.Add(this.txtIdContaCusto);
            this.panel1.Controls.Add(this.grdContaCusto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 305);
            this.panel1.TabIndex = 3;
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(7, 25);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConta.TabIndex = 7;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoConta_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filial";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(7, 70);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(618, 21);
            this.cboEmpresa.TabIndex = 9;
            // 
            // txtIdContaCusto
            // 
            this.txtIdContaCusto.Location = new System.Drawing.Point(459, 0);
            this.txtIdContaCusto.Name = "txtIdContaCusto";
            this.txtIdContaCusto.Size = new System.Drawing.Size(89, 20);
            this.txtIdContaCusto.TabIndex = 6;
            this.txtIdContaCusto.Visible = false;
            // 
            // grdContaCusto
            // 
            this.grdContaCusto.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdContaCusto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdContaCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdContaCusto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdContaCusto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContaCusto.Location = new System.Drawing.Point(4, 97);
            this.grdContaCusto.MultiSelect = false;
            this.grdContaCusto.Name = "grdContaCusto";
            this.grdContaCusto.ReadOnly = true;
            this.grdContaCusto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdContaCusto.Size = new System.Drawing.Size(617, 201);
            this.grdContaCusto.TabIndex = 10;
            this.grdContaCusto.DoubleClick += new System.EventHandler(this.grdContaCusto_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(110, 25);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(515, 20);
            this.txtDescricao.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número Conta";
            // 
            // frmContaCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 384);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmContaCusto";
            this.Text = "Plano de Contas de Custos";
            this.Load += new System.EventHandler(this.frmContaCusto_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContaCusto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdContaCusto;
        private System.Windows.Forms.TextBox txtIdContaCusto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;

    }
}
