namespace EMCCadastro
{
    partial class psqContaCusto
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCodigoConta = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtContaCusto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqCtaReceber = new System.Windows.Forms.DataGridView();
            this.codigoconta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpPsqContaCusto = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtCodigoConta);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtContaCusto);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 55);
            this.panel2.TabIndex = 20;
            // 
            // txtCodigoConta
            // 
            this.txtCodigoConta.BackColor = System.Drawing.SystemColors.Control;
            this.txtCodigoConta.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCodigoConta.Location = new System.Drawing.Point(7, 23);
            this.txtCodigoConta.Name = "txtCodigoConta";
            this.txtCodigoConta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConta.TabIndex = 3;
            this.txtCodigoConta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 8);
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
            // txtContaCusto
            // 
            this.txtContaCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContaCusto.Location = new System.Drawing.Point(115, 23);
            this.txtContaCusto.Name = "txtContaCusto";
            this.txtContaCusto.Size = new System.Drawing.Size(492, 20);
            this.txtContaCusto.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Conta Custo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 63);
            this.panel1.TabIndex = 19;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCCadastro.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 3;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqContaCusto.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqContaCusto.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqContaCusto.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grdPsqCtaReceber
            // 
            this.grdPsqCtaReceber.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqCtaReceber.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqCtaReceber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqCtaReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqCtaReceber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoconta,
            this.nome,
            this.idcontacusto});
            this.grdPsqCtaReceber.Location = new System.Drawing.Point(3, 130);
            this.grdPsqCtaReceber.Name = "grdPsqCtaReceber";
            this.grdPsqCtaReceber.ReadOnly = true;
            this.grdPsqCtaReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqCtaReceber.Size = new System.Drawing.Size(717, 294);
            this.grdPsqCtaReceber.TabIndex = 18;
            this.grdPsqCtaReceber.DoubleClick += new System.EventHandler(this.grdPsqCtaReceber_DoubleClick);
            // 
            // codigoconta
            // 
            this.codigoconta.DataPropertyName = "codigoconta";
            this.codigoconta.HeaderText = "Conta";
            this.codigoconta.Name = "codigoconta";
            this.codigoconta.ReadOnly = true;
            // 
            // nome
            // 
            this.nome.DataPropertyName = "descricao";
            this.nome.HeaderText = "Descrição";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            this.nome.Width = 350;
            // 
            // idcontacusto
            // 
            this.idcontacusto.DataPropertyName = "idcontacusto";
            this.idcontacusto.HeaderText = "idcontacusto";
            this.idcontacusto.Name = "idcontacusto";
            this.idcontacusto.ReadOnly = true;
            this.idcontacusto.Visible = false;
            // 
            // psqContaCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqCtaReceber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqContaCusto";
            this.Text = "Pesquisa - Conta Custo";
            this.Load += new System.EventHandler(this.psqContaCusto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqContaCusto_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaReceber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtContaCusto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqCtaReceber;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoconta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcontacusto;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.MaskedTextBox txtCodigoConta;
        private System.Windows.Forms.ToolTip ttpPsqContaCusto;
    }
}