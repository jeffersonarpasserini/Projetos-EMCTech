namespace EMCCadastro.Relatorios
   {
   partial class relFeriado
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relFeriado));
             this.groupBox3 = new System.Windows.Forms.GroupBox();
             this.cboOrdenar = new System.Windows.Forms.ComboBox();
             this.groupBox2 = new System.Windows.Forms.GroupBox();
             this.label1 = new System.Windows.Forms.Label();
             this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
             this.label2 = new System.Windows.Forms.Label();
             this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
             this.dstFeriado = new System.Data.DataSet();
             this.dataTable1 = new System.Data.DataTable();
             this.dataColumn1 = new System.Data.DataColumn();
             this.dataColumn2 = new System.Data.DataColumn();
             this.dataColumn3 = new System.Data.DataColumn();
             this.dataColumn4 = new System.Data.DataColumn();
             this.report1 = new FastReport.Report();
             this.groupBox3.SuspendLayout();
             this.groupBox2.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstFeriado)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Location = new System.Drawing.Point(14, 7);
             this.panBotoes.Size = new System.Drawing.Size(217, 68);
             // 
             // groupBox3
             // 
             this.groupBox3.Controls.Add(this.cboOrdenar);
             this.groupBox3.ForeColor = System.Drawing.Color.Blue;
             this.groupBox3.Location = new System.Drawing.Point(7, 156);
             this.groupBox3.Name = "groupBox3";
             this.groupBox3.Size = new System.Drawing.Size(239, 53);
             this.groupBox3.TabIndex = 3;
             this.groupBox3.TabStop = false;
             this.groupBox3.Text = "Ordenar";
             // 
             // cboOrdenar
             // 
             this.cboOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboOrdenar.FormattingEnabled = true;
             this.cboOrdenar.Location = new System.Drawing.Point(7, 21);
             this.cboOrdenar.Name = "cboOrdenar";
             this.cboOrdenar.Size = new System.Drawing.Size(219, 21);
             this.cboOrdenar.TabIndex = 4;
             // 
             // groupBox2
             // 
             this.groupBox2.Controls.Add(this.label1);
             this.groupBox2.Controls.Add(this.txtDtaFinal);
             this.groupBox2.Controls.Add(this.label2);
             this.groupBox2.Controls.Add(this.txtDtaInicial);
             this.groupBox2.ForeColor = System.Drawing.Color.Blue;
             this.groupBox2.Location = new System.Drawing.Point(7, 81);
             this.groupBox2.Name = "groupBox2";
             this.groupBox2.Size = new System.Drawing.Size(239, 69);
             this.groupBox2.TabIndex = 0;
             this.groupBox2.TabStop = false;
             this.groupBox2.Text = "Período a Emitir";
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.ForeColor = System.Drawing.Color.Black;
             this.label1.Location = new System.Drawing.Point(124, 20);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(23, 13);
             this.label1.TabIndex = 101;
             this.label1.Text = "Até";
             // 
             // txtDtaFinal
             // 
             this.txtDtaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
             this.txtDtaFinal.Location = new System.Drawing.Point(127, 35);
             this.txtDtaFinal.Name = "txtDtaFinal";
             this.txtDtaFinal.Size = new System.Drawing.Size(99, 20);
             this.txtDtaFinal.TabIndex = 2;
             // 
             // label2
             // 
             this.label2.AutoSize = true;
             this.label2.ForeColor = System.Drawing.Color.Black;
             this.label2.Location = new System.Drawing.Point(4, 20);
             this.label2.Name = "label2";
             this.label2.Size = new System.Drawing.Size(21, 13);
             this.label2.TabIndex = 100;
             this.label2.Text = "De";
             // 
             // txtDtaInicial
             // 
             this.txtDtaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
             this.txtDtaInicial.Location = new System.Drawing.Point(7, 35);
             this.txtDtaInicial.Name = "txtDtaInicial";
             this.txtDtaInicial.Size = new System.Drawing.Size(99, 20);
             this.txtDtaInicial.TabIndex = 1;
             // 
             // dstFeriado
             // 
             this.dstFeriado.DataSetName = "NewDataSet";
             this.dstFeriado.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
             // 
             // dataTable1
             // 
             this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
             this.dataTable1.TableName = "MyTable";
             // 
             // dataColumn1
             // 
             this.dataColumn1.ColumnName = "IdFeriados";
             this.dataColumn1.DataType = typeof(double);
             // 
             // dataColumn2
             // 
             this.dataColumn2.ColumnName = "DataFeriado";
             this.dataColumn2.DataType = typeof(System.DateTime);
             // 
             // dataColumn3
             // 
             this.dataColumn3.ColumnName = "Descricao";
             // 
             // dataColumn4
             // 
             this.dataColumn4.ColumnName = "Grupo1";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dstFeriado, "dstFeriado");
             // 
             // relFeriado
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(248, 216);
             this.Controls.Add(this.groupBox3);
             this.Controls.Add(this.groupBox2);
             this.MaximizeBox = false;
             this.Name = "relFeriado";
             this.Text = "Relação de Feriados";
             this.Load += new System.EventHandler(this.relFeriado_Load);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.Controls.SetChildIndex(this.groupBox2, 0);
             this.Controls.SetChildIndex(this.groupBox3, 0);
             this.groupBox3.ResumeLayout(false);
             this.groupBox2.ResumeLayout(false);
             this.groupBox2.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstFeriado)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox cboOrdenar;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker txtDtaFinal;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DateTimePicker txtDtaInicial;
      private System.Data.DataSet dstFeriado;
      private System.Data.DataTable dataTable1;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private FastReport.Report report1;
      private System.Data.DataColumn dataColumn4;
      }
   }