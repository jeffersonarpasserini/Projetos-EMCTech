namespace EMCCadastro.Relatorios
   {
   partial class relCtaBancaria
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relCtaBancaria));
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.lstBanco = new System.Windows.Forms.CheckedListBox();
             this.groupBox3 = new System.Windows.Forms.GroupBox();
             this.cboAgrupar = new System.Windows.Forms.ComboBox();
             this.groupBox2 = new System.Windows.Forms.GroupBox();
             this.cboOrdenar = new System.Windows.Forms.ComboBox();
             this.dstCtaBancaria = new System.Data.DataSet();
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
             this.report1 = new FastReport.Report();
             this.groupBox1.SuspendLayout();
             this.groupBox3.SuspendLayout();
             this.groupBox2.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dstCtaBancaria)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Size = new System.Drawing.Size(353, 68);
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.lstBanco);
             this.groupBox1.ForeColor = System.Drawing.Color.Blue;
             this.groupBox1.Location = new System.Drawing.Point(172, 81);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(188, 163);
             this.groupBox1.TabIndex = 4;
             this.groupBox1.TabStop = false;
             this.groupBox1.Text = "Bancos a Emitir";
             // 
             // lstBanco
             // 
             this.lstBanco.CheckOnClick = true;
             this.lstBanco.FormattingEnabled = true;
             this.lstBanco.Location = new System.Drawing.Point(12, 24);
             this.lstBanco.Name = "lstBanco";
             this.lstBanco.Size = new System.Drawing.Size(164, 124);
             this.lstBanco.TabIndex = 5;
             // 
             // groupBox3
             // 
             this.groupBox3.Controls.Add(this.cboAgrupar);
             this.groupBox3.ForeColor = System.Drawing.Color.Blue;
             this.groupBox3.Location = new System.Drawing.Point(7, 81);
             this.groupBox3.Name = "groupBox3";
             this.groupBox3.Size = new System.Drawing.Size(159, 51);
             this.groupBox3.TabIndex = 0;
             this.groupBox3.TabStop = false;
             this.groupBox3.Text = "Agrupar";
             // 
             // cboAgrupar
             // 
             this.cboAgrupar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboAgrupar.FormattingEnabled = true;
             this.cboAgrupar.Location = new System.Drawing.Point(7, 20);
             this.cboAgrupar.Name = "cboAgrupar";
             this.cboAgrupar.Size = new System.Drawing.Size(144, 21);
             this.cboAgrupar.TabIndex = 1;
             // 
             // groupBox2
             // 
             this.groupBox2.Controls.Add(this.cboOrdenar);
             this.groupBox2.ForeColor = System.Drawing.Color.Blue;
             this.groupBox2.Location = new System.Drawing.Point(7, 138);
             this.groupBox2.Name = "groupBox2";
             this.groupBox2.Size = new System.Drawing.Size(159, 51);
             this.groupBox2.TabIndex = 2;
             this.groupBox2.TabStop = false;
             this.groupBox2.Text = "Ordenar";
             // 
             // cboOrdenar
             // 
             this.cboOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.cboOrdenar.FormattingEnabled = true;
             this.cboOrdenar.Location = new System.Drawing.Point(7, 20);
             this.cboOrdenar.Name = "cboOrdenar";
             this.cboOrdenar.Size = new System.Drawing.Size(144, 21);
             this.cboOrdenar.TabIndex = 3;
             // 
             // dstCtaBancaria
             // 
             this.dstCtaBancaria.DataSetName = "NewDataSet";
             this.dstCtaBancaria.Tables.AddRange(new System.Data.DataTable[] {
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
             this.dataColumn1.ColumnName = "IdCtaBancaria";
             this.dataColumn1.DataType = typeof(long);
             // 
             // dataColumn2
             // 
             this.dataColumn2.ColumnName = "IdEmpresa";
             this.dataColumn2.DataType = typeof(short);
             // 
             // dataColumn3
             // 
             this.dataColumn3.ColumnName = "Descricao";
             // 
             // dataColumn4
             // 
             this.dataColumn4.ColumnName = "Agencia";
             // 
             // dataColumn5
             // 
             this.dataColumn5.ColumnName = "Conta";
             // 
             // dataColumn6
             // 
             this.dataColumn6.ColumnName = "IdBanco";
             this.dataColumn6.DataType = typeof(long);
             // 
             // dataColumn7
             // 
             this.dataColumn7.ColumnName = "SaldoAtual";
             this.dataColumn7.DataType = typeof(decimal);
             // 
             // dataColumn8
             // 
             this.dataColumn8.ColumnName = "Limite";
             this.dataColumn8.DataType = typeof(decimal);
             // 
             // dataColumn9
             // 
             this.dataColumn9.ColumnName = "VencLimite";
             this.dataColumn9.DataType = typeof(System.DateTime);
             // 
             // dataColumn10
             // 
             this.dataColumn10.ColumnName = "DtaFechamento";
             this.dataColumn10.DataType = typeof(System.DateTime);
             // 
             // dataColumn11
             // 
             this.dataColumn11.ColumnName = "SaldoFechamento";
             this.dataColumn11.DataType = typeof(decimal);
             // 
             // dataColumn12
             // 
             this.dataColumn12.ColumnName = "AgenciaDigito";
             // 
             // dataColumn13
             // 
             this.dataColumn13.ColumnName = "ContaDigito";
             // 
             // dataColumn14
             // 
             this.dataColumn14.ColumnName = "Cedente";
             // 
             // dataColumn15
             // 
             this.dataColumn15.ColumnName = "CedenteDigito";
             // 
             // dataColumn16
             // 
             this.dataColumn16.ColumnName = "DescrBanco";
             // 
             // dataColumn17
             // 
             this.dataColumn17.ColumnName = "Grupo1";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dstCtaBancaria, "dstCtaBancaria");
             // 
             // relCtaBancaria
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(368, 251);
             this.Controls.Add(this.groupBox2);
             this.Controls.Add(this.groupBox3);
             this.Controls.Add(this.groupBox1);
             this.MaximizeBox = false;
             this.Name = "relCtaBancaria";
             this.Text = "Relação de Contas Bancárias";
             this.Load += new System.EventHandler(this.relCtaBancaria_Load);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.Controls.SetChildIndex(this.groupBox1, 0);
             this.Controls.SetChildIndex(this.groupBox3, 0);
             this.Controls.SetChildIndex(this.groupBox2, 0);
             this.groupBox1.ResumeLayout(false);
             this.groupBox3.ResumeLayout(false);
             this.groupBox2.ResumeLayout(false);
             ((System.ComponentModel.ISupportInitialize)(this.dstCtaBancaria)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckedListBox lstBanco;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox cboAgrupar;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox cboOrdenar;
      private System.Data.DataSet dstCtaBancaria;
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
      private System.Data.DataColumn dataColumn16;
      private System.Data.DataColumn dataColumn17;
      private FastReport.Report report1;
      }
   }