namespace EMCEstoque
{
    partial class psqTipoProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtidEstq_TipoProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdEstq_TipoProduto = new System.Windows.Forms.DataGridView();
            this.idestq_tipoproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlaestoqueminimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prestacaoservico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familiaobrigatoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpTipoProduto = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_TipoProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 63);
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
            this.ttpTipoProduto.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpTipoProduto.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpTipoProduto.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtidEstq_TipoProduto);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 55);
            this.panel2.TabIndex = 16;
            // 
            // txtidEstq_TipoProduto
            // 
            this.txtidEstq_TipoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_TipoProduto.Location = new System.Drawing.Point(7, 24);
            this.txtidEstq_TipoProduto.MaxLength = 20;
            this.txtidEstq_TipoProduto.Name = "txtidEstq_TipoProduto";
            this.txtidEstq_TipoProduto.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_TipoProduto.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tipo Produto";
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
            this.txtDescricao.Size = new System.Drawing.Size(464, 20);
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
            // grdEstq_TipoProduto
            // 
            this.grdEstq_TipoProduto.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_TipoProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdEstq_TipoProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_TipoProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_TipoProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_TipoProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_tipoproduto,
            this.descricao,
            this.controlaestoqueminimo,
            this.prestacaoservico,
            this.familiaobrigatoria});
            this.grdEstq_TipoProduto.Location = new System.Drawing.Point(1, 132);
            this.grdEstq_TipoProduto.MultiSelect = false;
            this.grdEstq_TipoProduto.Name = "grdEstq_TipoProduto";
            this.grdEstq_TipoProduto.ReadOnly = true;
            this.grdEstq_TipoProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_TipoProduto.Size = new System.Drawing.Size(556, 245);
            this.grdEstq_TipoProduto.TabIndex = 20;
            this.grdEstq_TipoProduto.DoubleClick += new System.EventHandler(this.grdEstq_TipoProduto_DoubleClick);
            // 
            // idestq_tipoproduto
            // 
            this.idestq_tipoproduto.DataPropertyName = "idestq_tipoproduto";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_tipoproduto.DefaultCellStyle = dataGridViewCellStyle8;
            this.idestq_tipoproduto.HeaderText = "Código";
            this.idestq_tipoproduto.Name = "idestq_tipoproduto";
            this.idestq_tipoproduto.ReadOnly = true;
            this.idestq_tipoproduto.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Tipo de Produto";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 99;
            // 
            // controlaestoqueminimo
            // 
            this.controlaestoqueminimo.DataPropertyName = "controlaestoqueminimo";
            this.controlaestoqueminimo.HeaderText = "Controla Estoq. Mímino";
            this.controlaestoqueminimo.Name = "controlaestoqueminimo";
            this.controlaestoqueminimo.ReadOnly = true;
            this.controlaestoqueminimo.Width = 130;
            // 
            // prestacaoservico
            // 
            this.prestacaoservico.DataPropertyName = "prestacaoservico";
            this.prestacaoservico.HeaderText = "Prestação Serviço";
            this.prestacaoservico.Name = "prestacaoservico";
            this.prestacaoservico.ReadOnly = true;
            this.prestacaoservico.Width = 109;
            // 
            // familiaobrigatoria
            // 
            this.familiaobrigatoria.DataPropertyName = "familiaobrigatoria";
            this.familiaobrigatoria.HeaderText = "Família Obrigatória";
            this.familiaobrigatoria.Name = "familiaobrigatoria";
            this.familiaobrigatoria.ReadOnly = true;
            this.familiaobrigatoria.Width = 110;
            // 
            // psqTipoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 374);
            this.Controls.Add(this.grdEstq_TipoProduto);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqTipoProduto";
            this.Text = "Pesquisa - Tipo Produto";
            this.Load += new System.EventHandler(this.psqTipoProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqTipoProduto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_TipoProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtidEstq_TipoProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdEstq_TipoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_tipoproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlaestoqueminimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prestacaoservico;
        private System.Windows.Forms.DataGridViewTextBoxColumn familiaobrigatoria;
        private System.Windows.Forms.ToolTip ttpTipoProduto;
    }
}