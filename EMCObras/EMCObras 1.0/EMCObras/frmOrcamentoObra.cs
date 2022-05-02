using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using EMCSecurityRN;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCCadastro;
using EMCObrasModel;
using EMCObrasRN;
using EMCEstoqueModel;
using FastReport;

namespace EMCObras
{
    public partial class frmOrcamentoObra : Form
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmOrcamentoObra";
        private const string nomeAplicativo = "EMCObras";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        public frmOrcamentoObra()
        {
            InitializeComponent();
        }

         public frmOrcamentoObra(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            
            retPesquisa.codempresa = codempresa;
            retPesquisa.chavebusca = "";
            retPesquisa.chaveinterna = 0;

            InitializeComponent();
        }

         public void CancelaOperacao()
         {
             btnNovo.Enabled = true;
             btnCancela.Enabled = true;
             btnSair.Enabled = true;
             txtAbreviacao.Focus();
             btnAprovaCronograma.Enabled = false;
             LimpaCampos();
         }

         public void LimpaCampos()
         {
             foreach (Control c in Controls)

                 //dentro de um Panel
                 if (c is Panel)
                 {
                     for (int i = 0; i < c.Controls.Count; i++)
                     {
                         if (c.Controls[i].GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                         {
                             (c.Controls[i] as System.Windows.Forms.Sample.DecimalTextBox).Text = "";
                         }
                         if (c.Controls[i] is DateTimePicker)
                         {
                             (c.Controls[i] as DateTimePicker).Text = "";
                         }
                         if (c.Controls[i] is TextBox)
                         {
                             (c.Controls[i] as TextBox).Text = "";
                         }
                         if (c.Controls[i] is MaskedTextBox)
                         {
                             (c.Controls[i] as MaskedTextBox).Text = "";
                         }

                         if (c.Controls[i] is CheckBox)
                         {
                             (c.Controls[i] as CheckBox).Checked = false;
                         }
                     }
                 }
         }
         
         private void frmOrcamentoObra_Load(object sender, EventArgs e)
         {

             objOcorrencia = new Ocorrencia();
             Aplicativo oAplicativo = new Aplicativo();
             oAplicativo.nome = nomeAplicativo;
             objOcorrencia.aplicativo = oAplicativo;
             objOcorrencia.formulario = nomeFormulario;
             objOcorrencia.seqLogin = EmcResources.cInt(login);
             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario = EmcResources.cInt(usuario);
             objOcorrencia.usuario = oUsuario;
             objOcorrencia.tabela = "obra_cronograma";

             //define mudar cor do fundo dos campos
             this.ConfigurarFocoComponentes(this);

             //define se campos entram selecionados
             if (this.AutoSelectOnFocus)
             {
                 this.DelegateEnterFocus(this);
             }

             btnAprovaCronograma.Enabled = false;

             this.ActiveControl = txtAbreviacao;
         }

         public bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
         {
             if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
             {
                 return true;
             }
             else return false;
         }

         public void BuscaObra()
         {

             if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text) || !String.IsNullOrEmpty(txtAbreviacao.Text))
             {

                 Obra oObra = new Obra();
                 oObra.abreviacao = txtAbreviacao.Text;

                 try
                 {
                     ObraRN ObraBLL = new ObraRN(Conexao, objOcorrencia, codempresa);

                     //oObra = montaObra();

                     oObra = ObraBLL.obterPor(oObra);

                     if (oObra.idObra_Cronograma == 0)
                     {
                         DialogResult result = MessageBox.Show("Obra não cadastrada", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                         if (result == DialogResult.Yes)
                         {
                             //LimpaCampos();

                         }
                         else
                         {
                             CancelaOperacao();
                         }
                     }
                     else
                     {
                         txtIdObra_Cronograma.Text = oObra.idObra_Cronograma.ToString();
                         txtDescricaoObra.Text = oObra.descricao;
                         if (oObra.situacao == "A")
                             txtSituacao.Text = "Aberto";
                         else if (oObra.situacao == "E")
                             txtSituacao.Text = "Encerrado";
                         else if (oObra.situacao == "L")
                             txtSituacao.Text = "Aprovado";
                         MontaGrid();

                         if (oObra.situacao == "A")
                         {
                             btnAprovaCronograma.Enabled = true;
                         }
                         else
                         {
                             btnAprovaCronograma.Enabled = false;
                         }

                     }
                     
                 }
                 catch (Exception erro)
                 {
                     MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }

         }
            
        #region Botoes

         private void btnCancela_Click(object sender, EventArgs e)
         {
             CancelaOperacao();
             rdAnalitico.Checked = false;
             rdSintetico.Checked = false;
         }

         private void btnBuscaObra_Click(object sender, EventArgs e)
         {            
             try
             {
                 psqObra ofrm = new psqObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                 ofrm.ShowDialog();

                 if (retPesquisa.chaveinterna == 0)
                 {
                     // txtIdObra_Cronograma.Text = "";
                     //CancelaOperacao();
                 }
                 else
                 {
                     txtAbreviacao.Enabled = true;
                     txtAbreviacao.Text = EMCObras.retPesquisa.chavebusca.ToString();
                     txtAbreviacao.Focus();
                     SendKeys.Send("{TAB}");
                    

                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }

         private void btnSair_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnImprimir_Click(object sender, EventArgs e)
         {

             try
             {
                 Empresa oEmpresa = new Empresa();
                 oEmpresa.idEmpresa = codempresa;
                 EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                 oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                 Obra_PrevisaoDespesaRN oBLL = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                 string drpRelatorio;

                 if (String.IsNullOrEmpty(txtIdObra_Cronograma.Text))
                 {
                    MessageBox.Show("Obra não Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                 }
                 else
                 if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text))
                 {
                     if (rdSintetico.Checked)
                     {
                         drpRelatorio = oBLL.SinteticoObra(EmcResources.cInt(txtIdObra_Cronograma.Text));
                         this.dstOrcamentoObra.Tables["MyTable"].Clear();
                         this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                         if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                         {
                             MessageBox.Show("Registros não encontrados para Obra Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             return;
                         }
                         orcamentoObra.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                         orcamentoObra.Show();
                     }else

                     if (rdAnalitico.Checked)
                     {
                         drpRelatorio = oBLL.AnaliticoObra(EmcResources.cInt(txtIdObra_Cronograma.Text));
                         this.dstOrcamentoObra.Tables["MyTable"].Clear();
                         this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                         if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                         {
                             MessageBox.Show("Registros não encontrados para Obra Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             return;
                         }
                         OrcamentoObraItens.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                         OrcamentoObraItens.Show();
                     }
                 }

             }

             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message);
             }
         }

        #endregion

        #region Métodos da Grid

         private void MontaGrid()
         {
             //carrega a grid com os Obras cadastrados
             Obra_PrevisaoDespesaRN objObra = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
             DataTable dtCon = objObra.listaResumoOrcamento(EmcResources.cInt(txtIdObra_Cronograma.Text));
             grdObra.DataSource = dtCon;
         }

         private void grdObra_DoubleClick(object sender, EventArgs e)
         {
             Obra_PrevisaoDespesaRN objObra = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
             if (EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_cronogramaitem"].Value.ToString()) > 0)
             {
                 DataTable dtCon = objObra.listaDespesasItens(EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_cronogramaitem"].Value.ToString()));
                 grdTarefas.DataSource = dtCon;
             }
             else
             {
                 DataTable dtCon = objObra.listaModuloEtapaObra(EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_modulo"].Value.ToString()), EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_etapa"].Value.ToString()), EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_cronograma"].Value.ToString()));
                 grdTarefas.DataSource = dtCon;
             }
             if (EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_modulo"].Value.ToString()) == 0)
             {
                 DataTable dtCon = objObra.listaModuloEtapaObra(0, EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_etapa"].Value.ToString()), EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_cronograma"].Value.ToString()));
                 grdTarefas.DataSource = dtCon;
             }
             if (EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_etapa"].Value.ToString()) == 0)
             {
                 DataTable dtCon = objObra.listaModuloEtapaObra(0, 0, EmcResources.cInt(grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_cronograma"].Value.ToString()));
                 grdTarefas.DataSource = dtCon;
             }
         }

         #endregion
       
        private void frmOrcamentoObra_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
                 SendKeys.Send("{TAB}");

             if (e.KeyCode == Keys.F12)
                 CancelaOperacao();

             // if (e.KeyCode == Keys.F2)
             //  btnPesquisa_Click(null, null);
         }
               
        private void txtAbreviacao_Validating(object sender, CancelEventArgs e)
         {
             BuscaObra();
          
         }
               
        
        #region [Metodos para alterar a cor de fundo dos campos quando estiver em foco]

         private bool bolHighlightControlOnFocus = false;
         [Category("Focus")]
         [Description("Define se a cor de fundo de um campo é alterada sempre quando ele estiver em foco.")]
         [DisplayName("HighlightControlOnFocus")]
         public bool HighlightControlOnFocus
         {
             get { return bolHighlightControlOnFocus; }
             set { bolHighlightControlOnFocus = value; }
         }

         private void ConfiguraEnterComponente(object sender, EventArgs e)
         {
             if (sender is Control)
             {
                 Control controle = (Control)sender;
                 if (controle.Enabled)
                 {
                     controle.BackColor = Color.LightYellow;
                 }
             }
         }

         private void ConfiguraLeaveComponente(object sender, EventArgs e)
         {
             if (sender is Control)
             {
                 Control controle = (Control)sender;
                 if (controle.Enabled)
                 {
                     controle.BackColor = Color.White;
                 }
             }
         }

         private void ConfigurarFocoComponentes(Control controle)
         {
             // Configura o Enter e o Leave do componente
             if ((controle is MaskedTextBox) ||
                  (controle is ComboBox) ||
                  (controle is TextBox) ||
                  (controle is RichTextBox) ||
                  (controle is NumericUpDown))
             {
                 controle.Enter += this.ConfiguraEnterComponente;
                 controle.Leave += this.ConfiguraLeaveComponente;
             }

             if (controle is DateTimePicker)
             {
                 controle.Validated += this.ConfiguraLeaveComponente;
             }

             if (controle is ComboBox)
             {
                 ComboBox combo = (ComboBox)controle;
                 combo.DropDown += this.ConfiguraLeaveComponente;
             }

             // Chamada recursiva para configurar os controles filhos do item atual
             foreach (Control controleFilho in controle.Controls)
             {
                 this.ConfigurarFocoComponentes(controleFilho);
             }
         }


         #endregion

        #region [Metodos para definir se os campos ficam selecinados quando ganham foco]
         private bool bolAutoSelectOnFocus;

         [Category("Focus")]
         [Description("Ativa o método de AutoSelect dos campos da interface.")]
         [DisplayName("AutoSelectOnFocus")]
         public bool AutoSelectOnFocus
         {
             get { return bolAutoSelectOnFocus; }
             set { bolAutoSelectOnFocus = value; }
         }

         //___ Seleciona todo o texto de um controle. _______________________________________
         private void SelectText_Enter(object sender, System.EventArgs e)
         {
             // Executa o método de forma assíncrona - pois o MaskedTextBox já executa um
             // select no evento "Enter" do foco, que acaba desfazendo a seleção.
             this.BeginInvoke((MethodInvoker)delegate()
             {
                 if (sender is UpDownBase)
                 {
                     ((UpDownBase)sender).Select(0, ((UpDownBase)sender).Text.Length);
                 }
                 else if (sender is TextBoxBase)
                 {
                     ((TextBoxBase)sender).SelectAll();
                 }
             });
         }


         //__ Associa o evento "SelectText_Enter" a cada um dos campos com texto ____________ 
         private void DelegateEnterFocus(Control ctrl)
         {
             if ((ctrl is UpDownBase) || (ctrl is TextBoxBase))
             {
                 ctrl.Enter += SelectText_Enter;
                 return;
             }

             // Chamada recursiva para associar o evento a todos os controles da interface
             foreach (Control ctrlChild in ctrl.Controls)
             {
                 this.DelegateEnterFocus(ctrlChild);
             }
         }

         #endregion

         private void btnAprovaCronograma_Click(object sender, EventArgs e)
         {
             try
             {
                 /* Verifica Usuarios Aprovadores de Obra */
                 ParametroRN oParamDAO = new ParametroRN(Conexao,objOcorrencia,codempresa);
                 int nroAprovadores = EmcResources.cInt(oParamDAO.retParametro(codempresa, "EMCOBRAS", "OBRA", "NRO_APROVADORES"));

                 if (nroAprovadores == 0)
                 {
                     Exception oErro = new Exception("Não existem aprovadores cadastrados para está empresa.");
                     throw oErro;
                 }


                 bool resultadoUsuario = false;
                 for (int x = 1; x <= nroAprovadores; x++)
                 {
                     //string nroAprovador = EmcResources.FormatText(nroAprovadores.ToString(), "99", 2, EmcResources.eAlign.Esquerda);
                     string nroAprovador = EmcResources.MyFormat(x.ToString(), "00");
                     string chaveParametro = "USUARIO_APROVADOR"+nroAprovador.Trim();

                     if (EmcResources.cInt(oParamDAO.retParametro(codempresa, "EMCOBRAS", "OBRA", chaveParametro)) == EmcResources.cInt(usuario))
                     {
                         resultadoUsuario = true;
                     }
                 }

                 if (!resultadoUsuario)
                 {
                     MessageBox.Show("Usuário não tem permissão de aprovação de cronograma de obras.", "Aprova Cronograma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     DialogResult resultado = MessageBox.Show("Confirma aprovação do cronograma?", "Aprova Cronograma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (resultado == DialogResult.Yes)
                     {

                         Obra oObra = new Obra();
                         ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);

                         oObra.idObra_Cronograma = EmcResources.cInt(txtIdObra_Cronograma.Text);

                         oObra = oObraRN.obterPor(oObra);

                         oObra.situacao = "L";
                         oObra.aprovador_idUsuario = objOcorrencia.usuario;

                         oObraRN.alteraSituacaoObra(oObra);

                         MessageBox.Show("Cronograma Aprovado", "Aprova Cronograma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     else
                     {
                         MessageBox.Show("Aprovação Cancelada", "Aprova Cronograma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }

         }

        

       

        

    }
}
