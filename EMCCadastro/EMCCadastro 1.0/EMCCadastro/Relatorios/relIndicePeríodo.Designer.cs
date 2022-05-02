namespace EMCCadastro.Relatorios
   {
   partial class relIndicePeríodo
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relIndicePeríodo));
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.lstIndice = new System.Windows.Forms.CheckedListBox();
             this.groupBox2 = new System.Windows.Forms.GroupBox();
             this.label1 = new System.Windows.Forms.Label();
             this.txtDtaFinal = new System.Windows.Forms.DateTimePicker();
             this.label2 = new System.Windows.Forms.Label();
             this.txtDtaInicial = new System.Windows.Forms.DateTimePicker();
             this.groupBox3 = new System.Windows.Forms.GroupBox();
             this.label4 = new System.Windows.Forms.Label();
             this.cboOrdenarPeriodo = new System.Windows.Forms.ComboBox();
             this.label3 = new System.Windows.Forms.Label();
             this.cboOrdenarIndice = new System.Windows.Forms.ComboBox();
             this.dstIndice = new System.Data.DataSet();
             this.dataTable1 = new System.Data.DataTable();
             this.dataColumn3 = new System.Data.DataColumn();
             this.dataColumn4 = new System.Data.DataColumn();
             this.dataColumn5 = new System.Data.DataColumn();
             this.dataColumn6 = new System.Data.DataColumn();
             this.report1 = new FastReport.Report();
             this.groupBox1.SuspendLayout();
             this.groupBox2.SuspendLayout();
             this.groupBox3.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstIndice)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Size = new System.Drawing.Size(435, 68);
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.lstIndice);
             this.groupBox1.ForeColor = System.Drawing.Color.Blue;
             this.groupBox1.Location = new System.Drawing.Point(254, 81);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(188, 178);
             this.groupBox1.TabIndex = 6;
             this.groupBox1.TabStop = false;
             this.groupBox1.Text = "Índices a Emitir";
             // 
             // lstIndice
             // 
             this.lstIndice.CheckOnClick = true;
             this.lstIndice.FormattingEnabled = true;
             this.lstIndice.Location = new System.Drawing.Point(12, 24);
             this.lstIndice.Name = "lstIndice";
             this.lstIndice.Size = new System.Drawing.Size(164, 139);
             this.lstIndice.TabIndex = 7;
             // 
             // groupBox2
             // 
             this.groupBox2.Controls.Add(this.label1);
             this.groupBox2.Controls.Add(this.txtDtaFinal);
             this.groupBox2.Controls.Add(this.label2);
             this.groupBox2.Controls.Add(this.txtDtaInicial);
             this.groupBox2.ForeColor = System.Drawing.Color.Blue;
             this.groupBox2.Location = new System.Drawing.Point(7, 82);
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
             // groupBox3
             // 
             this.groupBox3.Controls.Add(this.label4);
             this.groupBox3.Controls.Add(this.cboOrdenarPeriodo);
             this.groupBox3.Controls.Add(this.label3);
             this.groupBox3.Controls.Add(this.cboOrdenarIndice);
             this.groupBox3.ForeColor = System.Drawing.Color.Blue;
             this.groupBox3.Location = new System.Drawing.Point(7, 157);
             this.groupBox3.Name = "groupBox3";
             this.groupBox3.Size = new System.Drawing.Size(239, 102);
             this.groupBox3.TabIndex = 3;
             this.groupBox3.TabStop = false;
             this.groupBox3.Text = "Ordenar";
             // 
             // label4
             // 
             this.label4.AutoSize = true;
             this.label4.ForeColor = System.Drawing.Color.Black;
             this.label4.Location = new System.Drawing.Point(4, 56);
             this.label4.Name = "label4";
             this.label4.Size = new System.Drawing.Size(45, 13);
             this.label4.TabIndex = 103;
             this.label4.Text = "Período";
             // 
             // cboOrdenarPeriodo
             // 
             this.cboOrdenarPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboOrdenarPeriodo.FormattingEnabled = true;
             this.cboOrdenarPeriodo.Location = new System.Drawing.Point(7, 71);
             this.cboOrdenarPeriodo.Name = "cboOrdenarPeriodo";
             this.cboOrdenarPeriodo.Size = new System.Drawing.Size(219, 21);
             this.cboOrdenarPeriodo.TabIndex = 5;
             // 
             // label3
             // 
             this.label3.AutoSize = true;
             this.label3.ForeColor = System.Drawing.Color.Black;
             this.label3.Location = new System.Drawing.Point(4, 14);
             this.label3.Name = "label3";
             this.label3.Size = new System.Drawing.Size(36, 13);
             this.label3.TabIndex = 102;
             this.label3.Text = "Índice";
             // 
             // cboOrdenarIndice
             // 
             this.cboOrdenarIndice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboOrdenarIndice.FormattingEnabled = true;
             this.cboOrdenarIndice.Location = new System.Drawing.Point(7, 29);
             this.cboOrdenarIndice.Name = "cboOrdenarIndice";
             this.cboOrdenarIndice.Size = new System.Drawing.Size(219, 21);
             this.cboOrdenarIndice.TabIndex = 4;
             // 
             // dstIndice
             // 
             this.dstIndice.DataSetName = "NewDataSet";
             this.dstIndice.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
             // 
             // dataTable1
             // 
             this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
             this.dataTable1.TableName = "MyTable";
             // 
             // dataColumn3
             // 
             this.dataColumn3.ColumnName = "IdIndices";
             this.dataColumn3.DataType = typeof(int);
             // 
             // dataColumn4
             // 
             this.dataColumn4.ColumnName = "DataIndice";
             this.dataColumn4.DataType = typeof(System.DateTime);
             // 
             // dataColumn5
             // 
             this.dataColumn5.ColumnName = "Valor";
             this.dataColumn5.DataType = typeof(decimal);
             // 
             // dataColumn6
             // 
             this.dataColumn6.ColumnName = "Grupo1";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dstIndice, "dstIndice");
             // 
             // relIndicePeríodo
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(448, 265);
             this.Controls.Add(this.groupBox3);
             this.Controls.Add(this.groupBox2);
             this.Controls.Add(this.groupBox1);
             this.MaximizeBox = false;
             this.Name = "relIndicePeríodo";
             this.Text = "Relação de Índices por Período";
             this.Load += new System.EventHandler(this.relIndicePeriodo_Load);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.Controls.SetChildIndex(this.groupBox1, 0);
             this.Controls.SetChildIndex(this.groupBox2, 0);
             this.Controls.SetChildIndex(this.groupBox3, 0);
             this.groupBox1.ResumeLayout(false);
             this.groupBox2.ResumeLayout(false);
             this.groupBox2.PerformLayout();
             this.groupBox3.ResumeLayout(false);
             this.groupBox3.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstIndice)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckedListBox lstIndice;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker txtDtaFinal;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.DateTimePicker txtDtaInicial;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox cboOrdenarIndice;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox cboOrdenarPeriodo;
      private System.Data.DataSet dstIndice;
      private System.Data.DataTable dataTable1;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private System.Data.DataColumn dataColumn5;
      private System.Data.DataColumn dataColumn6;
      private FastReport.Report report1;
      }
   }