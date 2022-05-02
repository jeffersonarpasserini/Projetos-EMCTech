using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmFormaPagamento : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFormaPagamento";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmFormaPagamento(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        public frmFormaPagamento()
        {
            InitializeComponent();
        }
               
        
        private void frmFormaPagamento_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "formapagamento";

            HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia,codempresa);
            Historico oHistorico = new Historico();
            cboHistoricoPadrao.DataSource = oHistRN.ListaHistorico(oHistorico);
            cboHistoricoPadrao.ValueMember = "idhistorico";
            cboHistoricoPadrao.DisplayMember = "descricao";

            AtualizaGrid();

            this.ActiveControl = txtIdFormaPagamento;
            CancelaOperacao();
        }

#endregion


#region "metodos para tratamento das informacoes"
     
        private FormaPagamento montaFormaPagamento()
        {
            FormaPagamento oFormaPagamento = new FormaPagamento();
            try
            {
                
                oFormaPagamento.descricao = txtDescricao.Text;
                oFormaPagamento.idFormaPagamento = EmcResources.cInt(txtIdFormaPagamento.Text);

                Historico oHistorico = new Historico();

                if (cboHistoricoPadrao.SelectedValue != null)
                {
                    oHistorico.idHistorico = EmcResources.cInt(cboHistoricoPadrao.SelectedValue.ToString());
                }
               
                oFormaPagamento.historicoPadrao = oHistorico;
            }
            catch (Exception erro) 
            {
                MessageBox.Show("Erro Forma de Pagamento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return oFormaPagamento;
        }
        
        private void montaTela(FormaPagamento oFormaPagamento)
        {
            txtDescricao.Text = oFormaPagamento.descricao;
            txtIdFormaPagamento.Text = oFormaPagamento.idFormaPagamento.ToString();
            cboHistoricoPadrao.SelectedValue = EmcResources.cInt(oFormaPagamento.historicoPadrao.idHistorico.ToString());
            
            objOcorrencia.chaveidentificacao = oFormaPagamento.idFormaPagamento.ToString();
            txtDescricao.Focus();
        }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
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
       
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtIdFormaPagamento.Enabled = false;
            
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
            objOcorrencia.chaveidentificacao = "";
            txtIdFormaPagamento.Enabled = true;
            txtIdFormaPagamento.ReadOnly = false;
            txtIdFormaPagamento.Focus();
        }

        public override void BuscaObjeto()
        {
            
            try
            {
                psqFormaPagamento ofrm = new psqFormaPagamento (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdFormaPagamento.Text = "";
                    
                }
                else
                {
                    txtIdFormaPagamento.Enabled = true;
                    txtIdFormaPagamento.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdFormaPagamento.Focus();
                    SendKeys.Send("{TAB}");
                 }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void BuscaFormaPagamento()
        {

            if (!String.IsNullOrEmpty(txtIdFormaPagamento.Text))
            {

                FormaPagamento oFormaPagamento = new FormaPagamento();
                oFormaPagamento.idFormaPagamento = EmcResources.cInt(txtIdFormaPagamento.Text);
                try
                {
                    FormaPagamentoRN FormaPagamentoBLL = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
                    oFormaPagamento = FormaPagamentoBLL.ObterPor(oFormaPagamento);

                    if (oFormaPagamento.idFormaPagamento == 0)
                    {
                        DialogResult result = MessageBox.Show("Forma de Pagamento não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        montaTela(oFormaPagamento);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Forma de Pagamento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdFormaPagamento.ReadOnly = true;
            txtDescricao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                FormaPagamento oFormaPagamento = new FormaPagamento();
                FormaPagamentoRN oFormaPagamentoBLL = new FormaPagamentoRN(Conexao,objOcorrencia,codempresa);
                oFormaPagamento = montaFormaPagamento();

                oFormaPagamentoBLL.Salvar(oFormaPagamento);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Forma de Pagamento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                FormaPagamento oFormaPagamento = new FormaPagamento();
                FormaPagamentoRN oFormaPagamentoBLL = new FormaPagamentoRN(Conexao,objOcorrencia,codempresa);
                oFormaPagamento = montaFormaPagamento();
                oFormaPagamento.idFormaPagamento = Convert.ToInt32(txtIdFormaPagamento.Text);
                                
                oFormaPagamentoBLL.Atualizar(oFormaPagamento);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Forma de Pagamento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                FormaPagamento oFormaPagamento = new FormaPagamento();
                FormaPagamentoRN oFormaPagamentoBLL = new FormaPagamentoRN(Conexao,objOcorrencia,codempresa);
                oFormaPagamento = montaFormaPagamento();
                oFormaPagamento.idFormaPagamento = Convert.ToInt32(txtIdFormaPagamento.Text);

                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Forma de Pagamento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relFormaPagamento ofrm = new Relatorios.relFormaPagamento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Forma Pagamento: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

      #region "metodos da dbgrid"

        private void grdFormaPagamento_DoubleClick(object sender, EventArgs e)
        {
            txtIdFormaPagamento.Enabled = true;
            txtIdFormaPagamento.Text = grdFormaPagamento.Rows[grdFormaPagamento.CurrentRow.Index].Cells["idFormaPagamento"].Value.ToString();
            txtIdFormaPagamento.Focus();
            SendKeys.Send("{TAB}");
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os FormaPagamentos cadastrados
            FormaPagamentoRN objFormaPagamento = new FormaPagamentoRN(Conexao,objOcorrencia,codempresa);
            grdFormaPagamento.DataSource = objFormaPagamento.ListaFormaPagamento();
        }

        #endregion
      
        private void txtIdFormaPagamento_Validating(object sender, CancelEventArgs e)
        {
            BuscaFormaPagamento();
        }


     }
}
