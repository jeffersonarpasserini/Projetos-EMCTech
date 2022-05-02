namespace EMCImob
{
    partial class frmLocacaoProventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocacaoProventos));
            this.grdLocacaoProventos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRotinaCalculo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboBaseIrpf = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboValorReferencia = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboBaseTaxaAdmCondominio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBaseTaxaAdm = new System.Windows.Forms.ComboBox();
            this.txtAplicacao = new System.Windows.Forms.TextBox();
            this.btnLocalizarAplicacao = new System.Windows.Forms.Button();
            this.txtIdAplicacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIntegraDimob = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoProvento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdLocacaoProventos = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtReferencia = new MaskedNumber.MaskedNumber();
            this.idlocacaoproventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoprovento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.integradimob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idaplicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basetaxaadm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basetaxaadmcondominio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseirpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotinacalculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocacaoProventos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLocacaoProventos
            // 
            this.grdLocacaoProventos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdLocacaoProventos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLocacaoProventos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdLocacaoProventos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdLocacaoProventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLocacaoProventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idlocacaoproventos,
            this.descricao,
            this.tipoprovento,
            this.integradimob,
            this.idaplicacao,
            this.basetaxaadm,
            this.basetaxaadmcondominio,
            this.referencia,
            this.valor_referencia,
            this.baseirpf,
            this.rotinacalculo});
            this.grdLocacaoProventos.Location = new System.Drawing.Point(4, 186);
            this.grdLocacaoProventos.MultiSelect = false;
            this.grdLocacaoProventos.Name = "grdLocacaoProventos";
            this.grdLocacaoProventos.ReadOnly = true;
            this.grdLocacaoProventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLocacaoProventos.Size = new System.Drawing.Size(626, 141);
            this.grdLocacaoProventos.TabIndex = 13;
            this.grdLocacaoProventos.DoubleClick += new System.EventHandler(this.grdLocacaoProventos_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtReferencia);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtRotinaCalculo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboBaseIrpf);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboValorReferencia);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboBaseTaxaAdmCondominio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboBaseTaxaAdm);
            this.panel1.Controls.Add(this.txtAplicacao);
            this.panel1.Controls.Add(this.btnLocalizarAplicacao);
            this.panel1.Controls.Add(this.txtIdAplicacao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboIntegraDimob);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboTipoProvento);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdLocacaoProventos);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 112);
            this.panel1.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(331, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Referencia";
            // 
            // txtRotinaCalculo
            // 
            this.txtRotinaCalculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRotinaCalculo.Location = new System.Drawing.Point(531, 85);
            this.txtRotinaCalculo.MaxLength = 2;
            this.txtRotinaCalculo.Name = "txtRotinaCalculo";
            this.txtRotinaCalculo.Size = new System.Drawing.Size(89, 20);
            this.txtRotinaCalculo.TabIndex = 13;
            this.txtRotinaCalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(529, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Rotina Cálculo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(424, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Base IRPF";
            // 
            // cboBaseIrpf
            // 
            this.cboBaseIrpf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseIrpf.FormattingEnabled = true;
            this.cboBaseIrpf.Location = new System.Drawing.Point(423, 85);
            this.cboBaseIrpf.Name = "cboBaseIrpf";
            this.cboBaseIrpf.Size = new System.Drawing.Size(105, 21);
            this.cboBaseIrpf.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Valor Ref.";
            // 
            // cboValorReferencia
            // 
            this.cboValorReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValorReferencia.FormattingEnabled = true;
            this.cboValorReferencia.Location = new System.Drawing.Point(223, 84);
            this.cboValorReferencia.Name = "cboValorReferencia";
            this.cboValorReferencia.Size = new System.Drawing.Size(105, 21);
            this.cboValorReferencia.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Base Tx Adm Cond.";
            // 
            // cboBaseTaxaAdmCondominio
            // 
            this.cboBaseTaxaAdmCondominio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseTaxaAdmCondominio.FormattingEnabled = true;
            this.cboBaseTaxaAdmCondominio.Location = new System.Drawing.Point(113, 85);
            this.cboBaseTaxaAdmCondominio.Name = "cboBaseTaxaAdmCondominio";
            this.cboBaseTaxaAdmCondominio.Size = new System.Drawing.Size(105, 21);
            this.cboBaseTaxaAdmCondominio.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Base Txa Adm.";
            // 
            // cboBaseTaxaAdm
            // 
            this.cboBaseTaxaAdm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseTaxaAdm.FormattingEnabled = true;
            this.cboBaseTaxaAdm.Location = new System.Drawing.Point(5, 85);
            this.cboBaseTaxaAdm.Name = "cboBaseTaxaAdm";
            this.cboBaseTaxaAdm.Size = new System.Drawing.Size(105, 21);
            this.cboBaseTaxaAdm.TabIndex = 8;
            // 
            // txtAplicacao
            // 
            this.txtAplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAplicacao.Location = new System.Drawing.Point(111, 48);
            this.txtAplicacao.MaxLength = 50;
            this.txtAplicacao.Name = "txtAplicacao";
            this.txtAplicacao.ReadOnly = true;
            this.txtAplicacao.Size = new System.Drawing.Size(509, 20);
            this.txtAplicacao.TabIndex = 7;
            // 
            // btnLocalizarAplicacao
            // 
            this.btnLocalizarAplicacao.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocalizarAplicacao.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizarAplicacao.Image")));
            this.btnLocalizarAplicacao.Location = new System.Drawing.Point(71, 47);
            this.btnLocalizarAplicacao.Name = "btnLocalizarAplicacao";
            this.btnLocalizarAplicacao.Size = new System.Drawing.Size(37, 23);
            this.btnLocalizarAplicacao.TabIndex = 6;
            this.btnLocalizarAplicacao.UseVisualStyleBackColor = true;
            this.btnLocalizarAplicacao.Click += new System.EventHandler(this.btnLocalizarAplicacao_Click);
            // 
            // txtIdAplicacao
            // 
            this.txtIdAplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdAplicacao.Location = new System.Drawing.Point(5, 48);
            this.txtIdAplicacao.MaxLength = 50;
            this.txtIdAplicacao.Name = "txtIdAplicacao";
            this.txtIdAplicacao.Size = new System.Drawing.Size(63, 20);
            this.txtIdAplicacao.TabIndex = 5;
            this.txtIdAplicacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdAplicacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdAplicacao_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Aplicação";
            // 
            // cboIntegraDimob
            // 
            this.cboIntegraDimob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIntegraDimob.FormattingEnabled = true;
            this.cboIntegraDimob.Location = new System.Drawing.Point(551, 13);
            this.cboIntegraDimob.Name = "cboIntegraDimob";
            this.cboIntegraDimob.Size = new System.Drawing.Size(69, 21);
            this.cboIntegraDimob.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Int. Dimob";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo Provento";
            // 
            // cboTipoProvento
            // 
            this.cboTipoProvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoProvento.FormattingEnabled = true;
            this.cboTipoProvento.Location = new System.Drawing.Point(463, 13);
            this.cboTipoProvento.Name = "cboTipoProvento";
            this.cboTipoProvento.Size = new System.Drawing.Size(84, 21);
            this.cboTipoProvento.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descrição";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Código";
            // 
            // txtIdLocacaoProventos
            // 
            this.txtIdLocacaoProventos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdLocacaoProventos.Location = new System.Drawing.Point(5, 14);
            this.txtIdLocacaoProventos.MaxLength = 50;
            this.txtIdLocacaoProventos.Name = "txtIdLocacaoProventos";
            this.txtIdLocacaoProventos.Size = new System.Drawing.Size(63, 20);
            this.txtIdLocacaoProventos.TabIndex = 0;
            this.txtIdLocacaoProventos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdLocacaoProventos.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdLocacaoProventos_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(71, 14);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(389, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // txtReferencia
            // 
            this.txtReferencia.CustomFormat = "0:0";
            this.txtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtReferencia.Format = MaskedNumberFormat.Porcentagem;
            this.txtReferencia.Location = new System.Drawing.Point(334, 85);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(85, 20);
            this.txtReferencia.TabIndex = 11;
            this.txtReferencia.Text = "0,0000%";
            this.txtReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // idlocacaoproventos
            // 
            this.idlocacaoproventos.DataPropertyName = "idlocacaoproventos";
            this.idlocacaoproventos.HeaderText = "Cód";
            this.idlocacaoproventos.Name = "idlocacaoproventos";
            this.idlocacaoproventos.ReadOnly = true;
            this.idlocacaoproventos.Width = 51;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // tipoprovento
            // 
            this.tipoprovento.DataPropertyName = "tipoprovento";
            this.tipoprovento.HeaderText = "Tipo Provento";
            this.tipoprovento.Name = "tipoprovento";
            this.tipoprovento.ReadOnly = true;
            this.tipoprovento.Width = 99;
            // 
            // integradimob
            // 
            this.integradimob.DataPropertyName = "integradimob";
            this.integradimob.HeaderText = "Int. Dimob";
            this.integradimob.Name = "integradimob";
            this.integradimob.ReadOnly = true;
            this.integradimob.Width = 80;
            // 
            // idaplicacao
            // 
            this.idaplicacao.DataPropertyName = "idaplicacao";
            this.idaplicacao.HeaderText = "Id Aplicação";
            this.idaplicacao.Name = "idaplicacao";
            this.idaplicacao.ReadOnly = true;
            this.idaplicacao.Width = 91;
            // 
            // basetaxaadm
            // 
            this.basetaxaadm.DataPropertyName = "basetaxaadm";
            this.basetaxaadm.HeaderText = "Base Tx Adm";
            this.basetaxaadm.Name = "basetaxaadm";
            this.basetaxaadm.ReadOnly = true;
            this.basetaxaadm.Width = 95;
            // 
            // basetaxaadmcondominio
            // 
            this.basetaxaadmcondominio.DataPropertyName = "basetaxaadmcondominio";
            this.basetaxaadmcondominio.HeaderText = "Base Tx Adm Cond.";
            this.basetaxaadmcondominio.Name = "basetaxaadmcondominio";
            this.basetaxaadmcondominio.ReadOnly = true;
            this.basetaxaadmcondominio.Width = 90;
            // 
            // referencia
            // 
            this.referencia.DataPropertyName = "referencia";
            this.referencia.HeaderText = "Referência";
            this.referencia.Name = "referencia";
            this.referencia.ReadOnly = true;
            this.referencia.Width = 84;
            // 
            // valor_referencia
            // 
            this.valor_referencia.DataPropertyName = "valor_referencia";
            this.valor_referencia.HeaderText = "Valor Referência";
            this.valor_referencia.Name = "valor_referencia";
            this.valor_referencia.ReadOnly = true;
            this.valor_referencia.Width = 102;
            // 
            // baseirpf
            // 
            this.baseirpf.DataPropertyName = "baseirpf";
            this.baseirpf.HeaderText = "Base IRPF";
            this.baseirpf.Name = "baseirpf";
            this.baseirpf.ReadOnly = true;
            this.baseirpf.Width = 77;
            // 
            // rotinacalculo
            // 
            this.rotinacalculo.DataPropertyName = "rotinacalculo";
            this.rotinacalculo.HeaderText = "Rotina Cálculo";
            this.rotinacalculo.Name = "rotinacalculo";
            this.rotinacalculo.ReadOnly = true;
            this.rotinacalculo.Width = 93;
            // 
            // frmLocacaoProventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(635, 329);
            this.Controls.Add(this.grdLocacaoProventos);
            this.Controls.Add(this.panel1);
            this.Name = "frmLocacaoProventos";
            this.Text = "Tabela de Proventos";
            this.Load += new System.EventHandler(this.frmLocacaoProventos_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdLocacaoProventos, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdLocacaoProventos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdLocacaoProventos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdLocacaoProventos;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtIdAplicacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboIntegraDimob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoProvento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboBaseIrpf;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboValorReferencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboBaseTaxaAdmCondominio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBaseTaxaAdm;
        private System.Windows.Forms.TextBox txtAplicacao;
        private System.Windows.Forms.Button btnLocalizarAplicacao;
        private System.Windows.Forms.TextBox txtRotinaCalculo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private MaskedNumber.MaskedNumber txtReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaoproventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoprovento;
        private System.Windows.Forms.DataGridViewTextBoxColumn integradimob;
        private System.Windows.Forms.DataGridViewTextBoxColumn idaplicacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn basetaxaadm;
        private System.Windows.Forms.DataGridViewTextBoxColumn basetaxaadmcondominio;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseirpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotinacalculo;
    }
}
