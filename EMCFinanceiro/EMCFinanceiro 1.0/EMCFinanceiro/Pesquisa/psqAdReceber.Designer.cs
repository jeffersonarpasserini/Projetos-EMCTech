﻿namespace EMCFinanceiro.Pesquisa
{
    partial class psqAdReceber
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqCtaReceber = new System.Windows.Forms.DataGridView();
            this.idpagarbaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroparcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomefornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datapagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valordocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdoamortizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaReceber)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCliente);
            this.panel2.Controls.Add(this.txtCliente);
            this.panel2.Controls.Add(this.txtIdCliente);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(4, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 54);
            this.panel2.TabIndex = 8;
            // 
            // btnCliente
            // 
            this.btnCliente.Image = global::EMCFinanceiro.Properties.Resources.binoculo_16x16;
            this.btnCliente.Location = new System.Drawing.Point(64, 21);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(31, 23);
            this.btnCliente.TabIndex = 35;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(97, 23);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(422, 20);
            this.txtCliente.TabIndex = 34;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(6, 23);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIdCliente.Size = new System.Drawing.Size(56, 20);
            this.txtIdCliente.TabIndex = 6;
            this.txtIdCliente.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdCliente_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cliente";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 63);
            this.panel1.TabIndex = 7;
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
            // grdPsqCtaReceber
            // 
            this.grdPsqCtaReceber.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqCtaReceber.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqCtaReceber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqCtaReceber.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idpagarbaixa,
            this.nrodocumento,
            this.nroparcela,
            this.nomefornecedor,
            this.datapagamento,
            this.valordocumento,
            this.sdoamortizacao});
            this.grdPsqCtaReceber.Location = new System.Drawing.Point(3, 132);
            this.grdPsqCtaReceber.Name = "grdPsqCtaReceber";
            this.grdPsqCtaReceber.ReadOnly = true;
            this.grdPsqCtaReceber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqCtaReceber.Size = new System.Drawing.Size(841, 240);
            this.grdPsqCtaReceber.TabIndex = 6;
            this.grdPsqCtaReceber.DoubleClick += new System.EventHandler(this.grdPsqCtaReceber_DoubleClick);
            // 
            // idpagarbaixa
            // 
            this.idpagarbaixa.DataPropertyName = "idpagarbaixa";
            this.idpagarbaixa.HeaderText = "id";
            this.idpagarbaixa.Name = "idpagarbaixa";
            this.idpagarbaixa.ReadOnly = true;
            this.idpagarbaixa.Visible = false;
            // 
            // nrodocumento
            // 
            this.nrodocumento.DataPropertyName = "nrodocumento";
            this.nrodocumento.HeaderText = "Numero Documento";
            this.nrodocumento.Name = "nrodocumento";
            this.nrodocumento.ReadOnly = true;
            // 
            // nroparcela
            // 
            this.nroparcela.DataPropertyName = "nroparcela";
            this.nroparcela.HeaderText = "Parcela";
            this.nroparcela.Name = "nroparcela";
            this.nroparcela.ReadOnly = true;
            this.nroparcela.Width = 50;
            // 
            // nomefornecedor
            // 
            this.nomefornecedor.DataPropertyName = "nomefornecedor";
            this.nomefornecedor.HeaderText = "Fornecedor";
            this.nomefornecedor.Name = "nomefornecedor";
            this.nomefornecedor.ReadOnly = true;
            this.nomefornecedor.Width = 300;
            // 
            // datapagamento
            // 
            this.datapagamento.DataPropertyName = "datapagamento";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.datapagamento.DefaultCellStyle = dataGridViewCellStyle2;
            this.datapagamento.HeaderText = "Data Baixa";
            this.datapagamento.Name = "datapagamento";
            this.datapagamento.ReadOnly = true;
            // 
            // valordocumento
            // 
            this.valordocumento.DataPropertyName = "valorbaixa";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.valordocumento.DefaultCellStyle = dataGridViewCellStyle3;
            this.valordocumento.HeaderText = "Valor";
            this.valordocumento.Name = "valordocumento";
            this.valordocumento.ReadOnly = true;
            // 
            // sdoamortizacao
            // 
            this.sdoamortizacao.DataPropertyName = "sdoamortizacao";
            this.sdoamortizacao.HeaderText = "Valor a Compensar";
            this.sdoamortizacao.Name = "sdoamortizacao";
            this.sdoamortizacao.ReadOnly = true;
            // 
            // psqAdReceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 376);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqCtaReceber);
            this.Name = "psqAdReceber";
            this.Text = "Contas a Receber - Adiantamentos a Compensar";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqCtaReceber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqCtaReceber;
        private System.Windows.Forms.DataGridViewTextBoxColumn idpagarbaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroparcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomefornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn datapagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn valordocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdoamortizacao;
    }
}