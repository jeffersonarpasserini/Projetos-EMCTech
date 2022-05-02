namespace EMCCadastro
{
    partial class frmContato
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboRecado = new System.Windows.Forms.ComboBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboTipoTelefone = new System.Windows.Forms.ComboBox();
            this.grdContato = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContato)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTelefone);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.cboRecado);
            this.panel1.Controls.Add(this.txtTelefone);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.cboTipoTelefone);
            this.panel1.Controls.Add(this.grdContato);
            this.panel1.Location = new System.Drawing.Point(2, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 251);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Recado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo Telefone";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(50, 7);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(49, 13);
            this.lblTelefone.TabIndex = 7;
            this.lblTelefone.Text = "Telefone";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(4, 7);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(354, 21);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(274, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // cboRecado
            // 
            this.cboRecado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecado.FormattingEnabled = true;
            this.cboRecado.Location = new System.Drawing.Point(300, 20);
            this.cboRecado.Name = "cboRecado";
            this.cboRecado.Size = new System.Drawing.Size(53, 21);
            this.cboRecado.TabIndex = 4;
            // 
            // txtTelefone
            // 
            this.txtTelefone.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTelefone.Location = new System.Drawing.Point(53, 20);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(114, 20);
            this.txtTelefone.TabIndex = 2;
            this.txtTelefone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(6, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(46, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // cboTipoTelefone
            // 
            this.cboTipoTelefone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTelefone.FormattingEnabled = true;
            this.cboTipoTelefone.Location = new System.Drawing.Point(168, 20);
            this.cboTipoTelefone.Name = "cboTipoTelefone";
            this.cboTipoTelefone.Size = new System.Drawing.Size(131, 21);
            this.cboTipoTelefone.TabIndex = 3;
            // 
            // grdContato
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdContato.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdContato.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.grdContato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContato.Location = new System.Drawing.Point(3, 47);
            this.grdContato.MultiSelect = false;
            this.grdContato.Name = "grdContato";
            this.grdContato.ReadOnly = true;
            this.grdContato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdContato.Size = new System.Drawing.Size(623, 201);
            this.grdContato.TabIndex = 0;
            this.grdContato.DoubleClick += new System.EventHandler(this.grdContato_DoubleClick);
            // 
            // frmContato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(633, 329);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmContato";
            this.Text = "Contatos";
            this.Load += new System.EventHandler(this.frmContato_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdContato;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboRecado;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cboTipoTelefone;
    }
}
