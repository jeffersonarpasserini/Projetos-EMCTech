using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCFinanceiroRN;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroRN;

namespace EMCFinanceiro
{
    public partial class frmConfereCaixa : EMCLibrary.EMCForm
    {
        private const string descricao = "frmConfereCaixa";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmConfereCaixa()
        {
            InitializeComponent();
        }

         public frmConfereCaixa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }


         private void frmConfereCaixa_Load(object sender, EventArgs e)
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
             objOcorrencia.tabela = "caixacontrole";

             this.ActiveControl = cboCtaBancaria;
             CancelaOperacao();

         }

         #region "metodos para tratamento das informacoes*********************************************************************"

         private Boolean verificaFechaCaixa(ControleCaixa oCaixa)
         {
             ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
             try
             {
                 oControleCaixaRN.VerificaDados(oCaixa);
                 return true;
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Caixa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return false;
             }
         }

         private ControleCaixa montaControleCaixa()
         {
             ControleCaixa oControleCaixa = new ControleCaixa();
             try
             {
                 ControleCaixaRN oCtrRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
                 oControleCaixa.idControleCaixa = EmcResources.cInt(txtIdControleCaixa.Text);

                 oControleCaixa = oCtrRN.ObterPor(oControleCaixa);
                 oControleCaixa.conferido = "S";
                 oControleCaixa.dtHoraConferencia = DateTime.Now;
                 oControleCaixa.usuarioConferencia = EmcResources.cInt(usuario);

             }
             catch (Exception oErro)
             {
                 MessageBox.Show("Erro Fechamento Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             return oControleCaixa;
         }

         private void montaTela(ControleCaixa oControleCaixa)
         {

             cboCtaBancaria.SelectedValue = oControleCaixa.contaBancaria.idCtaBancaria;
             
             //txtSdoAbertura.Text = oControleCaixa.saldoAbertura.ToString();

             UsuarioBLL oUserRN = new UsuarioBLL(Conexao);
             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario = oControleCaixa.usuarioResponsavel;
             oUsuario = oUserRN.ObterPor(oUsuario);
             //txtNomeUsuario.Text = oUsuario.nomeCompleto;

             objOcorrencia.chaveidentificacao = oControleCaixa.idControleCaixa.ToString();
             cboCtaBancaria.Focus();

         }

         public override void AtivaEdicao()
         {
             base.AtivaEdicao();
             travaBotao("btnSalvar");
             travaBotao("btnExcluir");
             travaBotao("btnBusca");
             travaBotao("btnNovo");
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
         }

         public override void AtualizaTela()
         {
             base.AtualizaTela();
         }

         public override void CancelaOperacao()
         {
             base.CancelaOperacao();

             CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
             CtaBancaria oConta = new CtaBancaria();
             oConta.codEmpresa = codempresa;
             cboCtaBancaria.DataSource = oCtaBancariaRN.ListaCtaCaixa(oConta);
             cboCtaBancaria.DisplayMember = "descricao";
             cboCtaBancaria.ValueMember = "idctabancaria";

             Usuario oUsuario = new Usuario();
             UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao);
             oUsuario.idUsuario = EmcResources.cInt(usuario);
             oUsuario = oUsuarioRN.ObterPor(oUsuario);

             txtUsuarioResponsavel.Text = oUsuario.nomeCompleto;

             objOcorrencia.chaveidentificacao = "";

             AtivaEdicao();

             if (cboCtaBancaria.SelectedIndex > -1)
             {
                 AtualizaGridAbertura();
                 atualizaGridMovimento(0);
             }
             
         }

         public override void LimpaCampos()
         {
             //base.LimpaCampos();
             objOcorrencia.chaveidentificacao = "";

             txtSaldoCaixa.Text = "0";
             txtSdoCtaCaixa.Text = "0";
             txtUsuarioResponsavel.Text = "";
             txtIdControleCaixa.Text = "";
             chkFechaCaixa.Checked = false;
         }

         public override void BuscaObjeto()
         {
             //try
             //{
             //    psqControleCaixa ofrm = new psqControleCaixa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
             //    ofrm.ShowDialog();

             //    if (EMCCadastro.retPesquisa.chaveinterna == 0)
             //    {
             //        //txtIdTipoCobranca.Text = "";

             //    }
             //    else
             //    {
             //        txtIdControleCaixa.Enabled = true;
             //        txtIdControleCaixa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
             //        txtIdControleCaixa.Focus();
             //        SendKeys.Send("{TAB}");
             //    }
             //}
             //catch (Exception erro)
             //{
             //    MessageBox.Show("Erro Histórico: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //}
         }

         public void BuscaControleCaixa()
         {
             /*
             if (!String.IsNullOrEmpty(txtIdControleCaixa.Text))
             {

                 ControleCaixa oControleCaixa = new ControleCaixa();
                 oControleCaixa.idControleCaixa = EmcResources.cInt(txtIdControleCaixa.Text);
                 try
                 {
                     ControleCaixaRN ControleCaixaBLL = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
                     oControleCaixa = ControleCaixaBLL.ObterPor(oControleCaixa);

                     if (oControleCaixa.idControleCaixa == 0)
                     {
                         DialogResult result = MessageBox.Show("Controle Caixa não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                         montaTela(oControleCaixa);
                         AtivaEdicao();
                     }
                 }
                 catch (Exception erro)
                 {
                     MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
              */
         }

         public override void SalvaObjeto()
         {
            

         }

         public override void AtualizaObjeto()
         {
             try
             {
                 if (chkFechaCaixa.Checked)
                 {
                     ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
                     oControleCaixaRN.Atualizar(montaControleCaixa());
                     CancelaOperacao();
                 }
                 else
                     MessageBox.Show("Para fechar um caixa é preciso marcar a caixa de fecha caixa, concordando com o fechamento", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message);
             }

         }

         public override void ExcluiObjeto()
         {
             
         }

         public override void ImprimeObjeto()
         {
             //try
             //{
             //    //base.ImprimeObjeto();
             //    Relatorios.relControleCaixa ofrm = new Relatorios.relControleCaixa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
             //    ofrm.ShowDialog();
             //}
             //catch (Exception e)
             //{
             //    MessageBox.Show("Erro Histórico: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             //}
         }

         #endregion


         #region "Tratamentos para buttons e texts**************************************************************************************"


         #endregion

         #region "metodos da dbgrid*******************************************************************************************"

         private void grdAberturas_DoubleClick(object sender, EventArgs e)
         {

             try
             {
                 txtIdControleCaixa.Text = grdAberturas.Rows[grdAberturas.CurrentRow.Index].Cells["idcaixacontrole"].Value.ToString();
                 atualizaGridMovimento(EmcResources.cInt(txtIdControleCaixa.Text));

                 calculaSaldoCaixa();

             }
             catch(Exception oErro)
             {
                 MessageBox.Show("Erro Fechamento Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             
         }
         private void grdAberturas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
            

          
                 
         }
         private void grdAberturas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
         {
             grdAberturas.CommitEdit(DataGridViewDataErrorContexts.Commit);
         }

         private void AtualizaGridAbertura()
         {
             CtaBancaria oConta = new CtaBancaria();
             CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
             oConta.codEmpresa = codempresa;
             oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
             oConta = oContaRN.ObterPor(oConta);

             ControleCaixaRN oCtrCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);

             grdAberturas.DataSource = oCtrCaixaRN.ListaConfereCaixa(oConta);

         }

        private void atualizaGridMovimento(int idControleCaixa)
         {
             
             MovimentoBancarioRN oMvBancoRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
             grdMovimento.DataSource = oMvBancoRN.listaControleCaixa(idControleCaixa);

         }

         #endregion

         private void cboCtaBancaria_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 if (cboCtaBancaria.SelectedValue.ToString() != "System.Data.DataRowView")
                 {
                     //buscar saldo na conta bancaria
                     CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                     CtaBancaria oConta = new CtaBancaria();
                     oConta.codEmpresa = codempresa;
                     oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
                     oConta = oCtaBancariaRN.ObterPor(oConta);

                     txtSdoCtaCaixa.Text = oConta.saldoAtual.ToString();

                     AtualizaGridAbertura();
                 }

             }
             catch (Exception oErro)
             {
                 MessageBox.Show("Erro Fechamento Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }

         public void calculaSaldoCaixa()
         {
             try
             {
                 MovimentoBancarioRN oMovRN = new MovimentoBancarioRN(Conexao,objOcorrencia,codempresa);

                 if (!String.IsNullOrEmpty(txtIdControleCaixa.Text))
                 {
                     txtSaldoCaixa.Text = oMovRN.calculaSdoCtrCaixa(EmcResources.cInt(txtIdControleCaixa.Text)).ToString();
                 }

             }
             catch(Exception oErro)
             {
                 MessageBox.Show("Erro Fechamento Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
                 
                
              
         }
    }
}
