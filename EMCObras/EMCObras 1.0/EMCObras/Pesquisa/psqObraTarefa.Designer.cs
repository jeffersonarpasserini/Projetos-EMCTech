namespace EMCObras
{
    partial class psqObraTarefa
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
            this.txtidObra_Tarefas = new System.Windows.Forms.TextBox();
            this.txtTarefa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.txtidObra_Modulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grdObra_Tarefa = new System.Windows.Forms.DataGridView();
            this.ttpPsqTarefa = new System.Windows.Forms.ToolTip(this.components);
            this.idobra_tarefas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idobra_etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Tarefa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 63);
            this.panel1.TabIndex = 18;
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
            this.ttpPsqTarefa.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
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
            this.ttpPsqTarefa.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
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
            this.ttpPsqTarefa.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtidObra_Tarefas);
            this.panel2.Controls.Add(this.txtTarefa);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtModulo);
            this.panel2.Controls.Add(this.txtidObra_Modulo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 94);
            this.panel2.TabIndex = 19;
            // 
            // txtidObra_Tarefas
            // 
            this.txtidObra_Tarefas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Tarefas.Location = new System.Drawing.Point(7, 24);
            this.txtidObra_Tarefas.MaxLength = 50;
            this.txtidObra_Tarefas.Name = "txtidObra_Tarefas";
            this.txtidObra_Tarefas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidObra_Tarefas.Size = new System.Drawing.Size(63, 20);
            this.txtidObra_Tarefas.TabIndex = 17;
            this.txtidObra_Tarefas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTarefa
            // 
            this.txtTarefa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTarefa.Location = new System.Drawing.Point(77, 24);
            this.txtTarefa.MaxLength = 50;
            this.txtTarefa.Name = "txtTarefa";
            this.txtTarefa.Size = new System.Drawing.Size(669, 20);
            this.txtTarefa.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Módulo";
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
            this.txtModulo.Location = new System.Drawing.Point(77, 63);
            this.txtModulo.MaxLength = 50;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(668, 20);
            this.txtModulo.TabIndex = 13;
            // 
            // txtidObra_Modulo
            // 
            this.txtidObra_Modulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidObra_Modulo.Location = new System.Drawing.Point(7, 63);
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
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Tarefa";
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
            // grdObra_Tarefa
            // 
            this.grdObra_Tarefa.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdObra_Tarefa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdObra_Tarefa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdObra_Tarefa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdObra_Tarefa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdObra_Tarefa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idobra_tarefas,
            this.descricao,
            this.idobra_modulo,
            this.Modulo,
            this.idobra_etapa,
            this.etapa});
            this.grdObra_Tarefa.Location = new System.Drawing.Point(1, 158);
            this.grdObra_Tarefa.MultiSelect = false;
            this.grdObra_Tarefa.Name = "grdObra_Tarefa";
            this.grdObra_Tarefa.ReadOnly = true;
            this.grdObra_Tarefa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdObra_Tarefa.Size = new System.Drawing.Size(758, 278);
            this.grdObra_Tarefa.TabIndex = 20;
            this.grdObra_Tarefa.DoubleClick += new System.EventHandler(this.grdObra_Tarefa_DoubleClick);
            // 
            // idobra_tarefas
            // 
            this.idobra_tarefas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idobra_tarefas.DataPropertyName = "idobra_tarefas";
            this.idobra_tarefas.HeaderText = "Código";
            this.idobra_tarefas.Name = "idobra_tarefas";
            this.idobra_tarefas.ReadOnly = true;
            this.idobra_tarefas.Width = 65;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Tarefa";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 260;
            // 
            // idobra_modulo
            // 
            this.idobra_modulo.DataPropertyName = "idobra_modulo";
            this.idobra_modulo.HeaderText = "idobra_modulo";
            this.idobra_modulo.Name = "idobra_modulo";
            this.idobra_modulo.ReadOnly = true;
            this.idobra_modulo.Visible = false;
            this.idobra_modulo.Width = 101;
            // 
            // Modulo
            // 
            this.Modulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Modulo.DataPropertyName = "Obra_Modulo_Descricao";
            this.Modulo.HeaderText = "Módulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            this.Modulo.Width = 200;
            // 
            // idobra_etapa
            // 
            this.idobra_etapa.DataPropertyName = "idobra_etapa";
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
            this.etapa.Width = 190;
            // 
            // psqObraTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 436);
            this.Controls.Add(this.grdObra_Tarefa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqObraTarefa";
            this.Text = "Pesquisa - Tarefa";
            this.Load += new System.EventHandler(this.psqObraTarefa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqObraTarefa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObra_Tarefa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.TextBox txtidObra_Modulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtidObra_Tarefas;
        private System.Windows.Forms.TextBox txtTarefa;
        private System.Windows.Forms.DataGridView grdObra_Tarefa;
        private System.Windows.Forms.ToolTip ttpPsqTarefa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_tarefas;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idobra_etapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn etapa;
    }
}