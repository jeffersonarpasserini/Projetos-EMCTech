namespace EMCCadastro
{
    partial class psqCustoComponente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtidCusto_Componente = new System.Windows.Forms.MaskedTextBox();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdCusto_Componente = new System.Windows.Forms.DataGridView();
            this.ttpCustoComponente = new System.Windows.Forms.ToolTip(this.components);
            this.idcusto_componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustoComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idgrupo_componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cg_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCusto_Componente)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 63);
            this.panel1.TabIndex = 15;
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
            this.ttpCustoComponente.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpCustoComponente.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpCustoComponente.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.txtidCusto_Componente);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 55);
            this.panel2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Componente de Custo";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(79, 24);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(394, 20);
            this.txtDescricao.TabIndex = 15;
            // 
            // txtidCusto_Componente
            // 
            this.txtidCusto_Componente.BackColor = System.Drawing.SystemColors.Control;
            this.txtidCusto_Componente.Location = new System.Drawing.Point(7, 24);
            this.txtidCusto_Componente.Mask = "00000";
            this.txtidCusto_Componente.Name = "txtidCusto_Componente";
            this.txtidCusto_Componente.PromptChar = ' ';
            this.txtidCusto_Componente.Size = new System.Drawing.Size(63, 20);
            this.txtidCusto_Componente.TabIndex = 14;
            this.txtidCusto_Componente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidCusto_Componente.ValidatingType = typeof(int);
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
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Código";
            // 
            // grdCusto_Componente
            // 
            this.grdCusto_Componente.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCusto_Componente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCusto_Componente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdCusto_Componente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdCusto_Componente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCusto_Componente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcusto_componente,
            this.CustoComponente,
            this.idgrupo_componente,
            this.cg_descricao});
            this.grdCusto_Componente.Location = new System.Drawing.Point(0, 130);
            this.grdCusto_Componente.MultiSelect = false;
            this.grdCusto_Componente.Name = "grdCusto_Componente";
            this.grdCusto_Componente.ReadOnly = true;
            this.grdCusto_Componente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCusto_Componente.Size = new System.Drawing.Size(494, 218);
            this.grdCusto_Componente.TabIndex = 19;
            this.grdCusto_Componente.DoubleClick += new System.EventHandler(this.grdCusto_Componente_DoubleClick);
            // 
            // idcusto_componente
            // 
            this.idcusto_componente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idcusto_componente.DataPropertyName = "idcusto_componente";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idcusto_componente.DefaultCellStyle = dataGridViewCellStyle2;
            this.idcusto_componente.HeaderText = "Código";
            this.idcusto_componente.Name = "idcusto_componente";
            this.idcusto_componente.ReadOnly = true;
            this.idcusto_componente.Width = 70;
            // 
            // CustoComponente
            // 
            this.CustoComponente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CustoComponente.DataPropertyName = "descricao";
            this.CustoComponente.HeaderText = "Custo Componente";
            this.CustoComponente.Name = "CustoComponente";
            this.CustoComponente.ReadOnly = true;
            this.CustoComponente.Width = 190;
            // 
            // idgrupo_componente
            // 
            this.idgrupo_componente.DataPropertyName = "idgrupo_componente";
            this.idgrupo_componente.HeaderText = "idgrupo_componente";
            this.idgrupo_componente.Name = "idgrupo_componente";
            this.idgrupo_componente.ReadOnly = true;
            this.idgrupo_componente.Visible = false;
            this.idgrupo_componente.Width = 132;
            // 
            // cg_descricao
            // 
            this.cg_descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cg_descricao.DataPropertyName = "cg_descricao";
            this.cg_descricao.HeaderText = "Grupo de Componente";
            this.cg_descricao.Name = "cg_descricao";
            this.cg_descricao.ReadOnly = true;
            this.cg_descricao.Width = 190;
            // 
            // psqCustoComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 347);
            this.Controls.Add(this.grdCusto_Componente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqCustoComponente";
            this.Text = "Pesquisa - Componente de Custo";
            this.Load += new System.EventHandler(this.psqCustoComponente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqCustoComponente_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCusto_Componente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtidCusto_Componente;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdCusto_Componente;
        private System.Windows.Forms.ToolTip ttpCustoComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcusto_componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustoComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idgrupo_componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cg_descricao;
    }
}