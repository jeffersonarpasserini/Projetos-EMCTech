namespace EMCCadastro
{
    partial class psqHistorico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtIdHistorico = new System.Windows.Forms.MaskedTextBox();
            this.cboExigeComplemento = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdpsqHistorico = new System.Windows.Forms.DataGridView();
            this.idhistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomehistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exigecomplemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttppsqHistorico = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpsqHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 63);
            this.panel1.TabIndex = 20;
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
            this.ttppsqHistorico.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttppsqHistorico.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttppsqHistorico.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtIdHistorico
            // 
            this.txtIdHistorico.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdHistorico.Location = new System.Drawing.Point(10, 22);
            this.txtIdHistorico.Mask = "00000";
            this.txtIdHistorico.Name = "txtIdHistorico";
            this.txtIdHistorico.PromptChar = ' ';
            this.txtIdHistorico.Size = new System.Drawing.Size(64, 20);
            this.txtIdHistorico.TabIndex = 1;
            this.txtIdHistorico.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdHistorico.ValidatingType = typeof(int);
            // 
            // cboExigeComplemento
            // 
            this.cboExigeComplemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExigeComplemento.FormattingEnabled = true;
            this.cboExigeComplemento.Location = new System.Drawing.Point(491, 22);
            this.cboExigeComplemento.Name = "cboExigeComplemento";
            this.cboExigeComplemento.Size = new System.Drawing.Size(86, 21);
            this.cboExigeComplemento.TabIndex = 3;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(80, 22);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(403, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cboExigeComplemento);
            this.panel2.Controls.Add(this.txtIdHistorico);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(2, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 55);
            this.panel2.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Complemento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 6);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Código";
            // 
            // grdpsqHistorico
            // 
            this.grdpsqHistorico.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdpsqHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdpsqHistorico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdpsqHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdpsqHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idhistorico,
            this.nomehistorico,
            this.exigecomplemento});
            this.grdpsqHistorico.Location = new System.Drawing.Point(2, 133);
            this.grdpsqHistorico.Name = "grdpsqHistorico";
            this.grdpsqHistorico.ReadOnly = true;
            this.grdpsqHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdpsqHistorico.Size = new System.Drawing.Size(594, 191);
            this.grdpsqHistorico.TabIndex = 25;
            this.grdpsqHistorico.DoubleClick += new System.EventHandler(this.psqgrdHistorico_DoubleClick);
            // 
            // idhistorico
            // 
            this.idhistorico.DataPropertyName = "idhistorico";
            this.idhistorico.HeaderText = "Código";
            this.idhistorico.Name = "idhistorico";
            this.idhistorico.ReadOnly = true;
            this.idhistorico.Width = 50;
            // 
            // nomehistorico
            // 
            this.nomehistorico.DataPropertyName = "descricao";
            this.nomehistorico.HeaderText = "Descrição";
            this.nomehistorico.Name = "nomehistorico";
            this.nomehistorico.ReadOnly = true;
            this.nomehistorico.Width = 400;
            // 
            // exigecomplemento
            // 
            this.exigecomplemento.DataPropertyName = "exigecomplemento";
            this.exigecomplemento.HeaderText = "Complemento";
            this.exigecomplemento.Name = "exigecomplemento";
            this.exigecomplemento.ReadOnly = true;
            // 
            // psqHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 326);
            this.Controls.Add(this.grdpsqHistorico);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqHistorico";
            this.Text = "Pesquisa - Histórico";
            this.Load += new System.EventHandler(this.psqHistorico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqHistorico_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpsqHistorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.MaskedTextBox txtIdHistorico;
        private System.Windows.Forms.ComboBox cboExigeComplemento;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdpsqHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn idhistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomehistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn exigecomplemento;
        private System.Windows.Forms.ToolTip ttppsqHistorico;
    }
}