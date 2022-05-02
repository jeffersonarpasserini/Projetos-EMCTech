using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFaturamentoModel;
using EMCFaturamentoRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using MaskedNumber;


namespace EMCFaturamento
{
    public partial class frmFatu_NaturezaOperacao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_NaturezaOperacao";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();
          
        #region "metodos do form"

         public frmFatu_NaturezaOperacao()
        {
            InitializeComponent();
        }

         public frmFatu_NaturezaOperacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void frmFatu_NaturezaOperacao_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_NaturezaOperacao";

            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Fatu_NaturezaOperacao montaFatu_NaturezaOperacao()
        {
            Fatu_NaturezaOperacao oFatu_NaturezaOperacao = new Fatu_NaturezaOperacao();
            oFatu_NaturezaOperacao.descricao = txtDescricao.Text;
            oFatu_NaturezaOperacao.tipo = cboTipo.SelectedValue.ToString();

            Fatu_CFOPRN oCfOpRN = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);

            Fatu_CFOP oEstadual = new Fatu_CFOP();
            oEstadual.idfatu_cfop = EmcResources.cInt(txtIdEstadual.Text);
            oEstadual = oCfOpRN.ObterPor(oEstadual);
            oFatu_NaturezaOperacao.idCfopEstadual = oEstadual;

            Fatu_CFOP oInterEstadual = new Fatu_CFOP();
            oInterEstadual.idfatu_cfop = EmcResources.cInt(txtIdInterEstadual.Text);
            oInterEstadual = oCfOpRN.ObterPor(oInterEstadual);
            oFatu_NaturezaOperacao.idCfopInterestadual = oInterEstadual;

            Fatu_CFOP oExterior = new Fatu_CFOP();
            oExterior.idfatu_cfop =EmcResources.cInt(txtIdExterior.Text);
            oExterior = oCfOpRN.ObterPor(oExterior);
            oFatu_NaturezaOperacao.idCfopExterior = oExterior;

            return oFatu_NaturezaOperacao;
        }
        private void montaTela(Fatu_NaturezaOperacao oFatu_NaturezaOperacao)
        {
            txtDescricao.Text = oFatu_NaturezaOperacao.descricao;
            cboTipo.SelectedValue = oFatu_NaturezaOperacao.tipo;

            txtIdEstadual.Text = oFatu_NaturezaOperacao.idCfopEstadual.idfatu_cfop.ToString();
            txtNroCfopEstadual.Text = oFatu_NaturezaOperacao.idCfopEstadual.nrocfop;
            txtEstadual.Text = oFatu_NaturezaOperacao.idCfopEstadual.descricao;

            txtIdInterEstadual.Text = oFatu_NaturezaOperacao.idCfopInterestadual.idfatu_cfop.ToString();
            txtNroCfopInterEstadual.Text = oFatu_NaturezaOperacao.idCfopInterestadual.nrocfop;
            txtInterEstadual.Text = oFatu_NaturezaOperacao.idCfopInterestadual.descricao;
            
            txtIdExterior.Text = oFatu_NaturezaOperacao.idCfopExterior.idfatu_cfop.ToString();
            txtNroCfopExterior.Text = oFatu_NaturezaOperacao.idCfopExterior.nrocfop;
            txtExterior.Text = oFatu_NaturezaOperacao.idCfopExterior.descricao;

            
            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_NaturezaOperacao.idFatu_NaturezaOperacao.ToString();
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
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtDescricao.Focus();
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidFatu_NaturezaOperacao.Text))
            {

                Fatu_NaturezaOperacao oFatu_NaturezaOperacao = new Fatu_NaturezaOperacao();
                try
                {
                    Fatu_NaturezaOperacaoRN Fatu_NaturezaOperacaoBLL = new Fatu_NaturezaOperacaoRN(Conexao, objOcorrencia, codempresa);

                    oFatu_NaturezaOperacao = montaFatu_NaturezaOperacao();
                    oFatu_NaturezaOperacao.idFatu_NaturezaOperacao = Convert.ToInt32(txtidFatu_NaturezaOperacao.Text);

                    oFatu_NaturezaOperacao = Fatu_NaturezaOperacaoBLL.ObterPor(oFatu_NaturezaOperacao);

                    if (String.IsNullOrEmpty(oFatu_NaturezaOperacao.descricao))
                    {
                        MessageBox.Show("Natureza de Operação não Cadastrado", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_NaturezaOperacao);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_NaturezaOperacao: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            
            //montando combo's
            ArrayList arrEntradaSaida = new ArrayList();
            arrEntradaSaida.Add(new popCombo("Saída", "S"));
            arrEntradaSaida.Add(new popCombo("Entrada", "E"));
            
            cboTipo.DataSource = arrEntradaSaida;
            cboTipo.DisplayMember = "nome";
            cboTipo.ValueMember = "valor";
        }

        public override void SalvaObjeto()
        {
            try
            {

                Fatu_NaturezaOperacao oFatu_NaturezaOperacao = new Fatu_NaturezaOperacao();
                Fatu_NaturezaOperacaoRN oFatu_NaturezaOperacaoBLL = new Fatu_NaturezaOperacaoRN(Conexao, objOcorrencia,codempresa);
                oFatu_NaturezaOperacao = montaFatu_NaturezaOperacao();

                oFatu_NaturezaOperacaoBLL.Salvar(oFatu_NaturezaOperacao);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                txtDescricao.Focus();
            }
           
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Fatu_NaturezaOperacao oFatu_NaturezaOperacao = new Fatu_NaturezaOperacao();
                Fatu_NaturezaOperacaoRN oFatu_NaturezaOperacaoBLL = new Fatu_NaturezaOperacaoRN(Conexao, objOcorrencia,codempresa);
                oFatu_NaturezaOperacao = montaFatu_NaturezaOperacao();
                oFatu_NaturezaOperacao.idFatu_NaturezaOperacao = Convert.ToInt32(txtidFatu_NaturezaOperacao.Text);

                oFatu_NaturezaOperacaoBLL.Atualizar(oFatu_NaturezaOperacao);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                txtDescricao.Focus();
            }
            
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Fatu_NaturezaOperacao oFatu_NaturezaOperacao = new Fatu_NaturezaOperacao();
                Fatu_NaturezaOperacaoRN oFatu_NaturezaOperacaoBLL = new Fatu_NaturezaOperacaoRN(Conexao, objOcorrencia,codempresa);
                oFatu_NaturezaOperacao = montaFatu_NaturezaOperacao();
                oFatu_NaturezaOperacao.idFatu_NaturezaOperacao = Convert.ToInt32(txtidFatu_NaturezaOperacao.Text);

                oFatu_NaturezaOperacaoBLL.Excluir(oFatu_NaturezaOperacao);
               
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                txtDescricao.Focus();
            }
            
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdFatu_NaturezaOperacao_DoubleClick(object sender, EventArgs e)
        {
            //carregando os dados da grid nos campos da tela
            txtidFatu_NaturezaOperacao.Text = grdNaturezaOperacao.Rows[grdNaturezaOperacao.CurrentRow.Index].Cells["idfatu_naturezaoperacao"].Value.ToString();
            txtidFatu_NaturezaOperacao.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_NaturezaOperacaoRN objFatu_NaturezaOperacao = new Fatu_NaturezaOperacaoRN(Conexao, objOcorrencia,codempresa);
            grdNaturezaOperacao.DataSource = objFatu_NaturezaOperacao.ListaFatu_NaturezaOperacao();
        }

        #endregion

        #region [Texts]
        private void txtidFatu_NaturezaOperacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }
        
        private void txtNroCfopEstadual_Validating(object sender, CancelEventArgs e)
        {
             try
            {
                if (EmcResources.cInt(txtNroCfopEstadual.Value.ToString()) > 0)
                {
                    Fatu_CFOP oCfop = new Fatu_CFOP();
                    oCfop.nrocfop = txtNroCfopEstadual.Value.ToString();

                    Fatu_CFOPRN oCfopRN = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
                    oCfop = oCfopRN.ObterPor(oCfop);

                    if (oCfop.idfatu_cfop == 0)
                    {
                        MessageBox.Show("CFOP não encontrado", "EMCFaturamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtEstadual.Text = oCfop.descricao;
                        txtNroCfopEstadual.Text = oCfop.nrocfop;
                        txtIdEstadual.Text = oCfop.idfatu_cfop.ToString();
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMCFaturamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNroCfopInterEstadual_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtNroCfopInterEstadual.Value.ToString()) > 0)
                {
                    Fatu_CFOP oCfop = new Fatu_CFOP();
                    oCfop.nrocfop = txtNroCfopInterEstadual.Value.ToString();

                    Fatu_CFOPRN oCfopRN = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
                    oCfop = oCfopRN.ObterPor(oCfop);

                    if (oCfop.idfatu_cfop == 0)
                    {
                        MessageBox.Show("CFOP não encontrado", "EMCFaturamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtInterEstadual.Text = oCfop.descricao;
                        txtNroCfopInterEstadual.Text = oCfop.nrocfop;
                        txtIdInterEstadual.Text = oCfop.idfatu_cfop.ToString();
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMCFaturamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNroCfopExterior_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (EmcResources.cInt(txtNroCfopExterior.Value.ToString()) > 0)
                {
                    Fatu_CFOP oCfop = new Fatu_CFOP();
                    oCfop.nrocfop = txtNroCfopExterior.Value.ToString();

                    Fatu_CFOPRN oCfopRN = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
                    oCfop = oCfopRN.ObterPor(oCfop);

                    if (oCfop.idfatu_cfop == 0)
                    {
                        MessageBox.Show("CFOP não encontrado", "EMCFaturamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtExterior.Text = oCfop.descricao;
                        txtNroCfopExterior.Text = oCfop.nrocfop;
                        txtIdExterior.Text = oCfop.idfatu_cfop.ToString();

                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMCFaturamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

    }
}
