namespace EMCFinanceiro
{
    partial class frmCancelaFormCheque
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFormulario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.maskedDateTextBox1 = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContaBancaria = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtContaBancaria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.maskedDateTextBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNroDocumento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboFormulario);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 86);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Formulário";
            // 
            // cboFormulario
            // 
            this.cboFormulario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormulario.FormattingEnabled = true;
            this.cboFormulario.Location = new System.Drawing.Point(7, 20);
            this.cboFormulario.Name = "cboFormulario";
            this.cboFormulario.Size = new System.Drawing.Size(227, 21);
            this.cboFormulario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Número Cheque";
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(449, 21);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.ReadOnly = true;
            this.txtNroDocumento.Size = new System.Drawing.Size(76, 20);
            this.txtNroDocumento.TabIndex = 7;
            // 
            // maskedDateTextBox1
            // 
            this.maskedDateTextBox1.DateValue = null;
            this.maskedDateTextBox1.Location = new System.Drawing.Point(528, 21);
            this.maskedDateTextBox1.Mask = "00/00/0000";
            this.maskedDateTextBox1.Name = "maskedDateTextBox1";
            this.maskedDateTextBox1.RequireValidEntry = true;
            this.maskedDateTextBox1.Size = new System.Drawing.Size(98, 20);
            this.maskedDateTextBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data Cancelamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Conta Bancária";
            // 
            // txtContaBancaria
            // 
            this.txtContaBancaria.Location = new System.Drawing.Point(240, 21);
            this.txtContaBancaria.Name = "txtContaBancaria";
            this.txtContaBancaria.ReadOnly = true;
            this.txtContaBancaria.Size = new System.Drawing.Size(206, 20);
            this.txtContaBancaria.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(629, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Motivo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(619, 20);
            this.textBox1.TabIndex = 14;
            // 
            // frmCancelaFormCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 310);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "frmCancelaFormCheque";
            this.Text = "Cancelamento Formulário Cheque";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFormulario;
        private System.Windows.Forms.Label label1;
        private MaskedDateEntryControl.MaskedDateTextBox maskedDateTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContaBancaria;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}
