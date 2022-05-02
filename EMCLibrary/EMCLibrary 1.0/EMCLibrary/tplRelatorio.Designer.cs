namespace EMCLibrary
{
    partial class tplRelatorio
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
            this.panBotoes = new System.Windows.Forms.Panel();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.panBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBotoes.Controls.Add(this.btnRelatorio);
            this.panBotoes.Controls.Add(this.btnSair);
            this.panBotoes.Controls.Add(this.btnNovo);
            this.panBotoes.Location = new System.Drawing.Point(7, 7);
            this.panBotoes.Name = "panBotoes";
            this.panBotoes.Size = new System.Drawing.Size(629, 68);
            this.panBotoes.TabIndex = 1;
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.Image = global::EMCLibrary.Properties.Resources.printer32x32;
            this.btnRelatorio.Location = new System.Drawing.Point(74, 5);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(68, 58);
            this.btnRelatorio.TabIndex = 7;
            this.btnRelatorio.Text = "Imprimir";
            this.btnRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCLibrary.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(142, 5);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::EMCLibrary.Properties.Resources.ImgNovo;
            this.btnNovo.Location = new System.Drawing.Point(6, 5);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(68, 58);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Limpar";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // tplRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 309);
            this.Controls.Add(this.panBotoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "tplRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.panBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnNovo;
        public System.Windows.Forms.Panel panBotoes;
    }
}