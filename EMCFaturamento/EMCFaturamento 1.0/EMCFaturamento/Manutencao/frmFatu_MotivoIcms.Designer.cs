namespace EMCFaturamento
{
    partial class frmFatu_MotivoIcms
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
            this.grdFatu_MotivoIcms = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboSituacao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtidFatu_MotivoIcms = new System.Windows.Forms.TextBox();
            this.idfatu_motivoicms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_MotivoIcms)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_MotivoIcms
            // 
            this.grdFatu_MotivoIcms.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_MotivoIcms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFatu_MotivoIcms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_MotivoIcms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_MotivoIcms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_MotivoIcms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_motivoicms,
            this.descricao});
            this.grdFatu_MotivoIcms.Location = new System.Drawing.Point(2, 133);
            this.grdFatu_MotivoIcms.MultiSelect = false;
            this.grdFatu_MotivoIcms.Name = "grdFatu_MotivoIcms";
            this.grdFatu_MotivoIcms.ReadOnly = true;
            this.grdFatu_MotivoIcms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_MotivoIcms.Size = new System.Drawing.Size(629, 193);
            this.grdFatu_MotivoIcms.TabIndex = 27;
            this.grdFatu_MotivoIcms.DoubleClick += new System.EventHandler(this.grdFatu_MotivoIcms_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cboSituacao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtidFatu_MotivoIcms);
            this.panel1.Location = new System.Drawing.Point(3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 26;
            // 
            // cboSituacao
            // 
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Location = new System.Drawing.Point(553, 23);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(70, 21);
            this.cboSituacao.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Situação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(71, 23);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(480, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // txtidFatu_MotivoIcms
            // 
            this.txtidFatu_MotivoIcms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_MotivoIcms.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_MotivoIcms.MaxLength = 50;
            this.txtidFatu_MotivoIcms.Name = "txtidFatu_MotivoIcms";
            this.txtidFatu_MotivoIcms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_MotivoIcms.Size = new System.Drawing.Size(59, 20);
            this.txtidFatu_MotivoIcms.TabIndex = 1;
            this.txtidFatu_MotivoIcms.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_MotivoIcms_Validating);
            // 
            // idfatu_motivoicms
            // 
            this.idfatu_motivoicms.DataPropertyName = "idfatu_motivoicms";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_motivoicms.DefaultCellStyle = dataGridViewCellStyle2;
            this.idfatu_motivoicms.HeaderText = "Código";
            this.idfatu_motivoicms.Name = "idfatu_motivoicms";
            this.idfatu_motivoicms.ReadOnly = true;
            this.idfatu_motivoicms.Width = 65;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 500;
            // 
            // frmFatu_MotivoIcms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.grdFatu_MotivoIcms);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_MotivoIcms";
            this.Text = "Motivo ICMS";
            this.Load += new System.EventHandler(this.frmFatu_MotivoIcms_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_MotivoIcms, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_MotivoIcms)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_MotivoIcms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboSituacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtidFatu_MotivoIcms;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_motivoicms;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
