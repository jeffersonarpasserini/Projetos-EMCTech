namespace EMCObras.Relatorios
{
    partial class relObraEtapa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relObraEtapa));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboOrdenar = new System.Windows.Forms.ComboBox();
            this.dstEtapas = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.etapas = new FastReport.Report();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstEtapas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etapas)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Location = new System.Drawing.Point(3, 2);
            this.panBotoes.Size = new System.Drawing.Size(237, 68);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboOrdenar);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(5, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar";
            // 
            // cboOrdenar
            // 
            this.cboOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenar.FormattingEnabled = true;
            this.cboOrdenar.Location = new System.Drawing.Point(7, 25);
            this.cboOrdenar.Name = "cboOrdenar";
            this.cboOrdenar.Size = new System.Drawing.Size(215, 21);
            this.cboOrdenar.TabIndex = 1;
            // 
            // dstEtapas
            // 
            this.dstEtapas.DataSetName = "NewDataSet";
            this.dstEtapas.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "idobra_etapa";
            this.dataColumn1.DataType = typeof(long);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "descricao";
            // 
            // etapas
            // 
            this.etapas.ReportResourceString = resources.GetString("etapas.ReportResourceString");
            this.etapas.RegisterData(this.dstEtapas, "dstEtapas");
            // 
            // relObraEtapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(242, 165);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "relObraEtapa";
            this.Text = "Relatório - Etapas";
            this.Load += new System.EventHandler(this.relObraEtapa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.relObraEtapa_KeyDown);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dstEtapas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etapas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboOrdenar;
        private System.Data.DataSet dstEtapas;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private FastReport.Report etapas;
    }
}
