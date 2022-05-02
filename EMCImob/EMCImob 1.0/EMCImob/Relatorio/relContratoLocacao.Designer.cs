namespace EMCImob.Relatorios
{
    partial class relContratoLocacao
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
            this.btnParcelasVencidas = new System.Windows.Forms.Button();
            this.btnExtratoContrato = new System.Windows.Forms.Button();
            this.btnProventosContrato = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.Size = new System.Drawing.Size(382, 68);
            // 
            // btnParcelasVencidas
            // 
            this.btnParcelasVencidas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnParcelasVencidas.Location = new System.Drawing.Point(7, 29);
            this.btnParcelasVencidas.Name = "btnParcelasVencidas";
            this.btnParcelasVencidas.Size = new System.Drawing.Size(119, 28);
            this.btnParcelasVencidas.TabIndex = 2;
            this.btnParcelasVencidas.Text = "Parcelas Vencidas";
            this.btnParcelasVencidas.UseVisualStyleBackColor = true;
            this.btnParcelasVencidas.Click += new System.EventHandler(this.btnParcelasVencidas_Click);
            // 
            // btnExtratoContrato
            // 
            this.btnExtratoContrato.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExtratoContrato.Location = new System.Drawing.Point(132, 29);
            this.btnExtratoContrato.Name = "btnExtratoContrato";
            this.btnExtratoContrato.Size = new System.Drawing.Size(119, 28);
            this.btnExtratoContrato.TabIndex = 3;
            this.btnExtratoContrato.Text = "Extrato Contrato";
            this.btnExtratoContrato.UseVisualStyleBackColor = true;
            this.btnExtratoContrato.Click += new System.EventHandler(this.btnExtratoContrato_Click);
            // 
            // btnProventosContrato
            // 
            this.btnProventosContrato.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProventosContrato.Location = new System.Drawing.Point(257, 29);
            this.btnProventosContrato.Name = "btnProventosContrato";
            this.btnProventosContrato.Size = new System.Drawing.Size(119, 28);
            this.btnProventosContrato.TabIndex = 4;
            this.btnProventosContrato.Text = "Proventos Contrato";
            this.btnProventosContrato.UseVisualStyleBackColor = true;
            this.btnProventosContrato.Click += new System.EventHandler(this.btnProventosContrato_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParcelasVencidas);
            this.groupBox1.Controls.Add(this.btnProventosContrato);
            this.groupBox1.Controls.Add(this.btnExtratoContrato);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(7, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar";
            // 
            // relContratoLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 157);
            this.Controls.Add(this.groupBox1);
            this.Name = "relContratoLocacao";
            this.Text = "Relatório de Contratos";
            this.Controls.SetChildIndex(this.panBotoes, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnParcelasVencidas;
        private System.Windows.Forms.Button btnExtratoContrato;
        private System.Windows.Forms.Button btnProventosContrato;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}