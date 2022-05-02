namespace EMCCadastro.Relatorios
   {
   partial class relCEP
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCEP));
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.cboOrdenar = new System.Windows.Forms.ComboBox();
             this.dstCEP = new System.Data.DataSet();
             this.dataTable1 = new System.Data.DataTable();
             this.dataColumn1 = new System.Data.DataColumn();
             this.dataColumn2 = new System.Data.DataColumn();
             this.dataColumn3 = new System.Data.DataColumn();
             this.dataColumn4 = new System.Data.DataColumn();
             this.dataColumn5 = new System.Data.DataColumn();
             this.report1 = new FastReport.Report();
             this.groupBox1.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstCEP)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Size = new System.Drawing.Size(217, 68);
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.cboOrdenar);
             this.groupBox1.ForeColor = System.Drawing.Color.Blue;
             this.groupBox1.Location = new System.Drawing.Point(7, 81);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(217, 62);
             this.groupBox1.TabIndex = 0;
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
             this.cboOrdenar.TabIndex = 1;
             // 
             // dstCEP
             // 
             this.dstCEP.DataSetName = "dstCEP";
             this.dstCEP.Tables.AddRange(new System.Data.DataTable[] {
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
             this.dataColumn1.ColumnName = "IdCEP";
             this.dataColumn1.DataType = typeof(double);
             // 
             // dataColumn2
             // 
             this.dataColumn2.ColumnName = "Cidade";
             // 
             // dataColumn3
             // 
             this.dataColumn3.ColumnName = "Bairro";
             // 
             // dataColumn4
             // 
             this.dataColumn4.ColumnName = "Estado";
             // 
             // dataColumn5
             // 
             this.dataColumn5.ColumnName = "Grupo1";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dstCEP, "dstCEP");
             // 
             // relCEP
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(231, 150);
             this.Controls.Add(this.groupBox1);
             this.MaximizeBox = false;
             this.Name = "relCEP";
             this.Text = "Rel. CEP/Cidade";
             this.Load += new System.EventHandler(this.relCEP_Load);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.Controls.SetChildIndex(this.groupBox1, 0);
             this.groupBox1.ResumeLayout(false);
             ((System.ComponentModel.ISupportInitialize)(this.dstCEP)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox cboOrdenar;
      private System.Data.DataSet dstCEP;
      private System.Data.DataTable dataTable1;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private System.Data.DataColumn dataColumn5;
      private FastReport.Report report1;
      }
   }