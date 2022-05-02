namespace EMCEstoque
{
    partial class frmEstq_Produto_Lote
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantidade = new MaskedNumber.MaskedNumber();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.cboEmbalagem = new System.Windows.Forms.ComboBox();
            this.txtDataValidade = new System.Windows.Forms.DateTimePicker();
            this.txtLoteProduto = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidEstq_Produto_Lote = new System.Windows.Forms.TextBox();
            this.grdEstq_Produto_Lote = new System.Windows.Forms.DataGridView();
            this.idestq_produto_lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_produto_idproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto_Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Lote)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtQuantidade);
            this.panel1.Controls.Add(this.txtUnidade);
            this.panel1.Controls.Add(this.cboEmbalagem);
            this.panel1.Controls.Add(this.txtDataValidade);
            this.panel1.Controls.Add(this.txtLoteProduto);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblProduto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtidEstq_Produto_Lote);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 136);
            this.panel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(8, 109);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(660, 20);
            this.txtDescricao.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Embalagem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Qtde Embalagem";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Unidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.CustomFormat = "0:0";
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Format = MaskedNumberFormat.Valor;
            this.txtQuantidade.Location = new System.Drawing.Point(427, 67);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(92, 20);
            this.txtQuantidade.TabIndex = 21;
            this.txtQuantidade.Text = "0,00";
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUnidade
            // 
            this.txtUnidade.Enabled = false;
            this.txtUnidade.Location = new System.Drawing.Point(522, 67);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(55, 20);
            this.txtUnidade.TabIndex = 20;
            // 
            // cboEmbalagem
            // 
            this.cboEmbalagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmbalagem.FormattingEnabled = true;
            this.cboEmbalagem.Location = new System.Drawing.Point(153, 67);
            this.cboEmbalagem.Name = "cboEmbalagem";
            this.cboEmbalagem.Size = new System.Drawing.Size(270, 21);
            this.cboEmbalagem.TabIndex = 1;
            this.cboEmbalagem.SelectedValueChanged += new System.EventHandler(this.cboEmbalagem_SelectedValueChanged);
            // 
            // txtDataValidade
            // 
            this.txtDataValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataValidade.Location = new System.Drawing.Point(580, 67);
            this.txtDataValidade.Name = "txtDataValidade";
            this.txtDataValidade.Size = new System.Drawing.Size(88, 20);
            this.txtDataValidade.TabIndex = 2;
            // 
            // txtLoteProduto
            // 
            this.txtLoteProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLoteProduto.Location = new System.Drawing.Point(8, 66);
            this.txtLoteProduto.MaxLength = 50;
            this.txtLoteProduto.Name = "txtLoteProduto";
            this.txtLoteProduto.Size = new System.Drawing.Size(143, 20);
            this.txtLoteProduto.TabIndex = 0;
            this.txtLoteProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtLoteProduto_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EMCEstoque.Properties.Resources.codigo_de_barra3;
            this.pictureBox1.Location = new System.Drawing.Point(568, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EMCEstoque.Properties.Resources.codigo_de_barra3;
            this.pictureBox2.Location = new System.Drawing.Point(4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lblProduto
            // 
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(110, 3);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(447, 24);
            this.lblProduto.TabIndex = 17;
            this.lblProduto.Text = "Produto";
            this.lblProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Validade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lote";
            // 
            // txtidEstq_Produto_Lote
            // 
            this.txtidEstq_Produto_Lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Produto_Lote.Location = new System.Drawing.Point(64, 43);
            this.txtidEstq_Produto_Lote.MaxLength = 50;
            this.txtidEstq_Produto_Lote.Name = "txtidEstq_Produto_Lote";
            this.txtidEstq_Produto_Lote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Produto_Lote.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Produto_Lote.TabIndex = 10;
            this.txtidEstq_Produto_Lote.Visible = false;
            this.txtidEstq_Produto_Lote.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Produto_Lote_Validating);
            // 
            // grdEstq_Produto_Lote
            // 
            this.grdEstq_Produto_Lote.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Produto_Lote.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Produto_Lote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Produto_Lote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Produto_Lote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Produto_Lote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_produto_lote,
            this.estq_produto_idproduto,
            this.Produto_Descricao,
            this.loteproduto,
            this.datavalidade});
            this.grdEstq_Produto_Lote.Location = new System.Drawing.Point(2, 214);
            this.grdEstq_Produto_Lote.MultiSelect = false;
            this.grdEstq_Produto_Lote.Name = "grdEstq_Produto_Lote";
            this.grdEstq_Produto_Lote.ReadOnly = true;
            this.grdEstq_Produto_Lote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Produto_Lote.Size = new System.Drawing.Size(672, 207);
            this.grdEstq_Produto_Lote.TabIndex = 20;
            this.grdEstq_Produto_Lote.DoubleClick += new System.EventHandler(this.grdEstq_Produto_Lote_DoubleClick);
            // 
            // idestq_produto_lote
            // 
            this.idestq_produto_lote.DataPropertyName = "idestq_produto_lote";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idestq_produto_lote.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_produto_lote.HeaderText = "Código";
            this.idestq_produto_lote.Name = "idestq_produto_lote";
            this.idestq_produto_lote.ReadOnly = true;
            this.idestq_produto_lote.Visible = false;
            this.idestq_produto_lote.Width = 65;
            // 
            // estq_produto_idproduto
            // 
            this.estq_produto_idproduto.DataPropertyName = "estq_produto_idproduto";
            this.estq_produto_idproduto.HeaderText = "Produto";
            this.estq_produto_idproduto.Name = "estq_produto_idproduto";
            this.estq_produto_idproduto.ReadOnly = true;
            this.estq_produto_idproduto.Visible = false;
            this.estq_produto_idproduto.Width = 69;
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
            // loteproduto
            // 
            this.loteproduto.DataPropertyName = "loteproduto";
            this.loteproduto.HeaderText = "Lote";
            this.loteproduto.Name = "loteproduto";
            this.loteproduto.ReadOnly = true;
            this.loteproduto.Width = 53;
            // 
            // datavalidade
            // 
            this.datavalidade.DataPropertyName = "datavalidade";
            this.datavalidade.HeaderText = "Validade";
            this.datavalidade.Name = "datavalidade";
            this.datavalidade.ReadOnly = true;
            this.datavalidade.Width = 73;
            // 
            // frmEstq_Produto_Lote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(676, 425);
            this.Controls.Add(this.grdEstq_Produto_Lote);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_Produto_Lote";
            this.Text = "Produto | Controle de Lote";
            this.Load += new System.EventHandler(this.frmEstq_Produto_Lote_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_Produto_Lote, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Produto_Lote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidEstq_Produto_Lote;
        private System.Windows.Forms.TextBox txtLoteProduto;
        private System.Windows.Forms.DateTimePicker txtDataValidade;
        private System.Windows.Forms.DataGridView grdEstq_Produto_Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_produto_lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_produto_idproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto_Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavalidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MaskedNumber.MaskedNumber txtQuantidade;
        private System.Windows.Forms.TextBox txtUnidade;
        private System.Windows.Forms.ComboBox cboEmbalagem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescricao;
    }
}
