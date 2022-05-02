namespace EMCFaturamento
{
    partial class frmFatu_TributacaoUf
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
            this.grdTributacaoUf = new System.Windows.Forms.DataGridView();
            this.btnEntradaIndustria = new System.Windows.Forms.Button();
            this.btnEntradaDistribuidor = new System.Windows.Forms.Button();
            this.btnEntradaME = new System.Windows.Forms.Button();
            this.btnEntradaProdutor = new System.Windows.Forms.Button();
            this.btnSaidaContribuinte = new System.Windows.Forms.Button();
            this.btnSaidaNaoContribuinte = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigoTributacao = new System.Windows.Forms.TextBox();
            this.btnIcms = new System.Windows.Forms.Button();
            this.txtTributacao = new System.Windows.Forms.TextBox();
            this.txtidFatu_Tributacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdFatu_NaturezaOperacao = new System.Windows.Forms.TextBox();
            this.btnNaturezaOperacao = new System.Windows.Forms.Button();
            this.txtNaturezaOperacao = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uforigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ufdestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icmstributado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icmsisento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icmsoutros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deduzreducao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icmsaliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipisomabase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subicmstributado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subicmsacrescimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subicmsaliquota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTributacaoUf)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTributacaoUf
            // 
            this.grdTributacaoUf.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTributacaoUf.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdTributacaoUf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTributacaoUf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uforigem,
            this.ufdestino,
            this.icmstributado,
            this.icmsisento,
            this.icmsoutros,
            this.deduzreducao,
            this.icmsaliquota,
            this.ipisomabase,
            this.subicmstributado,
            this.subicmsacrescimo,
            this.subicmsaliquota});
            this.grdTributacaoUf.Location = new System.Drawing.Point(2, 165);
            this.grdTributacaoUf.Name = "grdTributacaoUf";
            this.grdTributacaoUf.Size = new System.Drawing.Size(1004, 261);
            this.grdTributacaoUf.TabIndex = 1;
            // 
            // btnEntradaIndustria
            // 
            this.btnEntradaIndustria.Location = new System.Drawing.Point(3, 129);
            this.btnEntradaIndustria.Name = "btnEntradaIndustria";
            this.btnEntradaIndustria.Size = new System.Drawing.Size(165, 33);
            this.btnEntradaIndustria.TabIndex = 2;
            this.btnEntradaIndustria.Text = "&1 - Entrada de Indústria";
            this.btnEntradaIndustria.UseVisualStyleBackColor = true;
            // 
            // btnEntradaDistribuidor
            // 
            this.btnEntradaDistribuidor.Location = new System.Drawing.Point(170, 129);
            this.btnEntradaDistribuidor.Name = "btnEntradaDistribuidor";
            this.btnEntradaDistribuidor.Size = new System.Drawing.Size(165, 33);
            this.btnEntradaDistribuidor.TabIndex = 3;
            this.btnEntradaDistribuidor.Text = "&2 - Entrada de Distribuidor";
            this.btnEntradaDistribuidor.UseVisualStyleBackColor = true;
            // 
            // btnEntradaME
            // 
            this.btnEntradaME.Location = new System.Drawing.Point(337, 129);
            this.btnEntradaME.Name = "btnEntradaME";
            this.btnEntradaME.Size = new System.Drawing.Size(165, 33);
            this.btnEntradaME.TabIndex = 4;
            this.btnEntradaME.Text = "&3 - Entrada de Micro Empresa";
            this.btnEntradaME.UseVisualStyleBackColor = true;
            // 
            // btnEntradaProdutor
            // 
            this.btnEntradaProdutor.Location = new System.Drawing.Point(504, 129);
            this.btnEntradaProdutor.Name = "btnEntradaProdutor";
            this.btnEntradaProdutor.Size = new System.Drawing.Size(165, 33);
            this.btnEntradaProdutor.TabIndex = 5;
            this.btnEntradaProdutor.Text = "&4 - Entrada de Produtor";
            this.btnEntradaProdutor.UseVisualStyleBackColor = true;
            // 
            // btnSaidaContribuinte
            // 
            this.btnSaidaContribuinte.Location = new System.Drawing.Point(671, 129);
            this.btnSaidaContribuinte.Name = "btnSaidaContribuinte";
            this.btnSaidaContribuinte.Size = new System.Drawing.Size(165, 33);
            this.btnSaidaContribuinte.TabIndex = 6;
            this.btnSaidaContribuinte.Text = "&5 - Saída p/Contribuinte";
            this.btnSaidaContribuinte.UseVisualStyleBackColor = true;
            // 
            // btnSaidaNaoContribuinte
            // 
            this.btnSaidaNaoContribuinte.Location = new System.Drawing.Point(838, 129);
            this.btnSaidaNaoContribuinte.Name = "btnSaidaNaoContribuinte";
            this.btnSaidaNaoContribuinte.Size = new System.Drawing.Size(165, 33);
            this.btnSaidaNaoContribuinte.TabIndex = 7;
            this.btnSaidaNaoContribuinte.Text = "&6 - Saída p/não Contribuinte";
            this.btnSaidaNaoContribuinte.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIdFatu_NaturezaOperacao);
            this.groupBox1.Controls.Add(this.btnNaturezaOperacao);
            this.groupBox1.Controls.Add(this.txtNaturezaOperacao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodigoTributacao);
            this.groupBox1.Controls.Add(this.btnIcms);
            this.groupBox1.Controls.Add(this.txtTributacao);
            this.groupBox1.Controls.Add(this.txtidFatu_Tributacao);
            this.groupBox1.Location = new System.Drawing.Point(2, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 54);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identificação da Tributação";
            // 
            // txtCodigoTributacao
            // 
            this.txtCodigoTributacao.Location = new System.Drawing.Point(504, 30);
            this.txtCodigoTributacao.MaxLength = 3;
            this.txtCodigoTributacao.Name = "txtCodigoTributacao";
            this.txtCodigoTributacao.Size = new System.Drawing.Size(33, 20);
            this.txtCodigoTributacao.TabIndex = 255;
            this.txtCodigoTributacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnIcms
            // 
            this.btnIcms.Image = global::EMCFaturamento.Properties.Resources.binoculo_16x16;
            this.btnIcms.Location = new System.Drawing.Point(538, 28);
            this.btnIcms.Name = "btnIcms";
            this.btnIcms.Size = new System.Drawing.Size(31, 23);
            this.btnIcms.TabIndex = 257;
            this.btnIcms.UseVisualStyleBackColor = true;
            // 
            // txtTributacao
            // 
            this.txtTributacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTributacao.Enabled = false;
            this.txtTributacao.Location = new System.Drawing.Point(570, 30);
            this.txtTributacao.MaxLength = 50;
            this.txtTributacao.Name = "txtTributacao";
            this.txtTributacao.Size = new System.Drawing.Size(428, 20);
            this.txtTributacao.TabIndex = 256;
            // 
            // txtidFatu_Tributacao
            // 
            this.txtidFatu_Tributacao.Location = new System.Drawing.Point(626, 10);
            this.txtidFatu_Tributacao.Name = "txtidFatu_Tributacao";
            this.txtidFatu_Tributacao.Size = new System.Drawing.Size(43, 20);
            this.txtidFatu_Tributacao.TabIndex = 254;
            this.txtidFatu_Tributacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidFatu_Tributacao.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 258;
            this.label1.Text = "Tributação ICMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 263;
            this.label2.Text = "Natureza de Operação";
            // 
            // txtIdFatu_NaturezaOperacao
            // 
            this.txtIdFatu_NaturezaOperacao.Location = new System.Drawing.Point(6, 30);
            this.txtIdFatu_NaturezaOperacao.MaxLength = 3;
            this.txtIdFatu_NaturezaOperacao.Name = "txtIdFatu_NaturezaOperacao";
            this.txtIdFatu_NaturezaOperacao.Size = new System.Drawing.Size(33, 20);
            this.txtIdFatu_NaturezaOperacao.TabIndex = 260;
            this.txtIdFatu_NaturezaOperacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnNaturezaOperacao
            // 
            this.btnNaturezaOperacao.Image = global::EMCFaturamento.Properties.Resources.binoculo_16x16;
            this.btnNaturezaOperacao.Location = new System.Drawing.Point(39, 28);
            this.btnNaturezaOperacao.Name = "btnNaturezaOperacao";
            this.btnNaturezaOperacao.Size = new System.Drawing.Size(31, 23);
            this.btnNaturezaOperacao.TabIndex = 262;
            this.btnNaturezaOperacao.UseVisualStyleBackColor = true;
            // 
            // txtNaturezaOperacao
            // 
            this.txtNaturezaOperacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNaturezaOperacao.Enabled = false;
            this.txtNaturezaOperacao.Location = new System.Drawing.Point(71, 31);
            this.txtNaturezaOperacao.MaxLength = 50;
            this.txtNaturezaOperacao.Name = "txtNaturezaOperacao";
            this.txtNaturezaOperacao.Size = new System.Drawing.Size(428, 20);
            this.txtNaturezaOperacao.TabIndex = 261;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(2, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 138);
            this.panel1.TabIndex = 9;
            // 
            // uforigem
            // 
            this.uforigem.HeaderText = "UF Origem";
            this.uforigem.Name = "uforigem";
            this.uforigem.Width = 50;
            // 
            // ufdestino
            // 
            this.ufdestino.HeaderText = "UF Destino";
            this.ufdestino.Name = "ufdestino";
            this.ufdestino.Width = 50;
            // 
            // icmstributado
            // 
            this.icmstributado.HeaderText = "ICMS Tributado";
            this.icmstributado.Name = "icmstributado";
            this.icmstributado.Width = 75;
            // 
            // icmsisento
            // 
            this.icmsisento.HeaderText = "ICMS Isento";
            this.icmsisento.Name = "icmsisento";
            this.icmsisento.Width = 75;
            // 
            // icmsoutros
            // 
            this.icmsoutros.HeaderText = "ICMS Outros";
            this.icmsoutros.Name = "icmsoutros";
            this.icmsoutros.Width = 75;
            // 
            // deduzreducao
            // 
            this.deduzreducao.HeaderText = "Deduz Redução";
            this.deduzreducao.Name = "deduzreducao";
            this.deduzreducao.Width = 75;
            // 
            // icmsaliquota
            // 
            this.icmsaliquota.HeaderText = "ICMS Aliquota";
            this.icmsaliquota.Name = "icmsaliquota";
            this.icmsaliquota.Width = 75;
            // 
            // ipisomabase
            // 
            this.ipisomabase.HeaderText = "IPI Soma Base ICMS";
            this.ipisomabase.Name = "ipisomabase";
            // 
            // subicmstributado
            // 
            this.subicmstributado.HeaderText = "ICMS Subst. Tributado";
            this.subicmstributado.Name = "subicmstributado";
            // 
            // subicmsacrescimo
            // 
            this.subicmsacrescimo.HeaderText = "ICMS Sbstit. Acrécimo";
            this.subicmsacrescimo.Name = "subicmsacrescimo";
            // 
            // subicmsaliquota
            // 
            this.subicmsaliquota.HeaderText = "ICMS Subst. Aliquota";
            this.subicmsaliquota.Name = "subicmsaliquota";
            // 
            // frmFatu_TributacaoUf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 571);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaidaNaoContribuinte);
            this.Controls.Add(this.btnSaidaContribuinte);
            this.Controls.Add(this.btnEntradaProdutor);
            this.Controls.Add(this.btnEntradaME);
            this.Controls.Add(this.btnEntradaDistribuidor);
            this.Controls.Add(this.btnEntradaIndustria);
            this.Controls.Add(this.grdTributacaoUf);
            this.Name = "frmFatu_TributacaoUf";
            this.Text = "Tributação por Estado";
            this.Controls.SetChildIndex(this.grdTributacaoUf, 0);
            this.Controls.SetChildIndex(this.btnEntradaIndustria, 0);
            this.Controls.SetChildIndex(this.btnEntradaDistribuidor, 0);
            this.Controls.SetChildIndex(this.btnEntradaME, 0);
            this.Controls.SetChildIndex(this.btnEntradaProdutor, 0);
            this.Controls.SetChildIndex(this.btnSaidaContribuinte, 0);
            this.Controls.SetChildIndex(this.btnSaidaNaoContribuinte, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTributacaoUf)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTributacaoUf;
        private System.Windows.Forms.Button btnEntradaIndustria;
        private System.Windows.Forms.Button btnEntradaDistribuidor;
        private System.Windows.Forms.Button btnEntradaME;
        private System.Windows.Forms.Button btnEntradaProdutor;
        private System.Windows.Forms.Button btnSaidaContribuinte;
        private System.Windows.Forms.Button btnSaidaNaoContribuinte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoTributacao;
        private System.Windows.Forms.Button btnIcms;
        private System.Windows.Forms.TextBox txtTributacao;
        private System.Windows.Forms.TextBox txtidFatu_Tributacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdFatu_NaturezaOperacao;
        private System.Windows.Forms.Button btnNaturezaOperacao;
        private System.Windows.Forms.TextBox txtNaturezaOperacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn uforigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ufdestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn icmstributado;
        private System.Windows.Forms.DataGridViewTextBoxColumn icmsisento;
        private System.Windows.Forms.DataGridViewTextBoxColumn icmsoutros;
        private System.Windows.Forms.DataGridViewTextBoxColumn deduzreducao;
        private System.Windows.Forms.DataGridViewTextBoxColumn icmsaliquota;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipisomabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn subicmstributado;
        private System.Windows.Forms.DataGridViewTextBoxColumn subicmsacrescimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn subicmsaliquota;
    }
}
