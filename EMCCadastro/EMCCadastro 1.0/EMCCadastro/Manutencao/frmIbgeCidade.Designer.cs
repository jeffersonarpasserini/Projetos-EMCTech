namespace EMCCadastro
{
    partial class frmIbgeCidade
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
            this.grdIbgeCidade = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdIbgeCidade = new System.Windows.Forms.TextBox();
            this.txtIdEstado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoIbge = new MaskedNumber.MaskedNumber();
            ((System.ComponentModel.ISupportInitialize)(this.grdIbgeCidade)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdIbgeCidade
            // 
            this.grdIbgeCidade.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdIbgeCidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdIbgeCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIbgeCidade.Location = new System.Drawing.Point(2, 143);
            this.grdIbgeCidade.Name = "grdIbgeCidade";
            this.grdIbgeCidade.ReadOnly = true;
            this.grdIbgeCidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdIbgeCidade.Size = new System.Drawing.Size(629, 183);
            this.grdIbgeCidade.TabIndex = 1;
            this.grdIbgeCidade.DoubleClick += new System.EventHandler(this.grdIbgeCidade_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIdIbgeCidade);
            this.panel1.Controls.Add(this.txtIdEstado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboEstado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNomeCidade);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodigoIbge);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 65);
            this.panel1.TabIndex = 2;
            // 
            // txtIdIbgeCidade
            // 
            this.txtIdIbgeCidade.Location = new System.Drawing.Point(226, 5);
            this.txtIdIbgeCidade.Name = "txtIdIbgeCidade";
            this.txtIdIbgeCidade.Size = new System.Drawing.Size(100, 20);
            this.txtIdIbgeCidade.TabIndex = 7;
            this.txtIdIbgeCidade.Visible = false;
            // 
            // txtIdEstado
            // 
            this.txtIdEstado.Location = new System.Drawing.Point(407, 8);
            this.txtIdEstado.Name = "txtIdEstado";
            this.txtIdEstado.Size = new System.Drawing.Size(100, 20);
            this.txtIdEstado.TabIndex = 6;
            this.txtIdEstado.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(534, 31);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(83, 21);
            this.cboEstado.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Cidade";
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeCidade.Location = new System.Drawing.Point(110, 31);
            this.txtNomeCidade.MaxLength = 45;
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(420, 20);
            this.txtNomeCidade.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código IBGE";
            // 
            // txtCodigoIbge
            // 
            this.txtCodigoIbge.CustomFormat = "0000000";
            this.txtCodigoIbge.Format = MaskedNumberFormat.Custom;
            this.txtCodigoIbge.Location = new System.Drawing.Point(6, 31);
            this.txtCodigoIbge.MaxLength = 7;
            this.txtCodigoIbge.Name = "txtCodigoIbge";
            this.txtCodigoIbge.Size = new System.Drawing.Size(101, 20);
            this.txtCodigoIbge.TabIndex = 0;
            this.txtCodigoIbge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoIbge.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoIbge_Validating);
            // 
            // frmIbgeCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdIbgeCidade);
            this.Name = "frmIbgeCidade";
            this.Text = "IBGE Cidade";
            this.Load += new System.EventHandler(this.frmIbgeCidade_Load);
            this.Controls.SetChildIndex(this.grdIbgeCidade, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdIbgeCidade)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdIbgeCidade;
        private System.Windows.Forms.Panel panel1;
        private MaskedNumber.MaskedNumber txtCodigoIbge;
        private System.Windows.Forms.TextBox txtIdEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdIbgeCidade;
    }
}
