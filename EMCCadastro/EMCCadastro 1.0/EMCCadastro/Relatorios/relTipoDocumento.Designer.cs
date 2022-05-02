namespace EMCCadastro.Relatorios
   {
   partial class relTipoDocumento
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relTipoDocumento));
             this.groupBox2 = new System.Windows.Forms.GroupBox();
             this.cboOrdenar = new System.Windows.Forms.ComboBox();
             this.dstTipoDocumento = new System.Data.DataSet();
             this.dataTable1 = new System.Data.DataTable();
             this.dataColumn1 = new System.Data.DataColumn();
             this.dataColumn2 = new System.Data.DataColumn();
             this.report1 = new FastReport.Report();
             this.groupBox2.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstTipoDocumento)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Size = new System.Drawing.Size(220, 68);
             // 
             // groupBox2
             // 
             this.groupBox2.Controls.Add(this.cboOrdenar);
             this.groupBox2.ForeColor = System.Drawing.Color.Blue;
             this.groupBox2.Location = new System.Drawing.Point(7, 81);
             this.groupBox2.Name = "groupBox2";
             this.groupBox2.Size = new System.Drawing.Size(220, 51);
             this.groupBox2.TabIndex = 0;
             this.groupBox2.TabStop = false;
             this.groupBox2.Text = "Ordenar";
             // 
             // cboOrdenar
             // 
             this.cboOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboOrdenar.FormattingEnabled = true;
             this.cboOrdenar.Location = new System.Drawing.Point(7, 20);
             this.cboOrdenar.Name = "cboOrdenar";
             this.cboOrdenar.Size = new System.Drawing.Size(204, 21);
             this.cboOrdenar.TabIndex = 1;
             // 
             // dstTipoDocumento
             // 
             this.dstTipoDocumento.DataSetName = "NewDataSet";
             this.dstTipoDocumento.Tables.AddRange(new System.Data.DataTable[] {
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
             this.dataColumn1.ColumnName = "IdTipoDocumento";
             this.dataColumn1.DataType = typeof(double);
             // 
             // dataColumn2
             // 
             this.dataColumn2.ColumnName = "Descricao";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dstTipoDocumento, "dstTipoDocumento");
             // 
             // relTipoDocumento
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(231, 138);
             this.Controls.Add(this.groupBox2);
             this.MinimizeBox = false;
             this.Name = "relTipoDocumento";
             this.Text = "Rel. Tipo Documento";
             this.Load += new System.EventHandler(this.relTipoDocumento_Load);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.Controls.SetChildIndex(this.groupBox2, 0);
             this.groupBox2.ResumeLayout(false);
             ((System.ComponentModel.ISupportInitialize)(this.dstTipoDocumento)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox cboOrdenar;
      private System.Data.DataSet dstTipoDocumento;
      private System.Data.DataTable dataTable1;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private FastReport.Report report1;
      }
   }