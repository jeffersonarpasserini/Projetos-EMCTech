namespace EMCCadastro.Relatorios
   {
   partial class relCustoComponente
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCustoComponente));
             this.groupBox3 = new System.Windows.Forms.GroupBox();
             this.cboOrdenarIndice = new System.Windows.Forms.ComboBox();
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.lstComponente = new System.Windows.Forms.CheckedListBox();
             this.dstCustoComponente = new System.Data.DataSet();
             this.dataTable1 = new System.Data.DataTable();
             this.dataColumn1 = new System.Data.DataColumn();
             this.dataColumn2 = new System.Data.DataColumn();
             this.dataColumn3 = new System.Data.DataColumn();
             this.dataColumn4 = new System.Data.DataColumn();
             this.dataColumn5 = new System.Data.DataColumn();
             this.report1 = new FastReport.Report();
             this.groupBox3.SuspendLayout();
             this.groupBox1.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstCustoComponente)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Size = new System.Drawing.Size(361, 68);
             // 
             // groupBox3
             // 
             this.groupBox3.Controls.Add(this.cboOrdenarIndice);
             this.groupBox3.ForeColor = System.Drawing.Color.Blue;
             this.groupBox3.Location = new System.Drawing.Point(7, 81);
             this.groupBox3.Name = "groupBox3";
             this.groupBox3.Size = new System.Drawing.Size(167, 61);
             this.groupBox3.TabIndex = 7;
             this.groupBox3.TabStop = false;
             this.groupBox3.Text = "Ordenar";
             // 
             // cboOrdenarIndice
             // 
             this.cboOrdenarIndice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboOrdenarIndice.FormattingEnabled = true;
             this.cboOrdenarIndice.Location = new System.Drawing.Point(7, 26);
             this.cboOrdenarIndice.Name = "cboOrdenarIndice";
             this.cboOrdenarIndice.Size = new System.Drawing.Size(150, 21);
             this.cboOrdenarIndice.TabIndex = 4;
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.lstComponente);
             this.groupBox1.ForeColor = System.Drawing.Color.Blue;
             this.groupBox1.Location = new System.Drawing.Point(180, 81);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(188, 178);
             this.groupBox1.TabIndex = 8;
             this.groupBox1.TabStop = false;
             this.groupBox1.Text = "Grupos de Componentes a Emitir";
             // 
             // lstComponente
             // 
             this.lstComponente.CheckOnClick = true;
             this.lstComponente.FormattingEnabled = true;
             this.lstComponente.Location = new System.Drawing.Point(12, 24);
             this.lstComponente.Name = "lstComponente";
             this.lstComponente.Size = new System.Drawing.Size(164, 139);
             this.lstComponente.TabIndex = 7;
             // 
             // dstCustoComponente
             // 
             this.dstCustoComponente.DataSetName = "NewDataSet";
             this.dstCustoComponente.Tables.AddRange(new System.Data.DataTable[] {
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
             this.dataColumn1.ColumnName = "IdCusto_Componente";
             this.dataColumn1.DataType = typeof(double);
             // 
             // dataColumn2
             // 
             this.dataColumn2.ColumnName = "DescrComponente";
             // 
             // dataColumn3
             // 
             this.dataColumn3.ColumnName = "IdCusto_ComponenteGrupo";
             this.dataColumn3.DataType = typeof(double);
             // 
             // dataColumn4
             // 
             this.dataColumn4.ColumnName = "DescrGrupo";
             // 
             // dataColumn5
             // 
             this.dataColumn5.ColumnName = "Grupo1";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dstCustoComponente, "dstCustoComponente");
             // 
             // relCustoComponente
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(374, 266);
             this.Controls.Add(this.groupBox3);
             this.Controls.Add(this.groupBox1);
             this.MaximizeBox = false;
             this.Name = "relCustoComponente";
             this.Text = "Rel. Componente Custo";
             this.Load += new System.EventHandler(this.relCustoComponente_Load);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.Controls.SetChildIndex(this.groupBox1, 0);
             this.Controls.SetChildIndex(this.groupBox3, 0);
             this.groupBox3.ResumeLayout(false);
             this.groupBox1.ResumeLayout(false);
             ((System.ComponentModel.ISupportInitialize)(this.dstCustoComponente)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox cboOrdenarIndice;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckedListBox lstComponente;
      private System.Data.DataSet dstCustoComponente;
      private System.Data.DataTable dataTable1;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private System.Data.DataColumn dataColumn5;
      private FastReport.Report report1;
      }
   }