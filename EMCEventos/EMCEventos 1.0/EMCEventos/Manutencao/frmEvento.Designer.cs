namespace EMCEventos
{
    partial class frmEvento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvento));
            this.btnAtualizarAgenda = new System.Windows.Forms.Button();
            this.btnGerarEvento = new System.Windows.Forms.Button();
            this.txtIdAgenda = new System.Windows.Forms.TextBox();
            this.grdAgenda = new System.Windows.Forms.DataGridView();
            this.idevt_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataagenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusevento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idevt_agenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc_tipoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoimovel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDataInicio = new MaskedDateEntryControl.MaskedDateTextBox();
            this.txtDescricaoEvento = new System.Windows.Forms.TextBox();
            this.txtDataFinal = new MaskedDateEntryControl.MaskedDateTextBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdImovel = new System.Windows.Forms.TextBox();
            this.btnImovel = new System.Windows.Forms.Button();
            this.txtImovel = new System.Windows.Forms.TextBox();
            this.txtCodigoImovel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdEvento = new System.Windows.Forms.TextBox();
            this.cldCalendario = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAtualizarAgenda
            // 
            this.btnAtualizarAgenda.Location = new System.Drawing.Point(234, 3);
            this.btnAtualizarAgenda.Name = "btnAtualizarAgenda";
            this.btnAtualizarAgenda.Size = new System.Drawing.Size(99, 50);
            this.btnAtualizarAgenda.TabIndex = 208;
            this.btnAtualizarAgenda.Text = "Mostrar Agenda";
            this.btnAtualizarAgenda.UseVisualStyleBackColor = true;
            this.btnAtualizarAgenda.Click += new System.EventHandler(this.btnAtualizarAgenda_Click);
            // 
            // btnGerarEvento
            // 
            this.btnGerarEvento.Location = new System.Drawing.Point(234, 115);
            this.btnGerarEvento.Name = "btnGerarEvento";
            this.btnGerarEvento.Size = new System.Drawing.Size(99, 50);
            this.btnGerarEvento.TabIndex = 206;
            this.btnGerarEvento.Text = "Gerar Evento";
            this.btnGerarEvento.UseVisualStyleBackColor = true;
            this.btnGerarEvento.Click += new System.EventHandler(this.btnGerarEvento_Click);
            // 
            // txtIdAgenda
            // 
            this.txtIdAgenda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdAgenda.Location = new System.Drawing.Point(646, 2);
            this.txtIdAgenda.MaxLength = 50;
            this.txtIdAgenda.Name = "txtIdAgenda";
            this.txtIdAgenda.Size = new System.Drawing.Size(44, 20);
            this.txtIdAgenda.TabIndex = 205;
            this.txtIdAgenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdAgenda.Visible = false;
            // 
            // grdAgenda
            // 
            this.grdAgenda.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdAgenda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idevt_evento,
            this.dataagenda,
            this.codigoimovel,
            this.descricao,
            this.statusevento,
            this.idevt_agenda,
            this.status,
            this.situacao,
            this.idimovel,
            this.desc_tipoimovel,
            this.tipoimovel});
            this.grdAgenda.Location = new System.Drawing.Point(345, 74);
            this.grdAgenda.MultiSelect = false;
            this.grdAgenda.Name = "grdAgenda";
            this.grdAgenda.ReadOnly = true;
            this.grdAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAgenda.Size = new System.Drawing.Size(771, 435);
            this.grdAgenda.TabIndex = 11;
            this.grdAgenda.DoubleClick += new System.EventHandler(this.grdAgenda_DoubleClick);
            // 
            // idevt_evento
            // 
            this.idevt_evento.DataPropertyName = "idevt_evento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idevt_evento.DefaultCellStyle = dataGridViewCellStyle2;
            this.idevt_evento.HeaderText = "Cód. Evento";
            this.idevt_evento.Name = "idevt_evento";
            this.idevt_evento.ReadOnly = true;
            this.idevt_evento.Visible = false;
            this.idevt_evento.Width = 50;
            // 
            // dataagenda
            // 
            this.dataagenda.DataPropertyName = "dataagenda";
            this.dataagenda.HeaderText = "Data ";
            this.dataagenda.Name = "dataagenda";
            this.dataagenda.ReadOnly = true;
            // 
            // codigoimovel
            // 
            this.codigoimovel.DataPropertyName = "codigoimovel";
            this.codigoimovel.HeaderText = "Cód. Imóvel";
            this.codigoimovel.Name = "codigoimovel";
            this.codigoimovel.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição do Evento";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 450;
            // 
            // statusevento
            // 
            this.statusevento.DataPropertyName = "statusevento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.statusevento.DefaultCellStyle = dataGridViewCellStyle3;
            this.statusevento.HeaderText = "Status";
            this.statusevento.Name = "statusevento";
            this.statusevento.ReadOnly = true;
            this.statusevento.Width = 50;
            // 
            // idevt_agenda
            // 
            this.idevt_agenda.DataPropertyName = "idevt_agenda";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idevt_agenda.DefaultCellStyle = dataGridViewCellStyle4;
            this.idevt_agenda.HeaderText = "Cód. Agenda";
            this.idevt_agenda.Name = "idevt_agenda";
            this.idevt_agenda.ReadOnly = true;
            this.idevt_agenda.Visible = false;
            this.idevt_agenda.Width = 50;
            // 
            // status
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle5;
            this.status.HeaderText = "st";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            this.status.Width = 20;
            // 
            // situacao
            // 
            this.situacao.DataPropertyName = "situacao";
            this.situacao.HeaderText = "Situação";
            this.situacao.Name = "situacao";
            this.situacao.ReadOnly = true;
            this.situacao.Visible = false;
            // 
            // idimovel
            // 
            this.idimovel.DataPropertyName = "idimovel";
            this.idimovel.HeaderText = "IdImovel";
            this.idimovel.Name = "idimovel";
            this.idimovel.ReadOnly = true;
            this.idimovel.Visible = false;
            // 
            // desc_tipoimovel
            // 
            this.desc_tipoimovel.DataPropertyName = "desc_tipoimovel";
            this.desc_tipoimovel.HeaderText = "Imóvel";
            this.desc_tipoimovel.Name = "desc_tipoimovel";
            this.desc_tipoimovel.ReadOnly = true;
            this.desc_tipoimovel.Visible = false;
            // 
            // tipoimovel
            // 
            this.tipoimovel.DataPropertyName = "tipoimovel";
            this.tipoimovel.HeaderText = "TipoImovel";
            this.tipoimovel.Name = "tipoimovel";
            this.tipoimovel.ReadOnly = true;
            this.tipoimovel.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtDataInicio);
            this.panel2.Controls.Add(this.txtDescricaoEvento);
            this.panel2.Controls.Add(this.txtDataFinal);
            this.panel2.Controls.Add(this.lblSituacao);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtIdImovel);
            this.panel2.Controls.Add(this.btnImovel);
            this.panel2.Controls.Add(this.txtImovel);
            this.panel2.Controls.Add(this.txtCodigoImovel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(2, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 262);
            this.panel2.TabIndex = 16;
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.DateValue = null;
            this.txtDataInicio.Location = new System.Drawing.Point(3, 56);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.RequireValidEntry = true;
            this.txtDataInicio.Size = new System.Drawing.Size(88, 20);
            this.txtDataInicio.TabIndex = 5;
            // 
            // txtDescricaoEvento
            // 
            this.txtDescricaoEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoEvento.Location = new System.Drawing.Point(3, 95);
            this.txtDescricaoEvento.MaxLength = 100;
            this.txtDescricaoEvento.Multiline = true;
            this.txtDescricaoEvento.Name = "txtDescricaoEvento";
            this.txtDescricaoEvento.Size = new System.Drawing.Size(330, 91);
            this.txtDescricaoEvento.TabIndex = 7;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.DateValue = null;
            this.txtDataFinal.Location = new System.Drawing.Point(94, 56);
            this.txtDataFinal.Mask = "00/00/0000";
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.RequireValidEntry = true;
            this.txtDataFinal.Size = new System.Drawing.Size(88, 20);
            this.txtDataFinal.TabIndex = 6;
            this.txtDataFinal.Validating += new System.ComponentModel.CancelEventHandler(this.txtDataFinal_Validating);
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(3, 222);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(80, 20);
            this.lblSituacao.TabIndex = 15;
            this.lblSituacao.Text = "Situação";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Código do Imóvel";
            // 
            // txtIdImovel
            // 
            this.txtIdImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdImovel.Location = new System.Drawing.Point(152, -3);
            this.txtIdImovel.MaxLength = 50;
            this.txtIdImovel.Name = "txtIdImovel";
            this.txtIdImovel.Size = new System.Drawing.Size(44, 20);
            this.txtIdImovel.TabIndex = 204;
            this.txtIdImovel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdImovel.Visible = false;
            // 
            // btnImovel
            // 
            this.btnImovel.Image = ((System.Drawing.Image)(resources.GetObject("btnImovel.Image")));
            this.btnImovel.Location = new System.Drawing.Point(122, 17);
            this.btnImovel.Name = "btnImovel";
            this.btnImovel.Size = new System.Drawing.Size(30, 22);
            this.btnImovel.TabIndex = 3;
            this.btnImovel.UseVisualStyleBackColor = true;
            this.btnImovel.Click += new System.EventHandler(this.btnImovel_Click);
            // 
            // txtImovel
            // 
            this.txtImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImovel.Location = new System.Drawing.Point(152, 18);
            this.txtImovel.MaxLength = 50;
            this.txtImovel.Name = "txtImovel";
            this.txtImovel.Size = new System.Drawing.Size(181, 20);
            this.txtImovel.TabIndex = 4;
            // 
            // txtCodigoImovel
            // 
            this.txtCodigoImovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigoImovel.Location = new System.Drawing.Point(3, 18);
            this.txtCodigoImovel.MaxLength = 50;
            this.txtCodigoImovel.Name = "txtCodigoImovel";
            this.txtCodigoImovel.Size = new System.Drawing.Size(119, 20);
            this.txtCodigoImovel.TabIndex = 2;
            this.txtCodigoImovel.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoImovel_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Descrição";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Data Início";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Data Final";
            // 
            // txtIdEvento
            // 
            this.txtIdEvento.Location = new System.Drawing.Point(1023, 74);
            this.txtIdEvento.Name = "txtIdEvento";
            this.txtIdEvento.Size = new System.Drawing.Size(74, 20);
            this.txtIdEvento.TabIndex = 1;
            this.txtIdEvento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEvento_Validating);
            // 
            // cldCalendario
            // 
            this.cldCalendario.BackColor = System.Drawing.SystemColors.Window;
            this.cldCalendario.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cldCalendario.Location = new System.Drawing.Point(4, 3);
            this.cldCalendario.Name = "cldCalendario";
            this.cldCalendario.ShowTodayCircle = false;
            this.cldCalendario.TabIndex = 10;
            this.cldCalendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cldCalendario_DateChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cldCalendario);
            this.panel1.Controls.Add(this.btnAtualizarAgenda);
            this.panel1.Controls.Add(this.btnGerarEvento);
            this.panel1.Location = new System.Drawing.Point(2, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 170);
            this.panel1.TabIndex = 209;
            // 
            // frmEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1120, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtIdAgenda);
            this.Controls.Add(this.grdAgenda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtIdEvento);
            this.Name = "frmEvento";
            this.Text = "Eventos";
            this.Load += new System.EventHandler(this.frmEvento_Load);
            this.Controls.SetChildIndex(this.txtIdEvento, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.grdAgenda, 0);
            this.Controls.SetChildIndex(this.txtIdAgenda, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenda)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAgenda;
        private System.Windows.Forms.MonthCalendar cldCalendario;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescricaoEvento;
        private System.Windows.Forms.TextBox txtIdEvento;
        private System.Windows.Forms.TextBox txtCodigoImovel;
        private System.Windows.Forms.Button btnImovel;
        private System.Windows.Forms.TextBox txtImovel;
        private System.Windows.Forms.TextBox txtIdImovel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdAgenda;
        private System.Windows.Forms.Button btnGerarEvento;
        private System.Windows.Forms.Button btnAtualizarAgenda;
        private System.Windows.Forms.Panel panel1;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataInicio;
        private MaskedDateEntryControl.MaskedDateTextBox txtDataFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataagenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusevento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_agenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc_tipoimovel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoimovel;

    }
}
