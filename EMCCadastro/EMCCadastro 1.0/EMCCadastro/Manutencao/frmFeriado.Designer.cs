namespace EMCCadastro
{
    partial class frmFeriado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidFeriado = new System.Windows.Forms.TextBox();
            this.txtDataFeriado = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.grdFeriado = new System.Windows.Forms.DataGridView();
            this.idferiados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataferiado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeriado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtidFeriado);
            this.panel1.Controls.Add(this.txtDataFeriado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescricao);
            this.panel1.Location = new System.Drawing.Point(2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 51);
            this.panel1.TabIndex = 4;
            // 
            // txtidFeriado
            // 
            this.txtidFeriado.Location = new System.Drawing.Point(389, 4);
            this.txtidFeriado.Name = "txtidFeriado";
            this.txtidFeriado.Size = new System.Drawing.Size(123, 20);
            this.txtidFeriado.TabIndex = 0;
            this.txtidFeriado.Visible = false;
            this.txtidFeriado.Validating += new System.ComponentModel.CancelEventHandler(this.txtidFeriado_Validating);
            // 
            // txtDataFeriado
            // 
            this.txtDataFeriado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataFeriado.Location = new System.Drawing.Point(3, 23);
            this.txtDataFeriado.Name = "txtDataFeriado";
            this.txtDataFeriado.Size = new System.Drawing.Size(107, 20);
            this.txtDataFeriado.TabIndex = 1;
            this.txtDataFeriado.Validating += new System.ComponentModel.CancelEventHandler(this.txtDataFeriado_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descrição";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Feriado";
            // 
            // txtDescricao
            // 
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Location = new System.Drawing.Point(113, 23);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(502, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // grdFeriado
            // 
            this.grdFeriado.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdFeriado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFeriado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFeriado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdFeriado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFeriado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idferiados,
            this.dataferiado,
            this.descricao});
            this.grdFeriado.Location = new System.Drawing.Point(2, 130);
            this.grdFeriado.MultiSelect = false;
            this.grdFeriado.Name = "grdFeriado";
            this.grdFeriado.ReadOnly = true;
            this.grdFeriado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFeriado.Size = new System.Drawing.Size(626, 195);
            this.grdFeriado.TabIndex = 10;
            this.grdFeriado.DoubleClick += new System.EventHandler(this.grdFeriado_DoubleClick);
            // 
            // idferiados
            // 
            this.idferiados.DataPropertyName = "idferiados";
            this.idferiados.HeaderText = "Código";
            this.idferiados.Name = "idferiados";
            this.idferiados.ReadOnly = true;
            this.idferiados.Width = 65;
            // 
            // dataferiado
            // 
            this.dataferiado.DataPropertyName = "dataferiado";
            this.dataferiado.HeaderText = "Data";
            this.dataferiado.Name = "dataferiado";
            this.dataferiado.ReadOnly = true;
            this.dataferiado.Width = 55;
            // 
            // descricao
            // 
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 80;
            // 
            // frmFeriado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(631, 329);
            this.Controls.Add(this.grdFeriado);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "frmFeriado";
            this.Text = "Feriados";
            this.Load += new System.EventHandler(this.frmFeriado_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.grdFeriado, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeriado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView grdFeriado;
        private System.Windows.Forms.DateTimePicker txtDataFeriado;
        private System.Windows.Forms.TextBox txtidFeriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idferiados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataferiado;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
