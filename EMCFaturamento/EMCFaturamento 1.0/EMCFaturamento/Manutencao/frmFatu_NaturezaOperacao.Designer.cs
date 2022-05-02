namespace EMCFaturamento
{
    partial class frmFatu_NaturezaOperacao
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
            this.txtidFatu_NaturezaOperacao = new MaskedNumber.MaskedNumber();
            this.txtNroCfopExterior = new MaskedNumber.MaskedNumber();
            this.txtNroCfopInterEstadual = new MaskedNumber.MaskedNumber();
            this.txtNroCfopEstadual = new MaskedNumber.MaskedNumber();
            this.txtIdExterior = new System.Windows.Forms.TextBox();
            this.txtIdInterEstadual = new System.Windows.Forms.TextBox();
            this.txtIdEstadual = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCFOPEstadual = new System.Windows.Forms.Button();
            this.txtExterior = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInterEstadual = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstadual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grdNaturezaOperacao = new System.Windows.Forms.DataGridView();
            this.idfatu_naturezaoperacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNaturezaOperacao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtidFatu_NaturezaOperacao);
            this.panel1.Controls.Add(this.txtNroCfopExterior);
            this.panel1.Controls.Add(this.txtNroCfopInterEstadual);
            this.panel1.Controls.Add(this.txtNroCfopEstadual);
            this.panel1.Controls.Add(this.txtIdExterior);
            this.panel1.Controls.Add(this.txtIdInterEstadual);
            this.panel1.Controls.Add(this.txtIdEstadual);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCFOPEstadual);
            this.panel1.Controls.Add(this.txtExterior);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtInterEstadual);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtEstadual);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTipo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 181);
            this.panel1.TabIndex = 1;
            // 
            // txtidFatu_NaturezaOperacao
            // 
            this.txtidFatu_NaturezaOperacao.CustomFormat = "0";
            this.txtidFatu_NaturezaOperacao.Format = MaskedNumberFormat.Custom;
            this.txtidFatu_NaturezaOperacao.Location = new System.Drawing.Point(10, 22);
            this.txtidFatu_NaturezaOperacao.Name = "txtidFatu_NaturezaOperacao";
            this.txtidFatu_NaturezaOperacao.Size = new System.Drawing.Size(61, 20);
            this.txtidFatu_NaturezaOperacao.TabIndex = 0;
            this.txtidFatu_NaturezaOperacao.Text = "0";
            this.txtidFatu_NaturezaOperacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidFatu_NaturezaOperacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFatu_NaturezaOperacao_Validating);
            // 
            // txtNroCfopExterior
            // 
            this.txtNroCfopExterior.CustomFormat = "0.000";
            this.txtNroCfopExterior.Format = MaskedNumberFormat.Custom;
            this.txtNroCfopExterior.Location = new System.Drawing.Point(10, 151);
            this.txtNroCfopExterior.Name = "txtNroCfopExterior";
            this.txtNroCfopExterior.Size = new System.Drawing.Size(61, 20);
            this.txtNroCfopExterior.TabIndex = 5;
            this.txtNroCfopExterior.Text = " ,";
            this.txtNroCfopExterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroCfopExterior.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroCfopExterior_Validating);
            // 
            // txtNroCfopInterEstadual
            // 
            this.txtNroCfopInterEstadual.CustomFormat = "0.000";
            this.txtNroCfopInterEstadual.Format = MaskedNumberFormat.Custom;
            this.txtNroCfopInterEstadual.Location = new System.Drawing.Point(10, 107);
            this.txtNroCfopInterEstadual.Name = "txtNroCfopInterEstadual";
            this.txtNroCfopInterEstadual.Size = new System.Drawing.Size(61, 20);
            this.txtNroCfopInterEstadual.TabIndex = 4;
            this.txtNroCfopInterEstadual.Text = " ,";
            this.txtNroCfopInterEstadual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroCfopInterEstadual.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroCfopInterEstadual_Validating);
            // 
            // txtNroCfopEstadual
            // 
            this.txtNroCfopEstadual.CustomFormat = "0.000";
            this.txtNroCfopEstadual.Format = MaskedNumberFormat.Custom;
            this.txtNroCfopEstadual.Location = new System.Drawing.Point(10, 67);
            this.txtNroCfopEstadual.Name = "txtNroCfopEstadual";
            this.txtNroCfopEstadual.Size = new System.Drawing.Size(61, 20);
            this.txtNroCfopEstadual.TabIndex = 3;
            this.txtNroCfopEstadual.Text = " ,";
            this.txtNroCfopEstadual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNroCfopEstadual.Validating += new System.ComponentModel.CancelEventHandler(this.txtNroCfopEstadual_Validating);
            // 
            // txtIdExterior
            // 
            this.txtIdExterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdExterior.Location = new System.Drawing.Point(135, 132);
            this.txtIdExterior.MaxLength = 50;
            this.txtIdExterior.Name = "txtIdExterior";
            this.txtIdExterior.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdExterior.Size = new System.Drawing.Size(63, 20);
            this.txtIdExterior.TabIndex = 257;
            this.txtIdExterior.Visible = false;
            // 
            // txtIdInterEstadual
            // 
            this.txtIdInterEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdInterEstadual.Location = new System.Drawing.Point(135, 89);
            this.txtIdInterEstadual.MaxLength = 50;
            this.txtIdInterEstadual.Name = "txtIdInterEstadual";
            this.txtIdInterEstadual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdInterEstadual.Size = new System.Drawing.Size(63, 20);
            this.txtIdInterEstadual.TabIndex = 256;
            this.txtIdInterEstadual.Visible = false;
            // 
            // txtIdEstadual
            // 
            this.txtIdEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdEstadual.Location = new System.Drawing.Point(135, 44);
            this.txtIdEstadual.MaxLength = 50;
            this.txtIdEstadual.Name = "txtIdEstadual";
            this.txtIdEstadual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdEstadual.Size = new System.Drawing.Size(63, 20);
            this.txtIdEstadual.TabIndex = 255;
            this.txtIdEstadual.Visible = false;
            // 
            // button2
            // 
            this.button2.Image = global::EMCFaturamento.Properties.Resources.binoculo_16x16;
            this.button2.Location = new System.Drawing.Point(75, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 254;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::EMCFaturamento.Properties.Resources.binoculo_16x16;
            this.button1.Location = new System.Drawing.Point(75, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 253;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCFOPEstadual
            // 
            this.btnCFOPEstadual.Image = global::EMCFaturamento.Properties.Resources.binoculo_16x16;
            this.btnCFOPEstadual.Location = new System.Drawing.Point(75, 65);
            this.btnCFOPEstadual.Name = "btnCFOPEstadual";
            this.btnCFOPEstadual.Size = new System.Drawing.Size(31, 23);
            this.btnCFOPEstadual.TabIndex = 252;
            this.btnCFOPEstadual.UseVisualStyleBackColor = true;
            // 
            // txtExterior
            // 
            this.txtExterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExterior.Enabled = false;
            this.txtExterior.Location = new System.Drawing.Point(107, 151);
            this.txtExterior.MaxLength = 50;
            this.txtExterior.Name = "txtExterior";
            this.txtExterior.Size = new System.Drawing.Size(509, 20);
            this.txtExterior.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "CFOP - Exterior";
            // 
            // txtInterEstadual
            // 
            this.txtInterEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInterEstadual.Enabled = false;
            this.txtInterEstadual.Location = new System.Drawing.Point(107, 107);
            this.txtInterEstadual.MaxLength = 50;
            this.txtInterEstadual.Name = "txtInterEstadual";
            this.txtInterEstadual.Size = new System.Drawing.Size(509, 20);
            this.txtInterEstadual.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "CFOP - Interestadual";
            // 
            // txtEstadual
            // 
            this.txtEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstadual.Enabled = false;
            this.txtEstadual.Location = new System.Drawing.Point(107, 67);
            this.txtEstadual.MaxLength = 50;
            this.txtEstadual.Name = "txtEstadual";
            this.txtEstadual.Size = new System.Drawing.Size(509, 20);
            this.txtEstadual.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "CFOP - Estadual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Descrição";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(532, 22);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(85, 21);
            this.cboTipo.TabIndex = 2;
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(75, 22);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(450, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Código";
            // 
            // grdNaturezaOperacao
            // 
            this.grdNaturezaOperacao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdNaturezaOperacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdNaturezaOperacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNaturezaOperacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfatu_naturezaoperacao,
            this.descricao});
            this.grdNaturezaOperacao.Location = new System.Drawing.Point(2, 263);
            this.grdNaturezaOperacao.Name = "grdNaturezaOperacao";
            this.grdNaturezaOperacao.ReadOnly = true;
            this.grdNaturezaOperacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdNaturezaOperacao.Size = new System.Drawing.Size(629, 182);
            this.grdNaturezaOperacao.TabIndex = 2;
            this.grdNaturezaOperacao.DoubleClick += new System.EventHandler(this.grdFatu_NaturezaOperacao_DoubleClick);
            // 
            // idfatu_naturezaoperacao
            // 
            this.idfatu_naturezaoperacao.DataPropertyName = "idfatu_naturezaoperacao";
            this.idfatu_naturezaoperacao.HeaderText = "Código";
            this.idfatu_naturezaoperacao.Name = "idfatu_naturezaoperacao";
            this.idfatu_naturezaoperacao.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 400;
            // 
            // frmFatu_NaturezaOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 449);
            this.Controls.Add(this.grdNaturezaOperacao);
            this.Controls.Add(this.panel1);
            this.Name = "frmFatu_NaturezaOperacao";
            this.Text = "Natureza Operacao";
            this.Load += new System.EventHandler(this.frmFatu_NaturezaOperacao_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdNaturezaOperacao, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNaturezaOperacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExterior;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterEstadual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstadual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCFOPEstadual;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdExterior;
        private System.Windows.Forms.TextBox txtIdInterEstadual;
        private System.Windows.Forms.TextBox txtIdEstadual;
        private System.Windows.Forms.DataGridView grdNaturezaOperacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfatu_naturezaoperacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private MaskedNumber.MaskedNumber txtNroCfopEstadual;
        private MaskedNumber.MaskedNumber txtNroCfopExterior;
        private MaskedNumber.MaskedNumber txtNroCfopInterEstadual;
        private MaskedNumber.MaskedNumber txtidFatu_NaturezaOperacao;
    }
}
