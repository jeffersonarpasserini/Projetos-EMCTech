namespace EMCCadastro.Relatorios
{
    partial class relContaCusto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relContaCusto));
            this.cboOrdenar1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboOrdenar2 = new System.Windows.Forms.ComboBox();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.report1 = new FastReport.Report();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(221, 68);
            // 
            // cboOrdenar1
            // 
            this.cboOrdenar1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenar1.FormattingEnabled = true;
            this.cboOrdenar1.Location = new System.Drawing.Point(7, 26);
            this.cboOrdenar1.Name = "cboOrdenar1";
            this.cboOrdenar1.Size = new System.Drawing.Size(150, 21);
            this.cboOrdenar1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboOrdenar2);
            this.groupBox3.Controls.Add(this.cboOrdenar1);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(30, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 92);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenar";
            // 
            // cboOrdenar2
            // 
            this.cboOrdenar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenar2.FormattingEnabled = true;
            this.cboOrdenar2.Location = new System.Drawing.Point(7, 63);
            this.cboOrdenar2.Name = "cboOrdenar2";
            this.cboOrdenar2.Size = new System.Drawing.Size(150, 21);
            this.cboOrdenar2.TabIndex = 2;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "MyTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "codigoconta";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "tipoconta";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "descricao";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Matriz";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "razaosocial";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            this.report1.RegisterData(this.dataSet1, "dataSet1");
            // 
            // relContaCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 192);
            this.Controls.Add(this.groupBox3);
            this.MinimizeBox = false;
            this.Name = "relContaCusto";
            this.Text = "Relação Conta Custos";
            this.Load += new System.EventHandler(this.relContaCusto_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboOrdenar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboOrdenar2;
        private System.Data.DataSet dataSet1;
        private FastReport.Report report1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
    }
}