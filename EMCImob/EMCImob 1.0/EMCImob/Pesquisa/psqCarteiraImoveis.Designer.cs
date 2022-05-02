namespace EMCImob
{
    partial class psqCarteiraImoveis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqCarteiraImoveis));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIdCarteiraImoveis = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtCarteiraImoveis = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqCarteiraImoveis = new System.Windows.Forms.DataGridView();
            this.idcarteiraimoveis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaocarteiraimoveis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCarteiraImoveis)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtIdCarteiraImoveis);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtCarteiraImoveis);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 55);
            this.panel2.TabIndex = 26;
            // 
            // txtIdCarteiraImoveis
            // 
            this.txtIdCarteiraImoveis.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdCarteiraImoveis.Location = new System.Drawing.Point(436, 24);
            this.txtIdCarteiraImoveis.Mask = "00000";
            this.txtIdCarteiraImoveis.Name = "txtIdCarteiraImoveis";
            this.txtIdCarteiraImoveis.PromptChar = ' ';
            this.txtIdCarteiraImoveis.Size = new System.Drawing.Size(49, 20);
            this.txtIdCarteiraImoveis.TabIndex = 17;
            this.txtIdCarteiraImoveis.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdCarteiraImoveis.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Descrição";
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(671, 82);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.Size = new System.Drawing.Size(160, 20);
            this.txtCNPJCPF.TabIndex = 10;
            // 
            // txtCarteiraImoveis
            // 
            this.txtCarteiraImoveis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCarteiraImoveis.Location = new System.Drawing.Point(5, 24);
            this.txtCarteiraImoveis.Name = "txtCarteiraImoveis";
            this.txtCarteiraImoveis.Size = new System.Drawing.Size(428, 20);
            this.txtCarteiraImoveis.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Código";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 63);
            this.panel1.TabIndex = 25;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 19;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 18;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 20;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grdPsqCarteiraImoveis
            // 
            this.grdPsqCarteiraImoveis.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqCarteiraImoveis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPsqCarteiraImoveis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqCarteiraImoveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqCarteiraImoveis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcarteiraimoveis,
            this.descricaocarteiraimoveis});
            this.grdPsqCarteiraImoveis.Location = new System.Drawing.Point(1, 129);
            this.grdPsqCarteiraImoveis.Name = "grdPsqCarteiraImoveis";
            this.grdPsqCarteiraImoveis.ReadOnly = true;
            this.grdPsqCarteiraImoveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqCarteiraImoveis.Size = new System.Drawing.Size(493, 245);
            this.grdPsqCarteiraImoveis.TabIndex = 23;
            this.grdPsqCarteiraImoveis.DoubleClick += new System.EventHandler(this.grdPsqCarteiraImoveis_DoubleClick);
            // 
            // idcarteiraimoveis
            // 
            this.idcarteiraimoveis.DataPropertyName = "idcarteiraimoveis";
            this.idcarteiraimoveis.HeaderText = "Código";
            this.idcarteiraimoveis.Name = "idcarteiraimoveis";
            this.idcarteiraimoveis.ReadOnly = true;
            // 
            // descricaocarteiraimoveis
            // 
            this.descricaocarteiraimoveis.DataPropertyName = "descricao";
            this.descricaocarteiraimoveis.HeaderText = "Descrição";
            this.descricaocarteiraimoveis.Name = "descricaocarteiraimoveis";
            this.descricaocarteiraimoveis.ReadOnly = true;
            this.descricaocarteiraimoveis.Width = 350;
            // 
            // psqCarteiraImoveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqCarteiraImoveis);
            this.Name = "psqCarteiraImoveis";
            this.Text = "Pesquisa Carteira de Imóveis";
            this.Load += new System.EventHandler(this.psqCarteiraImoveis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqCarteiraImoveis_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCarteiraImoveis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox txtIdCarteiraImoveis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtCarteiraImoveis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqCarteiraImoveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcarteiraimoveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaocarteiraimoveis;
    }
}