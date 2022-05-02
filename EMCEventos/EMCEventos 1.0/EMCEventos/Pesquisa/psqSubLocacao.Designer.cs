namespace EMCEventos
{
    partial class psqSubLocacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqSubLocacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdSubLocacao = new System.Windows.Forms.TextBox();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEvento = new System.Windows.Forms.Button();
            this.txtDescEvento = new System.Windows.Forms.TextBox();
            this.txtIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdEvento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdPsqSubLocacao = new System.Windows.Forms.DataGridView();
            this.idevt_sublocacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idevt_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoevento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqSubLocacao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.txtIdSubLocacao);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 63);
            this.panel1.TabIndex = 130;
            // 
            // txtIdSubLocacao
            // 
            this.txtIdSubLocacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdSubLocacao.Location = new System.Drawing.Point(427, 11);
            this.txtIdSubLocacao.MaxLength = 50;
            this.txtIdSubLocacao.Name = "txtIdSubLocacao";
            this.txtIdSubLocacao.Size = new System.Drawing.Size(40, 20);
            this.txtIdSubLocacao.TabIndex = 111;
            this.txtIdSubLocacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdSubLocacao.Visible = false;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 14;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 13;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEvento);
            this.panel2.Controls.Add(this.txtIdBox);
            this.panel2.Controls.Add(this.txtDescEvento);
            this.panel2.Controls.Add(this.txtIdEvento);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 46);
            this.panel2.TabIndex = 131;
            // 
            // btnEvento
            // 
            this.btnEvento.Image = ((System.Drawing.Image)(resources.GetObject("btnEvento.Image")));
            this.btnEvento.Location = new System.Drawing.Point(52, 18);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(30, 22);
            this.btnEvento.TabIndex = 20;
            this.btnEvento.UseVisualStyleBackColor = true;
            this.btnEvento.Click += new System.EventHandler(this.btnEvento_Click);
            // 
            // txtDescEvento
            // 
            this.txtDescEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescEvento.Location = new System.Drawing.Point(83, 19);
            this.txtDescEvento.MaxLength = 50;
            this.txtDescEvento.Name = "txtDescEvento";
            this.txtDescEvento.Size = new System.Drawing.Size(306, 20);
            this.txtDescEvento.TabIndex = 21;
            // 
            // txtIdBox
            // 
            this.txtIdBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdBox.Location = new System.Drawing.Point(391, 19);
            this.txtIdBox.Name = "txtIdBox";
            this.txtIdBox.Size = new System.Drawing.Size(81, 20);
            this.txtIdBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Box";
            // 
            // txtIdEvento
            // 
            this.txtIdEvento.Location = new System.Drawing.Point(2, 19);
            this.txtIdEvento.Name = "txtIdEvento";
            this.txtIdEvento.Size = new System.Drawing.Size(49, 20);
            this.txtIdEvento.TabIndex = 19;
            this.txtIdEvento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEvento_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Evento";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.grdPsqSubLocacao);
            this.panel3.Location = new System.Drawing.Point(2, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 198);
            this.panel3.TabIndex = 132;
            // 
            // grdPsqSubLocacao
            // 
            this.grdPsqSubLocacao.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqSubLocacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdPsqSubLocacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPsqSubLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqSubLocacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idevt_sublocacao,
            this.idevt_evento,
            this.descricaoevento,
            this.idbox,
            this.descricao});
            this.grdPsqSubLocacao.Location = new System.Drawing.Point(2, 2);
            this.grdPsqSubLocacao.MultiSelect = false;
            this.grdPsqSubLocacao.Name = "grdPsqSubLocacao";
            this.grdPsqSubLocacao.ReadOnly = true;
            this.grdPsqSubLocacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqSubLocacao.Size = new System.Drawing.Size(470, 191);
            this.grdPsqSubLocacao.TabIndex = 13;
            this.grdPsqSubLocacao.DoubleClick += new System.EventHandler(this.grdPsqSubLocacao_DoubleClick);
            this.grdPsqSubLocacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqSubLocacao_KeyDown);
            // 
            // idevt_sublocacao
            // 
            this.idevt_sublocacao.DataPropertyName = "idevt_sublocacao";
            this.idevt_sublocacao.HeaderText = "Cód. SubLoc";
            this.idevt_sublocacao.Name = "idevt_sublocacao";
            this.idevt_sublocacao.ReadOnly = true;
            this.idevt_sublocacao.Width = 94;
            // 
            // idevt_evento
            // 
            this.idevt_evento.DataPropertyName = "idevt_evento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idevt_evento.DefaultCellStyle = dataGridViewCellStyle6;
            this.idevt_evento.HeaderText = "Cód. Evento";
            this.idevt_evento.Name = "idevt_evento";
            this.idevt_evento.ReadOnly = true;
            this.idevt_evento.Width = 91;
            // 
            // descricaoevento
            // 
            this.descricaoevento.DataPropertyName = "desc_evento";
            this.descricaoevento.HeaderText = "Evento";
            this.descricaoevento.Name = "descricaoevento";
            this.descricaoevento.ReadOnly = true;
            this.descricaoevento.Width = 66;
            // 
            // idbox
            // 
            this.idbox.DataPropertyName = "idbox";
            this.idbox.HeaderText = "Cód. Box";
            this.idbox.Name = "idbox";
            this.idbox.ReadOnly = true;
            this.idbox.Width = 75;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // psqSubLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 314);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "psqSubLocacao";
            this.Text = "Pesquisa Sub Locação";
            this.Load += new System.EventHandler(this.psqSubLocacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqSubLocacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtIdSubLocacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.TextBox txtIdBox;
        private System.Windows.Forms.TextBox txtDescEvento;
        private System.Windows.Forms.TextBox txtIdEvento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView grdPsqSubLocacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_sublocacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoevento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}