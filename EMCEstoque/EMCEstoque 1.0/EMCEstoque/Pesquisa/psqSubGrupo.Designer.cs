namespace EMCEstoque
{
    partial class psqSubGrupo
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
            this.txtidEstq_SubGrupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdEstq_SubGrupo = new System.Windows.Forms.DataGridView();
            this.idestq_subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_grupo_idEstq_grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_grupo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menor_unidadecontrole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadepadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttpSubGrupo = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_SubGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 63);
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
            this.ttpSubGrupo.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpSubGrupo.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpSubGrupo.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtidEstq_SubGrupo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.txtDescricao);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(1, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 55);
            this.panel2.TabIndex = 16;
            // 
            // txtidEstq_SubGrupo
            // 
            this.txtidEstq_SubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_SubGrupo.Location = new System.Drawing.Point(7, 28);
            this.txtidEstq_SubGrupo.MaxLength = 50;
            this.txtidEstq_SubGrupo.Name = "txtidEstq_SubGrupo";
            this.txtidEstq_SubGrupo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_SubGrupo.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_SubGrupo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Subgrupo";
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
            this.txtDescricao.Location = new System.Drawing.Point(76, 28);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(521, 20);
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
            // grdEstq_SubGrupo
            // 
            this.grdEstq_SubGrupo.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_SubGrupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdEstq_SubGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_SubGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_SubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_SubGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_subgrupo,
            this.Subgrupo,
            this.estq_grupo_idEstq_grupo,
            this.estq_grupo_descricao,
            this.menor_unidadecontrole,
            this.unidadepadrao});
            this.grdEstq_SubGrupo.Location = new System.Drawing.Point(1, 129);
            this.grdEstq_SubGrupo.MultiSelect = false;
            this.grdEstq_SubGrupo.Name = "grdEstq_SubGrupo";
            this.grdEstq_SubGrupo.ReadOnly = true;
            this.grdEstq_SubGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_SubGrupo.Size = new System.Drawing.Size(607, 225);
            this.grdEstq_SubGrupo.TabIndex = 17;
            this.grdEstq_SubGrupo.DoubleClick += new System.EventHandler(this.grdEstq_SubGrupo_DoubleClick);
            // 
            // idestq_subgrupo
            // 
            this.idestq_subgrupo.DataPropertyName = "idEstq_subgrupo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idestq_subgrupo.DefaultCellStyle = dataGridViewCellStyle8;
            this.idestq_subgrupo.HeaderText = "Código";
            this.idestq_subgrupo.Name = "idestq_subgrupo";
            this.idestq_subgrupo.ReadOnly = true;
            this.idestq_subgrupo.Width = 65;
            // 
            // Subgrupo
            // 
            this.Subgrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Subgrupo.DataPropertyName = "descricao";
            this.Subgrupo.HeaderText = "Subgrupo";
            this.Subgrupo.Name = "Subgrupo";
            this.Subgrupo.ReadOnly = true;
            this.Subgrupo.Width = 160;
            // 
            // estq_grupo_idEstq_grupo
            // 
            this.estq_grupo_idEstq_grupo.DataPropertyName = "estq_grupo_idEstq_grupo";
            this.estq_grupo_idEstq_grupo.HeaderText = "idestq_grupo";
            this.estq_grupo_idEstq_grupo.Name = "estq_grupo_idEstq_grupo";
            this.estq_grupo_idEstq_grupo.ReadOnly = true;
            this.estq_grupo_idEstq_grupo.Visible = false;
            this.estq_grupo_idEstq_grupo.Width = 93;
            // 
            // estq_grupo_descricao
            // 
            this.estq_grupo_descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estq_grupo_descricao.DataPropertyName = "estq_grupo_descricao";
            this.estq_grupo_descricao.HeaderText = "Grupo";
            this.estq_grupo_descricao.Name = "estq_grupo_descricao";
            this.estq_grupo_descricao.ReadOnly = true;
            this.estq_grupo_descricao.Width = 155;
            // 
            // menor_unidadecontrole
            // 
            this.menor_unidadecontrole.DataPropertyName = "menor_unidadecontrole";
            this.menor_unidadecontrole.HeaderText = "Menor Unid.";
            this.menor_unidadecontrole.Name = "menor_unidadecontrole";
            this.menor_unidadecontrole.ReadOnly = true;
            this.menor_unidadecontrole.Width = 90;
            // 
            // unidadepadrao
            // 
            this.unidadepadrao.DataPropertyName = "unidadepadrao";
            this.unidadepadrao.HeaderText = "Unid. Padrão";
            this.unidadepadrao.Name = "unidadepadrao";
            this.unidadepadrao.ReadOnly = true;
            this.unidadepadrao.Width = 94;
            // 
            // psqSubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 352);
            this.Controls.Add(this.grdEstq_SubGrupo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqSubGrupo";
            this.Text = "Pesquisa - Subgrupo";
            this.Load += new System.EventHandler(this.psqSubGrupo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqSubGrupo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_SubGrupo)).EndInit();
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
        private System.Windows.Forms.DataGridView grdEstq_SubGrupo;
        private System.Windows.Forms.TextBox txtidEstq_SubGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_subgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_grupo_idEstq_grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_grupo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn menor_unidadecontrole;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadepadrao;
        private System.Windows.Forms.ToolTip ttpSubGrupo;
    }
}