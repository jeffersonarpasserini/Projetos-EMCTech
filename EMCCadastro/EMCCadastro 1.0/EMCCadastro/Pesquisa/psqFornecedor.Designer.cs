namespace EMCCadastro
{
    partial class psqFornecedor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCnpj = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtIdFornecedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqCtaPagar = new System.Windows.Forms.DataGridView();
            this.idpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomefornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnpjcpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpPsqFornecedor = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaPagar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtCnpj);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtFornecedor);
            this.panel2.Controls.Add(this.txtIdFornecedor);
            this.panel2.Location = new System.Drawing.Point(3, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 55);
            this.panel2.TabIndex = 5;
            // 
            // txtCnpj
            // 
            this.txtCnpj.AutoSize = true;
            this.txtCnpj.Location = new System.Drawing.Point(497, 9);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(59, 13);
            this.txtCnpj.TabIndex = 12;
            this.txtCnpj.Text = "CNPJ/CPF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Razão Social";
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(500, 23);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.Size = new System.Drawing.Size(160, 20);
            this.txtCNPJCPF.TabIndex = 10;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(3, 23);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(491, 20);
            this.txtFornecedor.TabIndex = 0;
            // 
            // txtIdFornecedor
            // 
            this.txtIdFornecedor.Location = new System.Drawing.Point(666, 23);
            this.txtIdFornecedor.Name = "txtIdFornecedor";
            this.txtIdFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdFornecedor.Size = new System.Drawing.Size(65, 20);
            this.txtIdFornecedor.TabIndex = 6;
            this.txtIdFornecedor.TextChanged += new System.EventHandler(this.txtIdFornecedor_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(663, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fornecedor";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 63);
            this.panel1.TabIndex = 4;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCCadastro.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 15;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqFornecedor.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = global::EMCCadastro.Properties.Resources.binoculo_32x32;
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 14;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqFornecedor.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCCadastro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqFornecedor.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grdPsqCtaPagar
            // 
            this.grdPsqCtaPagar.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqCtaPagar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdPsqCtaPagar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqCtaPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqCtaPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpessoa,
            this.nomefornecedor,
            this.cnpjcpf});
            this.grdPsqCtaPagar.Location = new System.Drawing.Point(3, 129);
            this.grdPsqCtaPagar.Name = "grdPsqCtaPagar";
            this.grdPsqCtaPagar.ReadOnly = true;
            this.grdPsqCtaPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqCtaPagar.Size = new System.Drawing.Size(743, 294);
            this.grdPsqCtaPagar.TabIndex = 3;
            this.grdPsqCtaPagar.DoubleClick += new System.EventHandler(this.grdPsqCtaPagar_DoubleClick);
            // 
            // idpessoa
            // 
            this.idpessoa.DataPropertyName = "idpessoa";
            this.idpessoa.HeaderText = "Código";
            this.idpessoa.Name = "idpessoa";
            this.idpessoa.ReadOnly = true;
            // 
            // nomefornecedor
            // 
            this.nomefornecedor.DataPropertyName = "nome";
            this.nomefornecedor.HeaderText = "Fornecedor";
            this.nomefornecedor.Name = "nomefornecedor";
            this.nomefornecedor.ReadOnly = true;
            this.nomefornecedor.Width = 440;
            // 
            // cnpjcpf
            // 
            this.cnpjcpf.DataPropertyName = "cnpjcpf";
            this.cnpjcpf.HeaderText = "CNPJ";
            this.cnpjcpf.Name = "cnpjcpf";
            this.cnpjcpf.ReadOnly = true;
            this.cnpjcpf.Width = 160;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(576, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "[F8] Pesquisa";
            // 
            // psqFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 426);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqCtaPagar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "psqFornecedor";
            this.Text = "Pesquisa Fornecedor";
            this.Load += new System.EventHandler(this.psqFornecedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqFornecedor_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaPagar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtIdFornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqCtaPagar;
        private System.Windows.Forms.Label txtCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.ToolTip ttpPsqFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomefornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnpjcpf;
        private System.Windows.Forms.Label label7;
    }
}