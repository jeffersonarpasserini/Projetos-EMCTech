namespace EMCCadastro
{
    partial class psqGrupoEmpresa
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboHolding = new System.Windows.Forms.ComboBox();
            this.txtIdGrupoEmpresa = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtNomeGrupoEmpresa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdpsqGrupoEmpresa = new System.Windows.Forms.DataGridView();
            this.ttppsqGrupoEmpresa = new System.Windows.Forms.ToolTip(this.components);
            this.idgrupoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idHolding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpsqGrupoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 63);
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
            this.ttppsqGrupoEmpresa.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttppsqGrupoEmpresa.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttppsqGrupoEmpresa.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboHolding);
            this.panel2.Controls.Add(this.txtIdGrupoEmpresa);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtNomeGrupoEmpresa);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 55);
            this.panel2.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Holding";
            // 
            // cboHolding
            // 
            this.cboHolding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHolding.FormattingEnabled = true;
            this.cboHolding.Location = new System.Drawing.Point(452, 19);
            this.cboHolding.Name = "cboHolding";
            this.cboHolding.Size = new System.Drawing.Size(200, 21);
            this.cboHolding.TabIndex = 12;
            // 
            // txtIdGrupoEmpresa
            // 
            this.txtIdGrupoEmpresa.BackColor = System.Drawing.SystemColors.Control;
            this.txtIdGrupoEmpresa.Location = new System.Drawing.Point(10, 20);
            this.txtIdGrupoEmpresa.Mask = "00000";
            this.txtIdGrupoEmpresa.Name = "txtIdGrupoEmpresa";
            this.txtIdGrupoEmpresa.PromptChar = ' ';
            this.txtIdGrupoEmpresa.Size = new System.Drawing.Size(68, 20);
            this.txtIdGrupoEmpresa.TabIndex = 1;
            this.txtIdGrupoEmpresa.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtIdGrupoEmpresa.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Grupo Empresa";
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(671, 82);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.Size = new System.Drawing.Size(160, 20);
            this.txtCNPJCPF.TabIndex = 10;
            // 
            // txtNomeGrupoEmpresa
            // 
            this.txtNomeGrupoEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeGrupoEmpresa.Location = new System.Drawing.Point(86, 20);
            this.txtNomeGrupoEmpresa.Name = "txtNomeGrupoEmpresa";
            this.txtNomeGrupoEmpresa.Size = new System.Drawing.Size(360, 20);
            this.txtNomeGrupoEmpresa.TabIndex = 2;
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
            // grdpsqGrupoEmpresa
            // 
            this.grdpsqGrupoEmpresa.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdpsqGrupoEmpresa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdpsqGrupoEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdpsqGrupoEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdpsqGrupoEmpresa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idgrupoempresa,
            this.idHolding,
            this.grupoempresa,
            this.holding});
            this.grdpsqGrupoEmpresa.Location = new System.Drawing.Point(1, 131);
            this.grdpsqGrupoEmpresa.Name = "grdpsqGrupoEmpresa";
            this.grdpsqGrupoEmpresa.ReadOnly = true;
            this.grdpsqGrupoEmpresa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdpsqGrupoEmpresa.Size = new System.Drawing.Size(663, 235);
            this.grdpsqGrupoEmpresa.TabIndex = 22;
            this.grdpsqGrupoEmpresa.DoubleClick += new System.EventHandler(this.grdpsqGrupoEmpresa_DoubleClick);
            // 
            // idgrupoempresa
            // 
            this.idgrupoempresa.DataPropertyName = "idgrupoempresa";
            this.idgrupoempresa.HeaderText = "Código";
            this.idgrupoempresa.Name = "idgrupoempresa";
            this.idgrupoempresa.ReadOnly = true;
            this.idgrupoempresa.Width = 60;
            // 
            // idHolding
            // 
            this.idHolding.DataPropertyName = "holding_idholding";
            this.idHolding.HeaderText = "idHolding";
            this.idHolding.Name = "idHolding";
            this.idHolding.ReadOnly = true;
            this.idHolding.Visible = false;
            // 
            // grupoempresa
            // 
            this.grupoempresa.DataPropertyName = "nomegrupoempresa";
            this.grupoempresa.HeaderText = "Grupo Empresa";
            this.grupoempresa.Name = "grupoempresa";
            this.grupoempresa.ReadOnly = true;
            this.grupoempresa.Width = 312;
            // 
            // holding
            // 
            this.holding.DataPropertyName = "nomeholding";
            this.holding.HeaderText = "Holding";
            this.holding.Name = "holding";
            this.holding.ReadOnly = true;
            this.holding.Width = 248;
            // 
            // psqGrupoEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 367);
            this.Controls.Add(this.grdpsqGrupoEmpresa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqGrupoEmpresa";
            this.Text = "Pesquisa - Grupo Empresa";
            this.Load += new System.EventHandler(this.psqGrupoEmpresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqGrupoEmpresa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdpsqGrupoEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox txtIdGrupoEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtNomeGrupoEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboHolding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdpsqGrupoEmpresa;
        private System.Windows.Forms.ToolTip ttppsqGrupoEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgrupoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHolding;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn holding;
    }
}