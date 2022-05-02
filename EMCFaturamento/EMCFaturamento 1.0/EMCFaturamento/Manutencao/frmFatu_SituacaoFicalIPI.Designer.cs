namespace EMCFaturamento
{
    partial class frmFatu_SituacaoFiscalIPI
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
            this.grdFatu_SituacaoFiscalIPI = new System.Windows.Forms.DataGridView();
            this.idfatu_situacaofiscalipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigosituacaoipi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entradasaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEntradaSaida = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidFatu_SituacaoFiscalIPI = new System.Windows.Forms.TextBox();
            this.txtCodigoSituacaoIPI = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_SituacaoFiscalIPI)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFatu_SituacaoFiscalIPI
            // 
            this.grdFatu_SituacaoFiscalIPI.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFatu_SituacaoFiscalIPI.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFatu_SituacaoFiscalIPI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFatu_SituacaoFiscalIPI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFatu_SituacaoFiscalIPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFatu_SituacaoFiscalIPI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_situacaofiscalipi,
            this.codigosituacaoipi,
            this.descricao,
            this.entradasaida});
            this.grdFatu_SituacaoFiscalIPI.Location = new System.Drawing.Point(1, 131);
            this.grdFatu_SituacaoFiscalIPI.MultiSelect = false;
            this.grdFatu_SituacaoFiscalIPI.Name = "grdFatu_SituacaoFiscalIPI";
            this.grdFatu_SituacaoFiscalIPI.ReadOnly = true;
            this.grdFatu_SituacaoFiscalIPI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFatu_SituacaoFiscalIPI.Size = new System.Drawing.Size(629, 193);
            this.grdFatu_SituacaoFiscalIPI.TabIndex = 21;
            this.grdFatu_SituacaoFiscalIPI.DoubleClick += new System.EventHandler(this.grdFatu_SituacaoFiscalIPI_DoubleClick);
            // 
            // idfatu_situacaofiscalipi
            // 
            this.idfatu_situacaofiscalipi.DataPropertyName = "idfatu_situacaofiscalipi";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idfatu_situacaofiscalipi.DefaultCellStyle = dataGridViewCellStyle2;
            this.idfatu_situacaofiscalipi.HeaderText = "Código";
            this.idfatu_situacaofiscalipi.Name = "idfatu_situacaofiscalipi";
            this.idfatu_situacaofiscalipi.ReadOnly = true;
            this.idfatu_situacaofiscalipi.Width = 65;
            // 
            // codigosituacaoipi
            // 
            this.codigosituacaoipi.DataPropertyName = "codigosituacaoipi";
            this.codigosituacaoipi.HeaderText = "Sit. IPI";
            this.codigosituacaoipi.Name = "codigosituacaoipi";
            this.codigosituacaoipi.ReadOnly = true;
            this.codigosituacaoipi.Width = 63;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // entradasaida
            // 
            this.entradasaida.DataPropertyName = "entradasaida";
            this.entradasaida.HeaderText = "Tipo";
            this.entradasaida.Name = "entradasaida";
            this.entradasaida.ReadOnly = true;
            this.entradasaida.Width = 53;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboEntradaSaida);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidFatu_SituacaoFiscalIPI);
            this.panel1.Controls.Add(this.txtCodigoSituacaoIPI);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 53);
            this.panel1.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Descrição";
            // 
            // cboEntradaSaida
            // 
            this.cboEntradaSaida.FormattingEnabled = true;
            this.cboEntradaSaida.Location = new System.Drawing.Point(532, 23);
            this.cboEntradaSaida.Name = "cboEntradaSaida";
            this.cboEntradaSaida.Size = new System.Drawing.Size(85, 21);
            this.cboEntradaSaida.TabIndex = 4;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(118, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(408, 20);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sit. IPI";
            // 
            // txtidFatu_SituacaoFiscalIPI
            // 
            this.txtidFatu_SituacaoFiscalIPI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidFatu_SituacaoFiscalIPI.Location = new System.Drawing.Point(10, 23);
            this.txtidFatu_SituacaoFiscalIPI.MaxLength = 50;
            this.txtidFatu_SituacaoFiscalIPI.Name = "txtidFatu_SituacaoFiscalIPI";
            this.txtidFatu_SituacaoFiscalIPI.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidFatu_SituacaoFiscalIPI.Size = new System.Drawing.Size(63, 20);
            this.txtidFatu_SituacaoFiscalIPI.TabIndex = 1;
            this.txtidFatu_SituacaoFiscalIPI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidFatu_SituacaoFiscalIPI_KeyPress);
            this.txtidFatu_SituacaoFiscalIPI.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_SituacaoFiscalIPI_Validating);
            // 
            // txtCodigoSituacaoIPI
            // 
            this.txtCodigoSituacaoIPI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoSituacaoIPI.Location = new System.Drawing.Point(79, 23);
            this.txtCodigoSituacaoIPI.MaxLength = 2;
            this.txtCodigoSituacaoIPI.Name = "txtCodigoSituacaoIPI";
            this.txtCodigoSituacaoIPI.Size = new System.Drawing.Size(33, 20);
            this.txtCodigoSituacaoIPI.TabIndex = 2;
            // 
            // frmFatu_SituacaoFiscalIPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 327);
            this.Controls.Add(this.grdFatu_SituacaoFiscalIPI);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_SituacaoFiscalIPI";
            this.Text = "Situação Fiscal IPI";
            this.Load += new System.EventHandler(this.frmFatu_SituacaoFiscalIPI_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFatu_SituacaoFiscalIPI, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdFatu_SituacaoFiscalIPI)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdFatu_SituacaoFiscalIPI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEntradaSaida;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidFatu_SituacaoFiscalIPI;
        private System.Windows.Forms.TextBox txtCodigoSituacaoIPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_situacaofiscalipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigosituacaoipi;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn entradasaida;
    }
}
