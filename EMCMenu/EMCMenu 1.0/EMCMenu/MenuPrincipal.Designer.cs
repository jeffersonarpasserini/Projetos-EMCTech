namespace EMCMenu
{
    partial class MenuPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnTrocaEmpresa = new System.Windows.Forms.Button();
            this.btnSeguranca = new System.Windows.Forms.Button();
            this.btnObras = new System.Windows.Forms.Button();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.btnImob = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnFaturamento = new System.Windows.Forms.Button();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.lblIdentificaLogin = new System.Windows.Forms.Label();
            this.lblIdentificaUsuario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnTrocaEmpresa);
            this.panel1.Controls.Add(this.btnSeguranca);
            this.panel1.Controls.Add(this.btnObras);
            this.panel1.Controls.Add(this.btnFinanceiro);
            this.panel1.Controls.Add(this.btnImob);
            this.panel1.Controls.Add(this.btnEstoque);
            this.panel1.Controls.Add(this.btnFaturamento);
            this.panel1.Controls.Add(this.btnCadastro);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 613);
            this.panel1.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(3, 583);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(97, 27);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnTrocaEmpresa
            // 
            this.btnTrocaEmpresa.Location = new System.Drawing.Point(3, 551);
            this.btnTrocaEmpresa.Name = "btnTrocaEmpresa";
            this.btnTrocaEmpresa.Size = new System.Drawing.Size(97, 27);
            this.btnTrocaEmpresa.TabIndex = 7;
            this.btnTrocaEmpresa.Text = "Troca Empresa";
            this.btnTrocaEmpresa.UseVisualStyleBackColor = true;
            this.btnTrocaEmpresa.Click += new System.EventHandler(this.btnTrocaEmpresa_Click);
            // 
            // btnSeguranca
            // 
            this.btnSeguranca.Location = new System.Drawing.Point(4, 233);
            this.btnSeguranca.Name = "btnSeguranca";
            this.btnSeguranca.Size = new System.Drawing.Size(97, 40);
            this.btnSeguranca.TabIndex = 6;
            this.btnSeguranca.Text = "&Segurança";
            this.btnSeguranca.UseVisualStyleBackColor = true;
            this.btnSeguranca.Click += new System.EventHandler(this.btnSeguranca_Click);
            // 
            // btnObras
            // 
            this.btnObras.Location = new System.Drawing.Point(3, 187);
            this.btnObras.Name = "btnObras";
            this.btnObras.Size = new System.Drawing.Size(97, 40);
            this.btnObras.TabIndex = 5;
            this.btnObras.Text = "&Obras";
            this.btnObras.UseVisualStyleBackColor = true;
            this.btnObras.Click += new System.EventHandler(this.btnObras_Click);
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.Location = new System.Drawing.Point(3, 51);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(97, 40);
            this.btnFinanceiro.TabIndex = 4;
            this.btnFinanceiro.Text = "&Financeiro";
            this.btnFinanceiro.UseVisualStyleBackColor = true;
            this.btnFinanceiro.Click += new System.EventHandler(this.btnFinanceiro_Click);
            // 
            // btnImob
            // 
            this.btnImob.Location = new System.Drawing.Point(3, 278);
            this.btnImob.Name = "btnImob";
            this.btnImob.Size = new System.Drawing.Size(97, 40);
            this.btnImob.TabIndex = 3;
            this.btnImob.Text = "&Imóveis";
            this.btnImob.UseVisualStyleBackColor = true;
            this.btnImob.Click += new System.EventHandler(this.btnImob_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.Location = new System.Drawing.Point(3, 97);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(97, 40);
            this.btnEstoque.TabIndex = 2;
            this.btnEstoque.Text = "&Estoque";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // btnFaturamento
            // 
            this.btnFaturamento.Location = new System.Drawing.Point(3, 143);
            this.btnFaturamento.Name = "btnFaturamento";
            this.btnFaturamento.Size = new System.Drawing.Size(97, 40);
            this.btnFaturamento.TabIndex = 1;
            this.btnFaturamento.Text = "F&aturamento";
            this.btnFaturamento.UseVisualStyleBackColor = true;
            this.btnFaturamento.Click += new System.EventHandler(this.btnFaturamento_Click);
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(3, 5);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(97, 40);
            this.btnCadastro.TabIndex = 0;
            this.btnCadastro.Text = "&Cadastros";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1270, 24);
            this.mnuPrincipal.TabIndex = 2;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // lblIdentificaLogin
            // 
            this.lblIdentificaLogin.AutoSize = true;
            this.lblIdentificaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificaLogin.Location = new System.Drawing.Point(113, 58);
            this.lblIdentificaLogin.Name = "lblIdentificaLogin";
            this.lblIdentificaLogin.Size = new System.Drawing.Size(0, 24);
            this.lblIdentificaLogin.TabIndex = 4;
            this.lblIdentificaLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIdentificaUsuario
            // 
            this.lblIdentificaUsuario.AutoSize = true;
            this.lblIdentificaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificaUsuario.Location = new System.Drawing.Point(731, 59);
            this.lblIdentificaUsuario.Name = "lblIdentificaUsuario";
            this.lblIdentificaUsuario.Size = new System.Drawing.Size(0, 24);
            this.lblIdentificaUsuario.TabIndex = 5;
            this.lblIdentificaUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 733);
            this.Controls.Add(this.lblIdentificaUsuario);
            this.Controls.Add(this.lblIdentificaLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "MenuPrincipal";
            this.Text = "EMC - Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MenuPrincipal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.Button btnImob;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnFaturamento;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.Button btnObras;
        private System.Windows.Forms.Button btnSeguranca;
        private System.Windows.Forms.Label lblIdentificaLogin;
        private System.Windows.Forms.Label lblIdentificaUsuario;
        private System.Windows.Forms.Button btnTrocaEmpresa;
        private System.Windows.Forms.Button btnSair;
    }
}

