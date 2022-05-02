namespace EMCCadastro
{
    partial class psqTipoCobranca
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIdTipoCobranca = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ttpPsqTipoCobranca = new System.Windows.Forms.ToolTip(this.components);
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipocobranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdPsqTipoCobranca = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqTipoCobranca)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 63);
            this.panel1.TabIndex = 19;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCCadastro.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(138, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 7;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqTipoCobranca.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.btnPesquisa.TabIndex = 6;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqTipoCobranca.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCCadastro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(4, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqTipoCobranca.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtIdTipoCobranca);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 55);
            this.panel2.TabIndex = 20;
            // 
            // txtIdTipoCobranca
            // 
            this.txtIdTipoCobranca.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdTipoCobranca.Location = new System.Drawing.Point(10, 20);
            this.txtIdTipoCobranca.Mask = "00000";
            this.txtIdTipoCobranca.Name = "txtIdTipoCobranca";
            this.txtIdTipoCobranca.PromptChar = ' ';
            this.txtIdTipoCobranca.Size = new System.Drawing.Size(68, 20);
            this.txtIdTipoCobranca.TabIndex = 1;
            this.txtIdTipoCobranca.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdTipoCobranca.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 4);
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
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(86, 20);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(440, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Código";
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 395;
            // 
            // idtipocobranca
            // 
            this.idtipocobranca.DataPropertyName = "idtipocobranca";
            this.idtipocobranca.HeaderText = "Código";
            this.idtipocobranca.Name = "idtipocobranca";
            this.idtipocobranca.ReadOnly = true;
            // 
            // grdPsqTipoCobranca
            // 
            this.grdPsqTipoCobranca.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqTipoCobranca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqTipoCobranca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqTipoCobranca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqTipoCobranca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtipocobranca,
            this.descricao});
            this.grdPsqTipoCobranca.Location = new System.Drawing.Point(1, 129);
            this.grdPsqTipoCobranca.Name = "grdPsqTipoCobranca";
            this.grdPsqTipoCobranca.ReadOnly = true;
            this.grdPsqTipoCobranca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqTipoCobranca.Size = new System.Drawing.Size(538, 262);
            this.grdPsqTipoCobranca.TabIndex = 21;
            this.grdPsqTipoCobranca.DoubleClick += new System.EventHandler(this.grdPsqTipoCobranca_DoubleClick);
            // 
            // psqTipoCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 393);
            this.Controls.Add(this.grdPsqTipoCobranca);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqTipoCobranca";
            this.Text = "Pesquisa - Tipo Cobrança";
            this.Load += new System.EventHandler(this.psqTipoCobranca_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqTipoCobranca_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqTipoCobranca)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox txtIdTipoCobranca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip ttpPsqTipoCobranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipocobranca;
        private System.Windows.Forms.DataGridView grdPsqTipoCobranca;
    }
}