namespace EMCEstoque
{
    partial class relProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relProdutos));
            this.dstProdutos = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCodigoProduto = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.btnProduto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtidEstq_TipoProduto = new System.Windows.Forms.TextBox();
            this.txtTipoProduto = new System.Windows.Forms.TextBox();
            this.btnTipoProduto = new System.Windows.Forms.Button();
            this.produto = new FastReport.Report();
            this.produtos = new FastReport.Report();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtidEstq_Grupo = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.btnGrupo = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtidEstq_SubGrupo = new System.Windows.Forms.TextBox();
            this.txtSubGrupo = new System.Windows.Forms.TextBox();
            this.btnSubgrupo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dstProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(519, 68);
            // 
            // dstProdutos
            // 
            this.dstProdutos.DataSetName = "NewDataSet";
            this.dstProdutos.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "codigoproduto";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "descricaodetalhada";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "codigoEAN";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "situacao";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "qtde_estoqueminimo";
            this.dataColumn5.DataType = typeof(long);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "qtde_estoquemaxima";
            this.dataColumn6.DataType = typeof(long);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "descricaosubgrupo";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "descricaocustocomponente";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "descricaocomponentegrupo";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "unidadeproduto";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "descricaofamilia";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "tributacao";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "tipoproduto";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "precovendaprazo";
            this.dataColumn14.DataType = typeof(decimal);
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "precovendavista";
            this.dataColumn15.DataType = typeof(decimal);
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "descricaogrupo";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "ncm";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCodigoProduto);
            this.groupBox4.Controls.Add(this.txtProduto);
            this.groupBox4.Controls.Add(this.btnProduto);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(7, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(519, 47);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Produto";
            // 
            // txtCodigoProduto
            // 
            this.txtCodigoProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoProduto.Location = new System.Drawing.Point(7, 18);
            this.txtCodigoProduto.MaxLength = 20;
            this.txtCodigoProduto.Name = "txtCodigoProduto";
            this.txtCodigoProduto.Size = new System.Drawing.Size(136, 20);
            this.txtCodigoProduto.TabIndex = 42;
            this.txtCodigoProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoProduto_Validating);
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(175, 18);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.Size = new System.Drawing.Size(333, 20);
            this.txtProduto.TabIndex = 44;
            // 
            // btnProduto
            // 
            this.btnProduto.Image = global::EMCEstoque.Properties.Resources.binoculo_16x16;
            this.btnProduto.Location = new System.Drawing.Point(145, 17);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(29, 22);
            this.btnProduto.TabIndex = 43;
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtidEstq_TipoProduto);
            this.groupBox1.Controls.Add(this.txtTipoProduto);
            this.groupBox1.Controls.Add(this.btnTipoProduto);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 47);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Produto";
            // 
            // txtidEstq_TipoProduto
            // 
            this.txtidEstq_TipoProduto.Location = new System.Drawing.Point(6, 17);
            this.txtidEstq_TipoProduto.Name = "txtidEstq_TipoProduto";
            this.txtidEstq_TipoProduto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_TipoProduto.Size = new System.Drawing.Size(56, 20);
            this.txtidEstq_TipoProduto.TabIndex = 42;
            this.txtidEstq_TipoProduto.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_TipoProduto_Validating);
            // 
            // txtTipoProduto
            // 
            this.txtTipoProduto.Location = new System.Drawing.Point(94, 17);
            this.txtTipoProduto.Name = "txtTipoProduto";
            this.txtTipoProduto.ReadOnly = true;
            this.txtTipoProduto.Size = new System.Drawing.Size(415, 20);
            this.txtTipoProduto.TabIndex = 44;
            // 
            // btnTipoProduto
            // 
            this.btnTipoProduto.Image = global::EMCEstoque.Properties.Resources.binoculo_16x16;
            this.btnTipoProduto.Location = new System.Drawing.Point(64, 16);
            this.btnTipoProduto.Name = "btnTipoProduto";
            this.btnTipoProduto.Size = new System.Drawing.Size(29, 22);
            this.btnTipoProduto.TabIndex = 43;
            this.btnTipoProduto.UseVisualStyleBackColor = true;
            this.btnTipoProduto.Click += new System.EventHandler(this.btnTipoProduto_Click);
            // 
            // produto
            // 
            this.produto.ReportResourceString = resources.GetString("produto.ReportResourceString");
            this.produto.RegisterData(this.dstProdutos, "dstProdutos");
            // 
            // produtos
            // 
            this.produtos.ReportResourceString = resources.GetString("produtos.ReportResourceString");
            this.produtos.RegisterData(this.dstProdutos, "dstProdutos");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtidEstq_Grupo);
            this.groupBox5.Controls.Add(this.txtGrupo);
            this.groupBox5.Controls.Add(this.btnGrupo);
            this.groupBox5.ForeColor = System.Drawing.Color.Blue;
            this.groupBox5.Location = new System.Drawing.Point(7, 241);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(519, 47);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Grupo Produto";
            // 
            // txtidEstq_Grupo
            // 
            this.txtidEstq_Grupo.Location = new System.Drawing.Point(6, 17);
            this.txtidEstq_Grupo.Name = "txtidEstq_Grupo";
            this.txtidEstq_Grupo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_Grupo.Size = new System.Drawing.Size(56, 20);
            this.txtidEstq_Grupo.TabIndex = 42;
            this.txtidEstq_Grupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Grupo_Validating);
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(94, 17);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(415, 20);
            this.txtGrupo.TabIndex = 44;
            // 
            // btnGrupo
            // 
            this.btnGrupo.Image = global::EMCEstoque.Properties.Resources.binoculo_16x16;
            this.btnGrupo.Location = new System.Drawing.Point(64, 16);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(29, 22);
            this.btnGrupo.TabIndex = 43;
            this.btnGrupo.UseVisualStyleBackColor = true;
            this.btnGrupo.Click += new System.EventHandler(this.btnGrupo_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtidEstq_SubGrupo);
            this.groupBox6.Controls.Add(this.txtSubGrupo);
            this.groupBox6.Controls.Add(this.btnSubgrupo);
            this.groupBox6.ForeColor = System.Drawing.Color.Blue;
            this.groupBox6.Location = new System.Drawing.Point(7, 187);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(519, 47);
            this.groupBox6.TabIndex = 49;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Subgrupo Produto";
            // 
            // txtidEstq_SubGrupo
            // 
            this.txtidEstq_SubGrupo.Location = new System.Drawing.Point(6, 17);
            this.txtidEstq_SubGrupo.Name = "txtidEstq_SubGrupo";
            this.txtidEstq_SubGrupo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_SubGrupo.Size = new System.Drawing.Size(56, 20);
            this.txtidEstq_SubGrupo.TabIndex = 42;
            this.txtidEstq_SubGrupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_SubGrupo_Validating);
            // 
            // txtSubGrupo
            // 
            this.txtSubGrupo.Location = new System.Drawing.Point(94, 17);
            this.txtSubGrupo.Name = "txtSubGrupo";
            this.txtSubGrupo.ReadOnly = true;
            this.txtSubGrupo.Size = new System.Drawing.Size(415, 20);
            this.txtSubGrupo.TabIndex = 44;
            // 
            // btnSubgrupo
            // 
            this.btnSubgrupo.Image = global::EMCEstoque.Properties.Resources.binoculo_16x16;
            this.btnSubgrupo.Location = new System.Drawing.Point(64, 16);
            this.btnSubgrupo.Name = "btnSubgrupo";
            this.btnSubgrupo.Size = new System.Drawing.Size(29, 22);
            this.btnSubgrupo.TabIndex = 43;
            this.btnSubgrupo.UseVisualStyleBackColor = true;
            this.btnSubgrupo.Click += new System.EventHandler(this.btnSubgrupo_Click);
            // 
            // relProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(529, 297);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.MaximizeBox = false;
            this.Name = "relProdutos";
            this.Text = "Relatório de Produtos";
            this.Load += new System.EventHandler(this.relProdutos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relProdutos_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dstProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dstProdutos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtidEstq_TipoProduto;
        private System.Windows.Forms.TextBox txtTipoProduto;
        private System.Windows.Forms.Button btnTipoProduto;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private System.Windows.Forms.TextBox txtCodigoProduto;
        private FastReport.Report produto;
        private FastReport.Report produtos;
        private System.Data.DataColumn dataColumn16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtidEstq_Grupo;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Button btnGrupo;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtidEstq_SubGrupo;
        private System.Windows.Forms.TextBox txtSubGrupo;
        private System.Windows.Forms.Button btnSubgrupo;
        private System.Data.DataColumn dataColumn17;

    }
}
