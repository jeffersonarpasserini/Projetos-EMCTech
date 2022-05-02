namespace EMCObras
{
    partial class psqObra
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
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdObra = new System.Windows.Forms.DataGridView();
            this.abreviacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoObra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtainicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtafinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_cronograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpObra = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 63);
            this.panel1.TabIndex = 17;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCObras.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 3;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpObra.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = global::EMCObras.Properties.Resources.binoculo_32x32;
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpObra.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCObras.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpObra.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtDescricaoObra);
            this.panel2.Controls.Add(this.txtAbreviacao);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 55);
            this.panel2.TabIndex = 18;
            // 
            // txtDescricaoObra
            // 
            this.txtDescricaoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoObra.Location = new System.Drawing.Point(80, 24);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.Size = new System.Drawing.Size(513, 20);
            this.txtDescricaoObra.TabIndex = 13;
            // 
            // txtAbreviacao
            // 
            this.txtAbreviacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviacao.Location = new System.Drawing.Point(7, 24);
            this.txtAbreviacao.Name = "txtAbreviacao";
            this.txtAbreviacao.Size = new System.Drawing.Size(67, 20);
            this.txtAbreviacao.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Descrição";
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
            // grdObra
            // 
            this.grdObra.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdObra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.abreviacao,
            this.DescricaoObra,
            this.dtainicio,
            this.dtafinal,
            this.situacao,
            this.idobra_cronograma});
            this.grdObra.Location = new System.Drawing.Point(1, 132);
            this.grdObra.Name = "grdObra";
            this.grdObra.ReadOnly = true;
            this.grdObra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra.Size = new System.Drawing.Size(604, 229);
            this.grdObra.TabIndex = 19;
            this.grdObra.DoubleClick += new System.EventHandler(this.grdObra_DoubleClick);
            // 
            // abreviacao
            // 
            this.abreviacao.DataPropertyName = "abreviacao";
            this.abreviacao.HeaderText = "Código";
            this.abreviacao.Name = "abreviacao";
            this.abreviacao.ReadOnly = true;
            // 
            // DescricaoObra
            // 
            this.DescricaoObra.DataPropertyName = "descricao";
            this.DescricaoObra.HeaderText = "Descrição";
            this.DescricaoObra.Name = "DescricaoObra";
            this.DescricaoObra.ReadOnly = true;
            // 
            // dtainicio
            // 
            this.dtainicio.DataPropertyName = "dtainicio";
            this.dtainicio.HeaderText = "Início";
            this.dtainicio.Name = "dtainicio";
            this.dtainicio.ReadOnly = true;
            // 
            // dtafinal
            // 
            this.dtafinal.DataPropertyName = "dtafinal";
            this.dtafinal.HeaderText = "Final";
            this.dtafinal.Name = "dtafinal";
            this.dtafinal.ReadOnly = true;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            // 
            // idobra_cronograma
            // 
            this.idobra_cronograma.DataPropertyName = "idobra_cronograma";
            this.idobra_cronograma.HeaderText = "Id";
            this.idobra_cronograma.Name = "idobra_cronograma";
            this.idobra_cronograma.ReadOnly = true;
            this.idobra_cronograma.Visible = false;
            // 
            // psqObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 361);
            this.Controls.Add(this.grdObra);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqObra";
            this.Text = "Pesquisa - Obra";
            this.Load += new System.EventHandler(this.psqObra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqObra_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.DataGridView grdObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoObra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtainicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtafinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_cronograma;
        private System.Windows.Forms.ToolTip ttpObra;
    }
}