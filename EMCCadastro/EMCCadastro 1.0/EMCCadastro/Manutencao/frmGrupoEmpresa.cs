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
    public partial class frmGrupoEmpresa : EMCLibrary.EMCForm
    {
        private const string nomeGrupoEmpresa = "frmGrupoEmpresa";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmGrupoEmpresa()
        {
            InitializeComponent();
        }

        public frmGrupoEmpresa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void frmGrupoEmpresa_Load(object sender, EventArgs e)
         {
             objOcorrencia = new Ocorrencia();
             Aplicativo oAplicativo = new Aplicativo();
             oAplicativo.nome = nomeAplicativo;
             objOcorrencia.aplicativo = oAplicativo;
             objOcorrencia.formulario = nomeGrupoEmpresa;
             objOcorrencia.seqLogin = EmcResources.cInt(login);
             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario = EmcResources.cInt(usuario);
             objOcorrencia.usuario = oUsuario;
             objOcorrencia.tabela = "grupoempresa";

             Holding oHolding = new Holding();
             HoldingRN oHoldRN = new HoldingRN(Conexao, objOcorrencia,codempresa);

             cboHolding.DataSource = oHoldRN.ListaHolding(oHolding);
             cboHolding.ValueMember = "idholding";
             cboHolding.DisplayMember = "nomeholding";
             
             AtualizaGrid();
             this.ActiveControl = txtIdGrupoEmpresa;
             CancelaOperacao();

         }


         #region "metodos para tratamento das informacoes*********************************************************************"
        
        private Boolean verificaGrupoEmpresa(GrupoEmpresa oGrupoEmpresa)
         {
             GrupoEmpresaRN oGrupoEmpresaRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);
             try
             {
                 oGrupoEmpresaRN.VerificaDados(oGrupoEmpresa);
                 return true;
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Grupo Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return false;
             }
         }
         
        private GrupoEmpresa montaGrupoEmpresa()
         {

             GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();
             oGrupoEmpresa.nomeGrupoEmpresa = txtNomeGrupoEmpresa.Text;

             Holding oHold = new Holding();
             oHold.idHolding = EmcResources.cInt(cboHolding.SelectedValue.ToString());

             oGrupoEmpresa.holding = oHold;

             return oGrupoEmpresa;
         }
        
        private void montaTela(GrupoEmpresa oGrupoEmpresa)
         {
             txtIdGrupoEmpresa.Text = oGrupoEmpresa.idGrupoEmpresa.ToString();
             txtNomeGrupoEmpresa.Text = oGrupoEmpresa.nomeGrupoEmpresa;
             cboHolding.SelectedValue = oGrupoEmpresa.holding.idHolding;
             txtIdGrupoEmpresa.ReadOnly = true;
             txtNomeGrupoEmpresa.Focus();


             objOcorrencia.chaveidentificacao = oGrupoEmpresa.idGrupoEmpresa.ToString();

         }
         
        public override void AtivaEdicao()
         {
             base.AtivaEdicao();

             txtIdGrupoEmpresa.Enabled = false;
             txtNomeGrupoEmpresa.Focus();

         }
         
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
         {
             if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeGrupoEmpresa, btnFlag))
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
             txtIdGrupoEmpresa.Enabled = true;
             objOcorrencia.chaveidentificacao = "";
             txtIdGrupoEmpresa.ReadOnly = false;
             txtIdGrupoEmpresa.Focus();

         }

        public override void BuscaObjeto()
        {
            try
            {
                psqGrupoEmpresa ofrm = new psqGrupoEmpresa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdTipoCobranca.Text = "";

                }
                else
                {
                    txtIdGrupoEmpresa.Enabled = true;
                    txtIdGrupoEmpresa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdGrupoEmpresa.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Grupo Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaGrupoEmpresa()
        {

            if (!String.IsNullOrEmpty(txtIdGrupoEmpresa.Text))
            {

                GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();
                oGrupoEmpresa.idGrupoEmpresa = EmcResources.cInt(txtIdGrupoEmpresa.Text);
                try
                {
                    GrupoEmpresaRN grupoEmpresaBLL = new GrupoEmpresaRN(Conexao, objOcorrencia, codempresa);
                    oGrupoEmpresa = grupoEmpresaBLL.ObterPor(oGrupoEmpresa);

                    if (oGrupoEmpresa.idGrupoEmpresa == 0)
                    {
                        DialogResult result = MessageBox.Show("Grupo Empresa não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        montaTela(oGrupoEmpresa);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Grupo Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public override void LimpaCampos()
         {
             base.LimpaCampos();
             objOcorrencia.chaveidentificacao = "";
             cboHolding.SelectedIndex = -1;
             txtIdGrupoEmpresa.ReadOnly = true;
             txtNomeGrupoEmpresa.Focus();
         }
        
        public override void SalvaObjeto()
         {
             try
             {
                 GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();
                 GrupoEmpresaRN oGrupoEmpresaRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);


                 oGrupoEmpresa = montaGrupoEmpresa();

                 if (verificaGrupoEmpresa(oGrupoEmpresa))
                 {
                     oGrupoEmpresaRN.Salvar(oGrupoEmpresa);

                     LimpaCampos();
                     montaTela(oGrupoEmpresa);
                     AtualizaGrid();
                 }

             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Grupo Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            // base.SalvaObjeto();
         }
         
        public override void AtualizaObjeto()
         {
             try
             {
                 GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();
                 GrupoEmpresaRN oGrupoEmpresaRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);

                 oGrupoEmpresa = montaGrupoEmpresa();
                 oGrupoEmpresa.idGrupoEmpresa = EmcResources.cInt(txtIdGrupoEmpresa.Text);


                 if (verificaGrupoEmpresa(oGrupoEmpresa))
                 {

                     oGrupoEmpresaRN.Atualizar(oGrupoEmpresa);
                     LimpaCampos();
                     //MessageBox.Show("Grupo Empresa atualizado com sucesso");
                     AtualizaGrid();
                     
                 }
                 else MessageBox.Show("Atualização cancelada");
                 montaTela(oGrupoEmpresa);
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Grupo Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             base.AtualizaObjeto();
         }
        
        public override void ExcluiObjeto()
         {
             try
             {
                 GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();
                 GrupoEmpresaRN oGrupoEmpresaRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);
                 oGrupoEmpresa = montaGrupoEmpresa();
                 oGrupoEmpresa.idGrupoEmpresa = EmcResources.cInt(txtIdGrupoEmpresa.Text);

                 if (verificaGrupoEmpresa(oGrupoEmpresa))
                 {
                     DialogResult result = MessageBox.Show("Confirma exclusão do Grupo Empresa ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                     if (result == DialogResult.Yes)
                     {
                         oGrupoEmpresaRN.Excluir(oGrupoEmpresa);

                         LimpaCampos();
                         MessageBox.Show("Grupo Empresa excluido!", "EMCtech");
                         AtualizaGrid();
                     }
                     else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                 }
             }
             catch (Exception erro)
             {
                 MessageBox.Show("Erro Grupo Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             //base.ExcluiObjeto();
         }
       
       #endregion
         #region "Tratamentos para buttons e texts**************************************************************************************"

         private void txtIdGrupoEmpresa_Validating(object sender, CancelEventArgs e)
         {
             BuscaGrupoEmpresa();
         }
       #endregion
       
        #region "metodos da dbgrid*******************************************************************************************"
        
        private void grdGrupoEmpresa_DoubleClick(object sender, EventArgs e)
         {
             txtIdGrupoEmpresa.Enabled = true;
             txtIdGrupoEmpresa.Text = grdGrupoEmpresa.Rows[grdGrupoEmpresa.CurrentRow.Index].Cells["idgrupoempresa"].Value.ToString();
             txtIdGrupoEmpresa.Focus();
             SendKeys.Send("{TAB}");
        
         }
        
        private void AtualizaGrid()
         {
             //carrega a grid com os ceps cadastrados
             GrupoEmpresaRN oGrupoEmpresaRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);
             GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();

             grdGrupoEmpresa.DataSource = oGrupoEmpresaRN.ListaGrupoEmpresa(oGrupoEmpresa);

          }


         #endregion


    }
}
