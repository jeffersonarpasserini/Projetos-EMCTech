namespace EMCEstoque
{
    partial class frmEstq_SubGrupo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdEstq_SubGrupo = new System.Windows.Forms.DataGridView();
            this.idestq_subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subgrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_grupo_idEstq_grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estq_grupo_descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menor_unidadecontrole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadepadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMenor_UnidadeControle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMenor_UnidadeControle = new System.Windows.Forms.ComboBox();
            this.txtidEstq_Grupo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboEstq_Grupo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtidEstq_SubGrupo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtUnidadePadrao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboUnidadePadrao = new System.Windows.Forms.ComboBox();
            this.txtUnidadeSolicitacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUnidadeSolicitacao = new System.Windows.Forms.ComboBox();
            this.txtUnidadeRequisicao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboUnidadeRequisicao = new System.Windows.Forms.ComboBox();
            this.txtUnidadeIndustria = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboUnidadeIndustria = new System.Windows.Forms.ComboBox();
            this.txtUnidadeRecebimento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUnidadeRecebimento = new System.Windows.Forms.ComboBox();
            this.txtUnidadeVenda = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboUnidadeVenda = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_SubGrupo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEstq_SubGrupo
            // 
            this.grdEstq_SubGrupo.AllowUserToAddRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdEstq_SubGrupo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.grdEstq_SubGrupo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdEstq_SubGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdEstq_SubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstq_SubGrupo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestq_subgrupo,
            this.Subgrupo,
            this.estq_grupo_idEstq_grupo,
            this.estq_grupo_descricao,
            this.menor_unidadecontrole,
            this.unidadepadrao});
            this.grdEstq_SubGrupo.Location = new System.Drawing.Point(2, 330);
            this.grdEstq_SubGrupo.MultiSelect = false;
            this.grdEstq_SubGrupo.Name = "grdEstq_SubGrupo";
            this.grdEstq_SubGrupo.ReadOnly = true;
            this.grdEstq_SubGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstq_SubGrupo.Size = new System.Drawing.Size(629, 178);
            this.grdEstq_SubGrupo.TabIndex = 16;
            this.grdEstq_SubGrupo.DoubleClick += new System.EventHandler(this.grdEstq_SubGrupo_DoubleClick);
            // 
            // idestq_subgrupo
            // 
            this.idestq_subgrupo.DataPropertyName = "idestq_subgrupo";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.idestq_subgrupo.DefaultCellStyle = dataGridViewCellStyle12;
            this.idestq_subgrupo.HeaderText = "Código";
            this.idestq_subgrupo.Name = "idestq_subgrupo";
            this.idestq_subgrupo.ReadOnly = true;
            this.idestq_subgrupo.Width = 65;
            // 
            // Subgrupo
            // 
            this.Subgrupo.DataPropertyName = "descricao";
            this.Subgrupo.HeaderText = "Subgrupo";
            this.Subgrupo.Name = "Subgrupo";
            this.Subgrupo.ReadOnly = true;
            this.Subgrupo.Width = 78;
            // 
            // estq_grupo_idEstq_grupo
            // 
            this.estq_grupo_idEstq_grupo.DataPropertyName = "estq_grupo_idEstq_grupo";
            this.estq_grupo_idEstq_grupo.HeaderText = "idestq_grupo";
            this.estq_grupo_idEstq_grupo.Name = "estq_grupo_idEstq_grupo";
            this.estq_grupo_idEstq_grupo.ReadOnly = true;
            this.estq_grupo_idEstq_grupo.Visible = false;
            this.estq_grupo_idEstq_grupo.Width = 93;
            // 
            // estq_grupo_descricao
            // 
            this.estq_grupo_descricao.DataPropertyName = "estq_grupo_descricao";
            this.estq_grupo_descricao.HeaderText = "Grupo";
            this.estq_grupo_descricao.Name = "estq_grupo_descricao";
            this.estq_grupo_descricao.ReadOnly = true;
            this.estq_grupo_descricao.Width = 61;
            // 
            // menor_unidadecontrole
            // 
            this.menor_unidadecontrole.DataPropertyName = "menor_unidadecontrole";
            this.menor_unidadecontrole.HeaderText = "Menor Unid.";
            this.menor_unidadecontrole.Name = "menor_unidadecontrole";
            this.menor_unidadecontrole.ReadOnly = true;
            this.menor_unidadecontrole.Width = 90;
            // 
            // unidadepadrao
            // 
            this.unidadepadrao.DataPropertyName = "unidadepadrao";
            this.unidadepadrao.HeaderText = "Unid. Padrão";
            this.unidadepadrao.Name = "unidadepadrao";
            this.unidadepadrao.ReadOnly = true;
            this.unidadepadrao.Width = 94;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtUnidadeVenda);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cboUnidadeVenda);
            this.panel1.Controls.Add(this.txtUnidadeIndustria);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboUnidadeIndustria);
            this.panel1.Controls.Add(this.txtUnidadeRecebimento);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboUnidadeRecebimento);
            this.panel1.Controls.Add(this.txtUnidadeSolicitacao);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboUnidadeSolicitacao);
            this.panel1.Controls.Add(this.txtUnidadeRequisicao);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cboUnidadeRequisicao);
            this.panel1.Controls.Add(this.txtUnidadePadrao);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboUnidadePadrao);
            this.panel1.Controls.Add(this.txtMenor_UnidadeControle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboMenor_UnidadeControle);
            this.panel1.Controls.Add(this.txtidEstq_Grupo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboEstq_Grupo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtidEstq_SubGrupo);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 251);
            this.panel1.TabIndex = 15;
            // 
            // txtMenor_UnidadeControle
            // 
            this.txtMenor_UnidadeControle.Location = new System.Drawing.Point(10, 103);
            this.txtMenor_UnidadeControle.Name = "txtMenor_UnidadeControle";
            this.txtMenor_UnidadeControle.Size = new System.Drawing.Size(40, 20);
            this.txtMenor_UnidadeControle.TabIndex = 9;
            this.txtMenor_UnidadeControle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMenor_UnidadeControle.Validating += new System.ComponentModel.CancelEventHandler(this.txtMenor_UnidadeControle_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Menor Unidade de Controle";
            // 
            // cboMenor_UnidadeControle
            // 
            this.cboMenor_UnidadeControle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMenor_UnidadeControle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMenor_UnidadeControle.FormattingEnabled = true;
            this.cboMenor_UnidadeControle.Location = new System.Drawing.Point(52, 102);
            this.cboMenor_UnidadeControle.Name = "cboMenor_UnidadeControle";
            this.cboMenor_UnidadeControle.Size = new System.Drawing.Size(261, 21);
            this.cboMenor_UnidadeControle.TabIndex = 10;
            this.cboMenor_UnidadeControle.SelectedValueChanged += new System.EventHandler(this.cboMenor_UnidadeControle_SelectedValueChanged);
            // 
            // txtidEstq_Grupo
            // 
            this.txtidEstq_Grupo.Location = new System.Drawing.Point(10, 63);
            this.txtidEstq_Grupo.Name = "txtidEstq_Grupo";
            this.txtidEstq_Grupo.Size = new System.Drawing.Size(65, 20);
            this.txtidEstq_Grupo.TabIndex = 7;
            this.txtidEstq_Grupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtidEstq_Grupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_Grupo_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Grupo do Estoque";
            // 
            // cboEstq_Grupo
            // 
            this.cboEstq_Grupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboEstq_Grupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEstq_Grupo.FormattingEnabled = true;
            this.cboEstq_Grupo.Location = new System.Drawing.Point(79, 63);
            this.cboEstq_Grupo.Name = "cboEstq_Grupo";
            this.cboEstq_Grupo.Size = new System.Drawing.Size(540, 21);
            this.cboEstq_Grupo.TabIndex = 8;
            this.cboEstq_Grupo.SelectedValueChanged += new System.EventHandler(this.cboEstq_Grupo_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subgrupo";
            // 
            // txtidEstq_SubGrupo
            // 
            this.txtidEstq_SubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtidEstq_SubGrupo.Location = new System.Drawing.Point(10, 23);
            this.txtidEstq_SubGrupo.MaxLength = 50;
            this.txtidEstq_SubGrupo.Name = "txtidEstq_SubGrupo";
            this.txtidEstq_SubGrupo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtidEstq_SubGrupo.Size = new System.Drawing.Size(63, 20);
            this.txtidEstq_SubGrupo.TabIndex = 1;
            this.txtidEstq_SubGrupo.Validating += new System.ComponentModel.CancelEventHandler(this.txtidEstq_SubGrupo_Validating);
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(77, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(542, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtUnidadePadrao
            // 
            this.txtUnidadePadrao.Location = new System.Drawing.Point(319, 102);
            this.txtUnidadePadrao.Name = "txtUnidadePadrao";
            this.txtUnidadePadrao.Size = new System.Drawing.Size(40, 20);
            this.txtUnidadePadrao.TabIndex = 16;
            this.txtUnidadePadrao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadePadrao.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadePadrao_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Unidade Padrão";
            // 
            // cboUnidadePadrao
            // 
            this.cboUnidadePadrao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadePadrao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadePadrao.FormattingEnabled = true;
            this.cboUnidadePadrao.Location = new System.Drawing.Point(361, 102);
            this.cboUnidadePadrao.Name = "cboUnidadePadrao";
            this.cboUnidadePadrao.Size = new System.Drawing.Size(256, 21);
            this.cboUnidadePadrao.TabIndex = 17;
            this.cboUnidadePadrao.SelectedValueChanged += new System.EventHandler(this.cboUnidadePadrao_SelectedValueChanged);
            // 
            // txtUnidadeSolicitacao
            // 
            this.txtUnidadeSolicitacao.Location = new System.Drawing.Point(319, 142);
            this.txtUnidadeSolicitacao.Name = "txtUnidadeSolicitacao";
            this.txtUnidadeSolicitacao.Size = new System.Drawing.Size(40, 20);
            this.txtUnidadeSolicitacao.TabIndex = 22;
            this.txtUnidadeSolicitacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadeSolicitacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadeSolicitacao_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(319, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Unidade Solicitação";
            // 
            // cboUnidadeSolicitacao
            // 
            this.cboUnidadeSolicitacao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeSolicitacao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeSolicitacao.FormattingEnabled = true;
            this.cboUnidadeSolicitacao.Location = new System.Drawing.Point(361, 142);
            this.cboUnidadeSolicitacao.Name = "cboUnidadeSolicitacao";
            this.cboUnidadeSolicitacao.Size = new System.Drawing.Size(256, 21);
            this.cboUnidadeSolicitacao.TabIndex = 23;
            this.cboUnidadeSolicitacao.SelectedValueChanged += new System.EventHandler(this.cboUnidadeSolicitacao_SelectedValueChanged);
            // 
            // txtUnidadeRequisicao
            // 
            this.txtUnidadeRequisicao.Location = new System.Drawing.Point(10, 143);
            this.txtUnidadeRequisicao.Name = "txtUnidadeRequisicao";
            this.txtUnidadeRequisicao.Size = new System.Drawing.Size(40, 20);
            this.txtUnidadeRequisicao.TabIndex = 19;
            this.txtUnidadeRequisicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadeRequisicao.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadeRequisicao_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Unidade Requisição";
            // 
            // cboUnidadeRequisicao
            // 
            this.cboUnidadeRequisicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeRequisicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeRequisicao.FormattingEnabled = true;
            this.cboUnidadeRequisicao.Location = new System.Drawing.Point(52, 142);
            this.cboUnidadeRequisicao.Name = "cboUnidadeRequisicao";
            this.cboUnidadeRequisicao.Size = new System.Drawing.Size(261, 21);
            this.cboUnidadeRequisicao.TabIndex = 20;
            this.cboUnidadeRequisicao.SelectedValueChanged += new System.EventHandler(this.cboUnidadeRequisicao_SelectedValueChanged);
            // 
            // txtUnidadeIndustria
            // 
            this.txtUnidadeIndustria.Location = new System.Drawing.Point(319, 182);
            this.txtUnidadeIndustria.Name = "txtUnidadeIndustria";
            this.txtUnidadeIndustria.Size = new System.Drawing.Size(40, 20);
            this.txtUnidadeIndustria.TabIndex = 28;
            this.txtUnidadeIndustria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadeIndustria.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadeIndustria_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Unidade Industria";
            // 
            // cboUnidadeIndustria
            // 
            this.cboUnidadeIndustria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeIndustria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeIndustria.FormattingEnabled = true;
            this.cboUnidadeIndustria.Location = new System.Drawing.Point(361, 182);
            this.cboUnidadeIndustria.Name = "cboUnidadeIndustria";
            this.cboUnidadeIndustria.Size = new System.Drawing.Size(256, 21);
            this.cboUnidadeIndustria.TabIndex = 29;
            this.cboUnidadeIndustria.SelectedValueChanged += new System.EventHandler(this.cboUnidadeIndustria_SelectedValueChanged);
            // 
            // txtUnidadeRecebimento
            // 
            this.txtUnidadeRecebimento.Location = new System.Drawing.Point(10, 183);
            this.txtUnidadeRecebimento.Name = "txtUnidadeRecebimento";
            this.txtUnidadeRecebimento.Size = new System.Drawing.Size(40, 20);
            this.txtUnidadeRecebimento.TabIndex = 25;
            this.txtUnidadeRecebimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadeRecebimento.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadeRecebimento_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Unidade Recebimento";
            // 
            // cboUnidadeRecebimento
            // 
            this.cboUnidadeRecebimento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeRecebimento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeRecebimento.FormattingEnabled = true;
            this.cboUnidadeRecebimento.Location = new System.Drawing.Point(52, 182);
            this.cboUnidadeRecebimento.Name = "cboUnidadeRecebimento";
            this.cboUnidadeRecebimento.Size = new System.Drawing.Size(261, 21);
            this.cboUnidadeRecebimento.TabIndex = 26;
            this.cboUnidadeRecebimento.SelectedValueChanged += new System.EventHandler(this.cboUnidadeRecebimento_SelectedValueChanged);
            // 
            // txtUnidadeVenda
            // 
            this.txtUnidadeVenda.Location = new System.Drawing.Point(10, 222);
            this.txtUnidadeVenda.Name = "txtUnidadeVenda";
            this.txtUnidadeVenda.Size = new System.Drawing.Size(40, 20);
            this.txtUnidadeVenda.TabIndex = 31;
            this.txtUnidadeVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnidadeVenda.Validating += new System.ComponentModel.CancelEventHandler(this.txtUnidadeVenda_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Unidade Venda";
            // 
            // cboUnidadeVenda
            // 
            this.cboUnidadeVenda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboUnidadeVenda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboUnidadeVenda.FormattingEnabled = true;
            this.cboUnidadeVenda.Location = new System.Drawing.Point(52, 221);
            this.cboUnidadeVenda.Name = "cboUnidadeVenda";
            this.cboUnidadeVenda.Size = new System.Drawing.Size(261, 21);
            this.cboUnidadeVenda.TabIndex = 32;
            this.cboUnidadeVenda.SelectedValueChanged += new System.EventHandler(this.cboUnidadeVenda_SelectedValueChanged);
            // 
            // frmEstq_SubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.grdEstq_SubGrupo);
            this.Controls.Add(this.panel1);
            this.Name = "frmEstq_SubGrupo";
            this.Text = "Subgrupo de Estoque";
            this.Activated += new System.EventHandler(this.frmEstq_SubGrupo_Activated);
            this.Load += new System.EventHandler(this.frmEstq_SubGrupo_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdEstq_SubGrupo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstq_SubGrupo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdEstq_SubGrupo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtidEstq_Grupo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboEstq_Grupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidEstq_SubGrupo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestq_subgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subgrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_grupo_idEstq_grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn estq_grupo_descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn menor_unidadecontrole;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadepadrao;
        private System.Windows.Forms.TextBox txtMenor_UnidadeControle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMenor_UnidadeControle;
        private System.Windows.Forms.TextBox txtUnidadeVenda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboUnidadeVenda;
        private System.Windows.Forms.TextBox txtUnidadeIndustria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboUnidadeIndustria;
        private System.Windows.Forms.TextBox txtUnidadeRecebimento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboUnidadeRecebimento;
        private System.Windows.Forms.TextBox txtUnidadeSolicitacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboUnidadeSolicitacao;
        private System.Windows.Forms.TextBox txtUnidadeRequisicao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboUnidadeRequisicao;
        private System.Windows.Forms.TextBox txtUnidadePadrao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboUnidadePadrao;
    }
}
