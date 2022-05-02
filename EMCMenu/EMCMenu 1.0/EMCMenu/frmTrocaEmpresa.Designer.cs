namespace EMCMenu
{
    partial class frmTrocaEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrocaEmpresa));
            this.cboEmpresaUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btmEntrar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboEmpresaUsuario
            // 
            this.cboEmpresaUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresaUsuario.FormattingEnabled = true;
            this.cboEmpresaUsuario.Location = new System.Drawing.Point(5, 82);
            this.cboEmpresaUsuario.Name = "cboEmpresaUsuario";
            this.cboEmpresaUsuario.Size = new System.Drawing.Size(408, 21);
            this.cboEmpresaUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empresa";
            // 
            // btmEntrar
            // 
            this.btmEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btmEntrar.Image")));
            this.btmEntrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btmEntrar.Location = new System.Drawing.Point(306, 109);
            this.btmEntrar.Name = "btmEntrar";
            this.btmEntrar.Size = new System.Drawing.Size(107, 39);
            this.btmEntrar.TabIndex = 2;
            this.btmEntrar.Text = "Entrar";
            this.btmEntrar.UseVisualStyleBackColor = true;
            this.btmEntrar.Click += new System.EventHandler(this.btmEntrar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(5, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(91, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuário Atual :";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(5, 33);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(96, 13);
            this.lblEmpresa.TabIndex = 4;
            this.lblEmpresa.Text = "Empresa Atual :";
            // 
            // frmTrocaEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 157);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btmEntrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmpresaUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTrocaEmpresa";
            this.Text = "Troca Empresa";
            this.Load += new System.EventHandler(this.frmTrocaEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEmpresaUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmEntrar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEmpresa;
    }
}