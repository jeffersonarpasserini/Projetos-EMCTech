namespace EMCImob
{
    partial class psqDespesaImovel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqDespesaImovel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnImovel = new System.Windows.Forms.Button();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.txtPessoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLocalizarProprietario = new System.Windows.Forms.Button();
            this.txtIdDespesaImovel = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqDespesaImovel = new System.Windows.Forms.DataGridView();
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.fornecedor_idpessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locacaoproventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datalancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoacerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoprovento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_codempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedor_idp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddespesaimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlocacaoproventos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataacerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqDespesaImovel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtCodigoImovel);
            this.panel3.Controls.Add(this.btnImovel);
            this.panel3.Controls.Add(this.txtImovel);
            this.panel3.Controls.Add(this.txtIdImovel);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtDataFinal);
            this.panel3.Controls.Add(this.txtDataInicial);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtIdPessoa);
            this.panel3.Controls.Add(this.txtPessoa);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnLocalizarProprietario);
            this.panel3.Location = new System.Drawing.Point(2, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 77);
            this.panel3.TabIndex = 125;
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(77, 50);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 500;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(108, 51);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(210, 20);
            this.txtImovel.TabIndex = 501;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 502;
            this.label2.Text = "Imóvel";
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(46, 34);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdImovel.TabIndex = 499;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(398, 51);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(71, 20);
            this.txtDataFinal.TabIndex = 498;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(324, 51);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(71, 20);
            this.txtDataInicial.TabIndex = 497;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(398, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "até";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 114;
            this.label5.Text = "Fornecedor";
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdPessoa.Location = new System.Drawing.Point(5, 16);
            this.txtIdPessoa.MaxLength = 50;
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(40, 20);
            this.txtIdPessoa.TabIndex = 1;
            this.txtIdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdPessoa.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdPessoa_Validating);
            // 
            // txtPessoa
            // 
            this.txtPessoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPessoa.Location = new System.Drawing.Point(77, 16);
            this.txtPessoa.MaxLength = 50;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(392, 20);
            this.txtPessoa.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Período de";
            // 
            // btnLocalizarProprietario
            // 
            this.btnLocalizarProprietario.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizarProprietario.Image")));
            this.btnLocalizarProprietario.Location = new System.Drawing.Point(46, 15);
            this.btnLocalizarProprietario.Name = "btnLocalizarProprietario";
            this.btnLocalizarProprietario.Size = new System.Drawing.Size(30, 22);
            this.btnLocalizarProprietario.TabIndex = 2;
            this.btnLocalizarProprietario.UseVisualStyleBackColor = true;
            this.btnLocalizarProprietario.Click += new System.EventHandler(this.btnLocalizarProprietario_Click);
            // 
            // txtIdDespesaImovel
            // 
            this.txtIdDespesaImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdDespesaImovel.Location = new System.Drawing.Point(427, 11);
            this.txtIdDespesaImovel.MaxLength = 50;
            this.txtIdDespesaImovel.Name = "txtIdDespesaImovel";
            this.txtIdDespesaImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdDespesaImovel.TabIndex = 111;
            this.txtIdDespesaImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdDespesaImovel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.txtIdDespesaImovel);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 63);
            this.panel1.TabIndex = 123;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 14;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 13;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grdPsqDespesaImovel
            // 
            this.grdPsqDespesaImovel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqDespesaImovel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqDespesaImovel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPsqDespesaImovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqDespesaImovel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fornecedor_idpessoa,
            this.codigoimovel,
            this.locacaoproventos,
            this.datalancamento,
            this.valordespesa,
            this.situacao,
            this.descricaoacerto,
            this.tipoprovento,
            this.fornecedor_codempresa,
            this.fornecedor_idp,
            this.iddespesaimovel,
            this.tipoimovel,
            this.idimovel,
            this.idlocacaoproventos,
            this.historico,
            this.dataacerto});
            this.grdPsqDespesaImovel.Location = new System.Drawing.Point(2, 145);
            this.grdPsqDespesaImovel.MultiSelect = false;
            this.grdPsqDespesaImovel.Name = "grdPsqDespesaImovel";
            this.grdPsqDespesaImovel.ReadOnly = true;
            this.grdPsqDespesaImovel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqDespesaImovel.Size = new System.Drawing.Size(476, 166);
            this.grdPsqDespesaImovel.TabIndex = 127;
            this.grdPsqDespesaImovel.DoubleClick += new System.EventHandler(this.grdPsqDespesaImovel_DoubleClick);
            this.grdPsqDespesaImovel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqDespesaImovel_KeyDown);
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(5, 51);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(71, 20);
            this.txtCodigoImovel.TabIndex = 128;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // fornecedor_idpessoa
            // 
            this.fornecedor_idpessoa.DataPropertyName = "nome_proprietario";
            this.fornecedor_idpessoa.HeaderText = "Fornecedor";
            this.fornecedor_idpessoa.Name = "fornecedor_idpessoa";
            this.fornecedor_idpessoa.ReadOnly = true;
            this.fornecedor_idpessoa.Width = 86;
            // 
            // codigoimovel
            // 
            this.codigoimovel.DataPropertyName = "codigoimovel";
            this.codigoimovel.HeaderText = "Código Imóvel";
            this.codigoimovel.Name = "codigoimovel";
            this.codigoimovel.ReadOnly = true;
            this.codigoimovel.Width = 99;
            // 
            // locacaoproventos
            // 
            this.locacaoproventos.DataPropertyName = "desc_proventos";
            this.locacaoproventos.HeaderText = "Proventos";
            this.locacaoproventos.Name = "locacaoproventos";
            this.locacaoproventos.ReadOnly = true;
            this.locacaoproventos.Width = 80;
            // 
            // datalancamento
            // 
            this.datalancamento.DataPropertyName = "datalancamento";
            this.datalancamento.HeaderText = "Data Lançamento";
            this.datalancamento.Name = "datalancamento";
            this.datalancamento.ReadOnly = true;
            this.datalancamento.Width = 107;
            // 
            // valordespesa
            // 
            this.valordespesa.DataPropertyName = "valordespesa";
            this.valordespesa.HeaderText = "Vlr. Despesa";
            this.valordespesa.Name = "valordespesa";
            this.valordespesa.ReadOnly = true;
            this.valordespesa.Width = 85;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 74;
            // 
            // descricaoacerto
            // 
            this.descricaoacerto.DataPropertyName = "descricaoacerto";
            this.descricaoacerto.HeaderText = "Descrição do Acerto";
            this.descricaoacerto.Name = "descricaoacerto";
            this.descricaoacerto.ReadOnly = true;
            this.descricaoacerto.Width = 90;
            // 
            // tipoprovento
            // 
            this.tipoprovento.DataPropertyName = "tipoprovento";
            this.tipoprovento.HeaderText = "tipoprovento";
            this.tipoprovento.Name = "tipoprovento";
            this.tipoprovento.ReadOnly = true;
            this.tipoprovento.Visible = false;
            this.tipoprovento.Width = 91;
            // 
            // fornecedor_codempresa
            // 
            this.fornecedor_codempresa.DataPropertyName = "fornecedor_codempresa";
            this.fornecedor_codempresa.HeaderText = "fornecedor codempresa";
            this.fornecedor_codempresa.Name = "fornecedor_codempresa";
            this.fornecedor_codempresa.ReadOnly = true;
            this.fornecedor_codempresa.Visible = false;
            this.fornecedor_codempresa.Width = 132;
            // 
            // fornecedor_idp
            // 
            this.fornecedor_idp.DataPropertyName = "fornecedor_idpessoa";
            this.fornecedor_idp.HeaderText = "fornecedor idpessoa";
            this.fornecedor_idp.Name = "fornecedor_idp";
            this.fornecedor_idp.ReadOnly = true;
            this.fornecedor_idp.Visible = false;
            this.fornecedor_idp.Width = 117;
            // 
            // iddespesaimovel
            // 
            this.iddespesaimovel.DataPropertyName = "iddespesaimovel";
            this.iddespesaimovel.HeaderText = "Cód. Despesa";
            this.iddespesaimovel.Name = "iddespesaimovel";
            this.iddespesaimovel.ReadOnly = true;
            this.iddespesaimovel.Visible = false;
            this.iddespesaimovel.Width = 91;
            // 
            // tipoimovel
            // 
            this.tipoimovel.DataPropertyName = "desc_tipoimovel";
            this.tipoimovel.HeaderText = "Imóvel";
            this.tipoimovel.Name = "tipoimovel";
            this.tipoimovel.ReadOnly = true;
            this.tipoimovel.Visible = false;
            this.tipoimovel.Width = 63;
            // 
            // idimovel
            // 
            this.idimovel.DataPropertyName = "idimovel";
            this.idimovel.HeaderText = "idimovel";
            this.idimovel.Name = "idimovel";
            this.idimovel.ReadOnly = true;
            this.idimovel.Visible = false;
            this.idimovel.Width = 70;
            // 
            // idlocacaoproventos
            // 
            this.idlocacaoproventos.DataPropertyName = "idlocacaoproventos";
            this.idlocacaoproventos.HeaderText = "idlocacaoproventos";
            this.idlocacaoproventos.Name = "idlocacaoproventos";
            this.idlocacaoproventos.ReadOnly = true;
            this.idlocacaoproventos.Visible = false;
            this.idlocacaoproventos.Width = 125;
            // 
            // historico
            // 
            this.historico.DataPropertyName = "historico";
            this.historico.HeaderText = "Histórico";
            this.historico.Name = "historico";
            this.historico.ReadOnly = true;
            this.historico.Visible = false;
            this.historico.Width = 73;
            // 
            // dataacerto
            // 
            this.dataacerto.DataPropertyName = "dataacerto";
            this.dataacerto.HeaderText = "Data Acerto";
            this.dataacerto.Name = "dataacerto";
            this.dataacerto.ReadOnly = true;
            this.dataacerto.Visible = false;
            this.dataacerto.Width = 82;
            // 
            // psqDespesaImovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 314);
            this.Controls.Add(this.grdPsqDespesaImovel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "psqDespesaImovel";
            this.Text = "Pesquisa Despesa Imóvel";
            this.Load += new System.EventHandler(this.psqDespesaImovel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqDespesaImovel_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqDespesaImovel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtIdDespesaImovel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqDespesaImovel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.TextBox txtPessoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLocalizarProprietario;
        private System.Windows.Forms.Label label1;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_idpessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn locacaoproventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn datalancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoacerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoprovento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_codempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fornecedor_idp;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesaimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlocacaoproventos;
        private System.Windows.Forms.DataGridViewTextBoxColumn historico;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataacerto;
    }
}