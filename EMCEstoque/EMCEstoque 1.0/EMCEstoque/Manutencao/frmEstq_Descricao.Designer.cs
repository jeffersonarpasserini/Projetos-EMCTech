namespace EMCEstoque
{
    partial class frmEstq_Descricao
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
            this.grdEstq_Descricao = new System.Windows.Forms.DataGridView();
            this.idestq_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_CodEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idestq_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente_idPessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboCliente_IdPessoa = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente_IdPessoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidEstq_Descricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Descricao)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEstq_Descricao
            // 
            this.grdEstq_Descricao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Descricao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Descricao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Descricao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Descricao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Descricao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_descricao,
            this.cliente_CodEmpresa,
            this.Cliente,
            this.idestq_produto,
            this.Produto,
            this.cliente_idPessoa,
            this.Descricao});
            this.grdEstq_Descricao.Location = new System.Drawing.Point(2, 205);
            this.grdEstq_Descricao.MultiSelect = false;
            this.grdEstq_Descricao.Name = "grdEstq_Descricao";
            this.grdEstq_Descricao.ReadOnly = true;
            this.grdEstq_Descricao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Descricao.Size = new System.Drawing.Size(629, 270);
            this.grdEstq_Descricao.TabIndex = 22;
            this.grdEstq_Descricao.DoubleClick += new System.EventHandler(this.grdEstq_Descricao_DoubleClick);
            // 
            // idestq_descricao
            // 
            this.idestq_descricao.DataPropertyName = "idestq_descricao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idestq_descricao.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_descricao.HeaderText = "Código";
            this.idestq_descricao.Name = "idestq_descricao";
            this.idestq_descricao.ReadOnly = true;
            this.idestq_descricao.Visible = false;
            this.idestq_descricao.Width = 65;
            // 
            // cliente_CodEmpresa
            // 
            this.cliente_CodEmpresa.DataPropertyName = "cliente_CodEmpresa";
            this.cliente_CodEmpresa.HeaderText = "CodEmpresa";
            this.cliente_CodEmpresa.Name = "cliente_CodEmpresa";
            this.cliente_CodEmpresa.ReadOnly = true;
            this.cliente_CodEmpresa.Visible = false;
            this.cliente_CodEmpresa.Width = 92;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 64;
            // 
            // idestq_produto
            // 
            this.idestq_produto.DataPropertyName = "idEstq_Produto";
            this.idestq_produto.HeaderText = "Produto";
            this.idestq_produto.Name = "idestq_produto";
            this.idestq_produto.ReadOnly = true;
            this.idestq_produto.Visible = false;
            this.idestq_produto.Width = 69;
            // 
            // Produto
            // 
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto_Descricao";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Visible = false;
            this.Produto.Width = 123;
            // 
            // cliente_idPessoa
            // 
            this.cliente_idPessoa.DataPropertyName = "cliente_idPessoa";
            this.cliente_idPessoa.HeaderText = "CodCliente";
            this.cliente_idPessoa.Name = "cliente_idPessoa";
            this.cliente_idPessoa.ReadOnly = true;
            this.cliente_idPessoa.Visible = false;
            this.cliente_idPessoa.Width = 83;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição Personalizada";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 136;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.cboCliente_IdPessoa);
            this.panel1.Controls.Add(this.lblProduto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCliente_IdPessoa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtidEstq_Descricao);
            this.panel1.Location = new System.Drawing.Point(3, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 125);
            this.panel1.TabIndex = 21;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(8, 95);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(340, 20);
            this.txtDescricao.TabIndex = 3;
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
            // cboCliente_IdPessoa
            // 
            this.cboCliente_IdPessoa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboCliente_IdPessoa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCliente_IdPessoa.FormattingEnabled = true;
            this.cboCliente_IdPessoa.Location = new System.Drawing.Point(77, 53);
            this.cboCliente_IdPessoa.Name = "cboCliente_IdPessoa";
            this.cboCliente_IdPessoa.Size = new System.Drawing.Size(540, 21);
            this.cboCliente_IdPessoa.TabIndex = 2;
            this.cboCliente_IdPessoa.SelectedValueChanged += new System.EventHandler(this.cboCliente_IdPessoa_SelectedValueChanged);
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
            this.label4.Size = new System.Drawing.Size(179, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Descrição Personalizada do Produto";
            // 
            // txtCliente_IdPessoa
            // 
            this.txtCliente_IdPessoa.Location = new System.Drawing.Point(8, 53);
            this.txtCliente_IdPessoa.Name = "txtCliente_IdPessoa";
            this.txtCliente_IdPessoa.Size = new System.Drawing.Size(65, 20);
            this.txtCliente_IdPessoa.TabIndex = 1;
            this.txtCliente_IdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCliente_IdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtCliente_IdPessoa_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cliente";
            // 
            // txtidEstq_Descricao
            // 
            this.txtidEstq_Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Descricao.Location = new System.Drawing.Point(542, 9);
            this.txtidEstq_Descricao.MaxLength = 50;
            this.txtidEstq_Descricao.Name = "txtidEstq_Descricao";
            this.txtidEstq_Descricao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Descricao.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Descricao.TabIndex = 10;
            this.txtidEstq_Descricao.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Descricao_Validating);
            // 
            // frmEstq_Descricao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 477);
            this.Controls.Add(this.grdEstq_Descricao);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_Descricao";
            this.Text = "Produto | Descrição Personalizada do Cliente";
            this.Activated += new System.EventHandler(this.frmEstq_Descricao_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Descricao_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Descricao, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Descricao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Descricao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cboCliente_IdPessoa;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente_IdPessoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidEstq_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_CodEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente_idPessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
    }
}
