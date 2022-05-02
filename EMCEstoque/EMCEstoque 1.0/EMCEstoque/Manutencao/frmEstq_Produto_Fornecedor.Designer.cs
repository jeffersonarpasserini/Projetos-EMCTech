namespace EMCEstoque
{
    partial class frmEstq_Produto_Fornecedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdEstq_Produto_Fornecedor = new System.Windows.Forms.DataGridView();
            this.idestq_produto_fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_CodEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_produto_idestq_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_idPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproduto_fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdProduto_Fornecedor = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboFornecedor_IdPessoa = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFornecedor_IdPessoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidEstq_Produto_Fornecedor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Fornecedor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEstq_Produto_Fornecedor
            // 
            this.grdEstq_Produto_Fornecedor.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Produto_Fornecedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Produto_Fornecedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Produto_Fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Produto_Fornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Produto_Fornecedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_produto_fornecedor,
            this.fornecedor_CodEmpresa,
            this.estq_produto_idestq_produto,
            this.Produto_Descricao,
            this.fornecedor_idPessoa,
            this.Fornecedor,
            this.idproduto_fornecedor});
            this.grdEstq_Produto_Fornecedor.Location = new System.Drawing.Point(2, 205);
            this.grdEstq_Produto_Fornecedor.MultiSelect = false;
            this.grdEstq_Produto_Fornecedor.Name = "grdEstq_Produto_Fornecedor";
            this.grdEstq_Produto_Fornecedor.ReadOnly = true;
            this.grdEstq_Produto_Fornecedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Produto_Fornecedor.Size = new System.Drawing.Size(629, 270);
            this.grdEstq_Produto_Fornecedor.TabIndex = 20;
            this.grdEstq_Produto_Fornecedor.DoubleClick += new System.EventHandler(this.grdEstq_Produto_Fornecedor_DoubleClick);
            // 
            // idestq_produto_fornecedor
            // 
            this.idestq_produto_fornecedor.DataPropertyName = "idestq_produto_fornecedor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idestq_produto_fornecedor.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_produto_fornecedor.HeaderText = "Código";
            this.idestq_produto_fornecedor.Name = "idestq_produto_fornecedor";
            this.idestq_produto_fornecedor.ReadOnly = true;
            this.idestq_produto_fornecedor.Visible = false;
            this.idestq_produto_fornecedor.Width = 65;
            // 
            // fornecedor_CodEmpresa
            // 
            this.fornecedor_CodEmpresa.DataPropertyName = "fornecedor_CodEmpresa";
            this.fornecedor_CodEmpresa.HeaderText = "CodEmpresa";
            this.fornecedor_CodEmpresa.Name = "fornecedor_CodEmpresa";
            this.fornecedor_CodEmpresa.ReadOnly = true;
            this.fornecedor_CodEmpresa.Visible = false;
            this.fornecedor_CodEmpresa.Width = 92;
            // 
            // estq_produto_idestq_produto
            // 
            this.estq_produto_idestq_produto.DataPropertyName = "estq_Produto_idEstq_Produto";
            this.estq_produto_idestq_produto.HeaderText = "Produto";
            this.estq_produto_idestq_produto.Name = "estq_produto_idestq_produto";
            this.estq_produto_idestq_produto.ReadOnly = true;
            this.estq_produto_idestq_produto.Visible = false;
            this.estq_produto_idestq_produto.Width = 69;
            // 
            // Produto_Descricao
            // 
            this.Produto_Descricao.DataPropertyName = "Produto_Descricao";
            this.Produto_Descricao.HeaderText = "Produto_Descricao";
            this.Produto_Descricao.Name = "Produto_Descricao";
            this.Produto_Descricao.ReadOnly = true;
            this.Produto_Descricao.Visible = false;
            this.Produto_Descricao.Width = 123;
            // 
            // fornecedor_idPessoa
            // 
            this.fornecedor_idPessoa.DataPropertyName = "fornecedor_idPessoa";
            this.fornecedor_idPessoa.HeaderText = "CodFornecedor";
            this.fornecedor_idPessoa.Name = "fornecedor_idPessoa";
            this.fornecedor_idPessoa.ReadOnly = true;
            this.fornecedor_idPessoa.Visible = false;
            this.fornecedor_idPessoa.Width = 105;
            // 
            // Fornecedor
            // 
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Width = 86;
            // 
            // idproduto_fornecedor
            // 
            this.idproduto_fornecedor.DataPropertyName = "idproduto_fornecedor";
            this.idproduto_fornecedor.HeaderText = "Código Interno do Fornecedor";
            this.idproduto_fornecedor.Name = "idproduto_fornecedor";
            this.idproduto_fornecedor.ReadOnly = true;
            this.idproduto_fornecedor.Width = 109;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtIdProduto_Fornecedor);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.cboFornecedor_IdPessoa);
            this.panel1.Controls.Add(this.lblProduto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFornecedor_IdPessoa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtidEstq_Produto_Fornecedor);
            this.panel1.Location = new System.Drawing.Point(3, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 125);
            this.panel1.TabIndex = 19;
            // 
            // txtIdProduto_Fornecedor
            // 
            this.txtIdProduto_Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdProduto_Fornecedor.Location = new System.Drawing.Point(8, 95);
            this.txtIdProduto_Fornecedor.MaxLength = 20;
            this.txtIdProduto_Fornecedor.Name = "txtIdProduto_Fornecedor";
            this.txtIdProduto_Fornecedor.Size = new System.Drawing.Size(143, 20);
            this.txtIdProduto_Fornecedor.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EMCEstoque.Properties.Resources.codigo_de_barra3;
            this.pictureBox1.Location = new System.Drawing.Point(521, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EMCEstoque.Properties.Resources.codigo_de_barra3;
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // cboFornecedor_IdPessoa
            // 
            this.cboFornecedor_IdPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboFornecedor_IdPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFornecedor_IdPessoa.FormattingEnabled = true;
            this.cboFornecedor_IdPessoa.Location = new System.Drawing.Point(77, 53);
            this.cboFornecedor_IdPessoa.Name = "cboFornecedor_IdPessoa";
            this.cboFornecedor_IdPessoa.Size = new System.Drawing.Size(540, 21);
            this.cboFornecedor_IdPessoa.TabIndex = 2;
            this.cboFornecedor_IdPessoa.SelectedValueChanged += new System.EventHandler(this.cboFornecedor_IdPessoa_SelectedValueChanged);
            // 
            // lblProduto
            // 
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(89, 5);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(447, 24);
            this.lblProduto.TabIndex = 17;
            this.lblProduto.Text = "Produto";
            this.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Código Interno do Fornecedor";
            // 
            // txtFornecedor_IdPessoa
            // 
            this.txtFornecedor_IdPessoa.Location = new System.Drawing.Point(8, 53);
            this.txtFornecedor_IdPessoa.Name = "txtFornecedor_IdPessoa";
            this.txtFornecedor_IdPessoa.Size = new System.Drawing.Size(65, 20);
            this.txtFornecedor_IdPessoa.TabIndex = 1;
            this.txtFornecedor_IdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFornecedor_IdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtFornecedor_IdPessoa_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fornecedor";
            // 
            // txtidEstq_Produto_Fornecedor
            // 
            this.txtidEstq_Produto_Fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Produto_Fornecedor.Location = new System.Drawing.Point(542, 9);
            this.txtidEstq_Produto_Fornecedor.MaxLength = 50;
            this.txtidEstq_Produto_Fornecedor.Name = "txtidEstq_Produto_Fornecedor";
            this.txtidEstq_Produto_Fornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Produto_Fornecedor.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Produto_Fornecedor.TabIndex = 10;
            this.txtidEstq_Produto_Fornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Produto_Fornecedor_Validating);
            // 
            // frmEstq_Produto_Fornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 479);
            this.Controls.Add(this.grdEstq_Produto_Fornecedor);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_Produto_Fornecedor";
            this.Text = "Produto | Código Interno do Fornecedor";
            this.Activated += new System.EventHandler(this.frmEstq_Produto_Fornecedor_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Produto_Fornecedor_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Produto_Fornecedor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Fornecedor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Produto_Fornecedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cboFornecedor_IdPessoa;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFornecedor_IdPessoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidEstq_Produto_Fornecedor;
        private System.Windows.Forms.TextBox txtIdProduto_Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_produto_fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_CodEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_produto_idestq_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_idPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproduto_fornecedor;
    }
}
