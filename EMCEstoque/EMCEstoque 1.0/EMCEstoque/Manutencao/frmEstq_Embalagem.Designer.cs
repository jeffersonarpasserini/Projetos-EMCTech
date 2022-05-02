namespace EMCEstoque
{
    partial class frmEstq_Embalagem
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
            this.grdEstq_Embalagem = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboIdUnidade = new System.Windows.Forms.ComboBox();
            this.txtQuantidade = new MaskedNumber.MaskedNumber();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdEstq_Embalagem = new MaskedNumber.MaskedNumber();
            this.idEstq_Embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abreviacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Embalagem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstq_Embalagem
            // 
            this.grdEstq_Embalagem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Embalagem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Embalagem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Embalagem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEstq_Embalagem,
            this.descricao,
            this.abreviacao,
            this.quantidade});
            this.grdEstq_Embalagem.Location = new System.Drawing.Point(2, 127);
            this.grdEstq_Embalagem.Name = "grdEstq_Embalagem";
            this.grdEstq_Embalagem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Embalagem.Size = new System.Drawing.Size(629, 240);
            this.grdEstq_Embalagem.TabIndex = 1;
            this.grdEstq_Embalagem.DoubleClick += new System.EventHandler(this.grdEstq_Embalagem_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboIdUnidade);
            this.panel1.Controls.Add(this.txtQuantidade);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIdEstq_Embalagem);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 52);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantidade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição da Embalagem";
            // 
            // cboIdUnidade
            // 
            this.cboIdUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdUnidade.FormattingEnabled = true;
            this.cboIdUnidade.Location = new System.Drawing.Point(430, 23);
            this.cboIdUnidade.Name = "cboIdUnidade";
            this.cboIdUnidade.Size = new System.Drawing.Size(99, 21);
            this.cboIdUnidade.TabIndex = 2;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.CustomFormat = "0";
            this.txtQuantidade.Format = MaskedNumberFormat.Peso;
            this.txtQuantidade.Location = new System.Drawing.Point(532, 23);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(92, 20);
            this.txtQuantidade.TabIndex = 3;
            this.txtQuantidade.Text = "0,000";
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(76, 23);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(351, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // txtIdEstq_Embalagem
            // 
            this.txtIdEstq_Embalagem.CustomFormat = "0";
            this.txtIdEstq_Embalagem.Format = MaskedNumberFormat.Custom;
            this.txtIdEstq_Embalagem.Location = new System.Drawing.Point(3, 23);
            this.txtIdEstq_Embalagem.Name = "txtIdEstq_Embalagem";
            this.txtIdEstq_Embalagem.Size = new System.Drawing.Size(71, 20);
            this.txtIdEstq_Embalagem.TabIndex = 0;
            this.txtIdEstq_Embalagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdEstq_Embalagem.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEstq_Embalagem_Validating);
            // 
            // idEstq_Embalagem
            // 
            this.idEstq_Embalagem.DataPropertyName = "idestq_embalagem";
            this.idEstq_Embalagem.HeaderText = "Código";
            this.idEstq_Embalagem.Name = "idEstq_Embalagem";
            this.idEstq_Embalagem.Width = 50;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.Width = 300;
            // 
            // abreviacao
            // 
            this.abreviacao.DataPropertyName = "abreviacao";
            this.abreviacao.HeaderText = "Unidade";
            this.abreviacao.Name = "abreviacao";
            this.abreviacao.Width = 50;
            // 
            // quantidade
            // 
            this.quantidade.DataPropertyName = "quantidade";
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            // 
            // frmEstq_Embalagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 370);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdEstq_Embalagem);
            this.Name = "frmEstq_Embalagem";
            this.Text = "Embalagem";
            this.Load += new System.EventHandler(this.frmEstq_Embalagem_Load);
            this.Controls.SetChildIndex(this.grdEstq_Embalagem, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Embalagem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_Embalagem;
        private System.Windows.Forms.Panel panel1;
        private MaskedNumber.MaskedNumber txtIdEstq_Embalagem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboIdUnidade;
        private MaskedNumber.MaskedNumber txtQuantidade;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEstq_Embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
    }
}
