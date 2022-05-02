namespace EMCImob
{
    partial class psqTipoLanctoCaptacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqTipoLanctoCaptacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIdTipoLanctoCaptacao = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtTipoLanctoCaptacao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqTipoLanctoCaptacao = new System.Windows.Forms.DataGridView();
            this.idtipolanctocaptacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaotipolanctocaptacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqTipoLanctoCaptacao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtIdTipoLanctoCaptacao);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtTipoLanctoCaptacao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 55);
            this.panel2.TabIndex = 28;
            // 
            // txtIdTipoLanctoCaptacao
            // 
            this.txtIdTipoLanctoCaptacao.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdTipoLanctoCaptacao.Location = new System.Drawing.Point(437, 23);
            this.txtIdTipoLanctoCaptacao.Mask = "00000";
            this.txtIdTipoLanctoCaptacao.Name = "txtIdTipoLanctoCaptacao";
            this.txtIdTipoLanctoCaptacao.PromptChar = ' ';
            this.txtIdTipoLanctoCaptacao.Size = new System.Drawing.Size(49, 20);
            this.txtIdTipoLanctoCaptacao.TabIndex = 12;
            this.txtIdTipoLanctoCaptacao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdTipoLanctoCaptacao.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
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
            // txtTipoLanctoCaptacao
            // 
            this.txtTipoLanctoCaptacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoLanctoCaptacao.Location = new System.Drawing.Point(5, 23);
            this.txtTipoLanctoCaptacao.Name = "txtTipoLanctoCaptacao";
            this.txtTipoLanctoCaptacao.Size = new System.Drawing.Size(428, 20);
            this.txtTipoLanctoCaptacao.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 7);
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
            // grdPsqTipoLanctoCaptacao
            // 
            this.grdPsqTipoLanctoCaptacao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqTipoLanctoCaptacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqTipoLanctoCaptacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqTipoLanctoCaptacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqTipoLanctoCaptacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtipolanctocaptacao,
            this.descricaotipolanctocaptacao});
            this.grdPsqTipoLanctoCaptacao.Location = new System.Drawing.Point(1, 129);
            this.grdPsqTipoLanctoCaptacao.Name = "grdPsqTipoLanctoCaptacao";
            this.grdPsqTipoLanctoCaptacao.ReadOnly = true;
            this.grdPsqTipoLanctoCaptacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqTipoLanctoCaptacao.Size = new System.Drawing.Size(493, 245);
            this.grdPsqTipoLanctoCaptacao.TabIndex = 29;
            this.grdPsqTipoLanctoCaptacao.DoubleClick += new System.EventHandler(this.grdPsqTipoLanctoCaptacao_DoubleClick);
            this.grdPsqTipoLanctoCaptacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqTipoLanctoCaptacao_KeyDown);
            // 
            // idtipolanctocaptacao
            // 
            this.idtipolanctocaptacao.DataPropertyName = "idtipolanctocaptacao";
            this.idtipolanctocaptacao.HeaderText = "Código";
            this.idtipolanctocaptacao.Name = "idtipolanctocaptacao";
            this.idtipolanctocaptacao.ReadOnly = true;
            // 
            // descricaotipolanctocaptacao
            // 
            this.descricaotipolanctocaptacao.DataPropertyName = "descricao";
            this.descricaotipolanctocaptacao.HeaderText = "Descrição";
            this.descricaotipolanctocaptacao.Name = "descricaotipolanctocaptacao";
            this.descricaotipolanctocaptacao.ReadOnly = true;
            this.descricaotipolanctocaptacao.Width = 350;
            // 
            // psqTipoLanctoCaptacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 375);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqTipoLanctoCaptacao);
            this.Name = "psqTipoLanctoCaptacao";
            this.Text = "psqTipoLanctoCaptacao";
            this.Load += new System.EventHandler(this.psqTipoLanctoCaptacao_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqTipoLanctoCaptacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox txtIdTipoLanctoCaptacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtTipoLanctoCaptacao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqTipoLanctoCaptacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipolanctocaptacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaotipolanctocaptacao;
    }
}