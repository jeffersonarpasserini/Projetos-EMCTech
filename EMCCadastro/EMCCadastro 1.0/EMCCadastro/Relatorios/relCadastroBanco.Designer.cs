namespace EMCCadastro.Relatorios
{
    partial class relCadastroBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCadastroBanco));
            this.dstCadastroBanco = new System.Data.DataSet();
            this.MyTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.report1 = new FastReport.Report();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboOrdenar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dstCadastroBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(217, 68);
            // 
            // dstCadastroBanco
            // 
            this.dstCadastroBanco.DataSetName = "dstCadastroBanco";
            this.dstCadastroBanco.Tables.AddRange(new System.Data.DataTable[] {
            this.MyTable});
            // 
            // MyTable
            // 
            this.MyTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.MyTable.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idBanco";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Descricao";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            this.report1.RegisterData(this.dstCadastroBanco, "dstCadastroBanco");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboOrdenar);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar";
            // 
            // cboOrdenar
            // 
            this.cboOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenar.FormattingEnabled = true;
            this.cboOrdenar.Location = new System.Drawing.Point(7, 25);
            this.cboOrdenar.Name = "cboOrdenar";
            this.cboOrdenar.Size = new System.Drawing.Size(204, 21);
            this.cboOrdenar.TabIndex = 5;
            // 
            // relCadastroBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 148);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "relCadastroBanco";
            this.Text = "Rel.Cadastro de Bancos";
            this.Load += new System.EventHandler(this.relCadastroBanco_Load);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dstCadastroBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet dstCadastroBanco;
        private System.Data.DataTable MyTable;
        private FastReport.Report report1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboOrdenar;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
    }
}