using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurity;
using EMCSecurityModel;
using System.Collections;


namespace EMCCadastro
{
    public partial class frmHistorico : EMCLibrary.EMCForm
    {
        private const string descricao = "frmHistorico";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmHistorico()
        {
            InitializeComponent();
        }

         public frmHistorico(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void frmHistorico_Load(object sender, EventArgs e)
         {
             objOcorrencia = new Ocorrencia();
             Aplicativo oAplicativo = new Aplicativo();
             oAplicativo.nome = nomeAplicativo;
             objOcorrencia.aplicativo = oAplicativo;
             objOcorrencia.formulario = descricao;
             objOcorrencia.seqLogin = EmcResources.cInt(login);
             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario = EmcResources.cInt(usuario);
             objOcorrencia.usuario = oUsuario;
             objOcorrencia.tabela = "Historico";

             //inicializa combo de ordenação
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Sim", "S"));
            arr.Add(new popCombo("Não", "N"));
            cboExigeComplemento.DataSource = arr;
            cboExigeComplemento.DisplayMember = "nome";
            cboExigeComplemento.ValueMember = "valor";


             AtualizaGrid();
             this.ActiveControl = txtIdHistorico;
             CancelaOperacao();

         }

        #region "metodos para tratamento das informacoes*********************************************************************"
        
        private Boolean verificaHistorico(Historico oHistorico)
         {
             HistoricoRN oHistoricoRN = new HistoricoRN(Conexao, objOcorrencia,codempresa);
             try
             {
                 oHistoricoRN.VerificaDados(oHistorico);
                 return true;
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Historico: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return false;
             }
         }
        
        private Historico montaHistorico()
         {

             Historico oHistorico = new Historico();
             oHistorico.descricao = txtDescricao.Text;
             oHistorico.exigecomplemento = cboExigeComplemento.SelectedValue.ToString();

             return oHistorico;
         }
        
        private void montaTela(Historico oHistorico)
         {
             txtIdHistorico.Text = oHistorico.idHistorico.ToString();
             txtDescricao.Text = oHistorico.descricao;
             cboExigeComplemento.SelectedValue = oHistorico.exigecomplemento;

             objOcorrencia.chaveidentificacao = oHistorico.idHistorico.ToString();
             txtIdHistorico.ReadOnly = true;
             txtDescricao.Focus();

         }
         
        public override void AtivaEdicao()
         {
             base.AtivaEdicao();
             txtIdHistorico.Enabled = false;
         }
        
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
         {
             if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, descricao, btnFlag))
             {
                 return true;
             }
             else return false;
         }
        
        public override void Ocorrencia()
         {
             base.Ocorrencia();
             frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
             ofrm.ShowDialog();
         }
        
        public override void AtivaInsercao()
         {
             base.AtivaInsercao();

             txtIdHistorico.Enabled = false;
             txtDescricao.Focus();

         }
        
        public override void AtualizaTela()
         {
             base.AtualizaTela();
         }
        
        public override void CancelaOperacao()
         {
             base.CancelaOperacao();
             txtIdHistorico.Enabled = true;
             objOcorrencia.chaveidentificacao = "";
             txtIdHistorico.ReadOnly = false;
             txtIdHistorico.Focus();
         }

        public override void BuscaObjeto()
        {
            try
            {
                psqHistorico ofrm = new psqHistorico(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdTipoCobranca.Text = "";

                }
                else
                {
                    txtIdHistorico.Enabled = true;
                    txtIdHistorico.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdHistorico.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Histórico: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaHistorico()
        {

            if (!String.IsNullOrEmpty(txtIdHistorico.Text))
            {

                Historico oHistorico = new Historico();
                oHistorico.idHistorico = EmcResources.cInt(txtIdHistorico.Text);
                try
                {
                    HistoricoRN historicoBLL = new HistoricoRN(Conexao, objOcorrencia, codempresa);
                    oHistorico = historicoBLL.ObterPor(oHistorico);

                    if (oHistorico.idHistorico == 0)
                    {
                        DialogResult result = MessageBox.Show("Histórico não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            LimpaCampos();
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                    }
                    else
                    {
                        montaTela(oHistorico);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        public override void LimpaCampos()
         {
             base.LimpaCampos();
             objOcorrencia.chaveidentificacao = "";
             cboExigeComplemento.SelectedIndex = -1;
         }
         
        public override void SalvaObjeto()
         {
             try
             {
                 Historico oHistorico = new Historico();
                 HistoricoRN oHistoricoRN = new HistoricoRN(Conexao, objOcorrencia,codempresa);


                 oHistorico = montaHistorico();

                 if (verificaHistorico(oHistorico))
                 {
                     oHistoricoRN.Salvar(oHistorico);

                     LimpaCampos();
                     montaTela(oHistorico);
                     AtualizaGrid();
                 }

             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message);
             }
             //base.SalvaObjeto();
         }
         
        public override void AtualizaObjeto()
         {
             try
             {
                 Historico oHistorico = new Historico();
                 HistoricoRN oHistoricoRN = new HistoricoRN(Conexao, objOcorrencia,codempresa);

                 oHistorico = montaHistorico();
                 oHistorico.idHistorico = EmcResources.cInt(txtIdHistorico.Text);


                 if (verificaHistorico(oHistorico))
                 {

                     oHistoricoRN.Atualizar(oHistorico);

                     LimpaCampos();
                     //MessageBox.Show("Historico atualizado com sucesso");
                     AtualizaGrid();
                 }
                 else MessageBox.Show("Atualização cancelada");
                 montaTela(oHistorico);
             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message + " " + erro.StackTrace);
             }
             //base.AtualizaObjeto();
         }
        
        public override void ExcluiObjeto()
         {
             try
             {
                 Historico oHistorico = new Historico();
                 HistoricoRN oHistoricoRN = new HistoricoRN(Conexao, objOcorrencia,codempresa);
                 oHistorico = montaHistorico();
                 oHistorico.idHistorico = EmcResources.cInt(txtIdHistorico.Text);

                 if (verificaHistorico(oHistorico))
                 {
                     DialogResult result = MessageBox.Show("Confirma exclusão do Formulário ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (result == DialogResult.Yes)
                     {
                         oHistoricoRN.Excluir(oHistorico);

                         LimpaCampos();
                         MessageBox.Show("Formulário excluido!", "EMCtech");
                         AtualizaGrid();
                     }
                     else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                 }
             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message);
             }
             //base.ExcluiObjeto();
         }
                 
        public override void ImprimeObjeto()
         {
             try
             {
                 //base.ImprimeObjeto();
                 Relatorios.relHistorico ofrm = new Relatorios.relHistorico(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                 ofrm.ShowDialog();
             }
             catch (Exception e)
             {
                 MessageBox.Show("Erro Histórico: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }
       
        #endregion

         
        #region "Tratamentos para buttons e texts**************************************************************************************"

        private void txtIdHistorico_Validating(object sender, CancelEventArgs e)
         {
             BuscaHistorico();
         }
       
        #endregion
         
        #region "metodos da dbgrid*******************************************************************************************"
      
        private void grdHistorico_DoubleClick(object sender, EventArgs e)
         {
             txtIdHistorico.Enabled = true;
             txtIdHistorico.Text = grdHistorico.Rows[grdHistorico.CurrentRow.Index].Cells["idHistorico"].Value.ToString();
             txtIdHistorico.Focus();
             SendKeys.Send("{TAB}");
         }
         private void AtualizaGrid()
         {
             //carrega a grid com os ceps cadastrados
             HistoricoRN oHistoricoRN = new HistoricoRN(Conexao, objOcorrencia,codempresa);
             Historico oHistorico = new Historico();
             grdHistorico.DataSource = oHistoricoRN.ListaHistorico(oHistorico);

         }


         #endregion


    }
}
