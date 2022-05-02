namespace EMCEstoque
{
    partial class frmEstq_TipoProduto
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
            this.grdEstq_TipoProduto = new System.Windows.Forms.DataGridView();
            this.idestq_tipoproduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.controlaestoqueminimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prestacaoservico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familiaobrigatoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFamiliaObrigatoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPrestacaoServico = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboControlaEstoqueMinimo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidEstq_TipoProduto = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_TipoProduto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstq_TipoProduto
            // 
            this.grdEstq_TipoProduto.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_TipoProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_TipoProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_TipoProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_TipoProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_TipoProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_tipoproduto,
            this.descricao,
            this.controlaestoqueminimo,
            this.prestacaoservico,
            this.familiaobrigatoria});
            this.grdEstq_TipoProduto.Location = new System.Drawing.Point(3, 177);
            this.grdEstq_TipoProduto.MultiSelect = false;
            this.grdEstq_TipoProduto.Name = "grdEstq_TipoProduto";
            this.grdEstq_TipoProduto.ReadOnly = true;
            this.grdEstq_TipoProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_TipoProduto.Size = new System.Drawing.Size(629, 193);
            this.grdEstq_TipoProduto.TabIndex = 19;
            this.grdEstq_TipoProduto.DoubleClick += new System.EventHandler(this.grdEstq_TipoProduto_DoubleClick);
            // 
            // idestq_tipoproduto
            // 
            this.idestq_tipoproduto.DataPropertyName = "idestq_tipoproduto";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_tipoproduto.DefaultCellStyle = dataGridViewCellStyle2;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboFamiliaObrigatoria);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboPrestacaoServico);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboControlaEstoqueMinimo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidEstq_TipoProduto);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 104);
            this.panel1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(172, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "Família Obrigatória";
            // 
            // cboFamiliaObrigatoria
            // 
            this.cboFamiliaObrigatoria.FormattingEnabled = true;
            this.cboFamiliaObrigatoria.Location = new System.Drawing.Point(172, 75);
            this.cboFamiliaObrigatoria.Name = "cboFamiliaObrigatoria";
            this.cboFamiliaObrigatoria.Size = new System.Drawing.Size(70, 21);
            this.cboFamiliaObrigatoria.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(91, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Prestação Serviço";
            // 
            // cboPrestacaoServico
            // 
            this.cboPrestacaoServico.FormattingEnabled = true;
            this.cboPrestacaoServico.Location = new System.Drawing.Point(91, 75);
            this.cboPrestacaoServico.Name = "cboPrestacaoServico";
            this.cboPrestacaoServico.Size = new System.Drawing.Size(70, 21);
            this.cboPrestacaoServico.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Controla Estoq. Mínimo";
            // 
            // cboControlaEstoqueMinimo
            // 
            this.cboControlaEstoqueMinimo.FormattingEnabled = true;
            this.cboControlaEstoqueMinimo.Location = new System.Drawing.Point(10, 75);
            this.cboControlaEstoqueMinimo.Name = "cboControlaEstoqueMinimo";
            this.cboControlaEstoqueMinimo.Size = new System.Drawing.Size(70, 21);
            this.cboControlaEstoqueMinimo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de Produto";
            // 
            // txtidEstq_TipoProduto
            // 
            this.txtidEstq_TipoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_TipoProduto.Location = new System.Drawing.Point(10, 23);
            this.txtidEstq_TipoProduto.MaxLength = 50;
            this.txtidEstq_TipoProduto.Name = "txtidEstq_TipoProduto";
            this.txtidEstq_TipoProduto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_TipoProduto.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_TipoProduto.TabIndex = 1;
            this.txtidEstq_TipoProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_TipoProduto_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(75, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(541, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // frmEstq_TipoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 373);
            this.Controls.Add(this.grdEstq_TipoProduto);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_TipoProduto";
            this.Text = "Tipo de Produto";
            this.Activated += new System.EventHandler(this.frmEstq_TipoProduto_Activated);
            this.Load += new System.EventHandler(this.frmEstq_TipoProduto_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_TipoProduto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_TipoProduto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_TipoProduto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidEstq_TipoProduto;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ComboBox cboControlaEstoqueMinimo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFamiliaObrigatoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPrestacaoServico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_tipoproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn controlaestoqueminimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prestacaoservico;
        private System.Windows.Forms.DataGridViewTextBoxColumn familiaobrigatoria;
    }
}
