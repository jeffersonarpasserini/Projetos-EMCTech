namespace EMCFinanceiro.Pesquisa
{
    partial class psqContasPagar
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdPsqCtaPagar = new System.Windows.Forms.DataGridView();
            this.idpagardocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomefornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataemissao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.chkDocumentosAberto = new System.Windows.Forms.CheckBox();
            this.chkValorDocumento = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorFinal = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorInicio = new System.Windows.Forms.Sample.DecimalTextBox();
            this.chkTodasContas = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.DateTimePicker();
            this.txtIdFornecedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaPagar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPsqCtaPagar
            // 
            this.grdPsqCtaPagar.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqCtaPagar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqCtaPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqCtaPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpagardocumento,
            this.nrodocumento,
            this.nomefornecedor,
            this.dataemissao,
            this.valordocumento,
            this.situacao});
            this.grdPsqCtaPagar.Location = new System.Drawing.Point(2, 183);
            this.grdPsqCtaPagar.Name = "grdPsqCtaPagar";
            this.grdPsqCtaPagar.ReadOnly = true;
            this.grdPsqCtaPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqCtaPagar.Size = new System.Drawing.Size(743, 240);
            this.grdPsqCtaPagar.TabIndex = 0;
            this.grdPsqCtaPagar.DoubleClick += new System.EventHandler(this.grdPsqCtaPagar_DoubleClick);
            // 
            // idpagardocumento
            // 
            this.idpagardocumento.DataPropertyName = "idpagardocumento";
            this.idpagardocumento.HeaderText = "id";
            this.idpagardocumento.Name = "idpagardocumento";
            this.idpagardocumento.ReadOnly = true;
            this.idpagardocumento.Visible = false;
            // 
            // nrodocumento
            // 
            this.nrodocumento.DataPropertyName = "nrodocumento";
            this.nrodocumento.HeaderText = "Numero Documento";
            this.nrodocumento.Name = "nrodocumento";
            this.nrodocumento.ReadOnly = true;
            // 
            // nomefornecedor
            // 
            this.nomefornecedor.DataPropertyName = "nomefornecedor";
            this.nomefornecedor.HeaderText = "Fornecedor";
            this.nomefornecedor.Name = "nomefornecedor";
            this.nomefornecedor.ReadOnly = true;
            this.nomefornecedor.Width = 350;
            // 
            // dataemissao
            // 
            this.dataemissao.DataPropertyName = "dataemissao";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dataemissao.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataemissao.HeaderText = "Data Emissão";
            this.dataemissao.Name = "dataemissao";
            this.dataemissao.ReadOnly = true;
            // 
            // valordocumento
            // 
            this.valordocumento.DataPropertyName = "valordocumento";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valordocumento.DefaultCellStyle = dataGridViewCellStyle3;
            this.valordocumento.HeaderText = "Valor";
            this.valordocumento.Name = "valordocumento";
            this.valordocumento.ReadOnly = true;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Sit";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 63);
            this.panel1.TabIndex = 1;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = global::EMCFinanceiro.Properties.Resources.binoculo_32x32;
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 14;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnPesquisa, "[F8] Pesquisa");
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCFinanceiro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFornecedor);
            this.panel2.Controls.Add(this.txtFornecedor);
            this.panel2.Controls.Add(this.chkDocumentosAberto);
            this.panel2.Controls.Add(this.chkValorDocumento);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtValorFinal);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtValorInicio);
            this.panel2.Controls.Add(this.chkTodasContas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtDataFinal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtDataInicio);
            this.panel2.Controls.Add(this.txtIdFornecedor);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(2, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 109);
            this.panel2.TabIndex = 2;
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnFornecedor.Location = new System.Drawing.Point(64, 21);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(31, 23);
            this.btnFornecedor.TabIndex = 35;
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(97, 23);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(271, 20);
            this.txtFornecedor.TabIndex = 34;
            // 
            // chkDocumentosAberto
            // 
            this.chkDocumentosAberto.AutoSize = true;
            this.chkDocumentosAberto.Location = new System.Drawing.Point(506, 68);
            this.chkDocumentosAberto.Name = "chkDocumentosAberto";
            this.chkDocumentosAberto.Size = new System.Drawing.Size(234, 17);
            this.chkDocumentosAberto.TabIndex = 33;
            this.chkDocumentosAberto.Text = "Considerar Somente Documentos em aberto";
            this.chkDocumentosAberto.UseVisualStyleBackColor = true;
            // 
            // chkValorDocumento
            // 
            this.chkValorDocumento.AutoSize = true;
            this.chkValorDocumento.Checked = true;
            this.chkValorDocumento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValorDocumento.Location = new System.Drawing.Point(261, 68);
            this.chkValorDocumento.Name = "chkValorDocumento";
            this.chkValorDocumento.Size = new System.Drawing.Size(162, 17);
            this.chkValorDocumento.TabIndex = 32;
            this.chkValorDocumento.Text = "Todas as Contas do Período";
            this.chkValorDocumento.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "até";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Valor Documento";
            // 
            // txtValorFinal
            // 
            this.txtValorFinal.Location = new System.Drawing.Point(147, 65);
            this.txtValorFinal.Name = "txtValorFinal";
            this.txtValorFinal.numeroDecimais = 0;
            this.txtValorFinal.Size = new System.Drawing.Size(109, 20);
            this.txtValorFinal.TabIndex = 29;
            this.txtValorFinal.Text = "0,00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Valor Documento";
            // 
            // txtValorInicio
            // 
            this.txtValorInicio.Location = new System.Drawing.Point(9, 65);
            this.txtValorInicio.Name = "txtValorInicio";
            this.txtValorInicio.numeroDecimais = 0;
            this.txtValorInicio.Size = new System.Drawing.Size(109, 20);
            this.txtValorInicio.TabIndex = 27;
            this.txtValorInicio.Text = "0,00";
            // 
            // chkTodasContas
            // 
            this.chkTodasContas.AutoSize = true;
            this.chkTodasContas.Checked = true;
            this.chkTodasContas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodasContas.Location = new System.Drawing.Point(576, 26);
            this.chkTodasContas.Name = "chkTodasContas";
            this.chkTodasContas.Size = new System.Drawing.Size(162, 17);
            this.chkTodasContas.TabIndex = 15;
            this.chkTodasContas.Text = "Todas as Contas do Período";
            this.chkTodasContas.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(482, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Data Emissão";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFinal.Location = new System.Drawing.Point(484, 24);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(88, 20);
            this.txtDataFinal.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Emissão";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataInicio.Location = new System.Drawing.Point(374, 24);
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(88, 20);
            this.txtDataInicio.TabIndex = 9;
            // 
            // txtIdFornecedor
            // 
            this.txtIdFornecedor.Location = new System.Drawing.Point(6, 23);
            this.txtIdFornecedor.Name = "txtIdFornecedor";
            this.txtIdFornecedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdFornecedor.Size = new System.Drawing.Size(56, 20);
            this.txtIdFornecedor.TabIndex = 6;
            this.txtIdFornecedor.TextChanged += new System.EventHandler(this.txtIdFornecedor_TextChanged);
            this.txtIdFornecedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdFornecedor_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fornecedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(581, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "[F8] Pesquisa";
            // 
            // psqContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 425);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqCtaPagar);
            this.KeyPreview = true;
            this.Name = "psqContasPagar";
            this.Text = "Pesquisa Contas a Pagar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqContasPagar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaPagar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPsqCtaPagar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtIdFornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtDataFinal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtDataInicio;
        private System.Windows.Forms.CheckBox chkTodasContas;
        private System.Windows.Forms.CheckBox chkValorDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorFinal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtValorInicio;
        private System.Windows.Forms.CheckBox chkDocumentosAberto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagardocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomefornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataemissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
    }
}