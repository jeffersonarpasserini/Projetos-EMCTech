namespace EMCLibrary
{
    partial class EMCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMCForm));
            this.panBotoes = new System.Windows.Forms.Panel();
            this.btnOcorrencia = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnBusca = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.ttpEmcForm = new System.Windows.Forms.ToolTip(this.components);
            this.panBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBotoes
            // 
            this.panBotoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBotoes.Controls.Add(this.btnOcorrencia);
            this.panBotoes.Controls.Add(this.btnRelatorio);
            this.panBotoes.Controls.Add(this.btnCancela);
            this.panBotoes.Controls.Add(this.btnSair);
            this.panBotoes.Controls.Add(this.btnBusca);
            this.panBotoes.Controls.Add(this.btnExcluir);
            this.panBotoes.Controls.Add(this.btnAtualizar);
            this.panBotoes.Controls.Add(this.btnSalvar);
            this.panBotoes.Controls.Add(this.btnNovo);
            this.panBotoes.Location = new System.Drawing.Point(2, 2);
            this.panBotoes.Name = "panBotoes";
            this.panBotoes.Size = new System.Drawing.Size(629, 68);
            this.panBotoes.TabIndex = 0;
            // 
            // btnOcorrencia
            // 
            this.btnOcorrencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcorrencia.Image = global::EMCLibrary.Properties.Resources.ocorrencia;
            this.btnOcorrencia.Location = new System.Drawing.Point(488, 5);
            this.btnOcorrencia.Name = "btnOcorrencia";
            this.btnOcorrencia.Size = new System.Drawing.Size(68, 58);
            this.btnOcorrencia.TabIndex = 107;
            this.btnOcorrencia.Text = "Eventos";
            this.btnOcorrencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOcorrencia.UseVisualStyleBackColor = true;
            this.btnOcorrencia.Click += new System.EventHandler(this.btnOcorrencia_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.Image = global::EMCLibrary.Properties.Resources.printer32x32;
            this.btnRelatorio.Location = new System.Drawing.Point(420, 5);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(68, 58);
            this.btnRelatorio.TabIndex = 106;
            this.btnRelatorio.Text = "Imprimir";
            this.btnRelatorio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancela.Image = global::EMCLibrary.Properties.Resources.ImgCancel;
            this.btnCancela.Location = new System.Drawing.Point(351, 5);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(68, 58);
            this.btnCancela.TabIndex = 105;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnCancela, "Cancela Operação [F12]");
            this.btnCancela.UseVisualStyleBackColor = true;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::EMCLibrary.Properties.Resources.ImgFechar;
            this.btnSair.Location = new System.Drawing.Point(557, 5);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(68, 58);
            this.btnSair.TabIndex = 108;
            this.btnSair.Text = "Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnSair, "Fecha o Formulário");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnBusca
            // 
            this.btnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusca.Image = global::EMCLibrary.Properties.Resources.ImgBuscar;
            this.btnBusca.Location = new System.Drawing.Point(282, 5);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(68, 58);
            this.btnBusca.TabIndex = 104;
            this.btnBusca.Text = "Buscar";
            this.btnBusca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnBusca, "Busca um Registro [F8]");
            this.btnBusca.UseVisualStyleBackColor = true;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::EMCLibrary.Properties.Resources.Excluir;
            this.btnExcluir.Location = new System.Drawing.Point(213, 5);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(68, 58);
            this.btnExcluir.TabIndex = 103;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnExcluir, "Exclui Registro [F5]");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Image = global::EMCLibrary.Properties.Resources.right;
            this.btnAtualizar.Location = new System.Drawing.Point(144, 5);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(68, 58);
            this.btnAtualizar.TabIndex = 102;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnAtualizar, "Atualiza Registro [F4]");
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = global::EMCLibrary.Properties.Resources.ImgSalvar;
            this.btnSalvar.Location = new System.Drawing.Point(75, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(68, 58);
            this.btnSalvar.TabIndex = 101;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnSalvar, "Salva Novo Registro [F3]");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Image = global::EMCLibrary.Properties.Resources.ImgNovo;
            this.btnNovo.Location = new System.Drawing.Point(6, 5);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(68, 58);
            this.btnNovo.TabIndex = 100;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ttpEmcForm.SetToolTip(this.btnNovo, "Novo Registro [F2]");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // EMCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 329);
            this.Controls.Add(this.panBotoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EMCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMCForm";
            this.Load += new System.EventHandler(this.EMCForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EMCForm_KeyDown);
            this.panBotoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBotoes;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.ToolTip ttpEmcForm;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnOcorrencia;
    }
}