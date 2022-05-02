namespace EMCEventos
{
    partial class frmSubLocacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubLocacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdSubLocacao = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIdSubLocacao = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEvento = new System.Windows.Forms.Button();
            this.txtDescEvento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricaoSubLoc = new System.Windows.Forms.TextBox();
            this.txtIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdEvento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idevt_sublocacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idevt_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoevento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubLocacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdSubLocacao
            // 
            this.grdSubLocacao.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdSubLocacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSubLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSubLocacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idevt_sublocacao,
            this.idevt_evento,
            this.descricaoevento,
            this.idbox,
            this.descricao});
            this.grdSubLocacao.Location = new System.Drawing.Point(3, 3);
            this.grdSubLocacao.MultiSelect = false;
            this.grdSubLocacao.Name = "grdSubLocacao";
            this.grdSubLocacao.ReadOnly = true;
            this.grdSubLocacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSubLocacao.Size = new System.Drawing.Size(621, 227);
            this.grdSubLocacao.TabIndex = 12;
            this.grdSubLocacao.DoubleClick += new System.EventHandler(this.grdSubLocacao_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grdSubLocacao);
            this.panel1.Location = new System.Drawing.Point(2, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 235);
            this.panel1.TabIndex = 13;
            // 
            // txtIdSubLocacao
            // 
            this.txtIdSubLocacao.Location = new System.Drawing.Point(3, 20);
            this.txtIdSubLocacao.Name = "txtIdSubLocacao";
            this.txtIdSubLocacao.Size = new System.Drawing.Size(49, 20);
            this.txtIdSubLocacao.TabIndex = 1;
            this.txtIdSubLocacao.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdSubLocacao_Validating);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEvento);
            this.panel2.Controls.Add(this.txtDescEvento);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDescricaoSubLoc);
            this.panel2.Controls.Add(this.txtIdBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtIdEvento);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtIdSubLocacao);
            this.panel2.Location = new System.Drawing.Point(2, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 83);
            this.panel2.TabIndex = 15;
            // 
            // btnEvento
            // 
            this.btnEvento.Image = ((System.Drawing.Image)(resources.GetObject("btnEvento.Image")));
            this.btnEvento.Location = new System.Drawing.Point(104, 19);
            this.btnEvento.Name = "btnEvento";
            this.btnEvento.Size = new System.Drawing.Size(30, 22);
            this.btnEvento.TabIndex = 3;
            this.btnEvento.UseVisualStyleBackColor = true;
            this.btnEvento.Click += new System.EventHandler(this.btnEvento_Click);
            // 
            // txtDescEvento
            // 
            this.txtDescEvento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescEvento.Location = new System.Drawing.Point(135, 20);
            this.txtDescEvento.MaxLength = 50;
            this.txtDescEvento.Name = "txtDescEvento";
            this.txtDescEvento.ReadOnly = true;
            this.txtDescEvento.Size = new System.Drawing.Size(406, 20);
            this.txtDescEvento.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Descrição";
            // 
            // txtDescricaoSubLoc
            // 
            this.txtDescricaoSubLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoSubLoc.Location = new System.Drawing.Point(3, 57);
            this.txtDescricaoSubLoc.Name = "txtDescricaoSubLoc";
            this.txtDescricaoSubLoc.Size = new System.Drawing.Size(621, 20);
            this.txtDescricaoSubLoc.TabIndex = 6;
            // 
            // txtIdBox
            // 
            this.txtIdBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdBox.Location = new System.Drawing.Point(543, 20);
            this.txtIdBox.Name = "txtIdBox";
            this.txtIdBox.Size = new System.Drawing.Size(81, 20);
            this.txtIdBox.TabIndex = 5;
            this.txtIdBox.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdBox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Box";
            // 
            // txtIdEvento
            // 
            this.txtIdEvento.Location = new System.Drawing.Point(54, 20);
            this.txtIdEvento.Name = "txtIdEvento";
            this.txtIdEvento.Size = new System.Drawing.Size(49, 20);
            this.txtIdEvento.TabIndex = 2;
            this.txtIdEvento.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdEvento_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Evento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "SubLoc";
            // 
            // idevt_sublocacao
            // 
            this.idevt_sublocacao.DataPropertyName = "idevt_sublocacao";
            this.idevt_sublocacao.HeaderText = "Cód. SubLoc";
            this.idevt_sublocacao.Name = "idevt_sublocacao";
            this.idevt_sublocacao.ReadOnly = true;
            this.idevt_sublocacao.Visible = false;
            this.idevt_sublocacao.Width = 50;
            // 
            // idevt_evento
            // 
            this.idevt_evento.DataPropertyName = "idevt_evento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idevt_evento.DefaultCellStyle = dataGridViewCellStyle2;
            this.idevt_evento.HeaderText = "Cód. Evento";
            this.idevt_evento.Name = "idevt_evento";
            this.idevt_evento.ReadOnly = true;
            this.idevt_evento.Width = 50;
            // 
            // descricaoevento
            // 
            this.descricaoevento.DataPropertyName = "desc_evento";
            this.descricaoevento.HeaderText = "Evento";
            this.descricaoevento.Name = "descricaoevento";
            this.descricaoevento.ReadOnly = true;
            this.descricaoevento.Width = 110;
            // 
            // idbox
            // 
            this.idbox.DataPropertyName = "idbox";
            this.idbox.HeaderText = "Cód. Box";
            this.idbox.Name = "idbox";
            this.idbox.ReadOnly = true;
            this.idbox.Width = 60;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 350;
            // 
            // frmSubLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(634, 394);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmSubLocacao";
            this.Text = "Sub Locação";
            this.Load += new System.EventHandler(this.frmSubLocacao_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubLocacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdSubLocacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdSubLocacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDescricaoSubLoc;
        private System.Windows.Forms.TextBox txtIdBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdEvento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEvento;
        private System.Windows.Forms.TextBox txtDescEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_sublocacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idevt_evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoevento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
