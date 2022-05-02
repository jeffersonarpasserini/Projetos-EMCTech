namespace EMCObras
{
    partial class psqObraModulo
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
            this.txtidObra_Etapa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEtapa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.txtidObra_Modulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdObra_Modulo = new System.Windows.Forms.DataGridView();
            this.ttpObraModulo = new System.Windows.Forms.ToolTip(this.components);
            this.idobra_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Módulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Modulo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 63);
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
            this.ttpObraModulo.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpObraModulo.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpObraModulo.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtidObra_Etapa);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtEtapa);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtModulo);
            this.panel2.Controls.Add(this.txtidObra_Modulo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 94);
            this.panel2.TabIndex = 18;
            // 
            // txtidObra_Etapa
            // 
            this.txtidObra_Etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Etapa.Location = new System.Drawing.Point(7, 63);
            this.txtidObra_Etapa.MaxLength = 50;
            this.txtidObra_Etapa.Name = "txtidObra_Etapa";
            this.txtidObra_Etapa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Etapa.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_Etapa.TabIndex = 17;
            this.txtidObra_Etapa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Etapa";
            // 
            // txtEtapa
            // 
            this.txtEtapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEtapa.Location = new System.Drawing.Point(76, 63);
            this.txtEtapa.Name = "txtEtapa";
            this.txtEtapa.Size = new System.Drawing.Size(449, 20);
            this.txtEtapa.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Código";
            // 
            // txtModulo
            // 
            this.txtModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModulo.Location = new System.Drawing.Point(76, 24);
            this.txtModulo.MaxLength = 50;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(449, 20);
            this.txtModulo.TabIndex = 13;
            // 
            // txtidObra_Modulo
            // 
            this.txtidObra_Modulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Modulo.Location = new System.Drawing.Point(7, 24);
            this.txtidObra_Modulo.MaxLength = 50;
            this.txtidObra_Modulo.Name = "txtidObra_Modulo";
            this.txtidObra_Modulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Modulo.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_Modulo.TabIndex = 12;
            this.txtidObra_Modulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Módulo";
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
            // grdObra_Modulo
            // 
            this.grdObra_Modulo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra_Modulo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdObra_Modulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdObra_Modulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra_Modulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra_Modulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_modulo,
            this.Módulo,
            this.idobra_etapa,
            this.etapa});
            this.grdObra_Modulo.Location = new System.Drawing.Point(1, 168);
            this.grdObra_Modulo.MultiSelect = false;
            this.grdObra_Modulo.Name = "grdObra_Modulo";
            this.grdObra_Modulo.ReadOnly = true;
            this.grdObra_Modulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra_Modulo.Size = new System.Drawing.Size(544, 264);
            this.grdObra_Modulo.TabIndex = 19;
            this.grdObra_Modulo.DoubleClick += new System.EventHandler(this.grdObra_Modulo_DoubleClick);
            // 
            // idobra_modulo
            // 
            this.idobra_modulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idobra_modulo.DataPropertyName = "idobra_modulo";
            this.idobra_modulo.HeaderText = "Código";
            this.idobra_modulo.Name = "idobra_modulo";
            this.idobra_modulo.ReadOnly = true;
            // 
            // Módulo
            // 
            this.Módulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Módulo.DataPropertyName = "descricao";
            this.Módulo.HeaderText = "Módulo";
            this.Módulo.Name = "Módulo";
            this.Módulo.ReadOnly = true;
            this.Módulo.Width = 200;
            // 
            // idobra_etapa
            // 
            this.idobra_etapa.DataPropertyName = "obra_etapa_idobra_etapa";
            this.idobra_etapa.HeaderText = "idobra_etapa";
            this.idobra_etapa.Name = "idobra_etapa";
            this.idobra_etapa.ReadOnly = true;
            this.idobra_etapa.Visible = false;
            this.idobra_etapa.Width = 94;
            // 
            // etapa
            // 
            this.etapa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.etapa.DataPropertyName = "Obra_Etapa_Descricao";
            this.etapa.HeaderText = "Etapa";
            this.etapa.Name = "etapa";
            this.etapa.ReadOnly = true;
            this.etapa.Width = 200;
            // 
            // psqObraModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 433);
            this.Controls.Add(this.grdObra_Modulo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqObraModulo";
            this.Text = "Pesquisa - Obra Modulo";
            this.Load += new System.EventHandler(this.psqObraModulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqObraModulo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Modulo)).EndInit();
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
        private System.Windows.Forms.DataGridView grdObra_Modulo;
        private System.Windows.Forms.TextBox txtidObra_Modulo;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.ToolTip ttpObraModulo;
        private System.Windows.Forms.TextBox txtidObra_Etapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEtapa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Módulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
    }
}