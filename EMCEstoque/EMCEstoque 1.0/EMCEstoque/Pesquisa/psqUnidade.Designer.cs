namespace EMCEstoque
{
    partial class psqProduto_Unidade
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
            this.txtUnidade_Abreviatura = new System.Windows.Forms.TextBox();
            this.txtidEstq_Produto_Unidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdPsqProduto_Unidade = new System.Windows.Forms.DataGridView();
            this.ttpPsqUnidadeProduto = new System.Windows.Forms.ToolTip(this.components);
            this.idEstq_Produto_Unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abreviatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqProduto_Unidade)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 63);
            this.panel1.TabIndex = 15;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCEstoque.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 3;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqUnidadeProduto.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = global::EMCEstoque.Properties.Resources.binoculo_32x32;
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqUnidadeProduto.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCEstoque.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqUnidadeProduto.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtUnidade_Abreviatura);
            this.panel2.Controls.Add(this.txtidEstq_Produto_Unidade);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 55);
            this.panel2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(438, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Abreviatura";
            // 
            // txtUnidade_Abreviatura
            // 
            this.txtUnidade_Abreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUnidade_Abreviatura.Location = new System.Drawing.Point(441, 24);
            this.txtUnidade_Abreviatura.MaxLength = 45;
            this.txtUnidade_Abreviatura.Name = "txtUnidade_Abreviatura";
            this.txtUnidade_Abreviatura.Size = new System.Drawing.Size(58, 20);
            this.txtUnidade_Abreviatura.TabIndex = 13;
            // 
            // txtidEstq_Produto_Unidade
            // 
            this.txtidEstq_Produto_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Produto_Unidade.Location = new System.Drawing.Point(7, 24);
            this.txtidEstq_Produto_Unidade.MaxLength = 20;
            this.txtidEstq_Produto_Unidade.Name = "txtidEstq_Produto_Unidade";
            this.txtidEstq_Produto_Unidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Produto_Unidade.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Produto_Unidade.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descrição Unidade";
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
            this.txtDescricao.Location = new System.Drawing.Point(76, 24);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(359, 20);
            this.txtDescricao.TabIndex = 5;
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
            // grdPsqProduto_Unidade
            // 
            this.grdPsqProduto_Unidade.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqProduto_Unidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqProduto_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqProduto_Unidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqProduto_Unidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEstq_Produto_Unidade,
            this.descricao,
            this.abreviatura});
            this.grdPsqProduto_Unidade.Location = new System.Drawing.Point(0, 129);
            this.grdPsqProduto_Unidade.Name = "grdPsqProduto_Unidade";
            this.grdPsqProduto_Unidade.ReadOnly = true;
            this.grdPsqProduto_Unidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqProduto_Unidade.Size = new System.Drawing.Size(514, 243);
            this.grdPsqProduto_Unidade.TabIndex = 17;
            this.grdPsqProduto_Unidade.DoubleClick += new System.EventHandler(this.grdPsqProduto_Unidade_DoubleClick);
            // 
            // idEstq_Produto_Unidade
            // 
            this.idEstq_Produto_Unidade.DataPropertyName = "idEstq_Produto_Unidade";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idEstq_Produto_Unidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.idEstq_Produto_Unidade.HeaderText = "Código";
            this.idEstq_Produto_Unidade.Name = "idEstq_Produto_Unidade";
            this.idEstq_Produto_Unidade.ReadOnly = true;
            this.idEstq_Produto_Unidade.Width = 83;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "unidade_descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 270;
            // 
            // abreviatura
            // 
            this.abreviatura.DataPropertyName = "unidade_abreviatura";
            this.abreviatura.HeaderText = "Abreviatura";
            this.abreviatura.Name = "abreviatura";
            this.abreviatura.ReadOnly = true;
            // 
            // psqProduto_Unidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 373);
            this.Controls.Add(this.grdPsqProduto_Unidade);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "psqProduto_Unidade";
            this.Text = "Pesquisa - Unidade de Produto";
            this.Load += new System.EventHandler(this.psqProduto_Unidade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqProduto_Unidade_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqProduto_Unidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtidEstq_Produto_Unidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdPsqProduto_Unidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnidade_Abreviatura;
        private System.Windows.Forms.ToolTip ttpPsqUnidadeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstq_Produto_Unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviatura;
    }
}