namespace EMCImob
{
    partial class psqIptu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqIptu));
            this.grdPsqIptu = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtDataInicial = new MaskedDateEntryControl.MaskedDateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtIdIptu = new System.Windows.Forms.TextBox();
            this.idiptu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagoimobiliaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoacerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anobase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuarioexclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataexclusao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqIptu)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPsqIptu
            // 
            this.grdPsqIptu.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqIptu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqIptu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPsqIptu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqIptu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idiptu,
            this.idimovel,
            this.codigoimovel,
            this.nroparcela,
            this.datavencimento,
            this.valorparcela,
            this.observacao,
            this.pagoimobiliaria,
            this.tipoacerto,
            this.situacao,
            this.anobase,
            this.idusuarioexclusao,
            this.dataexclusao});
            this.grdPsqIptu.Location = new System.Drawing.Point(2, 113);
            this.grdPsqIptu.MultiSelect = false;
            this.grdPsqIptu.Name = "grdPsqIptu";
            this.grdPsqIptu.ReadOnly = true;
            this.grdPsqIptu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqIptu.Size = new System.Drawing.Size(476, 199);
            this.grdPsqIptu.TabIndex = 130;
            this.grdPsqIptu.DoubleClick += new System.EventHandler(this.grdPsqIptu_DoubleClick);
            this.grdPsqIptu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqIptu_KeyDown);
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
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(2, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 44);
            this.panel3.TabIndex = 129;
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(2, 18);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(71, 20);
            this.txtCodigoImovel.TabIndex = 128;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(74, 17);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 500;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(105, 18);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(210, 20);
            this.txtImovel.TabIndex = 501;
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(43, 1);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdImovel.TabIndex = 499;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 502;
            this.label2.Text = "Imóvel";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(395, 18);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(76, 20);
            this.txtDataFinal.TabIndex = 498;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.DateValue = null;
            this.txtDataInicial.Location = new System.Drawing.Point(317, 18);
            this.txtDataInicial.Mask = "00/00/0000";
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.RequireValidEntry = true;
            this.txtDataInicial.Size = new System.Drawing.Size(76, 20);
            this.txtDataInicial.TabIndex = 497;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "até";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Vencimento ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.txtIdIptu);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 63);
            this.panel1.TabIndex = 128;
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
            // txtIdIptu
            // 
            this.txtIdIptu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdIptu.Location = new System.Drawing.Point(427, 11);
            this.txtIdIptu.MaxLength = 50;
            this.txtIdIptu.Name = "txtIdIptu";
            this.txtIdIptu.Size = new System.Drawing.Size(40, 20);
            this.txtIdIptu.TabIndex = 111;
            this.txtIdIptu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdIptu.Visible = false;
            // 
            // idiptu
            // 
            this.idiptu.DataPropertyName = "idiptu";
            this.idiptu.HeaderText = "Cód. Iptu";
            this.idiptu.Name = "idiptu";
            this.idiptu.ReadOnly = true;
            this.idiptu.Width = 75;
            // 
            // idimovel
            // 
            this.idimovel.DataPropertyName = "idimovel";
            this.idimovel.HeaderText = "Cód. Imóvel";
            this.idimovel.Name = "idimovel";
            this.idimovel.ReadOnly = true;
            this.idimovel.Visible = false;
            this.idimovel.Width = 88;
            // 
            // codigoimovel
            // 
            this.codigoimovel.DataPropertyName = "codigoimovel";
            this.codigoimovel.HeaderText = "Imóvel";
            this.codigoimovel.Name = "codigoimovel";
            this.codigoimovel.ReadOnly = true;
            this.codigoimovel.Width = 63;
            // 
            // nroparcela
            // 
            this.nroparcela.DataPropertyName = "nroparcela";
            this.nroparcela.HeaderText = "Nro. Parcelas";
            this.nroparcela.Name = "nroparcela";
            this.nroparcela.ReadOnly = true;
            this.nroparcela.Width = 96;
            // 
            // datavencimento
            // 
            this.datavencimento.DataPropertyName = "datavencimento";
            this.datavencimento.HeaderText = "Vencimento";
            this.datavencimento.Name = "datavencimento";
            this.datavencimento.ReadOnly = true;
            this.datavencimento.Width = 88;
            // 
            // valorparcela
            // 
            this.valorparcela.DataPropertyName = "valorparcela";
            this.valorparcela.HeaderText = "Valor";
            this.valorparcela.Name = "valorparcela";
            this.valorparcela.ReadOnly = true;
            this.valorparcela.Width = 56;
            // 
            // observacao
            // 
            this.observacao.DataPropertyName = "observacao";
            this.observacao.HeaderText = "Observação";
            this.observacao.Name = "observacao";
            this.observacao.ReadOnly = true;
            this.observacao.Width = 90;
            // 
            // pagoimobiliaria
            // 
            this.pagoimobiliaria.DataPropertyName = "pagoimobiliaria";
            this.pagoimobiliaria.HeaderText = "Pago Imob.";
            this.pagoimobiliaria.Name = "pagoimobiliaria";
            this.pagoimobiliaria.ReadOnly = true;
            this.pagoimobiliaria.Width = 86;
            // 
            // tipoacerto
            // 
            this.tipoacerto.DataPropertyName = "tipoacerto";
            this.tipoacerto.HeaderText = "Tipo Acerto";
            this.tipoacerto.Name = "tipoacerto";
            this.tipoacerto.ReadOnly = true;
            this.tipoacerto.Width = 87;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 74;
            // 
            // anobase
            // 
            this.anobase.DataPropertyName = "anobase";
            this.anobase.HeaderText = "Ano Base";
            this.anobase.Name = "anobase";
            this.anobase.ReadOnly = true;
            this.anobase.Width = 78;
            // 
            // idusuarioexclusao
            // 
            this.idusuarioexclusao.HeaderText = "UsuarioExclusao";
            this.idusuarioexclusao.Name = "idusuarioexclusao";
            this.idusuarioexclusao.ReadOnly = true;
            this.idusuarioexclusao.Visible = false;
            this.idusuarioexclusao.Width = 111;
            // 
            // dataexclusao
            // 
            this.dataexclusao.DataPropertyName = "dataexclusao";
            this.dataexclusao.HeaderText = "DataExclusao";
            this.dataexclusao.Name = "dataexclusao";
            this.dataexclusao.ReadOnly = true;
            this.dataexclusao.Visible = false;
            this.dataexclusao.Width = 98;
            // 
            // psqIptu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 314);
            this.Controls.Add(this.grdPsqIptu);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "psqIptu";
            this.Text = "IPTU";
            this.Load += new System.EventHandler(this.psqIptu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqIptu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPsqIptu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.Label label2;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtIdIptu;
        private System.Windows.Forms.DataGridViewTextBoxColumn idiptu;
        private System.Windows.Forms.DataGridViewTextBoxColumn idimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagoimobiliaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoacerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn anobase;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioexclusao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataexclusao;
    }
}