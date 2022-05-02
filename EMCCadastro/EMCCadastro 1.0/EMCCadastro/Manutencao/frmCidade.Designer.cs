namespace EMCCadastro
{
    partial class frmCidade
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCepCidade = new MaskedNumber.MaskedNumber();
            this.btnBuscaCep = new System.Windows.Forms.Button();
            this.txtIdIbgeCidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoIbge = new MaskedNumber.MaskedNumber();
            this.grdCidade = new System.Windows.Forms.DataGridView();
            this.cepcidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoibge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCidade)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCepCidade);
            this.panel1.Controls.Add(this.btnBuscaCep);
            this.panel1.Controls.Add(this.txtIdIbgeCidade);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNomeCidade);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodigoIbge);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 65);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "CEP";
            // 
            // txtCepCidade
            // 
            this.txtCepCidade.CustomFormat = "00000";
            this.txtCepCidade.Format = MaskedNumberFormat.Custom;
            this.txtCepCidade.Location = new System.Drawing.Point(4, 31);
            this.txtCepCidade.MaxLength = 5;
            this.txtCepCidade.Name = "txtCepCidade";
            this.txtCepCidade.Size = new System.Drawing.Size(78, 20);
            this.txtCepCidade.TabIndex = 0;
            this.txtCepCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCepCidade.Validating += new System.ComponentModel.CancelEventHandler(this.txtCepCidade_Validating);
            // 
            // btnBuscaCep
            // 
            this.btnBuscaCep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscaCep.Image = global::EMCCadastro.Properties.Resources.binoculo_16x16;
            this.btnBuscaCep.Location = new System.Drawing.Point(173, 28);
            this.btnBuscaCep.Name = "btnBuscaCep";
            this.btnBuscaCep.Size = new System.Drawing.Size(31, 25);
            this.btnBuscaCep.TabIndex = 24;
            this.btnBuscaCep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaCep.UseVisualStyleBackColor = true;
            this.btnBuscaCep.Click += new System.EventHandler(this.btnBuscaCep_Click);
            // 
            // txtIdIbgeCidade
            // 
            this.txtIdIbgeCidade.Location = new System.Drawing.Point(294, 3);
            this.txtIdIbgeCidade.Name = "txtIdIbgeCidade";
            this.txtIdIbgeCidade.Size = new System.Drawing.Size(100, 20);
            this.txtIdIbgeCidade.TabIndex = 7;
            this.txtIdIbgeCidade.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Cidade";
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeCidade.Enabled = false;
            this.txtNomeCidade.Location = new System.Drawing.Point(206, 31);
            this.txtNomeCidade.MaxLength = 45;
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(417, 20);
            this.txtNomeCidade.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código IBGE";
            // 
            // txtCodigoIbge
            // 
            this.txtCodigoIbge.CustomFormat = "0000000";
            this.txtCodigoIbge.Format = MaskedNumberFormat.Custom;
            this.txtCodigoIbge.Location = new System.Drawing.Point(85, 31);
            this.txtCodigoIbge.MaxLength = 7;
            this.txtCodigoIbge.Name = "txtCodigoIbge";
            this.txtCodigoIbge.Size = new System.Drawing.Size(86, 20);
            this.txtCodigoIbge.TabIndex = 1;
            this.txtCodigoIbge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoIbge.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoIbge_Validating);
            // 
            // grdCidade
            // 
            this.grdCidade.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdCidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cepcidade,
            this.nomecidade,
            this.codigoibge});
            this.grdCidade.Location = new System.Drawing.Point(3, 144);
            this.grdCidade.Name = "grdCidade";
            this.grdCidade.ReadOnly = true;
            this.grdCidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCidade.Size = new System.Drawing.Size(629, 183);
            this.grdCidade.TabIndex = 3;
            this.grdCidade.DoubleClick += new System.EventHandler(this.grdCidade_DoubleClick);
            // 
            // cepcidade
            // 
            this.cepcidade.DataPropertyName = "cepcidade";
            this.cepcidade.HeaderText = "CEP";
            this.cepcidade.Name = "cepcidade";
            this.cepcidade.ReadOnly = true;
            // 
            // nomecidade
            // 
            this.nomecidade.DataPropertyName = "nomecidade";
            this.nomecidade.HeaderText = "Cidade";
            this.nomecidade.Name = "nomecidade";
            this.nomecidade.ReadOnly = true;
            this.nomecidade.Width = 300;
            // 
            // codigoibge
            // 
            this.codigoibge.DataPropertyName = "codigoibge";
            this.codigoibge.HeaderText = "IBGE";
            this.codigoibge.Name = "codigoibge";
            this.codigoibge.ReadOnly = true;
            // 
            // frmCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdCidade);
            this.Name = "frmCidade";
            this.Text = "CEP - Cidade";
            this.Load += new System.EventHandler(this.frmCidade_Load);
            this.Controls.SetChildIndex(this.grdCidade, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.Label label1;
        private MaskedNumber.MaskedNumber txtCodigoIbge;
        private System.Windows.Forms.DataGridView grdCidade;
        private System.Windows.Forms.TextBox txtIdIbgeCidade;
        private System.Windows.Forms.Button btnBuscaCep;
        private MaskedNumber.MaskedNumber txtCepCidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cepcidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoibge;
    }
}
