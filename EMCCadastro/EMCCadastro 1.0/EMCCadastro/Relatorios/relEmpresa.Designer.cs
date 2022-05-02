namespace EMCCadastro.Relatorios
   {
   partial class relEmpresa
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
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(relEmpresa));
             this.groupBox3 = new System.Windows.Forms.GroupBox();
             this.cboOrdenarIndice = new System.Windows.Forms.ComboBox();
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.lstGrupo = new System.Windows.Forms.CheckedListBox();
             this.dataSet1 = new System.Data.DataSet();
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
             this.dataColumn18 = new System.Data.DataColumn();
             this.dataColumn19 = new System.Data.DataColumn();
             this.dataColumn20 = new System.Data.DataColumn();
             this.dataColumn21 = new System.Data.DataColumn();
             this.dataColumn22 = new System.Data.DataColumn();
             this.dataColumn23 = new System.Data.DataColumn();
             this.report1 = new FastReport.Report();
             this.groupBox3.SuspendLayout();
             this.groupBox1.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
             this.SuspendLayout();
             // 
             // panBotoes
             // 
             this.panBotoes.Size = new System.Drawing.Size(457, 68);
             // 
             // groupBox3
             // 
             this.groupBox3.Controls.Add(this.cboOrdenarIndice);
             this.groupBox3.ForeColor = System.Drawing.Color.Blue;
             this.groupBox3.Location = new System.Drawing.Point(14, 89);
             this.groupBox3.Name = "groupBox3";
             this.groupBox3.Size = new System.Drawing.Size(167, 61);
             this.groupBox3.TabIndex = 0;
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
             this.cboOrdenarIndice.TabIndex = 1;
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.lstGrupo);
             this.groupBox1.ForeColor = System.Drawing.Color.Blue;
             this.groupBox1.Location = new System.Drawing.Point(188, 89);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(277, 171);
             this.groupBox1.TabIndex = 2;
             this.groupBox1.TabStop = false;
             this.groupBox1.Text = "Grupos de Empresas a Emitir";
             // 
             // lstGrupo
             // 
             this.lstGrupo.CheckOnClick = true;
             this.lstGrupo.FormattingEnabled = true;
             this.lstGrupo.Location = new System.Drawing.Point(12, 24);
             this.lstGrupo.Name = "lstGrupo";
             this.lstGrupo.Size = new System.Drawing.Size(256, 139);
             this.lstGrupo.TabIndex = 3;
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
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23});
             this.dataTable1.TableName = "MyTable";
             // 
             // dataColumn1
             // 
             this.dataColumn1.ColumnName = "IdHolding";
             this.dataColumn1.DataType = typeof(long);
             // 
             // dataColumn2
             // 
             this.dataColumn2.ColumnName = "NomeHolding";
             // 
             // dataColumn3
             // 
             this.dataColumn3.ColumnName = "IdGrupoEmpresa";
             this.dataColumn3.DataType = typeof(long);
             // 
             // dataColumn4
             // 
             this.dataColumn4.ColumnName = "NomeGrupoEmpresa";
             // 
             // dataColumn5
             // 
             this.dataColumn5.ColumnName = "IdEmpresa";
             this.dataColumn5.DataType = typeof(long);
             // 
             // dataColumn6
             // 
             this.dataColumn6.ColumnName = "EmpMaster";
             this.dataColumn6.DataType = typeof(long);
             // 
             // dataColumn7
             // 
             this.dataColumn7.ColumnName = "RazaoSocial";
             // 
             // dataColumn8
             // 
             this.dataColumn8.ColumnName = "NomeFantasia";
             // 
             // dataColumn9
             // 
             this.dataColumn9.ColumnName = "CNPJCPF";
             this.dataColumn9.DataType = typeof(double);
             // 
             // dataColumn10
             // 
             this.dataColumn10.ColumnName = "InscrEstadual";
             this.dataColumn10.DataType = typeof(double);
             // 
             // dataColumn11
             // 
             this.dataColumn11.ColumnName = "Endereco";
             // 
             // dataColumn12
             // 
             this.dataColumn12.ColumnName = "Numero";
             this.dataColumn12.DataType = typeof(double);
             // 
             // dataColumn13
             // 
             this.dataColumn13.ColumnName = "Bairro";
             // 
             // dataColumn14
             // 
             this.dataColumn14.ColumnName = "Complemento";
             // 
             // dataColumn15
             // 
             this.dataColumn15.ColumnName = "Cidade";
             // 
             // dataColumn16
             // 
             this.dataColumn16.ColumnName = "Estado";
             // 
             // dataColumn17
             // 
             this.dataColumn17.ColumnName = "idCEP";
             this.dataColumn17.DataType = typeof(double);
             // 
             // dataColumn18
             // 
             this.dataColumn18.ColumnName = "Telefone";
             this.dataColumn18.DataType = typeof(double);
             // 
             // dataColumn19
             // 
             this.dataColumn19.ColumnName = "MatrizFilial";
             // 
             // dataColumn20
             // 
             this.dataColumn20.ColumnName = "EmpresaMatriz";
             // 
             // dataColumn21
             // 
             this.dataColumn21.ColumnName = "Grupo1";
             // 
             // dataColumn22
             // 
             this.dataColumn22.ColumnName = "Grupo2";
             // 
             // dataColumn23
             // 
             this.dataColumn23.ColumnName = "InscrMunicipal";
             // 
             // report1
             // 
             this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
             this.report1.RegisterData(this.dataSet1, "dataSet1");
             // 
             // relEmpresa
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(469, 266);
             this.Controls.Add(this.groupBox3);
             this.Controls.Add(this.groupBox1);
             this.MaximizeBox = false;
             this.Name = "relEmpresa";
             this.Text = "Relatório de Empresas ";
             this.Load += new System.EventHandler(this.relEmpresa_Load);
             this.Controls.SetChildIndex(this.groupBox1, 0);
             this.Controls.SetChildIndex(this.groupBox3, 0);
             this.Controls.SetChildIndex(this.panBotoes, 0);
             this.groupBox3.ResumeLayout(false);
             this.groupBox1.ResumeLayout(false);
             ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
             this.ResumeLayout(false);

         }

      #endregion

      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox cboOrdenarIndice;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckedListBox lstGrupo;
      private System.Data.DataSet dataSet1;
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
      private System.Data.DataColumn dataColumn18;
      private System.Data.DataColumn dataColumn19;
      private System.Data.DataColumn dataColumn20;
      private System.Data.DataColumn dataColumn21;
      private System.Data.DataColumn dataColumn22;
      private FastReport.Report report1;
      private System.Data.DataColumn dataColumn23;
      }
   }