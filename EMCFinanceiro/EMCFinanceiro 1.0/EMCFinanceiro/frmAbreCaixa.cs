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
    public partial class frmAbreCaixa : EMCLibrary.EMCForm
    {
        private const string descricao = "frmAbreCaixa";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmAbreCaixa()
        {
            InitializeComponent();
        }

         public frmAbreCaixa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void frmAbreCaixa_Load(object sender, EventArgs e)
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
        
        private Boolean verificaAbreCaixa(ControleCaixa oCaixa)
         {
             ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia,codempresa);
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
            CtaBancaria oConta = new CtaBancaria();
            oConta.codEmpresa = codempresa;
            oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
            CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oConta = oContaRN.ObterPor(oConta);

            oControleCaixa.contaBancaria = oConta;
            oControleCaixa.conferido = "N";
            oControleCaixa.dtHoraAbertura = Convert.ToDateTime(txtDtHoraAbertura.Text);
            oControleCaixa.saldoAbertura = EmcResources.cCur(txtSdoAbertura.Value.ToString());
            oControleCaixa.usuarioResponsavel = objOcorrencia.usuario.idUsuario;
            oControleCaixa.fechado = "N";
            
             return oControleCaixa;
         }
        
        private void montaTela(ControleCaixa oControleCaixa)
         {

            cboCtaBancaria.SelectedValue = oControleCaixa.contaBancaria.idCtaBancaria;
            txtDtHoraAbertura.Text = oControleCaixa.dtHoraAbertura.ToString();
            txtSdoAbertura.Text = oControleCaixa.saldoAbertura.ToString();

            UsuarioBLL oUserRN = new UsuarioBLL(Conexao);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = oControleCaixa.usuarioResponsavel;
            oUsuario = oUserRN.ObterPor(oUsuario);
            txtNomeUsuario.Text = oUsuario.nomeCompleto;

            objOcorrencia.chaveidentificacao = oControleCaixa.idControleCaixa.ToString();
            cboCtaBancaria.Focus();

         }
         
        public override void AtivaEdicao()
         {
             base.AtivaEdicao();
            
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
             txtNomeUsuario.Text = oUsuario.nomeCompleto;

             objOcorrencia.chaveidentificacao = "";

             AtivaInsercao();
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
        }
                
        public override void LimpaCampos()
         {
             base.LimpaCampos();
             objOcorrencia.chaveidentificacao = "";
            
         }
         
        public override void SalvaObjeto()
         {
             try
             {
                 ControleCaixa oControleCaixa = new ControleCaixa();
                 ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia,codempresa);


                 oControleCaixa = montaControleCaixa();

                 if (verificaAbreCaixa(oControleCaixa))
                 {
                     oControleCaixaRN.Salvar(oControleCaixa);

                     LimpaCampos();
                 }

             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message);
             }

         }
         
        public override void AtualizaObjeto()
         {
             try
             {
                 ControleCaixa oControleCaixa = new ControleCaixa();
                 ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia,codempresa);

                 oControleCaixa = montaControleCaixa();
                 oControleCaixa.idControleCaixa = EmcResources.cInt(txtIdControleCaixa.Text);


                 if (verificaAbreCaixa(oControleCaixa))
                 {

                     oControleCaixaRN.Atualizar(oControleCaixa);

                     LimpaCampos();
                     //MessageBox.Show("ControleCaixa atualizado com sucesso");
                     AtualizaGrid();
                 }
                 else MessageBox.Show("Atualização cancelada");
                 montaTela(oControleCaixa);
             }
             catch (Exception erro)
             {
                 MessageBox.Show(erro.Message + " " + erro.StackTrace);
             }

         }
        
        public override void ExcluiObjeto()
         {
             //try
             //{
             //    ControleCaixa oControleCaixa = new ControleCaixa();
             //    ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia,codempresa);
             //    oControleCaixa = montaControleCaixa();
             //    oControleCaixa.idControleCaixa = EmcResources.cInt(txtIdControleCaixa.Text);

             //    if (verificaAbreCaixa(oControleCaixa))
             //    {
             //        DialogResult result = MessageBox.Show("Confirma exclusão do Formulário ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             //        if (result == DialogResult.Yes)
             //        {
             //            oControleCaixaRN.Excluir(oControleCaixa);

             //            LimpaCampos();
             //            MessageBox.Show("Formulário excluido!", "EMCtech");
             //            AtualizaGrid();
             //        }
             //        else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
             //    }
             //}
             //catch (Exception erro)
             //{
             //    MessageBox.Show(erro.Message);
             //}
             //base.ExcluiObjeto();
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

        private void txtIdControleCaixa_Validating(object sender, CancelEventArgs e)
         {
             BuscaControleCaixa();
         }
       
        #endregion
         
        #region "metodos da dbgrid*******************************************************************************************"
      
        private void grdCaixa_DoubleClick(object sender, EventArgs e)
         {
             txtIdControleCaixa.Enabled = true;
             txtIdControleCaixa.Text = grdCaixa.Rows[grdCaixa.CurrentRow.Index].Cells["idCaixacontrole"].Value.ToString();
             txtIdControleCaixa.Focus();
             SendKeys.Send("{TAB}");
         }
         private void AtualizaGrid()
         {
             CtaBancaria oConta = new CtaBancaria();
             CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
             oConta.codEmpresa = codempresa;
             oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
             oConta = oContaRN.ObterPor(oConta);

             ControleCaixaRN oCtrCaixaRN = new ControleCaixaRN(Conexao,objOcorrencia,codempresa);

             grdCaixa.DataSource = oCtrCaixaRN.ListaControleCaixa(oConta);

         }


         #endregion

         private void cboCtaBancaria_ValueMemberChanged(object sender, EventArgs e)
         {
            
         }

         private void cboCtaBancaria_TextChanged(object sender, EventArgs e)
         {
            
         }

         private void cboCtaBancaria_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 if (cboCtaBancaria.SelectedValue.ToString() != "System.Data.DataRowView" )
                 {
                     //buscar saldo na conta bancaria
                     CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                     CtaBancaria oConta = new CtaBancaria();
                     oConta.codEmpresa = codempresa;
                     oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
                     oConta = oCtaBancariaRN.ObterPor(oConta);

                     txtSdoAbertura.Text = oConta.saldoAtual.ToString();

                     AtualizaGrid();
                 }

             }
             catch (Exception oErro)
             {
                 MessageBox.Show("Erro Abertura Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
         }


    }
}
