namespace EMCCadastro
{
    partial class frmCliente
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
            this.grdAutorizados = new System.Windows.Forms.DataGridView();
            this.grdReferencia = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAviso2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAviso1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDtValidadeAviso = new System.Windows.Forms.DateTimePicker();
            this.cboAlertaAviso2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAlertaAviso1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRetemISS = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboContrICMS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMicroEmpresa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIncluiRef = new System.Windows.Forms.Button();
            this.btnExcluiRef = new System.Windows.Forms.Button();
            this.btnExcluiAut = new System.Windows.Forms.Button();
            this.btnIncluiAut = new System.Windows.Forms.Button();
            this.cboSPC = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutorizados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReferencia)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAutorizados
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdAutorizados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAutorizados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAutorizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAutorizados.Enabled = false;
            this.grdAutorizados.Location = new System.Drawing.Point(423, 250);
            this.grdAutorizados.Name = "grdAutorizados";
            this.grdAutorizados.ReadOnly = true;
            this.grdAutorizados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAutorizados.Size = new System.Drawing.Size(368, 142);
            this.grdAutorizados.TabIndex = 1;
            this.grdAutorizados.DoubleClick += new System.EventHandler(this.grdAutorizados_DoubleClick);
            // 
            // grdReferencia
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdReferencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdReferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReferencia.Enabled = false;
            this.grdReferencia.Location = new System.Drawing.Point(2, 250);
            this.grdReferencia.Name = "grdReferencia";
            this.grdReferencia.ReadOnly = true;
            this.grdReferencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReferencia.Size = new System.Drawing.Size(380, 142);
            this.grdReferencia.TabIndex = 2;
            this.grdReferencia.DoubleClick += new System.EventHandler(this.grdReferencia_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtAviso2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtAviso1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDtValidadeAviso);
            this.panel1.Controls.Add(this.cboAlertaAviso2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboAlertaAviso1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboRetemISS);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboContrICMS);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboMicroEmpresa);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Location = new System.Drawing.Point(2, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 160);
            this.panel1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(478, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Aviso 2";
            // 
            // txtAviso2
            // 
            this.txtAviso2.Location = new System.Drawing.Point(477, 113);
            this.txtAviso2.MaxLength = 100;
            this.txtAviso2.Name = "txtAviso2";
            this.txtAviso2.Size = new System.Drawing.Size(342, 20);
            this.txtAviso2.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(478, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Aviso 1";
            // 
            // txtAviso1
            // 
            this.txtAviso1.Location = new System.Drawing.Point(477, 77);
            this.txtAviso1.MaxLength = 100;
            this.txtAviso1.Name = "txtAviso1";
            this.txtAviso1.Size = new System.Drawing.Size(342, 20);
            this.txtAviso1.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(660, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Data Validade Aviso";
            // 
            // txtDtValidadeAviso
            // 
            this.txtDtValidadeAviso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtValidadeAviso.Location = new System.Drawing.Point(663, 41);
            this.txtDtValidadeAviso.Name = "txtDtValidadeAviso";
            this.txtDtValidadeAviso.Size = new System.Drawing.Size(115, 20);
            this.txtDtValidadeAviso.TabIndex = 12;
            // 
            // cboAlertaAviso2
            // 
            this.cboAlertaAviso2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlertaAviso2.FormattingEnabled = true;
            this.cboAlertaAviso2.Location = new System.Drawing.Point(572, 40);
            this.cboAlertaAviso2.Name = "cboAlertaAviso2";
            this.cboAlertaAviso2.Size = new System.Drawing.Size(85, 21);
            this.cboAlertaAviso2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(569, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Alerta Aviso 2";
            // 
            // cboAlertaAviso1
            // 
            this.cboAlertaAviso1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlertaAviso1.FormattingEnabled = true;
            this.cboAlertaAviso1.Location = new System.Drawing.Point(478, 40);
            this.cboAlertaAviso1.Name = "cboAlertaAviso1";
            this.cboAlertaAviso1.Size = new System.Drawing.Size(85, 21);
            this.cboAlertaAviso1.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(478, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Alerta Aviso 1";
            // 
            // cboRetemISS
            // 
            this.cboRetemISS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRetemISS.FormattingEnabled = true;
            this.cboRetemISS.Location = new System.Drawing.Point(10, 87);
            this.cboRetemISS.Name = "cboRetemISS";
            this.cboRetemISS.Size = new System.Drawing.Size(82, 21);
            this.cboRetemISS.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Retem ISS";
            // 
            // cboContrICMS
            // 
            this.cboContrICMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContrICMS.FormattingEnabled = true;
            this.cboContrICMS.Location = new System.Drawing.Point(10, 52);
            this.cboContrICMS.Name = "cboContrICMS";
            this.cboContrICMS.Size = new System.Drawing.Size(82, 21);
            this.cboContrICMS.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contr. ICMS";
            // 
            // cboMicroEmpresa
            // 
            this.cboMicroEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMicroEmpresa.FormattingEnabled = true;
            this.cboMicroEmpresa.Location = new System.Drawing.Point(7, 15);
            this.cboMicroEmpresa.Name = "cboMicroEmpresa";
            this.cboMicroEmpresa.Size = new System.Drawing.Size(85, 21);
            this.cboMicroEmpresa.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Micro Empresa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(98, 15);
            this.txtObservacao.MaxLength = 100;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(377, 131);
            this.txtObservacao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(420, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pessoas Autorizadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Referências";
            // 
            // btnIncluiRef
            // 
            this.btnIncluiRef.Enabled = false;
            this.btnIncluiRef.Image = global::EMCCadastro.Properties.Resources.Incluir_16x16;
            this.btnIncluiRef.Location = new System.Drawing.Point(381, 250);
            this.btnIncluiRef.Name = "btnIncluiRef";
            this.btnIncluiRef.Size = new System.Drawing.Size(39, 32);
            this.btnIncluiRef.TabIndex = 7;
            this.btnIncluiRef.UseVisualStyleBackColor = true;
            this.btnIncluiRef.Click += new System.EventHandler(this.btnIncluiRef_Click);
            // 
            // btnExcluiRef
            // 
            this.btnExcluiRef.Enabled = false;
            this.btnExcluiRef.Image = global::EMCCadastro.Properties.Resources.Deletar_16x16;
            this.btnExcluiRef.Location = new System.Drawing.Point(381, 281);
            this.btnExcluiRef.Name = "btnExcluiRef";
            this.btnExcluiRef.Size = new System.Drawing.Size(39, 32);
            this.btnExcluiRef.TabIndex = 8;
            this.btnExcluiRef.UseVisualStyleBackColor = true;
            this.btnExcluiRef.Click += new System.EventHandler(this.btnExcluiRef_Click);
            // 
            // btnExcluiAut
            // 
            this.btnExcluiAut.Enabled = false;
            this.btnExcluiAut.Image = global::EMCCadastro.Properties.Resources.Deletar_16x16;
            this.btnExcluiAut.Location = new System.Drawing.Point(789, 280);
            this.btnExcluiAut.Name = "btnExcluiAut";
            this.btnExcluiAut.Size = new System.Drawing.Size(39, 32);
            this.btnExcluiAut.TabIndex = 10;
            this.btnExcluiAut.UseVisualStyleBackColor = true;
            this.btnExcluiAut.Click += new System.EventHandler(this.btnExcluiAut_Click);
            // 
            // btnIncluiAut
            // 
            this.btnIncluiAut.Enabled = false;
            this.btnIncluiAut.Image = global::EMCCadastro.Properties.Resources.Incluir_16x16;
            this.btnIncluiAut.Location = new System.Drawing.Point(789, 249);
            this.btnIncluiAut.Name = "btnIncluiAut";
            this.btnIncluiAut.Size = new System.Drawing.Size(39, 32);
            this.btnIncluiAut.TabIndex = 9;
            this.btnIncluiAut.UseVisualStyleBackColor = true;
            this.btnIncluiAut.Click += new System.EventHandler(this.btnIncluiAut_Click);
            // 
            // cboSPC
            // 
            this.cboSPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSPC.FormattingEnabled = true;
            this.cboSPC.Location = new System.Drawing.Point(12, 197);
            this.cboSPC.Name = "cboSPC";
            this.cboSPC.Size = new System.Drawing.Size(82, 21);
            this.cboSPC.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "SPC";
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(828, 400);
            this.Controls.Add(this.cboSPC);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnExcluiAut);
            this.Controls.Add(this.btnIncluiAut);
            this.Controls.Add(this.btnExcluiRef);
            this.Controls.Add(this.btnIncluiRef);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdReferencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdAutorizados);
            this.MaximizeBox = false;
            this.Name = "frmCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.Controls.SetChildIndex(this.grdAutorizados, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.grdReferencia, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnIncluiRef, 0);
            this.Controls.SetChildIndex(this.btnExcluiRef, 0);
            this.Controls.SetChildIndex(this.btnIncluiAut, 0);
            this.Controls.SetChildIndex(this.btnExcluiAut, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.cboSPC, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdAutorizados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReferencia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAutorizados;
        private System.Windows.Forms.DataGridView grdReferencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAviso2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAviso1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtDtValidadeAviso;
        private System.Windows.Forms.ComboBox cboAlertaAviso2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAlertaAviso1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRetemISS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboContrICMS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMicroEmpresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Button btnIncluiRef;
        private System.Windows.Forms.Button btnExcluiRef;
        private System.Windows.Forms.Button btnExcluiAut;
        private System.Windows.Forms.Button btnIncluiAut;
        private System.Windows.Forms.ComboBox cboSPC;
        private System.Windows.Forms.Label label12;
    }
}
