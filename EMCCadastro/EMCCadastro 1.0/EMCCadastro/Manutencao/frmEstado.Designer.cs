namespace EMCCadastro
{
    partial class frmEstado
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
            this.grdEstado = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAbreviatura = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtIdEstado = new MaskedNumber.MaskedNumber();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstado
            // 
            this.grdEstado.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstado.Location = new System.Drawing.Point(2, 146);
            this.grdEstado.Name = "grdEstado";
            this.grdEstado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstado.Size = new System.Drawing.Size(629, 181);
            this.grdEstado.TabIndex = 1;
            this.grdEstado.DoubleClick += new System.EventHandler(this.grdEstado_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAbreviatura);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.txtIdEstado);
            this.panel1.Location = new System.Drawing.Point(2, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 66);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sigla";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código";
            // 
            // txtAbreviatura
            // 
            this.txtAbreviatura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviatura.Location = new System.Drawing.Point(559, 30);
            this.txtAbreviatura.MaxLength = 2;
            this.txtAbreviatura.Name = "txtAbreviatura";
            this.txtAbreviatura.Size = new System.Drawing.Size(60, 20);
            this.txtAbreviatura.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(64, 30);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(489, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtIdEstado
            // 
            this.txtIdEstado.CustomFormat = "00";
            this.txtIdEstado.Format = MaskedNumberFormat.Custom;
            this.txtIdEstado.Location = new System.Drawing.Point(6, 30);
            this.txtIdEstado.MaxLength = 2;
            this.txtIdEstado.Name = "txtIdEstado";
            this.txtIdEstado.Size = new System.Drawing.Size(52, 20);
            this.txtIdEstado.TabIndex = 0;
            this.txtIdEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdEstado.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEstado_Validating);
            // 
            // frmEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdEstado);
            this.Name = "frmEstado";
            this.Text = "Estado";
            this.Load += new System.EventHandler(this.frmEstado_Load);
            this.Controls.SetChildIndex(this.grdEstado, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAbreviatura;
        private System.Windows.Forms.TextBox txtNome;
        private MaskedNumber.MaskedNumber txtIdEstado;
    }
}
