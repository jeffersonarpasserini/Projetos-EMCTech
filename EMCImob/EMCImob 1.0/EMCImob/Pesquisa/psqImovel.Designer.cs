namespace EMCImob
{
    partial class psqImovel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(psqImovel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grdPsqImovel = new System.Windows.Forms.DataGridView();
            this.idimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carteiraimoveis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrocep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anotacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorvenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valoraluguel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorcondominio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecochave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matriculacri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaconstruida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproprietario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcarteira = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcontacusto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodImovel = new System.Windows.Forms.TextBox();
            this.chkCarteiraImoveis = new System.Windows.Forms.CheckBox();
            this.chkTipoImovel = new System.Windows.Forms.CheckBox();
            this.btnBuscaCep = new System.Windows.Forms.Button();
            this.lblCep = new System.Windows.Forms.Label();
            this.txtidCep = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboCarteiraImoveis = new System.Windows.Forms.ComboBox();
            this.cboTipoImovel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtIdEmpresa = new System.Windows.Forms.TextBox();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqImovel)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 63);
            this.panel1.TabIndex = 30;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 14;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisa.Image")));
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 13;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grdPsqImovel
            // 
            this.grdPsqImovel.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqImovel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqImovel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPsqImovel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqImovel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idimovel,
            this.codigoimovel,
            this.idempresa,
            this.tipoimovel,
            this.carteiraimoveis,
            this.nrocep,
            this.rua,
            this.numero,
            this.complemento,
            this.cidade,
            this.bairro,
            this.estado,
            this.idtipoimovel,
            this.descricaoimovel,
            this.anotacoes,
            this.observacoes,
            this.valorvenda,
            this.valoraluguel,
            this.valorcondominio,
            this.enderecochave,
            this.matriculacri,
            this.areaconstruida,
            this.codigoempresa,
            this.idproprietario,
            this.idcarteira,
            this.idcontacusto,
            this.situacao,
            this.idcep});
            this.grdPsqImovel.Location = new System.Drawing.Point(0, 184);
            this.grdPsqImovel.Name = "grdPsqImovel";
            this.grdPsqImovel.ReadOnly = true;
            this.grdPsqImovel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqImovel.Size = new System.Drawing.Size(572, 127);
            this.grdPsqImovel.TabIndex = 32;
            this.grdPsqImovel.DoubleClick += new System.EventHandler(this.grdPsqImovel_DoubleClick);
            // 
            // idimovel
            // 
            this.idimovel.DataPropertyName = "idimovel";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idimovel.DefaultCellStyle = dataGridViewCellStyle2;
            this.idimovel.HeaderText = "Código";
            this.idimovel.Name = "idimovel";
            this.idimovel.ReadOnly = true;
            this.idimovel.Visible = false;
            this.idimovel.Width = 65;
            // 
            // codigoimovel
            // 
            this.codigoimovel.DataPropertyName = "codigoimovel";
            this.codigoimovel.HeaderText = "Cód. Imóvel";
            this.codigoimovel.Name = "codigoimovel";
            this.codigoimovel.ReadOnly = true;
            this.codigoimovel.Width = 81;
            // 
            // idempresa
            // 
            this.idempresa.DataPropertyName = "idempresa";
            this.idempresa.HeaderText = "Empresa";
            this.idempresa.Name = "idempresa";
            this.idempresa.ReadOnly = true;
            this.idempresa.Width = 73;
            // 
            // tipoimovel
            // 
            this.tipoimovel.DataPropertyName = "desc_tipoimovel";
            this.tipoimovel.HeaderText = "Tipo de Imóvel";
            this.tipoimovel.Name = "tipoimovel";
            this.tipoimovel.ReadOnly = true;
            this.tipoimovel.Width = 94;
            // 
            // carteiraimoveis
            // 
            this.carteiraimoveis.DataPropertyName = "desc_carteira";
            this.carteiraimoveis.HeaderText = "Carteira de Imóveis";
            this.carteiraimoveis.Name = "carteiraimoveis";
            this.carteiraimoveis.ReadOnly = true;
            this.carteiraimoveis.Width = 112;
            // 
            // nrocep
            // 
            this.nrocep.DataPropertyName = "nrocep";
            this.nrocep.HeaderText = "CEP";
            this.nrocep.Name = "nrocep";
            this.nrocep.ReadOnly = true;
            this.nrocep.Width = 53;
            // 
            // rua
            // 
            this.rua.DataPropertyName = "rua";
            this.rua.HeaderText = "Rua";
            this.rua.Name = "rua";
            this.rua.ReadOnly = true;
            this.rua.Width = 52;
            // 
            // numero
            // 
            this.numero.DataPropertyName = "numero";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.numero.DefaultCellStyle = dataGridViewCellStyle3;
            this.numero.HeaderText = "Número";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 69;
            // 
            // complemento
            // 
            this.complemento.DataPropertyName = "complemento";
            this.complemento.HeaderText = "Complemento";
            this.complemento.Name = "complemento";
            this.complemento.ReadOnly = true;
            this.complemento.Width = 96;
            // 
            // cidade
            // 
            this.cidade.DataPropertyName = "cidade";
            this.cidade.HeaderText = "Cidade";
            this.cidade.Name = "cidade";
            this.cidade.ReadOnly = true;
            this.cidade.Width = 65;
            // 
            // bairro
            // 
            this.bairro.DataPropertyName = "bairro";
            this.bairro.HeaderText = "Bairro";
            this.bairro.Name = "bairro";
            this.bairro.ReadOnly = true;
            this.bairro.Width = 59;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.estado.DefaultCellStyle = dataGridViewCellStyle4;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 65;
            // 
            // idtipoimovel
            // 
            this.idtipoimovel.DataPropertyName = "idtipoimovel";
            this.idtipoimovel.HeaderText = "IdTipoImovel";
            this.idtipoimovel.Name = "idtipoimovel";
            this.idtipoimovel.ReadOnly = true;
            this.idtipoimovel.Visible = false;
            this.idtipoimovel.Width = 93;
            // 
            // descricaoimovel
            // 
            this.descricaoimovel.DataPropertyName = "descricao";
            this.descricaoimovel.HeaderText = "descricao imovel";
            this.descricaoimovel.Name = "descricaoimovel";
            this.descricaoimovel.ReadOnly = true;
            this.descricaoimovel.Visible = false;
            this.descricaoimovel.Width = 102;
            // 
            // anotacoes
            // 
            this.anotacoes.DataPropertyName = "anotacoes";
            this.anotacoes.HeaderText = "Anotações";
            this.anotacoes.Name = "anotacoes";
            this.anotacoes.ReadOnly = true;
            this.anotacoes.Visible = false;
            this.anotacoes.Width = 83;
            // 
            // observacoes
            // 
            this.observacoes.DataPropertyName = "observacoes";
            this.observacoes.HeaderText = "Observações";
            this.observacoes.Name = "observacoes";
            this.observacoes.ReadOnly = true;
            this.observacoes.Visible = false;
            this.observacoes.Width = 95;
            // 
            // valorvenda
            // 
            this.valorvenda.DataPropertyName = "valorvenda";
            this.valorvenda.HeaderText = "Valor Venda";
            this.valorvenda.Name = "valorvenda";
            this.valorvenda.ReadOnly = true;
            this.valorvenda.Visible = false;
            this.valorvenda.Width = 83;
            // 
            // valoraluguel
            // 
            this.valoraluguel.DataPropertyName = "valoraluguel";
            this.valoraluguel.HeaderText = "Valor aluguel";
            this.valoraluguel.Name = "valoraluguel";
            this.valoraluguel.ReadOnly = true;
            this.valoraluguel.Visible = false;
            this.valoraluguel.Width = 86;
            // 
            // valorcondominio
            // 
            this.valorcondominio.DataPropertyName = "valorcondominio";
            this.valorcondominio.HeaderText = "Valor Condominio";
            this.valorcondominio.Name = "valorcondominio";
            this.valorcondominio.ReadOnly = true;
            this.valorcondominio.Visible = false;
            this.valorcondominio.Width = 105;
            // 
            // enderecochave
            // 
            this.enderecochave.DataPropertyName = "enderecochave";
            this.enderecochave.HeaderText = "Endereço Chave";
            this.enderecochave.Name = "enderecochave";
            this.enderecochave.ReadOnly = true;
            this.enderecochave.Visible = false;
            this.enderecochave.Width = 103;
            // 
            // matriculacri
            // 
            this.matriculacri.DataPropertyName = "matriculacri";
            this.matriculacri.HeaderText = "Matricula";
            this.matriculacri.Name = "matriculacri";
            this.matriculacri.ReadOnly = true;
            this.matriculacri.Visible = false;
            this.matriculacri.Width = 75;
            // 
            // areaconstruida
            // 
            this.areaconstruida.DataPropertyName = "areaconstruida";
            this.areaconstruida.HeaderText = "Area";
            this.areaconstruida.Name = "areaconstruida";
            this.areaconstruida.ReadOnly = true;
            this.areaconstruida.Visible = false;
            this.areaconstruida.Width = 54;
            // 
            // codigoempresa
            // 
            this.codigoempresa.DataPropertyName = "codempresa";
            this.codigoempresa.HeaderText = "Empresa";
            this.codigoempresa.Name = "codigoempresa";
            this.codigoempresa.ReadOnly = true;
            this.codigoempresa.Visible = false;
            this.codigoempresa.Width = 73;
            // 
            // idproprietario
            // 
            this.idproprietario.DataPropertyName = "idproprietario";
            this.idproprietario.HeaderText = "Proprietario";
            this.idproprietario.Name = "idproprietario";
            this.idproprietario.ReadOnly = true;
            this.idproprietario.Visible = false;
            this.idproprietario.Width = 85;
            // 
            // idcarteira
            // 
            this.idcarteira.DataPropertyName = "idcarteiraimoveis";
            this.idcarteira.HeaderText = "Carteira";
            this.idcarteira.Name = "idcarteira";
            this.idcarteira.ReadOnly = true;
            this.idcarteira.Visible = false;
            this.idcarteira.Width = 68;
            // 
            // idcontacusto
            // 
            this.idcontacusto.DataPropertyName = "idcontacusto";
            this.idcontacusto.HeaderText = "Conta custo";
            this.idcontacusto.Name = "idcontacusto";
            this.idcontacusto.ReadOnly = true;
            this.idcontacusto.Visible = false;
            this.idcontacusto.Width = 82;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Visible = false;
            this.situacao.Width = 74;
            // 
            // idcep
            // 
            this.idcep.DataPropertyName = "idcep";
            this.idcep.HeaderText = "idcep";
            this.idcep.Name = "idcep";
            this.idcep.ReadOnly = true;
            this.idcep.Visible = false;
            this.idcep.Width = 58;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtCodImovel);
            this.panel3.Controls.Add(this.chkCarteiraImoveis);
            this.panel3.Controls.Add(this.chkTipoImovel);
            this.panel3.Controls.Add(this.btnBuscaCep);
            this.panel3.Controls.Add(this.lblCep);
            this.panel3.Controls.Add(this.txtidCep);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.cboCarteiraImoveis);
            this.panel3.Controls.Add(this.cboTipoImovel);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtRua);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtNumero);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtComplemento);
            this.panel3.Controls.Add(this.txtBairro);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtCidade);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtEstado);
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 116);
            this.panel3.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 252;
            this.label1.Text = "Cód. Imóvel";
            // 
            // txtCodImovel
            // 
            this.txtCodImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodImovel.Location = new System.Drawing.Point(2, 19);
            this.txtCodImovel.MaxLength = 50;
            this.txtCodImovel.Name = "txtCodImovel";
            this.txtCodImovel.Size = new System.Drawing.Size(114, 20);
            this.txtCodImovel.TabIndex = 123;
            // 
            // chkCarteiraImoveis
            // 
            this.chkCarteiraImoveis.AutoSize = true;
            this.chkCarteiraImoveis.Checked = true;
            this.chkCarteiraImoveis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCarteiraImoveis.Location = new System.Drawing.Point(460, 25);
            this.chkCarteiraImoveis.Name = "chkCarteiraImoveis";
            this.chkCarteiraImoveis.Size = new System.Drawing.Size(114, 17);
            this.chkCarteiraImoveis.TabIndex = 251;
            this.chkCarteiraImoveis.Text = "Todas as Carteiras";
            this.chkCarteiraImoveis.UseVisualStyleBackColor = true;
            // 
            // chkTipoImovel
            // 
            this.chkTipoImovel.AutoSize = true;
            this.chkTipoImovel.Checked = true;
            this.chkTipoImovel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTipoImovel.Location = new System.Drawing.Point(460, 4);
            this.chkTipoImovel.Name = "chkTipoImovel";
            this.chkTipoImovel.Size = new System.Drawing.Size(109, 17);
            this.chkTipoImovel.TabIndex = 123;
            this.chkTipoImovel.Text = "Todos os Imóveis";
            this.chkTipoImovel.UseVisualStyleBackColor = true;
            // 
            // btnBuscaCep
            // 
            this.btnBuscaCep.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaCep.Image")));
            this.btnBuscaCep.Location = new System.Drawing.Point(86, 54);
            this.btnBuscaCep.Name = "btnBuscaCep";
            this.btnBuscaCep.Size = new System.Drawing.Size(30, 22);
            this.btnBuscaCep.TabIndex = 9;
            this.btnBuscaCep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscaCep.UseVisualStyleBackColor = true;
            this.btnBuscaCep.Click += new System.EventHandler(this.btnBuscaCep_Click);
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(3, 41);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(26, 13);
            this.lblCep.TabIndex = 233;
            this.lblCep.Text = "Cep";
            // 
            // txtidCep
            // 
            this.txtidCep.Location = new System.Drawing.Point(2, 55);
            this.txtidCep.Mask = "00000-999";
            this.txtidCep.Name = "txtidCep";
            this.txtidCep.PromptChar = ' ';
            this.txtidCep.Size = new System.Drawing.Size(83, 20);
            this.txtidCep.TabIndex = 8;
            this.txtidCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtidCep.Validating += new System.ComponentModel.CancelEventHandler(this.txtidCep_Validating);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(285, 3);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 143;
            this.label24.Text = "Carteira";
            // 
            // cboCarteiraImoveis
            // 
            this.cboCarteiraImoveis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarteiraImoveis.FormattingEnabled = true;
            this.cboCarteiraImoveis.Location = new System.Drawing.Point(285, 19);
            this.cboCarteiraImoveis.Name = "cboCarteiraImoveis";
            this.cboCarteiraImoveis.Size = new System.Drawing.Size(154, 21);
            this.cboCarteiraImoveis.TabIndex = 2;
            // 
            // cboTipoImovel
            // 
            this.cboTipoImovel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoImovel.FormattingEnabled = true;
            this.cboTipoImovel.Location = new System.Drawing.Point(118, 19);
            this.cboTipoImovel.Name = "cboTipoImovel";
            this.cboTipoImovel.Size = new System.Drawing.Size(166, 21);
            this.cboTipoImovel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 140;
            this.label5.Text = "Tipo de Imóvel";
            // 
            // txtRua
            // 
            this.txtRua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRua.Location = new System.Drawing.Point(2, 91);
            this.txtRua.MaxLength = 50;
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(312, 20);
            this.txtRua.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 170;
            this.label4.Text = "Endereço";
            // 
            // txtNumero
            // 
            this.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Location = new System.Drawing.Point(316, 91);
            this.txtNumero.MaxLength = 10;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(53, 20);
            this.txtNumero.TabIndex = 14;
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 190;
            this.label3.Text = "Número";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(370, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 220;
            this.label7.Text = "Complemento";
            // 
            // txtComplemento
            // 
            this.txtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtComplemento.Location = new System.Drawing.Point(372, 91);
            this.txtComplemento.MaxLength = 25;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(193, 20);
            this.txtComplemento.TabIndex = 15;
            // 
            // txtBairro
            // 
            this.txtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBairro.Location = new System.Drawing.Point(396, 55);
            this.txtBairro.MaxLength = 25;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(170, 20);
            this.txtBairro.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 230;
            this.label8.Text = "Bairro";
            // 
            // txtCidade
            // 
            this.txtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCidade.Location = new System.Drawing.Point(117, 55);
            this.txtCidade.MaxLength = 50;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCidade.Size = new System.Drawing.Size(242, 20);
            this.txtCidade.TabIndex = 10;
            this.txtCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 240;
            this.label9.Text = "Cidade";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(360, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 250;
            this.label10.Text = "UF";
            // 
            // txtEstado
            // 
            this.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstado.Location = new System.Drawing.Point(361, 55);
            this.txtEstado.MaxLength = 2;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(32, 20);
            this.txtEstado.TabIndex = 11;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIdEmpresa
            // 
            this.txtIdEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdEmpresa.Location = new System.Drawing.Point(501, 43);
            this.txtIdEmpresa.MaxLength = 50;
            this.txtIdEmpresa.Name = "txtIdEmpresa";
            this.txtIdEmpresa.Size = new System.Drawing.Size(44, 20);
            this.txtIdEmpresa.TabIndex = 253;
            this.txtIdEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdEmpresa.Visible = false;
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(530, 4);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(40, 20);
            this.txtIdImovel.TabIndex = 122;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // psqImovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 313);
            this.Controls.Add(this.txtIdEmpresa);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtIdImovel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdPsqImovel);
            this.Name = "psqImovel";
            this.Text = "Pesquisa de Imóveis";
            this.Load += new System.EventHandler(this.psqImovel_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqImovel)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdPsqImovel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBuscaCep;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.MaskedTextBox txtidCep;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboCarteiraImoveis;
        private System.Windows.Forms.ComboBox cboTipoImovel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.CheckBox chkCarteiraImoveis;
        private System.Windows.Forms.CheckBox chkTipoImovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn carteiraimoveis;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrocep;
        private System.Windows.Forms.DataGridViewTextBoxColumn rua;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn complemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn bairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn anotacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorvenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn valoraluguel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorcondominio;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecochave;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculacri;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaconstruida;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproprietario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcarteira;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcontacusto;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcep;
        private System.Windows.Forms.TextBox txtIdEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodImovel;
    }
}