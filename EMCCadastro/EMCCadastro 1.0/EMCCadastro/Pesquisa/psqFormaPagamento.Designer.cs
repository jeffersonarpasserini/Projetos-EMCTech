namespace EMCCadastro
{
    partial class psqFormaPagamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtIdFormaPagamento = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdPsqFormaPagamento = new System.Windows.Forms.DataGridView();
            this.ttpPsqFormaPagamento = new System.Windows.Forms.ToolTip(this.components);
            this.idformapagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idHistoricoPadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaohistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboHistoricoPadrao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqFormaPagamento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(-3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 63);
            this.panel1.TabIndex = 18;
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
            this.ttpPsqFormaPagamento.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpPsqFormaPagamento.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpPsqFormaPagamento.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboHistoricoPadrao);
            this.panel2.Controls.Add(this.txtIdFormaPagamento);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 55);
            this.panel2.TabIndex = 19;
            // 
            // txtIdFormaPagamento
            // 
            this.txtIdFormaPagamento.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdFormaPagamento.Location = new System.Drawing.Point(10, 20);
            this.txtIdFormaPagamento.Mask = "00000";
            this.txtIdFormaPagamento.Name = "txtIdFormaPagamento";
            this.txtIdFormaPagamento.PromptChar = ' ';
            this.txtIdFormaPagamento.Size = new System.Drawing.Size(68, 20);
            this.txtIdFormaPagamento.TabIndex = 1;
            this.txtIdFormaPagamento.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdFormaPagamento.ValidatingType = typeof(int);
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
            this.txtDescricao.Size = new System.Drawing.Size(305, 20);
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
            // grdPsqFormaPagamento
            // 
            this.grdPsqFormaPagamento.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqFormaPagamento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdPsqFormaPagamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqFormaPagamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idformapagamento,
            this.descricao,
            this.idHistoricoPadrao,
            this.descricaohistorico});
            this.grdPsqFormaPagamento.Location = new System.Drawing.Point(0, 130);
            this.grdPsqFormaPagamento.Name = "grdPsqFormaPagamento";
            this.grdPsqFormaPagamento.ReadOnly = true;
            this.grdPsqFormaPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqFormaPagamento.Size = new System.Drawing.Size(626, 262);
            this.grdPsqFormaPagamento.TabIndex = 20;
            this.grdPsqFormaPagamento.DoubleClick += new System.EventHandler(this.grdPsqFormaPagamento_DoubleClick);
            // 
            // idformapagamento
            // 
            this.idformapagamento.DataPropertyName = "idformapagamento";
            this.idformapagamento.HeaderText = "Código";
            this.idformapagamento.Name = "idformapagamento";
            this.idformapagamento.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 280;
            // 
            // idHistoricoPadrao
            // 
            this.idHistoricoPadrao.DataPropertyName = "idHistoricoPadrao";
            this.idHistoricoPadrao.HeaderText = "Código Histórico Padrão";
            this.idHistoricoPadrao.Name = "idHistoricoPadrao";
            this.idHistoricoPadrao.ReadOnly = true;
            this.idHistoricoPadrao.Visible = false;
            this.idHistoricoPadrao.Width = 145;
            // 
            // descricaohistorico
            // 
            this.descricaohistorico.DataPropertyName = "descricaohistorico";
            this.descricaohistorico.HeaderText = "Histórico";
            this.descricaohistorico.Name = "descricaohistorico";
            this.descricaohistorico.ReadOnly = true;
            this.descricaohistorico.Width = 203;
            // 
            // cboHistoricoPadrao
            // 
            this.cboHistoricoPadrao.FormattingEnabled = true;
            this.cboHistoricoPadrao.Location = new System.Drawing.Point(397, 19);
            this.cboHistoricoPadrao.Name = "cboHistoricoPadrao";
            this.cboHistoricoPadrao.Size = new System.Drawing.Size(222, 21);
            this.cboHistoricoPadrao.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Histórico Padrão";
            // 
            // psqFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 394);
            this.Controls.Add(this.grdPsqFormaPagamento);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqFormaPagamento";
            this.Text = "Pesquisa - Forma Pagamento";
            this.Load += new System.EventHandler(this.psqFormaPagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqFormaPagamento_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqFormaPagamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdPsqFormaPagamento;
        private System.Windows.Forms.ToolTip ttpPsqFormaPagamento;
        private System.Windows.Forms.MaskedTextBox txtIdFormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idformapagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHistoricoPadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaohistorico;
        private System.Windows.Forms.ComboBox cboHistoricoPadrao;
        private System.Windows.Forms.Label label2;
    }
}