namespace EMCFaturamento
{
    partial class frmFatu_Tributacao
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
            this.grdFatu_Tributacao = new System.Windows.Forms.DataGridView();
            this.idfatu_tributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sistematributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigotributacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodigoTributacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSistemaTributacao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdvertencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtidFatu_Tributacao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_Tributacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_Tributacao
            // 
            this.grdFatu_Tributacao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_Tributacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFatu_Tributacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_Tributacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_Tributacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_Tributacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_tributacao,
            this.descricao,
            this.situacao,
            this.sistematributacao,
            this.codigotributacao});
            this.grdFatu_Tributacao.Location = new System.Drawing.Point(1, 210);
            this.grdFatu_Tributacao.MultiSelect = false;
            this.grdFatu_Tributacao.Name = "grdFatu_Tributacao";
            this.grdFatu_Tributacao.ReadOnly = true;
            this.grdFatu_Tributacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_Tributacao.Size = new System.Drawing.Size(629, 193);
            this.grdFatu_Tributacao.TabIndex = 23;
            this.grdFatu_Tributacao.DoubleClick += new System.EventHandler(this.grdFatu_Tributacao_DoubleClick);
            // 
            // idfatu_tributacao
            // 
            this.idfatu_tributacao.DataPropertyName = "idfatu_tributacao";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_tributacao.DefaultCellStyle = dataGridViewCellStyle2;
            this.idfatu_tributacao.HeaderText = "Código";
            this.idfatu_tributacao.Name = "idfatu_tributacao";
            this.idfatu_tributacao.ReadOnly = true;
            this.idfatu_tributacao.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 74;
            // 
            // sistematributacao
            // 
            this.sistematributacao.DataPropertyName = "sistematributacao";
            this.sistematributacao.HeaderText = "Sist. Tributação";
            this.sistematributacao.Name = "sistematributacao";
            this.sistematributacao.ReadOnly = true;
            this.sistematributacao.Width = 97;
            // 
            // codigotributacao
            // 
            this.codigotributacao.DataPropertyName = "codigotributacao";
            this.codigotributacao.HeaderText = "Cód. Tributação";
            this.codigotributacao.Name = "codigotributacao";
            this.codigotributacao.ReadOnly = true;
            this.codigotributacao.Width = 99;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCodigoTributacao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboSistemaTributacao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtAdvertencia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboSituacao);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtidFatu_Tributacao);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 133);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cód. Tributação";
            // 
            // txtCodigoTributacao
            // 
            this.txtCodigoTributacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoTributacao.Location = new System.Drawing.Point(180, 105);
            this.txtCodigoTributacao.MaxLength = 4;
            this.txtCodigoTributacao.Name = "txtCodigoTributacao";
            this.txtCodigoTributacao.Size = new System.Drawing.Size(83, 20);
            this.txtCodigoTributacao.TabIndex = 6;
            this.txtCodigoTributacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Sistema de Tributação";
            // 
            // cboSistemaTributacao
            // 
            this.cboSistemaTributacao.FormattingEnabled = true;
            this.cboSistemaTributacao.Location = new System.Drawing.Point(8, 104);
            this.cboSistemaTributacao.Name = "cboSistemaTributacao";
            this.cboSistemaTributacao.Size = new System.Drawing.Size(168, 21);
            this.cboSistemaTributacao.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Advertência";
            // 
            // txtAdvertencia
            // 
            this.txtAdvertencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdvertencia.Location = new System.Drawing.Point(8, 64);
            this.txtAdvertencia.MaxLength = 100;
            this.txtAdvertencia.Name = "txtAdvertencia";
            this.txtAdvertencia.Size = new System.Drawing.Size(610, 20);
            this.txtAdvertencia.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // cboSituacao
            // 
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(532, 23);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(85, 21);
            this.cboSituacao.TabIndex = 3;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(75, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(450, 20);
            this.txtDescricao.TabIndex = 2;
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
            // txtidFatu_Tributacao
            // 
            this.txtidFatu_Tributacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_Tributacao.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_Tributacao.MaxLength = 50;
            this.txtidFatu_Tributacao.Name = "txtidFatu_Tributacao";
            this.txtidFatu_Tributacao.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_Tributacao.Size = new System.Drawing.Size(63, 20);
            this.txtidFatu_Tributacao.TabIndex = 1;
            this.txtidFatu_Tributacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidFatu_Tributacao_KeyPress);
            this.txtidFatu_Tributacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_Tributacao_Validating);
            // 
            // frmFatu_Tributacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 441);
            this.Controls.Add(this.grdFatu_Tributacao);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_Tributacao";
            this.Text = "Tributação";
            this.Load += new System.EventHandler(this.frmFatu_Tributacao_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_Tributacao, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_Tributacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_Tributacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtidFatu_Tributacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdvertencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodigoTributacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSistemaTributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_tributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn sistematributacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigotributacao;
    }
}
