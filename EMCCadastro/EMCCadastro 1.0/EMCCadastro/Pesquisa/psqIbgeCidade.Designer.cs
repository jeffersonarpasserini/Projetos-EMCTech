namespace EMCCadastro
{
    partial class psqIbgeCidade
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNomeCidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoIbge = new MaskedNumber.MaskedNumber();
            this.txtCNPJCPF = new System.Windows.Forms.TextBox();
            this.grdPsqIbgeCidade = new System.Windows.Forms.DataGridView();
            this.ttpPsqIbgeCidade = new System.Windows.Forms.ToolTip(this.components);
            this.idestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idibgecidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoibge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqIbgeCidade)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancela);
            this.panel1.Controls.Add(this.btnPesquisa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 63);
            this.panel1.TabIndex = 16;
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCCadastro.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(139, 3);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 3;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqIbgeCidade.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisa.Image = global::EMCCadastro.Properties.Resources.binoculo_32x32;
            this.btnPesquisa.Location = new System.Drawing.Point(71, 3);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(68, 58);
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.Text = "Pesquisa";
            this.btnPesquisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqIbgeCidade.SetToolTip(this.btnPesquisa, "Pesquisa um Registro [F8]");
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCCadastro.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(3, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpPsqIbgeCidade.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cboEstado);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNomeCidade);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtCodigoIbge);
            this.panel2.Controls.Add(this.txtCNPJCPF);
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 55);
            this.panel2.TabIndex = 17;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(452, 23);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(53, 21);
            this.cboEstado.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Estado";
            // 
            // txtNomeCidade
            // 
            this.txtNomeCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomeCidade.Location = new System.Drawing.Point(107, 24);
            this.txtNomeCidade.MaxLength = 45;
            this.txtNomeCidade.Name = "txtNomeCidade";
            this.txtNomeCidade.Size = new System.Drawing.Size(336, 20);
            this.txtNomeCidade.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nome Cidade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Código IBGE";
            // 
            // txtCodigoIbge
            // 
            this.txtCodigoIbge.CustomFormat = "0000000";
            this.txtCodigoIbge.Format = MaskedNumberFormat.Custom;
            this.txtCodigoIbge.Location = new System.Drawing.Point(7, 24);
            this.txtCodigoIbge.MaxLength = 7;
            this.txtCodigoIbge.Name = "txtCodigoIbge";
            this.txtCodigoIbge.Size = new System.Drawing.Size(91, 20);
            this.txtCodigoIbge.TabIndex = 17;
            this.txtCodigoIbge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCNPJCPF
            // 
            this.txtCNPJCPF.Location = new System.Drawing.Point(671, 82);
            this.txtCNPJCPF.Name = "txtCNPJCPF";
            this.txtCNPJCPF.Size = new System.Drawing.Size(160, 20);
            this.txtCNPJCPF.TabIndex = 10;
            // 
            // grdPsqIbgeCidade
            // 
            this.grdPsqIbgeCidade.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdPsqIbgeCidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPsqIbgeCidade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPsqIbgeCidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdPsqIbgeCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPsqIbgeCidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idestado,
            this.idibgecidade,
            this.codigoibge,
            this.nomecidade,
            this.estado});
            this.grdPsqIbgeCidade.Location = new System.Drawing.Point(1, 125);
            this.grdPsqIbgeCidade.MultiSelect = false;
            this.grdPsqIbgeCidade.Name = "grdPsqIbgeCidade";
            this.grdPsqIbgeCidade.ReadOnly = true;
            this.grdPsqIbgeCidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPsqIbgeCidade.Size = new System.Drawing.Size(520, 253);
            this.grdPsqIbgeCidade.TabIndex = 22;
            this.grdPsqIbgeCidade.DoubleClick += new System.EventHandler(this.grdPsqIbgeCidade_DoubleClick);
            // 
            // idestado
            // 
            this.idestado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idestado.DataPropertyName = "idestado";
            this.idestado.HeaderText = "Código Estado";
            this.idestado.Name = "idestado";
            this.idestado.ReadOnly = true;
            // 
            // idibgecidade
            // 
            this.idibgecidade.DataPropertyName = "idibgecidade";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.idibgecidade.DefaultCellStyle = dataGridViewCellStyle2;
            this.idibgecidade.HeaderText = "Código";
            this.idibgecidade.Name = "idibgecidade";
            this.idibgecidade.ReadOnly = true;
            this.idibgecidade.Visible = false;
            this.idibgecidade.Width = 65;
            // 
            // codigoibge
            // 
            this.codigoibge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.codigoibge.DataPropertyName = "codigoibge";
            this.codigoibge.HeaderText = "Código IBGE";
            this.codigoibge.Name = "codigoibge";
            this.codigoibge.ReadOnly = true;
            // 
            // nomecidade
            // 
            this.nomecidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nomecidade.DataPropertyName = "nomecidade";
            this.nomecidade.HeaderText = "Cidade";
            this.nomecidade.Name = "nomecidade";
            this.nomecidade.ReadOnly = true;
            this.nomecidade.Width = 177;
            // 
            // estado
            // 
            this.estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // psqIbgeCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 378);
            this.Controls.Add(this.grdPsqIbgeCidade);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "psqIbgeCidade";
            this.Text = "Pesquisa - IBGE Cidade";
            this.Load += new System.EventHandler(this.psqIbgeCidade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psqIbgeCidade_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPsqIbgeCidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCNPJCPF;
        private System.Windows.Forms.DataGridView grdPsqIbgeCidade;
        private MaskedNumber.MaskedNumber txtCodigoIbge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCidade;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip ttpPsqIbgeCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn idestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idibgecidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoibge;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
    }
}