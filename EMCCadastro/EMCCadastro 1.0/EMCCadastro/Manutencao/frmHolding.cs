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

namespace EMCCadastro
{
    public partial class frmHolding : EMCLibrary.EMCForm
    {

        private const string nomeHolding = "frmHolding";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();


        public frmHolding()
        {
            InitializeComponent();
        }

         public frmHolding(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void frmHolding_Load(object sender, EventArgs e)
         {
             objOcorrencia = new Ocorrencia();
             Aplicativo oAplicativo = new Aplicativo();
             oAplicativo.nome = nomeAplicativo;
             objOcorrencia.aplicativo = oAplicativo;
             objOcorrencia.formulario = nomeHolding;
             objOcorrencia.seqLogin = EmcResources.cInt(login);
             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario = EmcResources.cInt(usuario);
             objOcorrencia.usuario = oUsuario;
             objOcorrencia.tabela = "holding";

             AtualizaGrid();
             this.ActiveControl = txtIdHolding;
             CancelaOperacao();

         }

#region "metodos para tratamento das informacoes*********************************************************************"
        
        private Boolean verificaHolding(Holding oHolding)
         {
             HoldingRN oHoldingRN = new HoldingRN(Conexao, objOcorrencia,codempresa);
             try
             {
                 oHoldingRN.VerificaDados(oHolding);
                 return true;
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Holding: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
             }
         }
       
        private Holding montaHolding()
         {

             Holding oHolding = new Holding();
             oHolding.nomeHolding = txtNomeHolding.Text;

             return oHolding;
         }
        
        private void montaTela(Holding oHolding)
         {
             txtIdHolding.Text = oHolding.idHolding.ToString();
             txtNomeHolding.Text = oHolding.nomeHolding;

             objOcorrencia.chaveidentificacao = oHolding.idHolding.ToString();
             txtIdHolding.ReadOnly = true;
             txtNomeHolding.Focus();


         }
        
        public override void AtivaEdicao()
         {
             base.AtivaEdicao();
             txtIdHolding.Enabled = false;
             
         }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
         {
             if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeHolding, btnFlag))
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

             txtIdHolding.Enabled = false;
             txtNomeHolding.Focus();

         }
        
        public override void AtualizaTela()
         {
             base.AtualizaTela();
         }
        
        public override void CancelaOperacao()
         {
             base.CancelaOperacao();
             txtIdHolding.Enabled = true;
             objOcorrencia.chaveidentificacao = "";
             txtIdHolding.Enabled = true;
             txtIdHolding.ReadOnly = false;
             txtIdHolding.Focus();
         }

        public override void BuscaObjeto()
        {

            try
            {
                psqHolding ofrm = new psqHolding(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdHolding.Text = "";

                }
                else
                {
                    txtIdHolding.Enabled = true;
                    txtIdHolding.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdHolding.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Holding: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaHolding()
        {

            if (!String.IsNullOrEmpty(txtIdHolding.Text))
            {

                Holding oHolding = new Holding();
                oHolding.idHolding = EmcResources.cInt(txtIdHolding.Text);
                try
                {
                    HoldingRN holdingBLL = new HoldingRN(Conexao, objOcorrencia, codempresa);
                    oHolding = holdingBLL.ObterPor(oHolding);

                    if (oHolding.idHolding == 0)
                    {
                        DialogResult result = MessageBox.Show("Holding não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        montaTela(oHolding);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Holding: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public override void LimpaCampos()
         {
             base.LimpaCampos();
             objOcorrencia.chaveidentificacao = "";
             txtIdHolding.ReadOnly = true;
             txtNomeHolding.Focus();
         }
        
        public override void SalvaObjeto()
         {
             try
             {
                 Holding oHolding = new Holding();
                 HoldingRN oHoldingRN = new HoldingRN(Conexao, objOcorrencia,codempresa);


                 oHolding = montaHolding();

                 if (verificaHolding(oHolding))
                 {
                     oHoldingRN.Salvar(oHolding);

                     LimpaCampos();
                     montaTela(oHolding);
                     AtualizaGrid();
                 }

             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Holding: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            // base.SalvaObjeto();
         }
         
        public override void AtualizaObjeto()
         {
             try
             {
                 Holding oHolding = new Holding();
                 HoldingRN oHoldingRN = new HoldingRN(Conexao, objOcorrencia,codempresa);

                 oHolding = montaHolding();
                 oHolding.idHolding = EmcResources.cInt(txtIdHolding.Text);
                 
                 if (verificaHolding(oHolding))
                 {
                     oHoldingRN.Atualizar(oHolding);

                     LimpaCampos();
                    // MessageBox.Show("Holding atualizado com sucesso");
                     AtualizaGrid();
                 }
                 //else MessageBox.Show("Atualização cancelada");
                 montaTela(oHolding);
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Holding: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             base.AtualizaObjeto();
         }
         
        public override void ExcluiObjeto()
         {
             try
             {
                 Holding oHolding = new Holding();
                 HoldingRN oHoldingRN = new HoldingRN(Conexao, objOcorrencia,codempresa);
                 oHolding = montaHolding();
                 oHolding.idHolding = EmcResources.cInt(txtIdHolding.Text);

                 if (verificaHolding(oHolding))
                 {
                     DialogResult result = MessageBox.Show("Confirma exclusão do Formulário ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (result == DialogResult.Yes)
                     {
                         oHoldingRN.Excluir(oHolding);

                         LimpaCampos();
                         MessageBox.Show("Formulário excluido!", "Mensagem");
                         AtualizaGrid();
                     }
                     else MessageBox.Show("Exclusão Cancelada!", "Mensagem");
                 }
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Holding: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             //base.ExcluiObjeto();
         }
         #endregion
         #region "Tratamentos para buttons e texts**************************************************************************************"

         private void txtIdHolding_Validating(object sender, CancelEventArgs e)
         {
             BuscaHolding();
         }
     
        #endregion
        
        #region "metodos da dbgrid*******************************************************************************************"
        
        private void grdHolding_DoubleClick(object sender, EventArgs e)
         {
             txtIdHolding.Enabled = true;
             txtIdHolding.Text = grdHolding.Rows[grdHolding.CurrentRow.Index].Cells["idHolding"].Value.ToString();
             txtIdHolding.Focus();
             SendKeys.Send("{TAB}");
       
         }
        
        private void AtualizaGrid()
         {
             //carrega a grid com os ceps cadastrados
             HoldingRN oHoldingRN = new HoldingRN(Conexao, objOcorrencia,codempresa);
             Holding oHolding = new Holding();

             grdHolding.DataSource = oHoldingRN.ListaHolding(oHolding);

         }
         #endregion
    }
}
