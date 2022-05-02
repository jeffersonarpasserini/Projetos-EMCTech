namespace EMCFinanceiro
{
    partial class frmReceberEditaParcelaBaixa
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
            this.txtValorParcela = new MaskedNumber.MaskedNumber();
            this.txtJuros = new MaskedNumber.MaskedNumber();
            this.txtDesconto = new MaskedNumber.MaskedNumber();
            this.txtValorTotal = new MaskedNumber.MaskedNumber();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroParcela = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtTaxaMulta = new MaskedNumber.MaskedNumber();
            this.txtTaxaJuros = new MaskedNumber.MaskedNumber();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtValorPagar = new MaskedNumber.MaskedNumber();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJurosRecalculo = new MaskedNumber.MaskedNumber();
            this.txtDescontoRecalculo = new MaskedNumber.MaskedNumber();
            this.txtValorPagarRecalculo = new MaskedNumber.MaskedNumber();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMultaRecalculo = new MaskedNumber.MaskedNumber();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDataVencimento = new MaskedDateEntryControl.MaskedDateTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDataVencimento);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtValorParcela);
            this.panel1.Controls.Add(this.txtJuros);
            this.panel1.Controls.Add(this.txtDesconto);
            this.panel1.Controls.Add(this.txtValorTotal);
            this.panel1.Controls.Add(this.txtNominal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNroParcela);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(4, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 244);
            this.panel1.TabIndex = 18;
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.CustomFormat = "0:0";
            this.txtValorParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorParcela.Format = MaskedNumberFormat.Moeda;
            this.txtValorParcela.Location = new System.Drawing.Point(14, 64);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.ReadOnly = true;
            this.txtValorParcela.Size = new System.Drawing.Size(130, 20);
            this.txtValorParcela.TabIndex = 104;
            this.txtValorParcela.Text = "R$ 0,00";
            this.txtValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtJuros
            // 
            this.txtJuros.CustomFormat = "0:0";
            this.txtJuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtJuros.Format = MaskedNumberFormat.Moeda;
            this.txtJuros.Location = new System.Drawing.Point(13, 101);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.ReadOnly = true;
            this.txtJuros.Size = new System.Drawing.Size(130, 20);
            this.txtJuros.TabIndex = 102;
            this.txtJuros.Text = "R$ 0,00";
            this.txtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDesconto
            // 
            this.txtDesconto.CustomFormat = "0:0";
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDesconto.Format = MaskedNumberFormat.Moeda;
            this.txtDesconto.Location = new System.Drawing.Point(12, 137);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ReadOnly = true;
            this.txtDesconto.Size = new System.Drawing.Size(130, 20);
            this.txtDesconto.TabIndex = 101;
            this.txtDesconto.Text = "R$ 0,00";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.CustomFormat = "0:0";
            this.txtValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorTotal.Format = MaskedNumberFormat.Moeda;
            this.txtValorTotal.Location = new System.Drawing.Point(12, 175);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.ReadOnly = true;
            this.txtValorTotal.Size = new System.Drawing.Size(130, 20);
            this.txtValorTotal.TabIndex = 100;
            this.txtValorTotal.Text = "R$ 0,00";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNominal
            // 
            this.txtNominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNominal.Location = new System.Drawing.Point(12, 218);
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(282, 20);
            this.txtNominal.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Nominal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Valor Final Pagar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Juros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Desconto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Parc";
            // 
            // txtNroParcela
            // 
            this.txtNroParcela.Location = new System.Drawing.Point(10, 26);
            this.txtNroParcela.Name = "txtNroParcela";
            this.txtNroParcela.ReadOnly = true;
            this.txtNroParcela.Size = new System.Drawing.Size(33, 20);
            this.txtNroParcela.TabIndex = 98;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Valor Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Vencimento";
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCFinanceiro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(79, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 17;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::EMCFinanceiro.Properties.Resources.ImgSalvar;
            this.btnSalvar.Location = new System.Drawing.Point(5, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(68, 58);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(238, 25);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(54, 13);
            this.label34.TabIndex = 48;
            this.label34.Text = "Txa Multa";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(173, 25);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 47;
            this.label33.Text = "Txa Juros";
            // 
            // txtTaxaMulta
            // 
            this.txtTaxaMulta.CustomFormat = "0:0";
            this.txtTaxaMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTaxaMulta.Format = MaskedNumberFormat.Porcentagem;
            this.txtTaxaMulta.Location = new System.Drawing.Point(241, 40);
            this.txtTaxaMulta.Name = "txtTaxaMulta";
            this.txtTaxaMulta.ReadOnly = true;
            this.txtTaxaMulta.Size = new System.Drawing.Size(64, 20);
            this.txtTaxaMulta.TabIndex = 46;
            this.txtTaxaMulta.Text = "0,0000%";
            this.txtTaxaMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTaxaJuros
            // 
            this.txtTaxaJuros.CustomFormat = "0:0";
            this.txtTaxaJuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTaxaJuros.Format = MaskedNumberFormat.Porcentagem;
            this.txtTaxaJuros.Location = new System.Drawing.Point(176, 40);
            this.txtTaxaJuros.Name = "txtTaxaJuros";
            this.txtTaxaJuros.ReadOnly = true;
            this.txtTaxaJuros.Size = new System.Drawing.Size(64, 20);
            this.txtTaxaJuros.TabIndex = 45;
            this.txtTaxaJuros.Text = "0,0000%";
            this.txtTaxaJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtMultaRecalculo);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtJurosRecalculo);
            this.panel2.Controls.Add(this.txtDescontoRecalculo);
            this.panel2.Controls.Add(this.txtValorPagarRecalculo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtValorPagar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(148, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 202);
            this.panel2.TabIndex = 105;
            // 
            // txtValorPagar
            // 
            this.txtValorPagar.CustomFormat = "0:0";
            this.txtValorPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorPagar.Format = MaskedNumberFormat.Moeda;
            this.txtValorPagar.Location = new System.Drawing.Point(5, 29);
            this.txtValorPagar.Name = "txtValorPagar";
            this.txtValorPagar.Size = new System.Drawing.Size(130, 20);
            this.txtValorPagar.TabIndex = 105;
            this.txtValorPagar.Text = "R$ 0,00";
            this.txtValorPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPagar.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorPagar_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "Valor Documento Pagar";
            // 
            // txtJurosRecalculo
            // 
            this.txtJurosRecalculo.CustomFormat = "0:0";
            this.txtJurosRecalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtJurosRecalculo.Format = MaskedNumberFormat.Moeda;
            this.txtJurosRecalculo.Location = new System.Drawing.Point(6, 101);
            this.txtJurosRecalculo.Name = "txtJurosRecalculo";
            this.txtJurosRecalculo.ReadOnly = true;
            this.txtJurosRecalculo.Size = new System.Drawing.Size(130, 20);
            this.txtJurosRecalculo.TabIndex = 111;
            this.txtJurosRecalculo.Text = "R$ 0,00";
            this.txtJurosRecalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescontoRecalculo
            // 
            this.txtDescontoRecalculo.CustomFormat = "0:0";
            this.txtDescontoRecalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDescontoRecalculo.Format = MaskedNumberFormat.Moeda;
            this.txtDescontoRecalculo.Location = new System.Drawing.Point(6, 137);
            this.txtDescontoRecalculo.Name = "txtDescontoRecalculo";
            this.txtDescontoRecalculo.ReadOnly = true;
            this.txtDescontoRecalculo.Size = new System.Drawing.Size(130, 20);
            this.txtDescontoRecalculo.TabIndex = 110;
            this.txtDescontoRecalculo.Text = "R$ 0,00";
            this.txtDescontoRecalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtValorPagarRecalculo
            // 
            this.txtValorPagarRecalculo.CustomFormat = "0:0";
            this.txtValorPagarRecalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtValorPagarRecalculo.Format = MaskedNumberFormat.Moeda;
            this.txtValorPagarRecalculo.Location = new System.Drawing.Point(6, 175);
            this.txtValorPagarRecalculo.Name = "txtValorPagarRecalculo";
            this.txtValorPagarRecalculo.ReadOnly = true;
            this.txtValorPagarRecalculo.Size = new System.Drawing.Size(130, 20);
            this.txtValorPagarRecalculo.TabIndex = 109;
            this.txtValorPagarRecalculo.Text = "R$ 0,00";
            this.txtValorPagarRecalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 108;
            this.label8.Text = "Valor Final Pagar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 107;
            this.label9.Text = "Juros";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 106;
            this.label10.Text = "Desconto";
            // 
            // txtMultaRecalculo
            // 
            this.txtMultaRecalculo.CustomFormat = "0:0";
            this.txtMultaRecalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMultaRecalculo.Format = MaskedNumberFormat.Moeda;
            this.txtMultaRecalculo.Location = new System.Drawing.Point(5, 66);
            this.txtMultaRecalculo.Name = "txtMultaRecalculo";
            this.txtMultaRecalculo.ReadOnly = true;
            this.txtMultaRecalculo.Size = new System.Drawing.Size(130, 20);
            this.txtMultaRecalculo.TabIndex = 113;
            this.txtMultaRecalculo.Text = "R$ 0,00";
            this.txtMultaRecalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 112;
            this.label11.Text = "Multa";
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.DateValue = null;
            this.txtDataVencimento.Location = new System.Drawing.Point(46, 26);
            this.txtDataVencimento.Mask = "00/00/0000";
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.ReadOnly = true;
            this.txtDataVencimento.RequireValidEntry = true;
            this.txtDataVencimento.Size = new System.Drawing.Size(85, 20);
            this.txtDataVencimento.TabIndex = 106;
            // 
            // frmReceberEditaParcelaBaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 312);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtTaxaMulta);
            this.Controls.Add(this.txtTaxaJuros);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSalvar);
            this.Name = "frmReceberEditaParcelaBaixa";
            this.Text = "Parcelamento";
            this.Load += new System.EventHandler(this.frmEditaParcelasPagar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNominal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroParcela;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private MaskedNumber.MaskedNumber txtTaxaMulta;
        private MaskedNumber.MaskedNumber txtTaxaJuros;
        private MaskedNumber.MaskedNumber txtValorTotal;
        private MaskedNumber.MaskedNumber txtDesconto;
        private MaskedNumber.MaskedNumber txtJuros;
        private MaskedNumber.MaskedNumber txtValorParcela;
        private System.Windows.Forms.Panel panel2;
        private MaskedNumber.MaskedNumber txtJurosRecalculo;
        private MaskedNumber.MaskedNumber txtDescontoRecalculo;
        private MaskedNumber.MaskedNumber txtValorPagarRecalculo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private MaskedNumber.MaskedNumber txtValorPagar;
        private System.Windows.Forms.Label label3;
        private MaskedNumber.MaskedNumber txtMultaRecalculo;
        private System.Windows.Forms.Label label11;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataVencimento;
    }
}