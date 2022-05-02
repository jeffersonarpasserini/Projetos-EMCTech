namespace EMCFaturamento
{
    partial class frmFatu_OrigemMercadoria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdFatu_OrigemMercadoria = new System.Windows.Forms.DataGridView();
            this.idfatu_origemmercadoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtidFatu_OrigemMercadoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoOrigem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_OrigemMercadoria)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_OrigemMercadoria
            // 
            this.grdFatu_OrigemMercadoria.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_OrigemMercadoria.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grdFatu_OrigemMercadoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_OrigemMercadoria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_OrigemMercadoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_OrigemMercadoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_origemmercadoria,
            this.descricao});
            this.grdFatu_OrigemMercadoria.Location = new System.Drawing.Point(1, 131);
            this.grdFatu_OrigemMercadoria.MultiSelect = false;
            this.grdFatu_OrigemMercadoria.Name = "grdFatu_OrigemMercadoria";
            this.grdFatu_OrigemMercadoria.ReadOnly = true;
            this.grdFatu_OrigemMercadoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_OrigemMercadoria.Size = new System.Drawing.Size(629, 193);
            this.grdFatu_OrigemMercadoria.TabIndex = 23;
            this.grdFatu_OrigemMercadoria.DoubleClick += new System.EventHandler(this.grdFatu_OrigemMercadoria_DoubleClick);
            // 
            // idfatu_origemmercadoria
            // 
            this.idfatu_origemmercadoria.DataPropertyName = "idfatu_origemmercadoria";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_origemmercadoria.DefaultCellStyle = dataGridViewCellStyle6;
            this.idfatu_origemmercadoria.HeaderText = "Código";
            this.idfatu_origemmercadoria.Name = "idfatu_origemmercadoria";
            this.idfatu_origemmercadoria.ReadOnly = true;
            this.idfatu_origemmercadoria.Width = 65;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtCodigoOrigem);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtidFatu_OrigemMercadoria);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(129, 23);
            this.txtDescricao.MaxLength = 100;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(490, 20);
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
            // txtidFatu_OrigemMercadoria
            // 
            this.txtidFatu_OrigemMercadoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_OrigemMercadoria.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_OrigemMercadoria.MaxLength = 50;
            this.txtidFatu_OrigemMercadoria.Name = "txtidFatu_OrigemMercadoria";
            this.txtidFatu_OrigemMercadoria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_OrigemMercadoria.Size = new System.Drawing.Size(59, 20);
            this.txtidFatu_OrigemMercadoria.TabIndex = 1;
            this.txtidFatu_OrigemMercadoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidFatu_OrigemMercadoria_KeyPress);
            this.txtidFatu_OrigemMercadoria.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_OrigemMercadoria_Validating);
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
            // txtCodigoOrigem
            // 
            this.txtCodigoOrigem.Location = new System.Drawing.Point(72, 23);
            this.txtCodigoOrigem.MaxLength = 1;
            this.txtCodigoOrigem.Name = "txtCodigoOrigem";
            this.txtCodigoOrigem.Size = new System.Drawing.Size(53, 20);
            this.txtCodigoOrigem.TabIndex = 2;
            this.txtCodigoOrigem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmFatu_OrigemMercadoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 326);
            this.Controls.Add(this.grdFatu_OrigemMercadoria);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_OrigemMercadoria";
            this.Text = "Origem da Mercadoria";
            this.Load += new System.EventHandler(this.frmFatu_OrigemMercadoria_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_OrigemMercadoria, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_OrigemMercadoria)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_OrigemMercadoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtidFatu_OrigemMercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_origemmercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.TextBox txtCodigoOrigem;
        private System.Windows.Forms.Label label2;
    }
}
