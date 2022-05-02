namespace EMCEstoque
{
    partial class frmEstq_Produto_Volume
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdEstq_Produto_Volume = new System.Windows.Forms.DataGridView();
            this.idestq_produto_volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_produto_idestq_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idestq_produto_unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidade_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatorconversao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboEstq_Produto_Unidade = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEstq_Produto_Unidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidEstq_Produto_Volume = new System.Windows.Forms.TextBox();
            this.txtFatorConversao = new MaskedNumber.MaskedNumber();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Volume)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEstq_Produto_Volume
            // 
            this.grdEstq_Produto_Volume.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Produto_Volume.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdEstq_Produto_Volume.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Produto_Volume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Produto_Volume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Produto_Volume.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_produto_volume,
            this.estq_produto_idestq_produto,
            this.Produto_Descricao,
            this.idestq_produto_unidade,
            this.Unidade_Descricao,
            this.fatorconversao});
            this.grdEstq_Produto_Volume.Location = new System.Drawing.Point(2, 162);
            this.grdEstq_Produto_Volume.MultiSelect = false;
            this.grdEstq_Produto_Volume.Name = "grdEstq_Produto_Volume";
            this.grdEstq_Produto_Volume.ReadOnly = true;
            this.grdEstq_Produto_Volume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Produto_Volume.Size = new System.Drawing.Size(629, 258);
            this.grdEstq_Produto_Volume.TabIndex = 18;
            this.grdEstq_Produto_Volume.DoubleClick += new System.EventHandler(this.grdEstq_Produto_Volume_DoubleClick);
            // 
            // idestq_produto_volume
            // 
            this.idestq_produto_volume.DataPropertyName = "idestq_produto_volume";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idestq_produto_volume.DefaultCellStyle = dataGridViewCellStyle4;
            this.idestq_produto_volume.HeaderText = "Código";
            this.idestq_produto_volume.Name = "idestq_produto_volume";
            this.idestq_produto_volume.ReadOnly = true;
            this.idestq_produto_volume.Visible = false;
            this.idestq_produto_volume.Width = 65;
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
            // idestq_produto_unidade
            // 
            this.idestq_produto_unidade.DataPropertyName = "idestq_produto_unidade";
            this.idestq_produto_unidade.HeaderText = "Cod_Unidade";
            this.idestq_produto_unidade.Name = "idestq_produto_unidade";
            this.idestq_produto_unidade.ReadOnly = true;
            this.idestq_produto_unidade.Visible = false;
            this.idestq_produto_unidade.Width = 97;
            // 
            // Unidade_Descricao
            // 
            this.Unidade_Descricao.DataPropertyName = "Unidade_Descricao";
            this.Unidade_Descricao.HeaderText = "Unidade";
            this.Unidade_Descricao.Name = "Unidade_Descricao";
            this.Unidade_Descricao.ReadOnly = true;
            this.Unidade_Descricao.Width = 72;
            // 
            // fatorconversao
            // 
            this.fatorconversao.DataPropertyName = "fatorconversao";
            this.fatorconversao.HeaderText = "Fator de Conversão";
            this.fatorconversao.Name = "fatorconversao";
            this.fatorconversao.ReadOnly = true;
            this.fatorconversao.Width = 114;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtFatorConversao);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.cboEstq_Produto_Unidade);
            this.panel1.Controls.Add(this.lblProduto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEstq_Produto_Unidade);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtidEstq_Produto_Volume);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 84);
            this.panel1.TabIndex = 17;
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
            // cboEstq_Produto_Unidade
            // 
            this.cboEstq_Produto_Unidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEstq_Produto_Unidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstq_Produto_Unidade.FormattingEnabled = true;
            this.cboEstq_Produto_Unidade.Location = new System.Drawing.Point(77, 52);
            this.cboEstq_Produto_Unidade.Name = "cboEstq_Produto_Unidade";
            this.cboEstq_Produto_Unidade.Size = new System.Drawing.Size(444, 21);
            this.cboEstq_Produto_Unidade.TabIndex = 2;
            this.cboEstq_Produto_Unidade.SelectedValueChanged += new System.EventHandler(this.cboEstq_Produto_Unidade_SelectedValueChanged);
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
            this.label4.Location = new System.Drawing.Point(522, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fator de Conversão";
            // 
            // txtEstq_Produto_Unidade
            // 
            this.txtEstq_Produto_Unidade.Location = new System.Drawing.Point(8, 53);
            this.txtEstq_Produto_Unidade.Name = "txtEstq_Produto_Unidade";
            this.txtEstq_Produto_Unidade.Size = new System.Drawing.Size(63, 20);
            this.txtEstq_Produto_Unidade.TabIndex = 1;
            this.txtEstq_Produto_Unidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstq_Produto_Unidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtEstq_Produto_Unidade_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Unidade de Produto";
            // 
            // txtidEstq_Produto_Volume
            // 
            this.txtidEstq_Produto_Volume.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Produto_Volume.Location = new System.Drawing.Point(538, 10);
            this.txtidEstq_Produto_Volume.MaxLength = 50;
            this.txtidEstq_Produto_Volume.Name = "txtidEstq_Produto_Volume";
            this.txtidEstq_Produto_Volume.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Produto_Volume.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Produto_Volume.TabIndex = 10;
            this.txtidEstq_Produto_Volume.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Produto_Volume_Validating);
            // 
            // txtFatorConversao
            // 
            this.txtFatorConversao.CustomFormat = "0:0";
            this.txtFatorConversao.Format = MaskedNumberFormat.Peso;
            this.txtFatorConversao.Location = new System.Drawing.Point(526, 52);
            this.txtFatorConversao.Name = "txtFatorConversao";
            this.txtFatorConversao.Size = new System.Drawing.Size(96, 20);
            this.txtFatorConversao.TabIndex = 3;
            this.txtFatorConversao.Text = "0,000";
            this.txtFatorConversao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmEstq_Produto_Volume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 423);
            this.Controls.Add(this.grdEstq_Produto_Volume);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_Produto_Volume";
            this.Text = "Produto | Volume";
            this.Activated += new System.EventHandler(this.frmEstq_Produto_Volume_Activated);
            this.Load += new System.EventHandler(this.frmEstq_Produto_Volume_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Produto_Volume, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Volume)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Produto_Volume;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEstq_Produto_Unidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEstq_Produto_Unidade;
        private System.Windows.Forms.TextBox txtidEstq_Produto_Volume;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_produto_volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_produto_idestq_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_produto_unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatorconversao;
        private MaskedNumber.MaskedNumber txtFatorConversao;
    }
}
