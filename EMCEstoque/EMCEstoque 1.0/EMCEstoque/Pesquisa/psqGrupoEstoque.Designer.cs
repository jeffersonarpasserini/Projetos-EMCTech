namespace EMCEstoque
{
    partial class psqGrupoEstoque
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
            this.txtidEstq_Grupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdEstq_Grupo = new System.Windows.Forms.DataGridView();
            this.ttpPsqGrupoEstoque = new System.Windows.Forms.ToolTip(this.components);
            this.idestq_grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatuEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fatusaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faturamentoentrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Grupo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 63);
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
            this.ttpPsqGrupoEstoque.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpPsqGrupoEstoque.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpPsqGrupoEstoque.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtidEstq_Grupo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 55);
            this.panel2.TabIndex = 16;
            // 
            // txtidEstq_Grupo
            // 
            this.txtidEstq_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_Grupo.Location = new System.Drawing.Point(7, 24);
            this.txtidEstq_Grupo.MaxLength = 50;
            this.txtidEstq_Grupo.Name = "txtidEstq_Grupo";
            this.txtidEstq_Grupo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Grupo.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_Grupo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Grupo";
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
            this.txtDescricao.Location = new System.Drawing.Point(79, 24);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(424, 20);
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
            // grdEstq_Grupo
            // 
            this.grdEstq_Grupo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_Grupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstq_Grupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_Grupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_Grupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_grupo,
            this.descricao,
            this.FatuEntrada,
            this.Fatusaida,
            this.faturamentoentrada,
            this.Column1});
            this.grdEstq_Grupo.Location = new System.Drawing.Point(0, 129);
            this.grdEstq_Grupo.MultiSelect = false;
            this.grdEstq_Grupo.Name = "grdEstq_Grupo";
            this.grdEstq_Grupo.ReadOnly = true;
            this.grdEstq_Grupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_Grupo.Size = new System.Drawing.Size(516, 242);
            this.grdEstq_Grupo.TabIndex = 18;
            this.grdEstq_Grupo.DoubleClick += new System.EventHandler(this.grdEstq_Grupo_DoubleClick);
            // 
            // idestq_grupo
            // 
            this.idestq_grupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idestq_grupo.DataPropertyName = "idestq_grupo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idestq_grupo.DefaultCellStyle = dataGridViewCellStyle2;
            this.idestq_grupo.HeaderText = "Código";
            this.idestq_grupo.Name = "idestq_grupo";
            this.idestq_grupo.ReadOnly = true;
            this.idestq_grupo.Width = 80;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Grupo";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 173;
            // 
            // FatuEntrada
            // 
            this.FatuEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FatuEntrada.DataPropertyName = "fatuentrada";
            this.FatuEntrada.HeaderText = "Faturamento na Entrada";
            this.FatuEntrada.Name = "FatuEntrada";
            this.FatuEntrada.ReadOnly = true;
            // 
            // Fatusaida
            // 
            this.Fatusaida.DataPropertyName = "fatusaida";
            this.Fatusaida.HeaderText = "Faturamento na Saída";
            this.Fatusaida.Name = "Fatusaida";
            this.Fatusaida.ReadOnly = true;
            // 
            // faturamentoentrada
            // 
            this.faturamentoentrada.DataPropertyName = "faturamentoentrada";
            this.faturamentoentrada.HeaderText = "faturamentoentrada";
            this.faturamentoentrada.Name = "faturamentoentrada";
            this.faturamentoentrada.ReadOnly = true;
            this.faturamentoentrada.Visible = false;
            this.faturamentoentrada.Width = 124;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "faturamentosaida";
            this.Column1.HeaderText = "faturamentosaida";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 113;
            // 
            // psqGrupoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 370);
            this.Controls.Add(this.grdEstq_Grupo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqGrupoEstoque";
            this.Text = "Pesquisa - Grupo Estoque";
            this.Load += new System.EventHandler(this.psqGrupoEstoque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqGrupoEstoque_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_Grupo)).EndInit();
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
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdEstq_Grupo;
        private System.Windows.Forms.TextBox txtidEstq_Grupo;
        private System.Windows.Forms.ToolTip ttpPsqGrupoEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatuEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fatusaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn faturamentoentrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}