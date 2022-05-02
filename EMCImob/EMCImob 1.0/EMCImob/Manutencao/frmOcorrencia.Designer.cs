namespace EMCImob
{
    partial class frmOcorrencia
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
            this.btnSair = new System.Windows.Forms.Button();
            this.grdOcorrencia = new System.Windows.Forms.DataGridView();
            this.idocorrencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_hota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(763, 7);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // grdOcorrencia
            // 
            this.grdOcorrencia.AllowUserToAddRows = false;
            this.grdOcorrencia.AllowUserToDeleteRows = false;
            this.grdOcorrencia.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdOcorrencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdOcorrencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdOcorrencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdOcorrencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdOcorrencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idocorrencia,
            this.data_hota,
            this.descricao});
            this.grdOcorrencia.Location = new System.Drawing.Point(4, 71);
            this.grdOcorrencia.Name = "grdOcorrencia";
            this.grdOcorrencia.ReadOnly = true;
            this.grdOcorrencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdOcorrencia.Size = new System.Drawing.Size(827, 375);
            this.grdOcorrencia.TabIndex = 7;
            // 
            // idocorrencia
            // 
            this.idocorrencia.HeaderText = "id";
            this.idocorrencia.Name = "idocorrencia";
            this.idocorrencia.ReadOnly = true;
            this.idocorrencia.Width = 30;
            // 
            // data_hota
            // 
            this.data_hota.HeaderText = "Data";
            this.data_hota.Name = "data_hota";
            this.data_hota.ReadOnly = true;
            this.data_hota.Width = 120;
            // 
            // descricao
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.descricao.DefaultCellStyle = dataGridViewCellStyle2;
            this.descricao.HeaderText = "Descricao";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            this.descricao.Width = 600;
            // 
            // frmOcorrencia
            // 
            this.ClientSize = new System.Drawing.Size(835, 452);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grdOcorrencia);
            this.Name = "frmOcorrencia";
            ((System.ComponentModel.ISupportInitialize)(this.grdOcorrencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView grdOcorrencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn idocorrencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_hota;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
    }
}
