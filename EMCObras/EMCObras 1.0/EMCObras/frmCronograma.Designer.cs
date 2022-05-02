namespace EMCObras
{
    partial class frmCronograma
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
            this.tvwTarefa = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscaObra = new System.Windows.Forms.Button();
            this.txtDescricaoObra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbreviacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSituacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSituacaoDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdObra_CronogramaItem = new System.Windows.Forms.TextBox();
            this.txtObra_Tarefa = new System.Windows.Forms.TextBox();
            this.txtIdObra_Tarefa = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNroDiasPrevisto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustoUnitarioPrevisto = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustoPrevisto = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQtdePrevista = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIdUnidadeMedida = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDtaFinalPrevisto = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDtaInicioPrevisto = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cboAtividadeCritica = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNroDiasRealizado = new System.Windows.Forms.TextBox();
            this.txtDtaFinal = new System.Windows.Forms.TextBox();
            this.txtDtaInicio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCustoUnitarioRealizado = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCustoRealizado = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQtdeRealizada = new System.Windows.Forms.Sample.DecimalTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvwTarefa
            // 
            this.tvwTarefa.Location = new System.Drawing.Point(3, 139);
            this.tvwTarefa.Name = "tvwTarefa";
            this.tvwTarefa.Size = new System.Drawing.Size(272, 286);
            this.tvwTarefa.TabIndex = 1;
            this.tvwTarefa.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwTarefa_NodeMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscaObra);
            this.groupBox1.Controls.Add(this.txtDescricaoObra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAbreviacao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 61);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obra";
            // 
            // btnBuscaObra
            // 
            this.btnBuscaObra.Image = global::EMCObras.Properties.Resources.binoculo_16x16;
            this.btnBuscaObra.Location = new System.Drawing.Point(128, 34);
            this.btnBuscaObra.Name = "btnBuscaObra";
            this.btnBuscaObra.Size = new System.Drawing.Size(31, 23);
            this.btnBuscaObra.TabIndex = 84;
            this.btnBuscaObra.UseVisualStyleBackColor = true;
            this.btnBuscaObra.Click += new System.EventHandler(this.btnBuscaObra_Click);
            // 
            // txtDescricaoObra
            // 
            this.txtDescricaoObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoObra.Location = new System.Drawing.Point(163, 34);
            this.txtDescricaoObra.Name = "txtDescricaoObra";
            this.txtDescricaoObra.ReadOnly = true;
            this.txtDescricaoObra.Size = new System.Drawing.Size(533, 22);
            this.txtDescricaoObra.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Descrição";
            // 
            // txtAbreviacao
            // 
            this.txtAbreviacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAbreviacao.Location = new System.Drawing.Point(8, 34);
            this.txtAbreviacao.Name = "txtAbreviacao";
            this.txtAbreviacao.Size = new System.Drawing.Size(118, 22);
            this.txtAbreviacao.TabIndex = 81;
            this.txtAbreviacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtAbreviacao_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Código";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSituacao);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSituacaoDesc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtIdObra_CronogramaItem);
            this.groupBox2.Controls.Add(this.txtObra_Tarefa);
            this.groupBox2.Controls.Add(this.txtIdObra_Tarefa);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(281, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 61);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tarefa";
            // 
            // txtSituacao
            // 
            this.txtSituacao.Enabled = false;
            this.txtSituacao.Location = new System.Drawing.Point(387, 8);
            this.txtSituacao.Name = "txtSituacao";
            this.txtSituacao.ReadOnly = true;
            this.txtSituacao.Size = new System.Drawing.Size(18, 22);
            this.txtSituacao.TabIndex = 90;
            this.txtSituacao.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 89;
            this.label4.Text = "Situação";
            // 
            // txtSituacaoDesc
            // 
            this.txtSituacaoDesc.Enabled = false;
            this.txtSituacaoDesc.Location = new System.Drawing.Point(319, 33);
            this.txtSituacaoDesc.Name = "txtSituacaoDesc";
            this.txtSituacaoDesc.ReadOnly = true;
            this.txtSituacaoDesc.Size = new System.Drawing.Size(93, 22);
            this.txtSituacaoDesc.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Tarefa";
            // 
            // txtIdObra_CronogramaItem
            // 
            this.txtIdObra_CronogramaItem.Location = new System.Drawing.Point(169, 13);
            this.txtIdObra_CronogramaItem.Name = "txtIdObra_CronogramaItem";
            this.txtIdObra_CronogramaItem.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_CronogramaItem.TabIndex = 86;
            this.txtIdObra_CronogramaItem.Visible = false;
            // 
            // txtObra_Tarefa
            // 
            this.txtObra_Tarefa.Enabled = false;
            this.txtObra_Tarefa.Location = new System.Drawing.Point(6, 33);
            this.txtObra_Tarefa.Name = "txtObra_Tarefa";
            this.txtObra_Tarefa.ReadOnly = true;
            this.txtObra_Tarefa.Size = new System.Drawing.Size(309, 22);
            this.txtObra_Tarefa.TabIndex = 83;
            // 
            // txtIdObra_Tarefa
            // 
            this.txtIdObra_Tarefa.Location = new System.Drawing.Point(63, 12);
            this.txtIdObra_Tarefa.Name = "txtIdObra_Tarefa";
            this.txtIdObra_Tarefa.Size = new System.Drawing.Size(100, 22);
            this.txtIdObra_Tarefa.TabIndex = 84;
            this.txtIdObra_Tarefa.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNroDiasPrevisto);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtCustoUnitarioPrevisto);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtCustoPrevisto);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtQtdePrevista);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cboIdUnidadeMedida);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtDtaFinalPrevisto);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtDtaInicioPrevisto);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboAtividadeCritica);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(281, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(421, 107);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Previsão";
            // 
            // txtNroDiasPrevisto
            // 
            this.txtNroDiasPrevisto.Enabled = false;
            this.txtNroDiasPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDiasPrevisto.Location = new System.Drawing.Point(319, 35);
            this.txtNroDiasPrevisto.Name = "txtNroDiasPrevisto";
            this.txtNroDiasPrevisto.ReadOnly = true;
            this.txtNroDiasPrevisto.Size = new System.Drawing.Size(92, 20);
            this.txtNroDiasPrevisto.TabIndex = 89;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(316, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Custo Unitário";
            // 
            // txtCustoUnitarioPrevisto
            // 
            this.txtCustoUnitarioPrevisto.Enabled = false;
            this.txtCustoUnitarioPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustoUnitarioPrevisto.Location = new System.Drawing.Point(319, 76);
            this.txtCustoUnitarioPrevisto.Name = "txtCustoUnitarioPrevisto";
            this.txtCustoUnitarioPrevisto.numeroDecimais = 0;
            this.txtCustoUnitarioPrevisto.ReadOnly = true;
            this.txtCustoUnitarioPrevisto.Size = new System.Drawing.Size(92, 20);
            this.txtCustoUnitarioPrevisto.TabIndex = 58;
            this.txtCustoUnitarioPrevisto.Text = "0,00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(224, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Custo Previsto";
            // 
            // txtCustoPrevisto
            // 
            this.txtCustoPrevisto.Enabled = false;
            this.txtCustoPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustoPrevisto.Location = new System.Drawing.Point(227, 76);
            this.txtCustoPrevisto.Name = "txtCustoPrevisto";
            this.txtCustoPrevisto.numeroDecimais = 0;
            this.txtCustoPrevisto.ReadOnly = true;
            this.txtCustoPrevisto.Size = new System.Drawing.Size(88, 20);
            this.txtCustoPrevisto.TabIndex = 56;
            this.txtCustoPrevisto.Text = "0,00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(132, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Quantidade";
            // 
            // txtQtdePrevista
            // 
            this.txtQtdePrevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdePrevista.Location = new System.Drawing.Point(135, 76);
            this.txtQtdePrevista.Name = "txtQtdePrevista";
            this.txtQtdePrevista.numeroDecimais = 0;
            this.txtQtdePrevista.Size = new System.Drawing.Size(88, 20);
            this.txtQtdePrevista.TabIndex = 54;
            this.txtQtdePrevista.Text = "0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Unidade Medida";
            // 
            // cboIdUnidadeMedida
            // 
            this.cboIdUnidadeMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIdUnidadeMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIdUnidadeMedida.FormattingEnabled = true;
            this.cboIdUnidadeMedida.Location = new System.Drawing.Point(7, 78);
            this.cboIdUnidadeMedida.Name = "cboIdUnidadeMedida";
            this.cboIdUnidadeMedida.Size = new System.Drawing.Size(121, 21);
            this.cboIdUnidadeMedida.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(316, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Nro Dias Previsto";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(225, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Data Final";
            // 
            // txtDtaFinalPrevisto
            // 
            this.txtDtaFinalPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtaFinalPrevisto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaFinalPrevisto.Location = new System.Drawing.Point(227, 35);
            this.txtDtaFinalPrevisto.Name = "txtDtaFinalPrevisto";
            this.txtDtaFinalPrevisto.Size = new System.Drawing.Size(88, 20);
            this.txtDtaFinalPrevisto.TabIndex = 47;
            this.txtDtaFinalPrevisto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDtaFinalPrevisto_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(133, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Data Inicio";
            // 
            // txtDtaInicioPrevisto
            // 
            this.txtDtaInicioPrevisto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDtaInicioPrevisto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDtaInicioPrevisto.Location = new System.Drawing.Point(135, 35);
            this.txtDtaInicioPrevisto.Name = "txtDtaInicioPrevisto";
            this.txtDtaInicioPrevisto.Size = new System.Drawing.Size(88, 20);
            this.txtDtaInicioPrevisto.TabIndex = 46;
            this.txtDtaInicioPrevisto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDtaInicioPrevisto_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Atividade Critica ?";
            // 
            // cboAtividadeCritica
            // 
            this.cboAtividadeCritica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAtividadeCritica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAtividadeCritica.FormattingEnabled = true;
            this.cboAtividadeCritica.Location = new System.Drawing.Point(7, 34);
            this.cboAtividadeCritica.Name = "cboAtividadeCritica";
            this.cboAtividadeCritica.Size = new System.Drawing.Size(121, 21);
            this.cboAtividadeCritica.TabIndex = 44;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNroDiasRealizado);
            this.groupBox4.Controls.Add(this.txtDtaFinal);
            this.groupBox4.Controls.Add(this.txtDtaInicio);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtCustoUnitarioRealizado);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtCustoRealizado);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtQtdeRealizada);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(281, 318);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(421, 107);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Realizado";
            // 
            // txtNroDiasRealizado
            // 
            this.txtNroDiasRealizado.Enabled = false;
            this.txtNroDiasRealizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDiasRealizado.Location = new System.Drawing.Point(264, 29);
            this.txtNroDiasRealizado.Name = "txtNroDiasRealizado";
            this.txtNroDiasRealizado.ReadOnly = true;
            this.txtNroDiasRealizado.Size = new System.Drawing.Size(137, 20);
            this.txtNroDiasRealizado.TabIndex = 91;
            // 
            // txtDtaFinal
            // 
            this.txtDtaFinal.Enabled = false;
            this.txtDtaFinal.Location = new System.Drawing.Point(137, 29);
            this.txtDtaFinal.Name = "txtDtaFinal";
            this.txtDtaFinal.ReadOnly = true;
            this.txtDtaFinal.Size = new System.Drawing.Size(121, 22);
            this.txtDtaFinal.TabIndex = 90;
            // 
            // txtDtaInicio
            // 
            this.txtDtaInicio.Enabled = false;
            this.txtDtaInicio.Location = new System.Drawing.Point(7, 28);
            this.txtDtaInicio.Name = "txtDtaInicio";
            this.txtDtaInicio.ReadOnly = true;
            this.txtDtaInicio.Size = new System.Drawing.Size(121, 22);
            this.txtDtaInicio.TabIndex = 89;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(261, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Custo Unitário";
            // 
            // txtCustoUnitarioRealizado
            // 
            this.txtCustoUnitarioRealizado.Enabled = false;
            this.txtCustoUnitarioRealizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustoUnitarioRealizado.Location = new System.Drawing.Point(264, 76);
            this.txtCustoUnitarioRealizado.Name = "txtCustoUnitarioRealizado";
            this.txtCustoUnitarioRealizado.numeroDecimais = 0;
            this.txtCustoUnitarioRealizado.ReadOnly = true;
            this.txtCustoUnitarioRealizado.Size = new System.Drawing.Size(137, 20);
            this.txtCustoUnitarioRealizado.TabIndex = 58;
            this.txtCustoUnitarioRealizado.Text = "0,00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(134, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Custo ";
            // 
            // txtCustoRealizado
            // 
            this.txtCustoRealizado.Enabled = false;
            this.txtCustoRealizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustoRealizado.Location = new System.Drawing.Point(137, 76);
            this.txtCustoRealizado.Name = "txtCustoRealizado";
            this.txtCustoRealizado.numeroDecimais = 0;
            this.txtCustoRealizado.ReadOnly = true;
            this.txtCustoRealizado.Size = new System.Drawing.Size(121, 20);
            this.txtCustoRealizado.TabIndex = 56;
            this.txtCustoRealizado.Text = "0,00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Quantidade";
            // 
            // txtQtdeRealizada
            // 
            this.txtQtdeRealizada.Enabled = false;
            this.txtQtdeRealizada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdeRealizada.Location = new System.Drawing.Point(7, 76);
            this.txtQtdeRealizada.Name = "txtQtdeRealizada";
            this.txtQtdeRealizada.numeroDecimais = 0;
            this.txtQtdeRealizada.ReadOnly = true;
            this.txtQtdeRealizada.Size = new System.Drawing.Size(121, 20);
            this.txtQtdeRealizada.TabIndex = 54;
            this.txtQtdeRealizada.Text = "0,00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(266, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 51;
            this.label17.Text = "Nro Dias ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(134, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 49;
            this.label18.Text = "Data Final";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(5, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 48;
            this.label19.Text = "Data Inicio";
            // 
            // frmCronograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(708, 429);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvwTarefa);
            this.MaximizeBox = false;
            this.Name = "frmCronograma";
            this.Text = "Cronograma de Obras";
            this.Load += new System.EventHandler(this.frmCronograma_Load);
            this.Controls.SetChildIndex(this.tvwTarefa, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwTarefa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscaObra;
        private System.Windows.Forms.TextBox txtDescricaoObra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbreviacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSituacaoDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdObra_CronogramaItem;
        private System.Windows.Forms.TextBox txtObra_Tarefa;
        private System.Windows.Forms.TextBox txtIdObra_Tarefa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker txtDtaFinalPrevisto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker txtDtaInicioPrevisto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboAtividadeCritica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboIdUnidadeMedida;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Sample.DecimalTextBox txtCustoUnitarioPrevisto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Sample.DecimalTextBox txtCustoPrevisto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Sample.DecimalTextBox txtQtdePrevista;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Sample.DecimalTextBox txtCustoUnitarioRealizado;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Sample.DecimalTextBox txtCustoRealizado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Sample.DecimalTextBox txtQtdeRealizada;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDtaFinal;
        private System.Windows.Forms.TextBox txtDtaInicio;
        private System.Windows.Forms.TextBox txtNroDiasPrevisto;
        private System.Windows.Forms.TextBox txtNroDiasRealizado;
        private System.Windows.Forms.TextBox txtSituacao;
    }
}
