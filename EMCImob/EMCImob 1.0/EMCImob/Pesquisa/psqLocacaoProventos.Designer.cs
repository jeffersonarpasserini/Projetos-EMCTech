namespace EMCImob
{
    partial class psqLocacaoProventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqLocacaoProventos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIdLocacaoProventos = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtLocacaoProventos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqLocacaoProventos = new System.Windows.Forms.DataGridView();
            this.idlocacaoproventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaolocacaoproventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqLocacaoProventos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtIdLocacaoProventos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtLocacaoProventos);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 55);
            this.panel2.TabIndex = 28;
            // 
            // txtIdLocacaoProventos
            // 
            this.txtIdLocacaoProventos.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdLocacaoProventos.Location = new System.Drawing.Point(435, 23);
            this.txtIdLocacaoProventos.Mask = "00000";
            this.txtIdLocacaoProventos.Name = "txtIdLocacaoProventos";
            this.txtIdLocacaoProventos.PromptChar = ' ';
            this.txtIdLocacaoProventos.Size = new System.Drawing.Size(49, 20);
            this.txtIdLocacaoProventos.TabIndex = 12;
            this.txtIdLocacaoProventos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdLocacaoProventos.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descrição";
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(671, 82);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.Size = new System.Drawing.Size(160, 20);
            this.txtCNPJCPF.TabIndex = 10;
            // 
            // txtLocacaoProventos
            // 
            this.txtLocacaoProventos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocacaoProventos.Location = new System.Drawing.Point(5, 23);
            this.txtLocacaoProventos.Name = "txtLocacaoProventos";
            this.txtLocacaoProventos.Size = new System.Drawing.Size(426, 20);
            this.txtLocacaoProventos.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
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
            this.panel1.TabIndex = 27;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 14;
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
            this.btnPesquisa.TabIndex = 13;
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
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grdPsqLocacaoProventos
            // 
            this.grdPsqLocacaoProventos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqLocacaoProventos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqLocacaoProventos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqLocacaoProventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqLocacaoProventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idlocacaoproventos,
            this.descricaolocacaoproventos});
            this.grdPsqLocacaoProventos.Location = new System.Drawing.Point(1, 129);
            this.grdPsqLocacaoProventos.Name = "grdPsqLocacaoProventos";
            this.grdPsqLocacaoProventos.ReadOnly = true;
            this.grdPsqLocacaoProventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqLocacaoProventos.Size = new System.Drawing.Size(493, 245);
            this.grdPsqLocacaoProventos.TabIndex = 29;
            this.grdPsqLocacaoProventos.DoubleClick += new System.EventHandler(this.grdPsqLocacaoProventos_DoubleClick);
            this.grdPsqLocacaoProventos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqLocacaoProventos_KeyDown);
            // 
            // idlocacaoproventos
            // 
            this.idlocacaoproventos.DataPropertyName = "idlocacaoproventos";
            this.idlocacaoproventos.HeaderText = "Código";
            this.idlocacaoproventos.Name = "idlocacaoproventos";
            this.idlocacaoproventos.ReadOnly = true;
            // 
            // descricaolocacaoproventos
            // 
            this.descricaolocacaoproventos.DataPropertyName = "descricao";
            this.descricaolocacaoproventos.HeaderText = "Descrição";
            this.descricaolocacaoproventos.Name = "descricaolocacaoproventos";
            this.descricaolocacaoproventos.ReadOnly = true;
            this.descricaolocacaoproventos.Width = 350;
            // 
            // psqLocacaoProventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqLocacaoProventos);
            this.Name = "psqLocacaoProventos";
            this.Text = "psqLocacaoProventos";
            this.Load += new System.EventHandler(this.psqLocacaoProventos_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqLocacaoProventos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox txtIdLocacaoProventos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtLocacaoProventos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqLocacaoProventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaoproventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaolocacaoproventos;
    }
}