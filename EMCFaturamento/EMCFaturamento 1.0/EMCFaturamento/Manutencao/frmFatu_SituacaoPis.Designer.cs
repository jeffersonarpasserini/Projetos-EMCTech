namespace EMCFaturamento
{
    partial class frmFatu_SituacaoPis
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
            this.grdFatu_SituacaoPis = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigoFiscal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtidFatu_SituacaoPis = new System.Windows.Forms.TextBox();
            this.idfatu_situacaopis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_SituacaoPis)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_SituacaoPis
            // 
            this.grdFatu_SituacaoPis.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_SituacaoPis.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFatu_SituacaoPis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_SituacaoPis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_SituacaoPis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_SituacaoPis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_situacaopis,
            this.descricao});
            this.grdFatu_SituacaoPis.Location = new System.Drawing.Point(2, 133);
            this.grdFatu_SituacaoPis.MultiSelect = false;
            this.grdFatu_SituacaoPis.Name = "grdFatu_SituacaoPis";
            this.grdFatu_SituacaoPis.ReadOnly = true;
            this.grdFatu_SituacaoPis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_SituacaoPis.Size = new System.Drawing.Size(629, 193);
            this.grdFatu_SituacaoPis.TabIndex = 27;
            this.grdFatu_SituacaoPis.DoubleClick += new System.EventHandler(this.grdFatu_SituacaoPis_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtCodigoFiscal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtidFatu_SituacaoPis);
            this.panel1.Location = new System.Drawing.Point(3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 26;
            // 
            // txtCodigoFiscal
            // 
            this.txtCodigoFiscal.Location = new System.Drawing.Point(72, 23);
            this.txtCodigoFiscal.MaxLength = 2;
            this.txtCodigoFiscal.Name = "txtCodigoFiscal";
            this.txtCodigoFiscal.Size = new System.Drawing.Size(53, 20);
            this.txtCodigoFiscal.TabIndex = 2;
            this.txtCodigoFiscal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Cod.Fisco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(127, 23);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(492, 20);
            this.txtDescricao.TabIndex = 3;
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
            // txtidFatu_SituacaoPis
            // 
            this.txtidFatu_SituacaoPis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_SituacaoPis.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_SituacaoPis.MaxLength = 50;
            this.txtidFatu_SituacaoPis.Name = "txtidFatu_SituacaoPis";
            this.txtidFatu_SituacaoPis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_SituacaoPis.Size = new System.Drawing.Size(59, 20);
            this.txtidFatu_SituacaoPis.TabIndex = 1;
            this.txtidFatu_SituacaoPis.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_SituacaoPis_Validating);
            // 
            // idfatu_situacaopis
            // 
            this.idfatu_situacaopis.DataPropertyName = "idfatu_situacaopis";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_situacaopis.DefaultCellStyle = dataGridViewCellStyle2;
            this.idfatu_situacaopis.HeaderText = "Código";
            this.idfatu_situacaopis.Name = "idfatu_situacaopis";
            this.idfatu_situacaopis.ReadOnly = true;
            this.idfatu_situacaopis.Width = 65;
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
            // frmFatu_SituacaoPis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.grdFatu_SituacaoPis);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_SituacaoPis";
            this.Text = "Situação Fiscal Pis";
            this.Load += new System.EventHandler(this.frmFatu_SituacaoPis_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_SituacaoPis, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_SituacaoPis)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_SituacaoPis;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCodigoFiscal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtidFatu_SituacaoPis;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_situacaopis;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
